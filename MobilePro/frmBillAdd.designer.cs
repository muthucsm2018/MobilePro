namespace MobilePro
{
    partial class frmBillAdd
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbPaymentType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Discount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChangeAmount = new System.Windows.Forms.TextBox();
            this.txtPaidAmount = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.NetAmount = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblstock = new System.Windows.Forms.Label();
            this.lblunitcost = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbautocomplete = new System.Windows.Forms.ComboBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.CustomerName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ServiceDate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BillNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsuspend = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnsettle = new System.Windows.Forms.Button();
            this.btnsettleprint = new System.Windows.Forms.Button();
            this.btnreprint = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
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
            this.btnClose.Location = new System.Drawing.Point(658, 653);
            this.btnClose.Size = new System.Drawing.Size(130, 35);
            this.btnClose.TabIndex = 11;
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
            this.btnSave.Location = new System.Drawing.Point(527, 653);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "&Save (Ctrl + S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.dgvResult);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Controls.Add(this.cmbautocomplete);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Price);
            this.panel1.Controls.Add(this.CustomerName);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.Quantity);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.ServiceDate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.BillNo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 533);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.cmbPaymentType);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.Discount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.txtChangeAmount);
            this.panel3.Controls.Add(this.txtPaidAmount);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.NetAmount);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Location = new System.Drawing.Point(802, 130);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 373);
            this.panel3.TabIndex = 140;
            // 
            // cmbPaymentType
            // 
            this.cmbPaymentType.BackColor = System.Drawing.Color.Yellow;
            this.cmbPaymentType.Font = new System.Drawing.Font("Verdana", 16.75F, System.Drawing.FontStyle.Bold);
            this.cmbPaymentType.FormattingEnabled = true;
            this.cmbPaymentType.Location = new System.Drawing.Point(0, 113);
            this.cmbPaymentType.Name = "cmbPaymentType";
            this.cmbPaymentType.Size = new System.Drawing.Size(215, 34);
            this.cmbPaymentType.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.SteelBlue;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(0, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(215, 35);
            this.label11.TabIndex = 24;
            this.label11.Text = "PAYMENT ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Discount
            // 
            this.Discount.BackColor = System.Drawing.Color.Yellow;
            this.Discount.Font = new System.Drawing.Font("Verdana", 16.75F, System.Drawing.FontStyle.Bold);
            this.Discount.Location = new System.Drawing.Point(0, 37);
            this.Discount.Name = "Discount";
            this.Discount.Size = new System.Drawing.Size(215, 35);
            this.Discount.TabIndex = 6;
            this.Discount.TextChanged += new System.EventHandler(this.Discount_TextChanged);
            this.Discount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, -1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 35);
            this.label2.TabIndex = 2;
            this.label2.Text = "DISCOUNT";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChangeAmount
            // 
            this.txtChangeAmount.BackColor = System.Drawing.Color.Yellow;
            this.txtChangeAmount.Enabled = false;
            this.txtChangeAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.txtChangeAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtChangeAmount.Location = new System.Drawing.Point(0, 338);
            this.txtChangeAmount.Name = "txtChangeAmount";
            this.txtChangeAmount.Size = new System.Drawing.Size(215, 34);
            this.txtChangeAmount.TabIndex = 9;
            this.txtChangeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtChangeAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // txtPaidAmount
            // 
            this.txtPaidAmount.BackColor = System.Drawing.Color.Yellow;
            this.txtPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 17.25F, System.Drawing.FontStyle.Bold);
            this.txtPaidAmount.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtPaidAmount.Location = new System.Drawing.Point(0, 266);
            this.txtPaidAmount.Name = "txtPaidAmount";
            this.txtPaidAmount.Size = new System.Drawing.Size(215, 34);
            this.txtPaidAmount.TabIndex = 8;
            this.txtPaidAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPaidAmount.TextChanged += new System.EventHandler(this.txtPaidAmount_TextChanged);
            this.txtPaidAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.SteelBlue;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label20.ForeColor = System.Drawing.Color.White;
            this.label20.Location = new System.Drawing.Point(0, 300);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(215, 35);
            this.label20.TabIndex = 72;
            this.label20.Text = "DUE";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.SteelBlue;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(0, 149);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(215, 35);
            this.label10.TabIndex = 22;
            this.label10.Text = "NET AMOUNT";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NetAmount
            // 
            this.NetAmount.BackColor = System.Drawing.Color.Yellow;
            this.NetAmount.Font = new System.Drawing.Font("Verdana", 17.75F, System.Drawing.FontStyle.Bold);
            this.NetAmount.ForeColor = System.Drawing.Color.Black;
            this.NetAmount.Location = new System.Drawing.Point(0, 188);
            this.NetAmount.Name = "NetAmount";
            this.NetAmount.ReadOnly = true;
            this.NetAmount.Size = new System.Drawing.Size(215, 36);
            this.NetAmount.TabIndex = 26;
            this.NetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.SteelBlue;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold);
            this.label19.ForeColor = System.Drawing.Color.White;
            this.label19.Location = new System.Drawing.Point(0, 228);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(215, 35);
            this.label19.TabIndex = 71;
            this.label19.Text = "TENDER";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblstock);
            this.groupBox1.Controls.Add(this.lblunitcost);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(802, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 85);
            this.groupBox1.TabIndex = 139;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DETAILS:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(8, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 18);
            this.label9.TabIndex = 20;
            this.label9.Text = "UNIT COST";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(8, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 36;
            this.label7.Text = "STOCK";
            // 
            // lblstock
            // 
            this.lblstock.AutoSize = true;
            this.lblstock.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblstock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblstock.Location = new System.Drawing.Point(115, 61);
            this.lblstock.Name = "lblstock";
            this.lblstock.Size = new System.Drawing.Size(19, 18);
            this.lblstock.TabIndex = 37;
            this.lblstock.Text = "0";
            // 
            // lblunitcost
            // 
            this.lblunitcost.AutoSize = true;
            this.lblunitcost.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Bold);
            this.lblunitcost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblunitcost.Location = new System.Drawing.Point(115, 26);
            this.lblunitcost.Name = "lblunitcost";
            this.lblunitcost.Size = new System.Drawing.Size(19, 18);
            this.lblunitcost.TabIndex = 34;
            this.lblunitcost.Text = "0";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbltotal);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(560, 126);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(237, 58);
            this.groupBox4.TabIndex = 138;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "TOTAL";
            // 
            // lbltotal
            // 
            this.lbltotal.AutoSize = true;
            this.lbltotal.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotal.ForeColor = System.Drawing.Color.Blue;
            this.lbltotal.Location = new System.Drawing.Point(74, 23);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(87, 23);
            this.lbltotal.TabIndex = 136;
            this.lbltotal.Text = "-----------";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeight = 25;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.Color.Black;
            this.dgvResult.Location = new System.Drawing.Point(10, 195);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(548, 307);
            this.dgvResult.TabIndex = 5;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(10, 93);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // cmbautocomplete
            // 
            this.cmbautocomplete.DropDownHeight = 166;
            this.cmbautocomplete.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold);
            this.cmbautocomplete.FormattingEnabled = true;
            this.cmbautocomplete.IntegralHeight = false;
            this.cmbautocomplete.Location = new System.Drawing.Point(285, 92);
            this.cmbautocomplete.Name = "cmbautocomplete";
            this.cmbautocomplete.Size = new System.Drawing.Size(512, 28);
            this.cmbautocomplete.TabIndex = 2;
            this.cmbautocomplete.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.cmbautocomplete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbautocomplete_KeyPress);
            // 
            // btnadd
            // 
            this.btnadd.Image = global::MobilePro.Properties.Resources.add;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(285, 142);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(115, 41);
            this.btnadd.TabIndex = 5;
            this.btnadd.Text = "ADD ITEM";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(138, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 16);
            this.label5.TabIndex = 39;
            this.label5.Text = "PRICE ($)";
            // 
            // Price
            // 
            this.Price.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Price.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Price.Location = new System.Drawing.Point(141, 160);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(120, 23);
            this.Price.TabIndex = 4;
            this.Price.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Price_KeyPress);
            // 
            // CustomerName
            // 
            this.CustomerName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.CustomerName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomerName.Location = new System.Drawing.Point(562, 31);
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.Size = new System.Drawing.Size(235, 23);
            this.CustomerName.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 141);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 27;
            this.label12.Text = "QTY";
            // 
            // Quantity
            // 
            this.Quantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Quantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Location = new System.Drawing.Point(11, 160);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(94, 23);
            this.Quantity.TabIndex = 3;
            this.Quantity.Text = "1";
            this.Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetAmount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(566, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "CUSTOMER NAME";
            // 
            // ServiceDate
            // 
            this.ServiceDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ServiceDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ServiceDate.Location = new System.Drawing.Point(287, 31);
            this.ServiceDate.Name = "ServiceDate";
            this.ServiceDate.ReadOnly = true;
            this.ServiceDate.Size = new System.Drawing.Size(252, 23);
            this.ServiceDate.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(291, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "DATE (Auto)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "BARCODE";
            // 
            // BillNo
            // 
            this.BillNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.BillNo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BillNo.Location = new System.Drawing.Point(9, 31);
            this.BillNo.Name = "BillNo";
            this.BillNo.ReadOnly = true;
            this.BillNo.Size = new System.Drawing.Size(253, 23);
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
            this.btnclear.Location = new System.Drawing.Point(340, 20);
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
            this.btnsuspend.Location = new System.Drawing.Point(421, 20);
            this.btnsuspend.Name = "btnsuspend";
            this.btnsuspend.Size = new System.Drawing.Size(75, 42);
            this.btnsuspend.TabIndex = 13;
            this.btnsuspend.Text = "SUSPEND\r\nF4";
            this.btnsuspend.UseVisualStyleBackColor = false;
            this.btnsuspend.Click += new System.EventHandler(this.btnsuspend_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.SteelBlue;
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(502, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 42);
            this.button3.TabIndex = 14;
            this.button3.Text = "TENDER\r\nF5";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.SteelBlue;
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(583, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 42);
            this.button4.TabIndex = 15;
            this.button4.Text = "DISC\r\nF6";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.SteelBlue;
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Location = new System.Drawing.Point(664, 20);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 42);
            this.button5.TabIndex = 16;
            this.button5.Text = "PAYMENT\r\nF7";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnsettle
            // 
            this.btnsettle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsettle.ForeColor = System.Drawing.Color.White;
            this.btnsettle.Location = new System.Drawing.Point(745, 20);
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
            this.btnsettleprint.Location = new System.Drawing.Point(826, 20);
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
            this.btnreprint.Location = new System.Drawing.Point(939, 20);
            this.btnreprint.Name = "btnreprint";
            this.btnreprint.Size = new System.Drawing.Size(75, 42);
            this.btnreprint.TabIndex = 19;
            this.btnreprint.Text = "REPRINT\r\nF10";
            this.btnreprint.UseVisualStyleBackColor = false;
            this.btnreprint.Click += new System.EventHandler(this.btnreprint_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(291, 73);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 16);
            this.label8.TabIndex = 141;
            this.label8.Text = "SEARCH PRODUCTS";
            // 
            // frmBillAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.Controls.Add(this.btnreprint);
            this.Controls.Add(this.btnsettleprint);
            this.Controls.Add(this.btnsettle);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnsuspend);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSave);
            this.HeaderDescription = "New Service Bill";
            this.KeyPreview = true;
            this.Name = "frmBillAdd";
            this.Activated += new System.EventHandler(this.frmBrandAdd_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrandAdd_KeyDown);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.frmBrandAdd_PreviewKeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnclear, 0);
            this.Controls.SetChildIndex(this.btnsuspend, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.button4, 0);
            this.Controls.SetChildIndex(this.button5, 0);
            this.Controls.SetChildIndex(this.btnsettle, 0);
            this.Controls.SetChildIndex(this.btnsettleprint, 0);
            this.Controls.SetChildIndex(this.btnreprint, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox BillNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Discount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ServiceDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbPaymentType;
        private System.Windows.Forms.Label lblunitcost;
        private System.Windows.Forms.TextBox CustomerName;
        private System.Windows.Forms.Label lblstock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NetAmount;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.ComboBox cmbautocomplete;
        private System.Windows.Forms.TextBox txtSearch;
        protected System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TextBox txtPaidAmount;
        private System.Windows.Forms.TextBox txtChangeAmount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsuspend;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnsettle;
        private System.Windows.Forms.Button btnsettleprint;
        private System.Windows.Forms.Button btnreprint;
        private System.Windows.Forms.Label label8;
    }
}
