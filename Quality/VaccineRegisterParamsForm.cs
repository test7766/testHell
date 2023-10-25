using System;
using System.Windows.Forms;

using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно настройки параметров для загрузки журнала вакцин
    /// </summary>
    public partial class VaccineRegisterParamsForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Дата начала периода или null, если загрузка вакцин не ограничивается периодом
        /// </summary>
        public DateTime? DateFrom
        {
            get { return chbDates.Checked ? (DateTime?)dtpDateFrom.Value : null; }
        }

        /// <summary>
        /// Дата конца периода или null, если загрузка вакцин не ограничивается периодом
        /// </summary>
        public DateTime? DateTo
        {
            get { return chbDates.Checked ? (DateTime?)dtpDateTo.Value : null; }
        }

        /// <summary>
        /// Код товара или null, если загрузка вакцин не ограничивается по товару
        /// </summary>
        public long? ItemID
        {
            get { return String.IsNullOrEmpty(stbItem.Value) ? null : (long?)Convert.ToInt64(stbItem.Value); }
        }

        /// <summary>
        /// Код производителя или null, если загрузка вакцин не ограничивается по производителю
        /// </summary>
        public long? ManufacturerID
        {
            get { return String.IsNullOrEmpty(stbManufacturer.Value) ? null : (long?)Convert.ToInt64(stbManufacturer.Value); }
        }

        /// <summary>
        /// Код поставщика или null, если загрузка вакцин не ограничивается по поставщику
        /// </summary>
        public long? VendorID
        {
            get { return String.IsNullOrEmpty(stbVendor.Value) ? null : (long?)Convert.ToInt64(stbVendor.Value); }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public VaccineRegisterParamsForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Инициализация окна
        /// </summary>
        private void VaccineRegisterParamsForm_Load(object sender, EventArgs e)
        {
            InitSearchTextBoxes();
            CustomDateFilterEnability();
        }

        /// <summary>
        /// Инициализация выпадающих справочников товаров, производителей и поставщиков
        /// </summary>
        private void InitSearchTextBoxes()
        {
            stbVendor.ValueReferenceQuery = "[dbo].[pr_AP_STB_Get_Vendors]";
            stbVendor.UserID = sessionID;
            stbVendor.OnVerifyValue += stb_OnVerifyValue;
            stbItem.ValueReferenceQuery = "[dbo].[pr_QK_STB_Get_Items]";
            stbItem.UserID = sessionID;
            stbItem.ApplyAdditionalParameter(true);
            stbItem.OnVerifyValue += stb_OnVerifyValue;
            stbManufacturer.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Manufacturers]";
            stbManufacturer.UserID = sessionID;
            stbManufacturer.ApplyAdditionalParameter(true);
            stbManufacturer.OnVerifyValue += stb_OnVerifyValue;
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ ПАРАМЕТРОВ

        /// <summary>
        /// Проверка введенного значения в выпадающие справочники
        /// </summary>
        private void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var stb = sender as SearchTextBox;
            stb.Value = e.Success ? e.Value : null;
            Control nextCtrl;
            Label lbl;
            string nullStr;
            if (sender == stbItem)
            {
                nextCtrl = stbManufacturer;
                lbl = lblItemName;
                nullStr = "Товар не выбран";
            }
            else if (sender == stbManufacturer)
            {
                nextCtrl = stbVendor;
                lbl = lblManufacturerName;
                nullStr = "Производитель не выбран";
            }
            else
            {
                nextCtrl = btnOk;
                lbl = lblVendorName;
                nullStr = "Поставщик не выбран";
            }

            lbl.Text = (e.Success && !String.IsNullOrEmpty(e.Description)) ? e.Description : nullStr;
            if (e.Success)
                nextCtrl.Focus();
        }

        /// <summary>
        /// Настройка доступности фильтров с датами в зависимости от флажка "По дате" каждый раз,
        /// когда переключается флажок
        /// </summary>
        private void chbDates_CheckedChanged(object sender, EventArgs e)
        {
            CustomDateFilterEnability();
        }

        /// <summary>
        /// Настройка доступности фильтров с датами в зависимости от флажка "По дате"
        /// </summary>
        private void CustomDateFilterEnability()
        {
            lblDateFrom.Enabled = lblDateTo.Enabled = dtpDateFrom.Enabled = dtpDateTo.Enabled = chbDates.Checked;
        }

        #endregion

        #region ПРОВЕРКА ВВЕДЕННЫХ ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Проверка данных и закрытие окна
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если введены корректные данные, False если есть ошибки и нужно подкорректировать данные</returns>
        private bool ValidateData()
        {
            string message = String.Empty;

            if (chbDates.Checked && dtpDateTo.Value.Date < dtpDateFrom.Value.Date)
                message = "Дата конца периода не может быть меньше за дату начала периода!";

            if (!String.IsNullOrEmpty(message))
            {
                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        #endregion
    }
}
