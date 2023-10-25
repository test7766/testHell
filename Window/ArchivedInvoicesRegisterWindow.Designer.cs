namespace WMSOffice.Window
{
    partial class ArchivedInvoicesRegisterWindow
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
            this.btnExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ssbPreviewRegister = new System.Windows.Forms.ToolStripSplitButton();
            this.ssbiPreviewRegister = new System.Windows.Forms.ToolStripMenuItem();
            this.ssbiPreviewRegisterHeader = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintBoxEtic = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowBoxEticsStatistics = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateUtilizationSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintRegisterBarcode = new System.Windows.Forms.ToolStripButton();
            this.btnChangeWorkMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCreateRegister = new System.Windows.Forms.ToolStripButton();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.xdgvRegistry = new WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView();
            this.pnlSearchParameters = new System.Windows.Forms.Panel();
            this.pnlArchiveModeSearchParameters = new System.Windows.Forms.Panel();
            this.tbBarCode = new System.Windows.Forms.TextBox();
            this.lblBarCode = new System.Windows.Forms.Label();
            this.tbInvoiceNumber = new System.Windows.Forms.TextBox();
            this.lbllInvoiceNumber = new System.Windows.Forms.Label();
            this.tbInvoiceType = new System.Windows.Forms.TextBox();
            this.stbInvoiceType = new WMSOffice.Controls.SearchTextBox();
            this.lblInvoiceType = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.tbStatusTo = new System.Windows.Forms.TextBox();
            this.lblStatusTo = new System.Windows.Forms.Label();
            this.stbStatusTo = new WMSOffice.Controls.SearchTextBox();
            this.tbStatusFrom = new System.Windows.Forms.TextBox();
            this.lblStatusFrom = new System.Windows.Forms.Label();
            this.stbStatusFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbDebtorTo = new System.Windows.Forms.TextBox();
            this.lbllDebtorTo = new System.Windows.Forms.Label();
            this.stbDebtorTo = new WMSOffice.Controls.SearchTextBox();
            this.tbDebtorFrom = new System.Windows.Forms.TextBox();
            this.lblDebtorFrom = new System.Windows.Forms.Label();
            this.stbDebtorFrom = new WMSOffice.Controls.SearchTextBox();
            this.tbDocType = new System.Windows.Forms.TextBox();
            this.lblDocType = new System.Windows.Forms.Label();
            this.stbDocType = new WMSOffice.Controls.SearchTextBox();
            this.tsMain.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
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
            this.btnExportToExcel,
            this.toolStripSeparator2,
            this.ssbPreviewRegister,
            this.toolStripSeparator3,
            this.btnPrintBoxEtic,
            this.toolStripSeparator5,
            this.btnShowBoxEticsStatistics,
            this.toolStripSeparator6,
            this.btnCreateUtilizationSettings,
            this.toolStripSeparator8,
            this.btnPrintRegisterBarcode,
            this.btnChangeWorkMode,
            this.toolStripSeparator9,
            this.toolStripSeparator10,
            this.btnCreateRegister});
            this.tsMain.Location = new System.Drawing.Point(0, 40);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1459, 55);
            this.tsMain.TabIndex = 1;
            this.tsMain.Text = "toolStrip1";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 52);
            this.btnRefresh.Text = "Оновити";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnExportToExcel
            // 
            this.btnExportToExcel.Image = global::WMSOffice.Properties.Resources.Excel;
            this.btnExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExportToExcel.Name = "btnExportToExcel";
            this.btnExportToExcel.Size = new System.Drawing.Size(100, 52);
            this.btnExportToExcel.Text = "Експорт\nв Excel";
            this.btnExportToExcel.Click += new System.EventHandler(this.btnExportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // ssbPreviewRegister
            // 
            this.ssbPreviewRegister.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssbiPreviewRegister,
            this.ssbiPreviewRegisterHeader});
            this.ssbPreviewRegister.Image = global::WMSOffice.Properties.Resources.document_print_preview;
            this.ssbPreviewRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ssbPreviewRegister.Name = "ssbPreviewRegister";
            this.ssbPreviewRegister.Size = new System.Drawing.Size(126, 52);
            this.ssbPreviewRegister.Text = "Перегляд\nдокумента";
            this.ssbPreviewRegister.ButtonClick += new System.EventHandler(this.ssbPreviewRegister_ButtonClick);
            // 
            // ssbiPreviewRegister
            // 
            this.ssbiPreviewRegister.Name = "ssbiPreviewRegister";
            this.ssbiPreviewRegister.Size = new System.Drawing.Size(205, 22);
            this.ssbiPreviewRegister.Text = "Включаючи вміст реєстру";
            this.ssbiPreviewRegister.Click += new System.EventHandler(this.ssbiPreviewRegister_Click);
            // 
            // ssbiPreviewRegisterHeader
            // 
            this.ssbiPreviewRegisterHeader.Name = "ssbiPreviewRegisterHeader";
            this.ssbiPreviewRegisterHeader.Size = new System.Drawing.Size(205, 22);
            this.ssbiPreviewRegisterHeader.Text = "Без вмісту реєстру";
            this.ssbiPreviewRegisterHeader.Click += new System.EventHandler(this.ssbiPreviewRegisterHeader_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintBoxEtic
            // 
            this.btnPrintBoxEtic.Image = global::WMSOffice.Properties.Resources.document_print;
            this.btnPrintBoxEtic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintBoxEtic.Name = "btnPrintBoxEtic";
            this.btnPrintBoxEtic.Size = new System.Drawing.Size(187, 52);
            this.btnPrintBoxEtic.Text = "Друк ШК \nдля коробки\n(без реєстру документів)";
            this.btnPrintBoxEtic.Click += new System.EventHandler(this.btnPrintBoxEtic_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnShowBoxEticsStatistics
            // 
            this.btnShowBoxEticsStatistics.Image = global::WMSOffice.Properties.Resources.assign;
            this.btnShowBoxEticsStatistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowBoxEticsStatistics.Name = "btnShowBoxEticsStatistics";
            this.btnShowBoxEticsStatistics.Size = new System.Drawing.Size(187, 52);
            this.btnShowBoxEticsStatistics.Text = "Реєстр коробок\nдля передачі\n(без реєстру документів)";
            this.btnShowBoxEticsStatistics.Click += new System.EventHandler(this.btnShowBoxEticsStatistics_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateUtilizationSettings
            // 
            this.btnCreateUtilizationSettings.Image = global::WMSOffice.Properties.Resources.recycle_bin;
            this.btnCreateUtilizationSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateUtilizationSettings.Name = "btnCreateUtilizationSettings";
            this.btnCreateUtilizationSettings.Size = new System.Drawing.Size(111, 52);
            this.btnCreateUtilizationSettings.Text = "Утилізація\nархіву";
            this.btnCreateUtilizationSettings.Click += new System.EventHandler(this.btnCreateUtilizationSettings_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 55);
            // 
            // btnPrintRegisterBarcode
            // 
            this.btnPrintRegisterBarcode.Image = global::WMSOffice.Properties.Resources.barcode;
            this.btnPrintRegisterBarcode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintRegisterBarcode.Name = "btnPrintRegisterBarcode";
            this.btnPrintRegisterBarcode.Size = new System.Drawing.Size(105, 52);
            this.btnPrintRegisterBarcode.Text = "Друк ШК\nреєстру";
            this.btnPrintRegisterBarcode.Click += new System.EventHandler(this.btnPrintRegisterBarcode_Click);
            // 
            // btnChangeWorkMode
            // 
            this.btnChangeWorkMode.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnChangeWorkMode.Image = global::WMSOffice.Properties.Resources.settings;
            this.btnChangeWorkMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnChangeWorkMode.Name = "btnChangeWorkMode";
            this.btnChangeWorkMode.Size = new System.Drawing.Size(97, 52);
            this.btnChangeWorkMode.Text = "Змінити\nрежим\nроботи";
            this.btnChangeWorkMode.Click += new System.EventHandler(this.btnChangeWorkMode_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 55);
            // 
            // btnCreateRegister
            // 
            this.btnCreateRegister.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnCreateRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRegister.Name = "btnCreateRegister";
            this.btnCreateRegister.Size = new System.Drawing.Size(108, 52);
            this.btnCreateRegister.Text = "Створити\nреєстр\nархіву";
            this.btnCreateRegister.Click += new System.EventHandler(this.btnCreateRegister_Click);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Controls.Add(this.pnlContent);
            this.pnlMainContent.Controls.Add(this.pnlSearchParameters);
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(0, 95);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1459, 440);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.xdgvRegistry);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 180);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(1459, 260);
            this.pnlContent.TabIndex = 1;
            // 
            // xdgvRegistry
            // 
            this.xdgvRegistry.AllowSort = true;
            this.xdgvRegistry.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            this.xdgvRegistry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xdgvRegistry.LargeAmountOfData = false;
            this.xdgvRegistry.Location = new System.Drawing.Point(0, 0);
            this.xdgvRegistry.Name = "xdgvRegistry";
            this.xdgvRegistry.RowHeadersVisible = false;
            this.xdgvRegistry.Size = new System.Drawing.Size(1459, 260);
            this.xdgvRegistry.TabIndex = 0;
            this.xdgvRegistry.UserID = ((long)(0));
            // 
            // pnlSearchParameters
            // 
            this.pnlSearchParameters.Controls.Add(this.pnlArchiveModeSearchParameters);
            this.pnlSearchParameters.Controls.Add(this.dtpPeriodTo);
            this.pnlSearchParameters.Controls.Add(this.lblPeriodTo);
            this.pnlSearchParameters.Controls.Add(this.dtpPeriodFrom);
            this.pnlSearchParameters.Controls.Add(this.lblPeriodFrom);
            this.pnlSearchParameters.Controls.Add(this.tbStatusTo);
            this.pnlSearchParameters.Controls.Add(this.lblStatusTo);
            this.pnlSearchParameters.Controls.Add(this.stbStatusTo);
            this.pnlSearchParameters.Controls.Add(this.tbStatusFrom);
            this.pnlSearchParameters.Controls.Add(this.lblStatusFrom);
            this.pnlSearchParameters.Controls.Add(this.stbStatusFrom);
            this.pnlSearchParameters.Controls.Add(this.tbDebtorTo);
            this.pnlSearchParameters.Controls.Add(this.lbllDebtorTo);
            this.pnlSearchParameters.Controls.Add(this.stbDebtorTo);
            this.pnlSearchParameters.Controls.Add(this.tbDebtorFrom);
            this.pnlSearchParameters.Controls.Add(this.lblDebtorFrom);
            this.pnlSearchParameters.Controls.Add(this.stbDebtorFrom);
            this.pnlSearchParameters.Controls.Add(this.tbDocType);
            this.pnlSearchParameters.Controls.Add(this.lblDocType);
            this.pnlSearchParameters.Controls.Add(this.stbDocType);
            this.pnlSearchParameters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchParameters.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchParameters.Name = "pnlSearchParameters";
            this.pnlSearchParameters.Size = new System.Drawing.Size(1459, 180);
            this.pnlSearchParameters.TabIndex = 0;
            // 
            // pnlArchiveModeSearchParameters
            // 
            this.pnlArchiveModeSearchParameters.Controls.Add(this.tbBarCode);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.lblBarCode);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.tbInvoiceNumber);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.lbllInvoiceNumber);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.tbInvoiceType);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.stbInvoiceType);
            this.pnlArchiveModeSearchParameters.Controls.Add(this.lblInvoiceType);
            this.pnlArchiveModeSearchParameters.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlArchiveModeSearchParameters.Location = new System.Drawing.Point(0, 115);
            this.pnlArchiveModeSearchParameters.Name = "pnlArchiveModeSearchParameters";
            this.pnlArchiveModeSearchParameters.Size = new System.Drawing.Size(1459, 65);
            this.pnlArchiveModeSearchParameters.TabIndex = 19;
            // 
            // tbBarCode
            // 
            this.tbBarCode.BackColor = System.Drawing.SystemColors.Info;
            this.tbBarCode.Location = new System.Drawing.Point(541, 8);
            this.tbBarCode.Name = "tbBarCode";
            this.tbBarCode.Size = new System.Drawing.Size(100, 20);
            this.tbBarCode.TabIndex = 21;
            this.tbBarCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbBarCode_KeyDown);
            // 
            // lblBarCode
            // 
            this.lblBarCode.AutoSize = true;
            this.lblBarCode.Location = new System.Drawing.Point(450, 8);
            this.lblBarCode.Name = "lblBarCode";
            this.lblBarCode.Size = new System.Drawing.Size(69, 26);
            this.lblBarCode.TabIndex = 20;
            this.lblBarCode.Text = "ШК реєстру\r\n/накладної :";
            // 
            // tbInvoiceNumber
            // 
            this.tbInvoiceNumber.BackColor = System.Drawing.SystemColors.Window;
            this.tbInvoiceNumber.Location = new System.Drawing.Point(104, 37);
            this.tbInvoiceNumber.Name = "tbInvoiceNumber";
            this.tbInvoiceNumber.Size = new System.Drawing.Size(100, 20);
            this.tbInvoiceNumber.TabIndex = 4;
            // 
            // lbllInvoiceNumber
            // 
            this.lbllInvoiceNumber.AutoSize = true;
            this.lbllInvoiceNumber.Location = new System.Drawing.Point(13, 41);
            this.lbllInvoiceNumber.Name = "lbllInvoiceNumber";
            this.lbllInvoiceNumber.Size = new System.Drawing.Size(75, 13);
            this.lbllInvoiceNumber.TabIndex = 3;
            this.lbllInvoiceNumber.Text = "№ накладної:";
            // 
            // tbInvoiceType
            // 
            this.tbInvoiceType.BackColor = System.Drawing.SystemColors.Window;
            this.tbInvoiceType.Location = new System.Drawing.Point(210, 8);
            this.tbInvoiceType.Name = "tbInvoiceType";
            this.tbInvoiceType.ReadOnly = true;
            this.tbInvoiceType.Size = new System.Drawing.Size(200, 20);
            this.tbInvoiceType.TabIndex = 2;
            this.tbInvoiceType.TabStop = false;
            // 
            // stbInvoiceType
            // 
            this.stbInvoiceType.Location = new System.Drawing.Point(104, 8);
            this.stbInvoiceType.Name = "stbInvoiceType";
            this.stbInvoiceType.NavigateByValue = false;
            this.stbInvoiceType.ReadOnly = false;
            this.stbInvoiceType.Size = new System.Drawing.Size(100, 20);
            this.stbInvoiceType.TabIndex = 1;
            this.stbInvoiceType.UserID = ((long)(0));
            this.stbInvoiceType.Value = null;
            this.stbInvoiceType.ValueReferenceQuery = null;
            // 
            // lblInvoiceType
            // 
            this.lblInvoiceType.AutoSize = true;
            this.lblInvoiceType.Location = new System.Drawing.Point(13, 12);
            this.lblInvoiceType.Name = "lblInvoiceType";
            this.lblInvoiceType.Size = new System.Drawing.Size(83, 13);
            this.lblInvoiceType.TabIndex = 0;
            this.lblInvoiceType.Text = "Тип накладної:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(541, 94);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.ShowCheckBox = true;
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 18;
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(450, 98);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(59, 13);
            this.lblPeriodTo.TabIndex = 17;
            this.lblPeriodTo.Text = "Період по:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(104, 94);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.ShowCheckBox = true;
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 16;
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(13, 98);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(53, 13);
            this.lblPeriodFrom.TabIndex = 15;
            this.lblPeriodFrom.Text = "Період з:";
            // 
            // tbStatusTo
            // 
            this.tbStatusTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusTo.Location = new System.Drawing.Point(647, 65);
            this.tbStatusTo.Name = "tbStatusTo";
            this.tbStatusTo.ReadOnly = true;
            this.tbStatusTo.Size = new System.Drawing.Size(200, 20);
            this.tbStatusTo.TabIndex = 14;
            // 
            // lblStatusTo
            // 
            this.lblStatusTo.AutoSize = true;
            this.lblStatusTo.Location = new System.Drawing.Point(450, 69);
            this.lblStatusTo.Name = "lblStatusTo";
            this.lblStatusTo.Size = new System.Drawing.Size(59, 13);
            this.lblStatusTo.TabIndex = 12;
            this.lblStatusTo.Text = "Статус по:";
            // 
            // stbStatusTo
            // 
            this.stbStatusTo.Location = new System.Drawing.Point(541, 65);
            this.stbStatusTo.Name = "stbStatusTo";
            this.stbStatusTo.NavigateByValue = false;
            this.stbStatusTo.ReadOnly = false;
            this.stbStatusTo.Size = new System.Drawing.Size(100, 20);
            this.stbStatusTo.TabIndex = 13;
            this.stbStatusTo.UserID = ((long)(0));
            this.stbStatusTo.Value = null;
            this.stbStatusTo.ValueReferenceQuery = null;
            // 
            // tbStatusFrom
            // 
            this.tbStatusFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbStatusFrom.Location = new System.Drawing.Point(210, 65);
            this.tbStatusFrom.Name = "tbStatusFrom";
            this.tbStatusFrom.ReadOnly = true;
            this.tbStatusFrom.Size = new System.Drawing.Size(200, 20);
            this.tbStatusFrom.TabIndex = 11;
            // 
            // lblStatusFrom
            // 
            this.lblStatusFrom.AutoSize = true;
            this.lblStatusFrom.Location = new System.Drawing.Point(13, 69);
            this.lblStatusFrom.Name = "lblStatusFrom";
            this.lblStatusFrom.Size = new System.Drawing.Size(53, 13);
            this.lblStatusFrom.TabIndex = 9;
            this.lblStatusFrom.Text = "Статус з:";
            // 
            // stbStatusFrom
            // 
            this.stbStatusFrom.Location = new System.Drawing.Point(104, 65);
            this.stbStatusFrom.Name = "stbStatusFrom";
            this.stbStatusFrom.NavigateByValue = false;
            this.stbStatusFrom.ReadOnly = false;
            this.stbStatusFrom.Size = new System.Drawing.Size(100, 20);
            this.stbStatusFrom.TabIndex = 10;
            this.stbStatusFrom.UserID = ((long)(0));
            this.stbStatusFrom.Value = null;
            this.stbStatusFrom.ValueReferenceQuery = null;
            // 
            // tbDebtorTo
            // 
            this.tbDebtorTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorTo.Location = new System.Drawing.Point(647, 36);
            this.tbDebtorTo.Name = "tbDebtorTo";
            this.tbDebtorTo.ReadOnly = true;
            this.tbDebtorTo.Size = new System.Drawing.Size(200, 20);
            this.tbDebtorTo.TabIndex = 8;
            // 
            // lbllDebtorTo
            // 
            this.lbllDebtorTo.AutoSize = true;
            this.lbllDebtorTo.Location = new System.Drawing.Point(450, 40);
            this.lbllDebtorTo.Name = "lbllDebtorTo";
            this.lbllDebtorTo.Size = new System.Drawing.Size(65, 13);
            this.lbllDebtorTo.TabIndex = 6;
            this.lbllDebtorTo.Text = "Дебітор по:";
            // 
            // stbDebtorTo
            // 
            this.stbDebtorTo.Location = new System.Drawing.Point(541, 36);
            this.stbDebtorTo.Name = "stbDebtorTo";
            this.stbDebtorTo.NavigateByValue = false;
            this.stbDebtorTo.ReadOnly = false;
            this.stbDebtorTo.Size = new System.Drawing.Size(100, 20);
            this.stbDebtorTo.TabIndex = 7;
            this.stbDebtorTo.UserID = ((long)(0));
            this.stbDebtorTo.Value = null;
            this.stbDebtorTo.ValueReferenceQuery = null;
            // 
            // tbDebtorFrom
            // 
            this.tbDebtorFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorFrom.Location = new System.Drawing.Point(210, 36);
            this.tbDebtorFrom.Name = "tbDebtorFrom";
            this.tbDebtorFrom.ReadOnly = true;
            this.tbDebtorFrom.Size = new System.Drawing.Size(200, 20);
            this.tbDebtorFrom.TabIndex = 5;
            // 
            // lblDebtorFrom
            // 
            this.lblDebtorFrom.AutoSize = true;
            this.lblDebtorFrom.Location = new System.Drawing.Point(13, 40);
            this.lblDebtorFrom.Name = "lblDebtorFrom";
            this.lblDebtorFrom.Size = new System.Drawing.Size(59, 13);
            this.lblDebtorFrom.TabIndex = 3;
            this.lblDebtorFrom.Text = "Дебітор з:";
            // 
            // stbDebtorFrom
            // 
            this.stbDebtorFrom.Location = new System.Drawing.Point(104, 36);
            this.stbDebtorFrom.Name = "stbDebtorFrom";
            this.stbDebtorFrom.NavigateByValue = false;
            this.stbDebtorFrom.ReadOnly = false;
            this.stbDebtorFrom.Size = new System.Drawing.Size(100, 20);
            this.stbDebtorFrom.TabIndex = 4;
            this.stbDebtorFrom.UserID = ((long)(0));
            this.stbDebtorFrom.Value = null;
            this.stbDebtorFrom.ValueReferenceQuery = null;
            // 
            // tbDocType
            // 
            this.tbDocType.BackColor = System.Drawing.SystemColors.Window;
            this.tbDocType.Location = new System.Drawing.Point(210, 7);
            this.tbDocType.Name = "tbDocType";
            this.tbDocType.ReadOnly = true;
            this.tbDocType.Size = new System.Drawing.Size(200, 20);
            this.tbDocType.TabIndex = 2;
            // 
            // lblDocType
            // 
            this.lblDocType.AutoSize = true;
            this.lblDocType.Location = new System.Drawing.Point(13, 11);
            this.lblDocType.Name = "lblDocType";
            this.lblDocType.Size = new System.Drawing.Size(86, 13);
            this.lblDocType.TabIndex = 0;
            this.lblDocType.Text = "Тип документа:";
            // 
            // stbDocType
            // 
            this.stbDocType.Location = new System.Drawing.Point(104, 7);
            this.stbDocType.Name = "stbDocType";
            this.stbDocType.NavigateByValue = false;
            this.stbDocType.ReadOnly = false;
            this.stbDocType.Size = new System.Drawing.Size(100, 20);
            this.stbDocType.TabIndex = 1;
            this.stbDocType.UserID = ((long)(0));
            this.stbDocType.Value = null;
            this.stbDocType.ValueReferenceQuery = null;
            // 
            // ArchivedInvoicesRegisterWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1459, 535);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.tsMain);
            this.Name = "ArchivedInvoicesRegisterWindow";
            this.Text = "ArchivedInvoicesRegisterWindow";
            this.Controls.SetChildIndex(this.tsMain, 0);
            this.Controls.SetChildIndex(this.pnlMainContent, 0);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripButton btnExportToExcel;
        private System.Windows.Forms.ToolStripButton btnPrintBoxEtic;
        private System.Windows.Forms.ToolStripButton btnShowBoxEticsStatistics;
        private System.Windows.Forms.ToolStripButton btnCreateUtilizationSettings;
        private System.Windows.Forms.ToolStripButton btnPrintRegisterBarcode;
        private System.Windows.Forms.ToolStripButton btnChangeWorkMode;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Panel pnlSearchParameters;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.Panel pnlContent;
        private WMSOffice.Controls.ExtraDataGridViewComponents.ExtraDataGridView xdgvRegistry;
        private System.Windows.Forms.TextBox tbDebtorFrom;
        private System.Windows.Forms.Label lblDebtorFrom;
        private WMSOffice.Controls.SearchTextBox stbDebtorFrom;
        private System.Windows.Forms.TextBox tbDocType;
        private System.Windows.Forms.Label lblDocType;
        private WMSOffice.Controls.SearchTextBox stbDocType;
        private System.Windows.Forms.TextBox tbStatusTo;
        private System.Windows.Forms.Label lblStatusTo;
        private WMSOffice.Controls.SearchTextBox stbStatusTo;
        private System.Windows.Forms.TextBox tbStatusFrom;
        private System.Windows.Forms.Label lblStatusFrom;
        private WMSOffice.Controls.SearchTextBox stbStatusFrom;
        private System.Windows.Forms.TextBox tbDebtorTo;
        private System.Windows.Forms.Label lbllDebtorTo;
        private WMSOffice.Controls.SearchTextBox stbDebtorTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.Panel pnlArchiveModeSearchParameters;
        private System.Windows.Forms.TextBox tbInvoiceNumber;
        private System.Windows.Forms.Label lbllInvoiceNumber;
        private System.Windows.Forms.TextBox tbInvoiceType;
        private WMSOffice.Controls.SearchTextBox stbInvoiceType;
        private System.Windows.Forms.Label lblInvoiceType;
        private System.Windows.Forms.Label lblBarCode;
        private System.Windows.Forms.TextBox tbBarCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripButton btnCreateRegister;
        private System.Windows.Forms.ToolStripSplitButton ssbPreviewRegister;
        private System.Windows.Forms.ToolStripMenuItem ssbiPreviewRegister;
        private System.Windows.Forms.ToolStripMenuItem ssbiPreviewRegisterHeader;
    }
}