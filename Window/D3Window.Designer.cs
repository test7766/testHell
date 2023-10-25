namespace WMSOffice.Window
{
    partial class D3Window
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(D3Window));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerView = new System.Windows.Forms.SplitContainer();
            this.viewD3 = new WMSOffice.Controls.D3.View();
            this.tabControlInfo = new System.Windows.Forms.TabControl();
            this.tabPageLegend = new System.Windows.Forms.TabPage();
            this.splitContainerInfo = new System.Windows.Forms.SplitContainer();
            this.gvLegend = new System.Windows.Forms.DataGridView();
            this.colImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.countDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.percentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.d3 = new WMSOffice.Data.D3();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.splitContainerProperties = new System.Windows.Forms.SplitContainer();
            this.viewObject = new WMSOffice.Controls.D3.View();
            this.pnlSelectedObjects = new System.Windows.Forms.FlowLayoutPanel();
            this.editObjectProperties = new WMSOffice.Controls.D3.EditPropertiesControl();
            this.toolStripEditObject = new System.Windows.Forms.ToolStrip();
            this.btnAddObject = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAddSector = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddRack = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddPlace = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddParentSector = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDeleteObject = new System.Windows.Forms.ToolStripButton();
            this.tabPageRoutes = new System.Windows.Forms.TabPage();
            this.editRouteControl = new WMSOffice.Controls.D3.EditPropertiesControl();
            this.groupRoutes = new System.Windows.Forms.GroupBox();
            this.lbRoutes = new System.Windows.Forms.ListBox();
            this.routesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripRoutes = new System.Windows.Forms.ToolStrip();
            this.btnAddRoute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditRoute = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteRoute = new System.Windows.Forms.ToolStripButton();
            this.groupRouteMaps = new System.Windows.Forms.GroupBox();
            this.lbRoutePlans = new System.Windows.Forms.ListBox();
            this.routePlansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStripRoutePlans = new System.Windows.Forms.ToolStrip();
            this.btnAddRoutePlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEditRoutePlan = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteRoutePlan = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.miNoReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.miViewSectors = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewRacks = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewPlaces = new System.Windows.Forms.ToolStripMenuItem();
            this.miViewRoutes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cbSectors = new System.Windows.Forms.ComboBox();
            this.cbWarehouses = new System.Windows.Forms.ComboBox();
            this.warehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.sectorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.warehousesTableAdapter = new WMSOffice.Data.D3TableAdapters.WarehousesTableAdapter();
            this.sectorsTableAdapter = new WMSOffice.Data.D3TableAdapters.SectorsTableAdapter();
            this.legendTableAdapter = new WMSOffice.Data.D3TableAdapters.LegendTableAdapter();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routesTableAdapter = new WMSOffice.Data.D3TableAdapters.RoutesTableAdapter();
            this.routePlansTableAdapter = new WMSOffice.Data.D3TableAdapters.RoutePlansTableAdapter();
            this.cmWarehouse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExportPlacesToJDE = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRoutePlans = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miExportRoutePlanToJDE = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainerView.Panel1.SuspendLayout();
            this.splitContainerView.Panel2.SuspendLayout();
            this.splitContainerView.SuspendLayout();
            this.tabControlInfo.SuspendLayout();
            this.tabPageLegend.SuspendLayout();
            this.splitContainerInfo.Panel1.SuspendLayout();
            this.splitContainerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvLegend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.legendBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).BeginInit();
            this.tabPageProperties.SuspendLayout();
            this.splitContainerProperties.Panel1.SuspendLayout();
            this.splitContainerProperties.Panel2.SuspendLayout();
            this.splitContainerProperties.SuspendLayout();
            this.toolStripEditObject.SuspendLayout();
            this.tabPageRoutes.SuspendLayout();
            this.groupRoutes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).BeginInit();
            this.toolStripRoutes.SuspendLayout();
            this.groupRouteMaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routePlansBindingSource)).BeginInit();
            this.toolStripRoutePlans.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).BeginInit();
            this.cmWarehouse.SuspendLayout();
            this.cmRoutePlans.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerView
            // 
            this.splitContainerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerView.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainerView.Location = new System.Drawing.Point(0, 75);
            this.splitContainerView.Name = "splitContainerView";
            // 
            // splitContainerView.Panel1
            // 
            this.splitContainerView.Panel1.Controls.Add(this.viewD3);
            // 
            // splitContainerView.Panel2
            // 
            this.splitContainerView.Panel2.Controls.Add(this.tabControlInfo);
            this.splitContainerView.Panel2MinSize = 0;
            this.splitContainerView.Size = new System.Drawing.Size(863, 313);
            this.splitContainerView.SplitterDistance = 656;
            this.splitContainerView.TabIndex = 2;
            // 
            // viewD3
            // 
            this.viewD3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewD3.Location = new System.Drawing.Point(0, 0);
            this.viewD3.MaxBitmapSize = 16777216;
            this.viewD3.Name = "viewD3";
            this.viewD3.Size = new System.Drawing.Size(656, 313);
            this.viewD3.Source = null;
            this.viewD3.TabIndex = 0;
            this.viewD3.ObjectSelected += new WMSOffice.Controls.D3.ObjectSelectionHandler(this.viewD3_ObjectSelected);
            // 
            // tabControlInfo
            // 
            this.tabControlInfo.Controls.Add(this.tabPageLegend);
            this.tabControlInfo.Controls.Add(this.tabPageProperties);
            this.tabControlInfo.Controls.Add(this.tabPageRoutes);
            this.tabControlInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlInfo.Location = new System.Drawing.Point(0, 0);
            this.tabControlInfo.Multiline = true;
            this.tabControlInfo.Name = "tabControlInfo";
            this.tabControlInfo.SelectedIndex = 0;
            this.tabControlInfo.Size = new System.Drawing.Size(203, 313);
            this.tabControlInfo.TabIndex = 1;
            // 
            // tabPageLegend
            // 
            this.tabPageLegend.Controls.Add(this.splitContainerInfo);
            this.tabPageLegend.Location = new System.Drawing.Point(4, 22);
            this.tabPageLegend.Name = "tabPageLegend";
            this.tabPageLegend.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLegend.Size = new System.Drawing.Size(195, 287);
            this.tabPageLegend.TabIndex = 0;
            this.tabPageLegend.Text = "Описание";
            this.tabPageLegend.UseVisualStyleBackColor = true;
            // 
            // splitContainerInfo
            // 
            this.splitContainerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerInfo.Location = new System.Drawing.Point(3, 3);
            this.splitContainerInfo.Name = "splitContainerInfo";
            this.splitContainerInfo.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerInfo.Panel1
            // 
            this.splitContainerInfo.Panel1.Controls.Add(this.gvLegend);
            this.splitContainerInfo.Size = new System.Drawing.Size(189, 281);
            this.splitContainerInfo.SplitterDistance = 242;
            this.splitContainerInfo.TabIndex = 0;
            // 
            // gvLegend
            // 
            this.gvLegend.AllowUserToAddRows = false;
            this.gvLegend.AllowUserToDeleteRows = false;
            this.gvLegend.AllowUserToResizeRows = false;
            this.gvLegend.AutoGenerateColumns = false;
            this.gvLegend.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gvLegend.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLegend.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gvLegend.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvLegend.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colImage,
            this.countDataGridViewTextBoxColumn,
            this.percentDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn});
            this.gvLegend.DataSource = this.legendBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvLegend.DefaultCellStyle = dataGridViewCellStyle4;
            this.gvLegend.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvLegend.GridColor = System.Drawing.SystemColors.Control;
            this.gvLegend.Location = new System.Drawing.Point(0, 0);
            this.gvLegend.Name = "gvLegend";
            this.gvLegend.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gvLegend.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.gvLegend.RowHeadersVisible = false;
            this.gvLegend.RowTemplate.Height = 30;
            this.gvLegend.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvLegend.Size = new System.Drawing.Size(189, 242);
            this.gvLegend.TabIndex = 1;
            this.gvLegend.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.gvLegend_DataBindingComplete);
            // 
            // colImage
            // 
            this.colImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImage.Frozen = true;
            this.colImage.HeaderText = "Стиль";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 43;
            // 
            // countDataGridViewTextBoxColumn
            // 
            this.countDataGridViewTextBoxColumn.DataPropertyName = "Count";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.countDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.countDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.countDataGridViewTextBoxColumn.Name = "countDataGridViewTextBoxColumn";
            this.countDataGridViewTextBoxColumn.ReadOnly = true;
            this.countDataGridViewTextBoxColumn.Width = 60;
            // 
            // percentDataGridViewTextBoxColumn
            // 
            this.percentDataGridViewTextBoxColumn.DataPropertyName = "Percent";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "# ##0.00%";
            dataGridViewCellStyle3.NullValue = null;
            this.percentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.percentDataGridViewTextBoxColumn.HeaderText = "%";
            this.percentDataGridViewTextBoxColumn.Name = "percentDataGridViewTextBoxColumn";
            this.percentDataGridViewTextBoxColumn.ReadOnly = true;
            this.percentDataGridViewTextBoxColumn.Width = 40;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            this.titleDataGridViewTextBoxColumn.Width = 82;
            // 
            // legendBindingSource
            // 
            this.legendBindingSource.DataMember = "Legend";
            this.legendBindingSource.DataSource = this.d3;
            // 
            // d3
            // 
            this.d3.DataSetName = "D3";
            this.d3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.splitContainerProperties);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProperties.Size = new System.Drawing.Size(195, 287);
            this.tabPageProperties.TabIndex = 1;
            this.tabPageProperties.Text = "Свойства";
            this.tabPageProperties.UseVisualStyleBackColor = true;
            // 
            // splitContainerProperties
            // 
            this.splitContainerProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerProperties.Location = new System.Drawing.Point(3, 3);
            this.splitContainerProperties.Name = "splitContainerProperties";
            this.splitContainerProperties.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerProperties.Panel1
            // 
            this.splitContainerProperties.Panel1.Controls.Add(this.viewObject);
            this.splitContainerProperties.Panel1.Controls.Add(this.pnlSelectedObjects);
            // 
            // splitContainerProperties.Panel2
            // 
            this.splitContainerProperties.Panel2.Controls.Add(this.editObjectProperties);
            this.splitContainerProperties.Panel2.Controls.Add(this.toolStripEditObject);
            this.splitContainerProperties.Size = new System.Drawing.Size(189, 281);
            this.splitContainerProperties.SplitterDistance = 122;
            this.splitContainerProperties.TabIndex = 0;
            // 
            // viewObject
            // 
            this.viewObject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewObject.Location = new System.Drawing.Point(0, 22);
            this.viewObject.MaxBitmapSize = 167770;
            this.viewObject.Name = "viewObject";
            this.viewObject.ShowToolStrip = false;
            this.viewObject.Size = new System.Drawing.Size(189, 100);
            this.viewObject.Source = null;
            this.viewObject.TabIndex = 5;
            // 
            // pnlSelectedObjects
            // 
            this.pnlSelectedObjects.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelectedObjects.Location = new System.Drawing.Point(0, 0);
            this.pnlSelectedObjects.Name = "pnlSelectedObjects";
            this.pnlSelectedObjects.Size = new System.Drawing.Size(189, 22);
            this.pnlSelectedObjects.TabIndex = 4;
            // 
            // editObjectProperties
            // 
            this.editObjectProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editObjectProperties.Location = new System.Drawing.Point(0, 25);
            this.editObjectProperties.Name = "editObjectProperties";
            this.editObjectProperties.Size = new System.Drawing.Size(189, 130);
            this.editObjectProperties.TabIndex = 1;
            this.editObjectProperties.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.editObjectProperties_PropertyValueChanged);
            // 
            // toolStripEditObject
            // 
            this.toolStripEditObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddObject,
            this.btnDeleteObject});
            this.toolStripEditObject.Location = new System.Drawing.Point(0, 0);
            this.toolStripEditObject.Name = "toolStripEditObject";
            this.toolStripEditObject.Size = new System.Drawing.Size(189, 25);
            this.toolStripEditObject.TabIndex = 2;
            this.toolStripEditObject.Text = "toolStripEditObject";
            // 
            // btnAddObject
            // 
            this.btnAddObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddSector,
            this.btnAddRack,
            this.btnAddPlace,
            this.toolStripSeparator2,
            this.btnAddParentSector});
            this.btnAddObject.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddObject.Name = "btnAddObject";
            this.btnAddObject.Size = new System.Drawing.Size(88, 22);
            this.btnAddObject.Text = "Добавить";
            // 
            // btnAddSector
            // 
            this.btnAddSector.Name = "btnAddSector";
            this.btnAddSector.Size = new System.Drawing.Size(162, 22);
            this.btnAddSector.Text = "Сектор";
            this.btnAddSector.Click += new System.EventHandler(this.btnAddSector_Click);
            // 
            // btnAddRack
            // 
            this.btnAddRack.Name = "btnAddRack";
            this.btnAddRack.Size = new System.Drawing.Size(162, 22);
            this.btnAddRack.Text = "Стеллаж";
            this.btnAddRack.Click += new System.EventHandler(this.btnAddRack_Click);
            // 
            // btnAddPlace
            // 
            this.btnAddPlace.Name = "btnAddPlace";
            this.btnAddPlace.Size = new System.Drawing.Size(162, 22);
            this.btnAddPlace.Text = "Места хранения";
            this.btnAddPlace.Click += new System.EventHandler(this.btnAddPlace_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // btnAddParentSector
            // 
            this.btnAddParentSector.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnAddParentSector.Name = "btnAddParentSector";
            this.btnAddParentSector.Size = new System.Drawing.Size(162, 22);
            this.btnAddParentSector.Text = "Новый склад";
            this.btnAddParentSector.Click += new System.EventHandler(this.btnAddParentSector_Click);
            // 
            // btnDeleteObject
            // 
            this.btnDeleteObject.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteObject.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteObject.Name = "btnDeleteObject";
            this.btnDeleteObject.Size = new System.Drawing.Size(71, 22);
            this.btnDeleteObject.Text = "Удалить";
            this.btnDeleteObject.Click += new System.EventHandler(this.btnDeleteObject_Click);
            // 
            // tabPageRoutes
            // 
            this.tabPageRoutes.Controls.Add(this.editRouteControl);
            this.tabPageRoutes.Controls.Add(this.groupRoutes);
            this.tabPageRoutes.Controls.Add(this.groupRouteMaps);
            this.tabPageRoutes.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoutes.Name = "tabPageRoutes";
            this.tabPageRoutes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoutes.Size = new System.Drawing.Size(195, 287);
            this.tabPageRoutes.TabIndex = 2;
            this.tabPageRoutes.Text = "Маршруты";
            this.tabPageRoutes.UseVisualStyleBackColor = true;
            // 
            // editRouteControl
            // 
            this.editRouteControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editRouteControl.Location = new System.Drawing.Point(3, 230);
            this.editRouteControl.Name = "editRouteControl";
            this.editRouteControl.Size = new System.Drawing.Size(189, 54);
            this.editRouteControl.TabIndex = 4;
            this.editRouteControl.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.editRouteControl_PropertyValueChanged);
            // 
            // groupRoutes
            // 
            this.groupRoutes.Controls.Add(this.lbRoutes);
            this.groupRoutes.Controls.Add(this.toolStripRoutes);
            this.groupRoutes.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupRoutes.Location = new System.Drawing.Point(3, 90);
            this.groupRoutes.Name = "groupRoutes";
            this.groupRoutes.Size = new System.Drawing.Size(189, 140);
            this.groupRoutes.TabIndex = 2;
            this.groupRoutes.TabStop = false;
            this.groupRoutes.Text = "Маршруты:";
            // 
            // lbRoutes
            // 
            this.lbRoutes.DataSource = this.routesBindingSource;
            this.lbRoutes.DisplayMember = "Route_Name";
            this.lbRoutes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoutes.FormattingEnabled = true;
            this.lbRoutes.Location = new System.Drawing.Point(3, 41);
            this.lbRoutes.Name = "lbRoutes";
            this.lbRoutes.Size = new System.Drawing.Size(183, 95);
            this.lbRoutes.TabIndex = 0;
            this.lbRoutes.ValueMember = "Route_ID";
            this.lbRoutes.SelectedIndexChanged += new System.EventHandler(this.lbRoutes_SelectedIndexChanged);
            // 
            // routesBindingSource
            // 
            this.routesBindingSource.DataMember = "Routes";
            this.routesBindingSource.DataSource = this.d3;
            // 
            // toolStripRoutes
            // 
            this.toolStripRoutes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRoute,
            this.toolStripSeparator3,
            this.btnEditRoute,
            this.toolStripSeparator4,
            this.btnDeleteRoute});
            this.toolStripRoutes.Location = new System.Drawing.Point(3, 16);
            this.toolStripRoutes.Name = "toolStripRoutes";
            this.toolStripRoutes.Size = new System.Drawing.Size(183, 25);
            this.toolStripRoutes.TabIndex = 1;
            this.toolStripRoutes.Text = "toolStrip3";
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRoute.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(23, 22);
            this.btnAddRoute.Text = "Добавить маршрут";
            this.btnAddRoute.Click += new System.EventHandler(this.btnAddRoute_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditRoute
            // 
            this.btnEditRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditRoute.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditRoute.Name = "btnEditRoute";
            this.btnEditRoute.Size = new System.Drawing.Size(23, 22);
            this.btnEditRoute.Text = "Редактировать маршрут";
            this.btnEditRoute.Click += new System.EventHandler(this.btnEditRoute_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteRoute
            // 
            this.btnDeleteRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteRoute.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRoute.Name = "btnDeleteRoute";
            this.btnDeleteRoute.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteRoute.Text = "Удалить маршрут";
            this.btnDeleteRoute.Click += new System.EventHandler(this.btnDeleteRoute_Click);
            // 
            // groupRouteMaps
            // 
            this.groupRouteMaps.Controls.Add(this.lbRoutePlans);
            this.groupRouteMaps.Controls.Add(this.toolStripRoutePlans);
            this.groupRouteMaps.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupRouteMaps.Location = new System.Drawing.Point(3, 3);
            this.groupRouteMaps.Name = "groupRouteMaps";
            this.groupRouteMaps.Size = new System.Drawing.Size(189, 87);
            this.groupRouteMaps.TabIndex = 3;
            this.groupRouteMaps.TabStop = false;
            this.groupRouteMaps.Text = "Карта маршрутов:";
            // 
            // lbRoutePlans
            // 
            this.lbRoutePlans.DataSource = this.routePlansBindingSource;
            this.lbRoutePlans.DisplayMember = "Route_Plan_Name";
            this.lbRoutePlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoutePlans.FormattingEnabled = true;
            this.lbRoutePlans.Location = new System.Drawing.Point(3, 41);
            this.lbRoutePlans.Name = "lbRoutePlans";
            this.lbRoutePlans.Size = new System.Drawing.Size(183, 43);
            this.lbRoutePlans.TabIndex = 3;
            this.lbRoutePlans.ValueMember = "Route_Plan_ID";
            this.lbRoutePlans.SelectedIndexChanged += new System.EventHandler(this.lbRoutePlans_SelectedIndexChanged);
            // 
            // routePlansBindingSource
            // 
            this.routePlansBindingSource.DataMember = "RoutePlans";
            this.routePlansBindingSource.DataSource = this.d3;
            // 
            // toolStripRoutePlans
            // 
            this.toolStripRoutePlans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddRoutePlan,
            this.toolStripSeparator5,
            this.btnEditRoutePlan,
            this.toolStripSeparator6,
            this.btnDeleteRoutePlan});
            this.toolStripRoutePlans.Location = new System.Drawing.Point(3, 16);
            this.toolStripRoutePlans.Name = "toolStripRoutePlans";
            this.toolStripRoutePlans.Size = new System.Drawing.Size(183, 25);
            this.toolStripRoutePlans.TabIndex = 2;
            this.toolStripRoutePlans.Text = "toolStripRoute";
            // 
            // btnAddRoutePlan
            // 
            this.btnAddRoutePlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddRoutePlan.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddRoutePlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddRoutePlan.Name = "btnAddRoutePlan";
            this.btnAddRoutePlan.Size = new System.Drawing.Size(23, 22);
            this.btnAddRoutePlan.Text = "Добавить карту маршрутов";
            this.btnAddRoutePlan.Click += new System.EventHandler(this.btnAddRoutePlan_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // btnEditRoutePlan
            // 
            this.btnEditRoutePlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditRoutePlan.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditRoutePlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditRoutePlan.Name = "btnEditRoutePlan";
            this.btnEditRoutePlan.Size = new System.Drawing.Size(23, 22);
            this.btnEditRoutePlan.Text = "Редактировать карту маршрутов";
            this.btnEditRoutePlan.Click += new System.EventHandler(this.btnEditRoutePlan_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDeleteRoutePlan
            // 
            this.btnDeleteRoutePlan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteRoutePlan.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteRoutePlan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteRoutePlan.Name = "btnDeleteRoutePlan";
            this.btnDeleteRoutePlan.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteRoutePlan.Text = "Удалить карту маршрутов";
            this.btnDeleteRoutePlan.Click += new System.EventHandler(this.btnDeleteRoutePlan_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Controls.Add(this.cbSectors);
            this.panel1.Controls.Add(this.cbWarehouses);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 40);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(863, 35);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.btnReports});
            this.toolStrip1.Location = new System.Drawing.Point(561, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(92, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 22);
            this.toolStripLabel1.Text = "Отчет:";
            // 
            // btnReports
            // 
            this.btnReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNoReport,
            this.toolStripMenuItem1,
            this.miViewSectors,
            this.miViewRacks,
            this.miViewPlaces,
            this.miViewRoutes,
            this.toolStripSeparator1});
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(38, 22);
            this.btnReports.Tag = "noReport";
            this.btnReports.Text = "нет";
            // 
            // miNoReport
            // 
            this.miNoReport.Checked = true;
            this.miNoReport.CheckState = System.Windows.Forms.CheckState.Checked;
            this.miNoReport.Name = "miNoReport";
            this.miNoReport.Size = new System.Drawing.Size(204, 22);
            this.miNoReport.Text = "нет";
            this.miNoReport.Click += new System.EventHandler(this.miReport_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(201, 6);
            // 
            // miViewSectors
            // 
            this.miViewSectors.Name = "miViewSectors";
            this.miViewSectors.Size = new System.Drawing.Size(204, 22);
            this.miViewSectors.Text = "Режим: сектора";
            this.miViewSectors.Click += new System.EventHandler(this.miReport_Click);
            // 
            // miViewRacks
            // 
            this.miViewRacks.Name = "miViewRacks";
            this.miViewRacks.Size = new System.Drawing.Size(204, 22);
            this.miViewRacks.Text = "Режим: стеллажи";
            this.miViewRacks.Click += new System.EventHandler(this.miReport_Click);
            // 
            // miViewPlaces
            // 
            this.miViewPlaces.Name = "miViewPlaces";
            this.miViewPlaces.Size = new System.Drawing.Size(204, 22);
            this.miViewPlaces.Text = "Режим: места хранения";
            this.miViewPlaces.Click += new System.EventHandler(this.miReport_Click);
            // 
            // miViewRoutes
            // 
            this.miViewRoutes.Name = "miViewRoutes";
            this.miViewRoutes.Size = new System.Drawing.Size(204, 22);
            this.miViewRoutes.Text = "Режим: маршруты";
            this.miViewRoutes.Click += new System.EventHandler(this.miReport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(201, 6);
            // 
            // cbSectors
            // 
            this.cbSectors.DisplayMember = "Text";
            this.cbSectors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSectors.FormattingEnabled = true;
            this.cbSectors.Location = new System.Drawing.Point(338, 6);
            this.cbSectors.Name = "cbSectors";
            this.cbSectors.Size = new System.Drawing.Size(220, 21);
            this.cbSectors.TabIndex = 3;
            this.cbSectors.ValueMember = "Sector_ID";
            this.cbSectors.SelectedIndexChanged += new System.EventHandler(this.cbSectors_SelectedIndexChanged);
            // 
            // cbWarehouses
            // 
            this.cbWarehouses.DataSource = this.warehousesBindingSource;
            this.cbWarehouses.DisplayMember = "Warehouse_Name";
            this.cbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarehouses.FormattingEnabled = true;
            this.cbWarehouses.Location = new System.Drawing.Point(60, 6);
            this.cbWarehouses.MaxDropDownItems = 16;
            this.cbWarehouses.Name = "cbWarehouses";
            this.cbWarehouses.Size = new System.Drawing.Size(220, 21);
            this.cbWarehouses.TabIndex = 2;
            this.cbWarehouses.ValueMember = "Warehouse_ID";
            this.cbWarehouses.SelectedIndexChanged += new System.EventHandler(this.cbWarehouses_SelectedIndexChanged);
            // 
            // warehousesBindingSource
            // 
            this.warehousesBindingSource.DataMember = "Warehouses";
            this.warehousesBindingSource.DataSource = this.d3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сектор:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Склад:";
            // 
            // sectorsBindingSource
            // 
            this.sectorsBindingSource.DataMember = "Sectors";
            this.sectorsBindingSource.DataSource = this.d3;
            // 
            // warehousesTableAdapter
            // 
            this.warehousesTableAdapter.ClearBeforeFill = true;
            // 
            // sectorsTableAdapter
            // 
            this.sectorsTableAdapter.ClearBeforeFill = true;
            // 
            // legendTableAdapter
            // 
            this.legendTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "Стиль";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Count";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn1.HeaderText = "Кол-во";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 60;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Percent";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "# ##0.00%";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn2.HeaderText = "%";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Title";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // routesTableAdapter
            // 
            this.routesTableAdapter.ClearBeforeFill = true;
            // 
            // routePlansTableAdapter
            // 
            this.routePlansTableAdapter.ClearBeforeFill = true;
            // 
            // cmWarehouse
            // 
            this.cmWarehouse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportPlacesToJDE});
            this.cmWarehouse.Name = "cmWarehouse";
            this.cmWarehouse.Size = new System.Drawing.Size(228, 26);
            // 
            // miExportPlacesToJDE
            // 
            this.miExportPlacesToJDE.Name = "miExportPlacesToJDE";
            this.miExportPlacesToJDE.Size = new System.Drawing.Size(227, 22);
            this.miExportPlacesToJDE.Text = "Экспорт схемы склада в JDE";
            this.miExportPlacesToJDE.Click += new System.EventHandler(this.miExportPlacesToJDE_Click);
            // 
            // cmRoutePlans
            // 
            this.cmRoutePlans.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miExportRoutePlanToJDE});
            this.cmRoutePlans.Name = "cmRoutePlans";
            this.cmRoutePlans.Size = new System.Drawing.Size(253, 26);
            // 
            // miExportRoutePlanToJDE
            // 
            this.miExportRoutePlanToJDE.Name = "miExportRoutePlanToJDE";
            this.miExportRoutePlanToJDE.Size = new System.Drawing.Size(252, 22);
            this.miExportRoutePlanToJDE.Text = "Экспорт карты маршрутов в JDE";
            this.miExportRoutePlanToJDE.Click += new System.EventHandler(this.miExportRoutePlanToJDE_Click);
            // 
            // D3Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 388);
            this.Controls.Add(this.splitContainerView);
            this.Controls.Add(this.panel1);
            this.Name = "D3Window";
            this.Text = "D3Window";
            this.Load += new System.EventHandler(this.D3Window_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.splitContainerView, 0);
            this.splitContainerView.Panel1.ResumeLayout(false);
            this.splitContainerView.Panel2.ResumeLayout(false);
            this.splitContainerView.ResumeLayout(false);
            this.tabControlInfo.ResumeLayout(false);
            this.tabPageLegend.ResumeLayout(false);
            this.splitContainerInfo.Panel1.ResumeLayout(false);
            this.splitContainerInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gvLegend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.legendBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.d3)).EndInit();
            this.tabPageProperties.ResumeLayout(false);
            this.splitContainerProperties.Panel1.ResumeLayout(false);
            this.splitContainerProperties.Panel2.ResumeLayout(false);
            this.splitContainerProperties.Panel2.PerformLayout();
            this.splitContainerProperties.ResumeLayout(false);
            this.toolStripEditObject.ResumeLayout(false);
            this.toolStripEditObject.PerformLayout();
            this.tabPageRoutes.ResumeLayout(false);
            this.groupRoutes.ResumeLayout(false);
            this.groupRoutes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routesBindingSource)).EndInit();
            this.toolStripRoutes.ResumeLayout(false);
            this.toolStripRoutes.PerformLayout();
            this.groupRouteMaps.ResumeLayout(false);
            this.groupRouteMaps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.routePlansBindingSource)).EndInit();
            this.toolStripRoutePlans.ResumeLayout(false);
            this.toolStripRoutePlans.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.warehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sectorsBindingSource)).EndInit();
            this.cmWarehouse.ResumeLayout(false);
            this.cmRoutePlans.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerView;
        private WMSOffice.Controls.D3.View viewD3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbSectors;
        private System.Windows.Forms.ComboBox cbWarehouses;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Data.D3 d3;
        private System.Windows.Forms.BindingSource warehousesBindingSource;
        private WMSOffice.Data.D3TableAdapters.WarehousesTableAdapter warehousesTableAdapter;
        private System.Windows.Forms.BindingSource sectorsBindingSource;
        private WMSOffice.Data.D3TableAdapters.SectorsTableAdapter sectorsTableAdapter;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton btnReports;
        private System.Windows.Forms.ToolStripMenuItem miNoReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource legendBindingSource;
        private WMSOffice.Data.D3TableAdapters.LegendTableAdapter legendTableAdapter;
        private System.Windows.Forms.TabControl tabControlInfo;
        private System.Windows.Forms.TabPage tabPageLegend;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.SplitContainer splitContainerInfo;
        private System.Windows.Forms.DataGridView gvLegend;
        private System.Windows.Forms.DataGridViewImageColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn countDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn percentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainerProperties;
        private WMSOffice.Controls.D3.View viewObject;
        private System.Windows.Forms.FlowLayoutPanel pnlSelectedObjects;
        private WMSOffice.Controls.D3.EditPropertiesControl editObjectProperties;
        private System.Windows.Forms.ToolStrip toolStripEditObject;
        private System.Windows.Forms.ToolStripDropDownButton btnAddObject;
        private System.Windows.Forms.ToolStripMenuItem btnAddParentSector;
        private System.Windows.Forms.ToolStripMenuItem btnAddSector;
        private System.Windows.Forms.ToolStripMenuItem btnAddRack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDeleteObject;
        private System.Windows.Forms.ToolStripMenuItem btnAddPlace;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem miViewSectors;
        private System.Windows.Forms.ToolStripMenuItem miViewRacks;
        private System.Windows.Forms.ToolStripMenuItem miViewPlaces;
        private System.Windows.Forms.ToolStripMenuItem miViewRoutes;
        private System.Windows.Forms.TabPage tabPageRoutes;
        private System.Windows.Forms.GroupBox groupRoutes;
        private System.Windows.Forms.ListBox lbRoutes;
        private System.Windows.Forms.ToolStrip toolStripRoutes;
        private System.Windows.Forms.GroupBox groupRouteMaps;
        private System.Windows.Forms.ListBox lbRoutePlans;
        private System.Windows.Forms.ToolStrip toolStripRoutePlans;
        private System.Windows.Forms.ToolStripButton btnAddRoutePlan;
        private System.Windows.Forms.BindingSource routesBindingSource;
        private WMSOffice.Data.D3TableAdapters.RoutesTableAdapter routesTableAdapter;
        private System.Windows.Forms.ToolStripButton btnAddRoute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnDeleteRoute;
        private WMSOffice.Controls.D3.EditPropertiesControl editRouteControl;
        private System.Windows.Forms.ToolStripButton btnEditRoute;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnEditRoutePlan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnDeleteRoutePlan;
        private System.Windows.Forms.BindingSource routePlansBindingSource;
        private WMSOffice.Data.D3TableAdapters.RoutePlansTableAdapter routePlansTableAdapter;
        private System.Windows.Forms.ContextMenuStrip cmWarehouse;
        private System.Windows.Forms.ToolStripMenuItem miExportPlacesToJDE;
        private System.Windows.Forms.ContextMenuStrip cmRoutePlans;
        private System.Windows.Forms.ToolStripMenuItem miExportRoutePlanToJDE;
    }
}