namespace WMSOffice.Window
{
    partial class СoldChainTemperatureSensorsWindow
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
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbRefreshSensors = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbAddSensor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintSticker = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.dgvSensors = new System.Windows.Forms.DataGridView();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.temperatureSensorsAbilityStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensorForwardersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensorModesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmsSensors = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPrintSticker = new System.Windows.Forms.ToolStripMenuItem();
            this.temperatureSensorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.temperatureSensorsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.TemperatureSensorsTableAdapter();
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            this.sensorForwardersTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.SensorForwardersTableAdapter();
            this.sensorModesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.SensorModesTableAdapter();
            this.Sensor_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sensor_Type_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Branch = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Ability = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Forwarder_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Sensor_Mode_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Verification_Date = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.tsMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorsAbilityStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorForwardersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorModesBindingSource)).BeginInit();
            this.cmsSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefreshSensors,
            this.toolStripSeparator1,
            this.sbAddSensor,
            this.toolStripSeparator3,
            this.btnPrintSticker,
            this.toolStripSeparator2,
            this.btnExportToExcel,
            this.cmbPrinters,
            this.lblPrinters,
            this.toolStripSeparator4});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 40);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1110, 55);
            this.tsMainMenu.TabIndex = 1;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbRefreshSensors
            // 
            this.sbRefreshSensors.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefreshSensors.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefreshSensors.Name = "sbRefreshSensors";
            this.sbRefreshSensors.Size = new System.Drawing.Size(113, 52);
            this.sbRefreshSensors.Text = "Обновить";
            this.sbRefreshSensors.Click += new System.EventHandler(this.sbRefreshSensors_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbAddSensor
            // 
            this.sbAddSensor.Image = global::WMSOffice.Properties.Resources.add_sensor;
            this.sbAddSensor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddSensor.Name = "sbAddSensor";
            this.sbAddSensor.Size = new System.Drawing.Size(137, 52);
            this.sbAddSensor.Text = "Новый датчик";
            this.sbAddSensor.Click += new System.EventHandler(this.sbAddSensor_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintSticker
            // 
            this.btnPrintSticker.Image = global::WMSOffice.Properties.Resources.barcode;
            this.btnPrintSticker.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintSticker.Name = "btnPrintSticker";
            this.btnPrintSticker.Size = new System.Drawing.Size(144, 52);
            this.btnPrintSticker.Text = "Печать стикера";
            this.btnPrintSticker.ToolTipText = "Напечатать этикетки на выбранные датчики температуы";
            this.btnPrintSticker.Visible = false;
            this.btnPrintSticker.Click += new System.EventHandler(this.PrintSticker_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(142, 52);
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            // 
            // lblPrinters
            // 
            this.lblPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(85, 52);
            this.lblPrinters.Text = "        Принтер: ";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // dgvSensors
            // 
            this.dgvSensors.AllowUserToAddRows = false;
            this.dgvSensors.AllowUserToDeleteRows = false;
            this.dgvSensors.AllowUserToResizeRows = false;
            this.dgvSensors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSensors.AutoGenerateColumns = false;
            this.dgvSensors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSensors.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sensor_ID,
            this.sensorNameDataGridViewTextBoxColumn,
            this.Sensor_Type_Name,
            this.Branch,
            this.Ability,
            this.Forwarder_ID,
            this.Sensor_Mode_ID,
            this.Verification_Date});
            this.dgvSensors.ContextMenuStrip = this.cmsSensors;
            this.dgvSensors.DataSource = this.temperatureSensorsBindingSource;
            this.dgvSensors.Location = new System.Drawing.Point(0, 98);
            this.dgvSensors.Name = "dgvSensors";
            this.dgvSensors.RowHeadersVisible = false;
            this.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensors.ShowEditingIcon = false;
            this.dgvSensors.Size = new System.Drawing.Size(1110, 463);
            this.dgvSensors.TabIndex = 5;
            this.dgvSensors.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSensors_CellValueChanged);
            this.dgvSensors.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSensors_CellBeginEdit);
            this.dgvSensors.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvSensors_CellValidating);
            this.dgvSensors.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSensors_EditingControlShowing);
            this.dgvSensors.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSensors_DataError);
            this.dgvSensors.SelectionChanged += new System.EventHandler(this.dgvSensors_SelectionChanged);
            // 
            // branchesBindingSource
            // 
            this.branchesBindingSource.DataMember = "Branches";
            this.branchesBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // temperatureSensorsAbilityStateBindingSource
            // 
            this.temperatureSensorsAbilityStateBindingSource.DataMember = "TemperatureSensorsAbilityState";
            this.temperatureSensorsAbilityStateBindingSource.DataSource = this.coldChain;
            // 
            // sensorForwardersBindingSource
            // 
            this.sensorForwardersBindingSource.DataMember = "SensorForwarders";
            this.sensorForwardersBindingSource.DataSource = this.coldChain;
            // 
            // sensorModesBindingSource
            // 
            this.sensorModesBindingSource.DataMember = "SensorModes";
            this.sensorModesBindingSource.DataSource = this.coldChain;
            // 
            // cmsSensors
            // 
            this.cmsSensors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPrintSticker});
            this.cmsSensors.Name = "cmsSensors";
            this.cmsSensors.Size = new System.Drawing.Size(201, 26);
            // 
            // miPrintSticker
            // 
            this.miPrintSticker.Enabled = false;
            this.miPrintSticker.Image = global::WMSOffice.Properties.Resources.barcode;
            this.miPrintSticker.Name = "miPrintSticker";
            this.miPrintSticker.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.miPrintSticker.Size = new System.Drawing.Size(200, 22);
            this.miPrintSticker.Text = "Печать стикера";
            this.miPrintSticker.Click += new System.EventHandler(this.PrintSticker_Click);
            // 
            // temperatureSensorsBindingSource
            // 
            this.temperatureSensorsBindingSource.DataMember = "TemperatureSensors";
            this.temperatureSensorsBindingSource.DataSource = this.coldChain;
            // 
            // temperatureSensorsTableAdapter
            // 
            this.temperatureSensorsTableAdapter.ClearBeforeFill = true;
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // sensorForwardersTableAdapter
            // 
            this.sensorForwardersTableAdapter.ClearBeforeFill = true;
            // 
            // sensorModesTableAdapter
            // 
            this.sensorModesTableAdapter.ClearBeforeFill = true;
            // 
            // Sensor_ID
            // 
            this.Sensor_ID.DataPropertyName = "Sensor_ID";
            this.Sensor_ID.HeaderText = "№";
            this.Sensor_ID.Name = "Sensor_ID";
            this.Sensor_ID.ReadOnly = true;
            this.Sensor_ID.Width = 50;
            // 
            // sensorNameDataGridViewTextBoxColumn
            // 
            this.sensorNameDataGridViewTextBoxColumn.DataPropertyName = "Sensor_Name";
            this.sensorNameDataGridViewTextBoxColumn.HeaderText = "S/N";
            this.sensorNameDataGridViewTextBoxColumn.Name = "sensorNameDataGridViewTextBoxColumn";
            this.sensorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sensorNameDataGridViewTextBoxColumn.Width = 70;
            // 
            // Sensor_Type_Name
            // 
            this.Sensor_Type_Name.DataPropertyName = "Sensor_Type_Name";
            this.Sensor_Type_Name.HeaderText = "Тип";
            this.Sensor_Type_Name.Name = "Sensor_Type_Name";
            this.Sensor_Type_Name.ReadOnly = true;
            // 
            // Branch
            // 
            this.Branch.DataPropertyName = "Branch";
            this.Branch.DataSource = this.branchesBindingSource;
            this.Branch.DisplayMember = "Branch_Name";
            this.Branch.DisplayStyleForCurrentCellOnly = true;
            this.Branch.HeaderText = "Филиал";
            this.Branch.Name = "Branch";
            this.Branch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Branch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Branch.ValueMember = "Warehouse_ID";
            this.Branch.Width = 160;
            // 
            // Ability
            // 
            this.Ability.DataPropertyName = "IsWork";
            this.Ability.DataSource = this.temperatureSensorsAbilityStateBindingSource;
            this.Ability.DisplayMember = "Name";
            this.Ability.DisplayStyleForCurrentCellOnly = true;
            this.Ability.HeaderText = "Исправность";
            this.Ability.Name = "Ability";
            this.Ability.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ability.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ability.ValueMember = "ID";
            this.Ability.Width = 150;
            // 
            // Forwarder_ID
            // 
            this.Forwarder_ID.DataPropertyName = "Forwarder_ID";
            this.Forwarder_ID.DataSource = this.sensorForwardersBindingSource;
            this.Forwarder_ID.DisplayMember = "Forwarder";
            this.Forwarder_ID.DisplayStyleForCurrentCellOnly = true;
            this.Forwarder_ID.HeaderText = "Экспедитор";
            this.Forwarder_ID.Name = "Forwarder_ID";
            this.Forwarder_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Forwarder_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Forwarder_ID.ValueMember = "Forwarder_ID";
            this.Forwarder_ID.Width = 250;
            // 
            // Sensor_Mode_ID
            // 
            this.Sensor_Mode_ID.DataPropertyName = "Sensor_Mode_ID";
            this.Sensor_Mode_ID.DataSource = this.sensorModesBindingSource;
            this.Sensor_Mode_ID.DisplayMember = "Sensor_Mode_Name";
            this.Sensor_Mode_ID.DisplayStyleForCurrentCellOnly = true;
            this.Sensor_Mode_ID.HeaderText = "Режим t°";
            this.Sensor_Mode_ID.Name = "Sensor_Mode_ID";
            this.Sensor_Mode_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Sensor_Mode_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Sensor_Mode_ID.ValueMember = "Sensor_Mode_ID";
            // 
            // Verification_Date
            // 
            this.Verification_Date.DataPropertyName = "Verification_Date";
            this.Verification_Date.HeaderText = "Дата поверки";
            this.Verification_Date.Name = "Verification_Date";
            this.Verification_Date.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Verification_Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Verification_Date.Width = 110;
            // 
            // СoldChainTemperatureSensorsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 562);
            this.Controls.Add(this.dgvSensors);
            this.Controls.Add(this.tsMainMenu);
            this.KeyPreview = true;
            this.Name = "СoldChainTemperatureSensorsWindow";
            this.Text = "СoldChainTemperatureSensorsWindow";
            this.Load += new System.EventHandler(this.СoldChainTemperatureSensorsWindow_Load);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.Controls.SetChildIndex(this.dgvSensors, 0);
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorsAbilityStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorForwardersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorModesBindingSource)).EndInit();
            this.cmsSensors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.temperatureSensorsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbRefreshSensors;
        private System.Windows.Forms.ToolStripButton sbAddSensor;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvSensors;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource temperatureSensorsBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.TemperatureSensorsTableAdapter temperatureSensorsTableAdapter;
        private System.Windows.Forms.BindingSource temperatureSensorsAbilityStateBindingSource;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
        private System.Windows.Forms.ToolStripButton btnPrintSticker;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ContextMenuStrip cmsSensors;
        private System.Windows.Forms.ToolStripMenuItem miPrintSticker;
        private System.Windows.Forms.BindingSource sensorForwardersBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.SensorForwardersTableAdapter sensorForwardersTableAdapter;
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.BindingSource sensorModesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.SensorModesTableAdapter sensorModesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sensor_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sensor_Type_Name;
        private System.Windows.Forms.DataGridViewComboBoxColumn Branch;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ability;
        private System.Windows.Forms.DataGridViewComboBoxColumn Forwarder_ID;
        private System.Windows.Forms.DataGridViewComboBoxColumn Sensor_Mode_ID;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn Verification_Date;
    }
}