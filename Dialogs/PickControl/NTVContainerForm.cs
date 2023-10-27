using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes.PickControl;
using WMSOffice.Window;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class NTVContainerForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public new long UserID { get; set; }

        public NTVContainerDoc NTVContainerDoc { get; private set; }

        public VarianceContainerWorkMode WorkMode { get; private set; }

        public long? PC_DocID { get; private set; }

        public Data.PickControl.NTVContainerDocDetailsRow SelectedDetailRow
        {
            get { return dgvItems.SelectedRows.Count == 0 ? null : (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.NTVContainerDocDetailsRow; }
        }

        #endregion
     
        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        protected NTVContainerForm()
        {
            InitializeComponent();
        }

        public NTVContainerForm(NTVContainerDoc ntvContainerDoc, VarianceContainerWorkMode workMode)
            : this()
        {
            this.NTVContainerDoc = ntvContainerDoc;
            this.UserID = ntvContainerDoc.UserID;
            this.WorkMode = workMode;
        }

        public NTVContainerForm(NTVContainerDoc ntvContainerDoc, VarianceContainerWorkMode workMode, long? PC_DocID)
            : this(ntvContainerDoc, workMode)
        {
            this.PC_DocID = PC_DocID;
        }

        private void NTVContainerForm_Load(object sender, EventArgs e)
        {
            SetInterfaceSettings();
            LoadNTVDetails();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            switch (this.WorkMode)
            {
                case VarianceContainerWorkMode.Preview:
                    tsMain.Visible = true;
                    btnDelete.Visible = true;
                    dgvItems.ReadOnly = true;
                    pnlFooter.Visible = false;
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";
                    break;
                //case VarianceContainerWorkMode.Init:
                //    tsMain.Visible = true;
                //    btnDelete.Visible = true;
                //    pnlFooter.Visible = true;
                //    lblVendorLotChange.Text = "F2 - выбор серии в позиции";
                //    btnOK.Text = "Подтвердить";
                //    btnOK.Width = 85;
                //    break;
                case VarianceContainerWorkMode.Confirm:
                    tsMain.Visible = true;

                    #region ДИНАМИЧЕСКИ ДОБАВЛЯЕМ ОКНО СКАНИРОВАНИЯ Ш/К

                    tsMain.Items.Add(new ToolStripSeparator());
                    tsMain.Items.Add(new ToolStripLabel("Отсканируйте ш/к\r\nтовара в контейнере: "));

                    var tbsItem = new TextBoxScaner();
                    tbsItem.TextChanged += delegate(object sender, EventArgs ea)
                    {
                        this.SelectItem(tbsItem.Text);

                        tbsItem.Text = string.Empty;
                        tbsItem.Focus();
                    };

                    var tsItemBarCodeScannerHost = new ToolStripControlHost(tbsItem);
                    tsItemBarCodeScannerHost.Width = 300;
                    tsMain.Items.Add(tsItemBarCodeScannerHost);

                    tsMain.Items.Add(new ToolStripButton("Добавить", Properties.Resources.Add_48, delegate(object sender, EventArgs ea) { this.SelectItem(); }));

                    #endregion

                    btnDelete.Visible = true;
                    pnlFooter.Visible = false;
                    //lblVendorLotChange.Text = "F2 - подтверждение позиции";
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";

                    tbsItem.Focus();

                    break;
                default:
                    throw new Exception("В указанном режиме работа с формой невозможна.");
                    break;
            }

            btnOK.Location = new Point(917, 8);
            btnCancel.Location = new Point(1007, 8);

            this.Text = string.Format("Контроль НТВ (документ № {0})", this.PC_DocID.HasValue ? this.PC_DocID : this.NTVContainerDoc.DocID);
            if (!this.NTVContainerDoc.IsRepeatControl)
                this.Text = string.Format("Контроль НТВ (контейнер № {0})", this.NTVContainerDoc.BarCode);
        }

        #endregion

        #region КОРРЕКТИРОВКА СТРОКИ ДОКУМЕНТА НТВ

        #region ВЫБОР СЕРИИ / КОЛИЧЕСТВА

        /// <summary>
        /// Выбор товара из справочника (ручной поиск)
        /// </summary>
        private void SelectItem()
        {
            try
            {
                var selectedItem = this.SelectItem(true, (string)null);
                this.ProcessItem(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Поиск товара по отсканированному ш/к
        /// </summary>
        /// <param name="itemBarCode"></param>
        private void SelectItem(string itemBarCode)
        {
            try
            {
                var selectedItem = this.SelectItem(false, itemBarCode);
                this.ProcessItem(selectedItem);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Интерфейс поиска товара
        /// </summary>
        /// <param name="useDynamicSearch"></param>
        /// <param name="itemBarCode"></param>
        /// <returns></returns>
        private Data.PickControl.ItemsRow SelectItem(bool useDynamicSearch, string itemBarCode)
        {
            try
            {
                Data.PickControl.ItemsDataTable items = null;

                // При статическом поиске готовим источник данных один раз
                if (!useDynamicSearch)
                {
                    var notRecalcUOMFlag = this.NTVContainerDoc.ApplyTestVersionChanges ? 1 : (int?)null;
                    var ignoreSurplusChecks = (int?)null;
                    using (var adapter = new Data.PickControlTableAdapters.ItemsTableAdapter())
                        items = adapter.GetData(this.NTVContainerDoc.PC_DocID, Convert.ToInt32(this.UserID), itemBarCode, notRecalcUOMFlag, ignoreSurplusChecks, this.NTVContainerDoc.ProcessVersionID);

                    if (items.Count == 0)
                        throw new Exception("Товар с указанным ш/к не найден.\r\nВоспользуйтесь возможностью ручного добавления товара.");

                    if (items.Count == 1)
                        return items[0];
                }

                var dlgSelectItem = new RichListForm();

                #region column Item

                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItem.DataPropertyName = "Item";
                colItem.HeaderText = "Наименование";
                colItem.Name = "colItem";
                colItem.ReadOnly = true;
                dlgSelectItem.Columns.Add(colItem);

                #endregion
                #region column Manufacturer

                DataGridViewTextBoxColumn colManuf = new DataGridViewTextBoxColumn();
                colManuf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colManuf.DataPropertyName = "Manufacturer";
                colManuf.HeaderText = "Производитель";
                colManuf.Name = "colManuf";
                colManuf.ReadOnly = true;
                dlgSelectItem.Columns.Add(colManuf);

                #endregion

                dlgSelectItem.Text = "Выбор товара";
                Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                dlgSelectItem.DataSource = table;
                dlgSelectItem.ColumnForFilters.Add("Item");
                dlgSelectItem.ColumnForFilters.Add("Manufacturer");

                // При динамическом поиске выполняем запрос каждый раз при смене фильтра
                if (useDynamicSearch)
                {
                    dlgSelectItem.FilterChanged += delegate(object sender, EventArgs e)
                    {
                        try
                        {
                            using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
                                items = adapter.GetDataAll(dlgSelectItem.Filter);

                            dlgSelectItem.DataSource = items;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                }
                else
                {
                    dlgSelectItem.FilterVisible = false;
                    dlgSelectItem.DataSource = items;
                }

                if (dlgSelectItem.ShowDialog() == DialogResult.OK)
                {
                    if (dlgSelectItem.SelectedRow != null)
                        return (Data.PickControl.ItemsRow)dlgSelectItem.SelectedRow;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Дальнейшая обработка найденного товара
        /// </summary>
        /// <param name="selectedItem"></param>
        private void ProcessItem(Data.PickControl.ItemsRow selectedItem)
        {
            if (selectedItem != null)
            {
                var detailRow = pickControl.NTVContainerDocDetails.NewNTVContainerDocDetailsRow();

                detailRow.line_id = -1;
                detailRow.item_id = Convert.ToInt32(selectedItem.Item_ID);
                detailRow.item_name = selectedItem.IsItemNull() ? (string)null : selectedItem.Item;
                detailRow.uom = selectedItem.IsUnitOfMeasureNull() ? (string)null : selectedItem.UnitOfMeasure;
                detailRow.Producer_Name = selectedItem.IsManufacturerNull() ? (string)null : selectedItem.Manufacturer;
                detailRow.vendor_lot = (string)null;
                detailRow.quantity = 0;

                this.SelectItemVendorLot(detailRow);
            }
        }

        private void SelectItemVendorLot(Data.PickControl.NTVContainerDocDetailsRow detailRow)
        {
            var detailEditRow = pickControl.NTVContainerDocDetails.NewNTVContainerDocDetailsRow();
            detailEditRow.ItemArray = detailRow.ItemArray;

            var vendorLot = (string)null;
            var needBossConfirm = false;
            var bossID = (int?)null;
            var quantity = 0;

            var needSelectItemVendorLot = true;
            var needSelectItemQuantity = true;

            do
            {
                try
                {
                    #region ВВОД СЕРИИ

                    if (needSelectItemVendorLot)
                    {
                        if (!this.SelectItemVendorLot(detailEditRow, ref vendorLot, ref needBossConfirm))
                            break;

                        detailEditRow.vendor_lot = vendorLot;

                        needSelectItemVendorLot = false;
                        needSelectItemQuantity = true;

                        needBossConfirm = this.WorkMode == VarianceContainerWorkMode.Init ? needBossConfirm : false;
                    }

                    #endregion

                    #region ВВОД КОЛИЧЕСТВА

                    if (needSelectItemQuantity)
                    {
                        if (!this.SelectItemQuantity(detailEditRow, ref quantity))
                        {
                            needSelectItemVendorLot = true;
                            continue;
                        }

                        detailEditRow.quantity = quantity;

                        needSelectItemQuantity = false;
                    }

                    #endregion

                    var applyOperation = false;

                    switch (this.WorkMode)
                    {
                        case VarianceContainerWorkMode.Confirm:
                            applyOperation = this.ConfirmDetail(detailEditRow);
                            break;
                        default:
                            break;
                    }

                    if (applyOperation)
                        this.LoadNTVDetails();
                }
                catch (Exception ex)
                {
                    var message = ex.Message;

                    if (message.Contains("#"))
                    {
                        var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Tag>\w+)#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                        if (regex.IsMatch(ex.Message))
                        {
                            var match = regex.Match(ex.Message);
                            message = match.Groups["Message"].Value;

                            var tag = match.Groups["Tag"].Value.ToUpper();
                            switch (tag)
                            {
                                case "VENDOR_LOT_ERROR":
                                    needSelectItemVendorLot = true;
                                    break;
                                case "QUANTITY_ERROR":
                                    needSelectItemQuantity = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            while (needSelectItemVendorLot || needSelectItemQuantity || needBossConfirm);
        }

        private bool SelectItemVendorLot(Data.PickControl.NTVContainerDocDetailsRow row, ref string vendorLot, ref bool needBossConfirm)
        {
            if (this.WorkMode == VarianceContainerWorkMode.Preview)
                return false;

            needBossConfirm = false;

            var itemID = row.item_id;
            var itemName = row.Isitem_nameNull() ? (string)null : row.item_name;
            var archiveMode = (int?)null;
            var surplusMode = (int?)null;

            Data.PickControl.VendorLotsDataTable vendorLots = null;

            try
            {
                using (var adapter = new Data.PickControlTableAdapters.VendorLotsTableAdapter())
                    vendorLots = adapter.GetData(this.NTVContainerDoc.PC_DocID, itemID, string.Empty, surplusMode, archiveMode, this.NTVContainerDoc.ProcessVersionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Серия определилась автоматически
            if (vendorLots.Count == 1)
            {
                vendorLot = vendorLots[0].Vendor_Lot;
                return true;
            }
            // Ручное определение серии 
            else
            {
                #region ПОДГОТОВКА СЕРИЙ К ОТОБРАЖЕНИЮ

                // удалим строки, которые не нужно отображать
                var lstRowsToRemove = new List<Data.PickControl.VendorLotsRow>();
                foreach (Data.PickControl.VendorLotsRow dr in vendorLots.Rows)
                    if (!dr.IsHideNull() && dr.Hide)
                        lstRowsToRemove.Add(dr);

                for (int i = 0; i < lstRowsToRemove.Count; i++)
                    vendorLots.Rows.Remove(lstRowsToRemove[i]);

                #endregion

                var dlgSearchVendorLot = new RichListForm() { Width = 600 };
                #region column Lotn
                DataGridViewTextBoxColumn colLot = new DataGridViewTextBoxColumn();
                colLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colLot.DataPropertyName = "Vendor_Lot";
                colLot.HeaderText = "Серия";
                colLot.Name = "colLot";
                colLot.ReadOnly = true;
                dlgSearchVendorLot.Columns.Add(colLot);
                #endregion
                #region column Date
                DataGridViewTextBoxColumn colDate = new DataGridViewTextBoxColumn();
                colDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colDate.DataPropertyName = "Exp_Date";
                colDate.HeaderText = "Срок годн.";
                colDate.Name = "colDate";
                colDate.ReadOnly = true;
                dlgSearchVendorLot.Columns.Add(colDate);
                #endregion
                #region column Collectors_remains
                DataGridViewTextBoxColumn colCollectorsRemains = new DataGridViewTextBoxColumn();
                colCollectorsRemains.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colCollectorsRemains.DataPropertyName = "Collectors_remains";
                colCollectorsRemains.HeaderText = "Остаток, уп.";
                colCollectorsRemains.Name = "colCollectorsRemains";
                colCollectorsRemains.ReadOnly = true;
                dlgSearchVendorLot.Columns.Add(colCollectorsRemains);
                #endregion

                dlgSearchVendorLot.ColumnForFilters.Add("Vendor_Lot");
                dlgSearchVendorLot.FilterChangeLevel = 2;

                if (!this.NTVContainerDoc.ApplyTestVersionChanges)
                {
                    #region ДИНАМИЧЕСКАЯ ФИЛЬТРАЦИЯ СЕРИЙ

                    dlgSearchVendorLot.FilterChanged += delegate(object sender, EventArgs e)
                    {
                        using (var adapter = new WMSOffice.Data.PickControlTableAdapters.VendorLotsTableAdapter())
                        {
                            try
                            {
                                Data.PickControl.VendorLotsDataTable table = adapter.GetData(this.NTVContainerDoc.PC_DocID, itemID, dlgSearchVendorLot.Filter, surplusMode, archiveMode, this.NTVContainerDoc.ProcessVersionID);
                                dlgSearchVendorLot.DataSource = table;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    };

                    #endregion
                }

                dlgSearchVendorLot.Text = "Выбор серии " + itemName;
                dlgSearchVendorLot.DataSource = vendorLots;

                if (dlgSearchVendorLot.ShowDialog() == DialogResult.OK)
                {
                    if (dlgSearchVendorLot.SelectedRow != null)
                    {
                        Data.PickControl.VendorLotsRow selectedVendorLot = (Data.PickControl.VendorLotsRow)dlgSearchVendorLot.SelectedRow;
                        vendorLot = selectedVendorLot.IsVendor_LotNull() ? (string)null : selectedVendorLot.Vendor_Lot;
                        return true;
                    }
                }
            }

            return false;
        }

        private bool SelectItemQuantity(Data.PickControl.NTVContainerDocDetailsRow row, ref int quantity)
        {
            if (this.WorkMode == VarianceContainerWorkMode.Preview)
                return false;

            var form = new SetCountForm();
            form.ItemID = row.item_id;
            form.ItemName = row.item_name;
            form.Lotn = row.vendor_lot;
            form.TotalCount = row.quantity;
            form.Count = 0;
            form.InputCountEnabled = true;
            form.ShowNote = false;
            form.MinCount = 1;
            form.CommitVersionChanges = this.NTVContainerDoc.ApplyTestVersionChanges;

            if (form.ShowDialog() == DialogResult.OK)
            {
                quantity = Math.Max(form.MinCount.Value, form.Count);
                return true;
            }

            return false;
        }

        #endregion

        private bool ConfirmDetail(Data.PickControl.NTVContainerDocDetailsRow row)
        {
            try
            {
                var itemID = row.Isitem_idNull() ? (int?)null : row.item_id;
                var unitOfMeasure = row.IsuomNull() ? (string)null : row.uom;
                var vendorLot = row.Isvendor_lotNull() ? (string)null : row.vendor_lot;
                var quantity = row.IsquantityNull() ? (int?)null : row.quantity;

                nTVContainerDocDetailsTableAdapter.ConfirmNTVContainerDocDetail(this.UserID, this.NTVContainerDoc.DocID, this.NTVContainerDoc.VarianceTypeID, itemID, unitOfMeasure, vendorLot, quantity, this.NTVContainerDoc.PC_DocID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ПОЛУЧЕНИЕ СТРОК ДОКУМЕНТА НТВ

        private void LoadNTVDetails()
        {
            try
            {
                var statusFrom = (string)null;
                var statusTo = (string)null;

                //switch (this.WorkMode)
                //{
                //    //case VarianceContainerWorkMode.Init:
                //    //    statusFrom = "100";
                //    //    statusTo = "110";
                //    //    break;
                //    case VarianceContainerWorkMode.Confirm:
                //        statusFrom = "120";
                //        statusTo = "130";
                //        break;
                //    case VarianceContainerWorkMode.Preview:
                //        statusFrom = "120";
                //        statusTo = "130";
                //        break;
                //    default:
                //        break;
                //}

                var docID = this.NTVContainerDoc.IsRepeatControl ? this.NTVContainerDoc.DocID : (int?)null;
                nTVContainerDocDetailsTableAdapter.Fill(pickControl.NTVContainerDocDetails, this.UserID, docID, this.PC_DocID, statusFrom, statusTo, this.NTVContainerDoc.BarCode);

                // Снимаем выделение с первой строки
                if (dgvItems.Rows.Count > 0)
                    dgvItems.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ПОЛУЧЕНИЕ СБОРЩИКОВ

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                var docLine = (row.DataBoundItem as DataRowView).Row as Data.PickControl.NTVContainerDocDetailsRow;

                if (dgvbcCollectors.Visible)
                    ((DataGridViewDisableButtonCell)row.Cells[dgvbcCollectors.Name]).ButtonVisible = !docLine.Isitem_idNull() && !docLine.IsRelatedPickSlipNumberNull();

                var statusID = docLine.Isstatus_idNull() ? (string)null : docLine.status_id;
                if (!string.IsNullOrEmpty(statusID))
                {
                    var color = Color.Empty;
                    switch (statusID)
                    {
                        case "100":
                            color = Color.LightGray;
                            break;
                        case "110":
                            color = Color.Khaki;
                            break;
                        case "120":
                            color = Color.LightBlue;
                            break;
                        case "130":
                            color = Color.LightGreen;
                            break;
                        case "198":
                            color = Color.Salmon;
                            break;
                        default:
                            break;
                    }

                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = color;
                        cell.Style.SelectionForeColor = color;
                    }
                }
            }
        }

        private void dgvItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvItems.Columns[e.ColumnIndex].Name == dgvbcCollectors.Name)
            {
                if (((DataGridViewDisableButtonCell)dgvItems[e.ColumnIndex, e.RowIndex]).ButtonVisible)
                {
                    try
                    {
                        var docLine = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.NTVContainerDocDetailsRow;

                        pickControl.PickSlipItemCollectors.Clear();
                        using (var adapter = new Data.PickControlTableAdapters.PickSlipItemCollectorsTableAdapter())
                            adapter.Fill(pickControl.PickSlipItemCollectors, this.UserID, Convert.ToInt32(docLine.RelatedPickSlipNumber), docLine.item_id);

                        if (pickControl.PickSlipItemCollectors.Rows.Count > 0)
                        {
                            var dlgCollectors = new WMSOffice.Dialogs.RichListForm() { Width = 700 };
                            dlgCollectors.Text = string.Format("Список сборщиков по товару ({0}) {1}", docLine.item_id, docLine.item_name);
                            dlgCollectors.AddColumn("employee", "employee", "Ф.И.О. сотрудника");
                            dlgCollectors.AddColumn("location_id", "location_id", "Место сборки");
                            dlgCollectors.ColumnForFilters = new List<string>(new string[] { "employee", "location_id" });
                            dlgCollectors.FilterChangeLevel = 0;

                            pickControl.PickSlipItemCollectors.DefaultView.RowFilter = string.Empty;
                            dlgCollectors.DataSource = pickControl.PickSlipItemCollectors;
                            dlgCollectors.SetDictionaryViewMode();
                            dlgCollectors.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show(string.Format("Список сборщиков по товару ({0}) {1} не найден.", docLine.item_id, docLine.item_name), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    catch
                    {

                    }
                }
            }
        }

        #endregion

        #region УДАЛЕНИЕ СТРОКИ ДОКУМЕНТА НТВ

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DeleteDetail(this.SelectedDetailRow))
                    this.LoadNTVDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DeleteDetail(Data.PickControl.NTVContainerDocDetailsRow row)
        {
            try
            {
                var lineID = row.line_id;
                nTVContainerDocDetailsTableAdapter.CancelNTVContainerDocDetail(this.UserID, this.NTVContainerDoc.DocID, lineID);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            SetInterfaceSettings();
        }

        private void SetInterfaceSettings()
        {
            var isEnabled = this.SelectedDetailRow != null && this.SelectedDetailRow.status_id != "198";

            btnDelete.Enabled = isEnabled;
        }
    }
}
