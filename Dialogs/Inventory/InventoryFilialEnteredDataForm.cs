using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно просмотра введенных данных по счетному листу
    /// </summary>
    public partial class InventoryFilialEnteredDataForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Режим архива
        /// </summary>
        public bool IsArchiveMode { get; set; }

        /// <summary>
        /// Счетный лист, по которому просматривается информация
        /// </summary>
        private Data.Inventory.FI_Counting_SheetsRow countingSheet;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialEnteredDataForm(Data.Inventory.FI_Counting_SheetsRow pCountingSheet, long pSessionID)
        {
            InitializeComponent();
            countingSheet = pCountingSheet;
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка данных в таблицу просмотра введенных данных по счетному листу
        /// </summary>
        private void InventoryFilialEnteredDataForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.IsArchiveMode)
                    taFiCSTypedData.FillArchive(inventory.FI_CS_Typed_Data, sessionID, countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
                else
                    taFiCSTypedData.Fill(inventory.FI_CS_Typed_Data, sessionID, countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке введенных данных по счетному листу: ", exc);
            }
        }

        #endregion
    }
}
