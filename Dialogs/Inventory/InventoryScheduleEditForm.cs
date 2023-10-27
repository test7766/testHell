using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryScheduleEditForm : DialogForm
    {
        public long? PlanID { get; private set; }

        private readonly Data.Inventory.InventoriesScheduleRow _InventorySchedule = null;

        public bool CreateMode { get { return _InventorySchedule == null; } }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public InventoryScheduleEditForm()
        {
            InitializeComponent();
        }

        public InventoryScheduleEditForm(Data.Inventory.InventoriesScheduleRow inventorySchedule)
            : this()
        {
            _InventorySchedule = inventorySchedule;
        }

        private void InventoryScheduleEditForm_Load(object sender, EventArgs e)
        {
            LoadWarehouses();
            LoadTypes();
        }

        private void LoadWarehouses()
        {
            try
            {
                inventoriesScheduleWarehousesTableAdapter.Fill(inventory.InventoriesScheduleWarehouses, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTypes()
        {
            try
            {
                inventoriesScheduleTypesTableAdapter.Fill(inventory.InventoriesScheduleTypes, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(1017, 8);
            this.btnCancel.Location = new Point(1107, 8);

            Initialize();

            LoadWarehousesElements();

            var lstSelectedWarehouses = GetSelectedWarehouses(true);
            LoadStationsElements(lstSelectedWarehouses);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Initialize()
        {
            this.Text = string.Format("{0} [{1}]", this.Text, this.CreateMode ? "*" : _InventorySchedule.pln_id.ToString());

            if (this.CreateMode)
            {
                this.PlanID = this.Create();
            }
            else
            {
                this.PlanID = _InventorySchedule.pln_id;

                cmbWarehouse.SelectedValue = _InventorySchedule.Isfilial_codeNull() ? (string)null : _InventorySchedule.filial_code;
                cmbInventoryType.SelectedValue = _InventorySchedule.fi_type;

                dtpInventoryPlanDate.Value = _InventorySchedule.Isplan_date_dNull() ? DateTime.Today : _InventorySchedule.plan_date_d.Date;
                dtpInventoryPlanTime.Value = _InventorySchedule.Isplan_date_dNull() ? DateTime.Now : _InventorySchedule.plan_date_d;

                tbDescription.Text = _InventorySchedule.Ispln_dscNull() ? (string)null : _InventorySchedule.pln_dsc;
            }

            CustomCheckHeader(dgvWarehouses.Columns[0], warehouseHeaderCell_OnCheckBoxClicked);
            CustomCheckHeader(dgvStations.Columns[0], stationHeaderCell_OnCheckBoxClicked);
            CustomCheckHeader(dgvLocations.Columns[0], locationHeaderCell_OnCheckBoxClicked);
        }

        public List<WMSOffice.Data.Inventory.InventoriesScheduleWarehousesElementsRow> GetSelectedWarehouses(bool loadingMode)
        {
            var lstWarehouses = new List<WMSOffice.Data.Inventory.InventoriesScheduleWarehousesElementsRow>();

            foreach (Data.Inventory.InventoriesScheduleWarehousesElementsRow warehouse in inventory.InventoriesScheduleWarehousesElements.Rows)
                if (warehouse.checked_flag && (loadingMode ? !warehouse.nested_elements_loaded : true))
                    lstWarehouses.Add(warehouse);

            return lstWarehouses;
        }

        public List<Data.Inventory.InventoriesScheduleStationsElementsRow> GetSelectedStations(bool loadingMode)
        {
            var lstStations = new List<Data.Inventory.InventoriesScheduleStationsElementsRow>();

            foreach (Data.Inventory.InventoriesScheduleStationsElementsRow station in inventory.InventoriesScheduleStationsElements.Rows)
                if (station.checked_flag && (loadingMode ? !station.nested_elements_loaded : true))
                    lstStations.Add(station);

            return lstStations;
        }

        public List<Data.Inventory.InventoriesScheduleLocationsElementsRow> GetSelectedLocations(bool loadingMode)
        {
            var lstLocations = new List<Data.Inventory.InventoriesScheduleLocationsElementsRow>();

            foreach (Data.Inventory.InventoriesScheduleLocationsElementsRow location in inventory.InventoriesScheduleLocationsElements.Rows)
                if (location.checked_flag && (loadingMode ? !location.nested_elements_loaded : true))
                    lstLocations.Add(location);

            return lstLocations;
        }

        #region ЗАГРУЗКА И ФИЛЬТРАЦИЯ ЭЛЕМЕНТОВ ИНВЕНТАРИЗАЦИИ

        private static void CustomCheckHeader(DataGridViewColumn pColumn, CheckBoxClickedHandler pHandler)
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += pHandler;
            checkHeaderCell.Value = String.Empty;
            pColumn.HeaderCell = checkHeaderCell;
        }

        public void warehouseHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvWarehouses.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;

            this.LoadStationsSelectedElements();
        }

        public void stationHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvStations.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;

            this.LoadLocationsSelectedElements();
        }

        public void locationHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvLocations.Rows)
                if (Convert.ToBoolean((row.Cells[0] as DataGridViewCheckBoxCell).Value) != pState)
                    (row.Cells[0] as DataGridViewCheckBoxCell).Value = pState;
        }

        private void dgvWarehouses_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvWarehouses.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvWarehouses.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(dgvWarehouses.Rows[dgvWarehouses.CurrentRow.Index].Cells[0].Value);
                foreach (DataGridViewColumn column in dgvWarehouses.Columns)
                {
                    dgvWarehouses.Rows[dgvWarehouses.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    dgvWarehouses.Rows[dgvWarehouses.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }

                this.LoadStationsSelectedElements();
            }
        }

        private void dgvStations_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvStations.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvStations.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(dgvStations.Rows[dgvStations.CurrentRow.Index].Cells[0].Value);
                foreach (DataGridViewColumn column in dgvStations.Columns)
                {
                    dgvStations.Rows[dgvStations.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    dgvStations.Rows[dgvStations.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }

                this.LoadLocationsSelectedElements();
            }
        }

        private void dgvLocations_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvLocations.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvLocations.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(dgvLocations.Rows[dgvLocations.CurrentRow.Index].Cells[0].Value);
                foreach (DataGridViewColumn column in dgvLocations.Columns)
                {
                    dgvLocations.Rows[dgvLocations.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    dgvLocations.Rows[dgvLocations.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void LoadWarehousesSelectedElements()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            { 
                try
                {
                    this.LoadWarehousesElements();
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                splashForm.CloseForce();

                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    inventoriesScheduleWarehousesElementsBindingSource.DataSource = inventory.InventoriesScheduleWarehousesElements;
                    //inventoriesScheduleWarehousesElementsBindingSource.Sort = "warehouse_id";

                    SetWarehousesElementsFilter();
                }
            };
            inventoriesScheduleWarehousesElementsBindingSource.DataSource = null;
            splashForm.ActionText = "Подготовка складов..";
            bw.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        private void LoadWarehousesElements()
        {
            inventoriesScheduleWarehousesElementsTableAdapter.ClearBeforeFill = false;
            inventoriesScheduleWarehousesElementsTableAdapter.Fill(inventory.InventoriesScheduleWarehousesElements, this.UserID, this.PlanID);
        }

        private void LoadStationsSelectedElements()
        {
            var lstSelectedWarehouses = GetSelectedWarehouses(true);

            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                try
                {
                    this.LoadStationsElements(lstSelectedWarehouses);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                splashForm.CloseForce();

                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    inventoriesScheduleStationsElementsBindingSource.DataSource = inventory.InventoriesScheduleStationsElements;
                    //inventoriesScheduleStationsElementsBindingSource.Sort = "station_id";

                    SetStationsElementsFilter();
                    SetLocationsElementsFilter();
                }
            };
            inventoriesScheduleStationsElementsBindingSource.DataSource = null;
            splashForm.ActionText = "Подготовка станций..";
            bw.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        private void LoadStationsElements(List<Data.Inventory.InventoriesScheduleWarehousesElementsRow> lstWarehouses)
        {
            foreach (var warehouse in lstWarehouses)
            {
                var warehouseID = warehouse.warehouse_id;

                inventoriesScheduleStationsElementsTableAdapter.ClearBeforeFill = false;
                inventoriesScheduleStationsElementsTableAdapter.Fill(inventory.InventoriesScheduleStationsElements, this.UserID, this.PlanID, warehouseID);

                warehouse.nested_elements_loaded = true;
            }
        }

        private void LoadLocationsSelectedElements()
        {
            var lstSelectedStations = GetSelectedStations(true);

            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                try
                {
                    this.LoadLocationsElements(lstSelectedStations);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                splashForm.CloseForce();

                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    inventoriesScheduleLocationsElementsBindingSource.DataSource = inventory.InventoriesScheduleLocationsElements;
                    //inventoriesScheduleLocationsElementsBindingSource.Sort = "place_code";

                    SetLocationsElementsFilter();
                }
            };
            inventoriesScheduleLocationsElementsBindingSource.DataSource = null;
            splashForm.ActionText = "Подготовка мест..";
            bw.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        private void LoadLocationsElements(List<Data.Inventory.InventoriesScheduleStationsElementsRow> lstStations)
        {
            foreach (var station in lstStations)
            {
                var stationID = Convert.ToInt32(station.station_id);

                inventoriesScheduleLocationsElementsTableAdapter.ClearBeforeFill = false;
                inventoriesScheduleLocationsElementsTableAdapter.Fill(inventory.InventoriesScheduleLocationsElements, this.UserID, this.PlanID, stationID);

                station.nested_elements_loaded = true;
            }
        }

        private void SetWarehousesElementsFilter()
        {
            var sFilter = (string)null;
            inventoriesScheduleWarehousesElementsBindingSource.Filter = sFilter;
        }

        private void SetStationsElementsFilter()
        {
            var sbWarehouses = new StringBuilder();
            foreach (var warehouse in this.GetSelectedWarehouses(false))
                if (sbWarehouses.Length > 0)
                    sbWarehouses.AppendFormat(",'{0}'", warehouse.warehouse_id);
                else
                    sbWarehouses.AppendFormat("'{0}'", warehouse.warehouse_id);

            var sFilter = sbWarehouses.Length > 0 ? string.Format("warehouse_id in ({0})", sbWarehouses) : "1=0";
            inventoriesScheduleStationsElementsBindingSource.Filter = sFilter;
        }

        private void SetLocationsElementsFilter()
        {
            var sbWarehouses = new StringBuilder();
            foreach (var warehouse in this.GetSelectedWarehouses(false))
                if (sbWarehouses.Length > 0)
                    sbWarehouses.AppendFormat(",'{0}'", warehouse.warehouse_id);
                else
                    sbWarehouses.AppendFormat("'{0}'", warehouse.warehouse_id);

            var sbStations = new StringBuilder();
            foreach (var station in this.GetSelectedStations(false))
                if (sbStations.Length > 0)
                    sbStations.AppendFormat(",'{0}'", station.station_code);
                else
                    sbStations.AppendFormat("'{0}'", station.station_code);

            var sFilter = sbWarehouses.Length > 0 && sbStations.Length > 0 ? string.Format("warehouse_id in ({0}) and station_code in ({1})", sbWarehouses, sbStations) : "1=0";
            inventoriesScheduleLocationsElementsBindingSource.Filter = sFilter;
        }

        private void dgvWarehouses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(dgvWarehouses.Rows[e.RowIndex].Cells[0].Value);
            dgvWarehouses.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvWarehouses.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvStations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(dgvStations.Rows[e.RowIndex].Cells[0].Value);
            dgvStations.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvStations.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvLocations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(dgvLocations.Rows[e.RowIndex].Cells[0].Value);
            dgvLocations.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvLocations.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvWarehouses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void dgvStations_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void dgvLocations_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }
        #endregion

        private void InventoryScheduleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !this.CommitData();
            }
            else
            {
                if (this.CreateMode)
                    this.RollbackData();
            }
        }

        private bool CommitData()
        {
            try
            {
                this.Modify();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool RollbackData()
        {
            try
            {
                this.Delete();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private long? Create()
        {
            try
            {
                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    return Convert.ToInt64(adapter.Create(this.UserID));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (long?)null;
            }
        }

        private void Modify()
        {
            try
            {
                var inventoryType = cmbInventoryType.SelectedValue.ToString();
                var warehouseID = cmbWarehouse.SelectedValue.ToString();

                var planDate = dtpInventoryPlanDate.Value.Date;
                var planTime = dtpInventoryPlanTime.Value.ToShortTimeString();

                var planDescription = tbDescription.Text;

                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    adapter.Modify(this.UserID, this.PlanID, inventoryType, warehouseID, planDate, planTime, planDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete()
        {
            try
            {
                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    adapter.Remove(this.UserID, this.PlanID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            this.Export();
        }

        private void Export()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                try
                {
                    var stream = new MemoryStream(Properties.Resources.FI_Inventory_Elements);

                    var workBook = new XSSFWorkbook(stream);

                    ISheet workSheet = null;
                    int rowIndex;

                    #region ЭКСПОРТ СКЛАДОВ
                    workSheet = workBook.GetSheet("Склады");

                    rowIndex = 1;
                    foreach (var warehouse in this.GetSelectedWarehouses(false))
                    {
                        IRow row = workSheet.CreateRow(rowIndex);

                        if (!warehouse.Iswarehouse_idNull())
                            row.CreateCell(0).SetCellValue(warehouse.warehouse_id);

                        if (!warehouse.Iswarehouse_nameNull())
                            row.CreateCell(1).SetCellValue(warehouse.warehouse_name);

                        rowIndex++;
                    }
                    #endregion

                    #region ЭКСПОРТ СТАНЦИЙ
                    workSheet = workBook.GetSheet("Станции");

                    rowIndex = 1;
                    foreach (var station in this.GetSelectedStations(false))
                    {
                        IRow row = workSheet.CreateRow(rowIndex);

                        row.CreateCell(0).SetCellValue(station.station_id);

                        if (!station.Isstation_codeNull())
                            row.CreateCell(1).SetCellValue(station.station_code);

                        if (!station.Isstation_descriptionNull())
                            row.CreateCell(2).SetCellValue(station.station_description);

                        row.CreateCell(3).SetCellValue(station.warehouse_id);

                        if (!station.Isstage_nameNull())
                            row.CreateCell(4).SetCellValue(station.stage_name);

                        if (!station.Isplace_startNull())
                            row.CreateCell(5).SetCellValue(station.place_start);

                        if (!station.Isplace_finishNull())
                            row.CreateCell(6).SetCellValue(station.place_finish);

                        rowIndex++;
                    }
                    #endregion

                    #region ЭКСПОРТ МЕСТ
                    workSheet = workBook.GetSheet("Места");

                    rowIndex = 1;
                    foreach (var location in this.GetSelectedLocations(false))
                    {
                        IRow row = workSheet.CreateRow(rowIndex);

                        if (!location.Isplace_codeNull())
                        row.CreateCell(0).SetCellValue(location.place_code);
                      
                        row.CreateCell(1).SetCellValue(location.station_code);

                        if (!location.Iswarehouse_idNull())
                            row.CreateCell(2).SetCellValue(location.warehouse_id);

                        if (!location.IslmaislNull())
                            row.CreateCell(3).SetCellValue(location.lmaisl);

                        if (!location.IslmbinNull())
                            row.CreateCell(4).SetCellValue(location.lmbin);

                        if (!location.Islmla03Null())
                            row.CreateCell(5).SetCellValue(location.lmla03);

                        if (!location.Islmla04Null())
                            row.CreateCell(6).SetCellValue(location.lmla04);

                        if (!location.Islmla05Null())
                            row.CreateCell(7).SetCellValue(location.lmla05);

                        if (!location.Isroute_idNull())
                            row.CreateCell(8).SetCellValue(location.route_id);

                        rowIndex++;
                    }
                    #endregion

                    e.Result = workBook;
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                splashForm.CloseForce();

                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    {
                        var workBook = e.Result as XSSFWorkbook;

                        var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("Объекты инвентаризации по плану №{0}.xlsx", this.PlanID));
                        using (var fs = new FileStream(filePath, FileMode.Create))
                        {
                            workBook.Write(fs);
                            fs.Close();

                            Process.Start(filePath);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };
            splashForm.ActionText = "Экспорт объектов инвентаризации..";
            bw.RunWorkerAsync();
            splashForm.ShowDialog();
        }
    }
}
