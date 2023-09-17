namespace MobilePro
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Password = new System.Windows.Forms.TextBox();
            this.UserID = new System.Windows.Forms.TextBox();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.btnLogin = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnReset = new MaterialSkin.Controls.MaterialRaisedButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Size = new System.Drawing.Size(271, 23);
            this.lblTitle.Text = "MobilePro Control Panel";
            this.lblTitle.Visible = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.Location = new System.Drawing.Point(941, 734);
            this.btnClose.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Password);
            this.panel1.Controls.Add(this.UserID);
            this.panel1.Controls.Add(this.materialLabel1);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.btnReset);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(461, 273);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 294);
            this.panel1.TabIndex = 42;
            // 
            // Password
            // 
            this.Password.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password.Location = new System.Drawing.Point(112, 170);
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(199, 27);
            this.Password.TabIndex = 53;
            // 
            // UserID
            // 
            this.UserID.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserID.Location = new System.Drawing.Point(112, 103);
            this.UserID.Name = "UserID";
            this.UserID.Size = new System.Drawing.Size(199, 27);
            this.UserID.TabIndex = 52;
            // 
            // materialLabel1
            // 
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(-2, 0);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(402, 58);
            this.materialLabel1.TabIndex = 51;
            this.materialLabel1.Text = "Please Login To Access this Application";
            this.materialLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.Depth = 0;
            this.btnLogin.Location = new System.Drawing.Point(112, 228);
            this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Primary = true;
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 50;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnReset
            // 
            this.btnReset.Depth = 0;
            this.btnReset.Location = new System.Drawing.Point(203, 228);
            this.btnReset.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnReset.Name = "btnReset";
            this.btnReset.Primary = true;
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 49;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = global::MobilePro.Properties.Resources.doing;
            this.pictureBox2.Location = new System.Drawing.Point(60, 171);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(46, 26);
            this.pictureBox2.TabIndex = 44;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = global::MobilePro.Properties.Resources.user1;
            this.pictureBox1.Location = new System.Drawing.Point(60, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 26);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(1032, 764);
            this.Controls.Add(this.panel1);
            this.HeaderDescription = "MobilePro Control Panel";
            this.KeyPreview = true;
            this.Name = "frmLogin";
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frm_KeyPress);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.btnClose, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnLogin;
        private MaterialSkin.Controls.MaterialRaisedButton btnReset;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox UserID;

    }
}
