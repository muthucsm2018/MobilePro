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
using System.IO.Ports;


namespace MobilePro
{
    public partial class frmSMSModem : MobilePro.frmTemplate
    {
        public frmSMSModem()
        {
            InitializeComponent();
        }        

        #region Event Handler

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            clsCommon objCommon = new clsCommon();

            switch (btn.Name.ToString())
            {

                case "btnClose":
                    this.ParentForm.Controls["pnlSub"].Show();
                    this.Close();
                    break;              

            }
        }             

        #endregion


        #region Private Variables
        SerialPort port = new SerialPort();
        clsSMS objclsSMS = new clsSMS();
        clsCommon objCommon = new clsCommon();
        #endregion

        #region Private Methods

        #region Write StatusBar
        private void WriteStatusBar(string status)
        {
            try
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];                
                strip.Items["statusBarRole"].Text = "Message: " + status;
            }
            catch (Exception ex)
            {

            }
        }       

        #endregion

        #endregion

        #region Private Events

        private void SMSapplication_Load(object sender, EventArgs e)
        {
            try
            {
                #region Display all available COM Ports
                string[] ports = SerialPort.GetPortNames();

                // Add all port names to the combo box:
                foreach (string port in ports)
                {
                    this.cboPortName.Items.Add(port);
                }
                #endregion               

                this.btnDisconnect.Enabled = false;
            }
            catch (Exception ex)
            {
               objCommon.MessageBoxFunction(ex.Message, true);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                StatusStrip strip = (StatusStrip)this.MdiParent.Controls["StatusBarMain"];
                
                //Open communication port 
                this.port = objclsSMS.OpenPort(this.cboPortName.Text, Convert.ToInt32(this.cboBaudRate.Text), Convert.ToInt32(this.cboDataBits.Text), Convert.ToInt32(this.txtReadTimeOut.Text), Convert.ToInt32(this.txtWriteTimeOut.Text));

                if (this.port != null)
                {
                    Program._port = this.port;
                    this.gboPortSettings.Enabled = false;
                    strip.Items["statusBarRole"].Text = "Modem is connected at PORT " + this.cboPortName.Text;
                 
                    this.lblConnectionStatus.Text = "Connected at " + this.cboPortName.Text;
                    this.btnDisconnect.Enabled = true;
                }

                else
                {
                    strip.Items["statusBarRole"].Text = "Invalid port settings";
                }
            }
            catch (Exception ex)
            {
                objCommon.MessageBoxFunction(ex.Message, true);
            }

        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                this.gboPortSettings.Enabled = true;
                objclsSMS.ClosePort(this.port);
                Program._port = new SerialPort();

                this.lblConnectionStatus.Text = "Not Connected";
                this.btnDisconnect.Enabled = false;

            }
            catch (Exception ex)
            {
                objCommon.MessageBoxFunction(ex.Message, true);
            }
        }
       
       

        #endregion
       
    }    
}

