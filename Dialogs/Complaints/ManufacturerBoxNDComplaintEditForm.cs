using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls;
using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для создание претензии типа "Недостача в заводском ящике"
    /// </summary>
    public partial class ManufacturerBoxNDComplaintEditForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Название свойства таблицы с булевским значением выбора (к которому биндится CHECKBOX-колонка)
        /// </summary>
        private const string CHECKED_COL_NAME = "Checked";

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Тип накладной, по которой создаем претензию
        /// </summary>
        private string dcto;

        /// <summary>
        /// Номер накладной, по которой создаем претензию 
        /// </summary>
        private int doco;

        /// <summary>
        /// Отмеченные для выбора товары в таблице
        /// </summary>
        private List<Data.Complaints.CO_Search_ItemsRow> CheckedItems
        {
            get
            {
                var resultList = new List<Data.Complaints.CO_Search_ItemsRow>();
                foreach (Data.Complaints.CO_Search_ItemsRow row in complaints.CO_Search_Items)
                    if (row.Checked)
                        resultList.Add(row);

                return resultList;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ManufacturerBoxNDComplaintEditForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            CustomCheckHeader();
        }

        /// <summary>
        /// Настройка заголовка для CheckBox-колонки таблицы остатков тоже в виде CheckBox-а
        /// </summary>
        private void CustomCheckHeader()
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell(false);
            checkHeaderCell.OnCheckBoxClicked += checkHeaderCell_OnCheckBoxClicked;
            checkHeaderCell.Value = String.Empty;
            clChecked.HeaderCell = checkHeaderCell;
            //clChecked.ReadOnly = true;
        }

        /// <summary>
        /// Выбор/снятие флажка со всех строк при выборе флажка в заголовке колонки
        /// </summary>
        /// <param name="pState">True, если флажок в заголовке был выбран, False - если снят</param>
        public void checkHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
                ((row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow).Checked = pState;

            dgvInvoiceItems.RefreshEdit();
            bsСoSearchItems.ResetBindings(false);

            foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
                PaintRow(row);
        }

        /// <summary>
        /// Загрузка необходимых данных при загрузке окна
        /// </summary>
        private void ManufacturerBoxNDComplaintEditForm_Load(object sender, EventArgs e)
        {
            tbxInvoiceNumber.Focus();
        }

        /// <summary>
        /// Сохранение настроек при выходе из окна
        /// </summary>
        private void ManufacturerBoxNDComplaintEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvInvoiceItems);
        }

        #endregion

        #region ГОРЯЧИЕ КЛАВИШИ

        /// <summary>
        /// Управление окном с помощью горячих клавиш
        /// </summary>
        private void ManufacturerBoxNDComplaintEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                tbxFilter.Focus();
            else if (e.KeyCode == Keys.Enter && e.Control)
                btnOK_Click(btnOK, EventArgs.Empty);
            else if ((int)e.KeyCode == 107 && e.Control)    // Знак "+"
                checkHeaderCell_OnCheckBoxClicked(true);
            else if ((int)e.KeyCode == 109 && e.Control)    // Знак "-"
                checkHeaderCell_OnCheckBoxClicked(false);
        }

        /// <summary>
        /// Горячие клавиши на таблице товаров
        /// </summary>
        private void dgvInvoiceItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvInvoiceItems.SelectedRows.Count > 0)
                if ((int)e.KeyCode == 107)  // Знак "+"
                {
                    (dgvInvoiceItems.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = true;
                    PaintRow(dgvInvoiceItems.SelectedRows[0]);
                }
                else if ((int)e.KeyCode == 109) // Знак "-"
                {
                    (dgvInvoiceItems.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = false;
                    PaintRow(dgvInvoiceItems.SelectedRows[0]);
                }
        }

        #endregion

        #region ПОИСК НАКЛАДНОЙ

        /// <summary>
        /// Поиск накладной по заданным номеру и типу
        /// </summary>
        private void btnSearchInvoice_Click(object sender, EventArgs e)
        {
            if (CheckInvoiceRequisites())
            {
                var invoice = SearchInvoice();
                dcto = invoice == null ? null : tbxInvoiceType.Text;
                doco = invoice == null ? default(Int32) : Convert.ToInt32(tbxInvoiceNumber.Text);
                lblInvoiceReceiver.Text = invoice == null ? "Накладная не найдена..." : String.Format("Получатель: {0}", invoice.DebtorName);
                lblInvoiceReceiver.ForeColor = invoice == null ? Color.Red : lblInvoiceDate.ForeColor;
                lblInvoiceDate.Text = invoice == null ? String.Empty : String.Format("Дата накладной: {0}", invoice.InvoiceDate.ToShortDateString());
                if (invoice == null)
                    complaints.CO_Search_Items.Clear();
                else
                    StartRemainsLoading();
                lblNeedRefresh.Visible = invoice == null;
            }
        }

        /// <summary>
        /// Проверка, хватит ли заданных данных чтобы найти накладную
        /// </summary>
        /// <returns>True если номер и тип накладной заданы правильно, False в противном случае</returns>
        private bool CheckInvoiceRequisites()
        {
            string msg = String.Empty;

            if (String.IsNullOrEmpty(tbxInvoiceNumber.Text))
            {
                msg = "Введите номер накладной!";
                tbxInvoiceNumber.Focus();
            }
            else if (!Int32.TryParse(tbxInvoiceNumber.Text, out doco))
            {
                msg = "Номер накладной должен быть целым числом!";
                tbxInvoiceNumber.Focus();
            }
            else if (String.IsNullOrEmpty(tbxInvoiceNumber.Text))
            {
                msg = "Должен быть задан тип накладной!";
                tbxInvoiceType.Focus();
            }
            else if (tbxInvoiceType.Text.Length != 2)
            {
                msg = "Тип накладной должен содержать два символа!";
                tbxInvoiceType.Focus();
            }

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Поиск накладной", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Поиск накладной по номеру и типу
        /// </summary>
        /// <returns>Найденная накладная либо null, если накладная не была найдена</returns>
        private Data.Complaints.CO_Search_InvoiceIBRow SearchInvoice()
        {
            try
            {
                using (var adapter = new CO_Search_InvoiceIBTableAdapter())
                {
                    var table = adapter.GetData(sessionID, Convert.ToInt32(tbxInvoiceNumber.Text),
                        tbxInvoiceType.Text, Constants.KCOO);
                    if (table == null || table.Count == 0)
                        return null;
                    else
                        return table[0];
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время поиска накладной возникла ошибка: ", exc);
                return null;
            }
        }

        /// <summary>
        /// Индикация того, что введенные в текстовые поля значения еще не были использованы для поиска
        /// </summary>
        private void tbxInvoice_TextChanged(object sender, EventArgs e)
        {
            bool wasChanged = false;

            // Проверяем, соответствует ли значение, заданное в поле типа накладной значению уже найденной накладной
            if (String.IsNullOrEmpty(dcto))
            {
                if (!String.IsNullOrEmpty(tbxInvoiceType.Text))
                    wasChanged = true;
            }
            else if (dcto != tbxInvoiceType.Text)
                wasChanged = true;

            // Проверяем, соответствует ли значение, заданное в поле номера накладной значению уже найденной накладной
            if (doco == default(Int32))
            {
                if (!String.IsNullOrEmpty(tbxInvoiceNumber.Text))
                    wasChanged = true;
            }
            else
            {
                int tbxVal;
                bool res = Int32.TryParse(tbxInvoiceNumber.Text, out tbxVal);
                if (!res || tbxVal != doco)
                    wasChanged = true;
            }

            lblNeedRefresh.Visible = wasChanged;
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ТОВАРОВ В НАКЛАДНОЙ

        /// <summary>
        /// Запуск асинхронной загрузки товаров в накладной
        /// </summary>
        private void StartRemainsLoading()
        {
            lastWorker = new BackgroundWorker();
            lastWorker.DoWork += lastWorker_DoWork;
            lastWorker.RunWorkerCompleted += lastWorker_RunWorkerCompleted;
            if (dgvInvoiceItems.Rows.Count > 0)  // Исключаем сохранение настроек на пустой таблице
                Config.SaveDataGridViewSettings(Name, dgvInvoiceItems);
            dgvInvoiceItems.Enabled = false;
            pbWait.Visible = true;
            dgvInvoiceItems.DataSource = null;
            lastWorker.RunWorkerAsync(new InvoiceItemsSearchParameters
            {
                SessionID = sessionID,
                DocType = Constants.CO_DTFL_MANUFACTURERND,
                InvoiceNumber = doco,
                InvoiceType = dcto
            });
        }

        /// <summary>
        /// Асинхронная загрузка товаров в накладной
        /// </summary>
        private void lastWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as InvoiceItemsSearchParameters;
                using (var adapter = new CO_Search_ItemsTableAdapter())
                    adapter.Fill(complaints.CO_Search_Items, sc.SessionID, sc.DocType, 
                        sc.InvoiceType, sc.InvoiceNumber, sc.KCOO, null, null, null, null, null);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Загрузка товаров в накладной закончена
        /// </summary>
        private void lastWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender == lastWorker)
            {
                if (e.Result is Exception)
                    Logger.ShowErrorMessageBox("Во время загрузки товаров в накладной произошла ошибка!", e.Result as Exception);

                dgvInvoiceItems.DataSource = bsСoSearchItems;

                pbWait.Visible = false;
                dgvInvoiceItems.Enabled = true;
                DataGridViewHelper.AutoSetColumnWidths(dgvInvoiceItems);
                Config.LoadDataGridViewSettings(Name, dgvInvoiceItems);

                // Сбрасываем выделение позиций
                foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
                    row.Selected = false;
            }
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ТОВАРОВ В ТАБЛИЦЕ

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
        /// Обновление фильтров на таблице с товарами в накладной
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsСoSearchItems.Filter = String.Empty;
                else
                    bsСoSearchItems.Filter =
                        String.Format("Convert([Item_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%' OR [Vendor_Lot] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
            finally
            {
                foreach (DataGridViewRow row in dgvInvoiceItems.Rows)
                    PaintRow(row);
            }
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
                RefreshFilter();
        }

        #endregion

        #region ОКРАШИВАНИЕ ТОВАРОВ В ТАБЛИЦЕ

        /// <summary>
        /// Окрашивание строки, если поставили/убрали флажок
        /// </summary>
        private void dgvInvoiceItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == clChecked.Index)
            //    PaintRow(dgvInvoiceItems.Rows[e.RowIndex]);

            if (e.ColumnIndex == clChecked.Index)
            {
                bool ch = Convert.ToBoolean(dgvInvoiceItems.Rows[e.RowIndex].Cells[clChecked.Index].EditedFormattedValue);
                foreach (DataGridViewRow row in dgvInvoiceItems.SelectedRows)
                    ((row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow).Checked = ch;
            }
        }

        /// <summary>
        /// Окрашивание строки таблицы в зависимости от того, отмечена она флажком или нет
        /// </summary>
        /// <param name="pRow">Строка, которую нужно раскрасить</param>
        [Obsolete]
        private void PaintRow(DataGridViewRow pRow)
        {
            //bool ch = Convert.ToBoolean(pRow.Cells[clChecked.Index].EditedFormattedValue);
            //foreach (DataGridViewCell cell in pRow.Cells)
            //{
            //    cell.Style.BackColor = cell.Style.SelectionBackColor = ch ? Color.LightGreen : Color.White;
            //    cell.Style.ForeColor = cell.Style.SelectionForeColor = Color.Black;
            //}
        }

        private void dgvInvoiceItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvInvoiceItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvInvoiceItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool ch = Convert.ToBoolean(dgvInvoiceItems.Rows[dgvInvoiceItems.CurrentRow.Index].Cells[clChecked.Index].Value);
                foreach (DataGridViewColumn column in dgvInvoiceItems.Columns)
                {
                    dgvInvoiceItems.Rows[dgvInvoiceItems.CurrentRow.Index].Cells[column.Index].Style.BackColor = ch ? Color.LightGreen : Color.White;
                    dgvInvoiceItems.Rows[dgvInvoiceItems.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = ch ? Color.LightGreen : Color.White;
                }
            }
        }

        private void dgvInvoiceItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvInvoiceItems.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var row = ((dgvInvoiceItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow);
            bool ch = row.Checked;

            e.CellStyle.BackColor = ch ? Color.LightGreen : Color.White;
            e.CellStyle.SelectionForeColor = ch ? Color.LightGreen : Color.White;
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ КОЛИЧЕСТВА

        /// <summary>
        /// Редактируется количество - проверяем, чтобы оно не было больше чем всего в накладной
        /// </summary>
        private void dgvRemains_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= bsСoSearchItems.Count)
                return;

            var dgRow = dgvInvoiceItems.Rows[e.RowIndex];
            var dbRow = (dgRow.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow;
            if (!(dbRow.Quantity > 0 && dbRow.Quantity <= dbRow.Quantity_Max))
            {
                MessageBox.Show(String.Format(
                    "Количество добавляемого в претензию товара должно быть целым числом больше нуля и не больше {0:F0}",
                    dbRow.Quantity_Max), "Редактирование количества", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Не показываем стандартные сообщения об ошибке
        /// </summary>
        private void dgvRemains_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        #endregion

        #region СОХРАНЕНИЕ ПРЕТЕНЗИИ

        /// <summary>
        /// Сохранение претензии и ее строк и выход
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            var complaintDocID = (int?)null;

            if (ValidateData() && CreateComplaint(out complaintDocID))
            {
                MessageBox.Show(string.Format("Претензия №{0} успешно создана!", complaintDocID), "Сохранение претензии", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Создание претензии в БД
        /// </summary>
        /// <returns>True если удалось создать претензию, False если во время создания возникла ошибка</returns>
        private bool CreateComplaint(out int? complaintDocID)
        {
            complaintDocID = (int?)null;

            try
            {
                using (var scope = new TransactionScope())
                {
                    int docID = Convert.ToInt32(taCoSearchItems.AddDocIB(null, Constants.CO_DTFL_MANUFACTURERND,
                        CheckedItems[0].Warehouse_ID, CheckedItems[0].sourceAddressCode, null, null, null, sessionID, null));
                    foreach (var item in CheckedItems)
                        taCoSearchItems.AddDocIBDetail(docID, Constants.KCOO, dcto, doco, item.IsLNIDNull() ? (int?)null : item.LNID,
                            Convert.ToInt32(item.Item_ID), item.Item, item.Manufacturer, item.Vendor_Lot, item.Lot_Number, 
                            item.Lot_Number, item.UOM, item.Quantity, null, item.Locn);
                    using (var adapter = new CurrentDocsTableAdapter())
                    {
                        adapter.AddDocStages(docID);
                        adapter.ChangeDocStatus(sessionID, docID, "110", "100");
                    }
                    scope.Complete();

                    complaintDocID = docID;
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время сохранения претензии: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если все данные заданы правильно, False если есть некорректные данные</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;

            if (CheckedItems.Count == 0)
                msg = "Нужно выбрать товары, возвращаемые по претензии!";

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
                return true;
        }

        #endregion

        
    }
}
