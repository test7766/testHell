namespace WMSOffice.Dialogs.Docs
{
    partial class ArchiveInvoiceForm
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
            this.dtpInvoiceArchiveDate = new System.Windows.Forms.DateTimePicker();
            this.lblInvoiceBarCode = new System.Windows.Forms.Label();
            this.lblInvoiceArchiveDate = new System.Windows.Forms.Label();
            this.tbsInvoiceBarCode = new WMSOffice.Controls.TextBoxScaner();
            this.gbRequisites = new System.Windows.Forms.GroupBox();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.lblNote = new System.Windows.Forms.Label();
            this.tcAttachments = new System.Windows.Forms.TabControl();
            this.tpAttorneys = new System.Windows.Forms.TabPage();
            this.tsAttorneysOperations = new System.Windows.Forms.ToolStrip();
            this.ivcAttorneys = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tpAgreements = new System.Windows.Forms.TabPage();
            this.tsAgreementsOperations = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.ivcAgreements = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tpRegister = new System.Windows.Forms.TabPage();
            this.ivcRegister = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tsRegisterOperations = new System.Windows.Forms.ToolStrip();
            this.btnPrintRegister = new System.Windows.Forms.ToolStripButton();
            this.cbAcceptReceivedDocs = new System.Windows.Forms.CheckBox();
            this.wH = new WMSOffice.Data.WH();
            this.tsDocumentOperations = new System.Windows.Forms.ToolStrip();
            this.btnFind = new System.Windows.Forms.ToolStripButton();
            this.btnClear = new System.Windows.Forms.ToolStripButton();
            this.lblArchive = new System.Windows.Forms.Label();
            this.scDocumentWithAttachments = new System.Windows.Forms.SplitContainer();
            this.pnlDocumentContent = new System.Windows.Forms.Panel();
            this.tsRegister = new System.Windows.Forms.ToolStrip();
            this.btnCreateRegister = new System.Windows.Forms.ToolStripButton();
            this.btnSaveRegister = new System.Windows.Forms.ToolStripButton();
            this.btnCompleteRegister = new System.Windows.Forms.ToolStripButton();
            this.btnCloseRegister = new System.Windows.Forms.ToolStripButton();
            this.btnOpenRegister = new System.Windows.Forms.ToolStripButton();
            this.lblRegister = new System.Windows.Forms.ToolStripLabel();
            this.pnlButtons.SuspendLayout();
            this.gbRequisites.SuspendLayout();
            this.tcAttachments.SuspendLayout();
            this.tpAttorneys.SuspendLayout();
            this.tpAgreements.SuspendLayout();
            this.tsAgreementsOperations.SuspendLayout();
            this.tpRegister.SuspendLayout();
            this.tsRegisterOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.tsDocumentOperations.SuspendLayout();
            this.scDocumentWithAttachments.Panel1.SuspendLayout();
            this.scDocumentWithAttachments.Panel2.SuspendLayout();
            this.scDocumentWithAttachments.SuspendLayout();
            this.pnlDocumentContent.SuspendLayout();
            this.tsRegister.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(26941, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(27031, 8);
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
            this.dtpInvoiceArchiveDate.Location = new System.Drawing.Point(108, 86);
            this.dtpInvoiceArchiveDate.Name = "dtpInvoiceArchiveDate";
            this.dtpInvoiceArchiveDate.Size = new System.Drawing.Size(100, 26);
            this.dtpInvoiceArchiveDate.TabIndex = 4;
            // 
            // lblInvoiceBarCode
            // 
            this.lblInvoiceBarCode.AutoSize = true;
            this.lblInvoiceBarCode.Location = new System.Drawing.Point(12, 59);
            this.lblInvoiceBarCode.Name = "lblInvoiceBarCode";
            this.lblInvoiceBarCode.Size = new System.Drawing.Size(85, 13);
            this.lblInvoiceBarCode.TabIndex = 1;
            this.lblInvoiceBarCode.Text = "Ш/К накладної:";
            // 
            // lblInvoiceArchiveDate
            // 
            this.lblInvoiceArchiveDate.AutoSize = true;
            this.lblInvoiceArchiveDate.Location = new System.Drawing.Point(12, 93);
            this.lblInvoiceArchiveDate.Name = "lblInvoiceArchiveDate";
            this.lblInvoiceArchiveDate.Size = new System.Drawing.Size(85, 13);
            this.lblInvoiceArchiveDate.TabIndex = 3;
            this.lblInvoiceArchiveDate.Text = "Дата закриття:";
            // 
            // tbsInvoiceBarCode
            // 
            this.tbsInvoiceBarCode.AllowType = true;
            this.tbsInvoiceBarCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbsInvoiceBarCode.AutoConvert = true;
            this.tbsInvoiceBarCode.DelayThreshold = 50;
            this.tbsInvoiceBarCode.Location = new System.Drawing.Point(105, 53);
            this.tbsInvoiceBarCode.Name = "tbsInvoiceBarCode";
            this.tbsInvoiceBarCode.RaiseTextChangeWithoutEnter = false;
            this.tbsInvoiceBarCode.ReadOnly = false;
            this.tbsInvoiceBarCode.ScannerListener = null;
            this.tbsInvoiceBarCode.Size = new System.Drawing.Size(713, 25);
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
            this.gbRequisites.Controls.Add(this.tbNote);
            this.gbRequisites.Controls.Add(this.lblNote);
            this.gbRequisites.Location = new System.Drawing.Point(0, 137);
            this.gbRequisites.Name = "gbRequisites";
            this.gbRequisites.Size = new System.Drawing.Size(838, 480);
            this.gbRequisites.TabIndex = 7;
            this.gbRequisites.TabStop = false;
            this.gbRequisites.Text = "Реквізити";
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
            this.tbNote.Size = new System.Drawing.Size(803, 75);
            this.tbNote.TabIndex = 1;
            // 
            // lblNote
            // 
            this.lblNote.AutoSize = true;
            this.lblNote.Location = new System.Drawing.Point(12, 31);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(57, 13);
            this.lblNote.TabIndex = 0;
            this.lblNote.Text = "Примітки:";
            // 
            // tcAttachments
            // 
            this.tcAttachments.Controls.Add(this.tpAttorneys);
            this.tcAttachments.Controls.Add(this.tpAgreements);
            this.tcAttachments.Controls.Add(this.tpRegister);
            this.tcAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAttachments.Location = new System.Drawing.Point(0, 0);
            this.tcAttachments.Name = "tcAttachments";
            this.tcAttachments.SelectedIndex = 0;
            this.tcAttachments.Size = new System.Drawing.Size(620, 642);
            this.tcAttachments.TabIndex = 2;
            this.tcAttachments.SelectedIndexChanged += new System.EventHandler(this.tcAttachments_SelectedIndexChanged);
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
            this.tpAttorneys.Text = "Довіреності";
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
            this.ivcAttorneys.DisablePrint = false;
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
            this.btnLoad.Size = new System.Drawing.Size(95, 22);
            this.btnLoad.Text = "Завантажити";
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
            this.ivcAgreements.DisablePrint = false;
            this.ivcAgreements.Location = new System.Drawing.Point(3, 31);
            this.ivcAgreements.Name = "ivcAgreements";
            this.ivcAgreements.Size = new System.Drawing.Size(606, 582);
            this.ivcAgreements.TabIndex = 0;
            // 
            // tpRegister
            // 
            this.tpRegister.Controls.Add(this.ivcRegister);
            this.tpRegister.Controls.Add(this.tsRegisterOperations);
            this.tpRegister.Location = new System.Drawing.Point(4, 22);
            this.tpRegister.Name = "tpRegister";
            this.tpRegister.Size = new System.Drawing.Size(612, 616);
            this.tpRegister.TabIndex = 2;
            this.tpRegister.Text = "Реєстр";
            this.tpRegister.UseVisualStyleBackColor = true;
            // 
            // ivcRegister
            // 
            this.ivcRegister.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ivcRegister.AutoZoomActivated = true;
            this.ivcRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ivcRegister.CurrentItem = null;
            this.ivcRegister.CurrentZoomFactor = 1;
            this.ivcRegister.DisablePrint = false;
            this.ivcRegister.Location = new System.Drawing.Point(3, 31);
            this.ivcRegister.Name = "ivcRegister";
            this.ivcRegister.Size = new System.Drawing.Size(606, 582);
            this.ivcRegister.TabIndex = 3;
            // 
            // tsRegisterOperations
            // 
            this.tsRegisterOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrintRegister});
            this.tsRegisterOperations.Location = new System.Drawing.Point(0, 0);
            this.tsRegisterOperations.Name = "tsRegisterOperations";
            this.tsRegisterOperations.Size = new System.Drawing.Size(612, 25);
            this.tsRegisterOperations.TabIndex = 2;
            this.tsRegisterOperations.Text = "toolStrip1";
            // 
            // btnPrintRegister
            // 
            this.btnPrintRegister.Image = global::WMSOffice.Properties.Resources.print;
            this.btnPrintRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintRegister.Name = "btnPrintRegister";
            this.btnPrintRegister.Size = new System.Drawing.Size(53, 22);
            this.btnPrintRegister.Text = "Друк";
            this.btnPrintRegister.Click += new System.EventHandler(this.btnPrintRegister_Click);
            // 
            // cbAcceptReceivedDocs
            // 
            this.cbAcceptReceivedDocs.AutoSize = true;
            this.cbAcceptReceivedDocs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAcceptReceivedDocs.Location = new System.Drawing.Point(597, 91);
            this.cbAcceptReceivedDocs.Name = "cbAcceptReceivedDocs";
            this.cbAcceptReceivedDocs.Size = new System.Drawing.Size(217, 17);
            this.cbAcceptReceivedDocs.TabIndex = 6;
            this.cbAcceptReceivedDocs.Text = "Підтвердження прийнятих документів";
            this.cbAcceptReceivedDocs.UseVisualStyleBackColor = true;
            this.cbAcceptReceivedDocs.Visible = false;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsDocumentOperations
            // 
            this.tsDocumentOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFind,
            this.btnClear});
            this.tsDocumentOperations.Location = new System.Drawing.Point(0, 0);
            this.tsDocumentOperations.Name = "tsDocumentOperations";
            this.tsDocumentOperations.Size = new System.Drawing.Size(840, 25);
            this.tsDocumentOperations.TabIndex = 0;
            this.tsDocumentOperations.Text = "toolStrip1";
            // 
            // btnFind
            // 
            this.btnFind.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(60, 22);
            this.btnFind.Text = "Пошук";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Image = global::WMSOffice.Properties.Resources.clear;
            this.btnClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(76, 22);
            this.btnClear.Text = "Видалити";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblArchive
            // 
            this.lblArchive.AutoSize = true;
            this.lblArchive.Location = new System.Drawing.Point(500, 93);
            this.lblArchive.Name = "lblArchive";
            this.lblArchive.Size = new System.Drawing.Size(66, 13);
            this.lblArchive.TabIndex = 5;
            this.lblArchive.Text = "Додатково:";
            this.lblArchive.Visible = false;
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
            this.scDocumentWithAttachments.Panel1.Controls.Add(this.pnlDocumentContent);
            this.scDocumentWithAttachments.Panel1.Controls.Add(this.tsDocumentOperations);
            // 
            // scDocumentWithAttachments.Panel2
            // 
            this.scDocumentWithAttachments.Panel2.Controls.Add(this.tcAttachments);
            this.scDocumentWithAttachments.Size = new System.Drawing.Size(1464, 642);
            this.scDocumentWithAttachments.SplitterDistance = 840;
            this.scDocumentWithAttachments.TabIndex = 9;
            // 
            // pnlDocumentContent
            // 
            this.pnlDocumentContent.Controls.Add(this.tsRegister);
            this.pnlDocumentContent.Controls.Add(this.lblInvoiceBarCode);
            this.pnlDocumentContent.Controls.Add(this.lblArchive);
            this.pnlDocumentContent.Controls.Add(this.gbRequisites);
            this.pnlDocumentContent.Controls.Add(this.tbsInvoiceBarCode);
            this.pnlDocumentContent.Controls.Add(this.dtpInvoiceArchiveDate);
            this.pnlDocumentContent.Controls.Add(this.lblInvoiceArchiveDate);
            this.pnlDocumentContent.Controls.Add(this.cbAcceptReceivedDocs);
            this.pnlDocumentContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDocumentContent.Location = new System.Drawing.Point(0, 25);
            this.pnlDocumentContent.Name = "pnlDocumentContent";
            this.pnlDocumentContent.Size = new System.Drawing.Size(840, 617);
            this.pnlDocumentContent.TabIndex = 1;
            // 
            // tsRegister
            // 
            this.tsRegister.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tsRegister.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCreateRegister,
            this.btnSaveRegister,
            this.btnCompleteRegister,
            this.btnCloseRegister,
            this.btnOpenRegister,
            this.lblRegister});
            this.tsRegister.Location = new System.Drawing.Point(0, 0);
            this.tsRegister.Name = "tsRegister";
            this.tsRegister.Size = new System.Drawing.Size(840, 46);
            this.tsRegister.TabIndex = 8;
            this.tsRegister.Text = "toolStrip1";
            // 
            // btnCreateRegister
            // 
            this.btnCreateRegister.Image = global::WMSOffice.Properties.Resources.document_plain_new;
            this.btnCreateRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreateRegister.Name = "btnCreateRegister";
            this.btnCreateRegister.Size = new System.Drawing.Size(92, 43);
            this.btnCreateRegister.Text = "Створити\nреєстр\nархіву";
            this.btnCreateRegister.Click += new System.EventHandler(this.btnCreateRegister_Click);
            // 
            // btnSaveRegister
            // 
            this.btnSaveRegister.Image = global::WMSOffice.Properties.Resources.save;
            this.btnSaveRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveRegister.Name = "btnSaveRegister";
            this.btnSaveRegister.Size = new System.Drawing.Size(90, 43);
            this.btnSaveRegister.Text = "Зберегти\nреєстр\nархіву";
            this.btnSaveRegister.Click += new System.EventHandler(this.btnSaveRegister_Click);
            // 
            // btnCompleteRegister
            // 
            this.btnCompleteRegister.Image = global::WMSOffice.Properties.Resources.ok;
            this.btnCompleteRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompleteRegister.Name = "btnCompleteRegister";
            this.btnCompleteRegister.Size = new System.Drawing.Size(136, 43);
            this.btnCompleteRegister.Text = "Завершити\nформування\nреєстру (коробки)";
            this.btnCompleteRegister.Click += new System.EventHandler(this.btnCompleteRegister_Click);
            // 
            // btnCloseRegister
            // 
            this.btnCloseRegister.Image = global::WMSOffice.Properties.Resources.symbol_stop;
            this.btnCloseRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCloseRegister.Name = "btnCloseRegister";
            this.btnCloseRegister.Size = new System.Drawing.Size(102, 43);
            this.btnCloseRegister.Text = "Завершити\nсканування\nза період";
            this.btnCloseRegister.Click += new System.EventHandler(this.btnCloseRegister_Click);
            // 
            // btnOpenRegister
            // 
            this.btnOpenRegister.Image = global::WMSOffice.Properties.Resources.books;
            this.btnOpenRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenRegister.Name = "btnOpenRegister";
            this.btnOpenRegister.Size = new System.Drawing.Size(116, 43);
            this.btnOpenRegister.Text = "Реєстр архіву,\nнезавершені\n(збережені)";
            this.btnOpenRegister.Click += new System.EventHandler(this.btnOpenRegister_Click);
            // 
            // lblRegister
            // 
            this.lblRegister.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.lblRegister.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblRegister.ForeColor = System.Drawing.Color.Brown;
            this.lblRegister.Name = "lblRegister";
            this.lblRegister.Size = new System.Drawing.Size(67, 43);
            this.lblRegister.Text = "№ реєстру:";
            this.lblRegister.Visible = false;
            // 
            // ArchiveInvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 691);
            this.Controls.Add(this.scDocumentWithAttachments);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "ArchiveInvoiceForm";
            this.Text = "Закриття накладної";
            this.Load += new System.EventHandler(this.ArchiveInvoiceForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArchiveInvoiceForm_FormClosing);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.scDocumentWithAttachments, 0);
            this.pnlButtons.ResumeLayout(false);
            this.gbRequisites.ResumeLayout(false);
            this.gbRequisites.PerformLayout();
            this.tcAttachments.ResumeLayout(false);
            this.tpAttorneys.ResumeLayout(false);
            this.tpAttorneys.PerformLayout();
            this.tpAgreements.ResumeLayout(false);
            this.tpAgreements.PerformLayout();
            this.tsAgreementsOperations.ResumeLayout(false);
            this.tsAgreementsOperations.PerformLayout();
            this.tpRegister.ResumeLayout(false);
            this.tpRegister.PerformLayout();
            this.tsRegisterOperations.ResumeLayout(false);
            this.tsRegisterOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.tsDocumentOperations.ResumeLayout(false);
            this.tsDocumentOperations.PerformLayout();
            this.scDocumentWithAttachments.Panel1.ResumeLayout(false);
            this.scDocumentWithAttachments.Panel1.PerformLayout();
            this.scDocumentWithAttachments.Panel2.ResumeLayout(false);
            this.scDocumentWithAttachments.ResumeLayout(false);
            this.pnlDocumentContent.ResumeLayout(false);
            this.pnlDocumentContent.PerformLayout();
            this.tsRegister.ResumeLayout(false);
            this.tsRegister.PerformLayout();
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
        private System.Windows.Forms.CheckBox cbAcceptReceivedDocs;
        private System.Windows.Forms.TabControl tcAttachments;
        private System.Windows.Forms.TabPage tpAttorneys;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAttorneys;
        private System.Windows.Forms.TabPage tpAgreements;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAgreements;
        private System.Windows.Forms.ToolStrip tsAttorneysOperations;
        private System.Windows.Forms.ToolStrip tsAgreementsOperations;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private WMSOffice.Data.WH wH;
        private System.Windows.Forms.ToolStrip tsDocumentOperations;
        private System.Windows.Forms.ToolStripButton btnFind;
        private System.Windows.Forms.ToolStripButton btnClear;
        private System.Windows.Forms.Label lblArchive;
        private System.Windows.Forms.SplitContainer scDocumentWithAttachments;
        private System.Windows.Forms.Panel pnlDocumentContent;
        private System.Windows.Forms.ToolStrip tsRegister;
        private System.Windows.Forms.ToolStripButton btnCreateRegister;
        private System.Windows.Forms.ToolStripButton btnSaveRegister;
        private System.Windows.Forms.ToolStripButton btnCompleteRegister;
        private System.Windows.Forms.ToolStripButton btnCloseRegister;
        private System.Windows.Forms.ToolStripButton btnOpenRegister;
        private System.Windows.Forms.TabPage tpRegister;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcRegister;
        private System.Windows.Forms.ToolStrip tsRegisterOperations;
        private System.Windows.Forms.ToolStripButton btnPrintRegister;
        private System.Windows.Forms.ToolStripLabel lblRegister;
    }
}