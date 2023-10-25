using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class ComplaintsBrokenCommodityPlacementWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        private bool allowCloseWindow = false;

        public string WarehouseID { get; private set; }

        public string SSCC { get; private set; }

        public string LocationToID { get; private set; }

        public ComplaintsBrokenCommodityPlacementWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            tsMain.Visible = false;
            pnlContent.Visible = false;

            if (!SelectWarehouse())
            {
                // закрываем окно
                allowCloseWindow = true;
                Close();
            
                return;
            }

            if (!CreateDoc())
            {
                // закрываем окно
                allowCloseWindow = true;
                Close();
                
                return;
            }

            this.InitDocument();

            tsMain.Visible = true;
            pnlContent.Visible = true;

            this.Refresh();

            dgvRemains.Columns[IsChecked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvRemains.Columns[IsChecked.Index].HeaderCell).CheckBoxClicked += dgvRemains_CheckBoxHeaderCell_OnCheckBoxClicked;

            this.ReloadData();
        }

        private void InitDocument()
        {
            if (!string.IsNullOrEmpty(this.SSCC))
                this.DocTitle.Text = string.Format("Перепаковка Боя ({0}-{1}) [WH: {2}] [SSCC: {3}]", this.DocType, this.DocID, this.WarehouseID.Trim(), this.SSCC.Trim());
                //this.InitDocument(string.Format("{0} [WH: {1}] [SSCC: {2}]", this.DocName, this.WarehouseID.Trim(), this.SSCC.Trim()), this.DocID, this.DocType, this.DocDate, this.StatusID, this.StatusName);
            else
                this.DocTitle.Text = string.Format("Перепаковка Боя ({0}-{1}) [WH: {2}]", this.DocType, this.DocID, this.WarehouseID.Trim());
                //this.InitDocument(string.Format("{0} [WH: {1}]", this.DocName, this.WarehouseID.Trim()), this.DocID, this.DocType, this.DocDate, this.StatusID, this.StatusName);

            var canCloseDoc = !string.IsNullOrEmpty(this.SSCC);
            sbAssignSSCC.Enabled = !canCloseDoc;
            sbCloseDoc.Enabled = canCloseDoc;
        }

        private bool SelectWarehouse()
        {
            try
            {
                var warehouses = new Data.Complaints.CO_BM_Get_Warehouse_ListDataTable();
                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_Warehouse_ListTableAdapter())
                    adapter.Fill(warehouses, this.UserID);

                if (warehouses.Rows.Count == 0)
                    throw new Exception("У Вас нет доступа к интерфейсу перепаковки Боя.");

                if (warehouses.Rows.Count == 1)
                {
                    this.WarehouseID = warehouses[0].WarehouseID;
                    return true;
                }
                else
                {
                    var dlgSelectWarehouse = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWarehouse.Text = "Выберите склад";
                    dlgSelectWarehouse.AddColumn("WarehouseID", "WarehouseID", "Код");
                    dlgSelectWarehouse.AddColumn("Warehouse", "Warehouse", "Название");
                    dlgSelectWarehouse.FilterChangeLevel = 0;
                    dlgSelectWarehouse.FilterVisible = false;

                    dlgSelectWarehouse.DataSource = warehouses;

                    if (dlgSelectWarehouse.ShowDialog() != DialogResult.OK)
                        return false;

                    var warehouse = dlgSelectWarehouse.SelectedRow as Data.Complaints.CO_BM_Get_Warehouse_ListRow;
                    this.WarehouseID = warehouse.WarehouseID;
                    return true;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private bool CreateDoc()
        {
            try
            {
                var docID = (int?)null;
                var errorMessage = (string)null;
                var sscc = (string)null;

                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter())
                    adapter.CreateDoc(this.UserID, this.WarehouseID, ref docID, ref errorMessage, ref sscc);

                if (!docID.HasValue)
                    throw new Exception("Не удалось создать документ перепаковки Боя");

                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                this.DocID = docID.Value;
                this.SSCC = sscc;

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void sbReloadData_Click(object sender, EventArgs e)
        {
            Data.Complaints.CO_BM_Get_RemainsRow remainsRow = null;

            if (dgvRemains.SelectedRows.Count > 0)
                remainsRow = (dgvRemains.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.CO_BM_Get_RemainsRow;

            this.ReloadData(remainsRow);
        }

        private void ReloadData()
        {
            this.ReloadData(null);
        }

        private void ReloadData(Data.Complaints.CO_BM_Get_RemainsRow rowToNavigate)
        {
            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        e.Result = cO_BM_Get_RemainsTableAdapter.GetData((int)this.DocID, this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        cOBMGetRemainsBindingSource.DataSource = e.Result;
                        this.NavigateRow(rowToNavigate);
                    }

                    waitProgressForm.CloseForce();
                };

                cOBMGetRemainsBindingSource.DataSource = null;
                waitProgressForm.ActionText = "Выполняется загрузка остатка..";
                loadWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void NavigateRow(Data.Complaints.CO_BM_Get_RemainsRow rowToNavigate)
        {
            var docDetailsCount = 0;
            var remainsCount = dgvRemains.Rows.Count;

            var needNavigate = true;
            foreach (DataGridViewRow gridRow in dgvRemains.Rows)
            {
                var row = (gridRow.DataBoundItem as DataRowView).Row as Data.Complaints.CO_BM_Get_RemainsRow;

                if (rowToNavigate != null && needNavigate)
                {
                    if (row.ItemID.Equals(rowToNavigate.ItemID)
                        && row.BatchID.Equals(rowToNavigate.BatchID, StringComparison.OrdinalIgnoreCase)
                        && row.LocationID.Equals(rowToNavigate.LocationID, StringComparison.OrdinalIgnoreCase))
                    {
                        gridRow.Selected = true;
                        dgvRemains.FirstDisplayedScrollingRowIndex = gridRow.Index;
                        needNavigate = false;
                    }
                }

                if (row.IsChecked)
                    docDetailsCount++;
            }

            this.RefreshDocDetailsSummary(docDetailsCount, remainsCount);
        }

        private void RefreshDocDetailsSummary(int docDetailsCount, int remainsCount)
        {
            slDocDetailsSummary.Text = string.Format("Отм. {0} из {1}", docDetailsCount, remainsCount);
        }

        private bool AddDocDetail(Data.Complaints.CO_BM_Get_RemainsRow remainsRow, double docQty, bool needReloadData)
        {
            try
            {
                var itemID = (int)remainsRow.ItemID;
                var batchID = remainsRow.BatchID;
                var locationID = remainsRow.LocationID;

                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter())
                    adapter.AddDocDetail((int)this.DocID, this.UserID, itemID, batchID, locationID, docQty);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
            finally
            {
                if (needReloadData)
                    this.ReloadData(remainsRow);
            }
        }

        #region Привязать SSCC
        private void sbAssignSSCC_Click(object sender, EventArgs e)
        {
            this.AssignSSCC();
        }

        private void AssignSSCC()
        {
            try
            {
                var dlgScanSSCC = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте SSCC\r\nдля выполнения задания перепаковки Боя",
                    Text = "Перепаковка Боя",
                    Image = Properties.Resources.barcode
                };

                if (dlgScanSSCC.ShowDialog() == DialogResult.OK)
                {
                    var sscc = dlgScanSSCC.Barcode;

                    using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter())
                        adapter.AssignSSCC((int)this.DocID, this.UserID, sscc);

                    this.SSCC = sscc;

                    this.InitDocument();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        #endregion

        #region Закрыть документ
        private void sbCloseDoc_Click(object sender, EventArgs e)
        {
            this.CloseDoc();
        }

        private void CloseDoc()
        {
            try
            {
                if (string.IsNullOrEmpty(this.SSCC))
                    throw new Exception("Не привязана SSCC.");

                if (!this.SelectLocationTo())
                    return;

                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter())
                    adapter.CloseDoc((int)this.DocID, this.UserID, this.LocationToID);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool SelectLocationTo()
        {
            try
            {
                var locations = new Data.Complaints.CO_BM_Get_LocationsDataTable();
                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_LocationsTableAdapter())
                    adapter.Fill(locations, (int?)this.DocID, this.UserID);

                if (locations.Rows.Count == 0)
                    throw new Exception("У Вас нет доступа к выбору транзитной полки.");

                var dlgSelectLocationTo = new WMSOffice.Dialogs.RichListForm();
                dlgSelectLocationTo.Text = "Выберите транзитную полку";
                dlgSelectLocationTo.AddColumn("LMLOCN", "LMLOCN", "Полка");
                dlgSelectLocationTo.FilterChangeLevel = 0;
                dlgSelectLocationTo.FilterVisible = false;

                dlgSelectLocationTo.DataSource = locations;

                if (dlgSelectLocationTo.ShowDialog() != DialogResult.OK)
                    return false;

                var locationTo = dlgSelectLocationTo.SelectedRow as Data.Complaints.CO_BM_Get_LocationsRow;
                this.LocationToID = locationTo.LMLOCN;
                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }
        #endregion

        #region Отменить документ
        private void sbCancelDoc_Click(object sender, EventArgs e)
        {
            this.CancelDoc();
        }

        private void CancelDoc()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_BM_Get_RemainsTableAdapter())
                    adapter.CancelDoc((int)this.DocID, this.UserID);

                // закрываем окно
                allowCloseWindow = true;
                Close();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        #endregion

        private void ComplaintsBrokenCommodityPlacementWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры перепаковки. Пожалуйста, продолжайте работу.\n\rДля закрытия документа воспользуйтесь командой \"Закрыть документ\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        #region Обработчики DataGridView
        private void dgvRemains_CheckBoxHeaderCell_OnCheckBoxClicked(object sender, WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRemains.Rows)
                {
                    row.Cells[IsChecked.Index].Value = e.IsChecked;

                    var remainsRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.CO_BM_Get_RemainsRow;

                    var needAddDocDetail = (e.IsChecked && remainsRow.DocQty.Equals(0.0)) || (!e.IsChecked && remainsRow.DocQty > 0);
                    if (needAddDocDetail)
                    {
                        var docQty = e.IsChecked ? remainsRow.Qty : 0.0;

                        if (!this.AddDocDetail(remainsRow, docQty, false))
                            break;
                    }
                }

                this.ReloadData();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void dgvRemains_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var remainsRow = (dgvRemains.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.CO_BM_Get_RemainsRow;

            if (dgvRemains.Columns[e.ColumnIndex].DataPropertyName == this.complaints.CO_BM_Get_Remains.DocQtyColumn.Caption)
                this.AddDocDetail(remainsRow, remainsRow.DocQty, true);
        }

        private void dgvRemains_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvRemains.Rows[e.RowIndex].Cells[IsChecked.Index].Value);
            this.dgvRemains.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvRemains.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvRemains_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvRemains.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (dgvRemains.IsCurrentCellDirty)
                {
                    var remainsRow = (dgvRemains.CurrentRow.DataBoundItem as DataRowView).Row as Data.Complaints.CO_BM_Get_RemainsRow;

                    var docQty = !remainsRow.IsChecked ? remainsRow.Qty : 0.0;
                    this.AddDocDetail(remainsRow, docQty, true);

                    //dgvDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    //// Раскраска
                    //bool isChecked = Convert.ToBoolean(this.dgvRemains.Rows[this.dgvRemains.CurrentRow.Index].Cells[this.IsChecked.Index].Value);
                    //foreach (DataGridViewColumn column in this.dgvRemains.Columns)
                    //{
                    //    this.dgvRemains.Rows[this.dgvRemains.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    //    this.dgvRemains.Rows[this.dgvRemains.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                    //}
                }
            }
        }

        private void dgvRemains_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvRemains.Columns[e.ColumnIndex].DataPropertyName == this.complaints.CO_BM_Get_Remains.DocQtyColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
