using System;
using System.Data;
using System.Timers;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для создания новой электронной возвратной накладной
    /// </summary>
    public partial class NewReturnInvoiceForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int userId;

        /// <summary>
        /// Признак, показывающий, находится ли накладная в режиме редактирования либо в режиме создания
        /// </summary>
        private bool isEditMode;

        /// <summary>
        /// Идентификатор документа
        /// </summary>
        public long? DocId;

        /// <summary>
        /// Идентификатор поставщика
        /// </summary>
        private double? vendorId;

        /// <summary>
        /// Идентификатор склада, с которого будет осуществлен возврат
        /// </summary>
        private int? warehouseId;

        /// <summary>
        /// Тип документа возврата
        /// </summary>
        private string docType;

        /// <summary>
        /// Признак, который показывает, были ли сделанны какие-нибудь изменения с накладной
        /// </summary>
        public bool WasChangesMade { get; private set; }

        /// <summary>
        /// Признак, который показывает, были ли сделанны какие-нибудь изменения с товарами в накладной
        /// </summary>
        public bool WasChangesWithProductsMade { get; private set; }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public NewReturnInvoiceForm(int pUserId)
        {
            InitializeComponent();
            isEditMode = false;
            userId = pUserId;
            spcTwoGrids.Enabled = false;
        }

        public NewReturnInvoiceForm(int pUserId, long pDocId, double pVendorId, DateTime pInvoiceDate, int pWarehouseId,
            bool pIsCorrection, int pRound, string pDocType)
        {
            InitializeComponent();
            userId = pUserId;
            isEditMode = true;
            DocId = pDocId;
            cmbVendors.Enabled = false;
            cmbDocsTypes.Enabled = false;
            dtpDocDate.Enabled = cmbWarehouse.Enabled = !pIsCorrection;
            Text = pIsCorrection ? "Корректировка накладной " : "Редактирование накладной " + pDocId;
            nudRounding.Value = pRound;
            vendorId = pVendorId;
            dtpDocDate.Value = pInvoiceDate;
            warehouseId = pWarehouseId;
            docType = pDocType;
        }

        /// <summary>
        /// Загрузка списка поставщиков при загрузке формы
        /// </summary>
        private void NewReturnInvoiceForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            LoadDocsTypes();
            LoadVendors();
            LoadInvoiceProducts();
            filterTimer.Elapsed += filterTimer_Elapsed;
            Config.LoadDataGridViewSettings(Name + "_Remains", dgvFreeProducts);
            Config.LoadDataGridViewSettings(Name + "_Invoice", dgvInvoiceProducts);
        }

        /// <summary>
        /// Загрузка поставщиков
        /// </summary>
        private void LoadVendors()
        {
            try
            {
                taVendors.Fill(complaints.Vendors);
                if (isEditMode)
                    foreach (DataRowView view in cmbVendors.Items)
                        if (Math.Abs((view.Row as WMSOffice.Data.Complaints.VendorsRow).Vendor_ID - vendorId.Value) < Double.Epsilon)
                        {
                            cmbVendors.SelectedItem = view;
                            break;
                        }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список поставщиков:" + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка товаров, которые находятся в накладной
        /// </summary>
        private void LoadInvoiceProducts()
        {
            try
            {
                taVrDocDetails.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                taVrDocDetails.Fill(complaints.VR_DocDetails, userId, DocId);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список товаров, которые добавлены в накладную:"
                    + Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка возможных складов
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                taVr_GetShippingList.Fill(complaints.VR_GetShippingList, userId);
                if (isEditMode)
                    foreach (DataRowView view in cmbWarehouse.Items)
                        if (Math.Abs((view.Row as WMSOffice.Data.Complaints.VR_GetShippingListRow).Warehouse_ID - warehouseId.Value) < Double.Epsilon)
                        {
                            cmbVendors.SelectedItem = view;
                            break;
                        }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список доступных складов:"
                    + Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        /// <summary>
        /// Загрузка типов возвратов
        /// </summary>
        private void LoadDocsTypes()
        {
            try
            {
                vR_Docs_TypesTableAdapter.Fill(complaints.VR_Docs_Types, userId);
                if (isEditMode)
                     foreach (DataRowView view in cmbDocsTypes.Items)
                         if ((view.Row as WMSOffice.Data.Complaints.VR_Docs_TypesRow).Doc_Type == docType)
                         {
                             cmbDocsTypes.SelectedItem = view;
                             break;
                         }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить список доступных типов возвратов:"
                       + Environment.NewLine + exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void cmbDocsTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            ChangeNoVATStateOption();
            LoadFreeProducts();
        }

        private void ChangeNoVATStateOption()
        {
            var isVR = "VR".Equals(cmbDocsTypes.SelectedValue);

            cbNoVAT.Enabled = isVR && !isEditMode;
            cbNoVAT.Checked = false;
        }

        /// <summary>
        /// При выборе нового поставщика обновляем доступный товар
        /// </summary>
        private void cmbVendors_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadFreeProducts();
        }

        /// <summary>
        /// Загрузка товаров, доступных для помещения в накладную
        /// </summary>
        private void LoadFreeProducts()
        {
            try
            {
                complaints.VR_LC_Remains.Clear();
                if (cmbVendors.SelectedValue != null && cmbDocsTypes.SelectedValue != null)
                {
                    taVrLcRemains.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);
                    taVrLcRemains.Fill(complaints.VR_LC_Remains, Convert.ToInt32(cmbVendors.SelectedValue), cmbDocsTypes.SelectedValue.ToString());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить остатки в карантине по данному поставщику: " + Environment.NewLine + exc.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnAddToInvoice.Enabled = dgvFreeProducts.SelectedCells.Count > 0 && isEditMode;
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ ТОВАРОВ В СПИСОК

        /// <summary>
        /// В зависимости от того, выбраны ли товары в списке доступных для выбора, настраиваем доступность кнопок
        /// </summary>
        private void dgvFreeProducts_SelectionChanged(object sender, EventArgs e)
        {
            btnAddToInvoice.Enabled = dgvFreeProducts.SelectedCells.Count > 0 && isEditMode;
        }

        /// <summary>
        /// Добавление выбранных товаров в накладную
        /// </summary>
        private void btnAddToInvoice_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvFreeProducts.SelectedRows)
                try
                {
                    var newItem = (row.DataBoundItem as DataRowView).Row as WMSOffice.Data.Complaints.VR_LC_RemainsRow;
                    var warehouseID = newItem.IsWarehouse_IDNull() ? (string)null : newItem.Warehouse_ID;

                    WMSOffice.Data.Complaints.VR_DocDetailsRow existedItem = null;
                    foreach (WMSOffice.Data.Complaints.VR_DocDetailsRow existedRow in complaints.VR_DocDetails.Rows)
                        if (newItem.Item_ID == existedRow.Item_ID && newItem.Location_ID.Trim() == existedRow.Location_ID.Trim() &&
                            newItem.Batch_ID.Trim() == existedRow.Batch_ID.Trim())
                            existedItem = existedRow;

                    
                    taVrDocDetails.AddDocRow(userId, DocId, warehouseID, newItem.Location_ID, Convert.ToInt32(newItem.Item_ID),
                        newItem.Batch_ID, newItem.Quantity + (existedItem == null ? 0 : existedItem.Quantity),
                        Convert.ToInt32(nudRounding.Value));
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Не удалось добавить товар в накладную: " + Environment.NewLine + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            LoadFreeProducts();
            LoadInvoiceProducts();
        }

        /// <summary>
        /// Удаление выбранных товаров из накладной
        /// </summary>
        private void btnRemoveFromInvoice_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvInvoiceProducts.SelectedRows)
                try
                {
                    var newItem = (row.DataBoundItem as DataRowView).Row as WMSOffice.Data.Complaints.VR_DocDetailsRow;
                    var warehouseID = newItem.IsWarehouse_IDNull() ? (string)null : newItem.Warehouse_ID;

                    taVrDocDetails.AddDocRow(userId, DocId, warehouseID, newItem.Location_ID, Convert.ToInt32(newItem.Item_ID),
                        newItem.Batch_ID, 0, Convert.ToInt32(nudRounding.Value));
                }
                catch (Exception exc)
                {
                    MessageBox.Show("Не удалось удалить товар из накладной: " + Environment.NewLine + exc.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            LoadFreeProducts();
            LoadInvoiceProducts();
        }

        /// <summary>
        /// Редактирование количества товара в накладной в БД
        /// </summary>
        private void dgvInvoiceProducts_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var newItem = ((dgvInvoiceProducts.Rows[e.RowIndex]).DataBoundItem as DataRowView).Row as WMSOffice.Data.Complaints.VR_DocDetailsRow;
                var warehouseID = newItem.IsWarehouse_IDNull() ? (string)null : newItem.Warehouse_ID;

                taVrDocDetails.AddDocRow(userId, DocId, warehouseID, newItem.Location_ID, Convert.ToInt32(newItem.Item_ID),
                    newItem.Batch_ID, newItem.Quantity, Convert.ToInt32(nudRounding.Value));
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось изменить количество товара в накладной: " + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            LoadFreeProducts();
        }

        /// <summary>
        /// Проверка вводимого количества на корректность
        /// </summary>
        private void dgvInvoiceProducts_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvInvoiceProducts.Columns[e.ColumnIndex].Name != "quantityDataGridViewTextBoxColumn1")
                return;

            bool isRightNumber = false;
            if (Convert.ToInt32(cmbVendors.SelectedValue) == 30239)
            {
                double dNum;
                isRightNumber = !String.IsNullOrEmpty(e.FormattedValue.ToString()) &&
                    Double.TryParse(e.FormattedValue.ToString(), out dNum) && dNum >= 0;
            }
            else
            {
                int iNum;
                isRightNumber = !String.IsNullOrEmpty(e.FormattedValue.ToString()) &&
                    Int32.TryParse(e.FormattedValue.ToString(), out iNum) && iNum >= 0;
            }

            if (!isRightNumber)
            {
                MessageBox.Show("Количество должно быть неотрицательным целым (кроме ТОВ ТОРГОВЫЙ ДИМ КАСКАД МЕДИКАЛ) числом!", "Неверно задано количество",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ПО КОДУ, НАИМЕНОВАНИЮ, СЕРИИ И ПАРТИИ ТОВАРА

        /// <summary>
        /// Строка фильтра (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string filter;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация по остаткам проихсодила не сразу после изменения
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
        /// Обновление фильтров
        /// </summary>
        private void RefreshFilters()
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                    bSVrLCRemains.Filter = String.Empty;
                else
                    bSVrLCRemains.Filter =
                        String.Format("Convert([Item_ID], 'System.String') = '{0}' OR Convert([LotNumber], 'System.String') = '{0}'" +
                        " OR Convert([Batch_ID], 'System.String') = '{0}' OR [Item] LIKE '%{0}%'", filter);
            }
            catch { }   // Нам тут не важно, какая ошибка - главное чтобы не слетала программа
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvFreeProducts.Invoke(new Method(RefreshFilters));
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

        #endregion

        #region СОХРАНЕНИЕ ИЗМЕНЕНИЙ

        /// <summary>
        /// В зависимости от того, какая цифра выбрана, меняем метку
        /// </summary>
        private void nudRounding_ValueChanged(object sender, EventArgs e)
        {
            switch (Convert.ToInt32(nudRounding.Value))
            {
                case 1:
                    lblSigns.Text = "знак после запятой";
                    break;
                case 2:
                case 3:
                case 4:
                    lblSigns.Text = "знака после запятой";
                    break;
                default:
                    lblSigns.Text = "знаков после запятой";
                    break;
            }
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
                if (isEditMode)
                    EditInvoice();
                else
                    CreateNewInvoice();
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True, если данные введены корректно, False если есть ошибки</returns>
        private bool CheckData()
        {
            return true;
        }

        /// <summary>
        /// Сохранение созданной накладной в БД
        /// </summary>
        private void CreateNewInvoice()
        {
            try
            {
                var noVAT = Convert.ToInt32(cbNoVAT.Enabled ? cbNoVAT.Checked : false);
                using (var adapter = new VR_DocsTableAdapter())
                    DocId = Convert.ToInt64(adapter.CreateDoc(userId, Convert.ToInt32(cmbVendors.SelectedValue), dtpDocDate.Value,
                        Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToInt32(nudRounding.Value), cmbDocsTypes.SelectedValue.ToString(), noVAT));
                isEditMode = true;
                cmbVendors.Enabled = false;
                spcTwoGrids.Enabled = true;
                Text = "Редактирование накладной " + DocId;
                WasChangesMade = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось сохранить изменения в БД: " + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохранение изменений, сделанных в накладной, в БД (редактирование даты накладной)
        /// </summary>
        private void EditInvoice()
        {
            try
            {
                using (var adapter = new VR_DocsTableAdapter())
                    adapter.ChangeDocDate(userId, DocId, dtpDocDate.Value,
                        Convert.ToInt32(cmbWarehouse.SelectedValue), Convert.ToInt32(nudRounding.Value));
                WasChangesMade = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось сохранить изменения в БД: " + Environment.NewLine + exc.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохранение настроек гридов при закрытии окна
        /// </summary>
        private void NewReturnInvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name + "_Remains", dgvFreeProducts);
            Config.SaveDataGridViewSettings(Name + "_Invoice", dgvInvoiceProducts);
        }

        #endregion
    }
}
