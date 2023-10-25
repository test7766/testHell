using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Data;
using WMSOffice.Reports;
using WMSOffice.Controls.Complaints;
using WMSOffice.Dialogs;
using System.Transactions;

namespace WMSOffice.Window
{
    public partial class ComplaintsIlliquidCommodityPlacementWindow : GeneralWindow
    {
        private const int OLD_WORK_MODE = 1;
        private const int NEW_WORK_MODE = 2;
        private const int EXPERIMENTAL_WORK_MODE = 3;

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Признак использования "старого" режима работы
        /// </summary>
        private bool useOldWorkMode = false;

        /// <summary>
        /// Режим работы
        /// </summary>
        private int workMode = -1;

        /// <summary>
        /// Признак необходимости SSCC 
        /// </summary>
        private bool needSSCC;

        #endregion

        public ComplaintsIlliquidCommodityPlacementWindow()
        {
            InitializeComponent();
        }

        private void ComplaintsIlliquidCommodityPlacementWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            #region РЕГИСТРАЦИЯ СПРАВОЧНИКОВ

            stbWarehouse.ValueReferenceQuery = "[dbo].[pr_IL_Get_MCU_List]";

            stbLocation.ValueReferenceQuery = "[dbo].[pr_IL_Get_Locn_List]";
            this.stbLocation.AddReference(this.stbWarehouse, "Value");

            foreach (var stbControl in gbFilterSettings.Controls)
            {
                if (stbControl is SearchTextBox)
                {
                    (stbControl as SearchTextBox).UserID = this.UserID;
                    (stbControl as SearchTextBox).OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
                }
            }

            #endregion

            #region НАСТРОЙКА ТАБЛИЦЫ ИТОГОВ

            foreach (DataGridViewColumn dc in dgvDetails.Columns)
            {
                DataGridViewColumn fc = new DataGridViewTextBoxColumn();
                fc.DataPropertyName = dc.DataPropertyName;
                fc.Width = dc.Width;
                fc.Name = dc.DataPropertyName;

                if (dc != dgvcIsChecked && dc.DefaultCellStyle != null)
                    fc.DefaultCellStyle = dc.DefaultCellStyle;

                dgvFooter.Columns.Add(fc);
            }

            dgvFooter.AutoGenerateColumns = false;
            dgvFooter.Rows.Add();
            dgvFooter.Rows[0].Selected = false;
            dgvFooter.Visible = false;

            #endregion

            #region ПРОВЕРКА ДОСТУПА НА СМЕНУ ВИНОВНОГО СОТРУДНИКА

            try
            {
                var hasAccess = (int?)null;
                remainsTableAdapter.CheckAccessToChangeFaultEmployee(this.UserID, ref hasAccess);

                sbChangeFaultEmployee.Enabled = hasAccess.HasValue && Convert.ToBoolean(hasAccess.Value) == true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            #endregion

            #region ПРОВЕРКА ДОСТУПА НА ФОРМИРОВАНИЕ ЗАКАЗА М/С ПЕРЕМЕЩЕНИЯ

            try
            {
                var hasAccess = (int?)null;
                remainsTableAdapter.CheckAccessToCreateBranchMovementOrder(this.UserID, ref hasAccess);

                sbCreateBranchMovementOrder.Enabled = hasAccess.HasValue && Convert.ToBoolean(hasAccess.Value) == true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            #endregion

            #region ПОЛУЧЕНИЕ РЕЖИМА РАБОТЫ С ИНТЕРФЕЙСОМ

            try
            {
                var wMode = (int?)null;
                remainsTableAdapter.GetWorkMode(this.UserID, ref wMode);

                workMode = wMode ?? OLD_WORK_MODE;
                useOldWorkMode = workMode == OLD_WORK_MODE;

                if (!useOldWorkMode)
                {
                    docIDDataGridViewTextBoxColumn.Visible = false;
                    FaultEmployees.Visible = false;

                    sbChangeFaultEmployee.Visible = false;
                    toolStripSeparator3.Visible = false;
                }
                //else
                //{
                //    toolStripSeparator6.Visible = false;
                //    sbSplit.Visible = false;
                //}
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            #endregion
        }

        void searchCriteria_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouse;
            else if (control == stbLocation)
                lblDescription = lblLocation;

            if (lblDescription != null)
            {
                // Настройка сброса зависимой сущности при смене независимой (при смене склада сбрасывается полка)
                // TODO реализовать автоматически через Binding
                if (control == stbWarehouse)
                    if (e.Success)
                        stbLocation.SetValueByDefault(string.Empty);

                // Получение признака необходимости SSCC
                if (control == stbLocation)
                    needSSCC = e.Success && !string.IsNullOrEmpty(e.Value) ? Convert.ToBoolean(e.OwnedRow["NeedSSCC"]) : false;

                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            dgvDetails.Columns[dgvcIsChecked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvDetails.Columns[dgvcIsChecked.Index].HeaderCell).CheckBoxClicked += CheckBoxHeaderCell_OnCheckBoxClicked;
        }

        private void CheckBoxHeaderCell_OnCheckBoxClicked(object sender, WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                if (stbWarehouse.Value == null)
                    throw new Exception("Не указан склад.");

                if (stbLocation.Value == null)
                    throw new Exception("Не указано место.");

                foreach (DataGridViewRow row in dgvDetails.Rows)
                {
                    row.Cells[dgvcIsChecked.Index].Value = e.IsChecked;

                    var remainsRow = (row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                    if (!this.SetFcom(remainsRow, e.IsChecked))
                        row.Cells[dgvcIsChecked.Index].Value = !e.IsChecked;
                }

                dgvDetails.RefreshEdit();

                if (e.IsChecked)
                    this.LockSearchParameters(true);
                else
                    this.LockSearchParameters(false);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadRemains(true);
                return true;
            }

            if (keyData == (Keys.Control | Keys.P))
            {
                PrintPlacementTasks((string)null, (int?)null);
                return true;
            }

            if (keyData == (Keys.Control | Keys.M))
            {
                MoveRemains();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region ЗАГРУЗКА ОСТАТКА

        private void sbLoadRemains_Click(object sender, EventArgs e)
        {
            LoadRemains(true);
        }

        private void LoadRemains(bool withUpdate)
        {
            // Снимаем по всем строкам признак fcom (если установлен withUpdate -- для нового процесса) 
            if (useOldWorkMode)
                UnsetFcom(true);
            else
                UnsetFcom(withUpdate);

            // Получаем список скидок перед выгрузкой остатка
            if (!this.LoadDiscountTypes())
                return;

            string warehouseID;
            string locationID;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                Data.ComplaintsExt.RemainsRow targetRemainsRow = dgvDetails.SelectedRows.Count == 0 ? null : (dgvDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                var itemID = targetRemainsRow != null ? targetRemainsRow.Item_ID : (int?)null;
                var detailID = targetRemainsRow != null ? targetRemainsRow.Detail_ID : (long?)null;
                var lineID = targetRemainsRow != null ? targetRemainsRow.Line_ID : (int?)null;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        //this.remainsTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalMilliseconds);

                        if (useOldWorkMode)
                            e.Result = this.remainsTableAdapter.GetData(locationID, warehouseID, this.UserID);
                        else
                            e.Result = this.remainsTableAdapter.GetDataExt(locationID, warehouseID, this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        ShowError(e.Result as Exception);
                    else
                    {
                        this.complaintsExt.Remains.Merge(e.Result as DataTable);
                        this.remainsBindingSource.DataSource = this.complaintsExt.Remains;

                        this.NavigateToItem(targetRemainsRow == null, itemID, detailID, lineID);
                    }

                    waitProgressForm.CloseForce();
                    dgvFooter.Visible = true;
                    RecalculateFooter();
                };

                waitProgressForm.ActionText = "Выполняется загрузка остатка..";
                this.remainsBindingSource.DataSource = null;
                this.complaintsExt.Remains.Clear();
                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void NavigateToItem(bool emptyItem, int? itemID, long? detailID, int? lineID)
        {
            if (emptyItem)
                return;

            foreach (DataGridViewRow boundRow in dgvDetails.Rows)
            {
                var remainsRow = (boundRow.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                if (remainsRow.Item_ID.Equals(itemID.Value) && remainsRow.Detail_ID.Equals(detailID.Value) && remainsRow.Line_ID.Equals(lineID.Value))
                {
                    boundRow.Selected = true;
                    dgvDetails.FirstDisplayedScrollingRowIndex = boundRow.Index;
                    return;
                }
            }
        }

        private bool LoadDiscountTypes()
        {
            string warehouseID;

            try
            {
                 if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                this.discountTypesTableAdapter.Fill(this.complaintsExt.DiscountTypes, warehouseID);
                return true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        #endregion

        #region ПЕЧАТЬ ЗАДАНИЙ НА РАЗМЕЩЕНИЕ

        private void sbPrintPlacementTasks_Click(object sender, EventArgs e)
        {
            if (PrintPlacementTasks((string)null, (int?)null))
                LoadRemains(false);
        }

        private bool PrintPlacementTasks(string locationTo, int? createOrder)
        {
            bool success = false;
            var printerName = (string)cmbPrinters.SelectedItem;

            string warehouseID;
            string locationID;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                var sscc = (string)null;

                var printPutListWithSSCC = string.IsNullOrEmpty(locationTo) && !createOrder.HasValue && (workMode == EXPERIMENTAL_WORK_MODE || workMode == OLD_WORK_MODE) && needSSCC;
                if (printPutListWithSSCC)
                {
                    var dlgScanSSCC = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте SSCC\r\nдля выполнения задания размещения НТВ",
                        Text = "Размещение НТВ",
                        Image = Properties.Resources.barcode
                    };

                    if (dlgScanSSCC.ShowDialog() == DialogResult.OK)
                        sscc = dlgScanSSCC.Barcode;
                    else
                        throw new Exception("Вы отменили задание на размещение НТВ.");
                }

                var printWorker = new BackgroundWorker();
                printWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        using (var scope = new TransactionScope())
                        {
                            var lstTargetRemains = new List<Data.ComplaintsExt.RemainsRow>();
                            foreach (DataGridViewRow dr in dgvDetails.Rows)
                            {
                                var row = (dr.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                                if (row.IsChecked)
                                    lstTargetRemains.Add(row);
                            }

                            if (lstTargetRemains.Count == 0)
                                throw new Exception("Для продолжения операции необходимо отметить позиции.");

                            SaveData(warehouseID, locationID, lstTargetRemains, locationTo, createOrder);

                            if (createOrder.HasValue)
                            {
                                //CreateBranchMovementOrder();
                            }
                            else
                            {
                                PrintPutList(locationTo, printerName, sscc);
                            }

                            scope.Complete();
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                printWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        ShowError(e.Result as Exception);
                    else
                        success = true;

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = createOrder.HasValue ? "Выполняется формирование отложенного задания на м/с перемещение.." : "Выполняется печать заданий на размещение..";
                printWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            return success;
        }

        private void SaveData(string warehouseID, string locationID,  List<Data.ComplaintsExt.RemainsRow> lstTargetRemains, string locationTo, int? createOrder)
        {
            var moveRemains = !string.IsNullOrEmpty(locationTo);

            foreach (var row in lstTargetRemains)
            {
                //if (!row.Isblock_discountNull() && row.block_discount == 1)
                //{ 
                //    // игнорируем проверку проставленной скидки
                //}
                //else
                //{
                if (!moveRemains && (row.IsDiscountIDNull() || string.IsNullOrEmpty(row.DiscountID)))
                    throw new Exception("Не указана скидка для некоторых отмеченных позиций остатка.");
                //}

                if (createOrder.HasValue && (row.IsFaultEmployeesNull() || string.IsNullOrEmpty(row.FaultEmployees)))
                    throw new Exception("Не указаны виновные сотрудники для некоторых отмеченных позиций остатка.");
            }

            foreach (var row in lstTargetRemains)
            {
                string discountID = null;
                decimal? rateDiscount = (decimal?)null;

                if (!moveRemains)
                {
                    var findDiscount = this.complaintsExt.DiscountTypes.Select(string.Format("{0} = '{1}'", this.complaintsExt.DiscountTypes.DRKYColumn.Caption, row.IsDiscountIDNull() ? (string)null : row.DiscountID))[0] as Data.ComplaintsExt.DiscountTypesRow;
                    rateDiscount = findDiscount.DRDL02 / 100;
                    discountID = row.DiscountID;
                }

                var quantity = row.IsQuantityNull() ? 0 : row.Quantity;

                if (useOldWorkMode)
                    remainsTableAdapter.SetDiscount(row.Doc_ID, row.Detail_ID, discountID, rateDiscount, locationTo, createOrder, quantity, this.UserID, row.Line_ID);
                else
                    remainsTableAdapter.SetDiscountExt(warehouseID, locationID, row.Item_ID, row.Lot_Number, quantity, discountID, rateDiscount, this.UserID, locationTo, createOrder, row.Line_ID);
            }
        }

        private void PrintPutList(string locationTo, string printerName, string sscc)
        {
            string warehouseID;
            string locationID; 
            long moveTaskID;

            var moveRemains = !string.IsNullOrEmpty(locationTo);

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                Data.ComplaintsExt.PutListDocsDataTable docs = null;
                using (var adapter = new Data.ComplaintsExtTableAdapters.PutListDocsTableAdapter())
                {
                    if (useOldWorkMode)
                        docs = moveRemains
                            ? adapter.GetDataTransfer(warehouseID, locationID, this.UserID)
                            : string.IsNullOrEmpty(sscc)
                                ? adapter.GetData(warehouseID, locationID, this.UserID)
                                : adapter.GetDataSSCC(warehouseID, locationID, sscc, this.UserID);
                    else
                        docs = moveRemains
                            ? adapter.GetDataTransferExt(warehouseID, locationID, this.UserID)
                            : string.IsNullOrEmpty(sscc)
                                ? adapter.GetDataExt(warehouseID, locationID, this.UserID)
                                : adapter.GetDataExtSSCC(warehouseID, locationID, sscc, this.UserID);
                }

                foreach (Data.ComplaintsExt.PutListDocsRow doc in docs.Rows)
                {
                    moveTaskID = doc.doc_id;

                    // создадим таблицу для данных отчета
                    var putList = new WMove.WM_PutListDataTable();

                    // получим данные отчета, штрих-код создан
                    InterbranchReceiveWindow.MovePutListPrepare(putList, moveTaskID);

                    // напечатаем лист размещения
                    var report = new WMovePutListReport();
                    report.SetDataSource((DataTable)putList);

                    report.PrintOptions.PrinterName = printerName;
                    report.PrintToPrinter(1, false, 1, 0);

                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IL", 1, Convert.ToInt64(moveTaskID), (string)null, Convert.ToInt16(putList.Count), printerName, 1);
                }

                if (!string.IsNullOrEmpty(sscc))
                    MessageBox.Show("Передайте товар в отдел рекламаций.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("#ERROR_RESQTY"))
                {
                    var message = ex.Message.Replace("#ERROR_RESQTY", string.Empty).Trim();

                    // Снимаем по всем строкам выделение
                    UnsetFcom(false);

                    throw new Exception(message);
                }
                else
                {
                    throw ex;
                }
            }
        }

        [Obsolete]
        private void CreateBranchMovementOrder()
        {
            string warehouseID;
            string locationID; 
            int? errorCode = null;
            string errorMessage = null;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                using (var adapter = new Data.ComplaintsExtTableAdapters.QueriesTableAdapter())
                    adapter.CreateBranchMovementOrder(this.UserID, warehouseID, locationID, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ПЕРЕМЕЩЕНИЕ НА ДРУГУЮ ПОЛКУ

        private void sbMoveRemains_Click(object sender, EventArgs e)
        {
            MoveRemains();
        }

        private void MoveRemains()
        {
            string warehouseID;
            string locationID;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                var dlgLocationSelector = new SearchTextBoxSelector("[dbo].[pr_IL_Get_LocnTransfer_List]",
                    new List<ReferencedObject>(new ReferencedObject[] 
                { 
                    new ReferencedObject { Value = warehouseID },
                    new ReferencedObject { Value = true }
                }), 
                new List<string>());

                dlgLocationSelector.UserID = this.UserID;
                dlgLocationSelector.ExceptValue = locationID;

                if (dlgLocationSelector.ShowDialog() != DialogResult.OK)
                    return;

                var args = new VerifyValueArgs(dlgLocationSelector.SelectedItem);
                var locationTo = args.Value;

                if (PrintPlacementTasks(locationTo, (int?)null))
                    LoadRemains(false);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region СМЕНА ВИНОВНОГО СОТРУДНИКА

        private void sbChangeFaultEmployee_Click(object sender, EventArgs e)
        {
            string warehouseID;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                var lstTargetRemains = new List<Data.ComplaintsExt.RemainsRow>();
                foreach (DataGridViewRow dr in dgvDetails.Rows)
                {
                    var row = (dr.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                    if (row.IsChecked)
                        lstTargetRemains.Add(row);
                }

                if (lstTargetRemains.Count == 0)
                    throw new Exception("Сначала необходимо отметить позиции,\r\nпо которым следует сменить виновного сотрудника.");

                var docID = lstTargetRemains[0].Doc_ID;
                var docType = lstTargetRemains[0].doc_type;

                var dlgEnterFaultEmployee = new Dialogs.Complaints.EnterFaultEmployeeForm(this.UserID, 0, docType, null, warehouseID, docID);
                dlgEnterFaultEmployee.IsDepartmentChoiceEnabled = ComplaintsListWindow.CheckIfDepartmentChoiceEnabled(docType);

                if (dlgEnterFaultEmployee.ShowDialog() == DialogResult.OK)
                {
                    var faultEmployeeID = dlgEnterFaultEmployee.FaultEmployeeID.HasValue ? dlgEnterFaultEmployee.FaultEmployeeID.Value : (int?)null;
                    var faultDepartmentID = dlgEnterFaultEmployee.FaultDepartmentID.HasValue ? dlgEnterFaultEmployee.FaultDepartmentID.Value : (int?)null;

                    if (UpdateFaultEmployee(lstTargetRemains, faultEmployeeID, faultDepartmentID))
                        LoadRemains(false);
                }

                return;

                #region ВЫБОР ВИНОВНОГО СОТРУДНИКА БЕЗ ОТДЕЛА (СТАРЫЙ ВАРИАНТ)

                //var selector = new GuiltyEmployeesSelectionControl()
                //{
                //    SessionID = this.UserID,
                //    DepartmentID = (int?)null,
                //    WarehouseID = warehouseID,
                //    CallMode = 2
                //};

                //var dlgSelector = new DialogForm();
                //dlgSelector.Height = 250;
                //dlgSelector.Width = 320;
                //dlgSelector.Text = "Смена виновного сотрудника";
                //dlgSelector.FormBorderStyle = FormBorderStyle.SizableToolWindow;
                //dlgSelector.StartPosition = FormStartPosition.CenterScreen;
                //dlgSelector.Controls.Add(selector);

                //selector.Left = 0;
                //selector.Width = dlgSelector.OptionsPanel.Width;
                //selector.Top = 0;
                //selector.Height = dlgSelector.OptionsPanel.Top;
                //selector.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;

                //selector.Initialize();

                //dlgSelector.BeginShown += delegate(object s, EventArgs ea)
                //{
                //    selector.Focus();
                //};

                //dlgSelector.FormClosing += delegate(object s, FormClosingEventArgs ea)
                //{
                //    if (dlgSelector.DialogResult == DialogResult.OK)
                //    {
                //        var lst = selector.Value.Equals(DBNull.Value) ? string.Empty : selector.Value.ToString();
                //        if (lst.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length > 1)
                //        {
                //            MessageBox.Show("Выбрать можно только одного сотрудника!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //            ea.Cancel = true;
                //        }
                //    }
                //};

                //if (dlgSelector.ShowDialog() == DialogResult.OK)
                //{
                //    var employeeID = (selector.Value.Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(selector.Value)) ?? 0;
                //    var departmentID = (int?)null;

                //    if (!employeeID.Equals(0))
                //    {
                //        if (UpdateFaultEmployee(lstTargetRemains, employeeID, departmentID))
                //            LoadRemains(false);
                //    }
                //}

                #endregion
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool UpdateFaultEmployee(List<Data.ComplaintsExt.RemainsRow> lstTargetRemains, int? employeeID, int? departmentID)
        {
            var success = true;

            try
            {
                var updateWorker = new BackgroundWorker();
                updateWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        foreach (var row in lstTargetRemains)
                            remainsTableAdapter.UpdateFaultEmployee(row.Doc_ID, row.Detail_ID, employeeID, departmentID, this.UserID, row.Line_ID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                updateWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                    {
                        this.ShowError(e.Result as Exception);
                        success = false;
                    }

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = "Выполняется смена виновного сотрудника..";
                updateWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                success = false;
            }

            return success;
        }

        #endregion

        #region СОЗДАНИЕ ЗАКАЗА НА М/С ПЕРЕМЕЩЕНИЕ

        private void sbCreateBranchMovementOrder_Click(object sender, EventArgs e)
        {
            PrepareBranchMovementOrder();
        }

        private void PrepareBranchMovementOrder()
        {
            try
            {
                if (PrintPlacementTasks((string)null, (int?)1))
                    LoadRemains(false);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region СИНХРОНИЗАЦИЯ ПРОКРУТКИ И РАЗМЕРОВ КОЛОНОК ОСНОВОГО ТАБЛИЧНОГО ПРЕДСТАВЛЕНИЯ И ИТОГОВ

        private void dgvDetails_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvFooter.HorizontalScrollingOffset = e.NewValue;
                    dgvFooter.Refresh();
                }
                catch (Exception ex)
                { 
                
                }
            }
        }

        private void dgvFooter_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.ScrollOrientation == ScrollOrientation.HorizontalScroll)
            {
                try
                {
                    dgvDetails.HorizontalScrollingOffset = e.NewValue;
                    dgvDetails.Refresh();
                }
                catch (Exception ex)
                { 
                
                }
            }
        }

        private void dgvDetails_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            if (dgvFooter.Columns.Count > e.Column.Index)
            {
                dgvFooter.Columns[e.Column.Index].Width = e.Column.Width;
                //dgvFooter.Refresh();
            }
        }

        #endregion

        private void dgvDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var remainsRow = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;

            //if (dgvDetails.Columns[e.ColumnIndex].Index == 0)
            //    SetFcom(remainsRow);

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == this.complaintsExt.Remains.DiscountIDColumn.Caption)
                RecalculateFooter();
        }

        private bool SetFcom(Data.ComplaintsExt.RemainsRow row)
        {
            return SetFcom(row, (bool?)null);
        }

        /// <summary>
        /// Установка fcom строки претензии
        /// </summary>
        /// <param name="row"></param>
        private bool SetFcom(Data.ComplaintsExt.RemainsRow row, bool? isChecked)
        {
            string warehouseID;
            string locationID;

            try
            {
                var checkedFlag = Convert.ToInt32(isChecked ?? row.IsChecked);

                var quantity = row.IsQuantityNull() ? 0 : row.Quantity;

                if (useOldWorkMode)
                    remainsTableAdapter.SetFcom(this.UserID, row.Detail_ID, checkedFlag, quantity, row.Line_ID);
                else
                {
                    if ((warehouseID = stbWarehouse.Value) == null)
                        throw new Exception("Не указан склад.");

                    if ((locationID = stbLocation.Value) == null)
                        throw new Exception("Не указано место.");

                    remainsTableAdapter.SetFcomExt(this.UserID, warehouseID, locationID, row.Item_ID, row.Lot_Number, checkedFlag, quantity, row.Line_ID);
                }

                return true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
                return false;
            }
        }

        private void RecalculateDiscountAmount(Data.ComplaintsExt.RemainsRow row)
        {
            var rateDiscount = (double)1.0F;

            try
            {
                var findDiscount = this.complaintsExt.DiscountTypes.Select(string.Format("{0} = '{1}'", this.complaintsExt.DiscountTypes.DRKYColumn.Caption, row.IsDiscountIDNull() ? (string)null : row.DiscountID))[0] as Data.ComplaintsExt.DiscountTypesRow;
                rateDiscount = (100 - (findDiscount.IsDRDL02Null() ? 0.0F : (double)findDiscount.DRDL02)) / 100;
            }
            catch (Exception ex)
            {

            }

            row.DiscountAmount = (row.IsAmountNull() ? 0.0F : row.Amount) * rateDiscount;
        }

        private void RecalculateFooter()
        {
            try
            {
                var cntItems = 0;
                var totalQuantity = 0;
                var totalAmount = 0.0M;
                var totalDiscountAmount = 0.0M;

                foreach (Data.ComplaintsExt.RemainsRow row in complaintsExt.Remains.Rows)
                {
                    RecalculateDiscountAmount(row);

                    cntItems++;
                    totalQuantity += row.IsQuantityNull() ? 0 : (int)row.Quantity;
                    totalAmount += row.IsAmountNull() ? 0.0M : (decimal)row.Amount;
                    totalDiscountAmount += row.IsDiscountAmountNull() ? 0.0M : (decimal)row.DiscountAmount;
                }

                dgvFooter.Rows[0].Cells[complaintsExt.Remains.Item_IDColumn.Caption].Value = cntItems;
                dgvFooter.Rows[0].Cells[complaintsExt.Remains.QuantityColumn.Caption].Value = totalQuantity;
                dgvFooter.Rows[0].Cells[complaintsExt.Remains.AmountColumn.Caption].Value = totalAmount;
                dgvFooter.Rows[0].Cells[complaintsExt.Remains.DiscountAmountColumn.Caption].Value = totalDiscountAmount;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void dgvDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetails.CurrentCell is DataGridViewCheckBoxCell)
                {
                    if (dgvDetails.IsCurrentCellDirty)
                    {
                        var remainsRow = (dgvDetails.CurrentRow.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                        var fontColor = remainsRow.IsFont_ColorNull() ? Color.Black : Color.FromName(remainsRow.Font_Color);
                        var backColor = remainsRow.IsBack_ColorNull() ? SystemColors.Window : Color.FromName(remainsRow.Back_Color);

                        if (this.SetFcom(remainsRow, !remainsRow.IsChecked))
                        {
                            dgvDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                            if (remainsRow.IsChecked)
                                this.LockSearchParameters(true);
                            else
                            {
                                this.CheckUnlockSearchParameters();
                            }
                        }
                        else
                            dgvDetails.CancelEdit();

                        // Раскраска
                        bool isChecked = Convert.ToBoolean(this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[this.dgvcIsChecked.Index].Value);
                        foreach (DataGridViewColumn column in this.dgvDetails.Columns)
                        {
                            this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : backColor;
                            this.dgvDetails.Rows[this.dgvDetails.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : fontColor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var remainsRow = (this.dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                var fontColor = remainsRow.IsFont_ColorNull() ? Color.Black : Color.FromName(remainsRow.Font_Color);
                var backColor = remainsRow.IsBack_ColorNull() ? SystemColors.Window : Color.FromName(remainsRow.Back_Color);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvDetails.Rows[e.RowIndex].Cells[this.dgvcIsChecked.Index].Value);
                this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : backColor;
                this.dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : fontColor;
            }
            catch (Exception ex)
            {
               
            }
        }

        private void ComplaintsIlliquidCommodityPlacementWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsetFcom(true);
        }

        /// <summary>
        /// Снятие по всем строкам признака fcom
        /// </summary>
        private void UnsetFcom(bool withUpdate)
        {
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                var remainsRow = (row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;

                if (remainsRow.IsChecked)
                {
                    remainsRow.IsChecked = false;

                    if (withUpdate)
                        SetFcom(remainsRow);
                }
            }

            this.LockSearchParameters(false);
        }

        private void CheckUnlockSearchParameters()
        {
            foreach (DataGridViewRow row in dgvDetails.Rows)
            {
                var remainsRow = (row.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                if (remainsRow.IsChecked)
                    return;
            }

            this.LockSearchParameters(false);
        }

        private void LockSearchParameters(bool needLock)
        {
            stbWarehouse.ReadOnly = needLock;
            stbLocation.ReadOnly = needLock;
        }

        private void dgvDetails_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                (e.Control as ComboBox).SelectedValueChanged -= ComplaintsIlliquidCommodityPlacementWindow_SelectedValueChanged;

                var row = (dgvDetails.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;
                if (!row.Isblock_discountNull() && row.block_discount == 1)
                {
                    dgvDetails.EndEdit(DataGridViewDataErrorContexts.Commit);
                    return;
                }

                (e.Control as ComboBox).SelectedValueChanged += ComplaintsIlliquidCommodityPlacementWindow_SelectedValueChanged;
            }
        }

        void ComplaintsIlliquidCommodityPlacementWindow_SelectedValueChanged(object sender, EventArgs e)
        {
            var cb = sender as ComboBox;
            var discountID = (cb.SelectedValue ?? string.Empty).ToString().Trim();

            if ("ZC".Equals(discountID))
                cb.SelectedItem = null;
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        #region СПЛИТОВКА КОЛИЧЕСТВА

        private void sbSplit_Click(object sender, EventArgs e)
        {
            if (dgvDetails.Rows.Count == 0)
                return;

            Split(dgvDetails.CurrentCell.OwningRow.Index);
        }

        private void dgvDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Split(e.RowIndex);
        }

        private void Split(int idxGridRow)
        {
            //if (useOldWorkMode)
            //    return;

            string warehouseID;
            string locationID;

            try
            {
                if ((warehouseID = stbWarehouse.Value) == null)
                    throw new Exception("Не указан склад.");

                if ((locationID = stbLocation.Value) == null)
                    throw new Exception("Не указано место.");

                var oldRemainsRow = (dgvDetails.Rows[idxGridRow].DataBoundItem as DataRowView).Row as Data.ComplaintsExt.RemainsRow;

                var isChecked = oldRemainsRow.IsChecked;
                if (isChecked)
                    throw new Exception("Нельзя сплитовать отмеченные позиции.");

                var quantity = Convert.ToDecimal(oldRemainsRow.IsQuantityNull() ? 0 : oldRemainsRow.Quantity);

                if (quantity > 1)
                {
                    var dlgComplaintsIlliquidCommodityPlacementSplit = new ComplaintsIlliquidCommodityPlacementSplitForm(quantity);
                    if (dlgComplaintsIlliquidCommodityPlacementSplit.ShowDialog(this) == DialogResult.OK)
                    {
#if manual_split
                        oldRemainsRow.Quantity = dlgComplaintsIlliquidCommodityPlacementSplit.Quantity;
                        var idxRemainsRow = complaintsExt.Remains.Rows.IndexOf(oldRemainsRow);

                        var newRemainsRow = complaintsExt.Remains.NewRemainsRow();
                        newRemainsRow.ItemArray = oldRemainsRow.ItemArray;
                        newRemainsRow.Quantity = dlgComplaintsIlliquidCommodityPlacementSplit.Remains;

                        complaintsExt.Remains.Rows.InsertAt(newRemainsRow, idxRemainsRow);
#else

                        remainsTableAdapter.SplitFaultEmployee(oldRemainsRow.Doc_ID, oldRemainsRow.Detail_ID, oldRemainsRow.Line_ID, dlgComplaintsIlliquidCommodityPlacementSplit.Quantity, this.UserID);
                        LoadRemains(true);
#endif
                    }
                }
                else
                    throw new Exception(string.Format("Сплитовка невозможна: недостаточно количества."));
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion
    }
}
