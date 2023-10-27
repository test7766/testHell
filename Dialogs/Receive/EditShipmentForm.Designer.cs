namespace WMSOffice.Dialogs.Receive
{
    partial class EditShipmentForm
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
            this.tbShipmentID = new System.Windows.Forms.TextBox();
            this.shipmentDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.tbVendorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCarNumber = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpShipmentDate = new System.Windows.Forms.DateTimePicker();
            this.tbPalletsQty = new System.Windows.Forms.TextBox();
            this.dtpTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTimeTo = new System.Windows.Forms.DateTimePicker();
            this.pnlData = new System.Windows.Forms.Panel();
            this.cmbRamp = new System.Windows.Forms.ComboBox();
            this.rampsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.shipmentDetailTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.ShipmentDetailTableAdapter();
            this.rampsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.RampsTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            this.pnlData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rampsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(1223, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(1313, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 348);
            this.pnlButtons.Size = new System.Drawing.Size(377, 43);
            this.pnlButtons.TabIndex = 1;
            // 
            // tbShipmentID
            // 
            this.tbShipmentID.BackColor = System.Drawing.SystemColors.Window;
            this.tbShipmentID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentDetailBindingSource, "Shipment_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbShipmentID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbShipmentID.Location = new System.Drawing.Point(97, 8);
            this.tbShipmentID.Name = "tbShipmentID";
            this.tbShipmentID.ReadOnly = true;
            this.tbShipmentID.Size = new System.Drawing.Size(271, 22);
            this.tbShipmentID.TabIndex = 106;
            this.tbShipmentID.TabStop = false;
            // 
            // shipmentDetailBindingSource
            // 
            this.shipmentDetailBindingSource.DataMember = "ShipmentDetail";
            this.shipmentDetailBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tbVendorName
            // 
            this.tbVendorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbVendorName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentDetailBindingSource, "Vendor_Name", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbVendorName.Location = new System.Drawing.Point(97, 44);
            this.tbVendorName.Multiline = true;
            this.tbVendorName.Name = "tbVendorName";
            this.tbVendorName.ReadOnly = true;
            this.tbVendorName.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbVendorName.Size = new System.Drawing.Size(271, 40);
            this.tbVendorName.TabIndex = 108;
            this.tbVendorName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 16);
            this.label3.TabIndex = 107;
            this.label3.Text = "Поставщик:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 105;
            this.label1.Text = "№ поставки:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 109;
            this.label2.Text = "Дата:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 16);
            this.label4.TabIndex = 110;
            this.label4.Text = "Паллет:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 111;
            this.label5.Text = "Время с:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 246);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 16);
            this.label6.TabIndex = 112;
            this.label6.Text = "Время по:";
            // 
            // tbCarNumber
            // 
            this.tbCarNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbCarNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentDetailBindingSource, "CarNumber", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbCarNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCarNumber.Location = new System.Drawing.Point(97, 277);
            this.tbCarNumber.Name = "tbCarNumber";
            this.tbCarNumber.Size = new System.Drawing.Size(271, 22);
            this.tbCarNumber.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(3, 280);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 113;
            this.label7.Text = "№ машины:";
            // 
            // tbComments
            // 
            this.tbComments.BackColor = System.Drawing.SystemColors.Window;
            this.tbComments.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentDetailBindingSource, "ShipmentDescription", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbComments.Location = new System.Drawing.Point(97, 312);
            this.tbComments.Name = "tbComments";
            this.tbComments.Size = new System.Drawing.Size(271, 22);
            this.tbComments.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(3, 315);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 16);
            this.label8.TabIndex = 115;
            this.label8.Text = "Примечание:";
            // 
            // dtpShipmentDate
            // 
            this.dtpShipmentDate.CustomFormat = "dd.MM.yyyy";
            this.dtpShipmentDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.shipmentDetailBindingSource, "ShipDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtpShipmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpShipmentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpShipmentDate.Location = new System.Drawing.Point(97, 105);
            this.dtpShipmentDate.Name = "dtpShipmentDate";
            this.dtpShipmentDate.Size = new System.Drawing.Size(121, 22);
            this.dtpShipmentDate.TabIndex = 0;
            // 
            // tbPalletsQty
            // 
            this.tbPalletsQty.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.shipmentDetailBindingSource, "CountPL", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "N0"));
            this.tbPalletsQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPalletsQty.Location = new System.Drawing.Point(97, 140);
            this.tbPalletsQty.Name = "tbPalletsQty";
            this.tbPalletsQty.Size = new System.Drawing.Size(121, 22);
            this.tbPalletsQty.TabIndex = 1;
            // 
            // dtpTimeFrom
            // 
            this.dtpTimeFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTimeFrom.CustomFormat = "HH:mm";
            this.dtpTimeFrom.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.shipmentDetailBindingSource, "TimeFrom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "t"));
            this.dtpTimeFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeFrom.Location = new System.Drawing.Point(97, 209);
            this.dtpTimeFrom.Name = "dtpTimeFrom";
            this.dtpTimeFrom.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dtpTimeFrom.ShowUpDown = true;
            this.dtpTimeFrom.Size = new System.Drawing.Size(121, 22);
            this.dtpTimeFrom.TabIndex = 3;
            // 
            // dtpTimeTo
            // 
            this.dtpTimeTo.CustomFormat = "HH:mm";
            this.dtpTimeTo.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.shipmentDetailBindingSource, "TimeTo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged, null, "t"));
            this.dtpTimeTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTimeTo.Location = new System.Drawing.Point(97, 243);
            this.dtpTimeTo.Name = "dtpTimeTo";
            this.dtpTimeTo.ShowUpDown = true;
            this.dtpTimeTo.Size = new System.Drawing.Size(121, 22);
            this.dtpTimeTo.TabIndex = 4;
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.cmbRamp);
            this.pnlData.Controls.Add(this.label9);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Controls.Add(this.dtpTimeTo);
            this.pnlData.Controls.Add(this.label3);
            this.pnlData.Controls.Add(this.dtpTimeFrom);
            this.pnlData.Controls.Add(this.tbVendorName);
            this.pnlData.Controls.Add(this.tbPalletsQty);
            this.pnlData.Controls.Add(this.tbShipmentID);
            this.pnlData.Controls.Add(this.dtpShipmentDate);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Controls.Add(this.tbComments);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.label8);
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.tbCarNumber);
            this.pnlData.Controls.Add(this.label6);
            this.pnlData.Controls.Add(this.label7);
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlData.Location = new System.Drawing.Point(0, 0);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(377, 346);
            this.pnlData.TabIndex = 0;
            // 
            // cmbRamp
            // 
            this.cmbRamp.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.shipmentDetailBindingSource, "Ramp_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbRamp.DataSource = this.rampsBindingSource;
            this.cmbRamp.DisplayMember = "RampName";
            this.cmbRamp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRamp.FormattingEnabled = true;
            this.cmbRamp.Location = new System.Drawing.Point(97, 174);
            this.cmbRamp.Name = "cmbRamp";
            this.cmbRamp.Size = new System.Drawing.Size(121, 21);
            this.cmbRamp.TabIndex = 2;
            this.cmbRamp.ValueMember = "Ramp_ID";
            // 
            // rampsBindingSource
            // 
            this.rampsBindingSource.DataMember = "Ramps";
            this.rampsBindingSource.DataSource = this.receive;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(3, 176);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 16);
            this.label9.TabIndex = 116;
            this.label9.Text = "Рампа:";
            // 
            // shipmentDetailTableAdapter
            // 
            this.shipmentDetailTableAdapter.ClearBeforeFill = true;
            // 
            // rampsTableAdapter
            // 
            this.rampsTableAdapter.ClearBeforeFill = true;
            // 
            // EditShipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 391);
            this.Controls.Add(this.pnlData);
            this.Name = "EditShipmentForm";
            this.Text = "Запись на разгрузку";
            this.Load += new System.EventHandler(this.EditShipmentForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditShipmentForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlData, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.shipmentDetailBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rampsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbShipmentID;
        private System.Windows.Forms.TextBox tbVendorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCarNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpShipmentDate;
        private System.Windows.Forms.TextBox tbPalletsQty;
        private System.Windows.Forms.DateTimePicker dtpTimeFrom;
        private System.Windows.Forms.DateTimePicker dtpTimeTo;
        private System.Windows.Forms.Panel pnlData;
        private WMSOffice.Data.Receive receive;
        private System.Windows.Forms.BindingSource shipmentDetailBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.ShipmentDetailTableAdapter shipmentDetailTableAdapter;
        private System.Windows.Forms.ComboBox cmbRamp;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource rampsBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.RampsTableAdapter rampsTableAdapter;
    }
}