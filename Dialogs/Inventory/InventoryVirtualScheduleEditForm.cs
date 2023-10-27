using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryVirtualScheduleEditForm : DialogForm
    {
        public long? PlanID { get; private set; }

        private readonly Data.Inventory.InventoriesScheduleRow _InventorySchedule = null;

        public bool CreateMode { get { return _InventorySchedule == null; } }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public InventoryVirtualScheduleEditForm()
        {
            InitializeComponent();
        }

        public InventoryVirtualScheduleEditForm(Data.Inventory.InventoriesScheduleRow inventorySchedule)
            : this()
        {
            _InventorySchedule = inventorySchedule;
        }

        private void InventoryVirtualScheduleEditForm_Load(object sender, EventArgs e)
        {
            LoadTypes();
        }

        private void LoadTypes()
        {
            try
            {
                inventoriesVirtualScheduleTypesTableAdapter.Fill(inventory.InventoriesVirtualScheduleTypes, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(467, 8);
            this.btnCancel.Location = new Point(557, 8);

            Initialize();

            LoadCategories();
            LoadWarehousesElements();

            var lstSelectedWarehouses = GetSelectedWarehouses(true);

            //this.WindowState = FormWindowState.Maximized;
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

                //cmbWarehouse.SelectedValue = _InventorySchedule.Isfilial_codeNull() ? (string)null : _InventorySchedule.filial_code;
                //cmbInventoryType.SelectedValue = _InventorySchedule.fi_type;

                dtpInventoryPlanDate.Value = _InventorySchedule.Isplan_date_dNull() ? DateTime.Today : _InventorySchedule.plan_date_d.Date;
                dtpInventoryPlanTime.Value = _InventorySchedule.Isplan_date_dNull() ? DateTime.Now : _InventorySchedule.plan_date_d;

                //tbDescription.Text = _InventorySchedule.Ispln_dscNull() ? (string)null : _InventorySchedule.pln_dsc;
            }

            CustomCheckHeader(dgvWarehouses.Columns[0], warehouseHeaderCell_OnCheckBoxClicked);
        }

        public List<WMSOffice.Data.Inventory.InventoriesVirtualScheduleWarehousesElementsRow> GetSelectedWarehouses(bool loadingMode)
        {
            var lstWarehouses = new List<WMSOffice.Data.Inventory.InventoriesVirtualScheduleWarehousesElementsRow>();

            foreach (Data.Inventory.InventoriesVirtualScheduleWarehousesElementsRow warehouse in inventory.InventoriesVirtualScheduleWarehousesElements.Rows)
                if (warehouse.checked_flag)// && (loadingMode ? !warehouse.nested_elements_loaded : true))
                    lstWarehouses.Add(warehouse);

            return lstWarehouses;
        }

        private static void CustomCheckHeader(DataGridViewColumn pColumn, CheckBoxClickedHandler pHandler)
        {
            var checkHeaderCell = new DataGridViewHeaderCheckBoxCell();
            checkHeaderCell.OnCheckBoxClicked += pHandler;
            checkHeaderCell.Value = String.Empty;
            pColumn.HeaderCell = checkHeaderCell;
        }


        private void LoadCategories()
        {
            inventoriesVirtualScheduleCategoriesTableAdapter.Fill(inventory.InventoriesVirtualScheduleCategories, this.UserID, this.PlanID);
        }


        public void warehouseHeaderCell_OnCheckBoxClicked(bool pState)
        {
            foreach (DataGridViewRow row in dgvWarehouses.Rows)
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
                    inventoriesVirtualScheduleWarehousesElementsBindingSource.DataSource = inventory.InventoriesVirtualScheduleWarehousesElements;
                    //inventoriesVirtualScheduleWarehousesElementsBindingSource.Sort = "warehouse_id";

                    SetWarehousesElementsFilter();
                }
            };
            inventoriesVirtualScheduleWarehousesElementsBindingSource.DataSource = null;
            splashForm.ActionText = "Подготовка складов..";
            bw.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        private void LoadWarehousesElements()
        {
            inventoriesVirtualScheduleWarehousesElementsTableAdapter.ClearBeforeFill = false;
            inventoriesVirtualScheduleWarehousesElementsTableAdapter.Fill(inventory.InventoriesVirtualScheduleWarehousesElements, this.UserID, this.PlanID);
        }

        private void SetWarehousesElementsFilter()
        {
            var sFilter = (string)null;
            inventoriesVirtualScheduleWarehousesElementsBindingSource.Filter = sFilter;
        }

        private void dgvWarehouses_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(dgvWarehouses.Rows[e.RowIndex].Cells[0].Value);
            dgvWarehouses.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            dgvWarehouses.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvWarehouses_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void InventoryVirtualScheduleEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !this.CommitData();
            }
            else
            {
                if (this.CreateMode)
                    e.Cancel = !this.RollbackData();
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

                var planDate = dtpInventoryPlanDate.Value.Date;
                var planTime = dtpInventoryPlanTime.Value.ToShortTimeString();

                var planDescription = tbDescription.Text;

                var sbWarehouses = new StringBuilder();
                foreach (Data.Inventory.InventoriesVirtualScheduleWarehousesElementsRow warehouse in inventory.InventoriesVirtualScheduleWarehousesElements)
                {
                    if (warehouse.checked_flag)
                    {
                        if (sbWarehouses.Length > 0)
                            sbWarehouses.AppendFormat(",{0}", warehouse.warehouse_id);
                        else
                            sbWarehouses.AppendFormat("{0}", warehouse.warehouse_id);
                    }
                }

                if (sbWarehouses.Length == 0)
                    throw new Exception("Не вказано склад(и).");

                var qtyItems = cbQtyItems.Checked ? Convert.ToInt32(nudQtyItems.Value) : (int?)null;
                var priceFrom = cbPricesRange.Checked ? Convert.ToDouble(nudPriceFrom.Value) : (double?)null;
                var priceTo = cbPricesRange.Checked ? Convert.ToDouble(nudPriceTo.Value) : (double?)null;

                if (priceFrom > priceTo)
                    throw new Exception("Початкова ціна не повинна перевищувати кінцеву.");

                var category = cmbCategory.SelectedValue.ToString();

                var outMove = cbOutMove.Checked ? Convert.ToInt32(nudOutMove.Value) : (int?)null;
                var outInv = cbOutInv.Checked ? Convert.ToInt32(nudOutInv.Value) : (int?)null;

                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    adapter.ModifyVirtual(this.UserID, this.PlanID, inventoryType, planDate, planTime, planDescription, sbWarehouses.ToString(), qtyItems, priceFrom, priceTo, category, outMove, outInv);
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                throw ex;
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbQtyItems_CheckedChanged(object sender, EventArgs e)
        {
            cbQtyItems.Checked = true;
        }

        private void cbPricesRange_CheckedChanged(object sender, EventArgs e)
        {
            cbPricesRange.Checked = true;
        }

        private void cbCategory_CheckedChanged(object sender, EventArgs e)
        {
            cbCategory.Checked = true;
        }

        private void cbOutMove_CheckedChanged(object sender, EventArgs e)
        {
            nudOutMove.Enabled = cbOutMove.Checked;
            nudOutMove.Value = 0;
        }

        private void cbOutInv_CheckedChanged(object sender, EventArgs e)
        {
            nudOutInv.Enabled = cbOutInv.Checked;
            nudOutInv.Value = 0;
        }
     

    }
}
