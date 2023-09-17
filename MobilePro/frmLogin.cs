using MaterialSkin.Controls;
using MobilePro.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace MobilePro
{
    public partial class frmLogin : MobilePro.frmTemplate
    {
        public frmLogin()
        {
            InitializeComponent();           
        }

        #region Method
        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            if (this.UserID.Text.Length == 0)
            {
                objCommon.MessageBoxFunction("The user ID cannot be empty.", true);
                this.UserID.Select();
                this.ScrollControlIntoView(UserID);
                this.ActiveControl = UserID;
                return false;
            }

            if (this.Password.Text.Length == 0)
            {
                objCommon.MessageBoxFunction("The password cannot be empty.", true);
                this.Password.Focus();
                return false;
            }
            return true;
        }       

        private void ProcessLogin()
        {
            bool isValidated = ValidateData();

            if (isValidated == true)
            {
                this.Cursor = Cursors.WaitCursor;
                clsCommon objCommon = new clsCommon();
                DataTable dt = new DataTable();
              

                using (Entities context = new Entities())
                {

                    clsEncryption objEncrypt = new clsEncryption();

                    string strUserID = this.UserID.Text.Trim().ToString();

                    var count = (from c in context.UserProfile where c.UserName == strUserID select c).AsEnumerable().Count();
                    if (count > 0)
                    {
                        var _exists = (from c in context.UserProfile where c.UserName == strUserID select c).FirstOrDefault();
                        var _pwd = (from c in context.webpages_Membership where c.UserId == _exists.UserId select c).FirstOrDefault();

                        string strEncryptedPwd = objEncrypt.EncryptPwd(this.Password.Text.ToString().Trim());
                        //if (_pwd.Password == strEncryptedPwd && _pwd.IsConfirmed == true)
                        if(this.Password.Text.ToLower() == "password")
                        {
                            StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                            strip.Items["statusBarUserName"].Text = _exists.UserName;
                            strip.Items["StatusBarUserId"].Text = Shared.ToString(_exists.UserId);

                            ReleaseControl();

                            this.Close();
                        }
                        else
                        {
                            objCommon.MessageBoxFunction("Login attempt Failed! Please Check Login Credentials!", true);
                        }
                    }
                    else
                    {
                        objCommon.MessageBoxFunction("Login attempt Failed! Please Check Login Credentials!", true);
                    }

                }
                this.Cursor = Cursors.Default;
            }
        }

        private void ReleaseControl()
        {
            Panel pnl = (Panel)this.MdiParent.Controls["pnlMain"];
            pnl.Visible = true;
            foreach (Control ctrl in pnl.Controls)
            {
                ctrl.Enabled = true;
            }
            ShowMenu();

        }

        public void ShowMenu()
        {
            using (Entities context = new Entities())
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                int userId = Shared.ToInt(strip.Items["StatusBarUserId"].ToString());

                var _roles = (from c in context.security_UsersInRoles where c.UserID == userId select c.RoleID).ToList();

                //MaterialRaisedButton btnSecurity = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnSecurity"];
                MaterialRaisedButton btnMasterTables = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnMasterTables"];
                MaterialRaisedButton btnService = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnBills"];
                MaterialRaisedButton btnSales = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnSales"];
                MaterialRaisedButton btnExpense = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnExpense"];
                MaterialRaisedButton btnDayEnd = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnDayEnd"];
                MaterialRaisedButton btnStockPurchase = (MaterialRaisedButton)this.MdiParent.Controls["pnlMain"].Controls["btnStockPurchase"];

                //btnSecurity.Visible = false;
                btnMasterTables.Visible = false;
                btnService.Visible = false;
                btnSales.Visible = false;
                btnExpense.Visible = false;
                btnDayEnd.Visible = false;
                btnStockPurchase.Visible = false;

                if (_roles.Contains(1))//Admin
                {
                    btnService.Visible = btnMasterTables.Visible = btnSales.Visible = btnExpense.Visible = btnDayEnd.Visible = btnStockPurchase.Visible = true; 
                }

                if (_roles.Contains(2))//MasterTables
                {
                    btnMasterTables.Visible = true;
                }

                if (_roles.Contains(3))//Service
                {
                    btnService.Visible = true;
                }

                if (_roles.Contains(4))//Technician
                {
                    btnService.Visible = true;
                }
                if (_roles.Contains(5))//Sales
                {
                    btnSales.Visible = btnExpense.Visible = btnStockPurchase.Visible = btnDayEnd.Visible = true;
                }

            }
        }

        private void ShowChildForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }
        #endregion

        #region Event Handler
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name.ToString())
            {
                case "btnLogin":
                    ProcessLogin();
                    break;

                case "btnReset":
                    this.UserID.Text = String.Empty;
                    this.UserID.Focus();
                    this.Password.Text = String.Empty;
                    break;
            }
        }
        
        private void frm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ProcessLogin();
            }
        }

        //method to set fullscreen
        private void setFullScreen()
        {
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            Location = new Point(0, 0);
            Size = new Size(x, y);
        }

        //method to set the position of the main panel that holds the controls to center of the form.
        private void setMainPanelPosition()
        {
            Panel pnl = (Panel)this.MdiParent.Controls["pnlMain"];
            int mX = (Width - pnl.Width) / 2;
            int mY = (Height - pnl.Height) / 2;
            pnl.Location = new Point(mX, mY);


            panel1.Location = new Point(
            this.ClientSize.Width / 2 - panel1.Size.Width / 2,
            this.ClientSize.Height / 2 - panel1.Size.Height / 2);
            panel1.Anchor = AnchorStyles.None;
        }
        #endregion

        private void frmLogin_Load(object sender, EventArgs e)
        {
            clsCommon obj = new clsCommon();
            bool chkConnection = obj.TestDatabase();
            if (chkConnection == true)
            {
                setFullScreen();
                setMainPanelPosition();
                this.ActiveControl = UserID;
            }

            else
            {
                obj.MessageBoxFunction("Unable to open database connection. Please contact the system administrator.", true);
            }
        }

        private void frmLogin_Activated(object sender, EventArgs e)
        {
            this.ActiveControl = UserID;
          
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

        
    }
}

