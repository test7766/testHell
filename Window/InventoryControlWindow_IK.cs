using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Containers;

namespace WMSOffice.Window
{
    public partial class InventoryControlWindow_IK : GeneralWindow
    {
        /// <summary>
        /// Тип документа инвентаризации
        /// </summary>
        public const string INVENTORY_DOC_TYPE = "IK";

        #region Fields

        private int lastItemID = 0;
        private string lastItemName = string.Empty;
        private string lastVendorLotID = string.Empty;
        private string lastUOM = string.Empty;
        private string lastBarCode = string.Empty;
        private int lastCount = 0;
        private int lastCountNTV = 0;
        private int? lastLineID = (int?)null;

        #endregion

        #region Properties

        /// <summary>
        /// Признак, показывающий, доступна ли отмена последнего действия (и заодно - было ли последнее действие)
        /// </summary>
        private bool UndoEnabled { get { return btnUndo.Enabled; } set { btnUndo.Enabled = miUndo.Enabled = value; } }

        #endregion

        public InventoryControlWindow_IK()
        {
            InitializeComponent();
            tbBarcode.TextChanged += new EventHandler(tbBarcode_TextChanged);
        }

        private void InventoryControlWindow_IK_Load(object sender, EventArgs e)
        {
            this.ReloadData();
        }


        /// <summary>
        /// Полная перечитка данных
        /// </summary>
        private void ReloadData()
        {
            UndoEnabled = false;

            try
            {
                using (Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter hAdapter = new WMSOffice.Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter())
                {
                    hAdapter.Fill(inventory.IV_CS_Header, DocID, "", UserID);
                    if (inventory.IV_CS_Header != null && inventory.IV_CS_Header.Count == 1)
                    {
                        Data.Inventory.IV_CS_HeaderRow hRow = inventory.IV_CS_Header[0];
                        lblInventoryID.Text = hRow.Inv_Doc_ID.ToString();
                        lblCountSheetID.Text = hRow.Doc_ID.ToString();
                        lblCountSheetDate.Text = hRow.Doc_Date.ToShortDateString();
                        lblLocation.Text = hRow.Location;

                        //lblRecalcID.Text = hRow.Calc_ID.ToString();// +" (" + this.GetEnumDescription(this.currentCountSheetCategory) + ")";

                        this.DocID = hRow.Doc_ID;
                    }
                    else throw new ArgumentException("Не удалось получить заголовок Счетного листа");
                }

                tbBarcode.Focus();
                RefreshLines();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Обновляет список строк, уже введенных в счетный лист, загружая их из БД
        /// </summary>
        private void RefreshLines()
        {
            iVCSRowsBindingSource.Filter = "";
            iVCSRowsBindingSource.Sort = "";
            iV_CS_RowsTableAdapter.ClearBeforeFill = true;
            inventory.IV_CS_Rows.Clear();
            iV_CS_RowsTableAdapter.Fill(inventory.IV_CS_Rows, DocID);
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;
            SelectLastRow();
        }

        void tbBarcode_TextChanged(object sender, EventArgs e)
        {

            //if (String.IsNullOrEmpty(tbBarcode.Text))
            //{
            //    #region Анализ пустого ш/к

            //    // ввод количества по ENTER'у для товара, который был введен ранее
            //    if (UndoEnabled)
            //    {
            //        SelectLastRow();
            //        using (Dialogs.PickControl.SetCountForm form = new Dialogs.PickControl.SetCountForm()
            //        {
            //            ItemID = lastItemID,
            //            ItemName = lastItemName,
            //            Lotn = lastVendorLotID,
            //            TotalCount = (int)((Data.Inventory.IV_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).Quantity - lastCount,
            //            Count = lastCount,
            //            InputCountEnabled = true
            //        })
            //        {
            //            if (form.ShowDialog() == DialogResult.OK)
            //            {
            //                int old = lastCountNTV;
            //                int cnt = form.Count;
            //                if (cnt < 0)
            //                    MessageBox.Show("Невозможно установить отрицательное значение!");
            //                //else if (cnt < lastCountNTV)
            //                //    MessageBox.Show("Невозможно установить значение общего количества товара меньше, чем количество товара НТВ!");
            //                else
            //                {
            //                    if (cnt != lastCount)
            //                    {
            //                        lastCount = cnt - lastCount;
            //                        lastCountNTV = 0;
            //                        AddRow();
            //                    }
            //                    lastCount = cnt;
            //                    lastCountNTV = old;
            //                }
            //            }
            //        }
            //    }

            //    #endregion
            //}

            //else
            using (Data.InventoryTableAdapters.IV_ItemsTableAdapter adapter = new Data.InventoryTableAdapters.IV_ItemsTableAdapter())
            {
                try
                {
                    Data.Inventory.IV_ItemsDataTable table = adapter.GetDataByBarcode(DocID, UserID, tbBarcode.Text);
                    if (table == null || table.Count < 1)
                    {
                        throw new Exception("Товар не найден! Воспользуйтесь поиском (Ctrl+F) для добавления товара без штрих кода.");
                    }
                    else if (table.Count == 1)
                    {
                        // только один товар нашли, добавляем
                        Data.Inventory.IV_ItemsRow itemsRow = table[0];
                        lastBarCode = tbBarcode.Text;
                        lastItemID = (int)itemsRow.Item_ID;
                        lastItemName = itemsRow.Item;
                        lastUOM = itemsRow.UnitOfMeasure;
                        //lastVendorLotID = itemsRow.Vendor_Lot;
                        lastCount = (int)itemsRow.Qty;
                        lastCountNTV = 0;
                        lastLineID = (int?)null;

                        //// При повторном и завершающем пересчете добавляем товар с контролем серии
                        //if (this.currentCountSheetCategory == InventoryCountSheetCategory.Repeat ||
                        //    this.currentCountSheetCategory == InventoryCountSheetCategory.Final)
                        //{
                        if (!itemsRow.IsVendor_LotNull() && !String.IsNullOrEmpty(itemsRow.Vendor_Lot))
                        {
                            // отсканировали уникальный штрих код ящика! Знаем даже серию!
                            lastVendorLotID = itemsRow.Vendor_Lot;
                            AddRow();
                        }
                        else
                        {
                            // отсканировали простой товар, идентифицировали, выбираем серию
                            ChooseSeries();
                        }
                        //}
                        //else
                        //    // При первичном пересчете добавляем товар без контроля серии
                        //    if (this.currentCountSheetCategory == InventoryCountSheetCategory.Primary)
                        //    {
                        //        this.AddRow();
                        //    }

                        //AddRow();
                    }
                    else
                    {
                        // нашли несколько товаров, нужно выбрать наш
                        ChooseItems(table);
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
            tbBarcode.Text = "";
        }

        /// <summary>
        /// Метод выбора серии (если серий больше 1)
        /// </summary>
        private void ChooseSeries()
        {
            // получаем серии
            using (Data.InventoryTableAdapters.IV_Vendor_LotsTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.IV_Vendor_LotsTableAdapter())
            {
                try
                {
                    Data.Inventory.IV_Vendor_LotsDataTable table = adapter.GetData(DocID, lastItemID);

                    if (table == null || table.Count < 1) throw new Exception("Серии не найдены! Это исключительная ситуация. Обратитесь в Группу сопровождения ПО.");
                    else if (table.Count == 1)
                    {
                        if (table[0].Vendor_Lot == "NOSER")
                        {
                            // контроль серий отключен
                            lastVendorLotID = table[0].Vendor_Lot;
                            AddRow();
                        }
                        else
                            // серию необходимо ввести руками
                            SetSeria();
                    }
                    else
                    {
                        // есть несколько серий, предлагаем пользователю выбрать
                        ChooseSeries(table);
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        RichListForm formSeries = null;

        /// <summary>
        /// Выбор серии
        /// </summary>
        /// <param name="dataTable"></param>
        private void ChooseSeries(object dataTable)
        {
            if (dataTable != null && dataTable is DataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                if (formSeries == null)
                {
                    formSeries = new RichListForm();
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

                    formSeries.FilterVisible = false;
                }
                formSeries.Text = "Выбор серии " + lastItemName;
                formSeries.DataSource = dataTable;

                if (formSeries.ShowDialog() == DialogResult.OK)
                {
                    if (formSeries.SelectedRow != null)
                    {
                        Data.Inventory.IV_Vendor_LotsRow row = (Data.Inventory.IV_Vendor_LotsRow)formSeries.SelectedRow;
                        if (row.Vendor_Lot == "Ввести серию вручную...") SetSeria();
                        else
                        {
                            lastVendorLotID = row.Vendor_Lot;
                            AddRow();
                        }
                    }
                    else UndoEnabled = false;
                }
                else UndoEnabled = false;
            }
            else UndoEnabled = false;
        }

        /// <summary>
        /// Присвоение серии
        /// </summary>
        private void SetSeria()
        {
            using (Dialogs.RichListForm formLots = new Dialogs.RichListForm() { AllowSearchByEmptyFilter = true, FilterChangeLevel = 1 })
            {
                #region column LotNumber
                DataGridViewTextBoxColumn colItem = new DataGridViewTextBoxColumn();
                colItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItem.DataPropertyName = "LotNumber";
                colItem.HeaderText = "Серия";
                colItem.Name = "colLotNumber";
                colItem.ReadOnly = true;
                formLots.Columns.Add(colItem);
                #endregion

                formLots.Text = "Присвоение серии " + lastItemName;
                Data.Inventory.LotsByPatternDataTable table = new WMSOffice.Data.Inventory.LotsByPatternDataTable();

                this.RefreshLotsSource(formLots, null);
                //formLots.DataSource = table;

                formLots.ColumnForFilters.Add("LotNumber");
                formLots.FilterChanged += delegate(object sender, EventArgs e)
                {
                    this.RefreshLotsSource((Dialogs.RichListForm)sender, ((Dialogs.RichListForm)sender).Filter);
                };

                if (formLots.ShowDialog() == DialogResult.OK)
                {
                    lastVendorLotID = ((Data.Inventory.LotsByPatternRow)formLots.SelectedRow).LotNumber;
                    AddRow();
                }
                else
                {
                    UndoEnabled = false;
                }
            }

            #region Obsolete (старый подход)
            //WMSOffice.Dialogs.PickControl.SetVendorLotnForm form = new WMSOffice.Dialogs.PickControl.SetVendorLotnForm();
            //form.Text = "Присвоение серии " + lastItemName;
            //if (form.ShowDialog() == DialogResult.OK)
            //{
            //    lastVendorLotID = form.Lotn;
            //    AddRow();
            //}
            //else
            //{
            //    UndoEnabled = false;
            //}
            #endregion
        }

        /// <summary>
        /// Обновление источника данных для справочника серий
        /// </summary>
        /// <param name="form"></param>
        /// <param name="lotPattern"></param>
        private void RefreshLotsSource(RichListForm form, string lotPattern)
        {
            try
            {
                using (Data.InventoryTableAdapters.LotsByPatternTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.LotsByPatternTableAdapter())
                    form.DataSource = adapter.GetData(lastItemID, lotPattern);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Добавляет новую строку в БД
        /// </summary>
        private void AddRow()
        {
            try
            {
                UndoEnabled = false;
                iV_CS_RowsTableAdapter.AddRow(DocID, lastItemID, lastVendorLotID, lastUOM, lastCount, lastCountNTV, lastBarCode, lastLineID);
                UndoEnabled = true;
                RefreshLines();
                tbBarcode.Focus();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Показывает диалог с выбором препарата из нескольких по одному штрих-коду
        /// </summary>
        private void ChooseItems(object dataTable)
        {
            if (dataTable != null && dataTable is Data.Inventory.IV_ItemsDataTable && ((DataTable)dataTable).Rows.Count > 1)
            {
                using (Dialogs.RichListForm formItm = new Dialogs.RichListForm())
                {
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

                    formItm.Text = "Выбор препарата";
                    formItm.FilterVisible = false;
                    formItm.DataSource = dataTable;

                    if (formItm.ShowDialog() == DialogResult.OK && formItm.SelectedRow != null)
                    {
                        Data.Inventory.IV_ItemsRow row = (Data.Inventory.IV_ItemsRow)formItm.SelectedRow;

                        lastBarCode = tbBarcode.Text;
                        lastItemID = (int)row.Item_ID;
                        lastItemName = row.Item;
                        lastUOM = row.UnitOfMeasure;
                        lastVendorLotID = row.Vendor_Lot;
                        lastCount = 1;

                        //if (this.currentCountSheetCategory == InventoryCountSheetCategory.Repeat ||
                        //    this.currentCountSheetCategory == InventoryCountSheetCategory.Final)
                        //{
                        if (string.IsNullOrEmpty(lastVendorLotID))
                            SetSeria();
                        else
                            AddRow();
                        //}

                        //else
                        //    AddRow();
                    }
                    else
                    {
                        UndoEnabled = false;
                    }
                }
            }
        }

        private void SelectLastRow()
        {
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Inventory.IV_CS_RowsRow diffRow = (Data.Inventory.IV_CS_RowsRow)((DataRowView)row.DataBoundItem).Row;
                if (diffRow.Item_ID == lastItemID && diffRow.VendorLot == lastVendorLotID)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        /// <summary>
        /// Отмена последнего действия
        /// </summary>
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled && MessageBox.Show("Отменить данные по последнему введенному товару?",
               "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                iV_CS_RowsTableAdapter.CancelRow(DocID, lastItemID, lastVendorLotID, lastUOM, lastCount, lastCountNTV, lastBarCode);
                UndoEnabled = false;
                RefreshLines();
            }
        }

        /// <summary>
        /// Добавить товар без штрих-кода
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            using (Dialogs.RichListForm formItems = new Dialogs.RichListForm())
            {
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
                Data.Inventory.IV_ItemsDataTable table = new WMSOffice.Data.Inventory.IV_ItemsDataTable();
                formItems.DataSource = table;
                formItems.ColumnForFilters.Add("Item");
                formItems.ColumnForFilters.Add("Manufacturer");
                formItems.FilterChanged += new EventHandler(formItems_FilterChanged);

                if (formItems.ShowDialog() == DialogResult.OK)
                {
                    lastBarCode = string.Empty;
                    lastItemID = (int)((Data.Inventory.IV_ItemsRow)formItems.SelectedRow).Item_ID;
                    lastItemName = ((Data.Inventory.IV_ItemsRow)formItems.SelectedRow).Item;
                    lastUOM = ((Data.Inventory.IV_ItemsRow)formItems.SelectedRow).UnitOfMeasure;
                    lastVendorLotID = ((Data.Inventory.IV_ItemsRow)formItems.SelectedRow).Vendor_Lot;
                    lastCount = 1;
                    lastCountNTV = 0;
                    lastLineID = (int?)null;
                    //AddRow();
                    // двигаемся дальше в сторону выбора серии


                    //// При повторном и завершающем пересчете добавляем товар с контролем серии
                    //if (this.currentCountSheetCategory == InventoryCountSheetCategory.Repeat ||
                    //    this.currentCountSheetCategory == InventoryCountSheetCategory.Final)
                    //{
                    ChooseSeries();
                    //}
                    //else
                    //    // При первичном пересчете добавляем товар без контроля серии
                    //    if (this.currentCountSheetCategory == InventoryCountSheetCategory.Primary)
                    //    {
                    //        this.AddRow();
                    //    }
                }
                else
                {
                    UndoEnabled = false;
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение фильтра в диалоге выбора препарата без штрих-кода, загружая новый список препаратов с учетом фильтра
        /// </summary>
        private void formItems_FilterChanged(object sender, EventArgs e)
        {
            using (Data.InventoryTableAdapters.IV_ItemsTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.IV_ItemsTableAdapter())
            {
                try
                {
                    Data.Inventory.IV_ItemsDataTable table = adapter.GetData(((Dialogs.RichListForm)sender).Filter);
                    ((Dialogs.RichListForm)sender).DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private bool allowCloseWindow = false;

        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите завершить ввод товаров?",
                "Завершение ввода", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bool? check = false;
                    bool? success = false;
                    Data.Inventory.InventoryCloseCountListDocResponseDataTable dtResponse = null;
                    using (Data.InventoryTableAdapters.InventoryCloseCountListDocResponseTableAdapter adapter = new Data.InventoryTableAdapters.InventoryCloseCountListDocResponseTableAdapter())
                        dtResponse = adapter.GetData(DocID, ref check);

                    if (dtResponse.Count > 0)
                        success = dtResponse[0].OUT;

                    if ((bool)success)
                    {

                        MessageBox.Show("Документ контроля успешно закрыт!", "Закрытие документа", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        allowCloseWindow = true;
                        Close();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private void InventoryControlWindow_IK_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!allowCloseWindow && (Control.ModifierKeys != Keys.Control))
            {
                MessageBox.Show("Нельзя закрыть окно документа до завершения процедуры контроля. Пожалуйста, продолжайте работу.\n\rДля закрытия документа контроля воспользуйтесь командой \"Завершить ввод товаров\".", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Добавление товара в ящик
        /// </summary>
        private void btnAddToBox_Click(object sender, EventArgs e)
        {
            try
            {
                using (var scanBoxForm = new ScanBoxForm())
                {
                    if (scanBoxForm.ShowDialog() == DialogResult.OK)
                    {
                        using (var adapter = new Data.InventoryTableAdapters.IV_CS_HeaderTableAdapter())
                            adapter.CloseBox(DocID, scanBoxForm.Barcode);

                        RefreshLines();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Отмена строки
        /// </summary>
        private void miCancelLine_Click(object sender, EventArgs e)
        {
            if (gvLines.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите отменить строку?",
                    "Завершение ввода", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        Data.Inventory.IV_CS_RowsRow selRow = (Data.Inventory.IV_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row;
                        UndoEnabled = false;
                        lastItemID = selRow.Item_ID;
                        lastVendorLotID = selRow.VendorLot;
                        lastUOM = selRow.UnitOfMeasure;
                        lastCount = (int)selRow.EditQuantity;
                        lastCountNTV = (int)selRow.Quantity_NTV;

                        iV_CS_RowsTableAdapter.CancelRow(
                            DocID,
                            selRow.Item_ID,
                            selRow.VendorLot,
                            selRow.UnitOfMeasure,
                            selRow.Quantity,
                            selRow.Quantity_NTV,
                            ""//((Data.Inventory.IV_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).Bar_Code
                            );
                        RefreshLines();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрана ни одна строка, отмена невозможна.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обновление строк
        /// </summary>
        private void miRefresh_Click(object sender, EventArgs e)
        {
            RefreshLines();
        }

        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            Bitmap emptyBitmap = new Bitmap(16, 16);
            foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Inventory.IV_CS_RowsRow diffRow = (Data.Inventory.IV_CS_RowsRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                //Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                //                      ? Color.White
                //                      : Color.FromName(diffRow.Color);
                //for (int c = 0; c < row.Cells.Count; c++)
                //{
                //    row.Cells[c].Style.BackColor = backColor;
                //    row.Cells[c].Style.SelectionForeColor = backColor;
                //}

                // отображение иконок термо-режима
                if (diffRow.IsSnowFlakeNull()) row.Cells[colSnowFlake.DisplayIndex].Value = emptyBitmap;
                else row.Cells[colSnowFlake.DisplayIndex].Value = (diffRow.SnowFlake == "R")
                    ? Properties.Resources.snowflakeR
                    : (diffRow.SnowFlake == "B")
                        ? Properties.Resources.snowflakeB
                        : emptyBitmap;
            }
        }

        private void gvLines_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || gvLines.Columns[e.ColumnIndex] != dgvcEditQuantity)
                return;

            var item = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.IV_CS_RowsRow;

            try
            {
                lastItemID = item.Item_ID;
                lastVendorLotID = item.VendorLot;
                lastUOM = item.UnitOfMeasure;
                lastCount = (int)item.EditQuantity;
                lastCountNTV = (int)item.Quantity_NTV;
                lastBarCode = null;
                lastLineID = item.Line_ID; 

                AddRow();
                gvLines.Focus();
                gvLines.CurrentCell = gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void gvLines_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var item = (gvLines.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Inventory.IV_CS_RowsRow;
            if (!item.IsBox_Bar_CodeNull() && !string.IsNullOrEmpty(item.Box_Bar_Code))
            {
                gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;
                gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGray;
                gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = Color.LightGray;
            }
        }

        private void gvLines_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == gvLines.Columns[dgvcEditQuantity.Name].Index)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if (e.Context == context)
                    {
                        MessageBox.Show(string.Format("Неверный формат числа для поля \"{0}\".", dgvcEditQuantity.HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void gvLines_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.gvLines.CurrentCell = this.gvLines.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.gvLines.BeginEdit(true);
            }
        }
    }
}
