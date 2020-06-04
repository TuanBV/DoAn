using System;
using System.Collections.Generic;
using System.ComponentModel;
using sys = System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Xml;
//Nếu bị lỗi
using System.Data.SQLite;
//chuot phai pj->manage NuGet packages->browser->tìm Newtonsoft.Json->install
// hoặc View -> Other Windows -> Package Manager Console.
// chay:   Install-Package Newtonsoft.Json -Version 12.0.2
//https://www.newtonsoft.com/json/help/html/Introduction.htm
using Newtonsoft.Json;

using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using ZedGraph;

namespace HMI
{
    public partial class Control : Form
    {
        SQLiteConnection sqlite_conn = new SQLiteConnection("Data Source=E:\\new.db; Version = 3; New = True; Compress = True;");

        int i = 0;
        int x = -1;
        string InputData = String.Empty; // Khai báo string buff dùng cho hiển thị dữ liệu sau này.
        delegate void SetTextCallback(string text); // Khai bao delegate SetTextCallBack voi tham so string
        string[] BaudRate = { "1200", "2400", "4800", "9600", "19200", "38400", "57600", "115200" };
        string[] DeviceList = { "1", "2", "3" };
        string[] ListType = { "1", "0" };
        string[] ListTypeName = { "Dữ liệu", "Điều khiển" };
        string[] ListData = { "0", "1", "10", "50", "255" };
        string[] ListControl = { "red", "green", "blue", "motor", "temp", "humi", "light" };
        ZedGraph.GraphPane graphPane;
        PointPairList line1 = new PointPairList();

        public Control()
        {
            InitializeComponent();
            // Khai báo hàm delegate bằng phương thức DataReceived của Object SerialPort;
            // khi có sự kiện nhận dữ liệu sẽ nhảy đến phương thức DataReceive
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceive);

            //tab 1
            cbx_rate.Items.AddRange(BaudRate);
            cbx_device.Items.AddRange(DeviceList);
            cbx_type_data.Items.AddRange(ListType);
            cbx_data_send.Items.AddRange(ListData);
            cbx_device_control.Items.AddRange(ListControl);
            cbx_device_control.Text = "1";


            //tab 2
            cbx_namedevice.Items.AddRange(DeviceList);
            cbx_type.Text = "Dữ liệu";
            cbx_type.Items.AddRange(ListTypeName);
            cbx_namecambien.Items.AddRange(ListControl);

            // ZedGraph
            graphPane = zedGraphControl.GraphPane;
            graphPane.AddCurve(null, line1, Color.Blue);

            sqlite_conn = CreateConnection();
            ReadSQL(sqlite_conn);
        }
        private SQLiteConnection CreateConnection()
        {
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Connect to DB." + ex.ToString());
            }
            return sqlite_conn;
        }
        private void InsertData(SQLiteConnection conn, String name, int type, float data, String device)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "insert into data(name, type, data, device) values('" + name + "', " + type + ", " + data + ", '" + device + "')";
            sqlite_cmd.ExecuteNonQuery();
            
        }
        private void ReadSQL(SQLiteConnection conn)
        {
            try
            {
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM data where name='"+ cbx_namecambien.SelectedItem +"' order by timestamp desc";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

                sys.DataTable dt = new sys.DataTable();
                da.Fill(dt);
                table_data.DataSource = dt;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }

        }
        private void Control_Load(object sender, EventArgs e)
        {
            cbx_com.DataSource = SerialPort.GetPortNames();
            cbx_rate.SelectedIndex = 3;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                label5.Text = ("Chưa kết nối với Gateway");
                label5.ForeColor = Color.Red;
            }
            else if (serialPort1.IsOpen)
            {
                label5.Text = ("Đã kết nối Gateway");
                label5.ForeColor = Color.Green;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            ReadSQL(sqlite_conn);

        }
        private string GetSelectedName()
        {
            try
            {
                string name = "";
                cbx_namecambien.Invoke(new MethodInvoker(delegate
                {
                    if (cbx_namecambien.SelectedItem != null)
                        name = cbx_namecambien.SelectedItem.ToString();
                }));
                return name;
            }
            catch (Exception ss)
            {
            }
            return "";
        }
        private void SetText_test(string text)
        {
            try
            {
                if (this.txt_receive_2.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText_test); // tạo 1 delegate mới gọi đến SetText
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.txt_receive_2.Text += text;
                }
            }
            catch (Exception ss)
            {
            }
        }
        string ttx = "";
        private void DataReceive(object obj, SerialDataReceivedEventArgs e)
        {
            try
            {
                InputData = serialPort1.ReadExisting();
                if (ttx.IndexOf("}") >= 0 || string.IsNullOrEmpty(InputData)) ttx = "";
                ttx += InputData;
                if (InputData.IndexOf("}") == -1) return;
                SetText(ttx);
                if (ttx.IndexOf("}") == -1) return;
                if (string.IsNullOrEmpty(ttx)) return;
                InputData = ttx;
                ttx = "";
                Dictionary<string, string> json = JsonConvert.DeserializeObject<Dictionary<string, string>>(InputData);
                if (string.IsNullOrEmpty(json["a"].ToString())) return;
                if (string.IsNullOrEmpty(json["d"].ToString())) return;
                {
                    {
                        {
                            {
                                DateTime now = DateTime.Now;
                                string aa = json["a"].ToString();
                                if (!string.IsNullOrEmpty(aa))
                                {
                                    int bb = Int32.Parse(json["b"].ToString());
                                    float cc = float.Parse(json["c"].ToString());
                                    string dd = json["d"].ToString();
                                    InsertData(sqlite_conn, aa, bb, cc, dd);
                                    string txt = aa.ToString() + "       " + bb.ToString() + "       " + cc.ToString() + "       " + dd.ToString() + "       " + now.ToString() + Environment.NewLine;
                                    SetText_test(txt);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ss)
            {
                //MessageBox.Show("Có lỗi" + ss.ToString());
            }
        }

        private void SetText(string text)
        {
            try
            {
                if (this.txt_receive.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText); // tạo 1 delegate mới gọi đến SetText
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    //this.txt_receive.Text = text;
                    this.txt_receive.Text += text;
                }
            }
            catch (Exception ss)
            {
            }
        }

        private void SetLine(double value)
        {
            try
            {
                zedGraphControl.Invoke(new MethodInvoker(delegate
                {
                    x += 1;
                    line1.Add(new PointPair(x, value));
                    graphPane.XAxis.Scale.Max = x;
                    graphPane.YAxis.Scale.Max = value*2;
                    zedGraphControl.Refresh();
                }));    
            }
            catch (Exception ss)
            {
            }
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!serialPort1.IsOpen)
                {
                    serialPort1.PortName = cbx_com.Text;
                    serialPort1.BaudRate = Convert.ToInt32(cbx_rate.Text);
                    serialPort1.Open();
                    MessageBox.Show("Kết nối thành công");
                }
            }
            catch (Exception ss)
            {
                MessageBox.Show("Kiểm tra lại kết nối với Gateway hoặc khởi động lại chương trình và Gateway");
            }
        }

        private void btn_disconnnect_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }
        String a = "{\"a\":\"";//tên biến: van, cb,...
        String b = "\",\"b\":";//kiểu dữ liệu: 0-mac dinh-dl, 1-dieu khien
        String c = ",\"c\":";//dữ liệu:.... neu la dieu khien thi chi co 0 va 1
        String d = ",\"d\":";//tên thiết bị: 1, 2, 3,...
        String end = "}";
        String z = "";
        private void btn_send_Click(object sender, EventArgs e)
        {
            try
            {
                z = a + this.cbx_device_control.Text + b + this.cbx_type_data.Text + c + this.cbx_data_send.Text + d + this.cbx_device.Text;
                cbx_data_sent.Items.Add(z);
                cbx_data_sent.Text = z;
                serialPort1.Write(z);
                //this.txt_receive.Text += i.ToString() + "\t";
                i++;    
            }
            catch (Exception ss)
            {

            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.txt_receive_2.Text = "";
            this.txt_receive.Text = "";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            btn_disconnnect_Click(sender, e);
            sqlite_conn.Close();
            this.Close();
        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            btn_disconnnect_Click(sender, e);
            Control_Load(sender, e);
            btn_connect_Click(sender, e);
            btn_clear_Click(sender, e);
        }



        private void XuatExcel()
        {
            try
            {
                string saveExcelFile = @"E:\\excel_report.xlsx";

                Excel.Application xlApp = new Excel.Application();

                if (xlApp == null)
                {
                    MessageBox.Show("Lỗi không thể sử dụng được thư viện EXCEL");
                    return;
                }
                xlApp.Visible = false;

                object misValue = System.Reflection.Missing.Value;

                Workbook wb = xlApp.Workbooks.Add(misValue);

                Worksheet ws = (Worksheet)wb.Worksheets[1];

                if (ws == null)
                {
                    MessageBox.Show("Không thể tạo được WorkSheet");
                    return;
                }
                int row = 1;
                string fontName = "Times New Roman";
                int fontSizeTieuDe = 18;
                int fontSizeTenTruong = 14;
                int fontSizeNoiDung = 12;
                //Xuất dòng Tiêu đề của File báo cáo: Lưu ý 
                Range row1= ws.get_Range("A1", "F1");
                row1.Merge();
                row1.Font.Size = fontSizeTieuDe;
                row1.Font.Name = fontName;
                row1.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row1.Value2 = "Thu thập dữ liệu giám sát";

                //STT - ID
                Range row23_STT = ws.get_Range("A2", "A2");
                row23_STT.Font.Size = fontSizeTenTruong;
                row23_STT.Font.Name = fontName;
                row23_STT.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_STT.Value2 = "ID";

                //Tạo tên dữ liệu :
                Range row23_MaSP = ws.get_Range("B2", "B2");
                row23_MaSP.Font.Size = fontSizeTenTruong;
                row23_MaSP.Font.Name = fontName;
                row23_MaSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_MaSP.Value2 = "Trường dữ liệu";
                row23_MaSP.ColumnWidth = 20;

                //Kiểu dữ liệu :
                Range row23_TenSP = ws.get_Range("C2", "C2");
                row23_TenSP.Font.Size = fontSizeTenTruong;
                row23_TenSP.Font.Name = fontName;
                row23_TenSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row23_TenSP.ColumnWidth = 20;
                row23_TenSP.Value2 = "Kiểu dữ liệu";

                //Dữ liệu :
                Range row2_GiaSP = ws.get_Range("D2", "D2");
                row2_GiaSP.Font.Size = fontSizeTenTruong;
                row2_GiaSP.Font.Name = fontName;
                row2_GiaSP.Cells.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                row2_GiaSP.Value2 = "Dữ liệu";

                //Thiết bị:
                Range row2_GiaNhap = ws.get_Range("E2", "E2");
                row2_GiaNhap.Font.Size = fontSizeTenTruong;
                row2_GiaNhap.Font.Name = fontName;
                row2_GiaNhap.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row2_GiaNhap.Value2 = "Thiết bị";
                row2_GiaNhap.ColumnWidth = 20;

                //Timestamp
                Range row2_f = ws.get_Range("F2", "F2");
                row2_f.Font.Size = fontSizeTenTruong;
                row2_f.Font.Name = fontName;
                row2_f.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                row2_f.Value2 = "Thời gian";
                row2_f.ColumnWidth = 20;

                //Tô nền vàng các cột tiêu đề:
                Range row23_CotTieuDe = ws.get_Range("A2", "F2");
                //nền vàng
                row23_CotTieuDe.Interior.Color = ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                //in đậm
                row23_CotTieuDe.Font.Bold = true;
                //chữ đen
                row23_CotTieuDe.Font.Color = ColorTranslator.ToOle(System.Drawing.Color.Black);

                row = 2;

                /*
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM data";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

                SQLiteDataReader sd;
                sd = sqlite_cmd.ExecuteReader();
                //MessageBox.Show(sqlite_datareader.ToString());
                */
                SQLiteCommand sqlite_cmd;
                sqlite_cmd = sqlite_conn.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM data order by timestamp desc";
                SQLiteDataAdapter da = new SQLiteDataAdapter(sqlite_cmd);

                sys.DataTable dt = new sys.DataTable();
                da.Fill(dt);

                foreach (sys.DataRow rr in dt.Rows)
                {
                    row++;
                    //string myreader = sqlite_datareader.GetString(0);
                    //if(row == 3) MessageBox.Show(rr[5].ToString());
                    Range rowData = ws.get_Range("A" + row, "A" + row);//Lấy dòng thứ row ra để đổ dữ liệu
                    //rowData.Font.Size = fontSizeNoiDung;
                    //rowData.Font.Name = fontName;
                    //MessageBox.Show(dt.Rows[0][1].ToString());
                    rowData.Value2 = rr[0];
                     rowData = ws.get_Range("B" + row, "B" + row);
                    rowData.Value2 = rr[1];
                     rowData = ws.get_Range("C" + row, "C" + row);
                    rowData.Value2 = rr[2];
                     rowData = ws.get_Range("D" + row, "D" + row);
                    rowData.Value2 = rr[3];
                     rowData = ws.get_Range("E" + row, "E" + row);
                    rowData.Value2 = rr[4];
                     rowData = ws.get_Range("F" + row, "F" + row);
                    rowData.Value2 = rr[5];
                }
                //Kẻ khung
                BorderAround(ws.get_Range("A2", "F" + row));

                //Lưu file excel xuống Ổ cứng
                wb.SaveAs(saveExcelFile);

                //đóng file để hoàn tất quá trình lưu trữ
                wb.Close(true, misValue, misValue);
                //thoát và thu hồi bộ nhớ cho COM
                xlApp.Quit();
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xlApp);

                //Mở File excel sau khi Xuất thành công
                System.Diagnostics.Process.Start(saveExcelFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        //Hàm kẻ khung cho Excel
        private void BorderAround(Range range)
        {
            Borders borders = range.Borders;
            borders[XlBordersIndex.xlEdgeLeft].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeTop].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeBottom].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlEdgeRight].LineStyle = XlLineStyle.xlContinuous;
            borders.Color = Color.Black;
            borders[XlBordersIndex.xlInsideVertical].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlInsideHorizontal].LineStyle = XlLineStyle.xlContinuous;
            borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
            borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
        }
        //Hàm thu hồi bộ nhớ cho COM Excel
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            { GC.Collect(); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }
        int dk = 0;
        private void btnBom_Click(object sender, EventArgs e)
        {
            if(this.btnBom.Text == "Bật")
            {
                btnBom.Text = "Tắt";
                dk = 0;
            }
            else
            {
                btnBom.Text = "Bật";
                dk = 1;
            }
            z = a + "motor" + b + "1" + c + dk + d + "1" + end;
            serialPort1.Write(z);
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            ReadSQL(sqlite_conn);
        }

        private void cbx_namecambien_SelectedIndexChanged(object sender, EventArgs e)
        {
            x = -1;
            graphPane.XAxis.Scale.Max = 0;
            line1.Clear();
            zedGraphControl.Refresh();
        }

        private void BtnAuToBom_Click(object sender, EventArgs e)
        {
            string str = DateTime.Now.Date.ToString();
            MessageBox.Show(str);
        }
    }

}

