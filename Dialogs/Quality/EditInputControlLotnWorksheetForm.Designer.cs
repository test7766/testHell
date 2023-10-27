namespace WMSOffice.Dialogs.Quality
{
    partial class EditInputControlLotnWorksheetForm
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
            this.lblOrderNumber = new System.Windows.Forms.Label();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblDocID = new System.Windows.Forms.Label();
            this.lblVersionID = new System.Windows.Forms.Label();
            this.lblVersionStatus = new System.Windows.Forms.Label();
            this.tbxDocID = new System.Windows.Forms.TextBox();
            this.tbxOrderID = new System.Windows.Forms.TextBox();
            this.tbxItemID = new System.Windows.Forms.TextBox();
            this.tbxVersionID = new System.Windows.Forms.TextBox();
            this.tbxVersionStatus = new System.Windows.Forms.TextBox();
            this.tbxUser = new System.Windows.Forms.TextBox();
            this.tbxVersionDate = new System.Windows.Forms.TextBox();
            this.tbxLotNumber = new System.Windows.Forms.TextBox();
            this.tbxVendor = new System.Windows.Forms.TextBox();
            this.tbxDocDate = new System.Windows.Forms.TextBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblVersionDate = new System.Windows.Forms.Label();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.lblLotNumber = new System.Windows.Forms.Label();
            this.lblVendor = new System.Windows.Forms.Label();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.clQuestionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clAnswer1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clAnswer2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clAnswer3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clAnswer4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clInvoiceInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clResult = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsAtDocVersionQuestions = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblQuestionsHeader = new System.Windows.Forms.Label();
            this.lblCurrentDate = new System.Windows.Forms.Label();
            this.tbxCurrentDate = new System.Windows.Forms.TextBox();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.tbxCurrentUser = new System.Windows.Forms.TextBox();
            this.grbParams = new System.Windows.Forms.GroupBox();
            this.btnShowExpirationDatesDifference = new System.Windows.Forms.Button();
            this.lblTemperatureStorageMode = new System.Windows.Forms.Label();
            this.ecmbTemperatureStorageMode = new WMSOffice.Controls.ExtraComboBox.ExtraComboBox();
            this.aTTemperatureStorageModeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnScan = new System.Windows.Forms.Button();
            this.tbLot_Qty = new System.Windows.Forms.TextBox();
            this.lblLot_Qty = new System.Windows.Forms.Label();
            this.btnAddTaskDirectum = new System.Windows.Forms.Button();
            this.cbHasCertificate = new System.Windows.Forms.CheckBox();
            this.tbxCertDate = new System.Windows.Forms.TextBox();
            this.btnEditData = new System.Windows.Forms.Button();
            this.dtpExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpirationDate = new System.Windows.Forms.Label();
            this.tbxVendorLot = new System.Windows.Forms.TextBox();
            this.lblVendorLot = new System.Windows.Forms.Label();
            this.dtpCertDate = new System.Windows.Forms.DateTimePicker();
            this.lblCertDate = new System.Windows.Forms.Label();
            this.tbxCertNumber = new System.Windows.Forms.TextBox();
            this.lblCertNumber = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taAtDocVersionQuestions = new WMSOffice.Data.QualityTableAdapters.AT_Doc_Version_QuestionsTableAdapter();
            this.aT_TemperatureStorageModeTableAdapter = new WMSOffice.Data.QualityTableAdapters.AT_TemperatureStorageModeTableAdapter();
            this.lblLotnManufacturer = new System.Windows.Forms.Label();
            this.cmbLotnManufacturer = new System.Windows.Forms.ComboBox();
            this.aTLotnManufacturersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aT_Lotn_ManufacturersTableAdapter = new WMSOffice.Data.QualityTableAdapters.AT_Lotn_ManufacturersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtDocVersionQuestions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            this.grbParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aTTemperatureStorageModeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTLotnManufacturersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(999, 520);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 90;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(918, 520);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 80;
            this.btnOK.Text = "ОК";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblOrderNumber
            // 
            this.lblOrderNumber.AutoSize = true;
            this.lblOrderNumber.Location = new System.Drawing.Point(12, 9);
            this.lblOrderNumber.Name = "lblOrderNumber";
            this.lblOrderNumber.Size = new System.Drawing.Size(83, 13);
            this.lblOrderNumber.TabIndex = 2;
            this.lblOrderNumber.Text = "Номер заказа:";
            // 
            // lblItemID
            // 
            this.lblItemID.AutoSize = true;
            this.lblItemID.Location = new System.Drawing.Point(12, 32);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(67, 13);
            this.lblItemID.TabIndex = 3;
            this.lblItemID.Text = "Код товара:";
            // 
            // lblDocID
            // 
            this.lblDocID.AutoSize = true;
            this.lblDocID.Location = new System.Drawing.Point(12, 55);
            this.lblDocID.Name = "lblDocID";
            this.lblDocID.Size = new System.Drawing.Size(84, 13);
            this.lblDocID.TabIndex = 4;
            this.lblDocID.Text = "Номер анкеты:";
            // 
            // lblVersionID
            // 
            this.lblVersionID.AutoSize = true;
            this.lblVersionID.Location = new System.Drawing.Point(12, 79);
            this.lblVersionID.Name = "lblVersionID";
            this.lblVersionID.Size = new System.Drawing.Size(83, 13);
            this.lblVersionID.TabIndex = 5;
            this.lblVersionID.Text = "Номер версии:";
            // 
            // lblVersionStatus
            // 
            this.lblVersionStatus.AutoSize = true;
            this.lblVersionStatus.Location = new System.Drawing.Point(12, 103);
            this.lblVersionStatus.Name = "lblVersionStatus";
            this.lblVersionStatus.Size = new System.Drawing.Size(83, 13);
            this.lblVersionStatus.TabIndex = 6;
            this.lblVersionStatus.Text = "Статус версии:";
            // 
            // tbxDocID
            // 
            this.tbxDocID.Location = new System.Drawing.Point(102, 52);
            this.tbxDocID.Name = "tbxDocID";
            this.tbxDocID.ReadOnly = true;
            this.tbxDocID.Size = new System.Drawing.Size(100, 20);
            this.tbxDocID.TabIndex = 7;
            this.tbxDocID.TabStop = false;
            // 
            // tbxOrderID
            // 
            this.tbxOrderID.Location = new System.Drawing.Point(102, 6);
            this.tbxOrderID.Name = "tbxOrderID";
            this.tbxOrderID.ReadOnly = true;
            this.tbxOrderID.Size = new System.Drawing.Size(100, 20);
            this.tbxOrderID.TabIndex = 8;
            this.tbxOrderID.TabStop = false;
            // 
            // tbxItemID
            // 
            this.tbxItemID.Location = new System.Drawing.Point(102, 29);
            this.tbxItemID.Name = "tbxItemID";
            this.tbxItemID.ReadOnly = true;
            this.tbxItemID.Size = new System.Drawing.Size(100, 20);
            this.tbxItemID.TabIndex = 9;
            this.tbxItemID.TabStop = false;
            // 
            // tbxVersionID
            // 
            this.tbxVersionID.Location = new System.Drawing.Point(102, 76);
            this.tbxVersionID.Name = "tbxVersionID";
            this.tbxVersionID.ReadOnly = true;
            this.tbxVersionID.Size = new System.Drawing.Size(100, 20);
            this.tbxVersionID.TabIndex = 10;
            this.tbxVersionID.TabStop = false;
            // 
            // tbxVersionStatus
            // 
            this.tbxVersionStatus.Location = new System.Drawing.Point(102, 100);
            this.tbxVersionStatus.Name = "tbxVersionStatus";
            this.tbxVersionStatus.ReadOnly = true;
            this.tbxVersionStatus.Size = new System.Drawing.Size(100, 20);
            this.tbxVersionStatus.TabIndex = 11;
            this.tbxVersionStatus.TabStop = false;
            // 
            // tbxUser
            // 
            this.tbxUser.Location = new System.Drawing.Point(373, 100);
            this.tbxUser.Name = "tbxUser";
            this.tbxUser.ReadOnly = true;
            this.tbxUser.Size = new System.Drawing.Size(347, 20);
            this.tbxUser.TabIndex = 21;
            this.tbxUser.TabStop = false;
            // 
            // tbxVersionDate
            // 
            this.tbxVersionDate.Location = new System.Drawing.Point(373, 76);
            this.tbxVersionDate.Name = "tbxVersionDate";
            this.tbxVersionDate.ReadOnly = true;
            this.tbxVersionDate.Size = new System.Drawing.Size(170, 20);
            this.tbxVersionDate.TabIndex = 20;
            this.tbxVersionDate.TabStop = false;
            // 
            // tbxLotNumber
            // 
            this.tbxLotNumber.Location = new System.Drawing.Point(373, 29);
            this.tbxLotNumber.Name = "tbxLotNumber";
            this.tbxLotNumber.ReadOnly = true;
            this.tbxLotNumber.Size = new System.Drawing.Size(170, 20);
            this.tbxLotNumber.TabIndex = 19;
            this.tbxLotNumber.TabStop = false;
            // 
            // tbxVendor
            // 
            this.tbxVendor.Location = new System.Drawing.Point(373, 6);
            this.tbxVendor.Name = "tbxVendor";
            this.tbxVendor.ReadOnly = true;
            this.tbxVendor.Size = new System.Drawing.Size(347, 20);
            this.tbxVendor.TabIndex = 18;
            this.tbxVendor.TabStop = false;
            // 
            // tbxDocDate
            // 
            this.tbxDocDate.Location = new System.Drawing.Point(373, 52);
            this.tbxDocDate.Name = "tbxDocDate";
            this.tbxDocDate.ReadOnly = true;
            this.tbxDocDate.Size = new System.Drawing.Size(170, 20);
            this.tbxDocDate.TabIndex = 17;
            this.tbxDocDate.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(283, 103);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(79, 13);
            this.lblUser.TabIndex = 16;
            this.lblUser.Text = "Автор версии:";
            // 
            // lblVersionDate
            // 
            this.lblVersionDate.AutoSize = true;
            this.lblVersionDate.Location = new System.Drawing.Point(283, 79);
            this.lblVersionDate.Name = "lblVersionDate";
            this.lblVersionDate.Size = new System.Drawing.Size(75, 13);
            this.lblVersionDate.TabIndex = 15;
            this.lblVersionDate.Text = "Дата версии:";
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(283, 55);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(76, 13);
            this.lblDocDate.TabIndex = 14;
            this.lblDocDate.Text = "Дата анкеты:";
            // 
            // lblLotNumber
            // 
            this.lblLotNumber.AutoSize = true;
            this.lblLotNumber.Location = new System.Drawing.Point(283, 32);
            this.lblLotNumber.Name = "lblLotNumber";
            this.lblLotNumber.Size = new System.Drawing.Size(47, 13);
            this.lblLotNumber.TabIndex = 13;
            this.lblLotNumber.Text = "Партия:";
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(283, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 12;
            this.lblVendor.Text = "Поставщик:";
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.AllowUserToAddRows = false;
            this.dgvQuestions.AllowUserToDeleteRows = false;
            this.dgvQuestions.AllowUserToOrderColumns = true;
            this.dgvQuestions.AllowUserToResizeRows = false;
            this.dgvQuestions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuestions.AutoGenerateColumns = false;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clQuestionName,
            this.clAnswer1,
            this.clAnswer2,
            this.clAnswer3,
            this.clAnswer4,
            this.clInvoiceInfo,
            this.clResult});
            this.dgvQuestions.DataSource = this.bsAtDocVersionQuestions;
            this.dgvQuestions.Location = new System.Drawing.Point(15, 250);
            this.dgvQuestions.MultiSelect = false;
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.RowHeadersVisible = false;
            this.dgvQuestions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestions.ShowEditingIcon = false;
            this.dgvQuestions.ShowRowErrors = false;
            this.dgvQuestions.Size = new System.Drawing.Size(1059, 219);
            this.dgvQuestions.TabIndex = 70;
            this.dgvQuestions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestions_CellValueChanged);
            // 
            // clQuestionName
            // 
            this.clQuestionName.DataPropertyName = "question_name";
            this.clQuestionName.HeaderText = "Критерий проверки";
            this.clQuestionName.Name = "clQuestionName";
            this.clQuestionName.ReadOnly = true;
            this.clQuestionName.Width = 200;
            // 
            // clAnswer1
            // 
            this.clAnswer1.DataPropertyName = "answer1";
            this.clAnswer1.HeaderText = "Сертиф. произв.";
            this.clAnswer1.Name = "clAnswer1";
            this.clAnswer1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clAnswer1.ThreeState = true;
            // 
            // clAnswer2
            // 
            this.clAnswer2.DataPropertyName = "answer2";
            this.clAnswer2.HeaderText = "Виз. контроль";
            this.clAnswer2.Name = "clAnswer2";
            this.clAnswer2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clAnswer2.ThreeState = true;
            // 
            // clAnswer3
            // 
            this.clAnswer3.DataPropertyName = "answer3";
            this.clAnswer3.HeaderText = "Печатная накл.";
            this.clAnswer3.Name = "clAnswer3";
            this.clAnswer3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clAnswer3.ThreeState = true;
            // 
            // clAnswer4
            // 
            this.clAnswer4.DataPropertyName = "answer4";
            this.clAnswer4.HeaderText = "Заключение ГЛС";
            this.clAnswer4.Name = "clAnswer4";
            this.clAnswer4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clAnswer4.ThreeState = true;
            // 
            // clInvoiceInfo
            // 
            this.clInvoiceInfo.DataPropertyName = "invoice_info";
            this.clInvoiceInfo.HeaderText = "Накладная JDE";
            this.clInvoiceInfo.Name = "clInvoiceInfo";
            this.clInvoiceInfo.ReadOnly = true;
            this.clInvoiceInfo.Width = 350;
            // 
            // clResult
            // 
            this.clResult.DataPropertyName = "result";
            this.clResult.HeaderText = "Результат";
            this.clResult.Name = "clResult";
            this.clResult.ReadOnly = true;
            // 
            // bsAtDocVersionQuestions
            // 
            this.bsAtDocVersionQuestions.DataMember = "AT_Doc_Version_Questions";
            this.bsAtDocVersionQuestions.DataSource = this.quality;
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblQuestionsHeader
            // 
            this.lblQuestionsHeader.AutoSize = true;
            this.lblQuestionsHeader.Location = new System.Drawing.Point(12, 234);
            this.lblQuestionsHeader.Name = "lblQuestionsHeader";
            this.lblQuestionsHeader.Size = new System.Drawing.Size(109, 13);
            this.lblQuestionsHeader.TabIndex = 23;
            this.lblQuestionsHeader.Text = "Критерии проверки:";
            // 
            // lblCurrentDate
            // 
            this.lblCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentDate.AutoSize = true;
            this.lblCurrentDate.Location = new System.Drawing.Point(12, 491);
            this.lblCurrentDate.Name = "lblCurrentDate";
            this.lblCurrentDate.Size = new System.Drawing.Size(143, 13);
            this.lblCurrentDate.TabIndex = 24;
            this.lblCurrentDate.Text = "Дата и время заполнения:";
            // 
            // tbxCurrentDate
            // 
            this.tbxCurrentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCurrentDate.Location = new System.Drawing.Point(161, 488);
            this.tbxCurrentDate.Name = "tbxCurrentDate";
            this.tbxCurrentDate.ReadOnly = true;
            this.tbxCurrentDate.Size = new System.Drawing.Size(169, 20);
            this.tbxCurrentDate.TabIndex = 25;
            this.tbxCurrentDate.TabStop = false;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Location = new System.Drawing.Point(370, 491);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(59, 13);
            this.lblCurrentUser.TabIndex = 26;
            this.lblCurrentUser.Text = "Заполнил:";
            // 
            // tbxCurrentUser
            // 
            this.tbxCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbxCurrentUser.Location = new System.Drawing.Point(435, 488);
            this.tbxCurrentUser.Name = "tbxCurrentUser";
            this.tbxCurrentUser.ReadOnly = true;
            this.tbxCurrentUser.Size = new System.Drawing.Size(285, 20);
            this.tbxCurrentUser.TabIndex = 27;
            this.tbxCurrentUser.TabStop = false;
            // 
            // grbParams
            // 
            this.grbParams.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grbParams.Controls.Add(this.cmbLotnManufacturer);
            this.grbParams.Controls.Add(this.lblLotnManufacturer);
            this.grbParams.Controls.Add(this.btnShowExpirationDatesDifference);
            this.grbParams.Controls.Add(this.lblTemperatureStorageMode);
            this.grbParams.Controls.Add(this.ecmbTemperatureStorageMode);
            this.grbParams.Controls.Add(this.btnScan);
            this.grbParams.Controls.Add(this.tbLot_Qty);
            this.grbParams.Controls.Add(this.cbHasCertificate);
            this.grbParams.Controls.Add(this.lblLot_Qty);
            this.grbParams.Controls.Add(this.btnAddTaskDirectum);
            this.grbParams.Controls.Add(this.tbxCertDate);
            this.grbParams.Controls.Add(this.btnEditData);
            this.grbParams.Controls.Add(this.dtpExpirationDate);
            this.grbParams.Controls.Add(this.lblExpirationDate);
            this.grbParams.Controls.Add(this.tbxVendorLot);
            this.grbParams.Controls.Add(this.lblVendorLot);
            this.grbParams.Controls.Add(this.dtpCertDate);
            this.grbParams.Controls.Add(this.lblCertDate);
            this.grbParams.Controls.Add(this.tbxCertNumber);
            this.grbParams.Controls.Add(this.lblCertNumber);
            this.grbParams.Location = new System.Drawing.Point(15, 128);
            this.grbParams.Name = "grbParams";
            this.grbParams.Size = new System.Drawing.Size(1059, 104);
            this.grbParams.TabIndex = 10;
            this.grbParams.TabStop = false;
            this.grbParams.Text = "Редактирование данных для партии";
            // 
            // btnShowExpirationDatesDifference
            // 
            this.btnShowExpirationDatesDifference.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnShowExpirationDatesDifference.Location = new System.Drawing.Point(558, 45);
            this.btnShowExpirationDatesDifference.Name = "btnShowExpirationDatesDifference";
            this.btnShowExpirationDatesDifference.Size = new System.Drawing.Size(23, 23);
            this.btnShowExpirationDatesDifference.TabIndex = 68;
            this.btnShowExpirationDatesDifference.UseVisualStyleBackColor = true;
            this.btnShowExpirationDatesDifference.Visible = false;
            this.btnShowExpirationDatesDifference.Click += new System.EventHandler(this.btnShowExpirationDatesDifference_Click);
            // 
            // lblTemperatureStorageMode
            // 
            this.lblTemperatureStorageMode.AutoSize = true;
            this.lblTemperatureStorageMode.Location = new System.Drawing.Point(736, 74);
            this.lblTemperatureStorageMode.Name = "lblTemperatureStorageMode";
            this.lblTemperatureStorageMode.Size = new System.Drawing.Size(107, 13);
            this.lblTemperatureStorageMode.TabIndex = 67;
            this.lblTemperatureStorageMode.Text = " Условия хранения:";
            // 
            // ecmbTemperatureStorageMode
            // 
            this.ecmbTemperatureStorageMode.DataSource = this.aTTemperatureStorageModeBindingSource;
            this.ecmbTemperatureStorageMode.DisplayMember = "mode_name";
            this.ecmbTemperatureStorageMode.FormattingEnabled = true;
            this.ecmbTemperatureStorageMode.Location = new System.Drawing.Point(849, 70);
            this.ecmbTemperatureStorageMode.MatchingMethod = WMSOffice.Controls.ExtraComboBox.StringMatchingMethod.UseWildcards;
            this.ecmbTemperatureStorageMode.Name = "ecmbTemperatureStorageMode";
            this.ecmbTemperatureStorageMode.Size = new System.Drawing.Size(200, 21);
            this.ecmbTemperatureStorageMode.TabIndex = 66;
            this.ecmbTemperatureStorageMode.ValueMember = "mode_id";
            // 
            // aTTemperatureStorageModeBindingSource
            // 
            this.aTTemperatureStorageModeBindingSource.DataMember = "AT_TemperatureStorageMode";
            this.aTTemperatureStorageModeBindingSource.DataSource = this.quality;
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(558, 69);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(87, 23);
            this.btnScan.TabIndex = 65;
            this.btnScan.Text = "Сканировать";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // tbLot_Qty
            // 
            this.tbLot_Qty.Location = new System.Drawing.Point(125, 69);
            this.tbLot_Qty.Name = "tbLot_Qty";
            this.tbLot_Qty.Size = new System.Drawing.Size(114, 20);
            this.tbLot_Qty.TabIndex = 64;
            // 
            // lblLot_Qty
            // 
            this.lblLot_Qty.AutoSize = true;
            this.lblLot_Qty.Location = new System.Drawing.Point(6, 72);
            this.lblLot_Qty.Name = "lblLot_Qty";
            this.lblLot_Qty.Size = new System.Drawing.Size(82, 13);
            this.lblLot_Qty.TabIndex = 63;
            this.lblLot_Qty.Text = "Размер серии:";
            // 
            // btnAddTaskDirectum
            // 
            this.btnAddTaskDirectum.Location = new System.Drawing.Point(379, 69);
            this.btnAddTaskDirectum.Name = "btnAddTaskDirectum";
            this.btnAddTaskDirectum.Size = new System.Drawing.Size(173, 23);
            this.btnAddTaskDirectum.TabIndex = 62;
            this.btnAddTaskDirectum.Text = "Добавить задание в Directum";
            this.btnAddTaskDirectum.UseVisualStyleBackColor = true;
            this.btnAddTaskDirectum.Click += new System.EventHandler(this.btnAddTaskDirectum_Click);
            // 
            // cbHasCertificate
            // 
            this.cbHasCertificate.AutoSize = true;
            this.cbHasCertificate.Location = new System.Drawing.Point(849, 24);
            this.cbHasCertificate.Name = "cbHasCertificate";
            this.cbHasCertificate.Size = new System.Drawing.Size(138, 17);
            this.cbHasCertificate.TabIndex = 61;
            this.cbHasCertificate.Text = "Наличие сертификата";
            this.cbHasCertificate.UseVisualStyleBackColor = true;
            // 
            // tbxCertDate
            // 
            this.tbxCertDate.BackColor = System.Drawing.Color.Red;
            this.tbxCertDate.Location = new System.Drawing.Point(379, 23);
            this.tbxCertDate.Name = "tbxCertDate";
            this.tbxCertDate.Size = new System.Drawing.Size(173, 20);
            this.tbxCertDate.TabIndex = 30;
            this.tbxCertDate.TextChanged += new System.EventHandler(this.tbxDate_TextChanged);
            // 
            // btnEditData
            // 
            this.btnEditData.Location = new System.Drawing.Point(271, 69);
            this.btnEditData.Name = "btnEditData";
            this.btnEditData.Size = new System.Drawing.Size(102, 23);
            this.btnEditData.TabIndex = 60;
            this.btnEditData.Text = "Внести данные";
            this.btnEditData.UseVisualStyleBackColor = true;
            this.btnEditData.Click += new System.EventHandler(this.btnEditData_Click);
            // 
            // dtpExpirationDate
            // 
            this.dtpExpirationDate.Location = new System.Drawing.Point(379, 46);
            this.dtpExpirationDate.Name = "dtpExpirationDate";
            this.dtpExpirationDate.Size = new System.Drawing.Size(173, 20);
            this.dtpExpirationDate.TabIndex = 50;
            // 
            // lblExpirationDate
            // 
            this.lblExpirationDate.AutoSize = true;
            this.lblExpirationDate.Location = new System.Drawing.Point(268, 49);
            this.lblExpirationDate.Name = "lblExpirationDate";
            this.lblExpirationDate.Size = new System.Drawing.Size(84, 13);
            this.lblExpirationDate.TabIndex = 6;
            this.lblExpirationDate.Text = "Срок годности:";
            // 
            // tbxVendorLot
            // 
            this.tbxVendorLot.Location = new System.Drawing.Point(125, 46);
            this.tbxVendorLot.Name = "tbxVendorLot";
            this.tbxVendorLot.Size = new System.Drawing.Size(114, 20);
            this.tbxVendorLot.TabIndex = 40;
            this.tbxVendorLot.Leave += new System.EventHandler(this.tbxVendorLot_Leave);
            // 
            // lblVendorLot
            // 
            this.lblVendorLot.AutoSize = true;
            this.lblVendorLot.Location = new System.Drawing.Point(6, 49);
            this.lblVendorLot.Name = "lblVendorLot";
            this.lblVendorLot.Size = new System.Drawing.Size(77, 13);
            this.lblVendorLot.TabIndex = 4;
            this.lblVendorLot.Text = "Номер серии:";
            // 
            // dtpCertDate
            // 
            this.dtpCertDate.Enabled = false;
            this.dtpCertDate.Location = new System.Drawing.Point(558, 22);
            this.dtpCertDate.Name = "dtpCertDate";
            this.dtpCertDate.Size = new System.Drawing.Size(147, 20);
            this.dtpCertDate.TabIndex = 30;
            this.dtpCertDate.TabStop = false;
            // 
            // lblCertDate
            // 
            this.lblCertDate.AutoSize = true;
            this.lblCertDate.Location = new System.Drawing.Point(268, 26);
            this.lblCertDate.Name = "lblCertDate";
            this.lblCertDate.Size = new System.Drawing.Size(105, 13);
            this.lblCertDate.TabIndex = 2;
            this.lblCertDate.Text = "Дата сертификата:";
            // 
            // tbxCertNumber
            // 
            this.tbxCertNumber.Location = new System.Drawing.Point(125, 23);
            this.tbxCertNumber.Name = "tbxCertNumber";
            this.tbxCertNumber.Size = new System.Drawing.Size(114, 20);
            this.tbxCertNumber.TabIndex = 20;
            // 
            // lblCertNumber
            // 
            this.lblCertNumber.AutoSize = true;
            this.lblCertNumber.Location = new System.Drawing.Point(6, 26);
            this.lblCertNumber.Name = "lblCertNumber";
            this.lblCertNumber.Size = new System.Drawing.Size(113, 13);
            this.lblCertNumber.TabIndex = 0;
            this.lblCertNumber.Text = "Номер сертификата:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "question_name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Критерий проверки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "answer1";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Сертиф. произв.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.ThreeState = true;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "answer2";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Виз. контроль";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn2.ThreeState = true;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "answer3";
            this.dataGridViewCheckBoxColumn3.HeaderText = "Печатная накл.";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.ThreeState = true;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "answer4";
            this.dataGridViewCheckBoxColumn4.HeaderText = "Заключение ГЛС";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn4.ThreeState = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "invoice_info";
            this.dataGridViewTextBoxColumn2.HeaderText = "Накладная JDE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "result";
            this.dataGridViewTextBoxColumn3.HeaderText = "result";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // taAtDocVersionQuestions
            // 
            this.taAtDocVersionQuestions.ClearBeforeFill = true;
            // 
            // aT_TemperatureStorageModeTableAdapter
            // 
            this.aT_TemperatureStorageModeTableAdapter.ClearBeforeFill = true;
            // 
            // lblLotnManufacturer
            // 
            this.lblLotnManufacturer.AutoSize = true;
            this.lblLotnManufacturer.Location = new System.Drawing.Point(701, 49);
            this.lblLotnManufacturer.Name = "lblLotnManufacturer";
            this.lblLotnManufacturer.Size = new System.Drawing.Size(142, 13);
            this.lblLotnManufacturer.TabIndex = 69;
            this.lblLotnManufacturer.Text = "Производитель по партии:";
            // 
            // cmbLotnManufacturer
            // 
            this.cmbLotnManufacturer.DataSource = this.aTLotnManufacturersBindingSource;
            this.cmbLotnManufacturer.DisplayMember = "Manufacturer_Name";
            this.cmbLotnManufacturer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLotnManufacturer.FormattingEnabled = true;
            this.cmbLotnManufacturer.Location = new System.Drawing.Point(849, 45);
            this.cmbLotnManufacturer.Name = "cmbLotnManufacturer";
            this.cmbLotnManufacturer.Size = new System.Drawing.Size(200, 21);
            this.cmbLotnManufacturer.TabIndex = 70;
            this.cmbLotnManufacturer.ValueMember = "Manufacturer_ID";
            // 
            // aTLotnManufacturersBindingSource
            // 
            this.aTLotnManufacturersBindingSource.DataMember = "AT_Lotn_Manufacturers";
            this.aTLotnManufacturersBindingSource.DataSource = this.quality;
            // 
            // aT_Lotn_ManufacturersTableAdapter
            // 
            this.aT_Lotn_ManufacturersTableAdapter.ClearBeforeFill = true;
            // 
            // EditInputControlLotnWorksheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1086, 555);
            this.Controls.Add(this.grbParams);
            this.Controls.Add(this.tbxCurrentUser);
            this.Controls.Add(this.lblCurrentUser);
            this.Controls.Add(this.tbxCurrentDate);
            this.Controls.Add(this.lblCurrentDate);
            this.Controls.Add(this.lblQuestionsHeader);
            this.Controls.Add(this.dgvQuestions);
            this.Controls.Add(this.tbxUser);
            this.Controls.Add(this.tbxVersionDate);
            this.Controls.Add(this.tbxLotNumber);
            this.Controls.Add(this.tbxVendor);
            this.Controls.Add(this.tbxDocDate);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblVersionDate);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.lblLotNumber);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.tbxVersionStatus);
            this.Controls.Add(this.tbxVersionID);
            this.Controls.Add(this.tbxItemID);
            this.Controls.Add(this.tbxOrderID);
            this.Controls.Add(this.tbxDocID);
            this.Controls.Add(this.lblVersionStatus);
            this.Controls.Add(this.lblVersionID);
            this.Controls.Add(this.lblDocID);
            this.Controls.Add(this.lblItemID);
            this.Controls.Add(this.lblOrderNumber);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Name = "EditInputControlLotnWorksheetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование анкеты входного контроля партии";
            this.Load += new System.EventHandler(this.EditInputControlLotnWorksheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsAtDocVersionQuestions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            this.grbParams.ResumeLayout(false);
            this.grbParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aTTemperatureStorageModeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aTLotnManufacturersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblOrderNumber;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblDocID;
        private System.Windows.Forms.Label lblVersionID;
        private System.Windows.Forms.Label lblVersionStatus;
        private System.Windows.Forms.TextBox tbxDocID;
        private System.Windows.Forms.TextBox tbxOrderID;
        private System.Windows.Forms.TextBox tbxItemID;
        private System.Windows.Forms.TextBox tbxVersionID;
        private System.Windows.Forms.TextBox tbxVersionStatus;
        private System.Windows.Forms.TextBox tbxUser;
        private System.Windows.Forms.TextBox tbxVersionDate;
        private System.Windows.Forms.TextBox tbxLotNumber;
        private System.Windows.Forms.TextBox tbxVendor;
        private System.Windows.Forms.TextBox tbxDocDate;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblVersionDate;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Label lblLotNumber;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.Label lblQuestionsHeader;
        private System.Windows.Forms.Label lblCurrentDate;
        private System.Windows.Forms.TextBox tbxCurrentDate;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.TextBox tbxCurrentUser;
        private System.Windows.Forms.BindingSource bsAtDocVersionQuestions;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AT_Doc_Version_QuestionsTableAdapter taAtDocVersionQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuestionName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clAnswer1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clAnswer2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clAnswer3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clAnswer4;
        private System.Windows.Forms.DataGridViewTextBoxColumn clInvoiceInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clResult;
        private System.Windows.Forms.GroupBox grbParams;
        private System.Windows.Forms.Button btnEditData;
        private System.Windows.Forms.DateTimePicker dtpExpirationDate;
        private System.Windows.Forms.Label lblExpirationDate;
        private System.Windows.Forms.TextBox tbxVendorLot;
        private System.Windows.Forms.Label lblVendorLot;
        private System.Windows.Forms.DateTimePicker dtpCertDate;
        private System.Windows.Forms.Label lblCertDate;
        private System.Windows.Forms.TextBox tbxCertNumber;
        private System.Windows.Forms.Label lblCertNumber;
        private System.Windows.Forms.TextBox tbxCertDate;
        private System.Windows.Forms.CheckBox cbHasCertificate;
        private System.Windows.Forms.Button btnAddTaskDirectum;
        private System.Windows.Forms.TextBox tbLot_Qty;
        private System.Windows.Forms.Label lblLot_Qty;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label lblTemperatureStorageMode;
        private WMSOffice.Controls.ExtraComboBox.ExtraComboBox ecmbTemperatureStorageMode;
        private System.Windows.Forms.BindingSource aTTemperatureStorageModeBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AT_TemperatureStorageModeTableAdapter aT_TemperatureStorageModeTableAdapter;
        private System.Windows.Forms.Button btnShowExpirationDatesDifference;
        private System.Windows.Forms.ComboBox cmbLotnManufacturer;
        private System.Windows.Forms.Label lblLotnManufacturer;
        private System.Windows.Forms.BindingSource aTLotnManufacturersBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AT_Lotn_ManufacturersTableAdapter aT_Lotn_ManufacturersTableAdapter;
    }
}