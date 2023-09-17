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
using System.Net.Mail;
using System.Net;
using System.Configuration;


namespace MobilePro
{
    public partial class frmDailyService : MobilePro.frmTemplate
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

        public frmDailyService()
        {
            InitializeComponent();
        }

        #region Method

        public class DailySalesListModel
        {
            public string ByCASH { get; set; }

            public string ByNETS { get; set; }

            public string TotalAmount { get; set; }

        }

        public async Task<IPagedList<DailySalesListModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();

                        return (from c in context.sp_frm_get_Daily_Service_Report(dtServiceDate.Value.Date, dtServiceDate.Value.Date, Shared.ToInt(userId), "Sales")
                                select new DailySalesListModel
                                     {
                                         ByCASH = String.Format("{0:C}", Shared.ToDecimal(c.ByCash)),
                                         ByNETS = String.Format("{0:C}", Shared.ToDecimal(c.ByNETS)),
                                         TotalAmount = String.Format("{0:C}", Shared.ToDecimal(c.ByCash + c.ByNETS))                                        
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
                    case "ByCASH":
                        dc.Width = 125;
                        dc.HeaderText = "CASH";                       
                        break;

                    case "ByNETS":
                        dc.Width = 125;
                        dc.HeaderText = "NETS";
                        break;

                    case "TotalAmount":
                        dc.Width = 150;
                        dc.HeaderText = "TOTAL";
                        break;                  

                    default:
                        dc.Visible = false;
                        break;
                }
            }
        }

        private async void ListBillData()
        {           
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

            StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
            string userName = strip.Items["statusBarUserName"].ToString();
            string userId = strip.Items["StatusBarUserId"].ToString();

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

                    DailyServiceForm frm1 = new DailyServiceForm();
                    frm1._servicedate = dtServiceDate.Value.Date;
                    frm1._shopname = userName;
                    frm1._userid = userId;
                    frm1.Dispose();
                    frm1.Run();

                    //RptDailyService frm1 = new RptDailyService();
                    //frm1._servicedate = dtServiceDate.Value.Date;
                    //frm1._shopname = userName;
                    //frm1._userid = userId;
                    //ShowForm(frm1);

                    break;

                case "btnendwork":
                    try
                    {
                        CreateTimeoutTestMessage(userId, userName);
                        objCommon.MessageBoxFunction("End Work Completed!", false);
                    }
                    catch (Exception ex)
                    {
                       objCommon.MessageBoxFunction(ex.Message, true);
                    }

                    break;
            }
        }

        public void CreateTimeoutTestMessage(string userId, string username)
        {
            //    var smtpServerName = ConfigurationManager.AppSettings["SmtpServer"];
            //    var port = ConfigurationManager.AppSettings["Port"];
            var senderEmailId = ConfigurationManager.AppSettings["SenderEmailId"];
            var senderPassword = ConfigurationManager.AppSettings["SenderPassword"];

            var toEmailId = ConfigurationManager.AppSettings["ToEmailId"];



            StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
            string userName = strip.Items["statusBarUserName"].ToString();

            using (Entities context = new Entities())
            {
                var _body = (from c in context.sp_frm_get_Daily_Service_Report(dtServiceDate.Value.Date, dtServiceDate.Value.Date, Shared.ToInt(userId), "Bills")
                             select new DailySalesListModel
                                  {
                                      ByCASH = String.Format("{0:C}", Shared.ToDecimal(c.ByCash)),
                                      ByNETS = String.Format("{0:C}", Shared.ToDecimal(c.ByNETS)),
                                      TotalAmount = String.Format("{0:C}", Shared.ToDecimal(c.ByCash + c.ByNETS))
                                  }).SingleOrDefault();


                var fromAddress = new MailAddress(senderEmailId, username);
                var toAddress = new MailAddress(toEmailId, "123 Mobile");
                string _subject = userName + " Service Report " + dtServiceDate.Value.ToShortDateString();
                string fromPassword = senderPassword;
                string subject = _subject;


                string messageBody = "<font>The following are the records: </font><br><br>";

                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style =\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style =\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";

                messageBody += htmlTableStart;
                messageBody += htmlHeaderRowStart;
                messageBody += htmlTdStart + "By CASH " + htmlTdEnd;
                messageBody += htmlTdStart + "By NETS " + htmlTdEnd;
                messageBody += htmlTdStart + "Total " + htmlTdEnd;
                messageBody += htmlHeaderRowEnd;


                messageBody = messageBody + htmlTrStart;
                messageBody = messageBody + htmlTdStart + _body.ByCASH + htmlTdEnd;
                messageBody = messageBody + htmlTdStart + _body.ByNETS + htmlTdEnd;
                messageBody = messageBody + htmlTdStart + _body.TotalAmount + htmlTdEnd;
                messageBody = messageBody + htmlTrEnd;

                messageBody = messageBody + htmlTableEnd;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = true,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = messageBody,
                    IsBodyHtml = true
                })
                {                    
                    smtp.Send(message);                 
                }
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

            if (e.KeyCode == Keys.F11)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = ((Button)(btnendwork));
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

