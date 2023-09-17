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
    public partial class BillRptReceipt : Form
    {
        private string receiptNo = "00000";
        private bool editMode = false;

        public BillRptReceipt()
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
       

        private void RptReceipt_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "MobilePro.BillReceipt.rdlc";
                DataSet serviceds = ReturnQueryService(receiptNo);

                ReportDataSource rptDS = new ReportDataSource("DataSet1", new DataTable());
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", new DataTable());
                ReportDataSource rptDS2 = new ReportDataSource("DataSet3", serviceds.Tables[0]);

                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rptDS);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS1);
                this.reportViewer1.LocalReport.DataSources.Add(rptDS2);

              
                try
                {                   
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

        private DataSet ReturnQueryService(string ReceiptNo)
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
                sqlParams[2].Value = "Bills";
                sqlParams[3] = new SqlParameter("@ParmType", SqlDbType.Int);
                sqlParams[3].Value = 2;

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Bills", sqlParams);
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
                frmServiceBills frm1 = new frmServiceBills();
                ShowForm(frm1);
            }
            else
            {
                frmServiceBillAdd frm1 = new frmServiceBillAdd();
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
