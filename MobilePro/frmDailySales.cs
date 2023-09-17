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
    public partial class frmDailySales : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        IPagedList<DailySalesListModel> list;
        private DateTime? _date_Search = null;

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

        public frmDailySales()
        {
            InitializeComponent();
        }

        #region Method

        public class DailySalesListModel
        {
            public string SalesByCASH { get; set; }

            public string SalesByNETS { get; set; }

            public string TotalAmount { get; set; }

            public string Expense { get; set; }

            public string NetAmount { get; set; }

        }

        public async Task<IPagedList<DailySalesListModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();

                        return (from c in context.sp_frm_get_Daily_Sales_Report(dtServiceDate.Value.Date, dtServiceDate.Value.Date, Shared.ToInt(userId), "Sales")
                                select new DailySalesListModel
                                     {
                                         SalesByCASH = String.Format("{0:C}", Shared.ToDecimal(c.SaleByCash)),
                                         SalesByNETS = String.Format("{0:C}", Shared.ToDecimal(c.SaleByNETS)),
                                         TotalAmount = String.Format("{0:C}", Shared.ToDecimal(c.SaleByCash + c.SaleByNETS)),
                                         Expense = String.Format("{0:C}", Shared.ToDecimal(c.Expense)),
                                         NetAmount = String.Format("{0:C}", Shared.ToDecimal(c.NetAmount))
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
                    case "SalesByCASH":
                        dc.Width = 125;
                        dc.HeaderText = "CASH";                       
                        break;

                    case "SalesByNETS":
                        dc.Width = 125;
                        dc.HeaderText = "NETS";
                        break;

                    case "TotalAmount":
                        dc.Width = 150;
                        dc.HeaderText = "TOTAL";
                        break;

                    case "Expense":
                        dc.Width = 125;
                        dc.HeaderText = "EXPENSE";
                        break;

                    case "NetAmount":
                        dc.Width = 150;
                        dc.HeaderText = "NETAMOUNT";
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

                    _date_Search = dtServiceDate.Value.Date;

                    ListBillData();
                    SetupDataGrid();
                    break;

                case "btnreprint":

                    DailySalesForm frm1 = new DailySalesForm();
                    frm1._servicedate = dtServiceDate.Value.Date;
                    frm1.Dispose();
                    frm1.Run();

                    //RptDailySales frm1 = new RptDailySales();
                    //frm1._servicedate = dtServiceDate.Value.Date;
                    //ShowForm(frm1);

                    break;
            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            
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

            if (e.KeyCode == Keys.F10)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = ((Button)(btnreprint));
                btn_Click(btn, null);
            }

        }

        private void dgvResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void Search_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button btn = (Button)btnSearch;
                btn_Click(btn, null);
            }
        }      

        private void dgvResult_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            
        }

    }    
}

