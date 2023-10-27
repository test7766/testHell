namespace WMSOffice.Dialogs.ColdChain
{
    partial class EquipmentSensorsBindingEditor
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
            this.scEquipmentSensorsPanel = new System.Windows.Forms.SplitContainer();
            this.grbEquipment = new System.Windows.Forms.GroupBox();
            this.dgvEquipment = new System.Windows.Forms.DataGridView();
            this.equipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.equipmentTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.transportationTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedEquipmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.btnRemoveEquipment = new System.Windows.Forms.Button();
            this.btnAddEquipment = new System.Windows.Forms.Button();
            this.scSensorPlatformsPanel = new System.Windows.Forms.SplitContainer();
            this.grbSensors = new System.Windows.Forms.GroupBox();
            this.dgvSensors = new System.Windows.Forms.DataGridView();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedSensorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemoveSensor = new System.Windows.Forms.Button();
            this.btnAddSensor = new System.Windows.Forms.Button();
            this.grbPlatforms = new System.Windows.Forms.GroupBox();
            this.dgvPlatforms = new System.Windows.Forms.DataGridView();
            this.peronIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedPlatformsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnRemovePlatform = new System.Windows.Forms.Button();
            this.btnAddPlatform = new System.Windows.Forms.Button();
            this.relatedEquipmentTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.RelatedEquipmentTableAdapter();
            this.relatedSensorsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.RelatedSensorsTableAdapter();
            this.relatedPlatformsTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.RelatedPlatformsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbOptions = new System.Windows.Forms.GroupBox();
            this.scEquipmentSensorsPanel.Panel1.SuspendLayout();
            this.scEquipmentSensorsPanel.Panel2.SuspendLayout();
            this.scEquipmentSensorsPanel.SuspendLayout();
            this.grbEquipment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedEquipmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            this.scSensorPlatformsPanel.Panel1.SuspendLayout();
            this.scSensorPlatformsPanel.Panel2.SuspendLayout();
            this.scSensorPlatformsPanel.SuspendLayout();
            this.grbSensors.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedSensorsBindingSource)).BeginInit();
            this.grbPlatforms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatforms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedPlatformsBindingSource)).BeginInit();
            this.grbOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Text = "Сохранить";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // scEquipmentSensorsPanel
            // 
            this.scEquipmentSensorsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scEquipmentSensorsPanel.Location = new System.Drawing.Point(5, 16);
            this.scEquipmentSensorsPanel.Name = "scEquipmentSensorsPanel";
            this.scEquipmentSensorsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scEquipmentSensorsPanel.Panel1
            // 
            this.scEquipmentSensorsPanel.Panel1.Controls.Add(this.grbEquipment);
            // 
            // scEquipmentSensorsPanel.Panel2
            // 
            this.scEquipmentSensorsPanel.Panel2.Controls.Add(this.scSensorPlatformsPanel);
            this.scEquipmentSensorsPanel.Size = new System.Drawing.Size(790, 536);
            this.scEquipmentSensorsPanel.SplitterDistance = 110;
            this.scEquipmentSensorsPanel.TabIndex = 101;
            // 
            // grbEquipment
            // 
            this.grbEquipment.Controls.Add(this.dgvEquipment);
            this.grbEquipment.Controls.Add(this.btnRemoveEquipment);
            this.grbEquipment.Controls.Add(this.btnAddEquipment);
            this.grbEquipment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbEquipment.Location = new System.Drawing.Point(0, 0);
            this.grbEquipment.Name = "grbEquipment";
            this.grbEquipment.Size = new System.Drawing.Size(790, 110);
            this.grbEquipment.TabIndex = 4;
            this.grbEquipment.TabStop = false;
            this.grbEquipment.Text = "Холодильное оборудование:";
            // 
            // dgvEquipment
            // 
            this.dgvEquipment.AllowUserToAddRows = false;
            this.dgvEquipment.AllowUserToDeleteRows = false;
            this.dgvEquipment.AllowUserToResizeRows = false;
            this.dgvEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEquipment.AutoGenerateColumns = false;
            this.dgvEquipment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEquipment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.equipmentIDDataGridViewTextBoxColumn,
            this.equipmentNameDataGridViewTextBoxColumn,
            this.equipmentTypeNameDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.transportationTypeNameDataGridViewTextBoxColumn});
            this.dgvEquipment.DataSource = this.relatedEquipmentBindingSource;
            this.dgvEquipment.Location = new System.Drawing.Point(6, 19);
            this.dgvEquipment.MultiSelect = false;
            this.dgvEquipment.Name = "dgvEquipment";
            this.dgvEquipment.ReadOnly = true;
            this.dgvEquipment.RowHeadersVisible = false;
            this.dgvEquipment.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEquipment.Size = new System.Drawing.Size(778, 56);
            this.dgvEquipment.TabIndex = 0;
            // 
            // equipmentIDDataGridViewTextBoxColumn
            // 
            this.equipmentIDDataGridViewTextBoxColumn.DataPropertyName = "Equipment_ID";
            this.equipmentIDDataGridViewTextBoxColumn.HeaderText = "№";
            this.equipmentIDDataGridViewTextBoxColumn.Name = "equipmentIDDataGridViewTextBoxColumn";
            this.equipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // equipmentNameDataGridViewTextBoxColumn
            // 
            this.equipmentNameDataGridViewTextBoxColumn.DataPropertyName = "Equipment_Name";
            this.equipmentNameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.equipmentNameDataGridViewTextBoxColumn.Name = "equipmentNameDataGridViewTextBoxColumn";
            this.equipmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // equipmentTypeNameDataGridViewTextBoxColumn
            // 
            this.equipmentTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Equipment_Type_Name";
            this.equipmentTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.equipmentTypeNameDataGridViewTextBoxColumn.Name = "equipmentTypeNameDataGridViewTextBoxColumn";
            this.equipmentTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.equipmentTypeNameDataGridViewTextBoxColumn.Width = 170;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Отдел (примечание)";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.ReadOnly = true;
            this.departmentDataGridViewTextBoxColumn.Width = 150;
            // 
            // transportationTypeNameDataGridViewTextBoxColumn
            // 
            this.transportationTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Transportation_Type_Name";
            this.transportationTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип транспортировки";
            this.transportationTypeNameDataGridViewTextBoxColumn.Name = "transportationTypeNameDataGridViewTextBoxColumn";
            this.transportationTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.transportationTypeNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // relatedEquipmentBindingSource
            // 
            this.relatedEquipmentBindingSource.DataMember = "RelatedEquipment";
            this.relatedEquipmentBindingSource.DataSource = this.coldChain;
            // 
            // coldChain
            // 
            this.coldChain.DataSetName = "ColdChain";
            this.coldChain.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnRemoveEquipment
            // 
            this.btnRemoveEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveEquipment.Location = new System.Drawing.Point(703, 81);
            this.btnRemoveEquipment.Name = "btnRemoveEquipment";
            this.btnRemoveEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveEquipment.TabIndex = 2;
            this.btnRemoveEquipment.Text = "Удалить";
            this.btnRemoveEquipment.UseVisualStyleBackColor = true;
            this.btnRemoveEquipment.Click += new System.EventHandler(this.btnRemoveEquipment_Click);
            // 
            // btnAddEquipment
            // 
            this.btnAddEquipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddEquipment.Location = new System.Drawing.Point(613, 81);
            this.btnAddEquipment.Name = "btnAddEquipment";
            this.btnAddEquipment.Size = new System.Drawing.Size(75, 23);
            this.btnAddEquipment.TabIndex = 1;
            this.btnAddEquipment.Text = "Добавить";
            this.btnAddEquipment.UseVisualStyleBackColor = true;
            this.btnAddEquipment.Click += new System.EventHandler(this.btnAddEquipment_Click);
            // 
            // scSensorPlatformsPanel
            // 
            this.scSensorPlatformsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scSensorPlatformsPanel.Location = new System.Drawing.Point(0, 3);
            this.scSensorPlatformsPanel.Name = "scSensorPlatformsPanel";
            this.scSensorPlatformsPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scSensorPlatformsPanel.Panel1
            // 
            this.scSensorPlatformsPanel.Panel1.Controls.Add(this.grbSensors);
            // 
            // scSensorPlatformsPanel.Panel2
            // 
            this.scSensorPlatformsPanel.Panel2.Controls.Add(this.grbPlatforms);
            this.scSensorPlatformsPanel.Size = new System.Drawing.Size(787, 411);
            this.scSensorPlatformsPanel.SplitterDistance = 177;
            this.scSensorPlatformsPanel.TabIndex = 0;
            // 
            // grbSensors
            // 
            this.grbSensors.Controls.Add(this.dgvSensors);
            this.grbSensors.Controls.Add(this.btnRemoveSensor);
            this.grbSensors.Controls.Add(this.btnAddSensor);
            this.grbSensors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbSensors.Location = new System.Drawing.Point(0, 0);
            this.grbSensors.Name = "grbSensors";
            this.grbSensors.Size = new System.Drawing.Size(787, 177);
            this.grbSensors.TabIndex = 6;
            this.grbSensors.TabStop = false;
            this.grbSensors.Text = "Датчики температуры:";
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
            this.serialNumberDataGridViewTextBoxColumn,
            this.sensorTypeNameDataGridViewTextBoxColumn});
            this.dgvSensors.DataSource = this.relatedSensorsBindingSource;
            this.dgvSensors.Location = new System.Drawing.Point(6, 19);
            this.dgvSensors.MultiSelect = false;
            this.dgvSensors.Name = "dgvSensors";
            this.dgvSensors.ReadOnly = true;
            this.dgvSensors.RowHeadersVisible = false;
            this.dgvSensors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSensors.Size = new System.Drawing.Size(778, 126);
            this.dgvSensors.TabIndex = 0;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "Serial_Number";
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "S/N";
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // sensorTypeNameDataGridViewTextBoxColumn
            // 
            this.sensorTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Sensor_Type_Name";
            this.sensorTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.sensorTypeNameDataGridViewTextBoxColumn.Name = "sensorTypeNameDataGridViewTextBoxColumn";
            this.sensorTypeNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // relatedSensorsBindingSource
            // 
            this.relatedSensorsBindingSource.DataMember = "RelatedSensors";
            this.relatedSensorsBindingSource.DataSource = this.coldChain;
            // 
            // btnRemoveSensor
            // 
            this.btnRemoveSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveSensor.Location = new System.Drawing.Point(703, 151);
            this.btnRemoveSensor.Name = "btnRemoveSensor";
            this.btnRemoveSensor.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSensor.TabIndex = 4;
            this.btnRemoveSensor.Text = "Удалить";
            this.btnRemoveSensor.UseVisualStyleBackColor = true;
            this.btnRemoveSensor.Click += new System.EventHandler(this.btnRemoveSensor_Click);
            // 
            // btnAddSensor
            // 
            this.btnAddSensor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSensor.Location = new System.Drawing.Point(613, 151);
            this.btnAddSensor.Name = "btnAddSensor";
            this.btnAddSensor.Size = new System.Drawing.Size(75, 23);
            this.btnAddSensor.TabIndex = 3;
            this.btnAddSensor.Text = "Добавить";
            this.btnAddSensor.UseVisualStyleBackColor = true;
            this.btnAddSensor.Click += new System.EventHandler(this.btnAddSensor_Click);
            // 
            // grbPlatforms
            // 
            this.grbPlatforms.Controls.Add(this.dgvPlatforms);
            this.grbPlatforms.Controls.Add(this.btnRemovePlatform);
            this.grbPlatforms.Controls.Add(this.btnAddPlatform);
            this.grbPlatforms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbPlatforms.Location = new System.Drawing.Point(0, 0);
            this.grbPlatforms.Name = "grbPlatforms";
            this.grbPlatforms.Size = new System.Drawing.Size(787, 230);
            this.grbPlatforms.TabIndex = 6;
            this.grbPlatforms.TabStop = false;
            this.grbPlatforms.Text = "Перроны:";
            // 
            // dgvPlatforms
            // 
            this.dgvPlatforms.AllowUserToAddRows = false;
            this.dgvPlatforms.AllowUserToDeleteRows = false;
            this.dgvPlatforms.AllowUserToResizeRows = false;
            this.dgvPlatforms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlatforms.AutoGenerateColumns = false;
            this.dgvPlatforms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlatforms.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.peronIDDataGridViewTextBoxColumn});
            this.dgvPlatforms.DataSource = this.relatedPlatformsBindingSource;
            this.dgvPlatforms.Location = new System.Drawing.Point(6, 19);
            this.dgvPlatforms.MultiSelect = false;
            this.dgvPlatforms.Name = "dgvPlatforms";
            this.dgvPlatforms.ReadOnly = true;
            this.dgvPlatforms.RowHeadersVisible = false;
            this.dgvPlatforms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlatforms.Size = new System.Drawing.Size(778, 176);
            this.dgvPlatforms.TabIndex = 0;
            // 
            // peronIDDataGridViewTextBoxColumn
            // 
            this.peronIDDataGridViewTextBoxColumn.DataPropertyName = "Peron_ID";
            this.peronIDDataGridViewTextBoxColumn.HeaderText = "№";
            this.peronIDDataGridViewTextBoxColumn.Name = "peronIDDataGridViewTextBoxColumn";
            this.peronIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // relatedPlatformsBindingSource
            // 
            this.relatedPlatformsBindingSource.DataMember = "RelatedPlatforms";
            this.relatedPlatformsBindingSource.DataSource = this.coldChain;
            // 
            // btnRemovePlatform
            // 
            this.btnRemovePlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemovePlatform.Location = new System.Drawing.Point(703, 201);
            this.btnRemovePlatform.Name = "btnRemovePlatform";
            this.btnRemovePlatform.Size = new System.Drawing.Size(75, 23);
            this.btnRemovePlatform.TabIndex = 4;
            this.btnRemovePlatform.Text = "Удалить";
            this.btnRemovePlatform.UseVisualStyleBackColor = true;
            this.btnRemovePlatform.Click += new System.EventHandler(this.btnRemovePlatform_Click);
            // 
            // btnAddPlatform
            // 
            this.btnAddPlatform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddPlatform.Location = new System.Drawing.Point(613, 201);
            this.btnAddPlatform.Name = "btnAddPlatform";
            this.btnAddPlatform.Size = new System.Drawing.Size(75, 23);
            this.btnAddPlatform.TabIndex = 3;
            this.btnAddPlatform.Text = "Добавить";
            this.btnAddPlatform.UseVisualStyleBackColor = true;
            this.btnAddPlatform.Click += new System.EventHandler(this.btnAddPlatform_Click);
            // 
            // relatedEquipmentTableAdapter
            // 
            this.relatedEquipmentTableAdapter.ClearBeforeFill = true;
            // 
            // relatedSensorsTableAdapter
            // 
            this.relatedSensorsTableAdapter.ClearBeforeFill = true;
            // 
            // relatedPlatformsTableAdapter
            // 
            this.relatedPlatformsTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Equipment_ID";
            this.dataGridViewTextBoxColumn1.HeaderText = "№";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Equipment_Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Название";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Equipment_Type_Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 170;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Department";
            this.dataGridViewTextBoxColumn4.HeaderText = "Отдел (примечание)";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Transportation_Type_Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Тип транспортировки";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 200;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Serial_Number";
            this.dataGridViewTextBoxColumn6.HeaderText = "S/N";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Sensor_Type_Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Тип";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Peron_ID";
            this.dataGridViewTextBoxColumn8.HeaderText = "№";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // grbOptions
            // 
            this.grbOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbOptions.Controls.Add(this.scEquipmentSensorsPanel);
            this.grbOptions.Location = new System.Drawing.Point(12, 1);
            this.grbOptions.Name = "grbOptions";
            this.grbOptions.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.grbOptions.Size = new System.Drawing.Size(800, 555);
            this.grbOptions.TabIndex = 4;
            this.grbOptions.TabStop = false;
            // 
            // EquipmentSensorsBindingEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 605);
            this.Controls.Add(this.grbOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "EquipmentSensorsBindingEditor";
            this.Text = "Редактор текущих закреплений";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EquipmentSensorsBindingEditor_FormClosing);
            this.Controls.SetChildIndex(this.grbOptions, 0);
            this.scEquipmentSensorsPanel.Panel1.ResumeLayout(false);
            this.scEquipmentSensorsPanel.Panel2.ResumeLayout(false);
            this.scEquipmentSensorsPanel.ResumeLayout(false);
            this.grbEquipment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEquipment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedEquipmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            this.scSensorPlatformsPanel.Panel1.ResumeLayout(false);
            this.scSensorPlatformsPanel.Panel2.ResumeLayout(false);
            this.scSensorPlatformsPanel.ResumeLayout(false);
            this.grbSensors.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSensors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedSensorsBindingSource)).EndInit();
            this.grbPlatforms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlatforms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.relatedPlatformsBindingSource)).EndInit();
            this.grbOptions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer scEquipmentSensorsPanel;
        private System.Windows.Forms.SplitContainer scSensorPlatformsPanel;
        private System.Windows.Forms.DataGridView dgvEquipment;
        private System.Windows.Forms.DataGridView dgvSensors;
        private System.Windows.Forms.DataGridView dgvPlatforms;
        private System.Windows.Forms.Button btnRemoveEquipment;
        private System.Windows.Forms.Button btnAddEquipment;
        private System.Windows.Forms.Button btnRemoveSensor;
        private System.Windows.Forms.Button btnAddSensor;
        private System.Windows.Forms.Button btnRemovePlatform;
        private System.Windows.Forms.Button btnAddPlatform;
        private System.Windows.Forms.BindingSource relatedEquipmentBindingSource;
        private WMSOffice.Data.ColdChain coldChain;
        private WMSOffice.Data.ColdChainTableAdapters.RelatedEquipmentTableAdapter relatedEquipmentTableAdapter;
        private System.Windows.Forms.BindingSource relatedSensorsBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.RelatedSensorsTableAdapter relatedSensorsTableAdapter;
        private System.Windows.Forms.BindingSource relatedPlatformsBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.RelatedPlatformsTableAdapter relatedPlatformsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn peronIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn equipmentTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn transportationTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.GroupBox grbOptions;
        private System.Windows.Forms.GroupBox grbEquipment;
        private System.Windows.Forms.GroupBox grbSensors;
        private System.Windows.Forms.GroupBox grbPlatforms;
    }
}