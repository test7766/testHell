using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    /// <summary>
    /// Форма-проверка, нужно ли продолжать открытый документ приемки товара от поставщика либо нужно создать новый
    /// </summary>
    public partial class AlreadyOpenedDocumentForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// True, если форма закрывается посредством кнопок, False если посредством красного крестика
        /// </summary>
        private bool readyToClose;

        #endregion

        #region КОНСТРУКТОР

        public AlreadyOpenedDocumentForm(long pDocID)
        {
            InitializeComponent();
            lblUnclosedDoc.Text = String.Format("Не закрыт пак-лист № {0}. Закончите работу с ним!", pDocID.ToString());
        }

        #endregion

        #region ЗАКРЫТИЕ ФОРМЫ

        /// <summary>
        /// Закрыть окно - создание нового задания
        /// </summary>
        private void btnNewTask_Click(object sender, EventArgs e)
        {
            readyToClose = true;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        /// <summary>
        /// Закрыть окно - продолжение незакрытого задания
        /// </summary>
        private void btnContinueUnclosed_Click(object sender, EventArgs e)
        {
            readyToClose = true;
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// При закрытии нужно предупреждать, что будет открыт новый документ
        /// </summary>
        private void AlreadyOpenedDocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                this.DialogResult = DialogResult.Abort;

            //    if (!readyToClose)
            //    {
            //        if (MessageBox.Show("При выходе будет создано новое задание! Вы точно хотите закрыть окно?", "Незакрытые задания",
            //            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //            e.Cancel = true;
            //    }
        }

        #endregion
    }
}
