namespace WMSOffice.Dialogs.Complaints
{
    partial class ComplaintMergeExtForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComplaintMergeExtForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvComplaints = new System.Windows.Forms.DataGridView();
            this.currentDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.gbDocRequestDetails = new System.Windows.Forms.GroupBox();
            this.dgvDocRequestDetails = new System.Windows.Forms.DataGridView();
            this.docRequestDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.currentDocsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter();
            this.docRequestDetailsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter();
            this.clmLinked = new System.Windows.Forms.DataGridViewImageColumn();
            this.coldColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcComplaintProcessingDataError = new System.Windows.Forms.DataGridViewImageColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Linked_Doc_ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttachedFiles = new System.Windows.Forms.DataGridViewImageColumn();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Source_Address_Base_Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoicesListDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientLetterSentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.warehouseNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateReceivedFromClientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateForecastSolutionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usersUpdatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PayCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmLinkedDetail = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvcColdSignImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.detailIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedCompanyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedOrderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedOrderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedInvoiceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineStageDataGridViewImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.stageResultDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorLotFactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitOfMeasureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tax = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.relatedInvoiceNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.gbDocRequestDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocRequestDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRequestDetailsBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.68421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.31579F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 475);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvComplaints);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbDocRequestDetails);
            this.splitContainer1.Size = new System.Drawing.Size(852, 439);
            this.splitContainer1.SplitterDistance = 284;
            this.splitContainer1.TabIndex = 0;
            // 
            // dgvComplaints
            // 
            this.dgvComplaints.AllowUserToAddRows = false;
            this.dgvComplaints.AllowUserToDeleteRows = false;
            this.dgvComplaints.AllowUserToOrderColumns = true;
            this.dgvComplaints.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvComplaints.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvComplaints.AutoGenerateColumns = false;
            this.dgvComplaints.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaints.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvComplaints.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComplaints.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLinked,
            this.coldColumn,
            this.dgvcComplaintProcessingDataError,
            this.docIDDataGridViewTextBoxColumn,
            this.Linked_Doc_ID,
            this.docTypeDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.colAttachedFiles,
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.usersCreatedDataGridViewTextBoxColumn,
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn,
            this.sourceAddressCodeDataGridViewTextBoxColumn,
            this.INN,
            this.Source_Address_Base_Code,
            this.sourceAddressNameDataGridViewTextBoxColumn,
            this.sourceAddressDataGridViewTextBoxColumn,
            this.ordersListDataGridViewTextBoxColumn,
            this.invoicesListDataGridViewTextBoxColumn,
            this.contactNameDataGridViewTextBoxColumn,
            this.clientLetterSentDataGridViewTextBoxColumn,
            this.warehouseNameDataGridViewTextBoxColumn,
            this.dateReceivedFromClientDataGridViewTextBoxColumn,
            this.dateForecastSolutionDataGridViewTextBoxColumn,
            this.dateUpdatedDataGridViewTextBoxColumn,
            this.usersUpdatedDataGridViewTextBoxColumn,
            this.PayCondition});
            this.dgvComplaints.DataSource = this.currentDocsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvComplaints.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvComplaints.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComplaints.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvComplaints.Location = new System.Drawing.Point(0, 0);
            this.dgvComplaints.MultiSelect = false;
            this.dgvComplaints.Name = "dgvComplaints";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvComplaints.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvComplaints.RowHeadersVisible = false;
            this.dgvComplaints.RowTemplate.Height = 21;
            this.dgvComplaints.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComplaints.ShowEditingIcon = false;
            this.dgvComplaints.Size = new System.Drawing.Size(852, 284);
            this.dgvComplaints.TabIndex = 6;
            this.dgvComplaints.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvComplaints_DataBindingComplete);
            this.dgvComplaints.SelectionChanged += new System.EventHandler(this.dgvComplaints_SelectionChanged);
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
            // gbDocRequestDetails
            // 
            this.gbDocRequestDetails.Controls.Add(this.dgvDocRequestDetails);
            this.gbDocRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDocRequestDetails.Location = new System.Drawing.Point(0, 0);
            this.gbDocRequestDetails.Name = "gbDocRequestDetails";
            this.gbDocRequestDetails.Size = new System.Drawing.Size(852, 151);
            this.gbDocRequestDetails.TabIndex = 1;
            this.gbDocRequestDetails.TabStop = false;
            this.gbDocRequestDetails.Text = "Состав претензии";
            // 
            // dgvDocRequestDetails
            // 
            this.dgvDocRequestDetails.AllowUserToAddRows = false;
            this.dgvDocRequestDetails.AllowUserToDeleteRows = false;
            this.dgvDocRequestDetails.AllowUserToOrderColumns = true;
            this.dgvDocRequestDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvDocRequestDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvDocRequestDetails.AutoGenerateColumns = false;
            this.dgvDocRequestDetails.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocRequestDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvDocRequestDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocRequestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmLinkedDetail,
            this.dgvcColdSignImage,
            this.detailIDDataGridViewTextBoxColumn,
            this.docIDDataGridViewTextBoxColumn1,
            this.relatedCompanyDataGridViewTextBoxColumn,
            this.relatedOrderTypeDataGridViewTextBoxColumn,
            this.relatedOrderNumberDataGridViewTextBoxColumn,
            this.relatedInvoiceTypeDataGridViewTextBoxColumn,
            this.lineStageDataGridViewImageColumn,
            this.stageResultDataGridViewTextBoxColumn,
            this.lineIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorLotDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.vendorLotFactDataGridViewTextBoxColumn,
            this.unitOfMeasureDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.resultQuantityDataGridViewTextBoxColumn,
            this.Price,
            this.Tax,
            this.relatedInvoiceNumberDataGridViewTextBoxColumn,
            this.InvoiceDate});
            this.dgvDocRequestDetails.DataSource = this.docRequestDetailsBindingSource;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocRequestDetails.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDocRequestDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocRequestDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDocRequestDetails.Location = new System.Drawing.Point(3, 16);
            this.dgvDocRequestDetails.MultiSelect = false;
            this.dgvDocRequestDetails.Name = "dgvDocRequestDetails";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocRequestDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dgvDocRequestDetails.RowHeadersVisible = false;
            this.dgvDocRequestDetails.RowTemplate.Height = 21;
            this.dgvDocRequestDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocRequestDetails.ShowCellErrors = false;
            this.dgvDocRequestDetails.ShowEditingIcon = false;
            this.dgvDocRequestDetails.ShowRowErrors = false;
            this.dgvDocRequestDetails.Size = new System.Drawing.Size(846, 132);
            this.dgvDocRequestDetails.TabIndex = 8;
            this.dgvDocRequestDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocRequestDetails_DataBindingComplete);
            // 
            // docRequestDetailsBindingSource
            // 
            this.docRequestDetailsBindingSource.DataMember = "DocRequestDetails";
            this.docRequestDetailsBindingSource.DataSource = this.complaints;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 448);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(852, 24);
            this.panel1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(658, 1);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(95, 23);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "Связать";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(755, 1);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(95, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // currentDocsTableAdapter
            // 
            this.currentDocsTableAdapter.ClearBeforeFill = true;
            // 
            // docRequestDetailsTableAdapter
            // 
            this.docRequestDetailsTableAdapter.ClearBeforeFill = true;
            // 
            // clmLinked
            // 
            this.clmLinked.HeaderText = "";
            this.clmLinked.Name = "clmLinked";
            this.clmLinked.Visible = false;
            this.clmLinked.Width = 23;
            // 
            // coldColumn
            // 
            this.coldColumn.HeaderText = "Холод";
            this.coldColumn.Name = "coldColumn";
            this.coldColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.coldColumn.Width = 26;
            // 
            // dgvcComplaintProcessingDataError
            // 
            this.dgvcComplaintProcessingDataError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcComplaintProcessingDataError.HeaderText = "";
            this.dgvcComplaintProcessingDataError.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dgvcComplaintProcessingDataError.Name = "dgvcComplaintProcessingDataError";
            this.dgvcComplaintProcessingDataError.Width = 5;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "First_Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.Width = 60;
            // 
            // Linked_Doc_ID
            // 
            this.Linked_Doc_ID.DataPropertyName = "Linked_Doc_ID";
            this.Linked_Doc_ID.HeaderText = "Код связан.";
            this.Linked_Doc_ID.Name = "Linked_Doc_ID";
            this.Linked_Doc_ID.Width = 60;
            // 
            // docTypeDataGridViewTextBoxColumn
            // 
            this.docTypeDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type";
            this.docTypeDataGridViewTextBoxColumn.HeaderText = "Тип";
            this.docTypeDataGridViewTextBoxColumn.Name = "docTypeDataGridViewTextBoxColumn";
            this.docTypeDataGridViewTextBoxColumn.Width = 35;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "Doc_Type_Name";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Назв. типа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            this.docTypeNameDataGridViewTextBoxColumn.Width = 110;
            // 
            // colAttachedFiles
            // 
            this.colAttachedFiles.HeaderText = "П. ф.";
            this.colAttachedFiles.Image = global::WMSOffice.Properties.Resources.paperclip1;
            this.colAttachedFiles.Name = "colAttachedFiles";
            this.colAttachedFiles.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAttachedFiles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colAttachedFiles.Width = 22;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "Status_Name";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Назв. статуса";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.Width = 180;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Created";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Создана";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            // 
            // usersCreatedDataGridViewTextBoxColumn
            // 
            this.usersCreatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Created";
            this.usersCreatedDataGridViewTextBoxColumn.HeaderText = "Кем создана";
            this.usersCreatedDataGridViewTextBoxColumn.Name = "usersCreatedDataGridViewTextBoxColumn";
            this.usersCreatedDataGridViewTextBoxColumn.Width = 140;
            // 
            // commonFaultEmployeeNameDataGridViewTextBoxColumn
            // 
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "Common_Fault_Employee_Name";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.HeaderText = "Виновный сотрудник";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Name = "commonFaultEmployeeNameDataGridViewTextBoxColumn";
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Visible = false;
            this.commonFaultEmployeeNameDataGridViewTextBoxColumn.Width = 130;
            // 
            // sourceAddressCodeDataGridViewTextBoxColumn
            // 
            this.sourceAddressCodeDataGridViewTextBoxColumn.DataPropertyName = "Source_Address_Code";
            this.sourceAddressCodeDataGridViewTextBoxColumn.HeaderText = "Код дост.";
            this.sourceAddressCodeDataGridViewTextBoxColumn.Name = "sourceAddressCodeDataGridViewTextBoxColumn";
            this.sourceAddressCodeDataGridViewTextBoxColumn.Visible = false;
            this.sourceAddressCodeDataGridViewTextBoxColumn.Width = 70;
            // 
            // INN
            // 
            this.INN.DataPropertyName = "INN";
            this.INN.HeaderText = "ИНН";
            this.INN.Name = "INN";
            this.INN.Visible = false;
            // 
            // Source_Address_Base_Code
            // 
            this.Source_Address_Base_Code.DataPropertyName = "Source_Address_Base_Code";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Source_Address_Base_Code.DefaultCellStyle = dataGridViewCellStyle3;
            this.Source_Address_Base_Code.HeaderText = "Код баз. деб.";
            this.Source_Address_Base_Code.Name = "Source_Address_Base_Code";
            this.Source_Address_Base_Code.Visible = false;
            this.Source_Address_Base_Code.Width = 75;
            // 
            // sourceAddressNameDataGridViewTextBoxColumn
            // 
            this.sourceAddressNameDataGridViewTextBoxColumn.DataPropertyName = "Source_Address_Name";
            this.sourceAddressNameDataGridViewTextBoxColumn.HeaderText = "Наименование клиента";
            this.sourceAddressNameDataGridViewTextBoxColumn.Name = "sourceAddressNameDataGridViewTextBoxColumn";
            this.sourceAddressNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // sourceAddressDataGridViewTextBoxColumn
            // 
            this.sourceAddressDataGridViewTextBoxColumn.DataPropertyName = "Source_Address";
            this.sourceAddressDataGridViewTextBoxColumn.HeaderText = "Адрес клиента";
            this.sourceAddressDataGridViewTextBoxColumn.Name = "sourceAddressDataGridViewTextBoxColumn";
            this.sourceAddressDataGridViewTextBoxColumn.Visible = false;
            this.sourceAddressDataGridViewTextBoxColumn.Width = 140;
            // 
            // ordersListDataGridViewTextBoxColumn
            // 
            this.ordersListDataGridViewTextBoxColumn.DataPropertyName = "OrdersList";
            this.ordersListDataGridViewTextBoxColumn.HeaderText = "Заказы";
            this.ordersListDataGridViewTextBoxColumn.Name = "ordersListDataGridViewTextBoxColumn";
            this.ordersListDataGridViewTextBoxColumn.Visible = false;
            // 
            // invoicesListDataGridViewTextBoxColumn
            // 
            this.invoicesListDataGridViewTextBoxColumn.DataPropertyName = "InvoicesList";
            this.invoicesListDataGridViewTextBoxColumn.HeaderText = "№ накладных";
            this.invoicesListDataGridViewTextBoxColumn.Name = "invoicesListDataGridViewTextBoxColumn";
            this.invoicesListDataGridViewTextBoxColumn.Visible = false;
            this.invoicesListDataGridViewTextBoxColumn.Width = 120;
            // 
            // contactNameDataGridViewTextBoxColumn
            // 
            this.contactNameDataGridViewTextBoxColumn.DataPropertyName = "Contact_Name";
            this.contactNameDataGridViewTextBoxColumn.HeaderText = "Контактное лицо";
            this.contactNameDataGridViewTextBoxColumn.Name = "contactNameDataGridViewTextBoxColumn";
            this.contactNameDataGridViewTextBoxColumn.Visible = false;
            this.contactNameDataGridViewTextBoxColumn.Width = 120;
            // 
            // clientLetterSentDataGridViewTextBoxColumn
            // 
            this.clientLetterSentDataGridViewTextBoxColumn.DataPropertyName = "Client_Letter_Sent";
            this.clientLetterSentDataGridViewTextBoxColumn.HeaderText = "Письмо отправлено";
            this.clientLetterSentDataGridViewTextBoxColumn.Name = "clientLetterSentDataGridViewTextBoxColumn";
            this.clientLetterSentDataGridViewTextBoxColumn.Visible = false;
            this.clientLetterSentDataGridViewTextBoxColumn.Width = 70;
            // 
            // warehouseNameDataGridViewTextBoxColumn
            // 
            this.warehouseNameDataGridViewTextBoxColumn.DataPropertyName = "Warehouse_Name";
            this.warehouseNameDataGridViewTextBoxColumn.HeaderText = "Филиал";
            this.warehouseNameDataGridViewTextBoxColumn.Name = "warehouseNameDataGridViewTextBoxColumn";
            this.warehouseNameDataGridViewTextBoxColumn.Visible = false;
            this.warehouseNameDataGridViewTextBoxColumn.Width = 140;
            // 
            // dateReceivedFromClientDataGridViewTextBoxColumn
            // 
            this.dateReceivedFromClientDataGridViewTextBoxColumn.DataPropertyName = "Date_ReceivedFromClient";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.HeaderText = "Получено от клиента";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.Name = "dateReceivedFromClientDataGridViewTextBoxColumn";
            this.dateReceivedFromClientDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateForecastSolutionDataGridViewTextBoxColumn
            // 
            this.dateForecastSolutionDataGridViewTextBoxColumn.DataPropertyName = "Date_ForecastSolution";
            this.dateForecastSolutionDataGridViewTextBoxColumn.HeaderText = "Прогн. решения";
            this.dateForecastSolutionDataGridViewTextBoxColumn.Name = "dateForecastSolutionDataGridViewTextBoxColumn";
            this.dateForecastSolutionDataGridViewTextBoxColumn.Visible = false;
            this.dateForecastSolutionDataGridViewTextBoxColumn.Width = 70;
            // 
            // dateUpdatedDataGridViewTextBoxColumn
            // 
            this.dateUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Date_Updated";
            this.dateUpdatedDataGridViewTextBoxColumn.HeaderText = "Обновлена";
            this.dateUpdatedDataGridViewTextBoxColumn.Name = "dateUpdatedDataGridViewTextBoxColumn";
            this.dateUpdatedDataGridViewTextBoxColumn.Visible = false;
            // 
            // usersUpdatedDataGridViewTextBoxColumn
            // 
            this.usersUpdatedDataGridViewTextBoxColumn.DataPropertyName = "Users_Updated";
            this.usersUpdatedDataGridViewTextBoxColumn.HeaderText = "Кем обновлена";
            this.usersUpdatedDataGridViewTextBoxColumn.Name = "usersUpdatedDataGridViewTextBoxColumn";
            this.usersUpdatedDataGridViewTextBoxColumn.Visible = false;
            this.usersUpdatedDataGridViewTextBoxColumn.Width = 140;
            // 
            // PayCondition
            // 
            this.PayCondition.DataPropertyName = "Conditions";
            this.PayCondition.HeaderText = "Усл. опл.";
            this.PayCondition.Name = "PayCondition";
            this.PayCondition.Visible = false;
            this.PayCondition.Width = 50;
            // 
            // clmLinkedDetail
            // 
            this.clmLinkedDetail.HeaderText = "";
            this.clmLinkedDetail.Name = "clmLinkedDetail";
            this.clmLinkedDetail.Width = 23;
            // 
            // dgvcColdSignImage
            // 
            this.dgvcColdSignImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvcColdSignImage.HeaderText = "";
            this.dgvcColdSignImage.Name = "dgvcColdSignImage";
            this.dgvcColdSignImage.ReadOnly = true;
            this.dgvcColdSignImage.Width = 5;
            // 
            // detailIDDataGridViewTextBoxColumn
            // 
            this.detailIDDataGridViewTextBoxColumn.DataPropertyName = "Detail_ID";
            this.detailIDDataGridViewTextBoxColumn.HeaderText = "Detail_ID";
            this.detailIDDataGridViewTextBoxColumn.Name = "detailIDDataGridViewTextBoxColumn";
            this.detailIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // docIDDataGridViewTextBoxColumn1
            // 
            this.docIDDataGridViewTextBoxColumn1.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn1.HeaderText = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn1.Name = "docIDDataGridViewTextBoxColumn1";
            this.docIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // relatedCompanyDataGridViewTextBoxColumn
            // 
            this.relatedCompanyDataGridViewTextBoxColumn.DataPropertyName = "Related_Company";
            this.relatedCompanyDataGridViewTextBoxColumn.HeaderText = "Related_Company";
            this.relatedCompanyDataGridViewTextBoxColumn.Name = "relatedCompanyDataGridViewTextBoxColumn";
            this.relatedCompanyDataGridViewTextBoxColumn.Visible = false;
            // 
            // relatedOrderTypeDataGridViewTextBoxColumn
            // 
            this.relatedOrderTypeDataGridViewTextBoxColumn.DataPropertyName = "Related_Order_Type";
            this.relatedOrderTypeDataGridViewTextBoxColumn.HeaderText = "Related_Order_Type";
            this.relatedOrderTypeDataGridViewTextBoxColumn.Name = "relatedOrderTypeDataGridViewTextBoxColumn";
            this.relatedOrderTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // relatedOrderNumberDataGridViewTextBoxColumn
            // 
            this.relatedOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "Related_Order_Number";
            this.relatedOrderNumberDataGridViewTextBoxColumn.HeaderText = "Related_Order_Number";
            this.relatedOrderNumberDataGridViewTextBoxColumn.Name = "relatedOrderNumberDataGridViewTextBoxColumn";
            this.relatedOrderNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // relatedInvoiceTypeDataGridViewTextBoxColumn
            // 
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.DataPropertyName = "Related_Invoice_Type";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.HeaderText = "Related_Invoice_Type";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.Name = "relatedInvoiceTypeDataGridViewTextBoxColumn";
            this.relatedInvoiceTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // lineStageDataGridViewImageColumn
            // 
            this.lineStageDataGridViewImageColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineStageDataGridViewImageColumn.HeaderText = "";
            this.lineStageDataGridViewImageColumn.Name = "lineStageDataGridViewImageColumn";
            this.lineStageDataGridViewImageColumn.Visible = false;
            this.lineStageDataGridViewImageColumn.Width = 5;
            // 
            // stageResultDataGridViewTextBoxColumn
            // 
            this.stageResultDataGridViewTextBoxColumn.HeaderText = "Результат";
            this.stageResultDataGridViewTextBoxColumn.Name = "stageResultDataGridViewTextBoxColumn";
            this.stageResultDataGridViewTextBoxColumn.Visible = false;
            // 
            // lineIDDataGridViewTextBoxColumn
            // 
            this.lineIDDataGridViewTextBoxColumn.DataPropertyName = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.HeaderText = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.Name = "lineIDDataGridViewTextBoxColumn";
            this.lineIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "Код";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.Width = 40;
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "Item_Name";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "Название товара";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            this.itemNameDataGridViewTextBoxColumn.Width = 160;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.Visible = false;
            // 
            // vendorLotDataGridViewTextBoxColumn
            // 
            this.vendorLotDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.HeaderText = "Vendor_Lot";
            this.vendorLotDataGridViewTextBoxColumn.Name = "vendorLotDataGridViewTextBoxColumn";
            this.vendorLotDataGridViewTextBoxColumn.Visible = false;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // vendorLotFactDataGridViewTextBoxColumn
            // 
            this.vendorLotFactDataGridViewTextBoxColumn.DataPropertyName = "Vendor_Lot_Fact";
            this.vendorLotFactDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorLotFactDataGridViewTextBoxColumn.Name = "vendorLotFactDataGridViewTextBoxColumn";
            this.vendorLotFactDataGridViewTextBoxColumn.Width = 70;
            // 
            // unitOfMeasureDataGridViewTextBoxColumn
            // 
            this.unitOfMeasureDataGridViewTextBoxColumn.DataPropertyName = "UnitOfMeasure";
            this.unitOfMeasureDataGridViewTextBoxColumn.HeaderText = "ЕИ";
            this.unitOfMeasureDataGridViewTextBoxColumn.Name = "unitOfMeasureDataGridViewTextBoxColumn";
            this.unitOfMeasureDataGridViewTextBoxColumn.Width = 40;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.Width = 55;
            // 
            // resultQuantityDataGridViewTextBoxColumn
            // 
            this.resultQuantityDataGridViewTextBoxColumn.DataPropertyName = "ResultQuantity";
            this.resultQuantityDataGridViewTextBoxColumn.HeaderText = "ResultQuantity";
            this.resultQuantityDataGridViewTextBoxColumn.Name = "resultQuantityDataGridViewTextBoxColumn";
            this.resultQuantityDataGridViewTextBoxColumn.Visible = false;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Price.DefaultCellStyle = dataGridViewCellStyle9;
            this.Price.HeaderText = "Цена";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 65;
            // 
            // Tax
            // 
            this.Tax.DataPropertyName = "Tax";
            this.Tax.HeaderText = "НДС";
            this.Tax.Name = "Tax";
            this.Tax.ReadOnly = true;
            this.Tax.Width = 55;
            // 
            // relatedInvoiceNumberDataGridViewTextBoxColumn
            // 
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.DataPropertyName = "Related_Invoice_Number";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.HeaderText = "Накладная";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.Name = "relatedInvoiceNumberDataGridViewTextBoxColumn";
            this.relatedInvoiceNumberDataGridViewTextBoxColumn.Width = 70;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "Дата накладной";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 106;
            // 
            // ComplaintMergeExtForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(858, 475);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ComplaintMergeExtForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Претензии - Недостача";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComplaints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentDocsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.gbDocRequestDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocRequestDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.docRequestDetailsBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.BindingSource currentDocsBindingSource;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource docRequestDetailsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.CurrentDocsTableAdapter currentDocsTableAdapter;
        private WMSOffice.Data.ComplaintsTableAdapters.DocRequestDetailsTableAdapter docRequestDetailsTableAdapter;
        private System.Windows.Forms.DataGridView dgvComplaints;
        private System.Windows.Forms.GroupBox gbDocRequestDetails;
        private System.Windows.Forms.DataGridView dgvDocRequestDetails;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewImageColumn clmLinked;
        private System.Windows.Forms.DataGridViewImageColumn coldColumn;
        private System.Windows.Forms.DataGridViewImageColumn dgvcComplaintProcessingDataError;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Linked_Doc_ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn colAttachedFiles;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commonFaultEmployeeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn INN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Source_Address_Base_Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordersListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoicesListDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clientLetterSentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateReceivedFromClientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateForecastSolutionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usersUpdatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PayCondition;
        private System.Windows.Forms.DataGridViewImageColumn clmLinkedDetail;
        private System.Windows.Forms.DataGridViewImageColumn dgvcColdSignImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn detailIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedCompanyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedOrderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedOrderNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedInvoiceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewImageColumn lineStageDataGridViewImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stageResultDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorLotFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitOfMeasureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tax;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedInvoiceNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;

    }
}