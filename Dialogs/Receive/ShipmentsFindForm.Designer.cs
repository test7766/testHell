namespace WMSOffice.Dialogs.Receive
{
    partial class ShipmentsFindForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvShipments = new System.Windows.Forms.DataGridView();
            this.rampsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receive = new WMSOffice.Data.Receive();
            this.freeShipmentsOnDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.freeShipmentsOnDateTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.FreeShipmentsOnDateTableAdapter();
            this.rampsTableAdapter = new WMSOffice.Data.ReceiveTableAdapters.RampsTableAdapter();
            this.tsMainMenu = new System.Windows.Forms.ToolStrip();
            this.sbExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.dgvcShipmentSignColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.SelfDelivery = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countPLDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ramp_ID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TimeFromRamp = new WMSOffice.Controls.Custom.DataGridViewTimeColumn();
            this.TimeToRamp = new WMSOffice.Controls.Custom.DataGridViewTimeColumn();
            this.F = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.P = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanDate = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.carNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlanDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactTimeIn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactTimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Filial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rampsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.freeShipmentsOnDateBindingSource)).BeginInit();
            this.tsMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(9645, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(9735, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 556);
            this.pnlButtons.Size = new System.Drawing.Size(1259, 43);
            // 
            // dgvShipments
            // 
            this.dgvShipments.AllowUserToAddRows = false;
            this.dgvShipments.AllowUserToDeleteRows = false;
            this.dgvShipments.AllowUserToResizeRows = false;
            this.dgvShipments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvShipments.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipments.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvShipments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShipments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcShipmentSignColumn,
            this.SelfDelivery,
            this.shipmentIDDataGridViewTextBoxColumn,
            this.vendorIDDataGridViewTextBoxColumn,
            this.vendorNameDataGridViewTextBoxColumn,
            this.countPLDataGridViewTextBoxColumn,
            this.Ramp_ID,
            this.TimeFromRamp,
            this.TimeToRamp,
            this.F,
            this.P,
            this.StatusName,
            this.PlanDate,
            this.carNumber,
            this.description,
            this.FactDate,
            this.FactTime,
            this.PlanDuration,
            this.FactTimeIn,
            this.FactTimeOut,
            this.Filial});
            this.dgvShipments.DataSource = this.freeShipmentsOnDateBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvShipments.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvShipments.Location = new System.Drawing.Point(0, 58);
            this.dgvShipments.MultiSelect = false;
            this.dgvShipments.Name = "dgvShipments";
            this.dgvShipments.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvShipments.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvShipments.RowHeadersVisible = false;
            this.dgvShipments.RowHeadersWidth = 25;
            this.dgvShipments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvShipments.ShowEditingIcon = false;
            this.dgvShipments.Size = new System.Drawing.Size(1259, 499);
            this.dgvShipments.TabIndex = 101;
            this.dgvShipments.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvShipments_CellFormatting);
            this.dgvShipments.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvShipments_CellMouseDoubleClick);
            this.dgvShipments.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvShipments_DataBindingComplete);
            // 
            // rampsBindingSource
            // 
            this.rampsBindingSource.DataMember = "Ramps";
            this.rampsBindingSource.DataSource = this.receive;
            // 
            // receive
            // 
            this.receive.DataSetName = "Receive";
            this.receive.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // freeShipmentsOnDateBindingSource
            // 
            this.freeShipmentsOnDateBindingSource.DataMember = "FreeShipmentsOnDate";
            this.freeShipmentsOnDateBindingSource.DataSource = this.receive;
            // 
            // freeShipmentsOnDateTableAdapter
            // 
            this.freeShipmentsOnDateTableAdapter.ClearBeforeFill = true;
            // 
            // rampsTableAdapter
            // 
            this.rampsTableAdapter.ClearBeforeFill = true;
            // 
            // tsMainMenu
            // 
            this.tsMainMenu.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbExportToExcel});
            this.tsMainMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMainMenu.Name = "tsMainMenu";
            this.tsMainMenu.Size = new System.Drawing.Size(1259, 55);
            this.tsMainMenu.TabIndex = 102;
            this.tsMainMenu.Text = "toolStrip1";
            // 
            // sbExportToExcel
            // 
            this.sbExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportToExcel.Name = "sbExportToExcel";
            this.sbExportToExcel.Size = new System.Drawing.Size(142, 52);
            this.sbExportToExcel.Text = "Экспорт в Excel";
            this.sbExportToExcel.Click += new System.EventHandler(this.sbExportToExcel_Click);
            // 
            // dgvcShipmentSignColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = "System.Drawing.Bitmap";
            this.dgvcShipmentSignColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvcShipmentSignColumn.HeaderText = "";
            this.dgvcShipmentSignColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvcShipmentSignColumn.Name = "dgvcShipmentSignColumn";
            this.dgvcShipmentSignColumn.ReadOnly = true;
            this.dgvcShipmentSignColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvcShipmentSignColumn.Width = 25;
            // 
            // SelfDelivery
            // 
            this.SelfDelivery.DataPropertyName = "SelfDelivery";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SelfDelivery.DefaultCellStyle = dataGridViewCellStyle3;
            this.SelfDelivery.HeaderText = "С/В";
            this.SelfDelivery.Name = "SelfDelivery";
            this.SelfDelivery.ReadOnly = true;
            this.SelfDelivery.ToolTipText = "Самовывоз";
            this.SelfDelivery.Width = 30;
            // 
            // shipmentIDDataGridViewTextBoxColumn
            // 
            this.shipmentIDDataGridViewTextBoxColumn.DataPropertyName = "ShipmentID";
            this.shipmentIDDataGridViewTextBoxColumn.HeaderText = "Пос- тавка";
            this.shipmentIDDataGridViewTextBoxColumn.Name = "shipmentIDDataGridViewTextBoxColumn";
            this.shipmentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipmentIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // vendorIDDataGridViewTextBoxColumn
            // 
            this.vendorIDDataGridViewTextBoxColumn.DataPropertyName = "VendorID";
            this.vendorIDDataGridViewTextBoxColumn.HeaderText = "Код поставщ.";
            this.vendorIDDataGridViewTextBoxColumn.Name = "vendorIDDataGridViewTextBoxColumn";
            this.vendorIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // vendorNameDataGridViewTextBoxColumn
            // 
            this.vendorNameDataGridViewTextBoxColumn.DataPropertyName = "VendorName";
            this.vendorNameDataGridViewTextBoxColumn.HeaderText = "Поставщик";
            this.vendorNameDataGridViewTextBoxColumn.Name = "vendorNameDataGridViewTextBoxColumn";
            this.vendorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorNameDataGridViewTextBoxColumn.Width = 135;
            // 
            // countPLDataGridViewTextBoxColumn
            // 
            this.countPLDataGridViewTextBoxColumn.DataPropertyName = "CountPL";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.countPLDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.countPLDataGridViewTextBoxColumn.HeaderText = "Паллет";
            this.countPLDataGridViewTextBoxColumn.Name = "countPLDataGridViewTextBoxColumn";
            this.countPLDataGridViewTextBoxColumn.ReadOnly = true;
            this.countPLDataGridViewTextBoxColumn.Width = 50;
            // 
            // Ramp_ID
            // 
            this.Ramp_ID.DataPropertyName = "Ramp_ID";
            this.Ramp_ID.DataSource = this.rampsBindingSource;
            this.Ramp_ID.DisplayMember = "RampName";
            this.Ramp_ID.DisplayStyleForCurrentCellOnly = true;
            this.Ramp_ID.HeaderText = "Рампа";
            this.Ramp_ID.Name = "Ramp_ID";
            this.Ramp_ID.ReadOnly = true;
            this.Ramp_ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Ramp_ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Ramp_ID.ValueMember = "Ramp_ID";
            this.Ramp_ID.Width = 105;
            // 
            // TimeFromRamp
            // 
            this.TimeFromRamp.DataPropertyName = "TimeFromRamp";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeFromRamp.DefaultCellStyle = dataGridViewCellStyle5;
            this.TimeFromRamp.HeaderText = "Время с";
            this.TimeFromRamp.Name = "TimeFromRamp";
            this.TimeFromRamp.ReadOnly = true;
            this.TimeFromRamp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeFromRamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TimeFromRamp.Width = 65;
            // 
            // TimeToRamp
            // 
            this.TimeToRamp.DataPropertyName = "TimeToRamp";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.TimeToRamp.DefaultCellStyle = dataGridViewCellStyle6;
            this.TimeToRamp.HeaderText = "Время по";
            this.TimeToRamp.Name = "TimeToRamp";
            this.TimeToRamp.ReadOnly = true;
            this.TimeToRamp.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TimeToRamp.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TimeToRamp.Width = 65;
            // 
            // F
            // 
            this.F.DataPropertyName = "F";
            this.F.HeaderText = "Ф";
            this.F.Name = "F";
            this.F.ReadOnly = true;
            this.F.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.F.ToolTipText = "Фиксированные дата и время";
            this.F.Width = 20;
            // 
            // P
            // 
            this.P.DataPropertyName = "P";
            this.P.HeaderText = "П";
            this.P.Name = "P";
            this.P.ReadOnly = true;
            this.P.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.P.ToolTipText = "Предварительные дата и время";
            this.P.Width = 20;
            // 
            // StatusName
            // 
            this.StatusName.DataPropertyName = "StatusName";
            this.StatusName.HeaderText = "Статус";
            this.StatusName.Name = "StatusName";
            this.StatusName.ReadOnly = true;
            // 
            // PlanDate
            // 
            this.PlanDate.DataPropertyName = "PlanDate";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PlanDate.DefaultCellStyle = dataGridViewCellStyle7;
            this.PlanDate.HeaderText = "Дата разгр.";
            this.PlanDate.Name = "PlanDate";
            this.PlanDate.ReadOnly = true;
            this.PlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PlanDate.Width = 95;
            // 
            // carNumber
            // 
            this.carNumber.DataPropertyName = "CarNumber";
            this.carNumber.HeaderText = "Номер машины";
            this.carNumber.Name = "carNumber";
            this.carNumber.ReadOnly = true;
            this.carNumber.Width = 80;
            // 
            // description
            // 
            this.description.DataPropertyName = "Descript";
            this.description.HeaderText = "Примечание";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // FactDate
            // 
            this.FactDate.DataPropertyName = "FactDate";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FactDate.DefaultCellStyle = dataGridViewCellStyle8;
            this.FactDate.HeaderText = "Дата записи";
            this.FactDate.Name = "FactDate";
            this.FactDate.ReadOnly = true;
            this.FactDate.Width = 70;
            // 
            // FactTime
            // 
            this.FactTime.DataPropertyName = "FactTime";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.FactTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.FactTime.HeaderText = "Время записи";
            this.FactTime.Name = "FactTime";
            this.FactTime.ReadOnly = true;
            this.FactTime.Width = 50;
            // 
            // PlanDuration
            // 
            this.PlanDuration.DataPropertyName = "PlanDuration";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.PlanDuration.DefaultCellStyle = dataGridViewCellStyle10;
            this.PlanDuration.HeaderText = "План. длит.";
            this.PlanDuration.Name = "PlanDuration";
            this.PlanDuration.ReadOnly = true;
            this.PlanDuration.Width = 50;
            // 
            // FactTimeIn
            // 
            this.FactTimeIn.DataPropertyName = "FactTimeIn";
            this.FactTimeIn.HeaderText = "Факт. въезд";
            this.FactTimeIn.Name = "FactTimeIn";
            this.FactTimeIn.ReadOnly = true;
            this.FactTimeIn.Width = 50;
            // 
            // FactTimeOut
            // 
            this.FactTimeOut.DataPropertyName = "FactTimeOut";
            this.FactTimeOut.HeaderText = "Факт. выезд";
            this.FactTimeOut.Name = "FactTimeOut";
            this.FactTimeOut.ReadOnly = true;
            this.FactTimeOut.Width = 50;
            // 
            // Filial
            // 
            this.Filial.DataPropertyName = "Filial";
            this.Filial.HeaderText = "Получатель";
            this.Filial.Name = "Filial";
            this.Filial.ReadOnly = true;
            this.Filial.Width = 68;
            // 
            // ShipmentsFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 599);
            this.Controls.Add(this.tsMainMenu);
            this.Controls.Add(this.dgvShipments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "ShipmentsFindForm";
            this.Text = "Все поставки";
            this.Load += new System.EventHandler(this.ShipmentsFindForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShipmentsFindForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.dgvShipments, 0);
            this.Controls.SetChildIndex(this.tsMainMenu, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShipments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rampsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.freeShipmentsOnDateBindingSource)).EndInit();
            this.tsMainMenu.ResumeLayout(false);
            this.tsMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvShipments;
        private System.Windows.Forms.BindingSource rampsBindingSource;
        private WMSOffice.Data.Receive receive;
        private System.Windows.Forms.BindingSource freeShipmentsOnDateBindingSource;
        private WMSOffice.Data.ReceiveTableAdapters.FreeShipmentsOnDateTableAdapter freeShipmentsOnDateTableAdapter;
        private WMSOffice.Data.ReceiveTableAdapters.RampsTableAdapter rampsTableAdapter;
        private System.Windows.Forms.ToolStrip tsMainMenu;
        private System.Windows.Forms.ToolStripButton sbExportToExcel;
        private System.Windows.Forms.DataGridViewImageColumn dgvcShipmentSignColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelfDelivery;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countPLDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn Ramp_ID;
        private WMSOffice.Controls.Custom.DataGridViewTimeColumn TimeFromRamp;
        private WMSOffice.Controls.Custom.DataGridViewTimeColumn TimeToRamp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn F;
        private System.Windows.Forms.DataGridViewCheckBoxColumn P;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusName;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn PlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn carNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlanDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactTimeIn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactTimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filial;

    }
}