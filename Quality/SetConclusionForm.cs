using System;
using System.Data;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для ввода заключения ГЛС
    /// </summary>
    public partial class SetConclusionForm : Form
    {
        #region СВОЙСТВА

        /// <summary>
        /// Тип, который нужно передать в процедуру, чтобы получить типы заключений ГЛС
        /// </summary>
        private const string C_TYPE = "C";

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Номер заключения
        /// </summary>
        public string Number
        {
            get { return tbxNumber.Text; }
            set { tbxNumber.Text = value; }
        }

        /// <summary>
        /// Дата заключения ГЛС
        /// </summary>
        public DateTime SelectedDate
        {
            get { return dtpDate.Value; }
            set { dtpDate.Value = value; }
        }

        /// <summary>
        /// Результат заключения ГЛС
        /// </summary>
        public Data.Quality.QK_Get_Conclusion_TypesRow ConclusionType
        {
            get
            {
                return (cmbResult.SelectedItem as DataRowView).Row as
                    Data.Quality.QK_Get_Conclusion_TypesRow;
            }
        }

        /// <summary>
        /// Получение/задание доступности выбора итога заключения ГЛС
        /// </summary>
        public bool ConclTypeEnable
        {
            get { return cmbResult.Enabled; }
            set { cmbResult.Enabled = value; }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SetConclusionForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка доступных результатов ГЛС
        /// </summary>
        private void SetConclusionForm_Load(object sender, EventArgs e)
        {
            try
            {
                taQkGetConclusionTypes.Fill(quality.QK_Get_Conclusion_Types, sessionID, C_TYPE);
                if (quality.QK_Get_Conclusion_Types.Count == 0)
                    throw new ApplicationException("Процедура получения доступных заключений не вернула данные!");
                cmbResult.SelectedIndex = 0;
                tbxNumber.Focus();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время загрузки доступных результатов заключения произошла ошибка: ", exc);
                Close();
            }
        }

        /// <summary>
        /// Закрываем окно с положительным результатом
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
