namespace WMSOffice.Window
{
    partial class WHDocsControlWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnOpenDoc = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnPrintRangSection = new System.Windows.Forms.ToolStripButton();
            this.btnPrintZoneRank = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.pnlFilter = new System.Windows.Forms.GroupBox();
            this.tbDeliveryID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.stbSupplierCode = new WMSOffice.Controls.SearchTextBox();
            this.lblSupplierCode = new System.Windows.Forms.Label();
            this.tbBoxCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.statusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.tbDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.gvDocs = new System.Windows.Forms.DataGridView();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.moduleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docsControlBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scDocDetails = new System.Windows.Forms.SplitContainer();
            this.gvDocLines = new System.Windows.Forms.DataGridView();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTinBXDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bXQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iTQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gvDocLineItems = new System.Windows.Forms.DataGridView();
            this.barCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDetailItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.docLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.statusesTableAdapter = new WMSOffice.Data.WHTableAdapters.StatusesTableAdapter();
            this.docsControlTableAdapter = new WMSOffice.Data.WHTableAdapters.DocsControlTableAdapter();
            this.docLinesTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.DocLinesTableAdapter();
            this.docDetailsTableAdapter = new WMSOffice.Data.WHTableAdapters.DocDetailsTableAdapter();
            this.docDetailItemsTableAdapter = new WMSOffice.Data.WHTableAdapters.DocDetailItemsTableAdapter();
            this.toolStripDoc.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsControlBindingSource)).BeginInit();
            this.scDocDetails.Panel1.SuspendLayout();
            this.scDocDetails.Panel2.SuspendLayout();
            this.scDocDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLineItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDetailItemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnOpenDoc,
            this.btnDelete,
            this.btnPrintRangSection,
            this.btnPrintZoneRank,
            this.cmbPrinters});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1196, 55);
            this.toolStripDoc.TabIndex = 4;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(155, 52);
            this.btnRefresh.Text = "Обновить список\n\r документов";
            this.btnRefresh.ToolTipText = "Обновить список документов";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 52);
            this.btnPrint.Text = "Напечатать\n\r документ\n\r повторно";
            this.btnPrint.ToolTipText = "Напечатать документ повторно";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Image = global::WMSOffice.Properties.Resources.lock_open;
            this.btnOpenDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(114, 52);
            this.btnOpenDoc.Text = "Открыть\n\r документ";
            this.btnOpenDoc.ToolTipText = "Открыть документ";
            this.btnOpenDoc.Click += new System.EventHandler(this.btnOpenDoc_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(138, 52);
            this.btnDelete.Text = "Аннулировать\nдокумент";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnPrintRangSection
            // 
            this.btnPrintRangSection.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintRangSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintRangSection.Name = "btnPrintRangSection";
            this.btnPrintRangSection.Size = new System.Drawing.Size(171, 52);
            this.btnPrintRangSection.Text = "Одноразовая печать\nРяд/секция";
            this.btnPrintRangSection.Click += new System.EventHandler(this.btnPrintRangSection_Click);
            // 
            // btnPrintZoneRank
            // 
            this.btnPrintZoneRank.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintZoneRank.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintZoneRank.Name = "btnPrintZoneRank";
            this.btnPrintZoneRank.Size = new System.Drawing.Size(171, 52);
            this.btnPrintZoneRank.Text = "Одноразовая печать\nЗона/ряд";
            this.btnPrintZoneRank.Click += new System.EventHandler(this.btnPrintZoneRank_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.tbDeliveryID);
            this.pnlFilter.Controls.Add(this.label9);
            this.pnlFilter.Controls.Add(this.lblSupplierName);
            this.pnlFilter.Controls.Add(this.stbSupplierCode);
            this.pnlFilter.Controls.Add(this.lblSupplierCode);
            this.pnlFilter.Controls.Add(this.tbBoxCode);
            this.pnlFilter.Controls.Add(this.label8);
            this.pnlFilter.Controls.Add(this.tbItemCode);
            this.pnlFilter.Controls.Add(this.label7);
            this.pnlFilter.Controls.Add(this.label6);
            this.pnlFilter.Controls.Add(this.cbStatus);
            this.pnlFilter.Controls.Add(this.tbEmployee);
            this.pnlFilter.Controls.Add(this.label5);
            this.pnlFilter.Controls.Add(this.dateTo);
            this.pnlFilter.Controls.Add(this.label4);
            this.pnlFilter.Controls.Add(this.dateFrom);
            this.pnlFilter.Controls.Add(this.label3);
            this.pnlFilter.Controls.Add(this.label2);
            this.pnlFilter.Controls.Add(this.tbDocType);
            this.pnlFilter.Controls.Add(this.tbDoc);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 95);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(1196, 77);
            this.pnlFilter.TabIndex = 5;
            this.pnlFilter.TabStop = false;
            this.pnlFilter.Text = "Фильтр:";
            // 
            // tbDeliveryID
            // 
            this.tbDeliveryID.Location = new System.Drawing.Point(1006, 18);
            this.tbDeliveryID.Name = "tbDeliveryID";
            this.tbDeliveryID.Size = new System.Drawing.Size(100, 20);
            this.tbDeliveryID.TabIndex = 20;
            this.tbDeliveryID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(954, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Код ТТ:";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(759, 48);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(0, 13);
            this.lblSupplierName.TabIndex = 18;
            // 
            // stbSupplierCode
            // 
            this.stbSupplierCode.Location = new System.Drawing.Point(667, 44);
            this.stbSupplierCode.Name = "stbSupplierCode";
            this.stbSupplierCode.ReadOnly = false;
            this.stbSupplierCode.Size = new System.Drawing.Size(72, 20);
            this.stbSupplierCode.TabIndex = 17;
            this.stbSupplierCode.UserID = ((long)(0));
            this.stbSupplierCode.Value = null;
            this.stbSupplierCode.ValueReferenceQuery = null;
            // 
            // lblSupplierCode
            // 
            this.lblSupplierCode.AutoSize = true;
            this.lblSupplierCode.Location = new System.Drawing.Point(566, 48);
            this.lblSupplierCode.Name = "lblSupplierCode";
            this.lblSupplierCode.Size = new System.Drawing.Size(94, 13);
            this.lblSupplierCode.TabIndex = 16;
            this.lblSupplierCode.Text = "Код поставщика:";
            // 
            // tbBoxCode
            // 
            this.tbBoxCode.Location = new System.Drawing.Point(830, 18);
            this.tbBoxCode.Name = "tbBoxCode";
            this.tbBoxCode.Size = new System.Drawing.Size(100, 20);
            this.tbBoxCode.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(759, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Код ящика:";
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(639, 19);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(100, 20);
            this.tbItemCode.TabIndex = 13;
            this.tbItemCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(566, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Код товара:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(278, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Сотрудник:";
            // 
            // cbStatus
            // 
            this.cbStatus.DataSource = this.statusesBindingSource;
            this.cbStatus.DisplayMember = "Status_Name";
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(56, 45);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(216, 21);
            this.cbStatus.TabIndex = 10;
            this.cbStatus.ValueMember = "Status_ID";
            // 
            // statusesBindingSource
            // 
            this.statusesBindingSource.DataMember = "Statuses";
            this.statusesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbEmployee
            // 
            this.tbEmployee.Location = new System.Drawing.Point(347, 45);
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.Size = new System.Drawing.Size(207, 20);
            this.tbEmployee.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Статус:";
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(473, 19);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(81, 20);
            this.dateTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(416, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата по:";
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(329, 19);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(81, 20);
            this.dateFrom.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(278, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата с:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Тип:";
            // 
            // tbDocType
            // 
            this.tbDocType.Location = new System.Drawing.Point(231, 19);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.Size = new System.Drawing.Size(41, 20);
            this.tbDocType.TabIndex = 2;
            // 
            // tbDoc
            // 
            this.tbDoc.Location = new System.Drawing.Point(90, 19);
            this.tbDoc.Name = "tbDoc";
            this.tbDoc.Size = new System.Drawing.Size(100, 20);
            this.tbDoc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "№ документа:";
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 172);
            this.scMain.Name = "scMain";
            this.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.gvDocs);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scDocDetails);
            this.scMain.Size = new System.Drawing.Size(1196, 375);
            this.scMain.SplitterDistance = 186;
            this.scMain.TabIndex = 6;
            // 
            // gvDocs
            // 
            this.gvDocs.AllowUserToAddRows = false;
            this.gvDocs.AllowUserToDeleteRows = false;
            this.gvDocs.AllowUserToResizeRows = false;
            this.gvDocs.AutoGenerateColumns = false;
            this.gvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.docIDDataGridViewTextBoxColumn,
            this.docTypeDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.moduleIDDataGridViewTextBoxColumn,
            this.moduleDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeNameDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn});
            this.gvDocs.DataSource = this.docsControlBindingSource;
            this.gvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocs.Location = new System.Drawing.Point(0, 0);
            this.gvDocs.MultiSelect = false;
            this.gvDocs.Name = "gvDocs";
            this.gvDocs.ReadOnly = true;
            this.gvDocs.RowHeadersVisible = false;
            this.gvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDocs.Size = new System.Drawing.Size(1196, 186);
            this.gvDocs.TabIndex = 0;
            this.gvDocs.SelectionChanged += new System.EventHandler(this.gvDocs_SelectionChanged);
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Документ";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 83;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeDataGridViewTextBoxColumn.Width = 51;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Название типа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 99;
            // 
            // moduleIDDataGridViewTextBoxColumn
            // 
            this.moduleIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.moduleIDDataGridViewTextBoxColumn.DataPropertyName = "Module_ID";
            this.moduleIDDataGridViewTextBoxColumn.HeaderText = "Модуль";
            this.moduleIDDataGridViewTextBoxColumn.Name = "moduleIDDataGridViewTextBoxColumn";
            this.moduleIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.moduleIDDataGridViewTextBoxColumn.Width = 70;
            // 
            // moduleDataGridViewTextBoxColumn
            // 
            this.moduleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.moduleDataGridViewTextBoxColumn.DataPropertyName = "Module";
            this.moduleDataGridViewTextBoxColumn.HeaderText = "Название модуля";
            this.moduleDataGridViewTextBoxColumn.Name = "moduleDataGridViewTextBoxColumn";
            this.moduleDataGridViewTextBoxColumn.ReadOnly = true;
            this.moduleDataGridViewTextBoxColumn.Width = 112;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 66;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Название статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusNameDataGridViewTextBoxColumn.Width = 114;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Width = 58;
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // employeeNameDataGridViewTextBoxColumn
            // 
            this.employeeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeNameDataGridViewTextBoxColumn.DataPropertyName = "Employee_Name";
            this.employeeNameDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeNameDataGridViewTextBoxColumn.Name = "employeeNameDataGridViewTextBoxColumn";
            this.employeeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeNameDataGridViewTextBoxColumn.Width = 85;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "DateUpdated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Изменен";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateUpdatedDataGridViewTextBoxColumn.Width = 78;
            // 
            // docsControlBindingSource
            // 
            this.docsControlBindingSource.DataMember = "DocsControl";
            this.docsControlBindingSource.DataSource = this.wH;
            // 
            // scDocDetails
            // 
            this.scDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scDocDetails.Location = new System.Drawing.Point(0, 0);
            this.scDocDetails.Name = "scDocDetails";
            // 
            // scDocDetails.Panel1
            // 
            this.scDocDetails.Panel1.Controls.Add(this.gvDocLines);
            // 
            // scDocDetails.Panel2
            // 
            this.scDocDetails.Panel2.Controls.Add(this.gvDocLineItems);
            this.scDocDetails.Size = new System.Drawing.Size(1196, 185);
            this.scDocDetails.SplitterDistance = 920;
            this.scDocDetails.TabIndex = 5;
            // 
            // gvDocLines
            // 
            this.gvDocLines.AllowUserToAddRows = false;
            this.gvDocLines.AllowUserToResizeRows = false;
            this.gvDocLines.AutoGenerateColumns = false;
            this.gvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.iTinBXDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.bXQtyDataGridViewTextBoxColumn,
            this.iTQtyDataGridViewTextBoxColumn,
            this.qtyDataGridViewTextBoxColumn});
            this.gvDocLines.DataSource = this.docDetailsBindingSource;
            this.gvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocLines.Location = new System.Drawing.Point(0, 0);
            this.gvDocLines.MultiSelect = false;
            this.gvDocLines.Name = "gvDocLines";
            this.gvDocLines.ReadOnly = true;
            this.gvDocLines.RowHeadersVisible = false;
            this.gvDocLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDocLines.Size = new System.Drawing.Size(920, 185);
            this.gvDocLines.TabIndex = 4;
            this.gvDocLines.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.gvDocLines_UserDeletingRow);
            this.gvDocLines.SelectionChanged += new System.EventHandler(this.gvDocLines_SelectionChanged);
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 51;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.Width = 108;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 47;
            // 
            // iTinBXDataGridViewTextBoxColumn
            // 
            this.iTinBXDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTinBXDataGridViewTextBoxColumn.DataPropertyName = "ITinBX";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "#,##0";
            this.iTinBXDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.iTinBXDataGridViewTextBoxColumn.HeaderText = "шт.";
            this.iTinBXDataGridViewTextBoxColumn.Name = "iTinBXDataGridViewTextBoxColumn";
            this.iTinBXDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTinBXDataGridViewTextBoxColumn.Width = 48;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия/Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 105;
            // 
            // bXQtyDataGridViewTextBoxColumn
            // 
            this.bXQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.bXQtyDataGridViewTextBoxColumn.DataPropertyName = "BX_Qty";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,##0";
            this.bXQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.bXQtyDataGridViewTextBoxColumn.HeaderText = "Ящиков";
            this.bXQtyDataGridViewTextBoxColumn.Name = "bXQtyDataGridViewTextBoxColumn";
            this.bXQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.bXQtyDataGridViewTextBoxColumn.Width = 73;
            // 
            // iTQtyDataGridViewTextBoxColumn
            // 
            this.iTQtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iTQtyDataGridViewTextBoxColumn.DataPropertyName = "IT_Qty";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,##0";
            this.iTQtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.iTQtyDataGridViewTextBoxColumn.HeaderText = "Упаковок";
            this.iTQtyDataGridViewTextBoxColumn.Name = "iTQtyDataGridViewTextBoxColumn";
            this.iTQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.iTQtyDataGridViewTextBoxColumn.Width = 82;
            // 
            // qtyDataGridViewTextBoxColumn
            // 
            this.qtyDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyDataGridViewTextBoxColumn.DataPropertyName = "Qty";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,##0";
            this.qtyDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.qtyDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.qtyDataGridViewTextBoxColumn.Name = "qtyDataGridViewTextBoxColumn";
            this.qtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.qtyDataGridViewTextBoxColumn.Width = 91;
            // 
            // docDetailsBindingSource
            // 
            this.docDetailsBindingSource.DataMember = "DocDetails";
            this.docDetailsBindingSource.DataSource = this.wH;
            // 
            // gvDocLineItems
            // 
            this.gvDocLineItems.AllowUserToAddRows = false;
            this.gvDocLineItems.AllowUserToDeleteRows = false;
            this.gvDocLineItems.AllowUserToResizeRows = false;
            this.gvDocLineItems.AutoGenerateColumns = false;
            this.gvDocLineItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvDocLineItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocLineItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.barCodeDataGridViewTextBoxColumn,
            this.docQtyDataGridViewTextBoxColumn});
            this.gvDocLineItems.DataSource = this.docDetailItemsBindingSource;
            this.gvDocLineItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocLineItems.Location = new System.Drawing.Point(0, 0);
            this.gvDocLineItems.MultiSelect = false;
            this.gvDocLineItems.Name = "gvDocLineItems";
            this.gvDocLineItems.ReadOnly = true;
            this.gvDocLineItems.RowHeadersVisible = false;
            this.gvDocLineItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDocLineItems.Size = new System.Drawing.Size(272, 185);
            this.gvDocLineItems.TabIndex = 0;
            this.gvDocLineItems.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvDocLineItems_CellDoubleClick);
            this.gvDocLineItems.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gvDocLineItems_CellFormatting);
            // 
            // barCodeDataGridViewTextBoxColumn
            // 
            this.barCodeDataGridViewTextBoxColumn.DataPropertyName = "Bar_Code";
            this.barCodeDataGridViewTextBoxColumn.HeaderText = "Ш/К";
            this.barCodeDataGridViewTextBoxColumn.Name = "barCodeDataGridViewTextBoxColumn";
            this.barCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barCodeDataGridViewTextBoxColumn.Width = 53;
            // 
            // docQtyDataGridViewTextBoxColumn
            // 
            this.docQtyDataGridViewTextBoxColumn.DataPropertyName = "Doc_Qty";
            this.docQtyDataGridViewTextBoxColumn.HeaderText = "шт.";
            this.docQtyDataGridViewTextBoxColumn.Name = "docQtyDataGridViewTextBoxColumn";
            this.docQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.docQtyDataGridViewTextBoxColumn.Width = 48;
            // 
            // docDetailItemsBindingSource
            // 
            this.docDetailItemsBindingSource.DataMember = "DocDetailItems";
            this.docDetailItemsBindingSource.DataSource = this.wH;
            // 
            // docLinesBindingSource
            // 
            this.docLinesBindingSource.DataMember = "DocLines";
            this.docLinesBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // statusesTableAdapter
            // 
            this.statusesTableAdapter.ClearBeforeFill = true;
            // 
            // docsControlTableAdapter
            // 
            this.docsControlTableAdapter.ClearBeforeFill = true;
            // 
            // docLinesTableAdapter
            // 
            this.docLinesTableAdapter.ClearBeforeFill = true;
            // 
            // docDetailsTableAdapter
            // 
            this.docDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // docDetailItemsTableAdapter
            // 
            this.docDetailItemsTableAdapter.ClearBeforeFill = true;
            // 
            // WHDocsControlWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 547);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "WHDocsControlWindow";
            this.Text = "WHDocsControlWindow";
            this.Load += new System.EventHandler(this.WHDocsControlWindow_Load);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.scMain, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.statusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docsControlBindingSource)).EndInit();
            this.scDocDetails.Panel1.ResumeLayout(false);
            this.scDocDetails.Panel2.ResumeLayout(false);
            this.scDocDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocLineItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docDetailItemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox pnlFilter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.TextBox tbDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.SplitContainer scMain;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource statusesBindingSource;
        private WMSOffice.Data.WHTableAdapters.StatusesTableAdapter statusesTableAdapter;
        private System.Windows.Forms.DataGridView gvDocs;
        private System.Windows.Forms.BindingSource docsControlBindingSource;
        private WMSOffice.Data.WHTableAdapters.DocsControlTableAdapter docsControlTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn moduleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView gvDocLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTinBXDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bXQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iTQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource docLinesBindingSource;
        private WMSOffice.Data.Receive receive;
        private WMSOffice.Data.ReceiveTableAdapters.DocLinesTableAdapter docLinesTableAdapter;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnOpenDoc;
        private System.Windows.Forms.BindingSource docDetailsBindingSource;
        private WMSOffice.Data.WHTableAdapters.DocDetailsTableAdapter docDetailsTableAdapter;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripButton btnPrintRangSection;
        private System.Windows.Forms.ToolStripButton btnPrintZoneRank;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.TextBox tbBoxCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.SplitContainer scDocDetails;
        private System.Windows.Forms.DataGridView gvDocLineItems;
        private System.Windows.Forms.BindingSource docDetailItemsBindingSource;
        private WMSOffice.Data.WHTableAdapters.DocDetailItemsTableAdapter docDetailItemsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn barCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.Label lblSupplierName;
        private WMSOffice.Controls.SearchTextBox stbSupplierCode;
        private System.Windows.Forms.Label lblSupplierCode;
        private System.Windows.Forms.TextBox tbDeliveryID;
        private System.Windows.Forms.Label label9;
    }
}