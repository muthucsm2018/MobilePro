namespace MobilePro
{
    partial class frmMainScreen
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnDayEnd = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnStockPurchase = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMasterTables = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnBills = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnExpense = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnSales = new MaterialSkin.Controls.MaterialRaisedButton();
            this.lnklblLogout = new System.Windows.Forms.LinkLabel();
            this.pnlSub = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gpBox3 = new System.Windows.Forms.GroupBox();
            this.gpBox2 = new System.Windows.Forms.GroupBox();
            this.gpBox1 = new System.Windows.Forms.GroupBox();
            this.StatusBarMain = new System.Windows.Forms.StatusStrip();
            this.statusBarUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarUserId = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBarRole = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlMain.SuspendLayout();
            this.pnlSub.SuspendLayout();
            this.StatusBarMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Controls.Add(this.btnDayEnd);
            this.pnlMain.Controls.Add(this.btnStockPurchase);
            this.pnlMain.Controls.Add(this.btnMasterTables);
            this.pnlMain.Controls.Add(this.btnBills);
            this.pnlMain.Controls.Add(this.btnExpense);
            this.pnlMain.Controls.Add(this.btnSales);
            this.pnlMain.Controls.Add(this.lnklblLogout);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMain.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1064, 69);
            this.pnlMain.TabIndex = 1;
            this.pnlMain.Visible = false;
            // 
            // btnDayEnd
            // 
            this.btnDayEnd.Depth = 0;
            this.btnDayEnd.Location = new System.Drawing.Point(309, 10);
            this.btnDayEnd.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnDayEnd.Name = "btnDayEnd";
            this.btnDayEnd.Primary = true;
            this.btnDayEnd.Size = new System.Drawing.Size(89, 49);
            this.btnDayEnd.TabIndex = 15;
            this.btnDayEnd.Text = "Day End\r\nF4";
            this.btnDayEnd.UseVisualStyleBackColor = true;
            this.btnDayEnd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnDailySales_MouseClick);
            // 
            // btnStockPurchase
            // 
            this.btnStockPurchase.Depth = 0;
            this.btnStockPurchase.Location = new System.Drawing.Point(546, 10);
            this.btnStockPurchase.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnStockPurchase.Name = "btnStockPurchase";
            this.btnStockPurchase.Primary = true;
            this.btnStockPurchase.Size = new System.Drawing.Size(125, 49);
            this.btnStockPurchase.TabIndex = 12;
            this.btnStockPurchase.Text = "Stock Purchase\r\nF6";
            this.btnStockPurchase.UseVisualStyleBackColor = true;
            this.btnStockPurchase.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnStockPurchase_MouseClick);
            // 
            // btnMasterTables
            // 
            this.btnMasterTables.Depth = 0;
            this.btnMasterTables.Location = new System.Drawing.Point(412, 10);
            this.btnMasterTables.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMasterTables.Name = "btnMasterTables";
            this.btnMasterTables.Primary = true;
            this.btnMasterTables.Size = new System.Drawing.Size(118, 49);
            this.btnMasterTables.TabIndex = 11;
            this.btnMasterTables.Text = "Master Tables\r\nF5";
            this.btnMasterTables.UseVisualStyleBackColor = true;
            this.btnMasterTables.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMasterTables_MouseClick);
            // 
            // btnBills
            // 
            this.btnBills.Depth = 0;
            this.btnBills.Location = new System.Drawing.Point(12, 10);
            this.btnBills.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnBills.Name = "btnBills";
            this.btnBills.Primary = true;
            this.btnBills.Size = new System.Drawing.Size(82, 49);
            this.btnBills.TabIndex = 10;
            this.btnBills.Text = "Service\r\nF1";
            this.btnBills.UseVisualStyleBackColor = true;
            this.btnBills.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnBills_MouseClick);
            // 
            // btnExpense
            // 
            this.btnExpense.Depth = 0;
            this.btnExpense.Location = new System.Drawing.Point(207, 10);
            this.btnExpense.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Primary = true;
            this.btnExpense.Size = new System.Drawing.Size(85, 49);
            this.btnExpense.TabIndex = 7;
            this.btnExpense.Text = "Expense\r\nF3";
            this.btnExpense.UseVisualStyleBackColor = true;
            this.btnExpense.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExpense_MouseClick);
            // 
            // btnSales
            // 
            this.btnSales.Depth = 0;
            this.btnSales.Location = new System.Drawing.Point(109, 10);
            this.btnSales.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnSales.Name = "btnSales";
            this.btnSales.Primary = true;
            this.btnSales.Size = new System.Drawing.Size(82, 49);
            this.btnSales.TabIndex = 6;
            this.btnSales.Text = "Sales\r\nF2";
            this.btnSales.UseVisualStyleBackColor = true;
            this.btnSales.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnSales_MouseClick);
            // 
            // lnklblLogout
            // 
            this.lnklblLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lnklblLogout.BackColor = System.Drawing.Color.Black;
            this.lnklblLogout.Enabled = false;
            this.lnklblLogout.Font = new System.Drawing.Font("Verdana", 7.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnklblLogout.ForeColor = System.Drawing.Color.White;
            this.lnklblLogout.Image = global::MobilePro.Properties.Resources.Alert;
            this.lnklblLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnklblLogout.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnklblLogout.LinkColor = System.Drawing.Color.White;
            this.lnklblLogout.Location = new System.Drawing.Point(844, 10);
            this.lnklblLogout.Name = "lnklblLogout";
            this.lnklblLogout.Size = new System.Drawing.Size(79, 52);
            this.lnklblLogout.TabIndex = 9;
            this.lnklblLogout.TabStop = true;
            this.lnklblLogout.Text = "LOG OUT\r\nF10";
            this.lnklblLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lnklblLogout.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnk_LinkClicked);
            // 
            // pnlSub
            // 
            this.pnlSub.BackColor = System.Drawing.Color.White;
            this.pnlSub.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlSub.Controls.Add(this.lblTitle);
            this.pnlSub.Controls.Add(this.gpBox3);
            this.pnlSub.Controls.Add(this.gpBox2);
            this.pnlSub.Controls.Add(this.gpBox1);
            this.pnlSub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSub.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlSub.Location = new System.Drawing.Point(0, 69);
            this.pnlSub.Name = "pnlSub";
            this.pnlSub.Size = new System.Drawing.Size(1064, 664);
            this.pnlSub.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblTitle.Location = new System.Drawing.Point(6, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(52, 16);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "label1";
            // 
            // gpBox3
            // 
            this.gpBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpBox3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox3.Location = new System.Drawing.Point(641, 49);
            this.gpBox3.Name = "gpBox3";
            this.gpBox3.Size = new System.Drawing.Size(286, 601);
            this.gpBox3.TabIndex = 2;
            this.gpBox3.TabStop = false;
            // 
            // gpBox2
            // 
            this.gpBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpBox2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox2.Location = new System.Drawing.Point(323, 49);
            this.gpBox2.Name = "gpBox2";
            this.gpBox2.Size = new System.Drawing.Size(296, 601);
            this.gpBox2.TabIndex = 1;
            this.gpBox2.TabStop = false;
            // 
            // gpBox1
            // 
            this.gpBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gpBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpBox1.Location = new System.Drawing.Point(10, 46);
            this.gpBox1.Name = "gpBox1";
            this.gpBox1.Size = new System.Drawing.Size(296, 601);
            this.gpBox1.TabIndex = 0;
            this.gpBox1.TabStop = false;
            // 
            // StatusBarMain
            // 
            this.StatusBarMain.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBarUserName,
            this.StatusBarUserId,
            this.statusBarRole});
            this.StatusBarMain.Location = new System.Drawing.Point(0, 711);
            this.StatusBarMain.Name = "StatusBarMain";
            this.StatusBarMain.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusBarMain.Size = new System.Drawing.Size(1064, 22);
            this.StatusBarMain.TabIndex = 5;
            this.StatusBarMain.Text = "statusStrip1";
            // 
            // statusBarUserName
            // 
            this.statusBarUserName.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarUserName.Name = "statusBarUserName";
            this.statusBarUserName.Size = new System.Drawing.Size(0, 0);
            // 
            // StatusBarUserId
            // 
            this.StatusBarUserId.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusBarUserId.Name = "StatusBarUserId";
            this.StatusBarUserId.Size = new System.Drawing.Size(16, 17);
            this.StatusBarUserId.Text = "|";
            // 
            // statusBarRole
            // 
            this.statusBarRole.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusBarRole.Name = "statusBarRole";
            this.statusBarRole.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 733);
            this.Controls.Add(this.StatusBarMain);
            this.Controls.Add(this.pnlSub);
            this.Controls.Add(this.pnlMain);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "frmMainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "MOBILE PRO - Mobile Sales and Service Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FormClosing);
            this.Load += new System.EventHandler(this.frm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMainScreen_KeyDown);
            this.pnlMain.ResumeLayout(false);
            this.pnlSub.ResumeLayout(false);
            this.pnlSub.PerformLayout();
            this.StatusBarMain.ResumeLayout(false);
            this.StatusBarMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlSub;
        private System.Windows.Forms.StatusStrip StatusBarMain;
        private System.Windows.Forms.ToolStripStatusLabel statusBarUserName;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarUserId;
        private System.Windows.Forms.ToolStripStatusLabel statusBarRole;
        private System.Windows.Forms.LinkLabel lnklblLogout;
        private System.Windows.Forms.GroupBox gpBox3;
        private System.Windows.Forms.GroupBox gpBox2;
        private System.Windows.Forms.GroupBox gpBox1;
        private System.Windows.Forms.Label lblTitle;
        private MaterialSkin.Controls.MaterialRaisedButton btnExpense;
        private MaterialSkin.Controls.MaterialRaisedButton btnSales;
        private MaterialSkin.Controls.MaterialRaisedButton btnBills;
        private MaterialSkin.Controls.MaterialRaisedButton btnStockPurchase;
        private MaterialSkin.Controls.MaterialRaisedButton btnMasterTables;
        private MaterialSkin.Controls.MaterialRaisedButton btnDayEnd;
    }
}

