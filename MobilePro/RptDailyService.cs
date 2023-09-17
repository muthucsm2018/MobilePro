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
    public partial class RptDailyService : Form
    {
        private DateTime? servicedate =(DateTime?)null;
        private string shopname = null;
        private string userid = null;

        public RptDailyService()
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

        internal string _shopname
        {
            get
            {
                return this.shopname;
            }
            set
            {
                this.shopname = value;
            }
        }

        internal string _userid
        {
            get
            {
                return this.userid;
            }
            set
            {
                this.userid = value;
            }
        } 

        private void RptReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MobilePro.DailyService.rdlc";
                DataSet serviceds = ReturnQueryService(servicedate, userid);

                ReportDataSource rptDS = new ReportDataSource("DataSet1", new DataTable());
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", new DataTable());
                ReportDataSource rptDS2 = new ReportDataSource("DataSet3", new DataTable());
                ReportDataSource rptDS3 = new ReportDataSource("DataSet4", serviceds.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rptDS);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS1);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS2);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS3);

                ReportParameter[] parameters;

                parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("ServiceDate", String.Format("{0:dd-MMM-yyyy}", servicedate));
                parameters[1] = new ReportParameter("ShopName", shopname);

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

        private DataSet ReturnQueryService(DateTime? ServiceDate, string UserId)
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
                sqlParams[2].Value = Shared.ToInt(UserId);
                sqlParams[3] = new SqlParameter("@PageName", SqlDbType.VarChar, 50);
                sqlParams[3].Value = "Bills";

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Daily_Service_Report", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }



        private void RptReceipt_FormClosed(object sender, FormClosedEventArgs e)
        {
            //frmDailyService frm1 = new frmDailyService();
            //ShowForm(frm1);
        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Dock = DockStyle.Fill;
            frm.Show();
        }

    }
}
