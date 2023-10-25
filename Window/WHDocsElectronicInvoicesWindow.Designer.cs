namespace WMSOffice.Window
{
    partial class WHDocsElectronicInvoicesWindow
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
            this.xdgvResult = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmContextOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPrintPreviewTaxInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintClientTaxInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewSellerTaxInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.sbSetSearchCriteria = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmContextOptions.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // xdgvResult
            // 
            this.xdgvResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvResult.ContextMenuStrip = this.cmContextOptions;
            this.xdgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvResult.LargeAmountOfData = false;
            this.xdgvResult.Location = new System.Drawing.Point(0, 0);
            this.xdgvResult.Name = "xdgvResult";
            this.xdgvResult.RowHeadersVisible = false;
            this.xdgvResult.Size = new System.Drawing.Size(1123, 471);
            this.xdgvResult.TabIndex = 2;
            this.xdgvResult.UserID = ((long)(0));
            // 
            // cmContextOptions
            // 
            this.cmContextOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.cmContextOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPrintPreviewTaxInvoice,
            this.miPrintClientTaxInvoices,
            this.toolStripSeparator1,
            this.miPreviewSellerTaxInvoice});
            this.cmContextOptions.Name = "cmContextOptions";
            this.cmContextOptions.Size = new System.Drawing.Size(375, 124);
            // 
            // miPrintPreviewTaxInvoice
            // 
            this.miPrintPreviewTaxInvoice.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPrintPreviewTaxInvoice.Name = "miPrintPreviewTaxInvoice";
            this.miPrintPreviewTaxInvoice.Size = new System.Drawing.Size(374, 38);
            this.miPrintPreviewTaxInvoice.Text = "Просмотр налоговой накладной для клиента";
            this.miPrintPreviewTaxInvoice.Click += new System.EventHandler(this.miPrintPreviewTaxInvoice_Click);
            // 
            // miPrintClientTaxInvoices
            // 
            this.miPrintClientTaxInvoices.Image = global::WMSOffice.Properties.Resources.document_print;
            this.miPrintClientTaxInvoices.Name = "miPrintClientTaxInvoices";
            this.miPrintClientTaxInvoices.Size = new System.Drawing.Size(374, 38);
            this.miPrintClientTaxInvoices.Text = "Пакетная печать налоговых накладных для клиента";
            this.miPrintClientTaxInvoices.Click += new System.EventHandler(this.miPrintClientTaxInvoices_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(371, 6);
            // 
            // miPreviewSellerTaxInvoice
            // 
            this.miPreviewSellerTaxInvoice.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.miPreviewSellerTaxInvoice.Name = "miPreviewSellerTaxInvoice";
            this.miPreviewSellerTaxInvoice.Size = new System.Drawing.Size(374, 38);
            this.miPreviewSellerTaxInvoice.Text = "Просмотр налоговой накладной для Оптимы";
            this.miPreviewSellerTaxInvoice.ToolTipText = "Только просмотр";
            this.miPreviewSellerTaxInvoice.Click += new System.EventHandler(this.miPreviewSellerTaxInvoice_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.xdgvResult);
            this.pnlMain.Location = new System.Drawing.Point(0, 98);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1123, 471);
            this.pnlMain.TabIndex = 2;
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.sbSetSearchCriteria,
            this.cmbPrinters,
            this.toolStripLabel1,
            this.toolStripSeparator2});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1123, 55);
            this.tsMainMenu.TabIndex = 3;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить\n(F5)";
            this.sbRefresh.ToolTipText = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // sbSetSearchCriteria
            // 
            this.sbSetSearchCriteria.Image = global::WMSOffice.Properties.Resources.find;
            this.sbSetSearchCriteria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSetSearchCriteria.Name = "sbSetSearchCriteria";
            this.sbSetSearchCriteria.Size = new System.Drawing.Size(153, 52);
            this.sbSetSearchCriteria.Text = "Настроить\nкритерии поиска\n(CTRL+F)";
            this.sbSetSearchCriteria.ToolTipText = "Настроить\nкритерии поиска";
            this.sbSetSearchCriteria.Click += new System.EventHandler(this.sbSetSearchCriteria_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // WHDocsElectronicInvoicesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 572);
            this.Controls.Add(this.tsMainMenu);
            this.Controls.Add(this.pnlMain);
            this.Name = "WHDocsElectronicInvoicesWindow";
            this.Text = "WHDocsElectronicInvoicesWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WHDocsElectronicInvoicesWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.cmContextOptions.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvResult;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripButton sbSetSearchCriteria;
        private System.Windows.Forms.ContextMenuStrip cmContextOptions;
        private System.Windows.Forms.ToolStripMenuItem miPrintPreviewTaxInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewSellerTaxInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPrintClientTaxInvoices;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}