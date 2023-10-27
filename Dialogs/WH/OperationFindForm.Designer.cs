namespace WMSOffice.Dialogs.WH
{
    partial class OperationFindForm
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
            this.cmbWarehouses = new System.Windows.Forms.ComboBox();
            this.operationWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.cmbOperationDocType = new System.Windows.Forms.ComboBox();
            this.operationsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtDateFrom = new System.Windows.Forms.DateTimePicker();
            this.dtDateTo = new System.Windows.Forms.DateTimePicker();
            this.tbStatusID = new System.Windows.Forms.TextBox();
            this.tbJDDocID = new System.Windows.Forms.TextBox();
            this.tbJDDocType = new System.Windows.Forms.TextBox();
            this.tbBatchNumber = new System.Windows.Forms.TextBox();
            this.tbTSDDocType = new System.Windows.Forms.TextBox();
            this.tbTSDDocID = new System.Windows.Forms.TextBox();
            this.cbIsVirtual = new System.Windows.Forms.CheckBox();
            this.cbCloseOperations = new System.Windows.Forms.CheckBox();
            this.tbEmployeeID = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.cbActivateSubDocType = new System.Windows.Forms.CheckBox();
            this.cbActivateDateFrom = new System.Windows.Forms.CheckBox();
            this.cbActivateDateTo = new System.Windows.Forms.CheckBox();
            this.cbActivateStatusID = new System.Windows.Forms.CheckBox();
            this.cbActivateWarehouseID = new System.Windows.Forms.CheckBox();
            this.cbActivateJDDocID = new System.Windows.Forms.CheckBox();
            this.cbActivateJDDocType = new System.Windows.Forms.CheckBox();
            this.cbActivateBatchNumber = new System.Windows.Forms.CheckBox();
            this.cbActivateTSDDocID = new System.Windows.Forms.CheckBox();
            this.cbActivateTSDDocType = new System.Windows.Forms.CheckBox();
            this.cbActivateIsVirtual = new System.Windows.Forms.CheckBox();
            this.cbActivateEmployeeID = new System.Windows.Forms.CheckBox();
            this.cbActivateDescription = new System.Windows.Forms.CheckBox();
            this.cbActivateCloseOperations = new System.Windows.Forms.CheckBox();
            this.lblCaption = new System.Windows.Forms.Label();
            this.operationsTypesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationsTypesTableAdapter();
            this.operationWarehousesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTypesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(645, 8);
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(735, 8);
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 568);
            this.pnlButtons.Size = new System.Drawing.Size(560, 43);
            // 
            // cmbWarehouses
            // 
            this.cmbWarehouses.DataSource = this.operationWarehousesBindingSource;
            this.cmbWarehouses.DisplayMember = "Warehouse";
            this.cmbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouses.FormattingEnabled = true;
            this.cmbWarehouses.Location = new System.Drawing.Point(266, 217);
            this.cmbWarehouses.Name = "cmbWarehouses";
            this.cmbWarehouses.Size = new System.Drawing.Size(269, 21);
            this.cmbWarehouses.TabIndex = 106;
            this.cmbWarehouses.ValueMember = "Warehouse_ID";
            // 
            // operationWarehousesBindingSource
            // 
            this.operationWarehousesBindingSource.DataMember = "OperationWarehouses";
            this.operationWarehousesBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbOperationDocType
            // 
            this.cmbOperationDocType.DataSource = this.operationsTypesBindingSource;
            this.cmbOperationDocType.DisplayMember = "TypeName";
            this.cmbOperationDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOperationDocType.FormattingEnabled = true;
            this.cmbOperationDocType.Location = new System.Drawing.Point(266, 73);
            this.cmbOperationDocType.Name = "cmbOperationDocType";
            this.cmbOperationDocType.Size = new System.Drawing.Size(269, 21);
            this.cmbOperationDocType.TabIndex = 107;
            this.cmbOperationDocType.ValueMember = "SubType_ID";
            // 
            // operationsTypesBindingSource
            // 
            this.operationsTypesBindingSource.DataMember = "OperationsTypes";
            this.operationsTypesBindingSource.DataSource = this.wH;
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.CustomFormat = "dd / MM / yyyy";
            this.dtDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(266, 109);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(130, 20);
            this.dtDateFrom.TabIndex = 108;
            // 
            // dtDateTo
            // 
            this.dtDateTo.CustomFormat = "dd / MM / yyyy";
            this.dtDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(266, 145);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(130, 20);
            this.dtDateTo.TabIndex = 109;
            // 
            // tbStatusID
            // 
            this.tbStatusID.Location = new System.Drawing.Point(266, 185);
            this.tbStatusID.MaxLength = 3;
            this.tbStatusID.Name = "tbStatusID";
            this.tbStatusID.Size = new System.Drawing.Size(130, 20);
            this.tbStatusID.TabIndex = 110;
            // 
            // tbJDDocID
            // 
            this.tbJDDocID.Location = new System.Drawing.Point(266, 253);
            this.tbJDDocID.Name = "tbJDDocID";
            this.tbJDDocID.Size = new System.Drawing.Size(130, 20);
            this.tbJDDocID.TabIndex = 115;
            // 
            // tbJDDocType
            // 
            this.tbJDDocType.Location = new System.Drawing.Point(266, 289);
            this.tbJDDocType.MaxLength = 2;
            this.tbJDDocType.Name = "tbJDDocType";
            this.tbJDDocType.Size = new System.Drawing.Size(130, 20);
            this.tbJDDocType.TabIndex = 116;
            // 
            // tbBatchNumber
            // 
            this.tbBatchNumber.Location = new System.Drawing.Point(266, 325);
            this.tbBatchNumber.Name = "tbBatchNumber";
            this.tbBatchNumber.Size = new System.Drawing.Size(130, 20);
            this.tbBatchNumber.TabIndex = 117;
            // 
            // tbTSDDocType
            // 
            this.tbTSDDocType.Location = new System.Drawing.Point(266, 397);
            this.tbTSDDocType.MaxLength = 2;
            this.tbTSDDocType.Name = "tbTSDDocType";
            this.tbTSDDocType.Size = new System.Drawing.Size(130, 20);
            this.tbTSDDocType.TabIndex = 118;
            // 
            // tbTSDDocID
            // 
            this.tbTSDDocID.Location = new System.Drawing.Point(266, 361);
            this.tbTSDDocID.Name = "tbTSDDocID";
            this.tbTSDDocID.Size = new System.Drawing.Size(130, 20);
            this.tbTSDDocID.TabIndex = 119;
            // 
            // cbIsVirtual
            // 
            this.cbIsVirtual.AutoSize = true;
            this.cbIsVirtual.Location = new System.Drawing.Point(266, 436);
            this.cbIsVirtual.Name = "cbIsVirtual";
            this.cbIsVirtual.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbIsVirtual.Size = new System.Drawing.Size(15, 14);
            this.cbIsVirtual.TabIndex = 121;
            this.cbIsVirtual.UseVisualStyleBackColor = true;
            // 
            // cbCloseOperations
            // 
            this.cbCloseOperations.AutoSize = true;
            this.cbCloseOperations.Location = new System.Drawing.Point(266, 544);
            this.cbCloseOperations.Name = "cbCloseOperations";
            this.cbCloseOperations.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbCloseOperations.Size = new System.Drawing.Size(15, 14);
            this.cbCloseOperations.TabIndex = 126;
            this.cbCloseOperations.UseVisualStyleBackColor = true;
            // 
            // tbEmployeeID
            // 
            this.tbEmployeeID.Location = new System.Drawing.Point(266, 469);
            this.tbEmployeeID.Name = "tbEmployeeID";
            this.tbEmployeeID.Size = new System.Drawing.Size(130, 20);
            this.tbEmployeeID.TabIndex = 127;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(266, 505);
            this.tbDescription.MaxLength = 50;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(269, 20);
            this.tbDescription.TabIndex = 128;
            // 
            // cbActivateSubDocType
            // 
            this.cbActivateSubDocType.AutoSize = true;
            this.cbActivateSubDocType.Location = new System.Drawing.Point(24, 76);
            this.cbActivateSubDocType.Name = "cbActivateSubDocType";
            this.cbActivateSubDocType.Size = new System.Drawing.Size(105, 17);
            this.cbActivateSubDocType.TabIndex = 129;
            this.cbActivateSubDocType.Text = "Тип документа:";
            this.cbActivateSubDocType.UseVisualStyleBackColor = true;
            // 
            // cbActivateDateFrom
            // 
            this.cbActivateDateFrom.AutoSize = true;
            this.cbActivateDateFrom.Location = new System.Drawing.Point(24, 112);
            this.cbActivateDateFrom.Name = "cbActivateDateFrom";
            this.cbActivateDateFrom.Size = new System.Drawing.Size(64, 17);
            this.cbActivateDateFrom.TabIndex = 130;
            this.cbActivateDateFrom.Text = "Дата с:";
            this.cbActivateDateFrom.UseVisualStyleBackColor = true;
            // 
            // cbActivateDateTo
            // 
            this.cbActivateDateTo.AutoSize = true;
            this.cbActivateDateTo.Location = new System.Drawing.Point(24, 148);
            this.cbActivateDateTo.Name = "cbActivateDateTo";
            this.cbActivateDateTo.Size = new System.Drawing.Size(70, 17);
            this.cbActivateDateTo.TabIndex = 131;
            this.cbActivateDateTo.Text = "Дата по:";
            this.cbActivateDateTo.UseVisualStyleBackColor = true;
            // 
            // cbActivateStatusID
            // 
            this.cbActivateStatusID.AutoSize = true;
            this.cbActivateStatusID.Location = new System.Drawing.Point(24, 184);
            this.cbActivateStatusID.Name = "cbActivateStatusID";
            this.cbActivateStatusID.Size = new System.Drawing.Size(82, 17);
            this.cbActivateStatusID.TabIndex = 132;
            this.cbActivateStatusID.Text = "№ статуса:";
            this.cbActivateStatusID.UseVisualStyleBackColor = true;
            // 
            // cbActivateWarehouseID
            // 
            this.cbActivateWarehouseID.AutoSize = true;
            this.cbActivateWarehouseID.Location = new System.Drawing.Point(24, 220);
            this.cbActivateWarehouseID.Name = "cbActivateWarehouseID";
            this.cbActivateWarehouseID.Size = new System.Drawing.Size(60, 17);
            this.cbActivateWarehouseID.TabIndex = 133;
            this.cbActivateWarehouseID.Text = "Склад:";
            this.cbActivateWarehouseID.UseVisualStyleBackColor = true;
            // 
            // cbActivateJDDocID
            // 
            this.cbActivateJDDocID.AutoSize = true;
            this.cbActivateJDDocID.Location = new System.Drawing.Point(24, 256);
            this.cbActivateJDDocID.Name = "cbActivateJDDocID";
            this.cbActivateJDDocID.Size = new System.Drawing.Size(113, 17);
            this.cbActivateJDDocID.TabIndex = 134;
            this.cbActivateJDDocID.Text = "№ документа JD:";
            this.cbActivateJDDocID.UseVisualStyleBackColor = true;
            // 
            // cbActivateJDDocType
            // 
            this.cbActivateJDDocType.AutoSize = true;
            this.cbActivateJDDocType.Location = new System.Drawing.Point(24, 292);
            this.cbActivateJDDocType.Name = "cbActivateJDDocType";
            this.cbActivateJDDocType.Size = new System.Drawing.Size(121, 17);
            this.cbActivateJDDocType.TabIndex = 135;
            this.cbActivateJDDocType.Text = "Тип документа JD:";
            this.cbActivateJDDocType.UseVisualStyleBackColor = true;
            // 
            // cbActivateBatchNumber
            // 
            this.cbActivateBatchNumber.AutoSize = true;
            this.cbActivateBatchNumber.Location = new System.Drawing.Point(24, 328);
            this.cbActivateBatchNumber.Name = "cbActivateBatchNumber";
            this.cbActivateBatchNumber.Size = new System.Drawing.Size(78, 17);
            this.cbActivateBatchNumber.TabIndex = 136;
            this.cbActivateBatchNumber.Text = "№ пакета:";
            this.cbActivateBatchNumber.UseVisualStyleBackColor = true;
            // 
            // cbActivateTSDDocID
            // 
            this.cbActivateTSDDocID.AutoSize = true;
            this.cbActivateTSDDocID.Location = new System.Drawing.Point(24, 364);
            this.cbActivateTSDDocID.Name = "cbActivateTSDDocID";
            this.cbActivateTSDDocID.Size = new System.Drawing.Size(111, 17);
            this.cbActivateTSDDocID.TabIndex = 137;
            this.cbActivateTSDDocID.Text = "№ задания ТСД:";
            this.cbActivateTSDDocID.UseVisualStyleBackColor = true;
            // 
            // cbActivateTSDDocType
            // 
            this.cbActivateTSDDocType.AutoSize = true;
            this.cbActivateTSDDocType.Location = new System.Drawing.Point(24, 400);
            this.cbActivateTSDDocType.Name = "cbActivateTSDDocType";
            this.cbActivateTSDDocType.Size = new System.Drawing.Size(119, 17);
            this.cbActivateTSDDocType.TabIndex = 138;
            this.cbActivateTSDDocType.Text = "Тип задания ТСД:";
            this.cbActivateTSDDocType.UseVisualStyleBackColor = true;
            // 
            // cbActivateIsVirtual
            // 
            this.cbActivateIsVirtual.AutoSize = true;
            this.cbActivateIsVirtual.Location = new System.Drawing.Point(24, 436);
            this.cbActivateIsVirtual.Name = "cbActivateIsVirtual";
            this.cbActivateIsVirtual.Size = new System.Drawing.Size(191, 17);
            this.cbActivateIsVirtual.TabIndex = 139;
            this.cbActivateIsVirtual.Text = "Признак виртуальной операции:";
            this.cbActivateIsVirtual.UseVisualStyleBackColor = true;
            // 
            // cbActivateEmployeeID
            // 
            this.cbActivateEmployeeID.AutoSize = true;
            this.cbActivateEmployeeID.Location = new System.Drawing.Point(24, 472);
            this.cbActivateEmployeeID.Name = "cbActivateEmployeeID";
            this.cbActivateEmployeeID.Size = new System.Drawing.Size(109, 17);
            this.cbActivateEmployeeID.TabIndex = 140;
            this.cbActivateEmployeeID.Text = "Код сотрудника:";
            this.cbActivateEmployeeID.UseVisualStyleBackColor = true;
            // 
            // cbActivateDescription
            // 
            this.cbActivateDescription.AutoSize = true;
            this.cbActivateDescription.Location = new System.Drawing.Point(24, 508);
            this.cbActivateDescription.Name = "cbActivateDescription";
            this.cbActivateDescription.Size = new System.Drawing.Size(130, 17);
            this.cbActivateDescription.TabIndex = 141;
            this.cbActivateDescription.Text = "Описание операции:";
            this.cbActivateDescription.UseVisualStyleBackColor = true;
            // 
            // cbActivateCloseOperations
            // 
            this.cbActivateCloseOperations.AutoSize = true;
            this.cbActivateCloseOperations.Location = new System.Drawing.Point(24, 544);
            this.cbActivateCloseOperations.Name = "cbActivateCloseOperations";
            this.cbActivateCloseOperations.Size = new System.Drawing.Size(196, 17);
            this.cbActivateCloseOperations.TabIndex = 142;
            this.cbActivateCloseOperations.Text = "Отображать закрытые операции:";
            this.cbActivateCloseOperations.UseVisualStyleBackColor = true;
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.SystemColors.Info;
            this.lblCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblCaption.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblCaption.Location = new System.Drawing.Point(0, 0);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(560, 60);
            this.lblCaption.TabIndex = 143;
            this.lblCaption.Text = "Для использования необходимого критерия поиска включите опцию слева";
            // 
            // operationsTypesTableAdapter
            // 
            this.operationsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // operationWarehousesTableAdapter
            // 
            this.operationWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // OperationFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 611);
            this.Controls.Add(this.lblCaption);
            this.Controls.Add(this.cbActivateCloseOperations);
            this.Controls.Add(this.cbActivateDescription);
            this.Controls.Add(this.cbActivateEmployeeID);
            this.Controls.Add(this.cbActivateIsVirtual);
            this.Controls.Add(this.cbActivateTSDDocType);
            this.Controls.Add(this.cbActivateTSDDocID);
            this.Controls.Add(this.cbActivateBatchNumber);
            this.Controls.Add(this.cbActivateJDDocType);
            this.Controls.Add(this.cbActivateJDDocID);
            this.Controls.Add(this.cbActivateWarehouseID);
            this.Controls.Add(this.cbActivateDateTo);
            this.Controls.Add(this.cmbOperationDocType);
            this.Controls.Add(this.dtDateFrom);
            this.Controls.Add(this.cbActivateDateFrom);
            this.Controls.Add(this.cbActivateSubDocType);
            this.Controls.Add(this.cbActivateStatusID);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbEmployeeID);
            this.Controls.Add(this.cbCloseOperations);
            this.Controls.Add(this.cbIsVirtual);
            this.Controls.Add(this.tbTSDDocID);
            this.Controls.Add(this.tbTSDDocType);
            this.Controls.Add(this.tbBatchNumber);
            this.Controls.Add(this.tbJDDocType);
            this.Controls.Add(this.tbJDDocID);
            this.Controls.Add(this.tbStatusID);
            this.Controls.Add(this.dtDateTo);
            this.Controls.Add(this.cmbWarehouses);
            this.Name = "OperationFindForm";
            this.Text = "Параметры поиска документов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperationFindForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.cmbWarehouses, 0);
            this.Controls.SetChildIndex(this.dtDateTo, 0);
            this.Controls.SetChildIndex(this.tbStatusID, 0);
            this.Controls.SetChildIndex(this.tbJDDocID, 0);
            this.Controls.SetChildIndex(this.tbJDDocType, 0);
            this.Controls.SetChildIndex(this.tbBatchNumber, 0);
            this.Controls.SetChildIndex(this.tbTSDDocType, 0);
            this.Controls.SetChildIndex(this.tbTSDDocID, 0);
            this.Controls.SetChildIndex(this.cbIsVirtual, 0);
            this.Controls.SetChildIndex(this.cbCloseOperations, 0);
            this.Controls.SetChildIndex(this.tbEmployeeID, 0);
            this.Controls.SetChildIndex(this.tbDescription, 0);
            this.Controls.SetChildIndex(this.cbActivateStatusID, 0);
            this.Controls.SetChildIndex(this.cbActivateSubDocType, 0);
            this.Controls.SetChildIndex(this.cbActivateDateFrom, 0);
            this.Controls.SetChildIndex(this.dtDateFrom, 0);
            this.Controls.SetChildIndex(this.cmbOperationDocType, 0);
            this.Controls.SetChildIndex(this.cbActivateDateTo, 0);
            this.Controls.SetChildIndex(this.cbActivateWarehouseID, 0);
            this.Controls.SetChildIndex(this.cbActivateJDDocID, 0);
            this.Controls.SetChildIndex(this.cbActivateJDDocType, 0);
            this.Controls.SetChildIndex(this.cbActivateBatchNumber, 0);
            this.Controls.SetChildIndex(this.cbActivateTSDDocID, 0);
            this.Controls.SetChildIndex(this.cbActivateTSDDocType, 0);
            this.Controls.SetChildIndex(this.cbActivateIsVirtual, 0);
            this.Controls.SetChildIndex(this.cbActivateEmployeeID, 0);
            this.Controls.SetChildIndex(this.cbActivateDescription, 0);
            this.Controls.SetChildIndex(this.cbActivateCloseOperations, 0);
            this.Controls.SetChildIndex(this.lblCaption, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.operationWarehousesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationsTypesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWarehouses;
        private System.Windows.Forms.ComboBox cmbOperationDocType;
        private System.Windows.Forms.DateTimePicker dtDateFrom;
        private System.Windows.Forms.DateTimePicker dtDateTo;
        private System.Windows.Forms.TextBox tbStatusID;
        private System.Windows.Forms.TextBox tbJDDocID;
        private System.Windows.Forms.TextBox tbJDDocType;
        private System.Windows.Forms.TextBox tbBatchNumber;
        private System.Windows.Forms.TextBox tbTSDDocType;
        private System.Windows.Forms.TextBox tbTSDDocID;
        private System.Windows.Forms.CheckBox cbIsVirtual;
        private System.Windows.Forms.CheckBox cbCloseOperations;
        private System.Windows.Forms.TextBox tbEmployeeID;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.CheckBox cbActivateSubDocType;
        private System.Windows.Forms.CheckBox cbActivateDateFrom;
        private System.Windows.Forms.CheckBox cbActivateDateTo;
        private System.Windows.Forms.CheckBox cbActivateStatusID;
        private System.Windows.Forms.CheckBox cbActivateWarehouseID;
        private System.Windows.Forms.CheckBox cbActivateJDDocID;
        private System.Windows.Forms.CheckBox cbActivateJDDocType;
        private System.Windows.Forms.CheckBox cbActivateBatchNumber;
        private System.Windows.Forms.CheckBox cbActivateTSDDocID;
        private System.Windows.Forms.CheckBox cbActivateTSDDocType;
        private System.Windows.Forms.CheckBox cbActivateIsVirtual;
        private System.Windows.Forms.CheckBox cbActivateEmployeeID;
        private System.Windows.Forms.CheckBox cbActivateDescription;
        private System.Windows.Forms.CheckBox cbActivateCloseOperations;
        private System.Windows.Forms.Label lblCaption;
        private System.Windows.Forms.BindingSource operationsTypesBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.OperationsTypesTableAdapter operationsTypesTableAdapter;
        private System.Windows.Forms.BindingSource operationWarehousesBindingSource;
        private WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter operationWarehousesTableAdapter;
    }
}