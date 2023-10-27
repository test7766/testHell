namespace WMSOffice.Dialogs.Complaints
{
    partial class SearchComplaintOptionsForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.cbTypes = new System.Windows.Forms.ComboBox();
            this.availableDocsTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.complaints = new WMSOffice.Data.Complaints();
            this.gbID = new System.Windows.Forms.GroupBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.chkbType = new System.Windows.Forms.CheckBox();
            this.chkbID = new System.Windows.Forms.CheckBox();
            this.chkbDate = new System.Windows.Forms.CheckBox();
            this.gbDate = new System.Windows.Forms.GroupBox();
            this.dtpDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.dtpDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.availableDocsTypesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter();
            this.chkbManager = new System.Windows.Forms.CheckBox();
            this.gbManager = new System.Windows.Forms.GroupBox();
            this.cbManager = new System.Windows.Forms.ComboBox();
            this.availableManagersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblManager = new System.Windows.Forms.Label();
            this.availableManagersTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableManagersTableAdapter();
            this.chkbDebtor = new System.Windows.Forms.CheckBox();
            this.gbDebtor = new System.Windows.Forms.GroupBox();
            this.cbDebtor = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.availableSourceDebtorsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblDebtor = new System.Windows.Forms.Label();
            this.availableSourceDebtorsTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableSourceDebtorsTableAdapter();
            this.chkbCreator = new System.Windows.Forms.CheckBox();
            this.gbCreator = new System.Windows.Forms.GroupBox();
            this.cbCreator = new System.Windows.Forms.ComboBox();
            this.availableEmployeesCreatedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblCreator = new System.Windows.Forms.Label();
            this.availableEmployeesCreatedTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableEmployeesCreatedTableAdapter();
            this.chkbItemName = new System.Windows.Forms.CheckBox();
            this.gbItemName = new System.Windows.Forms.GroupBox();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.chkbLinkedOrderID = new System.Windows.Forms.CheckBox();
            this.gbLinkedOrderID = new System.Windows.Forms.GroupBox();
            this.tbLinkedOrderID = new System.Windows.Forms.TextBox();
            this.lblLinkedOrderID = new System.Windows.Forms.Label();
            this.tbxItemId = new System.Windows.Forms.TextBox();
            this.chbItemId = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbItemId = new System.Windows.Forms.GroupBox();
            this.chkbFaultEmployee = new System.Windows.Forms.CheckBox();
            this.gbFaultEmployee = new System.Windows.Forms.GroupBox();
            this.cbFaultEmployee = new System.Windows.Forms.ComboBox();
            this.availableFaultEmployeesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblFaultEmployee = new System.Windows.Forms.Label();
            this.availableFaultEmployeesTableAdapter = new WMSOffice.Data.ComplaintsTableAdapters.AvailableFaultEmployeesTableAdapter();
            this.chkbLinkedInvoiceID = new System.Windows.Forms.CheckBox();
            this.gbLinkedInvoiceID = new System.Windows.Forms.GroupBox();
            this.tbLinkedInvoiceID = new System.Windows.Forms.TextBox();
            this.lblLinkedInvoiceID = new System.Windows.Forms.Label();
            this.gbType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).BeginInit();
            this.gbID.SuspendLayout();
            this.gbDate.SuspendLayout();
            this.gbManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableManagersBindingSource)).BeginInit();
            this.gbDebtor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableSourceDebtorsBindingSource)).BeginInit();
            this.gbCreator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableEmployeesCreatedBindingSource)).BeginInit();
            this.gbItemName.SuspendLayout();
            this.gbLinkedOrderID.SuspendLayout();
            this.gbItemId.SuspendLayout();
            this.gbFaultEmployee.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableFaultEmployeesBindingSource)).BeginInit();
            this.gbLinkedInvoiceID.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(232, 625);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(151, 625);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(10, 22);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(85, 13);
            this.lblType.TabIndex = 2;
            this.lblType.Text = "Тип претензии:";
            // 
            // gbType
            // 
            this.gbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbType.Controls.Add(this.cbTypes);
            this.gbType.Controls.Add(this.lblType);
            this.gbType.Enabled = false;
            this.gbType.Location = new System.Drawing.Point(12, 12);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(295, 47);
            this.gbType.TabIndex = 7;
            this.gbType.TabStop = false;
            // 
            // cbTypes
            // 
            this.cbTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTypes.DataSource = this.availableDocsTypesBindingSource;
            this.cbTypes.DisplayMember = "Doc_Type_Name";
            this.cbTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypes.FormattingEnabled = true;
            this.cbTypes.Location = new System.Drawing.Point(107, 17);
            this.cbTypes.MaxDropDownItems = 20;
            this.cbTypes.Name = "cbTypes";
            this.cbTypes.Size = new System.Drawing.Size(182, 21);
            this.cbTypes.TabIndex = 3;
            this.cbTypes.ValueMember = "Doc_Type";
            // 
            // availableDocsTypesBindingSource
            // 
            this.availableDocsTypesBindingSource.DataMember = "AvailableDocsTypes";
            this.availableDocsTypesBindingSource.DataSource = this.complaints;
            // 
            // complaints
            // 
            this.complaints.DataSetName = "Complaints";
            this.complaints.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gbID
            // 
            this.gbID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbID.Controls.Add(this.tbID);
            this.gbID.Controls.Add(this.lblID);
            this.gbID.Enabled = false;
            this.gbID.Location = new System.Drawing.Point(12, 65);
            this.gbID.Name = "gbID";
            this.gbID.Size = new System.Drawing.Size(295, 47);
            this.gbID.TabIndex = 8;
            this.gbID.TabStop = false;
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(93, 19);
            this.tbID.MaxLength = 12;
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(86, 20);
            this.tbID.TabIndex = 3;
            this.tbID.Text = "0";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(10, 22);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(77, 13);
            this.lblID.TabIndex = 2;
            this.lblID.Text = "№ претензии:";
            // 
            // chkbType
            // 
            this.chkbType.AutoSize = true;
            this.chkbType.Location = new System.Drawing.Point(20, 10);
            this.chkbType.Name = "chkbType";
            this.chkbType.Size = new System.Drawing.Size(101, 17);
            this.chkbType.TabIndex = 12;
            this.chkbType.Text = "Тип претензии";
            this.chkbType.UseVisualStyleBackColor = true;
            this.chkbType.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // chkbID
            // 
            this.chkbID.AutoSize = true;
            this.chkbID.Location = new System.Drawing.Point(20, 65);
            this.chkbID.Name = "chkbID";
            this.chkbID.Size = new System.Drawing.Size(143, 17);
            this.chkbID.TabIndex = 13;
            this.chkbID.Text = "Номер (код) претензии";
            this.chkbID.UseVisualStyleBackColor = true;
            this.chkbID.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // chkbDate
            // 
            this.chkbDate.AutoSize = true;
            this.chkbDate.Location = new System.Drawing.Point(20, 437);
            this.chkbDate.Name = "chkbDate";
            this.chkbDate.Size = new System.Drawing.Size(159, 17);
            this.chkbDate.TabIndex = 15;
            this.chkbDate.Text = "Дата создания претензии";
            this.chkbDate.UseVisualStyleBackColor = true;
            this.chkbDate.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbDate
            // 
            this.gbDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDate.Controls.Add(this.dtpDateTo);
            this.gbDate.Controls.Add(this.lblDateTo);
            this.gbDate.Controls.Add(this.dtpDateFrom);
            this.gbDate.Controls.Add(this.lblDateFrom);
            this.gbDate.Enabled = false;
            this.gbDate.Location = new System.Drawing.Point(12, 437);
            this.gbDate.Name = "gbDate";
            this.gbDate.Size = new System.Drawing.Size(295, 74);
            this.gbDate.TabIndex = 14;
            this.gbDate.TabStop = false;
            // 
            // dtpDateTo
            // 
            this.dtpDateTo.Location = new System.Drawing.Point(66, 45);
            this.dtpDateTo.Name = "dtpDateTo";
            this.dtpDateTo.Size = new System.Drawing.Size(161, 20);
            this.dtpDateTo.TabIndex = 5;
            // 
            // lblDateTo
            // 
            this.lblDateTo.AutoSize = true;
            this.lblDateTo.Location = new System.Drawing.Point(10, 48);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(51, 13);
            this.lblDateTo.TabIndex = 4;
            this.lblDateTo.Text = "Дата по:";
            // 
            // dtpDateFrom
            // 
            this.dtpDateFrom.Location = new System.Drawing.Point(66, 19);
            this.dtpDateFrom.Name = "dtpDateFrom";
            this.dtpDateFrom.Size = new System.Drawing.Size(161, 20);
            this.dtpDateFrom.TabIndex = 3;
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.AutoSize = true;
            this.lblDateFrom.Location = new System.Drawing.Point(10, 22);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(45, 13);
            this.lblDateFrom.TabIndex = 2;
            this.lblDateFrom.Text = "Дата с:";
            // 
            // availableDocsTypesTableAdapter
            // 
            this.availableDocsTypesTableAdapter.ClearBeforeFill = true;
            // 
            // chkbManager
            // 
            this.chkbManager.AutoSize = true;
            this.chkbManager.Location = new System.Drawing.Point(20, 223);
            this.chkbManager.Name = "chkbManager";
            this.chkbManager.Size = new System.Drawing.Size(283, 17);
            this.chkbManager.TabIndex = 17;
            this.chkbManager.Text = "Менеджер, закрепленный за адресом инициатора";
            this.chkbManager.UseVisualStyleBackColor = true;
            this.chkbManager.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbManager
            // 
            this.gbManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbManager.Controls.Add(this.cbManager);
            this.gbManager.Controls.Add(this.lblManager);
            this.gbManager.Enabled = false;
            this.gbManager.Location = new System.Drawing.Point(12, 225);
            this.gbManager.Name = "gbManager";
            this.gbManager.Size = new System.Drawing.Size(295, 47);
            this.gbManager.TabIndex = 16;
            this.gbManager.TabStop = false;
            // 
            // cbManager
            // 
            this.cbManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbManager.DataSource = this.availableManagersBindingSource;
            this.cbManager.DisplayMember = "Manager_Name";
            this.cbManager.Location = new System.Drawing.Point(74, 16);
            this.cbManager.MaxDropDownItems = 24;
            this.cbManager.Name = "cbManager";
            this.cbManager.Size = new System.Drawing.Size(215, 21);
            this.cbManager.TabIndex = 3;
            this.cbManager.ValueMember = "Manager_ID";
            // 
            // availableManagersBindingSource
            // 
            this.availableManagersBindingSource.DataMember = "AvailableManagers";
            this.availableManagersBindingSource.DataSource = this.complaints;
            // 
            // lblManager
            // 
            this.lblManager.AutoSize = true;
            this.lblManager.Location = new System.Drawing.Point(10, 22);
            this.lblManager.Name = "lblManager";
            this.lblManager.Size = new System.Drawing.Size(63, 13);
            this.lblManager.TabIndex = 2;
            this.lblManager.Text = "Менеджер:";
            // 
            // availableManagersTableAdapter
            // 
            this.availableManagersTableAdapter.ClearBeforeFill = true;
            // 
            // chkbDebtor
            // 
            this.chkbDebtor.AutoSize = true;
            this.chkbDebtor.Location = new System.Drawing.Point(20, 276);
            this.chkbDebtor.Name = "chkbDebtor";
            this.chkbDebtor.Size = new System.Drawing.Size(235, 17);
            this.chkbDebtor.TabIndex = 19;
            this.chkbDebtor.Text = "Основной дебитор по адресу инициатора";
            this.chkbDebtor.UseVisualStyleBackColor = true;
            this.chkbDebtor.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbDebtor
            // 
            this.gbDebtor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDebtor.Controls.Add(this.cbDebtor);
            this.gbDebtor.Controls.Add(this.lblDebtor);
            this.gbDebtor.Enabled = false;
            this.gbDebtor.Location = new System.Drawing.Point(12, 278);
            this.gbDebtor.Name = "gbDebtor";
            this.gbDebtor.Size = new System.Drawing.Size(295, 47);
            this.gbDebtor.TabIndex = 18;
            this.gbDebtor.TabStop = false;
            // 
            // cbDebtor
            // 
            this.cbDebtor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDebtor.DataSource = this.availableSourceDebtorsBindingSource;
            this.cbDebtor.DisplayMember = "Debtor_Name";
            this.cbDebtor.FormattingEnabled = true;
            this.cbDebtor.Location = new System.Drawing.Point(74, 16);
            this.cbDebtor.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.cbDebtor.Name = "cbDebtor";
            this.cbDebtor.Size = new System.Drawing.Size(215, 21);
            this.cbDebtor.TabIndex = 102;
            this.cbDebtor.ValueMember = "Debtor_ID";
            // 
            // availableSourceDebtorsBindingSource
            // 
            this.availableSourceDebtorsBindingSource.DataMember = "AvailableSourceDebtors";
            this.availableSourceDebtorsBindingSource.DataSource = this.complaints;
            // 
            // lblDebtor
            // 
            this.lblDebtor.AutoSize = true;
            this.lblDebtor.Location = new System.Drawing.Point(10, 22);
            this.lblDebtor.Name = "lblDebtor";
            this.lblDebtor.Size = new System.Drawing.Size(54, 13);
            this.lblDebtor.TabIndex = 2;
            this.lblDebtor.Text = "Дебитор:";
            // 
            // availableSourceDebtorsTableAdapter
            // 
            this.availableSourceDebtorsTableAdapter.ClearBeforeFill = true;
            // 
            // chkbCreator
            // 
            this.chkbCreator.AutoSize = true;
            this.chkbCreator.Location = new System.Drawing.Point(20, 329);
            this.chkbCreator.Name = "chkbCreator";
            this.chkbCreator.Size = new System.Drawing.Size(199, 17);
            this.chkbCreator.TabIndex = 21;
            this.chkbCreator.Text = "Сотрудник, создавший претензию";
            this.chkbCreator.UseVisualStyleBackColor = true;
            this.chkbCreator.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbCreator
            // 
            this.gbCreator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCreator.Controls.Add(this.cbCreator);
            this.gbCreator.Controls.Add(this.lblCreator);
            this.gbCreator.Enabled = false;
            this.gbCreator.Location = new System.Drawing.Point(12, 331);
            this.gbCreator.Name = "gbCreator";
            this.gbCreator.Size = new System.Drawing.Size(295, 47);
            this.gbCreator.TabIndex = 20;
            this.gbCreator.TabStop = false;
            // 
            // cbCreator
            // 
            this.cbCreator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbCreator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbCreator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbCreator.DataSource = this.availableEmployeesCreatedBindingSource;
            this.cbCreator.DisplayMember = "Employee_Name";
            this.cbCreator.Location = new System.Drawing.Point(74, 16);
            this.cbCreator.MaxDropDownItems = 24;
            this.cbCreator.Name = "cbCreator";
            this.cbCreator.Size = new System.Drawing.Size(215, 21);
            this.cbCreator.TabIndex = 3;
            this.cbCreator.ValueMember = "Employee_ID";
            // 
            // availableEmployeesCreatedBindingSource
            // 
            this.availableEmployeesCreatedBindingSource.DataMember = "AvailableEmployeesCreated";
            this.availableEmployeesCreatedBindingSource.DataSource = this.complaints;
            // 
            // lblCreator
            // 
            this.lblCreator.AutoSize = true;
            this.lblCreator.Location = new System.Drawing.Point(10, 22);
            this.lblCreator.Name = "lblCreator";
            this.lblCreator.Size = new System.Drawing.Size(63, 13);
            this.lblCreator.TabIndex = 2;
            this.lblCreator.Text = "Сотрудник:";
            // 
            // availableEmployeesCreatedTableAdapter
            // 
            this.availableEmployeesCreatedTableAdapter.ClearBeforeFill = true;
            // 
            // chkbItemName
            // 
            this.chkbItemName.AutoSize = true;
            this.chkbItemName.Location = new System.Drawing.Point(20, 517);
            this.chkbItemName.Name = "chkbItemName";
            this.chkbItemName.Size = new System.Drawing.Size(254, 17);
            this.chkbItemName.TabIndex = 23;
            this.chkbItemName.Text = "Товар в составе претензии (часть названия)";
            this.chkbItemName.UseVisualStyleBackColor = true;
            this.chkbItemName.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbItemName
            // 
            this.gbItemName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItemName.Controls.Add(this.tbItemName);
            this.gbItemName.Controls.Add(this.lblItemName);
            this.gbItemName.Enabled = false;
            this.gbItemName.Location = new System.Drawing.Point(12, 517);
            this.gbItemName.Name = "gbItemName";
            this.gbItemName.Size = new System.Drawing.Size(295, 47);
            this.gbItemName.TabIndex = 22;
            this.gbItemName.TabStop = false;
            // 
            // tbItemName
            // 
            this.tbItemName.Location = new System.Drawing.Point(57, 19);
            this.tbItemName.MaxLength = 30;
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(170, 20);
            this.tbItemName.TabIndex = 3;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(10, 22);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(41, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Товар:";
            // 
            // chkbLinkedOrderID
            // 
            this.chkbLinkedOrderID.AutoSize = true;
            this.chkbLinkedOrderID.Location = new System.Drawing.Point(20, 118);
            this.chkbLinkedOrderID.Name = "chkbLinkedOrderID";
            this.chkbLinkedOrderID.Size = new System.Drawing.Size(268, 17);
            this.chkbLinkedOrderID.TabIndex = 25;
            this.chkbLinkedOrderID.Text = "Номер (код) заказа, по кот. создана претензия";
            this.chkbLinkedOrderID.UseVisualStyleBackColor = true;
            this.chkbLinkedOrderID.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbLinkedOrderID
            // 
            this.gbLinkedOrderID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLinkedOrderID.Controls.Add(this.tbLinkedOrderID);
            this.gbLinkedOrderID.Controls.Add(this.lblLinkedOrderID);
            this.gbLinkedOrderID.Enabled = false;
            this.gbLinkedOrderID.Location = new System.Drawing.Point(12, 118);
            this.gbLinkedOrderID.Name = "gbLinkedOrderID";
            this.gbLinkedOrderID.Size = new System.Drawing.Size(295, 47);
            this.gbLinkedOrderID.TabIndex = 24;
            this.gbLinkedOrderID.TabStop = false;
            // 
            // tbLinkedOrderID
            // 
            this.tbLinkedOrderID.Location = new System.Drawing.Point(93, 19);
            this.tbLinkedOrderID.MaxLength = 12;
            this.tbLinkedOrderID.Name = "tbLinkedOrderID";
            this.tbLinkedOrderID.Size = new System.Drawing.Size(86, 20);
            this.tbLinkedOrderID.TabIndex = 3;
            this.tbLinkedOrderID.Text = "0";
            // 
            // lblLinkedOrderID
            // 
            this.lblLinkedOrderID.AutoSize = true;
            this.lblLinkedOrderID.Location = new System.Drawing.Point(10, 22);
            this.lblLinkedOrderID.Name = "lblLinkedOrderID";
            this.lblLinkedOrderID.Size = new System.Drawing.Size(60, 13);
            this.lblLinkedOrderID.TabIndex = 2;
            this.lblLinkedOrderID.Text = "№ заказа:";
            // 
            // tbxItemId
            // 
            this.tbxItemId.Location = new System.Drawing.Point(93, 19);
            this.tbxItemId.MaxLength = 12;
            this.tbxItemId.Name = "tbxItemId";
            this.tbxItemId.Size = new System.Drawing.Size(86, 20);
            this.tbxItemId.TabIndex = 3;
            this.tbxItemId.Text = "0";
            // 
            // chbItemId
            // 
            this.chbItemId.AutoSize = true;
            this.chbItemId.Location = new System.Drawing.Point(20, 570);
            this.chbItemId.Name = "chbItemId";
            this.chbItemId.Size = new System.Drawing.Size(192, 17);
            this.chbItemId.TabIndex = 27;
            this.chbItemId.Text = "Код товара в составе претензии";
            this.chbItemId.UseVisualStyleBackColor = true;
            this.chbItemId.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Код:";
            // 
            // gbItemId
            // 
            this.gbItemId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItemId.Controls.Add(this.tbxItemId);
            this.gbItemId.Controls.Add(this.label1);
            this.gbItemId.Enabled = false;
            this.gbItemId.Location = new System.Drawing.Point(12, 570);
            this.gbItemId.Name = "gbItemId";
            this.gbItemId.Size = new System.Drawing.Size(295, 47);
            this.gbItemId.TabIndex = 26;
            this.gbItemId.TabStop = false;
            // 
            // chkbFaultEmployee
            // 
            this.chkbFaultEmployee.AutoSize = true;
            this.chkbFaultEmployee.Location = new System.Drawing.Point(20, 382);
            this.chkbFaultEmployee.Name = "chkbFaultEmployee";
            this.chkbFaultEmployee.Size = new System.Drawing.Size(132, 17);
            this.chkbFaultEmployee.TabIndex = 29;
            this.chkbFaultEmployee.Text = "Виновный сотрудник";
            this.chkbFaultEmployee.UseVisualStyleBackColor = true;
            this.chkbFaultEmployee.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbFaultEmployee
            // 
            this.gbFaultEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFaultEmployee.Controls.Add(this.cbFaultEmployee);
            this.gbFaultEmployee.Controls.Add(this.lblFaultEmployee);
            this.gbFaultEmployee.Enabled = false;
            this.gbFaultEmployee.Location = new System.Drawing.Point(12, 384);
            this.gbFaultEmployee.Name = "gbFaultEmployee";
            this.gbFaultEmployee.Size = new System.Drawing.Size(295, 47);
            this.gbFaultEmployee.TabIndex = 28;
            this.gbFaultEmployee.TabStop = false;
            // 
            // cbFaultEmployee
            // 
            this.cbFaultEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFaultEmployee.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbFaultEmployee.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbFaultEmployee.DataSource = this.availableFaultEmployeesBindingSource;
            this.cbFaultEmployee.DisplayMember = "Employee_Name";
            this.cbFaultEmployee.Location = new System.Drawing.Point(74, 16);
            this.cbFaultEmployee.MaxDropDownItems = 24;
            this.cbFaultEmployee.Name = "cbFaultEmployee";
            this.cbFaultEmployee.Size = new System.Drawing.Size(215, 21);
            this.cbFaultEmployee.TabIndex = 3;
            this.cbFaultEmployee.ValueMember = "Employee_ID";
            // 
            // availableFaultEmployeesBindingSource
            // 
            this.availableFaultEmployeesBindingSource.DataMember = "AvailableFaultEmployees";
            this.availableFaultEmployeesBindingSource.DataSource = this.complaints;
            // 
            // lblFaultEmployee
            // 
            this.lblFaultEmployee.AutoSize = true;
            this.lblFaultEmployee.Location = new System.Drawing.Point(10, 22);
            this.lblFaultEmployee.Name = "lblFaultEmployee";
            this.lblFaultEmployee.Size = new System.Drawing.Size(63, 13);
            this.lblFaultEmployee.TabIndex = 2;
            this.lblFaultEmployee.Text = "Сотрудник:";
            // 
            // availableFaultEmployeesTableAdapter
            // 
            this.availableFaultEmployeesTableAdapter.ClearBeforeFill = true;
            // 
            // chkbLinkedInvoiceID
            // 
            this.chkbLinkedInvoiceID.AutoSize = true;
            this.chkbLinkedInvoiceID.Location = new System.Drawing.Point(20, 171);
            this.chkbLinkedInvoiceID.Name = "chkbLinkedInvoiceID";
            this.chkbLinkedInvoiceID.Size = new System.Drawing.Size(144, 17);
            this.chkbLinkedInvoiceID.TabIndex = 31;
            this.chkbLinkedInvoiceID.Text = "Номер (код) накладной";
            this.chkbLinkedInvoiceID.UseVisualStyleBackColor = true;
            this.chkbLinkedInvoiceID.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // gbLinkedInvoiceID
            // 
            this.gbLinkedInvoiceID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLinkedInvoiceID.Controls.Add(this.tbLinkedInvoiceID);
            this.gbLinkedInvoiceID.Controls.Add(this.lblLinkedInvoiceID);
            this.gbLinkedInvoiceID.Enabled = false;
            this.gbLinkedInvoiceID.Location = new System.Drawing.Point(12, 171);
            this.gbLinkedInvoiceID.Name = "gbLinkedInvoiceID";
            this.gbLinkedInvoiceID.Size = new System.Drawing.Size(295, 47);
            this.gbLinkedInvoiceID.TabIndex = 30;
            this.gbLinkedInvoiceID.TabStop = false;
            // 
            // tbLinkedInvoiceID
            // 
            this.tbLinkedInvoiceID.Location = new System.Drawing.Point(93, 19);
            this.tbLinkedInvoiceID.MaxLength = 12;
            this.tbLinkedInvoiceID.Name = "tbLinkedInvoiceID";
            this.tbLinkedInvoiceID.Size = new System.Drawing.Size(86, 20);
            this.tbLinkedInvoiceID.TabIndex = 3;
            this.tbLinkedInvoiceID.Text = "0";
            // 
            // lblLinkedInvoiceID
            // 
            this.lblLinkedInvoiceID.AutoSize = true;
            this.lblLinkedInvoiceID.Location = new System.Drawing.Point(10, 22);
            this.lblLinkedInvoiceID.Name = "lblLinkedInvoiceID";
            this.lblLinkedInvoiceID.Size = new System.Drawing.Size(78, 13);
            this.lblLinkedInvoiceID.TabIndex = 2;
            this.lblLinkedInvoiceID.Text = "№ накладной:";
            // 
            // SearchComplaintOptionsForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(319, 660);
            this.Controls.Add(this.chkbLinkedInvoiceID);
            this.Controls.Add(this.gbLinkedInvoiceID);
            this.Controls.Add(this.chkbFaultEmployee);
            this.Controls.Add(this.gbFaultEmployee);
            this.Controls.Add(this.chbItemId);
            this.Controls.Add(this.chkbLinkedOrderID);
            this.Controls.Add(this.gbItemId);
            this.Controls.Add(this.gbLinkedOrderID);
            this.Controls.Add(this.chkbItemName);
            this.Controls.Add(this.gbItemName);
            this.Controls.Add(this.chkbCreator);
            this.Controls.Add(this.gbCreator);
            this.Controls.Add(this.chkbDebtor);
            this.Controls.Add(this.gbDebtor);
            this.Controls.Add(this.chkbManager);
            this.Controls.Add(this.gbManager);
            this.Controls.Add(this.chkbDate);
            this.Controls.Add(this.gbDate);
            this.Controls.Add(this.chkbID);
            this.Controls.Add(this.chkbType);
            this.Controls.Add(this.gbID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.gbType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchComplaintOptionsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры поиска";
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableDocsTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.complaints)).EndInit();
            this.gbID.ResumeLayout(false);
            this.gbID.PerformLayout();
            this.gbDate.ResumeLayout(false);
            this.gbDate.PerformLayout();
            this.gbManager.ResumeLayout(false);
            this.gbManager.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableManagersBindingSource)).EndInit();
            this.gbDebtor.ResumeLayout(false);
            this.gbDebtor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableSourceDebtorsBindingSource)).EndInit();
            this.gbCreator.ResumeLayout(false);
            this.gbCreator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableEmployeesCreatedBindingSource)).EndInit();
            this.gbItemName.ResumeLayout(false);
            this.gbItemName.PerformLayout();
            this.gbLinkedOrderID.ResumeLayout(false);
            this.gbLinkedOrderID.PerformLayout();
            this.gbItemId.ResumeLayout(false);
            this.gbItemId.PerformLayout();
            this.gbFaultEmployee.ResumeLayout(false);
            this.gbFaultEmployee.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.availableFaultEmployeesBindingSource)).EndInit();
            this.gbLinkedInvoiceID.ResumeLayout(false);
            this.gbLinkedInvoiceID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.GroupBox gbType;
        private System.Windows.Forms.ComboBox cbTypes;
        private System.Windows.Forms.GroupBox gbID;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.CheckBox chkbType;
        private System.Windows.Forms.CheckBox chkbID;
        private System.Windows.Forms.CheckBox chkbDate;
        private System.Windows.Forms.GroupBox gbDate;
        private System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.DateTimePicker dtpDateTo;
        private System.Windows.Forms.Label lblDateTo;
        private System.Windows.Forms.DateTimePicker dtpDateFrom;
        private WMSOffice.Data.Complaints complaints;
        private System.Windows.Forms.BindingSource availableDocsTypesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableDocsTypesTableAdapter availableDocsTypesTableAdapter;
        private System.Windows.Forms.CheckBox chkbManager;
        private System.Windows.Forms.GroupBox gbManager;
        private System.Windows.Forms.ComboBox cbManager;
        private System.Windows.Forms.Label lblManager;
        private System.Windows.Forms.BindingSource availableManagersBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableManagersTableAdapter availableManagersTableAdapter;
        private System.Windows.Forms.CheckBox chkbDebtor;
        private System.Windows.Forms.GroupBox gbDebtor;
        private System.Windows.Forms.Label lblDebtor;
        private System.Windows.Forms.BindingSource availableSourceDebtorsBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableSourceDebtorsTableAdapter availableSourceDebtorsTableAdapter;
        private System.Windows.Forms.CheckBox chkbCreator;
        private System.Windows.Forms.GroupBox gbCreator;
        private System.Windows.Forms.ComboBox cbCreator;
        private System.Windows.Forms.Label lblCreator;
        private System.Windows.Forms.BindingSource availableEmployeesCreatedBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableEmployeesCreatedTableAdapter availableEmployeesCreatedTableAdapter;
        private System.Windows.Forms.CheckBox chkbItemName;
        private System.Windows.Forms.GroupBox gbItemName;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label lblItemName;
        private System.Windows.Forms.CheckBox chkbLinkedOrderID;
        private System.Windows.Forms.GroupBox gbLinkedOrderID;
        private System.Windows.Forms.TextBox tbLinkedOrderID;
        private System.Windows.Forms.Label lblLinkedOrderID;
        private System.Windows.Forms.TextBox tbxItemId;
        private System.Windows.Forms.CheckBox chbItemId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbItemId;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox cbDebtor;
        private System.Windows.Forms.CheckBox chkbFaultEmployee;
        private System.Windows.Forms.GroupBox gbFaultEmployee;
        private System.Windows.Forms.ComboBox cbFaultEmployee;
        private System.Windows.Forms.Label lblFaultEmployee;
        private System.Windows.Forms.BindingSource availableFaultEmployeesBindingSource;
        private WMSOffice.Data.ComplaintsTableAdapters.AvailableFaultEmployeesTableAdapter availableFaultEmployeesTableAdapter;
        private System.Windows.Forms.CheckBox chkbLinkedInvoiceID;
        private System.Windows.Forms.GroupBox gbLinkedInvoiceID;
        private System.Windows.Forms.TextBox tbLinkedInvoiceID;
        private System.Windows.Forms.Label lblLinkedInvoiceID;
    }
}