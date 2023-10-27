namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveReturnedTareInvoiceForm
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
            this.dtpInvoiceArchiveDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceBarCode = new System.Windows.Forms.Label();
            this.lblInvoiceArchiveDate = new System.Windows.Forms.Label();
            this.tbsInvoiceBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.gbRequisites = new System.Windows.Forms.GroupBox();
            this.pnlDocument = new System.Windows.Forms.Panel();
            this.dgvDocDetails = new System.Windows.Forms.DataGridView();
            this.aIRetDocDetailsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.pnlDocHeader = new System.Windows.Forms.Panel();
            this.tbRouteNumber = new System.Windows.Forms.TextBox();
            this.aIRetDocHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tbReceiver = new System.Windows.Forms.TextBox();
            this.tbReturnedTareInvoice = new System.Windows.Forms.TextBox();
            this.lblRouteNumber = new System.Windows.Forms.Label();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.lblReturnedTareInvoice = new System.Windows.Forms.Label();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.aI_Ret_Doc_DetailsTableAdapter = new WMSOffice.Data.WHTableAdapters.AI_Ret_Doc_DetailsTableAdapter();
            this.aI_Ret_Doc_HeaderTableAdapter = new WMSOffice.Data.WHTableAdapters.AI_Ret_Doc_HeaderTableAdapter();
            this.scDocumentWithAttachments = new System.Windows.Forms.SplitContainer();
            this.tcDocument = new System.Windows.Forms.TabControl();
            this.tpDocument = new System.Windows.Forms.TabPage();
            this.pnlDocumentContent = new System.Windows.Forms.Panel();
            this.tsDocumentOperations = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.tcDocumentAttachments = new System.Windows.Forms.TabControl();
            this.tpAttorneys = new System.Windows.Forms.TabPage();
            this.tsAttorneysOperations = new System.Windows.Forms.ToolStrip();
            this.ivcAttorneys = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tpAgreements = new System.Windows.Forms.TabPage();
            this.tsAgreementsOperations = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.ivcAgreements = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.imageViewerControl1 = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.imageViewerControl2 = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tareBarcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.creditQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remainsQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Driver_Return_Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factReturnQtyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlButtons.SuspendLayout();
            this.gbRequisites.SuspendLayout();
            this.pnlDocument.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIRetDocDetailsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.pnlDocHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aIRetDocHeaderBindingSource)).BeginInit();
            this.scDocumentWithAttachments.Panel1.SuspendLayout();
            this.scDocumentWithAttachments.Panel2.SuspendLayout();
            this.scDocumentWithAttachments.SuspendLayout();
            this.tcDocument.SuspendLayout();
            this.tpDocument.SuspendLayout();
            this.pnlDocumentContent.SuspendLayout();
            this.tsDocumentOperations.SuspendLayout();
            this.tcDocumentAttachments.SuspendLayout();
            this.tpAttorneys.SuspendLayout();
            this.tpAgreements.SuspendLayout();
            this.tsAgreementsOperations.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(4634, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(4724, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 648);
            this.pnlButtons.Size = new System.Drawing.Size(1464, 43);
            this.pnlButtons.TabIndex = 8;
            // 
            // dtpInvoiceArchiveDate
            // 
            this.dtpInvoiceArchiveDate.CustomFormat = "dd.MM.yyyy";
            this.dtpInvoiceArchiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dtpInvoiceArchiveDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInvoiceArchiveDate.Location = new System.Drawing.Point(108, 39);
            this.dtpInvoiceArchiveDate.Name = "dtpInvoiceArchiveDate";
            this.dtpInvoiceArchiveDate.Size = new System.Drawing.Size(100, 26);
            this.dtpInvoiceArchiveDate.TabIndex = 4;
            // 
            // lblInvoiceBarCode
            // 
            this.lblInvoiceBarCode.AutoSize = true;
            this.lblInvoiceBarCode.Location = new System.Drawing.Point(12, 12);
            this.lblInvoiceBarCode.Name = "lblInvoiceBarCode";
            this.lblInvoiceBarCode.Size = new System.Drawing.Size(57, 13);
            this.lblInvoiceBarCode.TabIndex = 1;
            this.lblInvoiceBarCode.Text = "Ш/К акта:";
            // 
            // lblInvoiceArchiveDate
            // 
            this.lblInvoiceArchiveDate.AutoSize = true;
            this.lblInvoiceArchiveDate.Location = new System.Drawing.Point(12, 46);
            this.lblInvoiceArchiveDate.Name = "lblInvoiceArchiveDate";
            this.lblInvoiceArchiveDate.Size = new System.Drawing.Size(88, 13);
            this.lblInvoiceArchiveDate.TabIndex = 3;
            this.lblInvoiceArchiveDate.Text = "Дата закрытия:";
            // 
            // tbsInvoiceBarCode
            // 
            this.tbsInvoiceBarCode.AllowType = true;
            this.tbsInvoiceBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsInvoiceBarCode.AutoConvert = true;
            this.tbsInvoiceBarCode.DelayThreshold = 50;
            this.tbsInvoiceBarCode.Location = new System.Drawing.Point(105, 6);
            this.tbsInvoiceBarCode.Name = "tbsInvoiceBarCode";
            this.tbsInvoiceBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbsInvoiceBarCode.ReadOnly = false;
            this.tbsInvoiceBarCode.Size = new System.Drawing.Size(708, 25);
            this.tbsInvoiceBarCode.TabIndex = 2;
            this.tbsInvoiceBarCode.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbsInvoiceBarCode.UseParentFont = false;
            this.tbsInvoiceBarCode.UseScanModeOnly = false;
            // 
            // gbRequisites
            // 
            this.gbRequisites.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbRequisites.Controls.Add(this.pnlDocument);
            this.gbRequisites.Controls.Add(this.tbNote);
            this.gbRequisites.Controls.Add(this.lblNote);
            this.gbRequisites.Location = new System.Drawing.Point(0, 92);
            this.gbRequisites.Name = "gbRequisites";
            this.gbRequisites.Size = new System.Drawing.Size(826, 490);
            this.gbRequisites.TabIndex = 7;
            this.gbRequisites.TabStop = false;
            this.gbRequisites.Text = "Реквизиты";
            // 
            // pnlDocument
            // 
            this.pnlDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDocument.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDocument.Controls.Add(this.dgvDocDetails);
            this.pnlDocument.Controls.Add(this.pnlDocHeader);
            this.pnlDocument.Location = new System.Drawing.Point(15, 133);
            this.pnlDocument.Name = "pnlDocument";
            this.pnlDocument.Size = new System.Drawing.Size(798, 351);
            this.pnlDocument.TabIndex = 2;
            // 
            // dgvDocDetails
            // 
            this.dgvDocDetails.AllowUserToAddRows = false;
            this.dgvDocDetails.AllowUserToDeleteRows = false;
            this.dgvDocDetails.AllowUserToResizeColumns = false;
            this.dgvDocDetails.AllowUserToResizeRows = false;
            this.dgvDocDetails.AutoGenerateColumns = false;
            this.dgvDocDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvDocDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tareBarcodeDataGridViewTextBoxColumn,
            this.creditQtyDataGridViewTextBoxColumn,
            this.shipQtyDataGridViewTextBoxColumn,
            this.returnQtyDataGridViewTextBoxColumn,
            this.remainsQtyDataGridViewTextBoxColumn,
            this.Driver_Return_Qty,
            this.factReturnQtyDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn});
            this.dgvDocDetails.DataSource = this.aIRetDocDetailsBindingSource;
            this.dgvDocDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocDetails.Location = new System.Drawing.Point(0, 90);
            this.dgvDocDetails.MultiSelect = false;
            this.dgvDocDetails.Name = "dgvDocDetails";
            this.dgvDocDetails.RowHeadersVisible = false;
            this.dgvDocDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocDetails.Size = new System.Drawing.Size(798, 261);
            this.dgvDocDetails.TabIndex = 1;
            this.dgvDocDetails.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocDetails_CellValueChanged);
            this.dgvDocDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDocDetails_DataError);
            // 
            // aIRetDocDetailsBindingSource
            // 
            this.aIRetDocDetailsBindingSource.DataMember = "AI_Ret_Doc_Details";
            this.aIRetDocDetailsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // pnlDocHeader
            // 
            this.pnlDocHeader.Controls.Add(this.tbRouteNumber);
            this.pnlDocHeader.Controls.Add(this.tbReceiver);
            this.pnlDocHeader.Controls.Add(this.tbReturnedTareInvoice);
            this.pnlDocHeader.Controls.Add(this.lblRouteNumber);
            this.pnlDocHeader.Controls.Add(this.lblReceiver);
            this.pnlDocHeader.Controls.Add(this.lblReturnedTareInvoice);
            this.pnlDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDocHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlDocHeader.Name = "pnlDocHeader";
            this.pnlDocHeader.Size = new System.Drawing.Size(798, 90);
            this.pnlDocHeader.TabIndex = 0;
            // 
            // tbRouteNumber
            // 
            this.tbRouteNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbRouteNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aIRetDocHeaderBindingSource, "Route_Number", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbRouteNumber.Location = new System.Drawing.Point(124, 63);
            this.tbRouteNumber.Name = "tbRouteNumber";
            this.tbRouteNumber.ReadOnly = true;
            this.tbRouteNumber.Size = new System.Drawing.Size(100, 20);
            this.tbRouteNumber.TabIndex = 5;
            // 
            // aIRetDocHeaderBindingSource
            // 
            this.aIRetDocHeaderBindingSource.DataMember = "AI_Ret_Doc_Header";
            this.aIRetDocHeaderBindingSource.DataSource = this.wH;
            // 
            // tbReceiver
            // 
            this.tbReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReceiver.BackColor = System.Drawing.SystemColors.Window;
            this.tbReceiver.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aIRetDocHeaderBindingSource, "Receiver_Address", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbReceiver.Location = new System.Drawing.Point(124, 34);
            this.tbReceiver.Name = "tbReceiver";
            this.tbReceiver.ReadOnly = true;
            this.tbReceiver.Size = new System.Drawing.Size(671, 20);
            this.tbReceiver.TabIndex = 3;
            // 
            // tbReturnedTareInvoice
            // 
            this.tbReturnedTareInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbReturnedTareInvoice.BackColor = System.Drawing.SystemColors.Window;
            this.tbReturnedTareInvoice.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.aIRetDocHeaderBindingSource, "Doc_Number_description", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tbReturnedTareInvoice.Location = new System.Drawing.Point(124, 5);
            this.tbReturnedTareInvoice.Name = "tbReturnedTareInvoice";
            this.tbReturnedTareInvoice.ReadOnly = true;
            this.tbReturnedTareInvoice.Size = new System.Drawing.Size(671, 20);
            this.tbReturnedTareInvoice.TabIndex = 1;
            // 
            // lblRouteNumber
            // 
            this.lblRouteNumber.AutoSize = true;
            this.lblRouteNumber.Location = new System.Drawing.Point(12, 67);
            this.lblRouteNumber.Name = "lblRouteNumber";
            this.lblRouteNumber.Size = new System.Drawing.Size(104, 13);
            this.lblRouteNumber.TabIndex = 4;
            this.lblRouteNumber.Text = "Маршрутный лист: ";
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(12, 38);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(72, 13);
            this.lblReceiver.TabIndex = 2;
            this.lblReceiver.Text = "Получатель: ";
            // 
            // lblReturnedTareInvoice
            // 
            this.lblReturnedTareInvoice.AutoSize = true;
            this.lblReturnedTareInvoice.Location = new System.Drawing.Point(12, 9);
            this.lblReturnedTareInvoice.Name = "lblReturnedTareInvoice";
            this.lblReturnedTareInvoice.Size = new System.Drawing.Size(95, 13);
            this.lblReturnedTareInvoice.TabIndex = 0;
            this.lblReturnedTareInvoice.Text = "Возвратный акт: ";
            // 
            // tbNote
            // 
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.BackColor = System.Drawing.SystemColors.Window;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbNote.Location = new System.Drawing.Point(15, 52);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ReadOnly = true;
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(799, 75);
            this.tbNote.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 31);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(73, 13);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Примечание:";
            // 
            // aI_Ret_Doc_DetailsTableAdapter
            // 
            this.aI_Ret_Doc_DetailsTableAdapter.ClearBeforeFill = true;
            // 
            // aI_Ret_Doc_HeaderTableAdapter
            // 
            this.aI_Ret_Doc_HeaderTableAdapter.ClearBeforeFill = true;
            // 
            // scDocumentWithAttachments
            // 
            this.scDocumentWithAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scDocumentWithAttachments.Location = new System.Drawing.Point(0, 0);
            this.scDocumentWithAttachments.Name = "scDocumentWithAttachments";
            // 
            // scDocumentWithAttachments.Panel1
            // 
            this.scDocumentWithAttachments.Panel1.Controls.Add(this.tcDocument);
            // 
            // scDocumentWithAttachments.Panel2
            // 
            this.scDocumentWithAttachments.Panel2.Controls.Add(this.tcDocumentAttachments);
            this.scDocumentWithAttachments.Size = new System.Drawing.Size(1464, 642);
            this.scDocumentWithAttachments.SplitterDistance = 840;
            this.scDocumentWithAttachments.TabIndex = 9;
            // 
            // tcDocument
            // 
            this.tcDocument.Controls.Add(this.tpDocument);
            this.tcDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDocument.Location = new System.Drawing.Point(0, 0);
            this.tcDocument.Name = "tcDocument";
            this.tcDocument.SelectedIndex = 0;
            this.tcDocument.Size = new System.Drawing.Size(840, 642);
            this.tcDocument.TabIndex = 5;
            // 
            // tpDocument
            // 
            this.tpDocument.Controls.Add(this.pnlDocumentContent);
            this.tpDocument.Controls.Add(this.tsDocumentOperations);
            this.tpDocument.Location = new System.Drawing.Point(4, 22);
            this.tpDocument.Name = "tpDocument";
            this.tpDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tpDocument.Size = new System.Drawing.Size(832, 616);
            this.tpDocument.TabIndex = 0;
            this.tpDocument.Text = "Документ";
            this.tpDocument.UseVisualStyleBackColor = true;
            // 
            // pnlDocumentContent
            // 
            this.pnlDocumentContent.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDocumentContent.Controls.Add(this.lblInvoiceBarCode);
            this.pnlDocumentContent.Controls.Add(this.dtpInvoiceArchiveDate);
            this.pnlDocumentContent.Controls.Add(this.lblInvoiceArchiveDate);
            this.pnlDocumentContent.Controls.Add(this.gbRequisites);
            this.pnlDocumentContent.Controls.Add(this.tbsInvoiceBarCode);
            this.pnlDocumentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDocumentContent.Location = new System.Drawing.Point(3, 28);
            this.pnlDocumentContent.Name = "pnlDocumentContent";
            this.pnlDocumentContent.Size = new System.Drawing.Size(826, 585);
            this.pnlDocumentContent.TabIndex = 2;
            // 
            // tsDocumentOperations
            // 
            this.tsDocumentOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind,
            this.btnClear});
            this.tsDocumentOperations.Location = new System.Drawing.Point(3, 3);
            this.tsDocumentOperations.Name = "tsDocumentOperations";
            this.tsDocumentOperations.Size = new System.Drawing.Size(826, 25);
            this.tsDocumentOperations.TabIndex = 1;
            this.tsDocumentOperations.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(62, 22);
            this.btnFind.Text = "Поиск";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Image = global::WMSOffice.Properties.Resources.clear;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 22);
            this.btnClear.Text = "Очистить";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // tcDocumentAttachments
            // 
            this.tcDocumentAttachments.Controls.Add(this.tpAttorneys);
            this.tcDocumentAttachments.Controls.Add(this.tpAgreements);
            this.tcDocumentAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDocumentAttachments.Location = new System.Drawing.Point(0, 0);
            this.tcDocumentAttachments.Name = "tcDocumentAttachments";
            this.tcDocumentAttachments.SelectedIndex = 0;
            this.tcDocumentAttachments.Size = new System.Drawing.Size(620, 642);
            this.tcDocumentAttachments.TabIndex = 4;
            this.tcDocumentAttachments.SelectedIndexChanged += new System.EventHandler(this.tcDocumentAttachments_SelectedIndexChanged);
            // 
            // tpAttorneys
            // 
            this.tpAttorneys.Controls.Add(this.tsAttorneysOperations);
            this.tpAttorneys.Controls.Add(this.ivcAttorneys);
            this.tpAttorneys.Location = new System.Drawing.Point(4, 22);
            this.tpAttorneys.Name = "tpAttorneys";
            this.tpAttorneys.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttorneys.Size = new System.Drawing.Size(612, 616);
            this.tpAttorneys.TabIndex = 0;
            this.tpAttorneys.Text = "Доверенности";
            this.tpAttorneys.UseVisualStyleBackColor = true;
            // 
            // tsAttorneysOperations
            // 
            this.tsAttorneysOperations.Location = new System.Drawing.Point(3, 3);
            this.tsAttorneysOperations.Name = "tsAttorneysOperations";
            this.tsAttorneysOperations.Size = new System.Drawing.Size(606, 25);
            this.tsAttorneysOperations.TabIndex = 1;
            this.tsAttorneysOperations.Text = "toolStrip1";
            // 
            // ivcAttorneys
            // 
            this.ivcAttorneys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ivcAttorneys.AutoZoomActivated = true;
            this.ivcAttorneys.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ivcAttorneys.CurrentItem = null;
            this.ivcAttorneys.CurrentZoomFactor = 1;
            this.ivcAttorneys.Location = new System.Drawing.Point(3, 31);
            this.ivcAttorneys.Name = "ivcAttorneys";
            this.ivcAttorneys.Size = new System.Drawing.Size(606, 582);
            this.ivcAttorneys.TabIndex = 0;
            // 
            // tpAgreements
            // 
            this.tpAgreements.Controls.Add(this.tsAgreementsOperations);
            this.tpAgreements.Controls.Add(this.ivcAgreements);
            this.tpAgreements.Location = new System.Drawing.Point(4, 22);
            this.tpAgreements.Name = "tpAgreements";
            this.tpAgreements.Padding = new System.Windows.Forms.Padding(3);
            this.tpAgreements.Size = new System.Drawing.Size(612, 616);
            this.tpAgreements.TabIndex = 1;
            this.tpAgreements.Text = "Договора";
            this.tpAgreements.UseVisualStyleBackColor = true;
            // 
            // tsAgreementsOperations
            // 
            this.tsAgreementsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad});
            this.tsAgreementsOperations.Location = new System.Drawing.Point(3, 3);
            this.tsAgreementsOperations.Name = "tsAgreementsOperations";
            this.tsAgreementsOperations.Size = new System.Drawing.Size(606, 25);
            this.tsAgreementsOperations.TabIndex = 1;
            this.tsAgreementsOperations.Text = "toolStrip1";
            // 
            // btnLoad
            // 
            this.btnLoad.Image = global::WMSOffice.Properties.Resources.start;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(81, 22);
            this.btnLoad.Text = "Загрузить";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // ivcAgreements
            // 
            this.ivcAgreements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ivcAgreements.AutoZoomActivated = true;
            this.ivcAgreements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ivcAgreements.CurrentItem = null;
            this.ivcAgreements.CurrentZoomFactor = 1;
            this.ivcAgreements.Location = new System.Drawing.Point(3, 31);
            this.ivcAgreements.Name = "ivcAgreements";
            this.ivcAgreements.Size = new System.Drawing.Size(606, 582);
            this.ivcAgreements.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Controls.Add(this.imageViewerControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 375);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Доверенности";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(458, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // imageViewerControl1
            // 
            this.imageViewerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewerControl1.AutoZoomActivated = true;
            this.imageViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerControl1.CurrentItem = null;
            this.imageViewerControl1.CurrentZoomFactor = 1;
            this.imageViewerControl1.Location = new System.Drawing.Point(3, 31);
            this.imageViewerControl1.Name = "imageViewerControl1";
            this.imageViewerControl1.Size = new System.Drawing.Size(458, 341);
            this.imageViewerControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip2);
            this.tabPage2.Controls.Add(this.imageViewerControl2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 375);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Договора";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(458, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::WMSOffice.Properties.Resources.start;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(81, 22);
            this.toolStripButton1.Text = "Загрузить";
            // 
            // imageViewerControl2
            // 
            this.imageViewerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageViewerControl2.AutoZoomActivated = true;
            this.imageViewerControl2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageViewerControl2.CurrentItem = null;
            this.imageViewerControl2.CurrentZoomFactor = 1;
            this.imageViewerControl2.Location = new System.Drawing.Point(3, 31);
            this.imageViewerControl2.Name = "imageViewerControl2";
            this.imageViewerControl2.Size = new System.Drawing.Size(458, 341);
            this.imageViewerControl2.TabIndex = 0;
            // 
            // tareBarcodeDataGridViewTextBoxColumn
            // 
            this.tareBarcodeDataGridViewTextBoxColumn.DataPropertyName = "Tare_Bar_code";
            this.tareBarcodeDataGridViewTextBoxColumn.HeaderText = "Оборотная тара";
            this.tareBarcodeDataGridViewTextBoxColumn.Name = "tareBarcodeDataGridViewTextBoxColumn";
            this.tareBarcodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.tareBarcodeDataGridViewTextBoxColumn.Width = 104;
            // 
            // creditQtyDataGridViewTextBoxColumn
            // 
            this.creditQtyDataGridViewTextBoxColumn.DataPropertyName = "Credit_Qty";
            this.creditQtyDataGridViewTextBoxColumn.HeaderText = "Задолженность";
            this.creditQtyDataGridViewTextBoxColumn.Name = "creditQtyDataGridViewTextBoxColumn";
            this.creditQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.creditQtyDataGridViewTextBoxColumn.Width = 112;
            // 
            // shipQtyDataGridViewTextBoxColumn
            // 
            this.shipQtyDataGridViewTextBoxColumn.DataPropertyName = "Ship_Qty";
            this.shipQtyDataGridViewTextBoxColumn.HeaderText = "Отгружено";
            this.shipQtyDataGridViewTextBoxColumn.Name = "shipQtyDataGridViewTextBoxColumn";
            this.shipQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.shipQtyDataGridViewTextBoxColumn.Width = 87;
            // 
            // returnQtyDataGridViewTextBoxColumn
            // 
            this.returnQtyDataGridViewTextBoxColumn.DataPropertyName = "Return_Qty";
            this.returnQtyDataGridViewTextBoxColumn.HeaderText = "Возврат (план)";
            this.returnQtyDataGridViewTextBoxColumn.Name = "returnQtyDataGridViewTextBoxColumn";
            this.returnQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.returnQtyDataGridViewTextBoxColumn.Width = 98;
            // 
            // remainsQtyDataGridViewTextBoxColumn
            // 
            this.remainsQtyDataGridViewTextBoxColumn.DataPropertyName = "Remains_Qty";
            this.remainsQtyDataGridViewTextBoxColumn.HeaderText = "Остаток (план)";
            this.remainsQtyDataGridViewTextBoxColumn.Name = "remainsQtyDataGridViewTextBoxColumn";
            this.remainsQtyDataGridViewTextBoxColumn.ReadOnly = true;
            this.remainsQtyDataGridViewTextBoxColumn.Width = 98;
            // 
            // Driver_Return_Qty
            // 
            this.Driver_Return_Qty.DataPropertyName = "Driver_Return_Qty";
            this.Driver_Return_Qty.HeaderText = "Возврат водитель (факт)";
            this.Driver_Return_Qty.Name = "Driver_Return_Qty";
            this.Driver_Return_Qty.ReadOnly = true;
            this.Driver_Return_Qty.Visible = false;
            this.Driver_Return_Qty.Width = 116;
            // 
            // factReturnQtyDataGridViewTextBoxColumn
            // 
            this.factReturnQtyDataGridViewTextBoxColumn.DataPropertyName = "Fact_Return_Qty";
            this.factReturnQtyDataGridViewTextBoxColumn.HeaderText = "Возврат (факт)";
            this.factReturnQtyDataGridViewTextBoxColumn.Name = "factReturnQtyDataGridViewTextBoxColumn";
            this.factReturnQtyDataGridViewTextBoxColumn.Width = 99;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 58;
            // 
            // ArchiveReturnedTareInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 691);
            this.Controls.Add(this.scDocumentWithAttachments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ArchiveReturnedTareInvoiceForm";
            this.Text = "Закрытие акта приема-передачи на оборотную тару";
            this.Load += new System.EventHandler(this.ArchiveInvoiceForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoiceForm_FormClosing);
            this.Controls.SetChildIndex(this.scDocumentWithAttachments, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbRequisites.ResumeLayout(false);
            this.gbRequisites.PerformLayout();
            this.pnlDocument.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aIRetDocDetailsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.pnlDocHeader.ResumeLayout(false);
            this.pnlDocHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aIRetDocHeaderBindingSource)).EndInit();
            this.scDocumentWithAttachments.Panel1.ResumeLayout(false);
            this.scDocumentWithAttachments.Panel2.ResumeLayout(false);
            this.scDocumentWithAttachments.ResumeLayout(false);
            this.tcDocument.ResumeLayout(false);
            this.tpDocument.ResumeLayout(false);
            this.tpDocument.PerformLayout();
            this.pnlDocumentContent.ResumeLayout(false);
            this.pnlDocumentContent.PerformLayout();
            this.tsDocumentOperations.ResumeLayout(false);
            this.tsDocumentOperations.PerformLayout();
            this.tcDocumentAttachments.ResumeLayout(false);
            this.tpAttorneys.ResumeLayout(false);
            this.tpAttorneys.PerformLayout();
            this.tpAgreements.ResumeLayout(false);
            this.tpAgreements.PerformLayout();
            this.tsAgreementsOperations.ResumeLayout(false);
            this.tsAgreementsOperations.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpInvoiceArchiveDate;
        private System.Windows.Forms.Label lblInvoiceBarCode;
        private System.Windows.Forms.Label lblInvoiceArchiveDate;
        private WMSOffice.Controls.TextBoxScaner tbsInvoiceBarCode;
        private System.Windows.Forms.GroupBox gbRequisites;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox tbNote;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.BindingSource aIRetDocDetailsBindingSource;
        private Data.WHTableAdapters.AI_Ret_Doc_DetailsTableAdapter aI_Ret_Doc_DetailsTableAdapter;
        private System.Windows.Forms.BindingSource aIRetDocHeaderBindingSource;
        private Data.WHTableAdapters.AI_Ret_Doc_HeaderTableAdapter aI_Ret_Doc_HeaderTableAdapter;
        private System.Windows.Forms.SplitContainer scDocumentWithAttachments;
        private System.Windows.Forms.TabControl tcDocumentAttachments;
        private System.Windows.Forms.TabPage tpAttorneys;
        private System.Windows.Forms.ToolStrip tsAttorneysOperations;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAttorneys;
        private System.Windows.Forms.TabPage tpAgreements;
        private System.Windows.Forms.ToolStrip tsAgreementsOperations;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAgreements;
        private System.Windows.Forms.TabControl tcDocument;
        private System.Windows.Forms.TabPage tpDocument;
        private System.Windows.Forms.ToolStrip tsDocumentOperations;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private WMSOffice.Controls.Custom.ImageViewerControl imageViewerControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private WMSOffice.Controls.Custom.ImageViewerControl imageViewerControl2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.Panel pnlDocumentContent;
        private System.Windows.Forms.Panel pnlDocument;
        private System.Windows.Forms.DataGridView dgvDocDetails;
        private System.Windows.Forms.Panel pnlDocHeader;
        private System.Windows.Forms.TextBox tbRouteNumber;
        private System.Windows.Forms.TextBox tbReceiver;
        private System.Windows.Forms.TextBox tbReturnedTareInvoice;
        private System.Windows.Forms.Label lblRouteNumber;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.Label lblReturnedTareInvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn tareBarcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn creditQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn remainsQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Driver_Return_Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn factReturnQtyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
    }
}