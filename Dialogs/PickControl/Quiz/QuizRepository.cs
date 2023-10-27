using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class QuizRepository
    {
        private readonly List<Question> repository = new List<Question>();

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; private set; }

        /// <summary>
        /// Номер документа
        /// </summary>
        public long RelatedDocID { get; private set; }

        /// <summary>
        /// Тип документа
        /// </summary>
        public string RelatedDocType { get; private set; }
        #endregion

        public QuizRepository(long relatedDocID, string relatedDocType, long userID)
        {
            this.RelatedDocID = relatedDocID;
            this.RelatedDocType = relatedDocType;
            this.UserID = userID;

            this.Refresh();
        }

        /// <summary>
        /// Обновление списка вопросов
        /// </summary>
        private void Refresh()
        {
            repository.Clear();

            try
            {
                #region ФОРМИРОВАНИЕ ВОПРОСОВ 
                
                var questions = new Data.PickControl.QuizQuestionDataTable();

                using (var adapter = new Data.PickControlTableAdapters.QuizQuestionTableAdapter())
                    adapter.Fill(questions, this.UserID, this.RelatedDocType, this.RelatedDocID);

                foreach (Data.PickControl.QuizQuestionRow rowQuestion in questions.Rows)
                {
                    var question = new Question()
                    {
                        QuizID = rowQuestion.quiz_id,
                        TemplateID = rowQuestion.template_id,
                        QuestionID = rowQuestion.question_id,
                        CriterionTypeID = rowQuestion.criterion_type_id,
                        CriterionValue = rowQuestion.criterion_value,
                        Text = rowQuestion.name,

                        RelatedDocID = this.RelatedDocID,
                        RelatedDocType = this.RelatedDocType
                    };

                    #region ФОРМИРОВАНИЕ ОТВЕТОВ

                    var answers = new Data.PickControl.QuizAnswerDataTable();
                    using (var adapter = new Data.PickControlTableAdapters.QuizAnswerTableAdapter())
                        adapter.Fill(answers, this.UserID, question.QuestionID);

                    foreach (Data.PickControl.QuizAnswerRow rowAnswer in answers.Rows)
                    {
                        var answer = new Answer()
                        {
                            AnswerID = rowAnswer.answer_id,
                            TemplateID = rowAnswer.template_id,
                            Color = rowAnswer.color,
                            Text = rowAnswer.name,
                            Priority = rowAnswer.priority
                        };

                        question.Answers.Add(answer);
                    }

                    #endregion ФОРМИРОВАНИЕ ОТВЕТОВ

                    repository.Add(question);
                }

                #endregion ФОРМИРОВАНИЕ ВОПРОСОВ
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Извлечение очередного вопроса
        /// </summary>
        /// <param name="criterionFieldName"></param>
        /// <param name="criterionValue"></param>
        /// <returns></returns>
        public Question GetQuestion(string criterionFieldName, string criterionValue)
        {
            foreach (var question in repository)
                if (question.CriterionTypeID.ToLower() == criterionFieldName.ToLower() && question.CriterionValue.ToLower() == criterionValue.ToLower())
                    return question;

            return null;
        }

        /// <summary>
        /// Отметка о получении ответа на вопрос
        /// </summary>
        /// <param name="question"></param>
        public void MarkAnswerQuestion(Question question)
        {
            repository.Remove(question);
        }
    }
}
