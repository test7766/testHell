using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class RemainsWithMovementsDispatcherWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.WH.MV_RemainsRow SelectedRemainsItem { get { return xdgvRemains.SelectedItem as Data.WH.MV_RemainsRow; } }

        public RemainsWithMovementsDispatcherWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();
        }

        private void Initialize()
        {
            stbBusinessUnitFrom.ValueReferenceQuery = "[dbo].[pr_MV_Get_MCU]";
            stbBusinessUnitFrom.UserID = this.UserID;
            stbBusinessUnitFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbBusinessUnitFrom.SetFirstValueByDefault();

            stbBusinessUnitTo.ValueReferenceQuery = "[dbo].[pr_MV_Get_MCU]";
            stbBusinessUnitTo.UserID = this.UserID;
            stbBusinessUnitTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbBusinessUnitTo.SetLastValueByDefault();

            stbItem.ValueReferenceQuery = "[dbo].[pr_MV_Get_Items]";
            stbItem.ApplyAdditionalParameter("ITM_NAME", string.Empty);
            stbItem.UserID = this.UserID;
            stbItem.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbItem.SetValueByDefault(string.Empty);
            
            stbVendorLot.ValueReferenceQuery = "[dbo].[pr_MV_Get_VendorLots]";
            stbVendorLot.ApplyAdditionalParameter("WH_From", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("WH_To", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("ITM", string.Empty);
            stbVendorLot.ApplyAdditionalParameter("flagAllRemains", string.Empty);
            stbVendorLot.UserID = this.UserID;
            stbVendorLot.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbVendorLot.SetValueByDefault(string.Empty);

            stbLocation.ValueReferenceQuery = "[dbo].[pr_MV_Get_Locations]";         
            stbLocation.ApplyAdditionalParameter("WH_From", string.Empty);
            stbLocation.ApplyAdditionalParameter("WH_To", string.Empty);
            stbLocation.ApplyAdditionalParameter("ITM", string.Empty);
            stbLocation.ApplyAdditionalParameter("flagAllRemains", string.Empty);
            stbLocation.UserID = this.UserID;
            stbLocation.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbLocation.SetValueByDefault(string.Empty);

            stbBatchNumber.ValueReferenceQuery = "[dbo].[pr_MV_Get_BatchNumbers]";
            stbBatchNumber.ApplyAdditionalParameter("WH_From", string.Empty);
            stbBatchNumber.ApplyAdditionalParameter("WH_To", string.Empty);
            stbBatchNumber.ApplyAdditionalParameter("ITM", string.Empty);
            stbBatchNumber.ApplyAdditionalParameter("flagAllRemains", string.Empty);
            stbBatchNumber.UserID = this.UserID;
            stbBatchNumber.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stb_OnVerifyValue);
            stbBatchNumber.SetValueByDefault(string.Empty);

            var today = DateTime.Today;
            dtpDateFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpDateTo.Value = today; //new DateTime(today.Year, today.Month, DateTime.DaysInMonth(today.Year, today.Month));

            var tabPageFont = new Font(tcMain.Font.FontFamily, 8.25f);
            tcMain.Font = new Font(tcMain.Font.FontFamily, 12.0f);
            tpRemains.Font = tabPageFont;
            tpMovements.Font = tabPageFont;
            tcMain.DrawMode = TabDrawMode.OwnerDrawFixed;
           

            
            xdgvRemains.AllowSummary = false;
            xdgvRemains.AllowRangeColumns = true;

            xdgvRemains.UseMultiSelectMode = false;

            xdgvRemains.Init(new MVRemainsView(), true);
            xdgvRemains.LoadExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvRemains.Name));

            xdgvRemains.UserID = this.UserID;

            xdgvRemains.OnDataError += new DataGridViewDataErrorEventHandler(xdgvRemains_OnDataError);
            xdgvRemains.OnFilterChanged += new EventHandler(xdgvRemains_OnFilterChanged);
            xdgvRemains.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvRemains_OnFormattingCell);
            xdgvRemains.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvRemains_OnСustomSummaryCalculation);
            xdgvRemains.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvRemains_OnRowDoubleClick);

            // активация постраничного просмотра
            xdgvRemains.CreatePageNavigator();



            xdgvMovements.AllowSummary = false;
            xdgvMovements.AllowRangeColumns = true;

            xdgvMovements.UseMultiSelectMode = false;

            xdgvMovements.Init(new MVMovementsView(), true);
            xdgvMovements.LoadExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvMovements.Name));

            xdgvMovements.UserID = this.UserID;

            xdgvMovements.OnDataError += new DataGridViewDataErrorEventHandler(xdgvMovements_OnDataError);
            xdgvMovements.OnFilterChanged += new EventHandler(xdgvMovements_OnFilterChanged);
            xdgvMovements.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvMovements_OnFormattingCell);
            xdgvMovements.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvMovements_OnСustomSummaryCalculation);

            // активация постраничного просмотра
            xdgvMovements.CreatePageNavigator();


            SetOperationsAccess();
        }

        void xdgvRemains_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvRemains_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
            xdgvRemains.RecalculateSummary();
        }

        void xdgvRemains_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var remainsRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.MV_RemainsRow;

            #region ИНДИКАЦИЯ ГРУППЫ "ОСТАТКИ И РЕЗЕРВЫ"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "StockQuantity" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "AvailableQuantity" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "ReserveQuantity" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "TaskReserveQuantity" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "TransitQuantity")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 153);
            }
            #endregion

            #region ИНДИКАЦИЯ ПРОМЕЖУТОЧНОГО ИТОГА
            var rowType = remainsRow.RowType;
            if (rowType == 1)
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.SelectionForeColor = Color.LightGreen;

                if (grid.Columns[e.ColumnIndex].DataPropertyName == "ItemID" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "ItemName" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "WarehouseCode" ||

                    grid.Columns[e.ColumnIndex].DataPropertyName == "StockQuantity" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "AvailableQuantity" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "ReserveQuantity" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "TaskReserveQuantity" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "TransitQuantity")
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
            #endregion
        }

        void xdgvRemains_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                if (e.PatternСolumn.DataFieldName == "StockQuantity" ||
                    e.PatternСolumn.DataFieldName == "AvailableQuantity" ||
                    e.PatternСolumn.DataFieldName == "ReserveQuantity" ||
                    e.PatternСolumn.DataFieldName == "TaskReserveQuantity" ||
                    e.PatternСolumn.DataFieldName == "TransitQuantity")
                {
                    var sumQuantity = 0;
                    foreach (DataRow dataRow in e.FilteredFullDataRows)
                    {
                        if (!dataRow[e.PatternСolumn.DataFieldName].Equals(DBNull.Value) && Convert.ToInt32(dataRow["RowType"]) != 1)
                            sumQuantity += Convert.ToInt32(dataRow[e.PatternСolumn.DataFieldName]);
                    }

                    e.TargetCell.Value = sumQuantity;
                    e.TargetCell.Style.BackColor = e.TargetCell.Style.SelectionBackColor = Color.FromArgb(255, 255, 153);
                    e.TargetCell.Style.ForeColor = e.TargetCell.Style.SelectionForeColor = Color.Black;

                    e.TargetCell.Style.Font = new Font(e.TargetCell.OwningRow.DataGridView.DefaultCellStyle.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {

            }
        }

        void xdgvRemains_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.SelectedRemainsItem == null)
                    return;

                var searchCriteria = this.CreateMovementsSearchCriteria();

                var dlgMovementsAdditionalFilterSelection = new MovementsAdditionalFilterSelectionForm
                {
                    Item = tbItem.Text,
                    PeriodFrom = dtpDateFrom.Value.Date,
                    PeriodTo = dtpDateTo.Value.Date,
                    Warehouse = !this.SelectedRemainsItem.IsWarehouseCodeNull() ? this.SelectedRemainsItem.WarehouseCode : (string)null,
                    Location_ = !this.SelectedRemainsItem.IsLocationCodeNull() ? this.SelectedRemainsItem.LocationCode : (string)null,
                    Batch = !this.SelectedRemainsItem.IsBatchNumberNull() ? this.SelectedRemainsItem.BatchNumber : (string)null
                };
                if (dlgMovementsAdditionalFilterSelection.ShowDialog() != DialogResult.OK)
                    return;

                searchCriteria.TargetWarehouse = dlgMovementsAdditionalFilterSelection.Warehouse;
                searchCriteria.TargetLocation = dlgMovementsAdditionalFilterSelection.Location_;
                searchCriteria.TargetBatch = dlgMovementsAdditionalFilterSelection.Batch;

                tcMain.SelectedTab = tpMovements;
                LoadMovements(searchCriteria);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }



        void xdgvMovements_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvMovements_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
            xdgvMovements.RecalculateSummary();
        }

        void xdgvMovements_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var movementsRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.MV_MovementsRow;

            #region ИНДИКАЦИЯ КОЛИЧЕСТВ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "QtyIT" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "QtyBase")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 153);

                if (e.Value.ToString().Contains("-"))
                {
                    //e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);

                    e.CellStyle.ForeColor = Color.Brown;
                    e.CellStyle.SelectionBackColor = Color.Salmon;
                }
                else
                {
                    e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                    e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 153);
                }
            }
            #endregion

            #region ИНДИКАЦИЯ ПРОМЕЖУТОЧНОГО ИТОГА
            var rowType = movementsRow.RowType;
            if (rowType == 1 || rowType == 3 || rowType == 4)
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.SelectionForeColor = Color.LightGreen;

                if (grid.Columns[e.ColumnIndex].DataPropertyName == "ItemID" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "ItemName" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "WarehouseCode" ||

                    grid.Columns[e.ColumnIndex].DataPropertyName == "QtyIT" ||
                    grid.Columns[e.ColumnIndex].DataPropertyName == "QtyBase")
                {
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                }
            }
            #endregion
        }

        void xdgvMovements_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                if (e.PatternСolumn.DataFieldName == "QtyIT" ||
                   e.PatternСolumn.DataFieldName == "QtyBase")
                {
                    var sumQuantity = 0;
                    foreach (DataRow dataRow in e.FilteredFullDataRows)
                    {
                        if (!dataRow[e.PatternСolumn.DataFieldName].Equals(DBNull.Value) && Convert.ToInt32(dataRow["RowType"]) == 2)
                            sumQuantity += Convert.ToInt32(dataRow[e.PatternСolumn.DataFieldName]);
                    }

                    e.TargetCell.Value = sumQuantity;
                    e.TargetCell.Style.BackColor = e.TargetCell.Style.SelectionBackColor = Color.FromArgb(255, 255, 153);
                    e.TargetCell.Style.ForeColor = e.TargetCell.Style.SelectionForeColor = Color.Black;

                    e.TargetCell.Style.Font = new Font(e.TargetCell.OwningRow.DataGridView.DefaultCellStyle.Font, FontStyle.Bold);
                }
            }
            catch (Exception ex)
            {

            }
        }



        private void tcMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            btnExportToExcel.Enabled = 
                tcMain.SelectedTab == tpRemains ? xdgvRemains.HasRows
                : tcMain.SelectedTab == tpMovements ? xdgvMovements.HasRows : false;
        }



        void stb_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox tbDescription = null;

            if (control == stbBusinessUnitFrom)
                tbDescription = tbBusinessUnitFrom;
            else if (control == stbBusinessUnitTo)
                tbDescription = tbBusinessUnitTo;
            else if (control == stbItem)
                tbDescription = tbItem;
            else if (control == stbVendorLot)
                tbDescription = tbVendorLot;
            else if (control == stbLocation)
                tbDescription = tbLocation;
            else if (control == stbBatchNumber)
                tbDescription = tbBatchNumber;

            if (tbDescription != null)
            {
                tbDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                tbDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (control == stbBusinessUnitFrom)
                {
                    stbVendorLot.ApplyAdditionalParameter("WH_From", e.Value); 
                    stbLocation.ApplyAdditionalParameter("WH_From", e.Value); 
                    stbBatchNumber.ApplyAdditionalParameter("WH_From", e.Value);
                }
                else if (control == stbBusinessUnitTo)
                {
                    stbVendorLot.ApplyAdditionalParameter("WH_To", e.Value); 
                    stbLocation.ApplyAdditionalParameter("WH_To", e.Value);
                    stbBatchNumber.ApplyAdditionalParameter("WH_To", e.Value);
                }
                else if (control == stbItem)
                {
                    stbVendorLot.ApplyAdditionalParameter("ITM", e.Value);
                    stbLocation.ApplyAdditionalParameter("ITM", e.Value);
                    stbBatchNumber.ApplyAdditionalParameter("ITM", e.Value);
                }

                // Настройка сброса зависимой сущности при смене независимой (при смене товара сбрасывается серия, полка, партия)
                if (control == stbBusinessUnitFrom)
                {
                    stbVendorLot.SetValueByDefault(string.Empty);
                    stbLocation.SetValueByDefault(string.Empty);
                    stbBatchNumber.SetValueByDefault(string.Empty);
                }
                else if (control == stbBusinessUnitTo)
                {
                    stbVendorLot.SetValueByDefault(string.Empty);
                    stbLocation.SetValueByDefault(string.Empty);
                    stbBatchNumber.SetValueByDefault(string.Empty);
                }
                else if (control == stbItem)
                {
                    stbVendorLot.SetValueByDefault(string.Empty);
                    stbLocation.SetValueByDefault(string.Empty);
                    stbBatchNumber.SetValueByDefault(string.Empty);
                }

                // Зачистка "быстрого" фильтра товара
                if (control == stbItem)
                {
                    if (e.Success && string.IsNullOrEmpty(e.Value))
                        tbQFilterItem.Clear();
                }

                if (e.Success)
                {
                    control.Value = e.Value;

                    //if (!string.IsNullOrEmpty(e.Value))
                    //    this.LoadData();
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (tcMain.SelectedTab == tpRemains)
                LoadRemains();
            else if (tcMain.SelectedTab == tpMovements)
                LoadMovements();
        }

        private void LoadRemains()
        {
            try
            {
                var searchCriteria = this.CreateRemainsSearchCriteria();
                LoadRemains(searchCriteria);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadRemains(MVRemainsSearchParameters searchCriteria)
        {
            try
            {
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvRemains.DataView.FillData(e.Argument as MVRemainsSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvRemains.BindData(false);

                        //this.xdgvRemains.AllowFilter = true;
                        this.xdgvRemains.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка остатков..";
                bw.RunWorkerAsync(searchCriteria);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private MVRemainsSearchParameters CreateRemainsSearchCriteria()
        {
            var searchCriteria = new MVRemainsSearchParameters() { SessionID = this.UserID };

            if (!string.IsNullOrEmpty(stbBusinessUnitFrom.Value))
                searchCriteria.WarehouseFrom = stbBusinessUnitFrom.Value;
            else
                throw new Exception("Не указана \"Биз. ед. с\".");

            if (!string.IsNullOrEmpty(stbBusinessUnitTo.Value))
                searchCriteria.WarehouseTo = stbBusinessUnitTo.Value;
            else
                throw new Exception("Не указана \"Биз. ед. по\".");

            if (!string.IsNullOrEmpty(stbItem.Value))
                searchCriteria.ItemID = Convert.ToInt32(stbItem.Value);
            else
                throw new Exception("Не указан \"Товар\".");

            if (!string.IsNullOrEmpty(stbVendorLot.Value))
                searchCriteria.VendorLot = stbVendorLot.Value;

            if (!string.IsNullOrEmpty(stbLocation.Value))
                searchCriteria.LocationID = stbLocation.Value;

            if (!string.IsNullOrEmpty(stbBatchNumber.Value))
                searchCriteria.BatchNumber = stbBatchNumber.Value;

            searchCriteria.VendorLotUseAllRemains = cbVendorLotUseAllRemains.Checked;
            searchCriteria.LocationUseAllRemains = cbLocationUseAllRemains.Checked;
            searchCriteria.BatchUseAllRemains = cbBatchUseAllRemains.Checked;

            return searchCriteria;
        }



        private void LoadMovements()
        {
            try
            {
                var searchCriteria = this.CreateMovementsSearchCriteria();
                LoadMovements(searchCriteria);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void LoadMovements(MVMovementsSearchParameters searchCriteria)
        {
            try
            {
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvMovements.DataView.FillData(e.Argument as MVMovementsSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvMovements.BindData(false);

                        //this.xdgvMovements.AllowFilter = true;
                        this.xdgvMovements.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка движений..";
                bw.RunWorkerAsync(searchCriteria);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private MVMovementsSearchParameters CreateMovementsSearchCriteria()
        {
            var searchCriteria = new MVMovementsSearchParameters(this.CreateRemainsSearchCriteria()) { SessionID = this.UserID };

            if (dtpDateFrom.Value.Date > dtpDateTo.Value.Date)
                throw new Exception("Начальный период не должен превышать конечный.");

            searchCriteria.PeriodFrom = dtpDateFrom.Value.Date;
            searchCriteria.PeriodTo = dtpDateTo.Value.Date;

            searchCriteria.TargetWarehouse = (string)null;
            searchCriteria.TargetLocation = (string)null;
            searchCriteria.TargetBatch = (string)null;

            return searchCriteria;
        }



        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportData();
        }

        private void ExportData()
        {
            try
            {
                if (tcMain.SelectedTab == tpRemains)
                    xdgvRemains.ExportToExcel("Экспорт остатков в Excel", "остатки", true);
                else if (tcMain.SelectedTab == tpMovements)
                    xdgvMovements.ExportToExcel("Экспорт движений в Excel", "движения", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void tbQFilterItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbQFilterItem_Leave(sender, EventArgs.Empty);
        }

        private void tbQFilterItem_Leave(object sender, EventArgs e)
        {
            stbItem.ApplyAdditionalParameter("ITM_NAME", tbQFilterItem.Text);
            if (!string.IsNullOrEmpty(tbQFilterItem.Text.Trim()) && tbQFilterItem.Text.Trim().Length >= 3)
                stbItem.VerifyValue(true, AutoSelectItemSideMode.None);
        }

        private void cbVendorLotUseAllRemains_CheckedChanged(object sender, EventArgs e)
        {
            //cbLocationUseAllRemains.Checked = cbVendorLotUseAllRemains.Checked;
            //cbBatchUseAllRemains.Checked = cbVendorLotUseAllRemains.Checked;

            stbVendorLot.ApplyAdditionalParameter("flagAllRemains", cbVendorLotUseAllRemains.Checked);
            var previousValue = stbVendorLot.TextEditor.Text;
            stbVendorLot.SetValueByDefault(string.Empty);
            stbVendorLot.SetValueByDefault(previousValue);
            stbVendorLot.Focus();
        }

        private void cbLocationUseAllRemains_CheckedChanged(object sender, EventArgs e)
        {
            //cbBatchUseAllRemains.Checked = cbLocationUseAllRemains.Checked;
            //cbVendorLotUseAllRemains.Checked = cbLocationUseAllRemains.Checked;

            stbLocation.ApplyAdditionalParameter("flagAllRemains", cbLocationUseAllRemains.Checked);
            var previousValue = stbLocation.TextEditor.Text;
            stbLocation.SetValueByDefault(string.Empty);
            stbLocation.SetValueByDefault(previousValue);
            stbLocation.Focus();
        }

        private void cbBatchUseAllRemains_CheckedChanged(object sender, EventArgs e)
        {
            //cbVendorLotUseAllRemains.Checked = cbBatchUseAllRemains.Checked;
            //cbLocationUseAllRemains.Checked = cbBatchUseAllRemains.Checked;

            stbBatchNumber.ApplyAdditionalParameter("flagAllRemains", cbBatchUseAllRemains.Checked);
            var previousValue = stbBatchNumber.TextEditor.Text;
            stbBatchNumber.SetValueByDefault(string.Empty);
            stbBatchNumber.SetValueByDefault(previousValue);
            stbBatchNumber.Focus();
        }

        private void RemainsWithMovementsDispatcherWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            xdgvRemains.SaveExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvRemains.Name));
            xdgvMovements.SaveExtraDataGridViewSettings(string.Format("{0}_{1}", this.Name, xdgvMovements.Name));
        }

        private void tcMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            var foreColor = SystemColors.ControlText;
            var foreColorBrush = new SolidBrush(foreColor);

            var backColor = tcMain.TabPages[e.Index] == tpRemains ? Color.LightGreen : Color.LightSkyBlue;
            var backColorBrush = new SolidBrush(backColor);

            e.Graphics.FillRectangle(backColorBrush, e.Bounds);

            var font = new Font(e.Font.FontFamily, 10.0f, FontStyle.Bold);
            var textHeader = tcMain.TabPages[e.Index].Text;
            SizeF sizeHeader = e.Graphics.MeasureString(textHeader, font);
            e.Graphics.DrawString(textHeader, font, foreColorBrush, e.Bounds.Left + (e.Bounds.Width - sizeHeader.Width) / 2, e.Bounds.Top + (e.Bounds.Height - sizeHeader.Height) / 2 + 1);

            Rectangle bounds = e.Bounds;
            bounds.Offset(0, 1);
            bounds.Inflate(0, -1);
            e.Graphics.DrawRectangle(new Pen(backColor), bounds);
            e.DrawFocusRectangle();
        }
    }

    /// <summary>
    /// Представление для остатков
    /// </summary>
    public class MVRemainsView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as MVRemainsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseFrom = searchCriteria.WarehouseFrom;
            var warehouseTo = searchCriteria.WarehouseTo;
            var itemID = searchCriteria.ItemID;
            var vendorLot = searchCriteria.VendorLot;
            var locationID = searchCriteria.LocationID;
            var batchNumber = searchCriteria.BatchNumber;

            var vendorLotUseAllRemains = searchCriteria.VendorLotUseAllRemains;
            var locationUseAllRemains = searchCriteria.LocationUseAllRemains;
            var batchUseAllRemains = searchCriteria.BatchUseAllRemains;

            using (var adapter = new Data.WHTableAdapters.MV_RemainsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, warehouseFrom, warehouseTo, itemID, vendorLot, locationID, batchNumber, vendorLotUseAllRemains, locationUseAllRemains, batchUseAllRemains);
            }
        }

        #endregion

        public MVRemainsView()
        {
            this.dataColumns.Add(new PatternColumn("Код товара", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count) { Width = 50, IsFrozen = true });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 200, IsFrozen = true });

            this.dataColumns.Add(new PatternColumn("Код склада", "WarehouseCode", new FilterPatternExpressionRule("WarehouseCode"), SummaryCalculationType.Count) { Width = 50, IsFrozen = true });

            this.dataColumns.Add(new PatternColumn("Код поставщ.", "VendorID", new FilterCompareExpressionRule<Int32>("VendorID"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Наименование поставщика", "VendorName", new FilterPatternExpressionRule("VendorName")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Место", "LocationCode", new FilterPatternExpressionRule("LocationCode"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Сектор", "LocationDesc", new FilterPatternExpressionRule("LocationDesc"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Партия", "BatchNumber", new FilterPatternExpressionRule("BatchNumber"), SummaryCalculationType.Count) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("Кол-во\nна складе", "StockQuantity", new FilterCompareExpressionRule<Int32>("StockQuantity"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во\nдоступно", "AvailableQuantity", new FilterCompareExpressionRule<Int32>("AvailableQuantity"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во\nв резерве", "ReserveQuantity", new FilterCompareExpressionRule<Int32>("ReserveQuantity"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во\nпо заданиям", "TaskReserveQuantity", new FilterCompareExpressionRule<Int32>("TaskReserveQuantity"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во\nв пути", "TransitQuantity", new FilterCompareExpressionRule<Int32>("TransitQuantity"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("ЕИ", "Uom", new FilterPatternExpressionRule("Uom")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Серия", "VendorLot", new FilterPatternExpressionRule("VendorLot"), SummaryCalculationType.Count) { Width = 90 });

            this.dataColumns.Add(new PatternColumn("Тип блокировки", "BlockName", new FilterPatternExpressionRule("BlockName"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Описание блокировки", "BlockDesc", new FilterPatternExpressionRule("BlockDesc")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Срок годности", "ExpDate", new FilterDateCompareExpressionRule("ExpDate")) { Width = 90 });
        }
    }

    /// <summary>
    /// Критерий поиска для остатков
    /// </summary>
    public class MVRemainsSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseFrom { get; set; }
        public string WarehouseTo { get; set; }
        public int? ItemID { get; set; }
        public string VendorLot { get; set; }
        public string LocationID { get; set; }
        public string BatchNumber { get; set; }

        public bool VendorLotUseAllRemains { get; set; }
        public bool LocationUseAllRemains { get; set; }
        public bool BatchUseAllRemains { get; set; }
    }


    /// <summary>
    /// Представление для перемещений
    /// </summary>
    public class MVMovementsView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as MVMovementsSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseFrom = searchCriteria.WarehouseFrom;
            var warehouseTo = searchCriteria.WarehouseTo;
            var itemID = searchCriteria.ItemID;
            var vendorLot = searchCriteria.VendorLot;
            var locationID = searchCriteria.LocationID;
            var batchNumber = searchCriteria.BatchNumber;

            var vendorLotUseAllRemains = searchCriteria.VendorLotUseAllRemains;
            var locationUseAllRemains = searchCriteria.LocationUseAllRemains;
            var batchUseAllRemains = searchCriteria.BatchUseAllRemains;

            var periodFrom = searchCriteria.PeriodFrom;
            var periodTo = searchCriteria.PeriodTo;
            var targetWarehouse = searchCriteria.TargetWarehouse;
            var targetLocation = searchCriteria.TargetLocation;
            var targetBatch = searchCriteria.TargetBatch;

            using (var adapter = new Data.WHTableAdapters.MV_MovementsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, warehouseFrom, warehouseTo, itemID, vendorLot, locationID, batchNumber, vendorLotUseAllRemains, locationUseAllRemains, batchUseAllRemains, periodFrom, periodTo, targetWarehouse, targetLocation, targetBatch);
            }
        }

        #endregion

        public MVMovementsView()
        {
            this.dataColumns.Add(new PatternColumn("Код товара", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count) { Width = 50, IsFrozen = true });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 200, IsFrozen = true });

            this.dataColumns.Add(new PatternColumn("Код склада", "WarehouseCode", new FilterPatternExpressionRule("WarehouseCode"), SummaryCalculationType.Count) { Width = 50, IsFrozen = true });

            this.dataColumns.Add(new PatternColumn("Место", "LocationCode", new FilterPatternExpressionRule("LocationCode"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Сектор", "LocationDesc", new FilterPatternExpressionRule("LocationDesc"), SummaryCalculationType.Count) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Партия", "BatchNumber", new FilterPatternExpressionRule("BatchNumber"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Серия", "VendorLot", new FilterPatternExpressionRule("VendorLot"), SummaryCalculationType.Count) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Номер заказа", "OrderNumber", new FilterCompareExpressionRule<Int32>("OrderNumber"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Тип заказа", "OrderType", new FilterPatternExpressionRule("OrderType"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Дата заказа", "OrderDate", new FilterDateCompareExpressionRule("OrderDate"), SummaryCalculationType.Count) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("Номер проводки", "DocNumber", new FilterCompareExpressionRule<Int32>("DocNumber"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Тип проводки", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.Count) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Описание проводки", "DocTypeDescription", new FilterPatternExpressionRule("DocTypeDescription")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Дата проводки", "DocDate", new FilterDateCompareExpressionRule("DocDate"), SummaryCalculationType.Count) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("ШТ", "UomIT", new FilterPatternExpressionRule("UomIT")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Кол-во,\nшт.", "QtyIT", new FilterCompareExpressionRule<Int32>("QtyIT"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("ЕИ\nосн.", "UomBase", new FilterPatternExpressionRule("UomBase")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Кол-во,\nв осн.", "QtyBase", new FilterCompareExpressionRule<Int32>("QtyBase"), SummaryCalculationType.Custom) { Width = 100, UseIntegerNumbersAlignment = true });
            
            this.dataColumns.Add(new PatternColumn("Назначение проводки", "DocKind", new FilterPatternExpressionRule("DocKind"), SummaryCalculationType.Count) { Width = 150 });
            //this.dataColumns.Add(new PatternColumn("Комментарий к проводке", "DocDesc", new FilterPatternExpressionRule("DocDesc")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Код получателя", "AddressNumber", new FilterCompareExpressionRule<Int32>("AddressNumber"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Название получателя", "AddressName", new FilterPatternExpressionRule("AddressName")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("Автор проводки", "DocAuthor", new FilterPatternExpressionRule("DocAuthor")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Сборочный", "PickNumber", new FilterCompareExpressionRule<Int32>("PickNumber")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Ближайший статус", "NextState", new FilterPatternExpressionRule("NextState")) { Width = 70 });
        }
    }

    /// <summary>
    /// Критерий поиска для перемещений
    /// </summary>
    public class MVMovementsSearchParameters : MVRemainsSearchParameters
    {
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }

        public string TargetWarehouse { get; set; }
        public string TargetLocation { get; set; }
        public string TargetBatch { get; set; }

        public MVMovementsSearchParameters(MVRemainsSearchParameters searchCriteria)
        {
            this.WarehouseFrom = searchCriteria.WarehouseFrom;
            this.WarehouseTo = searchCriteria.WarehouseTo;
            this.ItemID = searchCriteria.ItemID;
            this.VendorLot = searchCriteria.VendorLot;
            this.LocationID = searchCriteria.LocationID;
            this.BatchNumber = searchCriteria.BatchNumber;

            this.VendorLotUseAllRemains = searchCriteria.VendorLotUseAllRemains;
            this.LocationUseAllRemains = searchCriteria.LocationUseAllRemains;
            this.BatchUseAllRemains = searchCriteria.BatchUseAllRemains;
        }
    }
}
