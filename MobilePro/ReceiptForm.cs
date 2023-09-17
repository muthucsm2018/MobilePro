using System;
using System.IO;
using System.Data;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Drawing;
using System.Data.SqlClient;
using MobilePro.Classes;

namespace MobilePro
{
    public class ReceiptForm : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private string receiptNo = "00000";
        private string tendered = "00";
        private string disc = "00";
        private string change = "00";
        private bool editMode = false;       

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

        internal string _tendered
        {
            get
            {
                return this.tendered;
            }
            set
            {
                this.tendered = value;
            }
        }

        internal string _disc
        {
            get
            {
                return this.disc;
            }
            set
            {
                this.disc = value;
            }
        }


        internal string _change
        {
            get
            {
                return this.change;
            }
            set
            {
                this.change = value;
            }
        }

        private DataSet ReturnQuerySale(string ReceiptNo)
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
                sqlParams[2].Value = "Sales";
                sqlParams[3] = new SqlParameter("@ParmType", SqlDbType.Int);
                sqlParams[3].Value = 2;

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Sales", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }

        private DataSet ReturnQuerySaleBill(string ReceiptNo)
        {
            DataSet dsQuery = new DataSet();

            try
            {
                SqlParameter[] sqlParams = new SqlParameter[3];

                sqlParams[0] = new SqlParameter("@ReceiptNo", SqlDbType.NVarChar, 50);
                sqlParams[0].Value = Shared.ToString(ReceiptNo);
                sqlParams[1] = new SqlParameter("@UserId", SqlDbType.Int);
                sqlParams[1].Value = 1;
                sqlParams[2] = new SqlParameter("@PageName", SqlDbType.VarChar, 50);
                sqlParams[2].Value = "Sales";


                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Sales_Bill_Items", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }

        private DataTable LoadSalesData()
        {
            DataSet salesds = ReturnQuerySale(receiptNo);
            return salesds.Tables[0];
        }

        private DataTable LoadSalesBillData()
        {
            DataSet salesbillds = ReturnQuerySaleBill(receiptNo);
            return salesbillds.Tables[0];
        }
        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }
        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
              @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>3.12in</PageWidth>
                <PageHeight>11.69in</PageHeight>
                <MarginTop>0.2in</MarginTop>
                <MarginLeft>0in</MarginLeft>
                <MarginRight>0in</MarginRight>
                <MarginBottom>0.2in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;
        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            printDoc.PrinterSettings.PrinterName = Shared.ToString(System.Configuration.ConfigurationManager.AppSettings["Printer"]);
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void Run()
        {
            try
            {
                LocalReport report = new LocalReport();
                report.ReportPath = @"Receipt.rdlc";

                ReportDataSource rptDS = new ReportDataSource("DataSet1", LoadSalesData());
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", LoadSalesBillData());

                report.DataSources.Clear();
                report.DataSources.Add(rptDS);
                report.DataSources.Add(rptDS1);

                //report.DataSources.Add(
                //   new ReportDataSource("Sales", LoadSalesData()));

                ReportParameter[] parameters;

                parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("Tendered", String.Format("{0:C}", Shared.ToDecimal(tendered)));
                parameters[1] = new ReportParameter("Change", String.Format("{0:C}", Shared.ToDecimal(change)));
                parameters[2] = new ReportParameter("Disc", String.Format("{0:C}", Shared.ToDecimal(disc)));

                report.SetParameters(parameters);
                Export(report);
                Print();
            }
            catch (LocalProcessingException ex)
            {
                clsCommon objCommon = new clsCommon();
                objCommon.MessageBoxFunction(ex.Message.ToString(), true);
            }

            catch (Exception ex)
            {
                clsCommon objCommon = new clsCommon();
                objCommon.MessageBoxFunction(ex.Message.ToString(), true);
            }
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

       
    }
}
