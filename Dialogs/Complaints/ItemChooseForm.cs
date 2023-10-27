using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для ручного ввода товара (например, для претензий типа "возврат излишков").
    /// </summary>
    public partial class ItemChooseForm : Form
    {
        /// <summary>
        /// Код сессии пользователя.
        /// </summary>
        private long SessionID { get; set; }

        /// <summary>
        /// Признак, была ли найдена и выбрана серия
        /// </summary>
        private bool VendorLotFound { get; set; }

        /// <summary>
        /// Признак возможности поиска по коду/наименованию товара
        /// </summary>
        public bool CanSearchByItemCode 
        {
            get { return btnSearchItemByName.Enabled; }
            set
            {
                btnSearchItemByName.Enabled = value;
                tbItemName.ReadOnly = !value;
                cmsiSearchByItemCode.Enabled = value;
            }
        }

        /// <summary>
        /// Признак возможности поиска по коду товара в документах
        /// </summary>
        public bool CanSearchByItemCodeInDocs
        {
            get { return cmsiSearchByItemCodeInDocs.Enabled; }
            set
            {
                cmsiSearchByItemCodeInDocs.Enabled = value;
                cmsiSearchByItemCodeExcludeDocs.Enabled = value;
            }
        }

        /// <summary>
        /// Использование режима поиска по коду товара в документах
        /// </summary>
        public bool ApplySearchByItemCodeInDocs { get; private set; }

        /// <summary>
        /// Использование режима поиска по коду товара отдельно от документов
        /// </summary>
        public bool ApplySearchByItemCodeExcludeDocs { get { return cbExcludeDocs.Checked; } }

        /// <summary>
        /// Тип документа(накладной) (при включенном режиме поиска по коду товара в документаx)
        /// </summary>
        public string DocType {get; private set;}

        /// <summary>
        /// Номер документа(накладной) (при включенном режиме поиска по коду товара в документаx)
        /// </summary>
        public int? DocNumber { get; private set; }

        /// <summary>
        /// Строка кода адреса доставки источника претензии
        /// </summary>
        public string SourceAddressCodeString { get; set; }

        public double? DebtorCode { get; private set; }
        public string OrderType { get; private set; }
        public double? OrderNumber { get; private set; }
        public string InvoiceType { get; private set; }
        public double? InvoiceNumber { get; private set; }
        public string WarehouseID { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Код сессии пользователя.</param>
        public ItemChooseForm(long sessionID)
        {
            InitializeComponent();

            this.SessionID = sessionID;
            VendorLotFound = false;
        }

        /// <summary>
        /// Возвращает код товара.
        /// </summary>
        public int ItemID
        {
            get
            {
                int result = 0;
                int.TryParse(tbItemCode.Text, out result);
                return result;
            }
        }

        /// <summary>
        /// Возвращает наименование товара.
        /// </summary>
        public string ItemName
        {
            get { return tbItemNameFound.Text; }
        }

        /// <summary>
        /// Возвращает наименование производителя товара.
        /// </summary>
        public string Manufacturer
        {
            get { return tbManufacturer.Text; }
        }

        /// <summary>
        /// Возвращает серию товара.
        /// </summary>
        public string VendorLot
        {
            get { return tbVendorLot.Text; }
        }

        /// <summary>
        /// Возвращает срок годности для указанной серии.
        /// </summary>
        public DateTime? LotExpirationDate { get; private set; }

        /// <summary>
        /// Возвращает партию для указанной серии.
        /// </summary>
        public string LotNumber { get; private set; }

        /// <summary>
        /// Возвращает единицы измерения товара.
        /// </summary>
        public string UnitOfMeasure
        {
            get { return tbUnitOfMeasure.Text; }
        }

        /// <summary>
        /// Возвращает количество товара.
        /// </summary>
        public float Quantity
        {
            get
            {
                float result = 0;
                float.TryParse(tbQuantity.Text, out result);
                return result;
            }
        }

        /// <summary>
        /// Обрабатывает момент отображения диалога.
        /// </summary>
        private void ItemChooseForm_Shown(object sender, EventArgs e)
        {
            tbItemCode.Focus();
        }
        
        /// <summary>
        /// Обрабатывает изменение кода товара.
        /// </summary>
        private void tbItemCode_TextChanged(object sender, EventArgs e)
        {
            tbItemNameFound.Text = tbManufacturer.Text = tbVendorLot.Text = tbUnitOfMeasure.Text = string.Empty;
            btnSearchVendorLot.Enabled = false;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск по коду".
        /// </summary>
        private void btnSearchItemByCode_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0 - Math.Abs(cmsiSearchByItemCodeInDocs.Width - btnSender.Width), btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsItemSearchModes.Show(ptLowerLeft);
        }

        private void cmsiSearchByItemCode_Click(object sender, EventArgs e)
        {
            SearchItemByCode(false);
        }

        private void SearchItemByCode(bool excludeDocs)
        {
            var deliveryID = (int?)null;
            if (excludeDocs)
            {
                int sourceAddressCode;
                if (!int.TryParse(SourceAddressCodeString, out sourceAddressCode) || sourceAddressCode <= 0)
                {
                    MessageBox.Show("Неверно указан код адреса доставки источника претензии!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    deliveryID = sourceAddressCode;
                }
            }

            int itemCode = 0;
            if (int.TryParse(tbItemCode.Text, out itemCode) && itemCode > 0)
            {
                using (Data.ComplaintsTableAdapters.InfoByItemTableAdapter adapter = new Data.ComplaintsTableAdapters.InfoByItemTableAdapter())
                {
                    Data.Complaints.InfoByItemDataTable table = adapter.GetDataByItemCode(itemCode, deliveryID);
                    if (table.Rows.Count > 0)
                    {
                        Data.Complaints.InfoByItemRow row = (Data.Complaints.InfoByItemRow)table.Rows[0];
                        tbItemNameFound.Text = row.IsItem_NameNull() ? string.Empty : row.Item_Name;
                        tbManufacturer.Text = row.IsManufacturer_NameNull() ? string.Empty : row.Manufacturer_Name;
                        tbUnitOfMeasure.Text = row.MinimumUnitOfMeasure;
                        btnSearchVendorLot.Enabled = true;
                        cbExcludeDocs.Checked = excludeDocs;

                        if (excludeDocs)
                        {
                            DebtorCode = row.IsDebtorCodeNull() ? (double?)null : (double?)row.DebtorCode;
                            OrderType = row.IsOrderTypeNull() ? (string)null : row.OrderType;
                            OrderNumber = row.IsOrderNumberNull() ? (double?)null : (double?)row.OrderNumber;
                            InvoiceType = row.IsInvoiceTypeNull() ? (string)null : row.InvoiceType;
                            InvoiceNumber = row.IsInvoiceNumberNull() ? (double?)null : (double?)row.InvoiceNumber;
                            WarehouseID = row.IsWarehouse_idNull() ? (string)null : row.Warehouse_id;
                        }
                    }
                    else
                    {
                        tbItemNameFound.Text = tbManufacturer.Text = string.Empty;
                        btnSearchVendorLot.Enabled = false;
                    }
                    tbVendorLot.Text = string.Empty;
                    VendorLotFound = false;
                }
            }
            else
            {
                MessageBox.Show("Неверно задан код товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbItemCode.Focus();
            }
        }

        private void cmsiSearchByItemCodeExcludeDocs_Click(object sender, EventArgs e)
        {
            SearchByItemCodeExcludeDocs();
        }

        private void SearchByItemCodeExcludeDocs()
        {
            SearchItemByCode(true);
        }

        private void cmsiSearchByItemCodeInDocs_Click(object sender, EventArgs e)
        {
            SearchByItemCodeInDocs();
        }

        private void SearchByItemCodeInDocs()
        {
            int sourceAddressCode;
            if (!int.TryParse(SourceAddressCodeString, out sourceAddressCode) || sourceAddressCode <= 0)
            {
                MessageBox.Show("Неверно указан код адреса доставки источника претензии!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int itemCode = 0;
            if (int.TryParse(tbItemCode.Text, out itemCode) && itemCode > 0)
            {
                using (var adapter = new Data.ComplaintsTableAdapters.ItemsInDocsTableAdapter())
                {
                    Data.Complaints.ItemsInDocsRow foundRow = null;

                    Data.Complaints.ItemsInDocsDataTable table = adapter.GetData(itemCode, sourceAddressCode);
                    if (table.Rows.Count == 1)
                    {
                        foundRow = (Data.Complaints.ItemsInDocsRow)table.Rows[0]; // выбор по умолчанию
                    }
                    else if (table.Rows.Count > 1)
                    {
                        using (Dialogs.RichListForm form = new Dialogs.RichListForm())
                        {
                            #region column FormattedInvoiceID
                            DataGridViewTextBoxColumn colFormattedInvoiceID = new DataGridViewTextBoxColumn();
                            colFormattedInvoiceID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colFormattedInvoiceID.DataPropertyName = "FormattedInvoiceID";
                            colFormattedInvoiceID.HeaderText = "№ накладной";
                            colFormattedInvoiceID.Name = "colFormattedInvoiceID";
                            colFormattedInvoiceID.ReadOnly = true;
                            form.Columns.Add(colFormattedInvoiceID);
                            #endregion
                            #region column InvoiceDate
                            DataGridViewTextBoxColumn colInvoiceDate = new DataGridViewTextBoxColumn();
                            colInvoiceDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colInvoiceDate.DataPropertyName = "InvoiceDate";
                            colInvoiceDate.HeaderText = "Дата накладной";
                            colInvoiceDate.Name = "colInvoiceDate";
                            colInvoiceDate.ReadOnly = true;
                            form.Columns.Add(colInvoiceDate);
                            #endregion
                            #region column BatchID
                            DataGridViewTextBoxColumn colBatchID = new DataGridViewTextBoxColumn();
                            colBatchID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colBatchID.DataPropertyName = "BatchID";
                            colBatchID.HeaderText = "Серия";
                            colBatchID.Name = "colBatchID";
                            colBatchID.ReadOnly = true;
                            form.Columns.Add(colBatchID);
                            #endregion
                            #region column ExpirationDate
                            DataGridViewTextBoxColumn colExpirationDate = new DataGridViewTextBoxColumn();
                            colExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colExpirationDate.DataPropertyName = "ExpirationDate";
                            colExpirationDate.HeaderText = "Срок годности";
                            colExpirationDate.Name = "colExpirationDate";
                            colExpirationDate.ReadOnly = true;
                            form.Columns.Add(colExpirationDate);
                            #endregion

                            form.Text = "Выбор документа";
                            form.DataSource = table;
                            form.FilterVisible = false;
                            form.DataSource = table;

                            if (form.ShowDialog() == DialogResult.OK && form.SelectedRow != null)
                                foundRow = (Data.Complaints.ItemsInDocsRow)form.SelectedRow;
                        }
                    }
                    else
                    {
                        MessageBox.Show("По данным параметрам документы не найдены!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (foundRow != null)
                    {
                        ApplySearchByItemCodeInDocs = true;

                        this.DocType = foundRow.InvoiceType;
                        this.DocNumber = (int)foundRow.InvoiceID;

                        cbExcludeDocs.Checked = false;

                        DialogResult = DialogResult.OK;
                        Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверно задан код товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbItemCode.Focus();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск по наименованию".
        /// </summary>
        private void btnSearchItemByName_Click(object sender, EventArgs e)
        {
            if (tbItemName.Text.Length >= 3)
            {
                using (Data.ComplaintsTableAdapters.InfoByItemTableAdapter adapter = new Data.ComplaintsTableAdapters.InfoByItemTableAdapter())
                {
                    Data.Complaints.InfoByItemDataTable table = adapter.GetDataByItemName(tbItemName.Text);
                    if (table.Rows.Count == 1)
                    {
                        Data.Complaints.InfoByItemRow row = (Data.Complaints.InfoByItemRow)table.Rows[0];
                        tbItemCode.Text = row.Item_ID.ToString();
                        tbItemNameFound.Text = row.IsItem_NameNull() ? string.Empty : row.Item_Name;
                        tbManufacturer.Text = row.IsManufacturer_NameNull() ? string.Empty : row.Manufacturer_Name;
                        tbUnitOfMeasure.Text = row.MinimumUnitOfMeasure;
                        btnSearchVendorLot.Enabled = true;
                        cbExcludeDocs.Checked = false;
                    }
                    else if (table.Rows.Count > 1)
                    {
                        using (Dialogs.RichListForm form = new Dialogs.RichListForm())
                        {
                            #region column ItemCode
                            DataGridViewTextBoxColumn colItemCode = new DataGridViewTextBoxColumn();
                            colItemCode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colItemCode.DataPropertyName = "Item_ID";
                            colItemCode.HeaderText = "Код";
                            colItemCode.Name = "colItemCode";
                            colItemCode.ReadOnly = true;
                            form.Columns.Add(colItemCode);
                            #endregion
                            #region column ItemName
                            DataGridViewTextBoxColumn colItemName = new DataGridViewTextBoxColumn();
                            colItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colItemName.DataPropertyName = "Item_Name";
                            colItemName.HeaderText = "Наименование товара";
                            colItemName.Name = "colItemName";
                            colItemName.ReadOnly = true;
                            form.Columns.Add(colItemName);
                            #endregion
                            #region column ManufacturerName
                            DataGridViewTextBoxColumn colManufacturerName = new DataGridViewTextBoxColumn();
                            colManufacturerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colManufacturerName.DataPropertyName = "Manufacturer_Name";
                            colManufacturerName.HeaderText = "Наименование производителя";
                            colManufacturerName.Name = "colManufacturerName";
                            colManufacturerName.ReadOnly = true;
                            form.Columns.Add(colManufacturerName);
                            #endregion

                            form.Text = "Выбор товара";
                            form.DataSource = table;
                            form.FilterVisible = false;
                            form.DataSource = table;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                if (form.SelectedRow != null)
                                {
                                    Data.Complaints.InfoByItemRow row = (Data.Complaints.InfoByItemRow)form.SelectedRow;
                                    tbItemCode.Text = row.Item_ID.ToString();
                                    tbItemNameFound.Text = row.IsItem_NameNull() ? string.Empty : row.Item_Name;
                                    tbManufacturer.Text = row.IsManufacturer_NameNull() ? string.Empty : row.Manufacturer_Name;
                                    tbUnitOfMeasure.Text = row.MinimumUnitOfMeasure;
                                    btnSearchVendorLot.Enabled = true;
                                    cbExcludeDocs.Checked = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        tbItemNameFound.Text = tbManufacturer.Text = string.Empty;
                        btnSearchVendorLot.Enabled = false;
                    }
                    tbVendorLot.Text = string.Empty;
                    VendorLotFound = false;
                }
            }
            else
            {
                MessageBox.Show("Необходимо ввести минимум 3 символа из наименования товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbItemName.Focus();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск серии".
        /// </summary>
        private void btnSearchVendorLot_Click(object sender, EventArgs e)
        {
            int itemCode = 0;
            if (int.TryParse(tbItemCode.Text, out itemCode) && itemCode > 0)
            {
                using (Data.ComplaintsTableAdapters.SearchVendorLotTableAdapter adapter = new Data.ComplaintsTableAdapters.SearchVendorLotTableAdapter())
                {
                    Data.Complaints.SearchVendorLotDataTable table = adapter.GetData(SessionID, itemCode);
                    if (table.Rows.Count > 0)
                    {
                        using (Dialogs.RichListForm form = new RichListForm())
                        {
                            #region column VendorLot
                            DataGridViewTextBoxColumn colVendorLot = new DataGridViewTextBoxColumn();
                            colVendorLot.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colVendorLot.DataPropertyName = "VendorLot";
                            colVendorLot.HeaderText = "Серия";
                            colVendorLot.Name = "colVendorLot";
                            colVendorLot.ReadOnly = true;
                            form.Columns.Add(colVendorLot);
                            #endregion
                            #region column LotExpirationDate
                            DataGridViewTextBoxColumn colLotExpirationDate = new DataGridViewTextBoxColumn();
                            colLotExpirationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                            colLotExpirationDate.DataPropertyName = "LotExpirationDate";
                            colLotExpirationDate.HeaderText = "Срок годности";
                            colLotExpirationDate.Name = "colLotExpirationDate";
                            colLotExpirationDate.ReadOnly = true;
                            form.Columns.Add(colLotExpirationDate);
                            #endregion

                            form.Text = "Выбор серии";
                            form.DataSource = table;
                            form.ColumnForFilters.Add("VendorLot");
                            form.ColumnForFilters.Add("LotExpirationDate");
                            form.FilterVisible = false;
                            form.DataSource = table;

                            if (form.ShowDialog() == DialogResult.OK)
                            {
                                if (form.SelectedRow != null)
                                {
                                    Data.Complaints.SearchVendorLotRow row = (Data.Complaints.SearchVendorLotRow)form.SelectedRow;
                                    tbVendorLot.Text = row.VendorLot;
                                    this.LotExpirationDate = row.IsLotExpirationDateNull() ? (DateTime?)null : row.LotExpirationDate;
                                    this.LotNumber = row.LotNumber;
                                    VendorLotFound = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Нет ни одной серии по введенному коду товара.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Неверно задан код товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbItemCode.Focus();
            } 
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            int itemCode = 0;
            float quantity = 0;
            if (!int.TryParse(tbItemCode.Text, out itemCode) && itemCode <= 0)
            {
                MessageBox.Show("Неверно задан код товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbItemNameFound.Text) || string.IsNullOrEmpty(tbManufacturer.Text))
            {
                MessageBox.Show("Отсутствует наименование товара и производитель! Выполните, пожалуйста, поиск товара по коду при помощи кнопки.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!VendorLotFound)
            {
                MessageBox.Show("Отсутствует серия товара! Выполните, пожалуйста, поиск серии при помощи кнопки.",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (string.IsNullOrEmpty(tbUnitOfMeasure.Text))
            {
                MessageBox.Show("Отсутствует код единиц измерения товара (IT / AM / ...)!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!float.TryParse(tbQuantity.Text, out quantity) || quantity <= 0)
            {
                MessageBox.Show("Неверно задано количество товара!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
