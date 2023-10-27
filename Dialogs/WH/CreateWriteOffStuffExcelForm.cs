using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using WMSOffice.Data.WHTableAdapters;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Форма массовой вставки товаров импортом из Excel
    /// </summary>
    public partial class CreateWriteOffStuffExcelForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Склад, для которого импортируются товары
        /// </summary>
        private readonly string whID;

        /// <summary>
        /// Введенные пользователем товары, которые нужно будет вставить в акт списания
        /// </summary>
        public List<Data.WH.WF_ImportFromExcelRow> Data
        { 
            get 
            {
                var result = new List<Data.WH.WF_ImportFromExcelRow>();
                foreach (Data.WH.WF_ImportFromExcelRow row in wH.WF_ImportFromExcel)
                    if (row.Check)
                        result.Add(row);
                return result; 
            } 
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public CreateWriteOffStuffExcelForm(long pSessionID, string pWhId)
        {
            InitializeComponent();
            sessionID = pSessionID;
            whID = pWhId;
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
                        var dbRow = (selectedRow.DataBoundItem as DataRowView).Row as Data.WH.WF_ImportFromExcelRow;
                        EditTableRow(bufferRows[i], dbRow);
                        if (!CollapseIdenticalItems(dbRow))
                            dgvItems.Rows[selectedRow.Index + 1].Selected = true;
                    }
                    else
                    {
                        PasteDataFromClipboardToEmptyRows(bufferRows, i);
                        break;
                    }
                }
                dgvItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        /// <summary>
        /// Редактирование строки товаров с помощью данных, полученных из буфера
        /// </summary>
        /// <param name="pData">Данные, полученные из буфера</param>
        /// <param name="pRowForEdit">Строка товара, которую надо отредактировать</param>
        /// <returns>True, если в результате редактирования получилась полноценная строка, False если редактирование завершилось неудачей</returns>
        private bool EditTableRow(string pData, Data.WH.WF_ImportFromExcelRow pRowForEdit)
        {
            string[] data = Regex.Split(pData, "\t");
            if (data.Length < 5)
                return false;
            pRowForEdit.WH_ID = data[0];
            pRowForEdit.Location = data[1];
            int itemId;
            if (!(Int32.TryParse(data[2], out itemId) && itemId > 0))
                return false;
            pRowForEdit.ItemId = itemId;
            pRowForEdit.BatchID = data[3];
            int quantity;
            if (!(Int32.TryParse(data[4], out quantity) && quantity > 0))
                return false;
            pRowForEdit.Quantity = quantity;
            CheckRow(pRowForEdit);

            return true;    // Редактирование всех данных прошло успешно
        }

        /// <summary>
        /// Проверка товара на соответствие (места, количества и т.д.)
        /// </summary>
        /// <param name="pRowForEdit">Строка товара, который проверяется</param>
        private void CheckRow(Data.WH.WF_ImportFromExcelRow pRowForEdit)
        {
            var checkRow = GetItemNameFromDb(pRowForEdit.WH_ID, pRowForEdit.Location, pRowForEdit.ItemId,
                pRowForEdit.BatchID, pRowForEdit.Quantity);
            pRowForEdit.Item_Name = checkRow.ItemName;
            pRowForEdit.Check = checkRow.Check;
            dgvItems.Refresh();
        }

        /// <summary>
        /// Проверка, находится ли заданный товар заданной партии в заданном количестве на заданной полке заданного склада
        /// </summary>
        /// <param name="pWhID">Идентификатор заданного склада</param>
        /// <param name="pLocationID">Заданное место</param>
        /// <param name="pItemId">Идентификатор заданного товара</param>
        /// <param name="pBatchID">Заданная партия</param>
        /// <param name="pQuantity">Заданное количество</param>
        /// <returns>Строка с данными, по которым видно, нашли товар или нет</returns>
        private Data.WH.WF_Check_ExcelRowRow GetItemNameFromDb(string pWhID, string pLocationID, int pItemId, string pBatchID, int pQuantity)
        {
            var errorRow = wH.WF_Check_ExcelRow.NewRow() as Data.WH.WF_Check_ExcelRowRow;
            errorRow.Check = false;

            try
            {
                if (pWhID.Trim().ToUpper() != whID.Trim().ToUpper())
                    errorRow.ItemName = String.Format("В акте списания указан склад {0}. Нельзя добавлять в акт списания товары из склада {1}",
                        whID.Trim(), pWhID.Trim());
                else
                    using (var adapter = new WF_Check_ExcelRowTableAdapter())
                    {
                        var table = adapter.GetData(pWhID, pLocationID, pItemId, pBatchID, pQuantity);
                        if (table == null || table.Count == 0)
                            errorRow.ItemName = "Не удалось получить данные о товаре!";
                        else
                            errorRow = table[0];
                    }
            }
            catch
            {
                errorRow.ItemName = "Ошибка во время работы процедуры проверки!";
            }

            return errorRow;
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
                bsWfImportFromExcel.MoveLast();
                var tableRowView = bsWfImportFromExcel.Current as DataRowView;
                if (tableRowView == null || !tableRowView.IsNew)
                    tableRowView = bsWfImportFromExcel.AddNew() as DataRowView;
                var tableRow = tableRowView.Row as Data.WH.WF_ImportFromExcelRow;
                if (EditTableRow(pBuffer[i], tableRow))
                {
                    (bsWfImportFromExcel.Current as DataRowView).EndEdit();
                    CollapseIdenticalItems(tableRow);
                }
                else
                    (bsWfImportFromExcel.Current as DataRowView).CancelEdit();
            }
        }

        /// <summary>
        /// Проверяет таблицу, и если есть товары, аналогичные к тому который находится в pDataRow, то схлопывает их количества
        /// </summary>
        /// <param name="pDataRow">Строка, которую мы удалим если найдется такой же товар в таблице</param>
        /// <returns>True если строка таки была удалена в связи с наличием такой же, False если строка прошла проверку на идентичность</returns>
        private bool CollapseIdenticalItems(Data.WH.WF_ImportFromExcelRow pDataRow)
        {
            if (wH.WF_ImportFromExcel.Count < 2)
                return false;

            foreach (Data.WH.WF_ImportFromExcelRow row in wH.WF_ImportFromExcel)
                if (pDataRow.WH_ID == row.WH_ID && pDataRow.Location == row.Location &&
                    pDataRow.ItemId == row.ItemId && pDataRow.BatchID == row.BatchID && row != pDataRow)
                {
                    row.Quantity += pDataRow.Quantity;
                    CheckRow(row);
                    pDataRow.Delete();
                    wH.WF_ImportFromExcel.AcceptChanges();
                    return true;
                }

            return false;
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ ДАННЫХ В ТАБЛИЦЕ ВРУЧНУЮ

        /// <summary>
        /// Скрываем отображение ошибки при неверном форматировании данных
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
            int quantity;
            var gridRow = dgvItems.Rows[e.RowIndex];
            if (gridRow.Cells["clWhId"].Value == null || gridRow.Cells["clWhId"].Value == DBNull.Value ||
                String.IsNullOrEmpty(gridRow.Cells["clWhId"].Value.ToString()))
            {
                MessageBox.Show("Должен быть обязательно задан склад!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            else if (gridRow.Cells["clLocation"].Value == null || gridRow.Cells["clLocation"].Value == DBNull.Value ||
                String.IsNullOrEmpty(gridRow.Cells["clLocation"].Value.ToString()))
            {
                MessageBox.Show("Должно быть обязательно задано место!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (gridRow.Cells["clItemID"].Value == null || gridRow.Cells["clItemID"].Value == DBNull.Value ||
                !Int32.TryParse(gridRow.Cells["clItemID"].Value.ToString(), out itemId) || itemId < 0)
            {
                MessageBox.Show("Код товара должен быть задан, и быть неотрицательным целым числом!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            else if (gridRow.Cells["clBatchID"].Value == null || gridRow.Cells["clBatchID"].Value == DBNull.Value ||
                String.IsNullOrEmpty(gridRow.Cells["clBatchID"].Value.ToString()))
            {
                MessageBox.Show("Должна быть обязательно задана партия!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
            if (gridRow.Cells["clQuantity"].Value == null || gridRow.Cells["clQuantity"].Value == DBNull.Value ||
                !Int32.TryParse(gridRow.Cells["clQuantity"].Value.ToString(), out quantity) || quantity < 0)
            {
                MessageBox.Show("Количество товара должно быть задано неотрицательным целым числом!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Проверка на товара на соответствие данным в БД после его редактирования
        /// </summary>
        private void dgvItems_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;
                var dbRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.WF_ImportFromExcelRow;
                if (!CollapseIdenticalItems(dbRow))
                    CheckRow(dbRow);
            }
            catch { }
        }

        #endregion

        #region РАСКРАШИВАНИЕ СТРОК

        /// <summary>
        /// Раскрашивание строк в зависимости от того, есть ли несоответствия
        /// </summary>
        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var gridRow = (sender as DataGridView).Rows[e.RowIndex];
            if (!gridRow.IsNewRow)
            {
                var dbRow = (gridRow.DataBoundItem as DataRowView).Row as Data.WH.WF_ImportFromExcelRow;
                e.CellStyle.BackColor = (dbRow.IsCheckNull() || dbRow.Check) ? Color.White : Color.Red;
            }
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ И ВЫХОД

        /// <summary>
        /// True если есть красные строки (нераспознанные товары), False если все строки распознаны
        /// </summary>
        private bool RedRowExists
        {
            get
            {
                foreach (Data.WH.WF_ImportFromExcelRow row in wH.WF_Check_ExcelRow)
                    if (!row.Check)
                        return true;

                return false;
            }
        }

        /// <summary>
        /// Сохранение данных и выход
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (RedRowExists)
                if (MessageBox.Show("В таблице есть нераспознанные строки (закрашены красным цветом)." +
                    "При вставке товаров в акт списания они вставлены не будут. Вы точно хотите завершить ввод товаров?", "Импорт товаров",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

            DialogResult = DialogResult.OK;
            Close();
        }

        #endregion
    }
}
