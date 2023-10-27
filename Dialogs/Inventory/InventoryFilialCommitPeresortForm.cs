using System;
using System.Text;
using System.Timers;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для подтверждения пересортов и перемещений
    /// </summary>
    public partial class InventoryFilialCommitPeresortForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// Тип: CI - для пересортов, MI - для перемещений
        /// </summary>
        private string type;

        /// <summary>
        /// Инвентаризация, для которой проводится подтверждение пересортов и перемещений
        /// </summary>
        private Data.Inventory.FI_Get_Inventory_ListsRow currentInventory;

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialCommitPeresortForm(long pSessionID, Data.Inventory.FI_Get_Inventory_ListsRow pInventory, string pType)
        {
            InitializeComponent();
            sessionID = pSessionID;
            filterTimer.Elapsed += filterTimer_Elapsed;
            currentInventory = pInventory;
            type = pType;
            Text = type == "CI" ? "Подтверждение пересортов" : "Подтверждение перемещений недостач";
            btnCommit.Text = type == "CI" ? "Подтвердить пересорты" : "Подтвердить перемещения";
            if (type == "CI")
                checkedFlag.ReadOnly = true;    // Запрещаем право выбора при посерийном/попартийном пересорте

            btnChangePlace.Visible = type == "CM" && pInventory.FI_Type_ID == "PI"; // смена полки только для частичной инвентаризации (кроме пересортов)
        }

        /// <summary>
        /// Загрузка допустимых пересортов или перемещений при загрузке окна
        /// </summary>
        private void InventoryFilialCommitPeresortForm_Load(object sender, EventArgs e)
        {
            this.LoadCorrections();
        }

        private void LoadCorrections()
        {
            try
            {
                taFIGetCorrections.Fill(inventory.FI_Get_Corrections, sessionID, currentInventory.Inventory_number, type);
            }
            catch (Exception exc)
            {
                string s = type == "CI" ? "пересортов" : "перемещений недостач";
                Logger.ShowErrorMessageBox(String.Format("Не удалось загрузить список допустимых {0}: ", s), exc);
            }
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ПО МЕСТУ, КОДУ И НАЗВАНИЮ ТОВАРА

        /// <summary>
        /// Строка фильтра(эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string filter;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);

        /// <summary>
        /// Начало фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filterTimer.Stop();
                RefreshFilters();
            }
        }

        /// <summary>
        /// Обновление таблицы в соответствии с фильтрами
        /// </summary>
        private void RefreshFilters()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsFIGetCorrections.Filter = String.Empty;
                else
                {
                    int itemNumber;
                    string itemIdPart = Int32.TryParse(filter, out itemNumber) ?
                        String.Format(" OR [Item_ID] = {0}", filter) : String.Empty;
                    bsFIGetCorrections.Filter =
                        String.Format("[Item_Name] LIKE '%{0}%' OR [Location] LIKE '%{0}%'{1}", filter, itemIdPart);
                }
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvPeresorts.Invoke(new Method(RefreshFilters));
        }

        /// <summary>
        /// При изменении фильтра запускаем таймер ожидания, чтобы по прошествию некоторого времени обновить фильтры
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            filter = tbxFilter.Text;
            filterTimer.Stop();
            filterTimer.Start();
        }

        /// <summary>
        /// Переход на фильтр с помощью сочетания клавиш
        /// </summary>
        private void InventoryFilialEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                tbxFilter.Focus();
        }

        #endregion

        #region СИНХРОНИЗАЦИЯ ОТМЕЧАНИЯ F и T

        /// <summary>
        /// Сохранение во внешней переменной отмеченности проверки
        /// </summary>
        private void dgvPeresorts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPeresorts.Columns["CheckedFlag"] != dgvPeresorts.Columns[e.ColumnIndex])
                return;

            dgvPeresorts.CommitEdit(DataGridViewDataErrorContexts.Commit);
            var val = Convert.ToBoolean(dgvPeresorts.Rows[e.RowIndex].Cells[e.ColumnIndex].FormattedValue);
            var lineID = Convert.ToInt32(dgvPeresorts.Rows[e.RowIndex].Cells["lineID"].Value);
            var trNumber = Convert.ToDouble(dgvPeresorts.Rows[e.RowIndex].Cells["transactionNumber"].Value);
            foreach (Data.Inventory.FI_Get_CorrectionsRow row in inventory.FI_Get_Corrections)
                if (row.TransactionNumber == trNumber && row.Line_ID != lineID)
                {
                    row.CheckedFlag = val;
                    return;
                }
        }

        #endregion

        #region ПОДТВЕРЖДЕНИЕ ПЕРЕСОРТОВ И ПЕРЕМЕЩЕНИЙ

        /// <summary>
        /// DelinetedList с отмеченными пересортами/перемещениями
        /// </summary>
        private string CommitedCorrections
        {
            get
            {
                var dList = new StringBuilder();
                foreach (Data.Inventory.FI_Get_CorrectionsRow row in inventory.FI_Get_Corrections)
                    if (row.CheckedFlag && row.FT.ToUpper() == "F")
                        dList.AppendFormat("{0}{1}", row.TransactionNumber, dList.Length > 0 ? "," : String.Empty);
                return dList.ToString();
            }
        }

        /// <summary>
        /// Подтверждение пересортов или перемещений
        /// </summary>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            string message = type == "CI" ? "Выполнить отмеченные пересорты?" : "Выполнить отмеченные перемещения?";
            if (MessageBox.Show(message, "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Commit();
            message = type == "CI" ? "пересорты" : "перемещения недостач";
            MessageBox.Show(String.Format("Отмеченные {0} запущены!", message), "Подтверждение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Подтверждение пересортов или перемещений
        /// </summary>
        private void Commit()
        {
            try
            {
                dgvPeresorts.CommitEdit(DataGridViewDataErrorContexts.Commit);
                taFIGetCorrections.EditCorrectionList(sessionID, currentInventory.Inventory_number, CommitedCorrections, type);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время подтверждения: ", exc);
            }
        }

        #endregion

        private void btnChangePlace_Click(object sender, EventArgs e)
        {
            try
            {
                var correctionID = inventory.FI_Get_Corrections[0].Correction_ID;
                var correctionType = type;

                Data.Inventory.FI_PlacesDataTable fi_places = null;
                using (var adapter = new Data.InventoryTableAdapters.FI_PlacesTableAdapter())
                    fi_places = adapter.GetData(sessionID, currentInventory.Inventory_number, correctionID);

                if (fi_places != null && fi_places.Rows.Count > 0)
                {
                    var dlgChangePlace = new WMSOffice.Dialogs.RichListForm();
                    dlgChangePlace.Text = "Выберите место НА";

                    dlgChangePlace.AddColumn("NamePlace", "NamePlace", "Склад - место");
                    dlgChangePlace.ColumnForFilters.Add("NamePlace");
                    dlgChangePlace.FilterChangeLevel = 0;
                    dlgChangePlace.DataSource = fi_places;

                    if (dlgChangePlace.ShowDialog() == DialogResult.OK)
                    {
                        var fi_place = dlgChangePlace.SelectedRow as Data.Inventory.FI_PlacesRow;

                        using (var adapter = new Data.InventoryTableAdapters.FI_PlacesTableAdapter())
                            adapter.EditDiffPlaceForShortage(sessionID, currentInventory.Inventory_number, correctionID, correctionType, fi_place.warehouse_id, fi_place.place_code);

                        tbxFilter.Clear();
                        this.LoadCorrections();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
