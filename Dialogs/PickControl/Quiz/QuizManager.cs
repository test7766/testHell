using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class QuizManager
    {
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

        /// <summary>
        /// Признак экстренного прекращения опроса
        /// </summary>
        private bool AbortQuiz = false;

        /// <summary>
        /// Репозитарий вопросов
        /// </summary>
        private QuizRepository repository = null;
        #endregion

        public QuizManager(long relatedDocID, string relatedDocType, long userID)
        {
            this.RelatedDocID = relatedDocID;
            this.RelatedDocType = relatedDocType;
            this.UserID = userID;
            repository = new QuizRepository(relatedDocID, relatedDocType, userID);
        }

        /// <summary>
        /// Попытка запуска опроса по данному критерию
        /// </summary>
        /// <param name="criterionFieldName"></param>
        /// <param name="criterionValue"></param>
        public void TryQuiz(string criterionFieldName, string criterionValue)
        {
            Question question = null;
            while ((question = this.GetNextQuestion(criterionFieldName, criterionValue)) != null)
            {
                this.AskQuestion(question);
                repository.MarkAnswerQuestion(question);
            }           
        }

        /// <summary>
        /// Поиск следующего вопроса
        /// </summary>
        /// <param name="criterionFieldName"></param>
        /// <param name="criterionValue"></param>
        /// <returns></returns>
        private Question GetNextQuestion(string criterionFieldName, string criterionValue)
        {
            if (this.AbortQuiz)
                return null;

            return repository.GetQuestion(criterionFieldName, criterionValue);
        }

        /// <summary>
        /// Отображение интерфейса опроса
        /// </summary>
        /// <param name="question"></param>
        private void AskQuestion(Question question)
        {
            using (var dlgQuiz = new QuizForm(question))
            {
                dlgQuiz.ShowDialog();
                if (dlgQuiz.Answer != null)
                    this.ApplyAnswer(dlgQuiz.Answer);
            }
        }

        /// <summary>
        /// Сохранение ответа на вопрос
        /// </summary>
        /// <param name="answer"></param>
        private void ApplyAnswer(Answer answer)
        {
            var question = answer.Question;
            int attempts = 3; // Кол-во попыток повторного сохранения ответа

            while (attempts-- > 0)
            {
                try
                {
                    using (var adapter = new Data.PickControlTableAdapters.QuizQuestionTableAdapter())
                        adapter.ApplyAnswer(this.UserID, question.QuestionID, answer.AnswerID, question.RelatedDocID, answer.EventDelay);

                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    if (attempts == 0)
                    {
                        MessageBox.Show(string.Format("Опрос будет экстренно завершен в связи со сбоем.\n\nСообщите об этом в ГСПО.\nНомер опроса: {0}", question.QuizID), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.AbortQuiz = true;
                    }
                }
            }

            
        }
    }
}
