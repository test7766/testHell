namespace WMSOffice.Window
{
    partial class OptionsPakSheetsWindow
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
            this.pnlFilter = new System.Windows.Forms.GroupBox();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.tbItemCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTo = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dateFrom = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDoc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnOpenDoc = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.паклистаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаЗакрытияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.статусDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.названиеСтатусаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодСотрудникаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сотрудникDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.измененDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wfgetibdocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wF = new WMSOffice.Data.WF();
            this.dgvDocLines = new System.Windows.Forms.DataGridView();
            this.кодТовараDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.наименованиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.производительDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.серияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.партияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.количествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.паклистаDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.макетаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.заявкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаЗаявкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.сборочногоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.местонахождениеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.складDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wfgetibdocdetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wf_get_ib_docsTableAdapter = new WMSOffice.Data.WFTableAdapters.wf_get_ib_docsTableAdapter();
            this.wf_get_ib_doc_detailsTableAdapter = new WMSOffice.Data.WFTableAdapters.wf_get_ib_doc_detailsTableAdapter();
            this.pnlFilter.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wfgetibdocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wfgetibdocdetailsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.checkBox);
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
            this.pnlFilter.Controls.Add(this.tbDoc);
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(0, 95);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(937, 77);
            this.pnlFilter.TabIndex = 9;
            this.pnlFilter.TabStop = false;
            this.pnlFilter.Text = "Фильтр:";
            // 
            // checkBox
            // 
            this.checkBox.AutoSize = true;
            this.checkBox.Location = new System.Drawing.Point(561, 48);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(76, 17);
            this.checkBox.TabIndex = 14;
            this.checkBox.Text = "Архивные";
            this.checkBox.UseVisualStyleBackColor = true;
            // 
            // tbItemCode
            // 
            this.tbItemCode.Location = new System.Drawing.Point(559, 19);
            this.tbItemCode.Name = "tbItemCode";
            this.tbItemCode.Size = new System.Drawing.Size(100, 20);
            this.tbItemCode.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(486, 22);
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
            this.cbStatus.DisplayMember = "Status_Name";
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(56, 45);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(216, 21);
            this.cbStatus.TabIndex = 10;
            this.cbStatus.ValueMember = "Status_ID";
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
            this.dateTo.Location = new System.Drawing.Point(393, 19);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(81, 20);
            this.dateTo.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(336, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата по:";
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(249, 19);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(81, 20);
            this.dateFrom.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата с:";
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
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnPrint,
            this.btnOpenDoc,
            this.cmbPrinters});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(937, 55);
            this.toolStripDoc.TabIndex = 7;
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
            this.btnPrint.Visible = false;
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnOpenDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size(104, 52);
            this.btnOpenDoc.Text = "Экспорт";
            this.btnOpenDoc.ToolTipText = "Открыть документ";
            this.btnOpenDoc.Click += new System.EventHandler(this.btnExportDoc_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            this.cmbPrinters.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 172);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDocs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvDocLines);
            this.splitContainer1.Size = new System.Drawing.Size(937, 395);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 10;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.паклистаDataGridViewTextBoxColumn,
            this.датаЗакрытияDataGridViewTextBoxColumn,
            this.статусDataGridViewTextBoxColumn,
            this.названиеСтатусаDataGridViewTextBoxColumn,
            this.кодСотрудникаDataGridViewTextBoxColumn,
            this.сотрудникDataGridViewTextBoxColumn,
            this.измененDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.wfgetibdocsBindingSource;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.ReadOnly = true;
            this.dgvDocs.RowHeadersWidth = 10;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(937, 170);
            this.dgvDocs.TabIndex = 0;
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // паклистаDataGridViewTextBoxColumn
            // 
            this.паклистаDataGridViewTextBoxColumn.DataPropertyName = "№ пак-листа";
            this.паклистаDataGridViewTextBoxColumn.HeaderText = "№ пак-листа";
            this.паклистаDataGridViewTextBoxColumn.Name = "паклистаDataGridViewTextBoxColumn";
            this.паклистаDataGridViewTextBoxColumn.ReadOnly = true;
            this.паклистаDataGridViewTextBoxColumn.Width = 88;
            // 
            // датаЗакрытияDataGridViewTextBoxColumn
            // 
            this.датаЗакрытияDataGridViewTextBoxColumn.DataPropertyName = "Дата закрытия";
            this.датаЗакрытияDataGridViewTextBoxColumn.HeaderText = "Дата закрытия";
            this.датаЗакрытияDataGridViewTextBoxColumn.Name = "датаЗакрытияDataGridViewTextBoxColumn";
            this.датаЗакрытияDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаЗакрытияDataGridViewTextBoxColumn.Width = 101;
            // 
            // статусDataGridViewTextBoxColumn
            // 
            this.статусDataGridViewTextBoxColumn.DataPropertyName = "Статус";
            this.статусDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.статусDataGridViewTextBoxColumn.Name = "статусDataGridViewTextBoxColumn";
            this.статусDataGridViewTextBoxColumn.ReadOnly = true;
            this.статусDataGridViewTextBoxColumn.Width = 66;
            // 
            // названиеСтатусаDataGridViewTextBoxColumn
            // 
            this.названиеСтатусаDataGridViewTextBoxColumn.DataPropertyName = "Название статуса";
            this.названиеСтатусаDataGridViewTextBoxColumn.HeaderText = "Название статуса";
            this.названиеСтатусаDataGridViewTextBoxColumn.Name = "названиеСтатусаDataGridViewTextBoxColumn";
            this.названиеСтатусаDataGridViewTextBoxColumn.ReadOnly = true;
            this.названиеСтатусаDataGridViewTextBoxColumn.Width = 114;
            // 
            // кодСотрудникаDataGridViewTextBoxColumn
            // 
            this.кодСотрудникаDataGridViewTextBoxColumn.DataPropertyName = "Код сотрудника";
            this.кодСотрудникаDataGridViewTextBoxColumn.HeaderText = "Код сотрудника";
            this.кодСотрудникаDataGridViewTextBoxColumn.Name = "кодСотрудникаDataGridViewTextBoxColumn";
            this.кодСотрудникаDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодСотрудникаDataGridViewTextBoxColumn.Width = 103;
            // 
            // сотрудникDataGridViewTextBoxColumn
            // 
            this.сотрудникDataGridViewTextBoxColumn.DataPropertyName = "Сотрудник";
            this.сотрудникDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.сотрудникDataGridViewTextBoxColumn.Name = "сотрудникDataGridViewTextBoxColumn";
            this.сотрудникDataGridViewTextBoxColumn.ReadOnly = true;
            this.сотрудникDataGridViewTextBoxColumn.Width = 85;
            // 
            // измененDataGridViewTextBoxColumn
            // 
            this.измененDataGridViewTextBoxColumn.DataPropertyName = "Изменен";
            this.измененDataGridViewTextBoxColumn.HeaderText = "Изменен";
            this.измененDataGridViewTextBoxColumn.Name = "измененDataGridViewTextBoxColumn";
            this.измененDataGridViewTextBoxColumn.ReadOnly = true;
            this.измененDataGridViewTextBoxColumn.Width = 78;
            // 
            // wfgetibdocsBindingSource
            // 
            this.wfgetibdocsBindingSource.DataMember = "wf_get_ib_docs";
            this.wfgetibdocsBindingSource.DataSource = this.wF;
            // 
            // wF
            // 
            this.wF.DataSetName = "WF";
            this.wF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dgvDocLines
            // 
            this.dgvDocLines.AllowUserToAddRows = false;
            this.dgvDocLines.AllowUserToDeleteRows = false;
            this.dgvDocLines.AutoGenerateColumns = false;
            this.dgvDocLines.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.кодТовараDataGridViewTextBoxColumn,
            this.наименованиеDataGridViewTextBoxColumn,
            this.производительDataGridViewTextBoxColumn,
            this.серияDataGridViewTextBoxColumn,
            this.партияDataGridViewTextBoxColumn,
            this.количествоDataGridViewTextBoxColumn,
            this.паклистаDataGridViewTextBoxColumn1,
            this.макетаDataGridViewTextBoxColumn,
            this.заявкиDataGridViewTextBoxColumn,
            this.датаЗаявкиDataGridViewTextBoxColumn,
            this.сборочногоDataGridViewTextBoxColumn,
            this.местонахождениеDataGridViewTextBoxColumn,
            this.складDataGridViewTextBoxColumn});
            this.dgvDocLines.DataSource = this.wfgetibdocdetailsBindingSource;
            this.dgvDocLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocLines.Location = new System.Drawing.Point(0, 0);
            this.dgvDocLines.Name = "dgvDocLines";
            this.dgvDocLines.ReadOnly = true;
            this.dgvDocLines.RowHeadersWidth = 10;
            this.dgvDocLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocLines.Size = new System.Drawing.Size(937, 221);
            this.dgvDocLines.TabIndex = 0;
            // 
            // кодТовараDataGridViewTextBoxColumn
            // 
            this.кодТовараDataGridViewTextBoxColumn.DataPropertyName = "Код товара";
            this.кодТовараDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.кодТовараDataGridViewTextBoxColumn.Name = "кодТовараDataGridViewTextBoxColumn";
            this.кодТовараDataGridViewTextBoxColumn.ReadOnly = true;
            this.кодТовараDataGridViewTextBoxColumn.Width = 82;
            // 
            // наименованиеDataGridViewTextBoxColumn
            // 
            this.наименованиеDataGridViewTextBoxColumn.DataPropertyName = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.наименованиеDataGridViewTextBoxColumn.Name = "наименованиеDataGridViewTextBoxColumn";
            this.наименованиеDataGridViewTextBoxColumn.ReadOnly = true;
            this.наименованиеDataGridViewTextBoxColumn.Width = 108;
            // 
            // производительDataGridViewTextBoxColumn
            // 
            this.производительDataGridViewTextBoxColumn.DataPropertyName = "Производитель";
            this.производительDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.производительDataGridViewTextBoxColumn.Name = "производительDataGridViewTextBoxColumn";
            this.производительDataGridViewTextBoxColumn.ReadOnly = true;
            this.производительDataGridViewTextBoxColumn.Width = 111;
            // 
            // серияDataGridViewTextBoxColumn
            // 
            this.серияDataGridViewTextBoxColumn.DataPropertyName = "Серия";
            this.серияDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.серияDataGridViewTextBoxColumn.Name = "серияDataGridViewTextBoxColumn";
            this.серияDataGridViewTextBoxColumn.ReadOnly = true;
            this.серияDataGridViewTextBoxColumn.Width = 63;
            // 
            // партияDataGridViewTextBoxColumn
            // 
            this.партияDataGridViewTextBoxColumn.DataPropertyName = "Партия";
            this.партияDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.партияDataGridViewTextBoxColumn.Name = "партияDataGridViewTextBoxColumn";
            this.партияDataGridViewTextBoxColumn.ReadOnly = true;
            this.партияDataGridViewTextBoxColumn.Width = 69;
            // 
            // количествоDataGridViewTextBoxColumn
            // 
            this.количествоDataGridViewTextBoxColumn.DataPropertyName = "Количество";
            this.количествоDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.количествоDataGridViewTextBoxColumn.Name = "количествоDataGridViewTextBoxColumn";
            this.количествоDataGridViewTextBoxColumn.ReadOnly = true;
            this.количествоDataGridViewTextBoxColumn.Width = 91;
            // 
            // паклистаDataGridViewTextBoxColumn1
            // 
            this.паклистаDataGridViewTextBoxColumn1.DataPropertyName = "№ пак-листа";
            this.паклистаDataGridViewTextBoxColumn1.HeaderText = "№ пак-листа";
            this.паклистаDataGridViewTextBoxColumn1.Name = "паклистаDataGridViewTextBoxColumn1";
            this.паклистаDataGridViewTextBoxColumn1.ReadOnly = true;
            this.паклистаDataGridViewTextBoxColumn1.Width = 88;
            // 
            // макетаDataGridViewTextBoxColumn
            // 
            this.макетаDataGridViewTextBoxColumn.DataPropertyName = "№ макета";
            this.макетаDataGridViewTextBoxColumn.HeaderText = "№ макета";
            this.макетаDataGridViewTextBoxColumn.Name = "макетаDataGridViewTextBoxColumn";
            this.макетаDataGridViewTextBoxColumn.ReadOnly = true;
            this.макетаDataGridViewTextBoxColumn.Width = 77;
            // 
            // заявкиDataGridViewTextBoxColumn
            // 
            this.заявкиDataGridViewTextBoxColumn.DataPropertyName = "№ заявки";
            this.заявкиDataGridViewTextBoxColumn.HeaderText = "№ заявки";
            this.заявкиDataGridViewTextBoxColumn.Name = "заявкиDataGridViewTextBoxColumn";
            this.заявкиDataGridViewTextBoxColumn.ReadOnly = true;
            this.заявкиDataGridViewTextBoxColumn.Width = 76;
            // 
            // датаЗаявкиDataGridViewTextBoxColumn
            // 
            this.датаЗаявкиDataGridViewTextBoxColumn.DataPropertyName = "Дата заявки";
            this.датаЗаявкиDataGridViewTextBoxColumn.HeaderText = "Дата заявки";
            this.датаЗаявкиDataGridViewTextBoxColumn.Name = "датаЗаявкиDataGridViewTextBoxColumn";
            this.датаЗаявкиDataGridViewTextBoxColumn.ReadOnly = true;
            this.датаЗаявкиDataGridViewTextBoxColumn.Width = 89;
            // 
            // сборочногоDataGridViewTextBoxColumn
            // 
            this.сборочногоDataGridViewTextBoxColumn.DataPropertyName = "№ сборочного";
            this.сборочногоDataGridViewTextBoxColumn.HeaderText = "№ сборочного";
            this.сборочногоDataGridViewTextBoxColumn.Name = "сборочногоDataGridViewTextBoxColumn";
            this.сборочногоDataGridViewTextBoxColumn.ReadOnly = true;
            this.сборочногоDataGridViewTextBoxColumn.Width = 96;
            // 
            // местонахождениеDataGridViewTextBoxColumn
            // 
            this.местонахождениеDataGridViewTextBoxColumn.DataPropertyName = "Местонахождение";
            this.местонахождениеDataGridViewTextBoxColumn.HeaderText = "Местонахождение";
            this.местонахождениеDataGridViewTextBoxColumn.Name = "местонахождениеDataGridViewTextBoxColumn";
            this.местонахождениеDataGridViewTextBoxColumn.ReadOnly = true;
            this.местонахождениеDataGridViewTextBoxColumn.Width = 125;
            // 
            // складDataGridViewTextBoxColumn
            // 
            this.складDataGridViewTextBoxColumn.DataPropertyName = "Склад";
            this.складDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.складDataGridViewTextBoxColumn.Name = "складDataGridViewTextBoxColumn";
            this.складDataGridViewTextBoxColumn.ReadOnly = true;
            this.складDataGridViewTextBoxColumn.Width = 63;
            // 
            // wfgetibdocdetailsBindingSource
            // 
            this.wfgetibdocdetailsBindingSource.DataMember = "wf_get_ib_doc_details";
            this.wfgetibdocdetailsBindingSource.DataSource = this.wF;
            // 
            // wf_get_ib_docsTableAdapter
            // 
            this.wf_get_ib_docsTableAdapter.ClearBeforeFill = true;
            // 
            // wf_get_ib_doc_detailsTableAdapter
            // 
            this.wf_get_ib_doc_detailsTableAdapter.ClearBeforeFill = true;
            // 
            // OptionsPakSheetsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 567);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "OptionsPakSheetsWindow";
            this.Text = "OptionsPakSheetsWindows";
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.pnlFilter, 0);
            this.Controls.SetChildIndex(this.splitContainer1, 0);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wfgetibdocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wfgetibdocdetailsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox pnlFilter;
        private System.Windows.Forms.TextBox tbItemCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateFrom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrint;
        private System.Windows.Forms.ToolStripButton btnOpenDoc;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.DataGridView dgvDocLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn паклистаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаЗакрытияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn статусDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеСтатусаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодСотрудникаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сотрудникDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn измененDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource wfgetibdocsBindingSource;
        private WMSOffice.Data.WF wF;
        private WMSOffice.Data.WFTableAdapters.wf_get_ib_docsTableAdapter wf_get_ib_docsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодТовараDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn наименованиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn производительDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn серияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn партияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn количествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn паклистаDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn макетаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn заявкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаЗаявкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn сборочногоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn местонахождениеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn складDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource wfgetibdocdetailsBindingSource;
        private WMSOffice.Data.WFTableAdapters.wf_get_ib_doc_detailsTableAdapter wf_get_ib_doc_detailsTableAdapter;
        private System.Windows.Forms.CheckBox checkBox;
    }
}