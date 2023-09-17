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
    public partial class frmExpenseAdd : MobilePro.frmTemplate
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

        public frmExpenseAdd()
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

        public class CreateExpenseModel
        {
            public int? ExpenseCode { get; set; }

            public int? VendorCode { get; set; }

            public string ExpenseName { get; set; }

            public string VendorName { get; set; }

            public string Charge { get; set; }

            public string Remarks { get; set; }

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
                        cmbSource.Items.Clear();
                        var comboSource = (from c in context.sp_frm_get_parm_ExpenseVendors(null, null,1)
                                      select new ComboboxItem
                                      {
                                          Text = c.VendorName,
                                          Value = Shared.ToString(c.VendorCode)
                                      }).ToList();


                        cmbSource.DataSource = new BindingSource(comboSource, null);
                        cmbSource.ValueMember = "Value";
                        cmbSource.DisplayMember = "Text";

                        BindDataToControl();
                        lblTitle.Text = "UPDATE EXPENSE";
                    }
                    else
                    {

                        cmbSource.Items.Clear();
                        var source = (from c in context.sp_frm_get_parm_ExpenseVendors(null, null,1)
                                      select new ComboboxItem
                                      {
                                          Text = c.VendorName,
                                          Value = Shared.ToString(c.VendorCode)
                                      }).ToList();

                        cmbSource.DataSource = source;
                        cmbSource.ValueMember = "Value";
                        cmbSource.DisplayMember = "Text";
                        lblTitle.Text = "NEW EXPENSE";

                    }
                }
               
            }
            catch(Exception ex)
            {
                objCommon.MessageBoxFunction(ex.Message, true);
            }
        }     
               

        private void BindDataToControl()
        {           
            using (Entities context = new Entities())
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                string userId = strip.Items["StatusBarUserId"].ToString();

                CreateExpenseModel model = (from c in context.sp_frm_get_Expense(Shared.ToInt(receiptNo), null, null, Shared.ToInt(userId), "Expense", 1, null, null)
                                            select new CreateExpenseModel
                         {
                             VendorCode = c.VendorCode,
                             VendorName = c.VendorName,
                             ExpenseCode = c.ExpenseCode,
                             ExpenseName = Shared.ToString(c.ExpenseName),
                             Charge = Shared.ToString(c.Charge),
                             Remarks = c.Remarks
                         }).FirstOrDefault();

                ExpenseCode.Text = Shared.ToString(model.ExpenseCode);
                Charge.Text = Shared.ToString(model.Charge);

                for (int i = 0; i < this.cmbSource.Items.Count; i++)
                {
                    string arrItem = this.cmbSource.Items[i].ToString();
                    if (arrItem.Length > 0)
                    {
                        if (arrItem.ToString() == model.VendorName.ToString())
                        {
                            this.cmbSource.SelectedIndex = i;
                            break;
                        }
                    }
                }

                //cmbSource.SelectedValue = model.VendorCode;
                Remarks.Text = model.Remarks;
                
            }
        }       

        private bool ValidateData()
        {
            clsCommon objCommon = new clsCommon();

            if (Shared.ToInt(Charge.Text) == 0)
            {
                objCommon.MessageBoxFunction("Amount is Required.", true);
                this.Charge.Focus();
                return false;
            }

            if (Shared.ToInt(cmbSource.SelectedIndex) == 0)
            {
                objCommon.MessageBoxFunction("Select Source.", true);
                this.cmbSource.Focus();
                return false;
            }
           
            return true;
        }

        private void SetupForm()
        {
            if (this._editMode == false)
            {
                //this.Status.Checked = true;
                cmbSource.Focus();
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
                                if (this._editMode == true)//Delete and Insert
                                {
                                    _affectedRows = context.sp_frm_add_upd_Expense(
                                    Shared.ToInt(((ComboboxItem)(cmbSource.SelectedItem)).Value),
                                    Shared.ToInt(ExpenseCode.Text),
                                    "",
                                    Shared.ToDecimal(Charge.Text),
                                    Remarks.Text,
                                    Shared.ToInt(userId),
                                    "Expense");
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                }
                                else
                                {
                                    _affectedRows = context.sp_frm_add_upd_Expense(
                                    Shared.ToInt(((ComboboxItem)(cmbSource.SelectedItem)).Value),
                                    (int?)null,
                                    "",
                                    Shared.ToDecimal(Charge.Text),
                                    Remarks.Text,
                                    Shared.ToInt(userId),
                                    "Expense");
                                    objCommon.MessageBoxFunction("Save completed.", false);
                                }
                            }

                            catch (Exception ex)
                            {
                                objmsg.MessageBoxFunction(ex.Message, true);
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
        }
        #endregion     

        private void frmBrandAdd_Activated(object sender, EventArgs e)
        {
            cmbSource.Focus();
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
                Button btn = ((Button)(btnSave));
                btn_Click(btn, null);
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
                Button btn = (Button)btnSave;
                btn_Click(btn, null);
            }
        }   
        
        private void btnclear_Click(object sender, EventArgs e)
        {
            try
            {
                cmbSource.Text = "";
                Charge.Text = "";
                Remarks.Text = "";
                cmbSource.Focus();
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
                if (this._editMode == true)//Delete and Insert
                {
                    DialogResult result = MessageBox.Show("Do you want to Delete this Expense?", "Yes or No", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    clsCommon objCommon = new clsCommon();
                    if (result == DialogResult.Yes)
                    {
                        using (Entities context = new Entities())
                        {
                            try
                            {
                                context.Database.ExecuteSqlCommand("delete from Expense where ExpenseCode = '" + ExpenseCode.Text + "'");
                                context.SaveChanges();
                                objCommon.MessageBoxFunction("Delete Completed!", false);

                                this.Close();
                            }
                            catch (Exception ex)
                            {
                                objCommon.MessageBoxFunction(ex.Message, true);
                            }
                        }
                    }
                }
                else
                {
                    objmsg.MessageBoxFunction("Delete Only in Update Expense!", true);
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

        private void cmbSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbSource.Text.Length >= 0)
                cmbSource.DroppedDown = true;
        }
        
        
    }
}

