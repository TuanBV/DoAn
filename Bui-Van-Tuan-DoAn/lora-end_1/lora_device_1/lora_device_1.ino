#include <SimpleDHT.h>
#include <SPI.h>              // include libraries
#include <LoRa.h>
#include <ArduinoJson.h>
/*
   So do noi chan arduino nong nghiep thong minh

   DHT   D7
   Relay D4  => DK bom nuoc, su dung nguon nuoi 12V
   Blue  D3
   Green D5
   Red   D6
   Quang tro A0


 * **LORA** xx Arduino
   3.3V/Vcc xx    3.3 V
   Gnd      xx    Gnd
   En/Nss   xx    D10 <duoc doi chan>
   G0/D0    xx    ....<khong dung>
   SCK      xx    D13
   MISO     xx    D12/MISO
   MOSI     xx    D11/MOSI
   RST      xx    D9 <duoc doi chan>

   override the default CS, reset, and IRQ pins (optional)
   trong ham setup
   LoRa.setPins(CS, RESET<, IRQ>);// cho module thuong
   LoRa.setPins(10, 9, 8);// cho module thuong
   LoRa.setPins(8, 7); //cho shield
   LoRa.setPins(D8, D4); //cho WEMOS
*/
// đổi kit wemos thành kit arduino thì bỏ D trước khai báo chân là được, và ngược lại
const int csPin = 10;          // chân kết nối với LoRa chip
const int resetPin = 9;       // chân reset
const int irqPin = -1;         // kết nối nếu muốn dùng đến dự kiện ngắt, không sử dụng đến

byte msgCount = 0;            // biến đếm số lượng tin đã gửi/ ID tin nhắn
byte this_device = 1;         // tên thiết bị
byte gateway = 0;

int set_time = 10000; // chu kỳ gửi data
long s1 = 2000;          // thời gian gửi định kỳ 1
long s2 = 3000;          // thời gian gửi định kỳ 2
long s3 = 4000;          // thời gian gửi định kỳ 3
long s4 = 5000;          // thời gian gửi định kỳ 4

int k1 = 0;
int k2 = 0;
int k3 = 0;
int k4 = 0;

StaticJsonDocument<128> root;

int pinDHT11 = 7;
SimpleDHT11 dht11(pinDHT11);

int red   = 6;
int blue  = 3;
int green = 5;


int relay      = 4;
int quangtro   = A0;
//
int nhietdo    = 0;
int doam       = 0;
int brightness = 0;
int fadeAmount = 10;

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

  pinMode(relay, OUTPUT);
  pinMode(red,   OUTPUT);
  pinMode(green, OUTPUT);
  pinMode(blue,  OUTPUT);
  digitalWrite(relay, HIGH);

}

String a = ""; //tên biến
int b = 0; // kiểu dữ liệu
float c = 0; // dữ liệu
int d = -1; // thiết bị
String json = "";

void loop() {
  // danh sach data-ten bien { "red", "green", "blue", "motor", "temp", "humi", "light"};
  if (millis() - s1 >= set_time) { //gui thong tin sau thời gian đã quy định
    a = "temp";
    b = 0;
    if (docDHT(nhietdo, doam)) Serial.println("DHT: OK");
    c = nhietdo;
    json = "{\"a\":\"" + String(a) + "\",\"b\":" + String(b) + ",\"c\":" + String(c, 2) + "}";
    sendMessage(json, gateway);
    Serial.println("Sending " + json);
    s1 = millis();
  }
  if (millis() - s2 >= set_time) { //gui thong tin sau thời gian đã quy định
    a = "humi";// a = "total";
    b = 0;
    if (docDHT(nhietdo, doam)) Serial.println("DHT: OK");
    c = doam;
    json = "{\"a\":\"" + String(a) + "\",\"b\":" + String(b) + ",\"c\":" + String(c, 2) + "}";
    sendMessage(json, gateway);
    Serial.println("Sending " + json);
    s2 = millis();
  }
  if (millis() - s3 >= set_time) { //gui thong tin sau thời gian đã quy định
    a = "light";
    b = 0;
    c = docQuangTro(quangtro);;
    json = "{\"a\":\"" + String(a) + "\",\"b\":" + String(b) + ",\"c\":" + String(c, 2) + "}";
    sendMessage(json, gateway);
    Serial.println("Sending " + json);
    s3 = millis();
  }

  //nhận dữ liệu từ module LoRa
  onReceive(LoRa.parsePacket());
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

String a1 = ""; //tên biến
int b1 = 0; // kiểu dữ liệu
float c1 = 0; // dữ liệu
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
  // xác nhận tin nhắn hợp lệ thì kiểm tra nội dung để điều khiển và in ra màn hình để kiểm tra
  deserializeJson(root, incoming);
  serializeJson(root, Serial);//in lên màn hình

  //Sau này tách thành hàm điều khiển riêng ra
  const char* a2 = root["a"];
  a1 = a2;
  b1 = root["b"];
  c1 = root["c"];
  if (b1 == 0) return; //không phải tín hiệu điều khiển
  if (a1 == "motor") {
    if (c1 == 1)
      digitalWrite(relay, HIGH);
    if (c1 == 0)
      digitalWrite(relay, LOW);
    return;
  }
  if (a1 == "red") {
    analogWrite(red, c1);
    return;
  }
  if (a1 == "blue") {
    analogWrite(blue, c1);
    return;
  }
  if (a1 == "green") {
    analogWrite(green, c1);
    return;
  }
}

int docDHT(int &t, int &h) {
  byte temperature = 0;
  byte humidity = 0;
  int err = SimpleDHTErrSuccess;
  if ((err = dht11.read(&temperature, &humidity, NULL)) != SimpleDHTErrSuccess) {
    Serial.print("Read DHT11 failed, err="); Serial.println(err); 
    return 0;
  }

  Serial.print("Sample OK: ");
  Serial.print((int)temperature); Serial.print(" *C, ");
  Serial.print((int)humidity); Serial.println(" H");
  t = temperature;
  h = humidity;
  return 1;
}

float docQuangTro(int zz) {
  return analogRead(zz);
}
