namespace WMSOffice.Window
{
    partial class WHDocsPrintNaklWindow
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WHDocsPrintNaklWindow));
            this.dgvDocs = new System.Windows.Forms.DataGridView();
            this.dgvcIsAlreadyPrinted = new System.Windows.Forms.DataGridViewImageColumn();
            this.Orders_Seuqence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RouteCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rout_Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.warehouseIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDDCT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceStatusIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormattedVatRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceSumWithVATNal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hasVATDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.InvoiceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaxInvoiceCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDebtorCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegisterCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isInterbranchDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isPackPrintedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebtorID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DebtorCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryAddressIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorDeliveryAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnloadingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeliveryInstructions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaymentConditionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SCGP_Flag = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuForDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.miPrintPackage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.miPrintInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintTaxInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintControlSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintSaleRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintRequirementOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintBillInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintTareInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintDocAgreement = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewInvoiceBase = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewTaxInvoiceForOptima = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewTaxInvoiceForClient = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewControlSheet = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewSaleRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewRequirementOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewBillInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewTareInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.miPreviewDocAgreement = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewTenderInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.docsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.printNakl = new WMSOffice.Data.PrintNakl();
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.btnEnableWaybillMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintFullPackageByWaybill = new System.Windows.Forms.ToolStripButton();
            this.tssPrintFullPackageByWaybill = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintPackage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExportDocs = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCheckInvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.lblDocsCount = new System.Windows.Forms.Label();
            this.lblDocsCountCaption = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblDocsCountNT = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRL = new System.Windows.Forms.Panel();
            this.chbIsRemotePrint = new System.Windows.Forms.CheckBox();
            this.tsShowHideRouteLists = new System.Windows.Forms.ToolStrip();
            this.btnShowHideRouteLists = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.cbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbScaner = new WMSOffice.Controls.TextBoxScaner();
            this.pnlLegend = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.scWaybillDocsContent = new System.Windows.Forms.SplitContainer();
            this.scRouteListWaybillsContent = new System.Windows.Forms.SplitContainer();
            this.pnlRouteListContent = new System.Windows.Forms.Panel();
            this.dgvRouteListDocs = new System.Windows.Forms.DataGridView();
            this.dgvcNeedPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.routeListNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driversDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblRouteListHeader = new System.Windows.Forms.Label();
            this.pnlWaybillContent = new System.Windows.Forms.Panel();
            this.dgvWaybillDocs = new System.Windows.Forms.DataGridView();
            this.dgvcIsReadyToPrint = new System.Windows.Forms.DataGridViewImageColumn();
            this.planDateStartDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.routeListNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTNNoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EWbFormattedFlagName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.printedDocsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.driversDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tTNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NeedPrint = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WbFormattedStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuForWaybillDocs = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRefreshWaybillDocs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.miPrintWaybillDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintPackageByWaybill = new System.Windows.Forms.ToolStripMenuItem();
            this.miPrintFullPackageByWaybill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.miRePrintFullPackageByWaybill = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.miPreviewWaybillDoc = new System.Windows.Forms.ToolStripMenuItem();
            this.waybillDocsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblWaybillHeader = new System.Windows.Forms.Label();
            this.pnlInvoiceContent = new System.Windows.Forms.Panel();
            this.lblInvoiceHeader = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.docsTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.DocsTableAdapter();
            this.waybill_DocsTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.Waybill_DocsTableAdapter();
            this.route_List_DocsTableAdapter = new WMSOffice.Data.PrintNaklTableAdapters.Route_List_DocsTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).BeginInit();
            this.contextMenuForDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).BeginInit();
            this.toolStripDoc.SuspendLayout();
            this.panelRL.SuspendLayout();
            this.tsShowHideRouteLists.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlLegend.SuspendLayout();
            this.scWaybillDocsContent.Panel1.SuspendLayout();
            this.scWaybillDocsContent.Panel2.SuspendLayout();
            this.scWaybillDocsContent.SuspendLayout();
            this.scRouteListWaybillsContent.Panel1.SuspendLayout();
            this.scRouteListWaybillsContent.Panel2.SuspendLayout();
            this.scRouteListWaybillsContent.SuspendLayout();
            this.pnlRouteListContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteListDocs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListDocsBindingSource)).BeginInit();
            this.pnlWaybillContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaybillDocs)).BeginInit();
            this.contextMenuForWaybillDocs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waybillDocsBindingSource)).BeginInit();
            this.pnlInvoiceContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDocs
            // 
            this.dgvDocs.AllowUserToAddRows = false;
            this.dgvDocs.AllowUserToDeleteRows = false;
            this.dgvDocs.AllowUserToOrderColumns = true;
            this.dgvDocs.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
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
            this.dgvcIsAlreadyPrinted,
            this.Orders_Seuqence,
            this.RouteCode,
            this.Rout_Number,
            this.orderTypeDataGridViewTextBoxColumn,
            this.orderIDDataGridViewTextBoxColumn,
            this.warehouseIDDataGridViewTextBoxColumn,
            this.SDDCT,
            this.invoiceIDDataGridViewTextBoxColumn,
            this.invoiceStatusIDDataGridViewTextBoxColumn,
            this.FormattedVatRate,
            this.InvoiceSumWithVATNal,
            this.hasVATDataGridViewCheckBoxColumn,
            this.InvoiceCount,
            this.TaxInvoiceCount,
            this.InvoiceDebtorCount,
            this.RegisterCount,
            this.isInterbranchDataGridViewCheckBoxColumn,
            this.isPackPrintedDataGridViewCheckBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.deliveryDateDataGridViewTextBoxColumn,
            this.DebtorID,
            this.debtorNameDataGridViewTextBoxColumn,
            this.DebtorCity,
            this.deliveryAddressIDDataGridViewTextBoxColumn,
            this.debtorDeliveryAddressDataGridViewTextBoxColumn,
            this.UnloadingAddress,
            this.DeliveryInstructions,
            this.ManagerID,
            this.ManagerName,
            this.PaymentConditionID,
            this.SCGP_Flag});
            this.dgvDocs.ContextMenuStrip = this.contextMenuForDocs;
            this.dgvDocs.DataSource = this.docsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDocs.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvDocs.Name = "dgvDocs";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDocs.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDocs.RowHeadersVisible = false;
            this.dgvDocs.RowTemplate.Height = 21;
            this.dgvDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocs.ShowCellErrors = false;
            this.dgvDocs.ShowEditingIcon = false;
            this.dgvDocs.ShowRowErrors = false;
            this.dgvDocs.Size = new System.Drawing.Size(1423, 502);
            this.dgvDocs.TabIndex = 8;
            this.dgvDocs.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocs_ColumnHeaderMouseClick);
            this.dgvDocs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvDocs_CellFormatting);
            this.dgvDocs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDocs_DataBindingComplete);
            this.dgvDocs.SelectionChanged += new System.EventHandler(this.dgvDocs_SelectionChanged);
            // 
            // dgvcIsAlreadyPrinted
            // 
            this.dgvcIsAlreadyPrinted.HeaderText = "";
            this.dgvcIsAlreadyPrinted.Name = "dgvcIsAlreadyPrinted";
            this.dgvcIsAlreadyPrinted.Width = 20;
            // 
            // Orders_Seuqence
            // 
            this.Orders_Seuqence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Orders_Seuqence.DataPropertyName = "Orders_Seuqence";
            this.Orders_Seuqence.HeaderText = "№ п\\п";
            this.Orders_Seuqence.Name = "Orders_Seuqence";
            this.Orders_Seuqence.ReadOnly = true;
            this.Orders_Seuqence.Width = 40;
            // 
            // RouteCode
            // 
            this.RouteCode.DataPropertyName = "RouteCode";
            this.RouteCode.HeaderText = "Код маршр.";
            this.RouteCode.Name = "RouteCode";
            this.RouteCode.ReadOnly = true;
            this.RouteCode.Width = 45;
            // 
            // Rout_Number
            // 
            this.Rout_Number.DataPropertyName = "Rout_Number";
            this.Rout_Number.HeaderText = "№ МЛ";
            this.Rout_Number.Name = "Rout_Number";
            this.Rout_Number.Width = 65;
            // 
            // orderTypeDataGridViewTextBoxColumn
            // 
            this.orderTypeDataGridViewTextBoxColumn.DataPropertyName = "OrderType";
            this.orderTypeDataGridViewTextBoxColumn.HeaderText = "Тип зак.";
            this.orderTypeDataGridViewTextBoxColumn.Name = "orderTypeDataGridViewTextBoxColumn";
            this.orderTypeDataGridViewTextBoxColumn.Width = 40;
            // 
            // orderIDDataGridViewTextBoxColumn
            // 
            this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
            this.orderIDDataGridViewTextBoxColumn.HeaderText = "№ заказа";
            this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
            this.orderIDDataGridViewTextBoxColumn.Visible = false;
            this.orderIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // warehouseIDDataGridViewTextBoxColumn
            // 
            this.warehouseIDDataGridViewTextBoxColumn.DataPropertyName = "WarehouseID";
            this.warehouseIDDataGridViewTextBoxColumn.HeaderText = "Склад";
            this.warehouseIDDataGridViewTextBoxColumn.Name = "warehouseIDDataGridViewTextBoxColumn";
            this.warehouseIDDataGridViewTextBoxColumn.Width = 65;
            // 
            // SDDCT
            // 
            this.SDDCT.DataPropertyName = "SDDCT";
            this.SDDCT.HeaderText = "Тип накл.";
            this.SDDCT.Name = "SDDCT";
            this.SDDCT.Width = 40;
            // 
            // invoiceIDDataGridViewTextBoxColumn
            // 
            this.invoiceIDDataGridViewTextBoxColumn.DataPropertyName = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn.HeaderText = "№ накл.";
            this.invoiceIDDataGridViewTextBoxColumn.Name = "invoiceIDDataGridViewTextBoxColumn";
            this.invoiceIDDataGridViewTextBoxColumn.Width = 75;
            // 
            // invoiceStatusIDDataGridViewTextBoxColumn
            // 
            this.invoiceStatusIDDataGridViewTextBoxColumn.DataPropertyName = "InvoiceStatusID";
            this.invoiceStatusIDDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.invoiceStatusIDDataGridViewTextBoxColumn.Name = "invoiceStatusIDDataGridViewTextBoxColumn";
            this.invoiceStatusIDDataGridViewTextBoxColumn.Width = 50;
            // 
            // FormattedVatRate
            // 
            this.FormattedVatRate.DataPropertyName = "FormattedVatRate";
            this.FormattedVatRate.HeaderText = "Ставка НДС";
            this.FormattedVatRate.Name = "FormattedVatRate";
            this.FormattedVatRate.ReadOnly = true;
            this.FormattedVatRate.Width = 60;
            // 
            // InvoiceSumWithVATNal
            // 
            this.InvoiceSumWithVATNal.DataPropertyName = "InvoiceSumWithVATNal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.InvoiceSumWithVATNal.DefaultCellStyle = dataGridViewCellStyle3;
            this.InvoiceSumWithVATNal.HeaderText = "Сумма";
            this.InvoiceSumWithVATNal.Name = "InvoiceSumWithVATNal";
            this.InvoiceSumWithVATNal.ReadOnly = true;
            this.InvoiceSumWithVATNal.Width = 80;
            // 
            // hasVATDataGridViewCheckBoxColumn
            // 
            this.hasVATDataGridViewCheckBoxColumn.DataPropertyName = "HasVAT";
            this.hasVATDataGridViewCheckBoxColumn.HeaderText = "НДС";
            this.hasVATDataGridViewCheckBoxColumn.Name = "hasVATDataGridViewCheckBoxColumn";
            this.hasVATDataGridViewCheckBoxColumn.ReadOnly = true;
            this.hasVATDataGridViewCheckBoxColumn.Visible = false;
            this.hasVATDataGridViewCheckBoxColumn.Width = 40;
            // 
            // InvoiceCount
            // 
            this.InvoiceCount.DataPropertyName = "InvoiceCount";
            this.InvoiceCount.HeaderText = "Расходных";
            this.InvoiceCount.Name = "InvoiceCount";
            this.InvoiceCount.ReadOnly = true;
            this.InvoiceCount.Visible = false;
            this.InvoiceCount.Width = 60;
            // 
            // TaxInvoiceCount
            // 
            this.TaxInvoiceCount.DataPropertyName = "TaxInvoiceCount";
            this.TaxInvoiceCount.HeaderText = "Налоговых";
            this.TaxInvoiceCount.Name = "TaxInvoiceCount";
            this.TaxInvoiceCount.ReadOnly = true;
            this.TaxInvoiceCount.Visible = false;
            this.TaxInvoiceCount.Width = 60;
            // 
            // InvoiceDebtorCount
            // 
            this.InvoiceDebtorCount.DataPropertyName = "InvoiceDebtorCount";
            this.InvoiceDebtorCount.HeaderText = "Для дебитора";
            this.InvoiceDebtorCount.Name = "InvoiceDebtorCount";
            this.InvoiceDebtorCount.ReadOnly = true;
            this.InvoiceDebtorCount.Visible = false;
            this.InvoiceDebtorCount.Width = 70;
            // 
            // RegisterCount
            // 
            this.RegisterCount.DataPropertyName = "RegisterCount";
            this.RegisterCount.HeaderText = "Реестров";
            this.RegisterCount.Name = "RegisterCount";
            this.RegisterCount.ReadOnly = true;
            this.RegisterCount.Visible = false;
            this.RegisterCount.Width = 60;
            // 
            // isInterbranchDataGridViewCheckBoxColumn
            // 
            this.isInterbranchDataGridViewCheckBoxColumn.DataPropertyName = "IsInterbranch";
            this.isInterbranchDataGridViewCheckBoxColumn.HeaderText = "Межскл.";
            this.isInterbranchDataGridViewCheckBoxColumn.Name = "isInterbranchDataGridViewCheckBoxColumn";
            this.isInterbranchDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isInterbranchDataGridViewCheckBoxColumn.Visible = false;
            this.isInterbranchDataGridViewCheckBoxColumn.Width = 50;
            // 
            // isPackPrintedDataGridViewCheckBoxColumn
            // 
            this.isPackPrintedDataGridViewCheckBoxColumn.DataPropertyName = "IsPackPrinted";
            this.isPackPrintedDataGridViewCheckBoxColumn.HeaderText = "Пакет распеч.";
            this.isPackPrintedDataGridViewCheckBoxColumn.Name = "isPackPrintedDataGridViewCheckBoxColumn";
            this.isPackPrintedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isPackPrintedDataGridViewCheckBoxColumn.Visible = false;
            this.isPackPrintedDataGridViewCheckBoxColumn.Width = 60;
            // 
            // orderDateDataGridViewTextBoxColumn
            // 
            this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
            this.orderDateDataGridViewTextBoxColumn.HeaderText = "Дата зак.";
            this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
            this.orderDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.orderDateDataGridViewTextBoxColumn.Width = 75;
            // 
            // deliveryDateDataGridViewTextBoxColumn
            // 
            this.deliveryDateDataGridViewTextBoxColumn.DataPropertyName = "DeliveryDate";
            this.deliveryDateDataGridViewTextBoxColumn.HeaderText = "Дата дост.";
            this.deliveryDateDataGridViewTextBoxColumn.Name = "deliveryDateDataGridViewTextBoxColumn";
            this.deliveryDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryDateDataGridViewTextBoxColumn.Width = 75;
            // 
            // DebtorID
            // 
            this.DebtorID.DataPropertyName = "DebtorID";
            this.DebtorID.HeaderText = "Код дебитора";
            this.DebtorID.Name = "DebtorID";
            this.DebtorID.ReadOnly = true;
            this.DebtorID.Width = 65;
            // 
            // debtorNameDataGridViewTextBoxColumn
            // 
            this.debtorNameDataGridViewTextBoxColumn.DataPropertyName = "DebtorName";
            this.debtorNameDataGridViewTextBoxColumn.HeaderText = "Наименование дебитора";
            this.debtorNameDataGridViewTextBoxColumn.Name = "debtorNameDataGridViewTextBoxColumn";
            this.debtorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // DebtorCity
            // 
            this.DebtorCity.DataPropertyName = "DebtorCity";
            this.DebtorCity.HeaderText = "Город";
            this.DebtorCity.Name = "DebtorCity";
            this.DebtorCity.ReadOnly = true;
            // 
            // deliveryAddressIDDataGridViewTextBoxColumn
            // 
            this.deliveryAddressIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryAddressID";
            this.deliveryAddressIDDataGridViewTextBoxColumn.HeaderText = "Код дост.";
            this.deliveryAddressIDDataGridViewTextBoxColumn.Name = "deliveryAddressIDDataGridViewTextBoxColumn";
            this.deliveryAddressIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryAddressIDDataGridViewTextBoxColumn.Width = 55;
            // 
            // debtorDeliveryAddressDataGridViewTextBoxColumn
            // 
            this.debtorDeliveryAddressDataGridViewTextBoxColumn.DataPropertyName = "DebtorDeliveryAddress";
            this.debtorDeliveryAddressDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.debtorDeliveryAddressDataGridViewTextBoxColumn.Name = "debtorDeliveryAddressDataGridViewTextBoxColumn";
            this.debtorDeliveryAddressDataGridViewTextBoxColumn.ReadOnly = true;
            this.debtorDeliveryAddressDataGridViewTextBoxColumn.Width = 140;
            // 
            // UnloadingAddress
            // 
            this.UnloadingAddress.DataPropertyName = "UnloadingAddress";
            this.UnloadingAddress.HeaderText = "Пункт разгрузки";
            this.UnloadingAddress.Name = "UnloadingAddress";
            this.UnloadingAddress.ReadOnly = true;
            this.UnloadingAddress.Width = 140;
            // 
            // DeliveryInstructions
            // 
            this.DeliveryInstructions.DataPropertyName = "DeliveryInstructions";
            this.DeliveryInstructions.HeaderText = "Инструкции доставки";
            this.DeliveryInstructions.Name = "DeliveryInstructions";
            this.DeliveryInstructions.ReadOnly = true;
            this.DeliveryInstructions.Width = 140;
            // 
            // ManagerID
            // 
            this.ManagerID.DataPropertyName = "ManagerID";
            this.ManagerID.HeaderText = "Код предст.";
            this.ManagerID.Name = "ManagerID";
            this.ManagerID.ReadOnly = true;
            this.ManagerID.Width = 60;
            // 
            // ManagerName
            // 
            this.ManagerName.DataPropertyName = "ManagerName";
            this.ManagerName.HeaderText = "ФИО представителя";
            this.ManagerName.Name = "ManagerName";
            this.ManagerName.ReadOnly = true;
            this.ManagerName.Width = 180;
            // 
            // PaymentConditionID
            // 
            this.PaymentConditionID.DataPropertyName = "PaymentConditionID";
            this.PaymentConditionID.HeaderText = "Усл. опл.";
            this.PaymentConditionID.Name = "PaymentConditionID";
            this.PaymentConditionID.ReadOnly = true;
            this.PaymentConditionID.Width = 45;
            // 
            // SCGP_Flag
            // 
            this.SCGP_Flag.DataPropertyName = "SCGP_Flag";
            this.SCGP_Flag.HeaderText = "ДС";
            this.SCGP_Flag.Name = "SCGP_Flag";
            this.SCGP_Flag.ReadOnly = true;
            this.SCGP_Flag.Width = 30;
            // 
            // contextMenuForDocs
            // 
            this.contextMenuForDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefresh,
            this.toolStripSeparator4,
            this.miPrintPackage,
            this.toolStripSeparator5,
            this.miPrintInvoice,
            this.miPrintTaxInvoice,
            this.miPrintControlSheet,
            this.miPrintRegister,
            this.miPrintSaleRegister,
            this.miPrintRequirementOrder,
            this.miPrintBillInvoice,
            this.miPrintTareInvoice,
            this.miPrintDocAgreement,
            this.toolStripSeparator6,
            this.miPreviewInvoice,
            this.miPreviewInvoiceBase,
            this.miPreviewTaxInvoiceForOptima,
            this.miPreviewTaxInvoiceForClient,
            this.miPreviewControlSheet,
            this.miPreviewRegister,
            this.miPreviewSaleRegister,
            this.miPreviewRequirementOrder,
            this.miPreviewBillInvoice,
            this.miPreviewTareInvoice,
            this.miPreviewDocAgreement,
            this.toolStripSeparator10,
            this.miPreviewTenderInvoice});
            this.contextMenuForDocs.Name = "contextMenuForDocs";
            this.contextMenuForDocs.Size = new System.Drawing.Size(310, 534);
            // 
            // miRefresh
            // 
            this.miRefresh.Name = "miRefresh";
            this.miRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefresh.Size = new System.Drawing.Size(309, 22);
            this.miRefresh.Text = "Обновить список документов";
            this.miRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(306, 6);
            // 
            // miPrintPackage
            // 
            this.miPrintPackage.Name = "miPrintPackage";
            this.miPrintPackage.Size = new System.Drawing.Size(309, 22);
            this.miPrintPackage.Text = "Напечатать пакет документов";
            this.miPrintPackage.Click += new System.EventHandler(this.btnPrintPackage_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(306, 6);
            // 
            // miPrintInvoice
            // 
            this.miPrintInvoice.Name = "miPrintInvoice";
            this.miPrintInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPrintInvoice.Text = "Напечатать пакет расходных";
            this.miPrintInvoice.Click += new System.EventHandler(this.miPrintInvoice_Click);
            // 
            // miPrintTaxInvoice
            // 
            this.miPrintTaxInvoice.Name = "miPrintTaxInvoice";
            this.miPrintTaxInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPrintTaxInvoice.Text = "Напечатать пакет налоговых";
            this.miPrintTaxInvoice.Click += new System.EventHandler(this.miPrintTaxInvoice_Click);
            // 
            // miPrintControlSheet
            // 
            this.miPrintControlSheet.Name = "miPrintControlSheet";
            this.miPrintControlSheet.Size = new System.Drawing.Size(309, 22);
            this.miPrintControlSheet.Text = "Напечатать контрольный лист";
            this.miPrintControlSheet.Click += new System.EventHandler(this.miPrintControlSheet_Click);
            // 
            // miPrintRegister
            // 
            this.miPrintRegister.Name = "miPrintRegister";
            this.miPrintRegister.Size = new System.Drawing.Size(309, 22);
            this.miPrintRegister.Text = "Напечатать реестр лек. средств";
            this.miPrintRegister.Click += new System.EventHandler(this.miPrintRegister_Click);
            // 
            // miPrintSaleRegister
            // 
            this.miPrintSaleRegister.Name = "miPrintSaleRegister";
            this.miPrintSaleRegister.Size = new System.Drawing.Size(309, 22);
            this.miPrintSaleRegister.Text = "Напечатать реестр реализации лек. средств";
            this.miPrintSaleRegister.Visible = false;
            this.miPrintSaleRegister.Click += new System.EventHandler(this.miPrintSaleRegister_Click);
            // 
            // miPrintRequirementOrder
            // 
            this.miPrintRequirementOrder.Name = "miPrintRequirementOrder";
            this.miPrintRequirementOrder.Size = new System.Drawing.Size(309, 22);
            this.miPrintRequirementOrder.Text = "Напечатать заказ-требование";
            this.miPrintRequirementOrder.Click += new System.EventHandler(this.miPrintRequirementOrder_Click);
            // 
            // miPrintBillInvoice
            // 
            this.miPrintBillInvoice.Name = "miPrintBillInvoice";
            this.miPrintBillInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPrintBillInvoice.Text = "Напечатать счет-фактуру";
            this.miPrintBillInvoice.Click += new System.EventHandler(this.miPrintBillInvoice_Click);
            // 
            // miPrintTareInvoice
            // 
            this.miPrintTareInvoice.Name = "miPrintTareInvoice";
            this.miPrintTareInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPrintTareInvoice.Text = "Напечатать накладную на оборотную тару";
            this.miPrintTareInvoice.Click += new System.EventHandler(this.miPrintTareInvoice_Click);
            // 
            // miPrintDocAgreement
            // 
            this.miPrintDocAgreement.Name = "miPrintDocAgreement";
            this.miPrintDocAgreement.Size = new System.Drawing.Size(309, 22);
            this.miPrintDocAgreement.Text = "Напечатать доп. соглашение к тендеру";
            this.miPrintDocAgreement.Click += new System.EventHandler(this.miPrintDocAgreement_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(306, 6);
            // 
            // miPreviewInvoice
            // 
            this.miPreviewInvoice.Name = "miPreviewInvoice";
            this.miPreviewInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPreviewInvoice.Text = "Просмотреть расходную";
            this.miPreviewInvoice.Click += new System.EventHandler(this.miPreviewInvoice_Click);
            // 
            // miPreviewInvoiceBase
            // 
            this.miPreviewInvoiceBase.Name = "miPreviewInvoiceBase";
            this.miPreviewInvoiceBase.Size = new System.Drawing.Size(309, 22);
            this.miPreviewInvoiceBase.Text = "Просмотреть расходную (База накладная)";
            this.miPreviewInvoiceBase.Click += new System.EventHandler(this.miPreviewInvoice_Click);
            // 
            // miPreviewTaxInvoiceForOptima
            // 
            this.miPreviewTaxInvoiceForOptima.Name = "miPreviewTaxInvoiceForOptima";
            this.miPreviewTaxInvoiceForOptima.Size = new System.Drawing.Size(309, 22);
            this.miPreviewTaxInvoiceForOptima.Text = "Просмотреть налоговую для Оптимы";
            this.miPreviewTaxInvoiceForOptima.Click += new System.EventHandler(this.miPreviewTaxInvoice_Click);
            // 
            // miPreviewTaxInvoiceForClient
            // 
            this.miPreviewTaxInvoiceForClient.Name = "miPreviewTaxInvoiceForClient";
            this.miPreviewTaxInvoiceForClient.Size = new System.Drawing.Size(309, 22);
            this.miPreviewTaxInvoiceForClient.Text = "Просмотреть налоговую для клиента";
            this.miPreviewTaxInvoiceForClient.Click += new System.EventHandler(this.miPreviewTaxInvoice_Click);
            // 
            // miPreviewControlSheet
            // 
            this.miPreviewControlSheet.Name = "miPreviewControlSheet";
            this.miPreviewControlSheet.Size = new System.Drawing.Size(309, 22);
            this.miPreviewControlSheet.Text = "Просмотреть контрольный лист";
            this.miPreviewControlSheet.Click += new System.EventHandler(this.miPreviewControlSheet_Click);
            // 
            // miPreviewRegister
            // 
            this.miPreviewRegister.Name = "miPreviewRegister";
            this.miPreviewRegister.Size = new System.Drawing.Size(309, 22);
            this.miPreviewRegister.Text = "Просмотреть реестр лек. средств";
            this.miPreviewRegister.Click += new System.EventHandler(this.miPreviewRegister_Click);
            // 
            // miPreviewSaleRegister
            // 
            this.miPreviewSaleRegister.Name = "miPreviewSaleRegister";
            this.miPreviewSaleRegister.Size = new System.Drawing.Size(309, 22);
            this.miPreviewSaleRegister.Text = "Просмотреть реестр реализации лек. средств";
            this.miPreviewSaleRegister.Visible = false;
            this.miPreviewSaleRegister.Click += new System.EventHandler(this.miPreviewSaleRegister_Click);
            // 
            // miPreviewRequirementOrder
            // 
            this.miPreviewRequirementOrder.Name = "miPreviewRequirementOrder";
            this.miPreviewRequirementOrder.Size = new System.Drawing.Size(309, 22);
            this.miPreviewRequirementOrder.Text = "Просмотреть заказ-требование";
            this.miPreviewRequirementOrder.Click += new System.EventHandler(this.miPreviewRequirementOrder_Click);
            // 
            // miPreviewBillInvoice
            // 
            this.miPreviewBillInvoice.Name = "miPreviewBillInvoice";
            this.miPreviewBillInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPreviewBillInvoice.Text = "Просмотреть счет-фактуру";
            this.miPreviewBillInvoice.Click += new System.EventHandler(this.miPreviewBillInvoice_Click);
            // 
            // miPreviewTareInvoice
            // 
            this.miPreviewTareInvoice.Name = "miPreviewTareInvoice";
            this.miPreviewTareInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPreviewTareInvoice.Text = "Просмотреть накладную на оборотную тару";
            this.miPreviewTareInvoice.Click += new System.EventHandler(this.miPreviewTareInvoice_Click);
            // 
            // miPreviewDocAgreement
            // 
            this.miPreviewDocAgreement.Name = "miPreviewDocAgreement";
            this.miPreviewDocAgreement.Size = new System.Drawing.Size(309, 22);
            this.miPreviewDocAgreement.Text = "Просмотреть доп. соглашение к тендеру";
            this.miPreviewDocAgreement.Click += new System.EventHandler(this.miPreviewDocAgreement_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(306, 6);
            this.toolStripSeparator10.Visible = false;
            // 
            // miPreviewTenderInvoice
            // 
            this.miPreviewTenderInvoice.Name = "miPreviewTenderInvoice";
            this.miPreviewTenderInvoice.Size = new System.Drawing.Size(309, 22);
            this.miPreviewTenderInvoice.Text = "Тендерная накладная";
            this.miPreviewTenderInvoice.Visible = false;
            this.miPreviewTenderInvoice.Click += new System.EventHandler(this.miPreviewTenderInvoice_Click);
            // 
            // docsBindingSource
            // 
            this.docsBindingSource.DataMember = "Docs";
            this.docsBindingSource.DataSource = this.printNakl;
            // 
            // printNakl
            // 
            this.printNakl.DataSetName = "PrintNakl";
            this.printNakl.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnableWaybillMode,
            this.toolStripSeparator11,
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnFind,
            this.toolStripSeparator9,
            this.btnPrintFullPackageByWaybill,
            this.tssPrintFullPackageByWaybill,
            this.btnPrintPackage,
            this.toolStripSeparator2,
            this.btnExportDocs,
            this.toolStripSeparator3,
            this.btnCheckInvoice,
            this.toolStripSeparator8});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 40);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1423, 55);
            this.toolStripDoc.TabIndex = 7;
            this.toolStripDoc.Text = "Панель инструментов документа";
            // 
            // btnEnableWaybillMode
            // 
            this.btnEnableWaybillMode.Image = global::WMSOffice.Properties.Resources.delivery;
            this.btnEnableWaybillMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEnableWaybillMode.Name = "btnEnableWaybillMode";
            this.btnEnableWaybillMode.Size = new System.Drawing.Size(91, 52);
            this.btnEnableWaybillMode.Text = "Режим\nТТН";
            this.btnEnableWaybillMode.Click += new System.EventHandler(this.btnEnableWaybillMode_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(52, 52);
            this.btnRefresh.Text = "Обновить список документов";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.find;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(104, 52);
            this.btnFind.Text = "Поиск\nв архиве";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintFullPackageByWaybill
            // 
            this.btnPrintFullPackageByWaybill.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintFullPackageByWaybill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintFullPackageByWaybill.Name = "btnPrintFullPackageByWaybill";
            this.btnPrintFullPackageByWaybill.Size = new System.Drawing.Size(131, 52);
            this.btnPrintFullPackageByWaybill.Text = "Напечатать\rТТН с пакетом\rдокументов";
            this.btnPrintFullPackageByWaybill.Visible = false;
            this.btnPrintFullPackageByWaybill.Click += new System.EventHandler(this.btnPrintFullPackageByWaybill_Click);
            // 
            // tssPrintFullPackageByWaybill
            // 
            this.tssPrintFullPackageByWaybill.Name = "tssPrintFullPackageByWaybill";
            this.tssPrintFullPackageByWaybill.Size = new System.Drawing.Size(6, 55);
            this.tssPrintFullPackageByWaybill.Visible = false;
            // 
            // btnPrintPackage
            // 
            this.btnPrintPackage.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintPackage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintPackage.Name = "btnPrintPackage";
            this.btnPrintPackage.Size = new System.Drawing.Size(120, 52);
            this.btnPrintPackage.Text = "Напечатать\rпакет\rдокументов";
            this.btnPrintPackage.ToolTipText = "Напечатать пакет документов";
            this.btnPrintPackage.Click += new System.EventHandler(this.btnPrintPackage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportDocs
            // 
            this.btnExportDocs.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportDocs.Name = "btnExportDocs";
            this.btnExportDocs.Size = new System.Drawing.Size(101, 52);
            this.btnExportDocs.Text = "Экспорт\nв Excel";
            this.btnExportDocs.Click += new System.EventHandler(this.btnExportDocs_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCheckInvoice
            // 
            this.btnCheckInvoice.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCheckInvoice.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnCheckInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCheckInvoice.Name = "btnCheckInvoice";
            this.btnCheckInvoice.Size = new System.Drawing.Size(116, 52);
            this.btnCheckInvoice.Text = "Проверка\r\nнакладных";
            this.btnCheckInvoice.Click += new System.EventHandler(this.btnCheckInvoice_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // lblDocsCount
            // 
            this.lblDocsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocsCount.Location = new System.Drawing.Point(846, 70);
            this.lblDocsCount.Name = "lblDocsCount";
            this.lblDocsCount.Size = new System.Drawing.Size(148, 15);
            this.lblDocsCount.TabIndex = 10;
            this.lblDocsCount.Text = "0";
            this.lblDocsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDocsCountCaption
            // 
            this.lblDocsCountCaption.AutoSize = true;
            this.lblDocsCountCaption.Location = new System.Drawing.Point(846, 56);
            this.lblDocsCountCaption.Name = "lblDocsCountCaption";
            this.lblDocsCountCaption.Size = new System.Drawing.Size(148, 13);
            this.lblDocsCountCaption.TabIndex = 9;
            this.lblDocsCountCaption.Text = "К-во накладных для печати:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CompanyID";
            this.dataGridViewTextBoxColumn1.HeaderText = "CompanyID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "OrderID";
            this.dataGridViewTextBoxColumn2.HeaderText = "OrderID";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderType";
            this.dataGridViewTextBoxColumn3.HeaderText = "OrderType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "OrderDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ManagerID";
            this.dataGridViewTextBoxColumn5.HeaderText = "ManagerID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 55;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ManagerName";
            this.dataGridViewTextBoxColumn6.HeaderText = "ManagerName";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CustPriceCoef";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn7.HeaderText = "CustPriceCoef";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 80;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "OrderHasTwoFactures";
            this.dataGridViewCheckBoxColumn1.HeaderText = "OrderHasTwoFactures";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Visible = false;
            this.dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PaymentConditionID";
            this.dataGridViewTextBoxColumn8.HeaderText = "PaymentConditionID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            this.dataGridViewTextBoxColumn8.Width = 80;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "PostPayDays";
            this.dataGridViewTextBoxColumn9.HeaderText = "PostPayDays";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Visible = false;
            this.dataGridViewTextBoxColumn9.Width = 60;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "RouteCode";
            this.dataGridViewTextBoxColumn10.HeaderText = "RouteCode";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 80;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DocumentCategory";
            this.dataGridViewTextBoxColumn11.HeaderText = "DocumentCategory";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            this.dataGridViewTextBoxColumn11.Width = 80;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "IsInterbranch";
            this.dataGridViewCheckBoxColumn2.HeaderText = "IsInterbranch";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Visible = false;
            this.dataGridViewCheckBoxColumn2.Width = 50;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "IsPackPrinted";
            this.dataGridViewCheckBoxColumn3.HeaderText = "IsPackPrinted";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Visible = false;
            this.dataGridViewCheckBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "ProxyData";
            this.dataGridViewTextBoxColumn12.HeaderText = "ProxyData";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 140;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "NalogDeliveryResponsePerson";
            this.dataGridViewTextBoxColumn13.HeaderText = "NalogDeliveryResponsePerson";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 55;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "SDDCT";
            this.dataGridViewTextBoxColumn14.HeaderText = "SDDCT";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 120;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "Filial";
            this.dataGridViewTextBoxColumn15.HeaderText = "Filial";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 200;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "DebtorOKPO";
            this.dataGridViewTextBoxColumn16.HeaderText = "DebtorOKPO";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "DebtorJurAddress";
            this.dataGridViewTextBoxColumn17.HeaderText = "DebtorJurAddress";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            this.dataGridViewTextBoxColumn17.Width = 55;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "DeliveryAddressID";
            this.dataGridViewTextBoxColumn18.HeaderText = "DeliveryAddressID";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            this.dataGridViewTextBoxColumn18.Width = 120;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "DebtorDeliveryAddress";
            this.dataGridViewTextBoxColumn19.HeaderText = "DebtorDeliveryAddress";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            this.dataGridViewTextBoxColumn19.Width = 120;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "DeliveryInstructions";
            this.dataGridViewTextBoxColumn20.HeaderText = "DeliveryInstructions";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            this.dataGridViewTextBoxColumn20.Width = 60;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "ManagerID";
            this.dataGridViewTextBoxColumn21.HeaderText = "ManagerID";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 180;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "ManagerName";
            this.dataGridViewTextBoxColumn22.HeaderText = "ManagerName";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "CreatedUserName";
            this.dataGridViewTextBoxColumn23.HeaderText = "CreatedUserName";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.DataPropertyName = "CustPriceCoef";
            this.dataGridViewTextBoxColumn24.HeaderText = "CustPriceCoef";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "DebtorContractNum";
            this.dataGridViewTextBoxColumn25.HeaderText = "DebtorContractNum";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "DebtorContractDate";
            this.dataGridViewTextBoxColumn26.HeaderText = "DebtorContractDate";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "DebtorCertNumber";
            this.dataGridViewTextBoxColumn27.HeaderText = "DebtorCertNumber";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "DebtorPhone";
            this.dataGridViewTextBoxColumn28.HeaderText = "DebtorPhone";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "PaymentConditionID";
            this.dataGridViewTextBoxColumn29.HeaderText = "PaymentConditionID";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "PostPayDays";
            this.dataGridViewTextBoxColumn30.HeaderText = "PostPayDays";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "InvoiceSum";
            this.dataGridViewTextBoxColumn31.HeaderText = "InvoiceSum";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "InvoiceSumWithVAT";
            this.dataGridViewTextBoxColumn32.HeaderText = "InvoiceSumWithVAT";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.DataPropertyName = "InvoiceSumVAT";
            this.dataGridViewTextBoxColumn33.HeaderText = "InvoiceSumVAT";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "InvoiceSumNal";
            this.dataGridViewTextBoxColumn34.HeaderText = "InvoiceSumNal";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "InvoiceSumWithVATNal";
            this.dataGridViewTextBoxColumn35.HeaderText = "InvoiceSumWithVATNal";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "InvoiceSumVATNal";
            this.dataGridViewTextBoxColumn36.HeaderText = "InvoiceSumVATNal";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "InvoicePrintDate";
            this.dataGridViewTextBoxColumn37.HeaderText = "InvoicePrintDate";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "InvoiceCount";
            this.dataGridViewTextBoxColumn38.HeaderText = "InvoiceCount";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "TaxInvoiceCount";
            this.dataGridViewTextBoxColumn39.HeaderText = "TaxInvoiceCount";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.DataPropertyName = "InvoiceDebtorCount";
            this.dataGridViewTextBoxColumn40.HeaderText = "InvoiceDebtorCount";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.DataPropertyName = "RegisterCount";
            this.dataGridViewTextBoxColumn41.HeaderText = "RegisterCount";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.DataPropertyName = "RouteCode";
            this.dataGridViewTextBoxColumn42.HeaderText = "RouteCode";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "OrderHasTwoFactures";
            this.dataGridViewCheckBoxColumn4.HeaderText = "OrderHasTwoFactures";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.DataPropertyName = "OrderInvoicesCount";
            this.dataGridViewTextBoxColumn43.HeaderText = "OrderInvoicesCount";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "DocumentCategory";
            this.dataGridViewTextBoxColumn44.HeaderText = "DocumentCategory";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.DataPropertyName = "ProxyData";
            this.dataGridViewTextBoxColumn45.HeaderText = "ProxyData";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.DataPropertyName = "NalogDeliveryResponsePerson";
            this.dataGridViewTextBoxColumn46.HeaderText = "NalogDeliveryResponsePerson";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "SDDCT";
            this.dataGridViewTextBoxColumn47.HeaderText = "SDDCT";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.DataPropertyName = "Filial";
            this.dataGridViewTextBoxColumn48.HeaderText = "Filial";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            // 
            // lblDocsCountNT
            // 
            this.lblDocsCountNT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDocsCountNT.Location = new System.Drawing.Point(630, 8);
            this.lblDocsCountNT.Name = "lblDocsCountNT";
            this.lblDocsCountNT.Size = new System.Drawing.Size(67, 15);
            this.lblDocsCountNT.TabIndex = 12;
            this.lblDocsCountNT.Text = "0";
            this.lblDocsCountNT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(463, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "К-во не обработанных заказов:";
            // 
            // panelRL
            // 
            this.panelRL.Controls.Add(this.chbIsRemotePrint);
            this.panelRL.Controls.Add(this.tsShowHideRouteLists);
            this.panelRL.Controls.Add(this.toolStrip1);
            this.panelRL.Controls.Add(this.lblDocsCountNT);
            this.panelRL.Controls.Add(this.label2);
            this.panelRL.Controls.Add(this.label1);
            this.panelRL.Controls.Add(this.tbScaner);
            this.panelRL.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelRL.Location = new System.Drawing.Point(0, 95);
            this.panelRL.Name = "panelRL";
            this.panelRL.Size = new System.Drawing.Size(1423, 30);
            this.panelRL.TabIndex = 13;
            // 
            // chbIsRemotePrint
            // 
            this.chbIsRemotePrint.AutoSize = true;
            this.chbIsRemotePrint.BackColor = System.Drawing.SystemColors.Info;
            this.chbIsRemotePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chbIsRemotePrint.ForeColor = System.Drawing.Color.Blue;
            this.chbIsRemotePrint.Location = new System.Drawing.Point(1156, 7);
            this.chbIsRemotePrint.Name = "chbIsRemotePrint";
            this.chbIsRemotePrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chbIsRemotePrint.Size = new System.Drawing.Size(126, 17);
            this.chbIsRemotePrint.TabIndex = 15;
            this.chbIsRemotePrint.Text = "Отложенная печать";
            this.chbIsRemotePrint.UseVisualStyleBackColor = false;
            this.chbIsRemotePrint.CheckedChanged += new System.EventHandler(this.chbIsRemotePrint_CheckedChanged);
            // 
            // tsShowHideRouteLists
            // 
            this.tsShowHideRouteLists.Dock = System.Windows.Forms.DockStyle.None;
            this.tsShowHideRouteLists.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowHideRouteLists});
            this.tsShowHideRouteLists.Location = new System.Drawing.Point(0, 3);
            this.tsShowHideRouteLists.Name = "tsShowHideRouteLists";
            this.tsShowHideRouteLists.Size = new System.Drawing.Size(33, 25);
            this.tsShowHideRouteLists.TabIndex = 14;
            this.tsShowHideRouteLists.Text = "toolStrip2";
            // 
            // btnShowHideRouteLists
            // 
            this.btnShowHideRouteLists.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowHideRouteLists.Enabled = false;
            this.btnShowHideRouteLists.Image = global::WMSOffice.Properties.Resources.chevron_right;
            this.btnShowHideRouteLists.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowHideRouteLists.Name = "btnShowHideRouteLists";
            this.btnShowHideRouteLists.Size = new System.Drawing.Size(23, 22);
            this.btnShowHideRouteLists.Text = "toolStripButton1";
            this.btnShowHideRouteLists.Click += new System.EventHandler(this.btnShowHideRouteLists_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPrinter,
            this.cbPrinters});
            this.toolStrip1.Location = new System.Drawing.Point(836, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(315, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lblPrinter
            // 
            this.lblPrinter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(53, 22);
            this.lblPrinter.Text = "Принтер:";
            // 
            // cbPrinters
            // 
            this.cbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrinters.DropDownWidth = 245;
            this.cbPrinters.Name = "cbPrinters";
            this.cbPrinters.Size = new System.Drawing.Size(250, 25);
            this.cbPrinters.SelectedIndexChanged += new System.EventHandler(this.cbPrinters_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Маршрутный лист";
            // 
            // tbScaner
            // 
            this.tbScaner.AllowType = true;
            this.tbScaner.AutoConvert = true;
            this.tbScaner.DelayThreshold = 50;
            this.tbScaner.Location = new System.Drawing.Point(138, 3);
            this.tbScaner.Name = "tbScaner";
            this.tbScaner.RaiseTextChangeWithoutEnter = false;
            this.tbScaner.ReadOnly = false;
            this.tbScaner.ScannerListener = null;
            this.tbScaner.Size = new System.Drawing.Size(305, 25);
            this.tbScaner.TabIndex = 0;
            this.tbScaner.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.tbScaner.UseParentFont = false;
            this.tbScaner.UseScanModeOnly = false;
            // 
            // pnlLegend
            // 
            this.pnlLegend.Controls.Add(this.label6);
            this.pnlLegend.Controls.Add(this.label5);
            this.pnlLegend.Controls.Add(this.label4);
            this.pnlLegend.Controls.Add(this.label3);
            this.pnlLegend.Location = new System.Drawing.Point(1000, 43);
            this.pnlLegend.Name = "pnlLegend";
            this.pnlLegend.Size = new System.Drawing.Size(152, 45);
            this.pnlLegend.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(41, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "- обработанные РН";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGreen;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(0, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 20);
            this.label5.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "- электронные РН";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Khaki;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 20);
            this.label3.TabIndex = 0;
            // 
            // scWaybillDocsContent
            // 
            this.scWaybillDocsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scWaybillDocsContent.IsSplitterFixed = true;
            this.scWaybillDocsContent.Location = new System.Drawing.Point(0, 125);
            this.scWaybillDocsContent.Name = "scWaybillDocsContent";
            this.scWaybillDocsContent.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scWaybillDocsContent.Panel1
            // 
            this.scWaybillDocsContent.Panel1.Controls.Add(this.scRouteListWaybillsContent);
            this.scWaybillDocsContent.Panel1Collapsed = true;
            // 
            // scWaybillDocsContent.Panel2
            // 
            this.scWaybillDocsContent.Panel2.Controls.Add(this.pnlInvoiceContent);
            this.scWaybillDocsContent.Panel2.Controls.Add(this.lblInvoiceHeader);
            this.scWaybillDocsContent.Size = new System.Drawing.Size(1423, 527);
            this.scWaybillDocsContent.SplitterDistance = 180;
            this.scWaybillDocsContent.TabIndex = 15;
            // 
            // scRouteListWaybillsContent
            // 
            this.scRouteListWaybillsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scRouteListWaybillsContent.Location = new System.Drawing.Point(0, 0);
            this.scRouteListWaybillsContent.Name = "scRouteListWaybillsContent";
            // 
            // scRouteListWaybillsContent.Panel1
            // 
            this.scRouteListWaybillsContent.Panel1.Controls.Add(this.pnlRouteListContent);
            this.scRouteListWaybillsContent.Panel1.Controls.Add(this.lblRouteListHeader);
            this.scRouteListWaybillsContent.Panel1Collapsed = true;
            // 
            // scRouteListWaybillsContent.Panel2
            // 
            this.scRouteListWaybillsContent.Panel2.Controls.Add(this.pnlWaybillContent);
            this.scRouteListWaybillsContent.Panel2.Controls.Add(this.lblWaybillHeader);
            this.scRouteListWaybillsContent.Size = new System.Drawing.Size(1423, 180);
            this.scRouteListWaybillsContent.SplitterDistance = 260;
            this.scRouteListWaybillsContent.TabIndex = 12;
            // 
            // pnlRouteListContent
            // 
            this.pnlRouteListContent.Controls.Add(this.dgvRouteListDocs);
            this.pnlRouteListContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRouteListContent.Location = new System.Drawing.Point(0, 25);
            this.pnlRouteListContent.Name = "pnlRouteListContent";
            this.pnlRouteListContent.Size = new System.Drawing.Size(260, 155);
            this.pnlRouteListContent.TabIndex = 12;
            // 
            // dgvRouteListDocs
            // 
            this.dgvRouteListDocs.AllowUserToAddRows = false;
            this.dgvRouteListDocs.AllowUserToDeleteRows = false;
            this.dgvRouteListDocs.AllowUserToOrderColumns = true;
            this.dgvRouteListDocs.AllowUserToResizeRows = false;
            this.dgvRouteListDocs.AutoGenerateColumns = false;
            this.dgvRouteListDocs.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRouteListDocs.ColumnHeadersHeight = 34;
            this.dgvRouteListDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRouteListDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcNeedPrint,
            this.routeListNumberDataGridViewTextBoxColumn1,
            this.driversDataGridViewTextBoxColumn1});
            this.dgvRouteListDocs.DataSource = this.routeListDocsBindingSource;
            this.dgvRouteListDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteListDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvRouteListDocs.MultiSelect = false;
            this.dgvRouteListDocs.Name = "dgvRouteListDocs";
            this.dgvRouteListDocs.ReadOnly = true;
            this.dgvRouteListDocs.RowHeadersVisible = false;
            this.dgvRouteListDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRouteListDocs.Size = new System.Drawing.Size(260, 155);
            this.dgvRouteListDocs.TabIndex = 0;
            this.dgvRouteListDocs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRouteListDocs_DataBindingComplete);
            this.dgvRouteListDocs.SelectionChanged += new System.EventHandler(this.dgvRouteListDocs_SelectionChanged);
            // 
            // dgvcNeedPrint
            // 
            this.dgvcNeedPrint.HeaderText = "";
            this.dgvcNeedPrint.Name = "dgvcNeedPrint";
            this.dgvcNeedPrint.ReadOnly = true;
            this.dgvcNeedPrint.Width = 20;
            // 
            // routeListNumberDataGridViewTextBoxColumn1
            // 
            this.routeListNumberDataGridViewTextBoxColumn1.DataPropertyName = "Route_List_Number";
            this.routeListNumberDataGridViewTextBoxColumn1.HeaderText = "№ МЛ";
            this.routeListNumberDataGridViewTextBoxColumn1.Name = "routeListNumberDataGridViewTextBoxColumn1";
            this.routeListNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.routeListNumberDataGridViewTextBoxColumn1.Width = 65;
            // 
            // driversDataGridViewTextBoxColumn1
            // 
            this.driversDataGridViewTextBoxColumn1.DataPropertyName = "Drivers";
            this.driversDataGridViewTextBoxColumn1.HeaderText = "Водители";
            this.driversDataGridViewTextBoxColumn1.Name = "driversDataGridViewTextBoxColumn1";
            this.driversDataGridViewTextBoxColumn1.ReadOnly = true;
            this.driversDataGridViewTextBoxColumn1.Width = 150;
            // 
            // routeListDocsBindingSource
            // 
            this.routeListDocsBindingSource.DataMember = "Route_List_Docs";
            this.routeListDocsBindingSource.DataSource = this.printNakl;
            // 
            // lblRouteListHeader
            // 
            this.lblRouteListHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblRouteListHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblRouteListHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRouteListHeader.Location = new System.Drawing.Point(0, 0);
            this.lblRouteListHeader.Name = "lblRouteListHeader";
            this.lblRouteListHeader.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblRouteListHeader.Size = new System.Drawing.Size(260, 25);
            this.lblRouteListHeader.TabIndex = 11;
            this.lblRouteListHeader.Text = "МЛ";
            // 
            // pnlWaybillContent
            // 
            this.pnlWaybillContent.Controls.Add(this.dgvWaybillDocs);
            this.pnlWaybillContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWaybillContent.Location = new System.Drawing.Point(0, 25);
            this.pnlWaybillContent.Name = "pnlWaybillContent";
            this.pnlWaybillContent.Size = new System.Drawing.Size(1423, 155);
            this.pnlWaybillContent.TabIndex = 11;
            // 
            // dgvWaybillDocs
            // 
            this.dgvWaybillDocs.AllowUserToAddRows = false;
            this.dgvWaybillDocs.AllowUserToDeleteRows = false;
            this.dgvWaybillDocs.AllowUserToOrderColumns = true;
            this.dgvWaybillDocs.AllowUserToResizeRows = false;
            this.dgvWaybillDocs.AutoGenerateColumns = false;
            this.dgvWaybillDocs.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvWaybillDocs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvWaybillDocs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWaybillDocs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvcIsReadyToPrint,
            this.planDateStartDataGridViewTextBoxColumn,
            this.routeListNumberDataGridViewTextBoxColumn,
            this.tTNNoDataGridViewTextBoxColumn,
            this.EWbFormattedFlagName,
            this.printedDocsDataGridViewTextBoxColumn,
            this.docsDataGridViewTextBoxColumn,
            this.ordersDataGridViewTextBoxColumn,
            this.driversDataGridViewTextBoxColumn,
            this.tTNameDataGridViewTextBoxColumn,
            this.regionDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.deliveryCodeDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.NeedPrint,
            this.WbFormattedStatusName});
            this.dgvWaybillDocs.ContextMenuStrip = this.contextMenuForWaybillDocs;
            this.dgvWaybillDocs.DataSource = this.waybillDocsBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvWaybillDocs.DefaultCellStyle = dataGridViewCellStyle12;
            this.dgvWaybillDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWaybillDocs.Location = new System.Drawing.Point(0, 0);
            this.dgvWaybillDocs.Name = "dgvWaybillDocs";
            this.dgvWaybillDocs.ReadOnly = true;
            this.dgvWaybillDocs.RowHeadersVisible = false;
            this.dgvWaybillDocs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWaybillDocs.Size = new System.Drawing.Size(1423, 155);
            this.dgvWaybillDocs.TabIndex = 0;
            this.dgvWaybillDocs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvWaybillDocs_DataBindingComplete);
            this.dgvWaybillDocs.SelectionChanged += new System.EventHandler(this.dgvWaybillDocs_SelectionChanged);
            // 
            // dgvcIsReadyToPrint
            // 
            this.dgvcIsReadyToPrint.HeaderText = "";
            this.dgvcIsReadyToPrint.Name = "dgvcIsReadyToPrint";
            this.dgvcIsReadyToPrint.ReadOnly = true;
            this.dgvcIsReadyToPrint.Width = 20;
            // 
            // planDateStartDataGridViewTextBoxColumn
            // 
            this.planDateStartDataGridViewTextBoxColumn.DataPropertyName = "Plan_Date_Start";
            dataGridViewCellStyle8.Format = "dd.MM.yyyy HH:mm";
            dataGridViewCellStyle8.NullValue = null;
            this.planDateStartDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.planDateStartDataGridViewTextBoxColumn.HeaderText = "Дата выезда";
            this.planDateStartDataGridViewTextBoxColumn.Name = "planDateStartDataGridViewTextBoxColumn";
            this.planDateStartDataGridViewTextBoxColumn.ReadOnly = true;
            this.planDateStartDataGridViewTextBoxColumn.ToolTipText = "Дата выезда (план)";
            // 
            // routeListNumberDataGridViewTextBoxColumn
            // 
            this.routeListNumberDataGridViewTextBoxColumn.DataPropertyName = "Route_List_Number";
            this.routeListNumberDataGridViewTextBoxColumn.HeaderText = "№ МЛ";
            this.routeListNumberDataGridViewTextBoxColumn.Name = "routeListNumberDataGridViewTextBoxColumn";
            this.routeListNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.routeListNumberDataGridViewTextBoxColumn.Width = 65;
            // 
            // tTNNoDataGridViewTextBoxColumn
            // 
            this.tTNNoDataGridViewTextBoxColumn.DataPropertyName = "TTN_No";
            this.tTNNoDataGridViewTextBoxColumn.HeaderText = "№ ТТН";
            this.tTNNoDataGridViewTextBoxColumn.Name = "tTNNoDataGridViewTextBoxColumn";
            this.tTNNoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // EWbFormattedFlagName
            // 
            this.EWbFormattedFlagName.DataPropertyName = "EWbFormattedFlagName";
            this.EWbFormattedFlagName.HeaderText = "Наличие e-ТТН";
            this.EWbFormattedFlagName.Name = "EWbFormattedFlagName";
            this.EWbFormattedFlagName.ReadOnly = true;
            // 
            // printedDocsDataGridViewTextBoxColumn
            // 
            this.printedDocsDataGridViewTextBoxColumn.DataPropertyName = "Printed_Docs";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            this.printedDocsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.printedDocsDataGridViewTextBoxColumn.HeaderText = "Напечатано РН";
            this.printedDocsDataGridViewTextBoxColumn.Name = "printedDocsDataGridViewTextBoxColumn";
            this.printedDocsDataGridViewTextBoxColumn.ReadOnly = true;
            this.printedDocsDataGridViewTextBoxColumn.Width = 70;
            // 
            // docsDataGridViewTextBoxColumn
            // 
            this.docsDataGridViewTextBoxColumn.DataPropertyName = "Docs";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.docsDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle10;
            this.docsDataGridViewTextBoxColumn.HeaderText = "Всего РН";
            this.docsDataGridViewTextBoxColumn.Name = "docsDataGridViewTextBoxColumn";
            this.docsDataGridViewTextBoxColumn.ReadOnly = true;
            this.docsDataGridViewTextBoxColumn.Width = 70;
            // 
            // ordersDataGridViewTextBoxColumn
            // 
            this.ordersDataGridViewTextBoxColumn.DataPropertyName = "Orders";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            this.ordersDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle11;
            this.ordersDataGridViewTextBoxColumn.HeaderText = "Всего заказов";
            this.ordersDataGridViewTextBoxColumn.Name = "ordersDataGridViewTextBoxColumn";
            this.ordersDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordersDataGridViewTextBoxColumn.Width = 70;
            // 
            // driversDataGridViewTextBoxColumn
            // 
            this.driversDataGridViewTextBoxColumn.DataPropertyName = "Drivers";
            this.driversDataGridViewTextBoxColumn.HeaderText = "Водители";
            this.driversDataGridViewTextBoxColumn.Name = "driversDataGridViewTextBoxColumn";
            this.driversDataGridViewTextBoxColumn.ReadOnly = true;
            this.driversDataGridViewTextBoxColumn.Width = 150;
            // 
            // tTNameDataGridViewTextBoxColumn
            // 
            this.tTNameDataGridViewTextBoxColumn.DataPropertyName = "TT_Name";
            this.tTNameDataGridViewTextBoxColumn.HeaderText = "Дебитор доставки";
            this.tTNameDataGridViewTextBoxColumn.Name = "tTNameDataGridViewTextBoxColumn";
            this.tTNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.tTNameDataGridViewTextBoxColumn.Width = 200;
            // 
            // regionDataGridViewTextBoxColumn
            // 
            this.regionDataGridViewTextBoxColumn.DataPropertyName = "Region";
            this.regionDataGridViewTextBoxColumn.HeaderText = "Регион";
            this.regionDataGridViewTextBoxColumn.Name = "regionDataGridViewTextBoxColumn";
            this.regionDataGridViewTextBoxColumn.ReadOnly = true;
            this.regionDataGridViewTextBoxColumn.Width = 150;
            // 
            // cityDataGridViewTextBoxColumn
            // 
            this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
            this.cityDataGridViewTextBoxColumn.HeaderText = "Город";
            this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
            this.cityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deliveryCodeDataGridViewTextBoxColumn
            // 
            this.deliveryCodeDataGridViewTextBoxColumn.DataPropertyName = "Delivery_Code";
            this.deliveryCodeDataGridViewTextBoxColumn.HeaderText = "Код дост.";
            this.deliveryCodeDataGridViewTextBoxColumn.Name = "deliveryCodeDataGridViewTextBoxColumn";
            this.deliveryCodeDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryCodeDataGridViewTextBoxColumn.Width = 50;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес доставки";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 150;
            // 
            // NeedPrint
            // 
            this.NeedPrint.DataPropertyName = "NeedPrint";
            this.NeedPrint.HeaderText = "Отм.";
            this.NeedPrint.Name = "NeedPrint";
            this.NeedPrint.ReadOnly = true;
            this.NeedPrint.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NeedPrint.ToolTipText = "Необходимость печати";
            this.NeedPrint.Width = 30;
            // 
            // WbFormattedStatusName
            // 
            this.WbFormattedStatusName.DataPropertyName = "WbFormattedStatusName";
            this.WbFormattedStatusName.HeaderText = "Статус";
            this.WbFormattedStatusName.Name = "WbFormattedStatusName";
            this.WbFormattedStatusName.ReadOnly = true;
            this.WbFormattedStatusName.Width = 150;
            // 
            // contextMenuForWaybillDocs
            // 
            this.contextMenuForWaybillDocs.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRefreshWaybillDocs,
            this.toolStripSeparator12,
            this.miPrintWaybillDoc,
            this.miPrintPackageByWaybill,
            this.miPrintFullPackageByWaybill,
            this.toolStripSeparator7,
            this.miRePrintFullPackageByWaybill,
            this.toolStripSeparator13,
            this.miPreviewWaybillDoc});
            this.contextMenuForWaybillDocs.Name = "contextMenuForWaybillDocs";
            this.contextMenuForWaybillDocs.Size = new System.Drawing.Size(326, 154);
            // 
            // miRefreshWaybillDocs
            // 
            this.miRefreshWaybillDocs.Name = "miRefreshWaybillDocs";
            this.miRefreshWaybillDocs.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.miRefreshWaybillDocs.Size = new System.Drawing.Size(325, 22);
            this.miRefreshWaybillDocs.Text = "Обновить список документов";
            this.miRefreshWaybillDocs.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(322, 6);
            // 
            // miPrintWaybillDoc
            // 
            this.miPrintWaybillDoc.Name = "miPrintWaybillDoc";
            this.miPrintWaybillDoc.Size = new System.Drawing.Size(325, 22);
            this.miPrintWaybillDoc.Text = "Напечатать ТТН";
            this.miPrintWaybillDoc.Click += new System.EventHandler(this.miPrintWaybillDoc_Click);
            // 
            // miPrintPackageByWaybill
            // 
            this.miPrintPackageByWaybill.Name = "miPrintPackageByWaybill";
            this.miPrintPackageByWaybill.Size = new System.Drawing.Size(325, 22);
            this.miPrintPackageByWaybill.Text = "Напечатать пакет документов";
            this.miPrintPackageByWaybill.Click += new System.EventHandler(this.miPrintPackageByWaybill_Click);
            // 
            // miPrintFullPackageByWaybill
            // 
            this.miPrintFullPackageByWaybill.Name = "miPrintFullPackageByWaybill";
            this.miPrintFullPackageByWaybill.Size = new System.Drawing.Size(325, 22);
            this.miPrintFullPackageByWaybill.Text = "Напечатать ТТН с пакетом документов";
            this.miPrintFullPackageByWaybill.Click += new System.EventHandler(this.miPrintFullPackageByWaybill_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(322, 6);
            // 
            // miRePrintFullPackageByWaybill
            // 
            this.miRePrintFullPackageByWaybill.Name = "miRePrintFullPackageByWaybill";
            this.miRePrintFullPackageByWaybill.Size = new System.Drawing.Size(325, 22);
            this.miRePrintFullPackageByWaybill.Text = "Напечатать ТТН с пакетом документов повторно";
            this.miRePrintFullPackageByWaybill.Click += new System.EventHandler(this.miRePrintFullPackageByWaybill_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(322, 6);
            // 
            // miPreviewWaybillDoc
            // 
            this.miPreviewWaybillDoc.Name = "miPreviewWaybillDoc";
            this.miPreviewWaybillDoc.Size = new System.Drawing.Size(325, 22);
            this.miPreviewWaybillDoc.Text = "Просмотреть ТТН";
            this.miPreviewWaybillDoc.Click += new System.EventHandler(this.miPreviewWaybillDoc_Click);
            // 
            // waybillDocsBindingSource
            // 
            this.waybillDocsBindingSource.DataMember = "Waybill_Docs";
            this.waybillDocsBindingSource.DataSource = this.printNakl;
            // 
            // lblWaybillHeader
            // 
            this.lblWaybillHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblWaybillHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWaybillHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblWaybillHeader.Location = new System.Drawing.Point(0, 0);
            this.lblWaybillHeader.Name = "lblWaybillHeader";
            this.lblWaybillHeader.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblWaybillHeader.Size = new System.Drawing.Size(1423, 25);
            this.lblWaybillHeader.TabIndex = 10;
            this.lblWaybillHeader.Text = "ТТН";
            // 
            // pnlInvoiceContent
            // 
            this.pnlInvoiceContent.Controls.Add(this.dgvDocs);
            this.pnlInvoiceContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlInvoiceContent.Location = new System.Drawing.Point(0, 25);
            this.pnlInvoiceContent.Name = "pnlInvoiceContent";
            this.pnlInvoiceContent.Size = new System.Drawing.Size(1423, 502);
            this.pnlInvoiceContent.TabIndex = 10;
            // 
            // lblInvoiceHeader
            // 
            this.lblInvoiceHeader.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.lblInvoiceHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblInvoiceHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblInvoiceHeader.Location = new System.Drawing.Point(0, 0);
            this.lblInvoiceHeader.Name = "lblInvoiceHeader";
            this.lblInvoiceHeader.Padding = new System.Windows.Forms.Padding(5, 5, 0, 0);
            this.lblInvoiceHeader.Size = new System.Drawing.Size(1423, 25);
            this.lblInvoiceHeader.TabIndex = 9;
            this.lblInvoiceHeader.Text = "РН";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "ok.png");
            this.imageList.Images.SetKeyName(1, "exit.png");
            this.imageList.Images.SetKeyName(2, "status-error.png");
            this.imageList.Images.SetKeyName(3, "status-offline.png");
            this.imageList.Images.SetKeyName(4, "status-ok.png");
            this.imageList.Images.SetKeyName(5, "status-warn.png");
            this.imageList.Images.SetKeyName(6, "refresh.png");
            // 
            // docsTableAdapter
            // 
            this.docsTableAdapter.ClearBeforeFill = true;
            // 
            // waybill_DocsTableAdapter
            // 
            this.waybill_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // route_List_DocsTableAdapter
            // 
            this.route_List_DocsTableAdapter.ClearBeforeFill = true;
            // 
            // WHDocsPrintNaklWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1423, 652);
            this.Controls.Add(this.scWaybillDocsContent);
            this.Controls.Add(this.pnlLegend);
            this.Controls.Add(this.lblDocsCount);
            this.Controls.Add(this.lblDocsCountCaption);
            this.Controls.Add(this.panelRL);
            this.Controls.Add(this.toolStripDoc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WHDocsPrintNaklWindow";
            this.Text = "Печать пакетов бухгалтерских документов по заказам";
            this.Shown += new System.EventHandler(this.WHDocsPrintNaklWindow_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WHDocsPrintNaklWindow_FormClosing);
            this.Controls.SetChildIndex(this.toolStripDoc, 0);
            this.Controls.SetChildIndex(this.panelRL, 0);
            this.Controls.SetChildIndex(this.lblDocsCountCaption, 0);
            this.Controls.SetChildIndex(this.lblDocsCount, 0);
            this.Controls.SetChildIndex(this.pnlLegend, 0);
            this.Controls.SetChildIndex(this.scWaybillDocsContent, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocs)).EndInit();
            this.contextMenuForDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.docsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printNakl)).EndInit();
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.panelRL.ResumeLayout(false);
            this.panelRL.PerformLayout();
            this.tsShowHideRouteLists.ResumeLayout(false);
            this.tsShowHideRouteLists.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlLegend.ResumeLayout(false);
            this.pnlLegend.PerformLayout();
            this.scWaybillDocsContent.Panel1.ResumeLayout(false);
            this.scWaybillDocsContent.Panel2.ResumeLayout(false);
            this.scWaybillDocsContent.ResumeLayout(false);
            this.scRouteListWaybillsContent.Panel1.ResumeLayout(false);
            this.scRouteListWaybillsContent.Panel2.ResumeLayout(false);
            this.scRouteListWaybillsContent.ResumeLayout(false);
            this.pnlRouteListContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteListDocs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.routeListDocsBindingSource)).EndInit();
            this.pnlWaybillContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWaybillDocs)).EndInit();
            this.contextMenuForWaybillDocs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waybillDocsBindingSource)).EndInit();
            this.pnlInvoiceContent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocs;
        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrintPackage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.BindingSource docsBindingSource;
        private WMSOffice.Data.PrintNakl printNakl;
        private WMSOffice.Data.PrintNaklTableAdapters.DocsTableAdapter docsTableAdapter;
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private System.Windows.Forms.ContextMenuStrip contextMenuForDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem miPrintPackage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem miPrintInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPrintTaxInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPrintControlSheet;
        private System.Windows.Forms.ToolStripMenuItem miPrintRegister;
        private System.Windows.Forms.ToolStripMenuItem miPrintRequirementOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem miPreviewInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewTaxInvoiceForOptima;
        private System.Windows.Forms.ToolStripMenuItem miPreviewControlSheet;
        private System.Windows.Forms.ToolStripMenuItem miPreviewRegister;
        private System.Windows.Forms.ToolStripMenuItem miPreviewRequirementOrder;
        private System.Windows.Forms.Label lblDocsCount;
        private System.Windows.Forms.Label lblDocsCountCaption;
        private System.Windows.Forms.ToolStripMenuItem miPrintBillInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewBillInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewSaleRegister;
        private System.Windows.Forms.ToolStripMenuItem miPrintSaleRegister;
        private System.Windows.Forms.ToolStripMenuItem miPreviewTaxInvoiceForClient;
        private System.Windows.Forms.Label lblDocsCountNT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelRL;
        private System.Windows.Forms.Label label1;
        private WMSOffice.Controls.TextBoxScaner tbScaner;
        private System.Windows.Forms.ToolStripButton btnCheckInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnExportDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem miPreviewTenderInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewInvoiceBase;
        private System.Windows.Forms.ToolStripMenuItem miPrintTareInvoice;
        private System.Windows.Forms.ToolStripMenuItem miPreviewTareInvoice;
        private System.Windows.Forms.Panel pnlLegend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem miPrintDocAgreement;
        private System.Windows.Forms.ToolStripMenuItem miPreviewDocAgreement;
        private System.Windows.Forms.SplitContainer scWaybillDocsContent;
        private System.Windows.Forms.Label lblInvoiceHeader;
        private System.Windows.Forms.Label lblWaybillHeader;
        private System.Windows.Forms.Panel pnlInvoiceContent;
        private System.Windows.Forms.DataGridView dgvWaybillDocs;
        private System.Windows.Forms.ToolStripButton btnEnableWaybillMode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.BindingSource waybillDocsBindingSource;
        private WMSOffice.Data.PrintNaklTableAdapters.Waybill_DocsTableAdapter waybill_DocsTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuForWaybillDocs;
        private System.Windows.Forms.ToolStripMenuItem miRefreshWaybillDocs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem miPrintWaybillDoc;
        private System.Windows.Forms.ToolStripMenuItem miPrintPackageByWaybill;
        private System.Windows.Forms.ToolStripMenuItem miPrintFullPackageByWaybill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem miPreviewWaybillDoc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripButton btnPrintFullPackageByWaybill;
        private System.Windows.Forms.ToolStripSeparator tssPrintFullPackageByWaybill;
        private System.Windows.Forms.DataGridViewImageColumn dgvcIsAlreadyPrinted;
        private System.Windows.Forms.DataGridViewTextBoxColumn Orders_Seuqence;
        private System.Windows.Forms.DataGridViewTextBoxColumn RouteCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rout_Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn warehouseIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDDCT;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceStatusIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormattedVatRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceSumWithVATNal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn hasVATDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaxInvoiceCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDebtorCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegisterCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isInterbranchDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPackPrintedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebtorID;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DebtorCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryAddressIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn debtorDeliveryAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnloadingAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeliveryInstructions;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ManagerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaymentConditionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SCGP_Flag;
        private System.Windows.Forms.SplitContainer scRouteListWaybillsContent;
        private System.Windows.Forms.Panel pnlRouteListContent;
        private System.Windows.Forms.Label lblRouteListHeader;
        private System.Windows.Forms.Panel pnlWaybillContent;
        private System.Windows.Forms.DataGridView dgvRouteListDocs;
        private System.Windows.Forms.BindingSource routeListDocsBindingSource;
        private WMSOffice.Data.PrintNaklTableAdapters.Route_List_DocsTableAdapter route_List_DocsTableAdapter;
        private System.Windows.Forms.ToolStrip tsShowHideRouteLists;
        private System.Windows.Forms.ToolStripButton btnShowHideRouteLists;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.DataGridViewImageColumn dgvcNeedPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeListNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn driversDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripMenuItem miRePrintFullPackageByWaybill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.CheckBox chbIsRemotePrint;
        private System.Windows.Forms.DataGridViewImageColumn dgvcIsReadyToPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn planDateStartDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn routeListNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTNNoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EWbFormattedFlagName;
        private System.Windows.Forms.DataGridViewTextBoxColumn printedDocsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn driversDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tTNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NeedPrint;
        private System.Windows.Forms.DataGridViewTextBoxColumn WbFormattedStatusName;
    }
}