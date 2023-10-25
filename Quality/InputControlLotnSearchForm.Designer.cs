namespace WMSOffice.Dialogs.Quality
{
    partial class InputControlLotnSearchForm
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
            this.chbOnlyActual = new System.Windows.Forms.CheckBox();
            this.grbItem = new System.Windows.Forms.GroupBox();
            this.lblItemName = new System.Windows.Forms.Label();
            this.stbItem = new WMSOffice.Controls.SearchTextBox();
            this.chbItem = new System.Windows.Forms.CheckBox();
            this.grbLotNumber = new System.Windows.Forms.GroupBox();
            this.tbxLotNumber = new System.Windows.Forms.TextBox();
            this.chbLotNumber = new System.Windows.Forms.CheckBox();
            this.grbVendor = new System.Windows.Forms.GroupBox();
            this.lblVendorName = new System.Windows.Forms.Label();
            this.stbVendor = new WMSOffice.Controls.SearchTextBox();
            this.chbVendor = new System.Windows.Forms.CheckBox();
            this.grbManufacturer = new System.Windows.Forms.GroupBox();
            this.lblManufacturerName = new System.Windows.Forms.Label();
            this.stbManufacturer = new WMSOffice.Controls.SearchTextBox();
            this.chbManufacturer = new System.Windows.Forms.CheckBox();
            this.grbWorksheetStatuses = new System.Windows.Forms.GroupBox();
            this.chbWorksheetIncludeCertDataInput = new System.Windows.Forms.CheckBox();
            this.chbWorksheetIncludeNotAccepted = new System.Windows.Forms.CheckBox();
            this.chbWorksheetIncludeAccepted = new System.Windows.Forms.CheckBox();
            this.chbWorksheetIncludeInWork = new System.Windows.Forms.CheckBox();
            this.chbWorksheetIncludeNew = new System.Windows.Forms.CheckBox();
            this.grbOrderDate = new System.Windows.Forms.GroupBox();
            this.dtpOrderDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDateTo = new System.Windows.Forms.Label();
            this.dtpOrderDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblOrderDateFrom = new System.Windows.Forms.Label();
            this.chbOrderDate = new System.Windows.Forms.CheckBox();
            this.grbProvisor = new System.Windows.Forms.GroupBox();
            this.cmbProvisors = new System.Windows.Forms.ComboBox();
            this.bsApGetProvisors = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.chbProvisor = new System.Windows.Forms.CheckBox();
            this.taApGetProvisors = new WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter();
            this.grbWorksheetDate = new System.Windows.Forms.GroupBox();
            this.dtpWorksheetDateTo = new System.Windows.Forms.DateTimePicker();
            this.lblWorksheetDateTo = new System.Windows.Forms.Label();
            this.dtpWorksheetDateFrom = new System.Windows.Forms.DateTimePicker();
            this.lblWorksheetDateFrom = new System.Windows.Forms.Label();
            this.chbWorksheetDate = new System.Windows.Forms.CheckBox();
            this.grbOrder = new System.Windows.Forms.GroupBox();
            this.tbxOrderID = new System.Windows.Forms.TextBox();
            this.chbOrderID = new System.Windows.Forms.CheckBox();
            this.grbItem.SuspendLayout();
            this.grbLotNumber.SuspendLayout();
            this.grbVendor.SuspendLayout();
            this.grbManufacturer.SuspendLayout();
            this.grbWorksheetStatuses.SuspendLayout();
            this.grbOrderDate.SuspendLayout();
            this.grbProvisor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApGetProvisors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.grbWorksheetDate.SuspendLayout();
            this.grbOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(347, 690);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(266, 690);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chbOnlyActual
            // 
            this.chbOnlyActual.AutoSize = true;
            this.chbOnlyActual.Checked = true;
            this.chbOnlyActual.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOnlyActual.Location = new System.Drawing.Point(18, 12);
            this.chbOnlyActual.Name = "chbOnlyActual";
            this.chbOnlyActual.Size = new System.Drawing.Size(222, 17);
            this.chbOnlyActual.TabIndex = 0;
            this.chbOnlyActual.Text = "Только актуальные версии документа";
            this.chbOnlyActual.UseVisualStyleBackColor = true;
            // 
            // grbItem
            // 
            this.grbItem.Controls.Add(this.lblItemName);
            this.grbItem.Controls.Add(this.stbItem);
            this.grbItem.Controls.Add(this.chbItem);
            this.grbItem.Location = new System.Drawing.Point(12, 35);
            this.grbItem.Name = "grbItem";
            this.grbItem.Size = new System.Drawing.Size(409, 67);
            this.grbItem.TabIndex = 1;
            this.grbItem.TabStop = false;
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblItemName.Location = new System.Drawing.Point(164, 42);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(91, 13);
            this.lblItemName.TabIndex = 2;
            this.lblItemName.Text = "Название товара";
            // 
            // stbItem
            // 
            this.stbItem.Location = new System.Drawing.Point(167, 16);
            this.stbItem.Name = "stbItem";
            this.stbItem.NavigateByValue = false;
            this.stbItem.ReadOnly = false;
            this.stbItem.Size = new System.Drawing.Size(159, 23);
            this.stbItem.TabIndex = 1;
            this.stbItem.UserID = ((long)(0));
            this.stbItem.Value = null;
            this.stbItem.ValueReferenceQuery = null;
            // 
            // chbItem
            // 
            this.chbItem.AutoSize = true;
            this.chbItem.Location = new System.Drawing.Point(6, 22);
            this.chbItem.Name = "chbItem";
            this.chbItem.Size = new System.Drawing.Size(110, 17);
            this.chbItem.TabIndex = 0;
            this.chbItem.Text = "Поиск по товару";
            this.chbItem.UseVisualStyleBackColor = true;
            this.chbItem.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbLotNumber
            // 
            this.grbLotNumber.Controls.Add(this.tbxLotNumber);
            this.grbLotNumber.Controls.Add(this.chbLotNumber);
            this.grbLotNumber.Location = new System.Drawing.Point(12, 108);
            this.grbLotNumber.Name = "grbLotNumber";
            this.grbLotNumber.Size = new System.Drawing.Size(409, 52);
            this.grbLotNumber.TabIndex = 2;
            this.grbLotNumber.TabStop = false;
            // 
            // tbxLotNumber
            // 
            this.tbxLotNumber.Location = new System.Drawing.Point(167, 20);
            this.tbxLotNumber.Name = "tbxLotNumber";
            this.tbxLotNumber.Size = new System.Drawing.Size(159, 20);
            this.tbxLotNumber.TabIndex = 1;
            // 
            // chbLotNumber
            // 
            this.chbLotNumber.AutoSize = true;
            this.chbLotNumber.Location = new System.Drawing.Point(6, 22);
            this.chbLotNumber.Name = "chbLotNumber";
            this.chbLotNumber.Size = new System.Drawing.Size(111, 17);
            this.chbLotNumber.TabIndex = 0;
            this.chbLotNumber.Text = "Поиск по партии";
            this.chbLotNumber.UseVisualStyleBackColor = true;
            this.chbLotNumber.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbVendor
            // 
            this.grbVendor.Controls.Add(this.lblVendorName);
            this.grbVendor.Controls.Add(this.stbVendor);
            this.grbVendor.Controls.Add(this.chbVendor);
            this.grbVendor.Location = new System.Drawing.Point(12, 166);
            this.grbVendor.Name = "grbVendor";
            this.grbVendor.Size = new System.Drawing.Size(409, 65);
            this.grbVendor.TabIndex = 3;
            this.grbVendor.TabStop = false;
            // 
            // lblVendorName
            // 
            this.lblVendorName.AutoSize = true;
            this.lblVendorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVendorName.Location = new System.Drawing.Point(164, 42);
            this.lblVendorName.Name = "lblVendorName";
            this.lblVendorName.Size = new System.Drawing.Size(115, 13);
            this.lblVendorName.TabIndex = 2;
            this.lblVendorName.Text = "Название поставщика";
            // 
            // stbVendor
            // 
            this.stbVendor.Location = new System.Drawing.Point(167, 16);
            this.stbVendor.Name = "stbVendor";
            this.stbVendor.NavigateByValue = false;
            this.stbVendor.ReadOnly = false;
            this.stbVendor.Size = new System.Drawing.Size(159, 23);
            this.stbVendor.TabIndex = 1;
            this.stbVendor.UserID = ((long)(0));
            this.stbVendor.Value = null;
            this.stbVendor.ValueReferenceQuery = null;
            // 
            // chbVendor
            // 
            this.chbVendor.AutoSize = true;
            this.chbVendor.Location = new System.Drawing.Point(6, 22);
            this.chbVendor.Name = "chbVendor";
            this.chbVendor.Size = new System.Drawing.Size(137, 17);
            this.chbVendor.TabIndex = 0;
            this.chbVendor.Text = "Поиск по поставщику";
            this.chbVendor.UseVisualStyleBackColor = true;
            this.chbVendor.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbManufacturer
            // 
            this.grbManufacturer.Controls.Add(this.lblManufacturerName);
            this.grbManufacturer.Controls.Add(this.stbManufacturer);
            this.grbManufacturer.Controls.Add(this.chbManufacturer);
            this.grbManufacturer.Location = new System.Drawing.Point(12, 237);
            this.grbManufacturer.Name = "grbManufacturer";
            this.grbManufacturer.Size = new System.Drawing.Size(409, 65);
            this.grbManufacturer.TabIndex = 4;
            this.grbManufacturer.TabStop = false;
            // 
            // lblManufacturerName
            // 
            this.lblManufacturerName.AutoSize = true;
            this.lblManufacturerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblManufacturerName.Location = new System.Drawing.Point(164, 42);
            this.lblManufacturerName.Name = "lblManufacturerName";
            this.lblManufacturerName.Size = new System.Drawing.Size(115, 13);
            this.lblManufacturerName.TabIndex = 2;
            this.lblManufacturerName.Text = "Название поставщика";
            // 
            // stbManufacturer
            // 
            this.stbManufacturer.Location = new System.Drawing.Point(167, 16);
            this.stbManufacturer.Name = "stbManufacturer";
            this.stbManufacturer.NavigateByValue = false;
            this.stbManufacturer.ReadOnly = false;
            this.stbManufacturer.Size = new System.Drawing.Size(159, 23);
            this.stbManufacturer.TabIndex = 1;
            this.stbManufacturer.UserID = ((long)(0));
            this.stbManufacturer.Value = null;
            this.stbManufacturer.ValueReferenceQuery = null;
            // 
            // chbManufacturer
            // 
            this.chbManufacturer.AutoSize = true;
            this.chbManufacturer.Location = new System.Drawing.Point(6, 22);
            this.chbManufacturer.Name = "chbManufacturer";
            this.chbManufacturer.Size = new System.Drawing.Size(155, 17);
            this.chbManufacturer.TabIndex = 0;
            this.chbManufacturer.Text = "Поиск по производителю";
            this.chbManufacturer.UseVisualStyleBackColor = true;
            this.chbManufacturer.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbWorksheetStatuses
            // 
            this.grbWorksheetStatuses.Controls.Add(this.chbWorksheetIncludeCertDataInput);
            this.grbWorksheetStatuses.Controls.Add(this.chbWorksheetIncludeNotAccepted);
            this.grbWorksheetStatuses.Controls.Add(this.chbWorksheetIncludeAccepted);
            this.grbWorksheetStatuses.Controls.Add(this.chbWorksheetIncludeInWork);
            this.grbWorksheetStatuses.Controls.Add(this.chbWorksheetIncludeNew);
            this.grbWorksheetStatuses.Location = new System.Drawing.Point(13, 366);
            this.grbWorksheetStatuses.Name = "grbWorksheetStatuses";
            this.grbWorksheetStatuses.Size = new System.Drawing.Size(409, 96);
            this.grbWorksheetStatuses.TabIndex = 6;
            this.grbWorksheetStatuses.TabStop = false;
            this.grbWorksheetStatuses.Text = "Статусы анкет";
            // 
            // chbWorksheetIncludeCertDataInput
            // 
            this.chbWorksheetIncludeCertDataInput.AutoSize = true;
            this.chbWorksheetIncludeCertDataInput.Location = new System.Drawing.Point(5, 69);
            this.chbWorksheetIncludeCertDataInput.Name = "chbWorksheetIncludeCertDataInput";
            this.chbWorksheetIncludeCertDataInput.Size = new System.Drawing.Size(160, 17);
            this.chbWorksheetIncludeCertDataInput.TabIndex = 4;
            this.chbWorksheetIncludeCertDataInput.Text = "Ввод данных сертификата";
            this.chbWorksheetIncludeCertDataInput.UseVisualStyleBackColor = true;
            // 
            // chbWorksheetIncludeNotAccepted
            // 
            this.chbWorksheetIncludeNotAccepted.AutoSize = true;
            this.chbWorksheetIncludeNotAccepted.Location = new System.Drawing.Point(172, 44);
            this.chbWorksheetIncludeNotAccepted.Name = "chbWorksheetIncludeNotAccepted";
            this.chbWorksheetIncludeNotAccepted.Size = new System.Drawing.Size(134, 17);
            this.chbWorksheetIncludeNotAccepted.TabIndex = 3;
            this.chbWorksheetIncludeNotAccepted.Text = "Контроль не пройден";
            this.chbWorksheetIncludeNotAccepted.UseVisualStyleBackColor = true;
            // 
            // chbWorksheetIncludeAccepted
            // 
            this.chbWorksheetIncludeAccepted.AutoSize = true;
            this.chbWorksheetIncludeAccepted.Location = new System.Drawing.Point(5, 44);
            this.chbWorksheetIncludeAccepted.Name = "chbWorksheetIncludeAccepted";
            this.chbWorksheetIncludeAccepted.Size = new System.Drawing.Size(119, 17);
            this.chbWorksheetIncludeAccepted.TabIndex = 2;
            this.chbWorksheetIncludeAccepted.Text = "Контроль пройден";
            this.chbWorksheetIncludeAccepted.UseVisualStyleBackColor = true;
            // 
            // chbWorksheetIncludeInWork
            // 
            this.chbWorksheetIncludeInWork.AutoSize = true;
            this.chbWorksheetIncludeInWork.Checked = true;
            this.chbWorksheetIncludeInWork.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbWorksheetIncludeInWork.Location = new System.Drawing.Point(172, 19);
            this.chbWorksheetIncludeInWork.Name = "chbWorksheetIncludeInWork";
            this.chbWorksheetIncludeInWork.Size = new System.Drawing.Size(71, 17);
            this.chbWorksheetIncludeInWork.TabIndex = 1;
            this.chbWorksheetIncludeInWork.Text = "В работе";
            this.chbWorksheetIncludeInWork.UseVisualStyleBackColor = true;
            // 
            // chbWorksheetIncludeNew
            // 
            this.chbWorksheetIncludeNew.AutoSize = true;
            this.chbWorksheetIncludeNew.Checked = true;
            this.chbWorksheetIncludeNew.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbWorksheetIncludeNew.Location = new System.Drawing.Point(5, 19);
            this.chbWorksheetIncludeNew.Name = "chbWorksheetIncludeNew";
            this.chbWorksheetIncludeNew.Size = new System.Drawing.Size(58, 17);
            this.chbWorksheetIncludeNew.TabIndex = 0;
            this.chbWorksheetIncludeNew.Text = "Новая";
            this.chbWorksheetIncludeNew.UseVisualStyleBackColor = true;
            // 
            // grbOrderDate
            // 
            this.grbOrderDate.Controls.Add(this.dtpOrderDateTo);
            this.grbOrderDate.Controls.Add(this.lblOrderDateTo);
            this.grbOrderDate.Controls.Add(this.dtpOrderDateFrom);
            this.grbOrderDate.Controls.Add(this.lblOrderDateFrom);
            this.grbOrderDate.Controls.Add(this.chbOrderDate);
            this.grbOrderDate.Location = new System.Drawing.Point(13, 468);
            this.grbOrderDate.Name = "grbOrderDate";
            this.grbOrderDate.Size = new System.Drawing.Size(409, 74);
            this.grbOrderDate.TabIndex = 7;
            this.grbOrderDate.TabStop = false;
            // 
            // dtpOrderDateTo
            // 
            this.dtpOrderDateTo.Location = new System.Drawing.Point(265, 43);
            this.dtpOrderDateTo.Name = "dtpOrderDateTo";
            this.dtpOrderDateTo.Size = new System.Drawing.Size(128, 20);
            this.dtpOrderDateTo.TabIndex = 4;
            // 
            // lblOrderDateTo
            // 
            this.lblOrderDateTo.AutoSize = true;
            this.lblOrderDateTo.Location = new System.Drawing.Point(211, 49);
            this.lblOrderDateTo.Name = "lblOrderDateTo";
            this.lblOrderDateTo.Size = new System.Drawing.Size(48, 13);
            this.lblOrderDateTo.TabIndex = 3;
            this.lblOrderDateTo.Text = "Дата по";
            // 
            // dtpOrderDateFrom
            // 
            this.dtpOrderDateFrom.Location = new System.Drawing.Point(54, 43);
            this.dtpOrderDateFrom.Name = "dtpOrderDateFrom";
            this.dtpOrderDateFrom.Size = new System.Drawing.Size(128, 20);
            this.dtpOrderDateFrom.TabIndex = 2;
            // 
            // lblOrderDateFrom
            // 
            this.lblOrderDateFrom.AutoSize = true;
            this.lblOrderDateFrom.Location = new System.Drawing.Point(6, 49);
            this.lblOrderDateFrom.Name = "lblOrderDateFrom";
            this.lblOrderDateFrom.Size = new System.Drawing.Size(42, 13);
            this.lblOrderDateFrom.TabIndex = 1;
            this.lblOrderDateFrom.Text = "Дата с";
            // 
            // chbOrderDate
            // 
            this.chbOrderDate.AutoSize = true;
            this.chbOrderDate.Location = new System.Drawing.Point(6, 19);
            this.chbOrderDate.Name = "chbOrderDate";
            this.chbOrderDate.Size = new System.Drawing.Size(212, 17);
            this.chbOrderDate.TabIndex = 0;
            this.chbOrderDate.Text = "Поиск по дате приходования заказа";
            this.chbOrderDate.UseVisualStyleBackColor = true;
            this.chbOrderDate.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbProvisor
            // 
            this.grbProvisor.Controls.Add(this.cmbProvisors);
            this.grbProvisor.Controls.Add(this.chbProvisor);
            this.grbProvisor.Location = new System.Drawing.Point(12, 628);
            this.grbProvisor.Name = "grbProvisor";
            this.grbProvisor.Size = new System.Drawing.Size(409, 52);
            this.grbProvisor.TabIndex = 9;
            this.grbProvisor.TabStop = false;
            // 
            // cmbProvisors
            // 
            this.cmbProvisors.DataSource = this.bsApGetProvisors;
            this.cmbProvisors.DisplayMember = "User_FIO";
            this.cmbProvisors.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProvisors.FormattingEnabled = true;
            this.cmbProvisors.Location = new System.Drawing.Point(124, 20);
            this.cmbProvisors.Name = "cmbProvisors";
            this.cmbProvisors.Size = new System.Drawing.Size(279, 21);
            this.cmbProvisors.TabIndex = 1;
            this.cmbProvisors.ValueMember = "User_ID";
            // 
            // bsApGetProvisors
            // 
            this.bsApGetProvisors.DataMember = "AP_Get_Provisors";
            this.bsApGetProvisors.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chbProvisor
            // 
            this.chbProvisor.AutoSize = true;
            this.chbProvisor.Location = new System.Drawing.Point(6, 22);
            this.chbProvisor.Name = "chbProvisor";
            this.chbProvisor.Size = new System.Drawing.Size(112, 17);
            this.chbProvisor.TabIndex = 0;
            this.chbProvisor.Text = "ФИО Провизора";
            this.chbProvisor.UseVisualStyleBackColor = true;
            this.chbProvisor.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // taApGetProvisors
            // 
            this.taApGetProvisors.ClearBeforeFill = true;
            // 
            // grbWorksheetDate
            // 
            this.grbWorksheetDate.Controls.Add(this.dtpWorksheetDateTo);
            this.grbWorksheetDate.Controls.Add(this.lblWorksheetDateTo);
            this.grbWorksheetDate.Controls.Add(this.dtpWorksheetDateFrom);
            this.grbWorksheetDate.Controls.Add(this.lblWorksheetDateFrom);
            this.grbWorksheetDate.Controls.Add(this.chbWorksheetDate);
            this.grbWorksheetDate.Location = new System.Drawing.Point(12, 548);
            this.grbWorksheetDate.Name = "grbWorksheetDate";
            this.grbWorksheetDate.Size = new System.Drawing.Size(409, 74);
            this.grbWorksheetDate.TabIndex = 8;
            this.grbWorksheetDate.TabStop = false;
            // 
            // dtpWorksheetDateTo
            // 
            this.dtpWorksheetDateTo.Location = new System.Drawing.Point(265, 43);
            this.dtpWorksheetDateTo.Name = "dtpWorksheetDateTo";
            this.dtpWorksheetDateTo.Size = new System.Drawing.Size(128, 20);
            this.dtpWorksheetDateTo.TabIndex = 4;
            // 
            // lblWorksheetDateTo
            // 
            this.lblWorksheetDateTo.AutoSize = true;
            this.lblWorksheetDateTo.Location = new System.Drawing.Point(211, 49);
            this.lblWorksheetDateTo.Name = "lblWorksheetDateTo";
            this.lblWorksheetDateTo.Size = new System.Drawing.Size(48, 13);
            this.lblWorksheetDateTo.TabIndex = 3;
            this.lblWorksheetDateTo.Text = "Дата по";
            // 
            // dtpWorksheetDateFrom
            // 
            this.dtpWorksheetDateFrom.Location = new System.Drawing.Point(54, 43);
            this.dtpWorksheetDateFrom.Name = "dtpWorksheetDateFrom";
            this.dtpWorksheetDateFrom.Size = new System.Drawing.Size(128, 20);
            this.dtpWorksheetDateFrom.TabIndex = 2;
            // 
            // lblWorksheetDateFrom
            // 
            this.lblWorksheetDateFrom.AutoSize = true;
            this.lblWorksheetDateFrom.Location = new System.Drawing.Point(6, 49);
            this.lblWorksheetDateFrom.Name = "lblWorksheetDateFrom";
            this.lblWorksheetDateFrom.Size = new System.Drawing.Size(42, 13);
            this.lblWorksheetDateFrom.TabIndex = 1;
            this.lblWorksheetDateFrom.Text = "Дата с";
            // 
            // chbWorksheetDate
            // 
            this.chbWorksheetDate.AutoSize = true;
            this.chbWorksheetDate.Location = new System.Drawing.Point(6, 19);
            this.chbWorksheetDate.Name = "chbWorksheetDate";
            this.chbWorksheetDate.Size = new System.Drawing.Size(225, 17);
            this.chbWorksheetDate.TabIndex = 0;
            this.chbWorksheetDate.Text = "Поиск по дате редактирования анкеты";
            this.chbWorksheetDate.UseVisualStyleBackColor = true;
            this.chbWorksheetDate.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // grbOrder
            // 
            this.grbOrder.Controls.Add(this.tbxOrderID);
            this.grbOrder.Controls.Add(this.chbOrderID);
            this.grbOrder.Location = new System.Drawing.Point(12, 308);
            this.grbOrder.Name = "grbOrder";
            this.grbOrder.Size = new System.Drawing.Size(409, 52);
            this.grbOrder.TabIndex = 5;
            this.grbOrder.TabStop = false;
            // 
            // tbOrder
            // 
            this.tbxOrderID.Location = new System.Drawing.Point(167, 20);
            this.tbxOrderID.Name = "tbOrder";
            this.tbxOrderID.Size = new System.Drawing.Size(159, 20);
            this.tbxOrderID.TabIndex = 1;
            // 
            // chbOrder
            // 
            this.chbOrderID.AutoSize = true;
            this.chbOrderID.Location = new System.Drawing.Point(6, 22);
            this.chbOrderID.Name = "chbOrder";
            this.chbOrderID.Size = new System.Drawing.Size(111, 17);
            this.chbOrderID.TabIndex = 0;
            this.chbOrderID.Text = "Поиск по заказу";
            this.chbOrderID.UseVisualStyleBackColor = true;
            this.chbOrderID.CheckedChanged += new System.EventHandler(this.chb_CheckedChanged);
            // 
            // InputControlLotnSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 725);
            this.Controls.Add(this.grbOrder);
            this.Controls.Add(this.grbWorksheetDate);
            this.Controls.Add(this.grbProvisor);
            this.Controls.Add(this.grbOrderDate);
            this.Controls.Add(this.grbWorksheetStatuses);
            this.Controls.Add(this.grbManufacturer);
            this.Controls.Add(this.grbVendor);
            this.Controls.Add(this.grbLotNumber);
            this.Controls.Add(this.grbItem);
            this.Controls.Add(this.chbOnlyActual);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputControlLotnSearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Поиск анкет входного контроля партии";
            this.Load += new System.EventHandler(this.InputControlLotnSearchForm_Load);
            this.grbItem.ResumeLayout(false);
            this.grbItem.PerformLayout();
            this.grbLotNumber.ResumeLayout(false);
            this.grbLotNumber.PerformLayout();
            this.grbVendor.ResumeLayout(false);
            this.grbVendor.PerformLayout();
            this.grbManufacturer.ResumeLayout(false);
            this.grbManufacturer.PerformLayout();
            this.grbWorksheetStatuses.ResumeLayout(false);
            this.grbWorksheetStatuses.PerformLayout();
            this.grbOrderDate.ResumeLayout(false);
            this.grbOrderDate.PerformLayout();
            this.grbProvisor.ResumeLayout(false);
            this.grbProvisor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApGetProvisors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.grbWorksheetDate.ResumeLayout(false);
            this.grbWorksheetDate.PerformLayout();
            this.grbOrder.ResumeLayout(false);
            this.grbOrder.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chbOnlyActual;
        private System.Windows.Forms.GroupBox grbItem;
        private System.Windows.Forms.Label lblItemName;
        private WMSOffice.Controls.SearchTextBox stbItem;
        private System.Windows.Forms.CheckBox chbItem;
        private System.Windows.Forms.GroupBox grbLotNumber;
        private System.Windows.Forms.TextBox tbxLotNumber;
        private System.Windows.Forms.CheckBox chbLotNumber;
        private System.Windows.Forms.GroupBox grbVendor;
        private System.Windows.Forms.Label lblVendorName;
        private WMSOffice.Controls.SearchTextBox stbVendor;
        private System.Windows.Forms.CheckBox chbVendor;
        private System.Windows.Forms.GroupBox grbManufacturer;
        private System.Windows.Forms.Label lblManufacturerName;
        private WMSOffice.Controls.SearchTextBox stbManufacturer;
        private System.Windows.Forms.CheckBox chbManufacturer;
        private System.Windows.Forms.GroupBox grbWorksheetStatuses;
        private System.Windows.Forms.CheckBox chbWorksheetIncludeNotAccepted;
        private System.Windows.Forms.CheckBox chbWorksheetIncludeAccepted;
        private System.Windows.Forms.CheckBox chbWorksheetIncludeInWork;
        private System.Windows.Forms.CheckBox chbWorksheetIncludeNew;
        private System.Windows.Forms.GroupBox grbOrderDate;
        private System.Windows.Forms.DateTimePicker dtpOrderDateTo;
        private System.Windows.Forms.Label lblOrderDateTo;
        private System.Windows.Forms.DateTimePicker dtpOrderDateFrom;
        private System.Windows.Forms.Label lblOrderDateFrom;
        private System.Windows.Forms.CheckBox chbOrderDate;
        private System.Windows.Forms.GroupBox grbProvisor;
        private System.Windows.Forms.ComboBox cmbProvisors;
        private System.Windows.Forms.CheckBox chbProvisor;
        private WMSOffice.Data.Quality quality;
        private System.Windows.Forms.BindingSource bsApGetProvisors;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_ProvisorsTableAdapter taApGetProvisors;
        private System.Windows.Forms.GroupBox grbWorksheetDate;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateTo;
        private System.Windows.Forms.Label lblWorksheetDateTo;
        private System.Windows.Forms.DateTimePicker dtpWorksheetDateFrom;
        private System.Windows.Forms.Label lblWorksheetDateFrom;
        private System.Windows.Forms.CheckBox chbWorksheetDate;
        private System.Windows.Forms.CheckBox chbWorksheetIncludeCertDataInput;
        private System.Windows.Forms.GroupBox grbOrder;
        private System.Windows.Forms.TextBox tbxOrderID;
        private System.Windows.Forms.CheckBox chbOrderID;
    }
}