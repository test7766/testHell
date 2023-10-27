using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using WMSOffice.Data.WHTableAdapters;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно для массовой вставки актов скидок из буфера
    /// </summary>
    public partial class ActDiscountManyActsInsertForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ActDiscountManyActsInsertForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        #endregion

        #region ВСТАВКА ИЗ БУФЕРА

        /// <summary>
        /// Вставка данных в таблицу актов скидок из буфера обмена
        /// </summary>
        private void PasteDataFromClipboard()
        {
            var dObject = Clipboard.GetDataObject() as DataObject;
            if (dObject.GetDataPresent(DataFormats.Text))
            {
                string[] bufferRows = Regex.Split(dObject.GetData(DataFormats.Text).ToString().TrimEnd("\r\n".ToCharArray()), "\r\n");
                if (bufferRows == null || bufferRows.Length == 0)
                    return;

                for (int i = 0; i < bufferRows.Length; i++)
                {
                    var selectedRow = dgvActs.SelectedRows[0];
                    if (!selectedRow.IsNewRow)
                    {
                        EditTableRow(bufferRows[i],
                            (selectedRow.DataBoundItem as DataRowView).Row as WMSOffice.Data.WH.ManyActInsertRow);
                        dgvActs.Rows[selectedRow.Index + 1].Selected = true;
                    }
                    else
                    {
                        PasteDataFromClipboardToEmptyRows(bufferRows, i);
                        break;
                    }
                }
                dgvActs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        /// <summary>
        /// Редактирование строки акта скидок с помощью данных, полученных из буфера
        /// </summary>
        /// <param name="pData">Данные, полученные из буфера</param>
        /// <param name="pRowForEdit">Строка с актами скидок, которую надо отредактировать</param>
        /// <returns>True, если в результате редактирования получилась полноценная строка, False если редактирование завершилось неудачей</returns>
        private bool EditTableRow(string pData, WMSOffice.Data.WH.ManyActInsertRow pRowForEdit)
        {
            if (pData.Length < 2)
                return false;
                    
            string[] data = Regex.Split(pData, "\t");
            int debtorID;
            double sum;
            if (!(Int32.TryParse(data[0], out debtorID) && Double.TryParse(data[1], out sum) && sum > 0))
                return false;
            pRowForEdit.DebtorID = debtorID;
            pRowForEdit.Sum = sum;

            DateTime docDate;
            if (data.Length > 2 && DateTime.TryParse(data[2], out docDate))
                pRowForEdit.DocDate = docDate;
            else
                pRowForEdit.DocDate = DateTime.Now;

            if (data.Length > 3 && !String.IsNullOrEmpty(data[3]))
                pRowForEdit.Type = data[3];
            else
                pRowForEdit.Type = "SPC";

            pRowForEdit.Filial = GetFilialByDebtorId(debtorID);

            return true;    // Редактирование всех данных прошло успешно
        }

        /// <summary>
        /// Получение названия филиала по идентификатору дебитора
        /// </summary>
        /// <param name="pDebtorID">Идентификатор дебитора</param>
        /// <returns>Название филиала, за которым закреплен дебитор</returns>
        private string GetFilialByDebtorId(int pDebtorID)
        {
            try
            {
                using (var adapter = new AS_Get_DebtorListTableAdapter())
                {
                    var table = adapter.GetData(pDebtorID);
                    return (table.Rows[0] as WMSOffice.Data.WH.AS_Get_DebtorListRow).Business_Unit;
                }
            }
            catch
            {
                return "Не удалось определить филиал!";
            }
        }

        /// <summary>
        /// Вставка данных из буфера обмена в таблицу актов, если выделена новая строка таблицы
        /// (вставка данных с добавлением новых строк)
        /// </summary>
        /// <param name="pBuffer">Данные из буфера обмена</param>
        /// <param name="pStartIndex">Индекс, с которого следует считывать данные 
        /// (возможно, некоторая часть данных из буфера уже была вставлена)</param>
        private void PasteDataFromClipboardToEmptyRows(string[] pBuffer, int pStartIndex)
        {
            for (int i = pStartIndex; i < pBuffer.Length; i++)
            {
                bsManyActInsert.MoveLast();
                var tableRowView = bsManyActInsert.Current as DataRowView;
                if (!tableRowView.IsNew)
                    tableRowView = bsManyActInsert.AddNew() as DataRowView;
                var tableRow = tableRowView.Row as WMSOffice.Data.WH.ManyActInsertRow;
                if (EditTableRow(pBuffer[i], tableRow))
                    (bsManyActInsert.Current as System.Data.DataRowView).EndEdit();
                else
                    (bsManyActInsert.Current as System.Data.DataRowView).CancelEdit();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ И СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Вывод ошибки при неверном редактировании таблицы
        /// </summary>
        private void dgvActs_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            ;
        }

        /// <summary>
        /// Проверка правильности заполнения таблицы с актами скидок
        /// </summary>
        private void dgvActs_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!dgvActs.IsCurrentRowDirty)
                return;

            int debtorId;
            double sum;
            DateTime docDate;
            var row = dgvActs.Rows[e.RowIndex];
            if (row.Cells["debtorId"].Value == null || row.Cells["debtorId"].Value == DBNull.Value ||
                !Int32.TryParse(row.Cells["debtorId"].Value.ToString(), out debtorId))
            {
                MessageBox.Show("Код дебитора должен быть задан, и быть неотрицательным целым числом!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (row.Cells["sum"].Value == null || row.Cells["sum"].Value == DBNull.Value ||
                !Double.TryParse(row.Cells["sum"].Value.ToString(), out sum))
            {
                MessageBox.Show("Сумма акта скидки должна быть задана, и быть неотрицательной!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
            else if (row.Cells["docDate"].Value == null || row.Cells["docDate"].Value == DBNull.Value ||
                !DateTime.TryParse(row.Cells["docDate"].Value.ToString(), out docDate))
            {
                MessageBox.Show("Должна быть задана дата акта скидки!", "Проверка данных",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Массовая вставка данных в БД
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wH.ManyActInsert.Rows.Count; i++)
                try
                {
                    var row = wH.ManyActInsert.Rows[i] as WMSOffice.Data.WH.ManyActInsertRow;
                    using (var adapter = new AS_Get_DocsTableAdapter())
                        adapter.AddAct(sessionID, row.DocDate, row.DebtorID, Convert.ToDecimal(row.Sum), row.Type, String.Empty);
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Не удалось добавить акт скидки: " + Environment.NewLine + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            MessageBox.Show("Массовая вставка актов скидок окончена", "Вставка актов скидок",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        /// <summary>
        /// Вставка данных из буфера
        /// </summary>
        private void miPaste_Click(object sender, EventArgs e)
        {
            PasteDataFromClipboard();
        }

        #endregion
    }
}
