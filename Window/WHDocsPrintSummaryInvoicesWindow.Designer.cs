namespace WMSOffice.Window
{
    partial class WHDocsPrintSummaryInvoicesWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMainStripForDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintPaketDocs = new System.Windows.Forms.ToolStripButton();
            this.btnExportRegisterToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.cbPrintedFilter = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblCount = new System.Windows.Forms.ToolStripLabel();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.docNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Peron_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debitorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSPrintedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExportRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExportGroupedRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintPaketDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPrintInvoiceForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPrintInvoiceForOptima = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewClientInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewOptimaInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.bsPIFindNaklSummary = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.taPI_FindNaklSummary = new WMSOffice.Data.WHTableAdapters.PI_FindNaklSummaryTableAdapter();
            this.tsMainStripForDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.cmsContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsPIFindNaklSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainStripForDocs
            // 
            this.tsMainStripForDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainStripForDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator2,
            this.btnPrintPaketDocs,
            this.btnExportRegisterToExcel,
            this.btnFind,
            this.cbPrintedFilter,
            this.toolStripSeparator3,
            this.lblPrinter,
            this.cbPrinters,
            this.lblCount});
            this.tsMainStripForDocs.Location = new System.Drawing.Point(0, 40);
            this.tsMainStripForDocs.Name = "tsMainStripForDocs";
            this.tsMainStripForDocs.Size = new System.Drawing.Size(1093, 55);
            this.tsMainStripForDocs.TabIndex = 7;
            this.tsMainStripForDocs.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список сводных налоговых накладных";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintPaketDocs
            // 
            this.btnPrintPaketDocs.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintPaketDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPaketDocs.Name = "btnPrintPaketDocs";
            this.btnPrintPaketDocs.Size = new System.Drawing.Size(124, 52);
            this.btnPrintPaketDocs.Text = "Печать\nпакета\nдокументов";
            this.btnPrintPaketDocs.Click += new System.EventHandler(this.tsmiPrintDocument_Click);
            // 
            // btnExportRegisterToExcel
            // 
            this.btnExportRegisterToExcel.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnExportRegisterToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportRegisterToExcel.Name = "btnExportRegisterToExcel";
            this.btnExportRegisterToExcel.Size = new System.Drawing.Size(149, 52);
            this.btnExportRegisterToExcel.Text = "Реестр\n(экспорт в Excel)";
            this.btnExportRegisterToExcel.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(143, 52);
            this.btnFind.Text = "Поиск в архиве";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // cbPrintedFilter
            // 
            this.cbPrintedFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrintedFilter.Items.AddRange(new object[] {
            "Не распечатанные",
            "Распечатанные",
            "Все"});
            this.cbPrintedFilter.Name = "cbPrintedFilter";
            this.cbPrintedFilter.Size = new System.Drawing.Size(150, 55);
            this.cbPrintedFilter.ToolTipText = "Фильтр по уже загруженным данным, который определяет, какие сводные показывать";
            this.cbPrintedFilter.SelectedIndexChanged += new System.EventHandler(this.cbPrintedFilter_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // lblPrinter
            // 
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblCount
            // 
            this.lblCount.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(141, 30);
            this.lblCount.Text = "Кол-во СНН для печати:\n1111";
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToOrderColumns = true;
            this.dgvDocs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docNumberDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.Peron_ID,
            this.amountDataGridViewTextBoxColumn,
            this.debtorIDDataGridViewTextBoxColumn,
            this.debitorDataGridViewTextBoxColumn,
            this.adressDataGridViewTextBoxColumn,
            this.salesDataGridViewTextBoxColumn,
            this.Filial,
            this.DocType,
            this.iSPrintedDataGridViewCheckBoxColumn});
            this.dgvDocs.ContextMenuStrip = this.cmsContextMenu;
            this.dgvDocs.DataSource = this.bsPIFindNaklSummary;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDocs.Location = new System.Drawing.Point(0, 95);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.ShowCellErrors = false;
            this.dgvDocs.ShowEditingIcon = false;
            this.dgvDocs.Size = new System.Drawing.Size(1093, 293);
            this.dgvDocs.TabIndex = 8;
            this.dgvDocs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellDoubleClick);
            this.dgvDocs.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvDocs_RowPrePaint);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // docNumberDataGridViewTextBoxColumn
            // 
            this.docNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docNumberDataGridViewTextBoxColumn.DataPropertyName = "Doc_Number";
            this.docNumberDataGridViewTextBoxColumn.HeaderText = "Номер НН";
            this.docNumberDataGridViewTextBoxColumn.Name = "docNumberDataGridViewTextBoxColumn";
            this.docNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.docNumberDataGridViewTextBoxColumn.Width = 79;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата выписки";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn.Width = 97;
            // 
            // Peron_ID
            // 
            this.Peron_ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Peron_ID.DataPropertyName = "Peron_ID";
            this.Peron_ID.HeaderText = "№ перрона";
            this.Peron_ID.Name = "Peron_ID";
            this.Peron_ID.ReadOnly = true;
            this.Peron_ID.Width = 81;
            // 
            // amountDataGridViewTextBoxColumn
            // 
            this.amountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountDataGridViewTextBoxColumn.DataPropertyName = "Amount";
            this.amountDataGridViewTextBoxColumn.HeaderText = "Сумма";
            this.amountDataGridViewTextBoxColumn.Name = "amountDataGridViewTextBoxColumn";
            this.amountDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountDataGridViewTextBoxColumn.Width = 66;
            // 
            // debtorIDDataGridViewTextBoxColumn
            // 
            this.debtorIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debtorIDDataGridViewTextBoxColumn.DataPropertyName = "Debtor_ID";
            this.debtorIDDataGridViewTextBoxColumn.HeaderText = "Код дебитора";
            this.debtorIDDataGridViewTextBoxColumn.Name = "debtorIDDataGridViewTextBoxColumn";
            this.debtorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorIDDataGridViewTextBoxColumn.Width = 93;
            // 
            // debitorDataGridViewTextBoxColumn
            // 
            this.debitorDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.debitorDataGridViewTextBoxColumn.DataPropertyName = "Debitor";
            this.debitorDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.debitorDataGridViewTextBoxColumn.Name = "debitorDataGridViewTextBoxColumn";
            this.debitorDataGridViewTextBoxColumn.ReadOnly = true;
            this.debitorDataGridViewTextBoxColumn.Width = 108;
            // 
            // adressDataGridViewTextBoxColumn
            // 
            this.adressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.adressDataGridViewTextBoxColumn.DataPropertyName = "Adress";
            this.adressDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.adressDataGridViewTextBoxColumn.Name = "adressDataGridViewTextBoxColumn";
            this.adressDataGridViewTextBoxColumn.ReadOnly = true;
            this.adressDataGridViewTextBoxColumn.Width = 104;
            // 
            // salesDataGridViewTextBoxColumn
            // 
            this.salesDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.salesDataGridViewTextBoxColumn.DataPropertyName = "Sales";
            this.salesDataGridViewTextBoxColumn.HeaderText = "Торговый представитель";
            this.salesDataGridViewTextBoxColumn.Name = "salesDataGridViewTextBoxColumn";
            this.salesDataGridViewTextBoxColumn.ReadOnly = true;
            this.salesDataGridViewTextBoxColumn.Width = 147;
            // 
            // Filial
            // 
            this.Filial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Filial.DataPropertyName = "Filial";
            this.Filial.HeaderText = "Описание склада";
            this.Filial.Name = "Filial";
            this.Filial.ReadOnly = true;
            this.Filial.Width = 111;
            // 
            // DocType
            // 
            this.DocType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocType.DataPropertyName = "DocType";
            this.DocType.HeaderText = "Тип документа";
            this.DocType.Name = "DocType";
            this.DocType.ReadOnly = true;
            this.DocType.Width = 99;
            // 
            // iSPrintedDataGridViewCheckBoxColumn
            // 
            this.iSPrintedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iSPrintedDataGridViewCheckBoxColumn.DataPropertyName = "IS_Printed1";
            this.iSPrintedDataGridViewCheckBoxColumn.HeaderText = "Распечатан";
            this.iSPrintedDataGridViewCheckBoxColumn.Name = "iSPrintedDataGridViewCheckBoxColumn";
            this.iSPrintedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.iSPrintedDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.iSPrintedDataGridViewCheckBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.iSPrintedDataGridViewCheckBoxColumn.Width = 91;
            // 
            // cmsContextMenu
            // 
            this.cmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRefresh,
            this.toolStripSeparator1,
            this.tsmiExportRegister,
            this.tsmiExportGroupedRegister,
            this.tsmiPrintPaketDocs,
            this.toolStripSeparator4,
            this.tsmiPrintInvoiceForClient,
            this.tsmiPrintInvoiceForOptima,
            this.tsmiViewClientInvoice,
            this.tsmiViewOptimaInvoice});
            this.cmsContextMenu.Name = "cmsContextMenu";
            this.cmsContextMenu.Size = new System.Drawing.Size(296, 214);
            // 
            // tsmiRefresh
            // 
            this.tsmiRefresh.Name = "tsmiRefresh";
            this.tsmiRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.tsmiRefresh.Size = new System.Drawing.Size(295, 22);
            this.tsmiRefresh.Text = "Обновить";
            this.tsmiRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(292, 6);
            // 
            // tsmiExportRegister
            // 
            this.tsmiExportRegister.Name = "tsmiExportRegister";
            this.tsmiExportRegister.Size = new System.Drawing.Size(295, 22);
            this.tsmiExportRegister.Text = "Реестр - экспорт в Excel";
            this.tsmiExportRegister.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
            // 
            // tsmiExportGroupedRegister
            // 
            this.tsmiExportGroupedRegister.Name = "tsmiExportGroupedRegister";
            this.tsmiExportGroupedRegister.Size = new System.Drawing.Size(295, 22);
            this.tsmiExportGroupedRegister.Text = "Реестр (только суммы) - экспорт в Excel";
            this.tsmiExportGroupedRegister.Click += new System.EventHandler(this.ExportToExcelToolStripMenuItem_Click);
            // 
            // tsmiPrintPaketDocs
            // 
            this.tsmiPrintPaketDocs.Name = "tsmiPrintPaketDocs";
            this.tsmiPrintPaketDocs.Size = new System.Drawing.Size(295, 22);
            this.tsmiPrintPaketDocs.Text = "Печать пакета документов";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(292, 6);
            // 
            // tsmiPrintInvoiceForClient
            // 
            this.tsmiPrintInvoiceForClient.Name = "tsmiPrintInvoiceForClient";
            this.tsmiPrintInvoiceForClient.Size = new System.Drawing.Size(295, 22);
            this.tsmiPrintInvoiceForClient.Text = "Печать накладной для клиента";
            this.tsmiPrintInvoiceForClient.Click += new System.EventHandler(this.tsmiPrintDocument_Click);
            // 
            // tsmiPrintInvoiceForOptima
            // 
            this.tsmiPrintInvoiceForOptima.Name = "tsmiPrintInvoiceForOptima";
            this.tsmiPrintInvoiceForOptima.Size = new System.Drawing.Size(295, 22);
            this.tsmiPrintInvoiceForOptima.Text = "Печать накладной для Оптимы";
            this.tsmiPrintInvoiceForOptima.Click += new System.EventHandler(this.tsmiPrintDocument_Click);
            // 
            // tsmiViewClientInvoice
            // 
            this.tsmiViewClientInvoice.Name = "tsmiViewClientInvoice";
            this.tsmiViewClientInvoice.Size = new System.Drawing.Size(295, 22);
            this.tsmiViewClientInvoice.Text = "Просмотр накладной для клиента";
            this.tsmiViewClientInvoice.Click += new System.EventHandler(this.tsmiViewInvoice_Click);
            // 
            // tsmiViewOptimaInvoice
            // 
            this.tsmiViewOptimaInvoice.Name = "tsmiViewOptimaInvoice";
            this.tsmiViewOptimaInvoice.Size = new System.Drawing.Size(295, 22);
            this.tsmiViewOptimaInvoice.Text = "Просмотр накладной для Оптимы";
            this.tsmiViewOptimaInvoice.Click += new System.EventHandler(this.tsmiViewInvoice_Click);
            // 
            // bsPIFindNaklSummary
            // 
            this.bsPIFindNaklSummary.DataMember = "PI_FindNaklSummary";
            this.bsPIFindNaklSummary.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Doc_Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер НН";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата выписки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn3.HeaderText = "Сумма";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Debtor_ID";
            this.dataGridViewTextBoxColumn4.HeaderText = "Код дебитора";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Debitor";
            this.dataGridViewTextBoxColumn5.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Adress";
            this.dataGridViewTextBoxColumn6.HeaderText = "Адрес доставки";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Sales";
            this.dataGridViewTextBoxColumn7.HeaderText = "Торговый представитель";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IS_Printed";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Распечатан";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewImageColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewImageColumn1.HeaderText = "Распечатан";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // taPI_FindNaklSummary
            // 
            this.taPI_FindNaklSummary.ClearBeforeFill = true;
            // 
            // WHDocsPrintSummaryInvoicesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 388);
            this.Controls.Add(this.dgvDocs);
            this.Controls.Add(this.tsMainStripForDocs);
            this.Name = "WHDocsPrintSummaryInvoicesWindow";
            this.Text = "WHDocsPrintSummaryInvoicesWindow";
            this.Shown += new System.EventHandler(this.WHDocsPrintSummaryInvoicesWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WHDocsPrintSummaryInvoicesWindow_FormClosing);
            this.Controls.SetChildIndex(this.tsMainStripForDocs, 0);
            this.Controls.SetChildIndex(this.dgvDocs, 0);
            this.tsMainStripForDocs.ResumeLayout(false);
            this.tsMainStripForDocs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.cmsContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsPIFindNaklSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainStripForDocs;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource bsPIFindNaklSummary;
        private WMSOffice.Data.WHTableAdapters.PI_FindNaklSummaryTableAdapter taPI_FindNaklSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ToolStripMenuItem tsmiRefresh;
        private System.Windows.Forms.DataGridViewImageColumn iSPrintedDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewOptimaInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportRegister;
        private System.Windows.Forms.ToolStripButton btnExportRegisterToExcel;
        private System.Windows.Forms.ToolStripComboBox cbPrintedFilter;
        private System.Windows.Forms.ToolStripButton btnPrintPaketDocs;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintPaketDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn docNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Peron_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debitorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filial;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn iSPrintedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintInvoiceForClient;
        private System.Windows.Forms.ToolStripMenuItem tsmiPrintInvoiceForOptima;
        private System.Windows.Forms.ToolStripLabel lblCount;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewClientInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmiExportGroupedRegister;
    }
}