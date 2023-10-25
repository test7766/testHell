namespace WMSOffice.Dialogs.Quality
{
    partial class EditInputControlDeliveryWorksheetForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblDeliveryID = new System.Windows.Forms.Label();
            this.tbxDeliveryID = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.tbxDocNumber = new System.Windows.Forms.TextBox();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.tbxVersionNumber = new System.Windows.Forms.TextBox();
            this.lblVendor = new System.Windows.Forms.Label();
            this.tbxVendor = new System.Windows.Forms.TextBox();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.lblVersionDate = new System.Windows.Forms.Label();
            this.tbxDocDate = new System.Windows.Forms.TextBox();
            this.tbxVersionDate = new System.Windows.Forms.TextBox();
            this.lblVersionStatus = new System.Windows.Forms.Label();
            this.tbxVersionStatus = new System.Windows.Forms.TextBox();
            this.lblVersionUser = new System.Windows.Forms.Label();
            this.tbxVersionUser = new System.Windows.Forms.TextBox();
            this.lblQuestionGroup1Header = new System.Windows.Forms.Label();
            this.dgvQuestionGroup1 = new System.Windows.Forms.DataGridView();
            this.clShowEditor1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.question_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuestion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miGenerateRightAnswers = new System.Windows.Forms.ToolStripMenuItem();
            this.bsApVersionQuestions1 = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.lblEditingDate1 = new System.Windows.Forms.Label();
            this.tbxEditingDate1 = new System.Windows.Forms.TextBox();
            this.tbxUser1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.dgvQuestionGroup2 = new System.Windows.Forms.DataGridView();
            this.clShowEditor2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuestion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsApVersionQuestions2 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.aPFileTypesDirectoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aPEquipmentTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aPTermoModesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.aPGetAttachmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsAttachments = new System.Windows.Forms.ToolStrip();
            this.btnAddFile = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteFile = new System.Windows.Forms.ToolStripButton();
            this.btnPreviewFile = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFileTemplate = new System.Windows.Forms.ToolStripButton();
            this.taApVersionQuestions = new WMSOffice.Data.QualityTableAdapters.AP_Version_QuestionsTableAdapter();
            this.taApGetWorksheetReportHeader = new WMSOffice.Data.QualityTableAdapters.AP_Get_Worksheet_Report_HeaderTableAdapter();
            this.aP_Get_AttachmentsTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter();
            this.aP_Termo_ModesTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Termo_ModesTableAdapter();
            this.tbxCarNumber = new System.Windows.Forms.TextBox();
            this.tbxTrailerNumber = new System.Windows.Forms.TextBox();
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.lblTrailerNumber = new System.Windows.Forms.Label();
            this.tbxLicenseInfo = new System.Windows.Forms.TextBox();
            this.lblLicenseInfo = new System.Windows.Forms.Label();
            this.tbxLicenseStatus = new System.Windows.Forms.TextBox();
            this.lblLicenseStatus = new System.Windows.Forms.Label();
            this.aP_File_Types_DirectoryTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_File_Types_DirectoryTableAdapter();
            this.aP_Equipment_TypesTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Equipment_TypesTableAdapter();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn3 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuestionGroup1 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Content = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Footer = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Header = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup2 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup2Content = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup2Footer = new System.Windows.Forms.Panel();
            this.lblEditingDate2 = new System.Windows.Forms.Label();
            this.tbxEditingDate2 = new System.Windows.Forms.TextBox();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.tbxUser2 = new System.Windows.Forms.TextBox();
            this.pnlQuestionGroup2Header = new System.Windows.Forms.Panel();
            this.lblQuestionGroup2Header = new System.Windows.Forms.Label();
            this.pnlAttachments = new System.Windows.Forms.Panel();
            this.pnlAttachmentsContent = new System.Windows.Forms.Panel();
            this.pnlAttachmentsHeader = new System.Windows.Forms.Panel();
            this.lblAttachmentsHeader = new System.Windows.Forms.Label();
            this.pnlAttachmentsFooter = new System.Windows.Forms.Panel();
            this.lblEditingDate3 = new System.Windows.Forms.Label();
            this.tbxEditingDate3 = new System.Windows.Forms.TextBox();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.tbxUser3 = new System.Windows.Forms.TextBox();
            this.pnlQuestionGroup4 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup4Content = new System.Windows.Forms.Panel();
            this.dgvQuestionGroup4 = new System.Windows.Forms.DataGridView();
            this.clShowEditor4 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsApVersionQuestions4 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlQuestionGroup4Header = new System.Windows.Forms.Panel();
            this.lblQuestionGroup4Header = new System.Windows.Forms.Label();
            this.pnlQuestionGroup4Footer = new System.Windows.Forms.Panel();
            this.lblEditingDate4 = new System.Windows.Forms.Label();
            this.tbxEditingDate4 = new System.Windows.Forms.TextBox();
            this.lblUser4 = new System.Windows.Forms.Label();
            this.tbxUser4 = new System.Windows.Forms.TextBox();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DirectoryType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.fileLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EquipmentType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EquipmentNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermoMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.clYesT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNoT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNullT = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup1)).BeginInit();
            this.cmsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPFileTypesDirectoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPEquipmentTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPTermoModesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetAttachmentsBindingSource)).BeginInit();
            this.tsAttachments.SuspendLayout();
            this.tlpMainContent.SuspendLayout();
            this.pnlQuestionGroup1.SuspendLayout();
            this.pnlQuestionGroup1Content.SuspendLayout();
            this.pnlQuestionGroup1Footer.SuspendLayout();
            this.pnlQuestionGroup1Header.SuspendLayout();
            this.pnlQuestionGroup2.SuspendLayout();
            this.pnlQuestionGroup2Content.SuspendLayout();
            this.pnlQuestionGroup2Footer.SuspendLayout();
            this.pnlQuestionGroup2Header.SuspendLayout();
            this.pnlAttachments.SuspendLayout();
            this.pnlAttachmentsContent.SuspendLayout();
            this.pnlAttachmentsHeader.SuspendLayout();
            this.pnlAttachmentsFooter.SuspendLayout();
            this.pnlQuestionGroup4.SuspendLayout();
            this.pnlQuestionGroup4Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions4)).BeginInit();
            this.pnlQuestionGroup4Header.SuspendLayout();
            this.pnlQuestionGroup4Footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1095, 837);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1014, 837);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 43;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblDeliveryID
            // 
            this.lblDeliveryID.AutoSize = true;
            this.lblDeliveryID.Location = new System.Drawing.Point(15, 9);
            this.lblDeliveryID.Name = "lblDeliveryID";
            this.lblDeliveryID.Size = new System.Drawing.Size(71, 13);
            this.lblDeliveryID.TabIndex = 0;
            this.lblDeliveryID.Text = "№ поставки:";
            // 
            // tbxDeliveryID
            // 
            this.tbxDeliveryID.Location = new System.Drawing.Point(98, 6);
            this.tbxDeliveryID.Name = "tbxDeliveryID";
            this.tbxDeliveryID.ReadOnly = true;
            this.tbxDeliveryID.Size = new System.Drawing.Size(160, 20);
            this.tbxDeliveryID.TabIndex = 1;
            this.tbxDeliveryID.TabStop = false;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(15, 87);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(61, 13);
            this.lblDocNumber.TabIndex = 6;
            this.lblDocNumber.Text = "№ анкеты:";
            // 
            // tbxDocNumber
            // 
            this.tbxDocNumber.Location = new System.Drawing.Point(98, 83);
            this.tbxDocNumber.Name = "tbxDocNumber";
            this.tbxDocNumber.ReadOnly = true;
            this.tbxDocNumber.Size = new System.Drawing.Size(160, 20);
            this.tbxDocNumber.TabIndex = 7;
            this.tbxDocNumber.TabStop = false;
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Location = new System.Drawing.Point(15, 114);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(60, 13);
            this.lblVersionNumber.TabIndex = 8;
            this.lblVersionNumber.Text = "№ версии:";
            // 
            // tbxVersionNumber
            // 
            this.tbxVersionNumber.Location = new System.Drawing.Point(98, 110);
            this.tbxVersionNumber.Name = "tbxVersionNumber";
            this.tbxVersionNumber.ReadOnly = true;
            this.tbxVersionNumber.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionNumber.TabIndex = 9;
            this.tbxVersionNumber.TabStop = false;
            // 
            // lblVendor
            // 
            this.lblVendor.AutoSize = true;
            this.lblVendor.Location = new System.Drawing.Point(341, 9);
            this.lblVendor.Name = "lblVendor";
            this.lblVendor.Size = new System.Drawing.Size(68, 13);
            this.lblVendor.TabIndex = 12;
            this.lblVendor.Text = "Поставщик:";
            // 
            // tbxVendor
            // 
            this.tbxVendor.Location = new System.Drawing.Point(476, 6);
            this.tbxVendor.Name = "tbxVendor";
            this.tbxVendor.ReadOnly = true;
            this.tbxVendor.Size = new System.Drawing.Size(330, 20);
            this.tbxVendor.TabIndex = 13;
            this.tbxVendor.TabStop = false;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(341, 35);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(120, 13);
            this.lblDocDate.TabIndex = 14;
            this.lblDocDate.Text = "Дата и время анкеты:";
            // 
            // lblVersionDate
            // 
            this.lblVersionDate.AutoSize = true;
            this.lblVersionDate.Location = new System.Drawing.Point(341, 61);
            this.lblVersionDate.Name = "lblVersionDate";
            this.lblVersionDate.Size = new System.Drawing.Size(120, 13);
            this.lblVersionDate.TabIndex = 16;
            this.lblVersionDate.Text = "Дата и время анкеты:";
            // 
            // tbxDocDate
            // 
            this.tbxDocDate.Location = new System.Drawing.Point(476, 32);
            this.tbxDocDate.Name = "tbxDocDate";
            this.tbxDocDate.ReadOnly = true;
            this.tbxDocDate.Size = new System.Drawing.Size(160, 20);
            this.tbxDocDate.TabIndex = 15;
            this.tbxDocDate.TabStop = false;
            // 
            // tbxVersionDate
            // 
            this.tbxVersionDate.Location = new System.Drawing.Point(476, 58);
            this.tbxVersionDate.Name = "tbxVersionDate";
            this.tbxVersionDate.ReadOnly = true;
            this.tbxVersionDate.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionDate.TabIndex = 17;
            this.tbxVersionDate.TabStop = false;
            // 
            // lblVersionStatus
            // 
            this.lblVersionStatus.AutoSize = true;
            this.lblVersionStatus.Location = new System.Drawing.Point(341, 114);
            this.lblVersionStatus.Name = "lblVersionStatus";
            this.lblVersionStatus.Size = new System.Drawing.Size(64, 13);
            this.lblVersionStatus.TabIndex = 20;
            this.lblVersionStatus.Text = "Ст. версии:";
            // 
            // tbxVersionStatus
            // 
            this.tbxVersionStatus.Location = new System.Drawing.Point(476, 110);
            this.tbxVersionStatus.Name = "tbxVersionStatus";
            this.tbxVersionStatus.ReadOnly = true;
            this.tbxVersionStatus.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionStatus.TabIndex = 21;
            this.tbxVersionStatus.TabStop = false;
            // 
            // lblVersionUser
            // 
            this.lblVersionUser.AutoSize = true;
            this.lblVersionUser.Location = new System.Drawing.Point(341, 87);
            this.lblVersionUser.Name = "lblVersionUser";
            this.lblVersionUser.Size = new System.Drawing.Size(79, 13);
            this.lblVersionUser.TabIndex = 18;
            this.lblVersionUser.Text = "Автор версии:";
            // 
            // tbxVersionUser
            // 
            this.tbxVersionUser.Location = new System.Drawing.Point(476, 84);
            this.tbxVersionUser.Name = "tbxVersionUser";
            this.tbxVersionUser.ReadOnly = true;
            this.tbxVersionUser.Size = new System.Drawing.Size(330, 20);
            this.tbxVersionUser.TabIndex = 19;
            this.tbxVersionUser.TabStop = false;
            // 
            // lblQuestionGroup1Header
            // 
            this.lblQuestionGroup1Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblQuestionGroup1Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionGroup1Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionGroup1Header.Location = new System.Drawing.Point(0, 0);
            this.lblQuestionGroup1Header.Name = "lblQuestionGroup1Header";
            this.lblQuestionGroup1Header.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblQuestionGroup1Header.Size = new System.Drawing.Size(1153, 25);
            this.lblQuestionGroup1Header.TabIndex = 24;
            this.lblQuestionGroup1Header.Text = "Проверка условий транспортировки поставки:";
            // 
            // dgvQuestionGroup1
            // 
            this.dgvQuestionGroup1.AllowUserToAddRows = false;
            this.dgvQuestionGroup1.AllowUserToDeleteRows = false;
            this.dgvQuestionGroup1.AllowUserToResizeRows = false;
            this.dgvQuestionGroup1.AutoGenerateColumns = false;
            this.dgvQuestionGroup1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionGroup1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clShowEditor1,
            this.question_type_name,
            this.clQuestion1,
            this.clYes1,
            this.clNo1,
            this.clNull1});
            this.dgvQuestionGroup1.ContextMenuStrip = this.cmsTools;
            this.dgvQuestionGroup1.DataSource = this.bsApVersionQuestions1;
            this.dgvQuestionGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionGroup1.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionGroup1.MultiSelect = false;
            this.dgvQuestionGroup1.Name = "dgvQuestionGroup1";
            this.dgvQuestionGroup1.ReadOnly = true;
            this.dgvQuestionGroup1.RowHeadersVisible = false;
            this.dgvQuestionGroup1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionGroup1.Size = new System.Drawing.Size(1153, 178);
            this.dgvQuestionGroup1.TabIndex = 25;
            this.dgvQuestionGroup1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionGroup_CellFormatting);
            this.dgvQuestionGroup1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuestionGroup_DataBindingComplete);
            this.dgvQuestionGroup1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionGroup_CellContentClick);
            // 
            // clShowEditor1
            // 
            this.clShowEditor1.HeaderText = "";
            this.clShowEditor1.Name = "clShowEditor1";
            this.clShowEditor1.ReadOnly = true;
            this.clShowEditor1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clShowEditor1.Width = 25;
            // 
            // question_type_name
            // 
            this.question_type_name.DataPropertyName = "question_type_name";
            this.question_type_name.HeaderText = "Группа критериев";
            this.question_type_name.Name = "question_type_name";
            this.question_type_name.ReadOnly = true;
            this.question_type_name.Width = 350;
            // 
            // clQuestion1
            // 
            this.clQuestion1.DataPropertyName = "question";
            this.clQuestion1.HeaderText = "Критерий проверки";
            this.clQuestion1.Name = "clQuestion1";
            this.clQuestion1.ReadOnly = true;
            this.clQuestion1.Width = 525;
            // 
            // clYes1
            // 
            this.clYes1.DataPropertyName = "yes";
            this.clYes1.HeaderText = "Да";
            this.clYes1.Name = "clYes1";
            this.clYes1.ReadOnly = true;
            this.clYes1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clYes1.Width = 30;
            // 
            // clNo1
            // 
            this.clNo1.DataPropertyName = "no";
            this.clNo1.HeaderText = "Нет";
            this.clNo1.Name = "clNo1";
            this.clNo1.ReadOnly = true;
            this.clNo1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNo1.Width = 30;
            // 
            // clNull1
            // 
            this.clNull1.DataPropertyName = "null";
            this.clNull1.HeaderText = " --";
            this.clNull1.Name = "clNull1";
            this.clNull1.ReadOnly = true;
            this.clNull1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNull1.Width = 30;
            // 
            // cmsTools
            // 
            this.cmsTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miGenerateRightAnswers});
            this.cmsTools.Name = "cmsTools";
            this.cmsTools.Size = new System.Drawing.Size(159, 26);
            // 
            // miGenerateRightAnswers
            // 
            this.miGenerateRightAnswers.Image = global::WMSOffice.Properties.Resources.accept_16;
            this.miGenerateRightAnswers.Name = "miGenerateRightAnswers";
            this.miGenerateRightAnswers.Size = new System.Drawing.Size(158, 22);
            this.miGenerateRightAnswers.Text = "Автозаполнение";
            this.miGenerateRightAnswers.Click += new System.EventHandler(this.miGenerateRightAnswers_Click);
            // 
            // bsApVersionQuestions1
            // 
            this.bsApVersionQuestions1.DataMember = "AP_Version_Questions";
            this.bsApVersionQuestions1.DataSource = this.quality;
            this.bsApVersionQuestions1.Filter = "[question_type_id] = 1";
            this.bsApVersionQuestions1.Sort = "[order_id]";
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // lblEditingDate1
            // 
            this.lblEditingDate1.AutoSize = true;
            this.lblEditingDate1.Location = new System.Drawing.Point(15, 6);
            this.lblEditingDate1.Name = "lblEditingDate1";
            this.lblEditingDate1.Size = new System.Drawing.Size(143, 13);
            this.lblEditingDate1.TabIndex = 26;
            this.lblEditingDate1.Text = "Дата и время заполнения:";
            // 
            // tbxEditingDate1
            // 
            this.tbxEditingDate1.Location = new System.Drawing.Point(164, 2);
            this.tbxEditingDate1.Name = "tbxEditingDate1";
            this.tbxEditingDate1.ReadOnly = true;
            this.tbxEditingDate1.Size = new System.Drawing.Size(152, 20);
            this.tbxEditingDate1.TabIndex = 27;
            this.tbxEditingDate1.TabStop = false;
            // 
            // tbxUser1
            // 
            this.tbxUser1.Location = new System.Drawing.Point(404, 2);
            this.tbxUser1.Name = "tbxUser1";
            this.tbxUser1.ReadOnly = true;
            this.tbxUser1.Size = new System.Drawing.Size(330, 20);
            this.tbxUser1.TabIndex = 29;
            this.tbxUser1.TabStop = false;
            // 
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.Location = new System.Drawing.Point(339, 6);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(59, 13);
            this.lblUser1.TabIndex = 28;
            this.lblUser1.Text = "Заполнил:";
            // 
            // dgvQuestionGroup2
            // 
            this.dgvQuestionGroup2.AllowUserToAddRows = false;
            this.dgvQuestionGroup2.AllowUserToDeleteRows = false;
            this.dgvQuestionGroup2.AllowUserToResizeRows = false;
            this.dgvQuestionGroup2.AutoGenerateColumns = false;
            this.dgvQuestionGroup2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionGroup2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clShowEditor2,
            this.dataGridViewTextBoxColumn8,
            this.clQuestion2,
            this.clYes2,
            this.clNo2,
            this.clNull2});
            this.dgvQuestionGroup2.ContextMenuStrip = this.cmsTools;
            this.dgvQuestionGroup2.DataSource = this.bsApVersionQuestions2;
            this.dgvQuestionGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionGroup2.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionGroup2.MultiSelect = false;
            this.dgvQuestionGroup2.Name = "dgvQuestionGroup2";
            this.dgvQuestionGroup2.ReadOnly = true;
            this.dgvQuestionGroup2.RowHeadersVisible = false;
            this.dgvQuestionGroup2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionGroup2.Size = new System.Drawing.Size(1153, 111);
            this.dgvQuestionGroup2.TabIndex = 31;
            this.dgvQuestionGroup2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionGroup_CellFormatting);
            this.dgvQuestionGroup2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuestionGroup_DataBindingComplete);
            this.dgvQuestionGroup2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionGroup_CellContentClick);
            // 
            // clShowEditor2
            // 
            this.clShowEditor2.HeaderText = "";
            this.clShowEditor2.Name = "clShowEditor2";
            this.clShowEditor2.ReadOnly = true;
            this.clShowEditor2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clShowEditor2.Width = 25;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "question_type_name";
            this.dataGridViewTextBoxColumn8.HeaderText = "Группа критериев";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 350;
            // 
            // clQuestion2
            // 
            this.clQuestion2.DataPropertyName = "question";
            this.clQuestion2.HeaderText = "Критерий проверки";
            this.clQuestion2.Name = "clQuestion2";
            this.clQuestion2.ReadOnly = true;
            this.clQuestion2.Width = 525;
            // 
            // clYes2
            // 
            this.clYes2.DataPropertyName = "yes";
            this.clYes2.HeaderText = "Да";
            this.clYes2.Name = "clYes2";
            this.clYes2.ReadOnly = true;
            this.clYes2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clYes2.Width = 30;
            // 
            // clNo2
            // 
            this.clNo2.DataPropertyName = "no";
            this.clNo2.HeaderText = "Нет";
            this.clNo2.Name = "clNo2";
            this.clNo2.ReadOnly = true;
            this.clNo2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNo2.Width = 30;
            // 
            // clNull2
            // 
            this.clNull2.DataPropertyName = "null";
            this.clNull2.HeaderText = " --";
            this.clNull2.Name = "clNull2";
            this.clNull2.ReadOnly = true;
            this.clNull2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNull2.Width = 30;
            // 
            // bsApVersionQuestions2
            // 
            this.bsApVersionQuestions2.DataMember = "AP_Version_Questions";
            this.bsApVersionQuestions2.DataSource = this.quality;
            this.bsApVersionQuestions2.Filter = "[question_type_id] = 2";
            this.bsApVersionQuestions2.Sort = "[order_id]";
            // 
            // dgvAttachments
            // 
            this.dgvAttachments.AllowUserToAddRows = false;
            this.dgvAttachments.AllowUserToResizeRows = false;
            this.dgvAttachments.AutoGenerateColumns = false;
            this.dgvAttachments.ColumnHeadersHeight = 20;
            this.dgvAttachments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvAttachments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RowNumber,
            this.fileNameDataGridViewTextBoxColumn,
            this.DirectoryType,
            this.fileLengthDataGridViewTextBoxColumn,
            this.userCreatedDataGridViewTextBoxColumn,
            this.EquipmentType,
            this.EquipmentNumber,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.TermoMode,
            this.clYesT,
            this.clNoT,
            this.clNullT});
            this.dgvAttachments.DataSource = this.aPGetAttachmentsBindingSource;
            this.dgvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachments.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachments.MultiSelect = false;
            this.dgvAttachments.Name = "dgvAttachments";
            this.dgvAttachments.RowHeadersVisible = false;
            this.dgvAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachments.Size = new System.Drawing.Size(1153, 111);
            this.dgvAttachments.TabIndex = 38;
            this.dgvAttachments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAttachments_UserDeletingRow);
            this.dgvAttachments.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachments_CellMouseDoubleClick);
            this.dgvAttachments.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAttachments_EditingControlShowing);
            this.dgvAttachments.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachments_CellEnter);
            this.dgvAttachments.SelectionChanged += new System.EventHandler(this.dgvAttachments_SelectionChanged);
            this.dgvAttachments.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachments_CellContentClick);
            // 
            // aPFileTypesDirectoryBindingSource
            // 
            this.aPFileTypesDirectoryBindingSource.DataMember = "AP_File_Types_Directory";
            this.aPFileTypesDirectoryBindingSource.DataSource = this.quality;
            // 
            // aPEquipmentTypesBindingSource
            // 
            this.aPEquipmentTypesBindingSource.DataMember = "AP_Equipment_Types";
            this.aPEquipmentTypesBindingSource.DataSource = this.quality;
            // 
            // aPTermoModesBindingSource
            // 
            this.aPTermoModesBindingSource.DataMember = "AP_Termo_Modes";
            this.aPTermoModesBindingSource.DataSource = this.quality;
            // 
            // aPGetAttachmentsBindingSource
            // 
            this.aPGetAttachmentsBindingSource.DataMember = "AP_Get_Attachments";
            this.aPGetAttachmentsBindingSource.DataSource = this.quality;
            // 
            // tsAttachments
            // 
            this.tsAttachments.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tsAttachments.Dock = System.Windows.Forms.DockStyle.None;
            this.tsAttachments.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFile,
            this.btnDeleteFile,
            this.btnPreviewFile,
            this.btnSaveFileTemplate});
            this.tsAttachments.Location = new System.Drawing.Point(270, 0);
            this.tsAttachments.Name = "tsAttachments";
            this.tsAttachments.Size = new System.Drawing.Size(102, 25);
            this.tsAttachments.TabIndex = 37;
            this.tsAttachments.Text = "toolStrip1";
            // 
            // btnAddFile
            // 
            this.btnAddFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddFile.Image = global::WMSOffice.Properties.Resources.add;
            this.btnAddFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFile.Name = "btnAddFile";
            this.btnAddFile.Size = new System.Drawing.Size(23, 22);
            this.btnAddFile.Text = "Загрузить файл";
            this.btnAddFile.Click += new System.EventHandler(this.btnAddFile_Click);
            // 
            // btnDeleteFile
            // 
            this.btnDeleteFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteFile.Image = global::WMSOffice.Properties.Resources.Delete;
            this.btnDeleteFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteFile.Name = "btnDeleteFile";
            this.btnDeleteFile.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteFile.Text = "Удалить файл";
            this.btnDeleteFile.Click += new System.EventHandler(this.btnDeleteFile_Click);
            // 
            // btnPreviewFile
            // 
            this.btnPreviewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPreviewFile.Image = global::WMSOffice.Properties.Resources.Search1;
            this.btnPreviewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPreviewFile.Name = "btnPreviewFile";
            this.btnPreviewFile.Size = new System.Drawing.Size(23, 22);
            this.btnPreviewFile.Text = "Просмотр файла";
            this.btnPreviewFile.Click += new System.EventHandler(this.btnPreviewFile_Click);
            // 
            // btnSaveFileTemplate
            // 
            this.btnSaveFileTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveFileTemplate.Image = global::WMSOffice.Properties.Resources.save;
            this.btnSaveFileTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFileTemplate.Name = "btnSaveFileTemplate";
            this.btnSaveFileTemplate.Size = new System.Drawing.Size(23, 22);
            this.btnSaveFileTemplate.Text = "Сохранить шаблон файла";
            this.btnSaveFileTemplate.Click += new System.EventHandler(this.btnSaveFileTemplate_Click);
            // 
            // taApVersionQuestions
            // 
            this.taApVersionQuestions.ClearBeforeFill = true;
            // 
            // taApGetWorksheetReportHeader
            // 
            this.taApGetWorksheetReportHeader.ClearBeforeFill = true;
            // 
            // aP_Get_AttachmentsTableAdapter
            // 
            this.aP_Get_AttachmentsTableAdapter.ClearBeforeFill = true;
            // 
            // aP_Termo_ModesTableAdapter
            // 
            this.aP_Termo_ModesTableAdapter.ClearBeforeFill = true;
            // 
            // tbxCarNumber
            // 
            this.tbxCarNumber.Location = new System.Drawing.Point(98, 31);
            this.tbxCarNumber.Name = "tbxCarNumber";
            this.tbxCarNumber.ReadOnly = true;
            this.tbxCarNumber.Size = new System.Drawing.Size(160, 20);
            this.tbxCarNumber.TabIndex = 3;
            this.tbxCarNumber.TabStop = false;
            // 
            // tbxTrailerNumber
            // 
            this.tbxTrailerNumber.Location = new System.Drawing.Point(98, 57);
            this.tbxTrailerNumber.Name = "tbxTrailerNumber";
            this.tbxTrailerNumber.ReadOnly = true;
            this.tbxTrailerNumber.Size = new System.Drawing.Size(160, 20);
            this.tbxTrailerNumber.TabIndex = 5;
            this.tbxTrailerNumber.TabStop = false;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(15, 35);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(47, 13);
            this.lblCarNumber.TabIndex = 2;
            this.lblCarNumber.Text = "№ авто:";
            // 
            // lblTrailerNumber
            // 
            this.lblTrailerNumber.AutoSize = true;
            this.lblTrailerNumber.Location = new System.Drawing.Point(15, 61);
            this.lblTrailerNumber.Name = "lblTrailerNumber";
            this.lblTrailerNumber.Size = new System.Drawing.Size(77, 13);
            this.lblTrailerNumber.TabIndex = 4;
            this.lblTrailerNumber.Text = "№ п/прицепа:";
            // 
            // tbxLicenseInfo
            // 
            this.tbxLicenseInfo.Location = new System.Drawing.Point(98, 136);
            this.tbxLicenseInfo.Name = "tbxLicenseInfo";
            this.tbxLicenseInfo.ReadOnly = true;
            this.tbxLicenseInfo.Size = new System.Drawing.Size(160, 20);
            this.tbxLicenseInfo.TabIndex = 11;
            this.tbxLicenseInfo.TabStop = false;
            // 
            // lblLicenseInfo
            // 
            this.lblLicenseInfo.AutoSize = true;
            this.lblLicenseInfo.Location = new System.Drawing.Point(15, 140);
            this.lblLicenseInfo.Name = "lblLicenseInfo";
            this.lblLicenseInfo.Size = new System.Drawing.Size(72, 13);
            this.lblLicenseInfo.TabIndex = 10;
            this.lblLicenseInfo.Text = "№ лицензии:";
            // 
            // tbxLicenseStatus
            // 
            this.tbxLicenseStatus.Location = new System.Drawing.Point(476, 137);
            this.tbxLicenseStatus.Name = "tbxLicenseStatus";
            this.tbxLicenseStatus.ReadOnly = true;
            this.tbxLicenseStatus.Size = new System.Drawing.Size(160, 20);
            this.tbxLicenseStatus.TabIndex = 23;
            this.tbxLicenseStatus.TabStop = false;
            // 
            // lblLicenseStatus
            // 
            this.lblLicenseStatus.AutoSize = true;
            this.lblLicenseStatus.Location = new System.Drawing.Point(341, 141);
            this.lblLicenseStatus.Name = "lblLicenseStatus";
            this.lblLicenseStatus.Size = new System.Drawing.Size(95, 13);
            this.lblLicenseStatus.TabIndex = 22;
            this.lblLicenseStatus.Text = "Статус лицензии:";
            // 
            // aP_File_Types_DirectoryTableAdapter
            // 
            this.aP_File_Types_DirectoryTableAdapter.ClearBeforeFill = true;
            // 
            // aP_Equipment_TypesTableAdapter
            // 
            this.aP_Equipment_TypesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "question";
            this.dataGridViewTextBoxColumn1.HeaderText = "Критерий проверки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 500;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "question";
            this.dataGridViewTextBoxColumn2.HeaderText = "Критерий проверки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 700;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "yes";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Да";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.Width = 30;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "no";
            this.dataGridViewCheckBoxColumn2.HeaderText = "Нет";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.ReadOnly = true;
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn2.Width = 30;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "null";
            this.dataGridViewCheckBoxColumn3.HeaderText = " --";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.ReadOnly = true;
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn3.Width = 30;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn2.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RowNmber";
            this.dataGridViewTextBoxColumn3.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 43;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FileName";
            this.dataGridViewTextBoxColumn4.HeaderText = "Файл";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 61;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.DataPropertyName = "yes";
            this.dataGridViewCheckBoxColumn4.HeaderText = "Да";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.ReadOnly = true;
            this.dataGridViewCheckBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn4.Width = 30;
            // 
            // dataGridViewCheckBoxColumn5
            // 
            this.dataGridViewCheckBoxColumn5.DataPropertyName = "no";
            this.dataGridViewCheckBoxColumn5.HeaderText = "Нет";
            this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
            this.dataGridViewCheckBoxColumn5.ReadOnly = true;
            this.dataGridViewCheckBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn5.Width = 30;
            // 
            // dataGridViewCheckBoxColumn6
            // 
            this.dataGridViewCheckBoxColumn6.DataPropertyName = "null";
            this.dataGridViewCheckBoxColumn6.HeaderText = " --";
            this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
            this.dataGridViewCheckBoxColumn6.ReadOnly = true;
            this.dataGridViewCheckBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn6.Width = 30;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FileLength";
            this.dataGridViewTextBoxColumn5.HeaderText = "Размер";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 71;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "UserCreated";
            this.dataGridViewTextBoxColumn6.HeaderText = "Кем загружен";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 104;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "DirectoryType";
            this.dataGridViewComboBoxColumn1.DataSource = this.aPFileTypesDirectoryBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "TypeDesc";
            this.dataGridViewComboBoxColumn1.HeaderText = "Тип файла";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "ID";
            this.dataGridViewComboBoxColumn1.Width = 86;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn7.HeaderText = "Когда загружен";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 113;
            // 
            // dataGridViewComboBoxColumn2
            // 
            this.dataGridViewComboBoxColumn2.DataPropertyName = "EquipmentType";
            this.dataGridViewComboBoxColumn2.DataSource = this.aPEquipmentTypesBindingSource;
            this.dataGridViewComboBoxColumn2.DisplayMember = "TypeDesc";
            this.dataGridViewComboBoxColumn2.HeaderText = "Вид оборудования";
            this.dataGridViewComboBoxColumn2.Name = "dataGridViewComboBoxColumn2";
            this.dataGridViewComboBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn2.ValueMember = "ID";
            this.dataGridViewComboBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "EquipmentNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "Номер оборудования";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.Width = 140;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn10.HeaderText = "Когда загружен";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            this.dataGridViewTextBoxColumn10.Width = 113;
            // 
            // dataGridViewComboBoxColumn3
            // 
            this.dataGridViewComboBoxColumn3.DataPropertyName = "TermoMode";
            this.dataGridViewComboBoxColumn3.DataSource = this.aPTermoModesBindingSource;
            this.dataGridViewComboBoxColumn3.DisplayMember = "Mode_Name";
            this.dataGridViewComboBoxColumn3.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn3.HeaderText = "Режим t, °C";
            this.dataGridViewComboBoxColumn3.Name = "dataGridViewComboBoxColumn3";
            this.dataGridViewComboBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn3.ValueMember = "Mode_Key";
            this.dataGridViewComboBoxColumn3.Width = 90;
            // 
            // tlpMainContent
            // 
            this.tlpMainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMainContent.ColumnCount = 1;
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainContent.Controls.Add(this.pnlQuestionGroup1, 0, 0);
            this.tlpMainContent.Controls.Add(this.pnlQuestionGroup2, 0, 1);
            this.tlpMainContent.Controls.Add(this.pnlAttachments, 0, 2);
            this.tlpMainContent.Controls.Add(this.pnlQuestionGroup4, 0, 3);
            this.tlpMainContent.Location = new System.Drawing.Point(12, 162);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.RowCount = 4;
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlpMainContent.Size = new System.Drawing.Size(1159, 669);
            this.tlpMainContent.TabIndex = 0;
            // 
            // pnlQuestionGroup1
            // 
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Content);
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Footer);
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Header);
            this.pnlQuestionGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup1.Location = new System.Drawing.Point(3, 3);
            this.pnlQuestionGroup1.Name = "pnlQuestionGroup1";
            this.pnlQuestionGroup1.Size = new System.Drawing.Size(1153, 228);
            this.pnlQuestionGroup1.TabIndex = 0;
            // 
            // pnlQuestionGroup1Content
            // 
            this.pnlQuestionGroup1Content.Controls.Add(this.dgvQuestionGroup1);
            this.pnlQuestionGroup1Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup1Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup1Content.Name = "pnlQuestionGroup1Content";
            this.pnlQuestionGroup1Content.Size = new System.Drawing.Size(1153, 178);
            this.pnlQuestionGroup1Content.TabIndex = 2;
            // 
            // pnlQuestionGroup1Footer
            // 
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblUser1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxUser1);
            this.pnlQuestionGroup1Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup1Footer.Location = new System.Drawing.Point(0, 203);
            this.pnlQuestionGroup1Footer.Name = "pnlQuestionGroup1Footer";
            this.pnlQuestionGroup1Footer.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup1Footer.TabIndex = 1;
            // 
            // pnlQuestionGroup1Header
            // 
            this.pnlQuestionGroup1Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlQuestionGroup1Header.Controls.Add(this.lblQuestionGroup1Header);
            this.pnlQuestionGroup1Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup1Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup1Header.Name = "pnlQuestionGroup1Header";
            this.pnlQuestionGroup1Header.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup1Header.TabIndex = 0;
            // 
            // pnlQuestionGroup2
            // 
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Content);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Footer);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Header);
            this.pnlQuestionGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2.Location = new System.Drawing.Point(3, 237);
            this.pnlQuestionGroup2.Name = "pnlQuestionGroup2";
            this.pnlQuestionGroup2.Size = new System.Drawing.Size(1153, 161);
            this.pnlQuestionGroup2.TabIndex = 1;
            // 
            // pnlQuestionGroup2Content
            // 
            this.pnlQuestionGroup2Content.Controls.Add(this.dgvQuestionGroup2);
            this.pnlQuestionGroup2Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup2Content.Name = "pnlQuestionGroup2Content";
            this.pnlQuestionGroup2Content.Size = new System.Drawing.Size(1153, 111);
            this.pnlQuestionGroup2Content.TabIndex = 3;
            // 
            // pnlQuestionGroup2Footer
            // 
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblUser2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxUser2);
            this.pnlQuestionGroup2Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup2Footer.Location = new System.Drawing.Point(0, 136);
            this.pnlQuestionGroup2Footer.Name = "pnlQuestionGroup2Footer";
            this.pnlQuestionGroup2Footer.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup2Footer.TabIndex = 2;
            // 
            // lblEditingDate2
            // 
            this.lblEditingDate2.AutoSize = true;
            this.lblEditingDate2.Location = new System.Drawing.Point(15, 5);
            this.lblEditingDate2.Name = "lblEditingDate2";
            this.lblEditingDate2.Size = new System.Drawing.Size(143, 13);
            this.lblEditingDate2.TabIndex = 26;
            this.lblEditingDate2.Text = "Дата и время заполнения:";
            // 
            // tbxEditingDate2
            // 
            this.tbxEditingDate2.Location = new System.Drawing.Point(164, 2);
            this.tbxEditingDate2.Name = "tbxEditingDate2";
            this.tbxEditingDate2.ReadOnly = true;
            this.tbxEditingDate2.Size = new System.Drawing.Size(152, 20);
            this.tbxEditingDate2.TabIndex = 27;
            this.tbxEditingDate2.TabStop = false;
            // 
            // lblUser2
            // 
            this.lblUser2.AutoSize = true;
            this.lblUser2.Location = new System.Drawing.Point(339, 7);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(59, 13);
            this.lblUser2.TabIndex = 28;
            this.lblUser2.Text = "Заполнил:";
            // 
            // tbxUser2
            // 
            this.tbxUser2.Location = new System.Drawing.Point(404, 3);
            this.tbxUser2.Name = "tbxUser2";
            this.tbxUser2.ReadOnly = true;
            this.tbxUser2.Size = new System.Drawing.Size(330, 20);
            this.tbxUser2.TabIndex = 29;
            this.tbxUser2.TabStop = false;
            // 
            // pnlQuestionGroup2Header
            // 
            this.pnlQuestionGroup2Header.BackColor = System.Drawing.SystemColors.Control;
            this.pnlQuestionGroup2Header.Controls.Add(this.lblQuestionGroup2Header);
            this.pnlQuestionGroup2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup2Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup2Header.Name = "pnlQuestionGroup2Header";
            this.pnlQuestionGroup2Header.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup2Header.TabIndex = 1;
            // 
            // lblQuestionGroup2Header
            // 
            this.lblQuestionGroup2Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblQuestionGroup2Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionGroup2Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionGroup2Header.Location = new System.Drawing.Point(0, 0);
            this.lblQuestionGroup2Header.Name = "lblQuestionGroup2Header";
            this.lblQuestionGroup2Header.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblQuestionGroup2Header.Size = new System.Drawing.Size(1153, 25);
            this.lblQuestionGroup2Header.TabIndex = 24;
            this.lblQuestionGroup2Header.Text = "Проверка комплектности документов по поставке:";
            // 
            // pnlAttachments
            // 
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsContent);
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsHeader);
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsFooter);
            this.pnlAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachments.Location = new System.Drawing.Point(3, 404);
            this.pnlAttachments.Name = "pnlAttachments";
            this.pnlAttachments.Size = new System.Drawing.Size(1153, 161);
            this.pnlAttachments.TabIndex = 2;
            // 
            // pnlAttachmentsContent
            // 
            this.pnlAttachmentsContent.Controls.Add(this.dgvAttachments);
            this.pnlAttachmentsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachmentsContent.Location = new System.Drawing.Point(0, 25);
            this.pnlAttachmentsContent.Name = "pnlAttachmentsContent";
            this.pnlAttachmentsContent.Size = new System.Drawing.Size(1153, 111);
            this.pnlAttachmentsContent.TabIndex = 29;
            // 
            // pnlAttachmentsHeader
            // 
            this.pnlAttachmentsHeader.Controls.Add(this.tsAttachments);
            this.pnlAttachmentsHeader.Controls.Add(this.lblAttachmentsHeader);
            this.pnlAttachmentsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttachmentsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachmentsHeader.Name = "pnlAttachmentsHeader";
            this.pnlAttachmentsHeader.Size = new System.Drawing.Size(1153, 25);
            this.pnlAttachmentsHeader.TabIndex = 28;
            // 
            // lblAttachmentsHeader
            // 
            this.lblAttachmentsHeader.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblAttachmentsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAttachmentsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAttachmentsHeader.Location = new System.Drawing.Point(0, 0);
            this.lblAttachmentsHeader.Name = "lblAttachmentsHeader";
            this.lblAttachmentsHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblAttachmentsHeader.Size = new System.Drawing.Size(1153, 25);
            this.lblAttachmentsHeader.TabIndex = 24;
            this.lblAttachmentsHeader.Text = "Показания температуры по поставке:";
            // 
            // pnlAttachmentsFooter
            // 
            this.pnlAttachmentsFooter.Controls.Add(this.lblEditingDate3);
            this.pnlAttachmentsFooter.Controls.Add(this.tbxEditingDate3);
            this.pnlAttachmentsFooter.Controls.Add(this.lblUser3);
            this.pnlAttachmentsFooter.Controls.Add(this.tbxUser3);
            this.pnlAttachmentsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAttachmentsFooter.Location = new System.Drawing.Point(0, 136);
            this.pnlAttachmentsFooter.Name = "pnlAttachmentsFooter";
            this.pnlAttachmentsFooter.Size = new System.Drawing.Size(1153, 25);
            this.pnlAttachmentsFooter.TabIndex = 27;
            // 
            // lblEditingDate3
            // 
            this.lblEditingDate3.AutoSize = true;
            this.lblEditingDate3.Location = new System.Drawing.Point(15, 5);
            this.lblEditingDate3.Name = "lblEditingDate3";
            this.lblEditingDate3.Size = new System.Drawing.Size(143, 13);
            this.lblEditingDate3.TabIndex = 26;
            this.lblEditingDate3.Text = "Дата и время заполнения:";
            // 
            // tbxEditingDate3
            // 
            this.tbxEditingDate3.Location = new System.Drawing.Point(164, 2);
            this.tbxEditingDate3.Name = "tbxEditingDate3";
            this.tbxEditingDate3.ReadOnly = true;
            this.tbxEditingDate3.Size = new System.Drawing.Size(152, 20);
            this.tbxEditingDate3.TabIndex = 27;
            this.tbxEditingDate3.TabStop = false;
            // 
            // lblUser3
            // 
            this.lblUser3.AutoSize = true;
            this.lblUser3.Location = new System.Drawing.Point(339, 7);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(59, 13);
            this.lblUser3.TabIndex = 28;
            this.lblUser3.Text = "Заполнил:";
            // 
            // tbxUser3
            // 
            this.tbxUser3.Location = new System.Drawing.Point(404, 3);
            this.tbxUser3.Name = "tbxUser3";
            this.tbxUser3.ReadOnly = true;
            this.tbxUser3.Size = new System.Drawing.Size(330, 20);
            this.tbxUser3.TabIndex = 29;
            this.tbxUser3.TabStop = false;
            // 
            // pnlQuestionGroup4
            // 
            this.pnlQuestionGroup4.Controls.Add(this.pnlQuestionGroup4Content);
            this.pnlQuestionGroup4.Controls.Add(this.pnlQuestionGroup4Header);
            this.pnlQuestionGroup4.Controls.Add(this.pnlQuestionGroup4Footer);
            this.pnlQuestionGroup4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup4.Location = new System.Drawing.Point(3, 571);
            this.pnlQuestionGroup4.Name = "pnlQuestionGroup4";
            this.pnlQuestionGroup4.Size = new System.Drawing.Size(1153, 95);
            this.pnlQuestionGroup4.TabIndex = 3;
            // 
            // pnlQuestionGroup4Content
            // 
            this.pnlQuestionGroup4Content.Controls.Add(this.dgvQuestionGroup4);
            this.pnlQuestionGroup4Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup4Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup4Content.Name = "pnlQuestionGroup4Content";
            this.pnlQuestionGroup4Content.Size = new System.Drawing.Size(1153, 45);
            this.pnlQuestionGroup4Content.TabIndex = 33;
            // 
            // dgvQuestionGroup4
            // 
            this.dgvQuestionGroup4.AllowUserToAddRows = false;
            this.dgvQuestionGroup4.AllowUserToDeleteRows = false;
            this.dgvQuestionGroup4.AllowUserToResizeRows = false;
            this.dgvQuestionGroup4.AutoGenerateColumns = false;
            this.dgvQuestionGroup4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionGroup4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clShowEditor4,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.clYes4,
            this.clNo4,
            this.clNull4});
            this.dgvQuestionGroup4.ContextMenuStrip = this.cmsTools;
            this.dgvQuestionGroup4.DataSource = this.bsApVersionQuestions4;
            this.dgvQuestionGroup4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionGroup4.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionGroup4.MultiSelect = false;
            this.dgvQuestionGroup4.Name = "dgvQuestionGroup4";
            this.dgvQuestionGroup4.ReadOnly = true;
            this.dgvQuestionGroup4.RowHeadersVisible = false;
            this.dgvQuestionGroup4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionGroup4.Size = new System.Drawing.Size(1153, 45);
            this.dgvQuestionGroup4.TabIndex = 32;
            this.dgvQuestionGroup4.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionGroup_CellFormatting);
            this.dgvQuestionGroup4.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuestionGroup_DataBindingComplete);
            this.dgvQuestionGroup4.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionGroup_CellContentClick);
            // 
            // clShowEditor4
            // 
            this.clShowEditor4.HeaderText = "";
            this.clShowEditor4.Name = "clShowEditor4";
            this.clShowEditor4.ReadOnly = true;
            this.clShowEditor4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clShowEditor4.Width = 25;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "question_type_name";
            this.dataGridViewTextBoxColumn11.HeaderText = "Группа критериев";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 350;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "question";
            this.dataGridViewTextBoxColumn12.HeaderText = "Критерий проверки";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 525;
            // 
            // clYes4
            // 
            this.clYes4.DataPropertyName = "yes";
            this.clYes4.HeaderText = "Да";
            this.clYes4.Name = "clYes4";
            this.clYes4.ReadOnly = true;
            this.clYes4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clYes4.Width = 30;
            // 
            // clNo4
            // 
            this.clNo4.DataPropertyName = "no";
            this.clNo4.HeaderText = "Нет";
            this.clNo4.Name = "clNo4";
            this.clNo4.ReadOnly = true;
            this.clNo4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNo4.Width = 30;
            // 
            // clNull4
            // 
            this.clNull4.DataPropertyName = "null";
            this.clNull4.HeaderText = " --";
            this.clNull4.Name = "clNull4";
            this.clNull4.ReadOnly = true;
            this.clNull4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNull4.Width = 30;
            // 
            // bsApVersionQuestions4
            // 
            this.bsApVersionQuestions4.DataMember = "AP_Version_Questions";
            this.bsApVersionQuestions4.DataSource = this.quality;
            this.bsApVersionQuestions4.Filter = "[question_type_id] = 4";
            this.bsApVersionQuestions4.Sort = "[order_id]";
            // 
            // pnlQuestionGroup4Header
            // 
            this.pnlQuestionGroup4Header.Controls.Add(this.lblQuestionGroup4Header);
            this.pnlQuestionGroup4Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup4Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup4Header.Name = "pnlQuestionGroup4Header";
            this.pnlQuestionGroup4Header.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup4Header.TabIndex = 29;
            // 
            // lblQuestionGroup4Header
            // 
            this.lblQuestionGroup4Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblQuestionGroup4Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionGroup4Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionGroup4Header.Location = new System.Drawing.Point(0, 0);
            this.lblQuestionGroup4Header.Name = "lblQuestionGroup4Header";
            this.lblQuestionGroup4Header.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblQuestionGroup4Header.Size = new System.Drawing.Size(1153, 25);
            this.lblQuestionGroup4Header.TabIndex = 24;
            this.lblQuestionGroup4Header.Text = "Показания к разгрузке поставки:";
            // 
            // pnlQuestionGroup4Footer
            // 
            this.pnlQuestionGroup4Footer.Controls.Add(this.lblEditingDate4);
            this.pnlQuestionGroup4Footer.Controls.Add(this.tbxEditingDate4);
            this.pnlQuestionGroup4Footer.Controls.Add(this.lblUser4);
            this.pnlQuestionGroup4Footer.Controls.Add(this.tbxUser4);
            this.pnlQuestionGroup4Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup4Footer.Location = new System.Drawing.Point(0, 70);
            this.pnlQuestionGroup4Footer.Name = "pnlQuestionGroup4Footer";
            this.pnlQuestionGroup4Footer.Size = new System.Drawing.Size(1153, 25);
            this.pnlQuestionGroup4Footer.TabIndex = 26;
            // 
            // lblEditingDate4
            // 
            this.lblEditingDate4.AutoSize = true;
            this.lblEditingDate4.Location = new System.Drawing.Point(15, 5);
            this.lblEditingDate4.Name = "lblEditingDate4";
            this.lblEditingDate4.Size = new System.Drawing.Size(143, 13);
            this.lblEditingDate4.TabIndex = 26;
            this.lblEditingDate4.Text = "Дата и время заполнения:";
            // 
            // tbxEditingDate4
            // 
            this.tbxEditingDate4.Location = new System.Drawing.Point(164, 2);
            this.tbxEditingDate4.Name = "tbxEditingDate4";
            this.tbxEditingDate4.ReadOnly = true;
            this.tbxEditingDate4.Size = new System.Drawing.Size(152, 20);
            this.tbxEditingDate4.TabIndex = 27;
            this.tbxEditingDate4.TabStop = false;
            // 
            // lblUser4
            // 
            this.lblUser4.AutoSize = true;
            this.lblUser4.Location = new System.Drawing.Point(339, 7);
            this.lblUser4.Name = "lblUser4";
            this.lblUser4.Size = new System.Drawing.Size(59, 13);
            this.lblUser4.TabIndex = 28;
            this.lblUser4.Text = "Заполнил:";
            // 
            // tbxUser4
            // 
            this.tbxUser4.Location = new System.Drawing.Point(404, 3);
            this.tbxUser4.Name = "tbxUser4";
            this.tbxUser4.ReadOnly = true;
            this.tbxUser4.Size = new System.Drawing.Size(330, 20);
            this.tbxUser4.TabIndex = 29;
            this.tbxUser4.TabStop = false;
            // 
            // RowNumber
            // 
            this.RowNumber.DataPropertyName = "RowNumber";
            this.RowNumber.HeaderText = "№";
            this.RowNumber.Name = "RowNumber";
            this.RowNumber.ReadOnly = true;
            this.RowNumber.Width = 25;
            // 
            // fileNameDataGridViewTextBoxColumn
            // 
            this.fileNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fileNameDataGridViewTextBoxColumn.DataPropertyName = "FileName";
            this.fileNameDataGridViewTextBoxColumn.HeaderText = "Файл";
            this.fileNameDataGridViewTextBoxColumn.Name = "fileNameDataGridViewTextBoxColumn";
            this.fileNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileNameDataGridViewTextBoxColumn.Width = 61;
            // 
            // DirectoryType
            // 
            this.DirectoryType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DirectoryType.DataPropertyName = "DirectoryType";
            this.DirectoryType.DataSource = this.aPFileTypesDirectoryBindingSource;
            this.DirectoryType.DisplayMember = "TypeDesc";
            this.DirectoryType.HeaderText = "Тип файла";
            this.DirectoryType.Name = "DirectoryType";
            this.DirectoryType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.DirectoryType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.DirectoryType.ValueMember = "ID";
            this.DirectoryType.Width = 86;
            // 
            // fileLengthDataGridViewTextBoxColumn
            // 
            this.fileLengthDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.fileLengthDataGridViewTextBoxColumn.DataPropertyName = "FileLength";
            this.fileLengthDataGridViewTextBoxColumn.HeaderText = "Размер";
            this.fileLengthDataGridViewTextBoxColumn.Name = "fileLengthDataGridViewTextBoxColumn";
            this.fileLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.fileLengthDataGridViewTextBoxColumn.Width = 71;
            // 
            // userCreatedDataGridViewTextBoxColumn
            // 
            this.userCreatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userCreatedDataGridViewTextBoxColumn.DataPropertyName = "UserCreated";
            this.userCreatedDataGridViewTextBoxColumn.HeaderText = "Кем загружен";
            this.userCreatedDataGridViewTextBoxColumn.Name = "userCreatedDataGridViewTextBoxColumn";
            this.userCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.userCreatedDataGridViewTextBoxColumn.Width = 104;
            // 
            // EquipmentType
            // 
            this.EquipmentType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EquipmentType.DataPropertyName = "EquipmentType";
            this.EquipmentType.DataSource = this.aPEquipmentTypesBindingSource;
            this.EquipmentType.DisplayMember = "TypeDesc";
            this.EquipmentType.HeaderText = "Вид оборудования";
            this.EquipmentType.Name = "EquipmentType";
            this.EquipmentType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EquipmentType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.EquipmentType.ValueMember = "ID";
            this.EquipmentType.Width = 125;
            // 
            // EquipmentNumber
            // 
            this.EquipmentNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EquipmentNumber.DataPropertyName = "EquipmentNumber";
            this.EquipmentNumber.HeaderText = "Номер оборудования";
            this.EquipmentNumber.Name = "EquipmentNumber";
            this.EquipmentNumber.Width = 140;
            // 
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Когда загружен";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateCreatedDataGridViewTextBoxColumn.Visible = false;
            this.dateCreatedDataGridViewTextBoxColumn.Width = 113;
            // 
            // TermoMode
            // 
            this.TermoMode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TermoMode.DataPropertyName = "TermoMode";
            this.TermoMode.DataSource = this.aPTermoModesBindingSource;
            this.TermoMode.DisplayMember = "Mode_Name";
            this.TermoMode.DisplayStyleForCurrentCellOnly = true;
            this.TermoMode.HeaderText = "Режим t, °C";
            this.TermoMode.Name = "TermoMode";
            this.TermoMode.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TermoMode.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TermoMode.ValueMember = "Mode_Key";
            this.TermoMode.Width = 90;
            // 
            // clYesT
            // 
            this.clYesT.DataPropertyName = "Yes";
            this.clYesT.HeaderText = "Да";
            this.clYesT.Name = "clYesT";
            this.clYesT.ReadOnly = true;
            this.clYesT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clYesT.Width = 30;
            // 
            // clNoT
            // 
            this.clNoT.DataPropertyName = "No";
            this.clNoT.HeaderText = "Нет";
            this.clNoT.Name = "clNoT";
            this.clNoT.ReadOnly = true;
            this.clNoT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNoT.Width = 30;
            // 
            // clNullT
            // 
            this.clNullT.DataPropertyName = "Null";
            this.clNullT.HeaderText = "--";
            this.clNullT.Name = "clNullT";
            this.clNullT.ReadOnly = true;
            this.clNullT.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clNullT.Width = 30;
            // 
            // EditInputControlDeliveryWorksheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1182, 863);
            this.Controls.Add(this.tlpMainContent);
            this.Controls.Add(this.tbxLicenseStatus);
            this.Controls.Add(this.lblLicenseStatus);
            this.Controls.Add(this.tbxLicenseInfo);
            this.Controls.Add(this.lblLicenseInfo);
            this.Controls.Add(this.lblTrailerNumber);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.tbxTrailerNumber);
            this.Controls.Add(this.tbxCarNumber);
            this.Controls.Add(this.tbxVersionUser);
            this.Controls.Add(this.lblVersionUser);
            this.Controls.Add(this.tbxVersionStatus);
            this.Controls.Add(this.lblVersionStatus);
            this.Controls.Add(this.tbxVersionDate);
            this.Controls.Add(this.tbxDocDate);
            this.Controls.Add(this.lblVersionDate);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.tbxVendor);
            this.Controls.Add(this.lblVendor);
            this.Controls.Add(this.tbxVersionNumber);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.tbxDocNumber);
            this.Controls.Add(this.lblDocNumber);
            this.Controls.Add(this.tbxDeliveryID);
            this.Controls.Add(this.lblDeliveryID);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "EditInputControlDeliveryWorksheetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование анкеты";
            this.Load += new System.EventHandler(this.EditInputControlDeliveryWorksheetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup1)).EndInit();
            this.cmsTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPFileTypesDirectoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPEquipmentTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPTermoModesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetAttachmentsBindingSource)).EndInit();
            this.tsAttachments.ResumeLayout(false);
            this.tsAttachments.PerformLayout();
            this.tlpMainContent.ResumeLayout(false);
            this.pnlQuestionGroup1.ResumeLayout(false);
            this.pnlQuestionGroup1Content.ResumeLayout(false);
            this.pnlQuestionGroup1Footer.ResumeLayout(false);
            this.pnlQuestionGroup1Footer.PerformLayout();
            this.pnlQuestionGroup1Header.ResumeLayout(false);
            this.pnlQuestionGroup2.ResumeLayout(false);
            this.pnlQuestionGroup2Content.ResumeLayout(false);
            this.pnlQuestionGroup2Footer.ResumeLayout(false);
            this.pnlQuestionGroup2Footer.PerformLayout();
            this.pnlQuestionGroup2Header.ResumeLayout(false);
            this.pnlAttachments.ResumeLayout(false);
            this.pnlAttachmentsContent.ResumeLayout(false);
            this.pnlAttachmentsHeader.ResumeLayout(false);
            this.pnlAttachmentsHeader.PerformLayout();
            this.pnlAttachmentsFooter.ResumeLayout(false);
            this.pnlAttachmentsFooter.PerformLayout();
            this.pnlQuestionGroup4.ResumeLayout(false);
            this.pnlQuestionGroup4Content.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions4)).EndInit();
            this.pnlQuestionGroup4Header.ResumeLayout(false);
            this.pnlQuestionGroup4Footer.ResumeLayout(false);
            this.pnlQuestionGroup4Footer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDeliveryID;
        private System.Windows.Forms.TextBox tbxDeliveryID;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.TextBox tbxDocNumber;
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.TextBox tbxVersionNumber;
        private System.Windows.Forms.Label lblVendor;
        private System.Windows.Forms.TextBox tbxVendor;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Label lblVersionDate;
        private System.Windows.Forms.TextBox tbxDocDate;
        private System.Windows.Forms.TextBox tbxVersionDate;
        private System.Windows.Forms.Label lblVersionStatus;
        private System.Windows.Forms.TextBox tbxVersionStatus;
        private System.Windows.Forms.Label lblVersionUser;
        private System.Windows.Forms.TextBox tbxVersionUser;
        private System.Windows.Forms.Label lblQuestionGroup1Header;
        private System.Windows.Forms.DataGridView dgvQuestionGroup1;
        private System.Windows.Forms.BindingSource bsApVersionQuestions1;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AP_Version_QuestionsTableAdapter taApVersionQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.Label lblEditingDate1;
        private System.Windows.Forms.TextBox tbxEditingDate1;
        private System.Windows.Forms.TextBox tbxUser1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.DataGridView dgvQuestionGroup2;
        private System.Windows.Forms.BindingSource bsApVersionQuestions2;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_Worksheet_Report_HeaderTableAdapter taApGetWorksheetReportHeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn2;
        private System.Windows.Forms.DataGridView dgvAttachments;
        private System.Windows.Forms.ToolStrip tsAttachments;
        private System.Windows.Forms.ToolStripButton btnAddFile;
        private System.Windows.Forms.ToolStripButton btnDeleteFile;
        private System.Windows.Forms.ToolStripButton btnPreviewFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource aPGetAttachmentsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter aP_Get_AttachmentsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNmberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripButton btnSaveFileTemplate;
        private System.Windows.Forms.ContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem miGenerateRightAnswers;
        private System.Windows.Forms.BindingSource aPTermoModesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Termo_ModesTableAdapter aP_Termo_ModesTableAdapter;
        private System.Windows.Forms.TextBox tbxCarNumber;
        private System.Windows.Forms.TextBox tbxTrailerNumber;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.Label lblTrailerNumber;
        private System.Windows.Forms.TextBox tbxLicenseInfo;
        private System.Windows.Forms.Label lblLicenseInfo;
        private System.Windows.Forms.TextBox tbxLicenseStatus;
        private System.Windows.Forms.Label lblLicenseStatus;
        private System.Windows.Forms.BindingSource aPFileTypesDirectoryBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_File_Types_DirectoryTableAdapter aP_File_Types_DirectoryTableAdapter;
        private System.Windows.Forms.BindingSource aPEquipmentTypesBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Equipment_TypesTableAdapter aP_Equipment_TypesTableAdapter;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn3;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Panel pnlQuestionGroup1;
        private System.Windows.Forms.Panel pnlQuestionGroup1Footer;
        private System.Windows.Forms.Panel pnlQuestionGroup1Header;
        private System.Windows.Forms.Panel pnlQuestionGroup2;
        private System.Windows.Forms.Panel pnlAttachments;
        private System.Windows.Forms.Panel pnlQuestionGroup4;
        private System.Windows.Forms.Panel pnlQuestionGroup1Content;
        private System.Windows.Forms.Panel pnlQuestionGroup2Header;
        private System.Windows.Forms.Label lblQuestionGroup2Header;
        private System.Windows.Forms.Panel pnlQuestionGroup2Content;
        private System.Windows.Forms.Panel pnlQuestionGroup2Footer;
        private System.Windows.Forms.Label lblEditingDate2;
        private System.Windows.Forms.TextBox tbxEditingDate2;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.TextBox tbxUser2;
        private System.Windows.Forms.Panel pnlAttachmentsFooter;
        private System.Windows.Forms.Label lblEditingDate3;
        private System.Windows.Forms.TextBox tbxEditingDate3;
        private System.Windows.Forms.Label lblUser3;
        private System.Windows.Forms.TextBox tbxUser3;
        private System.Windows.Forms.Panel pnlQuestionGroup4Footer;
        private System.Windows.Forms.Label lblEditingDate4;
        private System.Windows.Forms.TextBox tbxEditingDate4;
        private System.Windows.Forms.Label lblUser4;
        private System.Windows.Forms.TextBox tbxUser4;
        private System.Windows.Forms.Panel pnlAttachmentsContent;
        private System.Windows.Forms.Panel pnlAttachmentsHeader;
        private System.Windows.Forms.Label lblAttachmentsHeader;
        private System.Windows.Forms.Panel pnlQuestionGroup4Header;
        private System.Windows.Forms.Label lblQuestionGroup4Header;
        private System.Windows.Forms.DataGridView dgvQuestionGroup4;
        private System.Windows.Forms.BindingSource bsApVersionQuestions4;
        private System.Windows.Forms.DataGridViewButtonColumn clShowEditor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn question_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuestion1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clYes1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNo1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNull1;
        private System.Windows.Forms.DataGridViewButtonColumn clShowEditor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn clQuestion2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clYes2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNo2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNull2;
        private System.Windows.Forms.Panel pnlQuestionGroup4Content;
        private System.Windows.Forms.DataGridViewButtonColumn clShowEditor4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clYes4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNo4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNull4;
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DirectoryType;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn EquipmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn EquipmentNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TermoMode;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clYesT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNoT;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clNullT;
    }
}