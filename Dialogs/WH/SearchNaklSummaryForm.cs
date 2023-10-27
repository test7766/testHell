using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Форма для поиска сводных налоговых накладных в архиве
    /// </summary>
    public partial class SearchNaklSummaryForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Код дебитора для поиска в архиве
        /// </summary>
        public int? DebtorID
        {
            get
            {
                if (String.IsNullOrEmpty(tbxDebtorId.Text))
                    return null;
                else
                    return Convert.ToInt32(tbxDebtorId.Text);
            }
            set
            {
                tbxDebtorId.Text = value.ToString();
            }
        }

        /// <summary>
        /// Дата "с" для поиска в архиве
        /// </summary>
        public DateTime? DateFrom
        {
            get { return chbDateFilter.Checked ? (DateTime?)dtpDateFrom.Value : null; }
            set
            {
                if (value == null)
                    chbDateFilter.Checked = false;
                else
                {
                    chbDateFilter.Checked = true;
                    dtpDateFrom.Value = value.Value;
                }

                dtpDateTo.Enabled = dtpDateFrom.Enabled = chbDateFilter.Checked;
            }
        }

        /// <summary>
        /// Дата "по" для поиска в архиве
        /// </summary>
        public DateTime? DateTo
        {
            get { return chbDateFilter.Checked ? (DateTime?)dtpDateTo.Value : null; }
            set
            {
                if (value == null)
                    chbDateFilter.Checked = false;
                else
                {
                    chbDateFilter.Checked = true;
                    dtpDateTo.Value = value.Value;
                }

                dtpDateTo.Enabled = dtpDateFrom.Enabled = chbDateFilter.Checked;
            }
        }

        /// <summary>
        /// Номер сводной налоговой для поиска в архиве
        /// </summary>
        public long? SNukl
        {
            get
            {
                if (String.IsNullOrEmpty(tbxSNukl.Text))
                    return null;
                else
                    return Convert.ToInt64(tbxSNukl.Text);
            }
            set { tbxSNukl.Text = value.ToString(); }
        }

        /// <summary>
        /// Признак "распечатан" для поиска в архиве
        /// </summary>
        public int? Printed
        {
            get
            {
                if (rbtPrinted.Checked)
                    return 1;
                else if (rbtNotPrinted.Checked)
                    return 0;
                else return null;
            }
            set
            {
                if (value == 1)
                    rbtPrinted.Checked = true;
                else if (value == 0)
                    rbtNotPrinted.Checked = true;
                else
                    rbtAll.Checked = true;
            }
        }

        /// <summary>
        /// Номер накладной для поиска в архиве
        /// </summary>
        public int? NuklNumber
        {
            get
            {
                if (String.IsNullOrEmpty(tbxNuklNumber.Text))
                    return null;
                else
                    return Convert.ToInt32(tbxNuklNumber.Text);
            }
            set { tbxNuklNumber.Text = value.ToString(); }
        }

        #endregion

        #region КОНСТРУКТОР

        public SearchNaklSummaryForm()
        {
            InitializeComponent();
            dtpDateFrom.Value = DateTime.Now.AddMonths(-1);
            dtpDateTo.Value = DateTime.Now;
        }

        #endregion

        #region СОХРАНЕНИЕ И ПРОВЕРКА ДАННЫХ

        /// <summary>
        /// Сохранение фильтров
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateFilters())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка, все ли фильтры заданы правильно
        /// </summary>
        /// <returns>True, если все фильтры заданы правильно, False если есть ошибки</returns>
        private bool ValidateFilters()
        {
            // Проверка, правильно ли задан код дебитора
            int debtorId;
            if (!String.IsNullOrEmpty(tbxDebtorId.Text) && !Int32.TryParse(tbxDebtorId.Text, out debtorId))
            {
                MessageBox.Show("Неверно задан код дебитора!", "Ошибка настройки фильтров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка, правильно ли задан номер сводной налоговой
            long snukl;
            if (!String.IsNullOrEmpty(tbxSNukl.Text) && !Int64.TryParse(tbxSNukl.Text, out snukl))
            {
                MessageBox.Show("Неверно задан номер сводной налоговой!", "Ошибка настройки фильтров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка, правильно ли задан номер накладной
            int nuklNumber;
            if (!String.IsNullOrEmpty(tbxNuklNumber.Text) && !Int32.TryParse(tbxNuklNumber.Text, out nuklNumber))
            {
                MessageBox.Show("Неверно задан номер накладной!", "Ошибка настройки фильтров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Проверка, правильно ли задан диапазон дат
            if (chbDateFilter.Checked && dtpDateFrom.Value > dtpDateTo.Value)
            {
                MessageBox.Show("\"Дата с\" не может быть больше, чем \"Дата по\"!", "Ошибка настройки фильтров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            if (chbDateFilter.Checked && (dtpDateTo.Value - dtpDateFrom.Value).TotalDays > 31)
            {
                MessageBox.Show("Диапазон дат должен быть не больше месяца!", "Ошибка настройки фильтров", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Все нормально
            return true;
        }

        /// <summary>
        /// Настройка доступности фильтров дат в зависимости от флажка "Фильтр по датам"
        /// </summary>
        private void chbDateFilter_CheckedChanged(object sender, EventArgs e)
        {
            var checkBox = sender as CheckBox;
            dtpDateTo.Enabled = dtpDateFrom.Enabled = checkBox.Checked;
        }

        #endregion
    }
}
