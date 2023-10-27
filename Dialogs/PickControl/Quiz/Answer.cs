using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class Answer
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Номер ответа
        /// </summary>
        public int AnswerID { get; set; }

        /// <summary>
        /// Номер шаблона вопроса 
        /// </summary>
        public int TemplateID { get; set; }

        /// <summary>
        /// Текст ответа
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Цвет ответа
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        public int Priority { get; set; }

        /// <summary>
        /// Длительность ответа на вопрос
        /// </summary>
        public long EventDelay { get; set; }

        public Question Question { get; set; }
        #endregion
    }

    public class AnswersList : List<Answer>
    {
        private Question question = null; 

        public AnswersList(Question question)
        {
            this.question = question;
        }
        
        public new void Add(Answer answer)
        {
            answer.Question = question;
            base.Add(answer);
        }
    }
}
