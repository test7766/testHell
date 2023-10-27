using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Data.QualityTableAdapters;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ChooseItemsControl : UserControl
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// True если контрол был проинициализирован, False в противном случае.
        /// С непроинициализированным контролом работать нельзя
        /// </summary>
        public bool IsInitialized { get; private set; }

        /// <summary>
        /// Введенные пользователем товары, которые прошли проверку
        /// </summary>
        public List<Data.Quality.BL_BlockItemsRow> Items
        {
            get
            {
                var result = new List<Data.Quality.BL_BlockItemsRow>();
                foreach (Data.Quality.BL_BlockItemsRow row in quality.BL_BlockItems)
                    if (row.IsResultNull() || String.IsNullOrEmpty(row.Result))
                        result.Add(row);
                
                // Удаляем дубли
                for (int i = 0; i < result.Count; i++)
                    for (int j = i + 1; j < result.Count; j++)
                        if (AreRowsEquals(result[i], result[j]))
                        {
                            result.RemoveAt(j);
                            j--;
                        }


                return result;
            }
        }

        /// <summary>
        /// Проверка двух строк товаров на идентичность
        /// </summary>
        /// <param name="pRow1">Первая проверяемая строка</param>
        /// <param name="pRow2">Вторая проверяемая строка</param>
        /// <returns>True если строки одинаковые, False если разные</returns>
        private bool AreRowsEquals(Data.Quality.BL_BlockItemsRow pRow1, Data.Quality.BL_BlockItemsRow pRow2)
        {
            if (pRow1.ItemID != pRow2.ItemID)
                return false;   // Проверка по коду товара
            else if ((pRow1.IsVendorLotNull() && !pRow2.IsVendorLotNull()) ||
                (pRow2.IsVendorLotNull() && !pRow1.IsVendorLotNull()) ||
                (!pRow1.IsVendorLotNull() && !pRow2.IsVendorLotNull() && pRow1.VendorLot != pRow2.VendorLot))
                return false;   // Проверка по сериям
            else if ((pRow1.IsBatchIDNull() && !pRow2.IsBatchIDNull()) ||
                (pRow2.IsBatchIDNull() && !pRow1.IsBatchIDNull()) ||
                (!pRow1.IsBatchIDNull() && !pRow2.IsBatchIDNull() && pRow1.BatchID != pRow2.BatchID))
                return false;   // Проверка по партиям

            return true;    // Пройдены все проверки
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public ChooseItemsControl()
        {
            InitializeComponent();
            InitializSearchTextBoxes();
        }

        /// <summary>
        /// Инициализация контрола (без нее контрол будет бесполезным)
        /// </summary>
        /// <param name="pSessionID">Идентификатор сессии пользователя</param>
        /// <param name="pExistedTable">Таблица со строками, которыми инициализируется форма 
        /// (это те товары/серии/партии, которые были заданы ранее)</param>
        public void InitControl(long pSessionID, Data.Quality.BL_BlockItemsDataTable pExistedTable)
        {
            if (IsInitialized)
                throw new InvalidOperationException("Контрол уже проинициализирован! Повторная инициализация запрещена!");
            else if (pSessionID <= 0)
                throw new ArgumentException("Сессия пользователя должна быть положительным целым числом!");
            else if (pExistedTable == null)
                throw new ArgumentException("Таблица с существующими параметрами равна NULL");

            sessionID = pSessionID;
            quality.BL_BlockItems.Merge(pExistedTable);
            IsInitialized = true;
        }

        #endregion

        #region ВСТАВКА ИЗ БУФЕРА

        /// <summary>
        /// Вставка данных из Excel по при выборе соответствующего пункта меню
        /// </summary>
        private void miPaste_Click(object sender, EventArgs e)
        {
            PasteDataFromClipboard();
        }

        /// <summary>
        /// Вставка данных в таблицу товаров из буфера обмена
        /// </summary>
        private void PasteDataFromClipboard()
        {
            if (dgvItems.SelectedRows.Count == 0)
                dgvItems.Rows[0].Selected = true;

            var dObject = Clipboard.GetDataObject() as DataObject;
            if (dObject.GetDataPresent(DataFormats.Text))
            {
                string[] bufferRows = Regex.Split(dObject.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                if (bufferRows == null || bufferRows.Length == 0)
                    return;

                for (int i = 0; i < bufferRows.Length; i++)
                {
                    var selectedRow = dgvItems.SelectedRows[0];
                    if (!selectedRow.IsNewRow)
                    {
                        var dbRow = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_BlockItemsRow;
                        EditTableRow(bufferRows[i], dbRow);
                        dgvItems.Rows[selectedRow.Index + 1].Selected = true;
                    }
                    else
                    {
                        PasteDataFromClipboardToEmptyRows(bufferRows, i);
                        break;
                    }
                }
                dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvItems.Refresh();
            }
        }

        /// <summary>
        /// Редактирование строки товаров с помощью данных, полученных из буфера
        /// </summary>
        /// <param name="pData">Данные, полученные из буфера</param>
        /// <param name="pRowForEdit">Строка товара, которую надо отредактировать</param>
        /// <returns>True, если в результате редактирования получилась полноценная строка, False если редактирование завершилось неудачей</returns>
        private bool EditTableRow(string pData, Data.Quality.BL_BlockItemsRow pRowForEdit)
        {
            string[] data = Regex.Split(pData, "\t");
            if (data != null && data.Length > 0)
            {
                int itemId;
                if (!(Int32.TryParse(data[0], out itemId) && itemId > 0))
                    return false;
                pRowForEdit.ItemID = itemId;

                if (data.Length > 1)
                    pRowForEdit.VendorLot = data[1];

                if (data.Length > 2)
                    pRowForEdit.BatchID = data[2];
                CheckRow(pRowForEdit);
            }

            return true;    // Редактирование всех данных прошло успешно
        }

        /// <summary>
        /// Проверка товара на соответствие (места, количества и т.д.)
        /// </summary>
        /// <param name="pRowForEdit">Строка товара, который проверяется</param>
        private void CheckRow(Data.Quality.BL_BlockItemsRow pRowForEdit)
        {
            try
            {
                using (var adapter = new BL_Check_ItemTableAdapter())
                {
                    var resultTable = adapter.GetData(pRowForEdit.ItemID,
                        (pRowForEdit.IsVendorLotNull() || String.IsNullOrEmpty(pRowForEdit.VendorLot)) ? null : pRowForEdit.VendorLot,
                        (pRowForEdit.IsBatchIDNull() || String.IsNullOrEmpty(pRowForEdit.BatchID)) ? null : pRowForEdit.BatchID);
                    if (resultTable == null || resultTable.Count == 0)
                        throw new ApplicationException("Процедура проверки не вернула данные!");
                    var row = resultTable[0];
                    pRowForEdit.Result = row.IsresultNull() ? null : row.result;
                    pRowForEdit.ItemName = (row.Isitem_nameNull() || !row.IsresultNull()) ? String.Empty : row.item_name;
                }
            }
            catch (Exception exc)
            {
                pRowForEdit.Result = "Ошибка при проверке: " + exc.Message;
            }
            dgvItems.Refresh();
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
                bsBlBlockItems.MoveLast();
                var tableRowView = bsBlBlockItems.Current as DataRowView;
                if (tableRowView == null || !tableRowView.IsNew)
                    tableRowView = bsBlBlockItems.AddNew() as DataRowView;
                var tableRow = tableRowView.Row as Data.Quality.BL_BlockItemsRow;
                if (EditTableRow(pBuffer[i], tableRow))
                    (bsBlBlockItems.Current as DataRowView).EndEdit();
                else
                    (bsBlBlockItems.Current as DataRowView).CancelEdit();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ ДАННЫХ ВРУЧНУЮ

        /// <summary>
        /// Не показываем сообщения об ошибке - вместо этого валидация
        /// </summary>
        private void dgvItems_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }

        /// <summary>
        /// Проверка правильности заполнения таблицы товаров
        /// </summary>
        private void dgvItems_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvItems.IsCurrentRowDirty)
                return;

            int itemId;
            var gridRow = dgvItems.Rows[e.RowIndex];
            if (gridRow.Cells["clItemID"].Value == null || gridRow.Cells["clItemID"].Value == DBNull.Value ||
                !Int32.TryParse(gridRow.Cells["clItemID"].Value.ToString(), out itemId))
            {
                MessageBox.Show("Код товара должен быть задан, и быть целым числом!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Проверка, есть ли такой товар в БД
        /// </summary>
        private void dgvItems_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;
                var dbRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.BL_BlockItemsRow;
                CheckRow(dbRow);
            }
            catch { }
        }

        #endregion

        #region РАСКРАШИВАНИЕ СТРОК

        /// <summary>
        /// Раскрашивание строк в зависимости от того, есть ли нераспознанные идентификаторы товаров
        /// </summary>
        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var gridRow = (sender as DataGridView).Rows[e.RowIndex];
            if (!gridRow.IsNewRow)
            {
                var dbRow = (gridRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_BlockItemsRow;
                e.CellStyle.BackColor = (dbRow.IsResultNull() || String.IsNullOrEmpty(dbRow.Result)) ? Color.White : Color.Red;
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ В ТАБЛИЦУ ДАННЫХ ИЗ СПРАВОЧНИКА

        /// <summary>
        /// Инициализация выпадающих справочников товара, серии и партии
        /// </summary>
        private void InitializSearchTextBoxes()
        {
            stbItemID.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Items]";
            stbVendorLot.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Vendor_Lots]";
            stbBatchID.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Batch_Ids]";
            stbItemID.UserID = stbBatchID.UserID = stbVendorLot.UserID = sessionID;
            stbItemID.OnVerifyValue += stb_OnVerifyValue;
            stbVendorLot.OnVerifyValue += stb_OnVerifyValue;
            stbBatchID.OnVerifyValue += stb_OnVerifyValue;
        }

        /// <summary>
        /// Проверка введенного значения в фильтр
        /// </summary>
        private void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var stb = sender as SearchTextBox;
            stb.Value = e.Success ? e.Value : null;
            if (sender == stbItemID)
            {
                lblItemName.Text = e.Success ? e.Description : String.Empty;
                btnAdd.Enabled = !String.IsNullOrEmpty(stbItemID.Value);
                RefreshVendorLotFilterState();
                RefreshBatchIdFilterState();
                if (stbVendorLot.Enabled)
                    stbVendorLot.Focus();
            }
            else if (sender == stbVendorLot)
            {
                RefreshBatchIdFilterState();
                stbBatchID.Focus();
            }
            else if (sender == stbBatchID)
                btnAdd.Focus();
        }

        /// <summary>
        /// Обновление фильтра по серии в зависимости от выбранного значения в фильтре по товарам
        /// </summary>
        private void RefreshVendorLotFilterState()
        {
            stbVendorLot.ClearAdditionalParameters();
            stbVendorLot.Value = null;
            if (!String.IsNullOrEmpty(stbItemID.Value))
                stbVendorLot.ApplyAdditionalParameter(stbItemID.Value);
            stbVendorLot.Enabled = !String.IsNullOrEmpty(stbItemID.Value);
        }

        /// <summary>
        /// Обновление фильтра по партии в зависимости от выбранных значений в фильтрах по товару и серии
        /// </summary>
        private void RefreshBatchIdFilterState()
        {
            stbBatchID.ClearAdditionalParameters();
            stbBatchID.Value = null;
            if (!String.IsNullOrEmpty(stbItemID.Value))
                stbBatchID.ApplyAdditionalParameter(stbItemID.Value);

            if (!String.IsNullOrEmpty(stbVendorLot.Value))
                stbBatchID.ApplyAdditionalParameter(stbVendorLot.Value);

            stbBatchID.Enabled = !String.IsNullOrEmpty(stbItemID.Value);
        }

        /// <summary>
        /// Добавление товара, выбранного в справочниках
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            bsBlBlockItems.MoveLast();
            var tableRowView = bsBlBlockItems.Current as DataRowView;
            if (tableRowView == null || !tableRowView.IsNew)
                tableRowView = bsBlBlockItems.AddNew() as DataRowView;
            var tableRow = tableRowView.Row as Data.Quality.BL_BlockItemsRow;
            tableRow.ItemID = Convert.ToInt32(stbItemID.Value);
            tableRow.VendorLot = stbVendorLot.Value;
            tableRow.BatchID = stbBatchID.Value;
            (bsBlBlockItems.Current as DataRowView).EndEdit();
        }

        /// <summary>
        /// Добавление строки в таблицу редактируемых блокировок
        /// </summary>
        /// <param name="pItemId">Идентификатор товара в новой строке</param>
        /// <param name="pVendorLot">Серия в новой строке</param>
        /// <param name="pBatchID">Партия в новой строке</param>
        public void AddRow(int pItemId, string pVendorLot, string pBatchID)
        {
            try
            {
                var newRow = quality.BL_BlockItems.NewBL_BlockItemsRow();
                newRow.ItemID = pItemId;
                newRow.VendorLot = pVendorLot;
                newRow.BatchID = pBatchID;
                quality.BL_BlockItems.AddBL_BlockItemsRow(newRow);
                CheckRow(newRow);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при добавлении строки в таблицу товаров в блокировке: ", exc);
            }
        }

        #endregion
    }
}
