namespace WMSOffice.Window
{
    partial class WriteOffStuffsWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WriteOffStuffsWindow));
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.tssAfterRefresh = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.btnAddDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCalc = new System.Windows.Forms.ToolStripButton();
            this.btnExportConsCalc = new System.Windows.Forms.ToolStripButton();
            this.btnAccept = new System.Windows.Forms.ToolStripButton();
            this.btnEditDoc = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.tssAfterSave = new System.Windows.Forms.ToolStripSeparator();
            this.btnHoldDoc = new System.Windows.Forms.ToolStripButton();
            this.tssAfterHold = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintDocs = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPackList = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.btnDestructionRequest = new System.Windows.Forms.ToolStripButton();
            this.tssAfterPrint = new System.Windows.Forms.ToolStripSeparator();
            this.btnSplit = new System.Windows.Forms.ToolStripButton();
            this.btnShowState = new System.Windows.Forms.ToolStripButton();
            this.btnCalcExport = new System.Windows.Forms.ToolStripButton();
            this.btnInvoice = new System.Windows.Forms.ToolStripButton();
            this.btnArchive = new System.Windows.Forms.ToolStripButton();
            this.cmsDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCreateRequestDestruction = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiSimpleAct = new System.Windows.Forms.ToolStripMenuItem();
            this.cmiExportDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.wH = new WMSOffice.Data.WH();
            this.bsWfGetDocs = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetDocs = new WMSOffice.Data.WHTableAdapters.WF_GetDocsTableAdapter();
            this.spcMain = new System.Windows.Forms.SplitContainer();
            this.dgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.dgvStatus = new System.Windows.Forms.DataGridView();
            this.statusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wFStatusesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wF = new WMSOffice.Data.WF();
            this.lblDetails = new System.Windows.Forms.Label();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.lineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.locationIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vATDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UOM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.basePriceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MOZ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vendor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsDocDetails = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miSplit = new System.Windows.Forms.ToolStripMenuItem();
            this.bsWfGetDocsDetail = new System.Windows.Forms.BindingSource(this.components);
            this.taWfGetDocs_Detail = new WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter();
            this.wF_StatusesTableAdapter = new WMSOffice.Data.WFTableAdapters.WF_StatusesTableAdapter();
            this.tsFilter = new System.Windows.Forms.ToolStrip();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.toolStripDoc.SuspendLayout();
            this.cmsDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocs)).BeginInit();
            this.spcMain.Panel1.SuspendLayout();
            this.spcMain.Panel2.SuspendLayout();
            this.spcMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wFStatusesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            this.cmsDocDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.tssAfterRefresh,
            this.btnShowAttachments,
            this.btnAddDoc,
            this.btnCalc,
            this.btnExportConsCalc,
            this.btnAccept,
            this.btnEditDoc,
            this.btnSave,
            this.btnDelete,
            this.tssAfterSave,
            this.btnHoldDoc,
            this.tssAfterHold,
            this.btnPrintDocs,
            this.btnPrintPackList,
            this.cmbPrinters,
            this.btnDestructionRequest,
            this.tssAfterPrint,
            this.btnSplit,
            this.btnShowState,
            this.btnCalcExport,
            this.btnInvoice,
            this.btnArchive});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1679, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "toolStripButton1";
            this.btnRefresh.ToolTipText = "Обновить таблицу макетов списания";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // tssAfterRefresh
            // 
            this.tssAfterRefresh.Name = "tssAfterRefresh";
            this.tssAfterRefresh.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(94, 52);
            this.btnShowAttachments.Text = "Прикр.\nфайли";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // btnAddDoc
            // 
            this.btnAddDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDoc.Image")));
            this.btnAddDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDoc.Name = "btnAddDoc";
            this.btnAddDoc.Size = new System.Drawing.Size(124, 52);
            this.btnAddDoc.Text = "Создать\nновый макет";
            this.btnAddDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddDoc.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Image = ((System.Drawing.Image)(resources.GetObject("btnCalc.Image")));
            this.btnCalc.ImageTransparentColor = System.Drawing.Color.White;
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(121, 52);
            this.btnCalc.Text = "Расчет\nпоставщика";
            this.btnCalc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnExportConsCalc
            // 
            this.btnExportConsCalc.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportConsCalc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportConsCalc.Name = "btnExportConsCalc";
            this.btnExportConsCalc.Size = new System.Drawing.Size(125, 52);
            this.btnExportConsCalc.Text = "Конс. расчет\nпоставщика";
            this.btnExportConsCalc.Click += new System.EventHandler(this.btnExportConsCalc_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Image = ((System.Drawing.Image)(resources.GetObject("btnAccept.Image")));
            this.btnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(115, 52);
            this.btnAccept.Text = "Утвердить\nмакет";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // btnEditDoc
            // 
            this.btnEditDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnEditDoc.Image")));
            this.btnEditDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditDoc.Name = "btnEditDoc";
            this.btnEditDoc.Size = new System.Drawing.Size(138, 52);
            this.btnEditDoc.Text = "Редактировать\nмакет";
            this.btnEditDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditDoc.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 52);
            this.btnSave.Text = "Сохранить\nмакет";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(103, 52);
            this.btnDelete.Text = "Удалить\nмакет";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tssAfterSave
            // 
            this.tssAfterSave.Name = "tssAfterSave";
            this.tssAfterSave.Size = new System.Drawing.Size(6, 55);
            // 
            // btnHoldDoc
            // 
            this.btnHoldDoc.Image = ((System.Drawing.Image)(resources.GetObject("btnHoldDoc.Image")));
            this.btnHoldDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoldDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnHoldDoc.Name = "btnHoldDoc";
            this.btnHoldDoc.Size = new System.Drawing.Size(108, 52);
            this.btnHoldDoc.Text = "Провести\nдокумент";
            this.btnHoldDoc.Click += new System.EventHandler(this.btnHoldDoc_Click);
            // 
            // tssAfterHold
            // 
            this.tssAfterHold.Name = "tssAfterHold";
            this.tssAfterHold.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintDocs
            // 
            this.btnPrintDocs.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintDocs.Image")));
            this.btnPrintDocs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintDocs.Name = "btnPrintDocs";
            this.btnPrintDocs.Size = new System.Drawing.Size(120, 52);
            this.btnPrintDocs.Text = "Печать\nдокументов\nсписания";
            this.btnPrintDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintDocs.Click += new System.EventHandler(this.btnPrintDocs_Click);
            // 
            // btnPrintPackList
            // 
            this.btnPrintPackList.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintPackList.Image")));
            this.btnPrintPackList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintPackList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPackList.Name = "btnPrintPackList";
            this.btnPrintPackList.Size = new System.Drawing.Size(117, 52);
            this.btnPrintPackList.Text = "Печать\nсборочного";
            this.btnPrintPackList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintPackList.ToolTipText = "Печать сборочного листа на выбранном принтере";
            this.btnPrintPackList.Click += new System.EventHandler(this.btnPrintPackList_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 55);
            // 
            // btnDestructionRequest
            // 
            this.btnDestructionRequest.Image = ((System.Drawing.Image)(resources.GetObject("btnDestructionRequest.Image")));
            this.btnDestructionRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDestructionRequest.Name = "btnDestructionRequest";
            this.btnDestructionRequest.Size = new System.Drawing.Size(142, 52);
            this.btnDestructionRequest.Text = "Экспорт заявок\nна уничтожение";
            this.btnDestructionRequest.Click += new System.EventHandler(this.btnDestructionRequest_Click);
            // 
            // tssAfterPrint
            // 
            this.tssAfterPrint.Name = "tssAfterPrint";
            this.tssAfterPrint.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSplit
            // 
            this.btnSplit.Image = ((System.Drawing.Image)(resources.GetObject("btnSplit.Image")));
            this.btnSplit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(124, 52);
            this.btnSplit.Text = "Выделить в\nновый макет";
            this.btnSplit.ToolTipText = "Создать новый макет списания и перенести туда выделенные строки";
            this.btnSplit.Click += new System.EventHandler(this.Split_Click);
            // 
            // btnShowState
            // 
            this.btnShowState.Image = ((System.Drawing.Image)(resources.GetObject("btnShowState.Image")));
            this.btnShowState.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowState.Name = "btnShowState";
            this.btnShowState.Size = new System.Drawing.Size(153, 52);
            this.btnShowState.Text = "Статус документа";
            this.btnShowState.Click += new System.EventHandler(this.ShowState_Click);
            // 
            // btnCalcExport
            // 
            this.btnCalcExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnCalcExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCalcExport.Name = "btnCalcExport";
            this.btnCalcExport.Size = new System.Drawing.Size(145, 52);
            this.btnCalcExport.Text = "Экспорт расчета";
            this.btnCalcExport.Click += new System.EventHandler(this.btnCalcExport_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Image = global::WMSOffice.Properties.Resources.Invoice;
            this.btnInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(84, 52);
            this.btnInvoice.Text = "Счет";
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Image = global::WMSOffice.Properties.Resources.box;
            this.btnArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(110, 52);
            this.btnArchive.Text = "Архивные\nзаявки";
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // cmsDocs
            // 
            this.cmsDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCreateRequestDestruction,
            this.cmiSimpleAct,
            this.cmiExportDocs});
            this.cmsDocs.Name = "cmsDocs";
            this.cmsDocs.Size = new System.Drawing.Size(300, 70);
            // 
            // miCreateRequestDestruction
            // 
            this.miCreateRequestDestruction.Image = ((System.Drawing.Image)(resources.GetObject("miCreateRequestDestruction.Image")));
            this.miCreateRequestDestruction.Name = "miCreateRequestDestruction";
            this.miCreateRequestDestruction.Size = new System.Drawing.Size(299, 22);
            this.miCreateRequestDestruction.Text = "Экспорт заявки на уничтожение";
            this.miCreateRequestDestruction.Click += new System.EventHandler(this.miCreateRequestDestruction_Click);
            // 
            // cmiSimpleAct
            // 
            this.cmiSimpleAct.Image = ((System.Drawing.Image)(resources.GetObject("cmiSimpleAct.Image")));
            this.cmiSimpleAct.Name = "cmiSimpleAct";
            this.cmiSimpleAct.Size = new System.Drawing.Size(299, 22);
            this.cmiSimpleAct.Text = "Формирования акта отдельным документом";
            this.cmiSimpleAct.Click += new System.EventHandler(this.cmiSimpleAct_Click);
            // 
            // cmiExportDocs
            // 
            this.cmiExportDocs.Image = global::WMSOffice.Properties.Resources.Excel;
            this.cmiExportDocs.Name = "cmiExportDocs";
            this.cmiExportDocs.Size = new System.Drawing.Size(299, 22);
            this.cmiExportDocs.Text = "Экспорт в Excel ";
            this.cmiExportDocs.Click += new System.EventHandler(this.cmiExportDocs_Click);
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bsWfGetDocs
            // 
            this.bsWfGetDocs.DataMember = "WF_GetDocs";
            this.bsWfGetDocs.DataSource = this.wH;
            // 
            // taWfGetDocs
            // 
            this.taWfGetDocs.ClearBeforeFill = true;
            // 
            // spcMain
            // 
            this.spcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMain.Location = new System.Drawing.Point(0, 0);
            this.spcMain.Name = "spcMain";
            this.spcMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMain.Panel1
            // 
            this.spcMain.Panel1.Controls.Add(this.dgvDocs);
            this.spcMain.Panel1.Controls.Add(this.dgvStatus);
            // 
            // spcMain.Panel2
            // 
            this.spcMain.Panel2.Controls.Add(this.lblDetails);
            this.spcMain.Panel2.Controls.Add(this.dgvDetails);
            this.spcMain.Size = new System.Drawing.Size(1679, 499);
            this.spcMain.SplitterDistance = 249;
            this.spcMain.TabIndex = 3;
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowSort = true;
            this.dgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvDocs.ContextMenuStrip = this.cmsDocs;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.LargeAmountOfData = false;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.Name = "dgvDocs";
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.Size = new System.Drawing.Size(1439, 249);
            this.dgvDocs.TabIndex = 2;
            this.dgvDocs.UserID = ((long)(0));
            // 
            // dgvStatus
            // 
            this.dgvStatus.AllowUserToAddRows = false;
            this.dgvStatus.AllowUserToDeleteRows = false;
            this.dgvStatus.AutoGenerateColumns = false;
            this.dgvStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusIDDataGridViewTextBoxColumn,
            this.statusNameDataGridViewTextBoxColumn});
            this.dgvStatus.DataSource = this.wFStatusesBindingSource;
            this.dgvStatus.Dock = System.Windows.Forms.DockStyle.Right;
            this.dgvStatus.Location = new System.Drawing.Point(1439, 0);
            this.dgvStatus.Name = "dgvStatus";
            this.dgvStatus.ReadOnly = true;
            this.dgvStatus.RowHeadersWidth = 10;
            this.dgvStatus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStatus.Size = new System.Drawing.Size(240, 249);
            this.dgvStatus.TabIndex = 3;
            this.dgvStatus.Visible = false;
            // 
            // statusIDDataGridViewTextBoxColumn
            // 
            this.statusIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.statusIDDataGridViewTextBoxColumn.DataPropertyName = "Status_ID";
            this.statusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusIDDataGridViewTextBoxColumn.Name = "statusIDDataGridViewTextBoxColumn";
            this.statusIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // statusNameDataGridViewTextBoxColumn
            // 
            this.statusNameDataGridViewTextBoxColumn.DataPropertyName = "StatusName";
            this.statusNameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.statusNameDataGridViewTextBoxColumn.Name = "statusNameDataGridViewTextBoxColumn";
            this.statusNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wFStatusesBindingSource
            // 
            this.wFStatusesBindingSource.DataMember = "WF_Statuses";
            this.wFStatusesBindingSource.DataSource = this.wF;
            // 
            // wF
            // 
            this.wF.DataSetName = "WF";
            this.wF.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.lblDetails.Location = new System.Drawing.Point(3, 9);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(224, 18);
            this.lblDetails.TabIndex = 1;
            this.lblDetails.Text = "Товары в документе списания:";
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
            this.lineIDDataGridViewTextBoxColumn,
            this.locationIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.itemDataGridViewTextBoxColumn,
            this.manufacturerDataGridViewTextBoxColumn,
            this.vATDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.UOM,
            this.quantityDataGridViewTextBoxColumn,
            this.basePriceDataGridViewTextBoxColumn,
            this.amountUAHDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.lotStatusDataGridViewTextBoxColumn,
            this.MOZ,
            this.Vendor});
            this.dgvDetails.ContextMenuStrip = this.cmsDocDetails;
            this.dgvDetails.DataSource = this.bsWfGetDocsDetail;
            this.dgvDetails.Location = new System.Drawing.Point(0, 30);
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(1679, 216);
            this.dgvDetails.TabIndex = 0;
            this.dgvDetails.SelectionChanged += new System.EventHandler(this.dgvDetails_SelectionChanged);
            // 
            // lineIDDataGridViewTextBoxColumn
            // 
            this.lineIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineIDDataGridViewTextBoxColumn.DataPropertyName = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.HeaderText = "№ п/п";
            this.lineIDDataGridViewTextBoxColumn.Name = "lineIDDataGridViewTextBoxColumn";
            this.lineIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineIDDataGridViewTextBoxColumn.Width = 59;
            // 
            // locationIDDataGridViewTextBoxColumn
            // 
            this.locationIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.locationIDDataGridViewTextBoxColumn.DataPropertyName = "Location_ID";
            this.locationIDDataGridViewTextBoxColumn.HeaderText = "Место";
            this.locationIDDataGridViewTextBoxColumn.Name = "locationIDDataGridViewTextBoxColumn";
            this.locationIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.locationIDDataGridViewTextBoxColumn.Width = 64;
            // 
            // itemIDDataGridViewTextBoxColumn
            // 
            this.itemIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemIDDataGridViewTextBoxColumn.DataPropertyName = "Item_ID";
            this.itemIDDataGridViewTextBoxColumn.HeaderText = "ID товара";
            this.itemIDDataGridViewTextBoxColumn.Name = "itemIDDataGridViewTextBoxColumn";
            this.itemIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // itemDataGridViewTextBoxColumn
            // 
            this.itemDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.itemDataGridViewTextBoxColumn.DataPropertyName = "Item";
            this.itemDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.itemDataGridViewTextBoxColumn.Name = "itemDataGridViewTextBoxColumn";
            this.itemDataGridViewTextBoxColumn.ReadOnly = true;
            this.itemDataGridViewTextBoxColumn.Width = 108;
            // 
            // manufacturerDataGridViewTextBoxColumn
            // 
            this.manufacturerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.manufacturerDataGridViewTextBoxColumn.DataPropertyName = "Manufacturer";
            this.manufacturerDataGridViewTextBoxColumn.HeaderText = "Производитель";
            this.manufacturerDataGridViewTextBoxColumn.Name = "manufacturerDataGridViewTextBoxColumn";
            this.manufacturerDataGridViewTextBoxColumn.ReadOnly = true;
            this.manufacturerDataGridViewTextBoxColumn.Width = 111;
            // 
            // vATDataGridViewTextBoxColumn
            // 
            this.vATDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.vATDataGridViewTextBoxColumn.DataPropertyName = "VAT";
            this.vATDataGridViewTextBoxColumn.HeaderText = "НДС";
            this.vATDataGridViewTextBoxColumn.Name = "vATDataGridViewTextBoxColumn";
            this.vATDataGridViewTextBoxColumn.ReadOnly = true;
            this.vATDataGridViewTextBoxColumn.Width = 56;
            // 
            // lotNumberDataGridViewTextBoxColumn
            // 
            this.lotNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotNumberDataGridViewTextBoxColumn.DataPropertyName = "Lot_Number";
            this.lotNumberDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.lotNumberDataGridViewTextBoxColumn.Name = "lotNumberDataGridViewTextBoxColumn";
            this.lotNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotNumberDataGridViewTextBoxColumn.Width = 63;
            // 
            // batchIDDataGridViewTextBoxColumn
            // 
            this.batchIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.batchIDDataGridViewTextBoxColumn.DataPropertyName = "Batch_ID";
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Партия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn.Width = 69;
            // 
            // expirationDateDataGridViewTextBoxColumn
            // 
            this.expirationDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.expirationDateDataGridViewTextBoxColumn.DataPropertyName = "ExpirationDate";
            this.expirationDateDataGridViewTextBoxColumn.HeaderText = "Срок годности";
            this.expirationDateDataGridViewTextBoxColumn.Name = "expirationDateDataGridViewTextBoxColumn";
            this.expirationDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.expirationDateDataGridViewTextBoxColumn.Width = 97;
            // 
            // UOM
            // 
            this.UOM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.UOM.DataPropertyName = "UOM";
            this.UOM.HeaderText = "ЕИ";
            this.UOM.Name = "UOM";
            this.UOM.ReadOnly = true;
            this.UOM.Width = 47;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Кол-во";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 66;
            // 
            // basePriceDataGridViewTextBoxColumn
            // 
            this.basePriceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.basePriceDataGridViewTextBoxColumn.DataPropertyName = "BasePrice";
            this.basePriceDataGridViewTextBoxColumn.HeaderText = "Базовая цена";
            this.basePriceDataGridViewTextBoxColumn.Name = "basePriceDataGridViewTextBoxColumn";
            this.basePriceDataGridViewTextBoxColumn.ReadOnly = true;
            this.basePriceDataGridViewTextBoxColumn.Width = 94;
            // 
            // amountUAHDataGridViewTextBoxColumn
            // 
            this.amountUAHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn.DataPropertyName = "Amount_UAH";
            this.amountUAHDataGridViewTextBoxColumn.HeaderText = "Всего, грн";
            this.amountUAHDataGridViewTextBoxColumn.Name = "amountUAHDataGridViewTextBoxColumn";
            this.amountUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn.Width = 79;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Цена, грн";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            this.priceDataGridViewTextBoxColumn.Width = 75;
            // 
            // lotStatusDataGridViewTextBoxColumn
            // 
            this.lotStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lotStatusDataGridViewTextBoxColumn.DataPropertyName = "LotStatus";
            this.lotStatusDataGridViewTextBoxColumn.HeaderText = "Код задержки";
            this.lotStatusDataGridViewTextBoxColumn.Name = "lotStatusDataGridViewTextBoxColumn";
            this.lotStatusDataGridViewTextBoxColumn.ReadOnly = true;
            this.lotStatusDataGridViewTextBoxColumn.Width = 96;
            // 
            // MOZ
            // 
            this.MOZ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.MOZ.DataPropertyName = "MOZ";
            this.MOZ.HeaderText = "МОЗ";
            this.MOZ.Name = "MOZ";
            this.MOZ.ReadOnly = true;
            this.MOZ.Width = 56;
            // 
            // Vendor
            // 
            this.Vendor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Vendor.DataPropertyName = "Vendor";
            this.Vendor.HeaderText = "Поставщик";
            this.Vendor.Name = "Vendor";
            this.Vendor.ReadOnly = true;
            this.Vendor.Width = 90;
            // 
            // cmsDocDetails
            // 
            this.cmsDocDetails.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSplit});
            this.cmsDocDetails.Name = "cmsDocDetails";
            this.cmsDocDetails.Size = new System.Drawing.Size(203, 26);
            // 
            // miSplit
            // 
            this.miSplit.Image = ((System.Drawing.Image)(resources.GetObject("miSplit.Image")));
            this.miSplit.Name = "miSplit";
            this.miSplit.Size = new System.Drawing.Size(202, 22);
            this.miSplit.Text = "Выделить в новый макет";
            this.miSplit.Click += new System.EventHandler(this.Split_Click);
            // 
            // bsWfGetDocsDetail
            // 
            this.bsWfGetDocsDetail.DataMember = "WF_GetDocs_Detail";
            this.bsWfGetDocsDetail.DataSource = this.wH;
            // 
            // taWfGetDocs_Detail
            // 
            this.taWfGetDocs_Detail.ClearBeforeFill = true;
            // 
            // wF_StatusesTableAdapter
            // 
            this.wF_StatusesTableAdapter.ClearBeforeFill = true;
            // 
            // tsFilter
            // 
            this.tsFilter.Location = new System.Drawing.Point(0, 95);
            this.tsFilter.Name = "tsFilter";
            this.tsFilter.Size = new System.Drawing.Size(1679, 25);
            this.tsFilter.TabIndex = 4;
            this.tsFilter.Text = "toolStrip1";
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.spcMain);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 120);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1679, 499);
            this.pnlContent.TabIndex = 5;
            // 
            // WriteOffStuffsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1679, 619);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsFilter);
            this.Controls.Add(this.toolStripDoc);
            this.Name = "WriteOffStuffsWindow";
            this.Text = "Макеты списания";
            this.Load += new System.EventHandler(this.WriteOffStuffsWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WriteOffStuffsWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.tsFilter, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.cmsDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocs)).EndInit();
            this.spcMain.Panel1.ResumeLayout(false);
            this.spcMain.Panel2.ResumeLayout(false);
            this.spcMain.Panel2.PerformLayout();
            this.spcMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wFStatusesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            this.cmsDocDetails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsWfGetDocsDetail)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator tssAfterRefresh;
        private System.Windows.Forms.BindingSource bsWfGetDocs;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocsTableAdapter taWfGetDocs;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ToolStripButton btnAddDoc;
        private System.Windows.Forms.ToolStripButton btnEditDoc;
        private System.Windows.Forms.ToolStripSeparator tssAfterSave;
        private System.Windows.Forms.ToolStripButton btnHoldDoc;
        private System.Windows.Forms.ToolStripSeparator tssAfterHold;
        private System.Windows.Forms.ToolStripButton btnPrintDocs;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.SplitContainer spcMain;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.BindingSource bsWfGetDocsDetail;
        private WMSOffice.Data.WHTableAdapters.WF_GetDocs_DetailTableAdapter taWfGetDocs_Detail;
        private System.Windows.Forms.ToolStripButton btnPrintPackList;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn locationIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vATDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UOM;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn MOZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vendor;
        private System.Windows.Forms.ToolStripButton btnDestructionRequest;
        private System.Windows.Forms.ToolStripSeparator tssAfterPrint;
        private System.Windows.Forms.ToolStripButton btnSplit;
        private System.Windows.Forms.ContextMenuStrip cmsDocDetails;
        private System.Windows.Forms.ToolStripMenuItem miSplit;
        private System.Windows.Forms.ContextMenuStrip cmsDocs;
        private System.Windows.Forms.ToolStripMenuItem miCreateRequestDestruction;
        private System.Windows.Forms.ToolStripMenuItem cmiSimpleAct;
        private System.Windows.Forms.ToolStripButton btnCalc;
        private System.Windows.Forms.ToolStripButton btnAccept;
        private System.Windows.Forms.ToolStripButton btnShowState;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvDocs;
        private System.Windows.Forms.DataGridView dgvStatus;
        private WMSOffice.Data.WF wF;
        private System.Windows.Forms.BindingSource wFStatusesBindingSource;
        private WMSOffice.Data.WFTableAdapters.WF_StatusesTableAdapter wF_StatusesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton btnCalcExport;
        private System.Windows.Forms.ToolStripButton btnInvoice;
        private System.Windows.Forms.ToolStripButton btnArchive;
        private System.Windows.Forms.ToolStripButton btnExportConsCalc;
        private System.Windows.Forms.ToolStripMenuItem cmiExportDocs;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
        private System.Windows.Forms.ToolStrip tsFilter;
        private System.Windows.Forms.Panel pnlContent;
    }
}