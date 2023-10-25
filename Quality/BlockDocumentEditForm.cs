using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Dialogs.WH;
using System.ComponentModel;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для создания документа блокировки
    /// </summary>
    public partial class BlockDocumentEditForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Режим запуска окна
        /// </summary>
        private readonly BlockActionType actionType;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Код блокировки указанной при импорте
        /// </summary>
        private string importedHoldTypeID = (string)null;

        /// <summary>
        /// Склад указанный при импорте
        /// </summary>
        private string importedWarehouseID = (string)null;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public BlockDocumentEditForm(long pSessionID, BlockActionType pActionType, Data.Quality.BL_Block_Document_ItemsDataTable pItemsTable)
        {
            InitializeComponent();
            sessionID = pSessionID;
            actionType = pActionType;
            CustomColumnsForMode();
            quality.BL_Block_Document_Items.TableNewRow += BL_Block_Document_Items_TableNewRow;
            quality.BL_Block_Document_Items.Merge(pItemsTable);
        }

        /// <summary>
        /// Установка значений по умолчанию для добавляемой строки с товаром
        /// </summary>
        private void BL_Block_Document_Items_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            var newRow = e.Row as Data.Quality.BL_Block_Document_ItemsRow;
            newRow.DateFrom = DateTime.Now;
            if (actionType == BlockActionType.RecallNotification)
                newRow.HoldTypeID = "W";
        }

        /// <summary>
        /// Подстраивание окна под конкретный режим редаткирования
        /// </summary>
        private void CustomColumnsForMode()
        {
            clIsNewItem.Visible = clIsNewVendorLot.Visible = actionType == BlockActionType.CreateBlock;
            clDocID.Visible = actionType == BlockActionType.CreateException || actionType == BlockActionType.FinishBlock;
            clHoldTypeID.Visible = clHoldTypeName.Visible = actionType != BlockActionType.RecallNotification;

            sbFindPurchaseOrderItems.Enabled = actionType == BlockActionType.CreateBlock || actionType == BlockActionType.FinishBlock;

            switch (actionType)
            {
                case BlockActionType.CreateBlock:
                    Text = "Создание документа блокировки";
                    break;
                case BlockActionType.CreateException:
                    Text = "Создание исключения на блокировку";
                    break;
                case BlockActionType.FinishBlock:
                    Text = "Снятие блокировки";
                    break;
                case BlockActionType.RecallNotification:
                    Text = "Создание уведомления об отзыве";
                    break;
                default:
                    Text = "Неизвестное действие!";
                    break;
            }
        }

        /// <summary>
        /// Загрузка необходимых данных при загрузке окна
        /// </summary>
        private void BlockDocumentEditForm_Load(object sender, EventArgs e)
        {
            LoadDocSources();
            foreach (DataGridViewRow dgvRow in dgvItems.Rows)
                CheckRow(dgvRow);
            tbxOuterDocNumber.Focus();
            Config.LoadDataGridViewSettings(Name, dgvItems);
        }

        /// <summary>
        /// Загрузка возможных источников документов для выбора
        /// </summary>
        private void LoadDocSources()
        {
            try
            {
                taBlGetDocSources.Fill(quality.BL_Get_Doc_Sources, sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки источников документов: ", exc);
            }
        }

        /// <summary>
        /// При изменении источника блокировки загружаем доступные организации этого источника
        /// </summary>
        private void cmbDocSource_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadOrganizations();
        }

        /// <summary>
        /// Загрузка допустимых организаций для выбора
        /// </summary>
        private void LoadOrganizations()
        {
            try
            {
                if (cmbDocSource.SelectedItem != null)
                    taBlGetDocOrganisations.Fill(quality.BL_Get_Doc_Organisations, sessionID, Convert.ToInt32(cmbDocSource.SelectedValue));
                else
                    quality.BL_Get_Doc_Organisations.Clear();
                cmbOrganizations.Enabled = quality.BL_Get_Doc_Organisations.Count > 1;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки допустимых организаций: ", exc);
            }
        }

        /// <summary>
        /// Управление окном с помощью клавиатуры
        /// </summary>
        private void BlockDocumentEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
                btnOK_Click(btnOK, EventArgs.Empty);
            else if (e.Control && e.KeyCode == Keys.X)
                btnCancel_Click(btnCancel, EventArgs.Empty);
        }

        /// <summary>
        /// Сохранение параметров колонок при закрытии окна
        /// </summary>
        private void BlockDocumentEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvItems);
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ ТАБЛИЦЫ ВРУЧНУЮ

        /// <summary>
        /// Строка, которая отображается в ячейке, если для товара нет уточнения по серии
        /// </summary>
        public const string ALL_VENDOR_LOTS = "Все серии";

        /// <summary>
        /// Строка, которая отображается в ячейке, если для товара нет уточнения по партии
        /// </summary>
        public const string ALL_BATCH_IDS = "Все партии";

        /// <summary>
        /// Строка, которая отображается в ячейке, если для товара нет уточнения по складам
        /// </summary>
        public const string ALL_WAREHOUSES = "Все склады";

        /// <summary>
        /// Идентификатор, который передается в процедуру проверки сущности в БД, если сущность - тип блокировки
        /// </summary>
        private const string CHECK_BLOCK_TYPE_ID = "BT";

        /// <summary>
        /// Идентификатор, который передается в процедуру проверки сущности в БД, если сущность - производитель
        /// </summary>
        private const string CHECK_MANUFACTURER_ID = "MN";

        /// <summary>
        /// Идентификатор, который передается в процедуру проверки сущности в БД, если сущность - склад
        /// </summary>
        private const string CHECK_WAREHOUSE_ID = "WH";

        /// <summary>
        /// Получение серии из строки товара в документе
        /// </summary>
        /// <param name="pItemRow">Товар, серию которого нужно получить</param>
        /// <returns>Серия товара либо null, если товар не уточняется по серии (ВСЕ СЕРИИ)</returns>
        private static string GetVendorLot(Data.Quality.BL_Block_Document_ItemsRow pItemRow)
        {
            return (pItemRow.VendorLot == null || pItemRow.VendorLot == ALL_VENDOR_LOTS || pItemRow.IsNewVendorLot)
                ? null : pItemRow.VendorLot;
        }

        /// <summary>
        /// Получение партии из строки товара в документе
        /// </summary>
        /// <param name="pItemRow">Товар, партию которого нужно получить</param>
        /// <returns>Партия товара либо null, если товар не уточняется по партии (ВСЕ ПАРТИИ)</returns>
        private static string GetBatchID(Data.Quality.BL_Block_Document_ItemsRow pItemRow)
        {
            return (pItemRow.BatchID == null || pItemRow.BatchID == ALL_BATCH_IDS || pItemRow.IsNewVendorLot)
                ? null : pItemRow.BatchID;
        }

        /// <summary>
        /// Устранение некоторых моментов при редактировании строк вручную
        /// </summary>
        private void dgvItems_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            ValidateIfEmptyItemIdValue();
            ValidateIfEmptyValue();     // Для серий, партий и складов
        }

        /// <summary>
        /// Почему-то при удалении значения из ячейки с кодом товара значение автоматом не удаляется
        /// приходится вручную его присваивать ячейке.
        /// В данном методе просматривается текущая редактируемая ячейка
        /// </summary>
        private void ValidateIfEmptyItemIdValue()
        {
            var cell = dgvItems.CurrentCell;
            if (cell.ColumnIndex != clItemID.Index)
                return;

            var newVal = cell.EditedFormattedValue;
            if (newVal == null || String.IsNullOrEmpty(newVal.ToString()))
            {
                cell.Value = DBNull.Value;
                dgvItems.RefreshEdit();
            }
        }

        /// <summary>
        /// Ставит значение по умолчанию для колонки серий, партий, складов
        /// </summary>
        private void ValidateIfEmptyValue()
        {
            var cell = dgvItems.CurrentCell;
            if (cell.ColumnIndex != clVendorLot.Index && cell.ColumnIndex != clBatchID.Index && cell.ColumnIndex != clWarehouseID.Index)
                return;

            string defVal = String.Empty;
            if (cell.ColumnIndex == clVendorLot.Index)
                defVal = ALL_VENDOR_LOTS;
            else if (cell.ColumnIndex == clBatchID.Index)
                defVal = ALL_BATCH_IDS;
            else
                defVal = ALL_WAREHOUSES;

            var newVal = cell.EditedFormattedValue;
            if (newVal == null || String.IsNullOrEmpty(newVal.ToString()))
            {
                cell.Value = defVal;
                dgvItems.RefreshEdit();
            }
        }

        /// <summary>
        /// Сокрытие стандартной ошибки редактирования
        /// </summary>
        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }

        /// <summary>
        /// После редактирования ячейки проверяем строку на валидность
        /// </summary>
        private void dgvItems_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            dgvItems.CellValidated -= dgvItems_CellValidated;
            CheckRow(dgvItems.Rows[e.RowIndex]);
            dgvItems.CellValidated += dgvItems_CellValidated;
        }

        /// <summary>
        /// Проверка, существует ли товар с заданной серией и партией в справочнике
        /// </summary>
        /// <param name="pRow">Строка товара в датагриде, которую проверяем</param>
        private void CheckRow(DataGridViewRow pDgvRow)
        {
            if (pDgvRow.DataBoundItem == null)
                return;

            var dbRow = (pDgvRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_Block_Document_ItemsRow;
            try
            {
                dbRow.Result = String.Empty;

                CheckBlockTypeAndDates(dbRow);

                // Выполняем проверки по коду товара/серии/партии
                if (!dbRow.IsItem_IDNull())
                    CheckRowWithItemID(dbRow);
                else if (dbRow.IsItem_IDNull() && dbRow.IsNewItem)
                    CheckRowWithoutItemID(dbRow);
                else
                    dbRow.Result = "Не задан идентификатор товара!";

                CheckBlockTypeAndDates(dbRow);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при получении свойств товара из БД: ", exc);
                dbRow.Result = "Ошибка во время проверки!";
            }
            finally
            {
                CustomCells(pDgvRow);
                PaintRow(pDgvRow);
            }
        }

        /// <summary>
        /// Проверка строки товара с заданным кодом товара
        /// </summary>
        /// <param name="pDgvRow">Проверяемая строка с данными</param>
        private static void CheckRowWithItemID(Data.Quality.BL_Block_Document_ItemsRow pDbRow)
        {
            using (var adapter = new BL_Check_ItemTableAdapter())
            {
                var checkTable = adapter.GetData(pDbRow.Item_ID, GetVendorLot(pDbRow), GetBatchID(pDbRow));
                if (checkTable == null || checkTable.Count == 0)
                    throw new ApplicationException("Процедура получения свойств товара не вернула данные!");
                var checkRow = checkTable[0];
                pDbRow.Item_Name = checkRow.Isitem_nameNull() ? null : checkRow.item_name;
                pDbRow.Manufacturer = checkRow.Ismanufacturer_nameNull() ? null : checkRow.manufacturer_name;
                pDbRow.Vendor = checkRow.Isvendor_nameNull() ? null : checkRow.vendor_name;
                pDbRow.Result = checkRow.IsresultNull() ? null : checkRow.result;
                pDbRow.Manufacturer_ID = checkRow.Ismanufacturer_idNull() ? null : checkRow.manufacturer_id.ToString();
            }
        }

        /// <summary>
        /// Проверка строки товара без кода товара (такого, что может быть товаром которого нет в справочника)
        /// </summary>
        /// <param name="pDgvRow">Проверяемая строка с данными</param>
        private void CheckRowWithoutItemID(Data.Quality.BL_Block_Document_ItemsRow pDbRow)
        {
            if (pDbRow.IsItem_NameNull() || String.IsNullOrEmpty(pDbRow.Item_Name))
                pDbRow.Result = "Для товаров, которых нет в справочнике, нужно обязательно задать название товара!";
            else if (pDbRow.VendorLot == ALL_VENDOR_LOTS)
                pDbRow.Result = "Для товаров, которых нет в справочнике, нужно обязательно задать серию!";
            CheckManufacturer(pDbRow);
        }

        /// <summary>
        /// Проверка, задан ли производитель для товара без кода товара
        /// </summary>
        /// <param name="pDbRow">Проверяемая строка с данными</param>
        private void CheckManufacturer(Data.Quality.BL_Block_Document_ItemsRow pDbRow)
        {
            if (!pDbRow.IsManufacturer_IDNull() && !String.IsNullOrEmpty(pDbRow.Manufacturer_ID))   // Задан код производителя
                using (var adapter = new BL_Check_EntityTableAdapter())
                {
                    var table = adapter.GetData(sessionID, pDbRow.Manufacturer_ID, CHECK_MANUFACTURER_ID);
                    if (table == null || table.Count == 0 || table[0].IsresultNull())
                            pDbRow.Result = "Не найден производитель с таким идентификатором!";
                    else
                        pDbRow.Manufacturer = table[0].result;
                }
            else if (pDbRow.IsManufacturerNull() || String.IsNullOrEmpty(pDbRow.Manufacturer))  // Производитель вообще не задан
                pDbRow.Result = "Для товаров, которых нет в справочнике, нужно обязательно задать производителя!";          
        }

        /// <summary>
        /// Проверка на правильность ввода типа блокировки и дат
        /// </summary>
        /// <param name="pDbRow">Проверяемая строка с данными</param>
        private void CheckBlockTypeAndDates(Data.Quality.BL_Block_Document_ItemsRow pDbRow)
        {
            if (pDbRow.IsHoldTypeIDNull() || String.IsNullOrEmpty(pDbRow.HoldTypeID))
                pDbRow.Result = "Нужно задать тип блокировки!";
            else
            {
                using (var adapter = new BL_Check_EntityTableAdapter())
                {
                    var table = adapter.GetData(sessionID, pDbRow.HoldTypeID, CHECK_BLOCK_TYPE_ID);
                    if (table == null || table.Count == 0 || table[0].IsresultNull())
                        pDbRow.Result = "Не найден тип блокировки с таким идентификатором!";
                    else
                        pDbRow.HoldTypeName = table[0].result;
                }
            }

            // продолжаем проверку, если нет ошибок
            if (pDbRow.IsResultNull() || String.IsNullOrEmpty(pDbRow.Result))
                CheckWarehouse(pDbRow);

            // продолжаем проверку, если нет ошибок
            if (pDbRow.IsResultNull() || String.IsNullOrEmpty(pDbRow.Result))
            {
                if (pDbRow.IsDateFromNull())
                    pDbRow.Result = "Должна быть задана дата начала действия блокировки!";
                else if (actionType == BlockActionType.RecallNotification && pDbRow.IsDateToNull())
                    pDbRow.Result = "Должна быть задана дата окончания действия отзыва!";
                else if (!pDbRow.IsDateToNull() && pDbRow.DateFrom > pDbRow.DateTo)
                    pDbRow.Result = "Дата начала действия блокировки не может быть больше чем дата окончания!";
            }

            // продолжаем проверку, если нет ошибок
            if ((pDbRow.IsResultNull() || String.IsNullOrEmpty(pDbRow.Result)) && 
                (actionType == BlockActionType.CreateException || actionType == BlockActionType.FinishBlock))
            {
                if (pDbRow.IsDoc_IDNull() || String.IsNullOrEmpty(pDbRow.Doc_ID))
                    pDbRow.Result = "Нужно выбрать документ, к которому будет привязана строка!";
            }
        }

        /// <summary>
        /// Проверка, правильно ли задан склад
        /// </summary>
        /// <param name="pDbRow">Проверяемая строка с данными</param>
        private void CheckWarehouse(Data.Quality.BL_Block_Document_ItemsRow pDbRow)
        {
            if (pDbRow.Warehouse_ID != ALL_WAREHOUSES) 
                using (var adapter = new BL_Check_EntityTableAdapter())
                {
                    var table = adapter.GetData(sessionID, pDbRow.Warehouse_ID, CHECK_WAREHOUSE_ID);
                    if (table == null || table.Count == 0 || table[0].IsresultNull())
                        pDbRow.Result = "Не найден склад с таким идентификатором!";
                }
        }

        /// <summary>
        /// Настройка ячеек строки
        /// </summary>
        private void CustomCells(DataGridViewRow pDgvRow)
        {
            var dbRow = (pDgvRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_Block_Document_ItemsRow;
            foreach (DataGridViewCell cell in pDgvRow.Cells)
            {
                if (cell.ColumnIndex == clItemName.Index)
                    cell.ReadOnly = !dbRow.IsItem_IDNull() || (dbRow.IsItem_IDNull() && !dbRow.IsNewItem);
                else if (cell.ColumnIndex == clManufacturerID.Index)
                    cell.ReadOnly = !dbRow.IsItem_IDNull() || (dbRow.IsItem_IDNull() && !dbRow.IsNewItem);
                else if (cell.ColumnIndex == clManufacturer.Index)
                    cell.ReadOnly = (!dbRow.IsItem_IDNull() || (dbRow.IsItem_IDNull() && !dbRow.IsNewItem)) &&
                        (dbRow.IsManufacturer_IDNull() || String.IsNullOrEmpty(dbRow.Manufacturer_ID));
                else if (cell.ColumnIndex == clBatchID.Index)
                    cell.ReadOnly = dbRow.IsItem_IDNull() && !dbRow.IsNewVendorLot;
                else if (cell.ColumnIndex == clIsNewVendorLot.Index)
                    cell.ReadOnly = dbRow.IsItem_IDNull();
            }
        }

        /// <summary>
        /// Раскрашивание строки датагрида с товаром в зависимости от значения проверки
        /// </summary>
        /// <param name="pDgvRow">Строка датагрида с товарами, которую нужно раскрасить</param>
        private void PaintRow(DataGridViewRow pDgvRow)
        {
            var dbRow = (pDgvRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_Block_Document_ItemsRow;
            foreach (DataGridViewCell cell in pDgvRow.Cells)
            {
                cell.Style.Font = cell.ReadOnly ? new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204))) :
                    new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                cell.Style.BackColor = cell.Style.SelectionForeColor =
                    (dbRow.IsResultNull() || String.IsNullOrEmpty(dbRow.Result) ? Color.White : Color.Red);
            }
        }

        #endregion

        #region ВЫБОР ЗНАЧЕНИЙ ИЗ ВЫПАДАЮЩИХ СПРАВОЧНИКОВ

        /// <summary>
        /// Отображение справочников для колонок с "фонариками"
        /// </summary>
        private void dgvItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvItems.CurrentCell.ColumnIndex == clItemID.Index || 
                dgvItems.CurrentCell.ColumnIndex == clVendorLot.Index ||
                dgvItems.CurrentCell.ColumnIndex == clBatchID.Index ||
                dgvItems.CurrentCell.ColumnIndex == clManufacturerID.Index ||
                dgvItems.CurrentCell.ColumnIndex == clWarehouseID.Index ||
                dgvItems.CurrentCell.ColumnIndex == clHoldTypeID.Index ||
                dgvItems.CurrentCell.ColumnIndex == clDocID.Index ||
                dgvItems.CurrentCell.ColumnIndex == clExpirationDate.Index)
            {
                var editor = e.Control as EllipsisGridCellEditorControl;
                editor.ShowSelector -= Editor_ShowSelector;
                editor.ShowSelector += Editor_ShowSelector;
            }
        }

        /// <summary>
        /// Открываем справочник товаров для редактирования колонки с кодом товара
        /// </summary>
        private void Editor_ShowSelector(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell.ColumnIndex == clItemID.Index)
                InsertItemFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clVendorLot.Index)
                InsertVendorLotFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clBatchID.Index)
                InsertBatchIDFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clManufacturerID.Index)
                InsertManufacturerFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clWarehouseID.Index)
                InsertWarehousesFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clHoldTypeID.Index)
                InsertHoldTypeFromDirectory();
            else if (dgvItems.CurrentCell.ColumnIndex == clExpirationDate.Index)
                InsertVendorLotsExpirationDatesFromDirectory();
            else
                InsertDocumentFromDirectory();
        }

        /// <summary>
        /// Редактирование товара/вставка новых товаров с помощью справочника
        /// </summary>
        private void InsertItemFromDirectory()
        {
            var currentRow = dgvItems.CurrentRow;
            var checkedItems = GetItemsFromDirectory();
            for (int i = 0; i < checkedItems.Count; i++)
            {
                var dictItem = checkedItems[i] as Data.Quality.BL_SelectItemsRow;
                Data.Quality.BL_Block_Document_ItemsRow item;
                if (i == 0)
                {
                    var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                    if (tableRowView == null)
                        tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                    item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                }
                else
                {
                    DataRowView tableRowView;
                    if (bsblBlockDocumentItems.Position == bsblBlockDocumentItems.Count - 1)
                        tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                    else
                    {
                        bsblBlockDocumentItems.MoveNext();
                        tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                    }
                    item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                }

                (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                item.Item_ID = Convert.ToInt32(dictItem.Item_ID);
                CopyRow(currentRow, item, ItemsRowCopyColumns.Items);
                CheckRow(dgvItems.CurrentRow);
            }
        }

        /// <summary>
        /// Выбор нескольких товаров из выпадающего справочника
        /// </summary>
        /// <returns>Список, содержащий выбранные товары либо пустой список, если не выбран ни один товар</returns>
        private List<DataRow> GetItemsFromDirectory()
        {
            var itms = LoadItems();
            var result = new List<DataRow>();
            if (itms != null)
            {
                var titles = new Dictionary<string, string>();
                var selectorForm = new ManyItemsChoiceForm(itms, new string[] { 
                    "Код товара", "Наименование товара", "Производитель", "Поставщик" }, ItemsChoiceMode.Multiple);
                selectorForm.Text = "Выбор товаров";
                selectorForm.FilterPattern = "Convert([Item_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%' OR [Manufacturer] LIKE '%{0}%' OR [Vendor] LIKE '%{0}%'";
                selectorForm.ConfigName = "BlockDocumentEditFormItemsSelectorForm";
                if (selectorForm.ShowDialog(this) == DialogResult.OK)
                    result = selectorForm.CheckedRows;
            }

            return result;
        }

        /// <summary>
        /// Получение таблицы товаров для справочника множественного выбора товаров
        /// </summary>
        /// <returns>Таблица с товарами либо null если загрузка завершилась с ошибкой</returns>
        private Data.Quality.BL_SelectItemsDataTable LoadItems()
        {
            try
            {
                using (var adapter = new BL_SelectItemsTableAdapter())
                    return adapter.GetData(sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка товаров:", exc);
                return null;
            }
        }

        /// <summary>
        /// Копирование значений из существующей строки в новую строку, учитывая тип копирования строки
        /// </summary>
        /// <param name="pFromRow">Строка, из которой берутся значения 
        /// (берется строка грида, а не DataTable, потому что к строке грида может еще быть не привязано DataRow)</param>
        /// <param name="pToRow">Строка, куда копируются значения </param>
        /// <param name="pCopyType">Тип копирования</param>
        private void CopyRow(DataGridViewRow pFromRow, Data.Quality.BL_Block_Document_ItemsRow pToRow,
           ItemsRowCopyColumns pCopyType)
        {
            // Копируем ячейку с идентификатором товара
            if (pCopyType != ItemsRowCopyColumns.Items)
                if (pFromRow.Cells[clItemID.Index].Value != null && pFromRow.Cells[clItemID.Index].Value != DBNull.Value)
                    pToRow.Item_ID = Convert.ToInt32(pFromRow.Cells[clItemID.Index].Value);

            // Копируем ячейку с серией товара
            if (pCopyType == ItemsRowCopyColumns.Warehouses)
                pToRow.VendorLot = (string)pFromRow.Cells[clVendorLot.Index].Value;

            // Копируем ячейку с партией товара
            if (pCopyType == ItemsRowCopyColumns.Warehouses)
                pToRow.BatchID = (string)pFromRow.Cells[clBatchID.Index].Value;

            // Копируем ячейку со складом
            if (pCopyType != ItemsRowCopyColumns.Warehouses)
                pToRow.Warehouse_ID = (string)pFromRow.Cells[clWarehouseID.Index].Value;

            // Копируем ячейку с типом блокировки
            if (pFromRow.Cells[clHoldTypeID.Index].Value != null && pFromRow.Cells[clHoldTypeID.Index].Value != DBNull.Value)
                pToRow.HoldTypeID = (string)pFromRow.Cells[clHoldTypeID.Index].Value;
            if (pFromRow.Cells[clHoldTypeName.Index].Value != null && pFromRow.Cells[clHoldTypeName.Index].Value != DBNull.Value)
                pToRow.HoldTypeName = (string)pFromRow.Cells[clHoldTypeName.Index].Value;

            // Копируем ячейки с датами
            if (pFromRow.Cells[clDateFrom.Index].Value != null && pFromRow.Cells[clDateFrom.Index].Value != DBNull.Value)
                pToRow.DateFrom = Convert.ToDateTime(pFromRow.Cells[clDateFrom.Index].Value);
            if (pFromRow.Cells[clDateTo.Index].Value != null && pFromRow.Cells[clDateTo.Index].Value != DBNull.Value)
                pToRow.DateTo = Convert.ToDateTime(pFromRow.Cells[clDateTo.Index].Value);
            if (pFromRow.Cells[clExpirationDate.Index].Value != null && pFromRow.Cells[clExpirationDate.Index].Value != DBNull.Value)
                pToRow.Expiration_Date = Convert.ToDateTime(pFromRow.Cells[clExpirationDate.Index].Value);
        }

        /// <summary>
        /// Редактирование серии/вставка новых серий с помощью справочника
        /// </summary>
        private void InsertVendorLotFromDirectory()
        {
            var itemIdValue = dgvItems.CurrentRow.Cells[clItemID.Index].Value;
            if (itemIdValue == null || itemIdValue == DBNull.Value)
            {
                MessageBox.Show("Не выбран код товара! Справочник серий можно отображать только по товару." +
                    " Если код товара не задан, серию можно ввести только вручную",
                    "Редактирование товара", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int currentRowIndex = dgvItems.CurrentRow.Index;
            var checkedVls = GetVendorLotsFromDirectory(Convert.ToInt32(itemIdValue));

            for (int i = 0; i < checkedVls.Count; i++)
            {
                var selVendorLot = checkedVls[i] as Data.Quality.BL_Get_Vendor_LotsRow;
                Data.Quality.BL_Block_Document_ItemsRow tblItem;
                if (i == 0)
                {
                    var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                    if (tableRowView == null)
                        tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                    tblItem = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                    (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                }
                else
                {
                    tblItem = quality.BL_Block_Document_Items.NewBL_Block_Document_ItemsRow();
                    quality.BL_Block_Document_Items.Rows.InsertAt(tblItem, currentRowIndex + i);
                }

                tblItem.VendorLot = selVendorLot.Vendor_Lot;
                CopyRow(dgvItems.Rows[currentRowIndex], tblItem, ItemsRowCopyColumns.VendorLots);
                CheckRow(dgvItems.Rows[currentRowIndex + i]);
            }
        }

        /// <summary>
        /// Выбор нескольких серий из выпадающего справочника
        /// </summary>
        /// <param name="pItemID">Идентификатор товара, для которого нужно получить серии</param>
        /// <returns>Список, содержащий выбранные серии либо пустой список, если не выбрана ни одна серия</returns>
        private List<DataRow> GetVendorLotsFromDirectory(int pItemID)
        {
            var vls = LoadVendorLots(pItemID);
            var result = new List<DataRow>();
            if (vls != null)
            {
                var selectorForm = new ManyItemsChoiceForm(vls, new string[] { "Серия" }, ItemsChoiceMode.Multiple);
                selectorForm.Text = "Выбор серий";
                selectorForm.FilterPattern = "[Vendor_Lot] LIKE '%{0}%'";
                selectorForm.ConfigName = "BlockDocumentEditFormVLsSelectorForm";
                if (selectorForm.ShowDialog(this) == DialogResult.OK)
                    result = selectorForm.CheckedRows;
            }

            return result;
        }

        /// <summary>
        /// Загрузка серий, на которые можно поставить блокировку
        /// </summary>
        /// <param name="pItemID">Идентификатор товара, для которого нужно получить серии</param>
        /// <returns>Таблица с сериями товара, на которые можно поставить блокировку</returns>
        private Data.Quality.BL_Get_Vendor_LotsDataTable LoadVendorLots(int pItemID)
        {
            try
            {
                using (var adapter = new BL_Get_Vendor_LotsTableAdapter())
                    return adapter.GetData(sessionID, pItemID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка серий:", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование партии/вставка новых партий с помощью справочника
        /// </summary>
        private void InsertBatchIDFromDirectory()
        {
            var vendorLot = dgvItems.CurrentRow.Cells[clVendorLot.Index].Value.ToString() == ALL_VENDOR_LOTS ?
                null : dgvItems.CurrentRow.Cells[clVendorLot.Index].Value.ToString();
            int itemID = Convert.ToInt32(dgvItems.CurrentRow.Cells[clItemID.Index].Value);
            int currentRowIndex = dgvItems.CurrentRow.Index;
            var batchIds = GetGetBatchIdsFromDirectory(itemID, vendorLot);
            for (int i = 0; i < batchIds.Count; i++)
                {
                    var selBatchID = batchIds[i] as Data.Quality.BL_Get_Lot_NumbersRow;
                    Data.Quality.BL_Block_Document_ItemsRow tblItem;
                    if (i == 0)
                    {
                        var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                        if (tableRowView == null)
                            tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                        tblItem = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                        (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                    }
                    else
                    {
                        tblItem = quality.BL_Block_Document_Items.NewBL_Block_Document_ItemsRow();
                        quality.BL_Block_Document_Items.Rows.InsertAt(tblItem, currentRowIndex + i);
                    }

                    tblItem.VendorLot = selBatchID.Vendor_Lot;
                    tblItem.BatchID = selBatchID.Lot_Number.ToString();
                    CopyRow(dgvItems.Rows[currentRowIndex], tblItem, ItemsRowCopyColumns.BatchIDs);
                    CheckRow(dgvItems.Rows[currentRowIndex + i]);
                }
        }

        /// <summary>
        /// Выбор нескольких партий из выпадающего справочника
        /// </summary>
        /// <param name="pItemID">Идентификатор товара, для которого нужно получить партии</param>
        /// <param name="pVendorLot">Серия, для которой нужно получить партии, либо null если нужно получить партии по всему товару</param>
        /// <returns>Список, содержащий выбранные партии либо пустой список, если не выбрана ни одна партия</returns>
        private List<DataRow> GetGetBatchIdsFromDirectory(int pItemID, string pVendorLot)
        {
            var bis = LoadBatchIds(pItemID, pVendorLot);
            var result = new List<DataRow>();
            if (bis != null)
            {
                var selectorForm = new ManyItemsChoiceForm(bis, new string[] { "Серия", "Партия" }, ItemsChoiceMode.Multiple);
                selectorForm.Text = "Выбор партий";
                selectorForm.FilterPattern = "[Lot_Number] LIKE '%{0}%'";
                selectorForm.ConfigName = "BlockDocumentEditFormBatchIdsSelectorForm";
                if (selectorForm.ShowDialog(this) == DialogResult.OK)
                    result = selectorForm.CheckedRows;
            }

            return result;
        }

        /// <summary>
        /// Загрузка партий, на которые можно поставить блокировку
        /// </summary>
        /// <param name="pItemID">Идентификатор товара, для которого нужно получить партии</param>
        /// <param name="pVendorLot">Серия, для которой нужно получить партии, либо null если нужно получить партии по всему товару</param>
        /// <returns>Таблица с партиями, на которые можно поставить блокировку</returns>
        private Data.Quality.BL_Get_Lot_NumbersDataTable LoadBatchIds(int pItemID, string pVendorLot)
        {
            try
            {
                using (var adapter = new BL_Get_Lot_NumbersTableAdapter())
                    return adapter.GetData(sessionID, pItemID, pVendorLot);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка партий:", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование производителя с помощью справочника
        /// </summary>
        private void InsertManufacturerFromDirectory()
        {
            var row = GetManufacturerFromDirectory();
            if (row != null)
            {
                var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                if (tableRowView == null)
                    tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                var item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                item.Manufacturer_ID = row.Manufacturer_ID.ToString();
                item.Manufacturer = row.Manufacturer;
                dgvItems.RefreshEdit();
            }
        }

        /// <summary>
        /// Выбор производителя из справочника
        /// </summary>
        private Data.Quality.BL_Get_ManufacturersRow GetManufacturerFromDirectory()
        {
            var manufacturers = GetManufacturers();
            if (manufacturers == null)
                return null;

            var choiceForm = new ManyItemsChoiceForm(manufacturers, new string[] { "Код произв.", "Производитель" }, ItemsChoiceMode.Single);
            choiceForm.Text = "Выбор производителя";
            choiceForm.ConfigName = "BlockDocumentEditFormManufSelectorForm";
            choiceForm.FilterPattern = "[Manufacturer_ID] LIKE '%{0}%' OR [Manufacturer] LIKE '%{0}%'";
            if (choiceForm.ShowDialog(this) == DialogResult.OK)
                return choiceForm.SelectedRow as Data.Quality.BL_Get_ManufacturersRow;
            else return null;
        }

        /// <summary>
        /// Получение списка производителей из БД
        /// </summary>
        /// <returns>Таблица с производителями либо null, если возникла ошибка</returns>
        private Data.Quality.BL_Get_ManufacturersDataTable GetManufacturers()
        {
            try
            {
                using (var adapter = new BL_Get_ManufacturersTableAdapter())
                    return adapter.GetData();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка производителей: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование срока годности с помощью справочника
        /// </summary>
        private void InsertVendorLotsExpirationDatesFromDirectory()
        {
            var itemIDValue = dgvItems.CurrentRow.Cells[clItemID.Index].Value;
            if (itemIDValue == null || itemIDValue == DBNull.Value)
            {
                MessageBox.Show("Не выбран код товара!", "Редактирование срока годности", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int itemID = Convert.ToInt32(dgvItems.CurrentRow.Cells[clItemID.Index].Value);
            var vendorLot = dgvItems.CurrentRow.Cells[clVendorLot.Index].Value.ToString() == ALL_VENDOR_LOTS ? null : dgvItems.CurrentRow.Cells[clVendorLot.Index].Value.ToString();

            var row = GetVendorLotsExpirationDatesFromDirectory(itemID, vendorLot);
            if (row != null)
            {
                var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                if (tableRowView == null)
                    tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                var item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                item.Expiration_Date = row.Expiration_Date;
                dgvItems.RefreshEdit();
            }
        }

        /// <summary>
        /// Выбор срока годности из справочника
        /// </summary>
        private Data.Quality.BL_Get_Vendor_Lots_Expiration_DatesRow GetVendorLotsExpirationDatesFromDirectory(int pItemID, string pVendorLot)
        {
            var expDates = GetVendorLotsExpirationDates(pItemID, pVendorLot);
            if (expDates == null)
                return null;

            var choiceForm = new ManyItemsChoiceForm(expDates, new string[] { "Срок годности" }, ItemsChoiceMode.Single);
            choiceForm.Text = "Выбор срока годности";
            choiceForm.ConfigName = "BlockDocumentEditFormExpDateSelectorForm";
            choiceForm.FilterPattern = "[Expiration_Date] LIKE '%{0}%'";
            if (choiceForm.ShowDialog(this) == DialogResult.OK)
                return choiceForm.SelectedRow as Data.Quality.BL_Get_Vendor_Lots_Expiration_DatesRow;
            else return null;
        }

        /// <summary>
        /// Получение списка сроков годности из БД
        /// </summary>
        /// <returns>Таблица со сроками годности  либо null, если возникла ошибка</returns>
        private Data.Quality.BL_Get_Vendor_Lots_Expiration_DatesDataTable GetVendorLotsExpirationDates(int pItemID, string pVendorLot)
        {
            try
            {
                using (var adapter = new BL_Get_Vendor_Lots_Expiration_DatesTableAdapter())
                    return adapter.GetData(pItemID, pVendorLot);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка сроков годности: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование типа блокировки с помощью справочника
        /// </summary>
        private void InsertHoldTypeFromDirectory()
        {
            var row = GetHoldTypeFromDirectory();
            if (row != null)
            {
                var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                if (tableRowView == null)
                    tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                var item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                item.HoldTypeID = row.Hold_ID;
                item.HoldTypeName = row.Hold;
                dgvItems.RefreshEdit();
                dgvItems.Refresh();
            }
        }

        /// <summary>
        /// Выбор типа блокировки из справочника
        /// </summary>
        private Data.Quality.BL_Get_HoldTypesRow GetHoldTypeFromDirectory()
        {
            var holdTypes = GetHoldTypes();
            if (holdTypes == null)
                return null;

            var titles = new Dictionary<string, string>();
            titles.Add("Hold_ID", "Код типа");
            titles.Add("Hold", "Название типа блокировки");
            var selectorForm = new ManyItemsChoiceForm(holdTypes, titles, ItemsChoiceMode.Single);
            selectorForm.Text = "Выбор типа блокировки";
            selectorForm.FilterPattern = "[Hold_ID] LIKE '%{0}%' OR [Hold] LIKE '%{0}%'";
            selectorForm.ConfigName = "BlockDocumentEditFormHoldIDSelectorForm";
            if (selectorForm.ShowDialog(this) == DialogResult.OK)
                return selectorForm.SelectedRow as Data.Quality.BL_Get_HoldTypesRow;
            else
                return null;
        }

        /// <summary>
        /// Получение списка типов блокировок из БД
        /// </summary>
        /// <returns>Таблица с типами блокировок либо null, если возникла ошибка</returns>
        private Data.Quality.BL_Get_HoldTypesDataTable GetHoldTypes()
        {
            try
            {
                using (var adapter = new BL_Get_HoldTypesTableAdapter())
                    return adapter.GetData(sessionID, false, Convert.ToInt32(cmbDocSource.SelectedValue));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка типов блокировок: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование складов с помощью справочника
        /// </summary>
        private void InsertWarehousesFromDirectory()
        {
            int currentRowIndex = dgvItems.CurrentRow.Index;
            var checkedWhs = GetWarehousesFromDirectory(false);
            for (int i = 0; i < checkedWhs.Count; i++)
            {
                var selWhID = checkedWhs[i] as Data.Quality.BL_Get_WarehousesRow;
                Data.Quality.BL_Block_Document_ItemsRow tblItem;
                if (i == 0)
                {
                    var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                    if (tableRowView == null)
                        tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                    tblItem = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                    (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                }
                else
                {
                    tblItem = quality.BL_Block_Document_Items.NewBL_Block_Document_ItemsRow();
                    quality.BL_Block_Document_Items.Rows.InsertAt(tblItem, currentRowIndex + i);
                }

                tblItem.Warehouse_ID = selWhID.Warehouse_ID;
                CopyRow(dgvItems.Rows[currentRowIndex], tblItem, ItemsRowCopyColumns.Warehouses);
                CheckRow(dgvItems.Rows[currentRowIndex + i]);
            }
        }

        /// <summary>
        /// Выбор одного или нескольких складов из выпадающего справочника
        /// </summary>
        /// <param name="singleOnly">Признак единственности выбора</param>
        /// <returns>Список, содержащий выбранные склады либо пустой список, если не выбран ни один склад</returns>        
        private List<DataRow> GetWarehousesFromDirectory(bool singleOnly)
        {
            var whs = LoadWarehouses();
            var result = new List<DataRow>();
            if (whs != null)
            {
                var titles = new Dictionary<string, string>();
                titles.Add("Warehouse_ID", "Код склада");
                titles.Add("Warehouse_DSC", "Наименование склада");
                var selectorForm = new ManyItemsChoiceForm(whs, titles, singleOnly ? ItemsChoiceMode.Single : ItemsChoiceMode.Multiple);
                selectorForm.Text = "Выбор складов";
                selectorForm.FilterPattern = "[Warehouse_ID] LIKE '%{0}%' OR [Warehouse_DSC] LIKE '%{0}%'";
                selectorForm.ConfigName = "BlockDocumentEditFormWhSelectorForm";
                if (selectorForm.ShowDialog(this) == DialogResult.OK)
                    result = singleOnly ? new List<DataRow>(new DataRow[] { selectorForm.SelectedRow }) : selectorForm.CheckedRows;
            }
            
            return result;
        }

        /// <summary>
        /// Загрузка складов, на которые можно поставить блокировку
        /// </summary>
        /// <returns>Таблица со складами, на которые можно поставить блокировку</returns>
        private Data.Quality.BL_Get_WarehousesDataTable LoadWarehouses()
        {
            try
            {
                using (var adapter = new BL_Get_WarehousesTableAdapter())
                    return adapter.GetData(sessionID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка складов:", exc);
                return null;
            }
        }

        /// <summary>
        /// Редактирование документа с помощью справочника
        /// </summary>
        private void InsertDocumentFromDirectory()
        {
            var row = GetDocumentFromDirectory();
            if (row != null)
            {
                var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                if (tableRowView == null)
                    tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                var item = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                item.Doc_ID = row.Doc_ID.ToString();
                item.parent_hold_id = row.hold_id.ToString();
                item.VendorLot = (row.Isvendor_lotNull() || String.IsNullOrEmpty(row.vendor_lot)) ? ALL_VENDOR_LOTS : row.vendor_lot;
                item.BatchID = (row.Islot_numberNull() || String.IsNullOrEmpty(row.lot_number)) ? ALL_BATCH_IDS : row.lot_number;
                
                dgvItems.RefreshEdit();
                dgvItems.Refresh();
            }
        }

        /// <summary>
        /// Выбор документа из справочника
        /// </summary>
        private Data.Quality.BL_Get_DocsRow GetDocumentFromDirectory()
        {
            var docs = GetDocs();
            if (docs == null)
                return null;

            var titles = new Dictionary<string, string>();
            titles.Add("Doc_ID", "Код документа");
            titles.Add("hold_type", "Тип блокировки");
            titles.Add("External_Doc_Number", "Номер документа");
            titles.Add("External_Doc_Date", "Дата документа");
            titles.Add("Item_ID", "Код товара");
            titles.Add("Item_Name", "Наименование товара");
            titles.Add("vendor_lot", "Серия");
            titles.Add("lot_number", "Партия");
            titles.Add("User", "Пользователь");
            titles.Add("Doc_Comment", "Описание");
            var selectorForm = new ManyItemsChoiceForm(docs, titles, ItemsChoiceMode.Single);
            selectorForm.Text = "Выбор документа";
            selectorForm.FilterPattern = "[External_Doc_Number] LIKE '%{0}%' OR [vendor_lot] LIKE '%{0}%'";
            selectorForm.ConfigName = "BlockDocumentEditFormDocSelectorForm";
            if (selectorForm.ShowDialog(this) == DialogResult.OK)
                return selectorForm.SelectedRow as Data.Quality.BL_Get_DocsRow;
            else
                return null;
        }

        /// <summary>
        /// Получение списка документов по строке
        /// </summary>
        /// <returns>Таблица с документами либо null, если возникла ошибка</returns>
        private Data.Quality.BL_Get_DocsDataTable GetDocs()
        {
            try
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                var row = dgvItems.CurrentRow;

                return BlockDocumentEditForm.GetDocs(
                    sessionID,
                    Convert.ToInt32(row.Cells[clItemID.Index].Value),
                    row.Cells[clVendorLot.Index].Value.ToString() == ALL_VENDOR_LOTS ? null : row.Cells[clVendorLot.Index].Value.ToString(),
                    row.Cells[clBatchID.Index].Value.ToString() == ALL_BATCH_IDS ? null : row.Cells[clBatchID.Index].Value.ToString(),
                    row.Cells[clWarehouseID.Index].Value.ToString() == ALL_WAREHOUSES ? null : row.Cells[clWarehouseID.Index].Value.ToString(),
                    row.Cells[clHoldTypeID.Index].Value.ToString(),
                    (row.Cells[clDateFrom.Index].Value == null || row.Cells[clDateFrom.Index].Value == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(row.Cells[clDateFrom.Index].Value),
                    (row.Cells[clDateTo.Index].Value == null || row.Cells[clDateTo.Index].Value == DBNull.Value) ? null : (DateTime?)Convert.ToDateTime(row.Cells[clDateTo.Index].Value));

            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время подготовки поиска документов блокировки по строке: ", ex);
                return null;
            }
        }

        private static Data.Quality.BL_Get_DocsDataTable GetDocs(long sessionID, int itemID, string vendorLot, string lotNumber, string warehouseID, string holdTypeID, DateTime? dateFrom, DateTime? dateTo)
        {
            try
            {
                using (var adapter = new BL_Get_DocsTableAdapter())
                    return adapter.GetData(sessionID, itemID, vendorLot, lotNumber, warehouseID, holdTypeID, dateFrom, dateTo);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки документов блокировки по строке: ", exc);
                return null;
            }
        }

        #endregion

        #region ИМПОРТ ИЗ EXCEL

        /// <summary>
        /// Вставка данных из Excel по при выборе соответствующего пункта меню
        /// </summary>
        private void miImportFromExcel_Click(object sender, EventArgs e)
        {
            PasteDataFromClipboard();
        }

        /// <summary>
        /// Вставка данных в таблицу товаров из буфера обмена
        /// </summary>
        private void PasteDataFromClipboard()
        {
            dgvItems.Rows[dgvItems.Rows.Count - 1].Selected = true;

            var dObject = Clipboard.GetDataObject() as DataObject;
            if (dObject.GetDataPresent(DataFormats.Text))
            {
                string[] bufferRows = Regex.Split(dObject.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                if (bufferRows == null || bufferRows.Length == 0)
                    return;

                // выбор типа блокировки при импорте
                if (actionType == BlockActionType.CreateBlock)
                {
                    var holdType = GetHoldTypeFromDirectory();
                    importedHoldTypeID = holdType == null ? (string)null : holdType.Hold_ID;
                }

                // выбор склада при импорте
                if (actionType == BlockActionType.CreateBlock || actionType == BlockActionType.FinishBlock)
                {
                    var warehouses = GetWarehousesFromDirectory(true);

                    importedWarehouseID = ALL_WAREHOUSES;
                    foreach (Data.Quality.BL_Get_WarehousesRow warehouse in warehouses)
                        importedWarehouseID = warehouse.Warehouse_ID;
                }

                for (int i = 0; i < bufferRows.Length; i++)
                {
                    var selectedRow = dgvItems.SelectedRows[0];
                    if (!selectedRow.IsNewRow)
                    {
                        var dbRow = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_Block_Document_ItemsRow;
                        EditTableRow(bufferRows[i], dbRow);
                        dgvItems.Rows[selectedRow.Index + 1].Selected = true;
                    }
                    else
                    {
                        PasteDataFromClipboardToEmptyRows(bufferRows, i);
                        break;
                    }
                }

                dgvItems.Refresh();
            }
        }

        /// <summary>
        /// Редактирование строки товаров с помощью данных, полученных из буфера
        /// </summary>
        /// <param name="pData">Данные, полученные из буфера</param>
        /// <param name="pRowForEdit">Строка товара, которую надо отредактировать</param>
        /// <returns>True, если в результате редактирования получилась полноценная строка, False если редактирование завершилось неудачей</returns>
        private bool EditTableRow(string pData, Data.Quality.BL_Block_Document_ItemsRow pRowForEdit)
        {
            string[] data = Regex.Split(pData, "\t");
            if (data != null && data.Length > 0)
            {
                int itemId;
                if (!(Int32.TryParse(data[0], out itemId) && itemId > 0))
                    return false;

                // код товара
                pRowForEdit.Item_ID = itemId;

                // серия
                if (data.Length > 1 && !String.IsNullOrEmpty(data[1]) && data[1] != ALL_VENDOR_LOTS)
                    pRowForEdit.VendorLot = data[1];

                // партия
                if (data.Length > 2 && !String.IsNullOrEmpty(data[2]) && data[2] != ALL_BATCH_IDS)
                    pRowForEdit.BatchID = data[2];

                if (actionType == BlockActionType.CreateBlock)
                {
                    pRowForEdit.HoldTypeID = importedHoldTypeID;
                    pRowForEdit.Warehouse_ID = importedWarehouseID;
                }

                if (actionType == BlockActionType.FinishBlock)
                {
                    pRowForEdit.Warehouse_ID = importedWarehouseID;

                    // код блокировки
                    if (data.Length > 3 && !String.IsNullOrEmpty(data[2]))
                    {
                        pRowForEdit.HoldTypeID = data[3];

                        // адаптация документа блокировки
                        if (actionType == BlockActionType.FinishBlock)
                        {
                            var bw = new BackgroundWorker();
                            bw.DoWork += (s, e) =>
                            {
                                try
                                {
                                    e.Result = BlockDocumentEditForm.GetDocs(
                                        sessionID,
                                        pRowForEdit.Item_ID,
                                        pRowForEdit.VendorLot,
                                        pRowForEdit.BatchID,
                                        pRowForEdit.Warehouse_ID == ALL_WAREHOUSES ? (string)null : pRowForEdit.Warehouse_ID,
                                        pRowForEdit.HoldTypeID,
                                        pRowForEdit.IsDateFromNull() ? (DateTime?)null : pRowForEdit.DateFrom,
                                        pRowForEdit.IsDateToNull() ? (DateTime?)null : pRowForEdit.DateTo);
                                }
                                catch (Exception ex)
                                {
                                    e.Result = ex;
                                }
                            };
                            bw.RunWorkerCompleted += (s, e) =>
                            {
                                if (e.Result is Exception)
                                    Logger.ShowErrorMessageBox("Возникла ошибка во время импорта блокировок: ", e.Result as Exception);
                                else
                                {
                                    var docs = e.Result as Data.Quality.BL_Get_DocsDataTable;
                                    if (docs != null && docs.Rows.Count == 1)
                                    {
                                        var doc = docs[0];
                                        pRowForEdit.Doc_ID = doc.Doc_ID.ToString();
                                        pRowForEdit.parent_hold_id = doc.hold_id.ToString();
                                    }
                                }

                                waitProgressForm.CloseForce();
                            };
                            waitProgressForm.ActionText = "Выполняется импорт блокировок..";
                            bw.RunWorkerAsync();
                            waitProgressForm.ShowDialog();
                        }
                    }
                }

                dgvItems.EndEdit();
                CheckRow(dgvItems.CurrentRow);
            }

            return true;    // Редактирование всех данных прошло успешно
        }

        /// <summary>
        /// Вставка данных из буфера обмена в таблицу товаров, если выделена новая строка таблицы
        /// (вставка данных с добавлением новых строк)
        /// </summary>
        /// <param name="pBuffer">Данные из буфера обмена</param>
        /// <param name="pStartIndex">Индекс, с которого следует считывать данные 
        /// (возможно, некоторая часть данных из буфера уже была вставлена)</param>
        private void PasteDataFromClipboardToEmptyRows(string[] pBuffer, int pStartIndex)
        {
            for (int i = pStartIndex; i < pBuffer.Length; i++)
            {
                bsblBlockDocumentItems.MoveLast();
                var tableRowView = bsblBlockDocumentItems.Current as DataRowView;
                if (tableRowView == null || !tableRowView.IsNew)
                    tableRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                var tableRow = tableRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                if (EditTableRow(pBuffer[i], tableRow))
                    (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                else
                    (bsblBlockDocumentItems.Current as DataRowView).CancelEdit();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ БЛОКИРОВКИ

        /// <summary>
        /// True если в таблице есть "красные строки" - строки с ошибками, False если строки в таблице заполнены правильно
        /// </summary>
        private bool HasRedRows
        {
            get
            {
                foreach (Data.Quality.BL_Block_Document_ItemsRow dbRow in quality.BL_Block_Document_Items)
                    if (!dbRow.IsResultNull() && !String.IsNullOrEmpty(dbRow.Result))
                        return true;    // Нашли строку с ошибкой!

                return false;   // Все строки заполнены правильно
            }
        }

        /// <summary>
        /// Сохранение блокировки в БД
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData() && CreateBlock())
            {
                MessageBox.Show(SuccessMessage, "Документ блокировки", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Сообщение, отображаемое при успешном выполнении операции, для которой было запущено окно
        /// </summary>
        private string SuccessMessage
        {
            get
            {
                switch (actionType)
                {
                    case BlockActionType.CreateBlock:
                        return "Документ блокировки успешно создан";
                    case BlockActionType.CreateException:
                        return "Исключение успешно создано";
                    case BlockActionType.FinishBlock:
                        return "Блокировки успешно сняты";
                    case BlockActionType.RecallNotification:
                        return "Уведомление об отзыве успешно создано";
                    default:
                        return String.Empty;
                }
            }
        }

        /// <summary>
        /// Проверка, правильно ли заданы все данные на форме
        /// </summary>
        /// <returns>True если данные заданы правильно, False в противном случае</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;

            if (dgvItems.Rows.Count == 0 || (dgvItems.Rows.Count == 1 && dgvItems.Rows[0].IsNewRow))
                msg = "Нужно выбрать товары, на которые будет установлена блокировка!";
            else if (HasRedRows)
                msg = "В таблице есть строки, заполненные неправильно (выделены красным цветом). " +
                    "Исправьте ошибки (колонка ПРОВЕРКА) либо удалите красные строки из документа." +
                    " Документ с красными строками не может быть создан!";

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Создание блокировки
        /// </summary>
        /// <returns>True если удалось сохранить блокировку, False если во время сохранения произошла ошибка</returns>
        private bool CreateBlock()
        {
            try
            {
                var tranOptions = new System.Transactions.TransactionOptions();
                tranOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;

                using (var scope = new TransactionScope(System.Transactions.TransactionScopeOption.Required, tranOptions))
                {
                    using (var adapter = new BL_Get_HoldsTableAdapter())
                    {
                        adapter.SetTimeout(600);
                        int docID = Convert.ToInt32(adapter.CreateBlockDocument(sessionID, tbxOuterDocNumber.Text,
                            dtpOuterDocDate.Value, tbxDescription.Text, Convert.ToInt32(cmbDocSource.SelectedValue),
                            Convert.ToInt32(cmbOrganizations.SelectedValue), ModeParam, tbxMsgNumber.Text, dtpMsgDate.Value));
                        adapter.AddDocsDetail(sessionID, docID, CreateXmlParam());
                    }

                    scope.Complete();
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время создания документа блокировки: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Параметр, который передается в процедуру сохранения документа и обозначает тип выполняемого действия
        /// (действия, для которого было запущено окно создания блокировки)
        /// </summary>
        private string ModeParam
        {
            get
            {
                switch (actionType)
                {
                    case BlockActionType.CreateBlock:
                        return "BL";
                    case BlockActionType.CreateException:
                        return "EX";
                    case BlockActionType.FinishBlock:
                        return "UB";
                    case BlockActionType.RecallNotification:
                        return "UO";
                    default:
                        return String.Empty;
                }
            }
        }

        /// <summary>
        /// Создание XML-параметра с товарами, добавляемыми в процедуру, удаляя по ходу дела дубли
        /// </summary>
        /// <returns>XML-структура с товарами</returns>
        private string CreateXmlParam()
        {
            TruncateDates();
            var doc = new XmlDocument();
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));
            foreach (Data.Quality.BL_Block_Document_ItemsRow dbRow in quality.BL_Block_Document_Items)
            {
                if (IsDuble(dbRow))
                    continue;

                var row = (XmlElement)root.AppendChild(doc.CreateElement("Row"));
                if (!dbRow.IsItem_IDNull() && !dbRow.IsNewItem)
                    row.SetAttribute("item_id", dbRow.Item_ID.ToString());
                if (!String.IsNullOrEmpty(dbRow.VendorLot) && dbRow.VendorLot != ALL_VENDOR_LOTS)
                    row.SetAttribute("vendor_lot", dbRow.VendorLot.Trim());
                if (!String.IsNullOrEmpty(dbRow.BatchID) && dbRow.BatchID != ALL_BATCH_IDS)
                    row.SetAttribute("lot_number", dbRow.BatchID.Trim());
                if (!String.IsNullOrEmpty(dbRow.Warehouse_ID) && dbRow.Warehouse_ID != ALL_WAREHOUSES)
                    row.SetAttribute("warehouse_id", dbRow.Warehouse_ID);
                row.SetAttribute("hold_type_id", dbRow.HoldTypeID);
                row.SetAttribute("date_from", dbRow.DateFrom.ToString("yyyy-MM-dd hh:mm:ss"));
                if (!dbRow.IsDateToNull())
                    row.SetAttribute("date_to", dbRow.DateTo.ToString("yyyy-MM-dd hh:mm:ss"));
                if (dbRow.IsNewItem && !dbRow.IsItem_NameNull() && !String.IsNullOrEmpty(dbRow.Item_Name))
                    row.SetAttribute("item", dbRow.Item_Name);
                if (dbRow.IsNewItem && !dbRow.IsManufacturer_IDNull() && !String.IsNullOrEmpty(dbRow.Manufacturer_ID))
                    row.SetAttribute("manufacturer_id", dbRow.Manufacturer_ID);
                if (dbRow.IsNewItem && !dbRow.IsManufacturerNull() && !String.IsNullOrEmpty(dbRow.Manufacturer))
                    row.SetAttribute("manufacturer", dbRow.Manufacturer);

                if (actionType == BlockActionType.CreateException || actionType == BlockActionType.FinishBlock)
                    row.SetAttribute("parent_hold_id", dbRow.parent_hold_id);

                if (!dbRow.IsExpiration_DateNull())
                    row.SetAttribute("Expiration_Date", dbRow.Expiration_Date.ToString("yyyy-MM-dd hh:mm:ss"));
            }

            return root.InnerXml;
        }

        /// <summary>
        /// "Обрезает" даты таким образом, чтобы оставались только даты без времени
        /// </summary>
        private void TruncateDates()
        {
            foreach (Data.Quality.BL_Block_Document_ItemsRow row in quality.BL_Block_Document_Items)
            {
                if (!row.IsDateFromNull())
                    row.DateFrom = row.DateFrom.Date;
                if (!row.IsDateToNull())
                    row.DateTo = row.DateTo.Date;
            }
        }

        /// <summary>
        /// Проверка, является ли данная строка дубликатом какой-либо из ранее встречавшихся строк в 
        /// таблице строк документа блокировки
        /// </summary>
        /// <param name="pRow">Проверяемая строка</param>
        /// <returns>True если строка является дубликатом, False если не является</returns>
        private bool IsDuble(Data.Quality.BL_Block_Document_ItemsRow pRow)
        {
            if (quality.BL_Block_Document_Items.Rows.IndexOf(pRow) < 1)
                return false;

            for (int i = quality.BL_Block_Document_Items.Rows.IndexOf(pRow) - 1; i >= 0; i--)
                for (int j = 0; j < pRow.ItemArray.Length; j++)
                    if (pRow.ItemArray[j].ToString() != quality.BL_Block_Document_Items[i].ItemArray[j].ToString())
                        return false;

            return true;
        }

        /// <summary>
        /// Выход из окна без сохранения документа
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        #endregion

        private void sbFindPurchaseOrderItems_Click(object sender, EventArgs e)
        {
            var dlgFindPurchaseOrder = new FindPurchaseOrderForm() { UserID = sessionID, ActionType = this.actionType };
            if (dlgFindPurchaseOrder.ShowDialog() == DialogResult.OK)
            {
                var warehouseID = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.WarehouseID;
                var orderID = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.OrderID;
                var orderType = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.OrderType;
                var blockTypeID = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.BlockTypeID;
                var dateFrom = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.DateFrom;
                var dateTo = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.DateTo;
                var isNewVendorLot = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.IsNewVendorLot;
                var isNewItem = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.IsNewItem;
                var blockAllWarehouses = dlgFindPurchaseOrder.PurchaseOrderItemsBlockParameters.BlockAllWarehouses;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, ea) =>
                {
                    try
                    {
                        using (var adapter = new Data.QualityTableAdapters.BL_Get_Purchase_Order_Items_Block_TemplateTableAdapter())
                        {
                            adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                            ea.Result = adapter.GetData(
                                warehouseID,
                                orderID,
                                blockTypeID,
                                dateFrom,
                                dateTo,
                                isNewVendorLot,
                                isNewItem,
                                blockAllWarehouses,
                                this.ModeParam,
                                orderType);
                        }
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, ea) =>
                {
                    if (ea.Result is Exception)
                        MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        try
                        {
                            var documentItems = ea.Result as Data.Quality.BL_Get_Purchase_Order_Items_Block_TemplateDataTable;
                            var currentRowIndex = dgvItems.Rows.Count - 1;
                            //Data.Quality.BL_Block_Document_ItemsRow itemRow;
                            for (int i = 0; i < documentItems.Count; i++)
                            {
                                //if (i == 0)
                                //{
                                //    var itemRowView = bsblBlockDocumentItems.Current as DataRowView;
                                //    if (itemRowView == null)
                                //        itemRowView = bsblBlockDocumentItems.AddNew() as DataRowView;
                                //    itemRow = itemRowView.Row as Data.Quality.BL_Block_Document_ItemsRow;
                                //    (bsblBlockDocumentItems.Current as DataRowView).EndEdit();
                                //}
                                //else
                                //{
                                //    itemRow = quality.BL_Block_Document_Items.NewBL_Block_Document_ItemsRow();
                                //    quality.BL_Block_Document_Items.Rows.InsertAt(itemRow, currentRowIndex + i);
                                //}

                                //itemRow.ItemArray = documentItems[i].ItemArray;

                                //itemRow.VendorLot = documentItems[i].IsVendorLotNull() ? ALL_VENDOR_LOTS : documentItems[i].VendorLot;
                                //itemRow.BatchID = documentItems[i].IsBatchIDNull() ? ALL_BATCH_IDS : documentItems[i].BatchID;
                                //itemRow.Warehouse_ID = documentItems[i].IsWarehouse_IDNull() ? ALL_WAREHOUSES : documentItems[i].Warehouse_ID;

                                //CheckRow(dgvItems.Rows[currentRowIndex + i]);

                                var newItem = quality.BL_Block_Document_Items.NewBL_Block_Document_ItemsRow();
                                newItem.ItemArray = documentItems[i].ItemArray;

                                newItem.VendorLot = documentItems[i].IsVendorLotNull() ? ALL_VENDOR_LOTS : documentItems[i].VendorLot;
                                newItem.BatchID = documentItems[i].IsBatchIDNull() ? ALL_BATCH_IDS : documentItems[i].BatchID;
                                newItem.Warehouse_ID = documentItems[i].IsWarehouse_IDNull() ? ALL_WAREHOUSES : documentItems[i].Warehouse_ID;

                                quality.BL_Block_Document_Items.Rows.InsertAt(newItem, currentRowIndex + i);

                                CheckRow(dgvItems.Rows[currentRowIndex + i]);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    waitProgressForm.CloseForce();
                };

                var actionText = actionType == BlockActionType.CreateBlock 
                                    ? "Выполняется поиск товаров в заказе на закупку.." 
                                    : actionType == BlockActionType.FinishBlock 
                                        ? "Выполняется поиск заблокированных товаров в заказе на закупку.." 
                                        : string.Empty;
                
                waitProgressForm.ActionText = actionText;
                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
        }
    }

    /// <summary>
    /// Перечисление колонок, по которым могут копироваться строки.
    /// Это нужно, чтобы при размножении строк, к примеру по серии или партии сохранялись значения
    /// той строки, в которой был вызван справочник с множественным выбором
    /// </summary>
    enum ItemsRowCopyColumns
    {
        /// <summary>
        /// Вставка в таблицу сразу нескольких разных товаров
        /// </summary>
        Items,

        /// <summary>
        /// Вставка в таблицу сразу нескольких серий одного товара
        /// </summary>
        VendorLots,

        /// <summary>
        /// Вставка в таблицу сразу нескольких партий одного товара
        /// </summary>
        BatchIDs,

        /// <summary>
        /// Размножение одной строки по складам
        /// </summary>
        Warehouses
    }

    /// <summary>
    /// Режимы запуска окна создания документа блокировки
    /// </summary>
    public enum BlockActionType
    {
        /// <summary>
        /// Создание блокировки
        /// </summary>
        CreateBlock,

        /// <summary>
        /// Установка исключения
        /// </summary>
        CreateException,

        /// <summary>
        /// Снятие блокировки
        /// </summary>
        FinishBlock,

        /// <summary>
        /// Уведомление об отзыве
        /// </summary>
        RecallNotification
    }
}
