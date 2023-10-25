using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using System.Timers;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseRequestItemsSelectorForm : DialogForm
    {
        public new long UserID { get; set; }

        public int? RequestID { get; private set; }

        public bool IsEditMode { get { return this.RequestID != null; } }
        public bool IsReadOnly { get; private set; }

        public bool HasChanges { get; private set; }

        public RequestCreateMode RequestCreateMode { get; set; }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public ImportLicenseRequestItemsSelectorForm()
        {
            InitializeComponent();
            this.RequestCreateMode = RequestCreateMode.AddItems;
        }

        public ImportLicenseRequestItemsSelectorForm(int? requestID)
            : this()
        {
            this.RequestID = requestID;
            //this.IsReadOnly = this.IsEditMode;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(717, 8);
            this.btnCancel.Location = new Point(807, 8);

            this.WindowState = FormWindowState.Maximized;

            this.Initialize();
        }

        private void Initialize()
        {
            dgvcColdType.DefaultCellStyle.NullValue = null;
            dgvcColdTypeRequests.DefaultCellStyle.NullValue = null;

            stbVendor.ValueReferenceQuery = "[dbo].[pr_QK_LI_Get_Vendors_List]";
            stbVendor.UserID = this.UserID;
            stbVendor.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbVendor_OnVerifyValue);

            filterTimer.Elapsed += filterTimer_Elapsed;

            if (this.IsEditMode)
                this.Text = string.Format("Выбор товара для уведомления № {0} на обновление лицензии на импорт", this.RequestID);

            switch (this.RequestCreateMode)
            {
                case RequestCreateMode.AddItems:
                    this.Text = string.Format("{0} [Режим обновления] {1}", this.Text, this.IsReadOnly ? "[ТОЛЬКО ЧТЕНИЕ]" : string.Empty);
                    chbOnlyNeedProcessLicense.Text = "Только товары требующие лицензию";
                    chbOnlyNeedProcessLicense.ForeColor = Color.Blue;
                    break;
                case RequestCreateMode.RemoveItems:
                    this.Text = string.Format("{0} [Режим изъятия] {1}", this.Text, this.IsReadOnly ? "[ТОЛЬКО ЧТЕНИЕ]" : string.Empty);
                    chbOnlyNeedProcessLicense.Text = "Только товары требующие обнуление лицензии";
                    chbOnlyNeedProcessLicense.ForeColor = Color.Red;
                    break;
                default:
                    break;
            }

            if (this.IsEditMode)
            {
                if (this.IsReadOnly)
                {
                    pnlFilter.Visible = false;
                    spcTwoGrids.Panel1Collapsed = true;
                    spcInternalGrid.Panel1Collapsed = true;

                    btnOK.Visible = false;
                    btnCancel.Text = "Закрыть";

                    btnCancel.Focus();
                }
            }

            this.SetOperationsAccess();

            this.InitializeItems();

            _isInitialized = true;

            if (this.RequestCreateMode == RequestCreateMode.AddItems && !this.IsReadOnly)
                chbOnlyNeedProcessLicense.Checked = true;

            if (this.RequestCreateMode == RequestCreateMode.RemoveItems && !this.IsReadOnly)
                this.ChangeOnlyNeedLicenseState();
        }

        void stbVendor_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbVendor)
                lblDescription = tbVendor;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                {
                    control.Value = e.Value;

                    if (control == stbVendor)
                    {
                        filterVendorID = string.IsNullOrEmpty(stbVendor.Value) ? (int?)null : Convert.ToInt32(stbVendor.Value);
                        filterTimer.Stop();
                        filterTimer.Start();
                    }
                }
                //else
                //    control.Value = string.Empty;
            }
        }

        private bool _isInitialized = false;
        private string _selectedItems = null;
        public string SelectedItems
        {
            get 
            {
                //var selectedItems = this.GetSelectedItems();
                //return string.IsNullOrEmpty(selectedItems) ? _selectedItems : selectedItems; 

                return _isInitialized ? _selectedItems = this.GetSelectedItems() : _selectedItems;
            }
            set { _selectedItems = value; }
        }

        private string GetSelectedItems()
        {
            var sbRequestItems = new StringBuilder();
            foreach (Data.Quality.QK_LI_Search_ItemsRow item in qualityRequests.QK_LI_Search_Items)
            {
                if (sbRequestItems.Length > 0)
                    sbRequestItems.AppendFormat(", {0}", item.ItemID);
                else
                    sbRequestItems.AppendFormat("{0}", item.ItemID);
            }

            return sbRequestItems.ToString();
        }

        private void btnFindItemForRequest_Click(object sender, EventArgs e)
        {

        }

        private void btnAddToRequest_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow selectedRow in dgvItems.SelectedRows)
                {
                    var item = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_Search_ItemsRow;

                    var canSelect = item.IsCanSelectNull() ? false : item.CanSelect; 

                    if (canSelect)
                    {
                        qualityRequests.QK_LI_Search_Items.LoadDataRow(item.ItemArray, true);

                        quality.QK_LI_Search_Items.RemoveQK_LI_Search_ItemsRow(item);
                        //quality.QK_LI_Search_Items.Rows.Remove(item);

                        this.HasChanges = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveFromRequest_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow selectedRow in dgvRequestItems.SelectedRows)
                {
                    var item = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_Search_ItemsRow;

                    qualityRequests.QK_LI_Search_Items.RemoveQK_LI_Search_ItemsRow(item);
                    //qualityRequests.QK_LI_Search_Items.Rows.Remove(item);

                    this.HasChanges = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            stbVendor.SetValueByDefault(string.Empty);
            tbFilter.Clear();
            chbOnlyNeedProcessLicense.Checked = false;
        }

        #region ПРИМЕНЕНИЕ ФИЛЬТРА ПО ТОВАРАМ

        /// <summary>
        /// Таймер, который отвечает за то, чтобы фильтрация по остаткам проихсодила не сразу после изменения
        /// фильтра, а спустя некоторое время
        /// </summary>
        private System.Timers.Timer filterTimer = new System.Timers.Timer(1000);
        /// <summary>
        /// Строка фильтра (эта переменная сделана для того, чтобы не обращаться из левых потоков к TextBox)
        /// </summary>
        private string filterItem;

        private bool filterOnlyNeedProcessLicense;

        private int? filterVendorID;

        /// <summary>
        /// Делегат для асинхронного вызова фильтрации
        /// </summary>
        private delegate void Method();

        private void tbFilter_Enter(object sender, EventArgs e)
        {

        }

        private void tbFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                filterTimer.Stop();
                LoadItems();
            }
        }

        /// <summary>
        /// Если прошло достаточно времени с момента последнего редактирования фильтра, запускается фильтрация
        /// </summary>
        private void filterTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            filterTimer.Stop();
            dgvItems.Invoke(new Method(LoadItems));
        }

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            filterItem = tbFilter.Text;
            filterTimer.Stop();
            filterTimer.Start();
        }

        private void InitializeItems()
        {
            try
            {
                var selectedItems = this.SelectedItems;
                this.SearchItems(qualityRequests.QK_LI_Search_Items, (string)null, (int?)null, (bool?)null, selectedItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchItems(Data.Quality.QK_LI_Search_ItemsDataTable searchResults, string itemName, int? vendorID, bool? onlyNeedProcessLicense, string selectedItems)
        {
            var splashForm = new SplashForm();

            try
            {
                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        switch (this.RequestCreateMode)
                        {
                            case RequestCreateMode.AddItems:
                                using (var adapter = new Data.QualityTableAdapters.QK_LI_Search_ItemsTableAdapter())
                                {
                                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                                    //adapter.FillForAddition(searchResults, this.UserID, itemName, this.RequestID, vendorID, onlyNeedProcessLicense, selectedItems);
                                    e.Result = adapter.GetDataForAddition(this.UserID, itemName, this.RequestID, vendorID, onlyNeedProcessLicense, selectedItems);
                                }
                                break;
                            case RequestCreateMode.RemoveItems:
                                using (var adapter = new Data.QualityTableAdapters.QK_LI_Search_ItemsTableAdapter())
                                {
                                    adapter.SetTimeout((int)TimeSpan.FromMinutes(3).TotalSeconds);
                                    //adapter.FillForDeletion(searchResults, this.UserID, itemName, this.RequestID, vendorID, onlyNeedProcessLicense, selectedItems);
                                    e.Result = adapter.GetDataForDeletion(this.UserID, itemName, this.RequestID, vendorID, onlyNeedProcessLicense, selectedItems);
                                }
                                break;
                            default:
                                break;
                        }

                        //System.Threading.Thread.Sleep(1000);

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
                    else if (e.Result is Data.Quality.QK_LI_Search_ItemsDataTable)
                        searchResults.Merge(e.Result as Data.Quality.QK_LI_Search_ItemsDataTable, true);
                };
                searchResults.Clear();
                splashForm.ActionText = string.Format("Выполняется {0} товаров..", _isInitialized ? "поиск" : "инициализация");
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadItems()
        {
            try
            {
                if (filterItem != null && filterItem.Length > 0 && filterItem.Length < 3)
                    return;

                //if (!filterVendorID.HasValue && !filterOnlyNeedProcessLicense && (filterItem == null || filterItem.Length == 0)) 
                //{
                //    quality.QK_LI_Search_Items.Clear();
                //    return;
                //}

                var vendorID = filterVendorID;
                var itemName = filterItem ?? "";
                var onlyNeedProcessLicense = filterOnlyNeedProcessLicense;
                var selectedItems = this.SelectedItems;

                this.SearchItems(quality.QK_LI_Search_Items, itemName, vendorID, onlyNeedProcessLicense, selectedItems);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetOperationsAccess()
        {
            btnFindItemForRequest.Enabled = false;
            btnAddToRequest.Enabled = this.CheckCanAddItemsToRequest(); // dgvItems.SelectedRows.Count > 0;
            btnRemoveFromRequest.Enabled = this.CheckCanRemoveItemsFromRequest(); //dgvRequestItems.SelectedRows.Count > 0;
        }

        private bool CheckCanAddItemsToRequest()
        {
            var cntItemsToAdd = 0;

            foreach (DataGridViewRow selectedRow in dgvItems.SelectedRows)
            {
                var item = (selectedRow.DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_Search_ItemsRow;

                var canSelect = item.IsCanSelectNull() ? false : item.CanSelect;

                if (canSelect)
                    cntItemsToAdd++;
            }

            return cntItemsToAdd > 0;
        }

        private bool CheckCanRemoveItemsFromRequest()
        {
            var cntItemsToRemove = dgvRequestItems.SelectedRows.Count;
            return cntItemsToRemove > 0;
        }

        private void chbOnlyNeedLicense_CheckedChanged(object sender, EventArgs e)
        {
            this.ChangeOnlyNeedLicenseState();

            //if (this.RequestCreateMode == RequestCreateMode.AddItems && !chbOnlyNeedProcessLicense.Checked)
            //{
            //    chbOnlyNeedProcessLicense.Checked = true;
            //    //return;
            //}

            //filterOnlyNeedProcessLicense = chbOnlyNeedProcessLicense.Checked;
            //filterTimer.Stop();
            //filterTimer.Start();
        }

        private void ChangeOnlyNeedLicenseState()
        {
            if (this.RequestCreateMode == RequestCreateMode.AddItems && !chbOnlyNeedProcessLicense.Checked)
            {
                chbOnlyNeedProcessLicense.Checked = true;
                //return;
            }

            filterOnlyNeedProcessLicense = chbOnlyNeedProcessLicense.Checked;
            filterTimer.Stop();
            filterTimer.Start();
        }

        #endregion

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var dataRow = ((sender as DataGridView).Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_Search_ItemsRow;
                var isAutoChecked = dataRow.IsIsAutoCheckedNull() ? false : dataRow.IsAutoChecked;
                var canSelect = dataRow.IsCanSelectNull() ? false : dataRow.CanSelect;
                var itemExists = dataRow.ItemID > 0;

                if (!canSelect && (!isAutoChecked || this.RequestCreateMode == RequestCreateMode.AddItems)) // || !itemExists)
                {
                    e.CellStyle.BackColor = Color.LightGray;
                    e.CellStyle.SelectionForeColor = Color.LightGray;
                }
                else if (isAutoChecked)
                {
                    e.CellStyle.BackColor = this.RequestCreateMode == RequestCreateMode.AddItems ? Color.LightBlue : this.RequestCreateMode == RequestCreateMode.RemoveItems ? Color.LightPink : e.CellStyle.BackColor;
                    e.CellStyle.SelectionForeColor = this.RequestCreateMode == RequestCreateMode.AddItems ? Color.LightBlue : this.RequestCreateMode == RequestCreateMode.RemoveItems ? Color.LightPink : e.CellStyle.SelectionForeColor;
                }

                if (!itemExists)
                    e.CellStyle.ForeColor = Color.Brown;

                if (!itemExists && (sender as DataGridView).Columns[e.ColumnIndex].DataPropertyName == quality.QK_LI_Search_Items.ItemIDColumn.Caption)
                    e.Value = string.Empty;
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void dgvRequestItems_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void dgv_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.RepaintColdType(sender == dgvItems ? dgvItems : dgvRequestItems, sender == dgvItems ? dgvcColdType : dgvcColdTypeRequests);
        }

        private void RepaintColdType(DataGridView dgv, DataGridViewImageColumn col)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var dataRow = (row.DataBoundItem as DataRowView).Row as Data.Quality.QK_LI_Search_ItemsRow;

                if (dataRow.IsColdTypeNull() || string.IsNullOrEmpty(dataRow.ColdType))
                {
                    row.Cells[col.Index].Value = emptyIcon;
                }
                else
                {
                    if (dataRow.ColdType == "R")
                    {
                        row.Cells[col.Index].Value = Properties.Resources.snowflakeR;
                        row.Cells[col.Index].ToolTipText = "Признак холода 2-8";
                    }
                    else if (dataRow.ColdType == "B")
                    {
                        row.Cells[col.Index].Value = Properties.Resources.snowflakeB;
                        row.Cells[col.Index].ToolTipText = "Признак холода 8-15";
                    }
                }
            }
        }
    }

    public enum RequestCreateMode
    { 
        AddItems,
        RemoveItems
    }
}
