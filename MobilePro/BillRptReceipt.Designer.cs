﻿namespace MobilePro
{
    partial class BillRptReceipt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.sp_frm_get_SalesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sp_frm_get_Sales_Bill_ItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.sp_frm_get_SalesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_frm_get_Sales_Bill_ItemsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sp_frm_get_SalesBindingSource
            // 
            this.sp_frm_get_SalesBindingSource.DataMember = "sp_frm_get_Sales";
            // 
            // sp_frm_get_Sales_Bill_ItemsBindingSource
            // 
            this.sp_frm_get_Sales_Bill_ItemsBindingSource.DataMember = "sp_frm_get_Sales_Bill_Items";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.sp_frm_get_SalesBindingSource;
            reportDataSource4.Name = "DataSet2";
            reportDataSource4.Value = this.sp_frm_get_Sales_Bill_ItemsBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "MobilePro.Receipt.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ShowBackButton = false;
            this.reportViewer1.ShowFindControls = false;
            this.reportViewer1.ShowPageNavigationControls = false;
            this.reportViewer1.ShowRefreshButton = false;
            this.reportViewer1.ShowStopButton = false;
            this.reportViewer1.ShowZoomControl = false;
            this.reportViewer1.Size = new System.Drawing.Size(323, 439);
            this.reportViewer1.TabIndex = 0;
            // 
            // BillRptReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 439);
            this.Controls.Add(this.reportViewer1);
            this.Location = new System.Drawing.Point(100, 500);
            this.MaximumSize = new System.Drawing.Size(339, 478);
            this.Name = "BillRptReceipt";
            this.Text = "RptReceipt";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RptReceipt_FormClosed);
            this.Load += new System.EventHandler(this.RptReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sp_frm_get_SalesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sp_frm_get_Sales_Bill_ItemsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sp_frm_get_SalesBindingSource;
        private MobileProDataSet MobileProDataSet;
        private System.Windows.Forms.BindingSource sp_frm_get_Sales_Bill_ItemsBindingSource;
        private MobileProDataSetTableAdapters.sp_frm_get_SalesTableAdapter sp_frm_get_SalesTableAdapter;
        private MobileProDataSetTableAdapters.sp_frm_get_Sales_Bill_ItemsTableAdapter sp_frm_get_Sales_Bill_ItemsTableAdapter;
    }
}