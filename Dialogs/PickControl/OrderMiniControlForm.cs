using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class OrderMiniControlForm : DialogForm
    {
        public long DocID { get; set; }
        public int OrderID { get; set; }

        public long? ProcessVersionID { get; set; }
        public bool CommitVersionChanges { get; set; }

        public bool IsProcessVersionEquals_2 { get { return this.ProcessVersionID.HasValue && ProcessVersionID.Value == 2; } }

        private bool UndoEnabled
        {
            get { return btnUndo.Enabled; }
            set { btnUndo.Enabled = value; }
        }

        private int _itemCode = 0;
        private string _vendorLot = "NOSER";
        private string _itemUOM = "IX";
        private string _scanType = "B"; 

        private int _count = 0;

        private bool _ntvFlag = false;
        private int _ntvQuantity = 0;

        private string _itemName = "";

        private bool _needReControl = false;

        public OrderMiniControlForm()
        {
            InitializeComponent();
            _count = 1;
        }

        public OrderMiniControlForm(bool needReControl)
            : this()
        {
            _needReControl = needReControl;
        }   

        public OrderMiniControlForm(int itemCode, string vendorLot, string itemUOM, string scanType, string itemName)
            : this()
        {
            _itemCode = itemCode;
            _vendorLot = vendorLot;
            _itemUOM = itemUOM;
            _scanType = scanType;
            _itemName = itemName;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (_needReControl)
                this.Text = string.Format("{0} № {1} по документу № {2} (повторный контроль)", this.Text, this.OrderID, this.DocID);
            else
                this.Text = string.Format("{0} № {1} по документу № {2}", this.Text, this.OrderID, this.DocID);

            this.Initialize();

            this.btnOK.Visible = false;
            this.btnCancel.Visible = false;
        }

        private void Initialize()
        {
            tbBarcode.TextChanged += new EventHandler(tbBarcode_TextChanged);

            if (_needReControl)
            {
                this.CancelOrderTask();
                this.RefreshLines();
                tbBarcode.Focus();
            }
            else
                this.AddRow();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Z))
            {
                btnUndo_Click(this, EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.F2) || keyData == (Keys.Control | Keys.F))
            {
                btnAddItem_Click(this, EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.F4))
            {
                btnCloseDoc_Click(this, EventArgs.Empty);
                return true;
            }

            if (keyData == (Keys.F8))
            {
                btnUndoDoc_Click(this, EventArgs.Empty);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private int _lastCountValue;
        void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _ntvFlag = false;
                _ntvQuantity = 0;

                if (string.IsNullOrEmpty(tbBarcode.Text))
                {
                    if (UndoEnabled)
                    {
                        var currentRow = this.MoveToCurrentRow();

                        var form = new SetCountNTVForm();
                        form.CommitVersionChanges = this.CommitVersionChanges;
                        form.ItemID = _itemCode;
                        form.ItemName = _itemName;
                        form.Lotn = _vendorLot;
                        form.TotalCount = currentRow != null ? Convert.ToInt32(currentRow.Doc_Qty_Control) - _count : 1;
                        form.Count = _count;
                        form.InputCountEnabled = true;
                        form.NTVCount = 0;
                        form.DocID = this.DocID;
                        form.NeedConfirmNTV = true;
                        //form.Box = _box;
                        //form.MaxCount = _maxQty;

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            int cnt = _lastCountValue = form.Count;

                            _count = cnt - _count;
                            _ntvFlag = form.NTVCount > 0;
                            _ntvQuantity = form.NTVCount > 0 ? form.NTVCount : 0;

                            if (this.AddRow())
                            {

                            }
                        }
                    }
                }
                else
                {
                    #region ДОБАВЛЕНИЕ ЗАПИСИ В ДОКУМЕНТ КОНТРОЛЯ ПРИ ОБРАБОТКЕ Ш/К

                    _lastCountValue = 1;

                    var success = false; // признак добавления позиции в документ контроля

                    var notRecalcUOMFlag = this.CommitVersionChanges ? 1 : (int?)null;
                    var ignoreSurplusChecks = this.IsProcessVersionEquals_2 ? 1 : (int?)null;
                    Data.PickControl.ItemsDataTable table = null;

                    using (var adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
                        table = adapter.GetData(DocID, UserID, tbBarcode.Text, notRecalcUOMFlag, ignoreSurplusChecks, this.ProcessVersionID);
                    
                    if (table == null || table.Count < 1)
                        throw new Exception("Товар не найден! Воспользуйтесь поиском (Ctrl+F) для добавления товара без штрих кода.");
                    else if (table.Count == 1)
                    {
                        // только один товар нашли! можем переходить к выбору серии
                        Data.PickControl.ItemsRow itemsRow = table[0];
                        _itemCode = (int)itemsRow.Item_ID;
                        _itemName = itemsRow.Item;
                        _itemUOM = itemsRow.UnitOfMeasure;
                        _count = (int)itemsRow.Qty;
                        _scanType = "B";

                        if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                        {
                            // отсканировали уникальный штрих код ящика! Знаем даже серию!
                            _vendorLot = itemsRow.Vendor_Lot;
                            success = AddRow();
                        }
                        else
                        {
                            // отсканировали простой товар, идентифицировали, выбираем серию
                            success = ChooseSeries();
                        }
                    }
                    else
                    {
                        // нашли несколько товаров, нужно выбрать наш
                        success = ChooseItems(table);
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                tbBarcode.Text = "";
            }
        }

        private void RefreshLines()
        {
            try
            {
                pC_IO_Order_DocRowsTableAdapter.Fill(pickControl.PC_IO_Order_DocRows, this.DocID, this.OrderID);

                this.MoveToCurrentRow();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private Data.PickControl.PC_IO_Order_DocRowsRow MoveToCurrentRow()
        {
            foreach (DataGridViewRow row in dgvDocRows.Rows)
            {
                var docRow = (row.DataBoundItem as DataRowView).Row as Data.PickControl.PC_IO_Order_DocRowsRow;
                if (docRow.Item_ID == _itemCode && docRow.Vendor_Lot.Equals((_vendorLot ?? "").Trim(), StringComparison.OrdinalIgnoreCase) && docRow.Itm_UOM.Equals((_itemUOM ?? "").Trim(), StringComparison.OrdinalIgnoreCase))
                {
                    row.Selected = true;
                    return docRow;
                }
            }

            return null;
        }

        private bool AddRow()
        {
            try
            {
                var addResult = this.AddDocRow();
                if (addResult)
                {
                    addResult = this.AddDocRowToMainDoc();
                    if (addResult)
                    {
                        this.VerifyUOM();
                        return true;
                    }
                    else
                    {
                        this.RemoveDocRow();
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
            finally
            {
                UndoEnabled = true;

                RefreshLines();
                tbBarcode.Focus();
            }
        }

        private bool AddDocRow()
        {
            var addResult = this.ChangeDocRow(_count, _ntvQuantity);
            return addResult;
        }

        private bool RemoveDocRow()
        {
            var removeResult = this.ChangeDocRow(-1 * _count, -1 * _ntvQuantity);
            return removeResult;
        }

        private bool ChangeDocRow(int count, int ntvQuantity)
        {
            try
            {
                pC_IO_Order_DocRowsTableAdapter.AddDocRow(this.DocID, this.OrderID, _itemCode, _vendorLot, count, ntvQuantity);
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("#SURPLUS#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#SURPLUS#(?<msg>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        var message = regex.Match(ex.Message).Groups["msg"].Value;

                        FullScreenErrorForm errorForm = new FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Enter)", Color.Red);
                        errorForm.TimeOut = 2000;
                        errorForm.ShowDialog();
                    }
                    else
                        this.ShowError(ex);
                }
                else
                    this.ShowError(ex);

                return false;
            }
        }

        private bool AddDocRowToMainDoc()
        {
            try
            {
                var mdsMessage = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.DocRowsTableAdapter())
                    adapter.Insert(this.DocID, _itemCode, _vendorLot, _itemUOM, _count, _scanType, _ntvFlag, _ntvQuantity, this.ProcessVersionID, ref mdsMessage);

                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                if (ex.Message.Contains("#OVERQUANTITY"))
                {
                    message = ex.Message.Replace("#OVERQUANTITY", string.Empty).Replace("_SKIP", string.Empty);
                    var body = ex.Message.Contains("#OVERQUANTITY_SKIP") ? "OVERQUANTITY_SKIP" : "OVERQUANTITY";

                    var regex = new System.Text.RegularExpressions.Regex(string.Format(@"^#{0}#(?<Message>.+)#", body), System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                        message = regex.Match(ex.Message).Groups["Message"].Value;
                }
                else if (ex.Message.StartsWith("#"))
                {
                    message = ex.Message.Replace("#", string.Empty);

                    var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                        message = regex.Match(ex.Message).Groups["Message"].Value;
                }

                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void VerifyUOM()
        {
            try
            {
                var message = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.DocRowsTableAdapter())
                    adapter.VerifyUOM(this.UserID, this.DocID, _itemCode, ref message);

                if (!string.IsNullOrEmpty(message))
                {
                    var messageForm = new FullScreenErrorForm(message, "ПРОДОЛЖИТЬ (Пробел)", Color.Yellow);
                    messageForm.TimeOut = 2000;
                    messageForm.AutoClose = false;
                    messageForm.CloseKey = Keys.Space;
                    messageForm.ShowDialog();
                }
            }
            catch
            {

            }
        }

        #region ВЫБОР ТОВАРА И СЕРИИ

        private int? surplusMode = null;
        private int? archiveMode = null;

        /// <summary>
        /// Метод выбора товара (если количество позиций с одним штрих кодом более 1)
        /// </summary>
        private bool ChooseItems(object dataTable)
        {
            var success = false;

            if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                RichListForm formItm = new RichListForm();
                //if (formItm == null)
                //{

                #region column Bonus
                DataGridViewTextBoxColumn colBonus = new DataGridViewTextBoxColumn();
                colBonus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colBonus.DataPropertyName = "bonus";
                colBonus.HeaderText = "Бонус";
                colBonus.Name = "colBonus";
                colBonus.ReadOnly = true;
                formItm.Columns.Add(colBonus);
                #endregion
                #region column Item
                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItem.DataPropertyName = "Item";
                colItem.HeaderText = "Наименование";
                colItem.Name = "colItem";
                colItem.ReadOnly = true;
                formItm.Columns.Add(colItem);
                #endregion
                #region column Manufacturer
                DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colManuf.DataPropertyName = "Manufacturer";
                colManuf.HeaderText = "Производитель";
                colManuf.Name = "colManuf";
                colManuf.ReadOnly = true;
                formItm.Columns.Add(colManuf);
                #endregion

                formItm.Text = "Выбор товара";
                Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                formItm.DataSource = table;
                formItm.ColumnForFilters.Add("Item");
                formItm.ColumnForFilters.Add("Manufacturer");
                formItm.FilterVisible = false;
                //formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                //}
                formItm.DataSource = dataTable;

                if (formItm.ShowDialog() == DialogResult.OK)
                {
                    if (formItm.SelectedRow != null)
                    {
                        Data.PickControl.ItemsRow row = (Data.PickControl.ItemsRow)formItm.SelectedRow;

                        _itemCode = (int)row.Item_ID;
                        _itemName = row.Item;
                        _itemUOM = row.UnitOfMeasure;

                        _count = (int)row.Qty;
                        _scanType = "B";

                        success = ChooseSeries();
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }

            return success;
        }

        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private bool ChooseSeries()
        {
            // получаем серии
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                var success = false;

                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetData(DocID, _itemCode, string.Empty, surplusMode, archiveMode, this.ProcessVersionID);

                    if (table == null || table.Count < 1)
                    {
                        throw new Exception("Серии не найдены! Это исключительная ситуация. Обратитесь в Группу сопровождения ПО.");
                    }
                    else if (table.Count == 1)
                    {
                        if (table[0].Vendor_Lot == "NOSER")
                        {
                            // контроль серий отключен
                            _vendorLot = table[0].Vendor_Lot;
                            success = AddRow();
                        }
                        else
                        {
                            // серию необходимо ввести руками
                            success = SetSeria();
                        }
                    }
                    //else if (table.Count == 2)
                    //{
                    //    // только одину серию, добавляем строку в документ
                    //    _vendorLot = table[0].Vendor_Lot;
                    //    AddRow();
                    //}
                    else
                    {
                        // есть несколько серий, предлагаем пользователю выбрать
                        success = ChooseSeries(table);
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("YELLOWFORM"))
                    {
                        FullScreenErrorForm errorForm = new FullScreenErrorForm(
                            String.Format("Товар {0}\n\rНЕ содержится в сборочном листе.\n\rТовар был выбран из списка.\n\rИсправьте свой выбор (если ошиблись),\n\rиначе\n\rОтложите товар в прозрачный ящик!", ex.Message.Replace("YELLOWFORM", "")),
                            "ПРОДОЛЖИТЬ (Enter)", Color.Yellow);
                        errorForm.ShowDialog();
                        UndoEnabled = false;
                    }
                    else
                        ShowError(ex);
                }

                return success;
            }
        }

        RichListForm formSeries = null;
        private bool ChooseSeries(DataTable dataTable)
        {
            var success = false;

            #region ПОДГОТОВКА СЕРИЙ К ОТОБРАЖЕНИЮ

            // удалим строки, которые не нужно отображать
            var lstRowsToRemove = new List<Data.PickControl.VendorLotsRow>();
            foreach (Data.PickControl.VendorLotsRow dr in dataTable.Rows)
                if (!dr.IsHideNull() && dr.Hide)
                    lstRowsToRemove.Add(dr);

            for (int i = 0; i < lstRowsToRemove.Count; i++)
                dataTable.Rows.Remove(lstRowsToRemove[i]);

            #endregion

            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                if (formSeries == null)
                {
                    formSeries = new RichListForm() { Width = 600, DiscardCanceling = true, AllowSearchByEmptyFilter = true };
                    #region column Lotn
                    DataGridViewTextBoxColumn colLot = new DataGridViewTextBoxColumn();
                    colLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colLot.DataPropertyName = "Vendor_Lot";
                    colLot.HeaderText = "Серия";
                    colLot.Name = "colLot";
                    colLot.ReadOnly = true;
                    formSeries.Columns.Add(colLot);
                    #endregion
                    #region column Date
                    DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                    colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colDate.DataPropertyName = "Exp_Date";
                    colDate.HeaderText = "Срок годн.";
                    colDate.Name = "colDate";
                    colDate.ReadOnly = true;
                    formSeries.Columns.Add(colDate);
                    #endregion
                    #region column Collectors_remains
                    DataGridViewTextBoxColumn colCollectorsRemains = new DataGridViewTextBoxColumn();
                    colCollectorsRemains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colCollectorsRemains.DataPropertyName = "Collectors_remains";
                    colCollectorsRemains.HeaderText = "Остаток, уп.";
                    colCollectorsRemains.Name = "colCollectorsRemains";
                    colCollectorsRemains.ReadOnly = true;
                    formSeries.Columns.Add(colCollectorsRemains);
                    #endregion

                    //formSeries.FilterVisible = false;
                    formSeries.ColumnForFilters.Add("Vendor_Lot");
                    formSeries.FilterChangeLevel = 2;

                    if (!this.CommitVersionChanges)
                        formSeries.FilterChanged += new EventHandler(formSeries_FilterChanged);
                }
                formSeries.Text = "Выбор серии " + _itemName;
                //ListChoiceForm form = new ListChoiceForm(dataTable, "Vendor_Lot", "Vendor_Lot");
                //form.Text = "Выбор серии " + _itemName;
                //form.RememberChoiceVisible = false;
                formSeries.DataSource = dataTable;

                if (formSeries.ShowDialog() == DialogResult.OK)
                {
                    if (formSeries.SelectedRow != null)
                    {
                        Data.PickControl.VendorLotsRow row = (Data.PickControl.VendorLotsRow)formSeries.SelectedRow;
                        if (row.Vendor_Lot == "Ввести серию вручную...")
                        {
                            success = SetSeria();
                        }
                        else
                        {
                            _vendorLot = row.Vendor_Lot;
                            success = AddRow();
                        }
                    }
                    else
                    {
                        UndoEnabled = false;
                    }
                }
                else
                {
                    UndoEnabled = false;
                }
            }
            else
            {
                UndoEnabled = false;
            }

            return success;
        }

        private void formSeries_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.VendorLotsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
            {
                try
                {
                    Data.PickControl.VendorLotsDataTable table = adapter.GetData(DocID, _itemCode, formSeries.Filter, surplusMode, archiveMode, this.ProcessVersionID);
                    formSeries.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private bool SetSeria()
        {
            var success = false;

            SetVendorLotnForm form = new SetVendorLotnForm() { UserID = this.UserID };
            form.Text = "Присвоение серии " + _itemName;
            if (form.ShowDialog() == DialogResult.OK)
            {
                _vendorLot = form.Lotn;
                success = AddRow();
            }
            else
            {
                UndoEnabled = false;
            }

            return success;
        }

        #endregion

        private bool CloseOrderTask()
        {
            bool fixShortage = false;

            while (true)
            {
                try
                {
                    using (var adapter = new Data.PickControlTableAdapters.PC_IO_OrdersTableAdapter())
                        adapter.CloseOrderTask(this.DocID, this.OrderID, fixShortage);

                    this.ConfirmPrintedEtic();

                    return true;
                }
                catch (Exception ex)
                {
                    var hasCommonErrorMessage = false;

                    if (ex.Message.Contains("#SHORTAGE"))
                    {
                        var regex = new System.Text.RegularExpressions.Regex(@"^#SHORTAGE#(?<msg>.+)#$", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            var match = regex.Match(ex.Message);
                            var message = match.Groups["msg"].Value;

                            if (MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                            {
                                var success = this.ConfirmShortage();
                                if (success)
                                {
                                    fixShortage = true;
                                    continue;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            hasCommonErrorMessage = true;
                        }
                    }
                    else
                    {
                        hasCommonErrorMessage = true;
                    }

                    if (hasCommonErrorMessage)
                    {
                        this.ShowError(ex);
                        break;
                    }
                }
            }

            return false;
        }

        private bool ConfirmPrintedEtic()
        {
            try
            {
                PickControlWindow.CheckPrintedEtics(this.UserID, this.DocID, this.CommitVersionChanges, true);
                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled)
            {
                _count = _count * -1;
                _ntvQuantity = _ntvQuantity * -1;
                AddRow();
                UndoEnabled = false;
            }
        }

        RichListForm formItems = null;
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (!btnAddItem.Enabled)
                return;

            try
            {
                if (formItems == null)
                {
                    formItems = new RichListForm();
                    #region column Item
                    DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                    colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colItem.DataPropertyName = "Item";
                    colItem.HeaderText = "Наименование";
                    colItem.Name = "colItem";
                    colItem.ReadOnly = true;
                    formItems.Columns.Add(colItem);
                    #endregion
                    #region column Manufacturer
                    DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                    colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colManuf.DataPropertyName = "Manufacturer";
                    colManuf.HeaderText = "Производитель";
                    colManuf.Name = "colManuf";
                    colManuf.ReadOnly = true;
                    formItems.Columns.Add(colManuf);
                    #endregion

                    formItems.Text = "Выбор товара";
                    Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                    formItems.DataSource = table;
                    formItems.ColumnForFilters.Add("Item");
                    formItems.ColumnForFilters.Add("Manufacturer");
                    formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                }
                if (formItems.ShowDialog() == DialogResult.OK)
                {
                    _itemCode = (int)((Data.PickControl.ItemsRow)formItems.SelectedRow).Item_ID;
                    _itemName = ((Data.PickControl.ItemsRow)formItems.SelectedRow).Item;
                    _itemUOM = ((Data.PickControl.ItemsRow)formItems.SelectedRow).UnitOfMeasure;
                    _count = 1;
                    _scanType = "M"; // ручной выбор товара
                    // двигаемся дальше в сторону выбора серии
                    var success = ChooseSeries();
                }
                else
                {
                    UndoEnabled = false;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void formItems_FilterChanged(object sender, EventArgs e)
        {
            using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
            {
                try
                {
                    Data.PickControl.ItemsDataTable table = adapter.GetDataAll(formItems.Filter);
                    formItems.DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (!btnCloseDoc.Enabled)
                return;

            this.DialogResult = DialogResult.OK;
        }

        private void btnUndoDoc_Click(object sender, EventArgs e)
        {
            if (!btnUndoDoc.Enabled)
                return;

            if (MessageBox.Show("Вы уверены что хотите отменить мини-контроль?", "Отмена мини-контроля", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                this.DialogResult = DialogResult.Cancel;
        }

        private bool CancelOrderTask()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.PC_IO_OrdersTableAdapter())
                    adapter.CancelOrderTask(this.DocID, this.OrderID);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        private void OrderMiniControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CloseOrderTask();
            else 
                if (this.DialogResult == DialogResult.Cancel)
                    e.Cancel = !this.CancelOrderTask();
        }

        private void dgvDocRows_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        private void dgvDocRows_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = (dgvDocRows.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.PC_IO_Order_DocRowsRow;
            var color = row.IsColorNull() ? Color.White : Color.FromName(row.Color);

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        public void ShowError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool ConfirmShortage()
        {
            while (true)
            {
                try
                {
                    var bossID = (int?)null;
                    var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                        Text = "Фиксация Недостачи",
                        Image = Properties.Resources.role,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                        return false;

                    bossID = Convert.ToInt32(dlgBossScanner.Barcode);

                    var result = (int?)null;
                    using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                        adapter.CheckBoss(this.UserID, this.DocID, bossID, ref result);

                    if (result.HasValue && Convert.ToBoolean(result.Value))
                        return true;
                    else
                        throw new Exception("Пользователь не имеет права\r\nподтверждения фиксации Недостачи.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
        }
    }
}
