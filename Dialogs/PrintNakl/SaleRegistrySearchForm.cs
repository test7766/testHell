using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PrintNakl
{
    public partial class SaleRegistrySearchForm : DialogForm
    {
        private const string ERROR_CAPTION = "Ошибка задания элементов фильтра";
        private const int MAX_ALLOWED_DATE_INTERVAL = 7; // максимально допустимый диапазон дат

        /// <summary>
        /// Предыдущая введенная пользователем дата "с".
        /// </summary>
        public static DateTime LastStartDate { get; private set; }
        /// <summary>
        /// Предыдущая введенная пользователем дата "по".
        /// </summary>
        public static DateTime LastEndDate { get; private set; }

        static SaleRegistrySearchForm()
        {
            DateTime dtPreviousDay = DateTime.Now.AddDays(-1);
            LastStartDate = dtPreviousDay;
            LastEndDate = dtPreviousDay;
        }

        public SaleRegistrySearchForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ApplyLastFilterSettings();
        }

        private void ApplyLastFilterSettings()
        {
            dtStartDate.Value = LastStartDate;
            dtEndDate.Value = LastEndDate;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void SaleRegistrySearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilterSettings();
        }

        /// <summary>
        /// Проверка установки допустимых значений для фильтра
        /// </summary>
        /// <returns></returns>
        private bool ValidateFilterSettings()
        {
            // Валидация корректности диапазона дат
            if (dtStartDate.Value > dtEndDate.Value)
            {
                MessageBox.Show("Начальная дата не должна превышать конечную.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtStartDate.Focus();
                return false;
            }

            // Валидация допустимости диапазона дат
            if (dtEndDate.Value.Subtract(dtStartDate.Value).Days > MAX_ALLOWED_DATE_INTERVAL)
            {
                MessageBox.Show(string.Format("Интервал между конечными датами не должен превышать {0} дней.", MAX_ALLOWED_DATE_INTERVAL), ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtStartDate.Focus();
                return false;
            }

            // Валидация ограничений в диапазоне дат
            if (dtStartDate.Value.Date > DateTime.Today || dtEndDate.Value.Date > DateTime.Today)
            {
                MessageBox.Show(string.Format("Нельзя выбрать дату большей чем текущая ({0}).", DateTime.Today.ToShortDateString()), ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtStartDate.Focus();
                return false;
            }

            LastStartDate = dtStartDate.Value;
            LastEndDate = dtEndDate.Value;
            return true;
        }
    }
}
