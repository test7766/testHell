namespace WMSOffice.Window
{
    partial class PrintingDevicesManagerWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.scLocationsDevices = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvLocations = new System.Windows.Forms.DataGridView();
            this.locationCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dDLocationsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.deviceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oSNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ipAddrDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currLocationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.locationCodeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityNum1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buildnumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityNum2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.identityNum3DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDevices = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miChangeDeviceIP = new System.Windows.Forms.ToolStripMenuItem();
            this.dDDevicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dgvDeviceStatistics = new System.Windows.Forms.DataGridView();
            this.cmsDeviceStatistics = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miDeleteDeviceStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.dDDeviceStatisticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.cmbStatisticsMonthes = new System.Windows.Forms.ComboBox();
            this.nudStatisticsYear = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dD_LocationsTableAdapter = new WMSOffice.Data.WHTableAdapters.DD_LocationsTableAdapter();
            this.dD_DevicesTableAdapter = new WMSOffice.Data.WHTableAdapters.DD_DevicesTableAdapter();
            this.dD_DeviceStatisticsTableAdapter = new WMSOffice.Data.WHTableAdapters.DD_DeviceStatisticsTableAdapter();
            this.PeriodDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.count2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MacAddr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.modifyDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorMessage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.scLocationsDevices.Panel1.SuspendLayout();
            this.scLocationsDevices.Panel2.SuspendLayout();
            this.scLocationsDevices.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDLocationsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.panel5.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.cmsDevices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dDDevicesBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceStatistics)).BeginInit();
            this.cmsDeviceStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dDDeviceStatisticsBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStatisticsYear)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1264, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 52);
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.scLocationsDevices);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1264, 507);
            this.pnlContent.TabIndex = 2;
            // 
            // scLocationsDevices
            // 
            this.scLocationsDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scLocationsDevices.Location = new System.Drawing.Point(0, 0);
            this.scLocationsDevices.Name = "scLocationsDevices";
            // 
            // scLocationsDevices.Panel1
            // 
            this.scLocationsDevices.Panel1.Controls.Add(this.panel1);
            this.scLocationsDevices.Panel1.Controls.Add(this.panel5);
            // 
            // scLocationsDevices.Panel2
            // 
            this.scLocationsDevices.Panel2.Controls.Add(this.splitContainer1);
            this.scLocationsDevices.Size = new System.Drawing.Size(1264, 507);
            this.scLocationsDevices.SplitterDistance = 300;
            this.scLocationsDevices.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLocations);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 483);
            this.panel1.TabIndex = 3;
            // 
            // dgvLocations
            // 
            this.dgvLocations.AllowUserToAddRows = false;
            this.dgvLocations.AllowUserToDeleteRows = false;
            this.dgvLocations.AllowUserToResizeRows = false;
            this.dgvLocations.AutoGenerateColumns = false;
            this.dgvLocations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLocations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.locationCodeDataGridViewTextBoxColumn,
            this.locationCityDataGridViewTextBoxColumn,
            this.locationAddressDataGridViewTextBoxColumn});
            this.dgvLocations.DataSource = this.dDLocationsBindingSource;
            this.dgvLocations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLocations.Location = new System.Drawing.Point(0, 0);
            this.dgvLocations.MultiSelect = false;
            this.dgvLocations.Name = "dgvLocations";
            this.dgvLocations.ReadOnly = true;
            this.dgvLocations.RowHeadersVisible = false;
            this.dgvLocations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocations.Size = new System.Drawing.Size(300, 483);
            this.dgvLocations.TabIndex = 0;
            this.dgvLocations.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvLocations_CellFormatting);
            this.dgvLocations.SelectionChanged += new System.EventHandler(this.dgvLocations_SelectionChanged);
            // 
            // locationCodeDataGridViewTextBoxColumn
            // 
            this.locationCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationCodeDataGridViewTextBoxColumn.DataPropertyName = "LocationCode";
            this.locationCodeDataGridViewTextBoxColumn.HeaderText = "Код локації";
            this.locationCodeDataGridViewTextBoxColumn.Name = "locationCodeDataGridViewTextBoxColumn";
            this.locationCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationCodeDataGridViewTextBoxColumn.Width = 89;
            // 
            // locationCityDataGridViewTextBoxColumn
            // 
            this.locationCityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationCityDataGridViewTextBoxColumn.DataPropertyName = "LocationCity";
            this.locationCityDataGridViewTextBoxColumn.HeaderText = "Місто";
            this.locationCityDataGridViewTextBoxColumn.Name = "locationCityDataGridViewTextBoxColumn";
            this.locationCityDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationCityDataGridViewTextBoxColumn.Width = 60;
            // 
            // locationAddressDataGridViewTextBoxColumn
            // 
            this.locationAddressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationAddressDataGridViewTextBoxColumn.DataPropertyName = "LocationAddress";
            this.locationAddressDataGridViewTextBoxColumn.HeaderText = "Адреса";
            this.locationAddressDataGridViewTextBoxColumn.Name = "locationAddressDataGridViewTextBoxColumn";
            this.locationAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationAddressDataGridViewTextBoxColumn.Width = 69;
            // 
            // dDLocationsBindingSource
            // 
            this.dDLocationsBindingSource.DataMember = "DD_Locations";
            this.dDLocationsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(300, 24);
            this.panel5.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label3.Size = new System.Drawing.Size(300, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Локації";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel6);
            this.splitContainer1.Panel2.Controls.Add(this.panel3);
            this.splitContainer1.Size = new System.Drawing.Size(960, 507);
            this.splitContainer1.SplitterDistance = 332;
            this.splitContainer1.TabIndex = 5;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.dgvDevices);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 24);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(960, 308);
            this.panel4.TabIndex = 4;
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            this.dgvDevices.AllowUserToDeleteRows = false;
            this.dgvDevices.AllowUserToResizeRows = false;
            this.dgvDevices.AutoGenerateColumns = false;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deviceIDDataGridViewTextBoxColumn,
            this.deviceNameDataGridViewTextBoxColumn,
            this.ModelName,
            this.oSNumberDataGridViewTextBoxColumn,
            this.ipAddrDataGridViewTextBoxColumn,
            this.currLocationIDDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn,
            this.locationCodeDataGridViewTextBoxColumn1,
            this.identityNum1DataGridViewTextBoxColumn,
            this.stageDataGridViewTextBoxColumn,
            this.buildnumDataGridViewTextBoxColumn,
            this.identityNum2DataGridViewTextBoxColumn,
            this.identityNum3DataGridViewTextBoxColumn,
            this.zoneDataGridViewTextBoxColumn});
            this.dgvDevices.ContextMenuStrip = this.cmsDevices;
            this.dgvDevices.DataSource = this.dDDevicesBindingSource;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevices.Location = new System.Drawing.Point(0, 0);
            this.dgvDevices.MultiSelect = false;
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.ReadOnly = true;
            this.dgvDevices.RowHeadersVisible = false;
            this.dgvDevices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDevices.Size = new System.Drawing.Size(960, 308);
            this.dgvDevices.TabIndex = 1;
            this.dgvDevices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDevices_CellFormatting);
            this.dgvDevices.SelectionChanged += new System.EventHandler(this.dgvDevices_SelectionChanged);
            // 
            // deviceIDDataGridViewTextBoxColumn
            // 
            this.deviceIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deviceIDDataGridViewTextBoxColumn.DataPropertyName = "Device_ID";
            this.deviceIDDataGridViewTextBoxColumn.HeaderText = "ІД пристрою";
            this.deviceIDDataGridViewTextBoxColumn.Name = "deviceIDDataGridViewTextBoxColumn";
            this.deviceIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deviceIDDataGridViewTextBoxColumn.Width = 96;
            // 
            // deviceNameDataGridViewTextBoxColumn
            // 
            this.deviceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.deviceNameDataGridViewTextBoxColumn.DataPropertyName = "DeviceName";
            this.deviceNameDataGridViewTextBoxColumn.HeaderText = "Найменування пристрою";
            this.deviceNameDataGridViewTextBoxColumn.Name = "deviceNameDataGridViewTextBoxColumn";
            this.deviceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.deviceNameDataGridViewTextBoxColumn.Width = 159;
            // 
            // ModelName
            // 
            this.ModelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ModelName.DataPropertyName = "ModelName";
            this.ModelName.HeaderText = "Виробник";
            this.ModelName.Name = "ModelName";
            this.ModelName.ReadOnly = true;
            this.ModelName.Width = 81;
            // 
            // oSNumberDataGridViewTextBoxColumn
            // 
            this.oSNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.oSNumberDataGridViewTextBoxColumn.DataPropertyName = "OSNumber";
            this.oSNumberDataGridViewTextBoxColumn.HeaderText = "Номер ОЗ";
            this.oSNumberDataGridViewTextBoxColumn.Name = "oSNumberDataGridViewTextBoxColumn";
            this.oSNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.oSNumberDataGridViewTextBoxColumn.Width = 84;
            // 
            // ipAddrDataGridViewTextBoxColumn
            // 
            this.ipAddrDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ipAddrDataGridViewTextBoxColumn.DataPropertyName = "IpAddr";
            this.ipAddrDataGridViewTextBoxColumn.HeaderText = "IP-адреса";
            this.ipAddrDataGridViewTextBoxColumn.Name = "ipAddrDataGridViewTextBoxColumn";
            this.ipAddrDataGridViewTextBoxColumn.ReadOnly = true;
            this.ipAddrDataGridViewTextBoxColumn.Width = 81;
            // 
            // currLocationIDDataGridViewTextBoxColumn
            // 
            this.currLocationIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.currLocationIDDataGridViewTextBoxColumn.DataPropertyName = "CurrLocationID";
            this.currLocationIDDataGridViewTextBoxColumn.HeaderText = "ШК локації";
            this.currLocationIDDataGridViewTextBoxColumn.Name = "currLocationIDDataGridViewTextBoxColumn";
            this.currLocationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.currLocationIDDataGridViewTextBoxColumn.Width = 86;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "Активний(так/ні)";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isActiveDataGridViewCheckBoxColumn.Width = 97;
            // 
            // locationCodeDataGridViewTextBoxColumn1
            // 
            this.locationCodeDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationCodeDataGridViewTextBoxColumn1.DataPropertyName = "LocationCode";
            this.locationCodeDataGridViewTextBoxColumn1.HeaderText = "Код локації";
            this.locationCodeDataGridViewTextBoxColumn1.Name = "locationCodeDataGridViewTextBoxColumn1";
            this.locationCodeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.locationCodeDataGridViewTextBoxColumn1.Width = 89;
            // 
            // identityNum1DataGridViewTextBoxColumn
            // 
            this.identityNum1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.identityNum1DataGridViewTextBoxColumn.DataPropertyName = "IdentityNum1";
            this.identityNum1DataGridViewTextBoxColumn.HeaderText = "Ідентифікатор локації №1";
            this.identityNum1DataGridViewTextBoxColumn.Name = "identityNum1DataGridViewTextBoxColumn";
            this.identityNum1DataGridViewTextBoxColumn.ReadOnly = true;
            this.identityNum1DataGridViewTextBoxColumn.Width = 161;
            // 
            // stageDataGridViewTextBoxColumn
            // 
            this.stageDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stageDataGridViewTextBoxColumn.DataPropertyName = "Stage";
            this.stageDataGridViewTextBoxColumn.HeaderText = "Поверх";
            this.stageDataGridViewTextBoxColumn.Name = "stageDataGridViewTextBoxColumn";
            this.stageDataGridViewTextBoxColumn.ReadOnly = true;
            this.stageDataGridViewTextBoxColumn.Width = 69;
            // 
            // buildnumDataGridViewTextBoxColumn
            // 
            this.buildnumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.buildnumDataGridViewTextBoxColumn.DataPropertyName = "Buildnum";
            this.buildnumDataGridViewTextBoxColumn.HeaderText = "Номер будівлі";
            this.buildnumDataGridViewTextBoxColumn.Name = "buildnumDataGridViewTextBoxColumn";
            this.buildnumDataGridViewTextBoxColumn.ReadOnly = true;
            this.buildnumDataGridViewTextBoxColumn.Width = 102;
            // 
            // identityNum2DataGridViewTextBoxColumn
            // 
            this.identityNum2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.identityNum2DataGridViewTextBoxColumn.DataPropertyName = "IdentityNum2";
            this.identityNum2DataGridViewTextBoxColumn.HeaderText = "Ідентифікатор локації №2";
            this.identityNum2DataGridViewTextBoxColumn.Name = "identityNum2DataGridViewTextBoxColumn";
            this.identityNum2DataGridViewTextBoxColumn.ReadOnly = true;
            this.identityNum2DataGridViewTextBoxColumn.Width = 161;
            // 
            // identityNum3DataGridViewTextBoxColumn
            // 
            this.identityNum3DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.identityNum3DataGridViewTextBoxColumn.DataPropertyName = "IdentityNum3";
            this.identityNum3DataGridViewTextBoxColumn.HeaderText = "Ідентифікатор локації №3";
            this.identityNum3DataGridViewTextBoxColumn.Name = "identityNum3DataGridViewTextBoxColumn";
            this.identityNum3DataGridViewTextBoxColumn.ReadOnly = true;
            this.identityNum3DataGridViewTextBoxColumn.Width = 161;
            // 
            // zoneDataGridViewTextBoxColumn
            // 
            this.zoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.zoneDataGridViewTextBoxColumn.DataPropertyName = "Zone";
            this.zoneDataGridViewTextBoxColumn.HeaderText = "Зона";
            this.zoneDataGridViewTextBoxColumn.Name = "zoneDataGridViewTextBoxColumn";
            this.zoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.zoneDataGridViewTextBoxColumn.Width = 57;
            // 
            // cmsDevices
            // 
            this.cmsDevices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeDeviceIP});
            this.cmsDevices.Name = "cmsDevices";
            this.cmsDevices.Size = new System.Drawing.Size(166, 26);
            // 
            // miChangeDeviceIP
            // 
            this.miChangeDeviceIP.Image = global::WMSOffice.Properties.Resources.Network;
            this.miChangeDeviceIP.Name = "miChangeDeviceIP";
            this.miChangeDeviceIP.Size = new System.Drawing.Size(165, 22);
            this.miChangeDeviceIP.Text = "Змінити IP-адресу";
            this.miChangeDeviceIP.Click += new System.EventHandler(this.miChangeDeviceIP_Click);
            // 
            // dDDevicesBindingSource
            // 
            this.dDDevicesBindingSource.DataMember = "DD_Devices";
            this.dDDevicesBindingSource.DataSource = this.wH;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(960, 24);
            this.panel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(960, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Пристрої";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.dgvDeviceStatistics);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 24);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(960, 147);
            this.panel6.TabIndex = 5;
            // 
            // dgvDeviceStatistics
            // 
            this.dgvDeviceStatistics.AllowUserToAddRows = false;
            this.dgvDeviceStatistics.AllowUserToDeleteRows = false;
            this.dgvDeviceStatistics.AllowUserToResizeRows = false;
            this.dgvDeviceStatistics.AutoGenerateColumns = false;
            this.dgvDeviceStatistics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDeviceStatistics.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PeriodDate,
            this.count1DataGridViewTextBoxColumn,
            this.count2DataGridViewTextBoxColumn,
            this.MacAddr,
            this.modifyDateDataGridViewTextBoxColumn,
            this.ErrorMessage});
            this.dgvDeviceStatistics.ContextMenuStrip = this.cmsDeviceStatistics;
            this.dgvDeviceStatistics.DataSource = this.dDDeviceStatisticsBindingSource;
            this.dgvDeviceStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeviceStatistics.Location = new System.Drawing.Point(0, 0);
            this.dgvDeviceStatistics.MultiSelect = false;
            this.dgvDeviceStatistics.Name = "dgvDeviceStatistics";
            this.dgvDeviceStatistics.ReadOnly = true;
            this.dgvDeviceStatistics.RowHeadersVisible = false;
            this.dgvDeviceStatistics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDeviceStatistics.Size = new System.Drawing.Size(960, 147);
            this.dgvDeviceStatistics.TabIndex = 2;
            this.dgvDeviceStatistics.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDeviceStatistics_CellFormatting);
            this.dgvDeviceStatistics.SelectionChanged += new System.EventHandler(this.dgvDeviceStatistics_SelectionChanged);
            // 
            // cmsDeviceStatistics
            // 
            this.cmsDeviceStatistics.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDeleteDeviceStatistics});
            this.cmsDeviceStatistics.Name = "cmsDeviceStatistics";
            this.cmsDeviceStatistics.Size = new System.Drawing.Size(124, 26);
            // 
            // miDeleteDeviceStatistics
            // 
            this.miDeleteDeviceStatistics.Image = global::WMSOffice.Properties.Resources.Delete;
            this.miDeleteDeviceStatistics.Name = "miDeleteDeviceStatistics";
            this.miDeleteDeviceStatistics.Size = new System.Drawing.Size(123, 22);
            this.miDeleteDeviceStatistics.Text = "Видалити";
            this.miDeleteDeviceStatistics.Click += new System.EventHandler(this.miDeleteDeviceStatistics_Click);
            // 
            // dDDeviceStatisticsBindingSource
            // 
            this.dDDeviceStatisticsBindingSource.DataMember = "DD_DeviceStatistics";
            this.dDDeviceStatisticsBindingSource.DataSource = this.wH;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSkyBlue;
            this.panel3.Controls.Add(this.cmbStatisticsMonthes);
            this.panel3.Controls.Add(this.nudStatisticsYear);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(960, 24);
            this.panel3.TabIndex = 4;
            // 
            // cmbStatisticsMonthes
            // 
            this.cmbStatisticsMonthes.BackColor = System.Drawing.Color.LightSkyBlue;
            this.cmbStatisticsMonthes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatisticsMonthes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbStatisticsMonthes.FormattingEnabled = true;
            this.cmbStatisticsMonthes.Items.AddRange(new object[] {
            "січень",
            "лютий",
            "березень",
            "квітень",
            "травень",
            "червень",
            "липень",
            "серпень",
            "вересень",
            "жовтень",
            "листопад",
            "грудень"});
            this.cmbStatisticsMonthes.Location = new System.Drawing.Point(119, 0);
            this.cmbStatisticsMonthes.Name = "cmbStatisticsMonthes";
            this.cmbStatisticsMonthes.Size = new System.Drawing.Size(95, 24);
            this.cmbStatisticsMonthes.TabIndex = 3;
            this.cmbStatisticsMonthes.SelectedIndexChanged += new System.EventHandler(this.cmbStatisticsMonthes_SelectedIndexChanged);
            // 
            // nudStatisticsYear
            // 
            this.nudStatisticsYear.BackColor = System.Drawing.Color.LightSkyBlue;
            this.nudStatisticsYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nudStatisticsYear.Location = new System.Drawing.Point(217, 0);
            this.nudStatisticsYear.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudStatisticsYear.Minimum = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.nudStatisticsYear.Name = "nudStatisticsYear";
            this.nudStatisticsYear.Size = new System.Drawing.Size(60, 22);
            this.nudStatisticsYear.TabIndex = 2;
            this.nudStatisticsYear.Value = new decimal(new int[] {
            2023,
            0,
            0,
            0});
            this.nudStatisticsYear.ValueChanged += new System.EventHandler(this.nudStatisticsYear_ValueChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(960, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Статистика за";
            // 
            // dD_LocationsTableAdapter
            // 
            this.dD_LocationsTableAdapter.ClearBeforeFill = true;
            // 
            // dD_DevicesTableAdapter
            // 
            this.dD_DevicesTableAdapter.ClearBeforeFill = true;
            // 
            // dD_DeviceStatisticsTableAdapter
            // 
            this.dD_DeviceStatisticsTableAdapter.ClearBeforeFill = true;
            // 
            // PeriodDate
            // 
            this.PeriodDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PeriodDate.DataPropertyName = "PeriodDate";
            this.PeriodDate.HeaderText = "Дата";
            this.PeriodDate.Name = "PeriodDate";
            this.PeriodDate.ReadOnly = true;
            this.PeriodDate.Width = 58;
            // 
            // count1DataGridViewTextBoxColumn
            // 
            this.count1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.count1DataGridViewTextBoxColumn.DataPropertyName = "Count1";
            this.count1DataGridViewTextBoxColumn.HeaderText = "Покази 1-го лічильника";
            this.count1DataGridViewTextBoxColumn.Name = "count1DataGridViewTextBoxColumn";
            this.count1DataGridViewTextBoxColumn.ReadOnly = true;
            this.count1DataGridViewTextBoxColumn.Width = 151;
            // 
            // count2DataGridViewTextBoxColumn
            // 
            this.count2DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.count2DataGridViewTextBoxColumn.DataPropertyName = "Count2";
            this.count2DataGridViewTextBoxColumn.HeaderText = "Покази 2-го лічильника";
            this.count2DataGridViewTextBoxColumn.Name = "count2DataGridViewTextBoxColumn";
            this.count2DataGridViewTextBoxColumn.ReadOnly = true;
            this.count2DataGridViewTextBoxColumn.Width = 151;
            // 
            // MacAddr
            // 
            this.MacAddr.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MacAddr.DataPropertyName = "MacAddr";
            this.MacAddr.HeaderText = "MAC-адреса";
            this.MacAddr.Name = "MacAddr";
            this.MacAddr.ReadOnly = true;
            this.MacAddr.Width = 94;
            // 
            // modifyDateDataGridViewTextBoxColumn
            // 
            this.modifyDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.modifyDateDataGridViewTextBoxColumn.DataPropertyName = "ModifyDate";
            this.modifyDateDataGridViewTextBoxColumn.HeaderText = "Час отримання";
            this.modifyDateDataGridViewTextBoxColumn.Name = "modifyDateDataGridViewTextBoxColumn";
            this.modifyDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.modifyDateDataGridViewTextBoxColumn.Width = 110;
            // 
            // ErrorMessage
            // 
            this.ErrorMessage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ErrorMessage.DataPropertyName = "ErrorMessage";
            this.ErrorMessage.HeaderText = "Помилка";
            this.ErrorMessage.Name = "ErrorMessage";
            this.ErrorMessage.ReadOnly = true;
            this.ErrorMessage.Width = 78;
            // 
            // PrintingDevicesManagerWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 602);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "PrintingDevicesManagerWindow";
            this.Text = "PrintingDevicesManagerWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.scLocationsDevices.Panel1.ResumeLayout(false);
            this.scLocationsDevices.Panel2.ResumeLayout(false);
            this.scLocationsDevices.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dDLocationsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.panel5.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.cmsDevices.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dDDevicesBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeviceStatistics)).EndInit();
            this.cmsDeviceStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dDDeviceStatisticsBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudStatisticsYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.SplitContainer scLocationsDevices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvLocations;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource dDLocationsBindingSource;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource dDDevicesBindingSource;
        private WMSOffice.Data.WHTableAdapters.DD_LocationsTableAdapter dD_LocationsTableAdapter;
        private WMSOffice.Data.WHTableAdapters.DD_DevicesTableAdapter dD_DevicesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView dgvDeviceStatistics;
        private System.Windows.Forms.BindingSource dDDeviceStatisticsBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private WMSOffice.Data.WHTableAdapters.DD_DeviceStatisticsTableAdapter dD_DeviceStatisticsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cmbStatisticsMonthes;
        private System.Windows.Forms.NumericUpDown nudStatisticsYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn oSNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ipAddrDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn currLocationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationCodeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn identityNum1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn buildnumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identityNum2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn identityNum3DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn zoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.ContextMenuStrip cmsDeviceStatistics;
        private System.Windows.Forms.ToolStripMenuItem miDeleteDeviceStatistics;
        private System.Windows.Forms.ContextMenuStrip cmsDevices;
        private System.Windows.Forms.ToolStripMenuItem miChangeDeviceIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn PeriodDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn count1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn count2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MacAddr;
        private System.Windows.Forms.DataGridViewTextBoxColumn modifyDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorMessage;
    }
}