using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.WHTableAdapters;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно для создания новой электронной возвратной накладной
    /// </summary>
    public partial class CreateWriteOffStuffForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private int sessionId;

        /// <summary>
        /// Признак, показывающий, находится ли накладная в режиме редактирования либо в режиме создания
        /// </summary>
        private bool isEditMode;

        /// <summary>
        /// Идентификатор редактируемого документа - в любом случае должен быть не null после загрузки окна
        /// </summary>
        private long? docID;
        public long DocID { get { return docID ?? -1; } }

        /// <summary>
        /// Название таблицы с остатками в конфигурационном файле
        /// </summary>
        private string ConfigRemainsTableName { get { return String.Format("{0}_Remains", Name); } }

        /// <summary>
        /// Название таблицы со строками в макете в конфигурационном файле
        /// </summary>
        private string ConfigLinesTableName { get { return String.Format("{0}_Lines", Name); } }

        /// <summary>
        /// Редактируемый макет (или null, если имеет место создание макета)
        /// </summary>
        private Data.WH.WF_GetDocsRow currentRow;

        /// <summary>
        /// Фильтр, который содержит в себе последние значения из фильтров грида
        /// </summary>
        private readonly RemainsFilter remainsFilter = new RemainsFilter();

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public CreateWriteOffStuffForm(int pUserId)
        {
            InitializeComponent();
            sessionId = pUserId;
            InitializeWriteOffRemainsGrid();
        }

        public CreateWriteOffStuffForm(int pUserId, Data.WH.WF_GetDocsRow pEditRow)
            : this(pUserId)
        {
            isEditMode = true;
            docID = pEditRow.Doc_ID;
            currentRow = pEditRow;
            dtpDocDate.Value = pEditRow.DocDate;
            cbSimpleAct.Checked = pEditRow.IsIS_Separate_ActNull() || pEditRow.IS_Separate_Act == 0 ? false : true;
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с остатками
        /// </summary>
        private void InitializeWriteOffRemainsGrid()
        {
            dgvRemains.Init(new WriteOffStuffRemainsView(), true);
            dgvRemains.LargeAmountOfData = true;
            dgvRemains.LoadExtraDataGridViewSettings(ConfigRemainsTableName);
            dgvRemains.UserID = sessionId;
            dgvRemains.SetCellStyles(dgvDocLines.RowTemplate.DefaultCellStyle, dgvDocLines.ColumnHeadersDefaultCellStyle);
            dgvRemains.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRemains.AllowRangeColumns = true;
            dgvRemains.UseMultiSelectMode = true;

            dgvRemains.OnFilterChanged += dgvRemains_OnFilterChanged;
            dgvRemains.OnRowSelectionChanged += dgvRemains_OnRowSelectionChanged;

            // активация постраничного просмотра
            dgvRemains.CreatePageNavigator();
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvRemains_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvRemains.RecalculateSummary();
            var filters = dgvRemains.PropertyFilters;
            if (!remainsFilter.IsEquals(filters))
            {
                remainsFilter.SaveFilters(filters);
                if (!remainsFilter.IsEmpty)
                    StartRemainsLoading();
            }
        }

        /// <summary>
        /// Загрузка всех необходимых данных при загрузке окна
        /// </summary>
        private void CreateWriteOffStuffForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'wH.Suppliers' table. You can move, or remove it, as needed.
            this.suppliersTableAdapter.Fill(this.wH.Suppliers);
            if (!LoadWarehouses() || !LoadDocTypes() || !LoadJDEDocTypes() || !LoadApprovers() || !LoadSuppliers() || !AdaptCurrencySign())
            {
                Close();
                return;
            }
            if (!isEditMode)
                if (!CreateEmptyDoc())
                {
                    Close();
                    return;
                }

            if (isEditMode)
            {
                InitFormWhenEditMode();
                if (!LoadDocLines())
                {
                    Close();
                    return;
                }
            }

            CustomInventoryCombobox();


        }

        /// <summary>
        /// Загрузка доступных для выбора складов
        /// </summary>
        /// <returns>True, если загрузка прошла успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool LoadWarehouses()
        {
            try
            {
                taWfGetWarehouseList.Fill(wH.WF_GetWarehouseList, sessionId);
                if (wH.WF_GetWarehouseList.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Список доступных складов пустой! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    if (isEditMode)
                        cmbWarehouses.SelectedValue = currentRow.Warehouse_ID;
                    else
                        cmbWarehouses.SelectedIndex = 0;
                    LoadInventories();
                    cmbWarehouses.SelectedValueChanged += cmbWarehouses_SelectedValueChanged;
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список складов! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Загрузка доступных для выбора типов документов
        /// </summary>
        /// <returns>True, если загрузка прошла успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool LoadDocTypes()
        {
            try
            {
                taWfGetDocTypes.Fill(wH.WF_GetDocTypes, sessionId);
                if (wH.WF_GetDocTypes.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Список доступных типов документов пустой! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    if (isEditMode)
                        cmbDocType.SelectedValue = currentRow.Doc_TypeID;
                    else
                        cmbDocType.SelectedIndex = 0;

                    CustomizeIsNotBalance();

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список доступных типов документов! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Перезагрузка подписантов при изменении выделенного типа документа
        /// </summary>
        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocType.SelectedItem != null)
            {
                AdaptCurrencySign();
                LoadApprovers();

                cmbJDE.SelectedItem = null;
            }

            CustomizeIsNotBalance();
            CustomInventoryCombobox();
        }

        private void CustomizeIsNotBalance()
        {
            cbIsNotBalance.Enabled = cmbDocType.SelectedItem != null && ((cmbDocType.SelectedItem as DataRowView).Row as Data.WH.WF_GetDocTypesRow).IsNotBalance;
            if (!cbIsNotBalance.Enabled)
                cbIsNotBalance.Checked = false;
        }

        /// <summary>
        /// Адаптация признака использования иностранной валюты
        /// </summary>
        private bool AdaptCurrencySign()
        {
            try
            {
                var objCurrency = taWfGetDocTypes.GetCurrencySign(sessionId, cmbDocType.SelectedValue.ToString());
                var signCurrency = Convert.ToInt16(objCurrency ?? 2);

                switch (signCurrency)
                {
                    case 0:
                        cbForeignCurrency.Checked = false;
                        cbForeignCurrency.Enabled = false;
                        break;
                    case 1:
                        cbForeignCurrency.Checked = true;
                        cbForeignCurrency.Enabled = false;
                        break;
                    case 2:
                    default:
                        cbForeignCurrency.Checked = false;
                        cbForeignCurrency.Enabled = true;
                        break;
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось получить признак использования иностранной валюты! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Загрузка списка поставщиков
        /// </summary>
        /// <returns></returns>
        private bool LoadSuppliers()
        {
            try
            {
                cbSelectSupplier_CheckedChanged(cbSelectSupplier, EventArgs.Empty);

                suppliersTableAdapter.Fill(wH.Suppliers);
                if (wH.Suppliers.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Список доступных поставщиков пустой! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    #region ПРОВЕРКА ДОСТУПА

                    var access = (int?)null;
                    suppliersTableAdapter.CheckAccess(sessionId, ref access);

                    if (!access.HasValue || (access.HasValue && !Convert.ToBoolean(access.Value)))
                    {
                        cbSelectSupplier.Enabled = false;
                        ecbSuppliers.Enabled = false;

                        cbSelectSupplier.Tag = "deny";
                    }

                    #endregion

                    if (isEditMode)
                    {
                        var selectSupplier = currentRow.IsShip_to_VendorNull() ? false : currentRow.Ship_to_Vendor;
                        if (selectSupplier)
                        {
                            var supplierID = currentRow.IsShip_Vendor_IDNull() ? (int?)null : currentRow.Ship_Vendor_ID;
                            if (supplierID.HasValue)
                            {
                                ecbSuppliers.SelectedValue = supplierID.Value;
                                cbSelectSupplier.Checked = true;
                            }
                        }

                        cbSelectSupplier.Enabled = false;
                        ecbSuppliers.Enabled = false;

                        cbSelectSupplier.Tag = "deny";
                    }
                    else
                    {
                        ecbSuppliers.SelectedIndex = 0;
                    }

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список доступных поставщиков! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        private void cbSelectSupplier_CheckedChanged(object sender, EventArgs e)
        {
            ecbSuppliers.Enabled = cbSelectSupplier.Checked;
        }

        /// <summary>
        /// Создание пустого документа
        /// </summary>
        /// <returns>True, если создание прошло успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool CreateEmptyDoc()
        {
            try
            {
                var isNotBalance = cbIsNotBalance.Enabled ? cbIsNotBalance.Checked : (bool?)null;

                docID = Convert.ToInt32(taWfGetDocsDetail.CreateDocs(sessionId,
                    cmbWarehouses.SelectedValue.ToString(), cmbDocType.SelectedValue.ToString(),
                    cmbJDE.SelectedValue == null ? (string)null : cmbJDE.SelectedValue.ToString(), null, null, null, null, null, null, cbSimpleAct.Checked ? 1 : 0, cbForeignCurrency.Checked ? 1 : 0, (bool?)null, (int?)null, isNotBalance, (string)null));
                if (!docID.HasValue)
                {
                    MessageBox.Show("Не удалось создать заготовку для макета! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    tbxID.Text = docID.Value.ToString();
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при создании заготовки для макета! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Загрузка доступных для выбора ответственных пользователей
        /// </summary>
        /// <returns>True, если загрузка прошла успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool LoadApprovers()
        {
            try
            {
                taWfGetApproverList.Fill(wH.WF_GetApproverList, sessionId, cmbDocType.SelectedValue.ToString());

                if (wH.WF_GetApproverList.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Список ответственных пользователей пустой! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    if (isEditMode)
                        cmbApprover.SelectedValue = currentRow.Approver_ID;
                    else
                        cmbApprover.SelectedIndex = 0;

                    cmbDocType.SelectedIndexChanged -= cmbDocType_SelectedIndexChanged;
                    cmbDocType.SelectedIndexChanged += cmbDocType_SelectedIndexChanged;

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список ответственных пользователей! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Настройка видимости выпадающего списка с инвентаризациями, если происходит списание недостач
        /// </summary>
        private void CustomInventoryCombobox()
        {
            if (cmbDocType.SelectedValue != null && cmbDocType.SelectedValue.ToString() == "SN")
                cmbInventory.Visible = lblInventory.Visible = true;
            else
                cmbInventory.Visible = lblInventory.Visible = false;

            label1.Visible = cmbApprover.Visible = cmbDocType.SelectedValue != null && !cmbDocType.SelectedValue.Equals("SM");
        }

        /// <summary>
        /// Загрузка списка типов документов JDE
        /// </summary>
        /// <returns>True, если загрузка прошла успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool LoadJDEDocTypes()
        {
            try
            {
                taWfGetJDEDocTypes.Fill(wH.WF_GetJDEDocTypes, sessionId);
                if (wH.WF_GetJDEDocTypes.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Список типов документов JDE пустой! Дальнейшее редактирование макета невозможно!");
                    return false;
                }
                else
                {
                    if (isEditMode)
                        cmbJDE.SelectedValue = currentRow.JDE_Doc_Type;
                    else
                        //cmbJDE.SelectedIndex = 0;
                        cmbJDE.SelectedItem = null;
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список типов документов JDE! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        private void cmbJDE_SelectedValueChanged(object sender, EventArgs e)
        {
            CustomizeSuppliers();

            if (cmbJDE.SelectedValue == null)
                return;

            // SD 281931 Списание лабораторных анализов
            if (cmbJDE.SelectedValue.ToString().Equals("T4", StringComparison.OrdinalIgnoreCase) || cmbJDE.SelectedValue.ToString().Equals("TC", StringComparison.OrdinalIgnoreCase))
                cbIsNotBalance.Checked = true;
        }

        private void CustomizeSuppliers()
        {
            var selectSMDocType = cmbDocType.SelectedValue != null && cmbDocType.SelectedValue.ToString().Equals("SM", StringComparison.OrdinalIgnoreCase);
            var selectT5JDE = cmbJDE.SelectedValue != null && cmbJDE.SelectedValue.ToString().Equals("T5", StringComparison.OrdinalIgnoreCase);

            var isSuppliersActive = selectSMDocType && selectT5JDE && cbSelectSupplier.Tag == null; // Есть доступ к изменению

            cbSelectSupplier.Checked = isSuppliersActive;
            cbSelectSupplier.Enabled = isSuppliersActive;
            ecbSuppliers.Enabled = isSuppliersActive;
        }

        /// <summary>
        /// Загрузка строк документа
        /// </summary>
        /// <returns>True, если создание прошло успешно и можно продолжать работу с формой, 
        /// False если дальнейшее редактирование невозможно и форму нужно закрыть</returns>
        private bool LoadDocLines()
        {
            try
            {
                taWfGetDocsDetail.Fill(wH.WF_GetDocs_Detail, sessionId, docID);
                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить строки в макете! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
        }

        /// <summary>
        /// Инициализация полей формы текущими значениями свойств макета списания
        /// </summary>
        private void InitFormWhenEditMode()
        {
            tbxID.Text = docID.ToString();
            cmbWarehouses.Enabled = false;
            tbxDescription.Text = currentRow.Desc;

            if (cbForeignCurrency.Enabled)
                cbForeignCurrency.Checked = Convert.ToBoolean(currentRow.IsIS_Foreign_CurrencyNull() ? 0 : currentRow.IS_Foreign_Currency);

            cbIsNotBalance.Checked = currentRow.IsIsNotBalanceNull() ? false : currentRow.IsNotBalance;

            tbxActComment.Text = currentRow.IsAct_CommentNull() ? (string)null : currentRow.Act_Comment;
        }

        /// <summary>
        /// Загрузка доступных для выбора инвентаризаций
        /// </summary>
        private void LoadInventories()
        {
            try
            {
                taWfGetInventarizationList.Fill(wH.WF_GetInventarizationList, sessionId, cmbWarehouses.SelectedValue.ToString());
                if (wH.WF_GetInventarizationList.Count > 0)
                {
                    if (isEditMode && !currentRow.IsInventory_IDNull())
                        cmbInventory.SelectedValue = currentRow.Inventory_ID;
                    else
                        cmbInventory.SelectedIndex = 0;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список доступных инвентаризаций!", exc);
            }
        }

        /// <summary>
        /// Обновление записей по нажатию кнопки F5
        /// </summary>
        private void CreateWriteOffStuffForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
                StartRemainsLoading();
        }

        #endregion

        #region АСИНХРОННАЯ ЗАГРУЗКА ОСТАТКОВ

        /// <summary>
        /// Поток загрузки, который был вызван последним (для того, чтобы можно было не дожидаясь конца загрузки еще раз поменять склад)
        /// </summary>
        private BackgroundWorker lastWorker;

        /// <summary>
        /// Обновление остатков, если был изменен выбранный склад
        /// </summary>
        private void cmbWarehouses_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadInventories();
            RemoveExistedItems();
        }

        /// <summary>
        /// Удаление уже добавленных в документ товаров при изменении склада
        /// </summary>
        private void RemoveExistedItems()
        {
            try
            {
                foreach (DataGridViewRow row in dgvDocLines.Rows)
                {
                    var newItem = (row.DataBoundItem as DataRowView).Row as Data.WH.WF_GetDocs_DetailRow;
                    taWfGetDocsDetail.AddDocRow(sessionId, docID, cmbWarehouses.SelectedValue.ToString(), newItem.Location_ID,
                        newItem.Item_ID, newItem.Batch_ID, 0);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при очистке уже добавленных товаров при изменении склада!" +
                    " Дальнейшее добавление товаров может вызвать ошибки! Перезагрузите форму редактирования!", exc);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartRemainsLoading();
        }

        /// <summary>
        /// Запуск асинхронной загрузки остатков
        /// </summary>
        private void StartRemainsLoading()
        {
            lastWorker = new BackgroundWorker();
            lastWorker.DoWork += lastWorker_DoWork;
            lastWorker.RunWorkerCompleted += lastWorker_RunWorkerCompleted;
            dgvRemains.Enabled = false;
            pbWait.Visible = true;
            lastWorker.RunWorkerAsync(new WriteOffStuffRemainsSearchParameters
                {
                    SessionID = sessionId,
                    WarehouseID = cmbWarehouses.SelectedValue.ToString(),
                    RemainsFilter = remainsFilter
                });
        }

        /// <summary>
        /// Асинхронная загрузка остатков
        /// </summary>
        private void lastWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as WriteOffStuffRemainsSearchParameters;

                dgvRemains.DataView.FillData(sc);
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
                {
                    Logger.ShowErrorMessageBox("Во время загрузки остатков произошла ошибка!", e.Result as Exception);
                }
                else
                {
                    dgvRemains.BindData(false);
                }

                pbWait.Visible = false;
                dgvRemains.Enabled = true;
            }
        }

        /// <summary>
        /// Обновление 
        /// </summary>
        /// <param name="pTable"></param>
        private void RefreshDataViewBinding(Data.WH.WF_GetItem_RemainsDataTable pTable)
        {
            try
            {
                dgvRemains.DataView.FillData(new WriteOffStuffRemainsSearchParameters
                {
                    SessionID = sessionId,
                    WarehouseID = cmbWarehouses.SelectedValue.ToString()
                });
                dgvRemains.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке остатков!", exc);
            }
        }

        #endregion

        #region КЛАСС ФИЛЬТРОВ ДЛЯ ПОЛУЧЕНИЯ ОСТАТКОВ

        /// <summary>
        /// Класс фильтров для получения остатков
        /// </summary>
        public class RemainsFilter
        {
            /// <summary>
            /// Фильтр по месту
            /// </summary>
            public string LocationIDFilter { get; set; }

            /// <summary>
            /// Фильтр по идентификатору товара
            /// </summary>
            public string ItemIDFilter { get; set; }

            /// <summary>
            /// Фильтр по товару
            /// </summary>
            public string ItemFilter { get; set; }

            /// <summary>
            /// Фильтр по производителю
            /// </summary>
            public string ManufacturerFilter { get; set; }

            /// <summary>
            /// Фильтр по серии
            /// </summary>
            public string LotNumberFilter { get; set; }

            /// <summary>
            /// Фильтр по партии
            /// </summary>
            public string BatchIdFilter { get; set; }

            /// <summary>
            /// Фильтр по единице измерения
            /// </summary>
            public string UomFilter { get; set; }

            /// <summary>
            /// Фильтр по признаку НДС
            /// </summary>
            public string VatFilter { get; set; }

            /// <summary>
            /// Фильтр по коду задержки
            /// </summary>
            public string LotStatusFilter { get; set; }

            /// <summary>
            /// Фильтр по сроку годности
            /// </summary>
            public string ExpirationDateFilter { get; set; }

            /// <summary>
            /// Фильтр по менеджеру отдела закупок
            /// </summary>
            public string MozFilter { get; set; }

            /// <summary>
            /// Фильтр по поставщику
            /// </summary>
            public string VendorFilter { get; set; }

            public RemainsFilter()
            {
                LocationIDFilter = ItemIDFilter = ItemFilter = ManufacturerFilter =
                    LotNumberFilter = BatchIdFilter = UomFilter = VatFilter = LotStatusFilter =
                    ExpirationDateFilter = MozFilter = VendorFilter = null;
            }

            /// <summary>
            /// True если ни один из фильтров не задан, False если установлен хотя бы один из фильтров
            /// </summary>
            public bool IsEmpty
            {
                get
                {
                    return String.IsNullOrEmpty(LocationIDFilter) && String.IsNullOrEmpty(ItemIDFilter) && String.IsNullOrEmpty(ItemFilter) &&
                        String.IsNullOrEmpty(ManufacturerFilter) && String.IsNullOrEmpty(LotNumberFilter) && String.IsNullOrEmpty(BatchIdFilter) &&
                        String.IsNullOrEmpty(UomFilter) && String.IsNullOrEmpty(VatFilter) && String.IsNullOrEmpty(LotStatusFilter) &&
                        String.IsNullOrEmpty(ExpirationDateFilter) && String.IsNullOrEmpty(MozFilter) && String.IsNullOrEmpty(VendorFilter);
                }
            }

            /// <summary>
            /// Проверка, соответствуют ли установленные в фильтрах грида параметры сохраненным в классе
            /// </summary>
            /// <param name="pSettedFilters">Значения в фильтрах грида</param>
            /// <returns>True если установленные в фильтрах грида параметры соответствуют сохраненным в классе,
            /// False если не соответствуют (в таком случае грид)</returns>
            public bool IsEquals(Dictionary<string, string> pSettedFilters)
            {
                string val = null;
                bool result = false;

                // Место
                result = pSettedFilters.TryGetValue("Location_ID", out val);
                if (String.IsNullOrEmpty(LocationIDFilter) && result || !String.IsNullOrEmpty(LocationIDFilter) && !result ||
                    result && LocationIDFilter != val)
                    return false;

                // Идентификатор товара
                result = pSettedFilters.TryGetValue("Item_ID", out val);
                if (String.IsNullOrEmpty(ItemIDFilter) && result || !String.IsNullOrEmpty(ItemIDFilter) && !result ||
                    result && ItemIDFilter != val)
                    return false;

                // Наименование товара
                result = pSettedFilters.TryGetValue("Item", out val);
                if (String.IsNullOrEmpty(ItemFilter) && result || !String.IsNullOrEmpty(ItemFilter) && !result ||
                    result && ItemFilter != val)
                    return false;

                // Производитель
                result = pSettedFilters.TryGetValue("Manufacturer", out val);
                if (String.IsNullOrEmpty(ManufacturerFilter) && result || !String.IsNullOrEmpty(ManufacturerFilter) && !result ||
                    result && ManufacturerFilter != val)
                    return false;

                // Серия
                result = pSettedFilters.TryGetValue("LotNumber", out val);
                if (String.IsNullOrEmpty(LotNumberFilter) && result || !String.IsNullOrEmpty(LotNumberFilter) && !result ||
                    result && LotNumberFilter != val)
                    return false;

                // Партия
                result = pSettedFilters.TryGetValue("Batch_ID", out val);
                if (String.IsNullOrEmpty(BatchIdFilter) && result || !String.IsNullOrEmpty(BatchIdFilter) && !result ||
                    result && BatchIdFilter != val)
                    return false;

                // Единица измерения
                result = pSettedFilters.TryGetValue("UOM", out val);
                if (String.IsNullOrEmpty(UomFilter) && result || !String.IsNullOrEmpty(UomFilter) && !result ||
                    result && UomFilter != val)
                    return false;

                // НДС
                result = pSettedFilters.TryGetValue("VAT", out val);
                if (String.IsNullOrEmpty(VatFilter) && result || !String.IsNullOrEmpty(VatFilter) && !result ||
                    result && VatFilter != val)
                    return false;

                // Код задержки
                result = pSettedFilters.TryGetValue("LotStatus", out val);
                if (String.IsNullOrEmpty(LotStatusFilter) && result || !String.IsNullOrEmpty(LotStatusFilter) && !result ||
                    result && LotStatusFilter != val)
                    return false;

                // Срок годности
                result = pSettedFilters.TryGetValue("ExpirationDate", out val);
                if (String.IsNullOrEmpty(ExpirationDateFilter) && result || !String.IsNullOrEmpty(ExpirationDateFilter) && !result ||
                    result && ExpirationDateFilter != val)
                    return false;

                // Менеджер отдела закупок
                result = pSettedFilters.TryGetValue("MOZ", out val);
                if (String.IsNullOrEmpty(MozFilter) && result || !String.IsNullOrEmpty(MozFilter) && !result ||
                    result && MozFilter != val)
                    return false;

                // Поставщик
                result = pSettedFilters.TryGetValue("Vendor", out val);
                if (String.IsNullOrEmpty(VendorFilter) && result || !String.IsNullOrEmpty(VendorFilter) && !result ||
                    result && VendorFilter != val)
                    return false;

                return true;
            }

            /// <summary>
            /// Сохранение в классе настроек, которые были установлены на фильтрах грида
            /// </summary>
            /// <param name="pSettedFilters">Значения в фильтрах грида</param>
            public void SaveFilters(Dictionary<string, string> pSettedFilters)
            {
                string val = null;
                bool result = false;

                // Место
                result = pSettedFilters.TryGetValue("Location_ID", out val);
                LocationIDFilter = result ? val : null;

                // Идентификатор товара
                result = pSettedFilters.TryGetValue("Item_ID", out val);
                ItemIDFilter = result ? val : null;

                // Наименование товара
                result = pSettedFilters.TryGetValue("Item", out val);
                ItemFilter = result ? val : null;

                // Производитель
                result = pSettedFilters.TryGetValue("Manufacturer", out val);
                ManufacturerFilter = result ? val : null;

                // Серия
                result = pSettedFilters.TryGetValue("LotNumber", out val);
                LotNumberFilter = result ? val : null;

                // Партия
                result = pSettedFilters.TryGetValue("Batch_ID", out val);
                BatchIdFilter = result ? val : null;

                // Единица измерения
                result = pSettedFilters.TryGetValue("UOM", out val);
                UomFilter = result ? val : null;

                // НДС
                result = pSettedFilters.TryGetValue("VAT", out val);
                VatFilter = result ? val : null;

                // Код задержки
                result = pSettedFilters.TryGetValue("LotStatus", out val);
                LotStatusFilter = result ? val : null;

                // Срок годности
                result = pSettedFilters.TryGetValue("ExpirationDate", out val);
                ExpirationDateFilter = result ? val : null;

                // Менеджер отдела закупок
                result = pSettedFilters.TryGetValue("MOZ", out val);
                MozFilter = result ? val : null;

                // Поставщик
                result = pSettedFilters.TryGetValue("Vendor", out val);
                VendorFilter = result ? val : null;
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ И УДАЛЕНИЕ ТОВАРОВ ИЗ ДОКУМЕНТА СПИСАНИЯ

        /// <summary>
        /// Настройка доступности кнопки "добавить товар" в зависимости от выбранных строк в таблице остатков
        /// </summary>
        private void dgvRemains_OnRowSelectionChanged(object sender, EventArgs e)
        {
            btnAddToDoc.Enabled = dgvRemains.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Настройка доступности кнопки "удалить товар" в зависимости от выбранных строк в таблице товаров в документе
        /// </summary>
        private void dgvDocLines_SelectionChanged(object sender, EventArgs e)
        {
            btnRemoveFromDoc.Enabled = dgvDocLines.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Добавление товаров в документ списания
        /// </summary>
        private void btnAddToDoc_Click(object sender, EventArgs e)
        {
            foreach (Data.WH.WF_GetItem_RemainsRow row in dgvRemains.SelectedItems)
                try
                {
                    Data.WH.WF_GetDocs_DetailRow existedItem = null;
                    foreach (Data.WH.WF_GetDocs_DetailRow existedRow in wH.WF_GetDocs_Detail)
                        if (row.Item_ID == existedRow.Item_ID && row.Location_ID.Trim() == existedRow.Location_ID.Trim() &&
                            row.Batch_ID.Trim() == existedRow.Batch_ID.Trim())
                        {
                            existedItem = existedRow;
                            break;
                        }
                    taWfGetDocsDetail.AddDocRow(sessionId, docID, cmbWarehouses.SelectedValue.ToString(), row.Location_ID,
                        Convert.ToInt32(row.Item_ID), row.Batch_ID, row.Quantity + (existedItem == null ? 0 : existedItem.Quantity));
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Не удалось добавить товар в макет списания: ", exc);
                }

            LoadDocLines();
            StartRemainsLoading();
        }

        /// <summary>
        /// Удаление товаров из документа списания
        /// </summary>
        private void btnRemoveFromDoc_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocLines.SelectedRows)
                try
                {
                    var newItem = (row.DataBoundItem as DataRowView).Row as Data.WH.WF_GetDocs_DetailRow;
                    taWfGetDocsDetail.AddDocRow(sessionId, docID, cmbWarehouses.SelectedValue.ToString(), newItem.Location_ID,
                        newItem.Item_ID, newItem.Batch_ID, 0);
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Не удалось удалить товар из макета списания: ", exc);
                }

            LoadDocLines();
            StartRemainsLoading();
        }

        /// <summary>
        /// Редактирование количества товара в накладной в БД
        /// </summary>
        private void dgvDocLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var newItem = ((dgvDocLines.Rows[e.RowIndex]).DataBoundItem as DataRowView).Row as Data.WH.WF_GetDocs_DetailRow;
                taWfGetDocsDetail.AddDocRow(sessionId, docID, cmbWarehouses.SelectedValue.ToString(), newItem.Location_ID,
                    newItem.Item_ID, newItem.Batch_ID, newItem.Quantity);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось изменить количество товара в макете списания: ", exc);
            }

            LoadDocLines();
            StartRemainsLoading();
        }

        /// <summary>
        /// Проверка вводимого количества на корректность
        /// </summary>
        private void dgvDocLines_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (dgvDocLines.Columns[e.ColumnIndex].Name != "clQuantity")
                return;

            int num;

            if (String.IsNullOrEmpty(e.FormattedValue.ToString()) || !Int32.TryParse(e.FormattedValue.ToString(), out num) ||
                num < 0)
            {
                MessageBox.Show("Количество должно быть неотрицательным целым числом!", "Неверно задано количество",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        #endregion

        #region ИМПОРТ ДАННЫХ ИЗ EXCEL

        /// <summary>
        /// Импорт товаров из Excel
        /// </summary>
        private void btnExcelImport_Click(object sender, EventArgs e)
        {
            var window = new CreateWriteOffStuffExcelForm(sessionId, cmbWarehouses.SelectedValue.ToString());
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                foreach (var importedRow in window.Data)
                    try
                    {
                        Data.WH.WF_GetDocs_DetailRow existedItem = null;
                        foreach (Data.WH.WF_GetDocs_DetailRow existedRow in wH.WF_GetDocs_Detail)
                            if (importedRow.ItemId == existedRow.Item_ID && importedRow.Location.Trim() == existedRow.Location_ID.Trim() &&
                                importedRow.BatchID.Trim() == existedRow.Batch_ID.Trim())
                            {
                                existedItem = existedRow;
                                break;
                            }
                        taWfGetDocsDetail.AddDocRow(sessionId, docID, cmbWarehouses.SelectedValue.ToString(), importedRow.Location,
                            Convert.ToInt32(importedRow.ItemId), importedRow.BatchID,
                            importedRow.Quantity + (existedItem == null ? 0 : existedItem.Quantity));
                    }
                    catch (Exception exc)
                    {
                        Logger.ShowErrorMessageBox("Не удалось добавить товар в макет списания: ", exc);
                    }
                LoadDocLines();
                StartRemainsLoading();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// True, если окно закрывается посредством кнопки "Сохранить", False в противном случае
        /// </summary>
        private bool closingBySave;

        /// <summary>
        /// Если был создан пустой документ, и окно закрывается без нажатия на кнопку СОХРАНИТЬ - удаляем его
        /// </summary>
        private void CreateWriteOffStuffForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!closingBySave && !isEditMode)
                RemoveEmptyDoc();
            lastWorker = null;
        }

        /// <summary>
        /// Удаление пустого документа
        /// </summary>
        private void RemoveEmptyDoc()
        {
            try
            {
                taWfGetDocsDetail.DeleteDoc(sessionId, docID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при удалении созданного пустого документа!", exc);
            }
        }

        /// <summary>
        /// Сохранение редактирования
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int? inventoryId = null;
                if (cmbDocType.SelectedValue.ToString() == "SN" && cmbInventory.SelectedItem == null)
                {
                    MessageBox.Show("Для типа СПИСАНИЕ НЕДОСТАЧ должна быть обязательно указана инвентаризация!", "Неверные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                else
                    inventoryId = cmbInventory.SelectedValue == null ? (int?)null : Convert.ToInt32(cmbInventory.SelectedValue.ToString());

                if (cmbJDE.SelectedItem == null)
                    throw new Exception("Не выбран тип документа JDE.");

                var selectSupplier = cbSelectSupplier.Checked;

                if (selectSupplier && ecbSuppliers.SelectedValue == null)
                    throw new Exception("Не выбран поставщик.");

                var supplierID = selectSupplier ? Convert.ToInt32(ecbSuppliers.SelectedValue) : (int?)null;

                var actComment = string.IsNullOrEmpty(tbxActComment.Text.Trim()) ? (string)null : tbxActComment.Text.Trim();

                var description = tbxDescription.Text.Substring(0, Math.Min(tbxDescription.Text.Length, 50));

                var isNotBalance = cbIsNotBalance.Enabled ? cbIsNotBalance.Checked : (bool?)null;

                taWfGetDocsDetail.CreateDocs(sessionId, cmbWarehouses.SelectedValue.ToString(), cmbDocType.SelectedValue.ToString(),
                    cmbJDE.SelectedValue.ToString(), description, Convert.ToInt32(cmbApprover.SelectedValue), docID,
                    cmbDocType.SelectedValue.ToString() == "SN" ? (int?)inventoryId : null, null, dtpDocDate.Value, cbSimpleAct.Checked ? 1 : 0, cbForeignCurrency.Checked ? 1 : 0,
                    selectSupplier, supplierID,
                    isNotBalance,
                    actComment);

                closingBySave = true;
                this.DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при сохранении макета списания!", exc);
            }
        }

        #endregion
    }

    #region КЛАССЫ ДЛЯ РЕАЛИЗАЦИИ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ СПИСАНИЯ

    /// <summary>
    /// Представление для грида с остатками на непродажных складах
    /// </summary>
    public class WriteOffStuffRemainsView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as WriteOffStuffRemainsSearchParameters;
            using (var adapter = new WF_GetItem_RemainsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                data = adapter.GetData(sc.SessionID, sc.WarehouseID, sc.RemainsFilter.LocationIDFilter,
                    String.IsNullOrEmpty(sc.RemainsFilter.ItemIDFilter) ? null : (int?)Convert.ToInt32(sc.RemainsFilter.ItemIDFilter.Substring(1)),
                    sc.RemainsFilter.ItemFilter, sc.RemainsFilter.ManufacturerFilter, sc.RemainsFilter.LotNumberFilter,
                    sc.RemainsFilter.BatchIdFilter, sc.RemainsFilter.UomFilter, sc.RemainsFilter.VatFilter, sc.RemainsFilter.LotStatusFilter,
                    sc.RemainsFilter.ExpirationDateFilter, sc.RemainsFilter.MozFilter, sc.RemainsFilter.VendorFilter);
            }
        }

        public WriteOffStuffRemainsView()
        {
            this.dataColumns.Add(new PatternColumn("Место", "Location_ID", new FilterPatternExpressionRule("Location_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("ID товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Наименование товара", "Item", new FilterPatternExpressionRule("Item")));
            this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Серия", "LotNumber", new FilterPatternExpressionRule("LotNumber")));
            this.dataColumns.Add(new PatternColumn("Партия", "Batch_ID", new FilterPatternExpressionRule("Batch_ID")));
            this.dataColumns.Add(new PatternColumn("ЕИ", "UOM", new FilterPatternExpressionRule("UOM"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("НДС", "VAT", new FilterPatternExpressionRule("VAT")));
            this.dataColumns.Add(new PatternColumn("Кол-во", "Quantity", new FilterCompareExpressionRule<Double>("Quantity")));
            this.dataColumns.Add(new PatternColumn("Итог. сумма", "Amount_UAH", new FilterCompareExpressionRule<Double>("Amount_UAH")));
            this.dataColumns.Add(new PatternColumn("Код задержки", "LotStatus", new FilterPatternExpressionRule("LotStatus"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Цена", "Price", new FilterCompareExpressionRule<Double>("Price")));
            this.dataColumns.Add(new PatternColumn("Валюта", "VInvCurrency", new FilterPatternExpressionRule("VInvCurrency"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Срок годности", "ExpirationDate", new FilterDateCompareExpressionRule("ExpirationDate")));
            this.dataColumns.Add(new PatternColumn("МОЗ", "MOZ", new FilterPatternExpressionRule("MOZ"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Поставщик", "Vendor", new FilterPatternExpressionRule("Vendor"), SummaryCalculationType.Count));
        }
    }

    /// <summary>
    /// Параметры получения списка макетов списания
    /// </summary>
    public class WriteOffStuffRemainsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }

        /// <summary>
        /// Идентификатор склада, по которому нужно получить макеты списания
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Фильтры, которые вводятся в заголовках таблицы
        /// </summary>
        public CreateWriteOffStuffForm.RemainsFilter RemainsFilter { get; set; }
    }

    #endregion
}
