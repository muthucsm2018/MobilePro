namespace MobilePro
{
    partial class frmServiceBillAdd
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
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TechRemark = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbPasswordType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbStatusCode = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbOutSourceCode = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.IMEINo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ModelNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ContactNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbBrandCode = new System.Windows.Forms.ComboBox();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.NetAmount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ServiceDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsuspend = new System.Windows.Forms.Button();
            this.btnsettle = new System.Windows.Forms.Button();
            this.btnsettleprint = new System.Windows.Forms.Button();
            this.btnreprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cmbNatureFault = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(7, 28);
            this.lblTitle.Size = new System.Drawing.Size(202, 25);
            this.lblTitle.Text = "New Service Bill";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(631, 653);
            this.btnClose.Size = new System.Drawing.Size(130, 35);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Back (Esc)";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(500, 653);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 35);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "&Save (Ctrl + S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cmbNatureFault);
            this.panel1.Controls.Add(this.TechRemark);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.cmbPasswordType);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cmbStatusCode);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.cmbOutSourceCode);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.IMEINo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ModelNo);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ContactNo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbBrandCode);
            this.panel1.Controls.Add(this.CustomerName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.NetAmount);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ServiceDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BillNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(1, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 566);
            this.panel1.TabIndex = 6;
            // 
            // TechRemark
            // 
            this.TechRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TechRemark.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.TechRemark.Location = new System.Drawing.Point(13, 281);
            this.TechRemark.Multiline = true;
            this.TechRemark.Name = "TechRemark";
            this.TechRemark.Size = new System.Drawing.Size(738, 76);
            this.TechRemark.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(206, 16);
            this.label14.TabIndex = 57;
            this.label14.Text = "COMMENTS TO TECHNICIAN";
            // 
            // Password
            // 
            this.Password.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Password.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.Password.Location = new System.Drawing.Point(497, 220);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(196, 25);
            this.Password.TabIndex = 9;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(503, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 16);
            this.label13.TabIndex = 55;
            this.label13.Text = "PASSWORD";
            // 
            // cmbPasswordType
            // 
            this.cmbPasswordType.DropDownHeight = 166;
            this.cmbPasswordType.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbPasswordType.FormattingEnabled = true;
            this.cmbPasswordType.IntegralHeight = false;
            this.cmbPasswordType.Location = new System.Drawing.Point(225, 220);
            this.cmbPasswordType.Name = "cmbPasswordType";
            this.cmbPasswordType.Size = new System.Drawing.Size(251, 25);
            this.cmbPasswordType.TabIndex = 8;
            this.cmbPasswordType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPasswordType_KeyDown);
            this.cmbPasswordType.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cbo_KeyPress);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(228, 201);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(129, 16);
            this.label11.TabIndex = 54;
            this.label11.Text = "PASSWORD TYPE";
            // 
            // cmbStatusCode
            // 
            this.cmbStatusCode.DropDownHeight = 166;
            this.cmbStatusCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbStatusCode.FormattingEnabled = true;
            this.cmbStatusCode.IntegralHeight = false;
            this.cmbStatusCode.Location = new System.Drawing.Point(10, 220);
            this.cmbStatusCode.Name = "cmbStatusCode";
            this.cmbStatusCode.Size = new System.Drawing.Size(198, 25);
            this.cmbStatusCode.TabIndex = 7;
            this.cmbStatusCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatusCode_KeyDown);
            this.cmbStatusCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cbo_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(13, 201);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 16);
            this.label10.TabIndex = 52;
            this.label10.Text = "STATUS";
            // 
            // cmbOutSourceCode
            // 
            this.cmbOutSourceCode.DropDownHeight = 166;
            this.cmbOutSourceCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbOutSourceCode.FormattingEnabled = true;
            this.cmbOutSourceCode.IntegralHeight = false;
            this.cmbOutSourceCode.Location = new System.Drawing.Point(709, 220);
            this.cmbOutSourceCode.Name = "cmbOutSourceCode";
            this.cmbOutSourceCode.Size = new System.Drawing.Size(284, 25);
            this.cmbOutSourceCode.TabIndex = 10;
            this.cmbOutSourceCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbOutSourceCode_KeyDown);
            this.cmbOutSourceCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cbo_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(713, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 16);
            this.label9.TabIndex = 50;
            this.label9.Text = "OUT SOURCE";
            // 
            // IMEINo
            // 
            this.IMEINo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.IMEINo.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.IMEINo.Location = new System.Drawing.Point(226, 154);
            this.IMEINo.Name = "IMEINo";
            this.IMEINo.Size = new System.Drawing.Size(284, 25);
            this.IMEINo.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(223, 135);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 16);
            this.label5.TabIndex = 47;
            this.label5.Text = "IMEI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(503, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 16);
            this.label8.TabIndex = 45;
            this.label8.Text = "NATURE FAULT";
            // 
            // ModelNo
            // 
            this.ModelNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ModelNo.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.ModelNo.Location = new System.Drawing.Point(224, 95);
            this.ModelNo.Name = "ModelNo";
            this.ModelNo.Size = new System.Drawing.Size(252, 25);
            this.ModelNo.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(228, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 43;
            this.label7.Text = "MODEL";
            // 
            // ContactNo
            // 
            this.ContactNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ContactNo.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.ContactNo.Location = new System.Drawing.Point(758, 31);
            this.ContactNo.MaxLength = 8;
            this.ContactNo.Name = "ContactNo";
            this.ContactNo.Size = new System.Drawing.Size(235, 25);
            this.ContactNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(762, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 41;
            this.label2.Text = "CONTACT NO";
            // 
            // cmbBrandCode
            // 
            this.cmbBrandCode.DropDownHeight = 166;
            this.cmbBrandCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbBrandCode.FormattingEnabled = true;
            this.cmbBrandCode.IntegralHeight = false;
            this.cmbBrandCode.Location = new System.Drawing.Point(10, 93);
            this.cmbBrandCode.Name = "cmbBrandCode";
            this.cmbBrandCode.Size = new System.Drawing.Size(199, 25);
            this.cmbBrandCode.TabIndex = 2;
            this.cmbBrandCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbBrandCode_KeyDown);
            this.cmbBrandCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cbo_KeyPress);
            // 
            // CustomerName
            // 
            this.CustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CustomerName.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.CustomerName.Location = new System.Drawing.Point(499, 31);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(235, 25);
            this.CustomerName.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(13, 135);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "EST AMOUNT";
            // 
            // NetAmount
            // 
            this.NetAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.NetAmount.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.NetAmount.Location = new System.Drawing.Point(11, 154);
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.Size = new System.Drawing.Size(197, 25);
            this.NetAmount.TabIndex = 5;
            this.NetAmount.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(503, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "CUSTOMER NAME";
            // 
            // ServiceDate
            // 
            this.ServiceDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ServiceDate.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.ServiceDate.Location = new System.Drawing.Point(224, 31);
            this.ServiceDate.Name = "ServiceDate";
            this.ServiceDate.ReadOnly = true;
            this.ServiceDate.Size = new System.Drawing.Size(252, 25);
            this.ServiceDate.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(228, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "SERVICE DATE (Auto)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "BRAND";
            // 
            // BillNo
            // 
            this.BillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BillNo.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.BillNo.Location = new System.Drawing.Point(9, 31);
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            this.BillNo.Size = new System.Drawing.Size(200, 25);
            this.BillNo.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "BILL NO (Auto)";
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(334, 8);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 42);
            this.btnclear.TabIndex = 12;
            this.btnclear.Text = "CLEAR\r\nF3";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsuspend
            // 
            this.btnsuspend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsuspend.ForeColor = System.Drawing.Color.White;
            this.btnsuspend.Location = new System.Drawing.Point(415, 8);
            this.btnsuspend.Name = "btnsuspend";
            this.btnsuspend.Size = new System.Drawing.Size(75, 42);
            this.btnsuspend.TabIndex = 13;
            this.btnsuspend.Text = "SUSPEND\r\nF4";
            this.btnsuspend.UseVisualStyleBackColor = false;
            this.btnsuspend.Click += new System.EventHandler(this.btnsuspend_Click);
            // 
            // btnsettle
            // 
            this.btnsettle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsettle.ForeColor = System.Drawing.Color.White;
            this.btnsettle.Location = new System.Drawing.Point(498, 8);
            this.btnsettle.Name = "btnsettle";
            this.btnsettle.Size = new System.Drawing.Size(75, 42);
            this.btnsettle.TabIndex = 17;
            this.btnsettle.Text = "SETTLE\r\nF8";
            this.btnsettle.UseVisualStyleBackColor = false;
            this.btnsettle.Click += new System.EventHandler(this.btnsettle_Click);
            // 
            // btnsettleprint
            // 
            this.btnsettleprint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsettleprint.ForeColor = System.Drawing.Color.White;
            this.btnsettleprint.Location = new System.Drawing.Point(584, 8);
            this.btnsettleprint.Name = "btnsettleprint";
            this.btnsettleprint.Size = new System.Drawing.Size(107, 42);
            this.btnsettleprint.TabIndex = 18;
            this.btnsettleprint.Text = "SETTLE  PRINT\r\nF9";
            this.btnsettleprint.UseVisualStyleBackColor = false;
            this.btnsettleprint.Click += new System.EventHandler(this.btnsettleprint_Click);
            // 
            // btnreprint
            // 
            this.btnreprint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnreprint.ForeColor = System.Drawing.Color.White;
            this.btnreprint.Location = new System.Drawing.Point(697, 8);
            this.btnreprint.Name = "btnreprint";
            this.btnreprint.Size = new System.Drawing.Size(75, 42);
            this.btnreprint.TabIndex = 19;
            this.btnreprint.Text = "REPRINT\r\nF10";
            this.btnreprint.UseVisualStyleBackColor = false;
            this.btnreprint.Click += new System.EventHandler(this.btnreprint_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnreprint);
            this.panel2.Controls.Add(this.btnclear);
            this.panel2.Controls.Add(this.btnsettleprint);
            this.panel2.Controls.Add(this.btnsuspend);
            this.panel2.Controls.Add(this.btnsettle);
            this.panel2.Location = new System.Drawing.Point(215, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(779, 53);
            this.panel2.TabIndex = 20;
            // 
            // cmbNatureFault
            // 
            this.cmbNatureFault.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.cmbNatureFault.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbNatureFault.Location = new System.Drawing.Point(499, 93);
            this.cmbNatureFault.Name = "cmbNatureFault";
            this.cmbNatureFault.Size = new System.Drawing.Size(494, 25);
            this.cmbNatureFault.TabIndex = 4;
            // 
            // frmServiceBillAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "New Service Bill";
            this.KeyPreview = true;
            this.Name = "frmServiceBillAdd";
            this.Activated += new System.EventHandler(this.frmBrandAdd_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrandAdd_KeyDown);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ServiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NetAmount;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.ComboBox cmbBrandCode;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsuspend;
        private System.Windows.Forms.Button btnsettle;
        private System.Windows.Forms.Button btnsettleprint;
        private System.Windows.Forms.Button btnreprint;
        private System.Windows.Forms.TextBox ContactNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox IMEINo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ModelNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TechRemark;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbPasswordType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbStatusCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbOutSourceCode;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox cmbNatureFault;
    }
}
