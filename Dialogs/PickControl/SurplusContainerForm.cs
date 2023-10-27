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
    public partial class SurplusContainerForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        public new long UserID { get; set; }

        public SurplusContainerDoc SurplusContainerDoc { get; private set; }

        public VarianceContainerWorkMode WorkMode { get; private set; }

        public long? PC_DocID { get; private set; }

        public Data.PickControl.SurplusContainerDocDetailsRow SelectedDetailRow
        {
            get { return dgvItems.SelectedRows.Count == 0 ? null : (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.SurplusContainerDocDetailsRow; }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        protected SurplusContainerForm()
        {
            InitializeComponent();
        }

        public SurplusContainerForm(SurplusContainerDoc surplusContainerDoc, VarianceContainerWorkMode workMode)
            : this()
        {
            this.SurplusContainerDoc = surplusContainerDoc;
            this.UserID = surplusContainerDoc.UserID;
            this.WorkMode = workMode;
        }

        public SurplusContainerForm(SurplusContainerDoc surplusContainerDoc, VarianceContainerWorkMode workMode, long? PC_DocID)
            : this(surplusContainerDoc, workMode)
        {
            this.PC_DocID = PC_DocID;
        }

        private void SurplusContainerForm_Load(object sender, EventArgs e)
        {
            SetInterfaceSettings();
            LoadSurplusDetails();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            switch (this.WorkMode)
            { 
                case VarianceContainerWorkMode.Preview:
                    tsMain.Visible = true;
                    btnSplit.Visible = false;
                    btnDelete.Visible = true;
                    sepCloseContainer.Visible = false;
                    btnCloseContainer.Visible = false;
                    dgvItems.ReadOnly = true;
                    pnlFooter.Visible = false;
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";
                    break;
                case VarianceContainerWorkMode.Init:
                    tsMain.Visible = true;
                    btnSplit.Visible = true;
                    btnDelete.Visible = true;
                    sepCloseContainer.Visible = false;
                    btnCloseContainer.Visible = false;
                    pnlFooter.Visible = true;
                    lblVendorLotChange.Text = "F2 - выбор серии в позиции";
                    btnOK.Text = "Подтвердить";
                    btnOK.Width = 85;
                    break;
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

                    btnSplit.Visible = false;
                    btnDelete.Visible = true;
                    sepCloseContainer.Visible = false;
                    btnCloseContainer.Visible = false;
                    pnlFooter.Visible = false;
                    //lblVendorLotChange.Text = "F2 - подтверждение позиции";
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";

                    tbsItem.Focus();

                    break;
                case VarianceContainerWorkMode.PreviewForClose:
                    tsMain.Visible = true;
                    btnSplit.Visible = false;
                    btnDelete.Visible = false;
                    sepCloseContainer.Visible = false;
                    btnCloseContainer.Visible = true;
                    dgvItems.ReadOnly = true;
                    pnlFooter.Visible = false;
                    this.btnOK.Visible = false;
                    this.btnCancel.Text = "Закрыть";
                    break;
                default:
                    throw new Exception("В указанном режиме работа с формой невозможна.");
                    break;
            }
            
            btnOK.Location = new Point(917, 8);
            btnCancel.Location = new Point(1007, 8);

            this.Text = string.Format("Контроль излишка (документ № {0})", this.PC_DocID.HasValue ? this.PC_DocID : this.SurplusContainerDoc.DocID);
            if (!this.SurplusContainerDoc.IsRepeatControl)
                this.Text = string.Format("Контроль излишка (контейнер № {0})", this.SurplusContainerDoc.BarCode);
        }

        public void Initialize(int itemID, string unitOfMeasure, int surplusQuantity, int expectedQuantity, string expectedVendorLot, int expectedSurplusQuantity)
        {
            this.AddDetail(itemID, unitOfMeasure, surplusQuantity, expectedQuantity, expectedVendorLot, expectedSurplusQuantity);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F2)
            {
                if (this.WorkMode == VarianceContainerWorkMode.Init)
                {
                    if (dgvItems.SelectedRows.Count > 0)
                    {
                        var docRow = (dgvItems.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.SurplusContainerDocDetailsRow;
                        if (docRow.status_id != "198")
                            this.SelectItemVendorLot(docRow);
                        return true;
                    }
                }
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region ПОЛУЧЕНИЕ СТРОК ДОКУМЕНТА ИЗЛИШКОВ

        private void LoadSurplusDetails()
        {
            try
            {
                var statusFrom = (string)null;
                var statusTo = (string)null;

                //switch (this.WorkMode)
                //{ 
                //    case VarianceContainerWorkMode.Init:
                //        statusFrom = "100";
                //        statusTo = "110";
                //        break;
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

                var docID = this.SurplusContainerDoc.IsRepeatControl ? this.SurplusContainerDoc.DocID : (int?)null;
                surplusContainerDocDetailsTableAdapter.Fill(pickControl.SurplusContainerDocDetails, this.UserID, docID, this.PC_DocID, statusFrom, statusTo, this.SurplusContainerDoc.BarCode);

                // Снимаем выделение с первой строки (кроме режима инициализации)
                if (dgvItems.Rows.Count > 0 && this.WorkMode != VarianceContainerWorkMode.Init)
                    dgvItems.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ СТРОКИ ДОКУМЕНТА ИЗЛИШКОВ

        private void btnSplit_Click(object sender, EventArgs e)
        {
            this.AddDetail(this.SelectedDetailRow);
        }

        private void AddDetail(Data.PickControl.SurplusContainerDocDetailsRow row)
        {
            int itemID = row.item_id;
            string unitOfMeasure = row.IsuomNull() ? (string)null : row.uom;

            int expectedQuantity = row.IsQTY_needNull() ? 0 : row.QTY_need;
            string expectedVendorLot = row.IsVendor_Lot_NeedNull() ? (string)null : row.Vendor_Lot_Need;
            int expectedSurplusQuantity = row.IsQty_Surplus_PlanNull() ? 0 : row.Qty_Surplus_Plan;

            if (this.AddDetail(itemID, unitOfMeasure, 0, expectedQuantity, expectedVendorLot, expectedSurplusQuantity))
                this.LoadSurplusDetails();
        }

        private bool AddDetail(int itemID, string unitOfMeasure, int surplusQuantity, int expectedQuantity, string expectedVendorLot, int expectedSurplusQuantity)
        {
            try
            {
                surplusContainerDocDetailsTableAdapter.AddSurplusContainerDocDetail(this.UserID, this.SurplusContainerDoc.UserLogin, this.SurplusContainerDoc.DocID, itemID, unitOfMeasure, this.SurplusContainerDoc.PC_DocID, expectedQuantity, expectedVendorLot, expectedSurplusQuantity);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region КОРРЕКТИРОВКА СТРОКИ ДОКУМЕНТА ИЗЛИШКОВ

        #region ВЫБОР СЕРИИ / КОЛИЧЕСТВА

        private void dgvItems_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (this.WorkMode == VarianceContainerWorkMode.Init)
            {
                var docRow = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.SurplusContainerDocDetailsRow;
                this.SelectItemVendorLot(docRow);
            }
        }

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
                    var notRecalcUOMFlag = this.SurplusContainerDoc.ApplyTestVersionChanges ? 1 : (int?)null;
                    var ignoreSurplusChecks = 1;
                    using (var adapter = new Data.PickControlTableAdapters.ItemsTableAdapter())
                        items = adapter.GetData(this.SurplusContainerDoc.PC_DocID, Convert.ToInt32(this.UserID), itemBarCode, notRecalcUOMFlag, ignoreSurplusChecks, this.SurplusContainerDoc.ProcessVersionID);

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
                var detailRow = pickControl.SurplusContainerDocDetails.NewSurplusContainerDocDetailsRow();

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

        private void SelectItemVendorLot(Data.PickControl.SurplusContainerDocDetailsRow detailRow)
        {
            var status_id = detailRow.Isstatus_idNull() ? string.Empty : detailRow.status_id;
            if (this.WorkMode == VarianceContainerWorkMode.Init && status_id != "100")
                return;

            var detailEditRow = pickControl.SurplusContainerDocDetails.NewSurplusContainerDocDetailsRow();
            detailEditRow.ItemArray = detailRow.ItemArray;

            var vendorLot = (string)null;
            var needBossConfirm = false;
            var bossVendorLotConfirm = (int?)null;
            var bossQuantityConfirm = (int?)null;
            var quantity = 0;
            var containerBarCode = (string)null;

            var needSelectItemVendorLot = true;
            var needSelectItemQuantity = true;
            var needSelectSurplusContainer = true;

            var needBossQuantityConfirm = false;

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
                        needSelectSurplusContainer = this.WorkMode == VarianceContainerWorkMode.Init;
                    }

                    #endregion

                    #region ТРЕБУЕТСЯ ПОДТВЕРЖДЕНИЕ СЕРИИ РУКОВОДИТЕЛЕМ

                    if (needBossConfirm)
                    {
                        if (!this.ConfirmBoss(BossConfirmMode.VendorLotConfirm, ref bossVendorLotConfirm))
                        {
                            needSelectItemVendorLot = true;
                            continue;
                        }

                        needBossConfirm = false;
                    }

                    #endregion

                    #region ПОДТВЕРЖДЕНИЕ КОНТЕЙНЕРА

                    if (needSelectSurplusContainer)
                    {
                        if (!this.ObtainSurplusContainerBarCode(detailEditRow, ref containerBarCode))
                            break;

                        needSelectSurplusContainer = false;
                    }

                    #endregion

                    #region ТРЕБУЕТСЯ ПОДТВЕРЖДЕНИЕ КОЛИЧЕСТВА РУКОВОДИТЕЛЕМ

                    if (needBossQuantityConfirm)
                    {
                        if (!this.ConfirmBoss(BossConfirmMode.QuantityConfirm, ref bossQuantityConfirm))
                        {
                            needSelectItemQuantity= true;
                            needBossQuantityConfirm = false;
                            continue;
                        }

                        needBossQuantityConfirm = false;
                    }

                    #endregion

                    var applyOperation = false;

                    switch (this.WorkMode)
                    { 
                        case VarianceContainerWorkMode.Init:
                            applyOperation = this.EditDetail(detailEditRow, containerBarCode, bossVendorLotConfirm, bossQuantityConfirm);
                            break;
                        case VarianceContainerWorkMode.Confirm:
                            applyOperation = this.ConfirmDetail(detailEditRow);
                            break;
                        default:
                            break;
                    }

                    if (applyOperation)
                        this.LoadSurplusDetails();
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
                                case "CONTAINER_ERROR":
                                    needSelectSurplusContainer = true;
                                    break;
                                case "SURPLUS_ERROR":
                                    needBossQuantityConfirm = true;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            while (needSelectItemVendorLot || needSelectItemQuantity || needSelectSurplusContainer || needBossConfirm || needBossQuantityConfirm);
        }

        private bool SelectItemVendorLot(Data.PickControl.SurplusContainerDocDetailsRow row, ref string vendorLot, ref bool needBossVendorLotConfirm)
        {
            if (this.WorkMode == VarianceContainerWorkMode.Preview || this.WorkMode == VarianceContainerWorkMode.PreviewForClose)
                return false;

            var itemID = row.item_id;
            var itemName = row.Isitem_nameNull() ? (string)null : row.item_name;
            var surplusMode = 1;

            using (var dlgSearchVendorLot = new SearchVendorLotForm(this.SurplusContainerDoc.PC_DocID, itemID, itemName, surplusMode, this.SurplusContainerDoc.ProcessVersionID))
            {
                if (dlgSearchVendorLot.ShowDialog() == DialogResult.OK)
                {
                    var selectedVendorLot = dlgSearchVendorLot.SelectedVendorLot;
                    vendorLot = selectedVendorLot.IsVendor_LotNull() ? (string)null : selectedVendorLot.Vendor_Lot;
                    needBossVendorLotConfirm = selectedVendorLot.IsNeedBossConfirmNull() ? false : Convert.ToBoolean(selectedVendorLot.NeedBossConfirm);
                    return true;
                }
            }

            return false;
        }

        private bool SelectItemQuantity(Data.PickControl.SurplusContainerDocDetailsRow row, ref int quantity)
        {
            if (this.WorkMode == VarianceContainerWorkMode.Preview || this.WorkMode == VarianceContainerWorkMode.PreviewForClose)
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
            form.CommitVersionChanges = this.SurplusContainerDoc.ApplyTestVersionChanges;

            if (form.ShowDialog() == DialogResult.OK)
            {
                quantity = Math.Max(form.MinCount.Value, form.Count);
                return true;
            }

            return false;
        }

        private bool ConfirmBoss(BossConfirmMode mode, ref int? bossID)
        {
            bossID = (int?)null;
            var dlgBossScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
            {
                Label = "Отсканируйте бэйдж руководителя,\r\nкоторый отвечает за мониторинг контроля",
                Text = mode == BossConfirmMode.VendorLotConfirm ? "Подтверждение отсутствующей серии" : mode == BossConfirmMode.QuantityConfirm ? "Подтверждение количества" : mode == BossConfirmMode.CancelConfirm ? "Подтверждение отмены" : string.Empty,
                Image = Properties.Resources.role,
                //OnlyNumbersInBarcode = true
                UseScanModeOnly = true
            };

            if (dlgBossScanner.ShowDialog() != DialogResult.OK)
                return false;

            bossID = Convert.ToInt32(dlgBossScanner.Barcode);

            var result = (int?)null;
            using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                adapter.CheckBoss(this.UserID, this.SurplusContainerDoc.PC_DocID, bossID, ref result);

            if (result.HasValue && Convert.ToBoolean(result.Value))
                return true;
            else
                throw new Exception("Пользователь не имеет права\r\nподтверждения.");
        }

        private bool ObtainSurplusContainerBarCode(Data.PickControl.SurplusContainerDocDetailsRow row, ref string containerBarCode)
        {
            containerBarCode = this.SurplusContainerDoc.ScanContainer("Отсканируйте контейнер излишков,\r\nс которым ведется работа", "Подтверждение контейнера излишков");
            return !string.IsNullOrEmpty(containerBarCode);
        }

        #endregion

        private bool EditDetail(Data.PickControl.SurplusContainerDocDetailsRow row, string containerBarCode, int? bossVendorLotConfirm, int? bossQuantityConfirm)
        {
            try
            {
                var lineID = row.line_id;
                var quantity = row.IsquantityNull() ? (int?)null : row.quantity;
                var vendorLot = row.Isvendor_lotNull() ? (string)null : row.vendor_lot;

                surplusContainerDocDetailsTableAdapter.EditSurplusContainerDocDetail(this.UserID, this.SurplusContainerDoc.DocID, lineID, quantity, vendorLot, containerBarCode, bossVendorLotConfirm, bossQuantityConfirm);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool ConfirmDetail(Data.PickControl.SurplusContainerDocDetailsRow row)
        {
            try
            {
                var itemID = row.Isitem_idNull() ? (int?)null : row.item_id;
                var unitOfMeasure = row.IsuomNull() ? (string)null : row.uom;
                var vendorLot = row.Isvendor_lotNull() ? (string)null : row.vendor_lot;
                var quantity = row.IsquantityNull() ? (int?)null : row.quantity;

                surplusContainerDocDetailsTableAdapter.ConfirmSurplusContainerDocDetail(this.UserID, this.SurplusContainerDoc.DocID, this.SurplusContainerDoc.VarianceTypeID, itemID, unitOfMeasure, vendorLot, quantity, this.SurplusContainerDoc.PC_DocID);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region УДАЛЕНИЕ СТРОКИ ДОКУМЕНТА ИЗЛИШКОВ

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var bossID = (int?)null;
                if (!this.ConfirmBoss(BossConfirmMode.CancelConfirm, ref bossID))
                    throw new Exception("Для удаления строки необходимо отсканировать бэйдж руководителя."); 

                if (this.DeleteDetail(this.SelectedDetailRow))
                    this.LoadSurplusDetails();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool DeleteDetail(Data.PickControl.SurplusContainerDocDetailsRow row)
        {
            try
            {
                var lineID = row.line_id;
                surplusContainerDocDetailsTableAdapter.CancelSurplusContainerDocDetail(this.UserID, this.SurplusContainerDoc.DocID, lineID);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region ПОЛУЧЕНИЕ СБОРЩИКОВ

        private void dgvItems_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                var docLine = (row.DataBoundItem as DataRowView).Row as Data.PickControl.SurplusContainerDocDetailsRow;

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
                        var docLine = (dgvItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.PickControl.SurplusContainerDocDetailsRow;

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

        #region ФИКСАЦИЯ ИЗМЕНЕНИЙ

        private void SurplusContainerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                e.Cancel = !this.ConfirmChanges();
            }
            else
            {
                if (this.WorkMode == VarianceContainerWorkMode.Init)
                    e.Cancel = !this.CancelChanges();
            }
        }

        private bool ConfirmChanges()
        {
            try
            {
                using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                    adapter.ConfirmSurplusContainerDocDetails(this.UserID, this.SurplusContainerDoc.DocID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CancelChanges()
        {
            try
            {
                var bossID = (int?)null;
                if (!this.ConfirmBoss(BossConfirmMode.CancelConfirm, ref bossID))
                    throw new Exception("Для отмены необходимо отсканировать бэйдж руководителя."); 

                using (var adapter = new Data.PickControlTableAdapters.SurplusContainerDocsTableAdapter())
                    adapter.CancelSurplusContainerDocDetails(this.UserID, this.SurplusContainerDoc.DocID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        #region ЗАКРЫТИЕ КОНТЕЙНЕРА

        private void btnCloseContainer_Click(object sender, EventArgs e)
        {
            try
            {
                var isClosed = this.SurplusContainerDoc.CloseDirectly();

                // Контейнер закрыт -> закрываем окно
                if (isClosed)
                    this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            btnSplit.Enabled = isEnabled;
            btnDelete.Enabled = isEnabled;

            if (!this.SurplusContainerDoc.IsRepeatControl)
                btnDelete.Enabled = false;
        }

        enum BossConfirmMode
        {
            /// <summary>
            /// Подтверждение серии
            /// </summary>
            VendorLotConfirm,

            /// <summary>
            /// Подтверждение количества
            /// </summary>
            QuantityConfirm,

            /// <summary>
            /// Подтверждение отмены
            /// </summary>
            CancelConfirm
        }
    }
}
