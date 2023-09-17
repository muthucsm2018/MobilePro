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
    public class LabelForm : IDisposable
    {
        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        private string receiptNo = "00000";       
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


        private DataSet ReturnQueryService(string ReceiptNo)
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
                sqlParams[2].Value = "Bills";
                sqlParams[3] = new SqlParameter("@ParmType", SqlDbType.Int);
                sqlParams[3].Value = 2;

                dsQuery = Data.FetchRS(CommandType.StoredProcedure, "sp_frm_get_Bills", sqlParams);
            }
            catch (Exception ex)
            {

            }

            return dsQuery;
        }

       

        private DataTable LoadServiceData()
        {
            DataSet serviceds = ReturnQueryService(receiptNo);
            return serviceds.Tables[0];
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
            printDoc.PrinterSettings.PrinterName = Shared.ToString(System.Configuration.ConfigurationManager.AppSettings["BarcodePrinter"]);
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
                report.ReportPath = @"Label.rdlc";

                ReportDataSource rptDS = new ReportDataSource("DataSet1", new DataTable());
                ReportDataSource rptDS1 = new ReportDataSource("DataSet2", new DataTable());
                ReportDataSource rptDS2 = new ReportDataSource("DataSet3", LoadServiceData());

                report.DataSources.Clear();
                report.DataSources.Add(rptDS);
                report.DataSources.Add(rptDS1);
                report.DataSources.Add(rptDS2);
                
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
