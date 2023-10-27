using System;
using System.Windows.Forms;

using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно настройки поиска анкет входного контроля поставки
    /// </summary>
    public partial class InputControlDeliveryWorksheetSearchForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// True если нужно искать только активные анкеты, False если все анкеты
        /// </summary>
        public bool FilterOnlyActive { get { return chbOnlyActual.Checked; } }

        /// <summary>
        /// Номер поставки, по которой нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterDeliveryNumber
        {
            get
            {
                if (chbDeliveryNumber.Checked)
                    return Convert.ToInt64(tbxDeliveryNumber.Text);
                else
                    return null;
            }
        }

        /// <summary>
        /// Номер заказа на закупку, по которому нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterOrderNumber
        {
            get
            {
                if (chbOrderNumber.Checked)
                    return Convert.ToInt64(tbxOrderNumber.Text);
                else
                    return null;
            }
        }

        /// <summary>
        /// Код поставщика, по которому нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterVendorID
        {
            get
            {
                if (chbVendor.Checked)
                    return Convert.ToInt64(stbVendor.Value);
                else
                    return null;
            }
        }

        /// <summary>
        /// Название поставщика, выбранного в фильтре по поставщику или пустая строка, если фильтр по поставщику не задан
        /// </summary>
        public string VendorName { get { return chbVendor.Checked ? lblVendorName.Text : String.Empty; } }


        /// <summary>
        /// "ДАТА С" анкеты, если выбран фильтр по дате анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterDateFrom
        {
            get
            {
                if (chbWorksheetDate.Checked)
                    return dtpDateFrom.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// "ДАТА ПО" анкеты, если выбран фильтр по дате анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterDateTo
        {
            get
            {
                if (chbWorksheetDate.Checked)
                    return dtpDateTo.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// Код провизора, по которому нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterProvisorID
        {
            get
            {
                if (chbProvisor.Checked)
                    return Convert.ToInt64(cmbProvisors.SelectedValue);
                else
                    return null;
            }
        }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Новая", False если не нужно
        /// </summary>
        public bool FilterIncludeNew { get { return chbIncludeNew.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "В работе", False если не нужно
        /// </summary>
        public bool FilterIncludeInWork { get { return chbIncludeInWork.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Пройдена успешно", False если не нужно
        /// </summary>
        public bool FilterIncludeAccepted { get { return chbIncludeAccepted.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Сомнительного качества", False если не нужно
        /// </summary>
        public bool FilterIncludeWithSuspectedQuality { get { return chbIncludeWithSuspectedQuality.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Не пройдена", False если не нужно
        /// </summary>
        public bool FilterIncludeNotAccepted { get { return chbIncludeNotAccepted.Checked; } }

        /// <summary>
        /// True если нужно включать только подтвержденные анкеты , False если не нужно
        /// </summary>
        public bool FilterIncludeOnlyApproved { get { return chbIncludeOnlyApproved.Checked; } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public InputControlDeliveryWorksheetSearchForm(InputControlDeliverySheetsSearchParameters pParams)
        {
            InitializeComponent();
            sessionID = pParams.SessionID;
            lblVendorName.Text = String.Empty;
            SetInitValues(pParams);
        }

        /// <summary>
        /// Инициализация фильтров заранее заданными значениями
        /// </summary>
        /// <param name="pParams">Значения фильтров, которые были выбраны при предыдущем запуске окна поиска</param>
        private void SetInitValues(InputControlDeliverySheetsSearchParameters pParams)
        {
            chbOnlyActual.Checked = pParams.OnlyActual;
            if (pParams.DeliveryNumber.HasValue)
            {
                chbDeliveryNumber.Checked = true;
                tbxDeliveryNumber.Text = pParams.DeliveryNumber.Value.ToString();
            }

            if (pParams.OrderNumber.HasValue)
            {
                chbOrderNumber.Checked = true;
                tbxOrderNumber.Text = pParams.OrderNumber.Value.ToString();
            }

            if (pParams.VendorID.HasValue)
            {
                chbVendor.Checked = true;
                stbVendor.Value = pParams.VendorID.Value.ToString();
                lblVendorName.Text = pParams.VendorName;
            }

            if (pParams.DateFrom.HasValue)
            {
                chbWorksheetDate.Checked = true;
                dtpDateFrom.Value = pParams.DateFrom.Value;
                dtpDateTo.Value = pParams.DateTo.Value;
            }

            if (pParams.ProvisorID.HasValue)
            {
                chbProvisor.Checked = true;
                cmbProvisors.SelectedValue = pParams.ProvisorID;
            }

            chbIncludeNew.Checked = pParams.IncludeNew;
            chbIncludeInWork.Checked = pParams.IncludeInWork;
            chbIncludeAccepted.Checked = pParams.IncludeAccepted;
            chbIncludeWithSuspectedQuality.Checked = pParams.IncludeWithSuspectedQuality;
            chbIncludeNotAccepted.Checked = pParams.IncludeNotAccepted;
            chbIncludeOnlyApproved.Checked = pParams.IncludeOnlyApproved;
        }

        /// <summary>
        /// Получение данных для списка провизоров при загрузке окна
        /// </summary>
        private void InputControlDeliveryWorksheetSearchForm_Load(object sender, EventArgs e)
        {
            LoadProvisors();
            InitSearchTextBox();
            CustomFilterEnability();
            chbOnlyActual.Focus();
        }

        /// <summary>
        /// Получение данных для списка провизоров
        /// </summary>
        private void LoadProvisors()
        {
            try
            {
                taApGetProvisors.Fill(quality.AP_Get_Provisors, sessionID, false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время загрузки списка доступных провизоров произошла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Настройка доступности фильтров при отмечании/снятии флажков
        /// </summary>
        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            CustomFilterEnability();
        }

        /// <summary>
        /// Настройка доступности фильтров в зависимости от отмеченных флажков
        /// </summary>
        private void CustomFilterEnability()
        {
            tbxDeliveryNumber.Enabled = chbDeliveryNumber.Checked;
            tbxOrderNumber.Enabled = chbOrderNumber.Checked;
            stbVendor.Enabled = lblVendorName.Enabled = chbVendor.Checked;
            dtpDateFrom.Enabled = lblDateFrom.Enabled = dtpDateTo.Enabled = lblDateTo.Enabled = chbWorksheetDate.Checked;
            cmbProvisors.Enabled = chbProvisor.Checked;
        }

        #endregion

        #region ПОИСК ПОСТАВЩИКОВ

        /// <summary>
        /// Инициализация выпадающего справочника поставщиков
        /// </summary>
        private void InitSearchTextBox()
        {
            stbVendor.ValueReferenceQuery = "[dbo].[pr_AP_STB_Get_Vendors]";
            stbVendor.UserID = sessionID;
            stbVendor.OnVerifyValue += stbVendor_OnVerifyValue;
        }

        /// <summary>
        /// Проверка введенного значения в фильтр поставщиков
        /// </summary>
        private void stbVendor_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var stb = sender as SearchTextBox;
            stb.Value = e.Success ? e.Value : null;
            lblVendorName.Text = e.Success ? e.Description : String.Empty;
            if (e.Success)
                chbWorksheetDate.Focus();
        }

        #endregion

        #region ПРОВЕРКА ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Проверка данных и закрытие окна с дальнейшей целью произвести поиск анкет
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
        /// <returns>True если данные верны, False если есть ошибки</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            long d;
            if (chbDeliveryNumber.Checked && (!Int64.TryParse(tbxDeliveryNumber.Text, out d) || d <= 0))
                msg = "Если фильтр по поставщику отмечен флажком, то в текстовом поле нужно ввести целый неотрицательный номер поставки!";
            else if (chbOrderNumber.Checked && (!Int64.TryParse(tbxOrderNumber.Text, out d) || d <= 0))
                msg = "Если фильтр по номеру заказа отмечен флажком, то в текстовом поле нужно ввести целый неотрицательный номер заказа!";
            else if (chbVendor.Checked && (!Int64.TryParse(stbVendor.Value, out d) || d <= 0))
                msg = "Если фильтр по поставщику отмечен флажком, то в нужно выбрать поставщика!";
            else if (chbWorksheetDate.Checked && dtpDateFrom.Value > dtpDateTo.Value)
                msg = "ДАТА ПО не может быть больше ДАТЫ С!";
            else if (chbProvisor.Checked && cmbProvisors.SelectedItem == null)
                msg = "Если выбран фильтр по ФИО Фармацевта, нужно выбрать фармацевта в выпадающем списке!";

            if (!String.IsNullOrEmpty(msg))
            {
                Logger.ShowErrorMessageBox(msg);
                return false;
            }
            else
                return true;
        }

        #endregion
    }
}
