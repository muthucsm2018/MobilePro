using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace MobilePro
{
    static class Program
    {
        public static SerialPort _port;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainScreen());
        }
    }
}
