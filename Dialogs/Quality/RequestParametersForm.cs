using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для редактирования параметров заявки
    /// </summary>
    public partial class RequestParametersForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор инспекции при открытии окна
        /// </summary>
        private readonly int initialInspectionID;

        /// <summary>
        /// Идентификатор выбранной инспекции
        /// </summary>
        public int InspectionID { get { return Convert.ToInt32(cmbInspection.SelectedValue); } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public RequestParametersForm(long pSessionID, int pInspectionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            initialInspectionID = pInspectionID;
            cmbInspection.Focus();
        }

        /// <summary>
        /// Загрузка списка возможных инспекций при загрузке окна
        /// </summary>
        private void RequestParametersForm_Load(object sender, EventArgs e)
        {
            string msg = String.Empty;
            try
            {
                taQkLocations.Fill(quality.QK_Locations, sessionID);
                if (quality.QK_Locations.Count == 0)
                    msg = "Нет ни одной инспекции для выбора. Дальнейшая работа с окном невозможна!";
                else
                    cmbInspection.SelectedValue = initialInspectionID;
            }
            catch (Exception exc)
            {
                msg = "Возникла ошибка во время загрузки списка возможных инспекций. Дальнейшая работа с окном невозможна!" + 
                    Environment.NewLine + exc.Message;
            }
            
            if (!String.IsNullOrEmpty(msg))
            {
                Logger.ShowErrorMessageBox(msg);
                Close();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ

        /// <summary>
        /// Проверка введенных результатов и закрытие окна с положительным результатом
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
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если все данные введены правильно, False в противном случае</returns>
        private bool ValidateData()
        {
            string errMsg = String.Empty;
            if (cmbInspection.SelectedItem == null)
                errMsg = "Не выбрана инспекция в выпадающем списке. Выберите инспекцию";

            if (String.IsNullOrEmpty(errMsg))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(errMsg);
                return false;
            }
        }

        #endregion
    }
}
