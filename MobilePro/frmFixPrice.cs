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
    public partial class frmFixPrice : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<StocksModel> list;
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

        public frmFixPrice()
        {
            InitializeComponent();
        }

        #region Method

        public class StocksModel
        {
            public string CategoryCode { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string CategoryName { get; set; }

            public int? Quantity { get; set; }

            public decimal? UnitPrice { get; set; }

            public decimal? SellingPrice { get; set; }

        }

        public async Task<IPagedList<StocksModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_Sales_Stocks(1, _categorycode, txtProductName.Text, 1, "StocksPurchase")
                                select new StocksModel
                                     {
                                         CategoryCode = Shared.ToString(c.CategoryCode),
                                         CategoryName = c.CategoryName,
                                         ProductCode = c.ProductCode,
                                         ProductDesc = c.ProductDesc,
                                         Quantity = Shared.ToInt(c.Quantity),
                                         UnitPrice = Shared.ToDecimal(c.UnitPrice),
                                         SellingPrice = Shared.ToDecimal(c.SellingPrice)
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
                    case "CategoryCode":
                        dc.Width = 50;
                        dc.HeaderText = "CategoryCode";
                        dc.Visible = false;
                        break;

                    case "ProductCode":
                        dc.Width = 50;
                        dc.HeaderText = "ProductCode";
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

                    case "Quantity":
                        dc.Width = 75;
                        dc.HeaderText = "QTY";
                        break;

                    case "UnitPrice":
                        dc.Width = 100;
                        dc.HeaderText = "UNIT COST";
                        break;

                    case "SellingPrice":
                        dc.Width = 130;
                        dc.HeaderText = "SELLING PRICE";
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

            if ((Shared.ToInt(cmbCategoryCode.SelectedIndex) == 0 && this.cmbautocomplete.Enabled == true))
            {
                objCommon.MessageBoxFunction("Category is Required.", true);
                this.cmbCategoryCode.Focus();
                return false;
            }

            if (Shared.ToString(cmbautocomplete.SelectedValue) == "")
            {
                objCommon.MessageBoxFunction("Product Code is Required.", true);
                this.cmbautocomplete.Focus();
                return false;
            }

            //using (Entities context = new Entities())
            //{
            //    var _catname = Shared.ToString(this.ProductCode.Text).ToUpper().Trim();
            //    var exists = context.Products.AsEnumerable().Count(p => p.ProductCode.ToUpper().Trim() == _catname );
            //    if (exists > 0 )
            //    {
            //        if (this.ProductCode.Enabled == true)
            //        {
            //            objCommon.MessageBoxFunction("Product Code Already Exists!", true);
            //            this.ProductCode.Focus();
            //            return false;
            //        }
            //    }
            //}

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
                                var ProductCode = Shared.ToString(((ComboboxItem)(cmbautocomplete.SelectedItem)).Value);
                                //ProductCode = Shared.ToString(ProductCode.Split(',')[1]);
                                _affectedRows = context.sp_frm_add_upd_Sales_Stock(1,
                                    Shared.ToInt(((ComboboxItem)(cmbCategoryCode.SelectedItem)).Value),
                                    ProductCode,
                                    0,
                                    Shared.ToDecimal(UnitPrice.Text),
                                    Shared.ToDecimal(SellingPrice.Text),
                                    Shared.ToInt(userId),
                                    "StocksPurchase"
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
            cmbCategoryCode.Focus();
            try
            {
                cmbautocomplete.AutoCompleteMode = AutoCompleteMode.None;
                cmbautocomplete.DataSource = Autocomplete("");
            }
            catch
            {

            }
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

        public IList<ComboboxItem> Autocomplete(string term)
        {
            using (Entities context = new Entities())
            {
                var result = new List<KeyValuePair<string, string>>();

                IList<ComboboxItem> ItemsList = new List<ComboboxItem>();
                int _category = Shared.ToInt(cmbCategoryCode.SelectedValue);
                ItemsList = (from c in context.Products
                             where c.CategoryCode.Equals(_category)
                             && c.ProductCode.Contains(term) || c.ProductDesc.Contains(term)
                             select new ComboboxItem
                             {
                                 Text =  c.ProductDesc,
                                 Value = c.ProductCode
                             }).ToList();

                return ItemsList;
            }
        }

        private void frmProducts_KeyDown(object sender, KeyEventArgs e)
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
                SellingPrice.Text = UnitPrice.Text = cmbautocomplete.Text = "";
                cmbCategoryCode.Enabled = true;
                cmbautocomplete.Enabled = true;
                txtSearch.Enabled = true;
                txtSearch.Text = "";
                
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
                        if (valueItem.ToString() == Shared.ToString(row.Cells[0].Value))
                        {
                            this.cmbCategoryCode.SelectedIndex = i;
                            break;
                        }
                    }

                }

                txtSearch.Text = Shared.ToString(row.Cells[2].Value);
                string name = string.Format("{0}", txtSearch.Text);
                cmbautocomplete.DataSource = null;
                cmbautocomplete.DataSource = Autocomplete(name);
                cmbautocomplete.DisplayMember = "Text";

                IList<ComboboxItem> Productdt = (IList<ComboboxItem>)cmbautocomplete.DataSource;

                for (int i = 0; i < Productdt.Count; ++i)
                {
                    string displayText = Productdt[i].Text.ToString();
                    string valueItem = Productdt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == Shared.ToString(row.Cells[1].Value))
                        {
                            this.cmbautocomplete.SelectedIndex = i;
                            break;
                        }
                    }

                }

                
                UnitPrice.Text = Shared.ToString(row.Cells[5].Value);
                SellingPrice.Text = Shared.ToString(row.Cells[6].Value);

                cmbCategoryCode.Enabled = false;
                cmbautocomplete.Enabled = false;
                txtSearch.Enabled = false;
                UnitPrice.Focus();
               
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
       

        private void cmbCategoryCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbCategoryCode.Text.Length >= 0)
                cmbCategoryCode.DroppedDown = true;
        }

       

        private void cmbCategoryCodeSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbCategoryCodeSearch.Text.Length >= 0)
                cmbCategoryCodeSearch.DroppedDown = true;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = string.Format("{0}", txtSearch.Text); //join previous text and new pressed char
                cmbautocomplete.DataSource = null;
                cmbautocomplete.DataSource = Autocomplete(name);
                cmbautocomplete.DisplayMember = "Text";
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }
    }    
}

