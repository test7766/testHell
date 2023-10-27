namespace WMSOffice.Dialogs.Quality
{
    partial class BlockDocsApproveForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.spcTwoGrids = new System.Windows.Forms.SplitContainer();
            this.pbLoading = new System.Windows.Forms.PictureBox();
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.clApprove = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clReject = new System.Windows.Forms.DataGridViewButtonColumn();
            this.clComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalDocNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.externalDocDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sourceNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organisationNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docCommentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDocsTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefreshDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.bsBlGetDocsApproved = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblDocs = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.holdtypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorlotDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datefromDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datetoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBlGetDocsApprovedDetail = new System.Windows.Forms.BindingSource(this.components);
            this.lblDetails = new System.Windows.Forms.Label();
            this.taBlGetDocsApproved = new WMSOffice.Data.QualityTableAdapters.BL_Get_Docs_ApprovedTableAdapter();
            this.taBlGetDocsApprovedDetail = new WMSOffice.Data.QualityTableAdapters.BL_Get_Docs_Approved_DetailTableAdapter();
            this.bgwDocsLoader = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
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
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spcTwoGrids.Panel1.SuspendLayout();
            this.spcTwoGrids.Panel2.SuspendLayout();
            this.spcTwoGrids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.cmsDocsTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocsApproved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocsApprovedDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(697, 427);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Закрыть";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // spcTwoGrids
            // 
            this.spcTwoGrids.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.spcTwoGrids.Location = new System.Drawing.Point(12, 12);
            this.spcTwoGrids.Name = "spcTwoGrids";
            this.spcTwoGrids.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTwoGrids.Panel1
            // 
            this.spcTwoGrids.Panel1.Controls.Add(this.pbLoading);
            this.spcTwoGrids.Panel1.Controls.Add(this.dgvDocs);
            this.spcTwoGrids.Panel1.Controls.Add(this.lblDocs);
            // 
            // spcTwoGrids.Panel2
            // 
            this.spcTwoGrids.Panel2.Controls.Add(this.dgvDetails);
            this.spcTwoGrids.Panel2.Controls.Add(this.lblDetails);
            this.spcTwoGrids.Size = new System.Drawing.Size(760, 409);
            this.spcTwoGrids.SplitterDistance = 197;
            this.spcTwoGrids.TabIndex = 2;
            // 
            // pbLoading
            // 
            this.pbLoading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pbLoading.Image = global::WMSOffice.Properties.Resources.Loading;
            this.pbLoading.Location = new System.Drawing.Point(325, 56);
            this.pbLoading.Name = "pbLoading";
            this.pbLoading.Size = new System.Drawing.Size(101, 101);
            this.pbLoading.TabIndex = 2;
            this.pbLoading.TabStop = false;
            this.pbLoading.Visible = false;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToOrderColumns = true;
            this.dgvDocs.AllowUserToResizeRows = false;
            this.dgvDocs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDocs.AutoGenerateColumns = false;
            this.dgvDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clApprove,
            this.clReject,
            this.clComment,
            this.docIDDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn,
            this.externalDocNumberDataGridViewTextBoxColumn,
            this.externalDocDateDataGridViewTextBoxColumn,
            this.sourceNameDataGridViewTextBoxColumn,
            this.organisationNameDataGridViewTextBoxColumn,
            this.userDataGridViewTextBoxColumn,
            this.docCommentDataGridViewTextBoxColumn});
            this.dgvDocs.ContextMenuStrip = this.cmsDocsTable;
            this.dgvDocs.DataSource = this.bsBlGetDocsApproved;
            this.dgvDocs.Location = new System.Drawing.Point(6, 24);
            this.dgvDocs.MultiSelect = false;
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.Size = new System.Drawing.Size(751, 170);
            this.dgvDocs.TabIndex = 1;
            this.dgvDocs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocs_DataBindingComplete);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            this.dgvDocs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocs_CellContentClick);
            // 
            // clApprove
            // 
            this.clApprove.HeaderText = "";
            this.clApprove.Name = "clApprove";
            this.clApprove.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clApprove.Width = 80;
            // 
            // clReject
            // 
            this.clReject.HeaderText = "";
            this.clReject.Name = "clReject";
            this.clReject.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clReject.Width = 80;
            // 
            // clComment
            // 
            this.clComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clComment.HeaderText = "Комментарий";
            this.clComment.Name = "clComment";
            this.clComment.Width = 102;
            // 
            // docIDDataGridViewTextBoxColumn
            // 
            this.docIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docIDDataGridViewTextBoxColumn.DataPropertyName = "Doc_ID";
            this.docIDDataGridViewTextBoxColumn.HeaderText = "Код док-та";
            this.docIDDataGridViewTextBoxColumn.Name = "docIDDataGridViewTextBoxColumn";
            this.docIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.docIDDataGridViewTextBoxColumn.Width = 86;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "Doc_Date";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата док-та";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // externalDocNumberDataGridViewTextBoxColumn
            // 
            this.externalDocNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.externalDocNumberDataGridViewTextBoxColumn.DataPropertyName = "External_Doc_Number";
            this.externalDocNumberDataGridViewTextBoxColumn.HeaderText = "Номер док-та";
            this.externalDocNumberDataGridViewTextBoxColumn.Name = "externalDocNumberDataGridViewTextBoxColumn";
            this.externalDocNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.externalDocNumberDataGridViewTextBoxColumn.Width = 101;
            // 
            // externalDocDateDataGridViewTextBoxColumn
            // 
            this.externalDocDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.externalDocDateDataGridViewTextBoxColumn.DataPropertyName = "External_Doc_Date";
            this.externalDocDateDataGridViewTextBoxColumn.HeaderText = "Дата док-та";
            this.externalDocDateDataGridViewTextBoxColumn.Name = "externalDocDateDataGridViewTextBoxColumn";
            this.externalDocDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.externalDocDateDataGridViewTextBoxColumn.Width = 93;
            // 
            // sourceNameDataGridViewTextBoxColumn
            // 
            this.sourceNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sourceNameDataGridViewTextBoxColumn.DataPropertyName = "Source_Name";
            this.sourceNameDataGridViewTextBoxColumn.HeaderText = "Источник";
            this.sourceNameDataGridViewTextBoxColumn.Name = "sourceNameDataGridViewTextBoxColumn";
            this.sourceNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.sourceNameDataGridViewTextBoxColumn.Width = 80;
            // 
            // organisationNameDataGridViewTextBoxColumn
            // 
            this.organisationNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.organisationNameDataGridViewTextBoxColumn.DataPropertyName = "Organisation_Name";
            this.organisationNameDataGridViewTextBoxColumn.HeaderText = "Организация";
            this.organisationNameDataGridViewTextBoxColumn.Name = "organisationNameDataGridViewTextBoxColumn";
            this.organisationNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.organisationNameDataGridViewTextBoxColumn.Width = 99;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "Пользователь";
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            this.userDataGridViewTextBoxColumn.ReadOnly = true;
            this.userDataGridViewTextBoxColumn.Width = 105;
            // 
            // docCommentDataGridViewTextBoxColumn
            // 
            this.docCommentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.docCommentDataGridViewTextBoxColumn.DataPropertyName = "Doc_Comment";
            this.docCommentDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.docCommentDataGridViewTextBoxColumn.Name = "docCommentDataGridViewTextBoxColumn";
            this.docCommentDataGridViewTextBoxColumn.ReadOnly = true;
            this.docCommentDataGridViewTextBoxColumn.Width = 82;
            // 
            // cmsDocsTable
            // 
            this.cmsDocsTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefreshDocs});
            this.cmsDocsTable.Name = "cmsDocsTable";
            this.cmsDocsTable.Size = new System.Drawing.Size(212, 26);
            // 
            // miRefreshDocs
            // 
            this.miRefreshDocs.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefreshDocs.Name = "miRefreshDocs";
            this.miRefreshDocs.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefreshDocs.Size = new System.Drawing.Size(211, 22);
            this.miRefreshDocs.Text = "Обновить документы";
            this.miRefreshDocs.Click += new System.EventHandler(this.miRefreshDocs_Click);
            // 
            // bsBlGetDocsApproved
            // 
            this.bsBlGetDocsApproved.DataMember = "BL_Get_Docs_Approved";
            this.bsBlGetDocsApproved.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDocs
            // 
            this.lblDocs.AutoSize = true;
            this.lblDocs.Location = new System.Drawing.Point(3, 8);
            this.lblDocs.Name = "lblDocs";
            this.lblDocs.Size = new System.Drawing.Size(282, 13);
            this.lblDocs.TabIndex = 0;
            this.lblDocs.Text = "Документы блокировок, которые нужно подтвердить:";
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AllowUserToDeleteRows = false;
            this.dgvDetails.AllowUserToOrderColumns = true;
            this.dgvDetails.AllowUserToResizeRows = false;
            this.dgvDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetails.AutoGenerateColumns = false;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.holdtypeDataGridViewTextBoxColumn,
            this.itemidDataGridViewTextBoxColumn,
            this.itemnameDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vendorlotDataGridViewTextBoxColumn,
            this.lotnumberDataGridViewTextBoxColumn,
            this.warehouseidDataGridViewTextBoxColumn,
            this.datefromDataGridViewTextBoxColumn,
            this.datetoDataGridViewTextBoxColumn});
            this.dgvDetails.DataSource = this.bsBlGetDocsApprovedDetail;
            this.dgvDetails.Location = new System.Drawing.Point(6, 24);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(751, 181);
            this.dgvDetails.TabIndex = 1;
            // 
            // holdtypeDataGridViewTextBoxColumn
            // 
            this.holdtypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.holdtypeDataGridViewTextBoxColumn.DataPropertyName = "hold_type";
            this.holdtypeDataGridViewTextBoxColumn.HeaderText = "Тип блокировки";
            this.holdtypeDataGridViewTextBoxColumn.Name = "holdtypeDataGridViewTextBoxColumn";
            this.holdtypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.holdtypeDataGridViewTextBoxColumn.Width = 105;
            // 
            // itemidDataGridViewTextBoxColumn
            // 
            this.itemidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemidDataGridViewTextBoxColumn.DataPropertyName = "item_id";
            this.itemidDataGridViewTextBoxColumn.HeaderText = "Код товара";
            this.itemidDataGridViewTextBoxColumn.Name = "itemidDataGridViewTextBoxColumn";
            this.itemidDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemidDataGridViewTextBoxColumn.Width = 82;
            // 
            // itemnameDataGridViewTextBoxColumn
            // 
            this.itemnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemnameDataGridViewTextBoxColumn.DataPropertyName = "item_name";
            this.itemnameDataGridViewTextBoxColumn.HeaderText = "Наименование товара";
            this.itemnameDataGridViewTextBoxColumn.Name = "itemnameDataGridViewTextBoxColumn";
            this.itemnameDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemnameDataGridViewTextBoxColumn.Width = 133;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // vendorlotDataGridViewTextBoxColumn
            // 
            this.vendorlotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vendorlotDataGridViewTextBoxColumn.DataPropertyName = "vendor_lot";
            this.vendorlotDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.vendorlotDataGridViewTextBoxColumn.Name = "vendorlotDataGridViewTextBoxColumn";
            this.vendorlotDataGridViewTextBoxColumn.ReadOnly = true;
            this.vendorlotDataGridViewTextBoxColumn.Width = 63;
            // 
            // lotnumberDataGridViewTextBoxColumn
            // 
            this.lotnumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotnumberDataGridViewTextBoxColumn.DataPropertyName = "lot_number";
            this.lotnumberDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.lotnumberDataGridViewTextBoxColumn.Name = "lotnumberDataGridViewTextBoxColumn";
            this.lotnumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotnumberDataGridViewTextBoxColumn.Width = 69;
            // 
            // warehouseidDataGridViewTextBoxColumn
            // 
            this.warehouseidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.warehouseidDataGridViewTextBoxColumn.DataPropertyName = "warehouse_id";
            this.warehouseidDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseidDataGridViewTextBoxColumn.Name = "warehouseidDataGridViewTextBoxColumn";
            this.warehouseidDataGridViewTextBoxColumn.ReadOnly = true;
            this.warehouseidDataGridViewTextBoxColumn.Width = 63;
            // 
            // datefromDataGridViewTextBoxColumn
            // 
            this.datefromDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datefromDataGridViewTextBoxColumn.DataPropertyName = "date_from";
            this.datefromDataGridViewTextBoxColumn.HeaderText = "Дата с";
            this.datefromDataGridViewTextBoxColumn.Name = "datefromDataGridViewTextBoxColumn";
            this.datefromDataGridViewTextBoxColumn.ReadOnly = true;
            this.datefromDataGridViewTextBoxColumn.Width = 62;
            // 
            // datetoDataGridViewTextBoxColumn
            // 
            this.datetoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.datetoDataGridViewTextBoxColumn.DataPropertyName = "date_to";
            this.datetoDataGridViewTextBoxColumn.HeaderText = "Дата по";
            this.datetoDataGridViewTextBoxColumn.Name = "datetoDataGridViewTextBoxColumn";
            this.datetoDataGridViewTextBoxColumn.ReadOnly = true;
            this.datetoDataGridViewTextBoxColumn.Width = 68;
            // 
            // bsBlGetDocsApprovedDetail
            // 
            this.bsBlGetDocsApprovedDetail.DataMember = "BL_Get_Docs_Approved_Detail";
            this.bsBlGetDocsApprovedDetail.DataSource = this.quality;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Location = new System.Drawing.Point(3, 8);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(301, 13);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Неподтвержденные блокировки в выбранном документе:";
            // 
            // taBlGetDocsApproved
            // 
            this.taBlGetDocsApproved.ClearBeforeFill = true;
            // 
            // taBlGetDocsApprovedDetail
            // 
            this.taBlGetDocsApprovedDetail.ClearBeforeFill = true;
            // 
            // bgwDocsLoader
            // 
            this.bgwDocsLoader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDocsLoader_DoWork);
            this.bgwDocsLoader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDocsLoader_RunWorkerCompleted);
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Width = 80;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "Комментарий";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Doc_ID";
            this.dataGridViewTextBoxColumn2.HeaderText = "Код док-та";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Doc_Date";
            this.dataGridViewTextBoxColumn3.HeaderText = "Дата док-та";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "External_Doc_Number";
            this.dataGridViewTextBoxColumn4.HeaderText = "Номер док-та";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "External_Doc_Date";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата док-та";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Source_Name";
            this.dataGridViewTextBoxColumn6.HeaderText = "Источник";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Organisation_Name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Организация";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn8.HeaderText = "Пользователь";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Doc_Comment";
            this.dataGridViewTextBoxColumn9.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "hold_type";
            this.dataGridViewTextBoxColumn10.HeaderText = "Тип блокировки";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "item_id";
            this.dataGridViewTextBoxColumn11.HeaderText = "Код товара";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "item_name";
            this.dataGridViewTextBoxColumn12.HeaderText = "Наименование товара";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn13.DataPropertyName = "manufacturer";
            this.dataGridViewTextBoxColumn13.HeaderText = "Производитель";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "vendor_lot";
            this.dataGridViewTextBoxColumn14.HeaderText = "Серия";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "lot_number";
            this.dataGridViewTextBoxColumn15.HeaderText = "Партия";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn16.DataPropertyName = "warehouse_id";
            this.dataGridViewTextBoxColumn16.HeaderText = "Склад";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn17.DataPropertyName = "date_from";
            this.dataGridViewTextBoxColumn17.HeaderText = "Дата с";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn18.DataPropertyName = "date_to";
            this.dataGridViewTextBoxColumn18.HeaderText = "Дата по";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // BlockDocsApproveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.spcTwoGrids);
            this.Controls.Add(this.btnClose);
            this.MinimumSize = new System.Drawing.Size(375, 325);
            this.Name = "BlockDocsApproveForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Подтверждение блокировок";
            this.Load += new System.EventHandler(this.BlockDocsApproveForm_Load);
            this.spcTwoGrids.Panel1.ResumeLayout(false);
            this.spcTwoGrids.Panel1.PerformLayout();
            this.spcTwoGrids.Panel2.ResumeLayout(false);
            this.spcTwoGrids.Panel2.PerformLayout();
            this.spcTwoGrids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoading)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.cmsDocsTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocsApproved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBlGetDocsApprovedDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.SplitContainer spcTwoGrids;
        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.Label lblDocs;
        private System.Windows.Forms.BindingSource bsBlGetDocsApproved;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.BL_Get_Docs_ApprovedTableAdapter taBlGetDocsApproved;
        private System.Windows.Forms.DataGridViewButtonColumn clApprove;
        private System.Windows.Forms.DataGridViewButtonColumn clReject;
        private System.Windows.Forms.DataGridViewTextBoxColumn clComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn docIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalDocNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn externalDocDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn organisationNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docCommentDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource bsBlGetDocsApprovedDetail;
        private WMSOffice.Data.QualityTableAdapters.BL_Get_Docs_Approved_DetailTableAdapter taBlGetDocsApprovedDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn holdtypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorlotDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotnumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datefromDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datetoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.PictureBox pbLoading;
        private System.ComponentModel.BackgroundWorker bgwDocsLoader;
        private System.Windows.Forms.ContextMenuStrip cmsDocsTable;
        private System.Windows.Forms.ToolStripMenuItem miRefreshDocs;
    }
}