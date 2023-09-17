
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MobilePro
{
    public partial class frmTemplate : Form
    {
        public frmTemplate()
        {
            InitializeComponent();
        }

        [System.ComponentModel.Browsable(true),
        System.ComponentModel.Category("CustomProperty"),
        System.ComponentModel.Description("The text of the caption.")]
        public string HeaderDescription
        {
            get
            {
                return this.lblTitle.Text;
            }
            set
            {
                this.lblTitle.Text = value;
            }
        }
    }
}