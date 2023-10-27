namespace WMSOffice.Dialogs.Admin
{
    partial class QuizAdminForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbQuiz = new System.Windows.Forms.GroupBox();
            this.dgvQuiz = new System.Windows.Forms.DataGridView();
            this.quizidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.doctypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxcountemployeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxcountdocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.periodfromDataGridViewTextBoxColumn = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.periodtoDataGridViewTextBoxColumn = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.qUQuizBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.admin = new WMSOffice.Data.Admin();
            this.tsQuizOptions = new System.Windows.Forms.ToolStrip();
            this.sbAddQuiz = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbQuestionTemplates = new System.Windows.Forms.GroupBox();
            this.dgvQuestionTemplates = new System.Windows.Forms.DataGridView();
            this.qUCriterionTypesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qUQuestionTemplatesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsQuestionTemplateOptions = new System.Windows.Forms.ToolStrip();
            this.sbAddQuestionTemplate = new System.Windows.Forms.ToolStripButton();
            this.tcQuestionsSettings = new System.Windows.Forms.TabControl();
            this.tpAnswersBuilder = new System.Windows.Forms.TabPage();
            this.gbAnswers = new System.Windows.Forms.GroupBox();
            this.dgvAnswers = new System.Windows.Forms.DataGridView();
            this.answeridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new WMSOffice.Controls.Custom.ColorPickerColumn();
            this.priorityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qUAnswersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsAnswerOptions = new System.Windows.Forms.ToolStrip();
            this.sbAddAnswer = new System.Windows.Forms.ToolStripButton();
            this.tpCriterionLink = new System.Windows.Forms.TabPage();
            this.gbQuestions = new System.Windows.Forms.GroupBox();
            this.tsQuestionOptions = new System.Windows.Forms.ToolStrip();
            this.sbAddQuestion = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbCriterionFilter = new System.Windows.Forms.ToolStripTextBox();
            this.dgvCriterionLinks = new System.Windows.Forms.DataGridView();
            this.IsChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.questionidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criterionvalueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qUQuestionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sbMainOptions = new System.Windows.Forms.ToolStrip();
            this.sbRefresh = new System.Windows.Forms.ToolStripButton();
            this.sbSaveChanges = new System.Windows.Forms.ToolStripButton();
            this.qU_QuizTableAdapter = new WMSOffice.Data.AdminTableAdapters.QU_QuizTableAdapter();
            this.qU_QuestionTemplatesTableAdapter = new WMSOffice.Data.AdminTableAdapters.QU_QuestionTemplatesTableAdapter();
            this.qU_CriterionTypesTableAdapter = new WMSOffice.Data.AdminTableAdapters.QU_CriterionTypesTableAdapter();
            this.qU_AnswersTableAdapter = new WMSOffice.Data.AdminTableAdapters.QU_AnswersTableAdapter();
            this.qU_QuestionsTableAdapter = new WMSOffice.Data.AdminTableAdapters.QU_QuestionsTableAdapter();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewDatePickerColumn1 = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.dataGridViewDatePickerColumn2 = new WMSOffice.Controls.Custom.DataGridViewDatePickerColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorPickerColumn1 = new WMSOffice.Controls.Custom.ColorPickerColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.templateidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxanswerscountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.criteriontypeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.perQuestionsCoverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perCriterionsPartCoverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perCriterionsFullCoverage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbQuiz.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuiz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuizBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).BeginInit();
            this.tsQuizOptions.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbQuestionTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUCriterionTypesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuestionTemplatesBindingSource)).BeginInit();
            this.tsQuestionTemplateOptions.SuspendLayout();
            this.tcQuestionsSettings.SuspendLayout();
            this.tpAnswersBuilder.SuspendLayout();
            this.gbAnswers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUAnswersBindingSource)).BeginInit();
            this.tsAnswerOptions.SuspendLayout();
            this.tpCriterionLink.SuspendLayout();
            this.gbQuestions.SuspendLayout();
            this.tsQuestionOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterionLinks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuestionsBindingSource)).BeginInit();
            this.sbMainOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 42);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.gbQuiz);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
            this.splitContainer2.Size = new System.Drawing.Size(1050, 595);
            this.splitContainer2.SplitterDistance = 150;
            this.splitContainer2.TabIndex = 1;
            // 
            // gbQuiz
            // 
            this.gbQuiz.Controls.Add(this.dgvQuiz);
            this.gbQuiz.Controls.Add(this.tsQuizOptions);
            this.gbQuiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQuiz.Location = new System.Drawing.Point(0, 0);
            this.gbQuiz.Name = "gbQuiz";
            this.gbQuiz.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.gbQuiz.Size = new System.Drawing.Size(1050, 150);
            this.gbQuiz.TabIndex = 0;
            this.gbQuiz.TabStop = false;
            this.gbQuiz.Text = "ОПРОСЫ";
            // 
            // dgvQuiz
            // 
            this.dgvQuiz.AllowUserToAddRows = false;
            this.dgvQuiz.AllowUserToDeleteRows = false;
            this.dgvQuiz.AllowUserToResizeRows = false;
            this.dgvQuiz.AutoGenerateColumns = false;
            this.dgvQuiz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuiz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.quizidDataGridViewTextBoxColumn,
            this.doctypeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.maxcountemployeeDataGridViewTextBoxColumn,
            this.maxcountdocDataGridViewTextBoxColumn,
            this.periodfromDataGridViewTextBoxColumn,
            this.periodtoDataGridViewTextBoxColumn});
            this.dgvQuiz.DataSource = this.qUQuizBindingSource;
            this.dgvQuiz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuiz.Location = new System.Drawing.Point(3, 43);
            this.dgvQuiz.MultiSelect = false;
            this.dgvQuiz.Name = "dgvQuiz";
            this.dgvQuiz.RowHeadersVisible = false;
            this.dgvQuiz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQuiz.Size = new System.Drawing.Size(1044, 104);
            this.dgvQuiz.TabIndex = 1;
            this.dgvQuiz.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvQuiz.Leave += new System.EventHandler(this.dgvData_Leave);
            this.dgvQuiz.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvQuiz_DataError);
            this.dgvQuiz.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            this.dgvQuiz.SelectionChanged += new System.EventHandler(this.dgvQuiz_SelectionChanged);
            // 
            // quizidDataGridViewTextBoxColumn
            // 
            this.quizidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quizidDataGridViewTextBoxColumn.DataPropertyName = "quiz_id";
            this.quizidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.quizidDataGridViewTextBoxColumn.Name = "quizidDataGridViewTextBoxColumn";
            this.quizidDataGridViewTextBoxColumn.ReadOnly = true;
            this.quizidDataGridViewTextBoxColumn.Width = 43;
            // 
            // doctypeDataGridViewTextBoxColumn
            // 
            this.doctypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.doctypeDataGridViewTextBoxColumn.DataPropertyName = "doc_type";
            this.doctypeDataGridViewTextBoxColumn.HeaderText = "Тип документа";
            this.doctypeDataGridViewTextBoxColumn.MaxInputLength = 2;
            this.doctypeDataGridViewTextBoxColumn.Name = "doctypeDataGridViewTextBoxColumn";
            this.doctypeDataGridViewTextBoxColumn.Width = 99;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn.MaxInputLength = 255;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 300;
            // 
            // maxcountemployeeDataGridViewTextBoxColumn
            // 
            this.maxcountemployeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maxcountemployeeDataGridViewTextBoxColumn.DataPropertyName = "max_count_employee";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.maxcountemployeeDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.maxcountemployeeDataGridViewTextBoxColumn.HeaderText = "Макс. вопр. / сотр.";
            this.maxcountemployeeDataGridViewTextBoxColumn.Name = "maxcountemployeeDataGridViewTextBoxColumn";
            this.maxcountemployeeDataGridViewTextBoxColumn.ToolTipText = "Ограничение по количеству вопросов для сотрудника в день";
            this.maxcountemployeeDataGridViewTextBoxColumn.Width = 95;
            // 
            // maxcountdocDataGridViewTextBoxColumn
            // 
            this.maxcountdocDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maxcountdocDataGridViewTextBoxColumn.DataPropertyName = "max_count_doc";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.maxcountdocDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.maxcountdocDataGridViewTextBoxColumn.HeaderText = "Макс. вопр. / док.";
            this.maxcountdocDataGridViewTextBoxColumn.Name = "maxcountdocDataGridViewTextBoxColumn";
            this.maxcountdocDataGridViewTextBoxColumn.ToolTipText = "Ограничение по количеству вопросов на документ";
            this.maxcountdocDataGridViewTextBoxColumn.Width = 95;
            // 
            // periodfromDataGridViewTextBoxColumn
            // 
            this.periodfromDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.periodfromDataGridViewTextBoxColumn.DataPropertyName = "period_from";
            this.periodfromDataGridViewTextBoxColumn.HeaderText = "Период начала действия";
            this.periodfromDataGridViewTextBoxColumn.Name = "periodfromDataGridViewTextBoxColumn";
            this.periodfromDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.periodfromDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.periodfromDataGridViewTextBoxColumn.Width = 144;
            // 
            // periodtoDataGridViewTextBoxColumn
            // 
            this.periodtoDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.periodtoDataGridViewTextBoxColumn.DataPropertyName = "period_to";
            this.periodtoDataGridViewTextBoxColumn.HeaderText = "Период конца действия";
            this.periodtoDataGridViewTextBoxColumn.Name = "periodtoDataGridViewTextBoxColumn";
            this.periodtoDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.periodtoDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.periodtoDataGridViewTextBoxColumn.Width = 140;
            // 
            // qUQuizBindingSource
            // 
            this.qUQuizBindingSource.DataMember = "QU_Quiz";
            this.qUQuizBindingSource.DataSource = this.admin;
            // 
            // admin
            // 
            this.admin.DataSetName = "Admin";
            this.admin.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tsQuizOptions
            // 
            this.tsQuizOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddQuiz});
            this.tsQuizOptions.Location = new System.Drawing.Point(3, 18);
            this.tsQuizOptions.Name = "tsQuizOptions";
            this.tsQuizOptions.Size = new System.Drawing.Size(1044, 25);
            this.tsQuizOptions.TabIndex = 0;
            this.tsQuizOptions.Text = "toolStrip2";
            // 
            // sbAddQuiz
            // 
            this.sbAddQuiz.Image = global::WMSOffice.Properties.Resources.add;
            this.sbAddQuiz.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddQuiz.Name = "sbAddQuiz";
            this.sbAddQuiz.Size = new System.Drawing.Size(79, 22);
            this.sbAddQuiz.Text = "Добавить";
            this.sbAddQuiz.Click += new System.EventHandler(this.sbAddQuiz_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbQuestionTemplates);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcQuestionsSettings);
            this.splitContainer1.Size = new System.Drawing.Size(1050, 441);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbQuestionTemplates
            // 
            this.gbQuestionTemplates.Controls.Add(this.dgvQuestionTemplates);
            this.gbQuestionTemplates.Controls.Add(this.tsQuestionTemplateOptions);
            this.gbQuestionTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQuestionTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gbQuestionTemplates.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gbQuestionTemplates.Location = new System.Drawing.Point(0, 0);
            this.gbQuestionTemplates.Name = "gbQuestionTemplates";
            this.gbQuestionTemplates.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.gbQuestionTemplates.Size = new System.Drawing.Size(1050, 150);
            this.gbQuestionTemplates.TabIndex = 1;
            this.gbQuestionTemplates.TabStop = false;
            this.gbQuestionTemplates.Text = "ШАБЛОНЫ ВОПРОСОВ";
            // 
            // dgvQuestionTemplates
            // 
            this.dgvQuestionTemplates.AllowUserToAddRows = false;
            this.dgvQuestionTemplates.AllowUserToDeleteRows = false;
            this.dgvQuestionTemplates.AllowUserToResizeRows = false;
            this.dgvQuestionTemplates.AutoGenerateColumns = false;
            this.dgvQuestionTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestionTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.templateidDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn1,
            this.maxanswerscountDataGridViewTextBoxColumn,
            this.criteriontypeidDataGridViewTextBoxColumn,
            this.perQuestionsCoverage,
            this.perCriterionsPartCoverage,
            this.perCriterionsFullCoverage});
            this.dgvQuestionTemplates.DataSource = this.qUQuestionTemplatesBindingSource;
            this.dgvQuestionTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvQuestionTemplates.Location = new System.Drawing.Point(3, 43);
            this.dgvQuestionTemplates.MultiSelect = false;
            this.dgvQuestionTemplates.Name = "dgvQuestionTemplates";
            this.dgvQuestionTemplates.RowHeadersVisible = false;
            this.dgvQuestionTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQuestionTemplates.Size = new System.Drawing.Size(1044, 104);
            this.dgvQuestionTemplates.TabIndex = 2;
            this.dgvQuestionTemplates.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvQuestionTemplates.Leave += new System.EventHandler(this.dgvData_Leave);
            this.dgvQuestionTemplates.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvQuestionTemplates_CellFormatting);
            this.dgvQuestionTemplates.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvQuestionTemplates_DataError);
            this.dgvQuestionTemplates.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvQuestionTemplates_KeyDown);
            this.dgvQuestionTemplates.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            this.dgvQuestionTemplates.SelectionChanged += new System.EventHandler(this.dgvQuestionTemplates_SelectionChanged);
            // 
            // qUCriterionTypesBindingSource
            // 
            this.qUCriterionTypesBindingSource.DataMember = "QU_CriterionTypes";
            this.qUCriterionTypesBindingSource.DataSource = this.admin;
            // 
            // qUQuestionTemplatesBindingSource
            // 
            this.qUQuestionTemplatesBindingSource.DataMember = "QU_QuestionTemplates";
            this.qUQuestionTemplatesBindingSource.DataSource = this.admin;
            // 
            // tsQuestionTemplateOptions
            // 
            this.tsQuestionTemplateOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddQuestionTemplate});
            this.tsQuestionTemplateOptions.Location = new System.Drawing.Point(3, 18);
            this.tsQuestionTemplateOptions.Name = "tsQuestionTemplateOptions";
            this.tsQuestionTemplateOptions.Size = new System.Drawing.Size(1044, 25);
            this.tsQuestionTemplateOptions.TabIndex = 1;
            this.tsQuestionTemplateOptions.Text = "toolStrip1";
            // 
            // sbAddQuestionTemplate
            // 
            this.sbAddQuestionTemplate.Image = global::WMSOffice.Properties.Resources.add;
            this.sbAddQuestionTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddQuestionTemplate.Name = "sbAddQuestionTemplate";
            this.sbAddQuestionTemplate.Size = new System.Drawing.Size(79, 22);
            this.sbAddQuestionTemplate.Text = "Добавить";
            this.sbAddQuestionTemplate.Click += new System.EventHandler(this.sbAddQuestionTemplate_Click);
            // 
            // tcQuestionsSettings
            // 
            this.tcQuestionsSettings.Controls.Add(this.tpAnswersBuilder);
            this.tcQuestionsSettings.Controls.Add(this.tpCriterionLink);
            this.tcQuestionsSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcQuestionsSettings.Location = new System.Drawing.Point(0, 0);
            this.tcQuestionsSettings.Name = "tcQuestionsSettings";
            this.tcQuestionsSettings.SelectedIndex = 0;
            this.tcQuestionsSettings.Size = new System.Drawing.Size(1050, 287);
            this.tcQuestionsSettings.TabIndex = 1;
            this.tcQuestionsSettings.SelectedIndexChanged += new System.EventHandler(this.tcQuestionsSettings_SelectedIndexChanged);
            // 
            // tpAnswersBuilder
            // 
            this.tpAnswersBuilder.Controls.Add(this.gbAnswers);
            this.tpAnswersBuilder.Location = new System.Drawing.Point(4, 22);
            this.tpAnswersBuilder.Name = "tpAnswersBuilder";
            this.tpAnswersBuilder.Padding = new System.Windows.Forms.Padding(3);
            this.tpAnswersBuilder.Size = new System.Drawing.Size(1042, 261);
            this.tpAnswersBuilder.TabIndex = 0;
            this.tpAnswersBuilder.Text = "Конструктор ответов";
            this.tpAnswersBuilder.UseVisualStyleBackColor = true;
            // 
            // gbAnswers
            // 
            this.gbAnswers.Controls.Add(this.dgvAnswers);
            this.gbAnswers.Controls.Add(this.tsAnswerOptions);
            this.gbAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAnswers.Location = new System.Drawing.Point(3, 3);
            this.gbAnswers.Name = "gbAnswers";
            this.gbAnswers.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.gbAnswers.Size = new System.Drawing.Size(1036, 255);
            this.gbAnswers.TabIndex = 1;
            this.gbAnswers.TabStop = false;
            this.gbAnswers.Text = "ВАРИАНТЫ ОТВЕТОВ";
            // 
            // dgvAnswers
            // 
            this.dgvAnswers.AllowUserToAddRows = false;
            this.dgvAnswers.AllowUserToResizeRows = false;
            this.dgvAnswers.AutoGenerateColumns = false;
            this.dgvAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.answeridDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn2,
            this.colorDataGridViewTextBoxColumn,
            this.priorityDataGridViewTextBoxColumn});
            this.dgvAnswers.DataSource = this.qUAnswersBindingSource;
            this.dgvAnswers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAnswers.Location = new System.Drawing.Point(3, 43);
            this.dgvAnswers.MultiSelect = false;
            this.dgvAnswers.Name = "dgvAnswers";
            this.dgvAnswers.RowHeadersVisible = false;
            this.dgvAnswers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAnswers.Size = new System.Drawing.Size(1030, 209);
            this.dgvAnswers.TabIndex = 2;
            this.dgvAnswers.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvAnswers.Leave += new System.EventHandler(this.dgvData_Leave);
            this.dgvAnswers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAnswers_DataError);
            this.dgvAnswers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvAnswers_KeyDown);
            this.dgvAnswers.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            this.dgvAnswers.SelectionChanged += new System.EventHandler(this.dgvAnswers_SelectionChanged);
            // 
            // answeridDataGridViewTextBoxColumn
            // 
            this.answeridDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.answeridDataGridViewTextBoxColumn.DataPropertyName = "answer_id";
            this.answeridDataGridViewTextBoxColumn.HeaderText = "ID";
            this.answeridDataGridViewTextBoxColumn.Name = "answeridDataGridViewTextBoxColumn";
            this.answeridDataGridViewTextBoxColumn.ReadOnly = true;
            this.answeridDataGridViewTextBoxColumn.Width = 43;
            // 
            // nameDataGridViewTextBoxColumn2
            // 
            this.nameDataGridViewTextBoxColumn2.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn2.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn2.MaxInputLength = 255;
            this.nameDataGridViewTextBoxColumn2.Name = "nameDataGridViewTextBoxColumn2";
            this.nameDataGridViewTextBoxColumn2.Width = 300;
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Цвет";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            this.colorDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colorDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colorDataGridViewTextBoxColumn.Width = 150;
            // 
            // priorityDataGridViewTextBoxColumn
            // 
            this.priorityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.priorityDataGridViewTextBoxColumn.DataPropertyName = "priority";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = null;
            this.priorityDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.priorityDataGridViewTextBoxColumn.HeaderText = "Приоритет";
            this.priorityDataGridViewTextBoxColumn.Name = "priorityDataGridViewTextBoxColumn";
            this.priorityDataGridViewTextBoxColumn.Width = 86;
            // 
            // qUAnswersBindingSource
            // 
            this.qUAnswersBindingSource.DataMember = "QU_Answers";
            this.qUAnswersBindingSource.DataSource = this.admin;
            // 
            // tsAnswerOptions
            // 
            this.tsAnswerOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddAnswer});
            this.tsAnswerOptions.Location = new System.Drawing.Point(3, 18);
            this.tsAnswerOptions.Name = "tsAnswerOptions";
            this.tsAnswerOptions.Size = new System.Drawing.Size(1030, 25);
            this.tsAnswerOptions.TabIndex = 1;
            this.tsAnswerOptions.Text = "toolStrip2";
            // 
            // sbAddAnswer
            // 
            this.sbAddAnswer.Image = global::WMSOffice.Properties.Resources.add;
            this.sbAddAnswer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddAnswer.Name = "sbAddAnswer";
            this.sbAddAnswer.Size = new System.Drawing.Size(79, 22);
            this.sbAddAnswer.Text = "Добавить";
            this.sbAddAnswer.Click += new System.EventHandler(this.sbAddAnswer_Click);
            // 
            // tpCriterionLink
            // 
            this.tpCriterionLink.Controls.Add(this.gbQuestions);
            this.tpCriterionLink.Location = new System.Drawing.Point(4, 22);
            this.tpCriterionLink.Name = "tpCriterionLink";
            this.tpCriterionLink.Padding = new System.Windows.Forms.Padding(3);
            this.tpCriterionLink.Size = new System.Drawing.Size(1042, 261);
            this.tpCriterionLink.TabIndex = 1;
            this.tpCriterionLink.Text = "Настройка критериев";
            this.tpCriterionLink.UseVisualStyleBackColor = true;
            // 
            // gbQuestions
            // 
            this.gbQuestions.Controls.Add(this.tsQuestionOptions);
            this.gbQuestions.Controls.Add(this.dgvCriterionLinks);
            this.gbQuestions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQuestions.Location = new System.Drawing.Point(3, 3);
            this.gbQuestions.Name = "gbQuestions";
            this.gbQuestions.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.gbQuestions.Size = new System.Drawing.Size(1036, 255);
            this.gbQuestions.TabIndex = 2;
            this.gbQuestions.TabStop = false;
            this.gbQuestions.Text = "КРИТЕРИИ";
            // 
            // tsQuestionOptions
            // 
            this.tsQuestionOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbAddQuestion,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tbCriterionFilter});
            this.tsQuestionOptions.Location = new System.Drawing.Point(3, 18);
            this.tsQuestionOptions.Name = "tsQuestionOptions";
            this.tsQuestionOptions.Size = new System.Drawing.Size(1030, 25);
            this.tsQuestionOptions.TabIndex = 0;
            this.tsQuestionOptions.Text = "toolStrip1";
            // 
            // sbAddQuestion
            // 
            this.sbAddQuestion.Image = global::WMSOffice.Properties.Resources.add;
            this.sbAddQuestion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbAddQuestion.Name = "sbAddQuestion";
            this.sbAddQuestion.Size = new System.Drawing.Size(79, 22);
            this.sbAddQuestion.Text = "Добавить";
            this.sbAddQuestion.Click += new System.EventHandler(this.sbAddQuestion_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Image = global::WMSOffice.Properties.Resources.filter;
            this.toolStripLabel1.Margin = new System.Windows.Forms.Padding(5, 1, 0, 2);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(67, 22);
            this.toolStripLabel1.Text = "Фильтр:";
            this.toolStripLabel1.ToolTipText = "Фильтрация значений критерия";
            // 
            // tbCriterionFilter
            // 
            this.tbCriterionFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCriterionFilter.Margin = new System.Windows.Forms.Padding(3, 1, 1, 1);
            this.tbCriterionFilter.Name = "tbCriterionFilter";
            this.tbCriterionFilter.Size = new System.Drawing.Size(150, 23);
            this.tbCriterionFilter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbCriterionFilter_KeyDown);
            // 
            // dgvCriterionLinks
            // 
            this.dgvCriterionLinks.AllowUserToAddRows = false;
            this.dgvCriterionLinks.AllowUserToDeleteRows = false;
            this.dgvCriterionLinks.AllowUserToResizeRows = false;
            this.dgvCriterionLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCriterionLinks.AutoGenerateColumns = false;
            this.dgvCriterionLinks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCriterionLinks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsChecked,
            this.questionidDataGridViewTextBoxColumn,
            this.criterionvalueDataGridViewTextBoxColumn});
            this.dgvCriterionLinks.DataSource = this.qUQuestionsBindingSource;
            this.dgvCriterionLinks.Location = new System.Drawing.Point(3, 44);
            this.dgvCriterionLinks.MultiSelect = false;
            this.dgvCriterionLinks.Name = "dgvCriterionLinks";
            this.dgvCriterionLinks.RowHeadersVisible = false;
            this.dgvCriterionLinks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvCriterionLinks.Size = new System.Drawing.Size(1033, 207);
            this.dgvCriterionLinks.TabIndex = 1;
            this.dgvCriterionLinks.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellValidated);
            this.dgvCriterionLinks.Leave += new System.EventHandler(this.dgvData_Leave);
            this.dgvCriterionLinks.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvCriterionLinks_CurrentCellDirtyStateChanged);
            this.dgvCriterionLinks.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCriterionLinks_DataError);
            this.dgvCriterionLinks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvCriterionLinks_KeyDown);
            this.dgvCriterionLinks.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellEnter);
            this.dgvCriterionLinks.SelectionChanged += new System.EventHandler(this.dgvCriterionLinks_SelectionChanged);
            // 
            // IsChecked
            // 
            this.IsChecked.DataPropertyName = "IsChecked";
            this.IsChecked.HeaderText = "Отм.";
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.IsChecked.ToolTipText = "Отм.";
            this.IsChecked.Width = 50;
            // 
            // questionidDataGridViewTextBoxColumn
            // 
            this.questionidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.questionidDataGridViewTextBoxColumn.DataPropertyName = "question_id";
            this.questionidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.questionidDataGridViewTextBoxColumn.Name = "questionidDataGridViewTextBoxColumn";
            this.questionidDataGridViewTextBoxColumn.ReadOnly = true;
            this.questionidDataGridViewTextBoxColumn.Width = 43;
            // 
            // criterionvalueDataGridViewTextBoxColumn
            // 
            this.criterionvalueDataGridViewTextBoxColumn.DataPropertyName = "criterion_value";
            this.criterionvalueDataGridViewTextBoxColumn.HeaderText = "Значение критерия";
            this.criterionvalueDataGridViewTextBoxColumn.MaxInputLength = 25;
            this.criterionvalueDataGridViewTextBoxColumn.Name = "criterionvalueDataGridViewTextBoxColumn";
            this.criterionvalueDataGridViewTextBoxColumn.Width = 300;
            // 
            // qUQuestionsBindingSource
            // 
            this.qUQuestionsBindingSource.DataMember = "QU_Questions";
            this.qUQuestionsBindingSource.DataSource = this.admin;
            // 
            // sbMainOptions
            // 
            this.sbMainOptions.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.sbMainOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbRefresh,
            this.sbSaveChanges});
            this.sbMainOptions.Location = new System.Drawing.Point(0, 0);
            this.sbMainOptions.Name = "sbMainOptions";
            this.sbMainOptions.Size = new System.Drawing.Size(1050, 39);
            this.sbMainOptions.TabIndex = 2;
            this.sbMainOptions.Text = "toolStrip1";
            // 
            // sbRefresh
            // 
            this.sbRefresh.Image = global::WMSOffice.Properties.Resources.refresh;
            this.sbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbRefresh.Name = "sbRefresh";
            this.sbRefresh.Size = new System.Drawing.Size(97, 36);
            this.sbRefresh.Text = "Обновить";
            this.sbRefresh.Click += new System.EventHandler(this.sbRefresh_Click);
            // 
            // sbSaveChanges
            // 
            this.sbSaveChanges.Image = global::WMSOffice.Properties.Resources.save;
            this.sbSaveChanges.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbSaveChanges.Name = "sbSaveChanges";
            this.sbSaveChanges.Size = new System.Drawing.Size(164, 36);
            this.sbSaveChanges.Text = "Сохранить изменения";
            this.sbSaveChanges.Click += new System.EventHandler(this.sbSaveChanges_Click);
            // 
            // qU_QuizTableAdapter
            // 
            this.qU_QuizTableAdapter.ClearBeforeFill = true;
            // 
            // qU_QuestionTemplatesTableAdapter
            // 
            this.qU_QuestionTemplatesTableAdapter.ClearBeforeFill = false;
            // 
            // qU_CriterionTypesTableAdapter
            // 
            this.qU_CriterionTypesTableAdapter.ClearBeforeFill = true;
            // 
            // qU_AnswersTableAdapter
            // 
            this.qU_AnswersTableAdapter.ClearBeforeFill = false;
            // 
            // qU_QuestionsTableAdapter
            // 
            this.qU_QuestionsTableAdapter.ClearBeforeFill = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "quiz_id";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "doc_type";
            this.dataGridViewTextBoxColumn2.HeaderText = "Тип документа";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Название";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 300;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "max_count_employee";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn4.HeaderText = "max_count_employee";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = "Ограничение по количеству вопросов для сотрудника в день";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "max_count_doc";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn5.HeaderText = "max_count_doc";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ToolTipText = "Ограничение по количеству вопросов на документ";
            // 
            // dataGridViewDatePickerColumn1
            // 
            this.dataGridViewDatePickerColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewDatePickerColumn1.DataPropertyName = "period_from";
            this.dataGridViewDatePickerColumn1.HeaderText = "Период начала действия";
            this.dataGridViewDatePickerColumn1.Name = "dataGridViewDatePickerColumn1";
            this.dataGridViewDatePickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDatePickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewDatePickerColumn2
            // 
            this.dataGridViewDatePickerColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewDatePickerColumn2.DataPropertyName = "period_to";
            this.dataGridViewDatePickerColumn2.HeaderText = "Период конца действия";
            this.dataGridViewDatePickerColumn2.Name = "dataGridViewDatePickerColumn2";
            this.dataGridViewDatePickerColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewDatePickerColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "template_id";
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn7.HeaderText = "Название";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 300;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "max_answers_count";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn8.HeaderText = "max_answers_count";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ToolTipText = "Максимальное количество раз, сколько мы должны задать вопрос";
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn1.DataPropertyName = "criterion_type_id";
            this.dataGridViewComboBoxColumn1.DataSource = this.qUCriterionTypesBindingSource;
            this.dataGridViewComboBoxColumn1.DisplayMember = "name";
            this.dataGridViewComboBoxColumn1.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.dataGridViewComboBoxColumn1.DisplayStyleForCurrentCellOnly = true;
            this.dataGridViewComboBoxColumn1.DividerWidth = 3;
            this.dataGridViewComboBoxColumn1.HeaderText = "Тип критерия";
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewComboBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewComboBoxColumn1.ValueMember = "type_id";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "answer_id";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "P";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn9.HeaderText = "ID";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Общее количество ответов / Общее количество вопросов";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "name";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "P";
            dataGridViewCellStyle12.NullValue = null;
            this.dataGridViewTextBoxColumn10.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn10.HeaderText = "Название";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.ToolTipText = "Количество критериев, по которым получен хоть один ответ / Общее количество крите" +
                "риев";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "color";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "P";
            dataGridViewCellStyle13.NullValue = null;
            this.dataGridViewTextBoxColumn11.DefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridViewTextBoxColumn11.HeaderText = "Цвет";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.ToolTipText = "Количество критериев, по которым получены все ответы / Общее количество критериев" +
                "";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "priority";
            this.dataGridViewTextBoxColumn12.HeaderText = "Приоритет";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "name";
            this.dataGridViewTextBoxColumn13.HeaderText = "Название";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.Width = 300;
            // 
            // colorPickerColumn1
            // 
            this.colorPickerColumn1.DataPropertyName = "color";
            this.colorPickerColumn1.HeaderText = "Цвет";
            this.colorPickerColumn1.Name = "colorPickerColumn1";
            this.colorPickerColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colorPickerColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colorPickerColumn1.Width = 150;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn14.DataPropertyName = "priority";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N0";
            dataGridViewCellStyle14.NullValue = null;
            this.dataGridViewTextBoxColumn14.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridViewTextBoxColumn14.HeaderText = "Приоритет";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "IsChecked";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCheckBoxColumn1.ToolTipText = "Отм.";
            this.dataGridViewCheckBoxColumn1.Width = 50;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn15.DataPropertyName = "question_id";
            this.dataGridViewTextBoxColumn15.HeaderText = "ID";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "criterion_value";
            this.dataGridViewTextBoxColumn16.HeaderText = "Значение критерия";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.Width = 300;
            // 
            // templateidDataGridViewTextBoxColumn
            // 
            this.templateidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.templateidDataGridViewTextBoxColumn.DataPropertyName = "template_id";
            this.templateidDataGridViewTextBoxColumn.HeaderText = "ID";
            this.templateidDataGridViewTextBoxColumn.Name = "templateidDataGridViewTextBoxColumn";
            this.templateidDataGridViewTextBoxColumn.ReadOnly = true;
            this.templateidDataGridViewTextBoxColumn.Width = 43;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn1.MaxInputLength = 255;
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.Width = 300;
            // 
            // maxanswerscountDataGridViewTextBoxColumn
            // 
            this.maxanswerscountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.maxanswerscountDataGridViewTextBoxColumn.DataPropertyName = "max_answers_count";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.maxanswerscountDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.maxanswerscountDataGridViewTextBoxColumn.HeaderText = "Макс. кол-во";
            this.maxanswerscountDataGridViewTextBoxColumn.Name = "maxanswerscountDataGridViewTextBoxColumn";
            this.maxanswerscountDataGridViewTextBoxColumn.ToolTipText = "Максимальное количество раз, сколько мы должны задать вопрос по одному значению к" +
                "ритерия";
            this.maxanswerscountDataGridViewTextBoxColumn.Width = 98;
            // 
            // criteriontypeidDataGridViewTextBoxColumn
            // 
            this.criteriontypeidDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.criteriontypeidDataGridViewTextBoxColumn.DataPropertyName = "criterion_type_id";
            this.criteriontypeidDataGridViewTextBoxColumn.DataSource = this.qUCriterionTypesBindingSource;
            this.criteriontypeidDataGridViewTextBoxColumn.DisplayMember = "name";
            this.criteriontypeidDataGridViewTextBoxColumn.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.criteriontypeidDataGridViewTextBoxColumn.DisplayStyleForCurrentCellOnly = true;
            this.criteriontypeidDataGridViewTextBoxColumn.DividerWidth = 3;
            this.criteriontypeidDataGridViewTextBoxColumn.HeaderText = "Тип критерия";
            this.criteriontypeidDataGridViewTextBoxColumn.Name = "criteriontypeidDataGridViewTextBoxColumn";
            this.criteriontypeidDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.criteriontypeidDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.criteriontypeidDataGridViewTextBoxColumn.ValueMember = "type_id";
            this.criteriontypeidDataGridViewTextBoxColumn.Width = 104;
            // 
            // perQuestionsCoverage
            // 
            this.perQuestionsCoverage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.perQuestionsCoverage.DataPropertyName = "perQuestionsCoverage";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "P";
            dataGridViewCellStyle4.NullValue = null;
            this.perQuestionsCoverage.DefaultCellStyle = dataGridViewCellStyle4;
            this.perQuestionsCoverage.HeaderText = "Покрытие вопросов";
            this.perQuestionsCoverage.Name = "perQuestionsCoverage";
            this.perQuestionsCoverage.ReadOnly = true;
            this.perQuestionsCoverage.ToolTipText = "Общее количество ответов / Общее количество вопросов";
            this.perQuestionsCoverage.Width = 123;
            // 
            // perCriterionsPartCoverage
            // 
            this.perCriterionsPartCoverage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.perCriterionsPartCoverage.DataPropertyName = "perCriterionsPartCoverage";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "P";
            dataGridViewCellStyle5.NullValue = null;
            this.perCriterionsPartCoverage.DefaultCellStyle = dataGridViewCellStyle5;
            this.perCriterionsPartCoverage.HeaderText = "Покрытие критериев";
            this.perCriterionsPartCoverage.Name = "perCriterionsPartCoverage";
            this.perCriterionsPartCoverage.ReadOnly = true;
            this.perCriterionsPartCoverage.ToolTipText = "Количество критериев, по которым получен хоть один ответ / Общее количество крите" +
                "риев";
            this.perCriterionsPartCoverage.Width = 127;
            // 
            // perCriterionsFullCoverage
            // 
            this.perCriterionsFullCoverage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.perCriterionsFullCoverage.DataPropertyName = "perCriterionsFullCoverage";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "P";
            dataGridViewCellStyle6.NullValue = null;
            this.perCriterionsFullCoverage.DefaultCellStyle = dataGridViewCellStyle6;
            this.perCriterionsFullCoverage.HeaderText = "Закрытие критериев";
            this.perCriterionsFullCoverage.Name = "perCriterionsFullCoverage";
            this.perCriterionsFullCoverage.ReadOnly = true;
            this.perCriterionsFullCoverage.ToolTipText = "Количество критериев, по которым получены все ответы / Общее количество критериев" +
                "";
            this.perCriterionsFullCoverage.Width = 126;
            // 
            // QuizAdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 638);
            this.Controls.Add(this.sbMainOptions);
            this.Controls.Add(this.splitContainer2);
            this.Name = "QuizAdminForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Администрирование опросов";
            this.Load += new System.EventHandler(this.QuizAdminForm_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.gbQuiz.ResumeLayout(false);
            this.gbQuiz.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuiz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuizBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.admin)).EndInit();
            this.tsQuizOptions.ResumeLayout(false);
            this.tsQuizOptions.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.gbQuestionTemplates.ResumeLayout(false);
            this.gbQuestionTemplates.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestionTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUCriterionTypesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuestionTemplatesBindingSource)).EndInit();
            this.tsQuestionTemplateOptions.ResumeLayout(false);
            this.tsQuestionTemplateOptions.PerformLayout();
            this.tcQuestionsSettings.ResumeLayout(false);
            this.tpAnswersBuilder.ResumeLayout(false);
            this.gbAnswers.ResumeLayout(false);
            this.gbAnswers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUAnswersBindingSource)).EndInit();
            this.tsAnswerOptions.ResumeLayout(false);
            this.tsAnswerOptions.PerformLayout();
            this.tpCriterionLink.ResumeLayout(false);
            this.gbQuestions.ResumeLayout(false);
            this.gbQuestions.PerformLayout();
            this.tsQuestionOptions.ResumeLayout(false);
            this.tsQuestionOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCriterionLinks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qUQuestionsBindingSource)).EndInit();
            this.sbMainOptions.ResumeLayout(false);
            this.sbMainOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvQuestionTemplates;
        private System.Windows.Forms.ToolStrip tsQuestionTemplateOptions;
        private System.Windows.Forms.ToolStripButton sbAddQuestionTemplate;
        private System.Windows.Forms.DataGridView dgvAnswers;
        private System.Windows.Forms.ToolStrip tsAnswerOptions;
        private System.Windows.Forms.ToolStripButton sbAddAnswer;
        private System.Windows.Forms.DataGridView dgvQuiz;
        private System.Windows.Forms.ToolStrip tsQuizOptions;
        private System.Windows.Forms.ToolStripButton sbAddQuiz;
        private System.Windows.Forms.GroupBox gbQuestionTemplates;
        private System.Windows.Forms.GroupBox gbAnswers;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbQuiz;
        private WMSOffice.Data.Admin admin;
        private System.Windows.Forms.BindingSource qUQuizBindingSource;
        private WMSOffice.Data.AdminTableAdapters.QU_QuizTableAdapter qU_QuizTableAdapter;
        private System.Windows.Forms.BindingSource qUQuestionTemplatesBindingSource;
        private WMSOffice.Data.AdminTableAdapters.QU_QuestionTemplatesTableAdapter qU_QuestionTemplatesTableAdapter;
        private System.Windows.Forms.BindingSource qUCriterionTypesBindingSource;
        private WMSOffice.Data.AdminTableAdapters.QU_CriterionTypesTableAdapter qU_CriterionTypesTableAdapter;
        private System.Windows.Forms.BindingSource qUAnswersBindingSource;
        private WMSOffice.Data.AdminTableAdapters.QU_AnswersTableAdapter qU_AnswersTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn dataGridViewDatePickerColumn1;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn dataGridViewDatePickerColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.TabControl tcQuestionsSettings;
        private System.Windows.Forms.TabPage tpAnswersBuilder;
        private System.Windows.Forms.TabPage tpCriterionLink;
        private System.Windows.Forms.ToolStrip tsQuestionOptions;
        private System.Windows.Forms.ToolStripButton sbAddQuestion;
        private System.Windows.Forms.DataGridView dgvCriterionLinks;
        private System.Windows.Forms.BindingSource qUQuestionsBindingSource;
        private WMSOffice.Data.AdminTableAdapters.QU_QuestionsTableAdapter qU_QuestionsTableAdapter;
        private System.Windows.Forms.GroupBox gbQuestions;
        private System.Windows.Forms.ToolStrip sbMainOptions;
        private System.Windows.Forms.ToolStripButton sbRefresh;
        private System.Windows.Forms.ToolStripButton sbSaveChanges;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbCriterionFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private WMSOffice.Controls.Custom.ColorPickerColumn colorPickerColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn quizidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn doctypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxcountemployeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxcountdocDataGridViewTextBoxColumn;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn periodfromDataGridViewTextBoxColumn;
        private WMSOffice.Controls.Custom.DataGridViewDatePickerColumn periodtoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn answeridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn2;
        private WMSOffice.Controls.Custom.ColorPickerColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priorityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn questionidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn criterionvalueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn templateidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxanswerscountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn criteriontypeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perQuestionsCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn perCriterionsPartCoverage;
        private System.Windows.Forms.DataGridViewTextBoxColumn perCriterionsFullCoverage;
    }
}