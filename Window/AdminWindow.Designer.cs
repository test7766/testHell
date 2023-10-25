namespace WMSOffice.Window
{
    partial class AdminWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminWindow));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lvModules = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gvDocTypes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docMCUDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wHDocsTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.admin = new WMSOffice.Data.Admin();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gvEmployees = new System.Windows.Forms.DataGridView();
            this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAccess = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miAccessAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.miAccessSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.miAccessRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbSearchEmployee = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gvAccess = new System.Windows.Forms.DataGridView();
            this.employeeIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isAccesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.entityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.entityValueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessModule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessDocTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAccessDocTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accessBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripAccess = new System.Windows.Forms.ToolStrip();
            this.btnAccessAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAccessSave = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageAccess = new System.Windows.Forms.TabPage();
            this.tabPagePCPrinters = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pCPrinterSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripPCPrinterSettings = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbPCPriterFilter = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPCPrinterSettingsSave = new System.Windows.Forms.ToolStripButton();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.gvSettings = new System.Windows.Forms.DataGridView();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autoPutawayFlagDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.disableBoxCheckDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RegistrationPSN = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.wMSSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripSettings = new System.Windows.Forms.ToolStrip();
            this.btnSaveSettings = new System.Windows.Forms.ToolStripButton();
            this.employeesTableAdapter = new WMSOffice.Data.AdminTableAdapters.EmployeesTableAdapter();
            this.wH_Docs_TypeTableAdapter = new WMSOffice.Data.AdminTableAdapters.WH_Docs_TypeTableAdapter();
            this.accessTableAdapter = new WMSOffice.Data.AdminTableAdapters.AccessTableAdapter();
            this.pC_Printer_SettingTableAdapter = new WMSOffice.Data.AdminTableAdapters.PC_Printer_SettingTableAdapter();
            this.wMS_SettingTableAdapter = new WMSOffice.Data.AdminTableAdapters.WMS_SettingTableAdapter();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnUndo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bUsers = new System.Windows.Forms.ToolStripButton();
            this.bRoles = new System.Windows.Forms.ToolStripButton();
            this.bResources = new System.Windows.Forms.ToolStripButton();
            this.bEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bQuiz = new System.Windows.Forms.ToolStripButton();
            this.bUpgradeControl = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bDeviceConfigurationSettings = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wHDocsTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployees)).BeginInit();
            this.cmAccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessBindingSource)).BeginInit();
            this.toolStripAccess.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageAccess.SuspendLayout();
            this.tabPagePCPrinters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPrinterSettingBindingSource)).BeginInit();
            this.toolStripPCPrinterSettings.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMSSettingBindingSource)).BeginInit();
            this.toolStripSettings.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(849, 319);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lvModules);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gvDocTypes);
            this.splitContainer2.Size = new System.Drawing.Size(849, 161);
            this.splitContainer2.SplitterDistance = 194;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // lvModules
            // 
            this.lvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.lvModules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvModules.FullRowSelect = true;
            this.lvModules.HideSelection = false;
            this.lvModules.Location = new System.Drawing.Point(0, 0);
            this.lvModules.MultiSelect = false;
            this.lvModules.Name = "lvModules";
            this.lvModules.Size = new System.Drawing.Size(194, 161);
            this.lvModules.TabIndex = 2;
            this.lvModules.UseCompatibleStateImageBehavior = false;
            this.lvModules.View = System.Windows.Forms.View.Details;
            this.lvModules.SelectedIndexChanged += new System.EventHandler(this.lvModules_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Модуль WMS";
            this.columnHeader2.Width = 160;
            // 
            // gvDocTypes
            // 
            this.gvDocTypes.AllowUserToAddRows = false;
            this.gvDocTypes.AllowUserToDeleteRows = false;
            this.gvDocTypes.AllowUserToResizeRows = false;
            this.gvDocTypes.AutoGenerateColumns = false;
            this.gvDocTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gvDocTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.docTypeIDDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.docMCUDataGridViewTextBoxColumn});
            this.gvDocTypes.DataSource = this.wHDocsTypeBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvDocTypes.DefaultCellStyle = dataGridViewCellStyle1;
            this.gvDocTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvDocTypes.Location = new System.Drawing.Point(0, 0);
            this.gvDocTypes.MultiSelect = false;
            this.gvDocTypes.Name = "gvDocTypes";
            this.gvDocTypes.ReadOnly = true;
            this.gvDocTypes.RowHeadersVisible = false;
            this.gvDocTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvDocTypes.Size = new System.Drawing.Size(650, 161);
            this.gvDocTypes.TabIndex = 5;
            this.gvDocTypes.SelectionChanged += new System.EventHandler(this.gvDocTypes_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.DataPropertyName = "Module_id";
            this.Column1.HeaderText = "Модуль";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Column1.Width = 76;
            // 
            // docTypeIDDataGridViewTextBoxColumn
            // 
            this.docTypeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_ID";
            this.docTypeIDDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeIDDataGridViewTextBoxColumn.Name = "docTypeIDDataGridViewTextBoxColumn";
            this.docTypeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.docTypeIDDataGridViewTextBoxColumn.Width = 53;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Наименование типа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.docTypeNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.docTypeNameDataGridViewTextBoxColumn.Width = 138;
            // 
            // docMCUDataGridViewTextBoxColumn
            // 
            this.docMCUDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docMCUDataGridViewTextBoxColumn.DataPropertyName = "Doc_MCU";
            this.docMCUDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.docMCUDataGridViewTextBoxColumn.Name = "docMCUDataGridViewTextBoxColumn";
            this.docMCUDataGridViewTextBoxColumn.ReadOnly = true;
            this.docMCUDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.docMCUDataGridViewTextBoxColumn.Width = 78;
            // 
            // wHDocsTypeBindingSource
            // 
            this.wHDocsTypeBindingSource.DataMember = "WH_Docs_Type";
            this.wHDocsTypeBindingSource.DataSource = this.admin;
            this.wHDocsTypeBindingSource.Sort = "Module_id, Sequence";
            // 
            // admin
            // 
            this.admin.DataSetName = "Admin";
            this.admin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gvEmployees);
            this.splitContainer3.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.gvAccess);
            this.splitContainer3.Panel2.Controls.Add(this.toolStripAccess);
            this.splitContainer3.Size = new System.Drawing.Size(849, 153);
            this.splitContainer3.SplitterDistance = 281;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // gvEmployees
            // 
            this.gvEmployees.AllowUserToAddRows = false;
            this.gvEmployees.AllowUserToDeleteRows = false;
            this.gvEmployees.AllowUserToResizeRows = false;
            this.gvEmployees.AutoGenerateColumns = false;
            this.gvEmployees.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvEmployees.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.gvEmployees.ContextMenuStrip = this.cmAccess;
            this.gvEmployees.DataSource = this.employeesBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvEmployees.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvEmployees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvEmployees.Location = new System.Drawing.Point(0, 23);
            this.gvEmployees.Name = "gvEmployees";
            this.gvEmployees.ReadOnly = true;
            this.gvEmployees.RowHeadersVisible = false;
            this.gvEmployees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvEmployees.Size = new System.Drawing.Size(281, 130);
            this.gvEmployees.TabIndex = 3;
            this.gvEmployees.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvEmployees_CellContentDoubleClick);
            this.gvEmployees.SelectionChanged += new System.EventHandler(this.gvEmployees_SelectionChanged);
            // 
            // employeeIDDataGridViewTextBoxColumn
            // 
            this.employeeIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
            this.employeeIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn.Width = 54;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "ФИО";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Width = 61;
            // 
            // cmAccess
            // 
            this.cmAccess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miAccessAdd,
            this.miAccessSave,
            this.toolStripSeparator3,
            this.miAccessRefresh});
            this.cmAccess.Name = "cmAccess";
            this.cmAccess.Size = new System.Drawing.Size(224, 76);
            // 
            // miAccessAdd
            // 
            this.miAccessAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.miAccessAdd.Name = "miAccessAdd";
            this.miAccessAdd.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miAccessAdd.Size = new System.Drawing.Size(223, 22);
            this.miAccessAdd.Text = "&Добавить доступ";
            this.miAccessAdd.Click += new System.EventHandler(this.btnAccessAdd_Click);
            // 
            // miAccessSave
            // 
            this.miAccessSave.Image = global::WMSOffice.Properties.Resources.save;
            this.miAccessSave.Name = "miAccessSave";
            this.miAccessSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.miAccessSave.Size = new System.Drawing.Size(223, 22);
            this.miAccessSave.Text = "&Сохранить изменения";
            this.miAccessSave.Click += new System.EventHandler(this.btnAccessSave_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(220, 6);
            // 
            // miAccessRefresh
            // 
            this.miAccessRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miAccessRefresh.Name = "miAccessRefresh";
            this.miAccessRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miAccessRefresh.Size = new System.Drawing.Size(223, 22);
            this.miAccessRefresh.Text = "&Обновить";
            this.miAccessRefresh.Click += new System.EventHandler(this.miAccessRefresh_Click);
            // 
            // employeesBindingSource
            // 
            this.employeesBindingSource.DataMember = "Employees";
            this.employeesBindingSource.DataSource = this.admin;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbSearchEmployee);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(281, 23);
            this.panel1.TabIndex = 2;
            // 
            // tbSearchEmployee
            // 
            this.tbSearchEmployee.ContextMenuStrip = this.cmAccess;
            this.tbSearchEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbSearchEmployee.Location = new System.Drawing.Point(34, 0);
            this.tbSearchEmployee.Name = "tbSearchEmployee";
            this.tbSearchEmployee.Size = new System.Drawing.Size(247, 21);
            this.tbSearchEmployee.TabIndex = 1;
            this.tbSearchEmployee.TextChanged += new System.EventHandler(this.tbSearchEmployee_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::WMSOffice.Properties.Resources.find;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // gvAccess
            // 
            this.gvAccess.AllowUserToAddRows = false;
            this.gvAccess.AllowUserToResizeRows = false;
            this.gvAccess.AutoGenerateColumns = false;
            this.gvAccess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAccess.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeIDDataGridViewTextBoxColumn1,
            this.Employee,
            this.isAccesDataGridViewCheckBoxColumn,
            this.entityDataGridViewTextBoxColumn,
            this.entityValueDataGridViewTextBoxColumn,
            this.colAccessModule,
            this.colAccessDocTypeID,
            this.colAccessDocTypeName});
            this.gvAccess.ContextMenuStrip = this.cmAccess;
            this.gvAccess.DataSource = this.accessBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvAccess.DefaultCellStyle = dataGridViewCellStyle3;
            this.gvAccess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAccess.Location = new System.Drawing.Point(0, 25);
            this.gvAccess.Name = "gvAccess";
            this.gvAccess.RowHeadersVisible = false;
            this.gvAccess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAccess.Size = new System.Drawing.Size(563, 128);
            this.gvAccess.TabIndex = 5;
            // 
            // employeeIDDataGridViewTextBoxColumn1
            // 
            this.employeeIDDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.employeeIDDataGridViewTextBoxColumn1.DataPropertyName = "Employee_ID";
            this.employeeIDDataGridViewTextBoxColumn1.HeaderText = "Код";
            this.employeeIDDataGridViewTextBoxColumn1.Name = "employeeIDDataGridViewTextBoxColumn1";
            this.employeeIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.employeeIDDataGridViewTextBoxColumn1.Width = 54;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Сотрудник";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.Width = 93;
            // 
            // isAccesDataGridViewCheckBoxColumn
            // 
            this.isAccesDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isAccesDataGridViewCheckBoxColumn.DataPropertyName = "Is_Acces";
            this.isAccesDataGridViewCheckBoxColumn.HeaderText = "Дост.";
            this.isAccesDataGridViewCheckBoxColumn.Name = "isAccesDataGridViewCheckBoxColumn";
            this.isAccesDataGridViewCheckBoxColumn.Width = 45;
            // 
            // entityDataGridViewTextBoxColumn
            // 
            this.entityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.entityDataGridViewTextBoxColumn.DataPropertyName = "Entity";
            this.entityDataGridViewTextBoxColumn.HeaderText = "Сущность";
            this.entityDataGridViewTextBoxColumn.Name = "entityDataGridViewTextBoxColumn";
            this.entityDataGridViewTextBoxColumn.Width = 88;
            // 
            // entityValueDataGridViewTextBoxColumn
            // 
            this.entityValueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.entityValueDataGridViewTextBoxColumn.DataPropertyName = "Entity_Value";
            this.entityValueDataGridViewTextBoxColumn.HeaderText = "Значение";
            this.entityValueDataGridViewTextBoxColumn.Name = "entityValueDataGridViewTextBoxColumn";
            this.entityValueDataGridViewTextBoxColumn.Width = 88;
            // 
            // colAccessModule
            // 
            this.colAccessModule.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccessModule.DataPropertyName = "Module_ID";
            this.colAccessModule.HeaderText = "Модуль";
            this.colAccessModule.Name = "colAccessModule";
            this.colAccessModule.ReadOnly = true;
            this.colAccessModule.Visible = false;
            // 
            // colAccessDocTypeID
            // 
            this.colAccessDocTypeID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccessDocTypeID.DataPropertyName = "Doc_Type";
            this.colAccessDocTypeID.HeaderText = "Тип";
            this.colAccessDocTypeID.Name = "colAccessDocTypeID";
            this.colAccessDocTypeID.ReadOnly = true;
            this.colAccessDocTypeID.Visible = false;
            // 
            // colAccessDocTypeName
            // 
            this.colAccessDocTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colAccessDocTypeName.DataPropertyName = "Doc_Type_Name";
            this.colAccessDocTypeName.HeaderText = "Тип документа WMS";
            this.colAccessDocTypeName.Name = "colAccessDocTypeName";
            this.colAccessDocTypeName.ReadOnly = true;
            this.colAccessDocTypeName.Visible = false;
            // 
            // accessBindingSource
            // 
            this.accessBindingSource.DataMember = "Access";
            this.accessBindingSource.DataSource = this.admin;
            // 
            // toolStripAccess
            // 
            this.toolStripAccess.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAccessAdd,
            this.toolStripSeparator2,
            this.btnAccessSave});
            this.toolStripAccess.Location = new System.Drawing.Point(0, 0);
            this.toolStripAccess.Name = "toolStripAccess";
            this.toolStripAccess.Size = new System.Drawing.Size(563, 25);
            this.toolStripAccess.TabIndex = 6;
            this.toolStripAccess.Text = "toolStrip1";
            // 
            // btnAccessAdd
            // 
            this.btnAccessAdd.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAccessAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccessAdd.Name = "btnAccessAdd";
            this.btnAccessAdd.Size = new System.Drawing.Size(116, 22);
            this.btnAccessAdd.Text = "Добавить доступ";
            this.btnAccessAdd.ToolTipText = "Добавить доступ текущего пользователя к текущему типу документа";
            this.btnAccessAdd.Click += new System.EventHandler(this.btnAccessAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAccessSave
            // 
            this.btnAccessSave.Image = global::WMSOffice.Properties.Resources.save;
            this.btnAccessSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccessSave.Name = "btnAccessSave";
            this.btnAccessSave.Size = new System.Drawing.Size(138, 22);
            this.btnAccessSave.Text = "Сохранить изменения";
            this.btnAccessSave.Click += new System.EventHandler(this.btnAccessSave_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageAccess);
            this.tabControl.Controls.Add(this.tabPagePCPrinters);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 95);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(863, 353);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageAccess
            // 
            this.tabPageAccess.Controls.Add(this.splitContainer1);
            this.tabPageAccess.Location = new System.Drawing.Point(4, 24);
            this.tabPageAccess.Name = "tabPageAccess";
            this.tabPageAccess.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccess.Size = new System.Drawing.Size(855, 325);
            this.tabPageAccess.TabIndex = 0;
            this.tabPageAccess.Text = "Права доступа";
            this.tabPageAccess.UseVisualStyleBackColor = true;
            // 
            // tabPagePCPrinters
            // 
            this.tabPagePCPrinters.Controls.Add(this.dataGridView2);
            this.tabPagePCPrinters.Controls.Add(this.toolStripPCPrinterSettings);
            this.tabPagePCPrinters.Location = new System.Drawing.Point(4, 24);
            this.tabPagePCPrinters.Name = "tabPagePCPrinters";
            this.tabPagePCPrinters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePCPrinters.Size = new System.Drawing.Size(855, 325);
            this.tabPagePCPrinters.TabIndex = 1;
            this.tabPagePCPrinters.Text = "Принтеры контроля сборки";
            this.tabPagePCPrinters.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.printerIDDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.pCPrinterSettingBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(849, 294);
            this.dataGridView2.TabIndex = 0;
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "User_ID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "Логин пользователя";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 139;
            // 
            // printerIDDataGridViewTextBoxColumn
            // 
            this.printerIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.printerIDDataGridViewTextBoxColumn.DataPropertyName = "Printer_ID";
            this.printerIDDataGridViewTextBoxColumn.HeaderText = "Идентификатор принтера";
            this.printerIDDataGridViewTextBoxColumn.Name = "printerIDDataGridViewTextBoxColumn";
            this.printerIDDataGridViewTextBoxColumn.Width = 170;
            // 
            // pCPrinterSettingBindingSource
            // 
            this.pCPrinterSettingBindingSource.DataMember = "PC_Printer_Setting";
            this.pCPrinterSettingBindingSource.DataSource = this.admin;
            // 
            // toolStripPCPrinterSettings
            // 
            this.toolStripPCPrinterSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tbPCPriterFilter,
            this.toolStripSeparator1,
            this.btnPCPrinterSettingsSave});
            this.toolStripPCPrinterSettings.Location = new System.Drawing.Point(3, 3);
            this.toolStripPCPrinterSettings.Name = "toolStripPCPrinterSettings";
            this.toolStripPCPrinterSettings.Size = new System.Drawing.Size(849, 25);
            this.toolStripPCPrinterSettings.TabIndex = 1;
            this.toolStripPCPrinterSettings.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(49, 22);
            this.toolStripLabel1.Text = "Фильтр:";
            // 
            // tbPCPriterFilter
            // 
            this.tbPCPriterFilter.Name = "tbPCPriterFilter";
            this.tbPCPriterFilter.Size = new System.Drawing.Size(100, 25);
            this.tbPCPriterFilter.TextChanged += new System.EventHandler(this.tbPCPriterFilter_TextChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPCPrinterSettingsSave
            // 
            this.btnPCPrinterSettingsSave.Image = global::WMSOffice.Properties.Resources.save;
            this.btnPCPrinterSettingsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPCPrinterSettingsSave.Name = "btnPCPrinterSettingsSave";
            this.btnPCPrinterSettingsSave.Size = new System.Drawing.Size(138, 22);
            this.btnPCPrinterSettingsSave.Text = "Сохранить изменения";
            this.btnPCPrinterSettingsSave.Click += new System.EventHandler(this.btnPCPrinterSettingsSave_Click);
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.gvSettings);
            this.tabPageSettings.Controls.Add(this.toolStripSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 24);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(855, 325);
            this.tabPageSettings.TabIndex = 2;
            this.tabPageSettings.Text = "Настройки WMS";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // gvSettings
            // 
            this.gvSettings.AutoGenerateColumns = false;
            this.gvSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.warehouseIDDataGridViewTextBoxColumn,
            this.autoPutawayFlagDataGridViewCheckBoxColumn,
            this.disableBoxCheckDataGridViewCheckBoxColumn,
            this.RegistrationPSN});
            this.gvSettings.DataSource = this.wMSSettingBindingSource;
            this.gvSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvSettings.Location = new System.Drawing.Point(3, 28);
            this.gvSettings.Name = "gvSettings";
            this.gvSettings.Size = new System.Drawing.Size(849, 294);
            this.gvSettings.TabIndex = 3;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_ID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "ID филиала";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.Width = 92;
            // 
            // autoPutawayFlagDataGridViewCheckBoxColumn
            // 
            this.autoPutawayFlagDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.autoPutawayFlagDataGridViewCheckBoxColumn.DataPropertyName = "AutoPutawayFlag";
            this.autoPutawayFlagDataGridViewCheckBoxColumn.HeaderText = "Авто-размещение";
            this.autoPutawayFlagDataGridViewCheckBoxColumn.Name = "autoPutawayFlagDataGridViewCheckBoxColumn";
            this.autoPutawayFlagDataGridViewCheckBoxColumn.Width = 118;
            // 
            // disableBoxCheckDataGridViewCheckBoxColumn
            // 
            this.disableBoxCheckDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.disableBoxCheckDataGridViewCheckBoxColumn.DataPropertyName = "DisableBoxCheck";
            this.disableBoxCheckDataGridViewCheckBoxColumn.HeaderText = "Отключить контроль ящиков";
            this.disableBoxCheckDataGridViewCheckBoxColumn.Name = "disableBoxCheckDataGridViewCheckBoxColumn";
            this.disableBoxCheckDataGridViewCheckBoxColumn.Width = 125;
            // 
            // RegistrationPSN
            // 
            this.RegistrationPSN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RegistrationPSN.DataPropertyName = "RegistrationPSN";
            this.RegistrationPSN.HeaderText = "Не конвеерная сборка";
            this.RegistrationPSN.Name = "RegistrationPSN";
            this.RegistrationPSN.Width = 130;
            // 
            // wMSSettingBindingSource
            // 
            this.wMSSettingBindingSource.DataMember = "WMS_Setting";
            this.wMSSettingBindingSource.DataSource = this.admin;
            // 
            // toolStripSettings
            // 
            this.toolStripSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSaveSettings});
            this.toolStripSettings.Location = new System.Drawing.Point(3, 3);
            this.toolStripSettings.Name = "toolStripSettings";
            this.toolStripSettings.Size = new System.Drawing.Size(849, 25);
            this.toolStripSettings.TabIndex = 2;
            this.toolStripSettings.Text = "toolStrip1";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Image = global::WMSOffice.Properties.Resources.save;
            this.btnSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(138, 22);
            this.btnSaveSettings.Text = "Сохранить изменения";
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // employeesTableAdapter
            // 
            this.employeesTableAdapter.ClearBeforeFill = true;
            // 
            // wH_Docs_TypeTableAdapter
            // 
            this.wH_Docs_TypeTableAdapter.ClearBeforeFill = true;
            // 
            // accessTableAdapter
            // 
            this.accessTableAdapter.ClearBeforeFill = true;
            // 
            // pC_Printer_SettingTableAdapter
            // 
            this.pC_Printer_SettingTableAdapter.ClearBeforeFill = true;
            // 
            // wMS_SettingTableAdapter
            // 
            this.wMS_SettingTableAdapter.ClearBeforeFill = true;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUndo,
            this.toolStripSeparator4,
            this.bUsers,
            this.bRoles,
            this.bResources,
            this.bEntities,
            this.toolStripSeparator5,
            this.bQuiz,
            this.bUpgradeControl,
            this.toolStripSeparator6,
            this.toolStripSeparator7,
            this.bDeviceConfigurationSettings});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(863, 55);
            this.toolStripDoc.TabIndex = 6;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnUndo
            // 
            this.btnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUndo.Enabled = false;
            this.btnUndo.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(52, 52);
            this.btnUndo.Text = "Отменить последнее действие";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // bUsers
            // 
            this.bUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bUsers.Enabled = false;
            this.bUsers.Image = global::WMSOffice.Properties.Resources.user;
            this.bUsers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUsers.Name = "bUsers";
            this.bUsers.Size = new System.Drawing.Size(52, 52);
            this.bUsers.Text = "Пользователи";
            this.bUsers.Click += new System.EventHandler(this.bUsers_Click);
            // 
            // bRoles
            // 
            this.bRoles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bRoles.Enabled = false;
            this.bRoles.Image = global::WMSOffice.Properties.Resources.role;
            this.bRoles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bRoles.Name = "bRoles";
            this.bRoles.Size = new System.Drawing.Size(52, 52);
            this.bRoles.Text = "Роли";
            this.bRoles.Click += new System.EventHandler(this.bRoles_Click);
            // 
            // bResources
            // 
            this.bResources.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bResources.Enabled = false;
            this.bResources.Image = global::WMSOffice.Properties.Resources.resource;
            this.bResources.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bResources.Name = "bResources";
            this.bResources.Size = new System.Drawing.Size(52, 52);
            this.bResources.Text = "Ресурсы";
            this.bResources.Click += new System.EventHandler(this.bResources_Click);
            // 
            // bEntities
            // 
            this.bEntities.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bEntities.Enabled = false;
            this.bEntities.Image = global::WMSOffice.Properties.Resources.entity;
            this.bEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bEntities.Name = "bEntities";
            this.bEntities.Size = new System.Drawing.Size(52, 52);
            this.bEntities.Text = "Сущности";
            this.bEntities.Click += new System.EventHandler(this.bEntities_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // bQuiz
            // 
            this.bQuiz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bQuiz.Enabled = false;
            this.bQuiz.Image = ((System.Drawing.Image)(resources.GetObject("bQuiz.Image")));
            this.bQuiz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bQuiz.Name = "bQuiz";
            this.bQuiz.Size = new System.Drawing.Size(52, 52);
            this.bQuiz.Text = "Опросы";
            this.bQuiz.Click += new System.EventHandler(this.bQuiz_Click);
            // 
            // bUpgradeControl
            // 
            this.bUpgradeControl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.bUpgradeControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bUpgradeControl.Enabled = false;
            this.bUpgradeControl.Image = global::WMSOffice.Properties.Resources.upgrade;
            this.bUpgradeControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bUpgradeControl.Name = "bUpgradeControl";
            this.bUpgradeControl.Size = new System.Drawing.Size(52, 52);
            this.bUpgradeControl.Text = "Контроль версий";
            this.bUpgradeControl.Click += new System.EventHandler(this.bUpgradeControl_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // bDeviceConfigurationSettings
            // 
            this.bDeviceConfigurationSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bDeviceConfigurationSettings.Enabled = false;
            this.bDeviceConfigurationSettings.Image = global::WMSOffice.Properties.Resources.settings;
            this.bDeviceConfigurationSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bDeviceConfigurationSettings.Name = "bDeviceConfigurationSettings";
            this.bDeviceConfigurationSettings.Size = new System.Drawing.Size(52, 52);
            this.bDeviceConfigurationSettings.Text = "Настройка конфигурации внешних цифровых устройств";
            this.bDeviceConfigurationSettings.Click += new System.EventHandler(this.bDigitalWeigherConfigurationSettings_Click);
            // 
            // AdminWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 448);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStripDoc);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "AdminWindow";
            this.Text = "Администрирование WMS";
            this.Load += new System.EventHandler(this.AdminWindow_Load);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.tabControl, 0);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wHDocsTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvEmployees)).EndInit();
            this.cmAccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.employeesBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accessBindingSource)).EndInit();
            this.toolStripAccess.ResumeLayout(false);
            this.toolStripAccess.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageAccess.ResumeLayout(false);
            this.tabPagePCPrinters.ResumeLayout(false);
            this.tabPagePCPrinters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pCPrinterSettingBindingSource)).EndInit();
            this.toolStripPCPrinterSettings.ResumeLayout(false);
            this.toolStripPCPrinterSettings.PerformLayout();
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMSSettingBindingSource)).EndInit();
            this.toolStripSettings.ResumeLayout(false);
            this.toolStripSettings.PerformLayout();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSearchEmployee;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView gvEmployees;
        private WMSOffice.Data.Admin admin;
        private System.Windows.Forms.BindingSource employeesBindingSource;
        private WMSOffice.Data.AdminTableAdapters.EmployeesTableAdapter employeesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource wHDocsTypeBindingSource;
        private WMSOffice.Data.AdminTableAdapters.WH_Docs_TypeTableAdapter wH_Docs_TypeTableAdapter;
        private System.Windows.Forms.BindingSource accessBindingSource;
        private WMSOffice.Data.AdminTableAdapters.AccessTableAdapter accessTableAdapter;
        private System.Windows.Forms.ListView lvModules;
        private System.Windows.Forms.DataGridView gvDocTypes;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docMCUDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageAccess;
        private System.Windows.Forms.TabPage tabPagePCPrinters;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource pCPrinterSettingBindingSource;
        private WMSOffice.Data.AdminTableAdapters.PC_Printer_SettingTableAdapter pC_Printer_SettingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn printerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStrip toolStripPCPrinterSettings;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbPCPriterFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPCPrinterSettingsSave;
        private System.Windows.Forms.DataGridView gvAccess;
        private System.Windows.Forms.ToolStrip toolStripAccess;
        private System.Windows.Forms.ToolStripButton btnAccessSave;
        private System.Windows.Forms.ToolStripButton btnAccessAdd;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isAccesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn entityValueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessModule;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessDocTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAccessDocTypeName;
        private System.Windows.Forms.ContextMenuStrip cmAccess;
        private System.Windows.Forms.ToolStripMenuItem miAccessAdd;
        private System.Windows.Forms.ToolStripMenuItem miAccessSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem miAccessRefresh;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.DataGridView gvSettings;
        private System.Windows.Forms.ToolStrip toolStripSettings;
        private System.Windows.Forms.ToolStripButton btnSaveSettings;
        private System.Windows.Forms.BindingSource wMSSettingBindingSource;
        private WMSOffice.Data.AdminTableAdapters.WMS_SettingTableAdapter wMS_SettingTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn autoPutawayFlagDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn disableBoxCheckDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RegistrationPSN;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnUndo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton bUsers;
        private System.Windows.Forms.ToolStripButton bRoles;
        private System.Windows.Forms.ToolStripButton bResources;
        private System.Windows.Forms.ToolStripButton bEntities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton bQuiz;
        private System.Windows.Forms.ToolStripButton bUpgradeControl;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton bDeviceConfigurationSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;

    }
}