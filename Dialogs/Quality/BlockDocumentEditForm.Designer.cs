namespace WMSOffice.Dialogs.Quality
{
    partial class BlockDocumentEditForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblOuterDocNumber = new System.Windows.Forms.Label();
            this.tbxOuterDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocSource = new System.Windows.Forms.Label();
            this.cmbDocSource = new System.Windows.Forms.ComboBox();
            this.bsBlGetDocSources = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblOrganization = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.dtpOuterDocDate = new System.Windows.Forms.DateTimePicker();
            this.lblDescription = new System.Windows.Forms.Label();
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.lblItems = new System.Windows.Forms.Label();
            this.cmbOrganizations = new System.Windows.Forms.ComboBox();
            this.bsBlGetDocOrganisations = new System.Windows.Forms.BindingSource(this.components);
            this.cmsDgvItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miImportFromExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvItems = new System.Windows.Forms.DataGridView();
            this.bsblBlockDocumentItems = new System.Windows.Forms.BindingSource(this.components);
            this.taBlGetDocSources = new WMSOffice.Data.QualityTableAdapters.BL_Get_Doc_SourcesTableAdapter();
            this.taBlGetDocOrganisations = new WMSOffice.Data.QualityTableAdapters.BL_Get_Doc_OrganisationsTableAdapter();
            this.dtpMsgDate = new System.Windows.Forms.DateTimePicker();
            this.lblMsgDate = new System.Windows.Forms.Label();
            this.tbxMsgNumber = new System.Windows.Forms.TextBox();
            this.lblMsgNumber = new System.Windows.Forms.Label();
            this.pnlItems = new System.Windows.Forms.Panel();
            this.tsItems = new System.Windows.Forms.ToolStrip();
            this.sbFindPurchaseOrderItems = new System.Windows.Forms.ToolStripButton();
            this.clItemID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clManufacturerID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clVendorLot = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clExpirationDate = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clBatchID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clWarehouseID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clHoldTypeID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clHoldTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateFrom = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.clDateTo = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.clDocID = new WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn();
            this.clIsNewVendorLot = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clIsNewItem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocSources)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocOrganisations)).BeginInit();
            this.cmsDgvItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsblBlockDocumentItems)).BeginInit();
            this.pnlItems.SuspendLayout();
            this.tsItems.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(983, 503);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 80;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(902, 503);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 70;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblOuterDocNumber
            // 
            this.lblOuterDocNumber.AutoSize = true;
            this.lblOuterDocNumber.Location = new System.Drawing.Point(12, 12);
            this.lblOuterDocNumber.Name = "lblOuterDocNumber";
            this.lblOuterDocNumber.Size = new System.Drawing.Size(133, 13);
            this.lblOuterDocNumber.TabIndex = 4;
            this.lblOuterDocNumber.Text = "№ внешнего документа: ";
            // 
            // tbxOuterDocNumber
            // 
            this.tbxOuterDocNumber.Location = new System.Drawing.Point(151, 9);
            this.tbxOuterDocNumber.Name = "tbxOuterDocNumber";
            this.tbxOuterDocNumber.Size = new System.Drawing.Size(140, 20);
            this.tbxOuterDocNumber.TabIndex = 10;
            // 
            // lblDocSource
            // 
            this.lblDocSource.AutoSize = true;
            this.lblDocSource.Location = new System.Drawing.Point(12, 86);
            this.lblDocSource.Name = "lblDocSource";
            this.lblDocSource.Size = new System.Drawing.Size(61, 13);
            this.lblDocSource.TabIndex = 6;
            this.lblDocSource.Text = "Источник: ";
            // 
            // cmbDocSource
            // 
            this.cmbDocSource.DataSource = this.bsBlGetDocSources;
            this.cmbDocSource.DisplayMember = "source_name";
            this.cmbDocSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocSource.FormattingEnabled = true;
            this.cmbDocSource.Location = new System.Drawing.Point(98, 83);
            this.cmbDocSource.Name = "cmbDocSource";
            this.cmbDocSource.Size = new System.Drawing.Size(193, 21);
            this.cmbDocSource.TabIndex = 30;
            this.cmbDocSource.ValueMember = "source_id";
            this.cmbDocSource.SelectedValueChanged += new System.EventHandler(this.cmbDocSource_SelectedValueChanged);
            // 
            // bsBlGetDocSources
            // 
            this.bsBlGetDocSources.DataMember = "BL_Get_Doc_Sources";
            this.bsBlGetDocSources.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblOrganization
            // 
            this.lblOrganization.AutoSize = true;
            this.lblOrganization.Location = new System.Drawing.Point(390, 83);
            this.lblOrganization.Name = "lblOrganization";
            this.lblOrganization.Size = new System.Drawing.Size(80, 13);
            this.lblOrganization.TabIndex = 8;
            this.lblOrganization.Text = "Организация: ";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(377, 12);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(93, 13);
            this.lblDateFrom.TabIndex = 10;
            this.lblDateFrom.Text = "Дата документа:";
            // 
            // dtpOuterDocDate
            // 
            this.dtpOuterDocDate.Location = new System.Drawing.Point(488, 9);
            this.dtpOuterDocDate.Name = "dtpOuterDocDate";
            this.dtpOuterDocDate.Size = new System.Drawing.Size(127, 20);
            this.dtpOuterDocDate.TabIndex = 20;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(12, 128);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(73, 13);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "Примечание:";
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(98, 125);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(791, 70);
            this.tbxDescription.TabIndex = 50;
            // 
            // lblItems
            // 
            this.lblItems.AutoSize = true;
            this.lblItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItems.Location = new System.Drawing.Point(12, 213);
            this.lblItems.Name = "lblItems";
            this.lblItems.Size = new System.Drawing.Size(214, 13);
            this.lblItems.TabIndex = 17;
            this.lblItems.Text = "Товары, добавленные в документ:";
            // 
            // cmbOrganizations
            // 
            this.cmbOrganizations.DataSource = this.bsBlGetDocOrganisations;
            this.cmbOrganizations.DisplayMember = "organisation_name";
            this.cmbOrganizations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganizations.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cmbOrganizations.FormattingEnabled = true;
            this.cmbOrganizations.Location = new System.Drawing.Point(476, 80);
            this.cmbOrganizations.Name = "cmbOrganizations";
            this.cmbOrganizations.Size = new System.Drawing.Size(413, 21);
            this.cmbOrganizations.TabIndex = 40;
            this.cmbOrganizations.ValueMember = "organisation_id";
            // 
            // bsBlGetDocOrganisations
            // 
            this.bsBlGetDocOrganisations.DataMember = "BL_Get_Doc_Organisations";
            this.bsBlGetDocOrganisations.DataSource = this.quality;
            // 
            // cmsDgvItems
            // 
            this.cmsDgvItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miImportFromExcel});
            this.cmsDgvItems.Name = "cmsDgvItems";
            this.cmsDgvItems.Size = new System.Drawing.Size(164, 26);
            // 
            // miImportFromExcel
            // 
            this.miImportFromExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.miImportFromExcel.Name = "miImportFromExcel";
            this.miImportFromExcel.Size = new System.Drawing.Size(163, 22);
            this.miImportFromExcel.Text = "Вставить из Excel";
            this.miImportFromExcel.Click += new System.EventHandler(this.miImportFromExcel_Click);
            // 
            // dgvItems
            // 
            this.dgvItems.AllowUserToOrderColumns = true;
            this.dgvItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvItems.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clItemID,
            this.clItemName,
            this.clManufacturerID,
            this.clManufacturer,
            this.clVendor,
            this.clVendorLot,
            this.clExpirationDate,
            this.clBatchID,
            this.clWarehouseID,
            this.clHoldTypeID,
            this.clHoldTypeName,
            this.clDateFrom,
            this.clDateTo,
            this.clDocID,
            this.clIsNewVendorLot,
            this.clIsNewItem,
            this.clResult});
            this.dgvItems.ContextMenuStrip = this.cmsDgvItems;
            this.dgvItems.DataSource = this.bsblBlockDocumentItems;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvItems.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvItems.Location = new System.Drawing.Point(0, 28);
            this.dgvItems.Name = "dgvItems";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItems.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItems.Size = new System.Drawing.Size(1043, 237);
            this.dgvItems.TabIndex = 60;
            this.dgvItems.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvItems_CellValidated);
            this.dgvItems.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvItems_CellValidating);
            this.dgvItems.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvItems_EditingControlShowing);
            this.dgvItems.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvItems_DataError);
            // 
            // bsblBlockDocumentItems
            // 
            this.bsblBlockDocumentItems.DataMember = "BL_Block_Document_Items";
            this.bsblBlockDocumentItems.DataSource = this.quality;
            // 
            // taBlGetDocSources
            // 
            this.taBlGetDocSources.ClearBeforeFill = true;
            // 
            // taBlGetDocOrganisations
            // 
            this.taBlGetDocOrganisations.ClearBeforeFill = true;
            // 
            // dtpMsgDate
            // 
            this.dtpMsgDate.Location = new System.Drawing.Point(489, 46);
            this.dtpMsgDate.Name = "dtpMsgDate";
            this.dtpMsgDate.Size = new System.Drawing.Size(127, 20);
            this.dtpMsgDate.TabIndex = 84;
            // 
            // lblMsgDate
            // 
            this.lblMsgDate.AutoSize = true;
            this.lblMsgDate.Location = new System.Drawing.Point(377, 49);
            this.lblMsgDate.Name = "lblMsgDate";
            this.lblMsgDate.Size = new System.Drawing.Size(106, 13);
            this.lblMsgDate.TabIndex = 83;
            this.lblMsgDate.Text = "Дата уведомления:";
            // 
            // tbxMsgNumber
            // 
            this.tbxMsgNumber.Location = new System.Drawing.Point(151, 46);
            this.tbxMsgNumber.Name = "tbxMsgNumber";
            this.tbxMsgNumber.Size = new System.Drawing.Size(140, 20);
            this.tbxMsgNumber.TabIndex = 82;
            // 
            // lblMsgNumber
            // 
            this.lblMsgNumber.AutoSize = true;
            this.lblMsgNumber.Location = new System.Drawing.Point(12, 49);
            this.lblMsgNumber.Name = "lblMsgNumber";
            this.lblMsgNumber.Size = new System.Drawing.Size(94, 13);
            this.lblMsgNumber.TabIndex = 81;
            this.lblMsgNumber.Text = "№ уведомления: ";
            // 
            // pnlItems
            // 
            this.pnlItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlItems.Controls.Add(this.tsItems);
            this.pnlItems.Controls.Add(this.dgvItems);
            this.pnlItems.Location = new System.Drawing.Point(15, 232);
            this.pnlItems.Name = "pnlItems";
            this.pnlItems.Size = new System.Drawing.Size(1043, 265);
            this.pnlItems.TabIndex = 86;
            // 
            // tsItems
            // 
            this.tsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbFindPurchaseOrderItems});
            this.tsItems.Location = new System.Drawing.Point(0, 0);
            this.tsItems.Name = "tsItems";
            this.tsItems.Size = new System.Drawing.Size(1043, 25);
            this.tsItems.TabIndex = 0;
            this.tsItems.Text = "toolStrip1";
            // 
            // sbFindPurchaseOrderItems
            // 
            this.sbFindPurchaseOrderItems.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sbFindPurchaseOrderItems.Image = global::WMSOffice.Properties.Resources.Search1;
            this.sbFindPurchaseOrderItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbFindPurchaseOrderItems.Name = "sbFindPurchaseOrderItems";
            this.sbFindPurchaseOrderItems.Size = new System.Drawing.Size(216, 22);
            this.sbFindPurchaseOrderItems.Text = "Поиск товаров в заказе на закупку";
            this.sbFindPurchaseOrderItems.Click += new System.EventHandler(this.sbFindPurchaseOrderItems_Click);
            // 
            // clItemID
            // 
            this.clItemID.DataPropertyName = "Item_ID";
            this.clItemID.HeaderText = "Код товара";
            this.clItemID.Name = "clItemID";
            this.clItemID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clItemID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clItemID.Width = 70;
            // 
            // clItemName
            // 
            this.clItemName.DataPropertyName = "Item_Name";
            this.clItemName.HeaderText = "Наименование товара";
            this.clItemName.Name = "clItemName";
            this.clItemName.Width = 120;
            // 
            // clManufacturerID
            // 
            this.clManufacturerID.DataPropertyName = "Manufacturer_ID";
            this.clManufacturerID.HeaderText = "Код произв.";
            this.clManufacturerID.Name = "clManufacturerID";
            this.clManufacturerID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clManufacturerID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clManufacturerID.Width = 70;
            // 
            // clManufacturer
            // 
            this.clManufacturer.DataPropertyName = "Manufacturer";
            this.clManufacturer.HeaderText = "Производитель";
            this.clManufacturer.Name = "clManufacturer";
            this.clManufacturer.Width = 120;
            // 
            // clVendor
            // 
            this.clVendor.DataPropertyName = "Vendor";
            this.clVendor.HeaderText = "Поставщик";
            this.clVendor.Name = "clVendor";
            this.clVendor.ReadOnly = true;
            this.clVendor.Width = 120;
            // 
            // clVendorLot
            // 
            this.clVendorLot.DataPropertyName = "VendorLot";
            this.clVendorLot.HeaderText = "Серия";
            this.clVendorLot.Name = "clVendorLot";
            this.clVendorLot.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clVendorLot.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clVendorLot.Width = 80;
            // 
            // clExpirationDate
            // 
            this.clExpirationDate.DataPropertyName = "Expiration_Date";
            this.clExpirationDate.HeaderText = "Срок годности";
            this.clExpirationDate.Name = "clExpirationDate";
            this.clExpirationDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clExpirationDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clBatchID
            // 
            this.clBatchID.DataPropertyName = "BatchID";
            this.clBatchID.HeaderText = "Партия";
            this.clBatchID.Name = "clBatchID";
            this.clBatchID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clBatchID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clBatchID.Width = 70;
            // 
            // clWarehouseID
            // 
            this.clWarehouseID.DataPropertyName = "Warehouse_ID";
            this.clWarehouseID.HeaderText = "Склад";
            this.clWarehouseID.Name = "clWarehouseID";
            this.clWarehouseID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clWarehouseID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clHoldTypeID
            // 
            this.clHoldTypeID.DataPropertyName = "HoldTypeID";
            this.clHoldTypeID.HeaderText = "Код бл.";
            this.clHoldTypeID.Name = "clHoldTypeID";
            this.clHoldTypeID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clHoldTypeID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clHoldTypeID.Width = 50;
            // 
            // clHoldTypeName
            // 
            this.clHoldTypeName.DataPropertyName = "HoldTypeName";
            this.clHoldTypeName.HeaderText = "Блокировка";
            this.clHoldTypeName.Name = "clHoldTypeName";
            this.clHoldTypeName.ReadOnly = true;
            this.clHoldTypeName.Width = 90;
            // 
            // clDateFrom
            // 
            this.clDateFrom.DataPropertyName = "DateFrom";
            this.clDateFrom.HeaderText = "Дата с";
            this.clDateFrom.Name = "clDateFrom";
            this.clDateFrom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDateFrom.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clDateFrom.Width = 80;
            // 
            // clDateTo
            // 
            this.clDateTo.DataPropertyName = "DateTo";
            this.clDateTo.HeaderText = "Дата по";
            this.clDateTo.Name = "clDateTo";
            this.clDateTo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clDateTo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.clDateTo.Width = 80;
            // 
            // clDocID
            // 
            this.clDocID.DataPropertyName = "Doc_ID";
            this.clDocID.HeaderText = "Документ блокировки";
            this.clDocID.Name = "clDocID";
            this.clDocID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.clDocID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // clIsNewVendorLot
            // 
            this.clIsNewVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clIsNewVendorLot.DataPropertyName = "IsNewVendorLot";
            this.clIsNewVendorLot.HeaderText = "Новая серия";
            this.clIsNewVendorLot.Name = "clIsNewVendorLot";
            this.clIsNewVendorLot.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clIsNewVendorLot.Width = 80;
            // 
            // clIsNewItem
            // 
            this.clIsNewItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clIsNewItem.DataPropertyName = "IsNewItem";
            this.clIsNewItem.HeaderText = "Новый товар";
            this.clIsNewItem.Name = "clIsNewItem";
            this.clIsNewItem.Width = 80;
            // 
            // clResult
            // 
            this.clResult.DataPropertyName = "Result";
            this.clResult.HeaderText = "Проверка";
            this.clResult.Name = "clResult";
            this.clResult.ReadOnly = true;
            this.clResult.Width = 300;
            // 
            // BlockDocumentEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 538);
            this.Controls.Add(this.pnlItems);
            this.Controls.Add(this.dtpMsgDate);
            this.Controls.Add(this.lblMsgDate);
            this.Controls.Add(this.tbxMsgNumber);
            this.Controls.Add(this.lblMsgNumber);
            this.Controls.Add(this.lblItems);
            this.Controls.Add(this.cmbOrganizations);
            this.Controls.Add(this.tbxDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblOrganization);
            this.Controls.Add(this.dtpOuterDocDate);
            this.Controls.Add(this.cmbDocSource);
            this.Controls.Add(this.lblDateFrom);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblDocSource);
            this.Controls.Add(this.tbxOuterDocNumber);
            this.Controls.Add(this.lblOuterDocNumber);
            this.Controls.Add(this.btnCancel);
            this.KeyPreview = true;
            this.Name = "BlockDocumentEditForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Создание документа блокировки";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BlockDocumentEditForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BlockDocumentEditForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BlockDocumentEditForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocSources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocOrganisations)).EndInit();
            this.cmsDgvItems.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsblBlockDocumentItems)).EndInit();
            this.pnlItems.ResumeLayout(false);
            this.pnlItems.PerformLayout();
            this.tsItems.ResumeLayout(false);
            this.tsItems.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblOuterDocNumber;
        private System.Windows.Forms.TextBox tbxOuterDocNumber;
        private System.Windows.Forms.Label lblDocSource;
        private System.Windows.Forms.ComboBox cmbDocSource;
        private System.Windows.Forms.BindingSource bsBlGetDocSources;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.BL_Get_Doc_SourcesTableAdapter taBlGetDocSources;
        private System.Windows.Forms.Label lblOrganization;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpOuterDocDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.DataGridView dgvItems;
        private System.Windows.Forms.Label lblItems;
        private System.Windows.Forms.BindingSource bsblBlockDocumentItems;
        private System.Windows.Forms.ComboBox cmbOrganizations;
        private System.Windows.Forms.BindingSource bsBlGetDocOrganisations;
        private WMSOffice.Data.QualityTableAdapters.BL_Get_Doc_OrganisationsTableAdapter taBlGetDocOrganisations;
        private System.Windows.Forms.ContextMenuStrip cmsDgvItems;
        private System.Windows.Forms.ToolStripMenuItem miImportFromExcel;
        private System.Windows.Forms.DateTimePicker dtpMsgDate;
        private System.Windows.Forms.Label lblMsgDate;
        private System.Windows.Forms.TextBox tbxMsgNumber;
        private System.Windows.Forms.Label lblMsgNumber;
        private System.Windows.Forms.Panel pnlItems;
        private System.Windows.Forms.ToolStrip tsItems;
        private System.Windows.Forms.ToolStripButton sbFindPurchaseOrderItems;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clItemName;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clManufacturerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clVendor;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clVendorLot;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clExpirationDate;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clBatchID;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clWarehouseID;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clHoldTypeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHoldTypeName;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn clDateFrom;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn clDateTo;
        private WMSOffice.Dialogs.WH.DataGridViewEllipsisEditColumn clDocID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsNewVendorLot;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clIsNewItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResult;
    }
}