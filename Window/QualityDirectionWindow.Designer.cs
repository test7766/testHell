namespace WMSOffice.Window
{
    partial class QualityDirectionWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QualityDirectionWindow));
            this.spcTools = new System.Windows.Forms.SplitContainer();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.tsButtonsDetails = new System.Windows.Forms.ToolStrip();
            this.btnItemsTable = new System.Windows.Forms.ToolStripButton();
            this.btnReadyDocs = new System.Windows.Forms.ToolStripButton();
            this.spbIntermediateStages = new System.Windows.Forms.ToolStripSplitButton();
            this.miDateSamplesRequest = new System.Windows.Forms.ToolStripMenuItem();
            this.miSamplesPurchase = new System.Windows.Forms.ToolStripMenuItem();
            this.miSamplesComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvLines = new System.Windows.Forms.DataGridView();
            this.clDdDocID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdLineID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdStatusID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdItemId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdVendorLot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdManufacturerPlant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdMode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDdQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHasItemsTableStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clHasDocsReadyStr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateSamplesRequest = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateSamplesPurchase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clDateSamplesComplete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.tssAfterMiRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.miCreateDirection = new System.Windows.Forms.ToolStripMenuItem();
            this.bsDrDocRows = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.bsDrDocs = new System.Windows.Forms.BindingSource(this.components);
            this.tsButtonsDocs = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateDirection = new System.Windows.Forms.ToolStripButton();
            this.tssAfterCreateDirection = new System.Windows.Forms.ToolStripSeparator();
            this.btnCollect = new System.Windows.Forms.ToolStripButton();
            this.btnMoveItems = new System.Windows.Forms.ToolStripButton();
            this.btnToPannedCar = new System.Windows.Forms.ToolStripButton();
            this.btnReceiveItems = new System.Windows.Forms.ToolStripButton();
            this.btnCancelDirection = new System.Windows.Forms.ToolStripButton();
            this.tbxSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.spcTables = new System.Windows.Forms.SplitContainer();
            this.chbShowArchived = new System.Windows.Forms.CheckBox();
            this.taDrDocs = new WMSOffice.Data.QualityTableAdapters.DRDocsTableAdapter();
            this.taDrDocRows = new WMSOffice.Data.QualityTableAdapters.DRDocRowsTableAdapter();
            this.spcTools.Panel1.SuspendLayout();
            this.spcTools.Panel2.SuspendLayout();
            this.spcTools.SuspendLayout();
            this.tsButtonsDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).BeginInit();
            this.cmsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocs)).BeginInit();
            this.tsButtonsDocs.SuspendLayout();
            this.spcTables.Panel1.SuspendLayout();
            this.spcTables.Panel2.SuspendLayout();
            this.spcTables.SuspendLayout();
            this.SuspendLayout();
            // 
            // spcTools
            // 
            this.spcTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcTools.Location = new System.Drawing.Point(0, 94);
            this.spcTools.Name = "spcTools";
            this.spcTools.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcTools.Panel1
            // 
            this.spcTools.Panel1.Controls.Add(this.xdgvDocs);
            // 
            // spcTools.Panel2
            // 
            this.spcTools.Panel2.Controls.Add(this.tsButtonsDetails);
            this.spcTools.Panel2.Controls.Add(this.dgvLines);
            this.spcTools.Size = new System.Drawing.Size(1163, 402);
            this.spcTools.SplitterDistance = 228;
            this.spcTools.TabIndex = 5;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 0);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(1163, 228);
            this.xdgvDocs.TabIndex = 31;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // tsButtonsDetails
            // 
            this.tsButtonsDetails.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsButtonsDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnItemsTable,
            this.btnReadyDocs,
            this.spbIntermediateStages});
            this.tsButtonsDetails.Location = new System.Drawing.Point(0, 0);
            this.tsButtonsDetails.Name = "tsButtonsDetails";
            this.tsButtonsDetails.Size = new System.Drawing.Size(1163, 39);
            this.tsButtonsDetails.TabIndex = 40;
            this.tsButtonsDetails.Text = "toolStrip1";
            // 
            // btnItemsTable
            // 
            this.btnItemsTable.Image = global::WMSOffice.Properties.Resources.checklist;
            this.btnItemsTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItemsTable.Name = "btnItemsTable";
            this.btnItemsTable.Size = new System.Drawing.Size(134, 36);
            this.btnItemsTable.Text = "Є таблиця зразків";
            this.btnItemsTable.ToolTipText = "Внести в систему факт заповнення постачальником таблиці зразків для товару в напр" +
                "авленні";
            this.btnItemsTable.Click += new System.EventHandler(this.DocsDetailAction_Click);
            // 
            // btnReadyDocs
            // 
            this.btnReadyDocs.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnReadyDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReadyDocs.Name = "btnReadyDocs";
            this.btnReadyDocs.Size = new System.Drawing.Size(133, 36);
            this.btnReadyDocs.Text = "Документи готові";
            this.btnReadyDocs.ToolTipText = "Внести в систему факт підготовки документів по товару в направленні";
            this.btnReadyDocs.Click += new System.EventHandler(this.DocsDetailAction_Click);
            // 
            // spbIntermediateStages
            // 
            this.spbIntermediateStages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDateSamplesRequest,
            this.miSamplesPurchase,
            this.miSamplesComplete});
            this.spbIntermediateStages.Image = global::WMSOffice.Properties.Resources.antivirus;
            this.spbIntermediateStages.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.spbIntermediateStages.Name = "spbIntermediateStages";
            this.spbIntermediateStages.Size = new System.Drawing.Size(90, 36);
            this.spbIntermediateStages.Text = "Зразки";
            this.spbIntermediateStages.ToolTipText = "Проміжні етапи аналізу";
            // 
            // miDateSamplesRequest
            // 
            this.miDateSamplesRequest.Name = "miDateSamplesRequest";
            this.miDateSamplesRequest.Size = new System.Drawing.Size(252, 22);
            this.miDateSamplesRequest.Text = "Зразки запрошені у постачальника";
            this.miDateSamplesRequest.Click += new System.EventHandler(this.DocsDetailAction_Click);
            // 
            // miSamplesPurchase
            // 
            this.miSamplesPurchase.Name = "miSamplesPurchase";
            this.miSamplesPurchase.Size = new System.Drawing.Size(252, 22);
            this.miSamplesPurchase.Text = "Розпочато закупівлю зразків";
            this.miSamplesPurchase.Click += new System.EventHandler(this.DocsDetailAction_Click);
            // 
            // miSamplesComplete
            // 
            this.miSamplesComplete.Name = "miSamplesComplete";
            this.miSamplesComplete.Size = new System.Drawing.Size(252, 22);
            this.miSamplesComplete.Text = "Зразки закуплені";
            this.miSamplesComplete.Click += new System.EventHandler(this.DocsDetailAction_Click);
            // 
            // dgvLines
            // 
            this.dgvLines.AllowUserToAddRows = false;
            this.dgvLines.AllowUserToDeleteRows = false;
            this.dgvLines.AllowUserToResizeRows = false;
            this.dgvLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLines.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLines.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clDdDocID,
            this.clDdLineID,
            this.clDdStatusID,
            this.clDdItemId,
            this.clDdItemName,
            this.clDdVendorLot,
            this.clDdManufacturer,
            this.clDdManufacturerPlant,
            this.clDdMode,
            this.clDdQuantity,
            this.clHasItemsTableStr,
            this.clHasDocsReadyStr,
            this.clDateSamplesRequest,
            this.clDateSamplesPurchase,
            this.clDateSamplesComplete});
            this.dgvLines.ContextMenuStrip = this.cmsDocs;
            this.dgvLines.DataSource = this.bsDrDocRows;
            this.dgvLines.Location = new System.Drawing.Point(0, 42);
            this.dgvLines.Name = "dgvLines";
            this.dgvLines.ReadOnly = true;
            this.dgvLines.RowHeadersVisible = false;
            this.dgvLines.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dgvLines.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Black;
            this.dgvLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLines.Size = new System.Drawing.Size(1163, 128);
            this.dgvLines.TabIndex = 50;
            this.dgvLines.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvLines_DataBindingComplete);
            this.dgvLines.SelectionChanged += new System.EventHandler(this.dgvLines_SelectionChanged);
            // 
            // clDdDocID
            // 
            this.clDdDocID.DataPropertyName = "Doc_ID";
            this.clDdDocID.HeaderText = "Заява";
            this.clDdDocID.Name = "clDdDocID";
            this.clDdDocID.ReadOnly = true;
            this.clDdDocID.Width = 80;
            // 
            // clDdLineID
            // 
            this.clDdLineID.DataPropertyName = "Line_ID";
            this.clDdLineID.HeaderText = "№ рядка";
            this.clDdLineID.Name = "clDdLineID";
            this.clDdLineID.ReadOnly = true;
            this.clDdLineID.Width = 80;
            // 
            // clDdStatusID
            // 
            this.clDdStatusID.DataPropertyName = "Status_ID";
            this.clDdStatusID.HeaderText = "Ст.";
            this.clDdStatusID.Name = "clDdStatusID";
            this.clDdStatusID.ReadOnly = true;
            this.clDdStatusID.Width = 60;
            // 
            // clDdItemId
            // 
            this.clDdItemId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdItemId.DataPropertyName = "Item_ID";
            this.clDdItemId.HeaderText = "Код товару";
            this.clDdItemId.Name = "clDdItemId";
            this.clDdItemId.ReadOnly = true;
            this.clDdItemId.Width = 98;
            // 
            // clDdItemName
            // 
            this.clDdItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdItemName.DataPropertyName = "ItemName";
            this.clDdItemName.HeaderText = "Назва товару";
            this.clDdItemName.Name = "clDdItemName";
            this.clDdItemName.ReadOnly = true;
            this.clDdItemName.Width = 112;
            // 
            // clDdVendorLot
            // 
            this.clDdVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdVendorLot.DataPropertyName = "VendorLot";
            this.clDdVendorLot.HeaderText = "Серія";
            this.clDdVendorLot.Name = "clDdVendorLot";
            this.clDdVendorLot.ReadOnly = true;
            this.clDdVendorLot.Width = 69;
            // 
            // clDdManufacturer
            // 
            this.clDdManufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdManufacturer.DataPropertyName = "Manufacturer";
            this.clDdManufacturer.HeaderText = "Виробник";
            this.clDdManufacturer.Name = "clDdManufacturer";
            this.clDdManufacturer.ReadOnly = true;
            this.clDdManufacturer.Width = 97;
            // 
            // clDdManufacturerPlant
            // 
            this.clDdManufacturerPlant.DataPropertyName = "ManufacturerPlant";
            this.clDdManufacturerPlant.HeaderText = "Завод";
            this.clDdManufacturerPlant.Name = "clDdManufacturerPlant";
            this.clDdManufacturerPlant.ReadOnly = true;
            this.clDdManufacturerPlant.Width = 300;
            // 
            // clDdMode
            // 
            this.clDdMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdMode.DataPropertyName = "Mode";
            this.clDdMode.HeaderText = "Режим";
            this.clDdMode.Name = "clDdMode";
            this.clDdMode.ReadOnly = true;
            this.clDdMode.Width = 76;
            // 
            // clDdQuantity
            // 
            this.clDdQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clDdQuantity.DataPropertyName = "Quantity";
            this.clDdQuantity.HeaderText = "Кіл-ть";
            this.clDdQuantity.Name = "clDdQuantity";
            this.clDdQuantity.ReadOnly = true;
            this.clDdQuantity.Width = 72;
            // 
            // clHasItemsTableStr
            // 
            this.clHasItemsTableStr.DataPropertyName = "Has_Items_Table_Str";
            this.clHasItemsTableStr.HeaderText = "Таблиця зразків";
            this.clHasItemsTableStr.Name = "clHasItemsTableStr";
            this.clHasItemsTableStr.ReadOnly = true;
            // 
            // clHasDocsReadyStr
            // 
            this.clHasDocsReadyStr.DataPropertyName = "Has_Docs_Ready_Str";
            this.clHasDocsReadyStr.HeaderText = "Готові документи";
            this.clHasDocsReadyStr.Name = "clHasDocsReadyStr";
            this.clHasDocsReadyStr.ReadOnly = true;
            // 
            // clDateSamplesRequest
            // 
            this.clDateSamplesRequest.DataPropertyName = "Date_Samples_Request";
            this.clDateSamplesRequest.HeaderText = "Запит на зразки";
            this.clDateSamplesRequest.Name = "clDateSamplesRequest";
            this.clDateSamplesRequest.ReadOnly = true;
            // 
            // clDateSamplesPurchase
            // 
            this.clDateSamplesPurchase.DataPropertyName = "Date_Samples_Purchase";
            this.clDateSamplesPurchase.HeaderText = "Розпочато закупівлю зразків";
            this.clDateSamplesPurchase.Name = "clDateSamplesPurchase";
            this.clDateSamplesPurchase.ReadOnly = true;
            this.clDateSamplesPurchase.Width = 120;
            // 
            // clDateSamplesComplete
            // 
            this.clDateSamplesComplete.DataPropertyName = "Date_Samples_Complete";
            this.clDateSamplesComplete.HeaderText = "Зразки закуплені";
            this.clDateSamplesComplete.Name = "clDateSamplesComplete";
            this.clDateSamplesComplete.ReadOnly = true;
            // 
            // cmsDocs
            // 
            this.cmsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.tssAfterMiRefresh,
            this.miCreateDirection});
            this.cmsDocs.Name = "contextMenuStrip1";
            this.cmsDocs.Size = new System.Drawing.Size(229, 54);
            // 
            // miRefresh
            // 
            this.miRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(228, 22);
            this.miRefresh.Text = "Оновити";
            this.miRefresh.ToolTipText = "Оновити таблицю направлень з БД";
            this.miRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterMiRefresh
            // 
            this.tssAfterMiRefresh.Name = "tssAfterMiRefresh";
            this.tssAfterMiRefresh.Size = new System.Drawing.Size(225, 6);
            // 
            // miCreateDirection
            // 
            this.miCreateDirection.Image = global::WMSOffice.Properties.Resources.F2;
            this.miCreateDirection.Name = "miCreateDirection";
            this.miCreateDirection.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.miCreateDirection.Size = new System.Drawing.Size(228, 22);
            this.miCreateDirection.Text = "Створити нове направлення";
            this.miCreateDirection.Click += new System.EventHandler(this.CreateDirection_Click);
            // 
            // bsDrDocRows
            // 
            this.bsDrDocRows.DataMember = "DRDocRows";
            this.bsDrDocRows.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsDrDocs
            // 
            this.bsDrDocs.DataMember = "DRDocs";
            this.bsDrDocs.DataSource = this.quality;
            // 
            // tsButtonsDocs
            // 
            this.tsButtonsDocs.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsButtonsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.btnCreateDirection,
            this.tssAfterCreateDirection,
            this.btnCollect,
            this.btnReceiveItems,
            this.btnMoveItems,
            this.btnToPannedCar,
            this.btnCancelDirection});
            this.tsButtonsDocs.Location = new System.Drawing.Point(0, 0);
            this.tsButtonsDocs.Name = "tsButtonsDocs";
            this.tsButtonsDocs.Size = new System.Drawing.Size(900, 55);
            this.tsButtonsDocs.TabIndex = 10;
            this.tsButtonsDocs.Text = "Панель інструментів документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.ToolTipText = "Оновити таблицю направлень з БД";
            this.btnRefresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateDirection
            // 
            this.btnCreateDirection.Image = global::WMSOffice.Properties.Resources.F2;
            this.btnCreateDirection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateDirection.Name = "btnCreateDirection";
            this.btnCreateDirection.Size = new System.Drawing.Size(125, 52);
            this.btnCreateDirection.Text = "Створити нове\n\rнаправлення";
            this.btnCreateDirection.Click += new System.EventHandler(this.CreateDirection_Click);
            // 
            // tssAfterCreateDirection
            // 
            this.tssAfterCreateDirection.Name = "tssAfterCreateDirection";
            this.tssAfterCreateDirection.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCollect
            // 
            this.btnCollect.Image = global::WMSOffice.Properties.Resources.drug_basket;
            this.btnCollect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCollect.Name = "btnCollect";
            this.btnCollect.Size = new System.Drawing.Size(173, 52);
            this.btnCollect.Text = "Сформувати завдання\n\rна відбір зразків";
            this.btnCollect.Visible = false;
            this.btnCollect.Click += new System.EventHandler(this.btnCollect_Click);
            // 
            // btnMoveItems
            // 
            this.btnMoveItems.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnMoveItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMoveItems.Name = "btnMoveItems";
            this.btnMoveItems.Size = new System.Drawing.Size(108, 52);
            this.btnMoveItems.Text = "Зразки\nпередано";
            this.btnMoveItems.Click += new System.EventHandler(this.MoveItems_Click);
            // 
            // btnToPannedCar
            // 
            this.btnToPannedCar.Image = ((System.Drawing.Image)(resources.GetObject("btnToPannedCar.Image")));
            this.btnToPannedCar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToPannedCar.Name = "btnToPannedCar";
            this.btnToPannedCar.Size = new System.Drawing.Size(116, 52);
            this.btnToPannedCar.Text = "Відправити\nплановою\nмашиною";
            this.btnToPannedCar.ToolTipText = "Натисніть на кнопку, щоб перевести направлення на статус 218 (\"Передано плановою " +
                "машиною\")";
            this.btnToPannedCar.Click += new System.EventHandler(this.MoveItems_Click);
            // 
            // btnReceiveItems
            // 
            this.btnReceiveItems.Image = global::WMSOffice.Properties.Resources.barcode;
            this.btnReceiveItems.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReceiveItems.Name = "btnReceiveItems";
            this.btnReceiveItems.Size = new System.Drawing.Size(109, 52);
            this.btnReceiveItems.Text = "Отримати\nтовар";
            this.btnReceiveItems.ToolTipText = "Відсканувати штрих-код ящика з товаром для лабораторії";
            this.btnReceiveItems.Click += new System.EventHandler(this.btnReceiveItems_Click);
            // 
            // btnCancelDirection
            // 
            this.btnCancelDirection.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnCancelDirection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelDirection.Name = "btnCancelDirection";
            this.btnCancelDirection.Size = new System.Drawing.Size(117, 52);
            this.btnCancelDirection.Text = "Анулювати";
            this.btnCancelDirection.ToolTipText = "Анулювати створене направлення";
            this.btnCancelDirection.Click += new System.EventHandler(this.btnCancelDirection_Click);
            // 
            // tbxSearch
            // 
            this.tbxSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxSearch.Location = new System.Drawing.Point(6, 28);
            this.tbxSearch.Name = "tbxSearch";
            this.tbxSearch.Size = new System.Drawing.Size(239, 20);
            this.tbxSearch.TabIndex = 20;
            this.tbxSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbxSearch_KeyDown);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(3, 7);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(95, 13);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Пошук по товару:";
            // 
            // spcTables
            // 
            this.spcTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.spcTables.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.spcTables.IsSplitterFixed = true;
            this.spcTables.Location = new System.Drawing.Point(0, 40);
            this.spcTables.Name = "spcTables";
            // 
            // spcTables.Panel1
            // 
            this.spcTables.Panel1.Controls.Add(this.tsButtonsDocs);
            // 
            // spcTables.Panel2
            // 
            this.spcTables.Panel2.Controls.Add(this.chbShowArchived);
            this.spcTables.Panel2.Controls.Add(this.tbxSearch);
            this.spcTables.Panel2.Controls.Add(this.lblSearch);
            this.spcTables.Size = new System.Drawing.Size(1163, 54);
            this.spcTables.SplitterDistance = 900;
            this.spcTables.TabIndex = 6;
            // 
            // chbShowArchived
            // 
            this.chbShowArchived.AutoSize = true;
            this.chbShowArchived.Location = new System.Drawing.Point(104, 7);
            this.chbShowArchived.Name = "chbShowArchived";
            this.chbShowArchived.Size = new System.Drawing.Size(126, 17);
            this.chbShowArchived.TabIndex = 19;
            this.chbShowArchived.Text = "Відображати архівні";
            this.chbShowArchived.UseVisualStyleBackColor = true;
            // 
            // taDrDocs
            // 
            this.taDrDocs.ClearBeforeFill = true;
            // 
            // taDrDocRows
            // 
            this.taDrDocRows.ClearBeforeFill = true;
            // 
            // QualityDirectionWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1163, 496);
            this.Controls.Add(this.spcTools);
            this.Controls.Add(this.spcTables);
            this.Name = "QualityDirectionWindow";
            this.Text = "Работа з направленнями";
            this.Load += new System.EventHandler(this.QualityRequestWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.QualityDirectionWindow_FormClosing);
            this.Controls.SetChildIndex(this.spcTables, 0);
            this.Controls.SetChildIndex(this.spcTools, 0);
            this.spcTools.Panel1.ResumeLayout(false);
            this.spcTools.Panel2.ResumeLayout(false);
            this.spcTools.Panel2.PerformLayout();
            this.spcTools.ResumeLayout(false);
            this.tsButtonsDetails.ResumeLayout(false);
            this.tsButtonsDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLines)).EndInit();
            this.cmsDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDrDocs)).EndInit();
            this.tsButtonsDocs.ResumeLayout(false);
            this.tsButtonsDocs.PerformLayout();
            this.spcTables.Panel1.ResumeLayout(false);
            this.spcTables.Panel1.PerformLayout();
            this.spcTables.Panel2.ResumeLayout(false);
            this.spcTables.Panel2.PerformLayout();
            this.spcTables.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcTools;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.DataGridView dgvLines;
        private System.Windows.Forms.ContextMenuStrip cmsDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedOrderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn relatedPoSoNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorInvoiceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorInvoiceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDrDocs;
        private WMSOffice.Data.QualityTableAdapters.DRDocsTableAdapter taDrDocs;
        private System.Windows.Forms.DataGridViewTextBoxColumn uSersDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bsDrDocRows;
        private WMSOffice.Data.QualityTableAdapters.DRDocRowsTableAdapter taDrDocRows;
        private System.Windows.Forms.ToolStripMenuItem miCreateDirection;
        private System.Windows.Forms.SplitContainer spcTables;
        private System.Windows.Forms.ToolStrip tsButtonsDocs;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.ToolStripButton btnCreateDirection;
        private System.Windows.Forms.ToolStripSeparator tssAfterCreateDirection;
        private System.Windows.Forms.ToolStripButton btnCollect;
        private System.Windows.Forms.TextBox tbxSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.ToolStripButton btnToPannedCar;
        private System.Windows.Forms.ToolStripSeparator tssAfterMiRefresh;
        private System.Windows.Forms.ToolStrip tsButtonsDetails;
        private System.Windows.Forms.ToolStripButton btnItemsTable;
        private System.Windows.Forms.ToolStripButton btnReadyDocs;
        private System.Windows.Forms.ToolStripSplitButton spbIntermediateStages;
        private System.Windows.Forms.ToolStripMenuItem miDateSamplesRequest;
        private System.Windows.Forms.ToolStripMenuItem miSamplesPurchase;
        private System.Windows.Forms.ToolStripMenuItem miSamplesComplete;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdDocID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdLineID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdStatusID;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdItemId;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdVendorLot;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdManufacturerPlant;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdMode;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDdQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHasItemsTableStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clHasDocsReadyStr;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateSamplesRequest;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateSamplesPurchase;
        private System.Windows.Forms.DataGridViewTextBoxColumn clDateSamplesComplete;
        private System.Windows.Forms.ToolStripButton btnReceiveItems;
        private System.Windows.Forms.ToolStripButton btnMoveItems;
        private System.Windows.Forms.ToolStripButton btnCancelDirection;
        private System.Windows.Forms.CheckBox chbShowArchived;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
    }
}