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
    public partial class RptDailySales : Form
    {
        private DateTime? servicedate =(DateTime?)null;

        public RptDailySales()
        {
            InitializeComponent();
        }

        internal DateTime? _servicedate
        {
            get
            {
                return this.servicedate;
            }
            set
            {
                this.servicedate = value;
            }
        }       

        private void RptReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MobilePro.DailySales.rdlc";
                DataSet salesds = ReturnQuerySale(servicedate);

                ReportDataSource rptDS = new ReportDataSource("DataSet1", new DataTable());
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", new DataTable());
                ReportDataSource rptDS2 = new ReportDataSource("DataSet3", salesds.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rptDS);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS1);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS2);

                ReportParameter[] parameters;

                parameters = new ReportParameter[1];
                parameters[0] = new ReportParameter("ServiceDate", String.Format("{0:dd-MMM-yyyy}", servicedate));

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

        private DataSet ReturnQuerySale(DateTime? ServiceDate)
        {
            DataSet dsQuery = new DataSet();

            try
            {
                SqlParameter[] sqlParams = new SqlParameter[4];
                sqlParams[0] = new SqlParameter("@TransactionFrom", SqlDbType.DateTime);
                if (ServiceDate != null)
                    sqlParams[0].Value = ServiceDate;
                else
                    sqlParams[0].Value = DBNull.Value;
                sqlParams[1] = new SqlParameter("@TransactionTo", SqlDbType.DateTime);
                if (ServiceDate != null)
                    sqlParams[1].Value = ServiceDate;
                else
                    sqlParams[1].Value = DBNull.Value;
                sqlParams[2] = new SqlParameter("@UserId", SqlDbType.Int);
                sqlParams[2].Value = 1;
                sqlParams[3] = new SqlParameter("@PageName", SqlDbType.VarChar, 50);
                sqlParams[3].Value = "Sales";

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Daily_Sales_Report", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }



        private void RptReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDailySales frm1 = new frmDailySales();
            ShowForm(frm1);
        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

    }
}
