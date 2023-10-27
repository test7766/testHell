using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Диалог для выбора вариантов создания счетных листов (счетных заданий)
    /// </summary>
    public partial class CreateCountSheetsForm : DialogForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public CreateCountSheetsForm()
        {
            InitializeComponent();
        }
              
        /// <summary>
        /// Возвращает признак, показывающий, нужно ли создавать обычные счетные листы (для дроби)
        /// </summary>
        public bool CreateUsual
        {
            get { return rbUsual.Checked; }
        }

        /// <summary>
        /// Возвращает признак, показывающий, нужно ли создавать пустые счетные листы (напр., для излишков)
        /// </summary>
        public bool CreateEmpty
        {
            get { return rbEmpty.Checked; }
        }

        /// <summary>
        /// Возвращает признак, показывающий, нужно ли создавать счетные задания для ТСД (для ящиков)
        /// </summary>
        public bool CreateWO
        {
            get { return rbWO.Checked; }   
        }

        /// <summary>
        /// Возвращает количество создаваемых пустых счетных листов
        /// </summary>
        public int CountEmpty
        {
            get
            {
                int result = 0;
                int.TryParse(tbEmptyCount.Text, out result);
                return result;
            }
        }

        /// <summary>
        /// Возвращает количество создаваемых счетных заданий для ТСД
        /// </summary>
        public int CountWO
        {
            get
            {
                int result = 0;
                int.TryParse(tbWOCount.Text, out result);
                return result;
            }
        }

        /// <summary>
        /// Меняет состояние элементов управления при переключении радиокнопок
        /// </summary>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            lblEmptyCount.Enabled = tbEmptyCount.Enabled = rbEmpty.Checked;
            lblWOCount.Enabled = tbWOCount.Enabled = rbWO.Checked;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК"
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            bool canClose = true;
            if (CreateEmpty && CountEmpty == 0)
            {
                MessageBox.Show("Не задано (или задано некорректно) число создаваемых пустых счетных листов!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                canClose = false;
            }
            if (CreateWO && CountWO == 0)
            {
                MessageBox.Show("Не задано (или задано некорректно) число создаваемых счетных заданий для ТСД!",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                canClose = false;
            }

            if (canClose)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
