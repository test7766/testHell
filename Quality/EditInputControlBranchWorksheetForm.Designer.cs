namespace WMSOffice.Dialogs.Quality
{
    partial class EditInputControlBranchWorksheetForm
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
            this.lblRouteListNumber = new System.Windows.Forms.Label();
            this.tbxRouteListNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.tbxDocNumber = new System.Windows.Forms.TextBox();
            this.lblVersionNumber = new System.Windows.Forms.Label();
            this.tbxVersionNumber = new System.Windows.Forms.TextBox();
            this.lblFilialFrom = new System.Windows.Forms.Label();
            this.tbxFilialFrom = new System.Windows.Forms.TextBox();
            this.lblFilialTo = new System.Windows.Forms.Label();
            this.lblVersionDate = new System.Windows.Forms.Label();
            this.tbxFilialTo = new System.Windows.Forms.TextBox();
            this.tbxVersionDate = new System.Windows.Forms.TextBox();
            this.lblVersionStatus = new System.Windows.Forms.Label();
            this.tbxVersionStatus = new System.Windows.Forms.TextBox();
            this.lblVersionUser = new System.Windows.Forms.Label();
            this.tbxVersionUser = new System.Windows.Forms.TextBox();
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
            this.dgvQuestionGroup2 = new System.Windows.Forms.DataGridView();
            this.clShowEditor2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuestion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bsApVersionQuestions2 = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAttachments = new System.Windows.Forms.DataGridView();
            this.RowNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateCreatedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TermoMode = new System.Windows.Forms.DataGridViewComboBoxColumn();
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
            this.lblCarNumber = new System.Windows.Forms.Label();
            this.tbxTrailerNumber = new System.Windows.Forms.TextBox();
            this.lblTrailerNumber = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewButtonColumn2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuestionGroup1 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Content = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Footer = new System.Windows.Forms.Panel();
            this.lblEditingDate1 = new System.Windows.Forms.Label();
            this.tbxEditingDate1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.tbxUser1 = new System.Windows.Forms.TextBox();
            this.pnlQuestionGroup1Header = new System.Windows.Forms.Panel();
            this.lblQuestionGroup1Header = new System.Windows.Forms.Label();
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
            this.pnlAttachmentsFooter = new System.Windows.Forms.Panel();
            this.lblEditingDate3 = new System.Windows.Forms.Label();
            this.tbxEditingDate3 = new System.Windows.Forms.TextBox();
            this.lblUser3 = new System.Windows.Forms.Label();
            this.tbxUser3 = new System.Windows.Forms.TextBox();
            this.pnlAttachmentsHeader = new System.Windows.Forms.Panel();
            this.lblAttachmentsHeader = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup1)).BeginInit();
            this.cmsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttachments)).BeginInit();
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
            this.pnlAttachmentsFooter.SuspendLayout();
            this.pnlAttachmentsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1095, 837);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1014, 837);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblRouteListNumber
            // 
            this.lblRouteListNumber.AutoSize = true;
            this.lblRouteListNumber.Location = new System.Drawing.Point(12, 10);
            this.lblRouteListNumber.Name = "lblRouteListNumber";
            this.lblRouteListNumber.Size = new System.Drawing.Size(102, 13);
            this.lblRouteListNumber.TabIndex = 0;
            this.lblRouteListNumber.Text = "№ МЛ (межсклад):";
            // 
            // tbxRouteListNumber
            // 
            this.tbxRouteListNumber.Location = new System.Drawing.Point(120, 6);
            this.tbxRouteListNumber.Name = "tbxRouteListNumber";
            this.tbxRouteListNumber.ReadOnly = true;
            this.tbxRouteListNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxRouteListNumber.TabIndex = 1;
            this.tbxRouteListNumber.TabStop = false;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(13, 88);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(61, 13);
            this.lblDocNumber.TabIndex = 6;
            this.lblDocNumber.Text = "№ анкеты:";
            // 
            // tbxDocNumber
            // 
            this.tbxDocNumber.Location = new System.Drawing.Point(120, 84);
            this.tbxDocNumber.Name = "tbxDocNumber";
            this.tbxDocNumber.ReadOnly = true;
            this.tbxDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxDocNumber.TabIndex = 7;
            this.tbxDocNumber.TabStop = false;
            // 
            // lblVersionNumber
            // 
            this.lblVersionNumber.AutoSize = true;
            this.lblVersionNumber.Location = new System.Drawing.Point(12, 114);
            this.lblVersionNumber.Name = "lblVersionNumber";
            this.lblVersionNumber.Size = new System.Drawing.Size(60, 13);
            this.lblVersionNumber.TabIndex = 8;
            this.lblVersionNumber.Text = "№ версии:";
            // 
            // tbxVersionNumber
            // 
            this.tbxVersionNumber.Location = new System.Drawing.Point(120, 110);
            this.tbxVersionNumber.Name = "tbxVersionNumber";
            this.tbxVersionNumber.ReadOnly = true;
            this.tbxVersionNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxVersionNumber.TabIndex = 9;
            this.tbxVersionNumber.TabStop = false;
            // 
            // lblFilialFrom
            // 
            this.lblFilialFrom.AutoSize = true;
            this.lblFilialFrom.Location = new System.Drawing.Point(273, 10);
            this.lblFilialFrom.Name = "lblFilialFrom";
            this.lblFilialFrom.Size = new System.Drawing.Size(124, 13);
            this.lblFilialFrom.TabIndex = 10;
            this.lblFilialFrom.Text = "Филиал (отправитель):";
            // 
            // tbxFilialFrom
            // 
            this.tbxFilialFrom.Location = new System.Drawing.Point(408, 6);
            this.tbxFilialFrom.Name = "tbxFilialFrom";
            this.tbxFilialFrom.ReadOnly = true;
            this.tbxFilialFrom.Size = new System.Drawing.Size(330, 20);
            this.tbxFilialFrom.TabIndex = 11;
            this.tbxFilialFrom.TabStop = false;
            // 
            // lblFilialTo
            // 
            this.lblFilialTo.AutoSize = true;
            this.lblFilialTo.Location = new System.Drawing.Point(273, 36);
            this.lblFilialTo.Name = "lblFilialTo";
            this.lblFilialTo.Size = new System.Drawing.Size(117, 13);
            this.lblFilialTo.TabIndex = 12;
            this.lblFilialTo.Text = "Филиал (получатель):";
            // 
            // lblVersionDate
            // 
            this.lblVersionDate.AutoSize = true;
            this.lblVersionDate.Location = new System.Drawing.Point(273, 62);
            this.lblVersionDate.Name = "lblVersionDate";
            this.lblVersionDate.Size = new System.Drawing.Size(120, 13);
            this.lblVersionDate.TabIndex = 14;
            this.lblVersionDate.Text = "Дата и время анкеты:";
            // 
            // tbxFilialTo
            // 
            this.tbxFilialTo.Location = new System.Drawing.Point(408, 32);
            this.tbxFilialTo.Name = "tbxFilialTo";
            this.tbxFilialTo.ReadOnly = true;
            this.tbxFilialTo.Size = new System.Drawing.Size(330, 20);
            this.tbxFilialTo.TabIndex = 13;
            this.tbxFilialTo.TabStop = false;
            // 
            // tbxVersionDate
            // 
            this.tbxVersionDate.Location = new System.Drawing.Point(408, 58);
            this.tbxVersionDate.Name = "tbxVersionDate";
            this.tbxVersionDate.ReadOnly = true;
            this.tbxVersionDate.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionDate.TabIndex = 15;
            this.tbxVersionDate.TabStop = false;
            // 
            // lblVersionStatus
            // 
            this.lblVersionStatus.AutoSize = true;
            this.lblVersionStatus.Location = new System.Drawing.Point(273, 114);
            this.lblVersionStatus.Name = "lblVersionStatus";
            this.lblVersionStatus.Size = new System.Drawing.Size(64, 13);
            this.lblVersionStatus.TabIndex = 18;
            this.lblVersionStatus.Text = "Ст. версии:";
            // 
            // tbxVersionStatus
            // 
            this.tbxVersionStatus.Location = new System.Drawing.Point(408, 110);
            this.tbxVersionStatus.Name = "tbxVersionStatus";
            this.tbxVersionStatus.ReadOnly = true;
            this.tbxVersionStatus.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionStatus.TabIndex = 19;
            this.tbxVersionStatus.TabStop = false;
            // 
            // lblVersionUser
            // 
            this.lblVersionUser.AutoSize = true;
            this.lblVersionUser.Location = new System.Drawing.Point(273, 88);
            this.lblVersionUser.Name = "lblVersionUser";
            this.lblVersionUser.Size = new System.Drawing.Size(79, 13);
            this.lblVersionUser.TabIndex = 16;
            this.lblVersionUser.Text = "Автор версии:";
            // 
            // tbxVersionUser
            // 
            this.tbxVersionUser.Location = new System.Drawing.Point(408, 84);
            this.tbxVersionUser.Name = "tbxVersionUser";
            this.tbxVersionUser.ReadOnly = true;
            this.tbxVersionUser.Size = new System.Drawing.Size(330, 20);
            this.tbxVersionUser.TabIndex = 17;
            this.tbxVersionUser.TabStop = false;
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
            this.dgvQuestionGroup1.Size = new System.Drawing.Size(1148, 256);
            this.dgvQuestionGroup1.TabIndex = 10;
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
            this.bsApVersionQuestions1.Filter = "[question_type_id] IN (2, 4)";
            this.bsApVersionQuestions1.Sort = "[order_id]";
            // 
            // quality
            // 
            this.quality.DataSetName = "Quality";
            this.quality.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            this.dgvQuestionGroup2.Size = new System.Drawing.Size(1148, 187);
            this.dgvQuestionGroup2.TabIndex = 20;
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
            this.bsApVersionQuestions2.Filter = "[question_type_id] IN (1, 3)";
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
            this.fileLengthDataGridViewTextBoxColumn,
            this.userCreatedDataGridViewTextBoxColumn,
            this.dateCreatedDataGridViewTextBoxColumn,
            this.TermoMode});
            this.dgvAttachments.DataSource = this.aPGetAttachmentsBindingSource;
            this.dgvAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttachments.Location = new System.Drawing.Point(0, 0);
            this.dgvAttachments.MultiSelect = false;
            this.dgvAttachments.Name = "dgvAttachments";
            this.dgvAttachments.RowHeadersVisible = false;
            this.dgvAttachments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAttachments.Size = new System.Drawing.Size(1148, 84);
            this.dgvAttachments.TabIndex = 41;
            this.dgvAttachments.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvAttachments_UserDeletingRow);
            this.dgvAttachments.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttachments_CellMouseDoubleClick);
            this.dgvAttachments.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvAttachments_EditingControlShowing);
            this.dgvAttachments.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttachments_CellEnter);
            this.dgvAttachments.SelectionChanged += new System.EventHandler(this.dgvAttachments_SelectionChanged);
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
            // dateCreatedDataGridViewTextBoxColumn
            // 
            this.dateCreatedDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateCreatedDataGridViewTextBoxColumn.DataPropertyName = "DateCreated";
            this.dateCreatedDataGridViewTextBoxColumn.HeaderText = "Когда загружен";
            this.dateCreatedDataGridViewTextBoxColumn.Name = "dateCreatedDataGridViewTextBoxColumn";
            this.dateCreatedDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.tsAttachments.TabIndex = 43;
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
            this.tbxCarNumber.Location = new System.Drawing.Point(120, 32);
            this.tbxCarNumber.Name = "tbxCarNumber";
            this.tbxCarNumber.ReadOnly = true;
            this.tbxCarNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxCarNumber.TabIndex = 3;
            this.tbxCarNumber.TabStop = false;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(12, 36);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(47, 13);
            this.lblCarNumber.TabIndex = 2;
            this.lblCarNumber.Text = "№ авто:";
            // 
            // tbxTrailerNumber
            // 
            this.tbxTrailerNumber.Location = new System.Drawing.Point(120, 58);
            this.tbxTrailerNumber.Name = "tbxTrailerNumber";
            this.tbxTrailerNumber.ReadOnly = true;
            this.tbxTrailerNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxTrailerNumber.TabIndex = 5;
            this.tbxTrailerNumber.TabStop = false;
            // 
            // lblTrailerNumber
            // 
            this.lblTrailerNumber.AutoSize = true;
            this.lblTrailerNumber.Location = new System.Drawing.Point(13, 62);
            this.lblTrailerNumber.Name = "lblTrailerNumber";
            this.lblTrailerNumber.Size = new System.Drawing.Size(77, 13);
            this.lblTrailerNumber.TabIndex = 4;
            this.lblTrailerNumber.Text = "№ п/прицепа:";
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
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.HeaderText = "";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            this.dataGridViewButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn1.Width = 30;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "RowNmber";
            this.dataGridViewTextBoxColumn3.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 43;
            // 
            // dataGridViewButtonColumn2
            // 
            this.dataGridViewButtonColumn2.HeaderText = "";
            this.dataGridViewButtonColumn2.Name = "dataGridViewButtonColumn2";
            this.dataGridViewButtonColumn2.ReadOnly = true;
            this.dataGridViewButtonColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewButtonColumn2.Width = 30;
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
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn7.HeaderText = "Когда загружен";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 113;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn9.HeaderText = "Когда загружен";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 113;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.DataPropertyName = "TermoMode";
            this.dataGridViewComboBoxColumn1.DataSource = this.aPTermoModesBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "Mode_Name";
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.HeaderText = "Режим t, °C";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "Mode_Key";
            this.dataGridViewComboBoxColumn1.Width = 90;
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
            this.tlpMainContent.Location = new System.Drawing.Point(16, 136);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.RowCount = 3;
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpMainContent.Size = new System.Drawing.Size(1154, 695);
            this.tlpMainContent.TabIndex = 48;
            // 
            // pnlQuestionGroup1
            // 
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Content);
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Footer);
            this.pnlQuestionGroup1.Controls.Add(this.pnlQuestionGroup1Header);
            this.pnlQuestionGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup1.Location = new System.Drawing.Point(3, 3);
            this.pnlQuestionGroup1.Name = "pnlQuestionGroup1";
            this.pnlQuestionGroup1.Size = new System.Drawing.Size(1148, 306);
            this.pnlQuestionGroup1.TabIndex = 0;
            // 
            // pnlQuestionGroup1Content
            // 
            this.pnlQuestionGroup1Content.Controls.Add(this.dgvQuestionGroup1);
            this.pnlQuestionGroup1Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup1Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup1Content.Name = "pnlQuestionGroup1Content";
            this.pnlQuestionGroup1Content.Size = new System.Drawing.Size(1148, 256);
            this.pnlQuestionGroup1Content.TabIndex = 3;
            // 
            // pnlQuestionGroup1Footer
            // 
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblUser1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxUser1);
            this.pnlQuestionGroup1Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup1Footer.Location = new System.Drawing.Point(0, 281);
            this.pnlQuestionGroup1Footer.Name = "pnlQuestionGroup1Footer";
            this.pnlQuestionGroup1Footer.Size = new System.Drawing.Size(1148, 25);
            this.pnlQuestionGroup1Footer.TabIndex = 2;
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
            // lblUser1
            // 
            this.lblUser1.AutoSize = true;
            this.lblUser1.Location = new System.Drawing.Point(339, 6);
            this.lblUser1.Name = "lblUser1";
            this.lblUser1.Size = new System.Drawing.Size(59, 13);
            this.lblUser1.TabIndex = 28;
            this.lblUser1.Text = "Заполнил:";
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
            // pnlQuestionGroup1Header
            // 
            this.pnlQuestionGroup1Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlQuestionGroup1Header.Controls.Add(this.lblQuestionGroup1Header);
            this.pnlQuestionGroup1Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup1Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup1Header.Name = "pnlQuestionGroup1Header";
            this.pnlQuestionGroup1Header.Size = new System.Drawing.Size(1148, 25);
            this.pnlQuestionGroup1Header.TabIndex = 1;
            // 
            // lblQuestionGroup1Header
            // 
            this.lblQuestionGroup1Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblQuestionGroup1Header.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblQuestionGroup1Header.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblQuestionGroup1Header.Location = new System.Drawing.Point(0, 0);
            this.lblQuestionGroup1Header.Name = "lblQuestionGroup1Header";
            this.lblQuestionGroup1Header.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblQuestionGroup1Header.Size = new System.Drawing.Size(1148, 25);
            this.lblQuestionGroup1Header.TabIndex = 24;
            this.lblQuestionGroup1Header.Text = "Проверка условий транспортировки поставки:";
            // 
            // pnlQuestionGroup2
            // 
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Content);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Footer);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Header);
            this.pnlQuestionGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2.Location = new System.Drawing.Point(3, 315);
            this.pnlQuestionGroup2.Name = "pnlQuestionGroup2";
            this.pnlQuestionGroup2.Size = new System.Drawing.Size(1148, 237);
            this.pnlQuestionGroup2.TabIndex = 1;
            // 
            // pnlQuestionGroup2Content
            // 
            this.pnlQuestionGroup2Content.Controls.Add(this.dgvQuestionGroup2);
            this.pnlQuestionGroup2Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup2Content.Name = "pnlQuestionGroup2Content";
            this.pnlQuestionGroup2Content.Size = new System.Drawing.Size(1148, 187);
            this.pnlQuestionGroup2Content.TabIndex = 3;
            // 
            // pnlQuestionGroup2Footer
            // 
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblUser2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxUser2);
            this.pnlQuestionGroup2Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup2Footer.Location = new System.Drawing.Point(0, 212);
            this.pnlQuestionGroup2Footer.Name = "pnlQuestionGroup2Footer";
            this.pnlQuestionGroup2Footer.Size = new System.Drawing.Size(1148, 25);
            this.pnlQuestionGroup2Footer.TabIndex = 2;
            // 
            // lblEditingDate2
            // 
            this.lblEditingDate2.AutoSize = true;
            this.lblEditingDate2.Location = new System.Drawing.Point(15, 6);
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
            this.lblUser2.Location = new System.Drawing.Point(339, 6);
            this.lblUser2.Name = "lblUser2";
            this.lblUser2.Size = new System.Drawing.Size(59, 13);
            this.lblUser2.TabIndex = 28;
            this.lblUser2.Text = "Заполнил:";
            // 
            // tbxUser2
            // 
            this.tbxUser2.Location = new System.Drawing.Point(404, 2);
            this.tbxUser2.Name = "tbxUser2";
            this.tbxUser2.ReadOnly = true;
            this.tbxUser2.Size = new System.Drawing.Size(330, 20);
            this.tbxUser2.TabIndex = 29;
            this.tbxUser2.TabStop = false;
            // 
            // pnlQuestionGroup2Header
            // 
            this.pnlQuestionGroup2Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlQuestionGroup2Header.Controls.Add(this.lblQuestionGroup2Header);
            this.pnlQuestionGroup2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup2Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup2Header.Name = "pnlQuestionGroup2Header";
            this.pnlQuestionGroup2Header.Size = new System.Drawing.Size(1148, 25);
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
            this.lblQuestionGroup2Header.Size = new System.Drawing.Size(1148, 25);
            this.lblQuestionGroup2Header.TabIndex = 24;
            this.lblQuestionGroup2Header.Text = "Проверка комплектности документов по поставке:";
            // 
            // pnlAttachments
            // 
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsContent);
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsFooter);
            this.pnlAttachments.Controls.Add(this.pnlAttachmentsHeader);
            this.pnlAttachments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachments.Location = new System.Drawing.Point(3, 558);
            this.pnlAttachments.Name = "pnlAttachments";
            this.pnlAttachments.Size = new System.Drawing.Size(1148, 134);
            this.pnlAttachments.TabIndex = 2;
            // 
            // pnlAttachmentsContent
            // 
            this.pnlAttachmentsContent.Controls.Add(this.dgvAttachments);
            this.pnlAttachmentsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAttachmentsContent.Location = new System.Drawing.Point(0, 25);
            this.pnlAttachmentsContent.Name = "pnlAttachmentsContent";
            this.pnlAttachmentsContent.Size = new System.Drawing.Size(1148, 84);
            this.pnlAttachmentsContent.TabIndex = 3;
            // 
            // pnlAttachmentsFooter
            // 
            this.pnlAttachmentsFooter.Controls.Add(this.lblEditingDate3);
            this.pnlAttachmentsFooter.Controls.Add(this.tbxEditingDate3);
            this.pnlAttachmentsFooter.Controls.Add(this.lblUser3);
            this.pnlAttachmentsFooter.Controls.Add(this.tbxUser3);
            this.pnlAttachmentsFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAttachmentsFooter.Location = new System.Drawing.Point(0, 109);
            this.pnlAttachmentsFooter.Name = "pnlAttachmentsFooter";
            this.pnlAttachmentsFooter.Size = new System.Drawing.Size(1148, 25);
            this.pnlAttachmentsFooter.TabIndex = 2;
            // 
            // lblEditingDate3
            // 
            this.lblEditingDate3.AutoSize = true;
            this.lblEditingDate3.Location = new System.Drawing.Point(15, 6);
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
            this.lblUser3.Location = new System.Drawing.Point(339, 6);
            this.lblUser3.Name = "lblUser3";
            this.lblUser3.Size = new System.Drawing.Size(59, 13);
            this.lblUser3.TabIndex = 28;
            this.lblUser3.Text = "Заполнил:";
            // 
            // tbxUser3
            // 
            this.tbxUser3.Location = new System.Drawing.Point(404, 2);
            this.tbxUser3.Name = "tbxUser3";
            this.tbxUser3.ReadOnly = true;
            this.tbxUser3.Size = new System.Drawing.Size(330, 20);
            this.tbxUser3.TabIndex = 29;
            this.tbxUser3.TabStop = false;
            // 
            // pnlAttachmentsHeader
            // 
            this.pnlAttachmentsHeader.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlAttachmentsHeader.Controls.Add(this.tsAttachments);
            this.pnlAttachmentsHeader.Controls.Add(this.lblAttachmentsHeader);
            this.pnlAttachmentsHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAttachmentsHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlAttachmentsHeader.Name = "pnlAttachmentsHeader";
            this.pnlAttachmentsHeader.Size = new System.Drawing.Size(1148, 25);
            this.pnlAttachmentsHeader.TabIndex = 1;
            // 
            // lblAttachmentsHeader
            // 
            this.lblAttachmentsHeader.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblAttachmentsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAttachmentsHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAttachmentsHeader.Location = new System.Drawing.Point(0, 0);
            this.lblAttachmentsHeader.Name = "lblAttachmentsHeader";
            this.lblAttachmentsHeader.Padding = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.lblAttachmentsHeader.Size = new System.Drawing.Size(1148, 25);
            this.lblAttachmentsHeader.TabIndex = 24;
            this.lblAttachmentsHeader.Text = "Показания температуры по поставке:";
            // 
            // EditInputControlBranchWorksheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1182, 863);
            this.Controls.Add(this.tlpMainContent);
            this.Controls.Add(this.lblTrailerNumber);
            this.Controls.Add(this.tbxTrailerNumber);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.tbxCarNumber);
            this.Controls.Add(this.tbxVersionUser);
            this.Controls.Add(this.lblVersionUser);
            this.Controls.Add(this.tbxVersionStatus);
            this.Controls.Add(this.lblVersionStatus);
            this.Controls.Add(this.tbxVersionDate);
            this.Controls.Add(this.tbxFilialTo);
            this.Controls.Add(this.lblVersionDate);
            this.Controls.Add(this.lblFilialTo);
            this.Controls.Add(this.tbxFilialFrom);
            this.Controls.Add(this.lblFilialFrom);
            this.Controls.Add(this.lblVersionNumber);
            this.Controls.Add(this.tbxVersionNumber);
            this.Controls.Add(this.tbxDocNumber);
            this.Controls.Add(this.lblDocNumber);
            this.Controls.Add(this.lblRouteListNumber);
            this.Controls.Add(this.tbxRouteListNumber);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Name = "EditInputControlBranchWorksheetForm";
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
            this.pnlAttachmentsFooter.ResumeLayout(false);
            this.pnlAttachmentsFooter.PerformLayout();
            this.pnlAttachmentsHeader.ResumeLayout(false);
            this.pnlAttachmentsHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblRouteListNumber;
        private System.Windows.Forms.TextBox tbxRouteListNumber;
        private System.Windows.Forms.Label lblDocNumber;
        private System.Windows.Forms.TextBox tbxDocNumber;
        private System.Windows.Forms.Label lblVersionNumber;
        private System.Windows.Forms.TextBox tbxVersionNumber;
        private System.Windows.Forms.Label lblFilialFrom;
        private System.Windows.Forms.TextBox tbxFilialFrom;
        private System.Windows.Forms.Label lblFilialTo;
        private System.Windows.Forms.Label lblVersionDate;
        private System.Windows.Forms.TextBox tbxFilialTo;
        private System.Windows.Forms.TextBox tbxVersionDate;
        private System.Windows.Forms.Label lblVersionStatus;
        private System.Windows.Forms.TextBox tbxVersionStatus;
        private System.Windows.Forms.Label lblVersionUser;
        private System.Windows.Forms.TextBox tbxVersionUser;
        private System.Windows.Forms.DataGridView dgvQuestionGroup1;
        private System.Windows.Forms.BindingSource bsApVersionQuestions1;
        private WMSOffice.Data.Quality quality;
        private WMSOffice.Data.QualityTableAdapters.AP_Version_QuestionsTableAdapter taApVersionQuestions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
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
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.TextBox tbxTrailerNumber;
        private System.Windows.Forms.Label lblTrailerNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Panel pnlQuestionGroup1;
        private System.Windows.Forms.Panel pnlQuestionGroup2;
        private System.Windows.Forms.Panel pnlAttachments;
        private System.Windows.Forms.Panel pnlQuestionGroup1Header;
        private System.Windows.Forms.Label lblQuestionGroup1Header;
        private System.Windows.Forms.Panel pnlQuestionGroup2Header;
        private System.Windows.Forms.Label lblQuestionGroup2Header;
        private System.Windows.Forms.Panel pnlAttachmentsHeader;
        private System.Windows.Forms.Label lblAttachmentsHeader;
        private System.Windows.Forms.Panel pnlQuestionGroup1Footer;
        private System.Windows.Forms.Label lblEditingDate1;
        private System.Windows.Forms.TextBox tbxEditingDate1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.TextBox tbxUser1;
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
        private System.Windows.Forms.Panel pnlQuestionGroup1Content;
        private System.Windows.Forms.Panel pnlQuestionGroup2Content;
        private System.Windows.Forms.Panel pnlAttachmentsContent;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn RowNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateCreatedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn TermoMode;
    }
}