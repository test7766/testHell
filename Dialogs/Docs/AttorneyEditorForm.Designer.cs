namespace WMSOffice.Dialogs.Docs
{
    partial class AttorneyEditorForm
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
            this.lblAttorneyNumber = new System.Windows.Forms.Label();
            this.dtpPeriodFrom = new System.Windows.Forms.DateTimePicker();
            this.tbAttorneyNumber = new System.Windows.Forms.TextBox();
            this.cbPrintOnInvoice = new System.Windows.Forms.CheckBox();
            this.lblReceiver = new System.Windows.Forms.Label();
            this.dtpPeriodTo = new System.Windows.Forms.DateTimePicker();
            this.ivcAttorneys = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.lblPeriodFrom = new System.Windows.Forms.Label();
            this.lblPeriodTo = new System.Windows.Forms.Label();
            this.lblRestrictDaysCount = new System.Windows.Forms.Label();
            this.tbRestrictDaysCount = new System.Windows.Forms.TextBox();
            this.cmbReceiver = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.aCDebtorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wH = new WMSOffice.Data.WH();
            this.timerSearchReceivers = new System.Windows.Forms.Timer(this.components);
            this.aC_DebtorsTableAdapter = new WMSOffice.Data.WHTableAdapters.AC_DebtorsTableAdapter();
            this.tcAttachments = new System.Windows.Forms.TabControl();
            this.tpAttorneys = new System.Windows.Forms.TabPage();
            this.tsAttorneysOperations = new System.Windows.Forms.ToolStrip();
            this.btnAddAttachment = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteAttachment = new System.Windows.Forms.ToolStripButton();
            this.tpAgreements = new System.Windows.Forms.TabPage();
            this.ivcAgreements = new WMSOffice.Controls.Custom.ImageViewerControl();
            this.tsAgreementsOperations = new System.Windows.Forms.ToolStrip();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.lblDebtorsForClone = new System.Windows.Forms.Label();
            this.tbDebtorsForClone = new System.Windows.Forms.TextBox();
            this.btnSelectDebtorsForClone = new System.Windows.Forms.Button();
            this.cmbAgreements = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.agreementsByVendorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblAgreement = new System.Windows.Forms.Label();
            this.tbAgreementFrom = new System.Windows.Forms.TextBox();
            this.lblAgreementFrom = new System.Windows.Forms.Label();
            this.tbAgreementTo = new System.Windows.Forms.TextBox();
            this.lblAgreementTo = new System.Windows.Forms.Label();
            this.agreementsByVendorTableAdapter = new WMSOffice.Data.WHTableAdapters.AgreementsByVendorTableAdapter();
            this.pnlButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aCDebtorsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).BeginInit();
            this.tcAttachments.SuspendLayout();
            this.tpAttorneys.SuspendLayout();
            this.tsAttorneysOperations.SuspendLayout();
            this.tpAgreements.SuspendLayout();
            this.tsAgreementsOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsByVendorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(10075, 8);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(10165, 8);
            // 
            // pnlButtons
            // 
            this.pnlButtons.Location = new System.Drawing.Point(0, 638);
            this.pnlButtons.Size = new System.Drawing.Size(704, 43);
            this.pnlButtons.TabIndex = 21;
            // 
            // lblAttorneyNumber
            // 
            this.lblAttorneyNumber.AutoSize = true;
            this.lblAttorneyNumber.Location = new System.Drawing.Point(12, 9);
            this.lblAttorneyNumber.Name = "lblAttorneyNumber";
            this.lblAttorneyNumber.Size = new System.Drawing.Size(95, 13);
            this.lblAttorneyNumber.TabIndex = 0;
            this.lblAttorneyNumber.Text = "№ доверенности:";
            // 
            // dtpPeriodFrom
            // 
            this.dtpPeriodFrom.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodFrom.Location = new System.Drawing.Point(167, 92);
            this.dtpPeriodFrom.Name = "dtpPeriodFrom";
            this.dtpPeriodFrom.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodFrom.TabIndex = 8;
            // 
            // tbAttorneyNumber
            // 
            this.tbAttorneyNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbAttorneyNumber.Location = new System.Drawing.Point(167, 5);
            this.tbAttorneyNumber.Name = "tbAttorneyNumber";
            this.tbAttorneyNumber.Size = new System.Drawing.Size(515, 20);
            this.tbAttorneyNumber.TabIndex = 1;
            // 
            // cbPrintOnInvoice
            // 
            this.cbPrintOnInvoice.AutoSize = true;
            this.cbPrintOnInvoice.Location = new System.Drawing.Point(12, 154);
            this.cbPrintOnInvoice.Name = "cbPrintOnInvoice";
            this.cbPrintOnInvoice.Size = new System.Drawing.Size(136, 30);
            this.cbPrintOnInvoice.TabIndex = 13;
            this.cbPrintOnInvoice.Text = "Печатать на \r\nрасходной накладной";
            this.cbPrintOnInvoice.UseVisualStyleBackColor = true;
            // 
            // lblReceiver
            // 
            this.lblReceiver.AutoSize = true;
            this.lblReceiver.Location = new System.Drawing.Point(12, 38);
            this.lblReceiver.Name = "lblReceiver";
            this.lblReceiver.Size = new System.Drawing.Size(69, 13);
            this.lblReceiver.TabIndex = 2;
            this.lblReceiver.Text = "Получатель:";
            // 
            // dtpPeriodTo
            // 
            this.dtpPeriodTo.CustomFormat = "dd.MM.yyyy";
            this.dtpPeriodTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpPeriodTo.Location = new System.Drawing.Point(499, 92);
            this.dtpPeriodTo.Name = "dtpPeriodTo";
            this.dtpPeriodTo.Size = new System.Drawing.Size(100, 20);
            this.dtpPeriodTo.TabIndex = 10;
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
            this.ivcAttorneys.Size = new System.Drawing.Size(666, 332);
            this.ivcAttorneys.TabIndex = 1;
            // 
            // lblPeriodFrom
            // 
            this.lblPeriodFrom.AutoSize = true;
            this.lblPeriodFrom.Location = new System.Drawing.Point(12, 96);
            this.lblPeriodFrom.Name = "lblPeriodFrom";
            this.lblPeriodFrom.Size = new System.Drawing.Size(98, 13);
            this.lblPeriodFrom.TabIndex = 7;
            this.lblPeriodFrom.Text = "Действительна с:";
            // 
            // lblPeriodTo
            // 
            this.lblPeriodTo.AutoSize = true;
            this.lblPeriodTo.Location = new System.Drawing.Point(331, 96);
            this.lblPeriodTo.Name = "lblPeriodTo";
            this.lblPeriodTo.Size = new System.Drawing.Size(104, 13);
            this.lblPeriodTo.TabIndex = 9;
            this.lblPeriodTo.Text = "Действительна по:";
            // 
            // lblRestrictDaysCount
            // 
            this.lblRestrictDaysCount.AutoSize = true;
            this.lblRestrictDaysCount.Location = new System.Drawing.Point(12, 200);
            this.lblRestrictDaysCount.Name = "lblRestrictDaysCount";
            this.lblRestrictDaysCount.Size = new System.Drawing.Size(149, 26);
            this.lblRestrictDaysCount.TabIndex = 18;
            this.lblRestrictDaysCount.Text = "Не печатать на документах \r\nза X дней:";
            // 
            // tbRestrictDaysCount
            // 
            this.tbRestrictDaysCount.Location = new System.Drawing.Point(167, 200);
            this.tbRestrictDaysCount.Name = "tbRestrictDaysCount";
            this.tbRestrictDaysCount.Size = new System.Drawing.Size(100, 20);
            this.tbRestrictDaysCount.TabIndex = 19;
            this.tbRestrictDaysCount.Text = "3";
            // 
            // cmbReceiver
            // 
            this.cmbReceiver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReceiver.DataSource = this.aCDebtorsBindingSource;
            this.cmbReceiver.DisplayMember = "debtor_name";
            this.cmbReceiver.FormattingEnabled = true;
            this.cmbReceiver.Location = new System.Drawing.Point(167, 34);
            this.cmbReceiver.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.cmbReceiver.Name = "cmbReceiver";
            this.cmbReceiver.Size = new System.Drawing.Size(515, 21);
            this.cmbReceiver.TabIndex = 3;
            this.cmbReceiver.ValueMember = "debtor_id";
            this.cmbReceiver.SelectedValueChanged += new System.EventHandler(this.cmbReceiver_SelectedValueChanged);
            this.cmbReceiver.TextChanged += new System.EventHandler(this.cmbReceiver_TextChanged);
            // 
            // aCDebtorsBindingSource
            // 
            this.aCDebtorsBindingSource.DataMember = "AC_Debtors";
            this.aCDebtorsBindingSource.DataSource = this.wH;
            // 
            // wH
            // 
            this.wH.DataSetName = "WH";
            this.wH.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // timerSearchReceivers
            // 
            this.timerSearchReceivers.Interval = 500;
            this.timerSearchReceivers.Tick += new System.EventHandler(this.timerSearchReceivers_Tick);
            // 
            // aC_DebtorsTableAdapter
            // 
            this.aC_DebtorsTableAdapter.ClearBeforeFill = true;
            // 
            // tcAttachments
            // 
            this.tcAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcAttachments.Controls.Add(this.tpAttorneys);
            this.tcAttachments.Controls.Add(this.tpAgreements);
            this.tcAttachments.Location = new System.Drawing.Point(12, 240);
            this.tcAttachments.Name = "tcAttachments";
            this.tcAttachments.SelectedIndex = 0;
            this.tcAttachments.Size = new System.Drawing.Size(680, 392);
            this.tcAttachments.TabIndex = 20;
            // 
            // tpAttorneys
            // 
            this.tpAttorneys.Controls.Add(this.tsAttorneysOperations);
            this.tpAttorneys.Controls.Add(this.ivcAttorneys);
            this.tpAttorneys.Location = new System.Drawing.Point(4, 22);
            this.tpAttorneys.Name = "tpAttorneys";
            this.tpAttorneys.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttorneys.Size = new System.Drawing.Size(672, 366);
            this.tpAttorneys.TabIndex = 0;
            this.tpAttorneys.Text = "Доверенности";
            this.tpAttorneys.UseVisualStyleBackColor = true;
            // 
            // tsAttorneysOperations
            // 
            this.tsAttorneysOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddAttachment,
            this.btnDeleteAttachment});
            this.tsAttorneysOperations.Location = new System.Drawing.Point(3, 3);
            this.tsAttorneysOperations.Name = "tsAttorneysOperations";
            this.tsAttorneysOperations.Size = new System.Drawing.Size(666, 25);
            this.tsAttorneysOperations.TabIndex = 0;
            this.tsAttorneysOperations.Text = "toolStrip1";
            // 
            // btnAddAttachment
            // 
            this.btnAddAttachment.Image = global::WMSOffice.Properties.Resources.open_folder_icon;
            this.btnAddAttachment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(119, 22);
            this.btnAddAttachment.Text = "Добавить копию";
            this.btnAddAttachment.Click += new System.EventHandler(this.btnAddAttachment_Click);
            // 
            // btnDeleteAttachment
            // 
            this.btnDeleteAttachment.Image = global::WMSOffice.Properties.Resources.close;
            this.btnDeleteAttachment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteAttachment.Name = "btnDeleteAttachment";
            this.btnDeleteAttachment.Size = new System.Drawing.Size(111, 22);
            this.btnDeleteAttachment.Text = "Удалить копию";
            this.btnDeleteAttachment.Click += new System.EventHandler(this.btnDeleteAttachment_Click);
            // 
            // tpAgreements
            // 
            this.tpAgreements.Controls.Add(this.ivcAgreements);
            this.tpAgreements.Controls.Add(this.tsAgreementsOperations);
            this.tpAgreements.Location = new System.Drawing.Point(4, 22);
            this.tpAgreements.Name = "tpAgreements";
            this.tpAgreements.Padding = new System.Windows.Forms.Padding(3);
            this.tpAgreements.Size = new System.Drawing.Size(672, 366);
            this.tpAgreements.TabIndex = 1;
            this.tpAgreements.Text = "Договора";
            this.tpAgreements.UseVisualStyleBackColor = true;
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
            this.ivcAgreements.Size = new System.Drawing.Size(666, 332);
            this.ivcAgreements.TabIndex = 1;
            // 
            // tsAgreementsOperations
            // 
            this.tsAgreementsOperations.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoad});
            this.tsAgreementsOperations.Location = new System.Drawing.Point(3, 3);
            this.tsAgreementsOperations.Name = "tsAgreementsOperations";
            this.tsAgreementsOperations.Size = new System.Drawing.Size(666, 25);
            this.tsAgreementsOperations.TabIndex = 0;
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
            // lblDebtorsForClone
            // 
            this.lblDebtorsForClone.AutoSize = true;
            this.lblDebtorsForClone.Location = new System.Drawing.Point(12, 67);
            this.lblDebtorsForClone.Name = "lblDebtorsForClone";
            this.lblDebtorsForClone.Size = new System.Drawing.Size(97, 13);
            this.lblDebtorsForClone.TabIndex = 4;
            this.lblDebtorsForClone.Text = "Адреса доставки:";
            // 
            // tbDebtorsForClone
            // 
            this.tbDebtorsForClone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebtorsForClone.BackColor = System.Drawing.SystemColors.Window;
            this.tbDebtorsForClone.Enabled = false;
            this.tbDebtorsForClone.Location = new System.Drawing.Point(195, 63);
            this.tbDebtorsForClone.Name = "tbDebtorsForClone";
            this.tbDebtorsForClone.Size = new System.Drawing.Size(487, 20);
            this.tbDebtorsForClone.TabIndex = 6;
            // 
            // btnSelectDebtorsForClone
            // 
            this.btnSelectDebtorsForClone.Image = global::WMSOffice.Properties.Resources.ellipsis;
            this.btnSelectDebtorsForClone.Location = new System.Drawing.Point(167, 62);
            this.btnSelectDebtorsForClone.Name = "btnSelectDebtorsForClone";
            this.btnSelectDebtorsForClone.Size = new System.Drawing.Size(25, 22);
            this.btnSelectDebtorsForClone.TabIndex = 5;
            this.btnSelectDebtorsForClone.UseVisualStyleBackColor = true;
            this.btnSelectDebtorsForClone.Click += new System.EventHandler(this.btnSelectDebtorsForClone_Click);
            // 
            // cmbAgreements
            // 
            this.cmbAgreements.DataSource = this.agreementsByVendorBindingSource;
            this.cmbAgreements.DisplayMember = "DocName";
            this.cmbAgreements.FormattingEnabled = true;
            this.cmbAgreements.Location = new System.Drawing.Point(167, 118);
            this.cmbAgreements.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.cmbAgreements.Name = "cmbAgreements";
            this.cmbAgreements.Size = new System.Drawing.Size(432, 21);
            this.cmbAgreements.TabIndex = 12;
            this.cmbAgreements.ValueMember = "DocID";
            this.cmbAgreements.SelectedValueChanged += new System.EventHandler(this.cmbAgreements_SelectedValueChanged);
            // 
            // agreementsByVendorBindingSource
            // 
            this.agreementsByVendorBindingSource.DataMember = "AgreementsByVendor";
            this.agreementsByVendorBindingSource.DataSource = this.wH;
            // 
            // lblAgreement
            // 
            this.lblAgreement.AutoSize = true;
            this.lblAgreement.Location = new System.Drawing.Point(12, 125);
            this.lblAgreement.Name = "lblAgreement";
            this.lblAgreement.Size = new System.Drawing.Size(54, 13);
            this.lblAgreement.TabIndex = 11;
            this.lblAgreement.Text = "Договор:";
            // 
            // tbAgreementFrom
            // 
            this.tbAgreementFrom.BackColor = System.Drawing.SystemColors.Window;
            this.tbAgreementFrom.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbAgreementFrom.Location = new System.Drawing.Point(202, 145);
            this.tbAgreementFrom.Name = "tbAgreementFrom";
            this.tbAgreementFrom.ReadOnly = true;
            this.tbAgreementFrom.Size = new System.Drawing.Size(65, 20);
            this.tbAgreementFrom.TabIndex = 15;
            // 
            // lblAgreementFrom
            // 
            this.lblAgreementFrom.AutoSize = true;
            this.lblAgreementFrom.Location = new System.Drawing.Point(180, 149);
            this.lblAgreementFrom.Name = "lblAgreementFrom";
            this.lblAgreementFrom.Size = new System.Drawing.Size(16, 13);
            this.lblAgreementFrom.TabIndex = 14;
            this.lblAgreementFrom.Text = "с:";
            // 
            // tbAgreementTo
            // 
            this.tbAgreementTo.BackColor = System.Drawing.SystemColors.Window;
            this.tbAgreementTo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.tbAgreementTo.Location = new System.Drawing.Point(534, 145);
            this.tbAgreementTo.Name = "tbAgreementTo";
            this.tbAgreementTo.ReadOnly = true;
            this.tbAgreementTo.Size = new System.Drawing.Size(65, 20);
            this.tbAgreementTo.TabIndex = 17;
            // 
            // lblAgreementTo
            // 
            this.lblAgreementTo.AutoSize = true;
            this.lblAgreementTo.Location = new System.Drawing.Point(506, 149);
            this.lblAgreementTo.Name = "lblAgreementTo";
            this.lblAgreementTo.Size = new System.Drawing.Size(22, 13);
            this.lblAgreementTo.TabIndex = 16;
            this.lblAgreementTo.Text = "по:";
            // 
            // agreementsByVendorTableAdapter
            // 
            this.agreementsByVendorTableAdapter.ClearBeforeFill = true;
            // 
            // AttorneyEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 681);
            this.Controls.Add(this.lblAgreementTo);
            this.Controls.Add(this.tbAgreementTo);
            this.Controls.Add(this.lblAgreementFrom);
            this.Controls.Add(this.tbAgreementFrom);
            this.Controls.Add(this.lblAgreement);
            this.Controls.Add(this.cmbAgreements);
            this.Controls.Add(this.btnSelectDebtorsForClone);
            this.Controls.Add(this.tbDebtorsForClone);
            this.Controls.Add(this.lblDebtorsForClone);
            this.Controls.Add(this.tcAttachments);
            this.Controls.Add(this.cmbReceiver);
            this.Controls.Add(this.tbRestrictDaysCount);
            this.Controls.Add(this.lblRestrictDaysCount);
            this.Controls.Add(this.lblPeriodTo);
            this.Controls.Add(this.lblPeriodFrom);
            this.Controls.Add(this.dtpPeriodTo);
            this.Controls.Add(this.lblReceiver);
            this.Controls.Add(this.cbPrintOnInvoice);
            this.Controls.Add(this.tbAttorneyNumber);
            this.Controls.Add(this.dtpPeriodFrom);
            this.Controls.Add(this.lblAttorneyNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.Name = "AttorneyEditorForm";
            this.Text = "Редактор доверенности";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AttorneyRegistrationForm_FormClosing);
            this.Controls.SetChildIndex(this.lblAttorneyNumber, 0);
            this.Controls.SetChildIndex(this.dtpPeriodFrom, 0);
            this.Controls.SetChildIndex(this.tbAttorneyNumber, 0);
            this.Controls.SetChildIndex(this.cbPrintOnInvoice, 0);
            this.Controls.SetChildIndex(this.pnlButtons, 0);
            this.Controls.SetChildIndex(this.lblReceiver, 0);
            this.Controls.SetChildIndex(this.dtpPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblPeriodFrom, 0);
            this.Controls.SetChildIndex(this.lblPeriodTo, 0);
            this.Controls.SetChildIndex(this.lblRestrictDaysCount, 0);
            this.Controls.SetChildIndex(this.tbRestrictDaysCount, 0);
            this.Controls.SetChildIndex(this.cmbReceiver, 0);
            this.Controls.SetChildIndex(this.tcAttachments, 0);
            this.Controls.SetChildIndex(this.lblDebtorsForClone, 0);
            this.Controls.SetChildIndex(this.tbDebtorsForClone, 0);
            this.Controls.SetChildIndex(this.btnSelectDebtorsForClone, 0);
            this.Controls.SetChildIndex(this.cmbAgreements, 0);
            this.Controls.SetChildIndex(this.lblAgreement, 0);
            this.Controls.SetChildIndex(this.tbAgreementFrom, 0);
            this.Controls.SetChildIndex(this.lblAgreementFrom, 0);
            this.Controls.SetChildIndex(this.tbAgreementTo, 0);
            this.Controls.SetChildIndex(this.lblAgreementTo, 0);
            this.pnlButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aCDebtorsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wH)).EndInit();
            this.tcAttachments.ResumeLayout(false);
            this.tpAttorneys.ResumeLayout(false);
            this.tpAttorneys.PerformLayout();
            this.tsAttorneysOperations.ResumeLayout(false);
            this.tsAttorneysOperations.PerformLayout();
            this.tpAgreements.ResumeLayout(false);
            this.tpAgreements.PerformLayout();
            this.tsAgreementsOperations.ResumeLayout(false);
            this.tsAgreementsOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.agreementsByVendorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAttorneyNumber;
        private System.Windows.Forms.DateTimePicker dtpPeriodFrom;
        private System.Windows.Forms.TextBox tbAttorneyNumber;
        private System.Windows.Forms.CheckBox cbPrintOnInvoice;
        private System.Windows.Forms.Label lblReceiver;
        private System.Windows.Forms.DateTimePicker dtpPeriodTo;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAttorneys;
        private System.Windows.Forms.Label lblPeriodFrom;
        private System.Windows.Forms.Label lblPeriodTo;
        private System.Windows.Forms.Label lblRestrictDaysCount;
        private System.Windows.Forms.TextBox tbRestrictDaysCount;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox cmbReceiver;
        private System.Windows.Forms.BindingSource aCDebtorsBindingSource;
        private WMSOffice.Data.WH wH;
        private WMSOffice.Data.WHTableAdapters.AC_DebtorsTableAdapter aC_DebtorsTableAdapter;
        private System.Windows.Forms.Timer timerSearchReceivers;
        private System.Windows.Forms.TabControl tcAttachments;
        private System.Windows.Forms.TabPage tpAttorneys;
        private System.Windows.Forms.TabPage tpAgreements;
        private System.Windows.Forms.ToolStrip tsAttorneysOperations;
        private System.Windows.Forms.ToolStripButton btnAddAttachment;
        private System.Windows.Forms.ToolStripButton btnDeleteAttachment;
        private WMSOffice.Controls.Custom.ImageViewerControl ivcAgreements;
        private System.Windows.Forms.ToolStrip tsAgreementsOperations;
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.Label lblDebtorsForClone;
        private System.Windows.Forms.TextBox tbDebtorsForClone;
        private System.Windows.Forms.Button btnSelectDebtorsForClone;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox cmbAgreements;
        private System.Windows.Forms.Label lblAgreement;
        private System.Windows.Forms.TextBox tbAgreementFrom;
        private System.Windows.Forms.Label lblAgreementFrom;
        private System.Windows.Forms.TextBox tbAgreementTo;
        private System.Windows.Forms.Label lblAgreementTo;
        private System.Windows.Forms.BindingSource agreementsByVendorBindingSource;
        private WMSOffice.Data.WHTableAdapters.AgreementsByVendorTableAdapter agreementsByVendorTableAdapter;
    }
}