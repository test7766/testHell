using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно редактирования провизоров
    /// </summary>
    public partial class ProvisorsEditForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public ProvisorsEditForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка провизоров при загрузке окна
        /// </summary>
        private void ProvisorsEditForm_Load(object sender, EventArgs e)
        {
            LoadProvisors();
        }

        /// <summary>
        /// Загрузка данных в таблицу провизоров
        /// </summary>
        private void LoadProvisors()
        {
            try
            {
                taGetProvisors.Fill(quality.QK_Get_Provisors, sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время наполнения таблицы провизоров: ", exc);
            }
        }

        #endregion
    }
}
