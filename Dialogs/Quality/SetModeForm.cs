using System;
using System.Drawing;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно установки режима для строки заявки
    /// </summary>
    public partial class SetModeForm : Form
    {
        #region СВОЙСТВА

        /// <summary>
        /// Название текущего режима
        /// </summary>
        private string currentModeName;

        /// <summary>
        /// Дата заявки
        /// </summary>
        private readonly DateTime requestDate;

        /// <summary>
        /// Выбранный режим
        /// </summary>
        public string SelectedMode { get { return (string)cmbModes.SelectedValue; } }

        /// <summary>
        /// Возможность редактировать другую информацию (дату производства и данные об участке и GMP)
        /// </summary>
        public bool CanEditOtherProperties { get { return cbEnableOtherEditors.Checked; } }


        /// <summary>
        /// Введенный размер серии либо null, если размер серии не задан
        /// </summary>
        public int? SelectedLotVolume 
        {
            get
            {
                if (String.IsNullOrEmpty(tbxLotVolume.Text))
                    return null;
                else
                    return Convert.ToInt32(tbxLotVolume.Text);
            }
        }

        /// <summary>
        /// Выбранная дата производства
        /// </summary>
        public DateTime ManufItemDate { get { return dtpManufItemDate.Value; } }

        /// <summary>
        /// Выбранная дата выпуска серии
        /// </summary>
        public DateTime ManufDate { get { return dtpManufDate.Value; } }

        /// <summary>
        /// Информация о производственном участке
        /// </summary>
        public string LicenseRequisites { get { return tbxLicenseRequisites.Text; } }

        /// <summary>
        /// Информация о GMP-сертификате производственного участка
        /// </summary>
        public string GMPSert { get { return tbxGMP_Sert.Text; } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public SetModeForm(string pCurrentMode, int? pCurrentLotVolume, DateTime? pCurrentManufDate,
            string pCurrentManufSectorDsc, string pCurrentGmpSert, DateTime pDocDate, bool pLockLotVolume, DateTime? pCurrentManufItemDate)
        {
            InitializeComponent();
            tbxLotVolume.Enabled = !pLockLotVolume;
            if (pCurrentLotVolume.HasValue)
                tbxLotVolume.Text = pCurrentLotVolume.Value.ToString();
            if (pCurrentManufItemDate.HasValue)
                dtpManufItemDate.Value = pCurrentManufItemDate.Value;
            if (pCurrentManufDate.HasValue)
                dtpManufDate.Value = pCurrentManufDate.Value;
            tbxLicenseRequisites.Text = pCurrentManufSectorDsc;
            tbxGMP_Sert.Text = pCurrentGmpSert;
            currentModeName = pCurrentMode;
            requestDate = pDocDate;
        } 
        
        /// <summary>
        /// Загрузка режимов при загрузке окна
        /// </summary>
        private void SetModeForm_Load(object sender, EventArgs e)
        {
            try
            {
                taModes.Fill(quality.Modes);
                if (quality.Modes.Count == 0)
                    throw new ApplicationException("Процедура получения списка режимов не вернула данные!");
                NavigateToCurrentMode();
                if (tbxLotVolume.Enabled)
                    tbxLotVolume.Focus();
                else
                    cmbModes.Focus();


                ChangeAccessForOtherEditors(cbEnableOtherEditors.Checked);

            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка режимов: ", exc);
                Close();
            }
        }

        /// <summary>
        /// Выбор текущего установленного режима
        /// </summary>
        private void NavigateToCurrentMode()
        {
            cmbModes.SelectedIndex = 0;
            foreach (Data.Quality.ModesRow item in quality.Modes)
                if (item.Mode_Name.Trim() == currentModeName.Trim())
                    cmbModes.SelectedValue = item.Mode_ID;
        }

        /// <summary>
        /// Разрешаем вводить только числа в поле "Размер серии"
        /// </summary>
        private void tbxLotVolume_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТА

        /// <summary>
        /// Сохранение данных, введенных в окне
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка данных на корректность
        /// </summary>
        /// <returns>True если данные введены правильно, False если неправильно</returns>
        private bool ValidateData()
        {
            int lotVolume;
            string msg = String.Empty;

            if (!String.IsNullOrEmpty(tbxLotVolume.Text) && !Int32.TryParse(tbxLotVolume.Text, out lotVolume))
                msg = "Введено некорректное значение в поле РАЗМЕР СЕРИИ!";

            else if (CanEditOtherProperties && String.IsNullOrEmpty(tbxLicenseRequisites.Text) && requestDate > Convert.ToDateTime("01.12.2013"))
                msg = "Нужно обязательно ввести наименование, местоположение и номер лицензии производственного участка!";

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;

        }

        #endregion

        private void cbEnableOtherEditors_CheckedChanged(object sender, EventArgs e)
        {
            ChangeAccessForOtherEditors(cbEnableOtherEditors.Checked);
        }

        private void ChangeAccessForOtherEditors(bool allowAccess)
        {
            gbOtherEditors.Enabled = allowAccess;
        }
    }
}
