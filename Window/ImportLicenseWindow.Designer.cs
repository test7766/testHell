namespace WMSOffice.Window
{
    partial class ImportLicenseWindow
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
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowItemDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRequestDocsFromPurchaseDepartment = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLinkItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddToLicense = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteFromLicense = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteFromUsage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.tbItem = new System.Windows.Forms.TextBox();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.tbVendor = new System.Windows.Forms.TextBox();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.chbAdvancedSearchModes = new WMSOffice.Controls.CheckedComboBox();
            this.lblAdvancedSearchModes = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator6,
            this.btnShowItemDocs,
            this.toolStripSeparator1,
            this.btnRequestDocsFromPurchaseDepartment,
            this.toolStripSeparator2,
            this.btnLinkItem,
            this.toolStripSeparator4,
            this.btnAddToLicense,
            this.toolStripSeparator3,
            this.btnDeleteFromLicense,
            this.toolStripSeparator5,
            this.btnDeleteFromUsage,
            this.toolStripSeparator7,
            this.btnExportToExcel});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1024, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(113, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowItemDocs
            // 
            this.btnShowItemDocs.Image = global::WMSOffice.Properties.Resources.preview;
            this.btnShowItemDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowItemDocs.Name = "btnShowItemDocs";
            this.btnShowItemDocs.Size = new System.Drawing.Size(124, 52);
            this.btnShowItemDocs.Text = "Просмотр\nдокументов";
            this.btnShowItemDocs.Click += new System.EventHandler(this.btnShowItemDocs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRequestDocsFromPurchaseDepartment
            // 
            this.btnRequestDocsFromPurchaseDepartment.Image = global::WMSOffice.Properties.Resources.document_certificate;
            this.btnRequestDocsFromPurchaseDepartment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRequestDocsFromPurchaseDepartment.Name = "btnRequestDocsFromPurchaseDepartment";
            this.btnRequestDocsFromPurchaseDepartment.Size = new System.Drawing.Size(129, 52);
            this.btnRequestDocsFromPurchaseDepartment.Text = "Запросить\nдокументы у\nпоставщика";
            this.btnRequestDocsFromPurchaseDepartment.Click += new System.EventHandler(this.btnRequestDocsFromPurchaseDepartment_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnLinkItem
            // 
            this.btnLinkItem.Image = global::WMSOffice.Properties.Resources.link;
            this.btnLinkItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLinkItem.Name = "btnLinkItem";
            this.btnLinkItem.Size = new System.Drawing.Size(109, 52);
            this.btnLinkItem.Text = "Связать\nкарточку";
            this.btnLinkItem.Visible = false;
            this.btnLinkItem.Click += new System.EventHandler(this.btnLinkItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddToLicense
            // 
            this.btnAddToLicense.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnAddToLicense.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddToLicense.Name = "btnAddToLicense";
            this.btnAddToLicense.Size = new System.Drawing.Size(120, 52);
            this.btnAddToLicense.Text = "Добавить в\nЛицензию";
            this.btnAddToLicense.Click += new System.EventHandler(this.btnAddToLicense_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDeleteFromLicense
            // 
            this.btnDeleteFromLicense.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnDeleteFromLicense.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteFromLicense.Name = "btnDeleteFromLicense";
            this.btnDeleteFromLicense.Size = new System.Drawing.Size(137, 52);
            this.btnDeleteFromLicense.Text = "Исключить из\nЛицензии";
            this.btnDeleteFromLicense.Click += new System.EventHandler(this.btnDeleteFromLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDeleteFromUsage
            // 
            this.btnDeleteFromUsage.Image = global::WMSOffice.Properties.Resources.recycle_bin;
            this.btnDeleteFromUsage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteFromUsage.Name = "btnDeleteFromUsage";
            this.btnDeleteFromUsage.Size = new System.Drawing.Size(139, 52);
            this.btnDeleteFromUsage.Text = "Сделать\nнеактуальным";
            this.btnDeleteFromUsage.Click += new System.EventHandler(this.btnDeleteFromUsage_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
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
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlContent);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 95);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1024, 293);
            this.pnlMain.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvDocs);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1024, 198);
            this.pnlContent.TabIndex = 3;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(1024, 198);
            this.xdgvDocs.TabIndex = 1;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.lblAdvancedSearchModes);
            this.pnlFilter.Controls.Add(this.chbAdvancedSearchModes);
            this.pnlFilter.Controls.Add(this.tbItem);
            this.pnlFilter.Controls.Add(this.stbItem);
            this.pnlFilter.Controls.Add(this.lblItem);
            this.pnlFilter.Controls.Add(this.tbVendor);
            this.pnlFilter.Controls.Add(this.stbVendor);
            this.pnlFilter.Controls.Add(this.lblVendor);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 0);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1024, 95);
            this.pnlFilter.TabIndex = 2;
            // 
            // tbItem
            // 
            this.tbItem.BackColor = System.Drawing.SystemColors.Window;
            this.tbItem.Location = new System.Drawing.Point(261, 38);
            this.tbItem.Name = "tbItem";
            this.tbItem.ReadOnly = true;
            this.tbItem.Size = new System.Drawing.Size(748, 20);
            this.tbItem.TabIndex = 5;
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(111, 38);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(144, 20);
            this.stbItem.TabIndex = 4;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Location = new System.Drawing.Point(13, 42);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(41, 13);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Товар:";
            // 
            // tbVendor
            // 
            this.tbVendor.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendor.Location = new System.Drawing.Point(261, 9);
            this.tbVendor.Name = "tbVendor";
            this.tbVendor.ReadOnly = true;
            this.tbVendor.Size = new System.Drawing.Size(748, 20);
            this.tbVendor.TabIndex = 2;
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(111, 9);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(144, 20);
            this.stbVendor.TabIndex = 1;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(13, 13);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 0;
            this.lblVendor.Text = "Поставщик:";
            // 
            // chbAdvancedSearchModes
            // 
            this.chbAdvancedSearchModes.CheckOnClick = true;
            this.chbAdvancedSearchModes.DisplayMember = "Name";
            this.chbAdvancedSearchModes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chbAdvancedSearchModes.DropDownHeight = 1;
            this.chbAdvancedSearchModes.DropDownWidth = 250;
            this.chbAdvancedSearchModes.FormattingEnabled = true;
            this.chbAdvancedSearchModes.IntegralHeight = false;
            this.chbAdvancedSearchModes.Location = new System.Drawing.Point(111, 67);
            this.chbAdvancedSearchModes.Name = "chbAdvancedSearchModes";
            this.chbAdvancedSearchModes.Size = new System.Drawing.Size(898, 21);
            this.chbAdvancedSearchModes.TabIndex = 7;
            this.chbAdvancedSearchModes.ValueSeparator = ", ";
            // 
            // lblAdvancedSearchModes
            // 
            this.lblAdvancedSearchModes.AutoSize = true;
            this.lblAdvancedSearchModes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAdvancedSearchModes.ForeColor = System.Drawing.Color.Brown;
            this.lblAdvancedSearchModes.Location = new System.Drawing.Point(13, 71);
            this.lblAdvancedSearchModes.Name = "lblAdvancedSearchModes";
            this.lblAdvancedSearchModes.Size = new System.Drawing.Size(90, 13);
            this.lblAdvancedSearchModes.TabIndex = 6;
            this.lblAdvancedSearchModes.Text = "Дополнительно:";
            // 
            // ImportLicenseWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 388);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.Name = "ImportLicenseWindow";
            this.Text = "ImportLicenseWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMain, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlContent.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.TextBox tbItem;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.TextBox tbVendor;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.ToolStripButton btnShowItemDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnRequestDocsFromPurchaseDepartment;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnLinkItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnAddToLicense;
        private System.Windows.Forms.ToolStripButton btnDeleteFromLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnDeleteFromUsage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.Label lblAdvancedSearchModes;
        private WMSOffice.Controls.CheckedComboBox chbAdvancedSearchModes;
    }
}