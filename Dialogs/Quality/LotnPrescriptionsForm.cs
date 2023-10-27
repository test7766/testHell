using System;
using System.Data;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для просмотра предписаний по партии товара
    /// </summary>
    public partial class LotnPrescriptionsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Код товара
        /// </summary>
        private readonly int itemID;

        /// <summary>
        /// Партия
        /// </summary>
        private readonly string lotNumber;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public LotnPrescriptionsForm(long pSessionID, int pItemID, string pLotNumber)
        {
            InitializeComponent();
            sessionID = pSessionID;
            itemID = pItemID;
            lotNumber = pLotNumber;
        }

        /// <summary>
        /// Загрузка предписаний по партии товара при загрузке окна
        /// </summary>
        private void LotnPrescriptionsForm_Load(object sender, EventArgs e)
        {
            LoadPrescriptions();
            tbxDescription.Focus();
        }

        /// <summary>
        /// Загрузка предписаний
        /// </summary>
        private void LoadPrescriptions()
        {
            try
            {
                taAtGetPrescriptionsForLotn.Fill(quality.AT_Get_Prescriptions_For_Lotn, sessionID, itemID, lotNumber);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки предписаний: ", exc);
            }
        }

        /// <summary>
        /// Отображение описания выбранного предписания в текстовом поле (в таблице его не удобно читать и копировать)
        /// </summary>
        private void dgvPrescriptions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPrescriptions.SelectedRows.Count == 0)
                tbxDescription.Text = String.Empty;
            else
            {
                var dbRow = (dgvPrescriptions.SelectedRows[0].DataBoundItem as DataRowView).Row
                    as Data.Quality.AT_Get_Prescriptions_For_LotnRow;
                tbxDescription.Text = dbRow.IscommentNull() ? String.Empty : dbRow.comment;
            }
        }

        #endregion
    }
}
