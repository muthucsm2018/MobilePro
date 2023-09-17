namespace MobilePro
{
    partial class frmExpenseAdd
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
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsuspend = new System.Windows.Forms.Button();
            this.btnsettle = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.Remarks = new System.Windows.Forms.TextBox();
            this.ExpenseCode = new System.Windows.Forms.TextBox();
            this.Charge = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
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
            this.btnClose.Location = new System.Drawing.Point(660, 498);
            this.btnClose.Size = new System.Drawing.Size(130, 35);
            this.btnClose.TabIndex = 4;
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
            this.btnSave.Location = new System.Drawing.Point(525, 498);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 35);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save (Ctrl + S)";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnclear
            // 
            this.btnclear.BackColor = System.Drawing.Color.SteelBlue;
            this.btnclear.ForeColor = System.Drawing.Color.White;
            this.btnclear.Location = new System.Drawing.Point(225, 22);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(75, 42);
            this.btnclear.TabIndex = 5;
            this.btnclear.Text = "CLEAR\r\nF3";
            this.btnclear.UseVisualStyleBackColor = false;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsuspend
            // 
            this.btnsuspend.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsuspend.ForeColor = System.Drawing.Color.White;
            this.btnsuspend.Location = new System.Drawing.Point(306, 22);
            this.btnsuspend.Name = "btnsuspend";
            this.btnsuspend.Size = new System.Drawing.Size(75, 42);
            this.btnsuspend.TabIndex = 6;
            this.btnsuspend.Text = "DELETE\r\nF4";
            this.btnsuspend.UseVisualStyleBackColor = false;
            this.btnsuspend.Click += new System.EventHandler(this.btnsuspend_Click);
            // 
            // btnsettle
            // 
            this.btnsettle.BackColor = System.Drawing.Color.SteelBlue;
            this.btnsettle.ForeColor = System.Drawing.Color.White;
            this.btnsettle.Location = new System.Drawing.Point(387, 22);
            this.btnsettle.Name = "btnsettle";
            this.btnsettle.Size = new System.Drawing.Size(75, 42);
            this.btnsettle.TabIndex = 7;
            this.btnsettle.Text = "SAVE\r\nF5";
            this.btnsettle.UseVisualStyleBackColor = false;
            this.btnsettle.Click += new System.EventHandler(this.btnsettle_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.cmbSource);
            this.panel1.Controls.Add(this.Remarks);
            this.panel1.Controls.Add(this.ExpenseCode);
            this.panel1.Controls.Add(this.Charge);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(477, 384);
            this.panel1.TabIndex = 18;
            // 
            // cmbSource
            // 
            this.cmbSource.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(180, 9);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(275, 27);
            this.cmbSource.TabIndex = 0;
            this.cmbSource.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbSource_KeyDown);
            // 
            // Remarks
            // 
            this.Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Remarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remarks.Location = new System.Drawing.Point(179, 101);
            this.Remarks.Multiline = true;
            this.Remarks.Name = "Remarks";
            this.Remarks.Size = new System.Drawing.Size(275, 72);
            this.Remarks.TabIndex = 2;
            // 
            // ExpenseCode
            // 
            this.ExpenseCode.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ExpenseCode.Location = new System.Drawing.Point(180, 340);
            this.ExpenseCode.Name = "ExpenseCode";
            this.ExpenseCode.Size = new System.Drawing.Size(275, 26);
            this.ExpenseCode.TabIndex = 8;
            this.ExpenseCode.Visible = false;
            // 
            // Charge
            // 
            this.Charge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.Charge.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Charge.Location = new System.Drawing.Point(179, 55);
            this.Charge.Name = "Charge";
            this.Charge.Size = new System.Drawing.Size(276, 26);
            this.Charge.TabIndex = 1;
            this.Charge.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "AMOUNT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "REMARKS";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "SOURCE";
            // 
            // frmExpenseAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1020, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnsettle);
            this.Controls.Add(this.btnsuspend);
            this.Controls.Add(this.btnclear);
            this.Controls.Add(this.btnSave);
            this.HeaderDescription = "New Service Bill";
            this.KeyPreview = true;
            this.Name = "frmExpenseAdd";
            this.Activated += new System.EventHandler(this.frmBrandAdd_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBrandAdd_KeyDown);
            this.Controls.SetChildIndex(this.btnSave, 0);
            this.Controls.SetChildIndex(this.btnclear, 0);
            this.Controls.SetChildIndex(this.btnsuspend, 0);
            this.Controls.SetChildIndex(this.btnsettle, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsuspend;
        private System.Windows.Forms.Button btnsettle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Remarks;
        private System.Windows.Forms.TextBox ExpenseCode;
        private System.Windows.Forms.TextBox Charge;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSource;
    }
}
