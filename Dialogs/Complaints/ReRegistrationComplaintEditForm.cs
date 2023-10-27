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

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для создание претензии типа "Перерегистрация"
    /// </summary>
    public partial class ReRegistrationComplaintEditForm : Form
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

        /// <summary>
        /// Список через запятую идентификаторов отмеченных складов
        /// </summary>
        public string CheckedWarehouses
        {
            get
            {
                var intIds = new List<int>();
                foreach (var item in ccbWarehouses.CheckedItems)
                    intIds.Add(Convert.ToInt32((item as CCBoxItem).Value));

                string s = String.Empty;
                foreach (Data.Complaints.CO_Get_WarehouseRow row in complaints.CO_Get_Warehouse)
                    if (intIds.Contains(row.Wh_Id_Int))
                    {
                        if (s.Length > 0)
                            s += ",";
                        s += row.Warehouse_id;
                    }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ReRegistrationComplaintEditForm(long pSessionID, string pDocType)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docType = pDocType;
            Initialize();
        }

        private void Initialize()
        {
            CustomTitle();
            CustomCheckHeader();
            CustomEditMode();
        }

        /// <summary>
        /// Настройка заголовка окна в зависимости от типа создаваемой претензии
        /// </summary>
        private void CustomTitle()
        {
            switch (docType)
            {
                case Constants.CO_DFTL_DEMAND:
                    Text = "Создание претензии \"Возврат по перераспределению\"";
                    break;
                case Constants.CO_DTFL_REG:
                    Text = "Создание претензии \"Возврат по перерегистрации\"";
                    break;
                case Constants.CO_DTFL_VIRTUAL_REFUSE:
                    Text = "Создание претензии \"Виртуальный возврат\"";
                    break;
                case Constants.CO_DTFL_EXPIRATION:
                    Text = "Создание претензии \"Возврат по срокам годности\"";
                    break;
                case Constants.CO_DTFL_DEFECT:
                    Text = "Создание претензии \"Заводской брак\"";
                    break;
                case Constants.CO_DTWH_MOVE_TO_SALE_FROM_QUARANTINE:
                    Text = "Создание претензии \"Перемещение в продажу (LC-LA)\""; ;
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

        public void CustomEditMode()
        {
            if (docType == Constants.CO_DTWH_MOVE_TO_SALE_FROM_QUARANTINE)
            {
                dtpExpiredReturnDate.Enabled = false;
                cmbItemState.Enabled = false;
                cmbDeliveryWarehouse.Enabled = false;
                btnFiles.Enabled = false;
                cmbReasonID.Enabled = false;
            }
        }

        /// <summary>
        /// Загрузка необходимых данных при загрузке окна
        /// </summary>
        private void ReRegistrationComplaintEditForm_Load(object sender, System.EventArgs e)
        {
            dtpExpiredReturnDate.Select();
            LoadWarehouses();
            LoadItemTypes();
            LoadReasons();
            InitStbFilters();
        }

        /// <summary>
        /// Заполнение фильтра - выпадающего списка со складами
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                int i = 1;
                using (var adapter = new CO_Get_WarehouseTableAdapter())
                {
                    if (docType == Constants.CO_DTWH_MOVE_TO_SALE_FROM_QUARANTINE)
                        adapter.FillByI9(complaints.CO_Get_Warehouse);
                    else
                        adapter.Fill(complaints.CO_Get_Warehouse);


                    foreach (Data.Complaints.CO_Get_WarehouseRow row in complaints.CO_Get_Warehouse)
                    {
                        row.Wh_Id_Int = i++;
                        ccbWarehouses.Items.Add(new CCBoxItem(row.Warehouse_description, row.Wh_Id_Int));
                    }
                }

                if (!cmbDeliveryWarehouse.Enabled)
                    return;

                // загрузка складов-получателей
                prCOGetAvailableDestDebtorsBindingSource.DataSource = pr_CO_Get_Available_DestDebtorsTableAdapter.GetData(this.sessionID, docType);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка складов!", exc);
                ccbWarehouses.Items.Clear();
            }
        }

        /// <summary>
        /// Загрузка типов состояния товаров
        /// </summary>
        private void LoadItemTypes()
        {
            try
            {
                if (!cmbItemState.Enabled)
                    return;

                taCoAutoGetTypeItemReason.Fill(complaints.CO_Auto_Get_Type_Item_Reason, docType);
                if (cmbItemState.Items.Count > 0)
                    cmbItemState.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки типов состояния возвращаемых товаров: ", exc);
            }
        }

        /// <summary>
        /// Загрузка возможных причин возврата товара
        /// </summary>
        private void LoadReasons()
        {
            try
            {
                if (!cmbReasonID.Enabled)
                    return;

                taCoGetIBReturnReasons.Fill(complaints.CO_Get_IBReturn_Reasons, docType, this.sessionID);
                if (cmbReasonID.Items.Count > 0)
                    cmbReasonID.SelectedIndex = 0;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки типов состояния возвращаемых товаров: ", exc);
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
                ReasonID = cmbReasonID.SelectedValue == null ? (int?)null : Convert.ToInt32(cmbReasonID.SelectedValue)
            });
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

        /// <summary>
        /// Перезагружаем остатки при изменении выбранных складов
        /// </summary>
        private void ccbWarehouses_TextChanged(object sender, EventArgs e)
        {
            StartRemainsLoading();
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
            stbItemName.UserID = stbFilterVendor.UserID = sessionID;
            stbItemName.ValueReferenceQuery = "[dbo].[pr_CO_STB_Get_Items]";
            stbFilterVendor.ValueReferenceQuery = "[dbo].[pr_CO_STB_Get_Vendors]";
            lblItemName.Text = lblVendorName.Text = String.Empty;
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
        /// Обновление фильтров на таблице с остатками
        /// </summary>
        private void RefreshFilter()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bsCoSearchItems.Filter = String.Empty;
                else
                    bsCoSearchItems.Filter =
                        String.Format("Convert([Item_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%' OR [Vendor_Lot] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
            finally
            {
                foreach (DataGridViewRow row in dgvRemains.Rows)
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
                MessageBox.Show(string.Format("Претензия №{0} успешно создана!", complaintDocID), "Сохранение претензии", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    var deliveryWH = cmbDeliveryWarehouse.Enabled ? cmbDeliveryWarehouse.SelectedValue : (object)null;

                    int id = Convert.ToInt32(taCoSearchItems.AddAutoDocsTempHeader(
                        docType, sessionID, 100, tbxComment.Text, deliveryWH == null ? (int?)null : (int)deliveryWH));

                    foreach (var row in CheckedItems)
                        taCoSearchItems.AddAutoDocsTempDetails(id, sessionID, row.Warehouse_ID, 
                            Convert.ToInt32(row.Item_ID), row.UOM, row.Lot_Number, row.Quantity,
                            dtpExpiredReturnDate.Enabled ? dtpExpiredReturnDate.Value : (DateTime?)null, 
                            cmbItemState.Enabled ? cmbItemState.SelectedItem.ToString() : (string)null,
                            cmbReasonID.Enabled ? ((cmbReasonID.SelectedItem as DataRowView).Row as Data.Complaints.CO_Get_IBReturn_ReasonsRow).Reason_ID : (int?)null,
                                row.Vendor_Lot, row.IsLocnNull() ? null : row.Locn, row.IsLotsNull() ? null : row.Lots);

                    // Добавляем вложенные файлы
                    taCoSearchItems.SetTimeout((int)TimeSpan.FromMinutes(2).TotalSeconds);
                    foreach (var file in attachedFiles)
                        taCoSearchItems.AddAutoDocsAttachmentTemp(id, file.File_Name, file.Description, file.File_Data, sessionID, file.Document_Number, file.Document_Date, file.IsDescriptionTypeNull() ? (string)null : file.DescriptionType);

                    var coDocID = (long?)null;
                    taCoSearchItems.AddAutoDocsIB(id, ref coDocID);

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
            try
            {
                string msg = String.Empty;

                if (dtpExpiredReturnDate.Enabled && dtpExpiredReturnDate.Value < DateTime.Now)
                    msg = "Срок возвращения товара на ЦС не может быть в прошлом!";
                else if (cmbItemState.Enabled && cmbItemState.SelectedItem == null)
                    msg = "Нужно выбрать вид возвращаемого товара (товарный, нетоварный, со следами от ценников)!";
                else if (CheckedItems.Count == 0)
                    msg = "Нужно выбрать товары, возвращаемые по претензии!";
                else if (btnFiles.Enabled && docType == Constants.CO_DFTL_DEMAND && attachedFiles.Count == 0)
                    msg = "Необходимо вложить документ!";

                if (!String.IsNullOrEmpty(msg))
                    throw new Exception(msg);

                using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
                {
                    foreach (var file in attachedFiles)
                        adapter.CheckDocAttachment(sessionID, docType, file.Document_Number, file.IsDescriptionTypeNull() ? (string)null : file.DescriptionType);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion


        /// <summary>
        /// Файлы, прикрепленные к претензии
        /// </summary>
        private readonly List<Data.Complaints.AttachmentsRow> attachedFiles = new List<Data.Complaints.AttachmentsRow>();

        private void btnFiles_Click(object sender, EventArgs e)
        {
            var window = new AttachmentsForm(attachedFiles) { Owner = this };
            window.ShowDialog();

            attachedFiles.Clear();
            attachedFiles.AddRange(window.Files);
        }
    }

    #region КЛАССЫ ПАРАМЕТРОВ ЗАГРУЗКИ ОСТАТКОВ

    /// <summary>
    /// Параметры получения остатков с блоками по перерегистрации
    /// </summary>
    public class ReRegistrationRemainsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }

        /// <summary>
        /// DelimetedList с идентификаторами складов
        /// </summary>
        public string WarehouseIDs { get; set; }

        /// <summary>
        /// Идентификатор поставщика либо null, если этот фильтр не задан
        /// </summary>
        public int? VendorID { get; set; }

        /// <summary>
        /// Идентификатор товара либо null, если этот фильтр не задан
        /// </summary>
        public int? ItemID { get; set; }

        /// <summary>
        /// Срок годности товаров либо null, если этот фильтр не задан
        /// </summary>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        ///Код причины
        /// </summary>
        public int? ReasonID { get; set; }
    }

    #endregion
}
