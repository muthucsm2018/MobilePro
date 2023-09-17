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
using System.Reflection;


namespace MobilePro
{
    public partial class frmCreatePurchase : MobilePro.frmTemplate
    {
        #region Private Variable

        private string orderNo = "00000";
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

        public frmCreatePurchase()
        {
            InitializeComponent();
        }

        #region Property
        internal string _orderNo
        {
            get
            {
                return this.orderNo;
            }
            set
            {
                this.orderNo = value;
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

        public class CreatePurchaseModel
        {
            public string OrderNo { get; set; }

            public DateTime? PurchaseDate { get; set; }

            public int? VendorCode { get; set; }

            public decimal TotalAmount { get; set; }

        }

        public class PurchaseItemsListModel
        {
            public string OrderNo { get; set; }

            public string CategoryCode { get; set; }

            public string CategoryName { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string Quantity { get; set; }

            public string UnitCost { get; set; }

        }

        public class CreatePurchaseItemModel
        {
            public string OrderNo { get; set; }

            public int? CategoryCode { get; set; }

            public string CategoryName { get; set; }

            public string ProductCode { get; set; }

            public string ProductDesc { get; set; }

            public string Quantity { get; set; }

            public string UnitCost { get; set; }

        }

        public class ProductDetailsModel
        {
            public string ProductCode { get; set; }
            public string ProductDesc { get; set; }
            public string UnitCost { get; set; }
            public string Quantity { get; set; }
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
                        IList<ComboboxItem> BrandsList = new List<ComboboxItem>();

                        BrandsList = (from c in context.sp_frm_get_parm_Vendors(1, "Brands",1)
                                      select new ComboboxItem
                                      {
                                          Text = c.VendorName,
                                          Value = Shared.ToString(c.VendorCode)
                                      }).ToList();

                        cmbVendorCode.BindingContext = new BindingContext();
                        cmbVendorCode.DataSource = BrandsList;
                        cmbVendorCode.DisplayMember = "Text";
                        cmbVendorCode.ValueMember = "Value";

                        BindDataToControl();
                        lblTitle.Text = "UPDATE PURCHASE";
                    }
                    else
                    {

                        IList<ComboboxItem> BrandsList = new List<ComboboxItem>();

                        BrandsList = (from c in context.sp_frm_get_parm_Vendors(1, "Brands",1)
                                      select new ComboboxItem
                                      {
                                          Text = c.VendorName,
                                          Value = Shared.ToString(c.VendorCode)
                                      }).ToList();

                        cmbVendorCode.BindingContext = new BindingContext();
                        cmbVendorCode.DataSource = BrandsList;
                        cmbVendorCode.DisplayMember = "Text";
                        cmbVendorCode.ValueMember = "Value";

                        lblTitle.Text = "NEW PURCHASE";

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

                        List<ProductGridModel> model = (from c in context.sp_frm_get_Sales_Purchase_Items(Shared.ToString(orderNo), Shared.ToInt(userId), "StocksPurchase")
                                                        select new ProductGridModel
                                                        {
                                                            itm = Shared.ToString(c.ProductDesc),
                                                            Am = Shared.ToString(c.UnitCost),
                                                            Qty = Shared.ToString(c.Quantity),
                                                            Total = Shared.ToString(Shared.ToDouble(c.Quantity) * Shared.ToDouble(c.UnitCost)),
                                                            ID = c.CategoryCode + "," + c.ProductCode
                                                        }).ToList();
                        DataTable dt = ToDataTable(model);
                        
                        //BindingSource source = new BindingSource();
                        //source.DataSource = dt;
                        //this.dgvResult.Columns.Clear();
                        //this.dgvResult.DataSource = source;
                        //this.dgvResult.ClearSelection();

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

                        //BindingSource source = new BindingSource();
                        //source.DataSource = dt;
                        //this.dgvResult.Columns.Clear();
                        //this.dgvResult.DataSource = source;
                        //this.dgvResult.ClearSelection();

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

                CreatePurchaseModel model = (from c in context.sp_frm_get_Sales_Purchases(1, null, null, null, Shared.ToString(orderNo), Shared.ToInt(userId), "StocksPurchase")
                                         select new CreatePurchaseModel
                                         {
                                             OrderNo = c.OrderNo,
                                             VendorCode = c.VendorCode,
                                             PurchaseDate = c.PurchaseDate,
                                             TotalAmount = Shared.ToDecimal(c.TotalAmount)
                                         }).FirstOrDefault();

                txtOrderNo.Text = Shared.ToString(model.OrderNo);
                dtPurchaseDate.Text = Shared.ToString(model.PurchaseDate);

                IList<ComboboxItem> Branddt = (IList<ComboboxItem>)cmbVendorCode.DataSource;

                for (int i = 0; i < Branddt.Count; ++i)
                {
                    string displayText = Branddt[i].Text.ToString();
                    string valueItem = Branddt[i].Value.ToString();
                    // Process the object depending on the type
                    if (valueItem.Length > 0)
                    {
                        if (valueItem.ToString() == model.VendorCode.ToString())
                        {
                            this.cmbVendorCode.SelectedIndex = i;
                            break;
                        }
                    }

                }

                TotalAmount.Text = Shared.ToString(model.TotalAmount);

            }
        }

        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            if (Shared.ToInt(txtOrderNo.Text) == 0)
            {
                objCommon.MessageBoxFunction("Order No is Required.", true);
                this.txtOrderNo.Focus();
                return false;
            }

            if (Shared.ToInt(cmbVendorCode.SelectedIndex) == 0)
            {
                objCommon.MessageBoxFunction("Vendor is Required.", true);
                this.cmbVendorCode.Focus();
                return false;

            }
            if (Shared.ToInt(TotalAmount.Text) == 0)
            {
                objCommon.MessageBoxFunction("No Entry Found!", true);
                this.Quantity.Focus();
                return false;
            }

            return true;
        }

        private void SetupForm()
        {
            if (this._editMode == true)
            {
                this.txtOrderNo.Enabled = false;
            }
            else
            {
                this.txtOrderNo.Enabled = true;
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
                        using (Entities context = new Entities())
                        {
                            try
                            {
                                _affectedRows = context.sp_frm_add_upd_Sales_Purchase(
                                    1,txtOrderNo.Text,
                                    dtPurchaseDate.Checked == true ? dtPurchaseDate.Value.Date : DateTime.Now,
                                    Shared.ToInt(((ComboboxItem)(cmbVendorCode.SelectedItem)).Value),
                                    Shared.ToDecimal(TotalAmount.Text),
                                    Shared.ToInt(userId),
                                    "StocksPurchase"
                                );

                                if (this._editMode == true)//Delete and Insert
                                {
                                    string receiptno = Shared.ToString(txtOrderNo.Text);

                                    SqlConnection connection = new SqlConnection(Shared.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MobileProConnectionString"]));
                                    SqlCommand commandtext = new SqlCommand("select * from SalesPurchaseItems where OrderNo = '" + receiptno + "'", connection);
                                    DataTable results = new DataTable();
                                    SqlDataAdapter sqlda = new SqlDataAdapter(commandtext);
                                    sqlda.Fill(results);

                                    foreach (DataRow dr in results.Rows)
                                    {
                                        context.sp_frm_del_Sales_Purchase_Items(
                                                   Shared.ToString(dr["OrderNo"]),
                                                   Shared.ToInt(dr["CategoryCode"]),
                                                   Shared.ToString(dr["ProductCode"]),
                                                   1,
                                                   "StocksPurchase"
                                                   );
                                    }
                                }

                                int rows = dgvResult.Rows.Count;
                                for (int i = 0; i < rows; i++)
                                {
                                    string trno = txtOrderNo.Text;
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

                                    _affectedRows = context.sp_frm_add_upd_Sales_Purchase_Items(
                                          trno,
                                          _categorycode,
                                          _productcode,
                                          Shared.ToInt(qty),
                                          _price,
                                          Shared.ToInt(userId),
                                          "StocksPurchase"                                          
                                          );

                                }

                                if (this._editMode == true)
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                }
                                else
                                {
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                    //Refresh the Current Form
                                    frmCreatePurchase frm = new frmCreatePurchase();                  
                                    frm.MdiParent = this.ParentForm;
                                    frm.Dock = DockStyle.Fill;
                                    frm.Show();
                                    this.Dispose();
                                   
                                }
                            }
                            catch (Exception ex)
                            {
                                objCommon.MessageBoxFunction(ex.InnerException.Message, true);
                            }
                        }
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

        private void frmCreatePurchase_Activated(object sender, EventArgs e)
        {
            try
            {
                cmbautocomplete.AutoCompleteMode = AutoCompleteMode.None;
                cmbautocomplete.DataSource = Autocomplete("");
            }
            catch
            {

            }

            txtOrderNo.Focus();
        }

        private void frmCreatePurchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl S
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnSave;
                btn_Click(btn, null);
            }

            if (e.Control && e.KeyCode == Keys.C)       // Ctrl S
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnsuspend;
                btn_Click(btn, null);
            }

            if (e.KeyCode == Keys.Escape)       // Cancel or Back
            {
                e.SuppressKeyPress = true;
                Button btn = (Button)btnClose;
                btn_Click(btn, null);
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
                        newRow["Am"] = Convert.ToDouble(UnitCost.Text);
                        newRow["Qty"] = Shared.ToString(Quantity.Text);
                        newRow["Total"] = (Convert.ToDouble(Quantity.Text) * Convert.ToDouble(UnitCost.Text));
                        newRow["ID"] = ProductCode;
                        // Add the row to the rows collection.
                        table.Rows.Add(newRow);
                    }
                    else
                    {
                        dgvResult.Rows.Add(ProductName, Convert.ToDouble(UnitCost.Text), Shared.ToString(Quantity.Text), (Convert.ToDouble(Quantity.Text) * Convert.ToDouble(UnitCost.Text)), ProductCode);
                    }
                }

                TotalCalculation();               

                cmbautocomplete.Text = "";
                Quantity.Text = "1";
                UnitCost.Text = "";
                txtSearch.Text = "";               
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
               
                TotalAmount.Text = totalsum.ToString();
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
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
                                     UnitCost = Shared.ToString(c.UnitPrice),
                                     Quantity = Shared.ToString(c.Quantity)
                                 }).Where(c => c.ProductCode.Equals(code)).FirstOrDefault();

                        UnitCost.Text = model.UnitCost;
                        Quantity.Focus();

                    }
                }
            }
            catch (Exception ex)
            {
                objmsg.MessageBoxFunction(ex.Message, true);
            }
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

        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                dgvResult.Rows.Clear();
                cmbautocomplete.Text = "";
                Quantity.Text = "1";
                UnitCost.Text = "";
                txtSearch.Text = "";
                TotalAmount.Text = "";
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
                DialogResult result = MessageBox.Show("Do you want to Delete this Purchase. All items will be Deleted?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                clsCommon objCommon = new clsCommon();
                if (result == DialogResult.Yes)
                {
                    using (Entities context = new Entities())
                    {
                        try
                        {
                            string receiptno = Shared.ToString(txtOrderNo.Text);

                            SqlConnection connection = new SqlConnection(Shared.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["MobileProConnectionString"]));
                            SqlCommand commandtext = new SqlCommand("select * from SalesPurchaseItems where OrderNo = '" + receiptno + "'", connection);
                            DataTable results = new DataTable();
                            SqlDataAdapter sqlda = new SqlDataAdapter(commandtext);
                            sqlda.Fill(results);

                            foreach (DataRow dr in results.Rows)
                            {
                                context.sp_frm_del_Sales_Purchase_Items(
                                           Shared.ToString(dr["OrderNo"]),
                                           Shared.ToInt(dr["CategoryCode"]),
                                           Shared.ToString(dr["ProductCode"]),
                                           1,
                                           "StocksPurchase"
                                           );
                            }

                            context.Database.ExecuteSqlCommand("delete from SalesPurchase where OrderNo = '" + receiptno + "'");
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
        }

        private void dgvResult_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

    }
}

