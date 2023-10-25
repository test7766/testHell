using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class CloseGlsRequestForReasonForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Тип, который надо передать в процедуру, чтобы получить причины закрытия заявки
        /// </summary>
        private const string F_TYPE = "F";

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public CloseGlsRequestForReasonForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка причин закрытия при загрузке окна
        /// </summary>
        private void CloseGlsRequestForReasonForm_Load(object sender, EventArgs e)
        {
            LoadReasons();
        }

        /// <summary>
        /// Загрузка причин закрытия строк
        /// </summary>
        private void LoadReasons()
        {
            try
            {
                taQkGetConclusionTypes.Fill(quality.QK_Get_Conclusion_Types, sessionID, F_TYPE);
                cmbReason.Focus();
                cmbReason.Select();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки возможных причин закрытия строки заявки: ", exc);
            }
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Идентификатор причины закрытия строки заявки
        /// </summary>
        public int ReasonID { get { return Convert.ToInt32(cmbReason.SelectedValue); } }

        /// <summary>
        /// Номер документа, связанного с закрытием
        /// </summary>
        public string DocNumber { get { return tbxDocNumber.Text; } }

        /// <summary>
        /// Дата документа, связанного с закрытием
        /// </summary>
        public DateTime DocDate { get { return dtpDocDate.Value; } }

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
        /// <returns>True если данные введены корректно, False в противном случае</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;

            if (cmbReason.SelectedItem == null)
                msg = "Нужно обязательно выбрать причину закрытия строки заявки из выпадающего списка!";

            if (String.IsNullOrEmpty(msg))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(msg);
                return false;
            }
        }

        #endregion
    }
}
