namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintsHistoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintsHistoryForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbSearchParameters = new System.Windows.Forms.GroupBox();
            this.btnChooseForLink = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkbInvoice = new System.Windows.Forms.CheckBox();
            this.chkbAddressCode = new System.Windows.Forms.CheckBox();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.tbInvoiceType = new System.Windows.Forms.TextBox();
            this.tbAddressCode = new System.Windows.Forms.TextBox();
            this.gbDocsList = new System.Windows.Forms.GroupBox();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.currentDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.relatedInvoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedInvoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotFactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docRequestDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.currentDocsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter();
            this.docRequestDetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.First_Doc_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateReceivedFromClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_Address_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.gbSearchParameters.SuspendLayout();
            this.gbDocsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.gbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRequestDetailsBindingSource)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(557, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(647, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 419);
            this.pnlButtons.Size = new System.Drawing.Size(734, 43);
            // 
            // gbSearchParameters
            // 
            this.gbSearchParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchParameters.Controls.Add(this.btnChooseForLink);
            this.gbSearchParameters.Controls.Add(this.btnSearch);
            this.gbSearchParameters.Controls.Add(this.chkbInvoice);
            this.gbSearchParameters.Controls.Add(this.chkbAddressCode);
            this.gbSearchParameters.Controls.Add(this.tbInvoiceNumber);
            this.gbSearchParameters.Controls.Add(this.tbInvoiceType);
            this.gbSearchParameters.Controls.Add(this.tbAddressCode);
            this.gbSearchParameters.Location = new System.Drawing.Point(12, 12);
            this.gbSearchParameters.Name = "gbSearchParameters";
            this.gbSearchParameters.Size = new System.Drawing.Size(710, 69);
            this.gbSearchParameters.TabIndex = 101;
            this.gbSearchParameters.TabStop = false;
            this.gbSearchParameters.Text = "Параметры поиска в истории:";
            // 
            // btnChooseForLink
            // 
            this.btnChooseForLink.Enabled = false;
            this.btnChooseForLink.Image = ((System.Drawing.Image)(resources.GetObject("btnChooseForLink.Image")));
            this.btnChooseForLink.Location = new System.Drawing.Point(457, 19);
            this.btnChooseForLink.Name = "btnChooseForLink";
            this.btnChooseForLink.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnChooseForLink.Size = new System.Drawing.Size(100, 41);
            this.btnChooseForLink.TabIndex = 108;
            this.btnChooseForLink.Text = "Выбрать для связи";
            this.btnChooseForLink.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnChooseForLink.UseVisualStyleBackColor = true;
            this.btnChooseForLink.Click += new System.EventHandler(this.btnChooseForLink_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(351, 19);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSearch.Size = new System.Drawing.Size(100, 41);
            this.btnSearch.TabIndex = 107;
            this.btnSearch.Text = "Поиск по претензиям";
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chkbInvoice
            // 
            this.chkbInvoice.AutoSize = true;
            this.chkbInvoice.Location = new System.Drawing.Point(16, 43);
            this.chkbInvoice.Name = "chkbInvoice";
            this.chkbInvoice.Size = new System.Drawing.Size(152, 17);
            this.chkbInvoice.TabIndex = 106;
            this.chkbInvoice.Text = "Накладная (тип - номер):";
            this.chkbInvoice.UseVisualStyleBackColor = true;
            this.chkbInvoice.CheckedChanged += new System.EventHandler(this.chkbAddressCode_CheckedChanged);
            // 
            // chkbAddressCode
            // 
            this.chkbAddressCode.AutoSize = true;
            this.chkbAddressCode.Location = new System.Drawing.Point(16, 19);
            this.chkbAddressCode.Name = "chkbAddressCode";
            this.chkbAddressCode.Size = new System.Drawing.Size(137, 17);
            this.chkbAddressCode.TabIndex = 105;
            this.chkbAddressCode.Text = "Код адреса доставки:";
            this.chkbAddressCode.UseVisualStyleBackColor = true;
            this.chkbAddressCode.CheckedChanged += new System.EventHandler(this.chkbAddressCode_CheckedChanged);
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.Enabled = false;
            this.tbInvoiceNumber.Location = new System.Drawing.Point(218, 40);
            this.tbInvoiceNumber.MaxLength = 10;
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(110, 20);
            this.tbInvoiceNumber.TabIndex = 104;
            this.tbInvoiceNumber.Text = "0";
            // 
            // tbInvoiceType
            // 
            this.tbInvoiceType.Enabled = false;
            this.tbInvoiceType.Location = new System.Drawing.Point(174, 40);
            this.tbInvoiceType.MaxLength = 2;
            this.tbInvoiceType.Name = "tbInvoiceType";
            this.tbInvoiceType.Size = new System.Drawing.Size(38, 20);
            this.tbInvoiceType.TabIndex = 103;
            // 
            // tbAddressCode
            // 
            this.tbAddressCode.Enabled = false;
            this.tbAddressCode.Location = new System.Drawing.Point(174, 17);
            this.tbAddressCode.MaxLength = 6;
            this.tbAddressCode.Name = "tbAddressCode";
            this.tbAddressCode.Size = new System.Drawing.Size(72, 20);
            this.tbAddressCode.TabIndex = 1;
            this.tbAddressCode.Text = "0";
            // 
            // gbDocsList
            // 
            this.gbDocsList.Controls.Add(this.dgvDocs);
            this.gbDocsList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocsList.Location = new System.Drawing.Point(0, 0);
            this.gbDocsList.Name = "gbDocsList";
            this.gbDocsList.Size = new System.Drawing.Size(710, 189);
            this.gbDocsList.TabIndex = 102;
            this.gbDocsList.TabStop = false;
            this.gbDocsList.Text = "Претензии, созданные ранее:";
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToOrderColumns = true;
            this.dgvDocs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvDocs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.First_Doc_ID,
            this.docTypeDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.dateReceivedFromClientDataGridViewTextBoxColumn,
            this.Source_Address_Code,
            this.Column1,
            this.Source_Address,
            this.contactNameDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn});
            this.dgvDocs.DataSource = this.currentDocsBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDocs.Location = new System.Drawing.Point(3, 16);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.RowTemplate.Height = 21;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.ShowEditingIcon = false;
            this.dgvDocs.Size = new System.Drawing.Size(704, 170);
            this.dgvDocs.TabIndex = 6;
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // currentDocsBindingSource
            // 
            this.currentDocsBindingSource.DataMember = "CurrentDocs";
            this.currentDocsBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbDetails
            // 
            this.gbDetails.Controls.Add(this.dgvDetails);
            this.gbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDetails.Location = new System.Drawing.Point(0, 0);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(710, 132);
            this.gbDetails.TabIndex = 103;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Состав выбранной претензии:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relatedInvoiceTypeDataGridViewTextBoxColumn,
            this.relatedInvoiceNumberDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.vendorLotFactDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.docRequestDetailsBindingSource;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.Height = 21;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.ShowEditingIcon = false;
            this.dgvDetails.Size = new System.Drawing.Size(704, 113);
            this.dgvDetails.TabIndex = 7;
            // 
            // relatedInvoiceTypeDataGridViewTextBoxColumn
            // 
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "Related_Invoice_Type";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.Name = "relatedInvoiceTypeDataGridViewTextBoxColumn";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.Width = 40;
            // 
            // relatedInvoiceNumberDataGridViewTextBoxColumn
            // 
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "Related_Invoice_Number";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.HeaderText = "№ накл.";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.Name = "relatedInvoiceNumberDataGridViewTextBoxColumn";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.Width = 80;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Серия док.";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            // 
            // vendorLotFactDataGridViewTextBoxColumn
            // 
            this.vendorLotFactDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot_Fact";
            this.vendorLotFactDataGridViewTextBoxColumn.HeaderText = "Серия факт.";
            this.vendorLotFactDataGridViewTextBoxColumn.Name = "vendorLotFactDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 75;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.Width = 120;
            // 
            // docRequestDetailsBindingSource
            // 
            this.docRequestDetailsBindingSource.DataMember = "DocRequestDetails";
            this.docRequestDetailsBindingSource.DataSource = this.complaints;
            // 
            // currentDocsTableAdapter
            // 
            this.currentDocsTableAdapter.ClearBeforeFill = true;
            // 
            // docRequestDetailsTableAdapter
            // 
            this.docRequestDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(12, 87);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbDocsList);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gbDetails);
            this.splitContainer.Size = new System.Drawing.Size(710, 326);
            this.splitContainer.SplitterDistance = 189;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 104;
            // 
            // First_Doc_ID
            // 
            this.First_Doc_ID.DataPropertyName = "First_Doc_ID";
            this.First_Doc_ID.HeaderText = "Код";
            this.First_Doc_ID.Name = "First_Doc_ID";
            this.First_Doc_ID.ReadOnly = true;
            this.First_Doc_ID.Width = 60;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.Width = 45;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Назв. типа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.Width = 55;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Название статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // dateReceivedFromClientDataGridViewTextBoxColumn
            // 
            this.dateReceivedFromClientDataGridViewTextBoxColumn.DataPropertyName = "Date_ReceivedFromClient";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.HeaderText = "Дата";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.Name = "dateReceivedFromClientDataGridViewTextBoxColumn";
            // 
            // Source_Address_Code
            // 
            this.Source_Address_Code.DataPropertyName = "Source_Address_Code";
            this.Source_Address_Code.HeaderText = "Адр.дост.";
            this.Source_Address_Code.Name = "Source_Address_Code";
            this.Source_Address_Code.Width = 65;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Source_Address_Name";
            this.Column1.HeaderText = "Дебитор";
            this.Column1.Name = "Column1";
            this.Column1.Width = 160;
            // 
            // Source_Address
            // 
            this.Source_Address.DataPropertyName = "Source_Address";
            this.Source_Address.HeaderText = "Адрес";
            this.Source_Address.Name = "Source_Address";
            this.Source_Address.ReadOnly = true;
            this.Source_Address.Width = 160;
            // 
            // contactNameDataGridViewTextBoxColumn
            // 
            this.contactNameDataGridViewTextBoxColumn.DataPropertyName = "Contact_Name";
            this.contactNameDataGridViewTextBoxColumn.HeaderText = "Контактн.инф.";
            this.contactNameDataGridViewTextBoxColumn.Name = "contactNameDataGridViewTextBoxColumn";
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.Width = 160;
            // 
            // ComplaintsHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 462);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.gbSearchParameters);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "ComplaintsHistoryForm";
            this.Text = "История претензий";
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.gbSearchParameters, 0);
            this.Controls.SetChildIndex(this.splitContainer, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbSearchParameters.ResumeLayout(false);
            this.gbSearchParameters.PerformLayout();
            this.gbDocsList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.gbDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRequestDetailsBindingSource)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchParameters;
        private System.Windows.Forms.GroupBox gbDocsList;
        private System.Windows.Forms.CheckBox chkbAddressCode;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceType;
        private System.Windows.Forms.TextBox tbAddressCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chkbInvoice;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.DataGridView dgvDetails;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource currentDocsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter currentDocsTableAdapter;
        private System.Windows.Forms.Button btnChooseForLink;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.BindingSource docRequestDetailsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter docRequestDetailsTableAdapter;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedInvoiceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedInvoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn First_Doc_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReceivedFromClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source_Address_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source_Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
    }
}