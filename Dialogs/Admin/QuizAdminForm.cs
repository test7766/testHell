using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;
using System.Transactions;

namespace WMSOffice.Dialogs.Admin
{
    public partial class QuizAdminForm : Form
    {
        private Data.Admin.QU_QuizRow selectedQuiz;
        private Data.Admin.QU_QuestionTemplatesRow selectedQuestionTemplate;
        private Data.Admin.QU_AnswersRow selectedAnswer;
        private Data.Admin.QU_QuestionsRow selectedQuestion;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public QuizAdminForm()
        {
            InitializeComponent();
        }

        private void QuizAdminForm_Load(object sender, EventArgs e)
        {
            var headerCell = new DatagridViewCheckBoxHeaderCell();
            dgvCriterionLinks.Columns[IsChecked.Index].HeaderCell = headerCell;
            headerCell.OwningColumn.ToolTipText = "Отм.";
            headerCell.CheckBoxClicked += IsChecked_CheckBoxClicked;

            this.RefreshData();
        }

        /// <summary>
        /// Перечитка данных
        /// </summary>
        private void RefreshData()
        {
            this.admin.Clear();
            this.LoadQuiz();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        /// <summary>
        /// Обрабатывает клик по флажку в заголовке столбца "Отм.".
        /// </summary>
        private void IsChecked_CheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCriterionLinks.Rows)
                row.Cells[IsChecked.Index].Value = e.IsChecked;
            
            dgvCriterionLinks.RefreshEdit();
        }

        #region ЗАГРУЗКА ДАННЫХ ОПРОСА
        private void LoadQuiz()
        {
            try
            {
                this.qU_QuizTableAdapter.Fill(this.admin.QU_Quiz);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCriterionTypes()
        {
            try
            {
                this.qU_CriterionTypesTableAdapter.Fill(this.admin.QU_CriterionTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdaptQuestionTemplates()
        {
            try
            {
                if (this.selectedQuiz != null && !this.selectedQuiz.IsQuestionTemplatesLoaded)
                {
                    this.qU_QuestionTemplatesTableAdapter.Fill(this.admin.QU_QuestionTemplates, this.selectedQuiz.quiz_id);
                    this.selectedQuiz.IsQuestionTemplatesLoaded = true;
                    this.selectedQuiz.AcceptChanges();
                }

                this.SetQuestionTemplatesFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdaptAnswers()
        {
            try
            {
                if (this.selectedQuestionTemplate != null && !this.selectedQuestionTemplate.IsAnswersLoaded)
                {
                    this.qU_AnswersTableAdapter.Fill(this.admin.QU_Answers, this.selectedQuestionTemplate.template_id);
                    this.selectedQuestionTemplate.IsAnswersLoaded = true;

                    if (this.selectedQuestionTemplate.IsQuestionsLoaded)
                        this.selectedQuestionTemplate.AcceptChanges();
                }

                this.SetAnswersFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void AdaptQuestions()
        {
            try
            {
                if (this.selectedQuestionTemplate != null && !this.selectedQuestionTemplate.IsQuestionsLoaded)
                {
                    this.qU_QuestionsTableAdapter.Fill(this.admin.QU_Questions, this.selectedQuestionTemplate.template_id);
                    this.selectedQuestionTemplate.IsQuestionsLoaded = true;

                    if (this.selectedQuestionTemplate.IsAnswersLoaded)
                        this.selectedQuestionTemplate.AcceptChanges();
                }

                this.SetQuestionsFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdaptQuestionsInBackground()
        {
            if (this.tcQuestionsSettings.SelectedTab != this.tpCriterionLink)
                return;

            bool isOptionsEnabled = this.selectedQuestionTemplate != null;

            BackgroundWorker loadCriterionWorker = new BackgroundWorker();
            loadCriterionWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    qUQuestionsBindingSource.SuspendBinding();

                    this.AdaptQuestions();

                    //// Обновление UI в процессе вставки записей из буфера
                    if (dgvCriterionLinks.InvokeRequired)
                    {
                        RefreshGridDelegate refreshHandler = new RefreshGridDelegate(RefreshCriterionLinksGrid);
                        dgvCriterionLinks.Invoke(refreshHandler, false);
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadCriterionWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                qUQuestionsBindingSource.ResetBindings(false);
                qUQuestionsBindingSource.ResumeBinding();

                this.splashForm.CloseForce();
            };

            this.splashForm.ActionText = "Выполняется загрузка значений критерия";
            loadCriterionWorker.RunWorkerAsync();
            this.splashForm.ShowDialog();

            sbAddQuestion.Enabled = isOptionsEnabled;
            tbCriterionFilter.Enabled = isOptionsEnabled;
        }

        #endregion

        #region УСТАНОВКА ФИЛЬТРА

        private void SetQuestionTemplatesFilter()
        {
            var quizID = this.selectedQuiz == null ? Int32.MinValue : this.selectedQuiz.quiz_id;
            this.qUQuestionTemplatesBindingSource.Filter = this.CreateQuestionTemplatesFilter(quizID);
        }

        private string CreateQuestionTemplatesFilter(int quizID)
        {
            return string.Format("{0} = {1}", this.admin.QU_QuestionTemplates.quiz_idColumn.Caption, quizID);
        }

        private void SetAnswersFilter()
        {
            var templateID = this.selectedQuestionTemplate == null ? Int32.MinValue : this.selectedQuestionTemplate.template_id;
            this.qUAnswersBindingSource.Filter = this.CreateAnswersFilter(templateID);
        }

        private string CreateAnswersFilter(int templateID)
        {
            return string.Format("{0} = {1}", this.admin.QU_Answers.template_idColumn.Caption, templateID);
        }

        private void SetQuestionsFilter()
        {
            var templateID = this.selectedQuestionTemplate == null ? Int32.MinValue : this.selectedQuestionTemplate.template_id;
            this.qUQuestionsBindingSource.Filter = this.CreateQuestionsFilter(templateID);
        }

        private string CreateQuestionsFilter(int templateID)
        {
            return string.Format("{0} = {1} AND {2} LIKE '%{3}%'", this.admin.QU_Questions.template_idColumn.Caption, templateID, this.admin.QU_Questions.criterion_valueColumn.Caption, tbCriterionFilter.Text);
        }
        #endregion

        #region СМЕНА ВЫДЕЛЕНИЯ ЭЛЕМЕНТОВ ОПРОСА
        private void dgvQuiz_SelectionChanged(object sender, EventArgs e)
        {
            this.selectedQuiz= this.dgvQuiz.SelectedCells.Count != 0 ? (dgvQuiz.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.Admin.QU_QuizRow : null;
            bool isOptionsEnabled = this.selectedQuiz != null;

            this.LoadCriterionTypes();
            this.AdaptQuestionTemplates();
            
            sbAddQuestionTemplate.Enabled = isOptionsEnabled;
        }

        private void dgvQuestionTemplates_SelectionChanged(object sender, EventArgs e)
        {
            this.selectedQuestionTemplate = this.dgvQuestionTemplates.SelectedCells.Count != 0 ? (dgvQuestionTemplates.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.Admin.QU_QuestionTemplatesRow : null;
            bool isOptionsEnabled = this.selectedQuestionTemplate != null;

            this.AdaptAnswers();

            this.AdaptQuestionsInBackground();

            sbAddAnswer.Enabled = isOptionsEnabled;
        }

        private void dgvAnswers_SelectionChanged(object sender, EventArgs e)
        {
            this.selectedAnswer = this.dgvAnswers.SelectedCells.Count != 0 ? (dgvAnswers.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.Admin.QU_AnswersRow : null;
        }

        private void dgvCriterionLinks_SelectionChanged(object sender, EventArgs e)
        {
            this.selectedQuestion = this.dgvCriterionLinks.SelectedCells.Count != 0 ? (dgvCriterionLinks.SelectedCells[0].OwningRow.DataBoundItem as DataRowView).Row as Data.Admin.QU_QuestionsRow : null;
        }
        #endregion

        #region ДОБАВЛЕНИЕ ЭЛЕМЕНТОВ ОПРОСА
        private void sbAddQuiz_Click(object sender, EventArgs e)
        {
            var row = this.admin.QU_Quiz.NewQU_QuizRow();
            row.name = "<Название опроса>";
            row.max_count_doc = 0;
            row.max_count_employee = 0;
            row.period_from = DateTime.Today;
            row.period_to = DateTime.Today.AddDays(1);
            row.IsQuestionTemplatesLoaded = true;

            this.admin.QU_Quiz.AddQU_QuizRow(row);
        }

        private void sbAddQuestionTemplate_Click(object sender, EventArgs e)
        {
            var row = this.admin.QU_QuestionTemplates.NewQU_QuestionTemplatesRow();
            row.name = "<Название шаблона вопроса>";
            row.max_answers_count = 0;
            row.quiz_id = this.selectedQuiz.quiz_id;
            row.criterion_type_id = this.admin.QU_CriterionTypes[0].type_id;
            row.IsAnswersLoaded = true;
            row.IsQuestionsLoaded = true;

            this.admin.QU_QuestionTemplates.AddQU_QuestionTemplatesRow(row);
        }

        private void sbAddAnswer_Click(object sender, EventArgs e)
        {
            var row = this.admin.QU_Answers.NewQU_AnswersRow();
            row.name = "<Название ответа>";
            row.priority = 1;
            row.color = "Black";
            row.template_id = this.selectedQuestionTemplate.template_id;

            this.admin.QU_Answers.AddQU_AnswersRow(row);
        }

        private void sbAddQuestion_Click(object sender, EventArgs e)
        {
            tbCriterionFilter.Clear();
            SetQuestionsFilter();

            var criterionValue = "<Значение критерия>";
            this.AddQuestion(criterionValue);
        }

        private void AddQuestion(string criterionValue)
        {
            var row = this.admin.QU_Questions.NewQU_QuestionsRow();
            row.criterion_value = criterionValue;
            row.template_id = this.selectedQuestionTemplate.template_id;
            row.IsChecked = true;

            this.admin.QU_Questions.AddQU_QuestionsRow(row);
        }
        #endregion

        private void tcQuestionsSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tcQuestionsSettings.SelectedTab == this.tpAnswersBuilder)
            {
                this.tbCriterionFilter.Clear();
                return;
            }

            if (this.tcQuestionsSettings.SelectedTab == this.tpCriterionLink)
            {
                this.AdaptQuestionsInBackground();
                this.dgvCriterionLinks.Focus();
                return;
            }
        }    


        delegate void RefreshGridDelegate(bool schemaUpdated);
        private void RefreshCriterionLinksGrid(bool schemaUpdated)
        {
            qUQuestionsBindingSource.SuspendBinding();
            qUQuestionsBindingSource.ResetBindings(false);

            dgvCriterionLinks.Refresh();
        }

        /// <summary>
        /// Вставка значений критерия из буфера обмена 
        /// </summary>
        private void PasteQuestionsFromClipboard()
        {
            var pastedText = Clipboard.GetText(TextDataFormat.Text);

            BackgroundWorker pasteCriterionWorker = new BackgroundWorker();
            pasteCriterionWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    qUQuestionsBindingSource.SuspendBinding();

                    foreach (var line in pastedText.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        foreach (var column in line.Split(new char[] { '\t' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var maxLength = this.admin.QU_Questions.criterion_valueColumn.MaxLength;
                            var criterionValue = column.Substring(0, column.Length > maxLength ? maxLength : column.Length).Trim();

                            if (!string.IsNullOrEmpty(criterionValue))
                                this.AddQuestion(criterionValue);

                            //// Обновление UI в процессе вставки записей из буфера
                            if (dgvCriterionLinks.InvokeRequired)
                            {
                                RefreshGridDelegate refreshHandler = new RefreshGridDelegate(RefreshCriterionLinksGrid);
                                dgvCriterionLinks.Invoke(refreshHandler, false);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            pasteCriterionWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                qUQuestionsBindingSource.ResetBindings(false);
                qUQuestionsBindingSource.ResumeBinding();

                this.splashForm.CloseForce();
            };

            this.splashForm.ActionText = "Выполняется вставка значений критерия из буфера обмена";
            pasteCriterionWorker.RunWorkerAsync();
            this.splashForm.ShowDialog();
        }

        private void dgvCriterionLinks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
            {
                if (this.selectedQuestionTemplate == null)
                    MessageBox.Show("Для вставки значений критерия необходимо\r\nвыбрать шаблон вопроса.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                {
                    tbCriterionFilter.Clear();
                    SetQuestionsFilter();
                    this.PasteQuestionsFromClipboard();
                }
            }
        }

        private void tbCriterionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SetQuestionsFilter();
            }
        }

        private void dgvQuestionTemplates_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvQuestionTemplates.Columns[e.ColumnIndex].DataPropertyName.StartsWith("per"))
            {
                Color statisticsColor = Color.LightGray;
                dgvQuestionTemplates.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = statisticsColor;
                dgvQuestionTemplates.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = statisticsColor;
                dgvQuestionTemplates.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.Black;
            }
        }

        #region ВАЛИДАТОРЫ
        private void dgvQuiz_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (dgvQuiz.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Quiz.max_count_employeeColumn.Caption ||
                dgvQuiz.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Quiz.max_count_docColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать целое числовое значение.", dgvQuiz.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (dgvQuiz.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Quiz.nameColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать непустое значение.", dgvQuiz.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
       
        private void dgvQuestionTemplates_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (dgvQuestionTemplates.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_QuestionTemplates.max_answers_countColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать целое числовое значение.", dgvQuestionTemplates.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (dgvQuestionTemplates.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_QuestionTemplates.nameColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать непустое значение.", dgvQuestionTemplates.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dgvAnswers_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (dgvAnswers.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Answers.priorityColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать целое числовое значение.", dgvAnswers.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (dgvAnswers.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Answers.nameColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать непустое значение.", dgvAnswers.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void dgvCriterionLinks_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (dgvCriterionLinks.Columns[e.ColumnIndex].DataPropertyName == this.admin.QU_Questions.criterion_valueColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать непустое значение.", dgvCriterionLinks.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
        #endregion       

        #region СОБЫТИЯ АДАПТАЦИИ ИЗМЕНЕНИЙ В ДАННЫХ
        private void dgvCriterionLinks_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                gridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvData_Leave(object sender, EventArgs e)
        {
            var dataGridView = sender as DataGridView;
            dataGridView.EndEdit();
        }

        private void dgvData_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dataGridView = sender as DataGridView;
            dataGridView.Refresh();
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //var dataGridView = sender as DataGridView;
            //if (dataGridView.CurrentRow != null && !dataGridView.CurrentRow.Cells[e.ColumnIndex].ReadOnly)
            //    dataGridView.BeginEdit(true);
        }
        #endregion

        private void sbSaveChanges_Click(object sender, EventArgs e)
        {
            tbCriterionFilter.Clear();
            SetQuestionsFilter();
            this.PrepareQuestionsToRemove(false);


            var conflictedQuestionTemplates = new List<int>();
            var conflictedQuestions = new List<int>();
            var conflictedAnswers = new List<int>();

            TransactionOptions tranOptions = new TransactionOptions();
            tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

             // Открываем транзакцию
            using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required, tranOptions))
            {
                try
                {
                    DataViewRowState processingRowState = DataViewRowState.Unchanged | DataViewRowState.Added | DataViewRowState.ModifiedCurrent | DataViewRowState.Deleted;
                    foreach (Data.Admin.QU_QuizRow quiz in this.admin.QU_Quiz.Rows)
                    {
                        switch (quiz.RowState)
                        {
                            case DataRowState.Added:
                            case DataRowState.Modified:
                            case DataRowState.Unchanged:

                                #region ВСТАВКА / МОДИФИКАЦИЯ ОПРОСА

                                if (quiz.RowState == DataRowState.Added || quiz.RowState == DataRowState.Modified)
                                    this.qU_QuizTableAdapter.Update(quiz);

                                #region АНАЛИЗ ШАБЛОНОВ ВОПРОСОВ
                                foreach (Data.Admin.QU_QuestionTemplatesRow template in this.admin.QU_QuestionTemplates.Select(this.CreateQuestionTemplatesFilter(quiz.quiz_id), null, processingRowState)) // фильтр
                                {
                                    switch (template.RowState)
                                    {
                                        case DataRowState.Added:
                                        case DataRowState.Modified:
                                        case DataRowState.Unchanged:

                                            #region ВСТАВКА / МОДИФИКАЦИЯ ШАБЛОНА ВОПРОСА

                                            if (quiz.RowState == DataRowState.Added)
                                                template.quiz_id = quiz.quiz_id;

                                            if (template.RowState == DataRowState.Added)
                                                template.template_id = Convert.ToInt32(this.qU_QuestionTemplatesTableAdapter.InsertQuestionTemplate(template.name, template.max_answers_count, template.quiz_id, template.criterion_type_id));

                                            if (template.RowState == DataRowState.Modified)
                                                this.qU_QuestionTemplatesTableAdapter.UpdateQuestionTemplate(template.template_id, template.name, template.max_answers_count, template.quiz_id, template.criterion_type_id);

                                            #region АНАЛИЗ ВАРИАНТОВ ОТВЕТОВ
                                            foreach (Data.Admin.QU_AnswersRow answer in this.admin.QU_Answers.Select(this.CreateAnswersFilter(template.template_id), null, processingRowState)) // фильтр 
                                            {
                                                switch (answer.RowState)
                                                {
                                                    case DataRowState.Added:
                                                    case DataRowState.Modified:

                                                        #region ВСТАВКА ВАРИАНТА ОТВЕТА
                                                        if (template.RowState == DataRowState.Added)
                                                            answer.template_id = template.template_id;
                                                        qU_AnswersTableAdapter.Update(answer);
                                                        break;
                                                        #endregion

                                                    case DataRowState.Deleted:
                                                        #region УДАЛЕНИЕ ВАРИАНТА ОТВЕТА
                                                        var originalAnswerID = Convert.ToInt32(answer["answer_id", DataRowVersion.Original]);

                                                        // TODO не использовать!
                                                        //qU_AnswersTableAdapter.Update(answer);

                                                        if (!Convert.ToBoolean(qU_AnswersTableAdapter.DeleteAnswer(originalAnswerID)))
                                                            conflictedAnswers.Add(originalAnswerID);

                                                        #endregion
                                                        break;

                                                    default:
                                                        break;
                                                }
                                            }
                                            #endregion

                                            #region АНАЛИЗ ВОПРОСОВ
                                            foreach (Data.Admin.QU_QuestionsRow question in this.admin.QU_Questions.Select(this.CreateQuestionsFilter(template.template_id), null, processingRowState)) // фильтр
                                            {
                                                switch (question.RowState)
                                                {
                                                    case DataRowState.Added:
                                                    case DataRowState.Modified:

                                                        #region ВСТАВКА / МОДИФИКАЦИЯ ВОПРОСА
                                                        if (template.RowState == DataRowState.Added)
                                                            question.template_id = template.template_id;
                                                        qU_QuestionsTableAdapter.Update(question);
                                                        #endregion
                                                        break;

                                                    case DataRowState.Deleted:
                                                        #region УДАЛЕНИЕ ВОПРОСА

                                                        var originalQuestionID = Convert.ToInt32(question["question_id", DataRowVersion.Original]);

                                                        // TODO не использовать!
                                                        //qU_QuestionsTableAdapter.Update(question);

                                                          if (!Convert.ToBoolean(qU_QuestionsTableAdapter.DeleteQuestion(originalQuestionID)))
                                                              conflictedQuestions.Add(originalQuestionID);

                                                        #endregion
                                                        break;

                                                }
                                            }
                                            #endregion
                                            #endregion
                                            break;

                                        case DataRowState.Deleted:
                                            #region УДАЛЕНИЕ ШАБЛОНА ВОПРОСА

                                            bool allowDeleteQuestionTemplate = true;

                                            var originalTemplateID = Convert.ToInt32(template["template_id", DataRowVersion.Original]);
                                            #region АНАЛИЗ ВАРИАНТОВ ОТВЕТОВ
                                            var lstAnswersToDelete = new List<Data.Admin.QU_AnswersRow>();
                                            foreach (Data.Admin.QU_AnswersRow answer in this.admin.QU_Answers.Select(this.CreateAnswersFilter(originalTemplateID), null, processingRowState)) // фильтр 
                                                lstAnswersToDelete.Add(answer);

                                            foreach (var item in lstAnswersToDelete)
                                            {
                                                if (item.RowState != DataRowState.Deleted)
                                                    item.Delete();

                                                //this.admin.QU_Answers.Rows.Remove(item);
                                                var originalAnswerID = Convert.ToInt32(item["answer_id", DataRowVersion.Original]);
                                                
                                                // TODO не использовать!
                                                //qU_AnswersTableAdapter.Update(item);

                                                if (!Convert.ToBoolean(qU_AnswersTableAdapter.DeleteAnswer(originalAnswerID)))
                                                {
                                                    conflictedAnswers.Add(originalAnswerID);
                                                    allowDeleteQuestionTemplate = false;
                                                }
                                            }

                                            #endregion

                                            #region АНАЛИЗ ВОПРОСОВ
                                            var lstQuestionsToDelete = new List<Data.Admin.QU_QuestionsRow>();
                                            foreach (Data.Admin.QU_QuestionsRow question in this.admin.QU_Questions.Select(this.CreateQuestionsFilter(originalTemplateID), null, processingRowState)) // фильтр
                                                lstQuestionsToDelete.Add(question);

                                            foreach (var item in lstQuestionsToDelete)
                                            {
                                                if (item.RowState != DataRowState.Deleted)
                                                    item.Delete();

                                                //this.admin.QU_Questions.Rows.Remove(item);
                                                var originalQuestionID = Convert.ToInt32(item["question_id", DataRowVersion.Original]);

                                                // TODO не использовать!
                                                //qU_QuestionsTableAdapter.Update(item);

                                                if (!Convert.ToBoolean(qU_QuestionsTableAdapter.DeleteQuestion(originalQuestionID)))
                                                {
                                                    conflictedQuestions.Add(originalQuestionID);
                                                    allowDeleteQuestionTemplate = false;
                                                }
                                            }
                                            #endregion

                                            if (allowDeleteQuestionTemplate)
                                                qU_QuestionTemplatesTableAdapter.DeleteQuestionTemplate(originalTemplateID);
                                            else
                                                conflictedQuestionTemplates.Add(originalTemplateID);
                                            #endregion
                                            break;

                                        default:
                                            break;
                                    }
                                }
                                #endregion

                                #endregion
                                break;

                            default:
                                break;
                        }
                    }

                    // Фиксирование транзакции
                    scope.Complete();

                    var sbMessage = new StringBuilder();

                    if (conflictedQuestionTemplates.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder("Не удалось сохранить следующие шаблоны вопросов: ");
                        foreach (var item in conflictedQuestionTemplates)
                            sb.AppendFormat("{0},", item);

                        sbMessage.AppendFormat("{0}\n", sb.ToString().TrimEnd(','));
                    }

                    if (conflictedAnswers.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder("Не удалось сохранить следующие варианты ответов: ");
                        foreach (var item in conflictedAnswers)
                            sb.AppendFormat("{0},", item);

                        sbMessage.AppendFormat("{0}\n", sb.ToString().TrimEnd(','));
                    }

                    if (conflictedQuestions.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder("Не удалось сохранить следующие вопросы: ");
                        foreach (var item in conflictedQuestions)
                            sb.AppendFormat("{0},", item);

                        sbMessage.AppendFormat("{0}\n", sb.ToString().TrimEnd(','));
                    }

                    sbMessage.AppendFormat("Сохранение завершено.");

                    MessageBox.Show(sbMessage.ToString(), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    //this.RefreshData();
                    //this.admin.AcceptChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.admin.RejectChanges();
                    return;
                }
            }
        }

        #region УДАЛЕНИЕ ЗАПИСЕЙ
        private void dgvAnswers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (this.selectedAnswer != null)
                    if (MessageBox.Show("Вы действительно хотите удалить этот вариант ответа?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                        this.selectedAnswer.Delete();
        }

        private void dgvQuestionTemplates_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                if (this.selectedQuestionTemplate != null)
                    if (MessageBox.Show("Вы действительно хотите удалить этот шаблон вопроса?", "Внимание", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
                    {
                        this.PrepareAnswersToRemove();

                        tbCriterionFilter.Clear();
                        SetQuestionsFilter();
                        this.PrepareQuestionsToRemove(true);

                        this.selectedQuestionTemplate.Delete();
                    }
        }

        private void PrepareQuestionsToRemove(bool isAutoDeleted)
        {
            var lstToRemove = new List<Data.Admin.QU_QuestionsRow>();

            foreach (Data.Admin.QU_QuestionsRow criterionValue in this.admin.QU_Questions.Select(this.qUQuestionsBindingSource.Filter))
                if (isAutoDeleted || !criterionValue.IsChecked)
                    lstToRemove.Add(criterionValue);

            foreach (var item in lstToRemove)
            {
                if (item.RowState != DataRowState.Deleted)
                    item.Delete();
                //this.admin.QU_Questions.Rows.Remove(item);
            }
        }

        private void PrepareAnswersToRemove()
        {
            var lstToRemove = new List<Data.Admin.QU_AnswersRow>();

            foreach (Data.Admin.QU_AnswersRow answer in this.admin.QU_Answers.Select(this.qUAnswersBindingSource.Filter))
                lstToRemove.Add(answer);

            foreach (var item in lstToRemove)
            {
                if (item.RowState != DataRowState.Deleted)
                    item.Delete();
                //this.admin.QU_Answers.Rows.Remove(item);
            }
        }
        #endregion       
    }
}
