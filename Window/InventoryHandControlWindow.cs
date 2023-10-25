using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class InventoryHandControlWindow : GeneralWindow
    {
        #region Fields

        private int lastItemID = 0;
        private string lastItemName = string.Empty;
        private string lastVendorLotID = string.Empty;
        private string lastUOM = string.Empty;
        private string lastBarCode = string.Empty;
        private string lastLocn = string.Empty;
        private int lastCount = 0;
        private int lastCountNTV = 0;

        #endregion

        #region Properties

        /// <summary>
        /// Дата родительского документа (идентификатор инвентаризации)
        /// </summary>
        public long RelatedDocID { get; private set; }

        /// <summary>
        /// Идентификатор пересчета
        /// </summary>
        public int RecalcID { get; private set; }

        /// <summary>
        /// Признак, показывающий, доступна ли отмена последнего действия (и заодно - было ли последнее действие)
        /// </summary>
        private bool UndoEnabled { get { return btnUndo.Enabled; } set { btnUndo.Enabled = miUndo.Enabled = value; } }

        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="relatedDocID"></param>
        /// <param name="recalcID"></param>
        public InventoryHandControlWindow(long relatedDocID, int recalcID)
        {
            InitializeComponent();

            RelatedDocID = relatedDocID;
            RecalcID = recalcID;
            UndoEnabled = false;
            AllowAddRows = false;
        }

        private void InventoryHandControlWindow_Load(object sender, EventArgs e)
        {
            lblInventoryID.Text = RelatedDocID.ToString();
            lblCountSheetID.Text = DocID.ToString();
            lblCountSheetDate.Text = DocDate.ToShortDateString();
            lblRecalcID.Text = RecalcID.ToString();

            //tbBarcode.Focus();
            //gvLines.Focus();
            RefreshLines();
        }

        private void InventoryHandControlWindow_Shown(object sender, EventArgs e)
        {
            SelectFirstRow();
        }

        /// <summary>
        /// Обновляет список строк, уже введенных в счетный лист, загружая их из БД
        /// </summary>
        private void RefreshLines()
        {
            // сохранение текущего значения
            //SaveCurrentRow();
            // заполнение таблицы строками из счетного листа
            iV_CS_Rows_byHandTableAdapter.Fill(inventory.IV_CS_Rows_byHand, DocID);
        }

        /// <summary>
        /// Разрешено ли добавление строк в документ (признак устанавливается для пустографок)
        /// </summary>
        public bool AllowAddRows {
            get { return btnAddItem.Enabled; }
            set { btnAddItem.Enabled = miAddItem.Visible = miAddItem2.Visible = lblBarcode.Visible = tbBarcode.Visible = value; } 
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBarcode.Text))
            {
                // ввод количества по ENTER'у для товара, который был введен ранее
                /*if (UndoEnabled)
                {
                    // SelectLastRow();
                    using (Dialogs.PickControl.SetCountForm form = new Dialogs.PickControl.SetCountForm()
                    {
                        ItemID = lastItemID,
                        ItemName = lastItemName,
                        Lotn = lastVendorLotID,
                        TotalCount = (int)((Data.Inventory.IV_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).Quantity - lastCount,
                        Count = lastCount,
                        InputCountEnabled = true
                    })
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            int old = lastCountNTV;
                            int cnt = form.Count;
                            if (cnt < 0)
                                MessageBox.Show("Невозможно установить отрицательное значение!");
                            else if (cnt < lastCountNTV)
                                MessageBox.Show("Невозможно установить значение общего количества товара меньше, чем количество товара НТВ!");
                            else
                            {
                                if (cnt != lastCount)
                                {
                                    lastCount = cnt - lastCount;
                                    lastCountNTV = 0;
                                    AddRow();
                                }
                                lastCount = cnt;
                                lastCountNTV = old;
                            }
                        }
                    }
                }*/
            }
            else
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

        private void SetSeria()
        {
            WMSOffice.Dialogs.PickControl.SetVendorLotnForm form = new WMSOffice.Dialogs.PickControl.SetVendorLotnForm();

            form.CurrentScenario = WMSOffice.Dialogs.PickControl.SetVendorLotnForm.Scenario.InventoryHand;
            form.ItemID = lastItemID;

            form.Text = "Присвоение серии " + lastItemName;
            if (form.ShowDialog() == DialogResult.OK)
            {
                lastVendorLotID = form.Lotn;
                AddRow();
            }
            else
            {
                UndoEnabled = false;
            }
        }

        private void SelectFirstRow()
        {
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Cells[quantityDataGridViewTextBoxColumn.Name].Selected = true;
            // tbBarcode.Focus();
            gvLines.Focus();
        }

        private void SelectLastRow()
        {
            /*foreach (DataGridViewRow row in gvLines.Rows)
            {
                Data.Inventory.IV_CS_Rows_byHandRow diffRow = (Data.Inventory.IV_CS_Rows_byHandRow)((DataRowView)row.DataBoundItem).Row;
                if (diffRow.Item_ID == lastItemID && diffRow.VendorLot == lastVendorLotID)
                {
                    row.Cells[quantityDataGridViewTextBoxColumn.Name].Selected = true;
                    gvLines.Focus();
                    break;
                }
            }*/
            gvLines.Focus();
            gvLines.Rows[gvLines.Rows.Count - 1].Cells[quantityDataGridViewTextBoxColumn.Name].Selected = true;
            gvLines.BeginEdit(true);
        }

        /// <summary>
        /// Добавляет новую строку в БД
        /// </summary>
        private void AddRow()
        {
            try
            {
                if (ChooseLocations())
                {
                    //UndoEnabled = false;
                    iV_CS_Rows_byHandTableAdapter.AddRowToBlank(DocID, lastLocn, lastItemID, lastVendorLotID, lastUOM, lastCount, lastCountNTV);
                    //UndoEnabled = true;
                    RefreshLines();
                    SelectLastRow();
                }
                //tbBarcode.Focus();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Выбор места хранения
        /// </summary>
        private bool ChooseLocations()
        {
            using (Dialogs.RichListForm formLocations = new Dialogs.RichListForm())
            {
                #region column LOCN
                DataGridViewTextBoxColumn colLocn = new DataGridViewTextBoxColumn();
                colLocn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colLocn.DataPropertyName = "LOCN";
                colLocn.HeaderText = "Полка";
                colLocn.Name = "colLocn";
                colLocn.ReadOnly = true;
                formLocations.Columns.Add(colLocn);
                #endregion

                formLocations.Text = "Выбор мест хранения";
                Data.Inventory.LocationsToSetDataTable table = new WMSOffice.Data.Inventory.LocationsToSetDataTable();
                formLocations.DataSource = table;
                formLocations.ColumnForFilters.Add("LOCN");
                formLocations.FilterChanged += new EventHandler(formLocations_FilterChanged);
                formLocations.RussianCulture = false;

                if (formLocations.ShowDialog() == DialogResult.OK)
                {
                    lastLocn = (string)((Data.Inventory.LocationsToSetRow)formLocations.SelectedRow).LOCN;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение фильтра в диалоге выбора мест хранения с учетом фильтра
        /// </summary>
        private void formLocations_FilterChanged(object sender, EventArgs e)
        {
            using (Data.InventoryTableAdapters.LocationsToSetTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.LocationsToSetTableAdapter())
            {
                try
                {
                    Data.Inventory.LocationsToSetDataTable table = adapter.GetData(DocID, ((Dialogs.RichListForm)sender).Filter);
                    ((Dialogs.RichListForm)sender).DataSource = table;
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
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
                    #region column ItemCode
                    DataGridViewTextBoxColumn colItemCode = new DataGridViewTextBoxColumn();
                    colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                    colItemCode.DataPropertyName = "Item_ID";
                    colItemCode.HeaderText = "Код";
                    colItemCode.Name = "colItemCode";
                    colItemCode.ReadOnly = true;
                    formItm.Columns.Add(colItemCode);
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
                        lastCount = 0;

                        AddRow();
                    }
                    else
                    {
                        UndoEnabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Добавить товар без штрих-кода"
        /// </summary>
        private void btnAddItem_Click(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            using (Dialogs.RichListForm formItems = new Dialogs.RichListForm())
            {
                #region column ItemCode
                DataGridViewTextBoxColumn colItemCode = new DataGridViewTextBoxColumn();
                colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                colItemCode.DataPropertyName = "Item_ID";
                colItemCode.HeaderText = "Код";
                colItemCode.Name = "colItemCode";
                colItemCode.ReadOnly = true;
                formItems.Columns.Add(colItemCode);
                #endregion
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
                    lastCount = 0;
                    lastCountNTV = 0;
                    // двигаемся дальше в сторону выбора серии
                    ChooseSeries();
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

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Завершить ввод товаров"
        /// </summary>
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            tbBarcode.Focus();
            if (MessageBox.Show("Вы действительно хотите завершить ввод товаров?",
                "Завершение ввода", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                 try
                 {
                     // построчное сохранение количеств
                     foreach (DataGridViewRow gridRow in gvLines.Rows)
                     {
                         Data.Inventory.IV_CS_Rows_byHandRow row = (Data.Inventory.IV_CS_Rows_byHandRow)((DataRowView)gridRow.DataBoundItem).Row;
                         iV_CS_Rows_byHandTableAdapter.SetQty(DocID, row.Line_ID, row.Quantity, row.Quantity_NTV);
                     }

                     // закрытие документа
                     iV_CS_Rows_byHandTableAdapter.CloseCS(DocID);
                     Close();
                 }
                 catch (Exception ex)
                 {
                     ShowError(ex);
                 }
            }
        }

        private void gvLines_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                SaveCurrentRow(e.RowIndex);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }     
        }

        private void SaveCurrentRow() { if (gvLines.SelectedCells.Count > 0) SaveCurrentRow(gvLines.SelectedCells[0].RowIndex); }
        private void SaveCurrentRow(int rowIndex)
        {
            if (inventory.IV_CS_Rows_byHand.Count > 0)
            {
                // сохранение количества всегда
                Data.Inventory.IV_CS_Rows_byHandRow row = (Data.Inventory.IV_CS_Rows_byHandRow)((DataRowView)gvLines.Rows[rowIndex].DataBoundItem).Row;
                iV_CS_Rows_byHandTableAdapter.SetQty(DocID, row.Line_ID, row.Quantity, row.Quantity_NTV);
            }
        }

        private void miUndo_Click(object sender, EventArgs e)
        {

        }

    }

}
