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
    public partial class frmBrands : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        IPagedList<BrandsModel> list;
        
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

        public frmBrands()
        {
            InitializeComponent();
        }

        #region Method

        public class BrandsModel
        {
            public string BrandCode { get; set; }

            public string BrandName { get; set; }

            public string BrandDesc { get; set; }

            public string Status { get; set; }           

        }

        public async Task<IPagedList<BrandsModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_Brands(txtBrandName.Text, 1, "Brands",1)
                                select new BrandsModel
                                     {
                                         BrandCode = Shared.ToString(c.BrandCode),
                                         BrandName = c.BrandName,
                                         BrandDesc = c.BrandDesc,
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
                    case "BrandCode":
                        dc.Width = 125;
                        dc.HeaderText = "BrandCode";
                        dc.Visible = false;
                        break;

                    case "BrandName":
                        dc.Width = 100;
                        dc.HeaderText = "NAME";
                        break;

                    case "BrandDesc":
                        dc.Width = 150;
                        dc.HeaderText = "DESC";
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

            //this.dt = objCommon.SystemBrandGet(null, "");
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

            if (Shared.ToInt(BrandName.Text) == 0)
            {
                objCommon.MessageBoxFunction("Brand Name is Required.", true);
                this.BrandName.Focus();
                return false;
            }

            using (Entities context = new Entities())
            {
                var _catname = Shared.ToString(this.BrandName.Text).ToUpper().Trim();
                var exists = context.Brands.AsEnumerable().Count(p => p.BrandName.ToUpper().Trim() == _catname );
                if (exists > 0 )
                {
                    if (this.BrandCode.Text == "")
                    {
                        objCommon.MessageBoxFunction("Brand Name Already Exists!", true);
                        this.BrandName.Focus();
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
                                _affectedRows = context.sp_frm_add_upd_Brand(
                                    Shared.ToInt(BrandCode.Text),
                                    Shared.ToString(BrandName.Text).ToUpper(),
                                    Shared.ToString(Description.Text).Length > 0 ? Shared.ToString(Description.Text).ToUpper() : Shared.ToString(BrandName.Text).ToUpper(),
                                    chkstatus.Checked,
                                    Shared.ToInt(userId),
                                    "Brands"
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
            BrandName.Focus();
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {

            }
        }

        #endregion

        private void frmBrands_KeyDown(object sender, KeyEventArgs e)
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
                BrandCode.Text = BrandName.Text = Description.Text = "";
                //chkstatus.Checked = false;
                BrandName.Focus();
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
                BrandCode.Text = Shared.ToString(row.Cells[0].Value);
                BrandName.Text = Shared.ToString(row.Cells[1].Value);
                Description.Text = Shared.ToString(row.Cells[2].Value);
                if (Shared.ToString(row.Cells[3].Value) == "Active")
                {
                    chkstatus.Checked = true;
                }
                else
                    chkstatus.Checked = false;
                BrandName.Focus();
               
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

