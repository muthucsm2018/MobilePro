namespace MobilePro
{
    partial class frmFault
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
            this.txtFaultName = new System.Windows.Forms.TextBox();
            this.btnSearch = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.FaultCode = new System.Windows.Forms.TextBox();
            this.btnCancel = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSave = new MaterialSkin.Controls.MaterialRaisedButton();
            this.chkstatus = new System.Windows.Forms.CheckBox();
            this.FaultName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.lblTitle.Size = new System.Drawing.Size(86, 25);
            this.lblTitle.Text = "FAULT";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(779, 619);
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
            this.panel1.Controls.Add(this.txtFaultName);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 74);
            this.panel1.TabIndex = 67;
            // 
            // txtFaultName
            // 
            this.txtFaultName.Location = new System.Drawing.Point(12, 40);
            this.txtFaultName.Name = "txtFaultName";
            this.txtFaultName.Size = new System.Drawing.Size(270, 26);
            this.txtFaultName.TabIndex = 71;
            this.txtFaultName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Search_KeyUp);
            // 
            // btnSearch
            // 
            this.btnSearch.Depth = 0;
            this.btnSearch.Location = new System.Drawing.Point(831, 39);
            this.btnSearch.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Primary = true;
            this.btnSearch.Size = new System.Drawing.Size(79, 26);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btn_Click);
            this.btnSearch.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSearch_MouseClick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(8, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 26);
            this.label3.TabIndex = 70;
            this.label3.Text = "FAULT NAME";
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
            this.dgvResult.Location = new System.Drawing.Point(423, 122);
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
            this.dgvResult.Size = new System.Drawing.Size(585, 479);
            this.dgvResult.TabIndex = 6;
            this.dgvResult.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResult_CellClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel2.Controls.Add(this.FaultCode);
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.chkstatus);
            this.panel2.Controls.Add(this.FaultName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(3, 124);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 481);
            this.panel2.TabIndex = 69;
            // 
            // FaultCode
            // 
            this.FaultCode.Location = new System.Drawing.Point(158, 2);
            this.FaultCode.Name = "FaultCode";
            this.FaultCode.Size = new System.Drawing.Size(230, 21);
            this.FaultCode.TabIndex = 78;
            this.FaultCode.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Depth = 0;
            this.btnCancel.Location = new System.Drawing.Point(267, 147);
            this.btnCancel.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Primary = true;
            this.btnCancel.Size = new System.Drawing.Size(79, 37);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel\r\n(Ctrl + C)";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCancel_MouseClick);
            // 
            // btnSave
            // 
            this.btnSave.Depth = 0;
            this.btnSave.Location = new System.Drawing.Point(158, 147);
            this.btnSave.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSave.Name = "btnSave";
            this.btnSave.Primary = true;
            this.btnSave.Size = new System.Drawing.Size(83, 37);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save\r\n(Ctrl+S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSave_MouseClick);
            // 
            // chkstatus
            // 
            this.chkstatus.AutoSize = true;
            this.chkstatus.Location = new System.Drawing.Point(137, 96);
            this.chkstatus.Name = "chkstatus";
            this.chkstatus.Size = new System.Drawing.Size(15, 14);
            this.chkstatus.TabIndex = 3;
            this.chkstatus.UseVisualStyleBackColor = true;
            this.chkstatus.CheckedChanged += new System.EventHandler(this.chkstatus_CheckedChanged);
            // 
            // FaultName
            // 
            this.FaultName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.FaultName.Font = new System.Drawing.Font("Verdana", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FaultName.Location = new System.Drawing.Point(138, 37);
            this.FaultName.Name = "FaultName";
            this.FaultName.Size = new System.Drawing.Size(263, 22);
            this.FaultName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(2, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 39);
            this.label2.TabIndex = 72;
            this.label2.Text = "FAULT NAME";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(2, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 26);
            this.label1.TabIndex = 71;
            this.label1.Text = "STATUS";
            // 
            // frmFault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 756);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.dgvResult);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HeaderDescription = "FAULT";
            this.KeyPreview = true;
            this.Name = "frmFault";
            this.Activated += new System.EventHandler(this.frm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOutSources_KeyDown);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dgvResult, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
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
        private System.Windows.Forms.TextBox txtFaultName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox FaultName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox FaultCode;
        private MaterialSkin.Controls.MaterialRaisedButton btnCancel;
        private MaterialSkin.Controls.MaterialRaisedButton btnSave;
        private System.Windows.Forms.CheckBox chkstatus;
        private System.Windows.Forms.Label label1;
    }
}
