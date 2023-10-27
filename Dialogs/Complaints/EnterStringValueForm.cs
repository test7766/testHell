using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для ввода текстового значения.
    /// </summary>
    public partial class EnterStringValueForm : DialogForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="caption">Заголовок диалога.</param>
        /// <param name="promt">Описание запроса значения (что нужно ввести пользователю).</param>
        /// <param name="value">Инициализация значения (значение по умолчанию).</param>
        public EnterStringValueForm(string caption, string promt, string value)
        {
            InitializeComponent();

            this.Text = caption;
            lblPromt.Text = promt;
            tbValue.Text = value;
            btnOK.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Возвращает / устанавливает признак, показывающий, можно ли вводить пустое значение.
        /// </summary>
        public bool AllowEmptyValue { get; set; }

        /// <summary>
        /// Возвращает введенное пользователем значение.
        /// </summary>
        public string Value
        {
            get { return tbValue.Text.Trim(); }
        }

        /// <summary>
        /// Обрабатывает момент отображения формы.
        /// </summary>
        private void EnterStringValueForm_Shown(object sender, EventArgs e)
        {
            tbValue.Focus();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (AllowEmptyValue || !string.IsNullOrEmpty(tbValue.Text.Trim()))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Значение не введено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbValue.Focus();
            }
        }
    }
}
