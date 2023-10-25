namespace WMSOffice.Window
{
    partial class SalesDispatcherWindow
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
            this.toolStripDoc = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExportOrdersToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.sbPreviewInvoice = new System.Windows.Forms.ToolStripButton();
            this.sbPrintInvoice = new System.Windows.Forms.ToolStripButton();
            this.cmbPrinters = new System.Windows.Forms.ToolStripComboBox();
            this.lblPrinter = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.sbExportInvoiceToPDF = new System.Windows.Forms.ToolStripButton();
            this.sbExportInvoiceToExcel = new System.Windows.Forms.ToolStripButton();
            this.sbExportCheckListToPDF = new System.Windows.Forms.ToolStripButton();
            this.sbExportCheckListBPToPDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbReprintPSN = new System.Windows.Forms.ToolStripButton();
            this.sbApprove = new System.Windows.Forms.ToolStripButton();
            this.sbBringOnCharge = new System.Windows.Forms.ToolStripButton();
            this.sbCreateSalesLogging = new System.Windows.Forms.ToolStripButton();
            this.sbSetDeliveryInfo = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.gbSearchCriteria = new System.Windows.Forms.GroupBox();
            this.tbInvoiceID = new System.Windows.Forms.TextBox();
            this.tbOrderID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.chbCategories = new WMSOffice.Controls.CheckedComboBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.lblSalesMan = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.stbSalesMan = new WMSOffice.Controls.SearchTextBox();
            this.lblStateTo = new System.Windows.Forms.Label();
            this.lblStateFrom = new System.Windows.Forms.Label();
            this.stbWarehouseTo = new WMSOffice.Controls.SearchTextBox();
            this.lblItem = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblWarehouseTo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblWarehouseFrom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.stbWarehouseFrom = new WMSOffice.Controls.SearchTextBox();
            this.stbStateFrom = new WMSOffice.Controls.SearchTextBox();
            this.stbStateTo = new WMSOffice.Controls.SearchTextBox();
            this.xdgvResult = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlWorkArea = new System.Windows.Forms.Panel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDoc.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.gbSearchCriteria.SuspendLayout();
            this.pnlWorkArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripDoc
            // 
            this.toolStripDoc.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStripDoc.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.toolStripSeparator1,
            this.sbExportOrdersToExcel,
            this.toolStripSeparator4,
            this.sbPreviewInvoice,
            this.sbPrintInvoice,
            this.cmbPrinters,
            this.lblPrinter,
            this.toolStripSeparator2,
            this.sbExportInvoiceToPDF,
            this.sbExportInvoiceToExcel,
            this.sbExportCheckListToPDF,
            this.sbExportCheckListBPToPDF,
            this.toolStripSeparator3,
            this.sbReprintPSN,
            this.sbApprove,
            this.sbBringOnCharge,
            this.sbCreateSalesLogging,
            this.toolStripSeparator5,
            this.sbSetDeliveryInfo});
            this.toolStripDoc.Location = new System.Drawing.Point(0, 0);
            this.toolStripDoc.Name = "toolStripDoc";
            this.toolStripDoc.Size = new System.Drawing.Size(1544, 55);
            this.toolStripDoc.TabIndex = 1;
            this.toolStripDoc.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(113, 52);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.ToolTipText = "Обновить (F5)";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // sbExportOrdersToExcel
            // 
            this.sbExportOrdersToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportOrdersToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportOrdersToExcel.Name = "sbExportOrdersToExcel";
            this.sbExportOrdersToExcel.Size = new System.Drawing.Size(142, 52);
            this.sbExportOrdersToExcel.Text = "Экспорт в Excel";
            this.sbExportOrdersToExcel.ToolTipText = "Экспорт в Excel реестра заказов";
            this.sbExportOrdersToExcel.Click += new System.EventHandler(this.sbExportOrdersToExcel_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // sbPreviewInvoice
            // 
            this.sbPreviewInvoice.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.sbPreviewInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPreviewInvoice.Name = "sbPreviewInvoice";
            this.sbPreviewInvoice.Size = new System.Drawing.Size(142, 52);
            this.sbPreviewInvoice.Text = "Просмотр\nсчета-фактуры";
            this.sbPreviewInvoice.Visible = false;
            this.sbPreviewInvoice.Click += new System.EventHandler(this.sbPreviewInvoice_Click);
            // 
            // sbPrintInvoice
            // 
            this.sbPrintInvoice.Image = global::WMSOffice.Properties.Resources.document_print;
            this.sbPrintInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbPrintInvoice.Name = "sbPrintInvoice";
            this.sbPrintInvoice.Size = new System.Drawing.Size(142, 52);
            this.sbPrintInvoice.Text = "Печать\nсчета-фактуры";
            this.sbPrintInvoice.Visible = false;
            this.sbPrintInvoice.Click += new System.EventHandler(this.sbPrintInvoice_Click);
            // 
            // cmbPrinters
            // 
            this.cmbPrinters.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.cmbPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrinters.Name = "cmbPrinters";
            this.cmbPrinters.Size = new System.Drawing.Size(250, 55);
            this.cmbPrinters.Visible = false;
            // 
            // lblPrinter
            // 
            this.lblPrinter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblPrinter.Name = "lblPrinter";
            this.lblPrinter.Size = new System.Drawing.Size(58, 52);
            this.lblPrinter.Text = "Принтер:";
            this.lblPrinter.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator2.Visible = false;
            // 
            // sbExportInvoiceToPDF
            // 
            this.sbExportInvoiceToPDF.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.sbExportInvoiceToPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportInvoiceToPDF.Name = "sbExportInvoiceToPDF";
            this.sbExportInvoiceToPDF.Size = new System.Drawing.Size(135, 52);
            this.sbExportInvoiceToPDF.Text = "Счет-фактура";
            this.sbExportInvoiceToPDF.Click += new System.EventHandler(this.sbExportInvoiceToPDF_Click);
            // 
            // sbExportInvoiceToExcel
            // 
            this.sbExportInvoiceToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.sbExportInvoiceToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportInvoiceToExcel.Name = "sbExportInvoiceToExcel";
            this.sbExportInvoiceToExcel.Size = new System.Drawing.Size(135, 52);
            this.sbExportInvoiceToExcel.Text = "Счет-фактура\nExcel";
            this.sbExportInvoiceToExcel.Click += new System.EventHandler(this.sbExportInvoiceToExcel_Click);
            // 
            // sbExportCheckListToPDF
            // 
            this.sbExportCheckListToPDF.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.sbExportCheckListToPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportCheckListToPDF.Name = "sbExportCheckListToPDF";
            this.sbExportCheckListToPDF.Size = new System.Drawing.Size(135, 52);
            this.sbExportCheckListToPDF.Text = "Контрольный\nлист";
            this.sbExportCheckListToPDF.Click += new System.EventHandler(this.sbExportCheckListToPDF_Click);
            // 
            // sbExportCheckListBPToPDF
            // 
            this.sbExportCheckListBPToPDF.Image = global::WMSOffice.Properties.Resources.export_pdf;
            this.sbExportCheckListBPToPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbExportCheckListBPToPDF.Name = "sbExportCheckListBPToPDF";
            this.sbExportCheckListBPToPDF.Size = new System.Drawing.Size(135, 52);
            this.sbExportCheckListBPToPDF.Text = "Контрольный\nлист ВР";
            this.sbExportCheckListBPToPDF.Click += new System.EventHandler(this.sbExportCheckListBPToPDF_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // sbReprintPSN
            // 
            this.sbReprintPSN.Image = global::WMSOffice.Properties.Resources.assign;
            this.sbReprintPSN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbReprintPSN.Name = "sbReprintPSN";
            this.sbReprintPSN.Size = new System.Drawing.Size(154, 52);
            this.sbReprintPSN.Text = "Добавить\nсборочный\nв очередь печати";
            this.sbReprintPSN.Click += new System.EventHandler(this.sbReprintPSN_Click);
            // 
            // sbApprove
            // 
            this.sbApprove.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.sbApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbApprove.Name = "sbApprove";
            this.sbApprove.Size = new System.Drawing.Size(114, 52);
            this.sbApprove.Text = "Утвердить\nмежсклад";
            this.sbApprove.Click += new System.EventHandler(this.sbApprove_Click);
            // 
            // sbBringOnCharge
            // 
            this.sbBringOnCharge.Image = global::WMSOffice.Properties.Resources.edit_document;
            this.sbBringOnCharge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbBringOnCharge.Name = "sbBringOnCharge";
            this.sbBringOnCharge.Size = new System.Drawing.Size(130, 52);
            this.sbBringOnCharge.Text = "Приходовать\nмежсклад";
            this.sbBringOnCharge.Click += new System.EventHandler(this.sbBringOnCharge_Click);
            // 
            // sbCreateSalesLogging
            // 
            this.sbCreateSalesLogging.Image = global::WMSOffice.Properties.Resources.folder_documents;
            this.sbCreateSalesLogging.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbCreateSalesLogging.Name = "sbCreateSalesLogging";
            this.sbCreateSalesLogging.Size = new System.Drawing.Size(141, 52);
            this.sbCreateSalesLogging.Text = "Журнализация";
            this.sbCreateSalesLogging.Click += new System.EventHandler(this.sbCreateSalesLogging_Click);
            // 
            // sbSetDeliverySettings
            // 
            this.sbSetDeliveryInfo.Image = global::WMSOffice.Properties.Resources.delivery;
            this.sbSetDeliveryInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSetDeliveryInfo.Name = "sbSetDeliverySettings";
            this.sbSetDeliveryInfo.Size = new System.Drawing.Size(108, 52);
            this.sbSetDeliveryInfo.Text = "Детали\nдоставки";
            this.sbSetDeliveryInfo.Click += new System.EventHandler(this.sbSetDeliveryInfo_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMain.Controls.Add(this.gbSearchCriteria);
            this.pnlMain.Controls.Add(this.xdgvResult);
            this.pnlMain.Location = new System.Drawing.Point(0, 58);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1544, 553);
            this.pnlMain.TabIndex = 2;
            // 
            // gbSearchCriteria
            // 
            this.gbSearchCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSearchCriteria.Controls.Add(this.tbInvoiceID);
            this.gbSearchCriteria.Controls.Add(this.tbOrderID);
            this.gbSearchCriteria.Controls.Add(this.label10);
            this.gbSearchCriteria.Controls.Add(this.label8);
            this.gbSearchCriteria.Controls.Add(this.label9);
            this.gbSearchCriteria.Controls.Add(this.chbCategories);
            this.gbSearchCriteria.Controls.Add(this.lblDocType);
            this.gbSearchCriteria.Controls.Add(this.label7);
            this.gbSearchCriteria.Controls.Add(this.stbDocType);
            this.gbSearchCriteria.Controls.Add(this.lblSalesMan);
            this.gbSearchCriteria.Controls.Add(this.label6);
            this.gbSearchCriteria.Controls.Add(this.stbSalesMan);
            this.gbSearchCriteria.Controls.Add(this.lblStateTo);
            this.gbSearchCriteria.Controls.Add(this.lblStateFrom);
            this.gbSearchCriteria.Controls.Add(this.stbWarehouseTo);
            this.gbSearchCriteria.Controls.Add(this.lblItem);
            this.gbSearchCriteria.Controls.Add(this.label1);
            this.gbSearchCriteria.Controls.Add(this.lblWarehouseTo);
            this.gbSearchCriteria.Controls.Add(this.label2);
            this.gbSearchCriteria.Controls.Add(this.lblWarehouseFrom);
            this.gbSearchCriteria.Controls.Add(this.label3);
            this.gbSearchCriteria.Controls.Add(this.stbItem);
            this.gbSearchCriteria.Controls.Add(this.label4);
            this.gbSearchCriteria.Controls.Add(this.label5);
            this.gbSearchCriteria.Controls.Add(this.stbWarehouseFrom);
            this.gbSearchCriteria.Controls.Add(this.stbStateFrom);
            this.gbSearchCriteria.Controls.Add(this.stbStateTo);
            this.gbSearchCriteria.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbSearchCriteria.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gbSearchCriteria.Location = new System.Drawing.Point(3, 3);
            this.gbSearchCriteria.Name = "gbSearchCriteria";
            this.gbSearchCriteria.Size = new System.Drawing.Size(1538, 127);
            this.gbSearchCriteria.TabIndex = 15;
            this.gbSearchCriteria.TabStop = false;
            this.gbSearchCriteria.Text = "Критерии поиска:";
            // 
            // tbInvoiceID
            // 
            this.tbInvoiceID.Location = new System.Drawing.Point(1311, 67);
            this.tbInvoiceID.Name = "tbInvoiceID";
            this.tbInvoiceID.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceID.TabIndex = 29;
            this.tbInvoiceID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // tbOrderID
            // 
            this.tbOrderID.Location = new System.Drawing.Point(1311, 18);
            this.tbOrderID.Name = "tbOrderID";
            this.tbOrderID.Size = new System.Drawing.Size(100, 20);
            this.tbOrderID.TabIndex = 28;
            this.tbOrderID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AllowOnlyNumber_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(1227, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "№ накладной:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(1227, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "№ заказа:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(813, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Категория:";
            // 
            // chbCategories
            // 
            this.chbCategories.CheckOnClick = true;
            this.chbCategories.DisplayMember = "Name";
            this.chbCategories.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chbCategories.DropDownHeight = 1;
            this.chbCategories.DropDownWidth = 250;
            this.chbCategories.FormattingEnabled = true;
            this.chbCategories.IntegralHeight = false;
            this.chbCategories.Location = new System.Drawing.Point(902, 19);
            this.chbCategories.Name = "chbCategories";
            this.chbCategories.Size = new System.Drawing.Size(238, 21);
            this.chbCategories.TabIndex = 23;
            this.chbCategories.ValueSeparator = ", ";
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblDocType.Location = new System.Drawing.Point(899, 97);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(0, 13);
            this.lblDocType.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(813, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Тип документа:";
            // 
            // stbDocType
            // 
            this.stbDocType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbDocType.Location = new System.Drawing.Point(902, 71);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(238, 23);
            this.stbDocType.TabIndex = 20;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // lblSalesMan
            // 
            this.lblSalesMan.AutoSize = true;
            this.lblSalesMan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSalesMan.Location = new System.Drawing.Point(627, 97);
            this.lblSalesMan.Name = "lblSalesMan";
            this.lblSalesMan.Size = new System.Drawing.Size(0, 13);
            this.lblSalesMan.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(577, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Код ТП:";
            // 
            // stbSalesMan
            // 
            this.stbSalesMan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbSalesMan.Location = new System.Drawing.Point(627, 71);
            this.stbSalesMan.Name = "stbSalesMan";
            this.stbSalesMan.ReadOnly = false;
            this.stbSalesMan.Size = new System.Drawing.Size(100, 23);
            this.stbSalesMan.TabIndex = 17;
            this.stbSalesMan.UserID = ((long)(0));
            this.stbSalesMan.Value = null;
            this.stbSalesMan.ValueReferenceQuery = null;
            // 
            // lblStateTo
            // 
            this.lblStateTo.AutoSize = true;
            this.lblStateTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStateTo.Location = new System.Drawing.Point(352, 45);
            this.lblStateTo.Name = "lblStateTo";
            this.lblStateTo.Size = new System.Drawing.Size(0, 13);
            this.lblStateTo.TabIndex = 16;
            // 
            // lblStateFrom
            // 
            this.lblStateFrom.AutoSize = true;
            this.lblStateFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblStateFrom.Location = new System.Drawing.Point(77, 47);
            this.lblStateFrom.Name = "lblStateFrom";
            this.lblStateFrom.Size = new System.Drawing.Size(0, 13);
            this.lblStateFrom.TabIndex = 15;
            // 
            // stbWarehouseTo
            // 
            this.stbWarehouseTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbWarehouseTo.Location = new System.Drawing.Point(352, 71);
            this.stbWarehouseTo.Name = "stbWarehouseTo";
            this.stbWarehouseTo.ReadOnly = false;
            this.stbWarehouseTo.Size = new System.Drawing.Size(100, 23);
            this.stbWarehouseTo.TabIndex = 10;
            this.stbWarehouseTo.UserID = ((long)(0));
            this.stbWarehouseTo.Value = null;
            this.stbWarehouseTo.ValueReferenceQuery = null;
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItem.Location = new System.Drawing.Point(624, 48);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(0, 13);
            this.lblItem.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(11, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Статус \"с\":";
            // 
            // lblWarehouseTo
            // 
            this.lblWarehouseTo.AutoSize = true;
            this.lblWarehouseTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseTo.Location = new System.Drawing.Point(349, 97);
            this.lblWarehouseTo.Name = "lblWarehouseTo";
            this.lblWarehouseTo.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseTo.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(280, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Статус \"по\":";
            // 
            // lblWarehouseFrom
            // 
            this.lblWarehouseFrom.AutoSize = true;
            this.lblWarehouseFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWarehouseFrom.Location = new System.Drawing.Point(74, 97);
            this.lblWarehouseFrom.Name = "lblWarehouseFrom";
            this.lblWarehouseFrom.Size = new System.Drawing.Size(0, 13);
            this.lblWarehouseFrom.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(14, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Склад \"с\":";
            // 
            // stbItem
            // 
            this.stbItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbItem.Location = new System.Drawing.Point(627, 22);
            this.stbItem.Name = "stbItem";
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(100, 23);
            this.stbItem.TabIndex = 11;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(283, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Склад \"по\":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(557, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Код товара:";
            // 
            // stbWarehouseFrom
            // 
            this.stbWarehouseFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbWarehouseFrom.Location = new System.Drawing.Point(77, 71);
            this.stbWarehouseFrom.Name = "stbWarehouseFrom";
            this.stbWarehouseFrom.ReadOnly = false;
            this.stbWarehouseFrom.Size = new System.Drawing.Size(100, 23);
            this.stbWarehouseFrom.TabIndex = 9;
            this.stbWarehouseFrom.UserID = ((long)(0));
            this.stbWarehouseFrom.Value = null;
            this.stbWarehouseFrom.ValueReferenceQuery = null;
            // 
            // stbStateFrom
            // 
            this.stbStateFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbStateFrom.Location = new System.Drawing.Point(77, 22);
            this.stbStateFrom.Name = "stbStateFrom";
            this.stbStateFrom.ReadOnly = false;
            this.stbStateFrom.Size = new System.Drawing.Size(100, 23);
            this.stbStateFrom.TabIndex = 7;
            this.stbStateFrom.UserID = ((long)(0));
            this.stbStateFrom.Value = null;
            this.stbStateFrom.ValueReferenceQuery = null;
            // 
            // stbStateTo
            // 
            this.stbStateTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.stbStateTo.Location = new System.Drawing.Point(352, 22);
            this.stbStateTo.Name = "stbStateTo";
            this.stbStateTo.ReadOnly = false;
            this.stbStateTo.Size = new System.Drawing.Size(100, 23);
            this.stbStateTo.TabIndex = 8;
            this.stbStateTo.UserID = ((long)(0));
            this.stbStateTo.Value = null;
            this.stbStateTo.ValueReferenceQuery = null;
            // 
            // xdgvResult
            // 
            this.xdgvResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.xdgvResult.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvResult.LargeAmountOfData = false;
            this.xdgvResult.Location = new System.Drawing.Point(0, 136);
            this.xdgvResult.Name = "xdgvResult";
            this.xdgvResult.RowHeadersVisible = false;
            this.xdgvResult.Size = new System.Drawing.Size(1541, 414);
            this.xdgvResult.TabIndex = 0;
            this.xdgvResult.UserID = ((long)(0));
            // 
            // pnlWorkArea
            // 
            this.pnlWorkArea.Controls.Add(this.toolStripDoc);
            this.pnlWorkArea.Controls.Add(this.pnlMain);
            this.pnlWorkArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkArea.Location = new System.Drawing.Point(0, 40);
            this.pnlWorkArea.Name = "pnlWorkArea";
            this.pnlWorkArea.Size = new System.Drawing.Size(1544, 611);
            this.pnlWorkArea.TabIndex = 3;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // SalesDispatcherWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1544, 651);
            this.Controls.Add(this.pnlWorkArea);
            this.Name = "SalesDispatcherWindow";
            this.Text = "Диспетчер продаж";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SalesDispatcherWindow_FormClosing);
            this.Controls.SetChildIndex(this.pnlWorkArea, 0);
            this.toolStripDoc.ResumeLayout(false);
            this.toolStripDoc.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.gbSearchCriteria.ResumeLayout(false);
            this.gbSearchCriteria.PerformLayout();
            this.pnlWorkArea.ResumeLayout(false);
            this.pnlWorkArea.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripDoc;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.Panel pnlMain;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton sbPrintInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private WMSOffice.Controls.SearchTextBox stbWarehouseFrom;
        private WMSOffice.Controls.SearchTextBox stbStateTo;
        private WMSOffice.Controls.SearchTextBox stbStateFrom;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private WMSOffice.Controls.SearchTextBox stbWarehouseTo;
        private System.Windows.Forms.ToolStripComboBox cmbPrinters;
        private System.Windows.Forms.ToolStripLabel lblPrinter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblWarehouseTo;
        private System.Windows.Forms.Label lblWarehouseFrom;
        private System.Windows.Forms.GroupBox gbSearchCriteria;
        private System.Windows.Forms.Label lblStateTo;
        private System.Windows.Forms.Label lblStateFrom;
        private System.Windows.Forms.ToolStripButton sbPreviewInvoice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton sbReprintPSN;
        private System.Windows.Forms.ToolStripButton sbExportInvoiceToPDF;
        private System.Windows.Forms.Label lblSalesMan;
        private System.Windows.Forms.Label label6;
        private WMSOffice.Controls.SearchTextBox stbSalesMan;
        private System.Windows.Forms.ToolStripButton sbExportOrdersToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton sbExportCheckListToPDF;
        private System.Windows.Forms.ToolStripButton sbExportCheckListBPToPDF;
        private System.Windows.Forms.ToolStripButton sbBringOnCharge;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.Label label7;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.ToolStripButton sbCreateSalesLogging;
        private System.Windows.Forms.Panel pnlWorkArea;
        private WMSOffice.Controls.CheckedComboBox chbCategories;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripButton sbExportInvoiceToExcel;
        private System.Windows.Forms.TextBox tbInvoiceID;
        private System.Windows.Forms.TextBox tbOrderID;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton sbApprove;
        private System.Windows.Forms.ToolStripButton sbSetDeliveryInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    }
}