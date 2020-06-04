#include <SPI.h>              // include libraries
#include <LoRa.h>
#include <ArduinoJson.h>
/*
 * So do noi chan WEMOS
 * 
 * **LORA** xx Arduino
 * 3.3V/Vcc xx    3.3 V
 * Gnd      xx    Gnd
 * En/Nss   xx    D10 <duoc doi chan>
 * G0/D0    xx    ....<khong dung>
 * SCK      xx    D13
 * MISO     xx    D12/MISO
 * MOSI     xx    D11/MOSI
 * RST      xx    D9 <duoc doi chan>
 * 
 * 
 * **LORA** xx WEMOS
 * 3.3V/Vcc xx    3.3 V
 * Gnd      xx    Gnd
 * En/Nss   xx    D8 <duoc doi chan>
 * G0/D0    xx    ....<khong dung>
 * SCK      xx    D5
 * MISO     xx    D6/MISO/D10
 * MOSI     xx    D7/MOSI/D9
 * RST      xx    D4 <duoc doi chan>
 * override the default CS, reset, and IRQ pins (optional)
 * trong ham setup
 * LoRa.setPins(CS, RESET<, IRQ>);// cho module thuong
 * LoRa.setPins(10, 9, 8);// cho module thuong
 * LoRa.setPins(8, 7); //cho shield
 * LoRa.setPins(D8, D4); //cho WEMOS
*/
// đổi kit wemos thành kit arduino thì bỏ D trước khai báo chân là được, và ngược lại
const int csPin = D8;          // chân kết nối với LoRa chip
const int resetPin = D4;       // chân reset
const int irqPin = -1;         // kết nối nếu muốn dùng đến dự kiện ngắt, không sử dụng đến

byte msgCount = 0;            // biến đếm số lượng tin đã gửi/ ID tin nhắn
byte this_device = 0;         // tên thiết bị
long lastSendTime = 0;        // thời gian gửi cuối
int interval = 2000;          // set thời gian gửi định kỳ


StaticJsonDocument<128> root;//cho send
StaticJsonDocument<128> groot;//cho receive

void setup() {
  Serial.begin(9600);                   // Khởi tạo kết nối tới Serial
  Serial.println("LoRa Server start!!");

  //thiết lập các chân kết nối tới module LoRa CS, reset, and IRQ pins (tùy chọn)
  LoRa.setPins(csPin, resetPin);// set CS, reset

  if (!LoRa.begin(433E6)) {             // khởi tạo kết nối tần số 433 MHz
    Serial.println("LoRa init failed. Check your connections.");
    while (true);                       // khởi tạo lỗi, kết thúc
  }

  Serial.println("LoRa init succeeded.");
}

String a = ""; //tên biến
int b = 0; // kiểu dữ liệu
float c = 0; // dữ liệu
int d = -1; // thiết bị
String json = "";

void loop() {
    docSerial(); //đọc dữ liệu gửi về từ Serial-HMI
    if(a != "" && a != NULL) {
        //serializeJson(root, Serial);
        Serial.println();
        json = "{\"a\":\"" + String(a) + "\",\"b\":" + String(b) + ",\"c\":" + String(c) + "}";
        sendMessage(json, d);
        json = "";
    }
  //nhận dữ liệu từ module LoRa
  onReceive(LoRa.parsePacket());
}

void docSerial() {
    json = "";
    while (Serial.available() > 0) {
        json = Serial.readString();
    }
    if(json != "" && json != NULL) {
      deserializeJson(root, json);
      //deserializeJson(root, Serial);
      const char* a1 = root["a"];
      a = a1;
      b = root["b"];
      c = root["c"];
      d = root["d"];
    } else {
      a = "";
    }
}

void sendMessage(String outgoing, int to_device) {
  LoRa.beginPacket();                   // bắt đầu 1 gói tin
  LoRa.write(to_device);              // địa chỉ thiết bị -nhận- tín hiệu
  LoRa.write(this_device);             // địa chỉ thiết bị -phát- tín hiệu
  LoRa.write(msgCount);                 // ID tin nhắn
  LoRa.write(outgoing.length());        // độ dài payload
  LoRa.print(outgoing);                 // nội dung tin nhắn gửi
  LoRa.endPacket();                     // kết thúc gói tin và tiến hành gửi
  msgCount++;                           // tăng ID
  Serial.println(outgoing);
}

void onReceive(int packetSize) {
  if (packetSize == 0) return;          // nếu không có tín hiệu gói tin nào thì kết thúc hàm
  // đọc gói tin được truyền đến
  int recipient = LoRa.read();          // địa chỉ thiết bị nhận
  int sender = LoRa.read();            // địa chỉ thiết bị gửi
  int incomingMsgId = LoRa.read();     // đọc ID
  int incomingLength = LoRa.read();    // đọc thông tin về độ dài tin nhắn
  String incoming = "";
  while (LoRa.available()) {
    //deserializeJson(doc, json);
    incoming += (char)LoRa.read();
  }
  if (incomingLength != incoming.length()) {   // kiểm tra chiều dài chuỗi nhận về thỏa mãn hay không
    Serial.println("Do dai chuoi nhan ve khong hop le.");
    return;                             // không thỏa mãn thì kết thúc hàm
  }
  // kiểm tra xem gói tin gửi cho thiết bị nào
  if (recipient != this_device) {
    Serial.println("Tin nhan cua thiet bi khac.");
    return;                             // không thỏa mãn thì kết thúc hàm
  }
  // như vậy là đã xác nhận gói tin gửi cho thiết bị này
  deserializeJson(groot, incoming);
  groot["d"] = sender;
  //in dữ liệu lên Serial-HMI
  serializeJson(groot, Serial);
  Serial.println();
  
  // if message is for this device, or broadcast, print details:
  //Serial.print(incoming);
  //đọc thông tin tín hiệu lora
  //Serial.println("RSSI: " + String(LoRa.packetRssi()));
  //Serial.println("Snr: " + String(LoRa.packetSnr()));
}
