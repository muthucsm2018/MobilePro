namespace MobilePro
{
    partial class frmDailySales
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtServiceDate = new System.Windows.Forms.DateTimePicker();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnreprint = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Size = new System.Drawing.Size(164, 25);
            this.lblTitle.Text = "DAILY SALES";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(654, 474);
            this.btnClose.Size = new System.Drawing.Size(135, 33);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close (Esc)";
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dtServiceDate);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 74);
            this.panel1.TabIndex = 67;
            // 
            // dtServiceDate
            // 
            this.dtServiceDate.Checked = false;
            this.dtServiceDate.CustomFormat = "dd/MM/yyyy";
            this.dtServiceDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtServiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtServiceDate.Location = new System.Drawing.Point(12, 29);
            this.dtServiceDate.Name = "dtServiceDate";
            this.dtServiceDate.ShowCheckBox = true;
            this.dtServiceDate.Size = new System.Drawing.Size(183, 26);
            this.dtServiceDate.TabIndex = 71;
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(740, 31);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(79, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(10, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 23);
            this.label3.TabIndex = 70;
            this.label3.Text = "DATE";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
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
            this.dgvResult.Location = new System.Drawing.Point(0, 74);
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
            this.dgvResult.RowTemplate.Height = 26;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1020, 682);
            this.dgvResult.TabIndex = 6;
            this.dgvResult.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellEndEdit);
            this.dgvResult.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // btnreprint
            // 
            this.btnreprint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnreprint.ForeColor = System.Drawing.Color.White;
            this.btnreprint.Location = new System.Drawing.Point(746, 80);
            this.btnreprint.Name = "btnreprint";
            this.btnreprint.Size = new System.Drawing.Size(75, 42);
            this.btnreprint.TabIndex = 68;
            this.btnreprint.Text = "PRINT\r\nF10";
            this.btnreprint.UseVisualStyleBackColor = false;
            this.btnreprint.Click += new System.EventHandler(this.btn_Click);
            // 
            // frmDailySales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.btnreprint);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "DAILY SALES";
            this.KeyPreview = true;
            this.Name = "frmDailySales";
            this.Activated += new System.EventHandler(this.frm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrands_KeyDown);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.Controls.SetChildIndex(this.btnreprint, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearch;
        protected System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.Button btnreprint;
        private System.Windows.Forms.DateTimePicker dtServiceDate;
    }
}
