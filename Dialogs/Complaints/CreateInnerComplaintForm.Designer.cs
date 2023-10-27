namespace WMSOffice.Dialogs.Complaints
{
    partial class CreateInnerComplaintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateInnerComplaintForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCommonParams = new System.Windows.Forms.GroupBox();
            this.btnFiles = new System.Windows.Forms.Button();
            this.cmbSubtype = new System.Windows.Forms.ComboBox();
            this.bsCoGetAvailableDocsSubtypes = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.lblSubtype = new System.Windows.Forms.Label();
            this.lblPayConditions = new System.Windows.Forms.Label();
            this.cBPayConditions = new System.Windows.Forms.ComboBox();
            this.lblLinkedComplaintInfo = new System.Windows.Forms.Label();
            this.tbDestAddressCode = new System.Windows.Forms.TextBox();
            this.lblDestAddressCode = new System.Windows.Forms.Label();
            this.tbSourceAddressCode = new System.Windows.Forms.TextBox();
            this.lblSourceAddressCode = new System.Windows.Forms.Label();
            this.cbWarehouses = new System.Windows.Forms.ComboBox();
            this.availableWarehousesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.tbContactName = new System.Windows.Forms.TextBox();
            this.lblContactName = new System.Windows.Forms.Label();
            this.dtpDateForecastSolution = new System.Windows.Forms.DateTimePicker();
            this.lblDateForecastSolution = new System.Windows.Forms.Label();
            this.dtpDateReceivedFromClient = new System.Windows.Forms.DateTimePicker();
            this.lblDateReceivedFromClient = new System.Windows.Forms.Label();
            this.cbComplaintType = new System.Windows.Forms.ComboBox();
            this.lblComplaintType = new System.Windows.Forms.Label();
            this.gbInvoiceHeader = new System.Windows.Forms.GroupBox();
            this.tbInnerDocDate = new System.Windows.Forms.TextBox();
            this.lblInnerDocDate = new System.Windows.Forms.Label();
            this.tbInnerDocTypeAndNumber = new System.Windows.Forms.TextBox();
            this.lblInnerDocTypeAndNumber = new System.Windows.Forms.Label();
            this.btnShowComplaintsHistory = new System.Windows.Forms.Button();
            this.tbDeliveryAddress = new System.Windows.Forms.TextBox();
            this.lblDeliveryAddress = new System.Windows.Forms.Label();
            this.tbDebtorName = new System.Windows.Forms.TextBox();
            this.lblDebtorName = new System.Windows.Forms.Label();
            this.tbDeliveryCode = new System.Windows.Forms.TextBox();
            this.lblDeliveryCode = new System.Windows.Forms.Label();
            this.btnSearchInvoice = new System.Windows.Forms.Button();
            this.gbInvoiceLines = new System.Windows.Forms.GroupBox();
            this.lblSumVAT = new System.Windows.Forms.Label();
            this.lblSumWithVAT = new System.Windows.Forms.Label();
            this.lblSumWithVATCaption = new System.Windows.Forms.Label();
            this.lblSumWithoutVAT = new System.Windows.Forms.Label();
            this.lblSumVATCaption = new System.Windows.Forms.Label();
            this.lblSumWithoutVATCaption = new System.Windows.Forms.Label();
            this.btnExportToExcel = new System.Windows.Forms.Button();
            this.btnCancelFastSearch = new System.Windows.Forms.Button();
            this.dgvInvoiceLines = new System.Windows.Forms.DataGridView();
            this.searchInnerDocsLinesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaintsExt = new WMSOffice.Data.ComplaintsExt();
            this.btnDoFactSearch = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.tbFastSearch = new System.Windows.Forms.TextBox();
            this.btnSearchVendorLotFact = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.availableWarehousesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableWarehousesTableAdapter();
            this.taCoGetAvailableDocsSubtypes = new WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_Docs_SubtypesTableAdapter();
            this.grbRefuseSubtypeData = new System.Windows.Forms.GroupBox();
            this.btnAttachment = new System.Windows.Forms.Button();
            this.tbxAttachment = new System.Windows.Forms.TextBox();
            this.lblAttachment = new System.Windows.Forms.Label();
            this.btnFaultEmployee = new System.Windows.Forms.Button();
            this.tbxFaultEmployee = new System.Windows.Forms.TextBox();
            this.lblFaultEmployee = new System.Windows.Forms.Label();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewDisableButtonColumn1 = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.tltFilePaths = new System.Windows.Forms.ToolTip(this.components);
            this.searchInnerDocsLinesTableAdapter = new WMSOffice.Data.ComplaintsExtTableAdapters.SearchInnerDocsLinesTableAdapter();
            this.clmAttachImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.colCheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmIsCold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotFactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotExpirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumWithoutVATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isVatDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isCheckedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmButton = new WMSOffice.Window.DataGridViewDisableButtonColumn();
            this.LineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colGuiltyEmployeesList = new WMSOffice.Controls.DataGridButtonEditorColumn();
            this.gbCommonParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoGetAvailableDocsSubtypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableWarehousesBindingSource)).BeginInit();
            this.gbInvoiceHeader.SuspendLayout();
            this.gbInvoiceLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchInnerDocsLinesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).BeginInit();
            this.grbRefuseSubtypeData.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCommonParams
            // 
            this.gbCommonParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCommonParams.Controls.Add(this.btnFiles);
            this.gbCommonParams.Controls.Add(this.cmbSubtype);
            this.gbCommonParams.Controls.Add(this.lblSubtype);
            this.gbCommonParams.Controls.Add(this.lblPayConditions);
            this.gbCommonParams.Controls.Add(this.cBPayConditions);
            this.gbCommonParams.Controls.Add(this.lblLinkedComplaintInfo);
            this.gbCommonParams.Controls.Add(this.tbDestAddressCode);
            this.gbCommonParams.Controls.Add(this.lblDestAddressCode);
            this.gbCommonParams.Controls.Add(this.tbSourceAddressCode);
            this.gbCommonParams.Controls.Add(this.lblSourceAddressCode);
            this.gbCommonParams.Controls.Add(this.cbWarehouses);
            this.gbCommonParams.Controls.Add(this.lblWarehouse);
            this.gbCommonParams.Controls.Add(this.tbComment);
            this.gbCommonParams.Controls.Add(this.lblComment);
            this.gbCommonParams.Controls.Add(this.tbContactName);
            this.gbCommonParams.Controls.Add(this.lblContactName);
            this.gbCommonParams.Controls.Add(this.dtpDateForecastSolution);
            this.gbCommonParams.Controls.Add(this.lblDateForecastSolution);
            this.gbCommonParams.Controls.Add(this.dtpDateReceivedFromClient);
            this.gbCommonParams.Controls.Add(this.lblDateReceivedFromClient);
            this.gbCommonParams.Controls.Add(this.cbComplaintType);
            this.gbCommonParams.Controls.Add(this.lblComplaintType);
            this.gbCommonParams.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbCommonParams.Location = new System.Drawing.Point(12, 12);
            this.gbCommonParams.Name = "gbCommonParams";
            this.gbCommonParams.Size = new System.Drawing.Size(1098, 199);
            this.gbCommonParams.TabIndex = 0;
            this.gbCommonParams.TabStop = false;
            this.gbCommonParams.Text = "Основные параметры";
            // 
            // btnFiles
            // 
            this.btnFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiles.Location = new System.Drawing.Point(1011, 149);
            this.btnFiles.Name = "btnFiles";
            this.btnFiles.Size = new System.Drawing.Size(75, 23);
            this.btnFiles.TabIndex = 105;
            this.btnFiles.Text = "Файлы";
            this.btnFiles.UseVisualStyleBackColor = true;
            this.btnFiles.Click += new System.EventHandler(this.btnFiles_Click);
            // 
            // cmbSubtype
            // 
            this.cmbSubtype.DataSource = this.bsCoGetAvailableDocsSubtypes;
            this.cmbSubtype.DisplayMember = "Doc_Subtype_Name";
            this.cmbSubtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubtype.FormattingEnabled = true;
            this.cmbSubtype.Location = new System.Drawing.Point(262, 32);
            this.cmbSubtype.Name = "cmbSubtype";
            this.cmbSubtype.Size = new System.Drawing.Size(155, 21);
            this.cmbSubtype.TabIndex = 20;
            this.cmbSubtype.ValueMember = "Doc_Subtype";
            this.cmbSubtype.SelectedValueChanged += new System.EventHandler(this.cmbSubtype_SelectedValueChanged);
            // 
            // bsCoGetAvailableDocsSubtypes
            // 
            this.bsCoGetAvailableDocsSubtypes.DataMember = "CO_Get_Available_Docs_Subtypes";
            this.bsCoGetAvailableDocsSubtypes.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblSubtype
            // 
            this.lblSubtype.AutoSize = true;
            this.lblSubtype.Location = new System.Drawing.Point(259, 16);
            this.lblSubtype.Name = "lblSubtype";
            this.lblSubtype.Size = new System.Drawing.Size(103, 13);
            this.lblSubtype.TabIndex = 19;
            this.lblSubtype.Text = "Подтип претензии:";
            // 
            // lblPayConditions
            // 
            this.lblPayConditions.AutoSize = true;
            this.lblPayConditions.Location = new System.Drawing.Point(833, 16);
            this.lblPayConditions.Name = "lblPayConditions";
            this.lblPayConditions.Size = new System.Drawing.Size(94, 13);
            this.lblPayConditions.TabIndex = 18;
            this.lblPayConditions.Text = "Условие оплаты:";
            this.lblPayConditions.Visible = false;
            // 
            // cBPayConditions
            // 
            this.cBPayConditions.Enabled = false;
            this.cBPayConditions.FormattingEnabled = true;
            this.cBPayConditions.Location = new System.Drawing.Point(836, 32);
            this.cBPayConditions.Name = "cBPayConditions";
            this.cBPayConditions.Size = new System.Drawing.Size(121, 21);
            this.cBPayConditions.TabIndex = 50;
            this.cBPayConditions.Visible = false;
            // 
            // lblLinkedComplaintInfo
            // 
            this.lblLinkedComplaintInfo.AutoSize = true;
            this.lblLinkedComplaintInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLinkedComplaintInfo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLinkedComplaintInfo.Location = new System.Drawing.Point(125, 135);
            this.lblLinkedComplaintInfo.Name = "lblLinkedComplaintInfo";
            this.lblLinkedComplaintInfo.Size = new System.Drawing.Size(496, 13);
            this.lblLinkedComplaintInfo.TabIndex = 15;
            this.lblLinkedComplaintInfo.Text = "* СВЯЗАНА С ПРЕТЕНЗИЕЙ № 12345678 от 15.02.2010 (тип претензии - (BR) Бой)";
            this.lblLinkedComplaintInfo.Visible = false;
            // 
            // tbDestAddressCode
            // 
            this.tbDestAddressCode.Enabled = false;
            this.tbDestAddressCode.Location = new System.Drawing.Point(461, 72);
            this.tbDestAddressCode.MaxLength = 6;
            this.tbDestAddressCode.Name = "tbDestAddressCode";
            this.tbDestAddressCode.Size = new System.Drawing.Size(100, 20);
            this.tbDestAddressCode.TabIndex = 80;
            this.tbDestAddressCode.Text = "0";
            // 
            // lblDestAddressCode
            // 
            this.lblDestAddressCode.AutoSize = true;
            this.lblDestAddressCode.Location = new System.Drawing.Point(458, 56);
            this.lblDestAddressCode.Name = "lblDestAddressCode";
            this.lblDestAddressCode.Size = new System.Drawing.Size(139, 13);
            this.lblDestAddressCode.TabIndex = 10;
            this.lblDestAddressCode.Text = "Код адр. дост. получателя";
            // 
            // tbSourceAddressCode
            // 
            this.tbSourceAddressCode.Location = new System.Drawing.Point(262, 72);
            this.tbSourceAddressCode.MaxLength = 6;
            this.tbSourceAddressCode.Name = "tbSourceAddressCode";
            this.tbSourceAddressCode.Size = new System.Drawing.Size(100, 20);
            this.tbSourceAddressCode.TabIndex = 70;
            this.tbSourceAddressCode.Text = "0";
            this.tbSourceAddressCode.TextChanged += new System.EventHandler(this.tbSourceAddressCode_TextChanged);
            this.tbSourceAddressCode.Leave += new System.EventHandler(this.tbSourceAddressCode_Leave);
            this.tbSourceAddressCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSourceAddressCode_KeyPress);
            // 
            // lblSourceAddressCode
            // 
            this.lblSourceAddressCode.AutoSize = true;
            this.lblSourceAddressCode.Location = new System.Drawing.Point(259, 56);
            this.lblSourceAddressCode.Name = "lblSourceAddressCode";
            this.lblSourceAddressCode.Size = new System.Drawing.Size(193, 13);
            this.lblSourceAddressCode.TabIndex = 8;
            this.lblSourceAddressCode.Text = "Код адр. дост. источника претензии:";
            // 
            // cbWarehouses
            // 
            this.cbWarehouses.DataSource = this.availableWarehousesBindingSource;
            this.cbWarehouses.DisplayMember = "Name";
            this.cbWarehouses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWarehouses.FormattingEnabled = true;
            this.cbWarehouses.Location = new System.Drawing.Point(9, 72);
            this.cbWarehouses.MaxDropDownItems = 20;
            this.cbWarehouses.Name = "cbWarehouses";
            this.cbWarehouses.Size = new System.Drawing.Size(238, 21);
            this.cbWarehouses.TabIndex = 60;
            this.cbWarehouses.ValueMember = "Code";
            // 
            // availableWarehousesBindingSource
            // 
            this.availableWarehousesBindingSource.DataMember = "AvailableWarehouses";
            this.availableWarehousesBindingSource.DataSource = this.complaints;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(6, 56);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(241, 13);
            this.lblWarehouse.TabIndex = 6;
            this.lblWarehouse.Text = "Склад, к которому предъявляется претензия:";
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(9, 151);
            this.tbComment.MaxLength = 500;
            this.tbComment.Multiline = true;
            this.tbComment.Name = "tbComment";
            this.tbComment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbComment.Size = new System.Drawing.Size(983, 41);
            this.tbComment.TabIndex = 100;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(6, 135);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(116, 13);
            this.lblComment.TabIndex = 14;
            this.lblComment.Text = "Описание претензии:";
            // 
            // tbContactName
            // 
            this.tbContactName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbContactName.Location = new System.Drawing.Point(9, 112);
            this.tbContactName.MaxLength = 100;
            this.tbContactName.Name = "tbContactName";
            this.tbContactName.Size = new System.Drawing.Size(1083, 20);
            this.tbContactName.TabIndex = 90;
            // 
            // lblContactName
            // 
            this.lblContactName.AutoSize = true;
            this.lblContactName.Location = new System.Drawing.Point(6, 96);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(136, 13);
            this.lblContactName.TabIndex = 12;
            this.lblContactName.Text = "Контактная информация:";
            // 
            // dtpDateForecastSolution
            // 
            this.dtpDateForecastSolution.CustomFormat = "dd.MM.yyy";
            this.dtpDateForecastSolution.Enabled = false;
            this.dtpDateForecastSolution.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateForecastSolution.Location = new System.Drawing.Point(660, 33);
            this.dtpDateForecastSolution.Name = "dtpDateForecastSolution";
            this.dtpDateForecastSolution.Size = new System.Drawing.Size(130, 20);
            this.dtpDateForecastSolution.TabIndex = 40;
            // 
            // lblDateForecastSolution
            // 
            this.lblDateForecastSolution.AutoSize = true;
            this.lblDateForecastSolution.Location = new System.Drawing.Point(657, 16);
            this.lblDateForecastSolution.Name = "lblDateForecastSolution";
            this.lblDateForecastSolution.Size = new System.Drawing.Size(133, 13);
            this.lblDateForecastSolution.TabIndex = 4;
            this.lblDateForecastSolution.Text = "Плановая дата решения:";
            // 
            // dtpDateReceivedFromClient
            // 
            this.dtpDateReceivedFromClient.CustomFormat = "dd.MM.yyy HH:mm:ss";
            this.dtpDateReceivedFromClient.Enabled = false;
            this.dtpDateReceivedFromClient.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateReceivedFromClient.Location = new System.Drawing.Point(461, 33);
            this.dtpDateReceivedFromClient.Name = "dtpDateReceivedFromClient";
            this.dtpDateReceivedFromClient.Size = new System.Drawing.Size(149, 20);
            this.dtpDateReceivedFromClient.TabIndex = 30;
            // 
            // lblDateReceivedFromClient
            // 
            this.lblDateReceivedFromClient.AutoSize = true;
            this.lblDateReceivedFromClient.Location = new System.Drawing.Point(458, 16);
            this.lblDateReceivedFromClient.Name = "lblDateReceivedFromClient";
            this.lblDateReceivedFromClient.Size = new System.Drawing.Size(147, 13);
            this.lblDateReceivedFromClient.TabIndex = 2;
            this.lblDateReceivedFromClient.Text = "Время обращения клиента:";
            // 
            // cbComplaintType
            // 
            this.cbComplaintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComplaintType.Enabled = false;
            this.cbComplaintType.FormattingEnabled = true;
            this.cbComplaintType.Items.AddRange(new object[] {
            "(не выбран)"});
            this.cbComplaintType.Location = new System.Drawing.Point(9, 32);
            this.cbComplaintType.MaxDropDownItems = 20;
            this.cbComplaintType.Name = "cbComplaintType";
            this.cbComplaintType.Size = new System.Drawing.Size(205, 21);
            this.cbComplaintType.TabIndex = 10;
            // 
            // lblComplaintType
            // 
            this.lblComplaintType.AutoSize = true;
            this.lblComplaintType.Location = new System.Drawing.Point(6, 16);
            this.lblComplaintType.Name = "lblComplaintType";
            this.lblComplaintType.Size = new System.Drawing.Size(85, 13);
            this.lblComplaintType.TabIndex = 0;
            this.lblComplaintType.Text = "Тип претензии:";
            // 
            // gbInvoiceHeader
            // 
            this.gbInvoiceHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInvoiceHeader.Controls.Add(this.tbInnerDocDate);
            this.gbInvoiceHeader.Controls.Add(this.lblInnerDocDate);
            this.gbInvoiceHeader.Controls.Add(this.tbInnerDocTypeAndNumber);
            this.gbInvoiceHeader.Controls.Add(this.lblInnerDocTypeAndNumber);
            this.gbInvoiceHeader.Controls.Add(this.btnShowComplaintsHistory);
            this.gbInvoiceHeader.Controls.Add(this.tbDeliveryAddress);
            this.gbInvoiceHeader.Controls.Add(this.lblDeliveryAddress);
            this.gbInvoiceHeader.Controls.Add(this.tbDebtorName);
            this.gbInvoiceHeader.Controls.Add(this.lblDebtorName);
            this.gbInvoiceHeader.Controls.Add(this.tbDeliveryCode);
            this.gbInvoiceHeader.Controls.Add(this.lblDeliveryCode);
            this.gbInvoiceHeader.Controls.Add(this.btnSearchInvoice);
            this.gbInvoiceHeader.Location = new System.Drawing.Point(12, 312);
            this.gbInvoiceHeader.Name = "gbInvoiceHeader";
            this.gbInvoiceHeader.Size = new System.Drawing.Size(1098, 132);
            this.gbInvoiceHeader.TabIndex = 1;
            this.gbInvoiceHeader.TabStop = false;
            this.gbInvoiceHeader.Text = "Поиск накладных, по которым создается претензия";
            // 
            // tbInnerDocDate
            // 
            this.tbInnerDocDate.Location = new System.Drawing.Point(142, 100);
            this.tbInnerDocDate.Name = "tbInnerDocDate";
            this.tbInnerDocDate.ReadOnly = true;
            this.tbInnerDocDate.Size = new System.Drawing.Size(134, 20);
            this.tbInnerDocDate.TabIndex = 144;
            this.tbInnerDocDate.TabStop = false;
            // 
            // lblInnerDocDate
            // 
            this.lblInnerDocDate.AutoSize = true;
            this.lblInnerDocDate.Location = new System.Drawing.Point(139, 84);
            this.lblInnerDocDate.Name = "lblInnerDocDate";
            this.lblInnerDocDate.Size = new System.Drawing.Size(89, 13);
            this.lblInnerDocDate.TabIndex = 143;
            this.lblInnerDocDate.Text = "Дата вн. док-та:";
            // 
            // tbInnerDocTypeAndNumber
            // 
            this.tbInnerDocTypeAndNumber.Location = new System.Drawing.Point(9, 100);
            this.tbInnerDocTypeAndNumber.Name = "tbInnerDocTypeAndNumber";
            this.tbInnerDocTypeAndNumber.ReadOnly = true;
            this.tbInnerDocTypeAndNumber.Size = new System.Drawing.Size(127, 20);
            this.tbInnerDocTypeAndNumber.TabIndex = 142;
            this.tbInnerDocTypeAndNumber.TabStop = false;
            // 
            // lblInnerDocTypeAndNumber
            // 
            this.lblInnerDocTypeAndNumber.AutoSize = true;
            this.lblInnerDocTypeAndNumber.Location = new System.Drawing.Point(6, 84);
            this.lblInnerDocTypeAndNumber.Name = "lblInnerDocTypeAndNumber";
            this.lblInnerDocTypeAndNumber.Size = new System.Drawing.Size(126, 13);
            this.lblInnerDocTypeAndNumber.TabIndex = 141;
            this.lblInnerDocTypeAndNumber.Text = "Тип и номер вн. док-та:";
            // 
            // btnShowComplaintsHistory
            // 
            this.btnShowComplaintsHistory.Image = ((System.Drawing.Image)(resources.GetObject("btnShowComplaintsHistory.Image")));
            this.btnShowComplaintsHistory.Location = new System.Drawing.Point(327, 19);
            this.btnShowComplaintsHistory.Name = "btnShowComplaintsHistory";
            this.btnShowComplaintsHistory.Size = new System.Drawing.Size(287, 23);
            this.btnShowComplaintsHistory.TabIndex = 140;
            this.btnShowComplaintsHistory.Text = "История претензий по адр.дост. или накладной";
            this.btnShowComplaintsHistory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnShowComplaintsHistory.UseVisualStyleBackColor = true;
            this.btnShowComplaintsHistory.Click += new System.EventHandler(this.btnShowComplaintsHistory_Click);
            // 
            // tbDeliveryAddress
            // 
            this.tbDeliveryAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDeliveryAddress.Location = new System.Drawing.Point(377, 61);
            this.tbDeliveryAddress.Name = "tbDeliveryAddress";
            this.tbDeliveryAddress.ReadOnly = true;
            this.tbDeliveryAddress.Size = new System.Drawing.Size(709, 20);
            this.tbDeliveryAddress.TabIndex = 7;
            this.tbDeliveryAddress.TabStop = false;
            // 
            // lblDeliveryAddress
            // 
            this.lblDeliveryAddress.AutoSize = true;
            this.lblDeliveryAddress.Location = new System.Drawing.Point(374, 45);
            this.lblDeliveryAddress.Name = "lblDeliveryAddress";
            this.lblDeliveryAddress.Size = new System.Drawing.Size(91, 13);
            this.lblDeliveryAddress.TabIndex = 6;
            this.lblDeliveryAddress.Text = "Адрес доставки:";
            // 
            // tbDebtorName
            // 
            this.tbDebtorName.Location = new System.Drawing.Point(111, 61);
            this.tbDebtorName.Name = "tbDebtorName";
            this.tbDebtorName.ReadOnly = true;
            this.tbDebtorName.Size = new System.Drawing.Size(260, 20);
            this.tbDebtorName.TabIndex = 5;
            this.tbDebtorName.TabStop = false;
            // 
            // lblDebtorName
            // 
            this.lblDebtorName.AutoSize = true;
            this.lblDebtorName.Location = new System.Drawing.Point(108, 45);
            this.lblDebtorName.Name = "lblDebtorName";
            this.lblDebtorName.Size = new System.Drawing.Size(130, 13);
            this.lblDebtorName.TabIndex = 4;
            this.lblDebtorName.Text = "Наименование клиента:";
            // 
            // tbDeliveryCode
            // 
            this.tbDeliveryCode.Location = new System.Drawing.Point(9, 61);
            this.tbDeliveryCode.Name = "tbDeliveryCode";
            this.tbDeliveryCode.ReadOnly = true;
            this.tbDeliveryCode.Size = new System.Drawing.Size(96, 20);
            this.tbDeliveryCode.TabIndex = 3;
            this.tbDeliveryCode.TabStop = false;
            // 
            // lblDeliveryCode
            // 
            this.lblDeliveryCode.AutoSize = true;
            this.lblDeliveryCode.Location = new System.Drawing.Point(6, 45);
            this.lblDeliveryCode.Name = "lblDeliveryCode";
            this.lblDeliveryCode.Size = new System.Drawing.Size(103, 13);
            this.lblDeliveryCode.TabIndex = 2;
            this.lblDeliveryCode.Text = "Код адр. доставки:";
            // 
            // btnSearchInvoice
            // 
            this.btnSearchInvoice.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchInvoice.Image")));
            this.btnSearchInvoice.Location = new System.Drawing.Point(9, 19);
            this.btnSearchInvoice.Name = "btnSearchInvoice";
            this.btnSearchInvoice.Size = new System.Drawing.Size(229, 23);
            this.btnSearchInvoice.TabIndex = 130;
            this.btnSearchInvoice.Text = "Поиск накладной (заказа) по номеру";
            this.btnSearchInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchInvoice.UseVisualStyleBackColor = false;
            this.btnSearchInvoice.Click += new System.EventHandler(this.btnSearchInvoice_Click);
            // 
            // gbInvoiceLines
            // 
            this.gbInvoiceLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInvoiceLines.Controls.Add(this.lblSumVAT);
            this.gbInvoiceLines.Controls.Add(this.lblSumWithVAT);
            this.gbInvoiceLines.Controls.Add(this.lblSumWithVATCaption);
            this.gbInvoiceLines.Controls.Add(this.lblSumWithoutVAT);
            this.gbInvoiceLines.Controls.Add(this.lblSumVATCaption);
            this.gbInvoiceLines.Controls.Add(this.lblSumWithoutVATCaption);
            this.gbInvoiceLines.Controls.Add(this.btnExportToExcel);
            this.gbInvoiceLines.Controls.Add(this.btnCancelFastSearch);
            this.gbInvoiceLines.Controls.Add(this.dgvInvoiceLines);
            this.gbInvoiceLines.Controls.Add(this.btnDoFactSearch);
            this.gbInvoiceLines.Controls.Add(this.btnAddItem);
            this.gbInvoiceLines.Controls.Add(this.tbFastSearch);
            this.gbInvoiceLines.Controls.Add(this.btnSearchVendorLotFact);
            this.gbInvoiceLines.Location = new System.Drawing.Point(12, 450);
            this.gbInvoiceLines.Name = "gbInvoiceLines";
            this.gbInvoiceLines.Size = new System.Drawing.Size(1098, 223);
            this.gbInvoiceLines.TabIndex = 2;
            this.gbInvoiceLines.TabStop = false;
            this.gbInvoiceLines.Text = "Строки накладной, по которым создается претензия. Отметьте нужные строки флажками" +
                " и измените к-во!";
            // 
            // lblSumVAT
            // 
            this.lblSumVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumVAT.AutoSize = true;
            this.lblSumVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumVAT.Location = new System.Drawing.Point(407, 200);
            this.lblSumVAT.Name = "lblSumVAT";
            this.lblSumVAT.Size = new System.Drawing.Size(16, 16);
            this.lblSumVAT.TabIndex = 12;
            this.lblSumVAT.Text = "0";
            // 
            // lblSumWithVAT
            // 
            this.lblSumWithVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumWithVAT.AutoSize = true;
            this.lblSumWithVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumWithVAT.Location = new System.Drawing.Point(701, 200);
            this.lblSumWithVAT.Name = "lblSumWithVAT";
            this.lblSumWithVAT.Size = new System.Drawing.Size(16, 16);
            this.lblSumWithVAT.TabIndex = 11;
            this.lblSumWithVAT.Text = "0";
            // 
            // lblSumWithVATCaption
            // 
            this.lblSumWithVATCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumWithVATCaption.AutoSize = true;
            this.lblSumWithVATCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumWithVATCaption.Location = new System.Drawing.Point(603, 202);
            this.lblSumWithVATCaption.Name = "lblSumWithVATCaption";
            this.lblSumWithVATCaption.Size = new System.Drawing.Size(92, 13);
            this.lblSumWithVATCaption.TabIndex = 10;
            this.lblSumWithVATCaption.Text = "Сумма с НДС:";
            // 
            // lblSumWithoutVAT
            // 
            this.lblSumWithoutVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumWithoutVAT.AutoSize = true;
            this.lblSumWithoutVAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumWithoutVAT.Location = new System.Drawing.Point(118, 200);
            this.lblSumWithoutVAT.Name = "lblSumWithoutVAT";
            this.lblSumWithoutVAT.Size = new System.Drawing.Size(16, 16);
            this.lblSumWithoutVAT.TabIndex = 9;
            this.lblSumWithoutVAT.Text = "0";
            // 
            // lblSumVATCaption
            // 
            this.lblSumVATCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumVATCaption.AutoSize = true;
            this.lblSumVATCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumVATCaption.Location = new System.Drawing.Point(363, 202);
            this.lblSumVATCaption.Name = "lblSumVATCaption";
            this.lblSumVATCaption.Size = new System.Drawing.Size(38, 13);
            this.lblSumVATCaption.TabIndex = 8;
            this.lblSumVATCaption.Text = "НДС:";
            // 
            // lblSumWithoutVATCaption
            // 
            this.lblSumWithoutVATCaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSumWithoutVATCaption.AutoSize = true;
            this.lblSumWithoutVATCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSumWithoutVATCaption.Location = new System.Drawing.Point(6, 202);
            this.lblSumWithoutVATCaption.Name = "lblSumWithoutVATCaption";
            this.lblSumWithoutVATCaption.Size = new System.Drawing.Size(106, 13);
            this.lblSumWithoutVATCaption.TabIndex = 7;
            this.lblSumWithoutVATCaption.Text = "Сумма без НДС:";
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExcel.Image")));
            this.btnExportToExcel.Location = new System.Drawing.Point(218, 13);
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(122, 24);
            this.btnExportToExcel.TabIndex = 200;
            this.btnExportToExcel.Text = "Экспорт в Excel";
            this.btnExportToExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExportToExcel.UseVisualStyleBackColor = true;
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnCancelFastSearch
            // 
            this.btnCancelFastSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelFastSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelFastSearch.Image")));
            this.btnCancelFastSearch.Location = new System.Drawing.Point(144, 16);
            this.btnCancelFastSearch.Name = "btnCancelFastSearch";
            this.btnCancelFastSearch.Size = new System.Drawing.Size(25, 22);
            this.btnCancelFastSearch.TabIndex = 190;
            this.btnCancelFastSearch.UseVisualStyleBackColor = true;
            this.btnCancelFastSearch.Click += new System.EventHandler(this.btnCancelFastSearch_Click);
            // 
            // dgvInvoiceLines
            // 
            this.dgvInvoiceLines.AllowUserToAddRows = false;
            this.dgvInvoiceLines.AllowUserToDeleteRows = false;
            this.dgvInvoiceLines.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvInvoiceLines.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvInvoiceLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoiceLines.AutoGenerateColumns = false;
            this.dgvInvoiceLines.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInvoiceLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmAttachImage,
            this.colCheckBox,
            this.clmIsCold,
            this.invoiceNumberDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.invoiceTypeDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.barcodeDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotFactDataGridViewTextBoxColumn,
            this.lotExpirationDateDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.manufacturerNameDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.sumWithoutVATDataGridViewTextBoxColumn,
            this.isVatDataGridViewCheckBoxColumn,
            this.isCheckedDataGridViewCheckBoxColumn,
            this.clmButton,
            this.LineID,
            this.colGuiltyEmployeesList});
            this.dgvInvoiceLines.DataSource = this.searchInnerDocsLinesBindingSource;
            this.dgvInvoiceLines.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInvoiceLines.Location = new System.Drawing.Point(3, 38);
            this.dgvInvoiceLines.Name = "dgvInvoiceLines";
            this.dgvInvoiceLines.RowHeadersVisible = false;
            this.dgvInvoiceLines.RowTemplate.Height = 21;
            this.dgvInvoiceLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceLines.ShowEditingIcon = false;
            this.dgvInvoiceLines.Size = new System.Drawing.Size(1092, 158);
            this.dgvInvoiceLines.TabIndex = 210;
            this.dgvInvoiceLines.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceLines_CellValueChanged);
            this.dgvInvoiceLines.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvInvoiceLines_CellPainting);
            this.dgvInvoiceLines.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvInvoiceLines_EditingControlShowing);
            this.dgvInvoiceLines.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvInvoiceLines_CurrentCellDirtyStateChanged);
            this.dgvInvoiceLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvInvoiceLines_DataBindingComplete);
            this.dgvInvoiceLines.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInvoiceLines_CellContentClick);
            // 
            // searchInnerDocsLinesBindingSource
            // 
            this.searchInnerDocsLinesBindingSource.DataMember = "SearchInnerDocsLines";
            this.searchInnerDocsLinesBindingSource.DataSource = this.complaintsExt;
            // 
            // complaintsExt
            // 
            this.complaintsExt.DataSetName = "ComplaintsExt";
            this.complaintsExt.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnDoFactSearch
            // 
            this.btnDoFactSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDoFactSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnDoFactSearch.Image")));
            this.btnDoFactSearch.Location = new System.Drawing.Point(120, 16);
            this.btnDoFactSearch.Name = "btnDoFactSearch";
            this.btnDoFactSearch.Size = new System.Drawing.Size(25, 22);
            this.btnDoFactSearch.TabIndex = 180;
            this.btnDoFactSearch.UseVisualStyleBackColor = true;
            this.btnDoFactSearch.Click += new System.EventHandler(this.btnDoFactSearch_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Enabled = false;
            this.btnAddItem.Image = ((System.Drawing.Image)(resources.GetObject("btnAddItem.Image")));
            this.btnAddItem.Location = new System.Drawing.Point(562, 12);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(130, 24);
            this.btnAddItem.TabIndex = 150;
            this.btnAddItem.Text = "Добавить товар";
            this.btnAddItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Visible = false;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // tbFastSearch
            // 
            this.tbFastSearch.Location = new System.Drawing.Point(9, 16);
            this.tbFastSearch.MaxLength = 100;
            this.tbFastSearch.Name = "tbFastSearch";
            this.tbFastSearch.Size = new System.Drawing.Size(111, 20);
            this.tbFastSearch.TabIndex = 170;
            this.tbFastSearch.Text = "Быстрый поиск...";
            this.tbFastSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbFastSearch_KeyDown);
            this.tbFastSearch.Enter += new System.EventHandler(this.tbFastSearch_Enter);
            // 
            // btnSearchVendorLotFact
            // 
            this.btnSearchVendorLotFact.Enabled = false;
            this.btnSearchVendorLotFact.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchVendorLotFact.Image")));
            this.btnSearchVendorLotFact.Location = new System.Drawing.Point(691, 12);
            this.btnSearchVendorLotFact.Name = "btnSearchVendorLotFact";
            this.btnSearchVendorLotFact.Size = new System.Drawing.Size(148, 24);
            this.btnSearchVendorLotFact.TabIndex = 160;
            this.btnSearchVendorLotFact.Text = "Сменить факт. серию";
            this.btnSearchVendorLotFact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearchVendorLotFact.UseVisualStyleBackColor = true;
            this.btnSearchVendorLotFact.Visible = false;
            this.btnSearchVendorLotFact.Click += new System.EventHandler(this.btnSearchVendorLotFact_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(948, 687);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(81, 23);
            this.btnSave.TabIndex = 220;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1035, 687);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 230;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // availableWarehousesTableAdapter
            // 
            this.availableWarehousesTableAdapter.ClearBeforeFill = true;
            // 
            // taCoGetAvailableDocsSubtypes
            // 
            this.taCoGetAvailableDocsSubtypes.ClearBeforeFill = true;
            // 
            // grbRefuseSubtypeData
            // 
            this.grbRefuseSubtypeData.Controls.Add(this.btnAttachment);
            this.grbRefuseSubtypeData.Controls.Add(this.tbxAttachment);
            this.grbRefuseSubtypeData.Controls.Add(this.lblAttachment);
            this.grbRefuseSubtypeData.Controls.Add(this.btnFaultEmployee);
            this.grbRefuseSubtypeData.Controls.Add(this.tbxFaultEmployee);
            this.grbRefuseSubtypeData.Controls.Add(this.lblFaultEmployee);
            this.grbRefuseSubtypeData.Location = new System.Drawing.Point(12, 217);
            this.grbRefuseSubtypeData.Name = "grbRefuseSubtypeData";
            this.grbRefuseSubtypeData.Size = new System.Drawing.Size(1098, 89);
            this.grbRefuseSubtypeData.TabIndex = 5;
            this.grbRefuseSubtypeData.TabStop = false;
            this.grbRefuseSubtypeData.Text = "Дополнительная информация по подтипу возврата";
            // 
            // btnAttachment
            // 
            this.btnAttachment.Location = new System.Drawing.Point(620, 56);
            this.btnAttachment.Name = "btnAttachment";
            this.btnAttachment.Size = new System.Drawing.Size(75, 23);
            this.btnAttachment.TabIndex = 120;
            this.btnAttachment.Text = "Вложить";
            this.btnAttachment.UseVisualStyleBackColor = true;
            this.btnAttachment.Click += new System.EventHandler(this.btnAttachment_Click);
            // 
            // tbxAttachment
            // 
            this.tbxAttachment.Location = new System.Drawing.Point(249, 58);
            this.tbxAttachment.Name = "tbxAttachment";
            this.tbxAttachment.ReadOnly = true;
            this.tbxAttachment.Size = new System.Drawing.Size(361, 20);
            this.tbxAttachment.TabIndex = 4;
            this.tbxAttachment.TabStop = false;
            // 
            // lblAttachment
            // 
            this.lblAttachment.AutoSize = true;
            this.lblAttachment.Location = new System.Drawing.Point(6, 61);
            this.lblAttachment.Name = "lblAttachment";
            this.lblAttachment.Size = new System.Drawing.Size(237, 13);
            this.lblAttachment.TabIndex = 3;
            this.lblAttachment.Text = "Подтверждение менеджера отдела закупок: ";
            // 
            // btnFaultEmployee
            // 
            this.btnFaultEmployee.Location = new System.Drawing.Point(620, 20);
            this.btnFaultEmployee.Name = "btnFaultEmployee";
            this.btnFaultEmployee.Size = new System.Drawing.Size(75, 23);
            this.btnFaultEmployee.TabIndex = 110;
            this.btnFaultEmployee.Text = "Выбрать";
            this.btnFaultEmployee.UseVisualStyleBackColor = true;
            this.btnFaultEmployee.Click += new System.EventHandler(this.btnFaultEmployee_Click);
            // 
            // tbxFaultEmployee
            // 
            this.tbxFaultEmployee.Location = new System.Drawing.Point(249, 22);
            this.tbxFaultEmployee.Name = "tbxFaultEmployee";
            this.tbxFaultEmployee.ReadOnly = true;
            this.tbxFaultEmployee.Size = new System.Drawing.Size(361, 20);
            this.tbxFaultEmployee.TabIndex = 110;
            this.tbxFaultEmployee.TabStop = false;
            // 
            // lblFaultEmployee
            // 
            this.lblFaultEmployee.AutoSize = true;
            this.lblFaultEmployee.Location = new System.Drawing.Point(6, 25);
            this.lblFaultEmployee.Name = "lblFaultEmployee";
            this.lblFaultEmployee.Size = new System.Drawing.Size(160, 13);
            this.lblFaultEmployee.TabIndex = 0;
            this.lblFaultEmployee.Text = "Ответственный оператор ТП: ";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 37;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Cold";
            this.dataGridViewTextBoxColumn1.HeaderText = "Темп.режим";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 75;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LineID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Стр.";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 50;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "InvoiceTypeAndNumber";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn3.HeaderText = "№ накладной";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 95;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "InvoiceDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата накл.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 75;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ItemID";
            this.dataGridViewTextBoxColumn5.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 55;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ItemName";
            this.dataGridViewTextBoxColumn6.HeaderText = "Наименование товара";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 180;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "VendorLot";
            this.dataGridViewTextBoxColumn7.HeaderText = "Докум. серия";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Quantity";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn8.HeaderText = "К-во";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.Width = 65;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "VendorLotFact";
            this.dataGridViewTextBoxColumn9.HeaderText = "Факт. серия";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 80;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "LotExpirationDate";
            this.dataGridViewTextBoxColumn10.HeaderText = "Срок годн.";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 70;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "UnitOfMeasure";
            this.dataGridViewTextBoxColumn11.HeaderText = "Ед. изм.";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 50;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ManufacturerName";
            this.dataGridViewTextBoxColumn12.HeaderText = "Наименование производителя";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 220;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "Price";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn13.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn13.HeaderText = "Цена без НДС";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 75;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "SumWithoutVAT";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn14.HeaderText = "Сумма без НДС";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 75;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsVat";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsVat";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            // 
            // dataGridViewDisableButtonColumn1
            // 
            this.dataGridViewDisableButtonColumn1.HeaderText = "Док.";
            this.dataGridViewDisableButtonColumn1.Name = "dataGridViewDisableButtonColumn1";
            this.dataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDisableButtonColumn1.Text = "Прикрепить документ";
            this.dataGridViewDisableButtonColumn1.ToolTipText = "Прикрепить документ";
            this.dataGridViewDisableButtonColumn1.Visible = false;
            this.dataGridViewDisableButtonColumn1.Width = 32;
            // 
            // searchInnerDocsLinesTableAdapter
            // 
            this.searchInnerDocsLinesTableAdapter.ClearBeforeFill = true;
            // 
            // clmAttachImage
            // 
            this.clmAttachImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clmAttachImage.HeaderText = "";
            this.clmAttachImage.Name = "clmAttachImage";
            this.clmAttachImage.Visible = false;
            this.clmAttachImage.Width = 5;
            // 
            // colCheckBox
            // 
            this.colCheckBox.DataPropertyName = "IsChecked";
            this.colCheckBox.HeaderText = "Отм.";
            this.colCheckBox.Name = "colCheckBox";
            this.colCheckBox.Width = 37;
            // 
            // clmIsCold
            // 
            this.clmIsCold.DataPropertyName = "Cold";
            this.clmIsCold.HeaderText = "Темп. режим";
            this.clmIsCold.Name = "clmIsCold";
            this.clmIsCold.ReadOnly = true;
            this.clmIsCold.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmIsCold.Visible = false;
            this.clmIsCold.Width = 75;
            // 
            // invoiceNumberDataGridViewTextBoxColumn
            // 
            this.invoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "InvoiceNumber";
            this.invoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ вн. док-та";
            this.invoiceNumberDataGridViewTextBoxColumn.Name = "invoiceNumberDataGridViewTextBoxColumn";
            this.invoiceNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invoiceDateDataGridViewTextBoxColumn
            // 
            this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "Дата вн. док-та";
            this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
            this.invoiceDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // invoiceTypeDataGridViewTextBoxColumn
            // 
            this.invoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "InvoiceType";
            this.invoiceTypeDataGridViewTextBoxColumn.HeaderText = "Тип вн. док-та";
            this.invoiceTypeDataGridViewTextBoxColumn.Name = "invoiceTypeDataGridViewTextBoxColumn";
            this.invoiceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "ItemID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemIDDataGridViewTextBoxColumn.Width = 55;
            // 
            // barcodeDataGridViewTextBoxColumn
            // 
            this.barcodeDataGridViewTextBoxColumn.DataPropertyName = "bar_code";
            this.barcodeDataGridViewTextBoxColumn.HeaderText = "Ш/К ящика";
            this.barcodeDataGridViewTextBoxColumn.Name = "barcodeDataGridViewTextBoxColumn";
            this.barcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.barcodeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.itemNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "VendorLot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Докум. серия";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorLotDataGridViewTextBoxColumn.Width = 80;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "К-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.quantityDataGridViewTextBoxColumn.Width = 65;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "LotNumber";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // vendorLotFactDataGridViewTextBoxColumn
            // 
            this.vendorLotFactDataGridViewTextBoxColumn.DataPropertyName = "VendorLotFact";
            this.vendorLotFactDataGridViewTextBoxColumn.HeaderText = "Факт. серия";
            this.vendorLotFactDataGridViewTextBoxColumn.Name = "vendorLotFactDataGridViewTextBoxColumn";
            this.vendorLotFactDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorLotFactDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.vendorLotFactDataGridViewTextBoxColumn.Width = 80;
            // 
            // lotExpirationDateDataGridViewTextBoxColumn
            // 
            this.lotExpirationDateDataGridViewTextBoxColumn.DataPropertyName = "LotExpirationDate";
            this.lotExpirationDateDataGridViewTextBoxColumn.HeaderText = "Срок. годн.";
            this.lotExpirationDateDataGridViewTextBoxColumn.Name = "lotExpirationDateDataGridViewTextBoxColumn";
            this.lotExpirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotExpirationDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.lotExpirationDateDataGridViewTextBoxColumn.Width = 70;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "Ед. изм.";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.ReadOnly = true;
            this.unitOfMeasureDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 50;
            // 
            // manufacturerNameDataGridViewTextBoxColumn
            // 
            this.manufacturerNameDataGridViewTextBoxColumn.DataPropertyName = "ManufacturerName";
            this.manufacturerNameDataGridViewTextBoxColumn.HeaderText = "Наименование производителя";
            this.manufacturerNameDataGridViewTextBoxColumn.Name = "manufacturerNameDataGridViewTextBoxColumn";
            this.manufacturerNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerNameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.manufacturerNameDataGridViewTextBoxColumn.Width = 220;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена без НДС";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.priceDataGridViewTextBoxColumn.Width = 75;
            // 
            // sumWithoutVATDataGridViewTextBoxColumn
            // 
            this.sumWithoutVATDataGridViewTextBoxColumn.DataPropertyName = "SumWithoutVAT";
            this.sumWithoutVATDataGridViewTextBoxColumn.HeaderText = "Сумма без НДС";
            this.sumWithoutVATDataGridViewTextBoxColumn.Name = "sumWithoutVATDataGridViewTextBoxColumn";
            this.sumWithoutVATDataGridViewTextBoxColumn.ReadOnly = true;
            this.sumWithoutVATDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sumWithoutVATDataGridViewTextBoxColumn.Width = 75;
            // 
            // isVatDataGridViewCheckBoxColumn
            // 
            this.isVatDataGridViewCheckBoxColumn.DataPropertyName = "IsVat";
            this.isVatDataGridViewCheckBoxColumn.HeaderText = "IsVat";
            this.isVatDataGridViewCheckBoxColumn.Name = "isVatDataGridViewCheckBoxColumn";
            this.isVatDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isVatDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isCheckedDataGridViewCheckBoxColumn
            // 
            this.isCheckedDataGridViewCheckBoxColumn.DataPropertyName = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.HeaderText = "IsChecked";
            this.isCheckedDataGridViewCheckBoxColumn.Name = "isCheckedDataGridViewCheckBoxColumn";
            this.isCheckedDataGridViewCheckBoxColumn.Visible = false;
            // 
            // clmButton
            // 
            this.clmButton.HeaderText = "Док.";
            this.clmButton.Name = "clmButton";
            this.clmButton.Text = "Прикрепить документ";
            this.clmButton.ToolTipText = "Прикрепить документ";
            this.clmButton.Visible = false;
            this.clmButton.Width = 32;
            // 
            // LineID
            // 
            this.LineID.DataPropertyName = "LineID";
            this.LineID.HeaderText = "LineID";
            this.LineID.Name = "LineID";
            this.LineID.Visible = false;
            // 
            // colGuiltyEmployeesList
            // 
            this.colGuiltyEmployeesList.DataPropertyName = "GuiltyEmployeesList";
            this.colGuiltyEmployeesList.HeaderText = "Виновные сотрудники";
            this.colGuiltyEmployeesList.Name = "colGuiltyEmployeesList";
            this.colGuiltyEmployeesList.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colGuiltyEmployeesList.Width = 80;
            // 
            // CreateInnerComplaintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1130, 722);
            this.Controls.Add(this.grbRefuseSubtypeData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbInvoiceLines);
            this.Controls.Add(this.gbInvoiceHeader);
            this.Controls.Add(this.gbCommonParams);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(660, 500);
            this.Name = "CreateInnerComplaintForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание внутренней претензии";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.CreateInnerComplaintForm_Shown);
            this.gbCommonParams.ResumeLayout(false);
            this.gbCommonParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsCoGetAvailableDocsSubtypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableWarehousesBindingSource)).EndInit();
            this.gbInvoiceHeader.ResumeLayout(false);
            this.gbInvoiceHeader.PerformLayout();
            this.gbInvoiceLines.ResumeLayout(false);
            this.gbInvoiceLines.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchInnerDocsLinesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaintsExt)).EndInit();
            this.grbRefuseSubtypeData.ResumeLayout(false);
            this.grbRefuseSubtypeData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCommonParams;
        private System.Windows.Forms.ComboBox cbComplaintType;
        private System.Windows.Forms.Label lblComplaintType;
        private System.Windows.Forms.TextBox tbContactName;
        private System.Windows.Forms.Label lblContactName;
        private System.Windows.Forms.DateTimePicker dtpDateForecastSolution;
        private System.Windows.Forms.Label lblDateForecastSolution;
        private System.Windows.Forms.DateTimePicker dtpDateReceivedFromClient;
        private System.Windows.Forms.Label lblDateReceivedFromClient;
        private System.Windows.Forms.Button btnSearchInvoice;
        private System.Windows.Forms.TextBox tbDeliveryCode;
        private System.Windows.Forms.Label lblDeliveryCode;
        private System.Windows.Forms.TextBox tbDeliveryAddress;
        private System.Windows.Forms.Label lblDeliveryAddress;
        private System.Windows.Forms.TextBox tbDebtorName;
        private System.Windows.Forms.Label lblDebtorName;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.GroupBox gbInvoiceLines;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView dgvInvoiceLines;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.GroupBox gbInvoiceHeader;
        private System.Windows.Forms.ComboBox cbWarehouses;
        private System.Windows.Forms.Label lblWarehouse;
        private System.Windows.Forms.TextBox tbSourceAddressCode;
        private System.Windows.Forms.Label lblSourceAddressCode;
        private System.Windows.Forms.BindingSource availableWarehousesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableWarehousesTableAdapter availableWarehousesTableAdapter;
        private System.Windows.Forms.TextBox tbDestAddressCode;
        private System.Windows.Forms.Label lblDestAddressCode;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnSearchVendorLotFact;
        private System.Windows.Forms.TextBox tbFastSearch;
        private System.Windows.Forms.Button btnDoFactSearch;
        private System.Windows.Forms.Button btnCancelFastSearch;
        private System.Windows.Forms.Button btnShowComplaintsHistory;
        private System.Windows.Forms.Button btnExportToExcel;
        private System.Windows.Forms.Label lblLinkedComplaintInfo;
        private System.Windows.Forms.ComboBox cBPayConditions;
        private System.Windows.Forms.Label lblPayConditions;
        private System.Windows.Forms.Label lblSumVAT;
        private System.Windows.Forms.Label lblSumWithVAT;
        private System.Windows.Forms.Label lblSumWithVATCaption;
        private System.Windows.Forms.Label lblSumWithoutVAT;
        private System.Windows.Forms.Label lblSumVATCaption;
        private System.Windows.Forms.Label lblSumWithoutVATCaption;
        private System.Windows.Forms.ComboBox cmbSubtype;
        private System.Windows.Forms.Label lblSubtype;
        private System.Windows.Forms.BindingSource bsCoGetAvailableDocsSubtypes;
        private WMSOffice.Data.ComplaintsTableAdapters.CO_Get_Available_Docs_SubtypesTableAdapter taCoGetAvailableDocsSubtypes;
        private System.Windows.Forms.GroupBox grbRefuseSubtypeData;
        private System.Windows.Forms.Button btnAttachment;
        private System.Windows.Forms.TextBox tbxAttachment;
        private System.Windows.Forms.Label lblAttachment;
        private System.Windows.Forms.Button btnFaultEmployee;
        private System.Windows.Forms.TextBox tbxFaultEmployee;
        private System.Windows.Forms.Label lblFaultEmployee;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private WMSOffice.Window.DataGridViewDisableButtonColumn dataGridViewDisableButtonColumn1;
        private System.Windows.Forms.ToolTip tltFilePaths;
        private System.Windows.Forms.Button btnFiles;
        private System.Windows.Forms.TextBox tbInnerDocDate;
        private System.Windows.Forms.Label lblInnerDocDate;
        private System.Windows.Forms.TextBox tbInnerDocTypeAndNumber;
        private System.Windows.Forms.Label lblInnerDocTypeAndNumber;
        private WMSOffice.Data.ComplaintsExt complaintsExt;
        private System.Windows.Forms.BindingSource searchInnerDocsLinesBindingSource;
        private WMSOffice.Data.ComplaintsExtTableAdapters.SearchInnerDocsLinesTableAdapter searchInnerDocsLinesTableAdapter;
        private System.Windows.Forms.DataGridViewImageColumn clmAttachImage;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIsCold;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotExpirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sumWithoutVATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isVatDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isCheckedDataGridViewCheckBoxColumn;
        private WMSOffice.Window.DataGridViewDisableButtonColumn clmButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn LineID;
        private WMSOffice.Controls.DataGridButtonEditorColumn colGuiltyEmployeesList;
    }
}