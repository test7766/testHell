namespace WMSOffice.Dialogs.Quality
{
    partial class InitFindPurchaseOrderItemsForm
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
            this.cbDateTo = new System.Windows.Forms.CheckBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblWarehouseName = new System.Windows.Forms.TextBox();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.cbBlockType = new System.Windows.Forms.CheckBox();
            this.lblBlockTypeName = new System.Windows.Forms.TextBox();
            this.stbBlockType = new WMSOffice.Controls.SearchTextBox();
            this.cbDateFrom = new System.Windows.Forms.CheckBox();
            this.cbNewVendorLot = new System.Windows.Forms.CheckBox();
            this.cbNewItem = new System.Windows.Forms.CheckBox();
            this.cbNewVendorLotValue = new System.Windows.Forms.CheckBox();
            this.cbNewItemValue = new System.Windows.Forms.CheckBox();
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.gbInitParameters = new System.Windows.Forms.GroupBox();
            this.gbAdvancedParameters = new System.Windows.Forms.GroupBox();
            this.cbBlockAllWarehouses = new System.Windows.Forms.CheckBox();
            this.pnlButtons.SuspendLayout();
            this.gbInitParameters.SuspendLayout();
            this.gbAdvancedParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(2432, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2522, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 338);
            this.pnlButtons.Size = new System.Drawing.Size(601, 43);
            this.pnlButtons.TabIndex = 7;
            // 
            // cbDateTo
            // 
            this.cbDateTo.AutoSize = true;
            this.cbDateTo.Location = new System.Drawing.Point(6, 95);
            this.cbDateTo.Name = "cbDateTo";
            this.cbDateTo.Size = new System.Drawing.Size(67, 17);
            this.cbDateTo.TabIndex = 5;
            this.cbDateTo.Text = "Дата по";
            this.cbDateTo.UseVisualStyleBackColor = true;
            this.cbDateTo.CheckStateChanged += new System.EventHandler(this.cbDateTo_CheckStateChanged);
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd.MM.yyyy";
            this.dtpDateTo.Enabled = false;
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(120, 93);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpDateTo.TabIndex = 6;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpDateFrom.Enabled = false;
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(120, 60);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpDateFrom.TabIndex = 4;
            // 
            // lblWarehouseName
            // 
            this.lblWarehouseName.BackColor = System.Drawing.SystemColors.Info;
            this.lblWarehouseName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouseName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseName.Location = new System.Drawing.Point(241, 34);
            this.lblWarehouseName.Name = "lblWarehouseName";
            this.lblWarehouseName.ReadOnly = true;
            this.lblWarehouseName.Size = new System.Drawing.Size(340, 20);
            this.lblWarehouseName.TabIndex = 4;
            this.lblWarehouseName.TabStop = false;
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.BackColor = System.Drawing.SystemColors.Info;
            this.stbWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stbWarehouse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbWarehouse.Location = new System.Drawing.Point(135, 34);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.ReadOnly = true;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 3;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // cbBlockType
            // 
            this.cbBlockType.AutoSize = true;
            this.cbBlockType.Location = new System.Drawing.Point(6, 29);
            this.cbBlockType.Name = "cbBlockType";
            this.cbBlockType.Size = new System.Drawing.Size(108, 17);
            this.cbBlockType.TabIndex = 0;
            this.cbBlockType.Text = "Код блокировки";
            this.cbBlockType.UseVisualStyleBackColor = true;
            this.cbBlockType.CheckStateChanged += new System.EventHandler(this.cbBlockType_CheckStateChanged);
            // 
            // lblBlockTypeName
            // 
            this.lblBlockTypeName.BackColor = System.Drawing.SystemColors.Control;
            this.lblBlockTypeName.Location = new System.Drawing.Point(226, 27);
            this.lblBlockTypeName.Name = "lblBlockTypeName";
            this.lblBlockTypeName.ReadOnly = true;
            this.lblBlockTypeName.Size = new System.Drawing.Size(340, 20);
            this.lblBlockTypeName.TabIndex = 2;
            this.lblBlockTypeName.TabStop = false;
            // 
            // stbBlockType
            // 
            this.stbBlockType.BackColor = System.Drawing.SystemColors.Control;
            this.stbBlockType.Location = new System.Drawing.Point(120, 27);
            this.stbBlockType.Name = "stbBlockType";
            this.stbBlockType.ReadOnly = true;
            this.stbBlockType.Size = new System.Drawing.Size(100, 20);
            this.stbBlockType.TabIndex = 1;
            this.stbBlockType.UserID = ((long)(0));
            this.stbBlockType.Value = null;
            this.stbBlockType.ValueReferenceQuery = null;
            // 
            // cbDateFrom
            // 
            this.cbDateFrom.AutoSize = true;
            this.cbDateFrom.Location = new System.Drawing.Point(6, 62);
            this.cbDateFrom.Name = "cbDateFrom";
            this.cbDateFrom.Size = new System.Drawing.Size(61, 17);
            this.cbDateFrom.TabIndex = 3;
            this.cbDateFrom.Text = "Дата с";
            this.cbDateFrom.UseVisualStyleBackColor = true;
            this.cbDateFrom.CheckStateChanged += new System.EventHandler(this.cbDateFrom_CheckStateChanged);
            // 
            // cbNewVendorLot
            // 
            this.cbNewVendorLot.AutoSize = true;
            this.cbNewVendorLot.Location = new System.Drawing.Point(6, 128);
            this.cbNewVendorLot.Name = "cbNewVendorLot";
            this.cbNewVendorLot.Size = new System.Drawing.Size(91, 17);
            this.cbNewVendorLot.TabIndex = 7;
            this.cbNewVendorLot.Text = "Новая серия";
            this.cbNewVendorLot.UseVisualStyleBackColor = true;
            this.cbNewVendorLot.CheckStateChanged += new System.EventHandler(this.cbNewVendorLot_CheckStateChanged);
            // 
            // cbNewItem
            // 
            this.cbNewItem.AutoSize = true;
            this.cbNewItem.Location = new System.Drawing.Point(6, 161);
            this.cbNewItem.Name = "cbNewItem";
            this.cbNewItem.Size = new System.Drawing.Size(92, 17);
            this.cbNewItem.TabIndex = 9;
            this.cbNewItem.Text = "Новый товар";
            this.cbNewItem.UseVisualStyleBackColor = true;
            this.cbNewItem.CheckStateChanged += new System.EventHandler(this.cbNewItem_CheckStateChanged);
            // 
            // cbNewVendorLotValue
            // 
            this.cbNewVendorLotValue.AutoSize = true;
            this.cbNewVendorLotValue.Enabled = false;
            this.cbNewVendorLotValue.Location = new System.Drawing.Point(120, 129);
            this.cbNewVendorLotValue.Name = "cbNewVendorLotValue";
            this.cbNewVendorLotValue.Size = new System.Drawing.Size(15, 14);
            this.cbNewVendorLotValue.TabIndex = 8;
            this.cbNewVendorLotValue.UseVisualStyleBackColor = true;
            // 
            // cbNewItemValue
            // 
            this.cbNewItemValue.AutoSize = true;
            this.cbNewItemValue.Enabled = false;
            this.cbNewItemValue.Location = new System.Drawing.Point(120, 162);
            this.cbNewItemValue.Name = "cbNewItemValue";
            this.cbNewItemValue.Size = new System.Drawing.Size(15, 14);
            this.cbNewItemValue.TabIndex = 10;
            this.cbNewItemValue.UseVisualStyleBackColor = true;
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblOrderNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 9);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(57, 13);
            this.lblOrderNumber.TabIndex = 0;
            this.lblOrderNumber.Text = "№ заказа";
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWarehouse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouse.Location = new System.Drawing.Point(12, 38);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(38, 13);
            this.lblWarehouse.TabIndex = 2;
            this.lblWarehouse.Text = "Склад";
            // 
            // tbOrderID
            // 
            this.tbOrderID.BackColor = System.Drawing.SystemColors.Info;
            this.tbOrderID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOrderID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbOrderID.Location = new System.Drawing.Point(135, 5);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.ReadOnly = true;
            this.tbOrderID.Size = new System.Drawing.Size(100, 20);
            this.tbOrderID.TabIndex = 1;
            // 
            // gbInitParameters
            // 
            this.gbInitParameters.Controls.Add(this.stbBlockType);
            this.gbInitParameters.Controls.Add(this.dtpDateFrom);
            this.gbInitParameters.Controls.Add(this.dtpDateTo);
            this.gbInitParameters.Controls.Add(this.cbDateTo);
            this.gbInitParameters.Controls.Add(this.lblBlockTypeName);
            this.gbInitParameters.Controls.Add(this.cbNewItemValue);
            this.gbInitParameters.Controls.Add(this.cbBlockType);
            this.gbInitParameters.Controls.Add(this.cbNewVendorLotValue);
            this.gbInitParameters.Controls.Add(this.cbDateFrom);
            this.gbInitParameters.Controls.Add(this.cbNewItem);
            this.gbInitParameters.Controls.Add(this.cbNewVendorLot);
            this.gbInitParameters.Location = new System.Drawing.Point(15, 75);
            this.gbInitParameters.Name = "gbInitParameters";
            this.gbInitParameters.Size = new System.Drawing.Size(574, 190);
            this.gbInitParameters.TabIndex = 5;
            this.gbInitParameters.TabStop = false;
            this.gbInitParameters.Text = "Параметры";
            // 
            // gbAdvancedParameters
            // 
            this.gbAdvancedParameters.BackColor = System.Drawing.SystemColors.Control;
            this.gbAdvancedParameters.Controls.Add(this.cbBlockAllWarehouses);
            this.gbAdvancedParameters.Location = new System.Drawing.Point(15, 271);
            this.gbAdvancedParameters.Name = "gbAdvancedParameters";
            this.gbAdvancedParameters.Size = new System.Drawing.Size(574, 60);
            this.gbAdvancedParameters.TabIndex = 6;
            this.gbAdvancedParameters.TabStop = false;
            this.gbAdvancedParameters.Text = "Дополнительно";
            // 
            // cbBlockAllWarehouses
            // 
            this.cbBlockAllWarehouses.AutoSize = true;
            this.cbBlockAllWarehouses.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbBlockAllWarehouses.Location = new System.Drawing.Point(6, 29);
            this.cbBlockAllWarehouses.Name = "cbBlockAllWarehouses";
            this.cbBlockAllWarehouses.Size = new System.Drawing.Size(204, 17);
            this.cbBlockAllWarehouses.TabIndex = 0;
            this.cbBlockAllWarehouses.Text = "Блокировать на всех складах";
            this.cbBlockAllWarehouses.UseVisualStyleBackColor = true;
            // 
            // InitFindPurchaseOrderItemsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 381);
            this.Controls.Add(this.gbAdvancedParameters);
            this.Controls.Add(this.gbInitParameters);
            this.Controls.Add(this.tbOrderID);
            this.Controls.Add(this.lblWarehouse);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.lblWarehouseName);
            this.Controls.Add(this.stbWarehouse);
            this.Name = "InitFindPurchaseOrderItemsForm";
            this.Text = "Параметры блокировки товаров в заказе на закупку";
            this.Load += new System.EventHandler(this.InitFindPurchaseOrderItemsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InitFindPurchaseOrderItemsForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.stbWarehouse, 0);
            this.Controls.SetChildIndex(this.lblWarehouseName, 0);
            this.Controls.SetChildIndex(this.lblOrderNumber, 0);
            this.Controls.SetChildIndex(this.lblWarehouse, 0);
            this.Controls.SetChildIndex(this.tbOrderID, 0);
            this.Controls.SetChildIndex(this.gbInitParameters, 0);
            this.Controls.SetChildIndex(this.gbAdvancedParameters, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbInitParameters.ResumeLayout(false);
            this.gbInitParameters.PerformLayout();
            this.gbAdvancedParameters.ResumeLayout(false);
            this.gbAdvancedParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.TextBox lblWarehouseName;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.CheckBox cbBlockType;
        private System.Windows.Forms.TextBox lblBlockTypeName;
        private WMSOffice.Controls.SearchTextBox stbBlockType;
        private System.Windows.Forms.CheckBox cbDateFrom;
        private System.Windows.Forms.CheckBox cbNewVendorLot;
        private System.Windows.Forms.CheckBox cbNewItem;
        private System.Windows.Forms.CheckBox cbNewVendorLotValue;
        private System.Windows.Forms.CheckBox cbNewItemValue;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.GroupBox gbInitParameters;
        private System.Windows.Forms.GroupBox gbAdvancedParameters;
        private System.Windows.Forms.CheckBox cbBlockAllWarehouses;
    }
}