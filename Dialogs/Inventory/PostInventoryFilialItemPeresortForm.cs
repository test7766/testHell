using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для проведения потоварного пересорта
    /// </summary>
    public partial class PostInventoryFilialItemPeresortForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Инвентаризация, для которой проводится потоварный пересорт
        /// </summary>
        private readonly Data.Inventory.FP_Get_InventoriesRow invRow;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly int sessionID;

        /// <summary>
        /// Название для левой таблицы в конфиг-файле
        /// </summary>
        private string LeftTableConfigName { get { return String.Format("{0}_LeftTable", Name); } }

        /// <summary>
        /// Название для правой таблицы в конфиг-файле
        /// </summary>
        private string RightTableConfigName { get { return String.Format("{0}_RightTable", Name); } }

        /// <summary>
        /// Идентификатор созданного пересорта
        /// </summary>
        private long peresortID;

        /// <summary>
        /// True, если редактируется уже существующий документ, False если создается новый документ
        /// </summary>
        private bool isEditMode;

        /// <summary>
        /// Выбранные строки в таблице товаров, доступных для потоварного пересорта
        /// </summary>
        private List<Data.Inventory.FP_Get_Items_For_ReparationRow> SelectedItemsForReparation
        {
            get
            {
                var list = new List<Data.Inventory.FP_Get_Items_For_ReparationRow>();
                foreach (DataGridViewRow row in dgvItems.SelectedRows)
                    list.Add((row.DataBoundItem as DataRowView).Row as Data.Inventory.FP_Get_Items_For_ReparationRow);
                return list;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public PostInventoryFilialItemPeresortForm(int pSessionID, Data.Inventory.FP_Get_InventoriesRow pInv)
        {
            InitializeComponent();
            sessionID = pSessionID;
            invRow = pInv;
        }

        public PostInventoryFilialItemPeresortForm(int pSessionID, Data.Inventory.FP_Get_InventoriesRow pInv, long pPeresortID)
            : this(pSessionID, pInv)
        {
            peresortID = pPeresortID;
            isEditMode = true;
        }

        /// <summary>
        /// Загрузка данных при загрузке окна
        /// </summary>
        private void PostInventoryFilialItemPeresortForm_Load(object sender, EventArgs e)
        {
            LoadAvailableItems();
            LoadDetails();
            if (!isEditMode)
                if (!CreateNewPeresort())
                {
                    Close();
                    return;
                }
            Config.LoadDataGridViewSettings(LeftTableConfigName, dgvItems);
            Config.LoadDataGridViewSettings(RightTableConfigName, dgvDocItems);
            tbxFilter.Focus();
        }

        /// <summary>
        /// Загрузка товаров, доступных для потоварного пересорта
        /// </summary>
        private void LoadAvailableItems()
        {
            try
            {
                Config.SaveDataGridViewSettings(LeftTableConfigName, dgvItems);
                int index = dgvItems.FirstDisplayedScrollingRowIndex;


                taFpGetItemsForReparation.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                taFpGetItemsForReparation.Fill(inventory.FP_Get_Items_For_Reparation, peresortID); //invRow.Inventory_number);
                
                Config.LoadDataGridViewSettings(RightTableConfigName, dgvItems);
                if (dgvItems.Rows.Count <= index)
                    index = dgvItems.Rows.Count - 1;
                if (index >= 0)
                    dgvItems.FirstDisplayedScrollingRowIndex = index;

                SetRowColorItems();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить товары, доступные для потоварного пересорта!", exc);
                inventory.FP_Get_Items_For_Reparation.Clear();
            }
        }

        /// <summary>
        /// Загрузка взаимозачетов в данном документе
        /// </summary>
        private void LoadDetails()
        {
            try
            {
                taFpGetCorrectionDetails.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                taFpGetCorrectionDetails.Fill(inventory.FP_Get_Correction_Details, sessionID, peresortID);
                SetRowColorDocItems();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при обновлении созданных взаимозачетов!", exc);
            }
        }

        /// <summary>
        /// Создание идентификатора для потоварного пересорта
        /// </summary>
        /// <returns>True, если создан идентификатор потоварного пересорта, False если возникла ошибка</returns>
        private bool CreateNewPeresort()
        {
            try
            {
                taFpGetItemsForReparation.SetTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds);
                peresortID = Convert.ToInt32(taFpGetItemsForReparation.AddCorrection(sessionID, invRow.Inventory_number, "CN"));
                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при создании идентификатора для потоварного пересорта", exc);
                return false;
            }
        }

        /// <summary>
        /// Переход на строку с фильтром по нажатию Ctrl+F
        /// </summary>
        private void PostInventoryFilialItemPeresortForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F)
                tbxFilter.Focus();
        }

        #endregion

        #region ДОБАВЛЕНИЕ/УДАЛЕНИЕ ТОВАРОВ ДЛЯ ПЕРЕСОРТА

        /// <summary>
        /// True, если последней нажатой кнопкой был Escape (это нужно, чтобы отменять в таком случае редактирование количества)
        /// </summary>
        private bool wasEscapePressed;

        /// <summary>
        /// Добавление товаров для потоварного пересорта (в правый список)
        /// </summary>
        private void btnAddItems_Click(object sender, EventArgs e)
        {
            try
            {
                var detailF = SelectedItemsForReparation[0].Результат == "недостача" ?
                    SelectedItemsForReparation[0] : SelectedItemsForReparation[1];
                var detailT = SelectedItemsForReparation[0].Результат != "недостача" ?
                    SelectedItemsForReparation[0] : SelectedItemsForReparation[1];
                taFpGetItemsForReparation.AddCorrectionDetails(sessionID, peresortID, (int?)detailF.Код_товара, detailF.Партия, detailF.Полка, detailF.Код_склада, detailF.Себестоимость, detailF.Ед_изм_,
                    Convert.ToDecimal(Math.Min(Math.Abs(detailF._Кол_во), Math.Abs(detailT._Кол_во))), (int?)detailT.Код_товара, detailT.Партия, detailT.Полка, detailT.Код_склада, detailT.Себестоимость);
                
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при добавлении товаров в документ взаимозачета!", exc);
            }

            LoadAvailableItems();
            LoadDetails();
        }

        /// <summary>
        /// Удаление товаров из правого списка (исключение их из потоварного пересорта)
        /// </summary>
        private void btnRemoveItems_Click(object sender, EventArgs e)
        {
            var Ids = new List<double>();
            foreach (DataGridViewRow dgvRow in dgvDocItems.SelectedRows)
            {
                var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Inventory.FP_Get_Correction_DetailsRow;
                if (!Ids.Contains(dbRow.ID_проводки))
                {
                    taFpGetItemsForReparation.EditCorrectionDetails(sessionID, peresortID, Convert.ToInt64(dbRow.ID_проводки), 0);
                    Ids.Add(dbRow.ID_проводки);
                }
            }

            LoadAvailableItems();
            LoadDetails();
        }

        /// <summary>
        /// Настройка доступности кнопки "Удалить связку товаров для пересорта"
        /// </summary>
        private void dgvDocItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocItems.SelectedRows.Count > 0)
                btnRemoveItems.Enabled = true;
            else
                btnRemoveItems.Enabled = false;
        }

        /// <summary>
        /// Определение доступности кнопки "Добавить" в зависимости от выбранных элементов в таблице доступных товаров
        /// </summary>
        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count != 2)
            {
                btnAddItems.Enabled = false;
                return;
            }

            var row1 = ((dgvItems.SelectedRows[0] as DataGridViewRow).DataBoundItem as DataRowView).Row
                as Data.Inventory.FP_Get_Items_For_ReparationRow;
            var row2 = ((dgvItems.SelectedRows[1] as DataGridViewRow).DataBoundItem as DataRowView).Row
                as Data.Inventory.FP_Get_Items_For_ReparationRow;

            // Нельзя выбирать пару с разными ставками НДС 0 и 20
            btnAddItems.Enabled =
                //(row1.Признак_НДС == row2.Признак_НДС) &&
           !((row1._ставка_зона_Описание.Equals("0") && row2._ставка_зона_Описание.Equals("20")) ||
           (row1._ставка_зона_Описание.Equals("20") && row2._ставка_зона_Описание.Equals("0")));

            // Нельзя выбрать пару одного знака
            if (row1._Кол_во * row2._Кол_во > 0)
                btnAddItems.Enabled = false;
        }

        /// <summary>
        /// Редактирование количества взаимозачета прямо в таблице
        /// </summary>
        private void dgvDocItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;
                var row = ((dgv.Rows[e.RowIndex]).DataBoundItem as DataRowView).Row as Data.Inventory.FP_Get_Correction_DetailsRow;
                taFpGetItemsForReparation.EditCorrectionDetails(sessionID, peresortID,
                    Convert.ToInt64(row.ID_проводки), Convert.ToDecimal(row._Кол_во));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось изменить количество товара в макете списания: ", exc);
            }

            LoadAvailableItems();
            LoadDetails();
        }

        /// <summary>
        /// Проверка, был ли нажат Escape (используется для отмены редактирования)
        /// </summary>
        protected override bool ProcessDialogKey(Keys pKeyData)
        {
            wasEscapePressed = pKeyData == Keys.Escape;
            return base.ProcessDialogKey(pKeyData);
        }

        /// <summary>
        /// Проверка правильности ввода количества
        /// </summary>
        private void dgvDocItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] != clDeQuantity || dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly)
                return;

            int num;

            if ((String.IsNullOrEmpty(e.FormattedValue.ToString()) && !wasEscapePressed) ||
                !Int32.TryParse(e.FormattedValue.ToString(), out num) ||
                num < 0)
            {
                MessageBox.Show("Количество должно быть неотрицательным целым числом!", "Неверно задано количество",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Разрешаем редактировать только T-строки
        /// </summary>
        private void dgvDocItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvDocItems.Columns[e.ColumnIndex] == clDeQuantity)
            {
                var dbRow = (dgvDocItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row
                    as Data.Inventory.FP_Get_Correction_DetailsRow;
                dgvDocItems.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = (dbRow.FT == "F");
            }
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ТОВАРОВ, ДОСТУПНЫХ ДЛЯ ПЕРЕСОРТА

        /// <summary>
        /// Строка фильтра
        /// </summary>
        private string filter;

        /// <summary>
        /// Применение фильтра при окончании работы таймера
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            RefreshFilter();
        }

        /// <summary>
        /// Обновление фильтров на таблице с доступными товарами для пересорта
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsFpGetItemsForReparation.Filter = String.Empty;
                else
                    bsFpGetItemsForReparation.Filter =
                        String.Format("Convert([Код товара], 'System.String') LIKE '%{0}%' OR [Наименование] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа

            SetRowColorItems();
        }

        /// <summary>
        /// Изменение фильтра
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            filter = tbxFilter.Text;
            delayTimer.Stop();
            delayTimer.Start();
        }

        /// <summary>
        /// Запуск фильтрации по нажатию на кнопку Enter
        /// </summary>
        private void tbxFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                delayTimer.Stop();
                RefreshFilter();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ НАСТРОЕК ПРИ ЗАКРЫТИИ ОКНА

        /// <summary>
        /// Сохранение настроек при закрытии окна
        /// </summary>
        private void PostInventoryFilialItemPeresortForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(LeftTableConfigName, dgvItems);
            Config.SaveDataGridViewSettings(RightTableConfigName, dgvDocItems);
            delayTimer.Stop();
        }

        #endregion

        #region ЭКСПОРТ СОЗДАННЫХ ВЗАИМОЗАЧЕТОВ В EXCEL

        /// <summary>
        /// Экспорт таблицы созданных взаимозачетов в CSV-файл
        /// </summary>
        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocItems.Rows.Count == 0)
                    MessageBox.Show("Не создано ни одного взаимозачета! Нечего экспортировать", "Экспорт в Excel",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    ExportHelper.ExportDataGridViewToExcel(dgvDocItems, "Экспорт взаимозачетов в Excel",
                        String.Format("взаимозачеты по инв.{0}", invRow.Inventory_number), true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта созданных взаимозачетов в Excel возникла ошибка!", exc);
            }
        }

        #endregion


        private void SetRowColorDocItems()
        {
            try
            {
                foreach (DataGridViewRow gridRow in dgvDocItems.Rows)
                {
                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;

                    var row = (gridRow.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FP_Get_Correction_DetailsRow;
                    if (row == null || row._Кол_во >= 0)
                        continue;

                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
                }
            }
            catch (Exception)
            {

            }
        }

        private void SetRowColorItems()
        {
            try
            {
                foreach (DataGridViewRow gridRow in dgvItems.Rows)
                {
                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Empty;

                    var row = (gridRow.DataBoundItem as DataRowView).Row as WMSOffice.Data.Inventory.FP_Get_Items_For_ReparationRow;
                    if (row == null || row._Кол_во >= 0)
                        continue;

                    gridRow.DefaultCellStyle.BackColor = System.Drawing.Color.Lavender;
                }
            }
            catch (Exception)
            {

            }
        }

        private void dgvItems_Sorted(object sender, EventArgs e)
        {
            SetRowColorItems();
        }

        private void dgvDocItems_Sorted(object sender, EventArgs e)
        {
            SetRowColorDocItems();
        }
    }
}
