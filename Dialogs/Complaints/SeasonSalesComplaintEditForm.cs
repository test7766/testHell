using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Transactions;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.ComplaintsTableAdapters;
using System.Text;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для создание претензии типа "Перерегистрация"
    /// </summary>
    public partial class SeasonSalesComplaintEditForm : Form
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
        /// Тип создаваемой претензии
        /// </summary>
        private readonly string docType;

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

        private string CheckedWarehouses
        {
            get
            {
                return cmbDeliveryWarehouse.SelectedValue.ToString();
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SeasonSalesComplaintEditForm(long pSessionID, string pDocType)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docType = pDocType;
            CustomTitle();
            CustomCheckHeader();
        }

        /// <summary>
        /// Настройка заголовка окна в зависимости от типа создаваемой претензии
        /// </summary>
        private void CustomTitle()
        {
            switch (docType)
            {
                case Constants.CO_DT_SEASON_SALES:
                    Text = "Создание претензии \"Сезонные продажи\"";
                    break;
            }
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
            foreach (DataGridViewRow row in dgvRemains.Rows)
                ((row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow).Checked = pState;

            dgvRemains.RefreshEdit();
            bsCoSearchItems.ResetBindings(false);

            foreach (DataGridViewRow row in dgvRemains.Rows)
                PaintRow(row);
        }

        /// <summary>
        /// Загрузка необходимых данных при загрузке окна
        /// </summary>
        private void ReRegistrationComplaintEditForm_Load(object sender, System.EventArgs e)
        {
            dtpExpiredReturnDate.Select();
            InitStbFilters();
        }

        /// <summary>
        /// Заполнение фильтра - выпадающего списка со складами
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                if (stbDeliveryID.Value == null)
                    return;

                var deliveryID = Convert.ToInt32(stbDeliveryID.Value);
                prCOGetDeliveryWarehouseIDBindingSource.DataSource = pr_CO_Get_Delivery_WarehouseIDTableAdapter.GetData(deliveryID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка складов!", exc);
            }
        }

        /// <summary>
        /// Сохранение настроек при выходе из окна
        /// </summary>
        private void ReRegistrationComplaintEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvRemains);
        }

        #endregion

        #region ГОРЯЧИЕ КЛАВИШИ

        /// <summary>
        /// Управление окном с помощью горячих клавиш
        /// </summary>
        private void ReRegistrationComplaintEditForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F && e.Control)
                stbFilterVendor.Focus();
            else if (e.KeyCode == Keys.Enter && e.Control)
                btnOK_Click(btnOK, EventArgs.Empty);
            else if ((int)e.KeyCode == 107 && e.Control)    // Знак "+"
                checkHeaderCell_OnCheckBoxClicked(true);
            else if ((int)e.KeyCode == 109 && e.Control)    // Знак "-"
                checkHeaderCell_OnCheckBoxClicked(false);
            else if (e.KeyCode == Keys.F5)
                btnRefresh_Click(btnRefresh, EventArgs.Empty);
        }

        /// <summary>
        /// Горячие клавиши на таблице товаров
        /// </summary>
        private void dgvRemains_KeyDown(object sender, KeyEventArgs e)
        {
            if (dgvRemains.SelectedRows.Count > 0)
                if ((int)e.KeyCode == 107)  // Знак "+"
                {
                    (dgvRemains.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = true;
                    PaintRow(dgvRemains.SelectedRows[0]);
                }
                else if ((int)e.KeyCode == 109) // Знак "-"
                {
                    (dgvRemains.SelectedRows[0].DataBoundItem as DataRowView).Row[CHECKED_COL_NAME] = false;
                    PaintRow(dgvRemains.SelectedRows[0]);
                }
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ОСТАТКОВ

        /// <summary>
        /// Запуск асинхронной загрузки остатков
        /// </summary>
        private void StartRemainsLoading()
        {
            try
            {
                // проверка по складам
                if (cmbDeliveryWarehouse.SelectedValue == null)
                    throw new Exception("Необходимо выбрать склад.");

                lastWorker = new BackgroundWorker();
                lastWorker.DoWork += lastWorker_DoWork;
                lastWorker.RunWorkerCompleted += lastWorker_RunWorkerCompleted;
                if (dgvRemains.Rows.Count > 0)  // Исключаем сохранение настроек на пустой таблице
                    Config.SaveDataGridViewSettings(Name, dgvRemains);
                dgvRemains.Enabled = false;
                pbWait.Visible = true;
                dgvRemains.DataSource = null;
                lastWorker.RunWorkerAsync(new ReRegistrationRemainsSearchParameters
                {
                    SessionID = sessionID,
                    WarehouseIDs = CheckedWarehouses,
                    VendorID = String.IsNullOrEmpty(stbFilterVendor.Value) ? null : (int?)Convert.ToInt32(stbFilterVendor.Value),
                    ItemID = String.IsNullOrEmpty(stbItemName.Value) ? null : (int?)Convert.ToInt32(stbItemName.Value),
                    ExpirationDate = chbExpirationDate.Checked ? (DateTime?)dtpExpirationDate.Value : null,
                    ReasonID = (int?)null
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Асинхронная загрузка остатков
        /// </summary>
        private void lastWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as ReRegistrationRemainsSearchParameters;
                using (var adapter = new CO_Search_ItemsTableAdapter())
                {
                    complaints.CO_Search_Items.Clear();
                    adapter.SetTimeout(600);
                    adapter.Fill(complaints.CO_Search_Items, sc.SessionID, docType, null, null, null,
                        sc.WarehouseIDs, sc.VendorID, sc.ItemID, sc.ExpirationDate, sc.ReasonID);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Загрузка остатков закончена
        /// </summary>
        private void lastWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (sender == lastWorker)
            {
                if (e.Result is Exception)
                    Logger.ShowErrorMessageBox("Во время загрузки остатков произошла ошибка!", e.Result as Exception);

                dgvRemains.DataSource = bsCoSearchItems;

                pbWait.Visible = false;
                dgvRemains.Enabled = true;
                DataGridViewHelper.AutoSetColumnWidths(dgvRemains);
                try { Config.LoadDataGridViewSettings(Name, dgvRemains); } catch { };

                // Сбрасываем выделение позиций
                foreach (DataGridViewRow row in dgvRemains.Rows)
                    row.Selected = false;
            }
        }

        #endregion

        #region ОКРАШИВАНИЕ ТОВАРОВ В ТАБЛИЦЕ

        /// <summary>
        /// Окрашивание строки, если поставили/убрали флажок
        /// </summary>
        private void dgvRemains_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == clChecked.Index)
            //    PaintRow(dgvRemains.Rows[e.RowIndex]);

            if (e.ColumnIndex == clChecked.Index)
            {
                bool ch = Convert.ToBoolean(dgvRemains.Rows[e.RowIndex].Cells[clChecked.Index].EditedFormattedValue);
                foreach (DataGridViewRow row in dgvRemains.SelectedRows)
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

        private void dgvRemains_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRemains.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvRemains.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool ch = Convert.ToBoolean(dgvRemains.Rows[dgvRemains.CurrentRow.Index].Cells[clChecked.Index].Value);
                foreach (DataGridViewColumn column in dgvRemains.Columns)
                {
                    dgvRemains.Rows[dgvRemains.CurrentRow.Index].Cells[column.Index].Style.BackColor = ch ? Color.LightGreen : Color.White;
                    dgvRemains.Rows[dgvRemains.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = ch ? Color.LightGreen : Color.White;
                }
            }
        }

        private void dgvRemains_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvRemains.Rows[e.RowIndex].DataBoundItem == null)
                return;

            var row = ((dgvRemains.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_Search_ItemsRow);
            bool ch = row.Checked;

            e.CellStyle.BackColor = ch ? Color.LightGreen : Color.White;
            e.CellStyle.SelectionForeColor = ch ? Color.LightGreen : Color.White;
        }

        #endregion

        #region ФИЛЬТРЫ ДЛЯ ЗАГРУЗКИ

        /// <summary>
        /// Инициализация фильтров с выпадающими справочниками по поставщику и товару
        /// </summary>
        private void InitStbFilters()
        {
            stbItemName.UserID = stbFilterVendor.UserID = stbDeliveryID.UserID = sessionID;
            stbItemName.ValueReferenceQuery = "[dbo].[pr_CO_STB_Get_Items]";
            stbFilterVendor.ValueReferenceQuery = "[dbo].[pr_CO_STB_Get_Vendors]";
            stbDeliveryID.ValueReferenceQuery = "[dbo].[pr_CO_Get_Delivery_Addresses]";
            lblItemName.Text = lblVendorName.Text = tbDeliveryName.Text = String.Empty;
        }

        /// <summary>
        /// Настройка доступности фильтра по сроку годности с помощью флажка
        /// </summary>
        private void chbExpirationDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpExpirationDate.Enabled = chbExpirationDate.Checked;
        }

        /// <summary>
        /// Проверка введенного значения в фильтр по поставщику
        /// </summary>
        private void stbFilterVendor_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            stbFilterVendor.Value = e.Success ? e.Value : null;
            lblVendorName.Text = e.Success ? e.Description : String.Empty;
        }

        /// <summary>
        /// Проверка введенного значения в фильтр по товару
        /// </summary>
        private void stbItemName_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            stbItemName.Value = e.Success ? e.Value : null;
            lblItemName.Text = e.Success ? e.Description : String.Empty;
        }

        /// <summary>
        /// Проверка введенного значения в фильтр по ТТ
        /// </summary>
        private void stbDeliveryID_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            tbDeliveryName.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
            tbDeliveryName.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

            prCOGetDeliveryWarehouseIDBindingSource.DataSource = null;
            complaints.pr_CO_Get_Delivery_WarehouseID.Clear();

            dgvRemains.DataSource = null;
            complaints.CO_Search_Items.Clear();

            if (e.Success)
            {
                stbDeliveryID.Value = e.Value;
                LoadWarehouses();
            }
        }

        /// <summary>
        /// Обновление товаров, доступных для выбора
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartRemainsLoading();
        }

        #endregion

        #region БЫСТРЫЙ ФИЛЬТР

        /// <summary>
        /// Строка фильтра
        /// </summary>
        private string filterText;

        /// <summary>
        /// Применение фильтра при окончании работы таймера
        /// </summary>
        private void delayTimer_Tick(object sender, EventArgs e)
        {
            delayTimer.Stop();
            RefreshFilter();
        }

        /// <summary>
        /// Обновление фильтров на таблице с остатками
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                var sbFilterFull = new StringBuilder("1=1");

                if (!String.IsNullOrEmpty(filterText))
                    sbFilterFull.AppendFormat(" AND (Convert([Item_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%' OR [Vendor_Lot] LIKE '%{0}%')", filterText);

                if (cbShowCheckedItemsOnly.Checked)
                    sbFilterFull.AppendFormat(" AND ([Checked] = 1)");

                //if (String.IsNullOrEmpty(filterText))
                //    bsCoSearchItems.Filter = String.Empty;
                //else
                //    bsCoSearchItems.Filter =
                //        String.Format("AND (Convert([Item_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%' OR [Vendor_Lot] LIKE '%{0}%)'", filterText);

                if (sbFilterFull.Length > 0)
                    bsCoSearchItems.Filter = sbFilterFull.ToString();
            
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
            finally
            {
                foreach (DataGridViewRow row in dgvRemains.Rows)
                    PaintRow(row);
            }
        }

        private void cbShowCheckedItemsOnly_CheckedChanged(object sender, EventArgs e)
        {
            RefreshFilter();
        }

        /// <summary>
        /// Изменение фильтра
        /// </summary>
        private void tbxFilter_TextChanged(object sender, EventArgs e)
        {
            filterText = tbxFilter.Text;
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

        #region РЕДАКТИРОВАНИЕ КОЛИЧЕСТВА

        /// <summary>
        /// Редактируется количество - проверяем, чтобы оно не было больше чем всего доступно на складе
        /// </summary>
        private void dgvRemains_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex >= bsCoSearchItems.Count)
                return;

            var dgRow = dgvRemains.Rows[e.RowIndex];
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
            var complaintDocID = (long?)null;

            if (ValidateData() && CreateComplaint(out complaintDocID))
            {
                MessageBox.Show(string.Format("Претензия № {0} успешно создана!", complaintDocID), "Сохранение претензии", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Создание претензии в БД
        /// </summary>
        /// <returns>True если удалось создать претензию, False если во время создания возникла ошибка</returns>
        private bool CreateComplaint(out long? complaintDocID)
        {
            complaintDocID = (long?)null;

            try
            {
                using (var scope = new TransactionScope())
                {
                    var deliveryWH = Convert.ToInt32(stbDeliveryID.Value);

                    int id = Convert.ToInt32(taCoSearchItems.AddAutoDocsTempHeader(
                        docType, sessionID, 100, tbxComment.Text, deliveryWH));

                    foreach (var row in CheckedItems)
                        taCoSearchItems.AddAutoDocsTempDetails(id, sessionID, row.Warehouse_ID, 
                            Convert.ToInt32(row.Item_ID), row.UOM, row.Lot_Number, row.Quantity,
                            dtpExpiredReturnDate.Value, (string)null, (int?)null, 
                            row.Vendor_Lot, row.IsLocnNull() ? null : row.Locn, row.IsLotsNull() ? null : row.Lots);

                    var coDocID = (long?)null;
                    taCoSearchItems.AddAutoDocsVS(id, ref coDocID);
                    scope.Complete();

                    complaintDocID = coDocID;
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

            if (dtpExpiredReturnDate.Value < DateTime.Now)
                msg = "Дата возврата не может быть в прошлом!";
            else if (cmbDeliveryWarehouse.SelectedValue == null)
                msg = "Необходимо выбрать склад!";
            else if (CheckedItems.Count == 0)
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
