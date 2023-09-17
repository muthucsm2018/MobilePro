using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Resources;
using System.Linq;
using MobilePro.Classes;

namespace MobilePro
{
    public partial class frmMainScreen : Form
    {
        #region Constructor

        public frmMainScreen()
        {
            InitializeComponent();
        }

        #endregion

        #region Method
        private void SetupButton(string btnName, string btnText,
            int x, int y, string imgName, string ModuleNm, string gpBoxNm)
        {
            // ------------------------------------------------
            // 1. Setup sub button properties.
            // 2. Setup sub button event handlers. 
            // 3. Add the sub button to the sub panel.
            // ------------------------------------------------
            MaterialSkin.Controls.MaterialRaisedButton btn = new MaterialSkin.Controls.MaterialRaisedButton();
            btn.Name = btnName;
            btn.Text = btnText;
            btn.Depth = 0;
            btn.Location = new Point(x, y);
            btn.MouseState = MaterialSkin.MouseState.HOVER;
            btn.Size = new System.Drawing.Size(255, 42);
            btn.Image = GetImage(imgName);
            btn.Primary = true;
            btn.UseVisualStyleBackColor = true;
            btn.ImageAlign = ContentAlignment.MiddleLeft;
            btn.TextImageRelation = TextImageRelation.ImageBeforeText;
            btn.Click += new EventHandler(btnSub_Click);


            switch (gpBoxNm)
            {
                case "gpBox1":
                    this.gpBox1.Controls.Add(btn);
                    break;

                case "gpBox2":
                    this.gpBox2.Controls.Add(btn);
                    break;

                case "gpBox3":
                    this.gpBox3.Controls.Add(btn);
                    break;
            }
        }

        private void ShowGroupBox(string GroupNm)
        {
            this.gpBox1.Visible = false;
            this.gpBox2.Visible = false;
            this.gpBox3.Visible = false;

            switch (GroupNm)
            {

                case "Security":
                    this.lblTitle.Text = "SECURITY";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = false;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "Users";
                    break;

                case "Bills":
                    this.lblTitle.Text = "SERVICE BILLS";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = false;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "SERVICE BILLS";
                    break;

                case "MasterTables":
                    this.lblTitle.Text = "MASTERTABLES";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = true;
                    this.gpBox3.Visible = true;
                    this.gpBox1.Text = "Service";
                    this.gpBox2.Text = "Sales";
                    this.gpBox3.Text = "Others";
                    break;

                case "StockPurchase":
                    this.lblTitle.Text = "STOCK PURCHASE";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = true;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "Fix Price";
                    this.gpBox2.Text = "Purchase";
                    break;

                case "Reports":
                    this.lblTitle.Text = "Reports";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = true;
                    this.gpBox3.Visible = true;
                    this.gpBox1.Text = "Service";
                    this.gpBox2.Text = "Sales";
                    this.gpBox3.Text = "Others";
                    break;


                case "Sales":
                    this.lblTitle.Text = "SALES";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = false;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "Sales";
                    break;

                case "Expenses":
                    this.lblTitle.Text = "EXPENSES";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = false;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "EXPENSES";
                    break;

                case "DayEnd":
                    this.lblTitle.Text = "DAY END";
                    this.gpBox1.Visible = true;
                    this.gpBox2.Visible = false;
                    this.gpBox3.Visible = false;
                    this.gpBox1.Text = "DAY END";
                    break;

            }

        }

        private void LockControl()
        {
            foreach (Control ctrl in this.pnlMain.Controls)
            {
                if (ctrl.Name.ToString() != "lnklblAbout")
                    ctrl.Enabled = false;
            }
        }

        private void ClearUserName()
        {
            this.StatusBarMain.Items["statusBarUserName"].Text = String.Empty;
            this.StatusBarMain.Items["statusBarRole"].Text = String.Empty;
            //this.StatusBarMain.Items["ModemStatus"].Text = String.Empty;
        }

        private Bitmap GetImage(string strImage)
        {
            // ------------------------------------------------
            // 1. Gets image file from Resources.resx.
            // ------------------------------------------------
            ResourceManager rscManager = new ResourceManager(
                "MobilePro.Properties.Resources", GetType().Assembly);
            Bitmap img = (Bitmap)rscManager.GetObject(strImage);
            return img;
        }

        private void ShowChildForm(Form frm)
        {
            // ------------------------------------------------
            // 1. Setup child form properties.
            // 2. Show child form.
            // 3. Hile sub panel.
            // ------------------------------------------------
            frm.MdiParent = this;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            this.pnlSub.Hide();
        }

        private void CloseChildForm()
        {
            // ------------------------------------------------
            // 1. Closes all child forms.
            // ------------------------------------------------
            Form[] frms = this.MdiChildren;
            if (frms.Length > 0)
            {
                for (int i = 0; i < frms.Length; i++)
                    frms[i].Close();
            }
        }
        #endregion

        #region EventHandler
        private void frm_Load(object sender, EventArgs e)
        {
            clsCommon obj = new clsCommon();
            bool chkConnection = obj.TestDatabase();
            if (chkConnection == true)
            {
                frmLogin frm = new frmLogin();
                ShowChildForm(frm);
            }
            else
            {
                this.pnlSub.Visible = false;
                obj.MessageBoxFunction("Unable to open database connection. Please contact the system administrator.", true);
            }
        }

        private void ShowHideButtons()
        {

        }


        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close the application?",
                "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                e.Cancel = false;
                clsCommon obj = new clsCommon();
                obj._connectionStr = null;
                CloseChildForm();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnMain_Click(Object sender, EventArgs e)
        {
            using (Entities context = new Entities())
            {
                // ------------------------------------------------
                // 1. Closes all child forms.
                // 2. Clears sub panel.
                // 3. Setup sub panel.
                // ------------------------------------------------

                CloseChildForm();

                this.gpBox1.Controls.Clear();
                this.gpBox2.Controls.Clear();
                this.gpBox3.Controls.Clear();
                this.pnlSub.Show();

                Button btnTemp = (Button)sender;

                StatusStrip strip = (StatusStrip)this.StatusBarMain;
                string userId = strip.Items["StatusBarUserId"].ToString();
                var auth1 = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 4)); // Service Update User(Technician) & Admin
                var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 3)); // Service Entry User & Admin

                switch (btnTemp.Name)
                {

                    case "btnMasterTables":
                        ShowGroupBox("MasterTables");
                        SetupButton("btnBrands", "&BRANDS (Alt + B)", 20, 30, "Service", "Service", "gpBox1");
                        SetupButton("btnOutSources", "&OUTSOURCES (Alt + O)", 20, 75, "Service", "Service", "gpBox1");
                        //SetupButton("btnCondition", "&CONDITIONS (Alt + C)", 20, 120, "Service", "Service", "gpBox1");
                        //SetupButton("btnFault", "&FAULTS (Alt + F)", 20, 120, "Service", "Service", "gpBox1");
                        SetupButton("btnCategories", "&CATEGORIES (Alt + C)", 20, 30, "Sales", "Sales", "gpBox2");
                        SetupButton("btnProducts", "&PRODUCTS (Alt + P)", 20, 75, "Sales", "Sales", "gpBox2");
                        SetupButton("btnVendors", "&VENDORS (Alt + V)", 20, 120, "Sales", "Sales", "gpBox2");
                        SetupButton("btnExpenseSources", "&EXPENSE SOURCES (Alt + E)", 20, 30, "Others", "Others", "gpBox3");
                        break;


                    case "btnBills":
                        ShowGroupBox("Bills");
                        SetupButton("btnListBills", "&BILLS LIST (Alt + B)", 20, 30, "Bills", "Bill", "gpBox1");
                        if (auth > 0)
                            SetupButton("btnCreateBill", "&NEW SERVICE BILL (Alt + N)", 20, 75, "Bills", "Bill", "gpBox1");
                        //if (auth > 0)
                            //SetupButton("btnDailyService", "&DAILY SERVICE (Alt + D)", 20, 120, "Service", "Service", "gpBox1");
                        //if (auth1 > 0)
                            //SetupButton("btnSMSModem", "&SMS MODEM (Alt + S)", 20, 165, "Service", "Service", "gpBox1");
                        break;


                    case "btnReports":
                        ShowGroupBox("Reports");
                        SetupButton("btnServiceReport", "&SERVICE (Alt + S)", 20, 30, "Reports", "Reports", "gpBox1");
                        SetupButton("btnSalesReport", "&Product Sales (Alt + P)", 20, 30, "Reports", "Reports", "gpBox2");
                        SetupButton("btnStockReports", "&Stocks (Alt + S)", 20, 75, "Reports", "Reports", "gpBox2");
                        SetupButton("btnCategoryReport", "&Category wise Sales (Alt + C)", 20, 120, "Reports", "Reports", "gpBox2");
                        SetupButton("btnExpenseReport", "&Expense (Alt + E)", 20, 30, "Reports", "Reports", "gpBox3");
                        SetupButton("btnUserSalesReport", "&User Sales (Alt + U)", 20, 75, "Reports", "Reports", "gpBox3");
                        SetupButton("btnDailySalesReport", "&Daily Sales (Alt + D)", 20, 120, "Reports", "Reports", "gpBox3");
                        SetupButton("btnMonthlySalesReport", "&Monthly Sales (Alt + M)", 20, 165, "Reports", "Reports", "gpBox3");
                        break;

                    case "btnStockPurchase":
                        ShowGroupBox("StockPurchase");
                        SetupButton("btnFixPrice", "&FIX PRICE (Alt + F)", 20, 30, "StockPurchase", "StockPurchase", "gpBox1");
                        SetupButton("btnListPurchases", "&PURCHASES LIST (Alt + P)", 20, 30, "StockPurchase", "StockPurchase", "gpBox2");
                        SetupButton("btnCreatePurchase", "&NEW PURCHASE (Alt + N)", 20, 75, "StockPurchase", "StockPurchase", "gpBox2");
                        break;

                    //case "btnSecurity":
                        //ShowGroupBox("Security");
                        //SetupButton("btnQueryUser", "&USERS LIST (Alt + U)", 20, 30, "Security", "Security", "gpBox1");
                        //SetupButton("btnCreateUser", "&Create User (Alt + C)", 20, 75, "Security", "Security", "gpBox1");
                        //break;

                    case "btnSales":
                        ShowGroupBox("Sales");
                        SetupButton("btnListSales", "&SALES LIST (Alt + S)", 20, 30, "Sales", "Sale", "gpBox1");
                        SetupButton("btnCreateSale", "&NEW SALES BILL (Alt + N)", 20, 75, "Sales", "Sale", "gpBox1");
                        break;

                    case "btnExpense":
                        ShowGroupBox("Expenses");
                        SetupButton("btnListExpense", "&EXPENSES LIST (Alt + E)", 20, 30, "Expenses", "Expense", "gpBox1");
                        SetupButton("btnCreateExpense", "&ADD EXPENSE (Alt + A)", 20, 75, "Expenses", "Expense", "gpBox1");
                        break;

                    case "btnDayEnd":
                        ShowGroupBox("DayEnd");
                        SetupButton("btnDailySales", "&DAILY SALES (Alt + D)", 20, 30, "DayEnd", "DayEnd", "gpBox1");
                        SetupButton("btnDailyService", "&DAILY SERVICE (Alt + A)", 20, 75, "DayEnd", "DayEnd", "gpBox1");
                        break;

                }
            }
        }

        private void btnSub_Click(Object sender, EventArgs e)
        {
            // ------------------------------------------------
            // 1. Shows appropriate child form.
            // ------------------------------------------------
            Button btnTemp = (Button)sender;
            Form frm = null;

            switch (btnTemp.Name)
            {
                // Master Tables
                case "btnBrands":
                    frm = new frmBrands();
                    ShowChildForm(frm);
                    break;

                case "btnOutSources":
                    frm = new frmOutSources();
                    ShowChildForm(frm);
                    break;

                case "btnCategories":
                    frm = new frmCategories();
                    ShowChildForm(frm);
                    break;

                case "btnProducts":
                    frm = new frmProducts();
                    ShowChildForm(frm);
                    break;

                case "btnVendors":
                    frm = new frmVendors();
                    ShowChildForm(frm);
                    break;

                case "btnExpenseSources":
                    frm = new frmExpenseVendors();
                    ShowChildForm(frm);
                    break;

                case "btnCondition":
                    frm = new frmCondition();
                    ShowChildForm(frm);
                    break;

                case "btnFault":
                    frm = new frmFault();
                    ShowChildForm(frm);
                    break;

                // Stock Purchase
                case "btnFixPrice":
                    frm = new frmFixPrice();
                    ShowChildForm(frm);
                    break;

                case "btnListPurchases":
                    frm = new frmListPurchase();
                    ShowChildForm(frm);
                    break;

                case "btnCreatePurchase":
                    frm = new frmCreatePurchase();
                    ShowChildForm(frm);
                    break;

                // Sales
                case "btnListSales":
                    frm = new frmBills();
                    ShowChildForm(frm);
                    break;

                case "btnCreateSale":
                    frm = new frmBillAdd();
                    ShowChildForm(frm);
                    break;

                // Bills
                case "btnListBills":
                    frm = new frmServiceBills();
                    ShowChildForm(frm);
                    break;

                case "btnCreateBill":
                    frm = new frmServiceBillAdd();
                    ShowChildForm(frm);
                    break;

                case "btnSMSModem":
                    frm = new frmSMSModem();
                    ShowChildForm(frm);
                    break;

                case "btnDailyService":
                    frm = new frmDailyService();
                    ShowChildForm(frm);
                    break;
                // Expenses
                case "btnListExpense":
                    frm = new frmExpenses();
                    ShowChildForm(frm);
                    break;

                case "btnCreateExpense":
                    frm = new frmExpenseAdd();
                    ShowChildForm(frm);
                    break;

                // Daily Sales
                case "btnDailySales":
                    frm = new frmDailySales();
                    ShowChildForm(frm);
                    break;
                //Security
                //case "btnQueryUser":
                //    frm = new frmUsers();
                //    ShowChildForm(frm);
                //    break;


            }
        }

        private void lnk_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lnk = (LinkLabel)sender;

            Form frm;
            switch (lnk.Name.ToString())
            {
                case "lnklblAbout":
                    frm = new frmAbout();
                    frm.ShowDialog();
                    break;

                case "lnklblLogout":
                    LockControl();
                    CloseChildForm();
                    pnlMain.Visible = false;
                    frm = new frmLogin();
                    ShowChildForm(frm);
                    ClearUserName();
                    break;
            }
        }

        #endregion

        private void frmMainScreen_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.F1)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnBills;
                if (btnBills.Visible == true)
                    btnMain_Click(btn, null);
            }

            if (e.KeyCode == Keys.F2)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnSales;
                if (btnSales.Visible == true)
                    btnMain_Click(btn, null);
            }

            if (e.KeyCode == Keys.F3)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnExpense;
                if (btnExpense.Visible == true)
                    btnMain_Click(btn, null);
            }

            if (e.KeyCode == Keys.F4)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnDayEnd;
                if (btnDayEnd.Visible == true)
                    btnMain_Click(btn, null);
            }

            if (e.KeyCode == Keys.F5)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnMasterTables;
                if (btnMasterTables.Visible == true)
                    btnMain_Click(btn, null);
            }

            if (e.KeyCode == Keys.F6)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnStockPurchase;
                if (btnStockPurchase.Visible == true)
                    btnMain_Click(btn, null);
            }

            //if (e.KeyCode == Keys.F7)       // Ctrl-S Save
            //{
            //    // Do what you want here
            //    e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            //    Button btn = (Button)btnSecurity;
            //    if (btnSecurity.Visible == true)
            //        btnMain_Click(btn, null);
            //}



            if (e.KeyCode == Keys.F10)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                LinkLabel btn = (LinkLabel)lnklblLogout;
                lnk_LinkClicked(btn, null);
            }
        }

        private void btnSales_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnSales;
            btnMain_Click(btn, null);
        }

        private void btnExpense_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnExpense;
            btnMain_Click(btn, null);
        }

        private void btnBills_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnBills;
            btnMain_Click(btn, null);
        }

        private void btnDailySales_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnDayEnd;
            btnMain_Click(btn, null);
        }

        private void btnMasterTables_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnMasterTables;
            btnMain_Click(btn, null);
        }

        private void btnStockPurchase_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnStockPurchase;
            btnMain_Click(btn, null);
        }

        private void btnSecurity_MouseClick(object sender, MouseEventArgs e)
        {
            //Button btn = (Button)btnSecurity;
            //btnMain_Click(btn, null);
        }
    }
}