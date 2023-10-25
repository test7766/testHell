namespace WMSOffice.Window
{
    partial class ArchiveInvoiceWindow
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
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnArchiveInvoice = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnArchiveInvoiceManual = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnRevert = new System.Windows.Forms.ToolStripButton();
            this.tssSetPaperform = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetPaperForm = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSetReceiptDate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExport = new System.Windows.Forms.ToolStripButton();
            this.btnChangeView = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvDocs = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlSearchParameters = new System.Windows.Forms.Panel();
            this.tbDebtorName = new System.Windows.Forms.TextBox();
            this.lblDebtor = new System.Windows.Forms.Label();
            this.stbDebtor = new WMSOffice.Controls.SearchTextBox();
            this.cbArchiveMode = new System.Windows.Forms.CheckBox();
            this.pnlArchiveModeSearchParameters = new System.Windows.Forms.Panel();
            this.tbDocNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.tbDocTypeName = new System.Windows.Forms.TextBox();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.lblArchiveMode = new System.Windows.Forms.Label();
            this.lblAdvancedSearchModes = new System.Windows.Forms.Label();
            this.chbAdvancedSearchModes = new WMSOffice.Controls.CheckedComboBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.tbDocTypeToName = new System.Windows.Forms.TextBox();
            this.stbDocTypeTo = new WMSOffice.Controls.SearchTextBox();
            this.lblDocTypeTo = new System.Windows.Forms.Label();
            this.tbDocTypeFromName = new System.Windows.Forms.TextBox();
            this.stbDocTypeFrom = new WMSOffice.Controls.SearchTextBox();
            this.lblDocTypeFrom = new System.Windows.Forms.Label();
            this.tbWarehouseName = new System.Windows.Forms.TextBox();
            this.lblWarehouse = new System.Windows.Forms.Label();
            this.stbWarehouse = new WMSOffice.Controls.SearchTextBox();
            this.tsMain.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.pnlSearchParameters.SuspendLayout();
            this.pnlArchiveModeSearchParameters.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRefresh,
            this.toolStripSeparator1,
            this.btnArchiveInvoice,
            this.toolStripSeparator3,
            this.btnArchiveInvoiceManual,
            this.toolStripSeparator2,
            this.btnRevert,
            this.tssSetPaperform,
            this.btnSetPaperForm,
            this.toolStripSeparator7,
            this.btnSetReceiptDate,
            this.toolStripSeparator5,
            this.btnExport,
            this.btnChangeView,
            this.toolStripSeparator6});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1278, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(109, 52);
            this.btnRefresh.Text = "Обновить";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnArchiveInvoice
            // 
            this.btnArchiveInvoice.Image = global::WMSOffice.Properties.Resources.finish_process;
            this.btnArchiveInvoice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArchiveInvoice.Name = "btnArchiveInvoice";
            this.btnArchiveInvoice.Size = new System.Drawing.Size(117, 52);
            this.btnArchiveInvoice.Text = "Закрыть\nнакладную";
            this.btnArchiveInvoice.Click += new System.EventHandler(this.btnArchiveInvoice_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnArchiveInvoiceManual
            // 
            this.btnArchiveInvoiceManual.Image = global::WMSOffice.Properties.Resources.view;
            this.btnArchiveInvoiceManual.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnArchiveInvoiceManual.Name = "btnArchiveInvoiceManual";
            this.btnArchiveInvoiceManual.Size = new System.Drawing.Size(117, 52);
            this.btnArchiveInvoiceManual.Text = "Закрыть\nнакладную\nвручную";
            this.btnArchiveInvoiceManual.Click += new System.EventHandler(this.btnArchiveInvoiceManual_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // btnRevert
            // 
            this.btnRevert.Image = global::WMSOffice.Properties.Resources.undo43;
            this.btnRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(109, 52);
            this.btnRevert.Text = "Отменить\nразноску";
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // tssSetPaperform
            // 
            this.tssSetPaperform.Name = "tssSetPaperform";
            this.tssSetPaperform.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetPaperForm
            // 
            this.btnSetPaperForm.Image = global::WMSOffice.Properties.Resources.document_ok;
            this.btnSetPaperForm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetPaperForm.Name = "btnSetPaperForm";
            this.btnSetPaperForm.Size = new System.Drawing.Size(133, 52);
            this.btnSetPaperForm.Text = "Перевести в\nбумажный вид";
            this.btnSetPaperForm.Click += new System.EventHandler(this.btnSetPaperForm_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSetReceiptDate
            // 
            this.btnSetReceiptDate.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnSetReceiptDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSetReceiptDate.Name = "btnSetReceiptDate";
            this.btnSetReceiptDate.Size = new System.Drawing.Size(152, 52);
            this.btnSetReceiptDate.Text = "Указать\nдату поступления\nиз филиала";
            this.btnSetReceiptDate.Click += new System.EventHandler(this.btnSetReceiptDate_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExport
            // 
            this.btnExport.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(101, 52);
            this.btnExport.Text = "Экспорт\nв Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnChangeView
            // 
            this.btnChangeView.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnChangeView.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnChangeView.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeView.Name = "btnChangeView";
            this.btnChangeView.Size = new System.Drawing.Size(107, 52);
            this.btnChangeView.Text = "Изменить\nрежим\nработы";
            this.btnChangeView.Click += new System.EventHandler(this.btnChangeView_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvDocs);
            this.pnlContent.Controls.Add(this.pnlSearchParameters);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 95);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1278, 518);
            this.pnlContent.TabIndex = 3;
            // 
            // xdgvDocs
            // 
            this.xdgvDocs.AllowSort = true;
            this.xdgvDocs.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvDocs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvDocs.LargeAmountOfData = false;
            this.xdgvDocs.Location = new System.Drawing.Point(0, 210);
            this.xdgvDocs.Name = "xdgvDocs";
            this.xdgvDocs.RowHeadersVisible = false;
            this.xdgvDocs.Size = new System.Drawing.Size(1278, 308);
            this.xdgvDocs.TabIndex = 1;
            this.xdgvDocs.UserID = ((long)(0));
            // 
            // pnlSearchParameters
            // 
            this.pnlSearchParameters.Controls.Add(this.tbDebtorName);
            this.pnlSearchParameters.Controls.Add(this.lblDebtor);
            this.pnlSearchParameters.Controls.Add(this.stbDebtor);
            this.pnlSearchParameters.Controls.Add(this.cbArchiveMode);
            this.pnlSearchParameters.Controls.Add(this.pnlArchiveModeSearchParameters);
            this.pnlSearchParameters.Controls.Add(this.lblArchiveMode);
            this.pnlSearchParameters.Controls.Add(this.lblAdvancedSearchModes);
            this.pnlSearchParameters.Controls.Add(this.chbAdvancedSearchModes);
            this.pnlSearchParameters.Controls.Add(this.dtpDateTo);
            this.pnlSearchParameters.Controls.Add(this.dtpDateFrom);
            this.pnlSearchParameters.Controls.Add(this.lblDateTo);
            this.pnlSearchParameters.Controls.Add(this.lblDateFrom);
            this.pnlSearchParameters.Controls.Add(this.tbDocTypeToName);
            this.pnlSearchParameters.Controls.Add(this.stbDocTypeTo);
            this.pnlSearchParameters.Controls.Add(this.lblDocTypeTo);
            this.pnlSearchParameters.Controls.Add(this.tbDocTypeFromName);
            this.pnlSearchParameters.Controls.Add(this.stbDocTypeFrom);
            this.pnlSearchParameters.Controls.Add(this.lblDocTypeFrom);
            this.pnlSearchParameters.Controls.Add(this.tbWarehouseName);
            this.pnlSearchParameters.Controls.Add(this.lblWarehouse);
            this.pnlSearchParameters.Controls.Add(this.stbWarehouse);
            this.pnlSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchParameters.Name = "pnlSearchParameters";
            this.pnlSearchParameters.Size = new System.Drawing.Size(1278, 210);
            this.pnlSearchParameters.TabIndex = 0;
            // 
            // tbDebtorName
            // 
            this.tbDebtorName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorName.Location = new System.Drawing.Point(666, 7);
            this.tbDebtorName.Name = "tbDebtorName";
            this.tbDebtorName.ReadOnly = true;
            this.tbDebtorName.Size = new System.Drawing.Size(200, 20);
            this.tbDebtorName.TabIndex = 5;
            this.tbDebtorName.TabStop = false;
            // 
            // lblDebtor
            // 
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Location = new System.Drawing.Point(444, 11);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(54, 13);
            this.lblDebtor.TabIndex = 3;
            this.lblDebtor.Text = "Дебитор:";
            // 
            // stbDebtor
            // 
            this.stbDebtor.Location = new System.Drawing.Point(560, 7);
            this.stbDebtor.Name = "stbDebtor";
            this.stbDebtor.NavigateByValue = false;
            this.stbDebtor.ReadOnly = false;
            this.stbDebtor.Size = new System.Drawing.Size(100, 20);
            this.stbDebtor.TabIndex = 4;
            this.stbDebtor.UserID = ((long)(0));
            this.stbDebtor.Value = null;
            this.stbDebtor.ValueReferenceQuery = null;
            // 
            // cbArchiveMode
            // 
            this.cbArchiveMode.AutoSize = true;
            this.cbArchiveMode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbArchiveMode.Location = new System.Drawing.Point(123, 126);
            this.cbArchiveMode.Name = "cbArchiveMode";
            this.cbArchiveMode.Size = new System.Drawing.Size(15, 14);
            this.cbArchiveMode.TabIndex = 19;
            this.cbArchiveMode.UseVisualStyleBackColor = true;
            this.cbArchiveMode.CheckedChanged += new System.EventHandler(this.cbArchiveMode_CheckedChanged);
            // 
            // pnlArchiveModeSearchParameters
            // 
            this.pnlArchiveModeSearchParameters.Controls.Add(this.tbDocNumber);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.lblDocNumber);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.tbDocTypeName);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.stbDocType);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.lblDocType);
            this.pnlArchiveModeSearchParameters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlArchiveModeSearchParameters.Location = new System.Drawing.Point(0, 145);
            this.pnlArchiveModeSearchParameters.Name = "pnlArchiveModeSearchParameters";
            this.pnlArchiveModeSearchParameters.Size = new System.Drawing.Size(1278, 65);
            this.pnlArchiveModeSearchParameters.TabIndex = 20;
            // 
            // tbDocNumber
            // 
            this.tbDocNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocNumber.Location = new System.Drawing.Point(123, 37);
            this.tbDocNumber.Name = "tbDocNumber";
            this.tbDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbDocNumber.TabIndex = 4;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(13, 41);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(78, 13);
            this.lblDocNumber.TabIndex = 3;
            this.lblDocNumber.Text = "№ документа:";
            // 
            // tbDocTypeName
            // 
            this.tbDocTypeName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocTypeName.Location = new System.Drawing.Point(229, 8);
            this.tbDocTypeName.Name = "tbDocTypeName";
            this.tbDocTypeName.ReadOnly = true;
            this.tbDocTypeName.Size = new System.Drawing.Size(200, 20);
            this.tbDocTypeName.TabIndex = 2;
            this.tbDocTypeName.TabStop = false;
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(123, 8);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.NavigateByValue = false;
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(13, 12);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа:";
            // 
            // lblArchiveMode
            // 
            this.lblArchiveMode.AutoSize = true;
            this.lblArchiveMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArchiveMode.Location = new System.Drawing.Point(13, 127);
            this.lblArchiveMode.Name = "lblArchiveMode";
            this.lblArchiveMode.Size = new System.Drawing.Size(89, 13);
            this.lblArchiveMode.TabIndex = 18;
            this.lblArchiveMode.Text = "Поиск в архиве:";
            this.lblArchiveMode.Click += new System.EventHandler(this.lblArchiveMode_Click);
            // 
            // lblAdvancedSearchModes
            // 
            this.lblAdvancedSearchModes.AutoSize = true;
            this.lblAdvancedSearchModes.Location = new System.Drawing.Point(13, 98);
            this.lblAdvancedSearchModes.Name = "lblAdvancedSearchModes";
            this.lblAdvancedSearchModes.Size = new System.Drawing.Size(90, 13);
            this.lblAdvancedSearchModes.TabIndex = 16;
            this.lblAdvancedSearchModes.Text = "Дополнительно:";
            // 
            // chbAdvancedSearchModes
            // 
            this.chbAdvancedSearchModes.CheckOnClick = true;
            this.chbAdvancedSearchModes.DisplayMember = "Name";
            this.chbAdvancedSearchModes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chbAdvancedSearchModes.DropDownHeight = 1;
            this.chbAdvancedSearchModes.DropDownWidth = 250;
            this.chbAdvancedSearchModes.FormattingEnabled = true;
            this.chbAdvancedSearchModes.IntegralHeight = false;
            this.chbAdvancedSearchModes.Location = new System.Drawing.Point(123, 94);
            this.chbAdvancedSearchModes.Name = "chbAdvancedSearchModes";
            this.chbAdvancedSearchModes.Size = new System.Drawing.Size(743, 21);
            this.chbAdvancedSearchModes.TabIndex = 17;
            this.chbAdvancedSearchModes.ValueSeparator = ", ";
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.CustomFormat = "dd.MM.yyyy";
            this.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateTo.Location = new System.Drawing.Point(560, 36);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(100, 20);
            this.dtpDateTo.TabIndex = 9;
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDateFrom.Location = new System.Drawing.Point(123, 36);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpDateFrom.TabIndex = 7;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(444, 40);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(108, 13);
            this.lblDateTo.TabIndex = 8;
            this.lblDateTo.Text = "Дата документа по:";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(13, 40);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(102, 13);
            this.lblDateFrom.TabIndex = 6;
            this.lblDateFrom.Text = "Дата документа с:";
            // 
            // tbDocTypeToName
            // 
            this.tbDocTypeToName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocTypeToName.Location = new System.Drawing.Point(666, 65);
            this.tbDocTypeToName.Name = "tbDocTypeToName";
            this.tbDocTypeToName.ReadOnly = true;
            this.tbDocTypeToName.Size = new System.Drawing.Size(200, 20);
            this.tbDocTypeToName.TabIndex = 15;
            this.tbDocTypeToName.TabStop = false;
            // 
            // stbDocTypeTo
            // 
            this.stbDocTypeTo.Location = new System.Drawing.Point(560, 65);
            this.stbDocTypeTo.Name = "stbDocTypeTo";
            this.stbDocTypeTo.NavigateByValue = false;
            this.stbDocTypeTo.ReadOnly = false;
            this.stbDocTypeTo.Size = new System.Drawing.Size(100, 20);
            this.stbDocTypeTo.TabIndex = 14;
            this.stbDocTypeTo.UserID = ((long)(0));
            this.stbDocTypeTo.Value = null;
            this.stbDocTypeTo.ValueReferenceQuery = null;
            // 
            // lblDocTypeTo
            // 
            this.lblDocTypeTo.AutoSize = true;
            this.lblDocTypeTo.Location = new System.Drawing.Point(444, 69);
            this.lblDocTypeTo.Name = "lblDocTypeTo";
            this.lblDocTypeTo.Size = new System.Drawing.Size(101, 13);
            this.lblDocTypeTo.TabIndex = 13;
            this.lblDocTypeTo.Text = "Тип документа по:";
            // 
            // tbDocTypeFromName
            // 
            this.tbDocTypeFromName.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocTypeFromName.Location = new System.Drawing.Point(229, 65);
            this.tbDocTypeFromName.Name = "tbDocTypeFromName";
            this.tbDocTypeFromName.ReadOnly = true;
            this.tbDocTypeFromName.Size = new System.Drawing.Size(200, 20);
            this.tbDocTypeFromName.TabIndex = 12;
            this.tbDocTypeFromName.TabStop = false;
            // 
            // stbDocTypeFrom
            // 
            this.stbDocTypeFrom.Location = new System.Drawing.Point(123, 65);
            this.stbDocTypeFrom.Name = "stbDocTypeFrom";
            this.stbDocTypeFrom.NavigateByValue = false;
            this.stbDocTypeFrom.ReadOnly = false;
            this.stbDocTypeFrom.Size = new System.Drawing.Size(100, 20);
            this.stbDocTypeFrom.TabIndex = 11;
            this.stbDocTypeFrom.UserID = ((long)(0));
            this.stbDocTypeFrom.Value = null;
            this.stbDocTypeFrom.ValueReferenceQuery = null;
            // 
            // lblDocTypeFrom
            // 
            this.lblDocTypeFrom.AutoSize = true;
            this.lblDocTypeFrom.Location = new System.Drawing.Point(13, 69);
            this.lblDocTypeFrom.Name = "lblDocTypeFrom";
            this.lblDocTypeFrom.Size = new System.Drawing.Size(95, 13);
            this.lblDocTypeFrom.TabIndex = 10;
            this.lblDocTypeFrom.Text = "Тип документа с:";
            // 
            // tbWarehouseName
            // 
            this.tbWarehouseName.BackColor = System.Drawing.SystemColors.Window;
            this.tbWarehouseName.Location = new System.Drawing.Point(229, 7);
            this.tbWarehouseName.Name = "tbWarehouseName";
            this.tbWarehouseName.ReadOnly = true;
            this.tbWarehouseName.Size = new System.Drawing.Size(200, 20);
            this.tbWarehouseName.TabIndex = 2;
            this.tbWarehouseName.TabStop = false;
            // 
            // lblWarehouse
            // 
            this.lblWarehouse.AutoSize = true;
            this.lblWarehouse.Location = new System.Drawing.Point(13, 11);
            this.lblWarehouse.Name = "lblWarehouse";
            this.lblWarehouse.Size = new System.Drawing.Size(41, 13);
            this.lblWarehouse.TabIndex = 0;
            this.lblWarehouse.Text = "Склад:";
            // 
            // stbWarehouse
            // 
            this.stbWarehouse.Location = new System.Drawing.Point(123, 7);
            this.stbWarehouse.Name = "stbWarehouse";
            this.stbWarehouse.NavigateByValue = false;
            this.stbWarehouse.ReadOnly = false;
            this.stbWarehouse.Size = new System.Drawing.Size(100, 20);
            this.stbWarehouse.TabIndex = 1;
            this.stbWarehouse.UserID = ((long)(0));
            this.stbWarehouse.Value = null;
            this.stbWarehouse.ValueReferenceQuery = null;
            // 
            // ArchiveInvoiceWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 613);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ArchiveInvoiceWindow";
            this.Text = "ArchiveInvoiceWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlSearchParameters.ResumeLayout(false);
            this.pnlSearchParameters.PerformLayout();
            this.pnlArchiveModeSearchParameters.ResumeLayout(false);
            this.pnlArchiveModeSearchParameters.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnArchiveInvoice;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvDocs;
        private System.Windows.Forms.Panel pnlSearchParameters;
        private System.Windows.Forms.TextBox tbWarehouseName;
        private System.Windows.Forms.Label lblWarehouse;
        private WMSOffice.Controls.SearchTextBox stbWarehouse;
        private System.Windows.Forms.TextBox tbDocTypeToName;
        private WMSOffice.Controls.SearchTextBox stbDocTypeTo;
        private System.Windows.Forms.Label lblDocTypeTo;
        private System.Windows.Forms.TextBox tbDocTypeFromName;
        private WMSOffice.Controls.SearchTextBox stbDocTypeFrom;
        private System.Windows.Forms.Label lblDocTypeFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.Label lblDateFrom;
        private WMSOffice.Controls.CheckedComboBox chbAdvancedSearchModes;
        private System.Windows.Forms.Label lblAdvancedSearchModes;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnRevert;
        private System.Windows.Forms.CheckBox cbArchiveMode;
        private System.Windows.Forms.Label lblArchiveMode;
        private System.Windows.Forms.Panel pnlArchiveModeSearchParameters;
        private System.Windows.Forms.TextBox tbDocNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.TextBox tbDocTypeName;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.Label lblDocType;
        private System.Windows.Forms.ToolStripButton btnArchiveInvoiceManual;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator tssSetPaperform;
        private System.Windows.Forms.ToolStripButton btnSetReceiptDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton btnExport;
        private System.Windows.Forms.ToolStripButton btnChangeView;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.TextBox tbDebtorName;
        private System.Windows.Forms.Label lblDebtor;
        private WMSOffice.Controls.SearchTextBox stbDebtor;
        private System.Windows.Forms.ToolStripButton btnSetPaperForm;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}