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
    public partial class frmListPurchase : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<SalesPurchaseModel> list;
        private string _orderNo_Search = null;
        private DateTime? _servicedate_Search = null;
        private int? _vendor_Search = null;
        private int? _parmType_Search = null;

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

        public frmListPurchase()
        {
            InitializeComponent();
        }

        #region Method

        public class SalesPurchaseModel
        {
            public string OrderNo { get; set; }

            public int? VendorCode { get; set; }

            public string VendorName { get; set; }

            public string PurchaseDateDisplay { get; set; }

            public string TotalAmount { get; set; }

        }

        public async Task<IPagedList<SalesPurchaseModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_Sales_Purchases(1, _vendor_Search, _servicedate_Search, _servicedate_Search, _orderNo_Search, 1, "StocksPurchase")
                                select new SalesPurchaseModel
                                     {
                                         OrderNo = c.OrderNo,
                                         VendorName = c.VendorName,
                                         PurchaseDateDisplay = Shared.ToString(c.PurchaseDate.Value.ToString("MMM dd yyyy h:mm tt")),
                                         TotalAmount = Shared.ToString(c.TotalAmount)
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
                    case "OrderNo":
                        dc.Width = 100;
                        dc.HeaderText = "ORDER NO";
                        break;

                    case "PurchaseDateDisplay":
                        dc.Width = 175;
                        dc.HeaderText = "PURCHASE DATE";
                        break;

                    case "VendorName":
                        dc.Width = 200;
                        dc.HeaderText = "VENDOR";
                        break;
                   
                    case "TotalAmount":
                        dc.Width = 75;
                        dc.HeaderText = "AMOUNT";
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

            //this.dt = objCommon.SystemBrandGet(null, "");
            list = await GetPagedListAsync();
            btnPrevious.Enabled = list.HasPreviousPage;
            btnNext.Enabled = list.HasNextPage;

            if (list != null)
            {
                this.dgvResult.DataSource = list.ToList();
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
        #endregion

        #region Event Handler
        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsCommon objCommon = new clsCommon();

            switch (btn.Name.ToString())
            {
                case "btnAddNew":
                    frmCreatePurchase frm = new frmCreatePurchase();
                    frm._editMode = false;
                    frm._orderNo = "0";
                    ShowForm(frm);
                    break;

                case "btnClose":
                    this.ParentForm.Controls["pnlSub"].Show();
                    this.Close();
                    break;

                case "btnSearch":
                    
                    _orderNo_Search = Shared.ToString(txtOrderNo.Text);
                    _servicedate_Search = dtPurchaseDate.Checked == true ? dtPurchaseDate.Value.Date : (DateTime?)null;
                    _parmType_Search = 2;
                    _vendor_Search = cmbVendor.SelectedItem != null ? Shared.ToInt(((ComboboxItem)(cmbVendor.SelectedItem)).Value) : (int?)null;

                    ListBillData();
                    SetupDataGrid();
                    break;
               
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count > 0)
            {
                frmCreatePurchase frm = new frmCreatePurchase();
                frm._orderNo = dgv.SelectedRows[0].Cells["OrderNo"].Value.ToString();
                frm._editMode = true;
                ShowForm(frm);
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
            txtOrderNo.Focus();
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {
                //cmbStatus.Items.Clear();

                IList<ComboboxItem> ItemsList = new List<ComboboxItem>();

                ItemsList = (from c in context.sp_frm_get_parm_Vendors(1, "",1)
                             select new ComboboxItem
                             {
                                 Text = c.VendorName,
                                 Value = Shared.ToString(c.VendorCode)
                             }).ToList();
                BindingSource source = new BindingSource();
                source.DataSource = ItemsList;
                cmbVendor.DataSource = source;
                cmbVendor.ValueMember = "Value";
                cmbVendor.DisplayMember = "Text";
            }
        }

        #endregion

        private void frmBrands_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnAddNew;
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.Escape)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = (Button)btnClose;
                btn_Click(btn, null);
            }

        }

        private void dgvResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataGridView dgv = (DataGridView)sender;

                if (dgv.SelectedRows.Count > 0)
                {
                    frmCreatePurchase frm = new frmCreatePurchase();
                    frm._orderNo = dgv.SelectedRows[0].Cells["OrderNo"].Value.ToString();
                    frm._editMode = true;
                    ShowForm(frm);
                }
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

        private void dgvResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count > 0)
            {
                frmCreatePurchase frm = new frmCreatePurchase();
                frm._orderNo = dgv.SelectedRows[0].Cells["OrderNo"].Value.ToString();
                frm._editMode = true;
                ShowForm(frm);
            }
        }

    }    
}

