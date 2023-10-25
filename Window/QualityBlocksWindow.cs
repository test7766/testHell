using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно просмотра и установки блокировок
    /// </summary>
    public partial class QualityBlocksWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Список строк, выделенных в таблице
        /// </summary>
        private List<Quality.BL_Get_HoldsRow> SelectedRows
        {
            get
            {
                return egvBlocks.SelectedItems.ConvertAll<Quality.BL_Get_HoldsRow>(
                    delegate(DataRow pInnerRow) { return pInnerRow as Quality.BL_Get_HoldsRow; });
            }
        }

        /// <summary>
        /// Название таблицы с блокировками в конфигурационном файле
        /// </summary>
        private string ConfigTableName { get { return String.Format("{0}_Blocks", Name); } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public QualityBlocksWindow()
        {
            InitializeComponent();
            InitializeBlocksGrid();
        }

        /// <summary>
        /// Загрузка данных в выпадающий список - фильтр по типам блокировки
        /// </summary>
        private void LoadBlockTypesToFilter()
        {
            try
            {
                int i = 1;
                using (var adapter = new BL_Get_HoldTypesTableAdapter())
                {
                    adapter.Fill(quality.BL_Get_HoldTypes, UserID, true, null);
                    foreach (Quality.BL_Get_HoldTypesRow row in quality.BL_Get_HoldTypes)
                    {
                        row.Hold_ID_Int = i++;
                        ccbBlockTypes.Items.Add(new CCBoxItem(row.Hold, row.Hold_ID_Int));
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка типов блокировок: ", exc);
                ccbBlockTypes.Items.Clear();
            }
        }

        /// <summary>
        /// Загрузка данных в выпадающий список - фильтр по складам
        /// </summary>
        private void LoadWarehousesToFilter()
        {
            try
            {
                int i = 1;
                using (var adapter = new BL_Get_WarehousesTableAdapter())
                {
                    adapter.Fill(quality.BL_Get_Warehouses, UserID);
                    foreach (Quality.BL_Get_WarehousesRow row in quality.BL_Get_Warehouses)
                    {
                        row.Warehouse_ID_Int = i++;
                        ccbWarehouses.Items.Add(new CCBoxItem(row.Warehouse_DSC, row.Warehouse_ID_Int));
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка складов: ", exc);
                ccbWarehouses.Items.Clear();
            }
        }

        /// <summary>
        /// Инициализация выпадающих справочников - фильтров по коду товара/серии/партии 
        /// (на панели фильтров)
        /// </summary>
        private void InitializSearchTextBoxes()
        {
            stbItemID.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Items]";
            stbVendorLot.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Vendor_Lots]";
            stbBatchId.ValueReferenceQuery = "[dbo].[pr_BL_STB_Get_Batch_Ids]";
            stbItemID.UserID = stbBatchId.UserID = stbVendorLot.UserID = UserID;
            stbItemID.OnVerifyValue += stb_OnVerifyValue;
            stbVendorLot.OnVerifyValue += stb_OnVerifyValue;
            stbBatchId.OnVerifyValue += stb_OnVerifyValue;
        }

        /// <summary>
        /// Проверка значения, которое введно в фильтр либо выбрано из выпадающего справочника
        /// </summary>
        private void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var stb = sender as SearchTextBox;
            stb.Value = e.Success ? e.Value : null;
            if (sender == stbItemID)
            {
                lblItemName.Text = e.Success ? e.Description : String.Empty;
                RefreshVendorLotFilterControl();  // Изменилось значение товара, нужно обновить справочники серии и партии
                RefreshBatchIdFilterControl();
                if (stbVendorLot.Enabled)
                    stbVendorLot.Focus();
            }
            else if (sender == stbVendorLot)
            {
                RefreshBatchIdFilterControl();    // Изменилась серия товара, нужно обновить справочник партий
                stbBatchId.Focus();
            }
        }

        /// <summary>
        /// Настройка контрола-выпадающего справочника серий 
        /// (в зависимости от того, что сейчас выбрано в выпадающем справочнике кода товара)
        /// </summary>
        private void RefreshVendorLotFilterControl()
        {
            stbVendorLot.ClearAdditionalParameters();
            stbVendorLot.Value = null;
            if (!String.IsNullOrEmpty(stbItemID.Value))
                stbVendorLot.ApplyAdditionalParameter(stbItemID.Value);
            stbVendorLot.Enabled = !String.IsNullOrEmpty(stbItemID.Value);
        }

        /// <summary>
        /// Настройка контрола-выпадающего справочника партий
        /// (в зависимости от того, что сейчас выбрано в выпадающих справочниках товара и серии)
        /// </summary>
        private void RefreshBatchIdFilterControl()
        {
            stbBatchId.ClearAdditionalParameters();
            stbBatchId.Value = null;
            if (!String.IsNullOrEmpty(stbItemID.Value))
                stbBatchId.ApplyAdditionalParameter(stbItemID.Value);

            if (!String.IsNullOrEmpty(stbVendorLot.Value))
                stbBatchId.ApplyAdditionalParameter(stbVendorLot.Value);

            stbBatchId.Enabled = !String.IsNullOrEmpty(stbItemID.Value);
        }

        /// <summary>
        /// Загрузка данных при загрузке окна
        /// </summary>
        private void QualityBlocksWindow_Load(object sender, EventArgs e)
        {
            searchParameters.SessionID = UserID;
            LoadBlockTypesToFilter();
            LoadWarehousesToFilter();
            InitializSearchTextBoxes();
            LoadSettingsFromConfig();
            LoadUserAccesses();
            ShowOffersWindow();
            StartBlocksLoading();
            stbItemID.Focus();
        }

        /// <summary>
        /// Отображение окна с предложениями связать товары по всем блокировкам
        /// </summary>
        private void ShowOffersWindow()
        {
            var offersWindow = new ItemOffersForm(UserID, null) { Text = "Есть доступные предложения связывания!" };
            if (offersWindow.RowCount > 0)
                offersWindow.ShowDialog(this);
        }

        /// <summary>
        /// Сохранение настроек в конфиге
        /// </summary>
        private void QualityBlocksWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            egvBlocks.SaveExtraDataGridViewSettings(ConfigTableName);
            Config.SaveSetting(Name, DATEFROM, searchParameters.DateFrom == null ? null : searchParameters.DateFrom.ToString());
            Config.SaveSetting(Name, DATETO, searchParameters.DateTo == null ? null : searchParameters.DateTo.ToString());
            Config.SaveSetting(Name, BLOCKTYPEIDS, searchParameters.BlockTypeIds);
            Config.SaveSetting(Name, ONLYACTIVEBLOCKS, searchParameters.ActiveBlocks == null ? null : searchParameters.ActiveBlocks.ToString());
            Config.SaveSetting(Name, WHIDS, searchParameters.WhIds);
            Config.SaveSetting(Name, XMLDATA, searchParameters.XmlData);
            Config.SaveSetting(Name, ITEMNAME, searchParameters.ItemName);
            Config.SaveSetting(Name, BLOCKDOCNUMBER, String.IsNullOrEmpty(searchParameters.BlockDocNumber) ? null : searchParameters.BlockDocNumber);
        }

        /// <summary>
        /// Управление интерфейсом с помощью "горячих клавиш"
        /// </summary>
        private void QualityBlocksWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5 && !(e.Alt || e.Control || e.Shift) && btnRefresh.Visible && btnRefresh.Enabled)
                StartBlocksLoading();
            else if (e.KeyCode == Keys.F && e.Control && btnFilter.Visible && btnFilter.Enabled)
                btnFilter_Click(btnFilter, EventArgs.Empty);
            else if (e.KeyCode == Keys.F3 && !(e.Alt || e.Control || e.Shift) && btnExportToExcel.Visible && btnExportToExcel.Enabled)
                btnExportToExcel_Click(btnExportToExcel, EventArgs.Empty);
            else if (e.KeyCode == Keys.F4 && !(e.Alt || e.Control || e.Shift) && btnCreateBlockDoc.Visible && btnCreateBlockDoc.Enabled)
                btnBlockAction_Click(btnCreateBlockDoc, EventArgs.Empty);
            else if (e.KeyCode == Keys.F4 && e.Shift && btnCreateBlockForRows.Visible && btnCreateBlockForRows.Enabled)
                btnBlockAction_Click(btnCreateBlockForRows, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6 && !(e.Alt || e.Control || e.Shift) && btnCreateExceptionDoc.Visible && btnCreateExceptionDoc.Enabled)
                btnBlockAction_Click(btnCreateExceptionDoc, EventArgs.Empty);
            else if (e.KeyCode == Keys.F6 && e.Shift && btnCreateExceptionForRows.Visible && btnCreateExceptionForRows.Enabled)
                btnBlockAction_Click(btnCreateExceptionForRows, EventArgs.Empty);
            else if (e.KeyCode == Keys.F7 && !(e.Alt || e.Control || e.Shift) && btnFinishBlockDoc.Visible && btnFinishBlockDoc.Enabled)
                btnBlockAction_Click(btnFinishBlockDoc, EventArgs.Empty);
            else if (e.KeyCode == Keys.F7 && e.Shift && btnFinishBlockForRows.Visible && btnFinishBlockForRows.Enabled)
                btnBlockAction_Click(btnFinishBlockForRows, EventArgs.Empty);
            else if (e.KeyCode == Keys.F8 && !(e.Alt || e.Control || e.Shift) && btnApproveBlock.Visible && btnApproveBlock.Enabled)
                btnApproveBlock_Click(btnApproveBlock, EventArgs.Empty);
            else if (e.KeyCode == Keys.F9 && !(e.Alt || e.Control || e.Shift) && btnItemOffers.Visible && btnItemOffers.Enabled)
                btnItemOffers_Click(btnItemOffers, EventArgs.Empty);
        }

        #endregion

        #region ФИЛЬТРЫ

        /// <summary>
        /// Название настройки фильтра "Дата начала действия блокировки"
        /// </summary>
        private const string DATEFROM = "DateFrom";

        /// <summary>
        /// Название настройки фильтра "Дата окончания действия блокировки"
        /// </summary>
        private const string DATETO = "DateTo";

        /// <summary>
        /// Название настройки фильтра "Типы блокировок" (DelimetedList с идентификаторами типов)
        /// </summary>
        private const string BLOCKTYPEIDS = "BlockTypeIds";

        /// <summary>
        /// Название настройки фильтра "Действительность блокировки" (актуальные, ожидающие подтверждения либо все)
        /// </summary>
        private const string ONLYACTIVEBLOCKS = "OnlyActiveBlocks";

        /// <summary>
        /// Название настройки фильтра "Склады" (DelimetedList с идентификаторами складов)
        /// </summary>
        private const string WHIDS = "WhIds";

        /// <summary>
        /// Название настройки фильтра, которая в XML-форме содержит "Расширенный фильтр" - строки, в которых указаны 
        /// код товара (обязательно), серия и/или партия товара (опционально)
        /// </summary>
        private const string XMLDATA = "XmlData";

        /// <summary>
        /// Название настройки "Наименование товара" - в случае, если искомый товар один, то это наименование будет выводиться возле строки поиска
        /// </summary>
        private const string ITEMNAME = "ItemName";

        /// <summary>
        /// Название настройки "Номер документа блоикровки"
        /// </summary>
        private const string BLOCKDOCNUMBER = "BlockDocNumber";

        /// <summary>
        /// Название корневого XML-элемента в XML-структуре, содержащей строки товар/серия/партия
        /// </summary>
        private const string XML_ROOT_NAME = "Root";

        /// <summary>
        /// Названия атрибута в строке XML-структуры, значение которого содержит код товара
        /// </summary>
        private const string XML_ITM_ATTR_NAME = "item_id";

        /// <summary>
        /// Названия атрибута в строке XML-структуры, значение которого содержит серию товара
        /// </summary>
        private const string XML_RLOT_ATTR_NAME = "vendor_lot";

        /// <summary>
        /// Названия атрибута в строке XML-структуры, значение которого содержит партию товара
        /// </summary>
        private const string XML_LOTN_ATTR_NAME = "lot_number";

        /// <summary>
        /// Названия атрибута в строке XML-структуры, значение которого содержит код склада
        /// </summary>
        private const string XML_MCU_ATTR_NAME = "warehouse_id";

        /// <summary>
        /// Текущие используемые параметры поиска (фильтры)
        /// </summary>
        private readonly BlocksSearchParameters searchParameters = new BlocksSearchParameters();

        /// <summary>
        /// Окно для настройки расширенного фильтра товаров
        /// </summary>
        private BlocksFilterForm filterForm;

        /// <summary>
        /// Загрузка настроек фильтров из конфигурационного файла
        /// </summary>
        private void LoadSettingsFromConfig()
        {
            bool active;

            // Получение настройки - начала действия блокировки
            searchParameters.DateFrom = GetDateTimeSettingFromConfig(DATEFROM);

            // Получение настройки - окончания действия блокировки
            searchParameters.DateTo = GetDateTimeSettingFromConfig(DATETO);

            // Получение актуальности блокировки
            string activeBlocksStr = Config.LoadSetting(Name, ONLYACTIVEBLOCKS);
            if (activeBlocksStr == null)
                searchParameters.ActiveBlocks = null;
            else if (Boolean.TryParse(activeBlocksStr, out active))
                searchParameters.ActiveBlocks = active;

            // Получение типов блокировок
            searchParameters.BlockTypeIds = Config.LoadSetting(Name, BLOCKTYPEIDS);

            // Получение складов
            searchParameters.WhIds = Config.LoadSetting(Name, WHIDS);

            // Получение XML-строки со списком товаров/серий/партий, которые нужно найти
            searchParameters.XmlData = Config.LoadSetting(Name, XMLDATA);

            // Получение названия товара
            searchParameters.ItemName = Config.LoadSetting(Name, ITEMNAME);

            // Получение номера документа блокировки
            searchParameters.BlockDocNumber = Config.LoadSetting(Name, BLOCKDOCNUMBER);

            InitializeFilterPanel();
        }

        /// <summary>
        /// Считывание настройки с датой из конфигурационного файла
        /// </summary>
        /// <param name="pSettingName">Название настройки в конфигурационном файле</param>
        /// <returns>Значение настройки либо null, если настройка не сохранена в конфигурационном файле</returns>
        private DateTime? GetDateTimeSettingFromConfig(string pSettingName)
        {
            DateTime date;
            string dateStr = Config.LoadSetting(Name, pSettingName);
            if (dateStr == null)
                return null;
            else if (DateTime.TryParse(dateStr, out date))
                return date;
            else
                return null;
        }

        /// <summary>
        /// Инициализация контролов фильтра на панели фильтра значениями, записанными в переменную searchParameters
        /// </summary>
        private void InitializeFilterPanel()
        {
            SetDateTimeFiltersValue();
            SetRadioButtonFiltersValue();
            SetBlockTypesFilterValue();
            SetWarehousesFilterValue();
            SetSTBFiltersValue();
            tbxDocNumber.Text = String.IsNullOrEmpty(searchParameters.BlockDocNumber) ? String.Empty : searchParameters.BlockDocNumber;
        }

        /// <summary>
        /// Инициализация контролов-фильтров с начальной и конечной датами блокировки значениями из searchParameters
        /// (или из конфигурационного файла)
        /// </summary>
        private void SetDateTimeFiltersValue()
        {
            chbDateFrom.Checked = dtpDateFrom.Enabled = searchParameters.DateFrom.HasValue;
            dtpDateFrom.Value = chbDateFrom.Checked ? searchParameters.DateFrom.Value : dtpDateFrom.Value;
            chbDateTo.Checked = dtpDateTo.Enabled = searchParameters.DateTo.HasValue;
            dtpDateTo.Value = chbDateTo.Checked ? searchParameters.DateTo.Value : dtpDateTo.Value;
        }

        /// <summary>
        /// Инициализация RadioButton-контролов - фильтров по актуальности блокировок значениями из searchParameters
        /// (или из конфигурационного файла)
        /// </summary>
        private void SetRadioButtonFiltersValue()
        {
            if (!searchParameters.ActiveBlocks.HasValue)
                rbtAll.Checked = true;
            else if (searchParameters.ActiveBlocks.Value)
                rbtOnlyActive.Checked = true;
            else
                rbtCommitNeeded.Checked = true;
        }

        /// <summary>
        /// Отмечание флажками типов блокировок в выпадающем списке-фильтре, по которым будет осуществляться поиск
        /// </summary>
        private void SetBlockTypesFilterValue()
        {
            if (searchParameters.BlockTypeIds != null && searchParameters.BlockTypeIds.Length > 0)
            {
                var intIds = new List<int>();
                foreach (string id in searchParameters.BlockTypeIds.Split(','))
                {
                    int number = -1;
                    foreach (Quality.BL_Get_HoldTypesRow row in quality.BL_Get_HoldTypes)
                        if (row.Hold_ID == id)
                            number = row.Hold_ID_Int;
                    if (number != -1)
                        intIds.Add(number);
                }

                for (int i = 0; i < ccbBlockTypes.Items.Count; i++)
                    if (intIds.Contains(Convert.ToInt32((ccbBlockTypes.Items[i] as CCBoxItem).Value)))
                        ccbBlockTypes.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Отмечание флажками складов в выпадающем списке-фильтре, по которым будет осуществляться поиск
        /// </summary>
        private void SetWarehousesFilterValue()
        {
            if (searchParameters.WhIds != null && searchParameters.WhIds.Length > 0)
            {
                var intIds = new List<int>();
                foreach (string id in searchParameters.WhIds.Split(','))
                {
                    int number = -1;
                    foreach (Quality.BL_Get_WarehousesRow row in quality.BL_Get_Warehouses)
                        if (row.Warehouse_ID == id)
                            number = row.Warehouse_ID_Int;
                    if (number != -1)
                        intIds.Add(number);
                }

                for (int i = 0; i < ccbWarehouses.Items.Count; i++)
                    if (intIds.Contains(Convert.ToInt32((ccbWarehouses.Items[i] as CCBoxItem).Value)))
                        ccbWarehouses.SetItemChecked(i, true);
            }
        }

        /// <summary>
        /// Инициализация фильтров по коду товара, серии и партии (если в фильтре только одна строка - то инициализуются
        /// выпадающие справочники на панели фильтров, если больше строк - то расширенный фильтр можно увидеть, открыв форму поиска)
        /// </summary>
        private void SetSTBFiltersValue()
        {
            var table = FromXml(searchParameters.XmlData);
            stbItemID.Value = (table.Count != 1) ? null : table[0].ItemID.ToString();
            lblItemName.Text = (table.Count != 1) ? String.Empty : searchParameters.ItemName;
            RefreshVendorLotFilterControl();
            stbVendorLot.Value = (table.Count != 1 || table[0].IsVendorLotNull()) ? null : table[0].VendorLot;
            RefreshBatchIdFilterControl();
            stbBatchId.Value = (table.Count != 1 || table[0].IsBatchIDNull()) ? null : table[0].BatchID;
            lblExtendedFilterExists.Text = (table.Count > 1) ? "Заданы фильтр по нескольким товарам (Ctrl+F для просмотра)" : String.Empty;
        }

        /// <summary>
        /// Формирует из XML-структуры таблицу со строками, содержащих код товара (обязательно),
        /// серию (опционально) и партию (опционально)
        /// </summary>
        /// <param name="pXmlString">XML-структура, полученная из конфигурационного файла или searchParameters</param>
        /// <returns>Таблица со строками код товара/серия/партия</returns>
        private static Quality.BL_BlockItemsDataTable FromXml(string pXmlString)
        {
            var table = new Quality.BL_BlockItemsDataTable();
            try
            {
                if (String.IsNullOrEmpty(pXmlString))
                    return table;
                var doc = new XmlDocument();
                doc.LoadXml(String.Format("<{0}>", XML_ROOT_NAME) + pXmlString + String.Format("\n</{0}>", XML_ROOT_NAME));
                foreach (XmlNode node in doc.ChildNodes[0].ChildNodes)
                {
                    var row = table.NewBL_BlockItemsRow();
                    foreach (XmlAttribute attr in node.Attributes)
                        if (attr.Name == XML_ITM_ATTR_NAME)
                            row.ItemID = Convert.ToInt32(attr.Value);
                        else if (attr.Name == XML_RLOT_ATTR_NAME)
                            row.VendorLot = attr.Value;
                        else if (attr.Name == XML_LOTN_ATTR_NAME)
                            row.BatchID = attr.Value;
                    table.AddBL_BlockItemsRow(row);
                }

                return table;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при разборе XML-структуры: ", exc);
                return table;
            }
        }

        /// <summary>
        /// Настройка доступности редакторов дат в зависимости от значений флажков (установка режима "дата не задана")
        /// Сохранение параметров настроек в SearchParameters
        /// </summary>
        private void filter_Changed(object sender, EventArgs e)
        {
            dtpDateFrom.Enabled = chbDateFrom.Checked;
            dtpDateTo.Enabled = chbDateTo.Checked;
        }

        /// <summary>
        /// Сохранение фильтров, настроенных на интерфейсе, в переменную searchParameters (происходит при каждой загрузке товаров)
        /// </summary>
        private void SaveValuesFromFiltersToSearchParameters()
        {
            stbItemID.VerifyValue();
            if (!String.IsNullOrEmpty(stbItemID.Value))
            {
                stbVendorLot.VerifyValue();
                stbBatchId.VerifyValue();
            }

            searchParameters.DateFrom = dtpDateFrom.Enabled ? (DateTime?)dtpDateFrom.Value : null;
            searchParameters.DateTo = dtpDateTo.Enabled ? (DateTime?)dtpDateTo.Value : null;
            searchParameters.ActiveBlocks = rbtAll.Checked ? null : (bool?)(rbtCommitNeeded.Checked ? false : true);
            searchParameters.BlockTypeIds = CheckedBlockTypes;
            searchParameters.WhIds = CheckedWarehouses;
            searchParameters.ItemName = lblItemName.Text;
            searchParameters.XmlData = CreateXmlParamFromFilterForm();
            searchParameters.BlockDocNumber = String.IsNullOrEmpty(tbxDocNumber.Text) ? null : tbxDocNumber.Text;
        }

        /// <summary>
        /// Список через запятую кодов типов блокировок, отмеченных в выпадающем списке типов блокировок (фильтре)
        /// </summary>
        public string CheckedBlockTypes
        {
            get
            {
                var intIds = new List<int>();
                foreach (var item in ccbBlockTypes.CheckedItems)
                    intIds.Add(Convert.ToInt32((item as CCBoxItem).Value));

                string s = String.Empty;
                foreach (Quality.BL_Get_HoldTypesRow row in quality.BL_Get_HoldTypes)
                    if (intIds.Contains(row.Hold_ID_Int))
                    {
                        if (s.Length > 0)
                            s += ",";
                        s += row.Hold_ID;
                    }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        /// <summary>
        /// Список через запятую кодов складов, отмеченных в выпадающем списке складов (фильтре)
        /// </summary>
        public string CheckedWarehouses
        {
            get
            {
                var intIds = new List<int>();
                foreach (var item in ccbWarehouses.CheckedItems)
                    intIds.Add(Convert.ToInt32((item as CCBoxItem).Value));

                string s = String.Empty;
                foreach (Quality.BL_Get_WarehousesRow row in quality.BL_Get_Warehouses)
                    if (intIds.Contains(row.Warehouse_ID_Int))
                    {
                        if (s.Length > 0)
                            s += ",";
                        s += row.Warehouse_ID;
                    }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        /// <summary>
        /// Создание XML-структуры с товарами/сериями/партиями после настройки в окне расширенного фильтра, 
        /// а также по результатам введенных значений в выпадающие справочники кодов товаров, серий и партий на панели фильтров
        /// </summary>
        /// <returns>XML-структура с товарами/сериями/партиями</returns>
        private string CreateXmlParamFromFilterForm()
        {
            var items = filterForm == null ? new List<Quality.BL_BlockItemsRow>() : filterForm.Items;
            if (!String.IsNullOrEmpty(stbItemID.Value))
            {
                var interfaceRow = quality.BL_BlockItems.NewRow() as Quality.BL_BlockItemsRow;
                interfaceRow.ItemID = Convert.ToInt32(stbItemID.Value);
                interfaceRow.VendorLot = stbVendorLot.Value == null ? null : stbVendorLot.Value.Trim();
                interfaceRow.BatchID = stbBatchId.Value == null ? null : stbBatchId.Value.Trim();
                items.Add(interfaceRow);
            }
            var doc = new XmlDocument();
            var root = (XmlElement)doc.AppendChild(doc.CreateElement("Root"));
            foreach (var dbRow in items)
            {
                var row = (XmlElement)root.AppendChild(doc.CreateElement("Row"));
                row.SetAttribute("item_id", dbRow.ItemID.ToString());
                if (!dbRow.IsVendorLotNull() && !String.IsNullOrEmpty(dbRow.VendorLot))
                    row.SetAttribute("vendor_lot", dbRow.VendorLot.Trim());
                if (!dbRow.IsBatchIDNull() && !String.IsNullOrEmpty(dbRow.BatchID))
                    row.SetAttribute("lot_number", dbRow.BatchID.Trim());
            }

            return root.InnerXml;
        }

        /// <summary>
        /// Вызов окна настройки фильтра блокировок
        /// </summary>
        private void btnFilter_Click(object sender, EventArgs e)
        {
            filterForm = new BlocksFilterForm(UserID, FromXml(searchParameters.XmlData));
            if (filterForm.ShowDialog(this) == DialogResult.OK)
            {
                StartBlocksLoading();
                InitializeFilterPanel();
            }
        }

        #endregion

        #region НАСТРОЙКА ДОСТУПОВ НА КНОПКИ

        /// <summary>
        /// True если пользователь имеет права на создание блокировок, False если не имеет
        /// </summary>
        private bool canCreateBlock;

        /// <summary>
        /// True если пользователь имеет права снимать блокировки, False если не имеет
        /// </summary>
        private bool canFinishBlock;

        /// <summary>
        /// True если пользователь имеет права ставить исключения, False если не имеет
        /// </summary>
        private bool canCreateException;

        /// <summary>
        /// True если пользователь имеет права создавать отзывы, False если не имеет
        /// </summary>
        private bool canRecall;

        /// <summary>
        /// True если пользователь имеет права утверждать/отклонять блокировки, False если не имеет
        /// </summary>
        private bool canCommitBlock;

        /// <summary>
        /// True если пользователь имеет право связывать предложения и реальные товары, False если не имеет
        /// </summary>
        private bool canLink;

        /// <summary>
        /// True если пользователь может установить блокировку на выделенные в таблице строки, False если нет.
        /// Устанавливать блокировку можно вообще на любые строки любых уровней
        /// </summary>
        private bool CanCreateBlockForRows { get { return SelectedRows.Count > 0 && canCreateBlock; } }

        /// <summary>
        /// True если пользователь может ставить исключение на выделенные в табилце строки, False если нет.
        /// Ставить исключения можно только на строки, на которых стоит активная блокирока и которые не являются 
        /// блокировкой верхнего уровня
        /// </summary>
        private bool CanCreateExceptionForRows
        {
            get
            {
                if (SelectedRows.Count == 0 || !canCreateException || SelectedRows[0].Ishold_id2Null())
                    return false;

                foreach (var row in SelectedRows)
                    if (row.IslockedNull() || !row.locked || row.Level == 0 ||
                        row.Ishold_id2Null() || 
                        !((SelectedRows[0].Isdate_fromNull() || DateTime.Now >= SelectedRows[0].date_from) &&
                          (SelectedRows[0].Isdate_toNull() || DateTime.Now <= SelectedRows[0].date_to)))
                        return false;
                return true;
            }
        }

        /// <summary>
        /// True если пользователь может снимать блокировку с выделенных в таблице строк, False если нет.
        /// Снимать блокировку можно только с блокировок верхнего уровня, на которых стоит активная блокирока
        /// </summary>
        private bool CanFinishBlockForRows
        {
            get
            {
                if (SelectedRows.Count == 0 || !canFinishBlock || SelectedRows[0].Ishold_id2Null())
                    return false;

                foreach (var row in SelectedRows)
                    if (row.IslockedNull() || !row.locked || row.Level != 0 ||
                        row.Ishold_id2Null() ||
                        !((SelectedRows[0].Isdate_fromNull() || DateTime.Now >= SelectedRows[0].date_from) &&
                          (SelectedRows[0].Isdate_toNull() || DateTime.Now <= SelectedRows[0].date_to)))
                        return false;

                return true;
            }
        }

        /// <summary>
        /// True если пользователь может связывать предложения с товарами, False если нет.
        /// Пользователь может вызвать форму связки товаров только для одной строки, которая имеет признак наличия предложений связки
        /// </summary>
        private bool CanLink
        {
            get
            {
                return SelectedRows.Count == 1 && canLink && 
                    !SelectedRows[0].IsBindingOffersNull() && SelectedRows[0].BindingOffers;
            }
        }

        /// <summary>
        /// Загрузка из БД прав на действия в модуле Блокировок
        /// </summary>
        private void LoadUserAccesses()
        {
            try
            {
                using (var adapter = new BL_AccessTableAdapter())
                {
                    var data = adapter.GetData(UserID);
                    if (data != null && data.Count > 0)
                    {
                        canCreateBlock = GetAccess(data, "canBlock");
                        canFinishBlock = GetAccess(data, "canUNBlock");
                        canCommitBlock = GetAccess(data, "canApproved");
                        canLink = GetAccess(data, "canLink");
                        canCreateException = GetAccess(data, "canException");
                        canRecall = GetAccess(data, "canRecall");
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке прав доступа на действия с блокировками: ", exc);
            }
            finally
            {
                CustomButtons();
            }
        }

        /// <summary>
        /// Получение значение права доступа по его ключу
        /// </summary>
        /// <param name="pAccesses">Таблица с правами доступа</param>
        /// <param name="pKey">Ключ, которых характеризирует получаемое право доступа</param>
        /// <returns>True, если пользователь имеет право доступа, False если не имеет</returns>
        private static bool GetAccess(Quality.BL_AccessDataTable pAccessesTable, string pKey)
        {
            foreach (Quality.BL_AccessRow row in pAccessesTable)
                if (row.Entity_Key == pKey)
                    return row.Entity_Value;

            return false;
        }

        /// <summary>
        /// Настройка доступности кнопок при изменении выделенной строки
        /// </summary>
        private void egvBlocks_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранных в таблице строк
        /// </summary>
        private void CustomButtons()
        {
            btnRecallNotification.Visible = canRecall;
            btnCreateBlockDoc.Visible = canCreateBlock;
            btnCreateBlockForRows.Visible = CanCreateBlockForRows;
            btnCreateExceptionDoc.Visible = canCreateException;
            btnFinishBlockDoc.Visible = canFinishBlock;
            btnCreateExceptionForRows.Visible = CanCreateExceptionForRows;
            btnFinishBlockForRows.Visible = CanFinishBlockForRows;
            btnApproveBlock.Visible = canCommitBlock;
            btnItemOffers.Visible = CanLink;
            tssAfterExcel.Visible = btnCreateBlockDoc.Visible || btnCreateBlockForRows.Visible ||
                btnCreateExceptionDoc.Visible || btnCreateExceptionForRows.Visible || btnFinishBlockDoc.Visible ||
                btnFinishBlockForRows.Visible || btnRecallNotification.Visible;
            tssAfterSet.Visible = btnApproveBlock.Visible || btnItemOffers.Visible;
        }

        #endregion

        #region ТАБЛИЦА БЛОКИРОВОК

        /// <summary>
        /// Инициализация фильтруемого грида с блокировками
        /// </summary>
        private void InitializeBlocksGrid()
        {
            egvBlocks.Init(new BlocksView(), true);
            egvBlocks.UserID = UserID;
            egvBlocks.AllowSummary = false;
            egvBlocks.AllowRangeColumns = true;
            egvBlocks.UseMultiSelectMode = true;
            egvBlocks.DisableSorting();
            egvBlocks.LoadExtraDataGridViewSettings(ConfigTableName);
        }

        /// <summary>
        /// Обновление блокировок по нажатию на кнопку "Обновить"
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            StartBlocksLoading();
        }

        /// <summary>
        /// Запуск асинхронной загрузки блокировок
        /// </summary>
        private void StartBlocksLoading()
        {
            egvBlocks.SaveExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenBlocksLoading(true);
            bgwBlocksLoader = new BackgroundWorker();
            bgwBlocksLoader.DoWork += bgwBlocksLoader_DoWork;
            bgwBlocksLoader.RunWorkerCompleted += bgwBlocksLoader_RunWorkerCompleted;
            SaveValuesFromFiltersToSearchParameters();
            bgwBlocksLoader.RunWorkerAsync(searchParameters);
        }

        /// <summary>
        /// Изменение доступности/видимости элементов управления при начале/окончании асинхронной загрузки блокировок
        /// </summary>
        /// <param name="pStartLoading">True если начало загрузки блокировок, False если окончание загрузки блокировок</param>
        private void PrepareControlsWhenBlocksLoading(bool pStartLoading)
        {
            egvBlocks.Enabled = btnRefresh.Enabled = btnExportToExcel.Enabled = btnRecallNotification.Enabled = 
                btnFilter.Enabled = btnCreateBlockDoc.Enabled = btnCreateBlockForRows.Enabled =
                btnCreateExceptionDoc.Enabled = btnCreateExceptionForRows.Enabled = btnFinishBlockDoc.Enabled =
                btnFinishBlockForRows.Enabled = btnApproveBlock.Enabled = btnItemOffers.Enabled = !pStartLoading;
            pbSplashControl.Visible = btnCancelLoading.Visible = pStartLoading;
        }

        /// <summary>
        /// Асинхронная загрузка блокировок
        /// </summary>
        private void bgwBlocksLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var sc = e.Argument as BlocksSearchParameters;
                    using (var adapter = new BL_Get_HoldsTableAdapter())
                        e.Result = adapter.GetData(sc.SessionID, sc.DateFrom, sc.DateTo, sc.ActiveBlocks, sc.WhIds,
                            sc.BlockTypeIds, sc.XmlData, null, sc.UseExpandedMode, sc.BlockDocNumber);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки блокировок и их отображение в гриде
        /// </summary>
        private void bgwBlocksLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке блокировок:", e.Result as Exception);
            else
                RefreshDataViewBinding(e.Result as Quality.BL_Get_HoldsDataTable);

            egvBlocks.LoadExtraDataGridViewSettings(ConfigTableName);
            PrepareControlsWhenBlocksLoading(false);
        }

        /// <summary>
        /// Отображение загруженных блокировок в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Таблица с блокировками, которые нужно отобразить в гриде</param>
        private void RefreshDataViewBinding(Quality.BL_Get_HoldsDataTable pData)
        {
            try
            {
                (egvBlocks.DataView as BlocksView).FillData(pData);
                egvBlocks.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения блокировок: ", exc);
            }
        }

        /// <summary>
        /// Отмена текущей асинхронной загрузки блокировок
        /// </summary>
        private void btnCancelLoading_Click(object sender, EventArgs e)
        {
            PrepareControlsWhenBlocksLoading(false);
            bgwBlocksLoader.RunWorkerCompleted -= bgwBlocksLoader_RunWorkerCompleted;
            bgwBlocksLoader = null;
        }

        /// <summary>
        /// Раскрашивание строк и отображение их разными шрифтами в зависимости от состояния блокировки
        /// </summary>
        private void egvBlocks_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                var dbRow = (row.DataBoundItem as DataRowView).Row as Quality.BL_Get_HoldsRow;
                var color = GetBlockRowColor(dbRow);
                if (!dbRow.Ishold_idNull() || (dbRow.IslockedNull() && dbRow.parentRows == DBNull.Value))
                    row.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(204)));
                for (int c = 0; c < row.Cells.Count; c++)
                    if (dbRow.expandedColIndex == c)
                    {
                        row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionBackColor = Color.Yellow;
                        row.Cells[c].Style.SelectionForeColor = Color.Black;
                    }
                    else
                    {
                        row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = color;
                        row.Cells[c].Style.SelectionBackColor = row.Cells[0].Style.SelectionBackColor;
                    }

                SetBindingOffersIcons(row);
            }
        }

        /// <summary>
        /// Определение цвета, которым должна отображаться строка блокировки
        /// </summary>
        /// <param name="pBlockRow">Строка блокировки, для которой определяем цвет</param>
        /// <returns>Цвет, которым нужно отображать в гриде строку блокировки</returns>
        private static Color GetBlockRowColor(Quality.BL_Get_HoldsRow pBlockRow)
        {
            if (pBlockRow.IslockedNull())
                return Color.White;
            else if (!pBlockRow.IsapprovedNull() && pBlockRow.approved)
                return Color.LightBlue;
            else if ((pBlockRow.Isdate_fromNull() || DateTime.Now >= pBlockRow.date_from) &&
                (pBlockRow.Isdate_toNull() || DateTime.Now <= pBlockRow.date_to))
                return pBlockRow.locked ? Color.LightCoral : Color.Green;
            else
                return Color.LightGray;
        }

        /// <summary>
        /// Установка пиктограммы для строки, если в ней есть предложение связать товары
        /// </summary>
        /// <param name="pDgvRow">Строка в датагриде, которую проверяем</param>
        private void SetBindingOffersIcons(DataGridViewRow pDgvRow)
        {
            var dgv = pDgvRow.DataGridView;
            var dbRow = (pDgvRow.DataBoundItem as DataRowView).Row as Quality.BL_Get_HoldsRow;
            foreach (DataGridViewColumn column in dgv.Columns)
                if (column is DataGridViewImageColumn && column.Tag != null)
                {
                    (column as DataGridViewImageColumn).ImageLayout = DataGridViewImageCellLayout.Zoom;
                    if (!dbRow.IsBindingOffersNull() && dbRow.BindingOffers)
                        dgv.Rows[pDgvRow.Index].Cells[column.Index].Value = Properties.Resources.dialog_question;
                    else
                        dgv.Rows[pDgvRow.Index].Cells[column.Index].Value = null;
                }
        }

        /// <summary>
        /// Экспорт блокировок, отображенных в гриде, в Excel
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                egvBlocks.ExportToExcel("Экспорт блокировок в Excel", "блокировки", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время экспорта таблицы блокировок в Excel: ", exc);
            }
        }

        #endregion

        #region РАЗВОРАЧИВАНИЕ/СВОРАЧИВАНИЕ ТАБЛИЦЫ

        /// <summary>
        /// Строка, которая выводится в колонке "Серия" в случае, если блокировка распространяется на все серии
        /// </summary>
        private const string ALL_VENDOR_LOTS = "Все серии";

        /// <summary>
        /// Строка, которая выводится в колонке "Партия" в случае, если блокировка распространяется на все партии
        /// </summary>
        private const string ALL_BATCH_IDS = "Все партии";

        /// <summary>
        /// Строка, которая выводится в колонке "Склад" в случае, если блокировка распространяется на все склады
        /// </summary>
        private const string ALL_WAREHOUSES = "Все склады";

        /// <summary>
        /// Индекс колонки с сериями
        /// </summary>
        private const int VENDOR_LOT_COL_INDEX = 7;

        /// <summary>
        /// Индекс колонки с партиями
        /// </summary>
        private const int BATCH_ID_COL_INDEX = 8;

        /// <summary>
        /// Индекс колонки с складами
        /// </summary>
        private const int WAREHOUSE_COL_INDEX = 9;

        /// <summary>
        /// Индекс колонки с комментарием
        /// </summary>
        private const int COMMENT_COL_INDEX = 17;

        /// <summary>
        /// Значение DefaultColIndex, используемое если строка не развернута вообще
        /// </summary>
        private const int DEFAULT_EXPANDED_COL_INDEX = -1;

        /// <summary>
        /// Разворачивание/сворачивание таблицы двойным щелчком на блокировке
        /// </summary>
        private void egvBlocks_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            int columnIndex = dgv.Columns[e.ColumnIndex].Index;
            if (columnIndex == VENDOR_LOT_COL_INDEX || columnIndex == BATCH_ID_COL_INDEX || columnIndex == WAREHOUSE_COL_INDEX)
            {
                var dbRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Quality.BL_Get_HoldsRow;
                if (dbRow.expandedColIndex == columnIndex)
                    CutDownExpandedRows(dbRow);
                else if (CanExpand(dbRow, columnIndex))
                    ExpandRow(dbRow, columnIndex);
                dgv.Refresh();
            }
            else if (columnIndex == COMMENT_COL_INDEX)
            {
                var dbRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Quality.BL_Get_HoldsRow;
                ShowCommentForm(dbRow);
            }

        }

        /// <summary>
        /// Сворачивание развертки
        /// </summary>
        /// <param name="pRow">Развернутая строка, которую нужно свернуть</param>
        private void CutDownExpandedRows(Quality.BL_Get_HoldsRow pRow)
        {
            try
            {
                var holdsTable = pRow.Table as Quality.BL_Get_HoldsDataTable;
                int rowIndex = holdsTable.Rows.IndexOf(pRow);
                var tempList = new List<DataRow>();
                foreach (Quality.BL_Get_HoldsRow holdsRow in holdsTable)
                    if (!holdsRow.IsparentRowsNull() && (holdsRow.parentRows as List<Quality.BL_Get_HoldsRow>).Contains(pRow))
                        tempList.Add(holdsRow);
                tempList.ForEach(delegate(DataRow pDelRow) { pDelRow.Delete(); });
                holdsTable.AcceptChanges();
                pRow.expandedColIndex = DEFAULT_EXPANDED_COL_INDEX;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при свертывании строки. Рекомендуется обновить таблицу блокировок.", exc);
            }
        }

        /// <summary>
        /// Разворачивание заданной строки по заданной колонке
        /// </summary>
        /// <param name="pRow">Строка, которую нужно развернуть</param>
        /// <param name="pExpandedColIndex">Индекс колонки, по которой нужно развернуть строку</param>
        private void ExpandRow(Quality.BL_Get_HoldsRow pRow, int pExpandedColIndex)
        {
            try
            {
                using (var adapter = new BL_Get_HoldsTableAdapter())
                {
                    var table = adapter.GetData(UserID, searchParameters.DateFrom, searchParameters.DateTo, searchParameters.ActiveBlocks,
                        pRow.Iswarehouse_idNull() ? String.Empty : pRow.warehouse_id, searchParameters.BlockTypeIds, CreateXml(pRow),
                        pRow.Ishold_id2Null() ? -1 : (int)pRow.hold_id2, 
                        pExpandedColIndex == VENDOR_LOT_COL_INDEX ? 1 : (pExpandedColIndex == BATCH_ID_COL_INDEX ? 2 : 3),
                        searchParameters.BlockDocNumber);
                    var data = egvBlocks.DataView.Data as Quality.BL_Get_HoldsDataTable;
                    int index = pRow.Table.Rows.IndexOf(pRow);
                    foreach (Quality.BL_Get_HoldsRow drow in table)
                    {
                        var newRow = data.NewRow() as Quality.BL_Get_HoldsRow;
                        newRow.ItemArray = drow.ItemArray.Clone() as object[];
                        if (newRow.IsparentRowsNull() || newRow.parentRows == DBNull.Value)
                            newRow.parentRows = new List<Quality.BL_Get_HoldsRow>();
                        (newRow.parentRows as List<Quality.BL_Get_HoldsRow>).Add(pRow);
                        if (!pRow.IsparentRowsNull())
                            (newRow.parentRows as List<Quality.BL_Get_HoldsRow>).AddRange(pRow.parentRows as List<Quality.BL_Get_HoldsRow>);
                        data.Rows.InsertAt(newRow, ++index);
                    }

                    pRow.expandedColIndex = pExpandedColIndex;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при развертывании строки. Рекомендуется обновить таблицу блокировок.", exc);
            }
        }

        /// <summary>
        /// Проверка, можно ли разворачивать заданную строку по заданной колонке
        /// </summary>
        /// <param name="pRow">Строка, возможность развертывания которой проверяется</param>
        /// <param name="pExpandedColIndex">Индекс колонки, по которой развертыается строка</param>
        /// <returns>True если строку можно развернуть по заданной колонке, 
        /// False если развертывание по заданной колонке не имеет смысла</returns>
        private bool CanExpand(Quality.BL_Get_HoldsRow pRow, int pExpandedColIndex)
        {
            if (pRow.expandedColIndex != DEFAULT_EXPANDED_COL_INDEX)
                return false;   // Нельзя развернуть уже развернутую строку

            if (pExpandedColIndex == VENDOR_LOT_COL_INDEX && !(pRow.Isvendor_lotNull() || pRow.vendor_lot == null ||
                pRow.vendor_lot == ALL_VENDOR_LOTS))
                return false;   // Нельзя развернуть по серии, если серия жестко указана
            else if (pExpandedColIndex == BATCH_ID_COL_INDEX && !(pRow.Islot_numberNull() || pRow.lot_number == null ||
                pRow.lot_number == ALL_BATCH_IDS))
                return false;   // Нельзя развернуть по партии, если партия жестко указана
            else if (pExpandedColIndex == WAREHOUSE_COL_INDEX && !(pRow.Iswarehouse_idNull() || pRow.warehouse_id == null ||
                pRow.warehouse_id == ALL_WAREHOUSES))
                return false;   // Нельзя развернуть по партии, если партия жестко указана

            return true;    // Строку можно развернуть
        }

        /// <summary>
        /// Формирование XML-структуры товар/серия/партия для разворачиваемой строки
        /// </summary>
        /// <param name="pRow">Строка, которая разворачивается</param>
        /// <returns>XML-фильтр, который характиризует разворачиваемую строку</returns>
        private string CreateXml(Quality.BL_Get_HoldsRow pRow)
        {
            var doc = new XmlDocument();
            var row = (XmlElement)doc.AppendChild(doc.CreateElement("Row"));
            row.SetAttribute(XML_ITM_ATTR_NAME, pRow.item_id.ToString());
            if (pRow.vendor_lot.Trim() != ALL_VENDOR_LOTS)
                row.SetAttribute(XML_RLOT_ATTR_NAME, pRow.vendor_lot.Trim());
            if (pRow.lot_number.Trim() != ALL_BATCH_IDS)
                row.SetAttribute(XML_LOTN_ATTR_NAME, pRow.lot_number.Trim());
            return doc.InnerXml;
        }

        /// <summary>
        /// Отображение окна с комментарием по двойному клику на ячейку с комментарием
        /// </summary>
        /// <param name="pHoldRow">Блокировка, для которой нужно отобразить комментарий</param>
        private void ShowCommentForm(Quality.BL_Get_HoldsRow pHoldRow)
        {
            if (pHoldRow.IsdescriptionNull() || String.IsNullOrEmpty(pHoldRow.description))
                return;
            var form = new CommentForm(true) { Text = "Комментарий", Comment = pHoldRow.description };
            form.ShowDialog(this);
        }

        #endregion

        #region УСТАНОВКА/СНЯТИЕ БЛОКИРОВКИ

        /// <summary>
        /// Обработчик для кнопок с действиями блокировок (установка, прекращение, установка исключения)
        /// </summary>
        private void btnBlockAction_Click(object sender, EventArgs e)
        {
            BlockActionType mode;
            if (sender == btnCreateBlockDoc || sender == btnCreateBlockForRows)
                mode = BlockActionType.CreateBlock;
            else if (sender == btnCreateExceptionDoc || sender == btnCreateExceptionForRows)
                mode = BlockActionType.CreateException;
            else
                mode = BlockActionType.FinishBlock;
            var table = (sender == btnCreateBlockForRows || sender == btnCreateExceptionForRows || sender == btnFinishBlockForRows) ?
                CreateSelectedItemsTable(mode) : new Quality.BL_Block_Document_ItemsDataTable();
            var window = new BlockDocumentEditForm(UserID, mode, table);
            window.ShowDialog(this);
        }

        /// <summary>
        /// Получение таблицы с выделенными строками для передачи в окно создания блокировки
        /// </summary>
        /// <param name="pActionType">Режим - установка блокировки, снятие блокировки либо создание исключения</param>
        /// <returns>Таблица, содержащая информацию по выделенным строкам</returns>
        private Quality.BL_Block_Document_ItemsDataTable CreateSelectedItemsTable(BlockActionType pActionType)
        {
            var table = new Quality.BL_Block_Document_ItemsDataTable();
            foreach (var selectedRow in SelectedRows)
            {
                var tableRow = table.NewBL_Block_Document_ItemsRow();
                tableRow.Item_ID = selectedRow.item_id;
                tableRow.VendorLot = selectedRow.Isvendor_lotNull() ? BlockDocumentEditForm.ALL_VENDOR_LOTS : selectedRow.vendor_lot;
                tableRow.BatchID = selectedRow.Islot_numberNull() ? BlockDocumentEditForm.ALL_BATCH_IDS : selectedRow.lot_number;
                tableRow.Warehouse_ID = selectedRow.Iswarehouse_idNull() ? BlockDocumentEditForm.ALL_WAREHOUSES : selectedRow.warehouse_id;
                if (pActionType != BlockActionType.CreateBlock)
                {
                    tableRow.HoldTypeID = selectedRow.hold_type_id;
                    tableRow.parent_hold_id = selectedRow.hold_id2.ToString();
                    tableRow.Doc_ID = selectedRow.doc_id.ToString();
                }
                
                tableRow.DateFrom = selectedRow.Isdate_fromNull() ? DateTime.Now : selectedRow.date_from;
                if (!selectedRow.Isdate_toNull())
                    tableRow.DateTo = selectedRow.date_to;
                if (!selectedRow.IsExpiration_DateNull())
                    tableRow.Expiration_Date = selectedRow.Expiration_Date;
                table.AddBL_Block_Document_ItemsRow(tableRow);
            }

            return table;
        }

        /// <summary>
        /// Создание уведомления об отзыве
        /// </summary>
        private void btnRecallNotification_Click(object sender, EventArgs e)
        {
            var window = new BlockDocumentEditForm(UserID, BlockActionType.RecallNotification, new Quality.BL_Block_Document_ItemsDataTable());
            window.ShowDialog(this);
        }

        #endregion

        #region УТВЕРЖДЕНИЕ БЛОКИРОВКИ И СВЯЗКА ТОВАРОВ

        /// <summary>
        /// Утверждение блокировок (которые требуют утверждения) в отдельном окне
        /// </summary>
        private void btnApproveBlock_Click(object sender, EventArgs e)
        {
            var form = new BlockDocsApproveForm(UserID);
            form.ShowDialog(this);
            if (form.WasChanges)
                StartBlocksLoading();
        }

        /// <summary>
        /// 
        /// </summary>
        private void btnItemOffers_Click(object sender, EventArgs e)
        {
            var form = new ItemOffersForm(UserID, SelectedRows[0].hold_id);
            if (form.ShowDialog(this) == DialogResult.OK)
                StartBlocksLoading();
        }

        #endregion
    }

    #region КЛАССЫ ДЛЯ ПОДДЕРЖКИ ФИЛЬТРУЕМОГО ГРИДА БЛОКИРОВОК

    /// <summary>
    /// Представление для грида с блокировками
    /// </summary>
    public class BlocksView : IDataView
    {
        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Таблица данных, содержащая блокировки
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Таблица данных, содержащая блокировки
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Заполнение таблицы блокировок согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as BlocksSearchParameters;
            using (var adapter = new BL_Get_HoldsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.DateFrom, sc.DateTo, sc.ActiveBlocks,
                    sc.WhIds, sc.BlockTypeIds, sc.XmlData, null, sc.UseExpandedMode, sc.BlockDocNumber);
        }

        /// <summary>
        /// Установка источника для грида блокировок
        /// </summary>
        /// <param name="pDataTable">Таблица с блокировками</param>
        public void FillData(Quality.BL_Get_HoldsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public BlocksView()
        {
            this.dataColumns.Add(new PatternColumn("ID блокировки", "hold_id", new FilterCompareExpressionRule<Int64>("hold_id"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new ImagePatternColumn(String.Empty, "BindingOffers") { Width = 40 });
            this.dataColumns.Add(new PatternColumn("Тип", "hold_type_id", new FilterPatternExpressionRule("hold_type_id"), SummaryCalculationType.Count) { Width = 30 });
            this.dataColumns.Add(new PatternColumn("Описание типа", "hold_type_name", new FilterPatternExpressionRule("hold_type_name"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Код товара", "item_id", new FilterCompareExpressionRule<Int64>("item_id"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "item_name", new FilterPatternExpressionRule("item_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Производитель", "Manufacturer", new FilterPatternExpressionRule("Manufacturer"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Серия", "vendor_lot", new FilterPatternExpressionRule("vendor_lot"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Срок годности", "Expiration_Date", new FilterDateCompareExpressionRule("Expiration_Date"), SummaryCalculationType.Count) { Width = 80 }); 
            this.dataColumns.Add(new PatternColumn("Партия", "lot_number", new FilterPatternExpressionRule("lot_number"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Склад", "warehouse_name", new FilterPatternExpressionRule("warehouse_name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Дата с", "date_from", new FilterDateCompareExpressionRule("date_from"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата по", "date_to", new FilterDateCompareExpressionRule("date_to"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Установлено", "user", new FilterPatternExpressionRule("user"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Номер документа", "doc_number", new FilterPatternExpressionRule("doc_number"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата документа", "doc_date", new FilterDateCompareExpressionRule("doc_date"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Номер уведомления", "notification_number", new FilterPatternExpressionRule("notification_number"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Дата уведомления", "notification_date", new FilterDateCompareExpressionRule("notification_date"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Описание", "description", new FilterPatternExpressionRule("description"), SummaryCalculationType.Count) { Width = 200 });
            
        }
    }

    /// <summary>
    /// Параметры получения списка блокировок
    /// </summary>
    public class BlocksSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }

        /// <summary>
        /// Начало периода времени, за который загружаются блокировки, либо null если период времени не ограничен снизу
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Конец периода времени, за который загружаются блокировки, либо null если период времени не ограничен сверху
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// True - загружаются только действующие блокировки, False - загружаются блокировки, ожидающие утверждения,
        /// NULL - загружаются все блокировки
        /// </summary>
        public bool? ActiveBlocks { get; set; }

        /// <summary>
        /// DelimetedList который содержит идентификаторы типов блокировок, которые нужно загрузить
        /// </summary>
        public string BlockTypeIds { get; set; }

        /// <summary>
        /// DelimetedList который содержит идентификаторы складов, на которые распространяется блокировка
        /// </summary>
        public string WhIds { get; set; }

        /// <summary>
        /// Данные о товарах, сериях, партиях и складах
        /// </summary>
        public string XmlData { get; set; }

        /// <summary>
        /// True если показывать построчно все товары, подпадающие под фильтры
        /// False если показывать только блокировки/исключения
        /// </summary>
        public int UseExpandedMode { get; set; }

        /// <summary>
        /// Название товара (в процедуры не передается, но служит для информативных целей)
        /// </summary>
        public string ItemName { get; set; }

        /// <summary>
        /// Номер документа блокировки либо null, если он не задан в фильтре
        /// </summary>
        public string BlockDocNumber { get; set; }
    }

    #endregion
}
