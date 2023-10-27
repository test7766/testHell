using System;
using System.Collections.Generic;
using System.Text;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public class Question
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Номер опроса
        /// </summary>
        public int QuizID { get; set; }

        /// <summary>
        /// Номер шаблона вопроса
        /// </summary>
        public int TemplateID { get; set; }

        /// <summary>
        /// Номер вопроса
        /// </summary>
        public int QuestionID { get; set; }

        /// <summary>
        /// Номер основного документа
        /// </summary>
        public long RelatedDocID { get; set; }

        /// <summary>
        /// Тип основного документа
        /// </summary>
        public string RelatedDocType { get; set; }

        /// <summary>
        /// Название поля для критерия
        /// </summary>
        public string CriterionTypeID { get; set; }

        /// <summary>
        /// Значение критерия
        /// </summary>
        public string CriterionValue { get; set; }

        /// <summary>
        /// Текст вопроса
        /// </summary>
        public string Text { get; set; }


        public AnswersList Answers { get; private set; }
        #endregion

        public Question()
        {
            this.Answers = new AnswersList(this);
        }
    }
}
