namespace WMSOffice.Dialogs.InterBranch
{
    partial class DeliveryTransportPlanCarForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDeliveries = new System.Windows.Forms.ComboBox();
            this.tSPDeliveriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.interbranch = new WMSOffice.Data.Interbranch();
            this.cmbRamps = new System.Windows.Forms.ComboBox();
            this.tSPRampsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.tbRouteNumber = new System.Windows.Forms.TextBox();
            this.dtpPeriod = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbRouteInformation = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFactPallets = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbCarVolumes = new System.Windows.Forms.ComboBox();
            this.tSPCarVolumesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.trackVolume = new System.Windows.Forms.TrackBar();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbShipmentTypeName = new System.Windows.Forms.TextBox();
            this.lnkVolume = new System.Windows.Forms.LinkLabel();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMaxVolume = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tSP_DeliveriesTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.TSP_DeliveriesTableAdapter();
            this.tSP_RampsTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.TSP_RampsTableAdapter();
            this.tSP_Car_VolumesTableAdapter = new WMSOffice.Data.InterbranchTableAdapters.TSP_Car_VolumesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSPDeliveriesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPRampsBindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSPCarVolumesBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(921, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1011, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 398);
            this.pnlButtons.Size = new System.Drawing.Size(384, 43);
            this.pnlButtons.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Направление :";
            // 
            // cmbDeliveries
            // 
            this.cmbDeliveries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDeliveries.DataSource = this.tSPDeliveriesBindingSource;
            this.cmbDeliveries.DisplayMember = "Delivery_Name_Full";
            this.cmbDeliveries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliveries.FormattingEnabled = true;
            this.cmbDeliveries.Location = new System.Drawing.Point(103, 37);
            this.cmbDeliveries.Name = "cmbDeliveries";
            this.cmbDeliveries.Size = new System.Drawing.Size(251, 21);
            this.cmbDeliveries.TabIndex = 3;
            this.cmbDeliveries.ValueMember = "Delivery_ID";
            // 
            // tSPDeliveriesBindingSource
            // 
            this.tSPDeliveriesBindingSource.DataMember = "TSP_Deliveries";
            this.tSPDeliveriesBindingSource.DataSource = this.interbranch;
            // 
            // interbranch
            // 
            this.interbranch.DataSetName = "Interbranch";
            this.interbranch.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbRamps
            // 
            this.cmbRamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRamps.DataSource = this.tSPRampsBindingSource;
            this.cmbRamps.DisplayMember = "Ramp_Name";
            this.cmbRamps.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRamps.FormattingEnabled = true;
            this.cmbRamps.Location = new System.Drawing.Point(91, 22);
            this.cmbRamps.Name = "cmbRamps";
            this.cmbRamps.Size = new System.Drawing.Size(251, 21);
            this.cmbRamps.TabIndex = 1;
            this.cmbRamps.ValueMember = "Ramp_ID";
            // 
            // tSPRampsBindingSource
            // 
            this.tSPRampsBindingSource.DataMember = "TSP_Ramps";
            this.tSPRampsBindingSource.DataSource = this.interbranch;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Рампа :";
            // 
            // tbRouteNumber
            // 
            this.tbRouteNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbRouteNumber.Location = new System.Drawing.Point(91, 51);
            this.tbRouteNumber.Name = "tbRouteNumber";
            this.tbRouteNumber.ReadOnly = true;
            this.tbRouteNumber.Size = new System.Drawing.Size(100, 20);
            this.tbRouteNumber.TabIndex = 3;
            // 
            // dtpPeriod
            // 
            this.dtpPeriod.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriod.Enabled = false;
            this.dtpPeriod.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriod.Location = new System.Drawing.Point(103, 8);
            this.dtpPeriod.Name = "dtpPeriod";
            this.dtpPeriod.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriod.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дата :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Время с :";
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.CustomFormat = "HH:mm";
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeFrom.Location = new System.Drawing.Point(91, 51);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.ShowUpDown = true;
            this.dtpTimeFrom.Size = new System.Drawing.Size(50, 20);
            this.dtpTimeFrom.TabIndex = 3;
            this.dtpTimeFrom.ValueChanged += new System.EventHandler(this.dtpTimeFrom_ValueChanged);
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTimeTo.CustomFormat = "HH:mm";
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeTo.Location = new System.Drawing.Point(292, 51);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.ShowUpDown = true;
            this.dtpTimeTo.Size = new System.Drawing.Size(50, 20);
            this.dtpTimeTo.TabIndex = 5;
            this.dtpTimeTo.ValueChanged += new System.EventHandler(this.dtpTimeTo_ValueChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(211, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Время по :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "№ М/Л :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Описание :";
            // 
            // tbRouteInformation
            // 
            this.tbRouteInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRouteInformation.BackColor = System.Drawing.SystemColors.Window;
            this.tbRouteInformation.Location = new System.Drawing.Point(91, 80);
            this.tbRouteInformation.Name = "tbRouteInformation";
            this.tbRouteInformation.ReadOnly = true;
            this.tbRouteInformation.Size = new System.Drawing.Size(251, 20);
            this.tbRouteInformation.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbFactPallets);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.cmbCarVolumes);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbRouteInformation);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tbRouteNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 115);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация об авто";
            // 
            // tbFactPallets
            // 
            this.tbFactPallets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbFactPallets.BackColor = System.Drawing.SystemColors.Window;
            this.tbFactPallets.Location = new System.Drawing.Point(292, 51);
            this.tbFactPallets.Name = "tbFactPallets";
            this.tbFactPallets.ReadOnly = true;
            this.tbFactPallets.Size = new System.Drawing.Size(50, 20);
            this.tbFactPallets.TabIndex = 5;
            this.tbFactPallets.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(222, 55);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Паллет :";
            // 
            // cmbCarVolumes
            // 
            this.cmbCarVolumes.DataSource = this.tSPCarVolumesBindingSource;
            this.cmbCarVolumes.DisplayMember = "Volume";
            this.cmbCarVolumes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarVolumes.FormattingEnabled = true;
            this.cmbCarVolumes.Location = new System.Drawing.Point(91, 22);
            this.cmbCarVolumes.Name = "cmbCarVolumes";
            this.cmbCarVolumes.Size = new System.Drawing.Size(100, 21);
            this.cmbCarVolumes.TabIndex = 1;
            this.cmbCarVolumes.ValueMember = "CV_ID";
            this.cmbCarVolumes.SelectedValueChanged += new System.EventHandler(this.cmbCarVolumes_SelectedValueChanged);
            // 
            // tSPCarVolumesBindingSource
            // 
            this.tSPCarVolumesBindingSource.DataMember = "TSP_Car_Volumes";
            this.tSPCarVolumesBindingSource.DataSource = this.interbranch;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Объем, м³ :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cmbRamps);
            this.groupBox2.Controls.Add(this.dtpTimeTo);
            this.groupBox2.Controls.Add(this.dtpTimeFrom);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 85);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Расписание отправки";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(245)))), ((int)(((byte)(213)))));
            this.pnlHeader.Controls.Add(this.dtpPeriod);
            this.pnlHeader.Controls.Add(this.label4);
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.cmbDeliveries);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(384, 73);
            this.pnlHeader.TabIndex = 0;
            // 
            // trackVolume
            // 
            this.trackVolume.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trackVolume.Location = new System.Drawing.Point(91, 53);
            this.trackVolume.Maximum = 20;
            this.trackVolume.Name = "trackVolume";
            this.trackVolume.Size = new System.Drawing.Size(251, 45);
            this.trackVolume.TabIndex = 3;
            this.trackVolume.ValueChanged += new System.EventHandler(this.trackVolume_ValueChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbShipmentTypeName);
            this.groupBox3.Controls.Add(this.lnkVolume);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.lblMaxVolume);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.trackVolume);
            this.groupBox3.Location = new System.Drawing.Point(12, 291);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 100);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Информация о заказе";
            // 
            // tbShipmentTypeName
            // 
            this.tbShipmentTypeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbShipmentTypeName.BackColor = System.Drawing.SystemColors.Window;
            this.tbShipmentTypeName.Location = new System.Drawing.Point(91, 22);
            this.tbShipmentTypeName.Name = "tbShipmentTypeName";
            this.tbShipmentTypeName.ReadOnly = true;
            this.tbShipmentTypeName.Size = new System.Drawing.Size(251, 20);
            this.tbShipmentTypeName.TabIndex = 1;
            // 
            // lnkVolume
            // 
            this.lnkVolume.AutoSize = true;
            this.lnkVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lnkVolume.Location = new System.Drawing.Point(91, 82);
            this.lnkVolume.Name = "lnkVolume";
            this.lnkVolume.Size = new System.Drawing.Size(32, 13);
            this.lnkVolume.TabIndex = 4;
            this.lnkVolume.TabStop = true;
            this.lnkVolume.Text = "0.00";
            this.lnkVolume.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkVolume_LinkClicked);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Тип :";
            // 
            // lblMaxVolume
            // 
            this.lblMaxVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMaxVolume.AutoSize = true;
            this.lblMaxVolume.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblMaxVolume.ForeColor = System.Drawing.Color.Red;
            this.lblMaxVolume.Location = new System.Drawing.Point(310, 82);
            this.lblMaxVolume.Name = "lblMaxVolume";
            this.lblMaxVolume.Size = new System.Drawing.Size(32, 13);
            this.lblMaxVolume.TabIndex = 5;
            this.lblMaxVolume.Text = "0.00";
            this.lblMaxVolume.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Объем, м³ :";
            // 
            // tSP_DeliveriesTableAdapter
            // 
            this.tSP_DeliveriesTableAdapter.ClearBeforeFill = true;
            // 
            // tSP_RampsTableAdapter
            // 
            this.tSP_RampsTableAdapter.ClearBeforeFill = true;
            // 
            // tSP_Car_VolumesTableAdapter
            // 
            this.tSP_Car_VolumesTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryTransportPlanCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 441);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "DeliveryTransportPlanCarForm";
            this.Text = "Планирование авто";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DeliveryTransportPlanCarForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.pnlHeader, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tSPDeliveriesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.interbranch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSPRampsBindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tSPCarVolumesBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackVolume)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDeliveries;
        private System.Windows.Forms.ComboBox cmbRamps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRouteNumber;
        private System.Windows.Forms.DateTimePicker dtpPeriod;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbRouteInformation;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCarVolumes;
        private System.Windows.Forms.Label lblMaxVolume;
        private System.Windows.Forms.BindingSource tSPDeliveriesBindingSource;
        private WMSOffice.Data.Interbranch interbranch;
        private System.Windows.Forms.BindingSource tSPRampsBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.TSP_DeliveriesTableAdapter tSP_DeliveriesTableAdapter;
        private WMSOffice.Data.InterbranchTableAdapters.TSP_RampsTableAdapter tSP_RampsTableAdapter;
        private System.Windows.Forms.BindingSource tSPCarVolumesBindingSource;
        private WMSOffice.Data.InterbranchTableAdapters.TSP_Car_VolumesTableAdapter tSP_Car_VolumesTableAdapter;
        private System.Windows.Forms.TextBox tbShipmentTypeName;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbFactPallets;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.LinkLabel lnkVolume;
    }
}