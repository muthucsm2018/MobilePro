using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MobilePro.Classes;
using System.Linq;
using System.Data.SqlClient;
using System.Reflection;


namespace MobilePro
{
    public partial class frmServiceBillAdd : MobilePro.frmTemplate
    {
        #region Private Variable

        private string receiptNo = "00000";
        private DataTable dt = new DataTable();
        private bool editMode = false;
        clsCommon objmsg = new clsCommon();

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

        public frmServiceBillAdd()
        {
            InitializeComponent();
        }

        #region Property
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
        #endregion

        #region Method

        public class CreateBillModel
        {
            public string ReceiptNo { get; set; }

            public DateTime? ServiceDate { get; set; }

            public string CustomerName { get; set; }

            public string ContactNo { get; set; }

            public int? BrandCode { get; set; }

            public string ModelNo { get; set; }

            public string NatureFault { get; set; }

            public string Condition { get; set; }

            public decimal EstimateAmount { get; set; }

            public string IMEINo { get; set; }

            public int? OutSourceCode { get; set; }

            public int? StatusCode { get; set; }

            public string PasswordType { get; set; }

            public string Password { get; set; }

            public string TechRemark { get; set; }

            public decimal NetAmount { get; set; }

        }

        public static string GenerateSaleNo()
        {
            string _patientid = "";
            using (Entities context = new Entities())
            {
                try
                {
                    var count = context.ServiceBill.AsEnumerable().Count();
                    if (count > 0)
                    {
                        var _existId = (from c in context.ServiceBill orderby c.ReceiptNo descending select c.ReceiptNo).FirstOrDefault();
                        _existId = Shared.ToString(_existId).Split('-')[1];
                        _patientid = "R" + "-" + ((Int32.Parse(_existId) + 1).ToString("D4").Trim());
                    }
                    else
                    {
                        _patientid = "R" + "-" + "0001";
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return _patientid;
            }
        }

        private void SetupTable()
        {
            clsCommon objCommon = new clsCommon();
            try
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();
                using (Entities context = new Entities())
                {
                    if (_editMode == true)
                    {
                        BindDropdowns();
                        BindDataToControl();
                        lblTitle.Text = "UPDATE BILL";
                    }
                    else
                    {
                        BillNo.Text = GenerateSaleNo();
                        ServiceDate.Text = DateTime.Now.ToString();
                        BindDropdowns();                     
                        lblTitle.Text = "NEW BILL";
                    }
                }

            }
            catch (Exception ex)
            {
                objCommon.MessageBoxFunction(ex.Message, true);
            }
        }

        private void BindDropdowns()
        {
            using (Entities context = new Entities())
            {
                IList<ComboboxItem> BrandsList = new List<ComboboxItem>();

                BrandsList = (from c in context.sp_frm_get_parm_Brands(1, "Brands",1)
                              select new ComboboxItem
                              {
                                  Text = c.BrandName,
                                  Value = Shared.ToString(c.BrandCode)
                              }).ToList();

                cmbBrandCode.BindingContext = new BindingContext();
                cmbBrandCode.DataSource = BrandsList;               
                cmbBrandCode.DisplayMember = "Text";
                cmbBrandCode.ValueMember = "Value";

                cmbBrandCode.AutoCompleteMode = AutoCompleteMode.Suggest;

                IList<ComboboxItem> ConditionList = new List<ComboboxItem>();

                ConditionList = (from c in context.sp_frm_get_parm_Condition(1, "Condition")
                              select new ComboboxItem
                              {
                                  Text = c.ConditionName,
                                  Value = Shared.ToString(c.ConditionName)
                              }).ToList();

                //cmbCondition.BindingContext = new BindingContext();
                //cmbCondition.DataSource = ConditionList;
                //cmbCondition.DisplayMember = "Text";
                //cmbCondition.ValueMember = "Value";

                //cmbCondition.AutoCompleteMode = AutoCompleteMode.Suggest;

                IList<ComboboxItem> FaultList = new List<ComboboxItem>();

                FaultList = (from c in context.sp_frm_get_parm_Fault(1, "Fault")
                              select new ComboboxItem
                              {
                                  Text = c.FaultName,
                                  Value = Shared.ToString(c.FaultName)
                              }).ToList();

                //cmbNatureFault.BindingContext = new BindingContext();
                //cmbNatureFault.DataSource = FaultList;
                //cmbNatureFault.DisplayMember = "Text";
                //cmbNatureFault.ValueMember = "Value";

                //cmbNatureFault.AutoCompleteMode = AutoCompleteMode.Suggest;

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
                
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                var auth = context.security_UsersInRoles.AsEnumerable().Count(p => p.UserID == Shared.ToInt(userId) && p.RoleID == 1);
                if (auth > 0)
                {
                    IList<ComboboxItem> StatusAllList = new List<ComboboxItem>();

                    StatusAllList = (from c in context.sp_frm_get_Parm_Status(1, "Bills")
                                  select new ComboboxItem
                                  {
                                      Text = c.StatusName,
                                      Value = Shared.ToString(c.StatusCode)
                                  }).ToList();

                    cmbStatusCode.BindingContext = new BindingContext();
                    cmbStatusCode.DataSource = StatusAllList;
                    cmbStatusCode.DisplayMember = "Text";
                    cmbStatusCode.ValueMember = "Value";
                    //cmbStatusCode.SelectedIndex = 1;
                }
                else
                {
                    IList<ComboboxItem> StatusList = new List<ComboboxItem>();
                    StatusList.Add(new ComboboxItem { Text = "New", Value = "1" });
                    StatusList.Add(new ComboboxItem { Text = "Rework", Value = "2" });

                    cmbStatusCode.BindingContext = new BindingContext();
                    cmbStatusCode.DataSource = StatusList.ToList();
                    cmbStatusCode.DisplayMember = "Text";
                    cmbStatusCode.ValueMember = "Value";
                    cmbStatusCode.SelectedIndex = 0;
                }

                IList<ComboboxItem> PasswordList = new List<ComboboxItem>();                
                PasswordList.Add(new ComboboxItem { Text = "", Value = "" });
                PasswordList.Add(new ComboboxItem { Text = "Number", Value = "Number" });
                PasswordList.Add(new ComboboxItem { Text = "Pattern", Value = "Pattern" });

                cmbPasswordType.BindingContext = new BindingContext();
                cmbPasswordType.DataSource = PasswordList.ToList();
                cmbPasswordType.DisplayMember = "Text";
                cmbPasswordType.ValueMember = "Value";
                cmbPasswordType.SelectedIndex = 0;

            }          
        }

        private void BindDataToControl()
        {
            using (Entities context = new Entities())
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                CreateBillModel model = (from c in context.sp_frm_get_Bills(1, Shared.ToString(receiptNo), null, null, (DateTime?)null, null, null, null, Shared.ToInt(userId), "ListBills", 2)
                                         select new CreateBillModel
                                         {
                                             ReceiptNo = c.ReceiptNo,
                                             ServiceDate = c.ServiceDate,
                                             CustomerName = c.CustomerName,
                                             ContactNo = c.ContactNo,
                                             ModelNo = c.ModelNo,
                                             NatureFault = c.NatureFault,
                                             //Condition = c.Condition,
                                             EstimateAmount = Shared.ToDecimal(c.EstimateAmount),
                                             IMEINo = c.IMEINo,
                                             Password = c.Password,
                                             TechRemark = c.TechRemark,
                                             BrandCode = c.BrandCode,
                                             OutSourceCode = c.OutSourceCode,
                                             StatusCode = c.StatusCode,
                                             PasswordType = c.PasswordType,
                                             NetAmount = Shared.ToDecimal(c.NetAmount)
                                         }).FirstOrDefault();

                BillNo.Text = Shared.ToString(model.ReceiptNo);
                ServiceDate.Text = Shared.ToString(model.ServiceDate);
                CustomerName.Text = Shared.ToString(model.CustomerName);
                ContactNo.Text = Shared.ToString(model.ContactNo);
                ModelNo.Text = Shared.ToString(model.ModelNo);
                cmbNatureFault.Text = Shared.ToString(model.NatureFault);
                NetAmount.Text = Shared.ToString(model.EstimateAmount);
                IMEINo.Text = Shared.ToString(model.IMEINo);
                Password.Text = Shared.ToString(model.Password);
                TechRemark.Text = Shared.ToString(model.TechRemark);

                
                //IList<ComboboxItem> NatureFaultdt = (IList<ComboboxItem>)cmbNatureFault.DataSource;

                //for (int i = 0; i < NatureFaultdt.Count; ++i)
                //{
                //    string displayText = NatureFaultdt[i].Text.ToString();
                //    string valueItem = NatureFaultdt[i].Value.ToString();
                //    // Process the object depending on the type
                //    if (displayText.Length > 0)
                //    {
                //        if (displayText.ToString() == model.NatureFault.ToString())
                //        {
                //            this.cmbNatureFault.SelectedIndex = i;
                //            break;
                //        }
                //    }

                //}

                //IList<ComboboxItem> Conditiondt = (IList<ComboboxItem>)cmbCondition.DataSource;

                //for (int i = 0; i < Conditiondt.Count; ++i)
                //{
                //    string displayText = Conditiondt[i].Text.ToString();
                //    string valueItem = Conditiondt[i].Value.ToString();
                //    // Process the object depending on the type
                //    if (displayText.Length > 0)
                //    {
                //        if (displayText.ToString() == model.Condition.ToString())
                //        {
                //            this.cmbCondition.SelectedIndex = i;
                //            break;
                //        }
                //    }

                //}

                IList<ComboboxItem> Branddt = (IList<ComboboxItem>)cmbBrandCode.DataSource;

                for (int i = 0; i < Branddt.Count; ++i)
                {
                    string displayText = Branddt[i].Text.ToString();
                    string valueItem = Branddt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == model.BrandCode.ToString())
                        {
                            this.cmbBrandCode.SelectedIndex = i;
                            break;
                        }
                    }

                }

                IList<ComboboxItem> OutSourcedt = (IList<ComboboxItem>)cmbOutSourceCode.DataSource;

                for (int i = 0; i < OutSourcedt.Count; ++i)
                {
                    string displayText = OutSourcedt[i].Text.ToString();
                    string valueItem = OutSourcedt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == model.OutSourceCode.ToString())
                        {
                            this.cmbOutSourceCode.SelectedIndex = i;
                            break;
                        }
                    }

                }

                IList<ComboboxItem> Statusdt = (IList<ComboboxItem>)cmbStatusCode.DataSource;

                for (int i = 0; i < Statusdt.Count; ++i)
                {
                    string displayText = Statusdt[i].Text.ToString();
                    string valueItem = Statusdt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == model.StatusCode.ToString())
                        {
                            this.cmbStatusCode.SelectedIndex = i;
                            break;
                        }
                    }

                }

                IList<ComboboxItem> Passworddt = (IList<ComboboxItem>)cmbPasswordType.DataSource;

                for (int i = 0; i < Passworddt.Count; ++i)
                {
                    string displayText = Passworddt[i].Text.ToString();
                    string valueItem = Passworddt[i].Value.ToString();
                    // Process the object depending on the type
                    if (displayText.Length > 0)
                    {
                        if (displayText.ToString() == model.PasswordType.ToString())
                        {
                            this.cmbPasswordType.SelectedIndex = i;
                            break;
                        }
                    }

                }   

               
                //for (int i = 0; i < this.cmbPasswordType.Items.Count; i++)
                //{
                //    string arrItem = this.cmbPasswordType.Items[i].ToString();
                //    if (arrItem.Length > 0)
                //    {
                //        if (arrItem.ToString() == model.PasswordType.ToString())
                //        {
                //            this.cmbPasswordType.SelectedIndex = i;
                //            break;
                //        }
                //    }
                //}

            }
        }

        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            //if ((Shared.ToInt(cmbStatusCode.SelectedIndex) != 1 && Shared.ToInt(NetAmount.Text) == 0))
            //{
            //    objCommon.MessageBoxFunction("Bill Amount Cannot be Zero.", true);
            //    this.NetAmount.Focus();
            //    return false;
            //}

            if (Shared.ToInt(CustomerName.Text) == 0)
            {
                objCommon.MessageBoxFunction("Customer Name is Required.", true);
                this.CustomerName.Focus();
                return false;
            }

            if (Shared.ToInt(ContactNo.Text) == 0)
            {
                objCommon.MessageBoxFunction("Contact No is Required.", true);
                this.ContactNo.Focus();
                return false;
            }

            if (Shared.ToInt(ModelNo.Text) == 0)
            {
                objCommon.MessageBoxFunction("Model No is Required.", true);
                this.ModelNo.Focus();
                return false;
            }

            if (Shared.ToString(cmbNatureFault.Text) == "")
            {
                objCommon.MessageBoxFunction("Nature Fault is Required.", true);
                this.cmbNatureFault.Focus();
                return false;
            }

            if (Shared.ToInt(cmbBrandCode.SelectedIndex) == 0)
            {
                objCommon.MessageBoxFunction("Brand is Required.", true);
                this.cmbBrandCode.Focus();
                return false;
            }
            //if (Shared.ToInt(cmbStatusCode.SelectedIndex) == 0)
            //{
            //    objCommon.MessageBoxFunction("Status is Required.", true);
            //    this.cmbStatusCode.Focus();
            //    return false;
            //}

            return true;
        }

        private void SetupForm()
        {
            if (this._editMode == false)
            {
                //this.Status.Checked = true;
            }

        }
        #endregion

        #region EventHandler

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name.ToString())
            {
                case "btnSave":
                    bool isValidated = ValidateData();
                    int _affectedRows = 0;

                    if (isValidated == true)
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();
                        clsCommon objCommon = new clsCommon();

                        var _billno = this._editMode == true ? BillNo.Text : GenerateSaleNo();

                        using (Entities context = new Entities())
                        {
                            try
                            {
                                _affectedRows = context.sp_frm_add_upd_Bill(
                                    _billno,
                                    Shared.ToString(CustomerName.Text).ToUpper(),
                                    ContactNo.Text,
                                    ModelNo.Text,
                                    //Shared.ToString(((ComboboxItem)(cmbNatureFault.SelectedItem)).Value),
                                    Shared.ToString(cmbNatureFault.Text),
                                    "",
                                    Shared.ToInt(((ComboboxItem)(cmbStatusCode.SelectedItem)).Value),                                    
                                    TechRemark.Text,
                                    Shared.ToDecimal(NetAmount.Text),
                                    "",
                                    Shared.ToString(((ComboboxItem)(cmbPasswordType.SelectedItem)).Value),
                                    Password.Text,
                                    DateTime.Parse(ServiceDate.Text),
                                    "",
                                    Shared.ToInt(((ComboboxItem)(cmbBrandCode.SelectedItem)).Value),
                                    0,
                                    "",
                                    IMEINo.Text,
                                    Shared.ToInt(((ComboboxItem)(cmbOutSourceCode.SelectedItem)).Value),
                                    Shared.ToDecimal(NetAmount.Text),
                                    Shared.ToDecimal(NetAmount.Text),
                                    Shared.ToDecimal(0),
                                    Shared.ToDecimal(NetAmount.Text),
                                    1,
                                    Shared.ToInt(userId),
                                    "Bills"
                                );                                                          

                                if (this._editMode == true)
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                }
                                else
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                    //Refresh the Current Form
                                    frmServiceBills frm = new frmServiceBills();
                                    frm.MdiParent = this.ParentForm;
                                    frm.Dock = DockStyle.Fill;
                                    frm.Show();
                                    this.Dispose();
                                }
                            }
                            catch (Exception ex)
                            {
                                objCommon.MessageBoxFunction(ex.Message, true);
                            }
                        }
                    }
                    break;

                case "btnsettleprint":
                    bool isValidated1 = ValidateData();
                    int _affectedRows1 = 0;

                    if (isValidated1 == true)
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();
                        clsCommon objCommon = new clsCommon();

                        var _billno = this._editMode == true ? BillNo.Text : GenerateSaleNo();

                        using (Entities context = new Entities())
                        {
                            try
                            {
                                _affectedRows1 = context.sp_frm_add_upd_Bill(
                                    _billno,
                                    Shared.ToString(CustomerName.Text).ToUpper(),
                                    ContactNo.Text,
                                    ModelNo.Text,
                                    //Shared.ToString(((ComboboxItem)(cmbNatureFault.SelectedItem)).Value),
                                    Shared.ToString(cmbNatureFault.Text),
                                    "",
                                    Shared.ToInt(((ComboboxItem)(cmbStatusCode.SelectedItem)).Value),
                                    TechRemark.Text,
                                    Shared.ToDecimal(NetAmount.Text),
                                    "",
                                    Shared.ToString(((ComboboxItem)(cmbPasswordType.SelectedItem)).Value),
                                    Password.Text,
                                    DateTime.Parse(ServiceDate.Text),
                                    "",
                                    Shared.ToInt(((ComboboxItem)(cmbBrandCode.SelectedItem)).Value),
                                    0,
                                    "",
                                    IMEINo.Text,
                                    Shared.ToInt(((ComboboxItem)(cmbOutSourceCode.SelectedItem)).Value),
                                    Shared.ToDecimal(NetAmount.Text),
                                    Shared.ToDecimal(NetAmount.Text),
                                    Shared.ToDecimal(0),
                                    Shared.ToDecimal(NetAmount.Text),
                                    1,
                                    Shared.ToInt(userId),
                                    "Bills"
                               );                               

                               
                                if (this._editMode == true)
                                {
                                    //objCommon.MessageBoxFunction("Save completed.", false);

                                    BillReceiptForm frm1 = new BillReceiptForm();
                                    frm1._editMode = this._editMode;
                                    frm1._receiptNo = _billno;
                                    frm1.Dispose();
                                    frm1.Run();

                                    //BillRptReceipt frm = new BillRptReceipt();
                                    //frm._editMode = this._editMode;
                                    //frm._receiptNo = _billno;
                                    //ShowForm(frm);
                                }
                                else
                                {
                                   // objCommon.MessageBoxFunction("Save completed.", false);

                                    //BillRptReceipt frm = new BillRptReceipt();
                                    //frm._editMode = this._editMode;
                                    //frm._receiptNo = _billno;
                                    //ShowForm(frm);

                                    BillReceiptForm frm1 = new BillReceiptForm();
                                    frm1._editMode = this._editMode;
                                    frm1._receiptNo = _billno;
                                    frm1.Dispose();
                                    frm1.Run();

                                    //Refresh the Current Form
                                    frmServiceBills frm2 = new frmServiceBills();
                                    frm2.MdiParent = this.ParentForm;
                                    frm2.Dock = DockStyle.Fill;
                                    frm2.Show();
                                    this.Dispose();

                                }
                            }
                            catch (Exception ex)
                            {
                                objCommon.MessageBoxFunction(ex.Message, true);
                            }
                        }
                    }
                    break;

                case "btnreprint":

                    if (this._editMode == false)
                    {
                        clsCommon objCommon = new clsCommon();
                        objCommon.MessageBoxFunction("Reprint Only Available in Update Bill!", false);
                    }
                    else
                    {
                        BillRptReceipt frm = new BillRptReceipt();
                        frm._editMode = this._editMode;
                        frm._receiptNo = BillNo.Text;
                        ShowForm(frm);

                        //BillReceiptForm frm1 = new BillReceiptForm();
                        //frm1._editMode = this._editMode;
                        //frm1._receiptNo = BillNo.Text;
                        //frm1.Dispose();
                        //frm1.Run();
                    }
                    break;

                case "btnClose":
                    this.Close();
                    break;
            }
        }

        private void ShowForm(Form frm)
        {
            frm.MdiParent = this.ParentForm;
            frm.Show();
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.dt != null)
                this.dt.Dispose();
        }

        private void frm_Load(object sender, EventArgs e)
        {
            SetupTable();
            SetupForm();

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;

        }
        #endregion

        private void frmBrandAdd_Activated(object sender, EventArgs e)
        {
            try
            {
                //cmbBrandCode.AutoCompleteMode = AutoCompleteMode.None;
                //cmbBrandCode.DataSource = Autocomplete("");
            }
            catch
            {

            }

            CustomerName.Focus();
        }

        private void frmBrandAdd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl S
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnSave;
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.Escape)       // Cancel or Back
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnClose;
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.F3)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                btnclear_Click(null, null);
            }

            if (e.KeyCode == Keys.F4)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                btnsuspend_Click(null, null);
            }
          

            if (e.KeyCode == Keys.F8)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = ((Button)(btnSave));
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.F9)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Button btn = ((Button)(btnsettleprint));
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

        private void NetAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
               // btnadd_Click(null, null);
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                Button btn = (Button)btnsettleprint;
                btn_Click(btn, null);
            }
        }

        public virtual void Cbo_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cb.DroppedDown = true;
            string strFindStr = "";
            if (e.KeyChar == (char)8)
            {
                if (cb.SelectionStart <= 1)
                {
                    cb.Text = "";
                    return;
                }

                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text.Substring(0, cb.Text.Length - 1);
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1);
            }
            else
            {
                if (cb.SelectionLength == 0)
                    strFindStr = cb.Text + e.KeyChar;
                else
                    strFindStr = cb.Text.Substring(0, cb.SelectionStart) + e.KeyChar;
            }
            int intIdx = -1;
            // Search the string in the ComboBox list.
            intIdx = cb.FindString(strFindStr);
            if (intIdx != -1)
            {
                cb.SelectedText = "";
                cb.SelectedIndex = intIdx;
                cb.SelectionStart = strFindStr.Length;
                cb.SelectionLength = cb.Text.Length;
                e.Handled = true;
            }
            else
                e.Handled = true;
        }
       
        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                CustomerName.Text = ContactNo.Text = cmbBrandCode.Text = ModelNo.Text = cmbNatureFault.Text = IMEINo.Text = cmbOutSourceCode.Text = "";
                cmbStatusCode.Text = cmbPasswordType.Text = Password.Text = TechRemark.Text = "";
                NetAmount.Text = "0";
                CustomerName.Focus();
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void btnsuspend_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you want to Clear this Service?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                clsCommon objCommon = new clsCommon();
                if (result == DialogResult.Yes)
                {
                    using (Entities context = new Entities())
                    {
                        try
                        {
                            string receiptno = Shared.ToString(BillNo.Text);

                            context.Database.ExecuteSqlCommand("delete from ServiceBill where ReceiptNo = '" + BillNo.Text + "'");
                            context.SaveChanges();
                            objCommon.MessageBoxFunction("Suspend Completed!", false);

                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            objCommon.MessageBoxFunction(ex.Message, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void btnsettle_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)(btnSave));
            btn_Click(btn, null);
        }

        private void btnsettleprint_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)(btnsettleprint));
            btn_Click(btn, null);
        }

        private void btnreprint_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)(btnreprint));
            btn_Click(btn, null);
        }

        private void cmbBrandCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbBrandCode.Text.Length >= 0)
                cmbBrandCode.DroppedDown = true;
        }

        private void cmbOutSourceCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbOutSourceCode.Text.Length >= 0)
                cmbOutSourceCode.DroppedDown = true;
        }

        private void cmbPasswordType_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbPasswordType.Text.Length >= 0)
                cmbPasswordType.DroppedDown = true;
        }

        private void cmbStatusCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbStatusCode.Text.Length >= 0)
                cmbStatusCode.DroppedDown = true;
        }

    }
}

