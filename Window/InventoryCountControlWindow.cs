using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для ввода препаратов по инвентаризационному счетному листу
    /// </summary>
    public partial class InventoryCountControlWindow : GeneralWindow
    {
        #region Fields

        private int lastItemID = 0;
        private string lastItemName = string.Empty;
        private string lastVendorLotID = string.Empty;
        private string lastUOM = string.Empty;
        private string lastBarCode = string.Empty;
        private int lastCount = 0;

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
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public InventoryCountControlWindow(long relatedDocID, int recalcID)
        {
            InitializeComponent();

            RelatedDocID = relatedDocID;
            RecalcID = recalcID;
            UndoEnabled = false;
        }

        /// <summary>
        /// Обрабатывает момент загрузки окна, инициализируя надписи с доп. информацией
        /// </summary>
        private void InventoryCountControlWindow_Load(object sender, EventArgs e)
        {
            lblInventoryID.Text = RelatedDocID.ToString();
            lblCountSheetID.Text = DocID.ToString();
            lblCountSheetDate.Text = DocDate.ToShortDateString();
            lblRecalcID.Text = RecalcID.ToString();
            
            tbBarcode.Focus();
            RefreshLines();
        }

        /// <summary>
        /// Обновляет список строк, уже введенных в счетный лист, загружая их из БД
        /// </summary>
        private void RefreshLines()
        {
            iNCSRowsBindingSource.Filter = "";
            iNCSRowsBindingSource.Sort = "";
            iN_CS_RowsTableAdapter.Fill(inventory.IN_CS_Rows, DocID);
            if (gvLines.Rows.Count > 0)
                gvLines.Rows[0].Selected = true;
        }

        /// <summary>
        /// Обрабатывает ввод новых штрих-кодов
        /// </summary>
        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbBarcode.Text))
            {
                // ввод количества по ENTER'у для товара, который был введен ранее
                if (UndoEnabled)
                {
                    using (Dialogs.PickControl.SetCountForm form = new Dialogs.PickControl.SetCountForm()
                    {
                        ItemID = lastItemID,
                        ItemName = lastItemName,
                        Lotn = lastVendorLotID,
                        TotalCount = (int)((Data.Inventory.IN_CS_RowsRow)((DataRowView)gvLines.Rows[0].DataBoundItem).Row).Doc_Qty,
                        InputCountEnabled = true
                    })
                    {
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            int cnt = form.Count;
                            if (cnt != lastCount)
                            {
                                lastCount = cnt - lastCount;
                                AddRow();
                            }
                            lastCount = cnt;
                        }
                    }
                }
            }
            else
                using (Data.InventoryTableAdapters.ItemByBarCodeTableAdapter adapter = new Data.InventoryTableAdapters.ItemByBarCodeTableAdapter())
                {
                    try
                    {
                        Data.Inventory.ItemByBarCodeDataTable table = adapter.GetData(DocID, tbBarcode.Text);
                        if (table == null || table.Count < 1)
                        {
                            throw new Exception("Товар не найден! Воспользуйтесь поиском (Ctrl+F) для добавления товара без штрих кода.");
                        }
                        else if (table.Count == 1)
                        {
                            // только один товар нашли, добавляем
                            Data.Inventory.ItemByBarCodeRow itemsRow = table[0];
                            lastBarCode = tbBarcode.Text;
                            lastItemID = (int)itemsRow.Item_ID;
                            lastItemName = itemsRow.Item;
                            lastUOM = itemsRow.UnitOfMeasure;
                            lastVendorLotID = itemsRow.Vendor_Lot;
                            lastCount = 1;

                            AddRow();
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
        /// Добавляет новую строку в БД
        /// </summary>
        private void AddRow()
        {
            try
            {
                UndoEnabled = false;
                iN_CS_RowsTableAdapter.AddCSRow(DocID, lastItemID, lastVendorLotID, lastUOM, lastCount, lastBarCode);
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
            if (dataTable != null && dataTable is Data.Inventory.ItemByBarCodeDataTable && ((DataTable)dataTable).Rows.Count > 1)
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
                        Data.Inventory.ItemByBarCodeRow row = (Data.Inventory.ItemByBarCodeRow)formItm.SelectedRow;

                        lastBarCode = tbBarcode.Text;
                        lastItemID = (int)row.Item_ID;
                        lastItemName = row.Item;
                        lastUOM = row.UnitOfMeasure;
                        lastVendorLotID = row.Vendor_Lot;
                        lastCount = 1;

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
        /// Обрабатывает нажатие на кнопку "Отменить последнее действие"
        /// </summary>
        private void btnUndo_Click(object sender, EventArgs e)
        {
            if (UndoEnabled && MessageBox.Show("Отменить данные по последнему введенному товару?",
                "Отмена", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                iN_CS_RowsTableAdapter.CancelCSLine(DocID, lastItemID, lastVendorLotID, lastUOM, lastBarCode);
                UndoEnabled = false;
                RefreshLines();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Добавить товар без штрих-кода"
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
                Data.PickControl.ItemsDataTable table = new WMSOffice.Data.PickControl.ItemsDataTable();
                formItems.DataSource = table;
                formItems.ColumnForFilters.Add("Item");
                formItems.ColumnForFilters.Add("Manufacturer");
                formItems.FilterChanged += new EventHandler(formItems_FilterChanged);
                
                if (formItems.ShowDialog() == DialogResult.OK)
                {
                    lastBarCode = string.Empty;
                    lastItemID = (int)((Data.PickControl.ItemsRow)formItems.SelectedRow).Item_ID;
                    lastItemName = ((Data.PickControl.ItemsRow)formItems.SelectedRow).Item;
                    lastUOM = ((Data.PickControl.ItemsRow)formItems.SelectedRow).UnitOfMeasure;
                    lastVendorLotID = ((Data.PickControl.ItemsRow)formItems.SelectedRow).Vendor_Lot;
                    lastCount = 1;
                    AddRow();
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
            using (Data.PickControlTableAdapters.ItemsTableAdapter adapter = new WMSOffice.Data.PickControlTableAdapters.ItemsTableAdapter())
            {
                try
                {
                    Data.PickControl.ItemsDataTable table = adapter.GetDataAll(((Dialogs.RichListForm)sender).Filter);
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
            if (MessageBox.Show("Вы действительно хотите завершить ввод товаров?",
                "Завершение ввода", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    using (Data.InventoryTableAdapters.IN_CS_HeaderTableAdapter adapter = new Data.InventoryTableAdapters.IN_CS_HeaderTableAdapter())
                    {
                        adapter.CloseCountSheet(DocID);
                    }
                    Close();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Отменить строку"
        /// </summary>
        private void btnCancelLine_Click(object sender, EventArgs e)
        {
            if (gvLines.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Вы действительно хотите отменить строку?",
                    "Завершение ввода", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    try
                    {
                        iN_CS_RowsTableAdapter.CancelCSLine(
                            DocID,
                            ((Data.Inventory.IN_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).Item_ID,
                            ((Data.Inventory.IN_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).VendorLot,
                            ((Data.Inventory.IN_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).UnitOfMeasure,
                            ((Data.Inventory.IN_CS_RowsRow)((DataRowView)gvLines.SelectedRows[0].DataBoundItem).Row).Bar_Code
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
    }
}
