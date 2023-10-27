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
    /// Диалог для ввода даты подтверждения возврата (даты расчет-корректировки).
    /// </summary>
    public partial class EnterDateConfirmReturnForm : DialogForm
    {
        /// <summary>
        /// Тип вводимой даты.
        /// </summary>
        private CalculationDateType dateType;

        /// <summary>
        /// Дата р/к (нужна для проверок для типа вводимой даты CloseDate).
        /// </summary>
        private DateTime calculationDate;
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="dateType">Тип вводимой даты.</param>
        /// <param name="calculationDate">Дата р/к (нужна для проверок для типа вводимой даты CloseDate); если её еще нет, достаточно DateTime.Today.</param>
        public EnterDateConfirmReturnForm(CalculationDateType dateType, DateTime calculationDate)
        {
            InitializeComponent();

            this.dateType = dateType;
            this.calculationDate = calculationDate;

            switch (dateType)
            {
                case CalculationDateType.CalculationDate:
                    lblPromt.Text = "Введите дату\r\nрасчет-корректировки:";
                    break;

                case CalculationDateType.CloseDate:
                    lblPromt.Text = "Введите дату закрытия / получения клиентом расчет-корректировки (от " +
                        calculationDate.ToString("dd.MM.yyy") + " до " +
                        (new DateTime(calculationDate.Year, calculationDate.Month, DateTime.DaysInMonth(calculationDate.Year, calculationDate.Month))).ToString("dd.MM.yyy") + "):";
                    break;

                default:
                    lblPromt.Text = "Введите дату:";
                    break;
            }

            dtpValue.Value = calculationDate;
            btnOK.DialogResult = DialogResult.None;
        }

        /// <summary>
        /// Возвращает введенное пользователем значение.
        /// </summary>
        public DateTime Value
        {
            get { return dtpValue.Value; }
        }

        /// <summary>
        /// Обрабатывает момент отображения формы.
        /// </summary>
        private void EnterDateConfirmReturnForm_Shown(object sender, EventArgs e)
        {
            dtpValue.Focus();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dateType == CalculationDateType.CalculationDate)
            {
                if (dtpValue.Value.Date > new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month)).Date)
                {
                    MessageBox.Show("Дата расчет-корректировки не может быть больше конца текущего месяца!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpValue.Value.Date < new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).Date)
                {
                    if (MessageBox.Show("Вы выбрали дату расчет-корректировки менее начала текущего месяца. Продолжить сохранение этой даты?",
                        "Ошибка", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes)
                    {
                        return;
                    }
                }
            }
            else if (dateType == CalculationDateType.CloseDate)
            {
                if (dtpValue.Value.Date > new DateTime(calculationDate.Year, calculationDate.Month, DateTime.DaysInMonth(calculationDate.Year, calculationDate.Month)).Date)
                {
                    MessageBox.Show("Дата ЗАКРЫТИЯ расчет-корректировки (она же - дата получения клиентом р/к, дата ГК) не может быть БОЛЬШЕ конца месяца даты расчет-корректировки (вводилась при первой печати р/к)!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dtpValue.Value.Date < calculationDate)
                {
                    MessageBox.Show("Дата ЗАКРЫТИЯ расчет-корректировки (она же - дата получения клиентом р/к, дата ГК) не может быть МЕНЬШЕ даты расчет-корректировки (вводилась при первой печати р/к)!",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            
            DialogResult = DialogResult.OK;
            Close();
        }

        /// <summary>
        /// Тип даты для расчет-корректировки.
        /// </summary>
        public enum CalculationDateType
        {
            /// <summary>
            /// Дата р/к (вводится при первой печати).
            /// </summary>
            CalculationDate,
            /// <summary>
            /// Дата закрытия р/к, она же дата ГК (вводится при получении подписанных документов от клиента).
            /// </summary>
            CloseDate
        }
    }
}
