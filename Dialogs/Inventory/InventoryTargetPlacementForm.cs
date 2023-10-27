using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Transactions;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryTargetPlacementForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        private int SelectorColumnIndex { get { return 0; } }

        private bool IsRowSelected(DataGridView gridView, int rowIndex)
        {
            object selectionModeValue = gridView.Rows[rowIndex].Cells[this.SelectorColumnIndex].Value;
            return selectionModeValue == null || string.IsNullOrEmpty(selectionModeValue.ToString()) || Convert.ToBoolean(Convert.ToInt16(selectionModeValue));
        }

        private Data.Inventory.InventoryTargetWarehousesRow SelectedWarehouse { get; set; }
        private Data.Inventory.InventoryTargetZoneInWarehouseRow SelectedZone { get; set; }
        private Data.Inventory.InventoryTargetStackesInZoneRow SelectedStack { get; set; }
        private Data.Inventory.InventoryTargetLocationsInStackRow SelectedLocation { get; set; }
       

        /// <summary>
        /// Определение статуса выбора текущего элемента места проведения инвентаризации
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        [Obsolete]
        public InventoryTargetPlacementItemCheckState GetInventoryTargetPlacementItemCheckState(DataGridView gridView, int rowIndex)
        {
            object selectionModeValue = gridView.Rows[rowIndex].Cells[this.SelectorColumnIndex].Value;
            if (selectionModeValue == null || string.IsNullOrEmpty(selectionModeValue.ToString()))
                return InventoryTargetPlacementItemCheckState.CheckedSeveral;

            bool isChecked = Convert.ToBoolean(Convert.ToInt16(selectionModeValue));
            return isChecked ? InventoryTargetPlacementItemCheckState.CheckedAll : InventoryTargetPlacementItemCheckState.NotChecked;
        }

        public InventoryTargetPlacementItemCheckState GetInventoryTargetPlacementItemCheckState(string selectionMode)
        {
            if (string.IsNullOrEmpty(selectionMode))
                return InventoryTargetPlacementItemCheckState.CheckedSeveral;
            bool isChecked = Convert.ToBoolean(Convert.ToInt16(selectionMode));
            return isChecked ? InventoryTargetPlacementItemCheckState.CheckedAll : InventoryTargetPlacementItemCheckState.NotChecked;
        }

        public InventoryTargetPlacementForm()
        {
            InitializeComponent();
        }

        private void InventoryTargetPlacementForm_Load(object sender, EventArgs e)
        {
            this.AdaptWarehouses();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(1036, 8);
            this.btnCancel.Location = new Point(1126, 8);
        }

        private void dgvWarehouses_SelectionChanged(object sender, EventArgs e)
        {
            this.SelectWarehouse();
        }

        private void SelectWarehouse()
        {
            this.ClearZonesInWarehousesFilter();

            if (this.inventoryTargetWarehousesBindingSource.Current == null || dgvWarehouses.SelectedRows.Count == 0)
                return;

            var bindRow = (this.inventoryTargetWarehousesBindingSource.Current as DataRowView).Row as Data.Inventory.InventoryTargetWarehousesRow;
            this.SelectedWarehouse = bindRow;
            this.SetZonesInWarehousesFilter(bindRow.Warehouse_id);

            this.SelectZone();
        }

        private void dgvZones_SelectionChanged(object sender, EventArgs e)
        {
            this.SelectZone();
        }

        private void SelectZone()
        {
            this.ClearStackesInZoneFilter();

            if (this.inventoryTargetZoneInWarehouseBindingSource.Current == null || dgvZones.SelectedRows.Count == 0)
                return;

            var bindRow = (this.inventoryTargetZoneInWarehouseBindingSource.Current as DataRowView).Row as Data.Inventory.InventoryTargetZoneInWarehouseRow;
            this.SelectedZone = bindRow;
            this.SetStackesInZoneFilter(bindRow.Zone_ID);

            var checkState = GetInventoryTargetPlacementItemCheckState(bindRow.IsSelectionModeNull() ? (string)null : bindRow.SelectionMode);
            if (checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
                this.AdaptStackesInZone(bindRow.Zone_ID, checkState);

            this.SelectStack();
        }

        private void dgvStackes_SelectionChanged(object sender, EventArgs e)
        {
            this.SelectStack();
        }

        private void SelectStack()
        {
            this.ClearLocationInStackFilter();

            if (this.inventoryTargetStackesInZoneBindingSource.Current == null || dgvStackes.SelectedRows.Count == 0)
                return;

            var bindRow = (this.inventoryTargetStackesInZoneBindingSource.Current as DataRowView).Row as Data.Inventory.InventoryTargetStackesInZoneRow;
            this.SelectedStack = bindRow;
            this.SetLocationInStackFilter(bindRow.Zone_ID, bindRow.Aisl);

            var checkState = GetInventoryTargetPlacementItemCheckState(bindRow.IsSelectionModeNull() ? (string)null : bindRow.SelectionMode);
            if (checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
                this.AdaptLocationsInStack(bindRow.Zone_ID, bindRow.Aisl, checkState);
        }

        private void dgvInventoryTargetPlacement_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            var gridView = sender as DataGridView;
            if (gridView.CurrentCell is DataGridViewCheckBoxCell)
            {
                gridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvInventoryTargetPlacement_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var gridView = sender as DataGridView;

            if (gridView.InvokeRequired)
                gridView.Invoke((MethodInvoker)delegate() { this.ChangeGridViewStyle(gridView, e); });
            else
                this.ChangeGridViewStyle(gridView, e);
        }

        /// <summary>
        /// Изменения стиля визуализации представления
        /// </summary>
        private void ChangeGridViewStyle(DataGridView gridView, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = this.IsRowSelected(gridView, e.RowIndex);
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(229, 243, 247) : SystemColors.Window;
            gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(229, 243, 247) : Color.Black;
        }

        private void dgvWarehouses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var gridView = sender as DataGridView;
            var warehouse = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryTargetWarehousesRow;

            var checkState = this.GetInventoryTargetPlacementItemCheckState(warehouse.IsSelectionModeNull() ? (string)null : warehouse.SelectionMode);
            if (checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
            {
                this.AdaptZonesInWarehouse(warehouse.Warehouse_id, checkState);
                if (this.SelectedZone != null)
                {
                    this.AdaptStackesInZone(this.SelectedZone.Zone_ID, checkState);
                    if (this.SelectedStack != null)
                    {
                        this.AdaptLocationsInStack(this.SelectedZone.Zone_ID, this.SelectedStack.Aisl, checkState);
                    }
                }
            }
        }

        private void dgvZones_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var gridView = sender as DataGridView;
            var zone = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryTargetZoneInWarehouseRow;
            var checkState = this.GetInventoryTargetPlacementItemCheckState(zone.IsSelectionModeNull() ? (string)null : zone.SelectionMode);
            if (checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
            {
                this.AdaptStackesInZone(zone.Zone_ID, checkState);
            }

            if (checkState == InventoryTargetPlacementItemCheckState.NotChecked)
            {
                this.ChangeLocationsInStackState(InventoryTargetPlacementItemCheckState.NotChecked);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }

            if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll)
            {
                this.ChangeLocationsInStackState(InventoryTargetPlacementItemCheckState.CheckedAll);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }
        }

        private void dgvStackes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var gridView = sender as DataGridView;
            var stack = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryTargetStackesInZoneRow;

            var checkState = this.GetInventoryTargetPlacementItemCheckState(stack.IsSelectionModeNull() ? (string)null : stack.SelectionMode);
            if (checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
            {
                this.AdaptLocationsInStack(stack.Zone_ID, stack.Aisl, checkState);
            }

            if (checkState == InventoryTargetPlacementItemCheckState.NotChecked)
            {
                //this.ChangeLocationsInStackState(InventoryTargetPlacementItemCheckState.NotChecked);
                this.ChangeZoneState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }

            if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll)
            {
                //this.ChangeLocationsInStackState(InventoryTargetPlacementItemCheckState.CheckedAll);
                this.ChangeZoneState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }

            //if (checkState != InventoryTargetPlacementItemCheckState.NotChecked && checkState != InventoryTargetPlacementItemCheckState.CheckedSeveral)
            //{
            //    this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            //}
        }

        private void dgvLocations_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var gridView = sender as DataGridView;
            var location = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.InventoryTargetLocationsInStackRow;

            var checkState = this.GetInventoryTargetPlacementItemCheckState(location.IsSelectionModeNull() ? (string)null : location.SelectionMode);
            if (checkState == InventoryTargetPlacementItemCheckState.CheckedSeveral)
            {
                gridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = IdentityAttribute.GetIdentityID(InventoryTargetPlacementItemCheckState.NotChecked);
                gridView.RefreshEdit();
            }

            if (checkState == InventoryTargetPlacementItemCheckState.NotChecked)
            {
                this.ChangeStackState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeZoneState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }

            if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll)
            {
                this.ChangeStackState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeZoneState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
                this.ChangeWarehouseState(InventoryTargetPlacementItemCheckState.CheckedSeveral);
            }
        }

        private void ChangeWarehouseState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);
            if (string.IsNullOrEmpty(selectionMode))
                this.SelectedWarehouse.SetSelectionModeNull();
            else
                this.SelectedWarehouse.SelectionMode = selectionMode;
        } 

        private void ChangeZoneState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);
            if (string.IsNullOrEmpty(selectionMode))
                this.SelectedZone.SetSelectionModeNull();
            else 
                this.SelectedZone.SelectionMode = selectionMode;
        }

        private void ChangeStackState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);
            if (string.IsNullOrEmpty(selectionMode))
                this.SelectedStack.SetSelectionModeNull();
            else
                this.SelectedStack.SelectionMode = selectionMode;
        }

        private void ChangeStackesInZoneState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);
            foreach (Data.Inventory.InventoryTargetStackesInZoneRow stack in this.inventory.InventoryTargetStackesInZone.Select(this.inventoryTargetStackesInZoneBindingSource.Filter))
            {
                if (string.IsNullOrEmpty(selectionMode))
                    stack.SetSelectionModeNull();
                else
                    stack.SelectionMode = selectionMode;
            }
        }

        private void ChangeLocationsInStackState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);

            BackgroundWorker changeCheckWorker = new BackgroundWorker();
            changeCheckWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    foreach (Data.Inventory.InventoryTargetLocationsInStackRow location in this.inventory.InventoryTargetLocationsInStack.Select(this.inventoryTargetLocationsInStackBindingSource.Filter))
                    {
                        if (string.IsNullOrEmpty(selectionMode))
                            location.SetSelectionModeNull();
                        else
                            location.SelectionMode = selectionMode;
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            changeCheckWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                waitProcessForm.CloseForce();
            };
            waitProcessForm.ActionText = "Выполняется автоматическое изменение выбора для мест по стеллажу..";
            changeCheckWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        private void ChangeZonesInWarehouseState(InventoryTargetPlacementItemCheckState checkState)
        {
            string selectionMode = IdentityAttribute.GetIdentityID(checkState);
            foreach (Data.Inventory.InventoryTargetZoneInWarehouseRow zone in this.inventory.InventoryTargetZoneInWarehouse.Select(this.inventoryTargetZoneInWarehouseBindingSource.Filter))
            {
                if (string.IsNullOrEmpty(selectionMode))
                    zone.SetSelectionModeNull();
                else
                    zone.SelectionMode = selectionMode;
            }
        }

        /// <summary>
        /// Очистка фильтра зон в складе
        /// </summary>
        private void ClearZonesInWarehousesFilter()
        {
            this.SetZonesInWarehousesFilter(string.Empty);
        }

        /// <summary>
        /// Установка фильтра зон в складе
        /// </summary>
        /// <param name="warehouseID"></param>
        private void SetZonesInWarehousesFilter(string warehouseID)
        {
            this.inventoryTargetZoneInWarehouseBindingSource.Filter = this.CreateZonesInWarehousesFilter(warehouseID);
        }

        /// <summary>
        /// Создание фильтра зон в складе
        /// </summary>
        /// <param name="warehouseID"></param>
        private string CreateZonesInWarehousesFilter(string warehouseID)
        {
            return string.Format("{0} = '{1}'", this.inventory.InventoryTargetZoneInWarehouse.Warehouse_IDColumn.Caption, warehouseID);
        }

        /// <summary>
        /// Очистка фильтра стеллажей в зоне
        /// </summary>
        private void ClearStackesInZoneFilter()
        {
            this.SetStackesInZoneFilter(-1);
        }

        /// <summary>
        /// Установка фильтра стеллажей в зоне
        /// </summary>
        private void SetStackesInZoneFilter(int zoneID)
        {
            this.inventoryTargetStackesInZoneBindingSource.Filter = this.CreateStackesInZoneFilter(zoneID);
        }

        /// <summary>
        /// Создание фильтра стеллажей в зоне
        /// </summary>
        private string CreateStackesInZoneFilter(int zoneID)
        {
            return string.Format("{0} = {1}", this.inventory.InventoryTargetStackesInZone.Zone_IDColumn.Caption, zoneID);
        }

        /// <summary>
        /// Очистка фильтра мест в стеллаже
        /// </summary>
        private void ClearLocationInStackFilter()
        {
            this.SetLocationInStackFilter(-1, string.Empty);
        }

        /// <summary>
        /// Установка фильтра для мест в стеллаже
        /// </summary>
        /// <param name="zoneID"></param>
        private void SetLocationInStackFilter(int zoneID, string stackID)
        {
            this.inventoryTargetLocationsInStackBindingSource.Filter = this.CreateLocationInStackFilter(zoneID, stackID);
        }

        /// <summary>
        /// Создание фильтра для мест в стеллаже
        /// </summary>
        /// <param name="zoneID"></param>
        private string CreateLocationInStackFilter(int zoneID, string stackID)
        {
            return string.Format("{0} = {1} AND {2} = '{3}'", this.inventory.InventoryTargetLocationsInStack.Zone_IDColumn.Caption, zoneID, this.inventory.InventoryTargetLocationsInStack.AislColumn.Caption, stackID);
        }

        /// <summary>
        /// Адаптация складов
        /// </summary>
        private void AdaptWarehouses()
        {
            try
            {
                this.inventoryTargetWarehousesTableAdapter.Fill(this.inventory.InventoryTargetWarehouses, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Адаптация зон для склада 
        /// </summary>
        /// <param name="warehouseID"></param>
        /// <param name="checkState"></param>
        private void AdaptZonesInWarehouse(string warehouseID, InventoryTargetPlacementItemCheckState checkState)
        {
            try
            {
                if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll && !this.SelectedWarehouse.ZonesLoaded)
                {
                    this.inventoryTargetZoneInWarehouseTableAdapter.Fill(this.inventory.InventoryTargetZoneInWarehouse, this.UserID, warehouseID);
                    this.SelectedWarehouse.ZonesLoaded = true;
                }

                this.ChangeZonesInWarehouseState(checkState);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Адаптация стеллажей для зоны 
        /// </summary>
        /// <param name="zoneID"></param>
        /// <param name="checkState"></param>
        private void AdaptStackesInZone(int zoneID, InventoryTargetPlacementItemCheckState checkState)
        {
            try
            {
                if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll && !this.SelectedZone.StacksLoaded)
                {
                    this.inventoryTargetStackesInZoneTableAdapter.Fill(this.inventory.InventoryTargetStackesInZone, this.UserID, zoneID);
                    this.SelectedZone.StacksLoaded = true;
                }

                this.ChangeStackesInZoneState(checkState);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Адаптация мест для стеллажа
        /// </summary>
        /// <param name="zoneID"></param>
        /// <param name="checkState"></param>
        private void AdaptLocationsInStack(int zoneID, string stackID, InventoryTargetPlacementItemCheckState checkState)
        {
            if (checkState == InventoryTargetPlacementItemCheckState.CheckedAll && !this.SelectedStack.LocationsLoaded)
            {
                BackgroundWorker loadworker = new BackgroundWorker();
                loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        e.Result = this.inventoryTargetLocationsInStackTableAdapter.GetData(this.UserID, zoneID, stackID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.inventory.InventoryTargetLocationsInStack.Merge(e.Result as DataTable);

                        this.SetLocationInStackFilter(zoneID, stackID);
                        this.SelectedStack.LocationsLoaded = true;
                    }

                    waitProcessForm.CloseForce();
                };
                waitProcessForm.ActionText = "Выполняется получение перечня мест по стеллажу..";
                loadworker.RunWorkerAsync();
                waitProcessForm.ShowDialog();
            }

            this.ChangeLocationsInStackState(checkState);
        }

        /// <summary>
        /// Сохранение изменений
        /// </summary>
        private bool SaveChanges()
        {
            bool saveResult = false;
            //TransactionScope tsSaveTargetPlacement = null;

            BackgroundWorker saveWorker = new BackgroundWorker();
            saveWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    //// Создание транзакции при сохранении
                    //tsSaveTargetPlacement = new TransactionScope(TransactionScopeOption.Required);

                    // Цикл по складам
                    foreach (Data.Inventory.InventoryTargetWarehousesRow warehouse in this.inventory.InventoryTargetWarehouses)
                    {
                        var warehouseCheckState = this.GetInventoryTargetPlacementItemCheckState(warehouse.IsSelectionModeNull() ? (string)null : warehouse.SelectionMode);
                        if (warehouseCheckState == InventoryTargetPlacementItemCheckState.NotChecked)
                            continue;

                        // Цикл по зонам
                        foreach (Data.Inventory.InventoryTargetZoneInWarehouseRow zone in this.inventory.InventoryTargetZoneInWarehouse.Select(this.CreateZonesInWarehousesFilter(warehouse.Warehouse_id)))
                        {
                            var zoneCheckState = this.GetInventoryTargetPlacementItemCheckState(zone.IsSelectionModeNull() ? (string)null : zone.SelectionMode);
                            if (zoneCheckState == InventoryTargetPlacementItemCheckState.NotChecked)
                                continue;

                            if (zoneCheckState == InventoryTargetPlacementItemCheckState.CheckedAll)
                            {
                                // Добавление всех стеллажей в зоне
                                this.SaveInventoryTargetPlacement(zone.Zone_ID, (string)null, (string)null);
                                continue;
                            }

                            if (zoneCheckState == InventoryTargetPlacementItemCheckState.CheckedSeveral)
                            {
                                // Цикл по стеллажам
                                foreach (Data.Inventory.InventoryTargetStackesInZoneRow stack in this.inventory.InventoryTargetStackesInZone.Select(this.CreateStackesInZoneFilter(zone.Zone_ID)))
                                {
                                    var stackCheckState = this.GetInventoryTargetPlacementItemCheckState(stack.IsSelectionModeNull() ? (string)null : stack.SelectionMode);
                                    if (stackCheckState == InventoryTargetPlacementItemCheckState.NotChecked)
                                        continue;

                                    if (stackCheckState == InventoryTargetPlacementItemCheckState.CheckedAll)
                                    {
                                        // Добавление всех мест в стеллаже
                                        this.SaveInventoryTargetPlacement(zone.Zone_ID, stack.Aisl, (string)null);
                                        continue;
                                    }

                                    if (stackCheckState == InventoryTargetPlacementItemCheckState.CheckedSeveral)
                                    {
                                        // Цикл по местам
                                        foreach (Data.Inventory.InventoryTargetLocationsInStackRow location in this.inventory.InventoryTargetLocationsInStack.Select(this.CreateLocationInStackFilter(zone.Zone_ID, stack.Aisl)))
                                        {
                                            var locationCheckState = this.GetInventoryTargetPlacementItemCheckState(location.IsSelectionModeNull() ? (string)null : location.SelectionMode);
                                            if (locationCheckState == InventoryTargetPlacementItemCheckState.NotChecked)
                                                continue;

                                            // Добавление места в стеллаже
                                            this.SaveInventoryTargetPlacement(zone.Zone_ID, stack.Aisl, location.Location_ID);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            saveWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    //tsSaveTargetPlacement.Complete();
                    saveResult = true;
                }

                waitProcessForm.CloseForce();
            };
            waitProcessForm.ActionText = "Выполняется сохранение выбранных мест для проведения инвентаризации..";
            saveWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            return saveResult;
        }

        /// <summary>
        /// Добавление места в инвентаризацию
        /// </summary>
        /// <param name="zoneID"></param>
        /// <param name="locationID"></param>
        private void SaveInventoryTargetPlacement(int zoneID, string stackID, string locationID)
        {
            // TODO Test only
            //System.Diagnostics.Debug.Write(string.Format("{0} {1} {2}\n", zoneID, string.IsNullOrEmpty(stackID) ? "NULL" : stackID, string.IsNullOrEmpty(locationID) ? "NULL" : locationID));
            using (Data.InventoryTableAdapters.InventoryTargetLocationsInStackTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryTargetLocationsInStackTableAdapter())
                adapter.AddInventoryTargetPlacement(this.UserID, this.InventoryDocID, zoneID, locationID, stackID);
        }

        private void InventoryTargetPlacementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                this.SaveChanges();
        }
    }

    /// <summary>
    /// Состояние выбора элемента места проведения инвентаризации
    /// </summary>
    public enum InventoryTargetPlacementItemCheckState
    {
        ///// <summary>
        ///// Неизвестно
        ///// </summary>
        //Unknown = -1,

        /// <summary>
        /// Не выбрано
        /// </summary>
        [Identity("0")]
        NotChecked = 0,

        /// <summary>
        /// Выбрано несколько
        /// </summary>
        [Identity(null)]
        CheckedSeveral = 1,

        /// <summary>
        /// Выбрано все
        /// </summary>
        [Identity("1")]
        CheckedAll = 2,
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class IdentityAttribute : Attribute
    {
        public string ID { get; private set; }
        public IdentityAttribute(string id)
        {
            this.ID = id;
        }

        /// <summary>
        /// Получить описание элемента перечисления
        /// </summary>
        /// <param name="field"></param>
        /// <returns></returns>
        public static string GetIdentityID(object field)
        {
            FieldInfo fi = field.GetType().GetField(field.ToString());

            if (fi != null)
            {
                object[] attrs = fi.GetCustomAttributes(typeof(IdentityAttribute), true);
                if (attrs != null && attrs.Length > 0)
                    return ((IdentityAttribute)attrs[0]).ID;
            }

            return null;
        }
    }
}
