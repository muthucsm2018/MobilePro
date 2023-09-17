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
    public partial class frmExpenses : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<ExpenseListModel> list;
        private int? _source_Search = null;

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

        public frmExpenses()
        {
            InitializeComponent();
        }

        #region Method

        public class ExpenseListModel
        {
            public string VendorCode { get; set; }

            public string VendorName { get; set; }

            public string ExpenseCode { get; set; }

            public string ExpenseName { get; set; }

            public string Charge { get; set; }

            public string Remarks { get; set; }

            public string TrxnDate { get; set; }

            public string CreatedBy { get; set; }

            public string CreatedDate { get; set; }

            public string UpdatedBy { get; set; }

            public string UpdatedDate { get; set; }

        }
       

        public async Task<IPagedList<ExpenseListModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        return (from c in context.sp_frm_get_Expense(null, null, _source_Search, 1, "Expense", 1, null, null)
                                select new ExpenseListModel
                                     {
                                         ExpenseCode = Shared.ToString(c.ExpenseCode),
                                         VendorName = c.VendorName,
                                         Charge = Shared.ToString(c.Charge),
                                         Remarks = c.Remarks,
                                         TrxnDate = c.CreatedDate
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
                    case "ExpenseCode":
                        dc.Width = 100;
                        dc.HeaderText = "ExpenseCode";
                        dc.Visible = false;
                        break;

                    case "VendorName":
                        dc.Width = 175;
                        dc.HeaderText = "NAME";
                        break;

                    case "Charge":
                        dc.Width = 100;
                        dc.HeaderText = "CHARGE";
                        break;

                    case "Remarks":
                        dc.Width = 200;
                        dc.HeaderText = "REMARKS";
                        break;

                    case "TrxnDate":
                        dc.Width = 150;
                        dc.HeaderText = "DATE";
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
                this.dgvResult.DataSource = list.ToList();
            }
            lblPageNumber.Text = string.Format("Page {0}/{1}", pageNumber, list.PageCount);
            SetupDataGrid();

            DataGridView dgv = dgvResult;
            double? amount = 0; //maybe you can use double if that is what you need
           
            int rows = dgvResult.Rows.Count;
            for (int i = 0; i < rows; i++)
            {
                amount += Shared.ToDouble(dgvResult.Rows[i].Cells["Charge"].Value);
            }

            lbltotalexpense.Text = "$ " + Shared.ToString(amount);

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
                    frmExpenseAdd frm = new frmExpenseAdd();
                    frm._editMode = false;
                    frm._receiptNo = "0";
                    ShowForm(frm);
                    break;

                case "btnClose":
                    this.ParentForm.Controls["pnlSub"].Show();
                    this.Close();
                    break;

                case "btnSearch":
                   
                    _source_Search = cmbSource.SelectedItem != null ? Shared.ToInt(((ComboboxItem)(cmbSource.SelectedItem)).Value) : (int?)null;

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
                frmExpenseAdd frm = new frmExpenseAdd();
                frm._receiptNo = dgv.SelectedRows[0].Cells["ExpenseCode"].Value.ToString();
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
        }

        private void LoadSearchDatas()
        {
            using (Entities context = new Entities())
            {
                //cmbSource.Items.Clear();

                var source = (from c in context.sp_frm_get_parm_ExpenseVendors(null,null,1)
                             select new ComboboxItem
                             {
                                 Text = c.VendorName,
                                 Value = Shared.ToString(c.VendorCode)
                             }).ToList();

                cmbSource.DataSource = source;
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
                    frmExpenseAdd frm = new frmExpenseAdd();
                    frm._receiptNo = dgv.SelectedRows[0].Cells["VendorCode"].Value.ToString();
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
                frmExpenseAdd frm = new frmExpenseAdd();
                frm._receiptNo = dgv.SelectedRows[0].Cells["VendorCode"].Value.ToString();
                frm._editMode = true;
                ShowForm(frm);
            }
        }

    }    
}

