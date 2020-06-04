namespace HMI
{
    partial class Control
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btn_close = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_connect = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btn_disconnnect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbx_rate = new System.Windows.Forms.ComboBox();
            this.cbx_com = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btn_load = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cbx_type = new System.Windows.Forms.ComboBox();
            this.cbx_namecambien = new System.Windows.Forms.ComboBox();
            this.cbx_namedevice = new System.Windows.Forms.ComboBox();
            this.table_data = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_receive_2 = new System.Windows.Forms.TextBox();
            this.lblBom = new System.Windows.Forms.Label();
            this.btnBom = new System.Windows.Forms.Button();
            this.txt_receive = new System.Windows.Forms.TextBox();
            this.btn_clear = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cbx_data_sent = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbx_type_data = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbx_device_control = new System.Windows.Forms.ComboBox();
            this.cbx_data_send = new System.Windows.Forms.ComboBox();
            this.cbx_device = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.BtnAuToBom = new System.Windows.Forms.Button();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_data)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(1134, 13);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 21;
            this.btn_close.Text = "close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(360, 169);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Test dữ liệu sent";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(666, 12);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(76, 24);
            this.btn_connect.TabIndex = 6;
            this.btn_connect.Text = "Kết nối";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(225, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Chưa kết nối";
            // 
            // btn_disconnnect
            // 
            this.btn_disconnnect.Location = new System.Drawing.Point(667, 39);
            this.btn_disconnnect.Name = "btn_disconnnect";
            this.btn_disconnnect.Size = new System.Drawing.Size(75, 26);
            this.btn_disconnnect.TabIndex = 7;
            this.btn_disconnnect.Text = "Ngắt kết nối";
            this.btn_disconnnect.UseVisualStyleBackColor = true;
            this.btn_disconnnect.Click += new System.EventHandler(this.btn_disconnnect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Trạng thái :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(448, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Baud Rate :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "COM :";
            // 
            // cbx_rate
            // 
            this.cbx_rate.FormattingEnabled = true;
            this.cbx_rate.Location = new System.Drawing.Point(512, 39);
            this.cbx_rate.Name = "cbx_rate";
            this.cbx_rate.Size = new System.Drawing.Size(121, 21);
            this.cbx_rate.TabIndex = 2;
            // 
            // cbx_com
            // 
            this.cbx_com.FormattingEnabled = true;
            this.cbx_com.Location = new System.Drawing.Point(512, 12);
            this.cbx_com.Name = "cbx_com";
            this.cbx_com.Size = new System.Drawing.Size(121, 21);
            this.cbx_com.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 206);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhận dữ liệu";
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(1134, 42);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_refresh.TabIndex = 23;
            this.btn_refresh.Text = "Refresh";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btn_load);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.cbx_type);
            this.tabPage2.Controls.Add(this.cbx_namecambien);
            this.tabPage2.Controls.Add(this.cbx_namedevice);
            this.tabPage2.Controls.Add(this.table_data);
            this.tabPage2.Controls.Add(this.zedGraphControl);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1501, 693);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Xem dữ liệu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(164, 126);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(76, 24);
            this.btn_load.TabIndex = 28;
            this.btn_load.Text = "Load Data";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(164, 70);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 24);
            this.button2.TabIndex = 26;
            this.button2.Text = "Làm mới";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(164, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 24);
            this.button1.TabIndex = 25;
            this.button1.Text = "Xuất Excel";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(62, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Kiểu dữ liệu";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Chọn tên cảm biến ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Chọn thiết bị";
            // 
            // cbx_type
            // 
            this.cbx_type.FormattingEnabled = true;
            this.cbx_type.Location = new System.Drawing.Point(7, 126);
            this.cbx_type.Name = "cbx_type";
            this.cbx_type.Size = new System.Drawing.Size(121, 21);
            this.cbx_type.TabIndex = 3;
            // 
            // cbx_namecambien
            // 
            this.cbx_namecambien.FormattingEnabled = true;
            this.cbx_namecambien.Location = new System.Drawing.Point(6, 78);
            this.cbx_namecambien.Name = "cbx_namecambien";
            this.cbx_namecambien.Size = new System.Drawing.Size(121, 21);
            this.cbx_namecambien.TabIndex = 3;
            this.cbx_namecambien.SelectedIndexChanged += new System.EventHandler(this.cbx_namecambien_SelectedIndexChanged);
            // 
            // cbx_namedevice
            // 
            this.cbx_namedevice.FormattingEnabled = true;
            this.cbx_namedevice.Location = new System.Drawing.Point(6, 25);
            this.cbx_namedevice.Name = "cbx_namedevice";
            this.cbx_namedevice.Size = new System.Drawing.Size(121, 21);
            this.cbx_namedevice.TabIndex = 2;
            // 
            // table_data
            // 
            this.table_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Type,
            this.Column3,
            this.Column4,
            this.Column5});
            this.table_data.Location = new System.Drawing.Point(529, 35);
            this.table_data.Name = "table_data";
            this.table_data.Size = new System.Drawing.Size(743, 184);
            this.table_data.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "id";
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "name";
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            // 
            // Type
            // 
            this.Type.DataPropertyName = "type";
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "data";
            this.Column3.HeaderText = "Data";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "device";
            this.Column4.HeaderText = "Device";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "timestamp";
            this.Column5.HeaderText = "Timestamp";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Location = new System.Drawing.Point(7, 294);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(1412, 378);
            this.zedGraphControl.TabIndex = 0;
            this.zedGraphControl.UseExtendedPrintDialog = true;
            this.zedGraphControl.Load += new System.EventHandler(this.zedGraphControl1_Load);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnAuToBom);
            this.tabPage1.Controls.Add(this.txt_receive_2);
            this.tabPage1.Controls.Add(this.lblBom);
            this.tabPage1.Controls.Add(this.btnBom);
            this.tabPage1.Controls.Add(this.txt_receive);
            this.tabPage1.Controls.Add(this.btn_clear);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cbx_data_sent);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cbx_type_data);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.btn_send);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.cbx_device_control);
            this.tabPage1.Controls.Add(this.cbx_data_send);
            this.tabPage1.Controls.Add(this.cbx_device);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1501, 693);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Điều khiển";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_receive_2
            // 
            this.txt_receive_2.AllowDrop = true;
            this.txt_receive_2.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_receive_2.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txt_receive_2.Location = new System.Drawing.Point(638, 106);
            this.txt_receive_2.Multiline = true;
            this.txt_receive_2.Name = "txt_receive_2";
            this.txt_receive_2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_receive_2.Size = new System.Drawing.Size(585, 428);
            this.txt_receive_2.TabIndex = 24;
            this.txt_receive_2.UseWaitCursor = true;
            // 
            // lblBom
            // 
            this.lblBom.AutoSize = true;
            this.lblBom.Location = new System.Drawing.Point(11, 76);
            this.lblBom.Name = "lblBom";
            this.lblBom.Size = new System.Drawing.Size(28, 13);
            this.lblBom.TabIndex = 22;
            this.lblBom.Text = "Bơm";
            // 
            // btnBom
            // 
            this.btnBom.Location = new System.Drawing.Point(82, 71);
            this.btnBom.Name = "btnBom";
            this.btnBom.Size = new System.Drawing.Size(91, 23);
            this.btnBom.TabIndex = 21;
            this.btnBom.Text = "Bật";
            this.btnBom.UseVisualStyleBackColor = true;
            this.btnBom.Click += new System.EventHandler(this.btnBom_Click);
            // 
            // txt_receive
            // 
            this.txt_receive.AllowDrop = true;
            this.txt_receive.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txt_receive.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            this.txt_receive.Location = new System.Drawing.Point(0, 106);
            this.txt_receive.Multiline = true;
            this.txt_receive.Name = "txt_receive";
            this.txt_receive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_receive.Size = new System.Drawing.Size(585, 428);
            this.txt_receive.TabIndex = 0;
            this.txt_receive.UseWaitCursor = true;
            // 
            // btn_clear
            // 
            this.btn_clear.Location = new System.Drawing.Point(1118, 60);
            this.btn_clear.Name = "btn_clear";
            this.btn_clear.Size = new System.Drawing.Size(75, 23);
            this.btn_clear.TabIndex = 20;
            this.btn_clear.Text = "clear";
            this.btn_clear.UseVisualStyleBackColor = true;
            this.btn_clear.Click += new System.EventHandler(this.btn_clear_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(322, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(42, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Thiết bị";
            // 
            // cbx_data_sent
            // 
            this.cbx_data_sent.FormattingEnabled = true;
            this.cbx_data_sent.Location = new System.Drawing.Point(951, 33);
            this.cbx_data_sent.Name = "cbx_data_sent";
            this.cbx_data_sent.Size = new System.Drawing.Size(242, 21);
            this.cbx_data_sent.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(216, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Dữ liệu";
            // 
            // cbx_type_data
            // 
            this.cbx_type_data.FormattingEnabled = true;
            this.cbx_type_data.Location = new System.Drawing.Point(114, 35);
            this.cbx_type_data.Name = "cbx_type_data";
            this.cbx_type_data.Size = new System.Drawing.Size(78, 21);
            this.cbx_type_data.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(111, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Kiểu dữ liệu";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(426, 33);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(75, 23);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "send";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Thiết bị điều khiển";
            // 
            // cbx_device_control
            // 
            this.cbx_device_control.FormattingEnabled = true;
            this.cbx_device_control.Location = new System.Drawing.Point(5, 35);
            this.cbx_device_control.Name = "cbx_device_control";
            this.cbx_device_control.Size = new System.Drawing.Size(88, 21);
            this.cbx_device_control.TabIndex = 9;
            this.cbx_device_control.Text = "x";
            // 
            // cbx_data_send
            // 
            this.cbx_data_send.FormattingEnabled = true;
            this.cbx_data_send.Location = new System.Drawing.Point(219, 35);
            this.cbx_data_send.Name = "cbx_data_send";
            this.cbx_data_send.Size = new System.Drawing.Size(77, 21);
            this.cbx_data_send.TabIndex = 12;
            // 
            // cbx_device
            // 
            this.cbx_device.FormattingEnabled = true;
            this.cbx_device.Location = new System.Drawing.Point(325, 35);
            this.cbx_device.Name = "cbx_device";
            this.cbx_device.Size = new System.Drawing.Size(73, 21);
            this.cbx_device.TabIndex = 10;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1509, 719);
            this.tabControl1.TabIndex = 22;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // BtnAuToBom
            // 
            this.BtnAuToBom.Location = new System.Drawing.Point(219, 71);
            this.BtnAuToBom.Name = "BtnAuToBom";
            this.BtnAuToBom.Size = new System.Drawing.Size(121, 23);
            this.BtnAuToBom.TabIndex = 25;
            this.BtnAuToBom.Text = "Tưới Tự Động";
            this.BtnAuToBom.UseVisualStyleBackColor = true;
            this.BtnAuToBom.Click += new System.EventHandler(this.BtnAuToBom_Click);
            // 
            // Control
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1523, 773);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_disconnnect);
            this.Controls.Add(this.btn_connect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbx_rate);
            this.Controls.Add(this.cbx_com);
            this.Controls.Add(this.label1);
            this.Name = "Control";
            this.Text = "Điều khiển hệ thống cấp nước";
            this.Load += new System.EventHandler(this.Control_Load);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table_data)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_com;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbx_rate;
        private System.Windows.Forms.Label label3;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_disconnnect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbx_namecambien;
        private System.Windows.Forms.ComboBox cbx_namedevice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_receive;
        private System.Windows.Forms.Button btn_clear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbx_data_sent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbx_type_data;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbx_device_control;
        private System.Windows.Forms.ComboBox cbx_data_send;
        private System.Windows.Forms.ComboBox cbx_device;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbx_type;
        private System.Windows.Forms.Button btnBom;
        private System.Windows.Forms.Label lblBom;
        private System.Windows.Forms.TextBox txt_receive_2;
        private System.Windows.Forms.DataGridView table_data;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button BtnAuToBom;
    }
}

