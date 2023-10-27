namespace WMSOffice.Dialogs.ColdChain
{
    partial class TemperatureSensorRegistrationForm
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
            this.lblSensorNumber = new System.Windows.Forms.Label();
            this.tbSensorNumber = new System.Windows.Forms.TextBox();
            this.pbSensor = new System.Windows.Forms.PictureBox();
            this.cmbBranches = new System.Windows.Forms.ComboBox();
            this.branchesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coldChain = new WMSOffice.Data.ColdChain();
            this.lblBranch = new System.Windows.Forms.Label();
            this.branchesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter();
            this.lblSensorType = new System.Windows.Forms.Label();
            this.cmbSensorType = new System.Windows.Forms.ComboBox();
            this.sensorTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensorTypesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.SensorTypesTableAdapter();
            this.lblVerificationDate = new System.Windows.Forms.Label();
            this.dtpVerificationDate = new System.Windows.Forms.DateTimePicker();
            this.cmbSensorMode = new System.Windows.Forms.ComboBox();
            this.sensorModesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sensorModesTableAdapter = new WMSOffice.Data.ColdChainTableAdapters.SensorModesTableAdapter();
            this.lblMode = new System.Windows.Forms.Label();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorModesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(179, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 158);
            this.pnlButtons.Size = new System.Drawing.Size(351, 43);
            // 
            // lblSensorNumber
            // 
            this.lblSensorNumber.AutoSize = true;
            this.lblSensorNumber.Location = new System.Drawing.Point(97, 17);
            this.lblSensorNumber.Name = "lblSensorNumber";
            this.lblSensorNumber.Size = new System.Drawing.Size(30, 13);
            this.lblSensorNumber.TabIndex = 0;
            this.lblSensorNumber.Text = "S/N:";
            // 
            // tbSensorNumber
            // 
            this.tbSensorNumber.Location = new System.Drawing.Point(163, 13);
            this.tbSensorNumber.Name = "tbSensorNumber";
            this.tbSensorNumber.Size = new System.Drawing.Size(174, 20);
            this.tbSensorNumber.TabIndex = 1;
            this.tbSensorNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSensorNumber_KeyDown);
            this.tbSensorNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSensorNumber_KeyPress);
            // 
            // pbSensor
            // 
            this.pbSensor.Image = global::WMSOffice.Properties.Resources.Sensor;
            this.pbSensor.Location = new System.Drawing.Point(12, 13);
            this.pbSensor.Name = "pbSensor";
            this.pbSensor.Size = new System.Drawing.Size(75, 75);
            this.pbSensor.TabIndex = 103;
            this.pbSensor.TabStop = false;
            // 
            // cmbBranches
            // 
            this.cmbBranches.DataSource = this.branchesBindingSource;
            this.cmbBranches.DisplayMember = "Branch_Name";
            this.cmbBranches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBranches.FormattingEnabled = true;
            this.cmbBranches.Location = new System.Drawing.Point(163, 71);
            this.cmbBranches.Name = "cmbBranches";
            this.cmbBranches.Size = new System.Drawing.Size(174, 21);
            this.cmbBranches.TabIndex = 5;
            this.cmbBranches.ValueMember = "Warehouse_ID";
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
            // lblBranch
            // 
            this.lblBranch.AutoSize = true;
            this.lblBranch.Location = new System.Drawing.Point(97, 75);
            this.lblBranch.Name = "lblBranch";
            this.lblBranch.Size = new System.Drawing.Size(51, 13);
            this.lblBranch.TabIndex = 4;
            this.lblBranch.Text = "Филиал:";
            // 
            // branchesTableAdapter
            // 
            this.branchesTableAdapter.ClearBeforeFill = true;
            // 
            // lblSensorType
            // 
            this.lblSensorType.AutoSize = true;
            this.lblSensorType.Location = new System.Drawing.Point(97, 46);
            this.lblSensorType.Name = "lblSensorType";
            this.lblSensorType.Size = new System.Drawing.Size(29, 13);
            this.lblSensorType.TabIndex = 2;
            this.lblSensorType.Text = "Тип:";
            // 
            // cmbSensorType
            // 
            this.cmbSensorType.DataSource = this.sensorTypesBindingSource;
            this.cmbSensorType.DisplayMember = "Sensor_Type_Name";
            this.cmbSensorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorType.FormattingEnabled = true;
            this.cmbSensorType.Location = new System.Drawing.Point(163, 42);
            this.cmbSensorType.Name = "cmbSensorType";
            this.cmbSensorType.Size = new System.Drawing.Size(174, 21);
            this.cmbSensorType.TabIndex = 3;
            this.cmbSensorType.ValueMember = "Sensor_Type_ID";
            // 
            // sensorTypesBindingSource
            // 
            this.sensorTypesBindingSource.DataMember = "SensorTypes";
            this.sensorTypesBindingSource.DataSource = this.coldChain;
            // 
            // sensorTypesTableAdapter
            // 
            this.sensorTypesTableAdapter.ClearBeforeFill = true;
            // 
            // lblVerificationDate
            // 
            this.lblVerificationDate.AutoSize = true;
            this.lblVerificationDate.Location = new System.Drawing.Point(97, 129);
            this.lblVerificationDate.Name = "lblVerificationDate";
            this.lblVerificationDate.Size = new System.Drawing.Size(52, 26);
            this.lblVerificationDate.TabIndex = 8;
            this.lblVerificationDate.Text = "Дата \r\nповерки:";
            // 
            // dtpVerificationDate
            // 
            this.dtpVerificationDate.Checked = false;
            this.dtpVerificationDate.CustomFormat = "dd / MM / yyyy";
            this.dtpVerificationDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpVerificationDate.Location = new System.Drawing.Point(163, 135);
            this.dtpVerificationDate.Name = "dtpVerificationDate";
            this.dtpVerificationDate.ShowCheckBox = true;
            this.dtpVerificationDate.Size = new System.Drawing.Size(174, 20);
            this.dtpVerificationDate.TabIndex = 9;
            // 
            // cmbSensorMode
            // 
            this.cmbSensorMode.DataSource = this.sensorModesBindingSource;
            this.cmbSensorMode.DisplayMember = "Sensor_Mode_Name";
            this.cmbSensorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSensorMode.FormattingEnabled = true;
            this.cmbSensorMode.Location = new System.Drawing.Point(163, 100);
            this.cmbSensorMode.Name = "cmbSensorMode";
            this.cmbSensorMode.Size = new System.Drawing.Size(174, 21);
            this.cmbSensorMode.TabIndex = 7;
            this.cmbSensorMode.ValueMember = "Sensor_Mode_ID";
            // 
            // sensorModesBindingSource
            // 
            this.sensorModesBindingSource.DataMember = "SensorModes";
            this.sensorModesBindingSource.DataSource = this.coldChain;
            // 
            // sensorModesTableAdapter
            // 
            this.sensorModesTableAdapter.ClearBeforeFill = true;
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Location = new System.Drawing.Point(97, 104);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(55, 13);
            this.lblMode.TabIndex = 6;
            this.lblMode.Text = "Режим t°:";
            // 
            // TemperatureSensorRegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 201);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.cmbSensorMode);
            this.Controls.Add(this.dtpVerificationDate);
            this.Controls.Add(this.lblVerificationDate);
            this.Controls.Add(this.cmbSensorType);
            this.Controls.Add(this.lblSensorType);
            this.Controls.Add(this.lblBranch);
            this.Controls.Add(this.cmbBranches);
            this.Controls.Add(this.lblSensorNumber);
            this.Controls.Add(this.pbSensor);
            this.Controls.Add(this.tbSensorNumber);
            this.Name = "TemperatureSensorRegistrationForm";
            this.Text = "Регистрация нового датчика температуры";
            this.Load += new System.EventHandler(this.TemperatureSensorRegistrationForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TemperatureSensorRegistrationForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.tbSensorNumber, 0);
            this.Controls.SetChildIndex(this.pbSensor, 0);
            this.Controls.SetChildIndex(this.lblSensorNumber, 0);
            this.Controls.SetChildIndex(this.cmbBranches, 0);
            this.Controls.SetChildIndex(this.lblBranch, 0);
            this.Controls.SetChildIndex(this.lblSensorType, 0);
            this.Controls.SetChildIndex(this.cmbSensorType, 0);
            this.Controls.SetChildIndex(this.lblVerificationDate, 0);
            this.Controls.SetChildIndex(this.dtpVerificationDate, 0);
            this.Controls.SetChildIndex(this.cmbSensorMode, 0);
            this.Controls.SetChildIndex(this.lblMode, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.branchesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coldChain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sensorModesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSensorNumber;
        private System.Windows.Forms.TextBox tbSensorNumber;
        private System.Windows.Forms.PictureBox pbSensor;
        private System.Windows.Forms.ComboBox cmbBranches;
        private System.Windows.Forms.Label lblBranch;
        private WMSOffice.Data.ColdChain coldChain;
        private System.Windows.Forms.BindingSource branchesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.BranchesTableAdapter branchesTableAdapter;
        private System.Windows.Forms.Label lblSensorType;
        private System.Windows.Forms.ComboBox cmbSensorType;
        private System.Windows.Forms.BindingSource sensorTypesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.SensorTypesTableAdapter sensorTypesTableAdapter;
        private System.Windows.Forms.Label lblVerificationDate;
        private System.Windows.Forms.DateTimePicker dtpVerificationDate;
        private System.Windows.Forms.ComboBox cmbSensorMode;
        private System.Windows.Forms.BindingSource sensorModesBindingSource;
        private WMSOffice.Data.ColdChainTableAdapters.SensorModesTableAdapter sensorModesTableAdapter;
        private System.Windows.Forms.Label lblMode;
    }
}