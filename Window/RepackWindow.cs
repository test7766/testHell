using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class RepackWindow : GeneralWindow
    {
        /// <summary>
        /// Режим выполнения
        /// </summary>
        private const string EXECUTION_MODE = "INIT";

        /// <summary>
        /// Код станции
        /// </summary>
        public string StationID { get; private set; }

        /// <summary>
        /// Стол перепаковки
        /// </summary>
        public string LOCN { get; private set; }

        /// <summary>
        /// Код склада
        /// </summary>
        public string WarehouseID { get; private set; }

        /// <summary>
        /// Наименование склада
        /// </summary>
        public string WarehouseName { get; private set; }

        /// <summary>
        /// Ш/К тележки
        /// </summary>
        public string TrolleyBarCode { get; private set; }

        /// <summary>
        /// Сканер Ш/К
        /// </summary>
        private WMSOffice.Controls.TextBoxScaner tbScan = null;

        public RepackWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!InitializeLOCN())
            {
                Close();
                return;
            }

            if (!InitializeWarehouse())
            {
                Close();
                return;
            }

            tbScan = new WMSOffice.Controls.TextBoxScaner();
            tbScan.TextChanged += new EventHandler(tbScan_TextChanged);
            tsMain.Items.Add(new ToolStripControlHost(tbScan));

            tsMain.Items.Add(new ToolStripSeparator());

            var sbCloseTrolley = new ToolStripButton("Закрыть тележку", Properties.Resources.baggage) { DisplayStyle = ToolStripItemDisplayStyle.ImageAndText };
            sbCloseTrolley.Click += delegate(object sender, EventArgs ea) { CloseTrolley(); };
            tsMain.Items.Add(sbCloseTrolley);

            tsMain.Items.Add(new ToolStripSeparator());

            var sbAssignTrolley = new ToolStripButton("Зафиксировать тележку", Properties.Resources.link) { DisplayStyle = ToolStripItemDisplayStyle.ImageAndText };
            sbAssignTrolley.Click += delegate(object sender, EventArgs ea) { AssignTrolley(); };
            tsMain.Items.Add(sbAssignTrolley);

            pnlMainLayout.Visible = true;
            tbScan.Focus();

            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, string.Format("Отбор ЖЭ для перепаковки на складе {0}", WarehouseName));

            // -> Отключено по просьбе Кадубенко 15.09
            // ->
            //// возобновление задания перепаковки, если такое имеется
            //if (!this.CheckRestoreRepackTask())
            //    this.RefreshData();

            this.RefreshData();
        }

        private bool InitializeLOCN()
        {
            var dlgRegister = new BeginRepackRegistrationForm() { UserID = this.UserID };
            if (dlgRegister.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            StationID = dlgRegister.StationID;
            LOCN = dlgRegister.LOCN;
            return true;
        }

        private bool InitializeWarehouse()
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.RepackWarehousesTableAdapter())
                    adapter.Fill(wH.RepackWarehouses, UserID);

                var dlgSelectWarehouse = new WMSOffice.Dialogs.RichListForm();
                dlgSelectWarehouse.Text = "Выберите склад";
                dlgSelectWarehouse.AddColumn("Warehouse", "Warehouse", "Склад");
                dlgSelectWarehouse.ColumnForFilters = new List<string>(new string[] { "Warehouse" });
                dlgSelectWarehouse.FilterChangeLevel = 0;
                dlgSelectWarehouse.DataSource = wH.RepackWarehouses;

                Data.WH.RepackWarehousesRow selectedRow = null;
                if (wH.RepackWarehouses.Rows.Count > 1)
                {
                    if (dlgSelectWarehouse.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }

                    selectedRow = dlgSelectWarehouse.SelectedRow as Data.WH.RepackWarehousesRow;
                }
                else if (wH.RepackWarehouses.Rows.Count == 0)
                {
                    MessageBox.Show("Для Вашего пользователя отсутствуют права доступа.\r\nОбратитесь в ГСПО.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    selectedRow = wH.RepackWarehouses[0];
                }

                WarehouseID = selectedRow.Warehouse_ID;
                WarehouseName = selectedRow.Warehouse.Trim();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Возобновление задания перепаковки
        /// </summary>
        [Obsolete]
        private bool CheckRestoreRepackTask()
        {
            try
            {
                string barcodeYL = null;
                string trolley = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.RepackRestoreTask(this.UserID, this.WarehouseID, this.LOCN, ref barcodeYL, ref trolley);

                if (!string.IsNullOrEmpty(trolley))
                    this.TrolleyBarCode = trolley;

                if (!string.IsNullOrEmpty(barcodeYL))
                {
                    MessageBox.Show("Осталось незавершенное задание перепаковки.\r\nОно будет переоткрыто автоматически.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.RefreshData();
                    tbScan.Text = barcodeYL;
                    this.SwitchToRepackTask(barcodeYL);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        void tbScan_TextChanged(object sender, EventArgs e)
        {
            SwitchToRepackTask(tbScan.Text);
        }

        /// <summary>
        /// Переключится на задание перепаковки
        /// </summary>
        private bool SwitchToRepackTask(string barcodeYL)
        {
            try
            {
                int? errorCode = null;
                string errorMessage = null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.CheckRepackItemBarcode(UserID, WarehouseID, LOCN, barcodeYL, EXECUTION_MODE, ref errorCode, ref errorMessage);

                if ((errorCode.HasValue && errorCode.Value > 0) || !string.IsNullOrEmpty(errorMessage))
                    throw new Exception(errorMessage);

                Data.WH.RepackMainDisplayCurrentTasksRow repackItem = null;
                if ((repackItem = this.FindRepackItemInTask(barcodeYL)) != null)
                {
                    var dlgRepackItem = new RepackItemForm(repackItem) { UserID = this.UserID, WarehouseID = this.WarehouseID, LOCN = this.LOCN, StationID = this.StationID, TrolleyBarCode = this.TrolleyBarCode };
                    DialogResult dlgRepackItemResult = DialogResult.None;
                    if ((dlgRepackItemResult = dlgRepackItem.ShowDialog()) != DialogResult.None)
                    {
                        #region АНАЛИЗ ПРИЗНАКА РЕКОМЕНДАЦИИ ЗАКРЫТИЯ ТЕЛЕЖКИ

                        if (dlgRepackItemResult != DialogResult.Abort)
                        {
                            int? canCloseTrolley = null;

                            using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                                adapter.RepackRecommendCloseTrolley(this.UserID, this.WarehouseID, this.LOCN, ref canCloseTrolley);

                            if (canCloseTrolley.HasValue && Convert.ToBoolean(canCloseTrolley.Value) == true)
                            {
                                MessageBox.Show("Необходимо закрыть тележку с ГП.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                CloseTrolley();
                            }
                        }

                        #endregion

                        this.RefreshData();
                        this.FindRepackItemInTask(barcodeYL);
                        tbScan.Focus();
                    }
                }
                else
                {
                    throw new Exception("Ш/К ЖЭ в заданиях перепаковки не найден!");
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                tbScan.Focus();
                tbScan.SelectAll();
                return false;
            }
        }

        /// <summary>
        /// Нахождение и установка фокуса на позицию из задания перепаковки 
        /// </summary>
        private Data.WH.RepackMainDisplayCurrentTasksRow FindRepackItemInTask(string repackItemBarcode)
        {
            foreach (DataGridViewRow row in dgvCurrentTasks.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.WH.RepackMainDisplayCurrentTasksRow;
                if (boundRow != null && boundRow.barcode_YL.ToUpper().Trim().Equals(repackItemBarcode.ToUpper().Trim()))
                {
                    row.Selected = true;
                    dgvCurrentTasks.FirstDisplayedScrollingRowIndex = row.Index;
                    return boundRow;
                }
            }

            return null;
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                repackMainDisplayCurrentTasksTableAdapter.Fill(wH.RepackMainDisplayCurrentTasks, this.UserID, WarehouseID, LOCN, (string)null, EXECUTION_MODE);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

            tbScan.Text = string.Empty;
        }

        /// <summary>
        /// Закрытие тележки
        /// </summary>
        private void CloseTrolley()
        {
            var dlgCloseTrolley = new RepackCloseTrolleyForm() { UserID = this.UserID, WarehouseID = this.WarehouseID, LOCN = this.LOCN };
            if (dlgCloseTrolley.ShowDialog() == DialogResult.OK)
            {
                this.TrolleyBarCode = (string)null;
                this.RefreshData();
            }
        }

        /// <summary>
        /// Фиксация тележки
        /// </summary>
        private void AssignTrolley()
        {
            var dlgAssignTrolley = new RepackAssignTrolleyForm() { UserID = this.UserID, WarehouseID = this.WarehouseID, LOCN = this.LOCN };
            if (dlgAssignTrolley.ShowDialog() == DialogResult.OK)
            {
                this.TrolleyBarCode = dlgAssignTrolley.TrolleyBarCode;
                this.RefreshData();
            }
        }

        private void dgvCurrentTasks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCurrentTasks.Rows)
            {
                var boundRow = (dgvCurrentTasks.Rows[row.Index].DataBoundItem as DataRowView).Row as Data.WH.RepackMainDisplayCurrentTasksRow;
                var color = Color.FromName(boundRow.color);

                foreach (DataGridViewColumn column in dgvCurrentTasks.Columns)
                {
                    row.Cells[column.Index].Style.BackColor = color;
                    row.Cells[column.Index].Style.SelectionForeColor = color;
                }
            }
        }
    }
}
