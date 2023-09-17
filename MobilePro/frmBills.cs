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
    public partial class frmBills : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<SalesListModel> list;
        private string _receiptNo_Search = null;
        private string _customername_Search = null;
        private DateTime? _servicedate_Search = null;
        private string _payment_Search = "";
        private int? _parmType_Search = 1;

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

        public frmBills()
        {
            InitializeComponent();
        }

        #region Method

        public class SalesListModel
        {
            public string ReceiptNo { get; set; }

            public string CustomerName { get; set; }

            public string ServiceDate { get; set; }

            public string ServiceDateDisplay { get; set; }

            public string BillItems { get; set; }

            public string PaymentType { get; set; }

            public string TotalAmount { get; set; }

            public string DiscountAmount { get; set; }

            public string NetAmount { get; set; }

        }

        public async Task<IPagedList<SalesListModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();

                        return (from c in context.sp_frm_get_Sales(1, _receiptNo_Search, _servicedate_Search, _customername_Search, Shared.ToInt(userId), "ListSales", _parmType_Search, _payment_Search)
                                select new SalesListModel
                                     {
                                         ReceiptNo = c.ReceiptNo,
                                         CustomerName = c.CustomerName,
                                         ServiceDateDisplay = Shared.ToString(c.ServiceDate.Value.ToString("MMM dd yyyy h:mm tt")),
                                         PaymentType = c.PaymentType,
                                         BillItems = c.Items,
                                         NetAmount = Shared.ToString(c.NetAmount),
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
                    case "ReceiptNo":
                        dc.Width = 100;
                        dc.HeaderText = "BILL NO";
                        break;

                    case "ServiceDateDisplay":
                        dc.Width = 175;
                        dc.HeaderText = "SERVICE DATE";
                        break;

                    case "CustomerName":
                        dc.Width = 150;
                        dc.HeaderText = "CUSTOMER";
                        break;

                    case "BillItems":
                        dc.Width = 400;
                        dc.HeaderText = "ITEMS";
                        break;

                    case "NetAmount":
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

            DataGridView dgv = dgvResult;
            double? amount = 0; //maybe you can use double if that is what you need
           
            int rows = dgvResult.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                amount += Shared.ToDouble(dgvResult.Rows[i].Cells[8].Value);
            }

            lbltotalsales.Text = "$ " + Shared.ToString(amount);

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
                    frmBillAdd frm = new frmBillAdd();
                    frm._editMode = false;
                    frm._receiptNo = "0";
                    ShowForm(frm);
                    break;

                case "btnClose":
                    this.ParentForm.Controls["pnlSub"].Show();
                    this.Close();
                    break;

                case "btnSearch":
                    if (Shared.ToString(txtBillNo.Text).Length > 0)
                    {
                        _receiptNo_Search = "S" + "-" + ((Int32.Parse(txtBillNo.Text)).ToString("D4").Trim());
                    }

                    //_receiptNo_Search = Shared.ToString(txtBillNo.Text);
                    _customername_Search = Shared.ToString(txtCustomerName.Text);
                    //_servicedate_Search = dtServiceDate.Value.Date == DateTime.Now.Date ? (DateTime?)null : dtServiceDate.Value.Date;
                    _servicedate_Search = dtServiceDate.Checked == true ? dtServiceDate.Value.Date : (DateTime?)null;
                    _parmType_Search = 2;
                    _payment_Search = cmbPayment.SelectedItem != null ? Shared.ToString(((ComboboxItem)(cmbPayment.SelectedItem)).Value) : "";

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
                frmBillAdd frm = new frmBillAdd();
                frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
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
            txtBillNo.Focus();
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {
                cmbPayment.Items.Clear();
                cmbPayment.Items.Add(new ComboboxItem { Text = "ALL", Value = "" });
                cmbPayment.Items.Add(new ComboboxItem { Text = "CASH", Value = "CASH" });
                cmbPayment.Items.Add(new ComboboxItem { Text = "NETS", Value = "NETS" });
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
                    frmBillAdd frm = new frmBillAdd();
                    frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
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
                frmBillAdd frm = new frmBillAdd();
                frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
                frm._editMode = true;
                ShowForm(frm);
            }
        }

    }    
}

