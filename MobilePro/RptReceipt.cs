using Microsoft.Reporting.WinForms;
using MobilePro.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePro
{
    public partial class RptReceipt : Form
    {
        private string receiptNo = "00000";
        private string tendered = "00";
        private string change = "00";
        private string disc = "00";
        private bool editMode = false;

        public RptReceipt()
        {
            InitializeComponent();
        }

        internal string _receiptNo
        {
            get
            {
                return this.receiptNo;
            }
            set
            {
                this.receiptNo = value;
            }
        }

        internal string _disc
        {
            get
            {
                return this.disc;
            }
            set
            {
                this.disc = value;
            }
        }

        internal bool _editMode
        {
            get
            {
                return this.editMode;
            }
            set
            {
                this.editMode = value;
            }
        }

        internal string _tendered
        {
            get
            {
                return this.tendered;
            }
            set
            {
                this.tendered = value;
            }
        }

        internal string _change
        {
            get
            {
                return this.change;
            }
            set
            {
                this.change = value;
            }
        }

        private void RptReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MobilePro.Receipt.rdlc";
                DataSet salesds = ReturnQuerySale(receiptNo);
                DataSet salesbillds = ReturnQuerySaleBill(receiptNo);

                ReportDataSource rptDS = new ReportDataSource("DataSet1", salesds.Tables[0]);
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", salesbillds.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rptDS);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS1);

                ReportParameter[] parameters;

                parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("Tendered", String.Format("{0:C}", Shared.ToDecimal(tendered)));
                parameters[1] = new ReportParameter("Change", String.Format("{0:C}", Shared.ToDecimal(change)));
                parameters[2] = new ReportParameter("Disc", String.Format("{0:C}", Shared.ToDecimal(disc)));

                try
                {
                    this.reportViewer1.LocalReport.SetParameters(parameters);
                    this.reportViewer1.RefreshReport();
                }
                catch (LocalProcessingException ex)
                {
                    clsCommon objCommon = new clsCommon();
                    objCommon.MessageBoxFunction(ex.Message.ToString(), true);
                }
                

            }
            catch (LocalProcessingException ex)
            {
                clsCommon objCommon = new clsCommon();
                objCommon.MessageBoxFunction(ex.Message.ToString(), true);
            }

        }

        private DataSet ReturnQuerySale(string ReceiptNo)
        {
            DataSet dsQuery = new DataSet();

            try
            {
                SqlParameter[] sqlParams = new SqlParameter[4];

                sqlParams[0] = new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 50);
                sqlParams[0].Value = Shared.ToString(ReceiptNo);
                sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
                sqlParams[1].Value = 1;
                sqlParams[2] = new SqlParameter("@PageName", SqlDbType.VarChar, 50);
                sqlParams[2].Value = "Sales";
                sqlParams[3] = new SqlParameter("@ParmType", SqlDbType.Int);
                sqlParams[3].Value = 2;

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Sales", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }

        private DataSet ReturnQuerySaleBill(string ReceiptNo)
        {
            DataSet dsQuery = new DataSet();

            try
            {
                SqlParameter[] sqlParams = new SqlParameter[3];

                sqlParams[0] = new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 50);
                sqlParams[0].Value = Shared.ToString(ReceiptNo);
                sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
                sqlParams[1].Value = 1;
                sqlParams[2] = new SqlParameter("@PageName", SqlDbType.VarChar, 50);
                sqlParams[2].Value = "Sales";


                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Sales_Bill_Items", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }

        private void RptReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this._editMode == true)
            {
                frmBills frm1 = new frmBills();
                ShowForm(frm1);
            }
            else
            {
                frmBillAdd frm1 = new frmBillAdd();
                ShowForm(frm1);
            }
        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

       
    }
}
