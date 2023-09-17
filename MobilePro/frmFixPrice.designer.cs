namespace MobilePro
{
    partial class frmFixPrice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbCategoryCodeSearch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SellingPrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbCategoryCode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.UnitPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.cmbautocomplete = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitle.Location = new System.Drawing.Point(3, 7);
            this.lblTitle.Size = new System.Drawing.Size(131, 25);
            this.lblTitle.Text = "FIX PRICE";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(783, 520);
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
            this.panel1.Controls.Add(this.cmbCategoryCodeSearch);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtProductName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 74);
            this.panel1.TabIndex = 67;
            // 
            // cmbCategoryCodeSearch
            // 
            this.cmbCategoryCodeSearch.FormattingEnabled = true;
            this.cmbCategoryCodeSearch.Location = new System.Drawing.Point(9, 38);
            this.cmbCategoryCodeSearch.Name = "cmbCategoryCodeSearch";
            this.cmbCategoryCodeSearch.Size = new System.Drawing.Size(244, 27);
            this.cmbCategoryCodeSearch.TabIndex = 7;
            this.cmbCategoryCodeSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategoryCodeSearch_KeyDown);
            this.cmbCategoryCodeSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 26);
            this.label6.TabIndex = 72;
            this.label6.Text = "CATEGORY";
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(271, 39);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(270, 26);
            this.txtProductName.TabIndex = 8;
            this.txtProductName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(831, 39);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(79, 26);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            this.btnSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(267, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 26);
            this.label3.TabIndex = 70;
            this.label3.Text = "PRODUCT";
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.AllowUserToResizeRows = false;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.Color.LightSteelBlue;
            this.dgvResult.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvResult.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResult.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvResult.ColumnHeadersHeight = 25;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.Color.MintCream;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResult.DefaultCellStyle = dataGridViewCellStyle19;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.Color.Black;
            this.dgvResult.Location = new System.Drawing.Point(0, 452);
            this.dgvResult.MultiSelect = false;
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.ReadOnly = true;
            this.dgvResult.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.ControlLight;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle20;
            this.dgvResult.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvResult.RowTemplate.Height = 26;
            this.dgvResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResult.Size = new System.Drawing.Size(1020, 304);
            this.dgvResult.TabIndex = 6;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.cmbautocomplete);
            this.panel2.Controls.Add(this.SellingPrice);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbCategoryCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.UnitPrice);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(3, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 116);
            this.panel2.TabIndex = 69;
            // 
            // SellingPrice
            // 
            this.SellingPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.SellingPrice.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.SellingPrice.Location = new System.Drawing.Point(471, 85);
            this.SellingPrice.Name = "SellingPrice";
            this.SellingPrice.Size = new System.Drawing.Size(151, 24);
            this.SellingPrice.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label7.Location = new System.Drawing.Point(331, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 26);
            this.label7.TabIndex = 85;
            this.label7.Text = "SELLING PRICE";
            // 
            // cmbCategoryCode
            // 
            this.cmbCategoryCode.DropDownHeight = 166;
            this.cmbCategoryCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbCategoryCode.FormattingEnabled = true;
            this.cmbCategoryCode.IntegralHeight = false;
            this.cmbCategoryCode.Location = new System.Drawing.Point(131, 15);
            this.cmbCategoryCode.Name = "cmbCategoryCode";
            this.cmbCategoryCode.Size = new System.Drawing.Size(229, 25);
            this.cmbCategoryCode.TabIndex = 1;
            this.cmbCategoryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategoryCode_KeyDown);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(1, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 26);
            this.label5.TabIndex = 83;
            this.label5.Text = "PRODUCT";
            // 
            // UnitPrice
            // 
            this.UnitPrice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.UnitPrice.Font = new System.Drawing.Font("Verdana", 10.25F, System.Drawing.FontStyle.Bold);
            this.UnitPrice.Location = new System.Drawing.Point(131, 85);
            this.UnitPrice.Name = "UnitPrice";
            this.UnitPrice.Size = new System.Drawing.Size(151, 24);
            this.UnitPrice.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(1, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 26);
            this.label4.TabIndex = 80;
            this.label4.Text = "UNIT COST";
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.Location = new System.Drawing.Point(889, 76);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel\r\n(Ctrl + C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(780, 76);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(83, 37);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save\r\n(Ctrl+S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseClick);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(2, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 26);
            this.label2.TabIndex = 72;
            this.label2.Text = "CATEGORY";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(186, 251);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 73;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblPageNumber
            // 
            this.lblPageNumber.AutoSize = true;
            this.lblPageNumber.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold);
            this.lblPageNumber.Location = new System.Drawing.Point(93, 255);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(54, 17);
            this.lblPageNumber.TabIndex = 72;
            this.lblPageNumber.Text = "label1";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(3, 251);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 71;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Verdana", 11.75F, System.Drawing.FontStyle.Bold);
            this.txtSearch.Location = new System.Drawing.Point(131, 47);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(229, 27);
            this.txtSearch.TabIndex = 2;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // cmbautocomplete
            // 
            this.cmbautocomplete.DropDownHeight = 166;
            this.cmbautocomplete.Font = new System.Drawing.Font("Verdana", 12.75F, System.Drawing.FontStyle.Bold);
            this.cmbautocomplete.FormattingEnabled = true;
            this.cmbautocomplete.IntegralHeight = false;
            this.cmbautocomplete.Location = new System.Drawing.Point(371, 46);
            this.cmbautocomplete.Name = "cmbautocomplete";
            this.cmbautocomplete.Size = new System.Drawing.Size(512, 28);
            this.cmbautocomplete.TabIndex = 3;
            // 
            // frmFixPrice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "FIX PRICE";
            this.KeyPreview = true;
            this.Name = "frmFixPrice";
            this.Activated += new System.EventHandler(this.frm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProducts_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.btnPrevious, 0);
            this.Controls.SetChildIndex(this.lblPageNumber, 0);
            this.Controls.SetChildIndex(this.btnNext, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private MaterialSkin.Controls.MaterialRaisedButton btnSearch;
        protected System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancel;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private System.Windows.Forms.TextBox UnitPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategoryCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCategoryCodeSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox SellingPrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbautocomplete;
    }
}
