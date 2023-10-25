using System;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Data.QualityTableAdapters;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Форма для связывания товаров
    /// </summary>
    public partial class ItemOffersForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор блокировки, по которой нужно связать товары
        /// </summary>
        private readonly long? blockID;

        /// <summary>
        /// Количество предоложений связки
        /// </summary>
        public int RowCount { get { return quality.BL_Get_BindingOffers.Count; } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public ItemOffersForm(long pSessionID, long? pBlockID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            blockID = pBlockID;
            LoadOffers();
        }

        /// <summary>
        /// Загрузка предложений по связыванию товаров
        /// </summary>
        private void LoadOffers()
        {
            try
            {
                taBlGetBindingOffers.Fill(quality.BL_Get_BindingOffers, blockID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время обновления предложений по связыванию товаров: ", exc);
            }
        }

        /// <summary>
        /// Задание текста на кнопку "Подтвердить"
        /// </summary>
        private void dgvOffers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvOffers.Rows)
                dgvRow.Cells["clApprove"].Value = "Подтвердить";
        }

        #endregion

        #region ПРИНЯТИЕ ЛИБО ОТКЛОНЕНИЕ ПРЕДЛОЖЕНИЙ

        /// <summary>
        /// Принятие либо отклонение предложения
        /// </summary>
        private void dgvOffers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvOffers.Columns[e.ColumnIndex] == clApprove)
                {
                    var row = (dgvOffers.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.BL_Get_BindingOffersRow;
                    using (var adapter = new BL_Get_BindingOffersTableAdapter())
                        adapter.SetBindingOffers(row.Offer_ID);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время связывания предложения с реальным товаром:", exc);
            }
            finally
            {
                LoadOffers();
            }
        }

        #endregion
    }
}
