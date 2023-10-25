namespace WMSOffice.Window
{
    partial class VendorReturnsWindow
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
            this.spcMainContainer = new System.Windows.Forms.SplitContainer();
            this.toolStripPrinters = new System.Windows.Forms.ToolStrip();
            this.lblPrinters = new System.Windows.Forms.ToolStripLabel();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.tbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSearchArchiveDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowAttachments = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddInvoice = new System.Windows.Forms.ToolStripButton();
            this.btnEditInvoice = new System.Windows.Forms.ToolStripButton();
            this.btnCorrection = new System.Windows.Forms.ToolStripButton();
            this.btnCorrectPickedReturns = new System.Windows.Forms.ToolStripButton();
            this.btnCreateVatCorrection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnToWarehouse = new System.Windows.Forms.ToolStripButton();
            this.btnAcceptReturns = new System.Windows.Forms.ToolStripButton();
            this.btnCloseVirtualReturn = new System.Windows.Forms.ToolStripButton();
            this.btnShipReturns = new System.Windows.Forms.ToolStripButton();
            this.btnShipping = new System.Windows.Forms.ToolStripButton();
            this.btnRK = new System.Windows.Forms.ToolStripButton();
            this.sprToStatuses = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintInvoice = new System.Windows.Forms.ToolStripButton();
            this.btnReprintPaketDocs = new System.Windows.Forms.ToolStripButton();
            this.btnPrintPackingList = new System.Windows.Forms.ToolStripButton();
            this.btnReprintPackingList = new System.Windows.Forms.ToolStripButton();
            this.sprToAnnulirovanie = new System.Windows.Forms.ToolStripSeparator();
            this.btnDeleteInvoice = new System.Windows.Forms.ToolStripButton();
            this.btnCreateVendorComplaint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportDocsToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnExportDetailsToExcel = new System.Windows.Forms.ToolStripButton();
            this.btnPrintDoc = new System.Windows.Forms.ToolStripButton();
            this.btnCreateVendorAct = new System.Windows.Forms.ToolStripButton();
            this.dgvInvoices = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.cmsGridMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miOriginalReceived = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvInvoiceLines = new System.Windows.Forms.DataGridView();
            this.lineIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lotNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.batchIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expirationDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clUom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountUAHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VAT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invoice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsVRDocDetails = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.taVR_DocDetails = new WMSOffice.Data.ComplaintsTableAdapters.VR_DocDetailsTableAdapter();
            this.spcMainContainer.Panel1.SuspendLayout();
            this.spcMainContainer.Panel2.SuspendLayout();
            this.spcMainContainer.SuspendLayout();
            this.toolStripPrinters.SuspendLayout();
            this.toolStripDoc.SuspendLayout();
            this.cmsGridMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceLines)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVRDocDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.SuspendLayout();
            // 
            // spcMainContainer
            // 
            this.spcMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcMainContainer.Location = new System.Drawing.Point(0, 40);
            this.spcMainContainer.Name = "spcMainContainer";
            this.spcMainContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spcMainContainer.Panel1
            // 
            this.spcMainContainer.Panel1.Controls.Add(this.toolStripPrinters);
            this.spcMainContainer.Panel1.Controls.Add(this.toolStripDoc);
            this.spcMainContainer.Panel1.Controls.Add(this.dgvInvoices);
            this.spcMainContainer.Panel1MinSize = 50;
            // 
            // spcMainContainer.Panel2
            // 
            this.spcMainContainer.Panel2.Controls.Add(this.dgvInvoiceLines);
            this.spcMainContainer.Panel2MinSize = 50;
            this.spcMainContainer.Size = new System.Drawing.Size(1488, 411);
            this.spcMainContainer.SplitterDistance = 258;
            this.spcMainContainer.SplitterWidth = 1;
            this.spcMainContainer.TabIndex = 1;
            // 
            // toolStripPrinters
            // 
            this.toolStripPrinters.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPrinters,
            this.cmbPrinters});
            this.toolStripPrinters.Location = new System.Drawing.Point(0, 55);
            this.toolStripPrinters.Name = "toolStripPrinters";
            this.toolStripPrinters.Size = new System.Drawing.Size(1488, 25);
            this.toolStripPrinters.TabIndex = 2;
            this.toolStripPrinters.Text = "toolStrip1";
            // 
            // lblPrinters
            // 
            this.lblPrinters.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrinters.ForeColor = System.Drawing.Color.Blue;
            this.lblPrinters.Name = "lblPrinters";
            this.lblPrinters.Size = new System.Drawing.Size(57, 22);
            this.lblPrinters.Text = "Принтер :";
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.BackColor = System.Drawing.SystemColors.Window;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(200, 25);
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbRefresh,
            this.toolStripSeparator3,
            this.btnSearchArchiveDocs,
            this.toolStripSeparator5,
            this.btnShowAttachments,
            this.toolStripSeparator1,
            this.btnAddInvoice,
            this.btnEditInvoice,
            this.btnCorrection,
            this.btnCorrectPickedReturns,
            this.btnCreateVatCorrection,
            this.toolStripSeparator2,
            this.btnToWarehouse,
            this.btnAcceptReturns,
            this.btnCloseVirtualReturn,
            this.btnShipReturns,
            this.btnShipping,
            this.btnRK,
            this.sprToStatuses,
            this.btnPrintInvoice,
            this.btnReprintPaketDocs,
            this.btnPrintPackingList,
            this.btnReprintPackingList,
            this.sprToAnnulirovanie,
            this.btnDeleteInvoice,
            this.btnCreateVendorComplaint,
            this.toolStripSeparator4,
            this.btnExportDocsToExcel,
            this.btnExportDetailsToExcel,
            this.btnPrintDoc,
            this.btnCreateVendorAct});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1488, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // tbRefresh
            // 
            this.tbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.tbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbRefresh.Name = "tbRefresh";
            this.tbRefresh.Size = new System.Drawing.Size(52, 52);
            this.tbRefresh.Text = "Обновить список электронных возвратных накладных";
            this.tbRefresh.Click += new System.EventHandler(this.tbRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSearchArchiveDocs
            // 
            this.btnSearchArchiveDocs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSearchArchiveDocs.Image = global::WMSOffice.Properties.Resources.find;
            this.btnSearchArchiveDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearchArchiveDocs.Name = "btnSearchArchiveDocs";
            this.btnSearchArchiveDocs.Size = new System.Drawing.Size(52, 52);
            this.btnSearchArchiveDocs.Text = "Поиск в архиве";
            this.btnSearchArchiveDocs.Click += new System.EventHandler(this.btnSearchArchiveDocs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowAttachments
            // 
            this.btnShowAttachments.Image = global::WMSOffice.Properties.Resources.paperclip;
            this.btnShowAttachments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAttachments.Name = "btnShowAttachments";
            this.btnShowAttachments.Size = new System.Drawing.Size(94, 52);
            this.btnShowAttachments.Text = "Прикр.\nфайлы";
            this.btnShowAttachments.Click += new System.EventHandler(this.btnShowAttachments_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnAddInvoice
            // 
            this.btnAddInvoice.Image = global::WMSOffice.Properties.Resources.add_document;
            this.btnAddInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddInvoice.Name = "btnAddInvoice";
            this.btnAddInvoice.Size = new System.Drawing.Size(147, 52);
            this.btnAddInvoice.Text = "Создать новую\nвозв. накладную";
            this.btnAddInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddInvoice.Click += new System.EventHandler(this.btnAddInvoice_Click);
            // 
            // btnEditInvoice
            // 
            this.btnEditInvoice.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.btnEditInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditInvoice.Name = "btnEditInvoice";
            this.btnEditInvoice.Size = new System.Drawing.Size(147, 52);
            this.btnEditInvoice.Text = "Редактировать\nвозв. накладную";
            this.btnEditInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditInvoice.Click += new System.EventHandler(this.btnEditInvoice_Click);
            // 
            // btnCorrection
            // 
            this.btnCorrection.Image = global::WMSOffice.Properties.Resources.line_sight;
            this.btnCorrection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCorrection.Name = "btnCorrection";
            this.btnCorrection.Size = new System.Drawing.Size(147, 52);
            this.btnCorrection.Text = "Корректировать\nвозв. накладную";
            this.btnCorrection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCorrection.Click += new System.EventHandler(this.btnCorrection_Click);
            // 
            // btnCorrectPickedReturns
            // 
            this.btnCorrectPickedReturns.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnCorrectPickedReturns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCorrectPickedReturns.Name = "btnCorrectPickedReturns";
            this.btnCorrectPickedReturns.Size = new System.Drawing.Size(158, 52);
            this.btnCorrectPickedReturns.Text = "Корректировать\nсобранный возврат";
            this.btnCorrectPickedReturns.ToolTipText = "Корректировать\nсобранный возврат";
            this.btnCorrectPickedReturns.Click += new System.EventHandler(this.btnCorrectPickedReturns_Click);
            // 
            // btnCreateVatCorrection
            // 
            this.btnCreateVatCorrection.Image = global::WMSOffice.Properties.Resources.tables_edit;
            this.btnCreateVatCorrection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateVatCorrection.Name = "btnCreateVatCorrection";
            this.btnCreateVatCorrection.Size = new System.Drawing.Size(123, 52);
            this.btnCreateVatCorrection.Text = "Создать акт\nкорр. НДС";
            this.btnCreateVatCorrection.ToolTipText = "Создать акт\nкорректировки НДС";
            this.btnCreateVatCorrection.Click += new System.EventHandler(this.btnCreateVatCorrection_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnToWarehouse
            // 
            this.btnToWarehouse.Image = global::WMSOffice.Properties.Resources.box;
            this.btnToWarehouse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToWarehouse.Name = "btnToWarehouse";
            this.btnToWarehouse.Size = new System.Drawing.Size(104, 52);
            this.btnToWarehouse.Text = "Взять\nв работу";
            this.btnToWarehouse.Click += new System.EventHandler(this.btnToWarehouse_Click);
            // 
            // btnAcceptReturns
            // 
            this.btnAcceptReturns.Image = global::WMSOffice.Properties.Resources.pallet;
            this.btnAcceptReturns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAcceptReturns.Name = "btnAcceptReturns";
            this.btnAcceptReturns.Size = new System.Drawing.Size(102, 52);
            this.btnAcceptReturns.Text = "Принять\nвозврат";
            this.btnAcceptReturns.Click += new System.EventHandler(this.btnAcceptReturns_Click);
            // 
            // btnnCloseVirtualReturn
            // 
            this.btnCloseVirtualReturn.Image = global::WMSOffice.Properties.Resources.checkered_flag;
            this.btnCloseVirtualReturn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseVirtualReturn.Name = "btnnCloseVirtualReturn";
            this.btnCloseVirtualReturn.Size = new System.Drawing.Size(178, 52);
            this.btnCloseVirtualReturn.Text = "Закрыть\nвирт. возврат";
            this.btnCloseVirtualReturn.Click += new System.EventHandler(this.btnCloseVirtualReturn_Click);
            // 
            // btnShipReturns
            // 
            this.btnShipReturns.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnShipReturns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShipReturns.Name = "btnShipReturns";
            this.btnShipReturns.Size = new System.Drawing.Size(157, 52);
            this.btnShipReturns.Text = "Отгрузка возврата\nпоставщику";
            this.btnShipReturns.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipReturns.Click += new System.EventHandler(this.btnShipReturns_Click);
            // 
            // btnShipping
            // 
            this.btnShipping.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnShipping.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShipping.Name = "btnShipping";
            this.btnShipping.Size = new System.Drawing.Size(147, 52);
            this.btnShipping.Text = "Отправить\nвозврат машиной";
            this.btnShipping.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShipping.Click += new System.EventHandler(this.btnShipping_Click);
            // 
            // btnRK
            // 
            this.btnRK.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnRK.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRK.Name = "btnRK";
            this.btnRK.Size = new System.Drawing.Size(151, 52);
            this.btnRK.Text = "Прибыли рассчет-\nкорректировки";
            this.btnRK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRK.Click += new System.EventHandler(this.btnRK_Click);
            // 
            // sprToStatuses
            // 
            this.sprToStatuses.Name = "sprToStatuses";
            this.sprToStatuses.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintInvoice
            // 
            this.btnPrintInvoice.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintInvoice.Name = "btnPrintInvoice";
            this.btnPrintInvoice.Size = new System.Drawing.Size(135, 52);
            this.btnPrintInvoice.Text = "Печать пакета\nдокументов";
            this.btnPrintInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrintInvoice.Click += new System.EventHandler(this.btnPrintInvoices_Click);
            // 
            // btnReprintPaketDocs
            // 
            this.btnReprintPaketDocs.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnReprintPaketDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintPaketDocs.Name = "btnReprintPaketDocs";
            this.btnReprintPaketDocs.Size = new System.Drawing.Size(159, 52);
            this.btnReprintPaketDocs.Text = "Повторная печать\nпакета документов";
            this.btnReprintPaketDocs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprintPaketDocs.Click += new System.EventHandler(this.btnReprintPaketDocs_Click);
            // 
            // btnPrintPackingList
            // 
            this.btnPrintPackingList.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintPackingList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPackingList.Name = "btnPrintPackingList";
            this.btnPrintPackingList.Size = new System.Drawing.Size(157, 52);
            this.btnPrintPackingList.Text = "Печать сборочного";
            this.btnPrintPackingList.Visible = false;
            this.btnPrintPackingList.Click += new System.EventHandler(this.btnPrintPackingList_Click);
            // 
            // btnReprintPackingList
            // 
            this.btnReprintPackingList.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnReprintPackingList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReprintPackingList.Name = "btnReprintPackingList";
            this.btnReprintPackingList.Size = new System.Drawing.Size(153, 52);
            this.btnReprintPackingList.Text = "Повторная печать\nсборочного";
            this.btnReprintPackingList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprintPackingList.Click += new System.EventHandler(this.btnReprintPackingList_Click);
            // 
            // sprToAnnulirovanie
            // 
            this.sprToAnnulirovanie.Name = "sprToAnnulirovanie";
            this.sprToAnnulirovanie.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDeleteInvoice
            // 
            this.btnDeleteInvoice.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeleteInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteInvoice.Name = "btnDeleteInvoice";
            this.btnDeleteInvoice.Size = new System.Drawing.Size(132, 52);
            this.btnDeleteInvoice.Text = "Аннулировать\nнакладную";
            this.btnDeleteInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteInvoice.ToolTipText = "Аннулирование накладной - снятие жесткого резерва со всех находящихся в ней товар" +
                "ов, и перевод ее на статус 189";
            this.btnDeleteInvoice.Click += new System.EventHandler(this.btnDeleteInvoice_Click);
            // 
            // btnCreateVendorComplaint
            // 
            this.btnCreateVendorComplaint.Image = global::WMSOffice.Properties.Resources.hand_yellow_card;
            this.btnCreateVendorComplaint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateVendorComplaint.Name = "btnCreateVendorComplaint";
            this.btnCreateVendorComplaint.Size = new System.Drawing.Size(155, 52);
            this.btnCreateVendorComplaint.Text = "Отказ поставщика\nот возврата";
            this.btnCreateVendorComplaint.Click += new System.EventHandler(this.btnCreateVendorComplaint_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportDocsToExcel
            // 
            this.btnExportDocsToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportDocsToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDocsToExcel.Name = "btnExportDocsToExcel";
            this.btnExportDocsToExcel.Size = new System.Drawing.Size(116, 52);
            this.btnExportDocsToExcel.Text = "Экспорт\nнакладных";
            this.btnExportDocsToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportDocsToExcel.ToolTipText = "Экспорт списка накладных в Excel";
            this.btnExportDocsToExcel.Click += new System.EventHandler(this.btnExportDocsToExcel_Click);
            // 
            // btnExportDetailsToExcel
            // 
            this.btnExportDetailsToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportDetailsToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDetailsToExcel.Name = "btnExportDetailsToExcel";
            this.btnExportDetailsToExcel.Size = new System.Drawing.Size(146, 52);
            this.btnExportDetailsToExcel.Text = "Экспорт товаров\nв накладной";
            this.btnExportDetailsToExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportDetailsToExcel.ToolTipText = "Экспорт в Excel товаров в накладной";
            this.btnExportDetailsToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // btnPrintDoc
            // 
            this.btnPrintDoc.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.btnPrintDoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintDoc.Name = "btnPrintDoc";
            this.btnPrintDoc.Size = new System.Drawing.Size(154, 52);
            this.btnPrintDoc.Text = "Печать накладной";
            this.btnPrintDoc.ToolTipText = "Печать/Экспорт/Просмотр накладной";
            this.btnPrintDoc.Click += new System.EventHandler(this.btnPrintDoc_Click);
            // 
            // btnCreateVendorAct
            // 
            this.btnCreateVendorAct.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.btnCreateVendorAct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateVendorAct.Name = "btnCreateVendorAct";
            this.btnCreateVendorAct.Size = new System.Drawing.Size(123, 52);
            this.btnCreateVendorAct.Text = "Создать акт\nпоставщику";
            this.btnCreateVendorAct.Click += new System.EventHandler(this.btnCreateVendorAct_Click);
            // 
            // dgvInvoices
            // 
            this.dgvInvoices.AllowSort = true;
            this.dgvInvoices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInvoices.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvInvoices.ContextMenuStrip = this.cmsGridMenu;
            this.dgvInvoices.LargeAmountOfData = false;
            this.dgvInvoices.Location = new System.Drawing.Point(3, 83);
            this.dgvInvoices.Name = "dgvInvoices";
            this.dgvInvoices.RowHeadersVisible = false;
            this.dgvInvoices.Size = new System.Drawing.Size(1482, 172);
            this.dgvInvoices.TabIndex = 0;
            this.dgvInvoices.UserID = ((long)(0));
            // 
            // cmsGridMenu
            // 
            this.cmsGridMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOriginalReceived});
            this.cmsGridMenu.Name = "cmsGridMenu";
            this.cmsGridMenu.Size = new System.Drawing.Size(169, 26);
            // 
            // miOriginalReceived
            // 
            this.miOriginalReceived.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.miOriginalReceived.Name = "miOriginalReceived";
            this.miOriginalReceived.Size = new System.Drawing.Size(168, 22);
            this.miOriginalReceived.Text = "Оригинал получен";
            this.miOriginalReceived.Click += new System.EventHandler(this.miOriginalReceived_Click);
            // 
            // dgvInvoiceLines
            // 
            this.dgvInvoiceLines.AllowUserToAddRows = false;
            this.dgvInvoiceLines.AllowUserToDeleteRows = false;
            this.dgvInvoiceLines.AllowUserToOrderColumns = true;
            this.dgvInvoiceLines.AllowUserToResizeRows = false;
            this.dgvInvoiceLines.AutoGenerateColumns = false;
            this.dgvInvoiceLines.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInvoiceLines.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lineIDDataGridViewTextBoxColumn,
            this.itemIDDataGridViewTextBoxColumn,
            this.Item,
            this.manufacturerDataGridViewTextBoxColumn,
            this.lotNumberDataGridViewTextBoxColumn,
            this.batchIDDataGridViewTextBoxColumn,
            this.expirationDateDataGridViewTextBoxColumn,
            this.Price,
            this.clUom,
            this.quantityDataGridViewTextBoxColumn,
            this.amountUAHDataGridViewTextBoxColumn,
            this.VAT,
            this.Invoice,
            this.InvoiceDate});
            this.dgvInvoiceLines.DataSource = this.bsVRDocDetails;
            this.dgvInvoiceLines.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInvoiceLines.Location = new System.Drawing.Point(0, 0);
            this.dgvInvoiceLines.Name = "dgvInvoiceLines";
            this.dgvInvoiceLines.ReadOnly = true;
            this.dgvInvoiceLines.RowHeadersVisible = false;
            this.dgvInvoiceLines.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInvoiceLines.Size = new System.Drawing.Size(1488, 152);
            this.dgvInvoiceLines.TabIndex = 0;
            // 
            // lineIDDataGridViewTextBoxColumn
            // 
            this.lineIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lineIDDataGridViewTextBoxColumn.DataPropertyName = "Line_ID";
            this.lineIDDataGridViewTextBoxColumn.HeaderText = "Номер строки";
            this.lineIDDataGridViewTextBoxColumn.Name = "lineIDDataGridViewTextBoxColumn";
            this.lineIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.lineIDDataGridViewTextBoxColumn.Width = 96;
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
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "Наименование";
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 108;
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
            this.batchIDDataGridViewTextBoxColumn.HeaderText = "Дл. партия";
            this.batchIDDataGridViewTextBoxColumn.Name = "batchIDDataGridViewTextBoxColumn";
            this.batchIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.batchIDDataGridViewTextBoxColumn.Width = 81;
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
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Price.DataPropertyName = "Price";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N4";
            this.Price.DefaultCellStyle = dataGridViewCellStyle1;
            this.Price.HeaderText = "Цена за шт.";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            this.Price.Width = 70;
            // 
            // clUom
            // 
            this.clUom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.clUom.DataPropertyName = "UOM";
            this.clUom.HeaderText = "Е.И.";
            this.clUom.Name = "clUom";
            this.clUom.ReadOnly = true;
            this.clUom.Width = 53;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            this.quantityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 91;
            // 
            // amountUAHDataGridViewTextBoxColumn
            // 
            this.amountUAHDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.amountUAHDataGridViewTextBoxColumn.DataPropertyName = "Amount_UAH";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            this.amountUAHDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.amountUAHDataGridViewTextBoxColumn.HeaderText = "Всего";
            this.amountUAHDataGridViewTextBoxColumn.Name = "amountUAHDataGridViewTextBoxColumn";
            this.amountUAHDataGridViewTextBoxColumn.ReadOnly = true;
            this.amountUAHDataGridViewTextBoxColumn.Width = 62;
            // 
            // VAT
            // 
            this.VAT.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.VAT.DataPropertyName = "VAT";
            this.VAT.HeaderText = "НДС";
            this.VAT.Name = "VAT";
            this.VAT.ReadOnly = true;
            this.VAT.Width = 56;
            // 
            // Invoice
            // 
            this.Invoice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Invoice.DataPropertyName = "Invoice";
            this.Invoice.HeaderText = "№ ориг. док.";
            this.Invoice.Name = "Invoice";
            this.Invoice.ReadOnly = true;
            this.Invoice.Width = 88;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "Дата ориг. док.";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            this.InvoiceDate.Width = 83;
            // 
            // bsVRDocDetails
            // 
            this.bsVRDocDetails.DataMember = "VR_DocDetails";
            this.bsVRDocDetails.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // taVR_DocDetails
            // 
            this.taVR_DocDetails.ClearBeforeFill = true;
            // 
            // VendorReturnsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1488, 451);
            this.Controls.Add(this.spcMainContainer);
            this.Name = "VendorReturnsWindow";
            this.Text = "VendorReturnsWindow";
            this.Load += new System.EventHandler(this.VendorReturnsWindow_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VendorReturnsWindow_FormClosing);
            this.Controls.SetChildIndex(this.spcMainContainer, 0);
            this.spcMainContainer.Panel1.ResumeLayout(false);
            this.spcMainContainer.Panel1.PerformLayout();
            this.spcMainContainer.Panel2.ResumeLayout(false);
            this.spcMainContainer.ResumeLayout(false);
            this.toolStripPrinters.ResumeLayout(false);
            this.toolStripPrinters.PerformLayout();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.cmsGridMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceLines)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsVRDocDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer spcMainContainer;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView dgvInvoices;
        private System.Windows.Forms.DataGridView dgvInvoiceLines;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton tbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bsVRDocDetails;
        private WMSOffice.Data.Complaints complaints;
        private WMSOffice.Data.ComplaintsTableAdapters.VR_DocDetailsTableAdapter taVR_DocDetails;
        private System.Windows.Forms.ToolStripButton btnAddInvoice;
        private System.Windows.Forms.ToolStripButton btnEditInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnToWarehouse;
        private System.Windows.Forms.ToolStripSeparator sprToStatuses;
        private System.Windows.Forms.ToolStripButton btnPrintPackingList;
        private System.Windows.Forms.ToolStripButton btnPrintInvoice;
        private System.Windows.Forms.ToolStripButton btnShipping;
        private System.Windows.Forms.ToolStripButton btnRK;
        private System.Windows.Forms.ToolStripButton btnCorrection;
        private System.Windows.Forms.ToolStripButton btnPrintDoc;
        private System.Windows.Forms.ToolStripSeparator sprToAnnulirovanie;
        private System.Windows.Forms.ToolStripButton btnDeleteInvoice;
        private System.Windows.Forms.ToolStripButton btnReprintPaketDocs;
        private System.Windows.Forms.ToolStripButton btnReprintPackingList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton btnExportDetailsToExcel;
        private System.Windows.Forms.ToolStripButton btnExportDocsToExcel;
        private System.Windows.Forms.ToolStripButton btnShipReturns;
        private System.Windows.Forms.ToolStripButton btnAcceptReturns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton btnSearchArchiveDocs;
        private System.Windows.Forms.ToolStripButton btnCorrectPickedReturns;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnShowAttachments;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lotNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn batchIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expirationDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn clUom;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountUAHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VAT;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.ToolStrip toolStripPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinters;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripButton btnCreateVatCorrection;
        private System.Windows.Forms.ToolStripButton btnCreateVendorComplaint;
        private System.Windows.Forms.ToolStripButton btnCreateVendorAct;
        private System.Windows.Forms.ContextMenuStrip cmsGridMenu;
        private System.Windows.Forms.ToolStripMenuItem miOriginalReceived;
        private System.Windows.Forms.ToolStripButton btnCloseVirtualReturn;
    }
}