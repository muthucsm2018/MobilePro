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
    public partial class frmBillAdd : MobilePro.frmTemplate
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

        public frmBillAdd()
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

        public class CreateSaleModel
        {
            public string ReceiptNo { get; set; }

            public DateTime? ServiceDate { get; set; }

            public string CustomerName { get; set; }

            public decimal? DiscountAmount { get; set; }

            public decimal NetAmount { get; set; }

            public string PaymentType { get; set; }

        }

        public class SaleItemsListModel
        {
            public string ReceiptNo { get; set; }

            public string CategoryCode { get; set; }

            public string CategoryName { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string Quantity { get; set; }

            public string SellingPrice { get; set; }

        }

        public class CreateSaleItemModel
        {
            public string ReceiptNo { get; set; }

            public int? CategoryCode { get; set; }

            public string CategoryName { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string Quantity { get; set; }

            public string SellingPrice { get; set; }

        }

        public class ProductDetailsModel
        {
            public string ProductCode { get; set; }
            public string ProductDesc { get; set; }
            public string UnitPrice { get; set; }
            public string SellingPrice { get; set; }
            public string Quantity { get; set; }
        }

        public static string GenerateSaleNo()
        {
            string _patientid = "";
            using (Entities context = new Entities())
            {
                try
                {
                    var count = context.SalesBill.AsEnumerable().Count();
                    if (count > 0)
                    {
                        var _existId = (from c in context.SalesBill orderby c.ReceiptNo descending select c.ReceiptNo).FirstOrDefault();
                        _existId = Shared.ToString(_existId).Split('-')[1];
                        _patientid = "S" + "-" + ((Int32.Parse(_existId) + 1).ToString("D4").Trim());
                    }
                    else
                    {
                        _patientid = "S" + "-" + "0001";
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                return _patientid;
            }
        }

        public class ProductGridModel
        {

            public string itm { get; set; }
            public string Am { get; set; }
            public string Qty { get; set; }
            public string Total { get; set; }
            public string ID { get; set; }
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
                        cmbPaymentType.Items.Clear();
                        cmbPaymentType.Items.Add(new ComboboxItem { Text = "CASH", Value = "CASH" });
                        cmbPaymentType.Items.Add(new ComboboxItem { Text = "NETS", Value = "NETS" });
                        cmbPaymentType.SelectedIndex = 0;

                        BindDataToControl();
                        lblTitle.Text = "UPDATE BILL";
                    }
                    else
                    {

                        BillNo.Text = GenerateSaleNo();
                        ServiceDate.Text = DateTime.Now.ToString();
                        cmbPaymentType.Items.Clear();
                        cmbPaymentType.Items.Add(new ComboboxItem { Text = "CASH", Value = "CASH" });
                        cmbPaymentType.Items.Add(new ComboboxItem { Text = "NETS", Value = "NETS" });
                        cmbPaymentType.SelectedIndex = 0;
                        lblTitle.Text = "NEW BILL";

                    }
                }

            }
            catch (Exception ex)
            {
                objCommon.MessageBoxFunction(ex.Message, true);
            }
        }

        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void SetupDataGrid()
        {
            try
            {
                using (Entities context = new Entities())
                {
                    if (_editMode == true)
                    {
                        StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                        string userId = strip.Items["StatusBarUserId"].ToString();

                        this.dgvResult.Rows.Clear();

                        List<ProductGridModel> model = (from c in context.sp_frm_get_Sales_Bill_Items(Shared.ToString(receiptNo), null, Shared.ToInt(userId), "Sales")
                                                        select new ProductGridModel
                                                        {
                                                            itm = Shared.ToString(c.ProductDesc),
                                                            Am = Shared.ToString(c.SellingPrice),
                                                            Qty = Shared.ToString(c.Quantity),
                                                            Total = Shared.ToString(Shared.ToDouble(c.Quantity) * Shared.ToDouble(c.SellingPrice)),
                                                            ID = c.CategoryCode + "," + c.ProductCode
                                                        }).ToList();
                        DataTable dt = ToDataTable(model);
                        this.dgvResult.DataSource = dt;

                        this.dgvResult.Columns[0].HeaderText = "Item Name";
                        this.dgvResult.Columns[0].Width = 300;
                        this.dgvResult.Columns[1].HeaderText = "Price";
                        this.dgvResult.Columns[1].Width = 75;
                        this.dgvResult.Columns[2].HeaderText = "Qty";
                        this.dgvResult.Columns["Qty"].Width = 50;
                        this.dgvResult.Columns[3].HeaderText = "Total";
                        this.dgvResult.Columns[4].HeaderText = "ID";
                        this.dgvResult.Columns[4].Visible = false;


                        DataGridViewButtonColumn inc = new DataGridViewButtonColumn();
                        dgvResult.Columns.Insert(5, inc);
                        inc.HeaderText = "Inc";
                        inc.Text = "+";
                        inc.Name = "inc";
                        inc.UseColumnTextForButtonValue = true;

                        DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                        dgvResult.Columns.Insert(6, del);
                        del.HeaderText = "Del";
                        del.Text = "X";
                        del.Name = "del";
                        del.UseColumnTextForButtonValue = true;

                        this.dgvResult.Columns["itm"].DisplayIndex = 0;
                        this.dgvResult.Columns["Am"].DisplayIndex = 1;
                        this.dgvResult.Columns["Qty"].DisplayIndex = 2;
                        this.dgvResult.Columns["Total"].DisplayIndex = 3;
                        this.dgvResult.Columns["ID"].DisplayIndex = 4;
                        this.dgvResult.Columns["inc"].DisplayIndex = 5;
                        this.dgvResult.Columns["del"].DisplayIndex = 6;
                    }
                    else
                    {
                        DataGridViewButtonColumn itemsname = new DataGridViewButtonColumn();
                        itemsname.Name = "itm";
                        itemsname.HeaderText = "Item Name";
                        itemsname.Width = 300;
                        this.dgvResult.Columns.Add(itemsname);

                        //this.dgvResult.Columns.Add("itm", "Items Name");
                        this.dgvResult.Columns.Add("Am", "Price");
                        this.dgvResult.Columns.Add("Qty", "Quantity");
                        this.dgvResult.Columns.Add("Total", "Total");

                        DataGridViewButtonColumn ID = new DataGridViewButtonColumn();
                        ID.Name = "ID";
                        ID.HeaderText = "ID";
                        ID.Visible = false;
                        this.dgvResult.Columns.Add(ID);

                        DataGridViewButtonColumn inc = new DataGridViewButtonColumn();
                        dgvResult.Columns.Add(inc);
                        inc.HeaderText = "Inc";
                        inc.Text = "+";
                        inc.Name = "inc";
                        inc.Width = 50;
                        inc.UseColumnTextForButtonValue = true;

                        DataGridViewButtonColumn del = new DataGridViewButtonColumn();
                        dgvResult.Columns.Add(del);
                        del.HeaderText = "Del";
                        del.Text = "X";
                        del.Name = "del";
                        inc.Width = 50;
                        del.UseColumnTextForButtonValue = true;

                        this.dgvResult.Rows[0].Cells[2].Value = "1";

                    }
                }

            }
            catch
            {

            }
        }

        private void BindDataToControl()
        {
            using (Entities context = new Entities())
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                CreateSaleModel model = (from c in context.sp_frm_get_Sales(1, Shared.ToString(receiptNo), null, null, Shared.ToInt(userId), "ListSales", 2, null)
                                         select new CreateSaleModel
                                         {
                                             ReceiptNo = c.ReceiptNo,
                                             CustomerName = c.CustomerName,
                                             ServiceDate = c.ServiceDate,
                                             PaymentType = c.PaymentType,
                                             DiscountAmount = Shared.ToDecimal(c.DiscountAmount),
                                             NetAmount = Shared.ToDecimal(c.NetAmount)
                                         }).FirstOrDefault();

                BillNo.Text = Shared.ToString(model.ReceiptNo);
                ServiceDate.Text = Shared.ToString(model.ServiceDate);
                CustomerName.Text = Shared.ToString(model.CustomerName);
                //cmbPaymentType.SelectedValue = Shared.ToString(model.PaymentType);
                for (int i = 0; i < this.cmbPaymentType.Items.Count; i++)
                {
                    string arrItem = this.cmbPaymentType.Items[i].ToString();
                    if (arrItem.Length > 0)
                    {
                        if (arrItem.ToString() == model.PaymentType.ToString())
                        {
                            this.cmbPaymentType.SelectedIndex = i;
                            break;
                        }
                    }
                }

                try
                {
                    Discount.Text = Shared.ToString(model.DiscountAmount);
                }
                catch { }
                NetAmount.Text = Shared.ToString(model.NetAmount);

                double total = Convert.ToDouble(Shared.ToString(model.NetAmount));
                //double DisCount = (total * Convert.ToDouble(Shared.ToString(model.DiscountAmount))) / 100;
                double DisCount = Convert.ToDouble(Shared.ToString(Discount.Text));
                double sum = total + DisCount;
                sum = Math.Round(sum, 0);

                lbltotal.Text = Shared.ToString(sum);
            }
        }

        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            if (Shared.ToInt(NetAmount.Text) == 0)
            {
                objCommon.MessageBoxFunction("Bill Amount Cannot be Zero.", true);
                this.Quantity.Focus();
                return false;
            }

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
                                _affectedRows = context.sp_frm_add_upd_Sales_Bill(
                                     _billno,
                                    Shared.ToString(CustomerName.Text).ToUpper(),
                                    Shared.ToString(((ComboboxItem)(cmbPaymentType.SelectedItem)).Value),
                                    DateTime.Parse(ServiceDate.Text),
                                    Shared.ToDecimal(Discount.Text),
                                    Shared.ToDecimal(NetAmount.Text),
                                    1,
                                    Shared.ToInt(userId),
                                    "CreateSale"
                                );

                                if (this._editMode == true)//Delete and Insert
                                {
                                    string receiptno = _billno;

                                    SqlConnection connection = new SqlConnection(Shared.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MobileProConnectionString"]));
                                    SqlCommand commandtext = new SqlCommand("select * from SalesItems where ReceiptNo = '" + receiptno + "'", connection);
                                    DataTable results = new DataTable();
                                    SqlDataAdapter sqlda = new SqlDataAdapter(commandtext);
                                    sqlda.Fill(results);

                                    foreach (DataRow dr in results.Rows)
                                    {
                                        context.sp_frm_del_Sales_Bill_Items(
                                                   Shared.ToString(dr["ReceiptNo"]),
                                                   Shared.ToInt(dr["CategoryCode"]),
                                                   Shared.ToString(dr["ProductCode"]),
                                                   "",
                                                   Shared.ToInt(dr["Quantity"]),
                                                   1,
                                                   "Sales"
                                                   );
                                    }
                                }

                                int rows = dgvResult.Rows.Count;
                                for (int i = 0; i < rows; i++)
                                {
                                    string trno = _billno;
                                    string item, qty, total = "";
                                    decimal? _price = 0;
                                    if (this._editMode == true)
                                    {
                                        item = dgvResult.Rows[i].Cells[6].Value.ToString();
                                        qty = dgvResult.Rows[i].Cells[4].Value.ToString();
                                        _price = Shared.ToDecimal(dgvResult.Rows[i].Cells[3].Value.ToString());
                                        total = dgvResult.Rows[i].Cells[5].Value.ToString();
                                    }
                                    else
                                    {
                                        item = dgvResult.Rows[i].Cells[4].Value.ToString();
                                        qty = dgvResult.Rows[i].Cells[2].Value.ToString();
                                        _price = Shared.ToDecimal(dgvResult.Rows[i].Cells[1].Value.ToString());
                                        total = dgvResult.Rows[i].Cells[3].Value.ToString();
                                    }

                                    var _categorycode = Shared.ToInt(item.Split(',')[0]);
                                    var _productcode = Shared.ToString(item.Split(',')[1]);

                                    _affectedRows = context.sp_frm_add_upd_Sales_Bill_Items(
                                          trno,
                                          _categorycode,
                                          _productcode,
                                          "","",
                                          Shared.ToInt(qty),
                                          _price,
                                          Shared.ToInt(userId),
                                          "Sales"
                                          );

                                }

                                if (this._editMode == true)
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                }
                                else
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                    //btnclear_Click(null, null);
                                    //this.frm_Load(this, null);
                                   
                                    //Refresh the Current Form
                                    frmBillAdd frm = new frmBillAdd();
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
                                _affectedRows1 = context.sp_frm_add_upd_Sales_Bill(
                                    _billno,
                                   Shared.ToString(CustomerName.Text).ToUpper(),
                                   Shared.ToString(((ComboboxItem)(cmbPaymentType.SelectedItem)).Value),
                                   DateTime.Parse(ServiceDate.Text),
                                   Shared.ToDecimal(Discount.Text),
                                   Shared.ToDecimal(NetAmount.Text),
                                   1,
                                   Shared.ToInt(userId),
                                   "CreateSale"
                               );

                                if (this._editMode == true)//Delete and Insert
                                {
                                    string receiptno = _billno;

                                    SqlConnection connection = new SqlConnection(Shared.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MobileProConnectionString"]));
                                    SqlCommand commandtext = new SqlCommand("select * from SalesItems where ReceiptNo = '" + receiptno + "'", connection);
                                    DataTable results = new DataTable();
                                    SqlDataAdapter sqlda = new SqlDataAdapter(commandtext);
                                    sqlda.Fill(results);

                                    foreach (DataRow dr in results.Rows)
                                    {
                                        context.sp_frm_del_Sales_Bill_Items(
                                                   Shared.ToString(dr["ReceiptNo"]),
                                                   Shared.ToInt(dr["CategoryCode"]),
                                                   Shared.ToString(dr["ProductCode"]),
                                                   "",
                                                   Shared.ToInt(dr["Quantity"]),
                                                   1,
                                                   "Sales"
                                                   );
                                    }
                                }

                                int rows = dgvResult.Rows.Count;
                                for (int i = 0; i < rows; i++)
                                {
                                    string trno = _billno;
                                    string item, qty, total = "";
                                    decimal? _price = 0;
                                    if (this._editMode == true)
                                    {
                                        item = dgvResult.Rows[i].Cells[6].Value.ToString();
                                        qty = dgvResult.Rows[i].Cells[4].Value.ToString();
                                        _price = Shared.ToDecimal(dgvResult.Rows[i].Cells[3].Value.ToString());
                                        total = dgvResult.Rows[i].Cells[5].Value.ToString();
                                    }
                                    else
                                    {
                                        item = dgvResult.Rows[i].Cells[4].Value.ToString();
                                        qty = dgvResult.Rows[i].Cells[2].Value.ToString();
                                        _price = Shared.ToDecimal(dgvResult.Rows[i].Cells[1].Value.ToString());
                                        total = dgvResult.Rows[i].Cells[3].Value.ToString();
                                    }

                                    var _categorycode = Shared.ToInt(item.Split(',')[0]);
                                    var _productcode = Shared.ToString(item.Split(',')[1]);

                                    _affectedRows = context.sp_frm_add_upd_Sales_Bill_Items(
                                          trno,
                                          _categorycode,
                                          _productcode,
                                          "","",
                                          Shared.ToInt(qty),
                                          _price,
                                          Shared.ToInt(userId),
                                          "Sales"
                                          );

                                }
                                if (this._editMode == true)
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);

                                    ReceiptForm frm1 = new ReceiptForm();
                                    frm1._editMode = this._editMode;
                                    frm1._receiptNo = BillNo.Text;
                                    frm1._tendered = txtPaidAmount.Text;
                                    frm1._change = txtChangeAmount.Text;
                                    frm1._disc = Discount.Text;
                                    frm1.Dispose();
                                    frm1.Run();

                                    //RptReceipt frm = new RptReceipt();
                                    //frm._editMode = this._editMode;
                                    //frm._receiptNo = _billno;
                                    //frm._tendered = txtPaidAmount.Text;
                                    //frm._change = txtChangeAmount.Text;
                                    //frm._disc = Discount.Text;
                                    //ShowForm(frm);
                                }
                                else
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                    //btnclear_Click(null, null);
                                    //this.frm_Load(this, null);

                                    ReceiptForm frm1 = new ReceiptForm();
                                    frm1._editMode = this._editMode;
                                    frm1._receiptNo = BillNo.Text;
                                    frm1._tendered = txtPaidAmount.Text;
                                    frm1._change = txtChangeAmount.Text;
                                    frm1._disc = Discount.Text;
                                    frm1.Dispose();
                                    frm1.Run();

                                    //RptReceipt frm = new RptReceipt();
                                    //frm._editMode = this._editMode;
                                    //frm._receiptNo = _billno;
                                    //frm._tendered = txtPaidAmount.Text;
                                    //frm._change = txtChangeAmount.Text;
                                    //frm._disc = Discount.Text;
                                    //ShowForm(frm);

                                    btnclear_Click(null, null);
                                    this.frm_Load(this, null);

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
                        ReceiptForm frm1 = new ReceiptForm();
                        frm1._editMode = this._editMode;
                        frm1._receiptNo = BillNo.Text;
                        frm1._tendered = txtPaidAmount.Text;
                        frm1._change = txtChangeAmount.Text;
                        frm1._disc = Discount.Text;
                        frm1.Dispose();
                        frm1.Run();

                        //RptReceipt frm = new RptReceipt();
                        //frm._editMode = this._editMode;
                        //frm._receiptNo = BillNo.Text;
                        //frm._tendered = txtPaidAmount.Text;
                        //frm._change = txtChangeAmount.Text;
                        //frm._disc = Discount.Text;
                        //ShowForm(frm);
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
            SetupDataGrid();
        }
        #endregion

        private void frmBrandAdd_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        public IList<ComboboxItem> Autocomplete(string term)
        {
            using (Entities context = new Entities())
            {
                var result = new List<KeyValuePair<string, string>>();

                IList<ComboboxItem> ItemsList = new List<ComboboxItem>();

                ItemsList = (from c in context.sp_frm_get_Sales_Stock_Items(term, 1, "SalesStocks")
                             select new ComboboxItem
                             {
                                 Text = c.ItemName,
                                 Value = Shared.ToString(c.ItemCode)
                             }).ToList();

                return ItemsList;
            }
        }

        private void frmBrandAdd_Activated(object sender, EventArgs e)
        {
            try
            {
                cmbautocomplete.AutoCompleteMode = AutoCompleteMode.None;
                cmbautocomplete.DataSource = Autocomplete("");
            }
            catch
            {

            }

            txtSearch.Focus();
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

            if (e.KeyCode == Keys.F5)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                txtPaidAmount.Focus();
            }

            if (e.KeyCode == Keys.F6)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                Discount.Focus();
            }

            if (e.KeyCode == Keys.F7)       // Ctrl-S Save
            {
                // Do what you want here
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
                cmbPaymentType.Focus();
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
                btnadd_Click(null, null);
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

        private void btnadd_Click(object sender, EventArgs e)
        {
            // _productcode = Shared.ToString(ProductCode.Split(',')[1]);
            try
            {
                var ProductName = Shared.ToString(((ComboboxItem)(cmbautocomplete.SelectedItem)).Text);
                ProductName = Shared.ToString(ProductName.Split(',')[1]);
                var ProductCode = Shared.ToString(((ComboboxItem)(cmbautocomplete.SelectedItem)).Value);
                //ProductCode = Shared.ToString(ProductCode.Split(',')[1]);

                bool found = false;
                foreach (DataGridViewRow row in dgvResult.Rows)
                {
                    var _cellValue = _editMode == true ? Shared.ToString(row.Cells[6].Value) : Shared.ToString(row.Cells[4].Value);

                    if (_cellValue == Shared.ToString(ProductCode))
                    {
                        // row exists
                        found = true;
                        MessageBox.Show("Already exists. Update Quantity!");
                        break;
                    }
                }

                if (!found)
                {
                    if (_editMode == true)
                    {
                        DataTable table = (DataTable)(dgvResult.DataSource);
                        DataRow newRow = table.NewRow();
                        newRow["itm"] = ProductName;
                        newRow["Am"] = Convert.ToDouble(Price.Text);
                        newRow["Qty"] = Shared.ToString(Quantity.Text);
                        newRow["Total"] = (Convert.ToDouble(Quantity.Text) * Convert.ToDouble(Price.Text));
                        newRow["ID"] = ProductCode;
                        // Add the row to the rows collection.
                        table.Rows.Add(newRow);
                    }
                    else
                    {
                        dgvResult.Rows.Add(ProductName, Convert.ToDouble(Price.Text), Shared.ToString(Quantity.Text), (Convert.ToDouble(Quantity.Text) * Convert.ToDouble(Price.Text)), ProductCode);
                    }
                }


                TotalCalculation();

                try
                {
                    ////    Discount
                    double total = Convert.ToDouble(Shared.ToString(lbltotal.Text));
                    //double DisCount = (total * Convert.ToDouble(Shared.ToString(Discount.Text))) / 100;
                    double DisCount = Convert.ToDouble(Shared.ToString(Discount.Text));
                    double sum = total - DisCount;
                    sum = Math.Round(sum, 1);
                    DisCount = Math.Round(DisCount, 2);
                    NetAmount.Text = sum.ToString();

                }
                catch { }

                cmbautocomplete.Text = "";
                Quantity.Text = "1";
                Price.Text = "";
                txtSearch.Text = "";
                lblunitcost.Text = "";
                lblstock.Text = "";
                txtSearch.Focus();

            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        // Discount Calculation
        public void TotalCalculation()
        {
            try
            {
                // // total sum 
                double totalsum = 0;
                for (int i = 0; i < dgvResult.Rows.Count; ++i)
                {
                    if (this._editMode == true)
                    {
                        totalsum += Convert.ToDouble(dgvResult.Rows[i].Cells[5].Value);
                    }
                    else
                    {
                        totalsum += Convert.ToDouble(dgvResult.Rows[i].Cells[3].Value);
                    }
                }

                lbltotal.Text = totalsum.ToString();
                NetAmount.Text = totalsum.ToString();
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Entities context = new Entities())
            {
                //ComboBox cmb = (ComboBox)sender;

                //ComboboxItem selected = (ComboboxItem)cmb.SelectedItem;

                //if (selected != null)
                //{
                //    var code = Shared.ToString(selected.Value);
                //    ProductDetailsModel model = new ProductDetailsModel();
                //    // select data by id here display static data;

                //    model = (from c in context.sp_frm_get_Sales_Stock_Items("", 1, "SalesStocks")
                //             select new ProductDetailsModel
                //             {
                //                 ProductDesc = c.ItemName,
                //                 ProductCode = Shared.ToString(c.ItemCode),
                //                 UnitPrice = Shared.ToString(c.UnitPrice),
                //                 SellingPrice = Shared.ToString(c.SellingPrice),
                //                 Quantity = Shared.ToString(c.Quantity)
                //             }).Where(c => c.ProductCode.Equals(code)).FirstOrDefault();

                //    lblstock.Text = model.Quantity;
                //    Price.Text = model.SellingPrice;
                //    lblunitcost.Text = model.UnitPrice;
                //    Quantity.Focus();
                //}

            }
        }

        private void cmbautocomplete_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    using (Entities context = new Entities())
                    {
                        var code = Shared.ToString(((ComboboxItem)(cmbautocomplete.SelectedItem)).Value);
                        ProductDetailsModel model = new ProductDetailsModel();
                        // select data by id here display static data;

                        model = (from c in context.sp_frm_get_Sales_Stock_Items("", 1, "SalesStocks")
                                 select new ProductDetailsModel
                                 {
                                     ProductDesc = c.ItemName,
                                     ProductCode = Shared.ToString(c.ItemCode),
                                     UnitPrice = Shared.ToString(c.UnitPrice),
                                     SellingPrice = Shared.ToString(c.SellingPrice),
                                     Quantity = Shared.ToString(c.Quantity)
                                 }).Where(c => c.ProductCode.Equals(code)).FirstOrDefault();

                        lblstock.Text = model.Quantity;
                        Price.Text = model.SellingPrice;
                        lblunitcost.Text = "$ " + model.UnitPrice;
                        Quantity.Focus();

                    }
                }
                else
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
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //try
            //{
            //    string name = string.Format("{0}{1}", txtSearch.Text, e.KeyChar.ToString()); //join previous text and new pressed char
            //    cmbautocomplete.DataSource = null;
            //    cmbautocomplete.DataSource = Autocomplete(name);
            //    cmbautocomplete.DisplayMember = "Text";
            //}
            //catch (Exception ex)
            //{
            //    objmsg.MessageBoxFunction(ex.Message, true);
            //}
        }

        private void Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnadd_Click(null, null);
            }
        }

        private void dgvResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                // Delete items From Gridview
                if (e.ColumnIndex == dgvResult.Columns["del"].Index && e.RowIndex >= 0)
                {
                    foreach (DataGridViewRow row2 in dgvResult.SelectedRows)
                    {
                        DialogResult result = MessageBox.Show("Do you want to Delete?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

                        if (result == DialogResult.Yes)
                        {
                            if (!row2.IsNewRow)
                                dgvResult.Rows.Remove(row2);
                        }

                    }
                }

                // Increase Item Quantity
                if (e.ColumnIndex == dgvResult.Columns["inc"].Index && e.RowIndex >= 0)
                {

                    foreach (DataGridViewRow row in dgvResult.SelectedRows)
                    {

                        if (this._editMode == true)
                        {
                            double sum1 = Convert.ToDouble(row.Cells[4].Value) + 1;
                            row.Cells[4].Value = sum1;

                            double ts = Convert.ToDouble(row.Cells[4].Value) * Convert.ToDouble(row.Cells[3].Value);
                            row.Cells[5].Value = ts;
                        }
                        else
                        {
                            double sum1 = Convert.ToDouble(row.Cells[2].Value) + 1;
                            row.Cells[2].Value = sum1;

                            double ts = Convert.ToDouble(row.Cells[2].Value) * Convert.ToDouble(row.Cells[1].Value);
                            row.Cells[3].Value = ts;
                        }

                    }
                }

                TotalCalculation();

            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void Discount_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            if (lbltotal.Text == "")
            {
                // MessageBox.Show("please insert Amount ");
            }
            else
            {
                try
                {
                    if (Convert.ToDouble(txtPaidAmount.Text) >= Convert.ToDouble(NetAmount.Text))
                    {
                        double changeAmt = Convert.ToDouble(txtPaidAmount.Text) - Convert.ToDouble(NetAmount.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        txtChangeAmount.Text = changeAmt.ToString();
                        //txtDueAmount.Text = "0";
                    }
                    if (Convert.ToDouble(txtPaidAmount.Text) <= Convert.ToDouble(NetAmount.Text))
                    {
                        double changeAmt = Convert.ToDouble(NetAmount.Text) - Convert.ToDouble(txtPaidAmount.Text);
                        changeAmt = Math.Round(changeAmt, 2);
                        //txtDueAmount.Text = changeAmt.ToString();
                        txtChangeAmount.Text = "0";
                    }

                }
                catch (Exception ex)
                {
                    //objmsg.MessageBoxFunction(ex.Message, true);
                }

            }
        }

        private void Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ////    Discount
                double total = Convert.ToDouble(Shared.ToString(lbltotal.Text, "0"));
                //double DisCount = (total * Convert.ToDouble(Shared.ToString(Discount.Text, "0"))) / 100;
                double DisCount = Convert.ToDouble(Shared.ToString(Discount.Text));
                double sum = total - DisCount;
                sum = Math.Round(sum, 1);
                DisCount = Math.Round(DisCount, 2);
                NetAmount.Text = sum.ToString();
            }
            catch (Exception ex)
            {
                //objmsg.MessageBoxFunction(ex.Message, true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPaidAmount.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Discount.Focus();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cmbPaymentType.Focus();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResult.Rows.Clear();
                CustomerName.Text = "";

                cmbautocomplete.Text = "";
                Quantity.Text = "1";
                Price.Text = "";
                txtSearch.Text = "";
                lblunitcost.Text = "";
                lblstock.Text = "";
                Discount.Text = "";
                lbltotal.Text = "";
                cmbPaymentType.Text = "";
                txtPaidAmount.Text = "";
                txtChangeAmount.Text = "";
                NetAmount.Text = "";
                txtSearch.Focus();
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
                DialogResult result = MessageBox.Show("Do you want to Clear this Sale. All items will be Deleted?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                clsCommon objCommon = new clsCommon();
                if (result == DialogResult.Yes)
                {
                    using (Entities context = new Entities())
                    {
                        try
                        {
                            string receiptno = Shared.ToString(BillNo.Text);

                            SqlConnection connection = new SqlConnection(Shared.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MobileProConnectionString"]));
                            SqlCommand commandtext = new SqlCommand("select * from SalesItems where ReceiptNo = '" + receiptno + "'", connection);
                            DataTable results = new DataTable();
                            SqlDataAdapter sqlda = new SqlDataAdapter(commandtext);
                            sqlda.Fill(results);

                            foreach (DataRow dr in results.Rows)
                            {
                                context.sp_frm_del_Sales_Bill_Items(
                                           Shared.ToString(dr["ReceiptNo"]),
                                           Shared.ToInt(dr["CategoryCode"]),
                                           Shared.ToString(dr["ProductCode"]),
                                           "",
                                           Shared.ToInt(dr["Quantity"]),                                          
                                           1,
                                           "Sales"
                                           );
                            }

                            context.Database.ExecuteSqlCommand("delete from SalesBill where ReceiptNo = '" + BillNo.Text + "'");
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string name = string.Format("{0}", txtSearch.Text); //join previous text and new pressed char
                cmbautocomplete.DataSource = null;
                cmbautocomplete.DataSource = Autocomplete(name);
                cmbautocomplete.DisplayMember = "Text";

            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }

            // _productcode = Shared.ToString(ProductCode.Split(',')[1]);

            //if (txtSearch.Text == "")
            //{

            //}
            //else
            //{
            //    using (Entities context = new Entities())
            //    {

            //        var code = Shared.ToString(txtSearch.Text);
            //        ProductDetailsModel model = new ProductDetailsModel();
            //        // select data by id here display static data;

            //        model = (from c in context.sp_frm_get_Sales_Stock_Items(code, null, 1, "SalesStocks")
            //                 select new ProductDetailsModel
            //                 {
            //                     ProductDesc = c.ItemName,
            //                     ProductCode = Shared.ToString(c.ItemCode),
            //                     UnitPrice = Shared.ToString(c.UnitPrice),
            //                     SellingPrice = Shared.ToString(c.SellingPrice),
            //                     Quantity = Shared.ToString(c.Quantity)
            //                 }).FirstOrDefault();

            //        try
            //        {
            //            var ProductName = Shared.ToString(model.ProductDesc);
            //            ProductName = Shared.ToString(ProductName.Split(',')[1]);

            //            var ProductCode = code;

            //            bool found = false;
            //            foreach (DataGridViewRow row in dgvResult.Rows)
            //            {
            //                var _cellValue = _editMode == true ? Shared.ToString(row.Cells[6].Value) : Shared.ToString(row.Cells[4].Value);

            //                if (_cellValue == Shared.ToString(model.ProductCode))
            //                {
            //                    // row exists
            //                    found = true;
            //                    MessageBox.Show("Already exists. Update Quantity!");
            //                    break;
            //                }
            //            }

            //            if (!found)
            //            {
            //                if (_editMode == true)
            //                {
            //                    DataTable table = (DataTable)(dgvResult.DataSource);
            //                    DataRow newRow = table.NewRow();
            //                    newRow["itm"] = ProductName;
            //                    newRow["Am"] = Convert.ToDouble(model.SellingPrice);
            //                    newRow["Qty"] = Shared.ToString(1);
            //                    newRow["Total"] = (Convert.ToDouble(1) * Convert.ToDouble(model.SellingPrice));
            //                    newRow["ID"] = model.ProductCode;
            //                    // Add the row to the rows collection.
            //                    table.Rows.Add(newRow);
            //                }
            //                else
            //                {
            //                    dgvResult.Rows.Add(ProductName, Convert.ToDouble(model.SellingPrice), Shared.ToString(1), (Convert.ToDouble(1) * Convert.ToDouble(model.SellingPrice)), model.ProductCode);
            //                }
            //            }


            //            TotalCalculation();

            //            try
            //            {
            //                ////    Discount
            //                double total = Convert.ToDouble(Shared.ToString(lbltotal.Text));
            //                //double DisCount = (total * Convert.ToDouble(Shared.ToString(Discount.Text))) / 100;
            //                double DisCount = Convert.ToDouble(Shared.ToString(Discount.Text));
            //                double sum = total - DisCount;
            //                sum = Math.Round(sum, 1);
            //                DisCount = Math.Round(DisCount, 2);
            //                NetAmount.Text = sum.ToString();

            //            }
            //            catch { }

            //            cmbautocomplete.Text = "";
            //            Quantity.Text = "1";
            //            Price.Text = "";
            //            txtSearch.Text = "";
            //            lblunitcost.Text = "";
            //            lblstock.Text = "";
            //            txtSearch.Focus();

            //        }
            //        catch (Exception ex)
            //        {
            //            //objmsg.MessageBoxFunction(ex.Message, true);
            //        }
            //    }
            //}
        }

        private void dgvResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

    }
}

