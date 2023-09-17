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
    public partial class frmProducts : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<ProductsModel> list;
        private int? _categorycode = null;
        
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

        public frmProducts()
        {
            InitializeComponent();
        }

        #region Method

        public class ProductsModel
        {
            public string ProductID { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string CategoryCode { get; set; }

            public string CategoryName { get; set; }

            public string Status { get; set; }

        }

        public async Task<IPagedList<ProductsModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_Products(_categorycode, txtProductName.Text, 1, "Categories", 1)
                                select new ProductsModel
                                     {
                                         ProductID = Shared.ToString(c.ProductID),
                                         CategoryCode = Shared.ToString(c.CategoryCode),
                                         CategoryName = c.CategoryName,
                                         ProductCode = c.ProductCode,
                                         ProductDesc = c.ProductDesc,
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
                    case "ProductID":
                        dc.Width = 50;
                        dc.HeaderText = "ProductID";
                        dc.Visible = false;
                        break;                   

                    case "ProductCode":
                        dc.Width = 90;
                        dc.HeaderText = "PRODUCT CODE";
                       
                        break;

                    case "CategoryCode":
                        dc.Width = 50;
                        dc.HeaderText = "CategoryCode";
                        dc.Visible = false;
                        break;

                    case "CategoryName":
                        dc.Width = 100;
                        dc.HeaderText = "CATEGORY";
                        break;

                    case "ProductDesc":
                        dc.Width = 275;
                        dc.HeaderText = "PRODUCT DESC";
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
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;

            if (list != null)
            {
                BindingSource source = new BindingSource();
                source.DataSource = list.ToList();
                this.dgvResult.Columns.Clear();
                this.dgvResult.DataSource = source;
                this.dgvResult.ClearSelection();
            }
            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
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

            if ((Shared.ToInt(cmbCategoryCode.SelectedIndex) == 0 && this.ProductID.Enabled == true))
            {
                objCommon.MessageBoxFunction("Category is Required.", true);
                this.cmbCategoryCode.Focus();
                return false;
            }

            if (Shared.ToInt(ProductCode.Text) == 0)
            {
                objCommon.MessageBoxFunction("Product Code is Required.", true);
                this.ProductCode.Focus();
                return false;
            }

            
            using (Entities context = new Entities())
            {
                var _catname = Shared.ToString(this.ProductCode.Text).ToUpper().Trim();
                var exists = context.Products.AsEnumerable().Count(p => p.ProductCode.ToUpper().Trim() == _catname);
                if (exists > 0)
                {
                    if (this.ProductID.Enabled == true)
                    {
                        objCommon.MessageBoxFunction("Product Code Already Exists!", true);
                        this.ProductCode.Focus();
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
                    _categorycode = Shared.ToInt(((ComboboxItem)(cmbCategoryCodeSearch.SelectedItem)).Value);
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
                                _affectedRows = context.sp_frm_add_upd_Product(
                                    Shared.ToInt(ProductID.Text),                                  
                                    Shared.ToString(ProductCode.Text).ToUpper(),
                                    Shared.ToString(Description.Text).Length > 0 ? Shared.ToString(Description.Text).ToUpper() : Shared.ToString(ProductCode.Text).ToUpper(),
                                    Shared.ToInt(((ComboboxItem)(cmbCategoryCode.SelectedItem)).Value),
                                    chkstatus.Checked,
                                    Shared.ToInt(userId),
                                    "Products"
                                );

                                try
                                {
                                   context.Database.ExecuteSqlCommand("update SalesStocks set [ProductCode] = '" + Shared.ToString(ProductCode.Text).ToUpper() + "'  where ProductCode = '" + oldproductcode.Text + "'");
                                   context.SaveChanges();
                                }
                                catch(Exception ex) { }

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
            cmbCategoryCode.Focus();
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {
                IList<ComboboxItem> CategoryList = new List<ComboboxItem>();

                CategoryList = (from c in context.sp_frm_get_parm_Categories(1, "Categories",1)
                              select new ComboboxItem
                              {
                                  Text = c.CategoryName,
                                  Value = Shared.ToString(c.CategoryCode)
                              }).ToList();

                cmbCategoryCode.BindingContext = new BindingContext();
                cmbCategoryCode.DataSource = CategoryList;
                cmbCategoryCode.DisplayMember = "Text";
                cmbCategoryCode.ValueMember = "Value";

                cmbCategoryCodeSearch.BindingContext = new BindingContext();
                cmbCategoryCodeSearch.DataSource = CategoryList;
                cmbCategoryCodeSearch.DisplayMember = "Text";
                cmbCategoryCodeSearch.ValueMember = "Value";
            }
        }

        private async void btnPrevious_Click(object sender, EventArgs e)
        {
            list = await GetPagedListAsync(--pageNumber);
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;

            if (list != null)
            {
                this.dgvResult.DataSource = list.ToList();
            }
            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            list = await GetPagedListAsync(++pageNumber);
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;

            if (list != null)
            {
                this.dgvResult.DataSource = list.ToList();
            }
            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
        }

        #endregion

        private void frmProducts_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnClose;
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.F10)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = ((Button)(btnreprint));
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
                ProductCode.Text = Description.Text = "";                
                ProductID.Text = "";
                cmbCategoryCode.Enabled = true;
                ProductID.Enabled = true;               
                ProductCode.Focus();
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
               
                IList<ComboboxItem> Categorydt = (IList<ComboboxItem>)cmbCategoryCode.DataSource;

                for (int i = 0; i < Categorydt.Count; ++i)
                {
                    string displayText = Categorydt[i].Text.ToString();
                    string valueItem = Categorydt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == Shared.ToString(row.Cells[3].Value))
                        {
                            this.cmbCategoryCode.SelectedIndex = i;
                            break;
                        }
                    }

                }
                ProductID.Text = Shared.ToString(row.Cells[0].Value);
                ProductCode.Text = oldproductcode.Text = Shared.ToString(row.Cells[1].Value);
                Description.Text = Shared.ToString(row.Cells[2].Value);
                if (Shared.ToString(row.Cells[5].Value) == "Active")
                {
                    chkstatus.Checked = true;
                }
                else
                    chkstatus.Checked = false;

                cmbCategoryCode.Enabled = false;
                ProductID.Enabled = false;
                Description.Focus();
               
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

        private void btnSave_Click(object sender, EventArgs e)
        {
           
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbCategoryCodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbCategoryCodeSearch.Text.Length >= 0)
                cmbCategoryCodeSearch.DroppedDown = true;
        }

        private void cmbCategoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbCategoryCode.Text.Length >= 0)
                cmbCategoryCode.DroppedDown = true;
        }
    }    
}

