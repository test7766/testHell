using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.Quiz
{
    public partial class QuizForm : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        private bool closeForce = false;

        private DateTime beginWorkWithQuizAnswer;

        private ToolTip tip = new ToolTip() { IsBalloon = true };

        public Question Question { get; private set; }

        public Answer Answer { get; private set; }

        #endregion

        public QuizForm()
        {
            InitializeComponent();
        }

        public QuizForm(Question question)
            : this()
        {
            this.Question = question;
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            this.PrepareQuestion();
            beginWorkWithQuizAnswer = DateTime.Now;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            var items = new List<CustomLabel>();
            foreach (var item in tlpAnswers.Controls)
                if (item is CustomLabel)
                    items.Add(item as CustomLabel);

            return CustomLabel.HandleKeyForItems(items, keyData) ? true : base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Подготовка вопроса к викторине
        /// </summary>
        private void PrepareQuestion()
        {
            tip.SetToolTip(lblHelpText, lblHelpText.Text);

            lblQuestion.Text = this.Question.Text;
            tip.SetToolTip(lblQuestion, lblQuestion.Text);
            tlpAnswers.RowCount = this.Question.Answers.Count;

            for (int i = 0; i < this.Question.Answers.Count; i++)
            {
                var position = i + 1;
                var item = new CustomLabel(position);
                item.Tag = this.Question.Answers[i];
                item.Prefix = "F";
                item.Content = this.Question.Answers[i].Text;
                tip.SetToolTip(item, item.Content);
                item.ForeColor = Color.FromName(this.Question.Answers[i].Color);
                //item.ForeColor = ColorShuffleHelper.GetColor(i);
                item.AutoSize = true;
                item.Margin = new Padding(5, 15, 0, 0);
                item.OnSelectItem += new EventHandler(item_OnSelectItem);
                item.OnApplySelection += new EventHandler(item_OnApplySelection);

                tlpAnswers.Controls.Add(item, 0, i);

                if (i > 0)
                    tlpAnswers.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            }
        }

        void item_OnSelectItem(object sender, EventArgs e)
        {
            tlpAnswers.ScrollControlIntoView(sender as CustomLabel);
        }

        void item_OnApplySelection(object sender, EventArgs e)
        {
            this.Answer = (sender as CustomLabel).Tag as Answer;
            this.Answer.EventDelay = (long)(DateTime.Now - beginWorkWithQuizAnswer).TotalMilliseconds;
            closeForce = true;
            this.Close();
        }

        private void QuizForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !closeForce;
        }
    }
}
