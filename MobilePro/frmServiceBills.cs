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
using System.Threading;
using System.IO.Ports;

namespace MobilePro
{
    public partial class frmServiceBills : MobilePro.frmTemplate
    {
        #region Private Variable
        DataTable dt = new DataTable();
        int pageNumber = 1;
        IPagedList<BillsListModel> list;
        private string _receiptNo_Search = null;
        private string _customername_Search = null;
        private DateTime? _servicedate_Search = null;
        private int? _status_Search = (int?)null;
        private int? _parmType_Search = 1; 
        //SMS
        SerialPort port = new SerialPort();
        clsSMS objclsSMS = new clsSMS();

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

        public frmServiceBills()
        {
            InitializeComponent();
        }

        #region Method

        public class BillsListModel
        {
            public string ServiceDateDisplay { get; set; }

            public string ReceiptNo { get; set; }

            public string CustomerName { get; set; }

            public string BrandName { get; set; }

            public string ModelNo { get; set; }

            public string NatureFault { get; set; }

            public string StatusName { get; set; }

            public string StatusCode { get; set; }

            public string NetAmount { get; set; }

        }

        public async Task<IPagedList<BillsListModel>> GetPagedListAsync(int pageNumber = 1, int pageSize = 50)
        {
            return await Task.Factory.StartNew(() =>
                {
                    using (Entities context = new Entities())
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();

                        return (from c in context.sp_frm_get_Bills(1, _receiptNo_Search, null, null, _servicedate_Search, _status_Search, null, _customername_Search, Shared.ToInt(userId), "ListBills", _parmType_Search)
                                select new BillsListModel
                                {
                                    ReceiptNo = c.ReceiptNo,
                                    CustomerName = c.CustomerName,
                                    ServiceDateDisplay = Shared.ToString(c.ServiceDate.Value.ToString("MMM dd yyyy h:mm tt")),
                                    BrandName = c.BrandName,
                                    ModelNo = c.ModelNo,
                                    NatureFault = c.NatureFault,
                                    NetAmount = Shared.ToString(c.EstimateAmount),
                                    StatusName = c.StatusName

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
                        dc.Width = 80;
                        dc.HeaderText = "BILL NO";
                        break;

                    case "ServiceDateDisplay":
                        dc.Width = 150;
                        dc.HeaderText = "SERVICE DATE";
                        break;

                    case "CustomerName":
                        dc.Width = 125;
                        dc.HeaderText = "CUSTOMER";
                        break;

                    case "BrandName":
                        dc.Width = 75;
                        dc.HeaderText = "BRAND";
                        dc.Visible = false;
                        break;

                    case "ModelNo":
                        dc.Width = 75;
                        dc.HeaderText = "MODEL";
                        break;

                    case "NatureFault":
                        dc.Width = 250;
                        dc.HeaderText = "FAULT";
                        break;

                    case "NetAmount":
                        dc.Width = 75;
                        dc.HeaderText = "AMOUNT";
                        break;

                    case "StatusName":
                        dc.Width = 100;
                        dc.HeaderText = "STATUS";
                        break;

                    default:
                        dc.Visible = false;
                        break;

                }
            }
        }

        private async void ListBillData()
        {
            using (Entities context = new Entities())
            {
                clsCommon objCommon = new clsCommon();

                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

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

                var auth1 = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 4)); // Service Update User & Admin
                if (auth1 > 0)
                {
                    DataGridViewButtonColumn view = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(9, view);
                    view.HeaderText = "More";
                    view.Text = "More";
                    view.Name = "view";
                    view.UseColumnTextForButtonValue = true;
                    view.Width = 50;
                    view.Visible = false;


                    DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(10, del);
                    del.HeaderText = "Update";
                    del.Text = "Update";
                    del.Name = "upd";
                    del.UseColumnTextForButtonValue = true;
                    del.Width = 50;

                    DataGridViewButtonColumn rem = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(11, rem);
                    rem.HeaderText = "Remark";
                    rem.Text = "Remark";
                    rem.Name = "rem";
                    rem.UseColumnTextForButtonValue = true;
                    rem.Width = 75;
                    rem.Visible = false;

                    DataGridViewButtonColumn outs = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(12, outs);
                    outs.HeaderText = "Out Source";
                    outs.Text = "Out Source";
                    outs.Name = "outs";
                    outs.UseColumnTextForButtonValue = true;
                    outs.Width = 100;
                    outs.Visible = false;

                    string _staus = Shared.ToString(strip.Items["statusBarRole"].Text);

                    label4.Text = _staus.Length > 0 ? _staus :  "SMS Modem is not Connected!";

                }

                var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 3)); // Service Entry User & Admin
                if (auth > 0)
                {

                    DataGridViewButtonColumn rem = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(9, rem);
                    rem.HeaderText = "Remark";
                    rem.Text = "Remark";
                    rem.Name = "remuser";
                    rem.UseColumnTextForButtonValue = true;
                    rem.Width = 75;
                    rem.Visible = false;

                    DataGridViewButtonColumn bar = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(10, bar);
                    bar.HeaderText = "Label";
                    bar.Text = "Label";
                    bar.Name = "bar";
                    bar.UseColumnTextForButtonValue = true;
                    bar.Width = 50;
                    bar.Visible = false;

                    DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(11, del);
                    del.HeaderText = "Delivery";
                    del.Text = "Delivery";
                    del.Name = "del";
                    del.UseColumnTextForButtonValue = true;
                    del.Width = 75;

                    DataGridViewButtonColumn print = new DataGridViewButtonColumn();
                    dgvResult.Columns.Insert(12, print);
                    print.HeaderText = "RePrint";
                    print.Text = "RePrint";
                    print.Name = "rep";
                    print.UseColumnTextForButtonValue = true;
                    print.Width = 75;

                    dgvResult.Columns[5].Visible = false;
                }

            }
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
                    frmServiceBillAdd frm = new frmServiceBillAdd();
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
                        _receiptNo_Search = "R" + "-" + ((Int32.Parse(txtBillNo.Text)).ToString("D4").Trim());
                    }
                    else { _receiptNo_Search = null; }

                    _customername_Search = Shared.ToString(txtCustomerName.Text);
                    _servicedate_Search = dtServiceDate.Checked == true ? dtServiceDate.Value.Date : (DateTime?)null;
                    _parmType_Search = 2;
                    _status_Search = cmbStatus.SelectedItem != null ? Shared.ToInt(((ComboboxItem)(cmbStatus.SelectedItem)).Value) : (int?)null;

                    ListBillData();
                    //SetupDataGrid();
                    break;


            }
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            using (Entities context = new Entities())
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && p.RoleID == 1);
                if (auth > 0)
                {
                    DataGridView dgv = (DataGridView)sender;

                    if (dgv.SelectedRows.Count > 0)
                    {
                        frmServiceBillAdd frm = new frmServiceBillAdd();
                        frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
                        frm._editMode = true;
                        ShowForm(frm);
                    }
                }
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
                //cmbStatus.Items.Clear();

                IList<ComboboxItem> ItemsList = new List<ComboboxItem>();

                ItemsList = (from c in context.sp_frm_get_Parm_Status(1, "")
                             select new ComboboxItem
                             {
                                 Text = c.StatusName,
                                 Value = Shared.ToString(c.StatusCode)
                             }).ToList();
                ItemsList.Insert(0,new ComboboxItem { Text = "", Value = "" });
                BindingSource source = new BindingSource();
                source.DataSource = ItemsList;
                cmbStatus.DataSource = source;
                cmbStatus.ValueMember = "Value";
                cmbStatus.DisplayMember = "Text";
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
                using (Entities context = new Entities())
                {
                    StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                    string userId = strip.Items["StatusBarUserId"].ToString();

                    var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1));
                    if (auth > 0)
                    {
                        DataGridView dgv = (DataGridView)sender;

                        if (dgv.SelectedRows.Count > 0)
                        {
                            frmServiceBillAdd frm = new frmServiceBillAdd();
                            frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
                            frm._editMode = true;
                            ShowForm(frm);
                        }
                    }
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
            //using (Entities context = new Entities())
            //{
            //    StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
            //    string userId = strip.Items["StatusBarUserId"].ToString();

            //    var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && p.RoleID == 1);
            //    if (auth > 0)
            //    {
            //        DataGridView dgv = (DataGridView)sender;

            //        if (dgv.SelectedRows.Count > 0)
            //        {
            //            frmServiceBillAdd frm = new frmServiceBillAdd();
            //            frm._receiptNo = dgv.SelectedRows[0].Cells["ReceiptNo"].Value.ToString();
            //            frm._editMode = true;
            //            ShowForm(frm);
            //        }
            //    }
            //}
        }

        public class CreateBillModel
        {
            public string ReceiptNo { get; set; }

            public string PasswordType { get; set; }

            public string Password { get; set; }

            public string Remark { get; set; }

            public string Condition { get; set; }  

        }

        private bool ReturnStatus(string status)
        {
            bool _bool = false;
            if (Shared.ToString(status).Trim() == "New")
                _bool = true;
            if (Shared.ToString(status).Trim() == "Rework")
                _bool = true;
            if (Shared.ToString(status).Trim() == "Ready")
                _bool = true;
            if (Shared.ToString(status).Trim() == "Doing")
                _bool = true;
            return _bool;
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            clsCommon objCommon = new clsCommon();
            using (Entities context = new Entities())
            {
                try
                {
                    StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                    string userId = strip.Items["StatusBarUserId"].ToString();

                    var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 4)); // service update & admin
                    if (auth > 0)
                    {
                        if (e.ColumnIndex == dgvResult.Columns["upd"].Index)
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                if (ReturnStatus(row2.Cells[6].Value.ToString()))
                                {
                                    ContextMenuStrip mnu = new ContextMenuStrip();
                                    Image imgready = new Bitmap(MobilePro.Properties.Resources.approve);
                                    Image imgcancel = new Bitmap(MobilePro.Properties.Resources.cancel);
                                    //Image imgdoing = new Bitmap(MobilePro.Properties.Resources.doing);
                                    ToolStripMenuItem mnuReady = new ToolStripMenuItem("Ready", imgready);
                                    mnuReady.Name = row2.Cells[1].Value.ToString();
                                    ToolStripMenuItem mnuReturn = new ToolStripMenuItem("Return", imgcancel);
                                    mnuReturn.Name = row2.Cells[1].Value.ToString();
                                    //ToolStripMenuItem mnuDoing = new ToolStripMenuItem("Doing", imgcancel);
                                    //mnuDoing.Name = row2.Cells[1].Value.ToString();
                                    //Assign event handlers
                                    mnuReady.Click += new EventHandler(mnuReady_Click);
                                    mnuReturn.Click += new EventHandler(mnuReturn_Click);
                                    //mnuDoing.Click += new EventHandler(mnuDoing_Click);
                                    //Add to main context menu
                                    mnu.Items.AddRange(new ToolStripItem[] { mnuReady, mnuReturn });

                                    var cellRectangle = dgvResult.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                    Point Location = new Point(cellRectangle.X, cellRectangle.Y);
                                    mnu.Show(dgvResult, Location);
                                }

                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["view"].Index)
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                //ServiceBillView frm = new ServiceBillView();
                                //frm._receiptNo = row2.Cells[1].Value.ToString();
                                //ShowForm(frm);

                                CreateBillModel model = (from c in context.sp_frm_get_Bills(1, Shared.ToString(row2.Cells[1].Value.ToString()), null, null, (DateTime?)null, null, null, null, Shared.ToInt(userId), "ListBills", 2)
                                                         select new CreateBillModel
                                                         {
                                                             ReceiptNo = c.ReceiptNo,
                                                             Password = c.Password,
                                                             Remark = c.TechRemark,
                                                             PasswordType = c.PasswordType,
                                                             //Condition = c.Condition
                                                         }).FirstOrDefault();

                                ContextMenuStrip mnu = new ContextMenuStrip();
                                ToolStripMenuItem mnupwdtype = new ToolStripMenuItem("Password Type : " + model.PasswordType);
                                ToolStripMenuItem mnupwd = new ToolStripMenuItem("Password : " + model.Password);
                                ToolStripMenuItem mnuremark = new ToolStripMenuItem("Comments : " + model.Remark);
                                ToolStripMenuItem mnucondition = new ToolStripMenuItem("Condition : " + model.Condition);
                                //Add to main context menu
                                mnu.Items.AddRange(new ToolStripItem[] { mnucondition, mnupwdtype, mnupwd, mnuremark });

                                var cellRectangle = dgvResult.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                                Point Location = new Point(cellRectangle.X, cellRectangle.Y);
                                mnu.Show(dgvResult, Location);

                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["rem"].Index)//Remarks
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                string _receiptno = Shared.ToString(row2.Cells[1].Value.ToString());
                                var _remarks = (from c in context.ServiceBill where c.ReceiptNo == _receiptno select c.TechRemark).SingleOrDefault();
                                string promptValue = RemarksPrompt.ShowDialog("Remarks :", "", _remarks);
                               
                                    var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                    //objCommon.MessageBoxFunction(promptValue.ToString(), true);
                                    context.Database.ExecuteSqlCommand("update ServiceBill set [TechRemark] = '" + Shared.ToString(promptValue) + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "'  where ReceiptNo = '" + _receiptno + "'");
                                    context.SaveChanges();

                                    ListBillData();
                                

                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["outs"].Index)//Remarks
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                string _receiptno = Shared.ToString(row2.Cells[1].Value.ToString());
                                var _remarks = (from c in context.ServiceBill where c.ReceiptNo == _receiptno select c.OutSourceCode).SingleOrDefault();
                                int? promptValue = OutSourcePrompt.ShowDialog("OutSource :", "", _remarks);

                                var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                //objCommon.MessageBoxFunction(promptValue.ToString(), true);
                                context.Database.ExecuteSqlCommand("update ServiceBill set [OutSourceCode] = '" + Shared.ToInt(promptValue) + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "'  where ReceiptNo = '" + _receiptno + "'");
                                context.SaveChanges();

                                ListBillData();


                            }
                        }

                    }

                    var auth1 = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && (p.RoleID == 1 || p.RoleID == 3));//service entry & admin
                    if (auth1 > 0)
                    {
                        if (e.ColumnIndex == dgvResult.Columns["bar"].Index)
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                 DialogResult result = MessageBox.Show("Are you Sure to Print Label?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                 if (result == DialogResult.Yes)
                                 {
                                     //LabelForm frm1 = new LabelForm();
                                     //frm1._receiptNo = row2.Cells[1].Value.ToString();
                                     //frm1.Dispose();
                                     //frm1.Run();

                                     RptLabel frm = new RptLabel();
                                     frm._receiptNo = row2.Cells[1].Value.ToString();
                                     ShowForm(frm);
                                 }
                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["del"].Index)//Delivery
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                if (Shared.ToString(row2.Cells[6].Value).Trim() == "Ready")
                                {
                                    //DialogResult result = MessageBox.Show("Are you Sure to Deliver this Service?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                                    //if (result == DialogResult.Yes)
                                    //{
                                    string promptValue = Prompt.ShowDialog("Amount Received :", "", Shared.ToString(row2.Cells[8].Value));
                                        if (Shared.ToDecimal(promptValue) == 0)
                                        {
                                            objCommon.MessageBoxFunction("Amount Can't Be Zero!", false);
                                        }
                                        else
                                        {
                                            var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                                            //objCommon.MessageBoxFunction(promptValue.ToString(), true);
                                            context.Database.ExecuteSqlCommand("update ServiceBill set [NetAmount] = '" + Shared.ToDecimal(promptValue.Split(',')[0]) + "', [PaymentType] = '" + Shared.ToString(promptValue.Split(',')[1]).Trim() + "', [StatusCode] = '" + 5 + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "'  where ReceiptNo = '" + Shared.ToString(row2.Cells[1].Value) + "'");
                                            context.SaveChanges();

                                            ListBillData();
                                        }
                                    //}
                                }
                                else
                                {
                                    objCommon.MessageBoxFunction("Only Ready Mobiles can do Delivery!", false);
                                }
                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["rep"].Index)
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                //BillReceiptForm frm1 = new BillReceiptForm();
                                //frm._receiptNo = row2.Cells[1].Value.ToString();
                                //frm1.Dispose();
                                //frm1.Run();
                                 DialogResult result = MessageBox.Show("Are you Sure to RePrint this Bill?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                 if (result == DialogResult.Yes)
                                 {
                                    //BillRptReceipt frm = new BillRptReceipt();
                                    //frm._receiptNo = row2.Cells[1].Value.ToString();
                                    //ShowForm(frm);

                                    BillReceiptForm frm1 = new BillReceiptForm();
                                    //frm1._editMode = this._editMode;
                                    frm1._receiptNo = row2.Cells[1].Value.ToString();
                                    frm1.Dispose();
                                    frm1.Run();
                                }
                            }
                        }

                        if (e.ColumnIndex == dgvResult.Columns["remuser"].Index)//Remarks
                        {
                            foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                            {
                                string _receiptno = Shared.ToString(row2.Cells[1].Value.ToString());
                                var _remarks = (from c in context.ServiceBill where c.ReceiptNo == _receiptno select c.TechRemark).SingleOrDefault();
                                string promptValue = RemarksPromptUser.ShowDialog("Remarks :", "", _remarks);

                            }
                        }

                    }
                    

                }
                catch (Exception ex)
                {
                    //objmsg.MessageBoxFunction(ex.Message, true);
                }
            }

        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption, string EstAmt)
            {
                Form prompt = new Form();
                prompt.Width = 300;
                prompt.Height = 260;
                prompt.Text = caption;
                Label txtLbl = new Label() { Left = 50, Top = 0, Text = "Estimate Cost : " + EstAmt , Width = 200};
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };

                NumericUpDown inputBox = new NumericUpDown() { Left = 50, Top = 50, Width = 200 };
                ComboBox cmb = new ComboBox() { Left = 50, Top = 80, Width = 75  };
                cmb.Items.Add(new ComboboxItem { Text = "CASH", Value = "CASH" });
                cmb.Items.Add(new ComboboxItem { Text = "NETS", Value = "NETS" });
                cmb.SelectedIndex = 0;

                inputBox.Value = Shared.ToDecimal(EstAmt);
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 120 };

                cmb.Font = txtLbl.Font = textLabel.Font = confirmation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                inputBox.KeyUp += (sender, e) =>
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        if (inputBox.Value == 0) MessageBox.Show("Amount Cannot be Zero!"); else prompt.Close();
                    }
                };
                confirmation.Click += (sender, e) => { if (inputBox.Value == 0) MessageBox.Show("Amount Cannot be Zero!"); else prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(txtLbl);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(cmb);
                prompt.StartPosition = FormStartPosition.CenterScreen;                
                prompt.ActiveControl = inputBox;
                prompt.ShowDialog();
               
                return Shared.ToString(inputBox.Value) + ", " + Shared.ToString(((ComboboxItem)(cmb.SelectedItem)).Value) ;
            }
           
        }

        public static class RemarksPrompt
        {
            public static string ShowDialog(string text, string caption, string Remarks)
            {
                Form prompt = new Form();
                prompt.Width = 350;
                prompt.Height = 250;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };

                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 250, Height = 60 };
                inputBox.Multiline = true;
                inputBox.CharacterCasing = CharacterCasing.Upper;
                inputBox.Text = Shared.ToString(Remarks);
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 120 };

                textLabel.Font = confirmation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //inputBox.KeyUp += (sender, e) =>
                //{
                //    if (e.KeyCode == Keys.Enter)
                //    {
                //        prompt.Close();
                //    }
                //};
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                
                prompt.Controls.Add(inputBox);
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.ActiveControl = inputBox;
                prompt.ShowDialog();

                return (string)inputBox.Text;
            }

        }

        private static void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }
        public static class ActualCostPrompt
        {
            public static string ShowDialog(string text, string caption, string ActualCost)
            {
                Form prompt = new Form();
                prompt.Width = 350;
                prompt.Height = 250;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };

                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 250, Height = 60 };
                inputBox.KeyPress += (sender, e) => { textBox1_KeyPress(sender, e); };

                inputBox.Text = Shared.ToString(ActualCost);
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 120 };

                textLabel.Font = confirmation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);

                prompt.Controls.Add(inputBox);
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.ActiveControl = inputBox;
                prompt.ShowDialog();

                return (string)inputBox.Text;
            }
        }

        public static class OutSourcePrompt
        {
            public static int? ShowDialog(string text, string caption, int? Code)
            {
                using (Entities context = new Entities())
                {
                    Form prompt = new Form();
                    prompt.Width = 350;
                    prompt.Height = 250;
                    prompt.Text = caption;
                    Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };

                    ComboBox cmbOutSourceCode = new ComboBox() { Left = 50, Top = 80, Width = 200 };

                    IList<ComboboxItem> OutSourcesList = new List<ComboboxItem>();

                    OutSourcesList = (from c in context.sp_frm_get_parm_OutSources(1, "Brands",1)
                                      select new ComboboxItem
                                      {
                                          Text = c.OutSourceName,
                                          Value = Shared.ToString(c.OutSourceCode)
                                      }).ToList();

                    cmbOutSourceCode.BindingContext = new BindingContext();
                    cmbOutSourceCode.DataSource = OutSourcesList;
                    cmbOutSourceCode.DisplayMember = "Text";
                    cmbOutSourceCode.ValueMember = "Value";
                    cmbOutSourceCode.SelectedIndex = 0;

                    IList<ComboboxItem> OutSourcedt = (IList<ComboboxItem>)cmbOutSourceCode.DataSource;

                    for (int i = 0; i < OutSourcedt.Count; ++i)
                    {
                        string displayText = OutSourcedt[i].Text.ToString();
                        int? valueItem = Shared.ToInt(OutSourcedt[i].Value);
                        // Process the object depending on the type
                        if (valueItem != null)
                        {
                            if (valueItem == Code)
                            {
                                cmbOutSourceCode.SelectedIndex = i;
                                break;
                            }
                        }

                    }

                   
                    Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 120 };

                    cmbOutSourceCode.Font = textLabel.Font = confirmation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    confirmation.Click += (sender, e) => { prompt.Close(); };
                    prompt.Controls.Add(confirmation);
                    prompt.Controls.Add(textLabel);
                    prompt.Controls.Add(cmbOutSourceCode);
                    prompt.StartPosition = FormStartPosition.CenterScreen;
                    prompt.ActiveControl = cmbOutSourceCode;
                    prompt.ShowDialog();

                    return Shared.ToInt(((ComboboxItem)(cmbOutSourceCode.SelectedItem)).Value);
                }
            }

        }

        public static class RemarksPromptUser
        {
            public static string ShowDialog(string text, string caption, string Remarks)
            {
                Form prompt = new Form();
                prompt.Width = 350;
                prompt.Height = 250;
                prompt.Text = caption;
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text, Width = 200 };

                TextBox inputBox = new TextBox() { Left = 50, Top = 50, Width = 250, Height = 60 };
                inputBox.Multiline = true;
                inputBox.ReadOnly = true;
                inputBox.CharacterCasing = CharacterCasing.Upper;
                inputBox.Text = Shared.ToString(Remarks);
                Button confirmation = new Button() { Text = "Ok", Left = 50, Width = 100, Top = 120 };

                textLabel.Font = confirmation.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                //inputBox.KeyUp += (sender, e) =>
                //{
                //    if (e.KeyCode == Keys.Enter)
                //    {
                //        prompt.Close();
                //    }
                //};
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);

                prompt.Controls.Add(inputBox);
                prompt.StartPosition = FormStartPosition.CenterScreen;
                prompt.ActiveControl = inputBox;
                prompt.ShowDialog();

                return (string)inputBox.Text;
            }

        } 

        private void mnuReturn_Click(object sender, EventArgs e)
        {
            clsCommon objCommon = new clsCommon();

            using (Entities context = new Entities())
            {
                ToolStripItem itm = (ToolStripItem)(sender);

                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                DialogResult result = MessageBox.Show("Are you Sure , this Service is Return?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    context.Database.ExecuteSqlCommand("update ServiceBill set [StatusCode] = '" + 7 + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "'  where ReceiptNo = '" + Shared.ToString(itm.Name) + "'");
                    context.SaveChanges();
                }

                ListBillData();

                //try
                //{
                //    DialogResult result1 = MessageBox.Show("Do you want to Send SMS for this Service ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                //    if (result1 == DialogResult.Yes)
                //    {
                //        var _result = (from c in context.ServiceBill where c.ReceiptNo == itm.Name select c).SingleOrDefault();
                //        if (_result != null)
                //        {
                //            string _retrunsms = Shared.ToString(System.Configuration.ConfigurationManager.AppSettings["ReturnSMS"]);
                //            string _msg = string.Format(_retrunsms, _result.CustomerName, _result.ModelNo);
                //            if (Program._port == null)
                //            {
                //                objCommon.MessageBoxFunction("Modem is Not Connected!", false);

                //            }
                //            else
                //            {
                //                if (objclsSMS.sendMsg(Program._port, _result.ContactNo, _msg))
                //                {
                //                    objCommon.MessageBoxFunction("Message has sent successfully", false);
                //                }
                //                else
                //                {
                //                    objCommon.MessageBoxFunction("Failed to send message", false);
                //                }
                //            }
                //        }

                //    }
                //}
                //catch (Exception ex)
                //{
                //    objCommon.MessageBoxFunction(ex.Message, true);
                //}
            }
        }

        private void mnuDoing_Click(object sender, EventArgs e)
        {
            clsCommon objCommon = new clsCommon();

            using (Entities context = new Entities())
            {
                ToolStripItem itm = (ToolStripItem)(sender);

                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");


                context.Database.ExecuteSqlCommand("update ServiceBill set [StatusCode] = '" + 6 + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "'  where ReceiptNo = '" + Shared.ToString(itm.Name) + "'");
                context.SaveChanges();

                ListBillData();

            }
        }

        public void setSerialPort(SerialPort port)
        {
            this.port = port;
        }

        private void mnuReady_Click(object sender, EventArgs e)
        {
            clsCommon objCommon = new clsCommon();

            using (Entities context = new Entities())
            {
                ToolStripItem itm = (ToolStripItem)(sender);

                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                
                var _readydate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DialogResult result = MessageBox.Show("Are you Sure , this Service is Ready?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    string promptValue = ActualCostPrompt.ShowDialog("Actual Cost for Service :", "", "");
                    if (Shared.ToDecimal(promptValue) == 0)
                    {
                        objCommon.MessageBoxFunction("Amount Can't Be Zero!", false);
                    }
                    else
                    {
                        context.Database.ExecuteSqlCommand("update ServiceBill set [StatusCode] = '" + 4 + "', [UpdatedBy] = '" + Shared.ToInt(userId) + "', [UpdatedDate] = '" + _readydate + "', [ReadyBy] = '" + Shared.ToInt(userId) + "', [ReadyDate] = '" + _readydate + "', [ActualCost] = '" + Shared.ToDouble(promptValue) + "'  where ReceiptNo = '" + Shared.ToString(itm.Name) + "'");
                        context.SaveChanges();
                    }
                }

                ListBillData();

                //try
                //{
                //   DialogResult result1 = MessageBox.Show("Do you want to Send SMS for this Service ?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                //   if (result1 == DialogResult.Yes)
                //   {
                //       var _result = (from c in context.ServiceBill where c.ReceiptNo == itm.Name select c).SingleOrDefault();
                //       if (_result != null)
                //       {
                //           string _readysms = Shared.ToString(System.Configuration.ConfigurationManager.AppSettings["ReadySMS"]);
                //           string _msg = string.Format(_readysms, _result.CustomerName, _result.ModelNo);
                //           if (Program._port == null)
                //           {
                //               objCommon.MessageBoxFunction("Modem is Not Connected!", false);
                               
                //           }
                //           else
                //           {
                //               if (objclsSMS.sendMsg(Program._port, _result.ContactNo, _msg))
                //               {
                //                   objclsSMS.sendMsg(Program._port, _result.ContactNo, " Please do not Reply to this SMS. Thanks for your Order! 123 Mobile PTE LTD.");
                //                   objCommon.MessageBoxFunction("Message has sent successfully", false);
                //               }
                //               else
                //               {
                //                   objCommon.MessageBoxFunction("Failed to send message", false);
                //               }
                //           }
                //       }
                       
                //   }
                //}
                //catch (Exception ex)
                //{
                //    objCommon.MessageBoxFunction(ex.Message, true);
                //}
            }
        }        

        private void dgvResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvResult.Rows)
            {
                if (Shared.ToString(Myrow.Cells[6].Value) == "Ready")
                {
                    Myrow.Cells[6].Style.BackColor = Color.Green;
                    Myrow.Cells[6].Style.ForeColor = Color.White;

                    Myrow.Cells[6].Style.SelectionBackColor = Color.Green;
                    Myrow.Cells[6].Style.SelectionForeColor = Color.White;
                }
                else if (Shared.ToString(Myrow.Cells[6].Value) == "Delivered")
                {
                    Myrow.Cells[6].Style.BackColor = Color.SkyBlue;
                    Myrow.Cells[6].Style.ForeColor = Color.White;

                    Myrow.Cells[6].Style.SelectionBackColor = Color.SkyBlue;
                    Myrow.Cells[6].Style.SelectionForeColor = Color.White;
                }
                else if (Shared.ToString(Myrow.Cells[6].Value) == "Return")
                {
                    Myrow.Cells[6].Style.BackColor = Color.Red;
                    Myrow.Cells[6].Style.ForeColor = Color.White;

                    Myrow.Cells[6].Style.SelectionBackColor = Color.Red;
                    Myrow.Cells[6].Style.SelectionForeColor = Color.White;
                }
                else if (Shared.ToString(Myrow.Cells[6].Value) == "Doing")
                {
                    Myrow.Cells[6].Style.BackColor = Color.Teal;
                    Myrow.Cells[6].Style.ForeColor = Color.White;

                    Myrow.Cells[6].Style.SelectionBackColor = Color.Teal;
                    Myrow.Cells[6].Style.SelectionForeColor = Color.White;
                }
                else 
                {
                    Myrow.Cells[6].Style.BackColor = Color.Violet;
                    Myrow.Cells[6].Style.ForeColor = Color.White;

                    Myrow.Cells[6].Style.SelectionBackColor = Color.Violet;
                    Myrow.Cells[6].Style.SelectionForeColor = Color.White;
                }
                
            }
        }

        private void cmbStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbStatus.Text.Length >= 0)
                cmbStatus.DroppedDown = true;
        }

        private void frmServiceBills_Load(object sender, EventArgs e)
        {
            dgvResult.ClearSelection();
            dgvResult.DefaultCellStyle.SelectionBackColor = dgvResult.DefaultCellStyle.BackColor;
            dgvResult.DefaultCellStyle.SelectionForeColor = dgvResult.DefaultCellStyle.ForeColor;
        }
       
    }
}

