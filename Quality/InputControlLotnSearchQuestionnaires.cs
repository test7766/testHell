using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Quality
{
    public partial class InputControlLotnSearchQuestionnaires : DialogForm
    {

        public static InputControlLotnOrdersSearchParamters SearchParameter { get; private set; }

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
        /// Код товара, по которому нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterItemID
        {
            get
            {
                if (chbItem.Checked)
                    return Convert.ToInt64(stbItem.Value);
                else
                    return null;
            }
        }

        /// <summary>
        /// Название товара, выбранного в фильтре по товару или пустая строка, если фильтр по товару не задан
        /// </summary>
        public string ItemName { get { return chbItem.Checked ? lblItemName.Text : String.Empty; } }

        /// <summary>
        /// Партия, по которой нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public string FilterLotNumber
        {
            get
            {
                if (chbLotNumber.Checked)
                    return tbxLotNumber.Text;
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
        /// Код производителя, по которому нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterManufacturerID
        {
            get
            {
                if (chbManufacturer.Checked)
                    return Convert.ToInt64(stbManufacturer.Value);
                else
                    return null;
            }
        }

        /// <summary>
        /// Название производителя, выбранного в фильтре или пустая строка, если фильтр по производителю не задан
        /// </summary>
        public string ManufacturerName { get { return chbManufacturer.Checked ? lblManufacturerName.Text : String.Empty; } }


        /// <summary>
        /// Партия, по которой нужно найти анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public long? FilterOrderID
        {
            get
            {
                if (chbOrderID.Checked)
                    return Convert.ToInt64(tbxOrderID.Text);
                else
                    return null;
            }
        }

        /// <summary>
        /// True если нужно искать в заказах на статусе "Новый", False если не нужно
        /// </summary>
        public bool FilterOrderIncludeNew { get { return true/*chbOrderIncludeNew.Checked*/; } }

        /// <summary>
        /// True если нужно искать в заказах на статусе "В работе", False если не нужно
        /// </summary>
        public bool FilterOrderIncludeInWork { get { return true /*chbOrderIncludeInWork.Checked*/; } }

        /// <summary>
        /// True если нужно искать в заказах на статусе "Обработан", False если не нужно
        /// </summary>
        public bool FilterOrderIncludeAccepted { get { return false/*chbOrderIncludeAccepted.Checked*/; } }

        /// <summary>
        /// True если нужно искать в заказах на статусе "Обработан с ошибкой", False если не нужно
        /// </summary>
        public bool FilterOrderIncludeNotAccepted { get { return false/*chbOrderIncludeNotAccepted.Checked*/; } }

        // <summary>
        /// True если нужно искать в заказах на статусе "Ввод данных сертификата", False если не нужно
        /// </summary>
        public bool FilterOrderIncludeCertDataInput { get { return false/*chbOrderIncludeCertDataInput.Checked*/; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Новая", False если не нужно
        /// </summary>
        public bool FilterIncludeNew { get { return chbWorksheetIncludeNew.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "В работе", False если не нужно
        /// </summary>
        public bool FilterIncludeInWork { get { return chbWorksheetIncludeInWork.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Пройдена успешно", False если не нужно
        /// </summary>
        public bool FilterIncludeAccepted { get { return chbWorksheetIncludeAccepted.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Не пройдена", False если не нужно
        /// </summary>
        public bool FilterIncludeNotAccepted { get { return chbWorksheetIncludeNotAccepted.Checked; } }

        /// <summary>
        /// True если нужно включать анкеты на статусе "Ввод данных сертификата", False если не нужно
        /// </summary>
        public bool FilterIncludeCertDataInput { get { return chbWorksheetIncludeCertDataInput.Checked; } }

        /// <summary>
        /// "ДАТА С" заказа, если выбран фильтр по дате заказа или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterOrderDateFrom
        {
            get
            {
                if (chbOrderDate.Checked)
                    return dtpOrderDateFrom.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// "ДАТА ПО" заказа, если выбран фильтр по дате заказа или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterOrderDateTo
        {
            get
            {
                if (chbOrderDate.Checked)
                    return dtpOrderDateTo.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// "ДАТА С" последнего редактирования анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterWorksheetDateFrom
        {
            get
            {
                if (chbWorksheetDate.Checked)
                    return dtpWorksheetDateFrom.Value;
                else
                    return null;
            }
        }

        /// <summary>
        /// "ДАТА ПО" последнего редактирования анкеты или null если фильтр не задан (не отмечен флажком)
        /// </summary>
        public DateTime? FilterWorksheetDateTo
        {
            get
            {
                if (chbWorksheetDate.Checked)
                    return dtpWorksheetDateTo.Value;
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

        #endregion


        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public InputControlLotnSearchQuestionnaires(InputControlLotnOrdersSearchParamters pParams)
        {
            InitializeComponent();
            sessionID = pParams.SessionID;
        //    lblItemName.Text = lblVendorName.Text = lblManufacturerName.Text = String.Empty;



            SetInitValues(pParams);
        }


        private void SetInitValues(InputControlLotnOrdersSearchParamters pParams)
        {
            chbOnlyActual.Checked = pParams.OnlyActual;

            if (pParams.ItemID.HasValue)
            {
                chbItem.Checked = true;
                stbItem.Value = pParams.ItemID.Value.ToString();
                lblItemName.Text = pParams.ItemName;
            }

            if (pParams.VendorID.HasValue)
            {
                chbVendor.Checked = true;
                stbVendor.Value = pParams.VendorID.Value.ToString();
                lblVendorName.Text = pParams.VendorName;
            }

            if (!String.IsNullOrEmpty(pParams.LotNumber))
            {
                chbLotNumber.Checked = true;
                tbxLotNumber.Text = pParams.LotNumber;
            }

            if (pParams.ManufacturerID.HasValue)
            {
                chbManufacturer.Checked = true;
                stbManufacturer.Value = pParams.ManufacturerID.Value.ToString();
                lblManufacturerName.Text = pParams.ManufacturerName;
            }

            if (pParams.OrderID.HasValue)
            {
                chbOrderID.Checked = true;
                tbxOrderID.Text = pParams.OrderID.Value.ToString();
            }

            chbWorksheetIncludeNew.Checked = pParams.IncludeNew;
            chbWorksheetIncludeInWork.Checked = pParams.IncludeInWork;
            chbWorksheetIncludeAccepted.Checked = pParams.IncludeAccepted;
            chbWorksheetIncludeNotAccepted.Checked = pParams.IncludeNotAccepted;
            chbWorksheetIncludeCertDataInput.Checked = pParams.IncludeCertDataInput;


            if (pParams.OrderDateFrom.HasValue)
            {
                chbOrderDate.Checked = true;
                dtpOrderDateFrom.Value = pParams.OrderDateFrom.Value;
                dtpOrderDateTo.Value = pParams.OrderDateTo.Value;
            }

            if (pParams.ProvisorID.HasValue)
            {
                chbProvisor.Checked = true;
                cmbProvisors.SelectedValue = pParams.ProvisorID;
            }

            if (pParams.DateFrom.HasValue)
            {
                chbWorksheetDate.Checked = true;
                dtpWorksheetDateFrom.Value = pParams.DateFrom.Value;
                dtpWorksheetDateTo.Value = pParams.DateTo.Value;
            }
        }





        private void InputControlLotnSearchQuestionnaires_Load(object sender, EventArgs e)
        {
            InitSearchTextBoxes();
            CustomFilterEnability();
            LoadProvisors();
        }



        /// <summary>
        /// Загрузка доступных для выбора провизоров ОК
        /// </summary>
        private void LoadProvisors()
        {
            try
            {
                taApGetProvisors.Fill(quality.AP_Get_Provisors, sessionID, true);
                if (quality.AP_Get_Provisors.Count == 0)
                    grbProvisor.Enabled = false;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки провизоров ОК: ", exc);
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
            stbItem.Enabled = lblItemName.Enabled = chbItem.Checked;
            tbxLotNumber.Enabled = chbLotNumber.Checked;
            stbVendor.Enabled = lblVendorName.Enabled = chbVendor.Checked;
            stbManufacturer.Enabled = lblManufacturerName.Enabled = chbManufacturer.Checked;
            dtpOrderDateFrom.Enabled = lblOrderDateFrom.Enabled = dtpOrderDateTo.Enabled = lblOrderDateTo.Enabled = chbOrderDate.Checked;
            cmbProvisors.Enabled = chbProvisor.Checked;
            dtpWorksheetDateFrom.Enabled = lblWorksheetDateFrom.Enabled =
                dtpWorksheetDateTo.Enabled = lblWorksheetDateTo.Enabled = chbWorksheetDate.Checked;
        }

        #endregion


        #region ПОИСК С ПОМОЩЬЮ SearchTextBox-ов

        /// <summary>
        /// Инициализация выпадающего справочника поставщиков
        /// </summary>
        private void InitSearchTextBoxes()
        {
            stbVendor.ValueReferenceQuery = "[dbo].[pr_AP_STB_Get_Vendors]";
            stbVendor.UserID = sessionID;
            stbVendor.OnVerifyValue += stb_OnVerifyValue;
            stbItem.ValueReferenceQuery = "[dbo].[pr_QK_STB_Get_Items]";
            stbItem.UserID = sessionID;
            stbItem.OnVerifyValue += stb_OnVerifyValue;
            stbManufacturer.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Manufacturers]";
            stbManufacturer.UserID = sessionID;
            stbManufacturer.OnVerifyValue += stb_OnVerifyValue;
        }

        /// <summary>
        /// Проверка введенного значения в выпадающие фильтры
        /// </summary>
        private void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var stb = sender as SearchTextBox;
            stb.Value = e.Success ? e.Value : null;
            Control nextCtrl;
            Label lbl;
            if (sender == stbItem)
            {
                nextCtrl = chbLotNumber;
                lbl = lblItemName;
            }
            else if (sender == stbVendor)
            {
                nextCtrl = chbManufacturer;
                lbl = lblVendorName;
            }
            else
            {
                nextCtrl = chbOrderDate/*chbOrderIncludeNew*/;
                lbl = lblManufacturerName;
            }

            lbl.Text = e.Success ? e.Description : String.Empty;
            if (e.Success)
                nextCtrl.Focus();
        }


        #endregion




        #region ПРОВЕРКА ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// Проверка данных и закрытие окна с дальнейшей целью произвести поиск анкет
        /// </summary>
        /// 

        private void InputControlLotnSearchQuestionnaires_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateData();
        }


        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если данные верны, False если есть ошибки</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            long d;
            if (chbItem.Checked && (!Int64.TryParse(stbItem.Value, out d) || d <= 0))
                msg = "Если фильтр по товару отмечен флажком, то в нужно выбрать товар!";
            else if (chbLotNumber.Checked && String.IsNullOrEmpty(tbxLotNumber.Text))
                msg = "Если выбран фильтр по партии, нужно ввести код партии!";
            else if (chbVendor.Checked && (!Int64.TryParse(stbVendor.Value, out d) || d <= 0))
                msg = "Если фильтр по поставщику отмечен флажком, то в нужно выбрать поставщика!";
            else if (chbManufacturer.Checked && (!Int64.TryParse(stbManufacturer.Value, out d) || d <= 0))
                msg = "Если фильтр по производителю отмечен флажком, то в нужно выбрать производителя!";
            else if (chbOrderDate.Checked && dtpOrderDateFrom.Value.Date > dtpOrderDateTo.Value.Date)
                msg = "ДАТА ПО заказа не может быть больше ДАТЫ С!";
            else if (chbProvisor.Checked && cmbProvisors.SelectedItem == null)
                msg = "Если выбран фильтр по ФИО провизора, нужно выбрать провизора в выпадающем списке!";
            else if (chbWorksheetDate.Checked && dtpWorksheetDateFrom.Value.Date > dtpWorksheetDateTo.Value.Date)
                msg = "ДАТА ПО анкеты не может быть больше ДАТЫ С!";

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
