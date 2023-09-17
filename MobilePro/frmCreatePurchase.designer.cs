namespace MobilePro
{
    partial class frmCreatePurchase
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.TotalAmount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnsuspend = new System.Windows.Forms.Button();
            this.cmbautocomplete = new System.Windows.Forms.ComboBox();
            this.btnadd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.UnitCost = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Quantity = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtPurchaseDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbVendorCode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Size = new System.Drawing.Size(138, 25);
            this.lblTitle.Text = "PURCHASE";
            this.lblTitle.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(724, 539);
            this.btnClose.Size = new System.Drawing.Size(135, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close (Esc)";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.TotalAmount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnsuspend);
            this.panel2.Controls.Add(this.cmbautocomplete);
            this.panel2.Controls.Add(this.btnadd);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.UnitCost);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.Quantity);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtOrderNo);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dtPurchaseDate);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cmbVendorCode);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1020, 177);
            this.panel2.TabIndex = 69;
            // 
            // TotalAmount
            // 
            this.TotalAmount.AutoSize = true;
            this.TotalAmount.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TotalAmount.Location = new System.Drawing.Point(518, 144);
            this.TotalAmount.Name = "TotalAmount";
            this.TotalAmount.Size = new System.Drawing.Size(0, 17);
            this.TotalAmount.TabIndex = 100;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(422, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 99;
            this.label7.Text = "TOTAL ($) ";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(722, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 42);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "SAVE\r\n(Ctrl + S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnsettle_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(7, 84);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(255, 27);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnsuspend
            // 
            this.btnsuspend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsuspend.ForeColor = System.Drawing.Color.White;
            this.btnsuspend.Location = new System.Drawing.Point(803, 129);
            this.btnsuspend.Name = "btnsuspend";
            this.btnsuspend.Size = new System.Drawing.Size(75, 42);
            this.btnsuspend.TabIndex = 8;
            this.btnsuspend.Text = "DELETE\r\n(Ctrl + C)";
            this.btnsuspend.UseVisualStyleBackColor = false;
            this.btnsuspend.Click += new System.EventHandler(this.btnsuspend_Click);
            // 
            // cmbautocomplete
            // 
            this.cmbautocomplete.DropDownHeight = 166;
            this.cmbautocomplete.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold);
            this.cmbautocomplete.FormattingEnabled = true;
            this.cmbautocomplete.IntegralHeight = false;
            this.cmbautocomplete.Location = new System.Drawing.Point(282, 83);
            this.cmbautocomplete.Name = "cmbautocomplete";
            this.cmbautocomplete.Size = new System.Drawing.Size(512, 28);
            this.cmbautocomplete.TabIndex = 4;
            this.cmbautocomplete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbautocomplete_KeyPress);
            // 
            // btnadd
            // 
            this.btnadd.Image = global::MobilePro.Properties.Resources.add;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(282, 121);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(115, 41);
            this.btnadd.TabIndex = 96;
            this.btnadd.Text = "ADD ITEM";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnadd.UseVisualStyleBackColor = true;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(135, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 16);
            this.label5.TabIndex = 98;
            this.label5.Text = "UNIT COST ($)";
            // 
            // UnitCost
            // 
            this.UnitCost.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UnitCost.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnitCost.Location = new System.Drawing.Point(138, 139);
            this.UnitCost.Name = "UnitCost";
            this.UnitCost.Size = new System.Drawing.Size(120, 23);
            this.UnitCost.TabIndex = 6;
            this.UnitCost.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Price_KeyPress);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 97;
            this.label12.Text = "QTY";
            // 
            // Quantity
            // 
            this.Quantity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Quantity.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Quantity.Location = new System.Drawing.Point(8, 139);
            this.Quantity.Name = "Quantity";
            this.Quantity.Size = new System.Drawing.Size(94, 23);
            this.Quantity.TabIndex = 5;
            this.Quantity.Text = "1";
            this.Quantity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NetAmount_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 16);
            this.label4.TabIndex = 95;
            this.label4.Text = "ADD PRODUCTS TO PURCHASE";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label6.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Firebrick;
            this.label6.Location = new System.Drawing.Point(1, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(883, 25);
            this.label6.TabIndex = 90;
            this.label6.Text = "---------------------------------------------------------------------------------" +
    "--------------------------------------------";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOrderNo.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.txtOrderNo.Location = new System.Drawing.Point(365, 21);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(157, 24);
            this.txtOrderNo.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(279, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 26);
            this.label3.TabIndex = 89;
            this.label3.Text = "ORDER NO";
            // 
            // dtPurchaseDate
            // 
            this.dtPurchaseDate.Checked = false;
            this.dtPurchaseDate.CustomFormat = "dd/MM/yyyy";
            this.dtPurchaseDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPurchaseDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPurchaseDate.Location = new System.Drawing.Point(89, 19);
            this.dtPurchaseDate.Name = "dtPurchaseDate";
            this.dtPurchaseDate.ShowCheckBox = true;
            this.dtPurchaseDate.Size = new System.Drawing.Size(183, 26);
            this.dtPurchaseDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(1, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 86;
            this.label1.Text = "DATE";
            // 
            // cmbVendorCode
            // 
            this.cmbVendorCode.DropDownHeight = 166;
            this.cmbVendorCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbVendorCode.FormattingEnabled = true;
            this.cmbVendorCode.IntegralHeight = false;
            this.cmbVendorCode.Location = new System.Drawing.Point(607, 21);
            this.cmbVendorCode.Name = "cmbVendorCode";
            this.cmbVendorCode.Size = new System.Drawing.Size(252, 25);
            this.cmbVendorCode.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(528, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 26);
            this.label2.TabIndex = 72;
            this.label2.Text = "VENDOR";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeColumns = false;
            this.dgvResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.ColumnHeadersHeight = 25;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.Color.Black;
            this.dgvResult.Location = new System.Drawing.Point(0, 177);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1020, 579);
            this.dgvResult.TabIndex = 70;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // frmCreatePurchase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "PURCHASE";
            this.KeyPreview = true;
            this.Name = "frmCreatePurchase";
            this.Activated += new System.EventHandler(this.frmCreatePurchase_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCreatePurchase_KeyDown);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbVendorCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtPurchaseDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbautocomplete;
        private System.Windows.Forms.Button btnadd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox UnitCost;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Quantity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnsuspend;
        private System.Windows.Forms.Label TotalAmount;
        private System.Windows.Forms.Label label7;
        protected System.Windows.Forms.DataGridView dgvResult;
    }
}
