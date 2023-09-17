namespace MobilePro
{
    partial class frmProducts
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
            this.cmbCategoryCodeSearch = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.btnreprint = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ProductID = new System.Windows.Forms.TextBox();
            this.cmbCategoryCode = new System.Windows.Forms.ComboBox();
            this.ProductCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkstatus = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblPageNumber = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.oldproductcode = new System.Windows.Forms.TextBox();
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
            this.lblTitle.Size = new System.Drawing.Size(139, 25);
            this.lblTitle.Text = "PRODUCTS";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(779, 673);
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
            this.cmbCategoryCodeSearch.TabIndex = 6;
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
            this.txtProductName.TabIndex = 7;
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
            this.btnSearch.TabIndex = 8;
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
            this.dgvResult.EnableHeadersVisualStyles = false;
            this.dgvResult.GridColor = System.Drawing.Color.Black;
            this.dgvResult.Location = new System.Drawing.Point(379, 170);
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
            this.dgvResult.Size = new System.Drawing.Size(620, 481);
            this.dgvResult.TabIndex = 6;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // btnreprint
            // 
            this.btnreprint.BackColor = System.Drawing.Color.SteelBlue;
            this.btnreprint.ForeColor = System.Drawing.Color.White;
            this.btnreprint.Location = new System.Drawing.Point(843, 123);
            this.btnreprint.Name = "btnreprint";
            this.btnreprint.Size = new System.Drawing.Size(75, 42);
            this.btnreprint.TabIndex = 68;
            this.btnreprint.Text = "PRINT\r\nF10";
            this.btnreprint.UseVisualStyleBackColor = false;
            this.btnreprint.Visible = false;
            this.btnreprint.Click += new System.EventHandler(this.btn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.oldproductcode);
            this.panel2.Controls.Add(this.ProductID);
            this.panel2.Controls.Add(this.cmbCategoryCode);
            this.panel2.Controls.Add(this.ProductCode);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Description);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.chkstatus);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 170);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 481);
            this.panel2.TabIndex = 69;
            // 
            // ProductID
            // 
            this.ProductID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ProductID.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductID.Location = new System.Drawing.Point(130, 188);
            this.ProductID.Name = "ProductID";
            this.ProductID.Size = new System.Drawing.Size(92, 22);
            this.ProductID.TabIndex = 84;
            this.ProductID.Visible = false;
            // 
            // cmbCategoryCode
            // 
            this.cmbCategoryCode.DropDownHeight = 166;
            this.cmbCategoryCode.Font = new System.Drawing.Font("Verdana", 10.75F, System.Drawing.FontStyle.Bold);
            this.cmbCategoryCode.FormattingEnabled = true;
            this.cmbCategoryCode.IntegralHeight = false;
            this.cmbCategoryCode.Location = new System.Drawing.Point(131, 37);
            this.cmbCategoryCode.Name = "cmbCategoryCode";
            this.cmbCategoryCode.Size = new System.Drawing.Size(229, 25);
            this.cmbCategoryCode.TabIndex = 1;
            this.cmbCategoryCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbCategoryCode_KeyDown);
            // 
            // ProductCode
            // 
            this.ProductCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.ProductCode.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProductCode.Location = new System.Drawing.Point(131, 76);
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Size = new System.Drawing.Size(230, 22);
            this.ProductCode.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(2, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 38);
            this.label5.TabIndex = 83;
            this.label5.Text = "PRODUCT / BAR CODE";
            // 
            // Description
            // 
            this.Description.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Description.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Description.Location = new System.Drawing.Point(130, 127);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(230, 22);
            this.Description.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(3, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 26);
            this.label4.TabIndex = 80;
            this.label4.Text = "DESCRIPTION";
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.Location = new System.Drawing.Point(239, 220);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel\r\n(Ctrl + C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(130, 220);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(83, 37);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save\r\n(Ctrl+S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseClick);
            // 
            // chkstatus
            // 
            this.chkstatus.AutoSize = true;
            this.chkstatus.Location = new System.Drawing.Point(130, 168);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Size = new System.Drawing.Size(15, 14);
            this.chkstatus.TabIndex = 4;
            this.chkstatus.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 26);
            this.label2.TabIndex = 72;
            this.label2.Text = "CATEGORY";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(2, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 26);
            this.label1.TabIndex = 71;
            this.label1.Text = "STATUS";
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(562, 138);
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
            this.lblPageNumber.Location = new System.Drawing.Point(469, 142);
            this.lblPageNumber.Name = "lblPageNumber";
            this.lblPageNumber.Size = new System.Drawing.Size(54, 17);
            this.lblPageNumber.TabIndex = 72;
            this.lblPageNumber.Text = "label1";
            // 
            // btnPrevious
            // 
            this.btnPrevious.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.Location = new System.Drawing.Point(379, 138);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(75, 23);
            this.btnPrevious.TabIndex = 71;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // oldproductcode
            // 
            this.oldproductcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.oldproductcode.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oldproductcode.Location = new System.Drawing.Point(228, 188);
            this.oldproductcode.Name = "oldproductcode";
            this.oldproductcode.Size = new System.Drawing.Size(92, 22);
            this.oldproductcode.TabIndex = 85;
            this.oldproductcode.Visible = false;
            // 
            // frmProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.lblPageNumber);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnreprint);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "PRODUCTS";
            this.KeyPreview = true;
            this.Name = "frmProducts";
            this.Activated += new System.EventHandler(this.frm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmProducts_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.Controls.SetChildIndex(this.btnreprint, 0);
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
        private System.Windows.Forms.Button btnreprint;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancel;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private System.Windows.Forms.CheckBox chkstatus;
        private System.Windows.Forms.TextBox Description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ProductCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCategoryCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCategoryCodeSearch;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPageNumber;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.TextBox ProductID;
        private System.Windows.Forms.TextBox oldproductcode;
    }
}
