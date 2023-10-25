using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Transactions;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualitySpecificMedicinesListItemsEditorForm : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private readonly string _perelikID = null;
        private readonly Data.Quality.NL_ListDetailsRow _detail = null;

        private readonly Data.Quality.NL_ListDetailItemsDataTable _detailItemsCache = new WMSOffice.Data.Quality.NL_ListDetailItemsDataTable();

        public bool FullAccess { get; set; }

        public bool IsReadOnly { get; private set; }

        public QualitySpecificMedicinesListItemsEditorForm()
        {
            InitializeComponent();
        }

        public QualitySpecificMedicinesListItemsEditorForm(string perelikID, Data.Quality.NL_ListDetailsRow detail)
            : this()
        {
            _perelikID = perelikID;
            _detail = detail;
        }

        private void QualitySpecificMedicinesListItemsEditorForm_Load(object sender, EventArgs e)
        {
            nLListDetailItemsBindingSource.Sort = quality.NL_ListDetailItems.ItemNameColumn.Caption;
        }

        private void tbItemsFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    string itemsFilter = tbItemsFilter.Text.Trim();

                    var minLength = 3;
                    if (0 < itemsFilter.Length && itemsFilter.Length < minLength)
                        throw new Exception(string.Format("Недопустимая длина текста в фильтре товаров.\r\nМинимальное значение: {0}.", minLength));

                    if (this.IsReadOnly)
                        this.NavigateToItemsByFilter(itemsFilter);
                    else
                        this.LoadItems(itemsFilter);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                }
            }
        }

        private void LoadItems()
        {
            this.LoadItems(null);
        }

        private void LoadItems(string itemsFilter)
        {
            try
            {
                var _detailID = _detail == null ? (int?)null : _detail.DetailID;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) => 
                {
                    try
                    {
                        e.Result = nL_ListDetailItemsTableAdapter.GetData(_perelikID, _detailID, itemsFilter);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) => 
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        quality.NL_ListDetailItems.Clear();
                        quality.NL_ListDetailItems.Merge(e.Result as Data.Quality.NL_ListDetailItemsDataTable);
                    }
                };
                splashForm.ActionText = "Выполняется поиск товаров..";
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();

                this.SyncDetailItems();

                this.NavigateToItemsByFilter(itemsFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NavigateToItemsByFilter(string itemsFilter)
        {
            var itemsFound = false;

            try
            {
                if (dgvItems.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(itemsFilter))
                    {
                        var filterQuery = string.Empty;

                        double itemID;
                        double.TryParse(itemsFilter, out itemID);

                        if (itemsFilter.Replace(",", ";").Contains(";") || itemID > 0)
                        {
                            var sbItems = new StringBuilder();
                            foreach (var item in itemsFilter.Replace(",", ";").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                            {
                                if (double.TryParse(item, out itemID))
                                {
                                    if (sbItems.Length > 0)
                                        sbItems.AppendFormat(",{0}", itemID);
                                    else
                                        sbItems.AppendFormat("{0}", itemID);
                                }
                            }

                            filterQuery = string.Format("{0} IN ({1})", quality.NL_ListDetailItems.ItemIDColumn.Caption, sbItems.ToString());
                        }
                        else
                        {
                            filterQuery = string.Format("{0} LIKE '%{1}%'", quality.NL_ListDetailItems.ItemNameColumn.Caption, itemsFilter);
                        }

                        var items = quality.NL_ListDetailItems.Select(filterQuery, nLListDetailItemsBindingSource.Sort);
                        if (items.Length > 0)
                        {
                            itemID = (items[0] as Data.Quality.NL_ListDetailItemsRow).ItemID;
                            this.NavigateToItem(itemID);
                            itemsFound = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                if (!itemsFound && dgvItems.Rows.Count > 0)
                {
                    dgvItems.FirstDisplayedScrollingRowIndex = 0;
                    dgvItems.Rows[0].Selected = false;
                }
            }
        }

        private void NavigateToItem(double itemID)
        {
            foreach (DataGridViewRow boundRow in dgvItems.Rows)
            {
                var item = (boundRow.DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailItemsRow;
                if (item.ItemID.Equals(itemID))
                {
                    boundRow.Selected = true;
                    dgvItems.FirstDisplayedScrollingRowIndex = boundRow.Index;
                    return;
                }
            }
        }

        private void SyncDetailItems()
        {
            try
            {
                // Добавим в кэш отсутсвующие товары из таблицы
                foreach (Data.Quality.NL_ListDetailItemsRow item in quality.NL_ListDetailItems.Rows)
                    this.SyncDetailItems(item, (bool?)null);

                // Добавим в таблицу отсутсвующие товары из кэша
                foreach (Data.Quality.NL_ListDetailItemsRow item in _detailItemsCache.Rows)
                    if (quality.NL_ListDetailItems.FindByItemID(item.ItemID) == null)
                        this.SyncDetailItems(item, (bool?)null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SyncDetailItems(Data.Quality.NL_ListDetailItemsRow item, bool? isChecked)
        {
            try
            {
                var findItem = _detailItemsCache.FindByItemID(item.ItemID);

                // Автоматическое добавление товара в кэш в случае его отсутсвия
                if (findItem == null && !item.IsExistsNull() && item.Exists)
                    _detailItemsCache.LoadDataRow(item.ItemArray, false);

                if (findItem != null)
                {
                    // Ручная корректировка
                    if (isChecked.HasValue)
                    {
                        // Товар был выбран
                        if (isChecked ?? false == true)
                        {
                            // Повторное добавление товара в кэш
                            if (!item.IsExistsNull() && item.Exists && !findItem.Exists)
                                findItem.Exists = true;
                        }
                        // Товар был исключен из выбора
                        else
                        {
                            // Удаление товара из кэша
                            findItem.Exists = false;

                            // Товар не существовал ранее в документе
                            if (findItem.RowState.Equals(DataRowState.Added))
                                item.SetExistsNull();
                        }
                    }
                    // Автоматическая корректировка (после обновления)
                    else
                    {
                        // Товар был исключен из документа (после обновления)
                        if (!item.IsExistsNull() && item.Exists && !findItem.Exists)
                            item.Exists = false;

                        // Товар был выбран (после обновления)
                        if (item.IsExistsNull() && findItem.Exists)
                            item.Exists = true;

                        // Товар был выбран перед снятым фильтром (после обновления)
                        if (findItem.Exists && findItem.Equals(item))
                        {
                            quality.NL_ListDetailItems.LoadDataRow(item.ItemArray, false);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_detail != null)
            {
                tbOrderNumber.Text = !_detail.IsOrderNumberNull() ? _detail.OrderNumber : string.Empty;
                dtpOrderDateFrom.Value = !_detail.IsDateFromNull() ? _detail.DateFrom : DateTime.Today;
                tbOrderDescription.Text = !_detail.IsDescriptionNull() ? _detail.Description : string.Empty;
            }

            this.Text = string.Format("{0}{1}", this.Text, _detail == null ? "*" : string.Empty);

            this.IsReadOnly = !this.FullAccess && _detail != null;

            if (this.IsReadOnly)
            {
                tbOrderNumber.ReadOnly = true;
                tbOrderNumber.BackColor = SystemColors.Window;

                dtpOrderDateFrom.Enabled = false;

                tbOrderDescription.ReadOnly = true;
                tbOrderDescription.BackColor = SystemColors.Window;

                dgvItems.ReadOnly = true;

                btnOK.Visible = false;
                btnCancel.Text = "Закрыть";

                this.Text = string.Format("{0} (только чтение)", this.Text);
            }
            else if (!string.IsNullOrEmpty(tbOrderNumber.Text))
            {
                tbOrderNumber.ReadOnly = true;
                tbOrderNumber.BackColor = SystemColors.Window;
            }

            this.btnOK.Location = new Point(1132, 8);
            this.btnCancel.Location = new Point(1222, 8);

            var tip = new ToolTip();
            var tipText = "Фильтр по товарам.\r\n\r\nПримеры:\r\n\r\n - 49623;49624\r\n - ксарелто";
            tip.SetToolTip(pnlFilter, tipText);
            tip.SetToolTip(lblItemsFilter, tipText);
            tip.SetToolTip(tbItemsFilter, tipText);

            this.LoadItems();

            _detailItemsCache.AcceptChanges();

            if (_detail != null)
                tbItemsFilter.Focus();
        }

        private void dgvItems_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                var item = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailItemsRow;
                this.SyncDetailItems(item, item.Exists);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                var isCheckedValue = this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[this.existsDataGridViewCheckBoxColumn.Index].Value;

                var backColor = isCheckedValue.Equals(DBNull.Value) || this.IsReadOnly ? SystemColors.Window : isCheckedValue.Equals(true) ? Color.LightGreen : Color.LightPink;
                var selectionForeColor = isCheckedValue.Equals(DBNull.Value) || this.IsReadOnly ? Color.Black : isCheckedValue.Equals(true) ? Color.LightGreen : Color.LightPink;

                foreach (DataGridViewColumn column in this.dgvItems.Columns)
                {
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.BackColor = backColor;
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = selectionForeColor;
                }
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            var isCheckedValue = this.dgvItems.Rows[e.RowIndex].Cells[this.existsDataGridViewCheckBoxColumn.Index].Value;

            var backColor = isCheckedValue.Equals(DBNull.Value) || this.IsReadOnly ? SystemColors.Window : isCheckedValue.Equals(true) ? Color.LightGreen : Color.LightPink;
            var selectionForeColor = isCheckedValue.Equals(DBNull.Value) || this.IsReadOnly ? Color.Black : isCheckedValue.Equals(true) ? Color.LightGreen : Color.LightPink;

            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = backColor;
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = selectionForeColor; // Color.FromArgb(209, 255, 117)
        }

        private void QualitySpecificMedicinesListItemsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveChanges();
        }

        private bool SaveChanges()
        {
            try
            {
                if (string.IsNullOrEmpty(tbOrderNumber.Text))
                    throw new Exception("№ приказа должен быть указан.");

                if (string.IsNullOrEmpty(tbOrderDescription.Text))
                    throw new Exception("Описание приказа должно быть указано.");

                var perelikID = _perelikID;
                var detailID = _detail == null ? (int?)null : _detail.DetailID;

                var orderNumber = tbOrderNumber.Text;
                var orderDescription = tbOrderDescription.Text;
                var orderDateFrom = dtpOrderDateFrom.Value;

                using (var scope = new TransactionScope())
                {
                    if (detailID.HasValue)
                    {
                        using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                            adapter.Edit(perelikID, detailID, orderDescription, orderDateFrom, orderNumber, this.UserID);
                    }
                    else
                    {
                        using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                            adapter.Add(perelikID, orderDescription, orderDateFrom, orderNumber, this.UserID, ref detailID);
                    }

                    var itemsToAdd = new List<double>();
                    var itemsToRemove = new List<double>();

                    foreach (Data.Quality.NL_ListDetailItemsRow item in _detailItemsCache.Rows)
                    {
                        if (item.RowState.Equals(DataRowState.Added) && item.Exists)
                            itemsToAdd.Add(item.RowState.Equals(DataRowState.Deleted) ? Convert.ToInt32(item[_detailItemsCache.ItemIDColumn.Caption, DataRowVersion.Original]) : item.ItemID);

                        else if (item.RowState.Equals(DataRowState.Deleted) || (item.RowState.Equals(DataRowState.Modified) && !item.Exists))
                            itemsToRemove.Add(item.RowState.Equals(DataRowState.Deleted) ? Convert.ToInt32(item[_detailItemsCache.ItemIDColumn.Caption, DataRowVersion.Original]) : item.ItemID);
                    }

                    if (itemsToAdd.Count > 0)
                        this.AddItemsList(itemsToAdd, detailID);

                    if (itemsToRemove.Count > 0)
                        this.RemoveItemsList(itemsToRemove, detailID);

                    scope.Complete();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AddItemsList(List<double> items, int? detailID)
        {
            try
            {
                var csvItems = this.GetCsvItems(items);
                nL_ListDetailItemsTableAdapter.AddList(_perelikID, detailID, csvItems, this.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void RemoveItemsList(List<double> items, int? detailID)
        {
            try
            {
                var csvItems = this.GetCsvItems(items);
                nL_ListDetailItemsTableAdapter.RemoveList(_perelikID, detailID, csvItems, this.UserID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetCsvItems(List<double> items)
        {
            var sbItems = new StringBuilder();

            foreach (var item in items)
                if (sbItems.Length > 0)
                    sbItems.AppendFormat(";{0}", item);
                else
                    sbItems.AppendFormat("{0}", item);

            return sbItems.ToString();
        }
    }
}
