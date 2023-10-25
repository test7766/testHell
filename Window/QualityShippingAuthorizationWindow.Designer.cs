namespace WMSOffice.Window
{
    partial class QualityShippingAuthorizationWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintWorksheet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintRegistry = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.xdgvWorksheets = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlStatusesFilter = new System.Windows.Forms.Panel();
            this.gbStatuses = new System.Windows.Forms.GroupBox();
            this.chbStatusInWork = new System.Windows.Forms.CheckBox();
            this.chbStatusNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbStatusNew = new System.Windows.Forms.CheckBox();
            this.chbStatusAccepted = new System.Windows.Forms.CheckBox();
            this.btnEditWorksheet = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsMain.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlStatusesFilter.SuspendLayout();
            this.gbStatuses.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.btnSearch,
            this.toolStripSeparator1,
            this.btnEditWorksheet,
            this.toolStripSeparator2,
            this.btnPrintWorksheet,
            this.toolStripSeparator5,
            this.btnPrintRegistry,
            this.toolStripSeparator3,
            this.btnExportToExcel,
            this.cmbPrinters,
            this.lblPrinters,
            this.toolStripSeparator4});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1158, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::WMSOffice.Properties.Resources.find;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 52);
            this.btnSearch.Text = "Поиск";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintWorksheet
            // 
            this.btnPrintWorksheet.Image = global::WMSOffice.Properties.Resources.preview;
            this.btnPrintWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintWorksheet.Name = "btnPrintWorksheet";
            this.btnPrintWorksheet.Size = new System.Drawing.Size(100, 52);
            this.btnPrintWorksheet.Text = "Печать\nАнкеты";
            this.btnPrintWorksheet.Click += new System.EventHandler(this.btnPrintWorksheet_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintRegistry
            // 
            this.btnPrintRegistry.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintRegistry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintRegistry.Name = "btnPrintRegistry";
            this.btnPrintRegistry.Size = new System.Drawing.Size(160, 52);
            this.btnPrintRegistry.Text = "Печать Реестра\nконтроля условий";
            this.btnPrintRegistry.Click += new System.EventHandler(this.btnPrintRegistry_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(104, 52);
            this.btnExportToExcel.Text = "Экспорт\nв Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            this.cmbPrinters.Visible = false;
            // 
            // lblPrinters
            // 
            this.lblPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(58, 52);
            this.lblPrinters.Text = "Принтер:";
            this.lblPrinters.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator4.Visible = false;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.xdgvWorksheets);
            this.pnlMainContent.Controls.Add(this.pnlStatusesFilter);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 95);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1158, 321);
            this.pnlMainContent.TabIndex = 2;
            // 
            // xdgvWorksheets
            // 
            this.xdgvWorksheets.AllowSort = true;
            this.xdgvWorksheets.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvWorksheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvWorksheets.LargeAmountOfData = false;
            this.xdgvWorksheets.Location = new System.Drawing.Point(0, 60);
            this.xdgvWorksheets.Name = "xdgvWorksheets";
            this.xdgvWorksheets.RowHeadersVisible = false;
            this.xdgvWorksheets.Size = new System.Drawing.Size(1158, 261);
            this.xdgvWorksheets.TabIndex = 1;
            this.xdgvWorksheets.UserID = ((long)(0));
            // 
            // pnlStatusesFilter
            // 
            this.pnlStatusesFilter.Controls.Add(this.gbStatuses);
            this.pnlStatusesFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatusesFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlStatusesFilter.Name = "pnlStatusesFilter";
            this.pnlStatusesFilter.Size = new System.Drawing.Size(1158, 60);
            this.pnlStatusesFilter.TabIndex = 0;
            // 
            // gbStatuses
            // 
            this.gbStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatuses.Controls.Add(this.chbStatusInWork);
            this.gbStatuses.Controls.Add(this.chbStatusNotAccepted);
            this.gbStatuses.Controls.Add(this.chbStatusNew);
            this.gbStatuses.Controls.Add(this.chbStatusAccepted);
            this.gbStatuses.Location = new System.Drawing.Point(3, 3);
            this.gbStatuses.Name = "gbStatuses";
            this.gbStatuses.Size = new System.Drawing.Size(1152, 54);
            this.gbStatuses.TabIndex = 62;
            this.gbStatuses.TabStop = false;
            this.gbStatuses.Text = "Статусы отображаемых анкет";
            // 
            // chbStatusInWork
            // 
            this.chbStatusInWork.AutoSize = true;
            this.chbStatusInWork.Location = new System.Drawing.Point(107, 25);
            this.chbStatusInWork.Name = "chbStatusInWork";
            this.chbStatusInWork.Size = new System.Drawing.Size(71, 17);
            this.chbStatusInWork.TabIndex = 30;
            this.chbStatusInWork.Tag = "2";
            this.chbStatusInWork.Text = "В работе";
            this.chbStatusInWork.UseVisualStyleBackColor = true;
            this.chbStatusInWork.CheckedChanged += new System.EventHandler(this.chbWorksheetStatuses_CheckedChanged);
            // 
            // chbStatusNotAccepted
            // 
            this.chbStatusNotAccepted.AutoSize = true;
            this.chbStatusNotAccepted.Location = new System.Drawing.Point(378, 25);
            this.chbStatusNotAccepted.Name = "chbStatusNotAccepted";
            this.chbStatusNotAccepted.Size = new System.Drawing.Size(91, 17);
            this.chbStatusNotAccepted.TabIndex = 60;
            this.chbStatusNotAccepted.Tag = "4";
            this.chbStatusNotAccepted.Text = "Не пройдена";
            this.chbStatusNotAccepted.UseVisualStyleBackColor = true;
            this.chbStatusNotAccepted.CheckedChanged += new System.EventHandler(this.chbWorksheetStatuses_CheckedChanged);
            // 
            // chbStatusNew
            // 
            this.chbStatusNew.AutoSize = true;
            this.chbStatusNew.Location = new System.Drawing.Point(5, 25);
            this.chbStatusNew.Name = "chbStatusNew";
            this.chbStatusNew.Size = new System.Drawing.Size(58, 17);
            this.chbStatusNew.TabIndex = 20;
            this.chbStatusNew.Tag = "1";
            this.chbStatusNew.Text = "Новая";
            this.chbStatusNew.UseVisualStyleBackColor = true;
            this.chbStatusNew.CheckedChanged += new System.EventHandler(this.chbWorksheetStatuses_CheckedChanged);
            // 
            // chbStatusAccepted
            // 
            this.chbStatusAccepted.AutoSize = true;
            this.chbStatusAccepted.Location = new System.Drawing.Point(216, 25);
            this.chbStatusAccepted.Name = "chbStatusAccepted";
            this.chbStatusAccepted.Size = new System.Drawing.Size(122, 17);
            this.chbStatusAccepted.TabIndex = 40;
            this.chbStatusAccepted.Tag = "3";
            this.chbStatusAccepted.Text = "Пройдена успешно";
            this.chbStatusAccepted.UseVisualStyleBackColor = true;
            this.chbStatusAccepted.CheckedChanged += new System.EventHandler(this.chbWorksheetStatuses_CheckedChanged);
            // 
            // btnEditWorksheet
            // 
            this.btnEditWorksheet.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditWorksheet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditWorksheet.Name = "btnEditWorksheet";
            this.btnEditWorksheet.Size = new System.Drawing.Size(153, 52);
            this.btnEditWorksheet.Text = "Редактор\nАнкеты";
            this.btnEditWorksheet.Click += new System.EventHandler(this.btnEditWorksheet_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // QualityShippingAuthorizationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 416);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.tsMain);
            this.Name = "QualityShippingAuthorizationWindow";
            this.Text = "QualityShippingAuthorizationWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMainContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlStatusesFilter.ResumeLayout(false);
            this.gbStatuses.ResumeLayout(false);
            this.gbStatuses.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripButton btnSearch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrintWorksheet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnPrintRegistry;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlStatusesFilter;
        private System.Windows.Forms.GroupBox gbStatuses;
        private System.Windows.Forms.CheckBox chbStatusInWork;
        private System.Windows.Forms.CheckBox chbStatusNotAccepted;
        private System.Windows.Forms.CheckBox chbStatusNew;
        private System.Windows.Forms.CheckBox chbStatusAccepted;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvWorksheets;
        private System.Windows.Forms.ToolStripButton btnEditWorksheet;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}