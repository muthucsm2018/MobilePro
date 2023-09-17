namespace MobilePro
{
    partial class frmServiceBills
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
            this.label6 = new System.Windows.Forms.Label();
            this.txtBillNo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtServiceDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.lbltotalsales = new System.Windows.Forms.Label();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Size = new System.Drawing.Size(188, 25);
            this.lblTitle.Text = "SERVICE BILLS";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(783, 686);
            this.btnClose.Size = new System.Drawing.Size(135, 33);
            this.btnClose.TabIndex = 35;
            this.btnClose.Text = "&Close (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btn_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(4, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 29);
            this.label6.TabIndex = 63;
            this.label6.Text = "BILL NO";
            // 
            // txtBillNo
            // 
            this.txtBillNo.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNo.Location = new System.Drawing.Point(3, 37);
            this.txtBillNo.Name = "txtBillNo";
            this.txtBillNo.Size = new System.Drawing.Size(156, 26);
            this.txtBillNo.TabIndex = 1;
            this.txtBillNo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.cmbStatus);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dtServiceDate);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtCustomerName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtBillNo);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 74);
            this.panel1.TabIndex = 67;
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(801, 39);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(79, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(563, 37);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(163, 27);
            this.cmbStatus.TabIndex = 4;
            this.cmbStatus.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbStatus_KeyDown);
            this.cmbStatus.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(560, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 29);
            this.label3.TabIndex = 70;
            this.label3.Text = "STATUS";
            // 
            // dtServiceDate
            // 
            this.dtServiceDate.Checked = false;
            this.dtServiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtServiceDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtServiceDate.Location = new System.Drawing.Point(371, 37);
            this.dtServiceDate.Name = "dtServiceDate";
            this.dtServiceDate.ShowCheckBox = true;
            this.dtServiceDate.Size = new System.Drawing.Size(183, 26);
            this.dtServiceDate.TabIndex = 3;
            this.dtServiceDate.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(368, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 29);
            this.label2.TabIndex = 67;
            this.label2.Text = "SERVICE DATE";
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerName.Location = new System.Drawing.Point(168, 37);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(197, 26);
            this.txtCustomerName.TabIndex = 2;
            this.txtCustomerName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(165, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 29);
            this.label1.TabIndex = 65;
            this.label1.Text = "CUSTOMER NAME";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(0, 129);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 68;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageNumber.Location = new System.Drawing.Point(90, 133);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(54, 17);
            this.lblPageNumber.TabIndex = 69;
            this.lblPageNumber.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(183, 129);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 70;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
            this.dgvResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvResult.ColumnHeadersHeight = 25;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.Color.Black;
            this.dgvResult.Location = new System.Drawing.Point(0, 305);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResult.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.MintCream;
            this.dgvResult.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvResult.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvResult.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.MintCream;
            this.dgvResult.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvResult.RowTemplate.Height = 26;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1020, 451);
            this.dgvResult.TabIndex = 6;
            this.dgvResult.TabStop = false;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            this.dgvResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellEndEdit);
            this.dgvResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvResult_CellFormatting);
            this.dgvResult.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // lbltotalsales
            // 
            this.lbltotalsales.AutoSize = true;
            this.lbltotalsales.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalsales.Location = new System.Drawing.Point(689, 129);
            this.lbltotalsales.Name = "lbltotalsales";
            this.lbltotalsales.Size = new System.Drawing.Size(0, 22);
            this.lbltotalsales.TabIndex = 74;
            this.lbltotalsales.Visible = false;
            // 
            // btnAddNew
            // 
            this.btnAddNew.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnAddNew.Font = new System.Drawing.Font("Times New Roman", 13.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(634, 687);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(143, 33);
            this.btnAddNew.TabIndex = 75;
            this.btnAddNew.Text = "Add (Ctrl + A)";
            this.btnAddNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Visible = false;
            this.btnAddNew.Click += new System.EventHandler(this.btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(466, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 76;
            // 
            // frmServiceBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.lbltotalsales);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "SERVICE BILLS";
            this.KeyPreview = true;
            this.Name = "frmServiceBills";
            this.Activated += new System.EventHandler(this.frm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frmServiceBills_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrands_KeyDown);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.lblPageNumber, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.Controls.SetChildIndex(this.lbltotalsales, 0);
            this.Controls.SetChildIndex(this.btnAddNew, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBillNo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtServiceDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearch;
        protected System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Label lbltotalsales;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Label label4;
    }
}
