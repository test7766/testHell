namespace WMSOffice.Window
{
    partial class PrePaymentDocsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshData = new System.Windows.Forms.ToolStripButton();
            this.sbFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPrintDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbConfirmDebtorSign = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsOperations = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPreviewInvoiceReport = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewComplaintsCalculationsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMainMenu.SuspendLayout();
            this.cmsOperations.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshData,
            this.sbFilter,
            this.toolStripSeparator1,
            this.sbPrintDocs,
            this.toolStripSeparator2,
            this.sbConfirmDebtorSign,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator3,
            this.sbExportToExcel});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1055, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshData
            // 
            this.sbRefreshData.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshData.Name = "sbRefreshData";
            this.sbRefreshData.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshData.Text = "Обновить\n(F5)";
            this.sbRefreshData.Click += new System.EventHandler(this.sbRefreshData_Click);
            // 
            // sbFilter
            // 
            this.sbFilter.Image = global::WMSOffice.Properties.Resources.find;
            this.sbFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFilter.Name = "sbFilter";
            this.sbFilter.Size = new System.Drawing.Size(94, 52);
            this.sbFilter.Text = "Поиск\n(F4)";
            this.sbFilter.Click += new System.EventHandler(this.sbFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPrintDocs
            // 
            this.sbPrintDocs.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintDocs.Name = "sbPrintDocs";
            this.sbPrintDocs.Size = new System.Drawing.Size(123, 52);
            this.sbPrintDocs.Text = "Напечатать\nвыбранные\nдокументы";
            this.sbPrintDocs.Click += new System.EventHandler(this.sbPrintDocs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // sbConfirmDebtorSign
            // 
            this.sbConfirmDebtorSign.Image = global::WMSOffice.Properties.Resources.ok;
            this.sbConfirmDebtorSign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbConfirmDebtorSign.Name = "sbConfirmDebtorSign";
            this.sbConfirmDebtorSign.Size = new System.Drawing.Size(129, 52);
            this.sbConfirmDebtorSign.Text = "Подтвердить\nподписание\nклиентом";
            this.sbConfirmDebtorSign.Click += new System.EventHandler(this.sbConfirmDebtorSign_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.DropDownWidth = 200;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(58, 52);
            this.toolStripLabel1.Text = "Принтер:";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbExportToExcel
            // 
            this.sbExportToExcel.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.sbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportToExcel.Name = "sbExportToExcel";
            this.sbExportToExcel.Size = new System.Drawing.Size(121, 52);
            this.sbExportToExcel.Text = "Экспорт РК\nв Excel";
            this.sbExportToExcel.Click += new System.EventHandler(this.sbExportToExcel_Click);
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.ContextMenuStrip = this.cmsOperations;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 95);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(1055, 428);
            this.xdgvDocs.TabIndex = 2;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // cmsOperations
            // 
            this.cmsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPreviewInvoiceReport,
            this.miPreviewComplaintsCalculationsReport});
            this.cmsOperations.Name = "cmsOperations";
            this.cmsOperations.Size = new System.Drawing.Size(235, 48);
            // 
            // miPreviewInvoiceReport
            // 
            this.miPreviewInvoiceReport.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreviewInvoiceReport.Name = "miPreviewInvoiceReport";
            this.miPreviewInvoiceReport.Size = new System.Drawing.Size(234, 22);
            this.miPreviewInvoiceReport.Text = "Просмотр предоплатной НН";
            this.miPreviewInvoiceReport.Click += new System.EventHandler(this.miPreviewInvoiceReport_Click);
            // 
            // miPreviewComplaintsCalculationsReport
            // 
            this.miPreviewComplaintsCalculationsReport.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreviewComplaintsCalculationsReport.Name = "miPreviewComplaintsCalculationsReport";
            this.miPreviewComplaintsCalculationsReport.Size = new System.Drawing.Size(234, 22);
            this.miPreviewComplaintsCalculationsReport.Text = "Просмотр предоплатной РК";
            this.miPreviewComplaintsCalculationsReport.Click += new System.EventHandler(this.miPreviewComplaintsCalculationsReport_Click);
            // 
            // PrePaymentDocsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 523);
            this.Controls.Add(this.xdgvDocs);
            this.Controls.Add(this.tsMainMenu);
            this.Name = "PrePaymentDocsWindow";
            this.Text = "PrePaymentDocsWindow";
            this.Load += new System.EventHandler(this.PrePaymentDocsWindow_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PrePaymentDocsWindow_FormClosed);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.xdgvDocs, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.cmsOperations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefreshData;
        private System.Windows.Forms.ToolStripButton sbFilter;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton sbPrintDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton sbConfirmDebtorSign;
        private System.Windows.Forms.ContextMenuStrip cmsOperations;
        private System.Windows.Forms.ToolStripMenuItem miPreviewInvoiceReport;
        private System.Windows.Forms.ToolStripMenuItem miPreviewComplaintsCalculationsReport;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sbExportToExcel;
    }
}