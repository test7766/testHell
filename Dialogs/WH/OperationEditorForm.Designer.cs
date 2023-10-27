namespace WMSOffice.Dialogs.WH
{
    partial class OperationEditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OperationEditorForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbOperationHeader = new System.Windows.Forms.GroupBox();
            this.pnlWarehouseTo = new System.Windows.Forms.Panel();
            this.tbWarehouseTo = new System.Windows.Forms.TextBox();
            this.operationDocHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.btnWarehouseToSelector = new System.Windows.Forms.Button();
            this.pnlWarehouseFrom = new System.Windows.Forms.Panel();
            this.tbWarehouseFrom = new System.Windows.Forms.TextBox();
            this.btnWarehouseFromSelector = new System.Windows.Forms.Button();
            this.lblWarehouseToValue = new System.Windows.Forms.Label();
            this.lblWarehouseFromValue = new System.Windows.Forms.Label();
            this.lblAmountValueUAH = new System.Windows.Forms.Label();
            this.tbTSDJobType = new System.Windows.Forms.TextBox();
            this.lblOperationFooterSeparator = new System.Windows.Forms.Label();
            this.tbDocStatus = new System.Windows.Forms.TextBox();
            this.tbDocStatusID = new System.Windows.Forms.TextBox();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.lblDocStatusID = new System.Windows.Forms.Label();
            this.lblTSDJobType = new System.Windows.Forms.Label();
            this.tbJDDocNumber = new System.Windows.Forms.TextBox();
            this.lblJDDocNumber = new System.Windows.Forms.Label();
            this.cmbJDDocType = new System.Windows.Forms.ComboBox();
            this.jDDocTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblJDDocType = new System.Windows.Forms.Label();
            this.tbDocID = new System.Windows.Forms.TextBox();
            this.lblDocID = new System.Windows.Forms.Label();
            this.tbTSDJobNumber = new System.Windows.Forms.TextBox();
            this.lblTSDJobNumber = new System.Windows.Forms.Label();
            this.dtDocDate = new System.Windows.Forms.DateTimePicker();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.tbEmployee = new System.Windows.Forms.TextBox();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblAmountUAH = new System.Windows.Forms.Label();
            this.tbBatchNumber = new System.Windows.Forms.TextBox();
            this.lblBatchNumber = new System.Windows.Forms.Label();
            this.lblWarehouseTo = new System.Windows.Forms.Label();
            this.lblWarehouseFrom = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.cmsClipboardMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.smbPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.gbOperationDetails = new System.Windows.Forms.GroupBox();
            this.tbxCellToolTip = new System.Windows.Forms.TextBox();
            this.dgvOperationDetails = new WMSOffice.Controls.InheritedDataGridView();
            this.fTDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gLCategoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationDataGridViewTextBoxColumn = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.iCLocationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location_To = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.iCLocationToDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costPriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.costAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePriceAmountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SSCC_From = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.SSCC_To = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.operationDocRowsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblSurplusSumValue = new System.Windows.Forms.Label();
            this.lblSurplusSum = new System.Windows.Forms.Label();
            this.lblShortageSumValue = new System.Windows.Forms.Label();
            this.lblShortageSum = new System.Windows.Forms.Label();
            this.gbOperation = new System.Windows.Forms.GroupBox();
            this.operationDocHeaderTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationDocHeaderTableAdapter();
            this.operationWarehousesTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter();
            this.jDDocTypesTableAdapter = new WMSOffice.Data.WHTableAdapters.JDDocTypesTableAdapter();
            this.operationDocRowsTableAdapter = new WMSOffice.Data.WHTableAdapters.OperationDocRowsTableAdapter();
            this.btnRemoveOperation = new System.Windows.Forms.Button();
            this.pnlButtons.SuspendLayout();
            this.gbOperationHeader.SuspendLayout();
            this.pnlWarehouseTo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationDocHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.pnlWarehouseFrom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDDocTypesBindingSource)).BeginInit();
            this.cmsClipboardMenu.SuspendLayout();
            this.gbOperationDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationDocRowsBindingSource)).BeginInit();
            this.gbOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            resources.ApplyResources(this.btnOK, "btnOK");
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlButtons
            // 
            resources.ApplyResources(this.pnlButtons, "pnlButtons");
            // 
            // gbOperationHeader
            // 
            resources.ApplyResources(this.gbOperationHeader, "gbOperationHeader");
            this.gbOperationHeader.Controls.Add(this.pnlWarehouseTo);
            this.gbOperationHeader.Controls.Add(this.pnlWarehouseFrom);
            this.gbOperationHeader.Controls.Add(this.lblWarehouseToValue);
            this.gbOperationHeader.Controls.Add(this.lblWarehouseFromValue);
            this.gbOperationHeader.Controls.Add(this.lblAmountValueUAH);
            this.gbOperationHeader.Controls.Add(this.tbTSDJobType);
            this.gbOperationHeader.Controls.Add(this.lblOperationFooterSeparator);
            this.gbOperationHeader.Controls.Add(this.tbDocStatus);
            this.gbOperationHeader.Controls.Add(this.tbDocStatusID);
            this.gbOperationHeader.Controls.Add(this.lblDocStatus);
            this.gbOperationHeader.Controls.Add(this.lblDocStatusID);
            this.gbOperationHeader.Controls.Add(this.lblTSDJobType);
            this.gbOperationHeader.Controls.Add(this.tbJDDocNumber);
            this.gbOperationHeader.Controls.Add(this.lblJDDocNumber);
            this.gbOperationHeader.Controls.Add(this.cmbJDDocType);
            this.gbOperationHeader.Controls.Add(this.lblJDDocType);
            this.gbOperationHeader.Controls.Add(this.tbDocID);
            this.gbOperationHeader.Controls.Add(this.lblDocID);
            this.gbOperationHeader.Controls.Add(this.tbTSDJobNumber);
            this.gbOperationHeader.Controls.Add(this.lblTSDJobNumber);
            this.gbOperationHeader.Controls.Add(this.dtDocDate);
            this.gbOperationHeader.Controls.Add(this.lblDocDate);
            this.gbOperationHeader.Controls.Add(this.tbEmployee);
            this.gbOperationHeader.Controls.Add(this.lblEmployee);
            this.gbOperationHeader.Controls.Add(this.lblAmountUAH);
            this.gbOperationHeader.Controls.Add(this.tbBatchNumber);
            this.gbOperationHeader.Controls.Add(this.lblBatchNumber);
            this.gbOperationHeader.Controls.Add(this.lblWarehouseTo);
            this.gbOperationHeader.Controls.Add(this.lblWarehouseFrom);
            this.gbOperationHeader.Controls.Add(this.lblDescription);
            this.gbOperationHeader.Controls.Add(this.tbDescription);
            this.gbOperationHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbOperationHeader.Name = "gbOperationHeader";
            this.gbOperationHeader.TabStop = false;
            // 
            // pnlWarehouseTo
            // 
            this.pnlWarehouseTo.Controls.Add(this.tbWarehouseTo);
            this.pnlWarehouseTo.Controls.Add(this.btnWarehouseToSelector);
            resources.ApplyResources(this.pnlWarehouseTo, "pnlWarehouseTo");
            this.pnlWarehouseTo.Name = "pnlWarehouseTo";
            this.pnlWarehouseTo.Leave += new System.EventHandler(this.pnlWarehouseTo_Leave);
            this.pnlWarehouseTo.Enter += new System.EventHandler(this.pnlWarehouseTo_Enter);
            // 
            // tbWarehouseTo
            // 
            this.tbWarehouseTo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "WarehouseID_To", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tbWarehouseTo, "tbWarehouseTo");
            this.tbWarehouseTo.Name = "tbWarehouseTo";
            this.tbWarehouseTo.Tag = "false";
            this.tbWarehouseTo.TextChanged += new System.EventHandler(this.tbWarehouseTo_TextChanged);
            this.tbWarehouseTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWarehouse_KeyDown);
            // 
            // operationDocHeaderBindingSource
            // 
            this.operationDocHeaderBindingSource.DataMember = "OperationDocHeader";
            this.operationDocHeaderBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnWarehouseToSelector
            // 
            this.btnWarehouseToSelector.Image = global::WMSOffice.Properties.Resources.open_dictionary;
            resources.ApplyResources(this.btnWarehouseToSelector, "btnWarehouseToSelector");
            this.btnWarehouseToSelector.Name = "btnWarehouseToSelector";
            this.btnWarehouseToSelector.TabStop = false;
            this.btnWarehouseToSelector.UseVisualStyleBackColor = true;
            this.btnWarehouseToSelector.Click += new System.EventHandler(this.btnWarehouseToSelector_Click);
            // 
            // pnlWarehouseFrom
            // 
            this.pnlWarehouseFrom.Controls.Add(this.tbWarehouseFrom);
            this.pnlWarehouseFrom.Controls.Add(this.btnWarehouseFromSelector);
            resources.ApplyResources(this.pnlWarehouseFrom, "pnlWarehouseFrom");
            this.pnlWarehouseFrom.Name = "pnlWarehouseFrom";
            this.pnlWarehouseFrom.Leave += new System.EventHandler(this.pnlWarehouseFrom_Leave);
            this.pnlWarehouseFrom.Enter += new System.EventHandler(this.pnlWarehouseFrom_Enter);
            // 
            // tbWarehouseFrom
            // 
            this.tbWarehouseFrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "WarehouseID_From", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tbWarehouseFrom, "tbWarehouseFrom");
            this.tbWarehouseFrom.Name = "tbWarehouseFrom";
            this.tbWarehouseFrom.Tag = "false";
            this.tbWarehouseFrom.TextChanged += new System.EventHandler(this.tbWarehouseFrom_TextChanged);
            this.tbWarehouseFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbWarehouse_KeyDown);
            // 
            // btnWarehouseFromSelector
            // 
            this.btnWarehouseFromSelector.Image = global::WMSOffice.Properties.Resources.open_dictionary;
            resources.ApplyResources(this.btnWarehouseFromSelector, "btnWarehouseFromSelector");
            this.btnWarehouseFromSelector.Name = "btnWarehouseFromSelector";
            this.btnWarehouseFromSelector.TabStop = false;
            this.btnWarehouseFromSelector.UseVisualStyleBackColor = true;
            this.btnWarehouseFromSelector.Click += new System.EventHandler(this.btnWarehouseFromSelector_Click);
            // 
            // lblWarehouseToValue
            // 
            resources.ApplyResources(this.lblWarehouseToValue, "lblWarehouseToValue");
            this.lblWarehouseToValue.Name = "lblWarehouseToValue";
            // 
            // lblWarehouseFromValue
            // 
            resources.ApplyResources(this.lblWarehouseFromValue, "lblWarehouseFromValue");
            this.lblWarehouseFromValue.Name = "lblWarehouseFromValue";
            // 
            // lblAmountValueUAH
            // 
            resources.ApplyResources(this.lblAmountValueUAH, "lblAmountValueUAH");
            this.lblAmountValueUAH.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Amount_UAH", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.lblAmountValueUAH.Name = "lblAmountValueUAH";
            // 
            // tbTSDJobType
            // 
            this.tbTSDJobType.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "WO_Doc_Type", true));
            resources.ApplyResources(this.tbTSDJobType, "tbTSDJobType");
            this.tbTSDJobType.Name = "tbTSDJobType";
            this.tbTSDJobType.TabStop = false;
            // 
            // lblOperationFooterSeparator
            // 
            this.lblOperationFooterSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblOperationFooterSeparator, "lblOperationFooterSeparator");
            this.lblOperationFooterSeparator.Name = "lblOperationFooterSeparator";
            // 
            // tbDocStatus
            // 
            this.tbDocStatus.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "StatusName", true));
            this.tbDocStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            resources.ApplyResources(this.tbDocStatus, "tbDocStatus");
            this.tbDocStatus.Name = "tbDocStatus";
            this.tbDocStatus.TabStop = false;
            // 
            // tbDocStatusID
            // 
            this.tbDocStatusID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Status_ID", true));
            resources.ApplyResources(this.tbDocStatusID, "tbDocStatusID");
            this.tbDocStatusID.Name = "tbDocStatusID";
            this.tbDocStatusID.TabStop = false;
            // 
            // lblDocStatus
            // 
            resources.ApplyResources(this.lblDocStatus, "lblDocStatus");
            this.lblDocStatus.ForeColor = System.Drawing.Color.Green;
            this.lblDocStatus.Name = "lblDocStatus";
            // 
            // lblDocStatusID
            // 
            resources.ApplyResources(this.lblDocStatusID, "lblDocStatusID");
            this.lblDocStatusID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDocStatusID.Name = "lblDocStatusID";
            // 
            // lblTSDJobType
            // 
            resources.ApplyResources(this.lblTSDJobType, "lblTSDJobType");
            this.lblTSDJobType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTSDJobType.Name = "lblTSDJobType";
            // 
            // tbJDDocNumber
            // 
            this.tbJDDocNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "JD_DocID", true));
            resources.ApplyResources(this.tbJDDocNumber, "tbJDDocNumber");
            this.tbJDDocNumber.Name = "tbJDDocNumber";
            this.tbJDDocNumber.TabStop = false;
            // 
            // lblJDDocNumber
            // 
            resources.ApplyResources(this.lblJDDocNumber, "lblJDDocNumber");
            this.lblJDDocNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJDDocNumber.Name = "lblJDDocNumber";
            // 
            // cmbJDDocType
            // 
            this.cmbJDDocType.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.operationDocHeaderBindingSource, "JD_DocType", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cmbJDDocType.DataSource = this.jDDocTypesBindingSource;
            this.cmbJDDocType.DisplayMember = "Dsc";
            this.cmbJDDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJDDocType.FormattingEnabled = true;
            resources.ApplyResources(this.cmbJDDocType, "cmbJDDocType");
            this.cmbJDDocType.Name = "cmbJDDocType";
            this.cmbJDDocType.ValueMember = "DCTO";
            this.cmbJDDocType.Enter += new System.EventHandler(this.cmbJDDocType_Enter);
            // 
            // jDDocTypesBindingSource
            // 
            this.jDDocTypesBindingSource.DataMember = "JDDocTypes";
            this.jDDocTypesBindingSource.DataSource = this.wH;
            // 
            // lblJDDocType
            // 
            resources.ApplyResources(this.lblJDDocType, "lblJDDocType");
            this.lblJDDocType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblJDDocType.Name = "lblJDDocType";
            // 
            // tbDocID
            // 
            this.tbDocID.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Doc_ID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tbDocID, "tbDocID");
            this.tbDocID.Name = "tbDocID";
            this.tbDocID.TabStop = false;
            // 
            // lblDocID
            // 
            resources.ApplyResources(this.lblDocID, "lblDocID");
            this.lblDocID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDocID.Name = "lblDocID";
            // 
            // tbTSDJobNumber
            // 
            this.tbTSDJobNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "WO_Doc_ID", true));
            resources.ApplyResources(this.tbTSDJobNumber, "tbTSDJobNumber");
            this.tbTSDJobNumber.Name = "tbTSDJobNumber";
            this.tbTSDJobNumber.TabStop = false;
            // 
            // lblTSDJobNumber
            // 
            resources.ApplyResources(this.lblTSDJobNumber, "lblTSDJobNumber");
            this.lblTSDJobNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTSDJobNumber.Name = "lblTSDJobNumber";
            // 
            // dtDocDate
            // 
            resources.ApplyResources(this.dtDocDate, "dtDocDate");
            this.dtDocDate.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.operationDocHeaderBindingSource, "DocDate", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.dtDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDocDate.Name = "dtDocDate";
            this.dtDocDate.TabStop = false;
            // 
            // lblDocDate
            // 
            resources.ApplyResources(this.lblDocDate, "lblDocDate");
            this.lblDocDate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDocDate.Name = "lblDocDate";
            // 
            // tbEmployee
            // 
            this.tbEmployee.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Employers", true));
            resources.ApplyResources(this.tbEmployee, "tbEmployee");
            this.tbEmployee.Name = "tbEmployee";
            this.tbEmployee.TabStop = false;
            // 
            // lblEmployee
            // 
            resources.ApplyResources(this.lblEmployee, "lblEmployee");
            this.lblEmployee.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblEmployee.Name = "lblEmployee";
            // 
            // lblAmountUAH
            // 
            resources.ApplyResources(this.lblAmountUAH, "lblAmountUAH");
            this.lblAmountUAH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblAmountUAH.Name = "lblAmountUAH";
            // 
            // tbBatchNumber
            // 
            this.tbBatchNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "BatchNumber", true));
            resources.ApplyResources(this.tbBatchNumber, "tbBatchNumber");
            this.tbBatchNumber.Name = "tbBatchNumber";
            this.tbBatchNumber.TabStop = false;
            // 
            // lblBatchNumber
            // 
            resources.ApplyResources(this.lblBatchNumber, "lblBatchNumber");
            this.lblBatchNumber.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblBatchNumber.Name = "lblBatchNumber";
            // 
            // lblWarehouseTo
            // 
            resources.ApplyResources(this.lblWarehouseTo, "lblWarehouseTo");
            this.lblWarehouseTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseTo.Name = "lblWarehouseTo";
            // 
            // lblWarehouseFrom
            // 
            resources.ApplyResources(this.lblWarehouseFrom, "lblWarehouseFrom");
            this.lblWarehouseFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseFrom.Name = "lblWarehouseFrom";
            // 
            // lblDescription
            // 
            resources.ApplyResources(this.lblDescription, "lblDescription");
            this.lblDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDescription.Name = "lblDescription";
            // 
            // tbDescription
            // 
            this.tbDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Image = global::WMSOffice.Properties.Resources.add_operation;
            resources.ApplyResources(this.btnAddOperation, "btnAddOperation");
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // cmsClipboardMenu
            // 
            this.cmsClipboardMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smbPaste});
            this.cmsClipboardMenu.Name = "cmsClipboardMenu";
            resources.ApplyResources(this.cmsClipboardMenu, "cmsClipboardMenu");
            // 
            // smbPaste
            // 
            this.smbPaste.Name = "smbPaste";
            resources.ApplyResources(this.smbPaste, "smbPaste");
            this.smbPaste.Click += new System.EventHandler(this.smbPaste_Click);
            // 
            // gbOperationDetails
            // 
            resources.ApplyResources(this.gbOperationDetails, "gbOperationDetails");
            this.gbOperationDetails.Controls.Add(this.btnRemoveOperation);
            this.gbOperationDetails.Controls.Add(this.tbxCellToolTip);
            this.gbOperationDetails.Controls.Add(this.dgvOperationDetails);
            this.gbOperationDetails.Controls.Add(this.lblSurplusSumValue);
            this.gbOperationDetails.Controls.Add(this.lblSurplusSum);
            this.gbOperationDetails.Controls.Add(this.lblShortageSumValue);
            this.gbOperationDetails.Controls.Add(this.lblShortageSum);
            this.gbOperationDetails.Controls.Add(this.btnAddOperation);
            this.gbOperationDetails.Name = "gbOperationDetails";
            this.gbOperationDetails.TabStop = false;
            // 
            // tbxCellToolTip
            // 
            resources.ApplyResources(this.tbxCellToolTip, "tbxCellToolTip");
            this.tbxCellToolTip.Name = "tbxCellToolTip";
            this.tbxCellToolTip.TabStop = false;
            // 
            // dgvOperationDetails
            // 
            this.dgvOperationDetails.AllowUserToAddRows = false;
            this.dgvOperationDetails.AllowUserToOrderColumns = true;
            this.dgvOperationDetails.AllowUserToResizeRows = false;
            resources.ApplyResources(this.dgvOperationDetails, "dgvOperationDetails");
            this.dgvOperationDetails.AutoGenerateColumns = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperationDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvOperationDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOperationDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fTDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.gLCategoryDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.expDateDataGridViewTextBoxColumn,
            this.lotStatusCodeDataGridViewTextBoxColumn,
            this.lotStatusDataGridViewTextBoxColumn,
            this.locationDataGridViewTextBoxColumn,
            this.iCLocationDataGridViewTextBoxColumn,
            this.Location_To,
            this.iCLocationToDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.costPriceDataGridViewTextBoxColumn,
            this.costAmountDataGridViewTextBoxColumn,
            this.basePriceDataGridViewTextBoxColumn,
            this.basePriceAmountDataGridViewTextBoxColumn,
            this.SSCC_From,
            this.SSCC_To});
            this.dgvOperationDetails.ContextMenuStrip = this.cmsClipboardMenu;
            this.dgvOperationDetails.DataSource = this.operationDocRowsBindingSource;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOperationDetails.DefaultCellStyle = dataGridViewCellStyle17;
            this.dgvOperationDetails.EnableHeadersVisualStyles = false;
            this.dgvOperationDetails.Name = "dgvOperationDetails";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOperationDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle18;
            this.dgvOperationDetails.Enter += new System.EventHandler(this.dgvOperationDetails_Enter);
            this.dgvOperationDetails.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperationDetails_CellValidated);
            this.dgvOperationDetails.Leave += new System.EventHandler(this.dgvOperationDetails_Leave);
            this.dgvOperationDetails.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvOperationDetails_UserDeletedRow);
            this.dgvOperationDetails.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvOperationDetails_EditingControlShowing);
            this.dgvOperationDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvOperationDetails_DataError);
            this.dgvOperationDetails.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvOperationDetails_KeyDown);
            this.dgvOperationDetails.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperationDetails_CellEnter);
            // 
            // fTDataGridViewTextBoxColumn
            // 
            this.fTDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fTDataGridViewTextBoxColumn.DataPropertyName = "FT";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fTDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            resources.ApplyResources(this.fTDataGridViewTextBoxColumn, "fTDataGridViewTextBoxColumn");
            this.fTDataGridViewTextBoxColumn.Name = "fTDataGridViewTextBoxColumn";
            this.fTDataGridViewTextBoxColumn.ReadOnly = true;
            this.fTDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            resources.ApplyResources(this.itemIDDataGridViewTextBoxColumn, "itemIDDataGridViewTextBoxColumn");
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            resources.ApplyResources(this.itemNameDataGridViewTextBoxColumn, "itemNameDataGridViewTextBoxColumn");
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            resources.ApplyResources(this.manufacturerDataGridViewTextBoxColumn, "manufacturerDataGridViewTextBoxColumn");
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // gLCategoryDataGridViewTextBoxColumn
            // 
            this.gLCategoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.gLCategoryDataGridViewTextBoxColumn.DataPropertyName = "GLCategory";
            resources.ApplyResources(this.gLCategoryDataGridViewTextBoxColumn, "gLCategoryDataGridViewTextBoxColumn");
            this.gLCategoryDataGridViewTextBoxColumn.Name = "gLCategoryDataGridViewTextBoxColumn";
            this.gLCategoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.gLCategoryDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            resources.ApplyResources(this.lotNumberDataGridViewTextBoxColumn, "lotNumberDataGridViewTextBoxColumn");
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            resources.ApplyResources(this.vendorLotDataGridViewTextBoxColumn, "vendorLotDataGridViewTextBoxColumn");
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // expDateDataGridViewTextBoxColumn
            // 
            this.expDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expDateDataGridViewTextBoxColumn.DataPropertyName = "ExpDate";
            resources.ApplyResources(this.expDateDataGridViewTextBoxColumn, "expDateDataGridViewTextBoxColumn");
            this.expDateDataGridViewTextBoxColumn.Name = "expDateDataGridViewTextBoxColumn";
            this.expDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lotStatusCodeDataGridViewTextBoxColumn
            // 
            this.lotStatusCodeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotStatusCodeDataGridViewTextBoxColumn.DataPropertyName = "LotStatusCode";
            resources.ApplyResources(this.lotStatusCodeDataGridViewTextBoxColumn, "lotStatusCodeDataGridViewTextBoxColumn");
            this.lotStatusCodeDataGridViewTextBoxColumn.Name = "lotStatusCodeDataGridViewTextBoxColumn";
            this.lotStatusCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotStatusCodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lotStatusDataGridViewTextBoxColumn
            // 
            this.lotStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotStatusDataGridViewTextBoxColumn.DataPropertyName = "LotStatus";
            resources.ApplyResources(this.lotStatusDataGridViewTextBoxColumn, "lotStatusDataGridViewTextBoxColumn");
            this.lotStatusDataGridViewTextBoxColumn.Name = "lotStatusDataGridViewTextBoxColumn";
            this.lotStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotStatusDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // locationDataGridViewTextBoxColumn
            // 
            this.locationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.locationDataGridViewTextBoxColumn.DataPropertyName = "Location";
            resources.ApplyResources(this.locationDataGridViewTextBoxColumn, "locationDataGridViewTextBoxColumn");
            this.locationDataGridViewTextBoxColumn.Name = "locationDataGridViewTextBoxColumn";
            this.locationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // iCLocationDataGridViewTextBoxColumn
            // 
            this.iCLocationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iCLocationDataGridViewTextBoxColumn.DataPropertyName = "IC_Location";
            resources.ApplyResources(this.iCLocationDataGridViewTextBoxColumn, "iCLocationDataGridViewTextBoxColumn");
            this.iCLocationDataGridViewTextBoxColumn.Name = "iCLocationDataGridViewTextBoxColumn";
            this.iCLocationDataGridViewTextBoxColumn.ReadOnly = true;
            this.iCLocationDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Location_To
            // 
            this.Location_To.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Location_To.DataPropertyName = "Location_To";
            resources.ApplyResources(this.Location_To, "Location_To");
            this.Location_To.Name = "Location_To";
            // 
            // iCLocationToDataGridViewTextBoxColumn
            // 
            this.iCLocationToDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iCLocationToDataGridViewTextBoxColumn.DataPropertyName = "IC_Location_To";
            resources.ApplyResources(this.iCLocationToDataGridViewTextBoxColumn, "iCLocationToDataGridViewTextBoxColumn");
            this.iCLocationToDataGridViewTextBoxColumn.Name = "iCLocationToDataGridViewTextBoxColumn";
            this.iCLocationToDataGridViewTextBoxColumn.ReadOnly = true;
            this.iCLocationToDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            resources.ApplyResources(this.unitOfMeasureDataGridViewTextBoxColumn, "unitOfMeasureDataGridViewTextBoxColumn");
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N2";
            dataGridViewCellStyle12.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle12;
            resources.ApplyResources(this.quantityDataGridViewTextBoxColumn, "quantityDataGridViewTextBoxColumn");
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // costPriceDataGridViewTextBoxColumn
            // 
            this.costPriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.costPriceDataGridViewTextBoxColumn.DataPropertyName = "CostPrice";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.costPriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle13;
            resources.ApplyResources(this.costPriceDataGridViewTextBoxColumn, "costPriceDataGridViewTextBoxColumn");
            this.costPriceDataGridViewTextBoxColumn.Name = "costPriceDataGridViewTextBoxColumn";
            this.costPriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.costPriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // costAmountDataGridViewTextBoxColumn
            // 
            this.costAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.costAmountDataGridViewTextBoxColumn.DataPropertyName = "CostAmount";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.costAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle14;
            resources.ApplyResources(this.costAmountDataGridViewTextBoxColumn, "costAmountDataGridViewTextBoxColumn");
            this.costAmountDataGridViewTextBoxColumn.Name = "costAmountDataGridViewTextBoxColumn";
            this.costAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.costAmountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // basePriceDataGridViewTextBoxColumn
            // 
            this.basePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.basePriceDataGridViewTextBoxColumn.DataPropertyName = "BasePrice";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle15.Format = "N4";
            dataGridViewCellStyle15.NullValue = null;
            this.basePriceDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle15;
            resources.ApplyResources(this.basePriceDataGridViewTextBoxColumn, "basePriceDataGridViewTextBoxColumn");
            this.basePriceDataGridViewTextBoxColumn.Name = "basePriceDataGridViewTextBoxColumn";
            this.basePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.basePriceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // basePriceAmountDataGridViewTextBoxColumn
            // 
            this.basePriceAmountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.basePriceAmountDataGridViewTextBoxColumn.DataPropertyName = "BasePriceAmount";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N4";
            dataGridViewCellStyle16.NullValue = null;
            this.basePriceAmountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle16;
            resources.ApplyResources(this.basePriceAmountDataGridViewTextBoxColumn, "basePriceAmountDataGridViewTextBoxColumn");
            this.basePriceAmountDataGridViewTextBoxColumn.Name = "basePriceAmountDataGridViewTextBoxColumn";
            this.basePriceAmountDataGridViewTextBoxColumn.ReadOnly = true;
            this.basePriceAmountDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // SSCC_From
            // 
            this.SSCC_From.DataPropertyName = "SSCC_From";
            resources.ApplyResources(this.SSCC_From, "SSCC_From");
            this.SSCC_From.Name = "SSCC_From";
            // 
            // SSCC_To
            // 
            this.SSCC_To.DataPropertyName = "SSCC_To";
            resources.ApplyResources(this.SSCC_To, "SSCC_To");
            this.SSCC_To.Name = "SSCC_To";
            // 
            // operationDocRowsBindingSource
            // 
            this.operationDocRowsBindingSource.DataMember = "OperationDocRows";
            this.operationDocRowsBindingSource.DataSource = this.wH;
            // 
            // lblSurplusSumValue
            // 
            resources.ApplyResources(this.lblSurplusSumValue, "lblSurplusSumValue");
            this.lblSurplusSumValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Amount_UAH", true));
            this.lblSurplusSumValue.Name = "lblSurplusSumValue";
            // 
            // lblSurplusSum
            // 
            resources.ApplyResources(this.lblSurplusSum, "lblSurplusSum");
            this.lblSurplusSum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSurplusSum.Name = "lblSurplusSum";
            // 
            // lblShortageSumValue
            // 
            resources.ApplyResources(this.lblShortageSumValue, "lblShortageSumValue");
            this.lblShortageSumValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.operationDocHeaderBindingSource, "Amount_UAH", true));
            this.lblShortageSumValue.Name = "lblShortageSumValue";
            // 
            // lblShortageSum
            // 
            resources.ApplyResources(this.lblShortageSum, "lblShortageSum");
            this.lblShortageSum.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblShortageSum.Name = "lblShortageSum";
            // 
            // gbOperation
            // 
            resources.ApplyResources(this.gbOperation, "gbOperation");
            this.gbOperation.Controls.Add(this.gbOperationHeader);
            this.gbOperation.Controls.Add(this.gbOperationDetails);
            this.gbOperation.Name = "gbOperation";
            this.gbOperation.TabStop = false;
            // 
            // operationDocHeaderTableAdapter
            // 
            this.operationDocHeaderTableAdapter.ClearBeforeFill = true;
            // 
            // operationWarehousesTableAdapter
            // 
            this.operationWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // jDDocTypesTableAdapter
            // 
            this.jDDocTypesTableAdapter.ClearBeforeFill = true;
            // 
            // operationDocRowsTableAdapter
            // 
            this.operationDocRowsTableAdapter.ClearBeforeFill = true;
            // 
            // btnRemoveOperation
            // 
            this.btnRemoveOperation.Image = global::WMSOffice.Properties.Resources.Delete_10x10;
            resources.ApplyResources(this.btnRemoveOperation, "btnRemoveOperation");
            this.btnRemoveOperation.Name = "btnRemoveOperation";
            this.btnRemoveOperation.UseVisualStyleBackColor = true;
            this.btnRemoveOperation.Click += new System.EventHandler(this.btnRemoveOperation_Click);
            // 
            // OperationEditorForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbOperation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Name = "OperationEditorForm";
            this.Load += new System.EventHandler(this.OperationEditorForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OperationEditorForm_FormClosing);
            this.Controls.SetChildIndex(this.gbOperation, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbOperationHeader.ResumeLayout(false);
            this.gbOperationHeader.PerformLayout();
            this.pnlWarehouseTo.ResumeLayout(false);
            this.pnlWarehouseTo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.operationDocHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.pnlWarehouseFrom.ResumeLayout(false);
            this.pnlWarehouseFrom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jDDocTypesBindingSource)).EndInit();
            this.cmsClipboardMenu.ResumeLayout(false);
            this.gbOperationDetails.ResumeLayout(false);
            this.gbOperationDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOperationDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.operationDocRowsBindingSource)).EndInit();
            this.gbOperation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOperationHeader;
        private System.Windows.Forms.GroupBox gbOperationDetails;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.TextBox tbDescription;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource operationDocHeaderBindingSource;
        private WMSOffice.Data.WHTableAdapters.OperationDocHeaderTableAdapter operationDocHeaderTableAdapter;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblWarehouseFrom;
        private System.Windows.Forms.Label lblWarehouseTo;
        private WMSOffice.Data.WHTableAdapters.OperationWarehousesTableAdapter operationWarehousesTableAdapter;
        private System.Windows.Forms.TextBox tbBatchNumber;
        private System.Windows.Forms.Label lblBatchNumber;
        private System.Windows.Forms.Label lblAmountUAH;
        private System.Windows.Forms.TextBox tbEmployee;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.DateTimePicker dtDocDate;
        private System.Windows.Forms.TextBox tbTSDJobNumber;
        private System.Windows.Forms.Label lblTSDJobNumber;
        private System.Windows.Forms.TextBox tbDocID;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.ComboBox cmbJDDocType;
        private System.Windows.Forms.Label lblJDDocType;
        private System.Windows.Forms.BindingSource jDDocTypesBindingSource;
        private WMSOffice.Data.WHTableAdapters.JDDocTypesTableAdapter jDDocTypesTableAdapter;
        private System.Windows.Forms.Label lblJDDocNumber;
        private System.Windows.Forms.TextBox tbJDDocNumber;
        private System.Windows.Forms.Label lblTSDJobType;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.Label lblDocStatusID;
        private System.Windows.Forms.TextBox tbDocStatus;
        private System.Windows.Forms.TextBox tbDocStatusID;
        private System.Windows.Forms.BindingSource operationDocRowsBindingSource;
        private WMSOffice.Data.WHTableAdapters.OperationDocRowsTableAdapter operationDocRowsTableAdapter;
        private System.Windows.Forms.Label lblOperationFooterSeparator;
        private System.Windows.Forms.TextBox tbTSDJobType;
        private System.Windows.Forms.Label lblAmountValueUAH;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.ContextMenuStrip cmsClipboardMenu;
        private System.Windows.Forms.ToolStripMenuItem smbPaste;
        private System.Windows.Forms.Label lblShortageSum;
        private System.Windows.Forms.Label lblShortageSumValue;
        private System.Windows.Forms.Label lblSurplusSumValue;
        private System.Windows.Forms.Label lblSurplusSum;
        private System.Windows.Forms.Button btnWarehouseToSelector;
        private System.Windows.Forms.Button btnWarehouseFromSelector;
        private System.Windows.Forms.TextBox tbWarehouseFrom;
        private System.Windows.Forms.TextBox tbWarehouseTo;
        private System.Windows.Forms.Label lblWarehouseToValue;
        private System.Windows.Forms.Label lblWarehouseFromValue;
        private System.Windows.Forms.Panel pnlWarehouseFrom;
        private System.Windows.Forms.Panel pnlWarehouseTo;
        private WMSOffice.Controls.InheritedDataGridView dgvOperationDetails;
        private System.Windows.Forms.TextBox tbxCellToolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn fTDataGridViewTextBoxColumn;
        private DataGridViewEllipsisEditColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn gLCategoryDataGridViewTextBoxColumn;
        private DataGridViewEllipsisEditColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusDataGridViewTextBoxColumn;
        private DataGridViewEllipsisEditColumn locationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCLocationDataGridViewTextBoxColumn;
        private DataGridViewEllipsisEditColumn Location_To;
        private System.Windows.Forms.DataGridViewTextBoxColumn iCLocationToDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn costAmountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePriceAmountDataGridViewTextBoxColumn;
        private DataGridViewEllipsisEditColumn SSCC_From;
        private DataGridViewEllipsisEditColumn SSCC_To;
        private System.Windows.Forms.Button btnRemoveOperation;
    }
}