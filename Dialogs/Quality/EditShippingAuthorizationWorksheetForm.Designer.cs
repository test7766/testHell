namespace WMSOffice.Dialogs.Quality
{
    partial class EditShippingAuthorizationWorksheetForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblRouteListNumber = new System.Windows.Forms.Label();
            this.tbxRouteListNumber = new System.Windows.Forms.TextBox();
            this.lblDocNumber = new System.Windows.Forms.Label();
            this.tbxDocNumber = new System.Windows.Forms.TextBox();
            this.lblDriver = new System.Windows.Forms.Label();
            this.tbxDriver = new System.Windows.Forms.TextBox();
            this.lblDocDate = new System.Windows.Forms.Label();
            this.lblVersionDate = new System.Windows.Forms.Label();
            this.tbxDocDate = new System.Windows.Forms.TextBox();
            this.tbxVersionDate = new System.Windows.Forms.TextBox();
            this.dgvQuestionGroup1 = new System.Windows.Forms.DataGridView();
            this.cmsTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miGenerateRightAnswers = new System.Windows.Forms.ToolStripMenuItem();
            this.bsApVersionQuestions1 = new System.Windows.Forms.BindingSource(this.components);
            this.quality = new WMSOffice.Data.Quality();
            this.dgvQuestionGroup2 = new System.Windows.Forms.DataGridView();
            this.bsApVersionQuestions2 = new System.Windows.Forms.BindingSource(this.components);
            this.tbxDocStatus = new System.Windows.Forms.TextBox();
            this.lblDocStatus = new System.Windows.Forms.Label();
            this.tbxCarNumber = new System.Windows.Forms.TextBox();
            this.lblCarNumber = new System.Windows.Forms.Label();
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
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aPGetAttachmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.taApVersionQuestions = new WMSOffice.Data.QualityTableAdapters.AP_Version_QuestionsTableAdapter();
            this.taApGetWorksheetReportHeader = new WMSOffice.Data.QualityTableAdapters.AP_Get_Worksheet_Report_HeaderTableAdapter();
            this.aP_Get_AttachmentsTableAdapter = new WMSOffice.Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter();
            this.lblTrailerNumber = new System.Windows.Forms.Label();
            this.tbxTrailerNumber = new System.Windows.Forms.TextBox();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlQuestionGroup1 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup2 = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup1Header = new System.Windows.Forms.Panel();
            this.lblQuestionGroup1Header = new System.Windows.Forms.Label();
            this.pnlQuestionGroup2Header = new System.Windows.Forms.Panel();
            this.lblQuestionGroup2Header = new System.Windows.Forms.Label();
            this.pnlQuestionGroup1Footer = new System.Windows.Forms.Panel();
            this.lblEditingDate1 = new System.Windows.Forms.Label();
            this.tbxEditingDate1 = new System.Windows.Forms.TextBox();
            this.lblUser1 = new System.Windows.Forms.Label();
            this.tbxUser1 = new System.Windows.Forms.TextBox();
            this.pnlQuestionGroup1Content = new System.Windows.Forms.Panel();
            this.pnlQuestionGroup2Footer = new System.Windows.Forms.Panel();
            this.lblEditingDate2 = new System.Windows.Forms.Label();
            this.tbxEditingDate2 = new System.Windows.Forms.TextBox();
            this.lblUser2 = new System.Windows.Forms.Label();
            this.tbxUser2 = new System.Windows.Forms.TextBox();
            this.pnlQuestionGroup2Content = new System.Windows.Forms.Panel();
            this.clShowEditor1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.question_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuestion1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clShowEditor2 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clQuestion2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clYes2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNo2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clNull2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup1)).BeginInit();
            this.cmsTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetAttachmentsBindingSource)).BeginInit();
            this.tlpMainContent.SuspendLayout();
            this.pnlQuestionGroup1.SuspendLayout();
            this.pnlQuestionGroup2.SuspendLayout();
            this.pnlQuestionGroup1Header.SuspendLayout();
            this.pnlQuestionGroup2Header.SuspendLayout();
            this.pnlQuestionGroup1Footer.SuspendLayout();
            this.pnlQuestionGroup1Content.SuspendLayout();
            this.pnlQuestionGroup2Footer.SuspendLayout();
            this.pnlQuestionGroup2Content.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(1095, 830);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1014, 830);
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
            this.lblRouteListNumber.Location = new System.Drawing.Point(12, 9);
            this.lblRouteListNumber.Name = "lblRouteListNumber";
            this.lblRouteListNumber.Size = new System.Drawing.Size(64, 13);
            this.lblRouteListNumber.TabIndex = 0;
            this.lblRouteListNumber.Text = "Номер МЛ:";
            // 
            // tbxRouteListNumber
            // 
            this.tbxRouteListNumber.Location = new System.Drawing.Point(118, 5);
            this.tbxRouteListNumber.Name = "tbxRouteListNumber";
            this.tbxRouteListNumber.ReadOnly = true;
            this.tbxRouteListNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxRouteListNumber.TabIndex = 1;
            this.tbxRouteListNumber.TabStop = false;
            // 
            // lblDocNumber
            // 
            this.lblDocNumber.AutoSize = true;
            this.lblDocNumber.Location = new System.Drawing.Point(12, 96);
            this.lblDocNumber.Name = "lblDocNumber";
            this.lblDocNumber.Size = new System.Drawing.Size(84, 13);
            this.lblDocNumber.TabIndex = 6;
            this.lblDocNumber.Text = "Номер анкеты:";
            // 
            // tbxDocNumber
            // 
            this.tbxDocNumber.Location = new System.Drawing.Point(118, 92);
            this.tbxDocNumber.Name = "tbxDocNumber";
            this.tbxDocNumber.ReadOnly = true;
            this.tbxDocNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxDocNumber.TabIndex = 7;
            this.tbxDocNumber.TabStop = false;
            // 
            // lblDriver
            // 
            this.lblDriver.AutoSize = true;
            this.lblDriver.Location = new System.Drawing.Point(273, 9);
            this.lblDriver.Name = "lblDriver";
            this.lblDriver.Size = new System.Drawing.Size(88, 13);
            this.lblDriver.TabIndex = 8;
            this.lblDriver.Text = "ФИО Водителя:";
            // 
            // tbxDriver
            // 
            this.tbxDriver.Location = new System.Drawing.Point(418, 5);
            this.tbxDriver.Name = "tbxDriver";
            this.tbxDriver.ReadOnly = true;
            this.tbxDriver.Size = new System.Drawing.Size(373, 20);
            this.tbxDriver.TabIndex = 9;
            this.tbxDriver.TabStop = false;
            // 
            // lblDocDate
            // 
            this.lblDocDate.AutoSize = true;
            this.lblDocDate.Location = new System.Drawing.Point(273, 38);
            this.lblDocDate.Name = "lblDocDate";
            this.lblDocDate.Size = new System.Drawing.Size(127, 13);
            this.lblDocDate.TabIndex = 10;
            this.lblDocDate.Text = "Дата создания анкеты:";
            // 
            // lblVersionDate
            // 
            this.lblVersionDate.AutoSize = true;
            this.lblVersionDate.Location = new System.Drawing.Point(273, 67);
            this.lblVersionDate.Name = "lblVersionDate";
            this.lblVersionDate.Size = new System.Drawing.Size(139, 13);
            this.lblVersionDate.TabIndex = 12;
            this.lblVersionDate.Text = "Дата заполнения анкеты:";
            // 
            // tbxDocDate
            // 
            this.tbxDocDate.Location = new System.Drawing.Point(418, 34);
            this.tbxDocDate.Name = "tbxDocDate";
            this.tbxDocDate.ReadOnly = true;
            this.tbxDocDate.Size = new System.Drawing.Size(160, 20);
            this.tbxDocDate.TabIndex = 11;
            this.tbxDocDate.TabStop = false;
            // 
            // tbxVersionDate
            // 
            this.tbxVersionDate.Location = new System.Drawing.Point(418, 63);
            this.tbxVersionDate.Name = "tbxVersionDate";
            this.tbxVersionDate.ReadOnly = true;
            this.tbxVersionDate.Size = new System.Drawing.Size(160, 20);
            this.tbxVersionDate.TabIndex = 13;
            this.tbxVersionDate.TabStop = false;
            // 
            // dgvQuestionGroup1
            // 
            this.dgvQuestionGroup1.AllowUserToAddRows = false;
            this.dgvQuestionGroup1.AllowUserToDeleteRows = false;
            this.dgvQuestionGroup1.AllowUserToResizeRows = false;
            this.dgvQuestionGroup1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestionGroup1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuestionGroup1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvQuestionGroup1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionGroup1.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionGroup1.MultiSelect = false;
            this.dgvQuestionGroup1.Name = "dgvQuestionGroup1";
            this.dgvQuestionGroup1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestionGroup1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvQuestionGroup1.RowHeadersVisible = false;
            this.dgvQuestionGroup1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionGroup1.Size = new System.Drawing.Size(1149, 367);
            this.dgvQuestionGroup1.TabIndex = 10;
            this.dgvQuestionGroup1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionGroup_CellFormatting);
            this.dgvQuestionGroup1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuestionGroup_DataBindingComplete);
            this.dgvQuestionGroup1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionGroup_CellContentClick);
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
            this.bsApVersionQuestions1.Filter = "[question_type_id] IN (1, 2)";
            this.bsApVersionQuestions1.Sort = "[question_type_id],[order_id]";
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestionGroup2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuestionGroup2.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQuestionGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionGroup2.Location = new System.Drawing.Point(0, 0);
            this.dgvQuestionGroup2.MultiSelect = false;
            this.dgvQuestionGroup2.Name = "dgvQuestionGroup2";
            this.dgvQuestionGroup2.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuestionGroup2.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvQuestionGroup2.RowHeadersVisible = false;
            this.dgvQuestionGroup2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuestionGroup2.Size = new System.Drawing.Size(1149, 227);
            this.dgvQuestionGroup2.TabIndex = 20;
            this.dgvQuestionGroup2.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionGroup_CellFormatting);
            this.dgvQuestionGroup2.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvQuestionGroup_DataBindingComplete);
            this.dgvQuestionGroup2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuestionGroup_CellContentClick);
            // 
            // bsApVersionQuestions2
            // 
            this.bsApVersionQuestions2.DataMember = "AP_Version_Questions";
            this.bsApVersionQuestions2.DataSource = this.quality;
            this.bsApVersionQuestions2.Filter = "[question_type_id] IN (3)";
            this.bsApVersionQuestions2.Sort = "[question_type_id], [order_id]";
            // 
            // tbxDocStatus
            // 
            this.tbxDocStatus.Location = new System.Drawing.Point(418, 92);
            this.tbxDocStatus.Name = "tbxDocStatus";
            this.tbxDocStatus.ReadOnly = true;
            this.tbxDocStatus.Size = new System.Drawing.Size(160, 20);
            this.tbxDocStatus.TabIndex = 15;
            this.tbxDocStatus.TabStop = false;
            // 
            // lblDocStatus
            // 
            this.lblDocStatus.AutoSize = true;
            this.lblDocStatus.Location = new System.Drawing.Point(273, 96);
            this.lblDocStatus.Name = "lblDocStatus";
            this.lblDocStatus.Size = new System.Drawing.Size(65, 13);
            this.lblDocStatus.TabIndex = 14;
            this.lblDocStatus.Text = "Ст. анкеты:";
            // 
            // tbxCarNumber
            // 
            this.tbxCarNumber.Location = new System.Drawing.Point(118, 34);
            this.tbxCarNumber.Name = "tbxCarNumber";
            this.tbxCarNumber.ReadOnly = true;
            this.tbxCarNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxCarNumber.TabIndex = 3;
            this.tbxCarNumber.TabStop = false;
            // 
            // lblCarNumber
            // 
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(12, 38);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new System.Drawing.Size(70, 13);
            this.lblCarNumber.TabIndex = 2;
            this.lblCarNumber.Text = "Номер авто:";
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
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "DateCreated";
            this.dataGridViewTextBoxColumn7.HeaderText = "Когда загружен";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 113;
            // 
            // aPGetAttachmentsBindingSource
            // 
            this.aPGetAttachmentsBindingSource.DataMember = "AP_Get_Attachments";
            this.aPGetAttachmentsBindingSource.DataSource = this.quality;
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
            // lblTrailerNumber
            // 
            this.lblTrailerNumber.AutoSize = true;
            this.lblTrailerNumber.Location = new System.Drawing.Point(12, 67);
            this.lblTrailerNumber.Name = "lblTrailerNumber";
            this.lblTrailerNumber.Size = new System.Drawing.Size(100, 13);
            this.lblTrailerNumber.TabIndex = 4;
            this.lblTrailerNumber.Text = "Номер п/прицепа:";
            // 
            // tbxTrailerNumber
            // 
            this.tbxTrailerNumber.Location = new System.Drawing.Point(118, 63);
            this.tbxTrailerNumber.Name = "tbxTrailerNumber";
            this.tbxTrailerNumber.ReadOnly = true;
            this.tbxTrailerNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxTrailerNumber.TabIndex = 5;
            this.tbxTrailerNumber.TabStop = false;
            // 
            // tlpMainContent
            // 
            this.tlpMainContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMainContent.ColumnCount = 1;
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMainContent.Controls.Add(this.pnlQuestionGroup1, 0, 0);
            this.tlpMainContent.Controls.Add(this.pnlQuestionGroup2, 0, 1);
            this.tlpMainContent.Location = new System.Drawing.Point(15, 118);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.RowCount = 2;
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMainContent.Size = new System.Drawing.Size(1155, 706);
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
            this.pnlQuestionGroup1.Size = new System.Drawing.Size(1149, 417);
            this.pnlQuestionGroup1.TabIndex = 0;
            // 
            // pnlQuestionGroup2
            // 
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Content);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Footer);
            this.pnlQuestionGroup2.Controls.Add(this.pnlQuestionGroup2Header);
            this.pnlQuestionGroup2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2.Location = new System.Drawing.Point(3, 426);
            this.pnlQuestionGroup2.Name = "pnlQuestionGroup2";
            this.pnlQuestionGroup2.Size = new System.Drawing.Size(1149, 277);
            this.pnlQuestionGroup2.TabIndex = 1;
            // 
            // pnlQuestionGroup1Header
            // 
            this.pnlQuestionGroup1Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlQuestionGroup1Header.Controls.Add(this.lblQuestionGroup1Header);
            this.pnlQuestionGroup1Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup1Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup1Header.Name = "pnlQuestionGroup1Header";
            this.pnlQuestionGroup1Header.Size = new System.Drawing.Size(1149, 25);
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
            this.lblQuestionGroup1Header.Size = new System.Drawing.Size(1149, 25);
            this.lblQuestionGroup1Header.TabIndex = 24;
            this.lblQuestionGroup1Header.Text = "Проверка условий транспортировки:";
            // 
            // pnlQuestionGroup2Header
            // 
            this.pnlQuestionGroup2Header.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnlQuestionGroup2Header.Controls.Add(this.lblQuestionGroup2Header);
            this.pnlQuestionGroup2Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQuestionGroup2Header.Location = new System.Drawing.Point(0, 0);
            this.pnlQuestionGroup2Header.Name = "pnlQuestionGroup2Header";
            this.pnlQuestionGroup2Header.Size = new System.Drawing.Size(1149, 25);
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
            this.lblQuestionGroup2Header.Size = new System.Drawing.Size(1149, 25);
            this.lblQuestionGroup2Header.TabIndex = 24;
            this.lblQuestionGroup2Header.Text = "Проверка комплектности документов:";
            // 
            // pnlQuestionGroup1Footer
            // 
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxEditingDate1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.lblUser1);
            this.pnlQuestionGroup1Footer.Controls.Add(this.tbxUser1);
            this.pnlQuestionGroup1Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup1Footer.Location = new System.Drawing.Point(0, 392);
            this.pnlQuestionGroup1Footer.Name = "pnlQuestionGroup1Footer";
            this.pnlQuestionGroup1Footer.Size = new System.Drawing.Size(1149, 25);
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
            // pnlQuestionGroup1Content
            // 
            this.pnlQuestionGroup1Content.Controls.Add(this.dgvQuestionGroup1);
            this.pnlQuestionGroup1Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup1Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup1Content.Name = "pnlQuestionGroup1Content";
            this.pnlQuestionGroup1Content.Size = new System.Drawing.Size(1149, 367);
            this.pnlQuestionGroup1Content.TabIndex = 3;
            // 
            // pnlQuestionGroup2Footer
            // 
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxEditingDate2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.lblUser2);
            this.pnlQuestionGroup2Footer.Controls.Add(this.tbxUser2);
            this.pnlQuestionGroup2Footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlQuestionGroup2Footer.Location = new System.Drawing.Point(0, 252);
            this.pnlQuestionGroup2Footer.Name = "pnlQuestionGroup2Footer";
            this.pnlQuestionGroup2Footer.Size = new System.Drawing.Size(1149, 25);
            this.pnlQuestionGroup2Footer.TabIndex = 3;
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
            // pnlQuestionGroup2Content
            // 
            this.pnlQuestionGroup2Content.Controls.Add(this.dgvQuestionGroup2);
            this.pnlQuestionGroup2Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQuestionGroup2Content.Location = new System.Drawing.Point(0, 25);
            this.pnlQuestionGroup2Content.Name = "pnlQuestionGroup2Content";
            this.pnlQuestionGroup2Content.Size = new System.Drawing.Size(1149, 227);
            this.pnlQuestionGroup2Content.TabIndex = 4;
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
            // EditShippingAuthorizationWorksheetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1182, 863);
            this.Controls.Add(this.tlpMainContent);
            this.Controls.Add(this.tbxTrailerNumber);
            this.Controls.Add(this.lblTrailerNumber);
            this.Controls.Add(this.tbxCarNumber);
            this.Controls.Add(this.lblCarNumber);
            this.Controls.Add(this.tbxDocStatus);
            this.Controls.Add(this.lblDocStatus);
            this.Controls.Add(this.tbxVersionDate);
            this.Controls.Add(this.tbxDocDate);
            this.Controls.Add(this.lblVersionDate);
            this.Controls.Add(this.lblDocDate);
            this.Controls.Add(this.tbxDriver);
            this.Controls.Add(this.lblDriver);
            this.Controls.Add(this.tbxDocNumber);
            this.Controls.Add(this.lblDocNumber);
            this.Controls.Add(this.tbxRouteListNumber);
            this.Controls.Add(this.lblRouteListNumber);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "EditShippingAuthorizationWorksheetForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование анкеты";
            this.Load += new System.EventHandler(this.EditInputControlDeliveryWorksheetForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditShippingAuthorizationWorksheetForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup1)).EndInit();
            this.cmsTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsApVersionQuestions2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPGetAttachmentsBindingSource)).EndInit();
            this.tlpMainContent.ResumeLayout(false);
            this.pnlQuestionGroup1.ResumeLayout(false);
            this.pnlQuestionGroup2.ResumeLayout(false);
            this.pnlQuestionGroup1Header.ResumeLayout(false);
            this.pnlQuestionGroup2Header.ResumeLayout(false);
            this.pnlQuestionGroup1Footer.ResumeLayout(false);
            this.pnlQuestionGroup1Footer.PerformLayout();
            this.pnlQuestionGroup1Content.ResumeLayout(false);
            this.pnlQuestionGroup2Footer.ResumeLayout(false);
            this.pnlQuestionGroup2Footer.PerformLayout();
            this.pnlQuestionGroup2Content.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblDriver;
        private System.Windows.Forms.TextBox tbxDriver;
        private System.Windows.Forms.Label lblDocDate;
        private System.Windows.Forms.Label lblVersionDate;
        private System.Windows.Forms.TextBox tbxDocDate;
        private System.Windows.Forms.TextBox tbxVersionDate;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource aPGetAttachmentsBindingSource;
        private WMSOffice.Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter aP_Get_AttachmentsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNmberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.TextBox tbxDocStatus;
        private System.Windows.Forms.Label lblDocStatus;
        private System.Windows.Forms.TextBox tbxCarNumber;
        private System.Windows.Forms.Label lblCarNumber;
        private System.Windows.Forms.ContextMenuStrip cmsTools;
        private System.Windows.Forms.ToolStripMenuItem miGenerateRightAnswers;
        private System.Windows.Forms.Label lblTrailerNumber;
        private System.Windows.Forms.TextBox tbxTrailerNumber;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Panel pnlQuestionGroup1;
        private System.Windows.Forms.Panel pnlQuestionGroup2;
        private System.Windows.Forms.Panel pnlQuestionGroup1Header;
        private System.Windows.Forms.Label lblQuestionGroup1Header;
        private System.Windows.Forms.Panel pnlQuestionGroup2Header;
        private System.Windows.Forms.Label lblQuestionGroup2Header;
        private System.Windows.Forms.Panel pnlQuestionGroup1Content;
        private System.Windows.Forms.Panel pnlQuestionGroup1Footer;
        private System.Windows.Forms.Label lblEditingDate1;
        private System.Windows.Forms.TextBox tbxEditingDate1;
        private System.Windows.Forms.Label lblUser1;
        private System.Windows.Forms.TextBox tbxUser1;
        private System.Windows.Forms.Panel pnlQuestionGroup2Content;
        private System.Windows.Forms.Panel pnlQuestionGroup2Footer;
        private System.Windows.Forms.Label lblEditingDate2;
        private System.Windows.Forms.TextBox tbxEditingDate2;
        private System.Windows.Forms.Label lblUser2;
        private System.Windows.Forms.TextBox tbxUser2;
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
    }
}