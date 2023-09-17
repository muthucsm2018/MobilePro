using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using MobilePro.Classes;
using System.Data.SqlClient;
using System.Globalization;


namespace MobilePro
{
    public partial class frmExpenseVendors : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        IPagedList<VendorsModel> list;
        
        clsCommon objmsg = new clsCommon();

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        #endregion

        public frmExpenseVendors()
        {
            InitializeComponent();
        }

        #region Method

        public class VendorsModel
        {
            public string VendorCode { get; set; }

            public string VendorName { get; set; }

            public string Status { get; set; }

        }


        public async Task<IPagedList<VendorsModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_ExpenseVendors(txtExpenseVendorName.Text, 1, "ExpenseVendors")
                                select new VendorsModel
                                     {
                                         VendorCode = Shared.ToString(c.VendorCode),
                                         VendorName = c.VendorName,
                                         Status = Shared.ToString(c.Status) == "1" ? "Active" : "InActive",
                                     }).ToList()
                                    .ToPagedList(pageNumber, pageSize);
                    }
                });
        }

        private void SetupDataGrid()
        {

            foreach (DataGridViewColumn dc in dgvResult.Columns)
            {
                dc.SortMode = DataGridViewColumnSortMode.Automatic;

                switch (dc.Name.ToString())
                {
                    case "VendorCode":
                        dc.Width = 125;
                        dc.HeaderText = "VendorCode";
                        dc.Visible = false;
                        break;

                    case "VendorName":
                        dc.Width = 175;
                        dc.HeaderText = "NAME";
                        break;                  

                    case "Status":
                        dc.Width = 75;
                        dc.HeaderText = "STATUS";
                        break;                   

                    default:
                        dc.Visible = false;
                        break;
                }
            }
        }

        private async void ListBillData()
        {
            clsCommon objCommon = new clsCommon();

            StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
            string userName = strip.Items["statusBarUserName"].ToString();

            //this.dt = objCommon.SystemVendorGet(null, "");
            list = await GetPagedListAsync();
           
            if (list != null)
            {
                this.dgvResult.DataSource = list.ToList();
            }
            SetupDataGrid();           

        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            if (Shared.ToInt(VendorName.Text) == 0)
            {
                objCommon.MessageBoxFunction("Source Name is Required.", true);
                this.VendorName.Focus();
                return false;
            }

            using (Entities context = new Entities())
            {
                var _catname = Shared.ToString(this.VendorName.Text).ToUpper().Trim();
                var exists = context.Vendors.AsEnumerable().Count(p => p.VendorName.ToUpper().Trim() == _catname );
                if (exists > 0 )
                {
                    if (this.ExpenseVendorCode.Text == "")
                    {
                        objCommon.MessageBoxFunction("Source Name Already Exists!", true);
                        this.VendorName.Focus();
                        return false;
                    }
                }
            }

            return true;
        }


        #endregion

        #region Event Handler

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsCommon objCommon = new clsCommon();

            switch (btn.Name.ToString())
            {

                case "btnClose":
                    this.ParentForm.Controls["pnlSub"].Show();
                    this.Close();
                    break;

                case "btnSearch":

                    ListBillData();
                    SetupDataGrid();
                    break;

                case "btnCancel":

                    btnclear_Click(null, null);
                    break;

                case "btnSave":
                    bool isValidated = ValidateData();
                    int _affectedRows = 0;

                    if (isValidated == true)
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();
                        using (Entities context = new Entities())
                        {
                            try
                            {
                                _affectedRows = context.sp_frm_add_upd_ExpenseVendors(
                                    Shared.ToInt(ExpenseVendorCode.Text),
                                    Shared.ToString(VendorName.Text).ToUpper(),
                                    chkstatus.Checked,
                                    Shared.ToInt(userId),
                                    "ExpenseVendors"
                                );

                                objCommon.MessageBoxFunction("Save completed.", false);
                                ListBillData();
                                btnclear_Click(null, null);

                            }
                            catch (Exception ex)
                            {
                                objCommon.MessageBoxFunction(ex.Message, true);
                            }
                        }
                    }
                    else
                    {
                        objCommon.MessageBoxFunction("Validation Error!", true);
                    }
                    break;

            }
        }       

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dt != null)
                this.dt.Dispose();
        }

        private void frm_Activated(object sender, EventArgs e)
        {
            ListBillData();
            LoadSearchDatas();
            chkstatus.Checked = true;
            VendorName.Focus();
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {

            }
        }

        #endregion

        private void frmExpenseVendors_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnClose;
                btn_Click(btn, null);
            }          

            if (e.Control && e.KeyCode == Keys.S)       // Ctrl S
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnSave;
                btn_Click(btn, null);
            }
            if (e.Control && e.KeyCode == Keys.C)       // Ctrl S
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnCancel;
                btn_Click(btn, null);
            }

        }
      
        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button btn = (Button)btnSearch;
                btn_Click(btn, null);
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                ExpenseVendorCode.Text = VendorName.Text = "";
                //chkstatus.Checked = false;
                VendorName.Focus();
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = dgvResult.Rows[e.RowIndex];
                ExpenseVendorCode.Text = Shared.ToString(row.Cells[0].Value);
                VendorName.Text = Shared.ToString(row.Cells[1].Value);
                if (Shared.ToString(row.Cells[2].Value) == "Active")
                {
                    chkstatus.Checked = true;
                }
                else
                    chkstatus.Checked = false;
                VendorName.Focus();
               
            }
            catch(Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void btnSearch_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnSearch;
            btn_Click(btn, null);
        }

        private void btnSave_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnSave;
            btn_Click(btn, null);
        }

        private void btnCancel_MouseClick(object sender, MouseEventArgs e)
        {
            Button btn = (Button)btnCancel;
            btn_Click(btn, null);
        }
    }    
}

