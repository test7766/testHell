using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.WHTableAdapters;

namespace WMSOffice.Dialogs.WH
{
    [Obsolete("Данный интерфейс нигде не используется")]
    public partial class ManufacturerWriteOffStuffForm : Form
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
        private readonly WMSOffice.Dialogs.WH.CreateWriteOffStuffForm.RemainsFilter remainsFilter =
            new WMSOffice.Dialogs.WH.CreateWriteOffStuffForm.RemainsFilter();

        /// <summary>
        /// Поток загрузки, который был вызван последним (для того, чтобы можно было не дожидаясь конца загрузки еще раз поменять склад)
        /// </summary>
        private BackgroundWorker lastWorker;

        #endregion

        public ManufacturerWriteOffStuffForm(int pUserId)
        {
            InitializeComponent();
            sessionId = pUserId;
            InitializeWriteOffRemainsGrid();
        }

        public ManufacturerWriteOffStuffForm(int pUserId, Data.WH.WF_GetDocsRow pEditRow)
            : this(pUserId)
        {
            isEditMode = true;
            docID = pEditRow.Doc_ID;
            currentRow = pEditRow;
            dtpDocDate.Value = pEditRow.DocDate;

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!LoadWarehouses() || !LoadDocTypes() || !LoadJDEDocTypes() || !LoadApprovers())
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
        /// Добавление товаров в документ списания
        /// </summary>
        private void btnAddToDoc_Click(object sender, EventArgs e)
        {
            var dt = (dgvRemains.DataView as WriteOffStuffRemainsView).Data;

            if (dt == null)
                (dgvRemains.DataView as WriteOffStuffRemainsView).FillData(wH.WF_GetItem_Remains);

            var m_count = dgvDocLines.SelectedItems.Count;
            foreach (Data.WH.WF_GetDocs_DetailRow row in dgvDocLines.SelectedItems)
                try
                {
                    WMSOffice.Data.WH.WF_GetItem_RemainsRow _row = FindRowDetail(wH.WF_GetItem_Remains, row);
                    if (_row == null)
                    {
                        _row = wH.WF_GetItem_Remains.AddWF_GetItem_RemainsRow(row.Location_ID, row.Item_ID, row.Item, row.Manufacturer.Substring(0, wH.WF_GetItem_Remains.ManufacturerColumn.MaxLength),
                               row.Lot_Number, row.Batch_ID, row.UOM.Substring(0, wH.WF_GetItem_Remains.UOMColumn.MaxLength), row.VAT, row.Quantity, (double)row.Amount_UAH, row.LotStatus, (double)row.Price,
                               String.Empty, row.ExpirationDate, row.MOZ, row.Vendor);

                        var frm = new ManufacturerWriteOffQuantityForm()
                        {
                            Item = _row,
                            Owner = this,
                            MaxQuantity = row.Quantity,
                            Quantity = row.Quantity
                        };

                        if (m_count == 1)
                        {
                            if (frm.ShowDialog() == DialogResult.Cancel)
                            {

                                wH.WF_GetItem_Remains.RemoveWF_GetItem_RemainsRow(_row);
                                continue;
                            }

                            _row.Quantity = frm.Quantity;
                        }
                        row.Quantity -= frm.Quantity;
                    }
                    else
                    {
                        var frm = new ManufacturerWriteOffQuantityForm()
                        {
                            Item = _row,
                            Owner = this,
                            MaxQuantity = row.Quantity,
                            Quantity = row.Quantity
                        };

                        if (dgvDocLines.SelectedItems.Count == 1)
                        {
                            if (frm.ShowDialog() == DialogResult.Cancel)
                                continue;

                            _row.Quantity += frm.Quantity;
                        }
                        else
                            _row.Quantity += row.Quantity;

                        row.Quantity -= frm.Quantity;
                    }

                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Не удалось добавить товар в макет списания: ", exc);
                }
            dgvRemains.BindData(false);
        }

        /// <summary>
        /// Удаление товаров из документа списания
        /// </summary>
        private void btnRemoveFromDoc_Click(object sender, EventArgs e)
        {
            var dt = (dgvDocLines.DataView as WriteOffStuffLinesView).Data;

            if (dt == null)
                (dgvDocLines.DataView as WriteOffStuffRemainsView).FillData(wH.WF_GetDocs_Detail);

            var m_count = dgvRemains.SelectedItems.Count;

            foreach (Data.WH.WF_GetItem_RemainsRow row in dgvRemains.SelectedItems)
                try
                {
                    //wH.WF_GetDocs_Detail.AddWF_GetDocs_DetailRow(-1, row.Location_ID, (int)row.Item_ID, row.Item, row.Manufacturer,
                    //    row.VAT, row.LotNumber, row.Batch_ID, row.ExpirationDate, row.Quantity, (decimal)row.Amount_UAH, (decimal)row.Price,
                    //    row.LotStatus, -1, row.MOZ, row.Vendor, row.UOM, -1);

                    var fRow = FindRowDetail(wH.WF_GetDocs_Detail, row);
                    if (fRow == null)
                        continue;

                    if (m_count == 1)
                    {
                        var frm = new ManufacturerWriteOffQuantityForm()
                        {
                            Item = row,
                            Owner = this,
                            MaxQuantity = row.Quantity,
                            Quantity = row.Quantity
                        };

                        if (frm.ShowDialog() == DialogResult.Cancel)
                            continue;

                        fRow.Quantity += (row.Quantity - frm.Quantity);
                        row.Quantity = frm.Quantity;
                        if (frm.Quantity == frm.MaxQuantity)
                            wH.WF_GetItem_Remains.RemoveWF_GetItem_RemainsRow(row);
                    }
                    else
                    {
                        fRow.Quantity += row.Quantity;
                        wH.WF_GetItem_Remains.RemoveWF_GetItem_RemainsRow(row);
                    }
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Не удалось добавить товар в макет списания: ", exc);
                }

            dgvRemains.BindData(false);
        }


        /// <summary>
        /// Поиск строки списания
        /// </summary>
        /// <param name="wF_GetDocs_DetailDataTable"></param>
        /// <param name="findRow"></param>
        /// <returns></returns>
        private WMSOffice.Data.WH.WF_GetDocs_DetailRow FindRowDetail(WMSOffice.Data.WH.WF_GetDocs_DetailDataTable wF_DataTable,
            WMSOffice.Data.WH.WF_GetItem_RemainsRow findRow)
        {
            foreach (var item in wF_DataTable.Rows)
            {
                var row = item as WMSOffice.Data.WH.WF_GetDocs_DetailRow;
                if (row == null)
                    continue;

                if (row.Location_ID == findRow.Location_ID && row.Item_ID == findRow.Item_ID
                    && row.Lot_Number == findRow.LotNumber && row.Batch_ID == findRow.Batch_ID)
                    return row;
            }
            return null;
        }

        /// <summary>
        /// Поиск строки списания производителем
        /// </summary>
        /// <param name="wF_GetDocs_DetailDataTable"></param>
        /// <param name="findRow"></param>
        /// <returns></returns>
        private WMSOffice.Data.WH.WF_GetItem_RemainsRow FindRowDetail(WMSOffice.Data.WH.WF_GetItem_RemainsDataTable wF_DataTable,
            WMSOffice.Data.WH.WF_GetDocs_DetailRow findRow)
        {
            foreach (var item in wF_DataTable.Rows)
            {
                var row = item as WMSOffice.Data.WH.WF_GetItem_RemainsRow;
                if (row == null)
                    continue;

                if (row.Location_ID == findRow.Location_ID && row.Item_ID == findRow.Item_ID
                    && row.LotNumber == findRow.Lot_Number && row.Batch_ID == findRow.Batch_ID)
                    return row;
            }
            return null;
        }

        /// <summary>
        /// Сохранение редактирования
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //int? inventoryId = null;
                //if (cmbDocType.SelectedValue.ToString() == "SN" && cmbInventory.SelectedItem == null)
                //{
                //    MessageBox.Show("Для типа СПИСАНИЕ НЕДОСТАЧ должна быть обязательно указана инвентаризация!", "Неверные данные",
                //        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return;
                //}
                //else
                //    inventoryId = Convert.ToInt32(cmbInventory.SelectedValue.ToString());

                //taWfGetDocsDetail.CreateDocs(sessionId, cmbWarehouses.SelectedValue.ToString(), cmbDocType.SelectedValue.ToString(),
                //    cmbJDE.SelectedValue.ToString(), tbxDescription.Text, Convert.ToInt32(cmbApprover.SelectedValue), docID,
                //    cmbDocType.SelectedValue.ToString() == "SN" ? (int?)inventoryId : null, null, dtpDocDate.Value, cbSimpleAct.Checked ? 1 : 0);
                ////closingBySave = true;
                //Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при сохранении макета списания!", exc);
            }
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
                docID = Convert.ToInt32(taWfGetDocsDetail.CreateDocs(sessionId,
                    cmbWarehouses.SelectedValue.ToString(), cmbDocType.SelectedValue.ToString(),
                    cmbJDE.SelectedValue.ToString(), null, null, null, null, null, null, 1, cbForeignCurrency.Checked ? 1 : 0, (bool?)null, (int?)null, (bool?)null, (string)null));
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
        /// Настройка видимости выпадающего списка с инвентаризациями, если происходит списание недостач
        /// </summary>
        private void CustomInventoryCombobox()
        {
            if (cmbDocType.SelectedValue != null && cmbDocType.SelectedValue.ToString() == "SN")
                cmbInventory.Visible = lblInventory.Visible = true;
            else
                cmbInventory.Visible = lblInventory.Visible = false;
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с остатками
        /// </summary>
        private void InitializeWriteOffRemainsGrid()
        {
            dgvDocLines.Init(new WriteOffStuffLinesView(), true);
            dgvDocLines.LargeAmountOfData = true;
            dgvDocLines.LoadExtraDataGridViewSettings(ConfigLinesTableName);
            dgvDocLines.UserID = sessionId;
            //dgvDocLines.SetCellStyles(dgvRemains.RowTemplate.DefaultCellStyle, dgvRemains.ColumnHeadersDefaultCellStyle);
            dgvDocLines.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDocLines.AllowRangeColumns = true;
            dgvDocLines.UseMultiSelectMode = true;

            dgvDocLines.OnFilterChanged += dgvRemains_OnFilterChanged;
            dgvDocLines.OnRowSelectionChanged += dgvDocLines_OnRowSelectionChanged;

            dgvRemains.Init(new WriteOffStuffRemainsView(), true);
            dgvRemains.LargeAmountOfData = true;
            dgvRemains.LoadExtraDataGridViewSettings(ConfigRemainsTableName);
            dgvRemains.UserID = sessionId;
            //dgvDocLines.SetCellStyles(dgvRemains.RowTemplate.DefaultCellStyle, dgvRemains.ColumnHeadersDefaultCellStyle);
            dgvRemains.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvRemains.AllowRangeColumns = true;
            dgvRemains.UseMultiSelectMode = true;

            dgvRemains.OnFilterChanged += dgvRemains_OnFilterChanged;
            dgvRemains.OnRowSelectionChanged += dgvRemains_OnRowSelectionChanged;
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
                using (var adapter = new WF_GetItem_RemainsTableAdapter())
                {
                    adapter.SetTimeout(600);
                    e.Result = adapter.GetData(sc.SessionID, sc.WarehouseID, sc.RemainsFilter.LocationIDFilter,
                    String.IsNullOrEmpty(sc.RemainsFilter.ItemIDFilter) ? null : (int?)Convert.ToInt32(sc.RemainsFilter.ItemIDFilter.Substring(1)),
                    sc.RemainsFilter.ItemFilter, sc.RemainsFilter.ManufacturerFilter, sc.RemainsFilter.LotNumberFilter,
                    sc.RemainsFilter.BatchIdFilter, sc.RemainsFilter.UomFilter, sc.RemainsFilter.VatFilter, sc.RemainsFilter.LotStatusFilter,
                    sc.RemainsFilter.ExpirationDateFilter, sc.RemainsFilter.MozFilter, sc.RemainsFilter.VendorFilter);
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
                {
                    Logger.ShowErrorMessageBox("Во время загрузки остатков произошла ошибка!", e.Result as Exception);
                    (dgvRemains.DataView as WriteOffStuffRemainsView).FillData(new Data.WH.WF_GetItem_RemainsDataTable());
                }
                else
                {
                    var table = e.Result as Data.WH.WF_GetItem_RemainsDataTable;
                    if (table == null)
                    {
                        Logger.ShowErrorMessageBox("Процедура получения остатков вернула NULL!");
                        table = new Data.WH.WF_GetItem_RemainsDataTable();
                    }
                    (dgvRemains.DataView as WriteOffStuffRemainsView).FillData(table);

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

        /// <summary>
        /// Настройка доступности кнопки "добавить товар" в зависимости от выбранных строк в таблице остатков
        /// </summary>
        private void dgvDocLines_OnRowSelectionChanged(object sender, EventArgs e)
        {
            btnAddToDoc.Enabled = dgvDocLines.SelectedItems.Count > 0;
        }

        /// <summary>
        /// Настройка доступности кнопки "добавить товар" в зависимости от выбранных строк в таблице остатков
        /// </summary>
        private void dgvRemains_OnRowSelectionChanged(object sender, EventArgs e)
        {
            btnRemoveFromDoc.Enabled = dgvRemains.SelectedItems.Count > 0;
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
                (dgvDocLines.DataView as WriteOffStuffLinesView).FillData(wH.WF_GetDocs_Detail);
                dgvDocLines.BindData(false);
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
                        cmbJDE.SelectedIndex = 0;
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список типов документов JDE! Дальнейшее редактирование макета невозможно!", exc);
                return false;
            }
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
        /// Обновление остатков, если был изменен выбранный склад
        /// </summary>
        private void cmbWarehouses_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadInventories();
            //RemoveExistedItems();
        }

        /// <summary>
        /// Перезагрузка подписантов при изменении выделенного типа документа
        /// </summary>
        private void cmbDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocType.SelectedItem != null)
                LoadApprovers();
            //CustomInventoryCombobox();
        }

        #region КЛАССЫ ДЛЯ РЕАЛИЗАЦИИ ФИЛЬТРУЕМОГО ГРИДА С МАКЕТАМИ СПИСАНИЯ

        /// <summary>
        /// Представление для грида с остатками на непродажных складах
        /// </summary>
        public class WriteOffStuffRemainsView : IDataView
        {
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
                    data = adapter.GetData(sc.SessionID, sc.WarehouseID, sc.RemainsFilter.LocationIDFilter,
                        String.IsNullOrEmpty(sc.RemainsFilter.ItemIDFilter) ? null : (int?)Convert.ToInt32(sc.RemainsFilter.ItemIDFilter.Substring(1)),
                        sc.RemainsFilter.ItemFilter, sc.RemainsFilter.ManufacturerFilter, sc.RemainsFilter.LotNumberFilter,
                        sc.RemainsFilter.BatchIdFilter, sc.RemainsFilter.UomFilter, sc.RemainsFilter.VatFilter, sc.RemainsFilter.LotStatusFilter,
                        sc.RemainsFilter.ExpirationDateFilter, sc.RemainsFilter.MozFilter, sc.RemainsFilter.VendorFilter);
            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(DataTable pTable)
            {
                data = pTable;
            }

            public WriteOffStuffRemainsView()
            {
                this.dataColumns.Add(new PatternColumn("Место", "Location_ID", new FilterPatternExpressionRule("Location_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("ID товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Наименование товара", "Item", new FilterPatternExpressionRule("Item"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Серия", "LotNumber", new FilterPatternExpressionRule("LotNumber"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Партия", "Batch_ID", new FilterPatternExpressionRule("Batch_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("ЕИ", "UOM", new FilterPatternExpressionRule("UOM"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("НДС", "VAT", new FilterPatternExpressionRule("VAT"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Кол-во", "Quantity", new FilterCompareExpressionRule<Double>("Quantity"), SummaryCalculationType.Sum));
                this.dataColumns.Add(new PatternColumn("Итог. сумма", "Amount_UAH", new FilterCompareExpressionRule<Double>("Amount_UAH"), SummaryCalculationType.Sum));
                this.dataColumns.Add(new PatternColumn("Код задержки", "LotStatus", new FilterPatternExpressionRule("LotStatus"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Цена", "Price", new FilterCompareExpressionRule<Double>("Price"), SummaryCalculationType.Count));
                //this.dataColumns.Add(new PatternColumn("Валюта", "VInvCurrency", new FilterPatternExpressionRule("VInvCurrency"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Срок годности", "ExpirationDate", new FilterDateCompareExpressionRule("ExpirationDate"), SummaryCalculationType.Count));
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

        /// <summary>
        /// Представление для грида с остатками на непродажных складах
        /// </summary>
        public class WriteOffStuffLinesView : IDataView
        {
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
                    data = adapter.GetData(sc.SessionID, sc.WarehouseID, sc.RemainsFilter.LocationIDFilter,
                        String.IsNullOrEmpty(sc.RemainsFilter.ItemIDFilter) ? null : (int?)Convert.ToInt32(sc.RemainsFilter.ItemIDFilter.Substring(1)),
                        sc.RemainsFilter.ItemFilter, sc.RemainsFilter.ManufacturerFilter, sc.RemainsFilter.LotNumberFilter,
                        sc.RemainsFilter.BatchIdFilter, sc.RemainsFilter.UomFilter, sc.RemainsFilter.VatFilter, sc.RemainsFilter.LotStatusFilter,
                        sc.RemainsFilter.ExpirationDateFilter, sc.RemainsFilter.MozFilter, sc.RemainsFilter.VendorFilter);
            }

            /// <summary>
            /// Наполнение источника данных с внешнего источника
            /// </summary>
            /// <param name="pTable">Внешний источник</param>
            public void FillData(DataTable pTable)
            {
                data = pTable;
            }

            public WriteOffStuffLinesView()
            {
                this.dataColumns.Add(new PatternColumn("Место", "Location_ID", new FilterPatternExpressionRule("Location_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("ID товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Наименование товара", "Item", new FilterPatternExpressionRule("Item"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Серия", "Lot_Number", new FilterPatternExpressionRule("Lot_Number"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Партия", "Batch_ID", new FilterPatternExpressionRule("Batch_ID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("ЕИ", "UOM", new FilterPatternExpressionRule("UOM"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("НДС", "VAT", new FilterPatternExpressionRule("VAT"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Кол-во", "Quantity", new FilterCompareExpressionRule<Double>("Quantity"), SummaryCalculationType.Sum));
                this.dataColumns.Add(new PatternColumn("Итог. сумма", "Amount_UAH", new FilterCompareExpressionRule<Double>("Amount_UAH"), SummaryCalculationType.Sum));
                this.dataColumns.Add(new PatternColumn("Код задержки", "LotStatus", new FilterPatternExpressionRule("LotStatus"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Цена", "Price", new FilterCompareExpressionRule<Double>("Price"), SummaryCalculationType.Count));
                //this.dataColumns.Add(new PatternColumn("Валюта", "VInvCurrency", new FilterPatternExpressionRule("VInvCurrency"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Срок годности", "ExpirationDate", new FilterDateCompareExpressionRule("ExpirationDate"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("МОЗ", "MOZ", new FilterPatternExpressionRule("MOZ"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Поставщик", "Vendor", new FilterPatternExpressionRule("Vendor"), SummaryCalculationType.Count));
            }
        }

        #endregion
    }
}
