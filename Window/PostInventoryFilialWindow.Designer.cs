namespace WMSOffice.Window
{
    partial class PostInventoryFilialWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PostInventoryFilialWindow));
            this.tsInventory = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreatePeresort = new System.Windows.Forms.ToolStripButton();
            this.btnOverages = new System.Windows.Forms.ToolStripButton();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvInventories = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsInventories = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCreatePeresort = new System.Windows.Forms.ToolStripMenuItem();
            this.miOverage = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvCorrectionDocs = new System.Windows.Forms.DataGridView();
            this.документаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.типDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Подтип = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.стDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.описаниеСтатусаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.документаВJDEDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.созданDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сотрудникDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsFpGetCorrectionDocuments = new System.Windows.Forms.BindingSource(this.components);
            this.inventory = new WMSOffice.Data.Inventory();
            this.tsCorrectionsDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefreshCorrectionDocs = new System.Windows.Forms.ToolStripButton();
            this.tssAfterCorrectionsRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditInvDoc = new System.Windows.Forms.ToolStripButton();
            this.btnShowInfo = new System.Windows.Forms.ToolStripButton();
            this.btnFiles = new System.Windows.Forms.ToolStripButton();
            this.tssAfterFiles = new System.Windows.Forms.ToolStripSeparator();
            this.btnRunDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCommitDoc = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRunDoc = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintInvoice = new System.Windows.Forms.ToolStripButton();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.taFpGetCorrection_Documents = new WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_DocumentsTableAdapter();
            this.tsInventory.SuspendLayout();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            this.cmsInventories.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrectionDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).BeginInit();
            this.tsCorrectionsDocs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsInventory
            // 
            this.tsInventory.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsInventory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.btnCreatePeresort,
            this.btnOverages,
            this.btnExport});
            this.tsInventory.Location = new System.Drawing.Point(0, 40);
            this.tsInventory.Name = "tsInventory";
            this.tsInventory.Size = new System.Drawing.Size(1011, 55);
            this.tsInventory.TabIndex = 1;
            this.tsInventory.Text = "Панель инструментов инвентаризаций";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.ToolTipText = "Обновить список инвентаризаций";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreatePeresort
            // 
            this.btnCreatePeresort.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnCreatePeresort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreatePeresort.Name = "btnCreatePeresort";
            this.btnCreatePeresort.Size = new System.Drawing.Size(112, 52);
            this.btnCreatePeresort.Text = "Пересорт";
            this.btnCreatePeresort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreatePeresort.Click += new System.EventHandler(this.CreatePeresort_Click);
            // 
            // btnOverages
            // 
            this.btnOverages.Image = global::WMSOffice.Properties.Resources.box3;
            this.btnOverages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOverages.Name = "btnOverages";
            this.btnOverages.Size = new System.Drawing.Size(139, 52);
            this.btnOverages.Text = "Приходование\nизлишков";
            this.btnOverages.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOverages.Click += new System.EventHandler(this.btnOverages_Click);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(142, 52);
            this.btnExport.Text = "Экспорт в Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 95);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvInventories);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.dgvCorrectionDocs);
            this.spcMain.Panel2.Controls.Add(this.tsCorrectionsDocs);
            this.spcMain.Size = new System.Drawing.Size(1011, 418);
            this.spcMain.SplitterDistance = 227;
            this.spcMain.TabIndex = 2;
            // 
            // dgvInventories
            // 
            this.dgvInventories.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.dgvInventories.ContextMenuStrip = this.cmsInventories;
            this.dgvInventories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInventories.LargeAmountOfData = false;
            this.dgvInventories.Location = new System.Drawing.Point(0, 0);
            this.dgvInventories.Name = "dgvInventories";
            this.dgvInventories.RowHeadersVisible = false;
            this.dgvInventories.Size = new System.Drawing.Size(1011, 227);
            this.dgvInventories.TabIndex = 0;
            this.dgvInventories.UserID = ((long)(0));
            // 
            // cmsInventories
            // 
            this.cmsInventories.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreatePeresort,
            this.miOverage});
            this.cmsInventories.Name = "cmsInventories";
            this.cmsInventories.Size = new System.Drawing.Size(214, 48);
            // 
            // miCreatePeresort
            // 
            this.miCreatePeresort.Image = global::WMSOffice.Properties.Resources.assign;
            this.miCreatePeresort.Name = "miCreatePeresort";
            this.miCreatePeresort.Size = new System.Drawing.Size(213, 22);
            this.miCreatePeresort.Text = "Потоварный пересорт";
            this.miCreatePeresort.Click += new System.EventHandler(this.CreatePeresort_Click);
            // 
            // miOverage
            // 
            this.miOverage.Image = global::WMSOffice.Properties.Resources.box3;
            this.miOverage.Name = "miOverage";
            this.miOverage.Size = new System.Drawing.Size(213, 22);
            this.miOverage.Text = "Приходование излишков";
            this.miOverage.Click += new System.EventHandler(this.btnOverages_Click);
            // 
            // dgvCorrectionDocs
            // 
            this.dgvCorrectionDocs.AllowUserToAddRows = false;
            this.dgvCorrectionDocs.AllowUserToDeleteRows = false;
            this.dgvCorrectionDocs.AllowUserToResizeRows = false;
            this.dgvCorrectionDocs.AutoGenerateColumns = false;
            this.dgvCorrectionDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorrectionDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.документаDataGridViewTextBoxColumn,
            this.типDataGridViewTextBoxColumn,
            this.Подтип,
            this.стDataGridViewTextBoxColumn,
            this.описаниеСтатусаDataGridViewTextBoxColumn,
            this.документаВJDEDataGridViewTextBoxColumn,
            this.созданDataGridViewTextBoxColumn,
            this.сотрудникDataGridViewTextBoxColumn});
            this.dgvCorrectionDocs.DataSource = this.bsFpGetCorrectionDocuments;
            this.dgvCorrectionDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCorrectionDocs.Location = new System.Drawing.Point(0, 39);
            this.dgvCorrectionDocs.MultiSelect = false;
            this.dgvCorrectionDocs.Name = "dgvCorrectionDocs";
            this.dgvCorrectionDocs.ReadOnly = true;
            this.dgvCorrectionDocs.RowHeadersVisible = false;
            this.dgvCorrectionDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCorrectionDocs.Size = new System.Drawing.Size(1011, 148);
            this.dgvCorrectionDocs.TabIndex = 1;
            this.dgvCorrectionDocs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgvCorrectionDocs_MouseDoubleClick);
            this.dgvCorrectionDocs.SelectionChanged += new System.EventHandler(this.dgvCorrectionDocs_SelectionChanged);
            // 
            // документаDataGridViewTextBoxColumn
            // 
            this.документаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.документаDataGridViewTextBoxColumn.DataPropertyName = "№ документа";
            this.документаDataGridViewTextBoxColumn.HeaderText = "№ документа";
            this.документаDataGridViewTextBoxColumn.Name = "документаDataGridViewTextBoxColumn";
            this.документаDataGridViewTextBoxColumn.ReadOnly = true;
            this.документаDataGridViewTextBoxColumn.Width = 92;
            // 
            // типDataGridViewTextBoxColumn
            // 
            this.типDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.типDataGridViewTextBoxColumn.DataPropertyName = "Тип";
            this.типDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.типDataGridViewTextBoxColumn.Name = "типDataGridViewTextBoxColumn";
            this.типDataGridViewTextBoxColumn.ReadOnly = true;
            this.типDataGridViewTextBoxColumn.Width = 51;
            // 
            // Подтип
            // 
            this.Подтип.DataPropertyName = "Подтип";
            this.Подтип.HeaderText = "Подтип";
            this.Подтип.Name = "Подтип";
            this.Подтип.ReadOnly = true;
            // 
            // стDataGridViewTextBoxColumn
            // 
            this.стDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.стDataGridViewTextBoxColumn.DataPropertyName = "Ст_";
            this.стDataGridViewTextBoxColumn.HeaderText = "Ст.";
            this.стDataGridViewTextBoxColumn.Name = "стDataGridViewTextBoxColumn";
            this.стDataGridViewTextBoxColumn.ReadOnly = true;
            this.стDataGridViewTextBoxColumn.Width = 47;
            // 
            // описаниеСтатусаDataGridViewTextBoxColumn
            // 
            this.описаниеСтатусаDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.описаниеСтатусаDataGridViewTextBoxColumn.DataPropertyName = "Описание статуса";
            this.описаниеСтатусаDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.описаниеСтатусаDataGridViewTextBoxColumn.Name = "описаниеСтатусаDataGridViewTextBoxColumn";
            this.описаниеСтатусаDataGridViewTextBoxColumn.ReadOnly = true;
            this.описаниеСтатусаDataGridViewTextBoxColumn.Width = 66;
            // 
            // документаВJDEDataGridViewTextBoxColumn
            // 
            this.документаВJDEDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.документаВJDEDataGridViewTextBoxColumn.DataPropertyName = "№ документа в JDE";
            this.документаВJDEDataGridViewTextBoxColumn.HeaderText = "№ документа в JDE";
            this.документаВJDEDataGridViewTextBoxColumn.Name = "документаВJDEDataGridViewTextBoxColumn";
            this.документаВJDEDataGridViewTextBoxColumn.ReadOnly = true;
            this.документаВJDEDataGridViewTextBoxColumn.Width = 103;
            // 
            // созданDataGridViewTextBoxColumn
            // 
            this.созданDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.созданDataGridViewTextBoxColumn.DataPropertyName = "Создан";
            this.созданDataGridViewTextBoxColumn.HeaderText = "Создан";
            this.созданDataGridViewTextBoxColumn.Name = "созданDataGridViewTextBoxColumn";
            this.созданDataGridViewTextBoxColumn.ReadOnly = true;
            this.созданDataGridViewTextBoxColumn.Width = 69;
            // 
            // сотрудникDataGridViewTextBoxColumn
            // 
            this.сотрудникDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.сотрудникDataGridViewTextBoxColumn.DataPropertyName = "Сотрудник";
            this.сотрудникDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.сотрудникDataGridViewTextBoxColumn.Name = "сотрудникDataGridViewTextBoxColumn";
            this.сотрудникDataGridViewTextBoxColumn.ReadOnly = true;
            this.сотрудникDataGridViewTextBoxColumn.Width = 85;
            // 
            // bsFpGetCorrectionDocuments
            // 
            this.bsFpGetCorrectionDocuments.DataMember = "FP_Get_Correction_Documents";
            this.bsFpGetCorrectionDocuments.DataSource = this.inventory;
            // 
            // inventory
            // 
            this.inventory.DataSetName = "Inventory";
            this.inventory.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsCorrectionsDocs
            // 
            this.tsCorrectionsDocs.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsCorrectionsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefreshCorrectionDocs,
            this.tssAfterCorrectionsRefresh,
            this.btnEditInvDoc,
            this.btnShowInfo,
            this.btnFiles,
            this.tssAfterFiles,
            this.btnRunDoc,
            this.btnCommitDoc,
            this.tssAfterRunDoc,
            this.btnPrintInvoice,
            this.lblPrinter,
            this.cmbPrinters});
            this.tsCorrectionsDocs.Location = new System.Drawing.Point(0, 0);
            this.tsCorrectionsDocs.Name = "tsCorrectionsDocs";
            this.tsCorrectionsDocs.Size = new System.Drawing.Size(1011, 39);
            this.tsCorrectionsDocs.TabIndex = 0;
            this.tsCorrectionsDocs.Text = "toolStrip1";
            // 
            // btnRefreshCorrectionDocs
            // 
            this.btnRefreshCorrectionDocs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefreshCorrectionDocs.Image = global::WMSOffice.Properties.Resources.Refresh2;
            this.btnRefreshCorrectionDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefreshCorrectionDocs.Name = "btnRefreshCorrectionDocs";
            this.btnRefreshCorrectionDocs.Size = new System.Drawing.Size(36, 36);
            this.btnRefreshCorrectionDocs.Text = "toolStripButton1";
            this.btnRefreshCorrectionDocs.ToolTipText = "Обновить список документов по выбранной инвентаризации";
            this.btnRefreshCorrectionDocs.Click += new System.EventHandler(this.btnRefreshCorrectionDocs_Click);
            // 
            // tssAfterCorrectionsRefresh
            // 
            this.tssAfterCorrectionsRefresh.Name = "tssAfterCorrectionsRefresh";
            this.tssAfterCorrectionsRefresh.Size = new System.Drawing.Size(6, 39);
            // 
            // btnEditInvDoc
            // 
            this.btnEditInvDoc.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditInvDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditInvDoc.Name = "btnEditInvDoc";
            this.btnEditInvDoc.Size = new System.Drawing.Size(123, 36);
            this.btnEditInvDoc.Text = "Редактировать\nдокумент";
            this.btnEditInvDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditInvDoc.Click += new System.EventHandler(this.btnEditInvDoc_Click);
            // 
            // btnShowInfo
            // 
            this.btnShowInfo.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnShowInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowInfo.Name = "btnShowInfo";
            this.btnShowInfo.Size = new System.Drawing.Size(130, 36);
            this.btnShowInfo.Text = "Открыть детали";
            this.btnShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowInfo.Click += new System.EventHandler(this.btnShowInfo_Click);
            // 
            // btnFiles
            // 
            this.btnFiles.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.btnFiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(134, 36);
            this.btnFiles.Text = "Прикрепленные\nфайлы";
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // tssAfterFiles
            // 
            this.tssAfterFiles.Name = "tssAfterFiles";
            this.tssAfterFiles.Size = new System.Drawing.Size(6, 39);
            // 
            // btnRunDoc
            // 
            this.btnRunDoc.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnRunDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunDoc.Name = "btnRunDoc";
            this.btnRunDoc.Size = new System.Drawing.Size(105, 36);
            this.btnRunDoc.Text = "Выполнить\nдокумент";
            this.btnRunDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRunDoc.Click += new System.EventHandler(this.btnRunDoc_Click);
            // 
            // btnCommitDoc
            // 
            this.btnCommitDoc.Image = global::WMSOffice.Properties.Resources.icon_staff_pick;
            this.btnCommitDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCommitDoc.Name = "btnCommitDoc";
            this.btnCommitDoc.Size = new System.Drawing.Size(98, 36);
            this.btnCommitDoc.Text = "Утвердить\nдокумент";
            this.btnCommitDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCommitDoc.Click += new System.EventHandler(this.btnCommitDoc_Click);
            // 
            // tssAfterRunDoc
            // 
            this.tssAfterRunDoc.Name = "tssAfterRunDoc";
            this.tssAfterRunDoc.Size = new System.Drawing.Size(6, 39);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(166, 36);
            this.btnPrintInvoice.Text = "Печать межскладской\nнакладной";
            this.btnPrintInvoice.ToolTipText = "Напечатать межскладскую накладную по выбранному приходованию излишков";
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoices_Click);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(76, 36);
            this.lblPrinter.Text = "      Принтер:";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 23);
            // 
            // taFpGetCorrection_Documents
            // 
            this.taFpGetCorrection_Documents.ClearBeforeFill = true;
            // 
            // PostInventoryFilialWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 513);
            this.Controls.Add(this.spcMain);
            this.Controls.Add(this.tsInventory);
            this.Name = "PostInventoryFilialWindow";
            this.Text = "Постинвентаризация";
            this.Load += new System.EventHandler(this.PostInventoryFilialWindow_Load);
            this.Controls.SetChildIndex(this.tsInventory, 0);
            this.Controls.SetChildIndex(this.spcMain, 0);
            this.tsInventory.ResumeLayout(false);
            this.tsInventory.PerformLayout();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            this.spcMain.ResumeLayout(false);
            this.cmsInventories.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorrectionDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsFpGetCorrectionDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventory)).EndInit();
            this.tsCorrectionsDocs.ResumeLayout(false);
            this.tsCorrectionsDocs.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsInventory;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.SplitContainer spcMain;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvInventories;
        private System.Windows.Forms.ToolStripButton btnCreatePeresort;
        private System.Windows.Forms.ContextMenuStrip cmsInventories;
        private System.Windows.Forms.ToolStripMenuItem miCreatePeresort;
        private System.Windows.Forms.ToolStrip tsCorrectionsDocs;
        private System.Windows.Forms.DataGridView dgvCorrectionDocs;
        private System.Windows.Forms.BindingSource bsFpGetCorrectionDocuments;
        private WMSOffice.Data.Inventory inventory;
        private WMSOffice.Data.InventoryTableAdapters.FP_Get_Correction_DocumentsTableAdapter taFpGetCorrection_Documents;
        private System.Windows.Forms.ToolStripButton btnRefreshCorrectionDocs;
        private System.Windows.Forms.ToolStripSeparator tssAfterCorrectionsRefresh;
        private System.Windows.Forms.ToolStripButton btnEditInvDoc;
        private System.Windows.Forms.ToolStripButton btnOverages;
        private System.Windows.Forms.ToolStripMenuItem miOverage;
        private System.Windows.Forms.ToolStripButton btnShowInfo;
        private System.Windows.Forms.ToolStripSeparator tssAfterRunDoc;
        private System.Windows.Forms.ToolStripButton btnPrintInvoice;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnFiles;
        private System.Windows.Forms.ToolStripSeparator tssAfterFiles;
        private System.Windows.Forms.ToolStripButton btnRunDoc;
        private System.Windows.Forms.ToolStripButton btnCommitDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn документаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn типDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Подтип;
        private System.Windows.Forms.DataGridViewTextBoxColumn стDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn описаниеСтатусаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn документаВJDEDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn созданDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сотрудникDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnExport;
    }
}