using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

using CrystalDecisions.Shared;

using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;
using WMSOffice.Data;
using WMSOffice.Data.InventoryTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Dialogs.Inventory;
using WMSOffice.Reports;
using WMSOffice.Controls;
using System.Text;

namespace WMSOffice.Window
{
    /// <summary>
    /// Форма для отображения и управления инвентаризациями филиалов
    /// </summary>
    public partial class InventoryFilialViewWindow : GeneralWindow
    {
        #region КОНСТАНТЫ

        /// <summary>
        /// Признак инвентаризации дорогостоя
        /// </summary>
        private const string HIGH_COST_INVENTORY_TYPE = "HC";

        /// <summary>
        /// Признак инвентаризации дорогостоя (этаж 2)
        /// </summary>
        private const string HIGH_COST_INVENTORY_FLOOR_2_TYPE = "H2";

        /// <summary>
        /// Признак инвентаризации дорогостоя (этаж 3)
        /// </summary>
        private const string HIGH_COST_INVENTORY_FLOOR_3_TYPE = "H3";

        /// <summary>
        /// Признак инвентаризации дорогостоя (этаж 4)
        /// </summary>
        private const string HIGH_COST_INVENTORY_FLOOR_4_TYPE = "H4";

        /// <summary>
        /// Признак инвентаризации дорогостоя в зоне БП2
        /// </summary>
        private const string HIGH_COST_INVENTORY_BP2_TYPE = "PB";

        /// <summary>
        /// Признак инвентаризации Наркоз
        /// </summary>
        private const string NARKOZ_INVENTORY_TYPE = "PN";

        /// <summary>
        /// Признак инвентаризации ПКУ
        /// </summary>
        private const string PKU_INVENTORY_TYPE = "PK";

        /// <summary>
        /// Признак инвентаризации ОТ
        /// </summary>
        private const string CLIENT_TARE_INVENTORY_TYPE = "RT";

        #endregion

        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Режим архива
        /// </summary>
        public bool IsArchiveMode { get; private set; }

        /// <summary>
        /// Идентификатор выбранной инвентаризации (в случае, если выбрано несколько строк, возвращается идентификатор первой из них).
        /// Если таблица пустая либо в ней не выбрана ни одна инвентаризация, будет сгенерировано исключение
        /// </summary>
        private long SelectedDocId { get { return Convert.ToInt32(dgvInventories.SelectedItem["Inventory_number"]); } }

        /// <summary>
        /// True, если в таблице инвентаризаций выделена хотя бы одна строка а если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одной строки, либо выделено несколько
        /// инвентаризаций на разных статусах
        /// </summary>
        private bool IsDocSelected
        {
            get
            {
                if (dgvInventories.SelectedItem == null)
                    return false;
                int status = SelectedDoc.Status_ID;
                foreach (var doc in SelectedDocs)
                    if (doc.Status_ID != status)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Выбранная инвентаризация в таблице либо null, если таблица пустая или в ней не выбрано ни одной инвентаризации.
        /// Если в таблице выделено несколько инвентаризаций, то возвращается первая из них
        /// </summary>
        private Inventory.FI_Get_Inventory_ListsRow SelectedDoc
        {
            get { return dgvInventories.SelectedItem as Inventory.FI_Get_Inventory_ListsRow; }
        }

        /// <summary>
        /// Коллекция номеров инвентаризаций, выделенных в таблице. Если не выделена ни одна инвентаризация, то коллекция пуста
        /// </summary>
        private List<long> SelectedDocIds
        {
            get
            {
                var ids = new List<long>();
                foreach (var doc in SelectedDocs)
                    ids.Add(doc.Inventory_number);
                return ids;
            }
        }

        /// <summary>
        /// Коллекция инвентаризаций, выделенных в таблице. Если не выделена ни одна инвентаризация, то коллекция пуста
        /// </summary>
        private IEnumerable<Inventory.FI_Get_Inventory_ListsRow> SelectedDocs
        {
            get
            {
                return
                    dgvInventories.SelectedItems.ConvertAll(
                    new Converter<DataRow, Inventory.FI_Get_Inventory_ListsRow>(x => x as Inventory.FI_Get_Inventory_ListsRow));
            }
        }

        /// <summary>
        /// Название таблицы с инвентаризациями в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Header", Name); } }

        /// <summary>
        /// БД адаптер для работы с инвентаризациями
        /// </summary>
        private FI_Get_Inventory_ListsTableAdapter adapter = new FI_Get_Inventory_ListsTableAdapter();

        /// <summary>
        /// Форма ожидания, которая появляется во время длительных операций
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialViewWindow(bool isArchiveMode)
        {
            InitializeComponent();

            this.IsArchiveMode = isArchiveMode;

            InitializeInventoryGrid();
            InitializeCalcSheetsGrid();
            InitPrinters();
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с накладными при создании окна
        /// </summary>
        private void InitializeInventoryGrid()
        {
            dgvInventories.Init(new InventoryFilialView(this.IsArchiveMode), true);
            dgvInventories.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInventories.UserID = UserID;
            dgvInventories.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInventories.AllowRangeColumns = true;
            dgvInventories.UseMultiSelectMode = true;

            dgvInventories.OnFilterChanged += dgvInventories_OnFilterChanged;
            dgvInventories.OnRowSelectionChanged += dgvInventories_OnRowSelectionChanged;
            dgvInventories.OnRowDoubleClick += dgvInventories_OnRowDoubleClick;

            // активация постраничного просмотра
            dgvInventories.CreatePageNavigator();
        }

        /// <summary>
        /// Загрузка инвентаризаций при загрузке окна
        /// </summary>
        private void InventoryFilialViewWindow_Load(object sender, EventArgs e)
        {
            Config.LoadDataGridViewSettings(ConfigCalcsTableName, dgvCalcs);

            CustomButtons();
            CustomCalcListsButtons();
            CustomCalcsContextMenu();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Initialize();

            if (!this.IsArchiveMode)
                RefreshDocs();
        }

        private void Initialize()
        {
            if (this.IsArchiveMode)
            {
                stbFilial.ValueReferenceQuery = "[dbo].[pr_FA_Get_Filials]";
                stbFilial.UserID = this.UserID;
                stbFilial.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

                stbInventoryType.ValueReferenceQuery = "[dbo].[pr_FA_Get_FI_Types]";
                stbInventoryType.UserID = this.UserID;
                stbInventoryType.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

                var today = DateTime.Today;
                dtpPeriodFrom.Value = new DateTime(today.Year, today.Month, 1);
                dtpPeriodTo.Value = new DateTime(today.Year, today.Month, today.Day);
            }
            else
            {
                pnlFilter.Height = 0;
                pnlFilter.Visible = false;
            }
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbFilial)
                lblDescription = tbFilial;
            else if (control == stbInventoryType)
                lblDescription = tbInventoryType;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                RefreshDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Обновление данных в таблице инвентаризаций с сохранением выделения и прокрутки
        /// </summary>
        private void RefreshDocs()
        {
            dgvInventories.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            var selectedDocIds = SelectedDocIds;

            RefreshDataViewBinding();

            dgvInventories.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInventories.UnselectAllRows();

            bool isSelected = false;
            foreach (var id in selectedDocIds)
            {
                dgvInventories.SelectRow("Inventory_number", id.ToString());
                isSelected = true;
            }

            if (!isSelected)
                dgvInventories.SelectRow(0);

            dgvInventories.ScrollToSelectedRow();
            CustomButtons();
        }

        /// <summary>
        /// Загрузка инвентаризаций в фильтруемый грид из БД
        /// </summary>
        private void RefreshDataViewBinding()
        {
            try
            {
                var sessionID = this.UserID;
                var filialID = (string)null;
                var periodFrom = (DateTime?)null;
                var periodTo = (DateTime?)null;
                var inventoryType = (string)null;

                if (this.IsArchiveMode)
                {
                    var hasFilial = true;
                    if (string.IsNullOrEmpty(stbFilial.Value))
                        hasFilial = false;
                    else
                    {
                        filialID = stbFilial.Value;
                    }

                    var hasInventoryType = true;
                    if (string.IsNullOrEmpty(stbInventoryType.Value))
                        hasInventoryType = false;
                    else
                    {
                        inventoryType = stbInventoryType.Value;
                    }

                    if (!hasFilial && !hasInventoryType)
                        throw new Exception("\nХотя бы одно из двух полей должно быть заполнено:\n - Филиал\n - Тип инвентаризации");


                    if (dtpPeriodFrom.Value.Date > dtpPeriodTo.Value.Date)
                        throw new Exception("\nНачальный период не должен превышать конечный.");
                    else
                    {
                        periodFrom = dtpPeriodFrom.Value.Date;
                        periodTo = dtpPeriodTo.Value.Date;
                    }
                }

                var loadworker = new BackgroundWorker();
                loadworker.DoWork += (s, e) =>
                {
                    try
                    {
                        dgvInventories.DataView.FillData(new InventoryFilialSearchParameters() 
                        { 
                            SessionID = UserID, 
                            FilialID = filialID, 
                            PeriodFrom = periodFrom, 
                            PeriodTo = periodTo, 
                            InventoryType = inventoryType 
                        });
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };

                loadworker.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        dgvInventories.BindData(false);

                    splashForm.CloseForce();

                };

                splashForm.ActionText = "Выполняется загрузка данных..";
                loadworker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить список инвентаризаций: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvInventories_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvInventories.RecalculateSummary();
        }

        /// <summary>
        /// Обновление статусов кнопок при изменении выделенной инвентаризации
        /// </summary>
        private void dgvInventories_OnRowSelectionChanged(object sender, EventArgs e)
        {
            LoadCalculations();
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранной инвентаризации
        /// </summary>
        private void CustomButtons()
        {
            btnAddInventory.Visible = miAddInventory.Enabled = !this.IsArchiveMode;
            btnRunChecks.Visible = miRunChecks.Enabled = !this.IsArchiveMode;
            btnRunAutoChecks.Visible = !this.IsArchiveMode;

            tssAfterRefresh.Visible = !this.IsArchiveMode;
            tssAfterEdit.Visible = !this.IsArchiveMode;

            btnDeleteInventory.Visible = miDeleteInventory.Enabled = IsDocSelected && SelectedDoc.Status_ID < 133 && !this.IsArchiveMode;
            btnToWork.Visible = miToWork.Enabled = IsDocSelected && SelectedDoc.Status_ID == 100 && !this.IsArchiveMode;
            btnEditInventory.Visible = miEditInventory.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID < 110 && !this.IsArchiveMode;
            btnSigners.Visible = miSigners.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && !this.IsArchiveMode;
            btnCloseInventory.Visible = miCloseInventory.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID == 125 && !this.IsArchiveMode;
            btnCreateCalc.Visible = miCreateCalc.Enabled = CanCreateCalc && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID == 125 && !this.IsArchiveMode;

            miExportInvenrotyResults.Enabled = /*IsDocSelected &&*/ SelectedDocIds.Count >= 1 && CheckCanExportInventoryResults();
            miInventoryListPrint.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            miExportInventorySheetToExcel.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            
            btnPeresorts.Visible = miPeresorts.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID == 132;
            btnReplacings.Visible = miReplacings.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID == 136;

            miExportPeresort.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            miExportMoving.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            miExportSurpluses.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            miExportDifferences.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 138;
            miExportCalcListsData.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID >= 125;
            miExportBonuses.Enabled = IsDocSelected && SelectedDocIds.Count == 1;

            sbPlanResources.Visible = IsDocSelected && SelectedDocIds.Count == 1 && !this.IsArchiveMode;
            sbInventoryMonitoring.Visible = IsDocSelected && SelectedDocIds.Count == 1 && !this.IsArchiveMode;
        }

        private bool CheckCanExportInventoryResults()
        {
            //return SelectedDoc.Status_ID >= 125;

            foreach (var doc in SelectedDocs)
                if (doc.Status_ID >= 125)
                    return true;

            return false;
        }

        /// <summary>
        /// Перезагрузка таблицы пересчетов для выбранной инвентаризации
        /// </summary>
        private void LoadCalculations()
        {
            try
            {
                Config.SaveDataGridViewSettings(ConfigCalcsTableName, dgvCalcs);
                if (dgvInventories.SelectedItems.Count == 1)
                {
                    if (this.IsArchiveMode)
                        taFiRecalculations.FillArchive(inventory.FI_Recalculations, UserID, SelectedDocId);
                    else
                        taFiRecalculations.Fill(inventory.FI_Recalculations, UserID, SelectedDocId);

                    Config.LoadDataGridViewSettings(ConfigCalcsTableName, dgvCalcs);
                }
                else
                    inventory.FI_Recalculations.Clear();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить пересчеты для выбранной инвентаризации!" + Environment.NewLine + exc.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Сохранение состояния колонок таблицы актов скидок при закрытии окна
        /// </summary>
        private void InventoryFilialViewWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvInventories.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            dgvCalcLists.SaveExtraDataGridViewSettings(ConfigCalcListsTableName);
            Config.SaveDataGridViewSettings(ConfigCalcsTableName, dgvCalcs);
        }

        /// <summary>
        /// Обновление данных в таблице инвентаризаций филиалов
        /// </summary>
        private void btnRefreshInventories_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Инициализация списка доступных принтеров
        /// </summary>
        private void InitPrinters()
        {
            try
            {
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                    cbPrinters.Items.Add(printerName);

                var tmpSettings = new PrinterSettings();
                cbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        #endregion

        #region СОЗДАНИЕ И РЕДАКТИРОВАНИЕ ИНВЕНТАРИЗАЦИИ

        /// <summary>
        /// Создание новой инвентаризации
        /// </summary>
        private void btnAddInventory_Click(object sender, EventArgs e)
        {
            var window = new InventoryFilialEditForm(UserID) { Owner = this };
            window.ShowDialog();
            if (window.WasChangesMade)
                RefreshDocs();
        }

        /// <summary>
        /// Редактирование инвентаризации
        /// </summary>
        private void btnEditInventory_Click(object sender, EventArgs e)
        {
            EditInventory();
        }

        /// <summary>
        /// Редактирование инвентаризации, выделенной в таблице
        /// </summary>
        private void EditInventory()
        {
            var window = new InventoryFilialEditForm(UserID, SelectedDoc) { Owner = this };
            window.ShowDialog();
            if (window.WasChangesMade)
                RefreshDocs();
        }

        /// <summary>
        /// Редактирование инвентаризации по двойному клику
        /// </summary>
        private void dgvInventories_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID < 110)
                EditInventory();
        }

        /// <summary>
        /// Удаление инвентаризации
        /// </summary>
        private void btnDeleteInventory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Все выбранные инвентаризации будут удалены и их дальнейшее продвижение по статусам будет невозможно. " +
                Environment.NewLine + "Продолжить операцию?", "Удаление инвентаризации",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (var inv in SelectedDocs)
                try
                {
                    adapter.DeleteEmptyInventory(UserID, SelectedDocId);
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Не удалось удалить инвентаризацию №{0}: ", inv.Inventory_number) + 
                        Environment.NewLine + exc.Message);
                }

            RefreshDocs();
        }

        /// <summary>
        /// Редактирование даты/номера приказа и членов комиссии по нажатию на соответствующую кнопку
        /// </summary>
        private void btnSigners_Click(object sender, EventArgs e)
        {
            var window = new InventoryFilialEnterSignersForm(SelectedDoc, UserID);
            window.ShowDialog(this);
            RefreshDocs();
        }

        #endregion

        #region ВЫПОЛНЕНИЕ ПРОВЕРОК ИНВЕНТАРИЗАЦИИ

        /// <summary>
        /// Выполнение проверок инвентаризации
        /// </summary>
        private void btnRunChecks_Click(object sender, EventArgs e)
        {
            var window = new InventoryFilialCheckForm(SelectedDocId) { Owner = this };
            window.ShowDialog();
        }

        #endregion

        #region ОТПРАВКА ИНВЕНТАРИЗАЦИИ В РАБОТУ

        /// <summary>
        /// Отправка инвентаризации в работу
        /// </summary>
        private void btnToWork_Click(object sender, EventArgs e)
        {
            foreach (var inv in SelectedDocs)
                try
                {
                    adapter.StartInventoryList(UserID, inv.Inventory_number);
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Не удалось отправить в работу инвентаризацию №{0}: ", inv.Inventory_number) +
                        Environment.NewLine + exc.Message);
                }

            RefreshDocs();
        }

        #endregion

        #region СОЗДАНИЕ ПЕРЕСЧЕТА

        /// <summary>
        /// Признак, можно ли создавать пересчет
        /// </summary>
        private bool CanCreateCalc
        {
            get
            {
                foreach (WMSOffice.Data.Inventory.FI_RecalculationsRow row in inventory.FI_Recalculations.Rows)
                    if (row.Status_ID != "199" || row.Calc_ID == 4)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Создание пересчета
        /// </summary>
        private void btnCreateCalc_Click(object sender, EventArgs e)
        {
            var calcForm = dgvInventories.SelectedItem["calc_form"].ToString();

            var isFourthCalc = Convert.ToBoolean(SelectedDoc.fourth_calc);

            var window = new InventoryFilialCalcItemsForm(UserID, (int)SelectedDocId, GetNextCalcId(isFourthCalc), false, calcForm) { Owner = this };
            window.ShowDialog();
            if (window.DialogResult == DialogResult.OK)
            {
                RefreshDocs();
                btnCreateCalc.Visible = miCreateCalc.Enabled = CanCreateCalc;
            }
        }

        /// <summary>
        /// Определяет номер пересчета
        /// </summary>
        /// <returns>Номер пересчета, основанный на количестве пересчетов и признаке, сошлось ли количество</returns>
        /// <param name="isFourthCalc">Признак необходимости создания 4-го пересчета</param>
        private int GetNextCalcId(bool isFourthCalc)
        {
            int maxCalcId = 0;
            bool isInequality = false;
            string inventoryType = string.Empty;

            foreach (WMSOffice.Data.Inventory.FI_RecalculationsRow row in inventory.FI_Recalculations.Rows)
                if (row.Calc_ID > maxCalcId)
                {
                    maxCalcId = row.Calc_ID;
                    isInequality = row.HasInequalities;
                    inventoryType = row.FI_Type;
                }

            if (maxCalcId == 0)
                return 1;
            else if (isFourthCalc)
                return 4;
            else if (maxCalcId == 3 || !isInequality)
                return 4;
            else
                return ++maxCalcId;

            //if (maxCalcId == 1 && inventoryType.Equals(HIGH_COST_INVENTORY_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(HIGH_COST_INVENTORY_FLOOR_2_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(HIGH_COST_INVENTORY_FLOOR_3_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(HIGH_COST_INVENTORY_FLOOR_4_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(HIGH_COST_INVENTORY_BP2_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(NARKOZ_INVENTORY_TYPE))
            //    return 4;
            //if (maxCalcId == 1 && inventoryType.Equals(PKU_INVENTORY_TYPE))
            //    return 4;
            //else if (maxCalcId == 0)
            //    return 1;
            //else if (maxCalcId == 3 || !isInequality)
            //    return 4;
            //else
            //    return ++maxCalcId;
        }

        #endregion

        #region СОЗДАНИЕ ПУСТОГРАФКИ

        /// <summary>
        /// Создание "пустографки" - счетной ведомости с незаполненными графами
        /// </summary>
        private void miCreateEmptyCountSheet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите создать новую\nпустую счетную ведомость для текущего пересчета?", "Создание счетной ведомости", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var inventoryID = SelectedCalc != null ? SelectedCalc.Inventory_ID : SelectedDoc.Inventory_number;
                    var calcID = SelectedCalc != null ? SelectedCalc.Calc_ID : (int?)null;

                    var result = taFiRecalculations.CheckCreateCountSheet(UserID, inventoryID, calcID, "BS");
                    var needSelectWarehouse = Convert.ToBoolean(result ?? 0);


                    var warehouseID = (string)null;
                    if (needSelectWarehouse)
                    {
                        #region ВЫБОР СКЛАДА

                        var dlgSelectWarehouse = new WMSOffice.Dialogs.RichListForm();
                        dlgSelectWarehouse.Text = "Выберите склад";
                        dlgSelectWarehouse.AddColumn("Warehouse_ID", "Warehouse_ID", "Код склада");
                        dlgSelectWarehouse.FilterChangeLevel = 0;
                        dlgSelectWarehouse.FilterVisible = false;

                        Data.Inventory.FI_Warehouses_For_SetDataTable table = null;
                        using (var adapter = new Data.InventoryTableAdapters.FI_Warehouses_For_SetTableAdapter())
                            table = adapter.GetData(this.UserID, inventoryID, calcID, "BS");

                        dlgSelectWarehouse.DataSource = table;

                        if (dlgSelectWarehouse.ShowDialog() != DialogResult.OK)
                            return;

                        warehouseID = (dlgSelectWarehouse.SelectedRow as Data.Inventory.FI_Warehouses_For_SetRow).Warehouse_ID;

                        #endregion
                    }

                    int cntEmptyCountSheets = 1;
                    #region ВЫБОР КОЛ-ВА "ПУСТОГРАФОК"

                    var dlgInventoryEmptyCountSheetsSetQuantity = new InventoryEmptyCountSheetsSetQuantityForm() { UserID = this.UserID };

                    if (dlgInventoryEmptyCountSheetsSetQuantity.ShowDialog() != DialogResult.OK)
                        return;

                    cntEmptyCountSheets = dlgInventoryEmptyCountSheetsSetQuantity.EmptyCountSheetsQuantity;

                    #endregion

                    try
                    {
                        for (int i = 0; i < cntEmptyCountSheets; i++)
                        {
                            taFiRecalculations.CreateCountSheet(UserID, inventoryID, calcID, "BS", warehouseID);
                        }
                    }
                    catch (Exception ex)
                    {
                        //ShowError(ex);
                    }

                    RefreshCalcLists();
                }
                catch (Exception exc)
                {
                    ShowError(exc);
                }
            }
        }

        #endregion

        #region ЗАКРЫТИЕ ИНВЕНТАРИЗАЦИИ, ВЫПОЛНЕНИЕ ПЕРЕСОРТОВ И ПЕРЕМЕЩЕНИЙ

        /// <summary>
        /// Закрыть инвентаризацию
        /// </summary>
        private void btnCloseInventory_Click(object sender, EventArgs e)
        {
            foreach (var inv in SelectedDocs)
                try
                {
                    var calcForm = dgvInventories.SelectedItem["calc_form"].ToString();

                    var window = new InventoryFilialCalcItemsForm(UserID, (int)SelectedDocId, 5, true, calcForm) { Owner = this };
                    window.ShowDialog();
                    if (window.DialogResult == DialogResult.OK)
                    {
                        adapter.CloseInventoryRecalculations(UserID, SelectedDocId);
                        RefreshDocs();
                    }
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Не удалось закрыть инвентаризацию №{0}: ", inv.Inventory_number) +
                        Environment.NewLine + exc.Message);
                }
        }

        /// <summary>
        /// Запуск формы подтверждения пересортов
        /// </summary>
        private void btnPeresorts_Click(object sender, EventArgs e)
        {
            var dialog = new InventoryFilialCommitPeresortForm(UserID, SelectedDoc, "CI");
            dialog.ShowDialog();
            RefreshDocs();
        }

        /// <summary>
        /// Запуск формы подтверждения перемещений недостач
        /// </summary>
        private void btnReplacings_Click(object sender, EventArgs e)
        {
            var dialog = new InventoryFilialCommitPeresortForm(UserID, SelectedDoc, "CM");
            dialog.ShowDialog();
            RefreshDocs();
        }

        #endregion

        #region ТАБЛИЦА ПЕРЕСЧЕТОВ

        /// <summary>
        /// Название таблицы с пересчетами в конфигурационном файле с настройками
        /// </summary>
        private string ConfigCalcsTableName { get { return String.Format("{0}_Calcs", Name); } }

        /// <summary>
        /// Пересчет, выделенный в таблице
        /// </summary>
        private Inventory.FI_RecalculationsRow SelectedCalc
        {
            get
            {
                if (dgvCalcs.SelectedRows.Count == 0)
                    return null;
                else
                    return (dgvCalcs.SelectedRows[0].DataBoundItem as DataRowView).Row as Inventory.FI_RecalculationsRow;
            }
        }

        /// <summary>
        /// Перезагрузка счетных листов при изменении выбранного пересчета
        /// </summary>
        private void dgvCalcs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshCalcLists();
            CustomCalcsContextMenu();
        }

        /// <summary>
        /// Настройка доступности пунктов контекстного меню таблицы пересчетов в зависимости от выбранного пересчета
        /// </summary>
        private void CustomCalcsContextMenu()
        {
            var cntCalcLists = dgvCalcLists.DataView.Data != null ? dgvCalcLists.DataView.Data.Rows.Count : 0;

            miCreateEmptyCountSheet.Enabled = ((cntCalcLists == 0 && SelectedDoc != null) || (cntCalcLists > 0 && SelectedCalc != null && Convert.ToInt32(SelectedCalc.Status_ID) == 100)) && !this.IsArchiveMode;
            miCloseRecalc.Enabled = cntCalcLists > 0 && SelectedCalc != null && Convert.ToInt32(SelectedCalc.Status_ID) == 100 && !this.IsArchiveMode;
            miCalcDiff.Enabled = cntCalcLists > 0 && SelectedCalc != null && Convert.ToInt32(SelectedCalc.Status_ID) == 199;
        }

        /// <summary>
        /// Разрисовка строк в таблице со списком пересчетов инвентаризации
        /// </summary>
        private void dgvCalcs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCalcs.Rows)
            {
               //var diffRow = (Data.Inventory.IM_CalcsRow)((DataRowView)row.DataBoundItem).Row;
                var diffRow = (Data.Inventory.FI_RecalculationsRow)((DataRowView)row.DataBoundItem).Row;

                var backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white") 
                    ? Color.White : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }

            CustomCalcsContextMenu();
        }

        #endregion

        #region ЗАКРЫТИЕ ПЕРЕСЧЕТА

        /// <summary>
        /// Закрываем пересчет
        /// </summary>
        private void miCloseRecalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть текущий пересчет?", "Закрытые пересчета",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var worker = new BackgroundWorker();
            worker.DoWork += closeCalcWorker_DoWork;
            worker.RunWorkerCompleted += closeCalcWorker_RunWorkerCompleted;

            splashForm.ActionText = "Выполняется закрытие пересчета...";
            worker.RunWorkerAsync(SelectedCalc);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Закрытие пересчета в фоне
        /// </summary>
        private void closeCalcWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var calc = e.Argument as Data.Inventory.FI_RecalculationsRow;
                taFiRecalculations.SetTimeout(1800);
                taFiRecalculations.CloseCalc(calc.Inventory_ID, calc.Doc_ID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обработка окончания фонового закрытия пересчета
        /// </summary>
        private void closeCalcWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Во время закрытия пересчета возникла ошибка: ", e.Result as Exception);
            splashForm.CloseForce();
            LoadCalculations();
        }

        #endregion

        #region ОТЧЕТ "ВЕДОМОСТЬ РАСХОЖДЕНИЙ"

        /// <summary>
        /// Отображение отчета "Ведомость расхождений" для закрытого пересчета
        /// </summary>
        private void miCalcDiff_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ReportForm();
                form.ReportDocument = GetCalcDiffReport(SelectedCalc.Inventory_ID, SelectedCalc.Calc_ID, SelectedDoc.Filial_Name);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Создание отчета "Ведомость расхождений"
        /// </summary>
        /// <param name="pDocID">Идентификатор инвентаризации</param>
        /// <param name="pCalcId">Идентификатор пересчета</param>
        /// <param name="pBusinessUnit">Бизнес-единица</param>
        /// <returns>Созданный отчет, заполненный данными и готовый к отображению</returns>
        private InventoryFilialCalcDiffReport GetCalcDiffReport(long pDocID, int pCalcId, string pBusinessUnit)
        {
            var report = new InventoryFilialCalcDiffReport();
            report.SetDataSource(GetDataSourceForCalcDiff(pDocID, pCalcId));

            // Добавление параметров отчета
            var crParameterFieldDefinitions = report.DataDefinition.ParameterFields;

            var crParameterFieldLocation = crParameterFieldDefinitions["CalcID"];
            var crParameterValues = crParameterFieldLocation.CurrentValues;
            var crParameterDiscreteValue = new ParameterDiscreteValue();
            crParameterDiscreteValue.Value = pCalcId.ToString();
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues);

            crParameterFieldLocation = crParameterFieldDefinitions["Warehouse"];
            crParameterValues = crParameterFieldLocation.CurrentValues;
            crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
            crParameterDiscreteValue.Value = pBusinessUnit;
            crParameterValues.Add(crParameterDiscreteValue);
            crParameterFieldLocation.ApplyCurrentValues(crParameterValues);

            return report;
        }

        /// <summary>
        /// Получение данных для отчета "Ведомость расхождений"
        /// </summary>
        /// <param name="pDocID">Идентификатор инвентаризации</param>
        /// <param name="pCalcId">Идентификатор пересчета</param>
        /// <returns>Заполненный DataSet, на основании которого будет строиться отчет</returns>
        private Inventory GetDataSourceForCalcDiff(long pDocID, int pCalcId)
        {
            var dataSet = new Inventory();

            using (var adapter = new FI_Calc_Diff_ReportTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(dataSet.FI_Calc_Diff_Report, pDocID, pCalcId, UserID);
                else
                    adapter.Fill(dataSet.FI_Calc_Diff_Report, pDocID, pCalcId, UserID);
            }

            if (dataSet.FI_Calc_Diff_Report.Count < 1)
                throw new Exception("Не удалось получить данные Ведомости расхождений!");

            return dataSet;
        }

        #endregion

        #region ТАБЛИЦА СЧЕТНЫХ ЛИСТОВ

        /// <summary>
        /// Название таблицы со счетными листами в конфигурационном файле с настройками
        /// </summary>
        private string ConfigCalcListsTableName { get { return String.Format("{0}_CalcLists", Name); } }

        /// <summary>
        /// Выбранный счетный лист в таблице либо null, если таблица пустая или в ней не выбрано ни одного счетного листа.
        /// Если в таблице выделено несколько счетных листов, то возвращается первый из них
        /// </summary>
        private Inventory.FI_Counting_SheetsRow SelectedCalcList
        {
            get { return dgvCalcLists.SelectedItem as Inventory.FI_Counting_SheetsRow; }
        }

        /// <summary>
        /// Коллекция счетных листов, выделенных в таблице. Если не выделен ни один счетный лист, то коллекция пуста
        /// </summary>
        private IEnumerable<Inventory.FI_Counting_SheetsRow> SelectedCalcLists
        {
            get
            {
                return dgvCalcLists.SelectedItems.ConvertAll(
                    new Converter<DataRow, Inventory.FI_Counting_SheetsRow>(x => x as Inventory.FI_Counting_SheetsRow));
            }
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида со счетными листами
        /// </summary>
        private void InitializeCalcSheetsGrid()
        {
            dgvCalcLists.Init(new InventoryFilialCalcListsView(this.IsArchiveMode), true);
            dgvCalcLists.LoadExtraDataGridViewSettings(ConfigCalcListsTableName);
            dgvCalcLists.UserID = UserID;
            dgvCalcLists.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvCalcLists.AllowRangeColumns = true;
            dgvCalcLists.UseMultiSelectMode = true;
            dgvCalcLists.AllowSummary = false;

            dgvCalcLists.OnFilterChanged += dgvCalcLists_OnFilterChanged;
            dgvCalcLists.OnRowSelectionChanged += dgvCalcLists_OnRowSelectionChanged;
            dgvCalcLists.OnFormattingCell += dgvCalcLists_OnFormattingCell;
            dgvCalcLists.OnRowDoubleClick += dgvCalcLists_OnRowDoubleClick;

            // активация постраничного просмотра
            dgvCalcLists.CreatePageNavigator();
        }

        /// <summary>
        /// Перезагрузка счетных листов
        /// </summary>
        private void RefreshCalcLists()
        {
            dgvCalcLists.SaveExtraDataGridViewSettings(ConfigCalcListsTableName);
            RefreshCalcListsDataViewBinding();
            dgvCalcLists.LoadExtraDataGridViewSettings(ConfigCalcListsTableName);
            CustomCalcListsButtons();
        }

        /// <summary>
        /// Загрузка счетных листов в фильтруемый грид из БД
        /// </summary>
        private void RefreshCalcListsDataViewBinding()
        {
            try
            {
                if (SelectedCalc != null && dgvCalcs.SelectedRows.Count == 1)
                {
                    dgvCalcLists.DataView.FillData(new InventoryFilialCalcListsSearchParameters()
                    {
                        SessionID = UserID,
                        CalcID = SelectedCalc.Doc_ID
                    });
                    dgvCalcLists.BindData(false);
                }
                else
                    dgvCalcLists.ClearItems();
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить список счетных листов для выбранного пересчета: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра в таблице счетных листов
        /// </summary>
        private void dgvCalcLists_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvCalcLists.RecalculateSummary();
        }

        /// <summary>
        /// Обновление статусов кнопок на панели инструментов счетных листов при изменении выделенного счетного листа
        /// </summary>
        private void dgvCalcLists_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomCalcListsButtons();
            //CustomCalcsContextMenu();
        }

        /// <summary>
        /// Раскраска строк счетных листов
        /// </summary>
        private void dgvCalcLists_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var gridView = sender as DataGridView;
            gridView.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16);
            var bindRow = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
            var color = Color.FromName(bindRow["Color"].ToString());

            gridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Black;
            gridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = color;
        }

        /// <summary>
        /// Если тип счетного листа - BS (пустографка), то вызываем пустографку для инвентаризации филиалов
        /// </summary>
        private void dgvCalcLists_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (SelectedCalcList != null && SelectedCalcList.Status_ID < 199)
                using (var form = new ScanCountSheetForm(UserID) { IsInventoryFilial = true })
                {
                    form.HandControlType = SelectedCalcList.CS_Type;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.DocType != "BS" && form.DocType != "CS")
                            MessageBox.Show("Отсканирован другой тип Счетного листа.");
                        else
                        {
                            var wnd = new InventoryFilialHandControlFrom(form.RelatedDocID, form.RecalcID)
                            {
                                AllowAddRows = form.DocType == "BS",
                                Owner = this,
                                UserID = UserID
                            };

                            wnd.InitDocument(form.DocTypeName, form.DocID, form.DocType, form.DocDate, form.DocStatusID, form.DocStatusName);
                            wnd.ShowDialog();
                            RefreshCalcLists();
                        }
                    }
                }
            else if (SelectedCalcList != null && SelectedCalcList.Status_ID == 199)
                MessageBox.Show("Ввод количества в документ завершен! Чтобы возобновить ввод, верните документ на 100-й статус", "Ввод количества",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления счетных листов в зависимости от выбранного пересчета
        /// </summary>
        private void CustomCalcListsButtons()
        {
            btnCalcSheetPreview.Enabled = miCalcSheetPreview.Enabled = dgvCalcLists.SelectedItems.Count == 1;
            btnPrintCalcSheet.Enabled = miPrintCalcSheet.Enabled = dgvCalcLists.SelectedItems.Count > 0 && !this.IsArchiveMode;
            btnEnteredDataWindow.Enabled = miEnteredDataWindow.Enabled = dgvCalcLists.SelectedItems.Count == 1;
            btnEditCsAfterClose.Enabled = miCsEditAfterClose.Enabled = dgvCalcLists.SelectedItems.Count == 1 && SelectedCalcList.Status_ID == 199 && SelectedDoc != null && !SelectedDoc.FI_Type_ID.Equals(CLIENT_TARE_INVENTORY_TYPE, StringComparison.OrdinalIgnoreCase) && !this.IsArchiveMode;
            miBindCsToUser.Enabled = dgvCalcLists.SelectedItems.Count == 1 /*&& SelectedCalcList.Status_ID < 199*/ && !this.IsArchiveMode;
            miBindManyCsToEmp.Enabled = !this.IsArchiveMode;
        }

        /// <summary>
        /// Возвращение пустографки на статус для редактирования
        /// </summary>
        private void btnEditCsAfterClose_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new FI_Counting_SheetsTableAdapter())
                    adapter.EditCsAfterClose(SelectedCalcList.CS_ID, UserID);
                RefreshCalcLists();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при переводе счетного листа по статусам:", exc);
            }
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ СЧЕТНОГО ЛИСТА

        /// <summary>
        /// Просмотр счетного листа
        /// </summary>
        private void btnCalcSheetPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (var report = new InventoryFilialCalcSheetReport())
                using (var reportForm = new ReportForm())
                {
                    var dsInventory = CreateInventoryFilialCalcSheetReport(SelectedCalcList);
                    report.SetDataSource(dsInventory);
                    reportForm.ReportDocument = report;
                    reportForm.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время просмотра счетного листа возникла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Заполнение данных для отображения печатной формы счетного листа
        /// </summary>
        /// <param name="pCalcSheetID">Идентификатор счетного листа</param>
        private Data.Inventory CreateInventoryFilialCalcSheetReport(Data.Inventory.FI_Counting_SheetsRow countingSheet)
        {
            var dsInventory = new Data.Inventory();

            using (var adapter = new FI_Calc_Sheet_HeaderTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(dsInventory.FI_Calc_Sheet_Header, UserID, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
                else
                    adapter.Fill(dsInventory.FI_Calc_Sheet_Header, UserID, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
            }

            if (dsInventory.FI_Calc_Sheet_Header.Rows.Count == 0)
                throw new Exception("Не удалось загрузить заголовок счетного листа!");
            dsInventory.FI_Calc_Sheet_Header[0].BarCodeImage = BarCodeGenerator.GetBarcodeCODE39(dsInventory.FI_Calc_Sheet_Header[0].Bar_Code.Trim());

            using (var adapter = new FI_Calc_Sheet_DetailsTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(dsInventory.FI_Calc_Sheet_Details, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
                else
                    adapter.Fill(dsInventory.FI_Calc_Sheet_Details, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
            }

            using (var adapter = new FI_Calc_Sheet_SignersTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(dsInventory.FI_Calc_Sheet_Signers, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
                else
                    adapter.Fill(dsInventory.FI_Calc_Sheet_Signers, (int)countingSheet.CS_ID, countingSheet.Inventory_ID, Convert.ToInt32(countingSheet.Recalc_ID));
            }

            return dsInventory;
        }

        /// <summary>
        /// Печать счетного листа
        /// </summary>
        private void btnPrintCalcSheet_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;

            var parameters = new PrinterWorkerParameters(){PrinterName = (string)cbPrinters.SelectedItem};
            parameters.DocsToPrint.AddRange(SelectedCalcLists);
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Печатает в фоне заданные документы
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (PrinterWorkerParameters)e.Argument;
                foreach (var doc in param.DocsToPrint)
                {
                    var dsInventory = CreateInventoryFilialCalcSheetReport(doc);
                    using (var report = new InventoryFilialCalcSheetReport())
                    {
                        report.PrintOptions.PrinterName = param.PrinterName;
                        report.SetDataSource(dsInventory);
                        report.PrintToPrinter(1, true, 1, 0);
                    }

                    if (!this.IsArchiveMode)
                    {
                        using (var adapter = new FI_Counting_SheetsTableAdapter())
                            adapter.SetStatusPrinted(doc.CS_ID);
                    }
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания печати отчетов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError((e.Result as Exception).Message);
            RefreshCalcLists();
        }

        #endregion

        #region РАЗДАЧА СЧЕТНЫХ ЛИСТОВ СОТРУДНИКАМ

        /// <summary>
        /// Отдать счетный лист заданному сотруднику
        /// </summary>
        private void miBindCsToUser_Click(object sender, EventArgs e)
        {
            var window = new InventoryFilialScanEmployeeForm();
            if (window.ShowDialog(this) == DialogResult.OK)
                try
                {
                    using (var adapter = new FI_Counting_SheetsTableAdapter())
                        adapter.Associate(UserID, SelectedCalcList.CS_ID, window.EmployeeID.ToString());
                    RefreshCalcLists();
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Не удалось закрепить счетный лист за сотрудником", exc);
                }
        }

        /// <summary>
        /// Массовое назначение счетных листов
        /// </summary>
        private void miBindManyCsToEmp_Click(object sender, EventArgs e)
        {
            try
            {
                ShowWarningWhenAllCalcListsAreLinked();
                var adapter = new FI_Counting_SheetsTableAdapter();
                foreach (Inventory.FI_Counting_SheetsRow row in dgvCalcLists.DataView.Data.Rows)
                    if (String.IsNullOrEmpty(row.Employee))
                    {
                        var window = new InventoryFilialScanEmployeeForm()
                        {
                            IsSkipEnabled = true,
                            Text = "Счетный лист №" + row.CS_ID
                        };
                        window.ShowDialog(this);
                        if (window.DialogResult == DialogResult.OK)
                            adapter.Associate(UserID, row.CS_ID, window.EmployeeID.ToString());
                        else if (window.DialogResult == DialogResult.Ignore)
                            continue;
                        else
                            break;
                    }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время закрепления счетных листов за сотрудниками: ", exc);
            }

        }

        /// <summary>
        /// Проверить, все ли счетные листы розданы сотрудникам (проверка выполняется перед раздачей)
        /// Если все - то нужно предупредить, что дальнейшая раздача листов бессмысленна
        /// </summary>
        private void ShowWarningWhenAllCalcListsAreLinked()
        {
            foreach (Inventory.FI_Counting_SheetsRow row in dgvCalcLists.DataView.Data.Rows)
                if (String.IsNullOrEmpty(row.Employee))
                    return;

            MessageBox.Show("Все счетные листы выданы сотрудникам!", "Инвентаризация", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати счетных листов
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Список счетных листов, которые нужно напечатать
            /// </summary>
            public List<Inventory.FI_Counting_SheetsRow> DocsToPrint = new List<Inventory.FI_Counting_SheetsRow>();

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion

        #region ПРОСМОТР ВВЕДЕННЫХ ДАННЫХ СЧЕТНОГО ЛИСТА

        /// <summary>
        /// Просмотр введенных данных счетного листа
        /// </summary>
        private void btnEnteredDataWindow_Click(object sender, EventArgs e)
        {
            var window = new InventoryFilialEnteredDataForm(SelectedCalcList, UserID) { IsArchiveMode = this.IsArchiveMode };
            window.ShowDialog(this);
        }

        #endregion

        #region ПЕЧАТЬ ИНВЕНТАРИЗАЦИОННОЙ ОПИСИ

        /// <summary>
        /// Просмотр, а затем печать инвентаризацонной описи
        /// </summary>
        private void btnInventoryListPrint_Click(object sender, EventArgs e)
        {
            try
            {
                using (var report = new InventoryFilialReport())
                using (var reportForm = new ReportForm())
                {
                    FillInventoryFilialReport((int)SelectedDocId);
                    report.SetDataSource(inventory);
                    reportForm.ReportDocument = report;
                    reportForm.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время просмотра инвентаризационной описи возникла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Заполнение данных для отображения инвентаризационной описи
        /// </summary>
        /// <param name="pInventoryId">Идентификатор инвентаризации</param>
        private void FillInventoryFilialReport(int pInventoryId)
        {
            using (var adapter = new FI_Inventory_Report_HeaderTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Report_Header, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Report_Header, pInventoryId);
            }

            if (inventory.FI_Inventory_Report_Header.Rows.Count == 0)
                throw new Exception("Не удалось загрузить заголовок инвентаризационной описи!");

            using (var adapter = new FI_Inventory_Report_DetailsTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Report_Details, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Report_Details, pInventoryId);
            }

            using (var adapter = new FI_Inventory_Report_SignersTableAdapter())
            {
                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Report_Signers, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Report_Signers, pInventoryId);
            }
        }

        #endregion

        #region ЭКСПОРТ РЕЗУЛЬТАТОВ ИНВЕНТАРИЗАЦИИ В EXCEL

        /// <summary>
        /// Экспорт результатов инвентаризации в Excel
        /// </summary>
        private void miExportInvenrotyResults_Click(object sender, EventArgs e)
        {
            if (LoadInventoryResults())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Inventory_Results,
                    new string[] { "Инв №", "Код склада", "Название склада", "Код строки", "Код товара", "Наименование товара", "Производитель", "Поставщик", "Госрегулирование", "ПКУ",
                        "Партия", "Серия", "Срок годности", "Статус партии", "ЕИ", "В наличии", "Вывезено", "В экспедиции",
                        "На складе", "Место", "Полка", "Отдел", "Себестоимость", "Цена", "Подсчитано", "Разница", "Учет",
                        "Базовые", "Кол-во недостача", "Сумм недостача", "Кол-во излишек", "Сумм излишек" },
                    new string[] { "Doc_ID", "WarehouseID", "WarehouseName", "Line_ID", "Item_ID", "Item_Name", "Manufacturer", "Vendor", "IsGosReg", "IsPku", "Batch_Number", 
                        "VendorLot", "LifeTime", "BatchStatus", "UM", "CountInStock", "CountDriven", "CountInExped", "CountInWarehouse",
                        "Location", "Stillage", "Zone", "Base_Price", "Price", "Counted", "Difference", "Accounting", "Base",
                        "Deficit_Count", "Deficit_Price", "Surplus_Count", "Surplus_Price" },
                    "Экспорт результатов инвентаризации", "результаты инвентаризации", true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Inventory_Results.Clear();
        }

        /// <summary>
        /// Загрузка результатов инвентаризации из БД
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadInventoryResults()
        {
            try
            {
                var sbDocsID = new StringBuilder();
                foreach (var doc in this.SelectedDocs)
                {
                    if (doc.Status_ID >= 125)
                    {
                        if (sbDocsID.Length > 0)
                            sbDocsID.AppendFormat(",{0}", doc.Inventory_number);
                        else
                            sbDocsID.AppendFormat("{0}", doc.Inventory_number);
                    }
                }
                var sDocsID = sbDocsID.ToString();

                using (var adapter = new FI_Inventory_ResultsTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Inventory_Results, sDocsID);
                    else
                        adapter.Fill(inventory.FI_Inventory_Results, sDocsID);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения результатов из БД возникла ошибка: ", exc);
                return false;
            }
        }

        #endregion

        #region ЭКСПОРТ ИНВЕНТАРИЗАЦИОННОЙ ВЕДОМОСТИ В EXCEL

        /// <summary>
        /// Экспорт ведомости
        /// </summary>
        private void miExportInventorySheetToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                FillInventoryFilialSheetReport((int)SelectedDocId);
                var report = new InventoryFilialSheetReport();
                report.SetDataSource(inventory);
                var message = ExportHelper.ExportCrystalReport(report, ExportFormatType.Excel, "Экспорт ведомости",
                    "Инвентаризационная ведомость №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    throw new ApplicationException(message);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время экспорта инвентаризационной ведомости!", exc);
            }
        }

        /// <summary>
        /// Заполнение данных для экспорта инвентаризационной ведомости
        /// </summary>
        /// <param name="pInventoryId">Идентификатор инвентаризации</param>
        private void FillInventoryFilialSheetReport(int pInventoryId)
        {
            using (var adapter = new FI_Inventory_Collation_Report_HeaderTableAdapter())
            {
                adapter.SetTimeout(600);    // Таймаут 10 минут

                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Collation_Report_Header, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Collation_Report_Header, pInventoryId);
            }

            if (inventory.FI_Inventory_Collation_Report_Header.Rows.Count == 0)
                throw new Exception("Не удалось загрузить заголовок инвентаризационной ведомости!");

            using (var adapter = new FI_Inventory_Collation_Report_DetailsTableAdapter())
            {
                adapter.SetTimeout(600);    // Таймаут 10 минут

                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Collation_Report_Details, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Collation_Report_Details, pInventoryId);
            }

            using (var adapter = new FI_Inventory_Collation_Report_SignersTableAdapter())
            {
                adapter.SetTimeout(600);    // Таймаут 10 минут

                if (this.IsArchiveMode)
                    adapter.FillArchive(inventory.FI_Inventory_Collation_Report_Signers, pInventoryId);
                else
                    adapter.Fill(inventory.FI_Inventory_Collation_Report_Signers, pInventoryId);
            }
        }

        #endregion

        #region ЭКСПОРТ ДОПОЛНИТЕЛЬНЫХ ФАЙЛОВ В EXCEL

        /// <summary>
        /// Экспорт пересортов при выборе соответствующего пункта меню
        /// </summary>
        private void miExportPeresort_Click(object sender, EventArgs e)
        {
            if (LoadInventoryPeresorts())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_Corrections,
                    new string[] { "Код строки", "Из/в", "Код товара", "Количество", "Место", "Партия", "Сумма в базовых", "% НДС(приход)", "Ставка НДС(приход)", "Облагается НДС(приход)", "% НДС(текущий)" },
                    new string[] { "Код строки", "Из/В", "Код товара", "Количество", "Место", "Партия", "Сумма в базовых ценах", "% НДС(приход)", "Ставка НДС(приход)", "Облагается НДС(приход)", "% НДС(текущий)" },
                    "Экспорт пересортов", "пересорты по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_Corrections.Clear();
        }

        /// <summary>
        /// Загрузка пересортов
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadInventoryPeresorts()
        {
            try
            {
                using (var adapter = new FI_Get_Report_CorrectionsTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_Corrections, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_Corrections, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения пересортов из БД возникла ошибка: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Экспорт списаний по нажатию на соответствующую кнопку
        /// </summary>
        private void miMoving_Click(object sender, EventArgs e)
        {
            if (LoadInventoryMovings())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_Moving,
                    new string[] { "Код строки", "Из/в", "Код товара", "Количество", "Партия", "Место" },
                    new string[] { "Код строки", "Из/В", "Код товара", "Количество", "Партия", "Место" },
                    "Экспорт списаний", "списания по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_Moving.Clear();
        }

        /// <summary>
        /// Загрузка списаний
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadInventoryMovings()
        {
            try
            {
                using (var adapter = new FI_Get_Report_MovingTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_Moving, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_Moving, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения списаний из БД возникла ошибка: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Экспорт излишков в Excel при выборе соответствующего пункта меню
        /// </summary>
        private void miExportSurpluses_Click(object sender, EventArgs e)
        {
            if (LoadInventorySurpluses())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_Overage,
                    new string[] { "Код строки", "Из/в", "Код товара", "Количество", "Партия", "Место" },
                    new string[] { "ID строки", "Из/В", "Код товара", "Количество", "Партия", "Место" },
                    "Экспорт излишков", "излишки по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_Overage.Clear();
        }

        /// <summary>
        /// Загрузка излишков
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadInventorySurpluses()
        {
            try
            {
                using (var adapter = new FI_Get_Report_OverageTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_Overage, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_Overage, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения излишков из БД возникла ошибка: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Экспорт расхождений в Excel при выборе соответствующего пункта меню
        /// </summary>
        private void miExportDifferences_Click(object sender, EventArgs e)
        {
            if (SelectedDoc.FI_Type_ID.Equals(CLIENT_TARE_INVENTORY_TYPE, StringComparison.OrdinalIgnoreCase))
                ExportClientDifferences();
            else
                ExportGeneralDifferences();
        }

        #region Экспорт расхождений
        private void ExportGeneralDifferences()
        {
            if (LoadGeneralInventoryDifferences())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_Difference,
                    new string[] { "Из/в", "Код товара", "Наименование", "Производитель", "Ед.изм.", "Кол-во",
                        "Полка", "Признак НДС", "Код строки", "Сумма в базовых ценах", "Сумма в себестоимости", "Партия", "Цена за единицу в базовых" },
                    new string[] { "Из/В", "Код товара", "Наименование", "Производитель", "Ед_изм_", "Кол-во",
                        "Полка", "Признак НДС", "Код строки", "сумма в базовых ценах", "сумма в себестоимости", "Партия", "Базовая цена" },
                    "Экспорт расхождений", "расхождения по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_Difference.Clear();
        }

        /// <summary>
        /// Загрузка расхождений
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadGeneralInventoryDifferences()
        {
            try
            {
                using (var adapter = new FI_Get_Report_DifferenceTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_Difference, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_Difference, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения расхождений из БД возникла ошибка: ", exc);
                return false;
            }
        }
        #endregion

        #region Экспорт расхождений ОТ
        private void ExportClientDifferences()
        {
            if (LoadClientTareInventoryDifferences())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.RET_Inventory_WMS_get_problem_tare,
                    new string[] { "Статус В", "Статус ИЗ", "Код тары", "Наименование тары", "Кол-во",
                        "Полка", "Цена тары", "Партия" },
                    new string[] { "Status_new", "Status_old", "Item_id", "Name", "Qty",
                        "Location", "price", "LOTN" },
                    "Экспорт расхождений", "расхождения по инвентаризации ОТ №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.RET_Inventory_WMS_get_problem_tare.Clear();
        }

        /// <summary>
        /// Загрузка расхождений
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadClientTareInventoryDifferences()
        {
            try
            {
                using (var adapter = new RET_Inventory_WMS_get_problem_tareTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут
                    adapter.Fill(inventory.RET_Inventory_WMS_get_problem_tare, SelectedDocId);
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения расхождений из БД возникла ошибка: ", exc);
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Экспорт распределения бонусов в Excel при выборе соответствующего пункта меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miExportBonuses_Click(object sender, EventArgs e)
        {
            if (LoadInventoryBonuses())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_BonusReplace,
                    new string[] { "Код строки", "Из/в", "Код товара", "Наименование", "Количество", "Место", "Партия", 
                        "Сумма в базовых ценах", "% НДС(приход)", "Ставка НДС(приход)", "Облагается НДС(приход)", "% НДС(текущий)" },
                    new string[] { "Код строки", "Из/В", "Код товара", "Item_Name", "Количество", "Место", "Партия",
                        "Сумма в базовых ценах", "% НДС(приход)", "Ставка НДС(приход)", "Облагается НДС(приход)", "% НДС(текущий)" },
                    "Экспорт распределения бонусов", "распределение бонусов по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_BonusReplace.Clear();
        }

        /// <summary>
        /// Загрузка распределения бонусов
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadInventoryBonuses()
        {
            try
            {
                using (var adapter = new FI_Get_Report_BonusReplaceTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_BonusReplace, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_BonusReplace, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения распределения бонусов из БД возникла ошибка: ", exc);
                return false;
            }
        }

        #region Экспорт данных по счетным листам в Excel

        /// <summary>
        /// Экспорт данных по счетным листам в Excel
        /// </summary>
        private void miExportCalcListsData_Click(object sender, EventArgs e)
        {
            if (SelectedDoc.FI_Type_ID.Equals(CLIENT_TARE_INVENTORY_TYPE, StringComparison.OrdinalIgnoreCase))
                ExportClientTareCalcListsData();
            else
                ExportGeneralCalcListsData();
        }

        #region Экспорт по обычным счетным листам
        private void ExportGeneralCalcListsData()
        {
            if (LoadGeneralInventoryCalcListsData())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.FI_Get_Report_CalcSheets,
                    new string[] { "№ инв.WMS", "№ пересчета", "Счетный лист", "Код товара", "Наименование товара",
                        "Код поставщика", "Поставщик", "Серия поставщика", "Место хранения", "Единица измерения",
                        "Количество", "Штрих-код счетного листа" },
                    new string[] { "№ инв_ WMS", "№ Пересчета", "Счетный лист", "Код товара", "Наименование товара",
                        "Код поставщика", "Поставщик", "Серия поставщика", "Место хранения", "Единица измерения",
                        "Количество", "Штрих-код Сч_ листа" },
                    "Экспорт данных по счетным листам", "счетные листы по инвентаризации №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.FI_Get_Report_CalcSheets.Clear();
        }

        /// <summary>
        /// Загрузка данных по счетным листам
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadGeneralInventoryCalcListsData()
        {
            try
            {
                using (var adapter = new FI_Get_Report_CalcSheetsTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут

                    if (this.IsArchiveMode)
                        adapter.FillArchive(inventory.FI_Get_Report_CalcSheets, SelectedDocId);
                    else
                        adapter.Fill(inventory.FI_Get_Report_CalcSheets, SelectedDocId);

                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения данных по счетным листам из БД возникла ошибка: ", exc);
                return false;
            }
        }
        #endregion

        #region Экспорт по счетным листам ОТ
        private void ExportClientTareCalcListsData()
        {
            if (LoadClientTareInventoryCalcListsData())
            {
                string message = ExportHelper.ExportDataTableToExcel(inventory.RET_Inventory_WMS_get_calc_task_info,
                    new string[] { "№ инв.WMS", "№ пересчета", "Счетный лист", "Код тары", "Наименование тары",
                        "Партия", "Место хранения", "Ш/К SSCC",
                        "Статус тары", "Пользователь" },
                    new string[] { "Inv_ID", "Calc_step", "Inv_doc_id", "Item_ID", "Item_Name",
                        "LotNumber", "Location_ID", "SSCC_BAR",
                        "RET_Status", "User_Info" },
                    "Экспорт данных по счетным листам", "счетные листы по инвентаризации ОТ №" + SelectedDocId, true);
                if (!String.IsNullOrEmpty(message))
                    Logger.ShowErrorMessageBox("Во время экспорта в Excel возникла ошибка: " + Environment.NewLine + message);
            }

            inventory.RET_Inventory_WMS_get_calc_task_info.Clear();
        }

        /// <summary>
        /// Загрузка данных по счетным листам ОТ
        /// </summary>
        /// <returns>True, если удалось загрузить, False если не удалось (возникла ошибка)</returns>
        private bool LoadClientTareInventoryCalcListsData()
        {
            try
            {
                using (var adapter = new RET_Inventory_WMS_get_calc_task_infoTableAdapter())
                {
                    adapter.SetTimeout(600);    // Таймаут 10 минут
                    adapter.Fill(inventory.RET_Inventory_WMS_get_calc_task_info, SelectedDocId, (long?)null, (int?)null);
                    return true;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время получения данных по счетным листам из БД возникла ошибка: ", exc);
                return false;
            }
        }
        #endregion

        #endregion

        #endregion

        #region ПЛАНИРОВАНИЕ РЕСУРСОВ ИНВЕНТАРИЗАЦИИ

        private void sbPlanResources_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedDoc == null)
                    return;

                var allowPlanResourceFlag = (int?)null;
                using (var adapter = new FI_Get_Inventory_ListsTableAdapter())
                    adapter.AllowPlanResource(this.UserID, SelectedDoc.Inventory_number, SelectedDoc.FI_Type_ID, ref allowPlanResourceFlag);

                if (allowPlanResourceFlag.HasValue && allowPlanResourceFlag.Value.Equals(1))
                {
                    using (InventoryResourcePlanningForm dlgPlanResources = new InventoryResourcePlanningForm()
                    {
                        UserID = this.UserID,
                        InventoryDocID = SelectedDoc.Inventory_number,
                        InventoryFI_Type = SelectedDoc.FI_Type_ID,
                        UsePartialMode = true,
                        UpgradeMode = true
                    })
                    {
                        dlgPlanResources.ShowDialog(this);
                    }
                }
                else
                    throw new Exception("Планирование ресурсов недоступно!");
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        private void sbInventoryMonitoring_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.SelectedDoc == null)
                    return;

                using (var dlgMonitor = new WMSOffice.Dialogs.Inventory.InventoryMonitoringForm() { UserID = this.UserID, InventoryDocID = this.SelectedDoc.Inventory_number, UseFilialSearchMode = true })
                    dlgMonitor.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRunAutoChecks_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new FI_ChecksListTableAdapter())
                    adapter.RunAutoChecks();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для грида с инвентаризациями
    /// </summary>
    public class InventoryFilialView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        public bool IsArchiveMode { get; private set; }

        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDataView

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as InventoryFilialSearchParameters;

            using (var adapter = new FI_Get_Inventory_ListsTableAdapter())
            {
                if (this.IsArchiveMode)
                    data = adapter.GetDataArchive(sc.SessionID, sc.FilialID, sc.PeriodFrom, sc.PeriodTo, sc.InventoryType);
                else
                    data = adapter.GetData(sc.SessionID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialView(bool isArchiveMode)
        {
            this.IsArchiveMode = isArchiveMode;

            this.dataColumns.Add(new PatternColumn("ID филиала", "Filial_ID", new FilterPatternExpressionRule("Filial_ID"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Филиал", "Filial_Name", new FilterPatternExpressionRule("Filial_Name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ инв.", "Inventory_number", new FilterCompareExpressionRule<Int64>("Inventory_number"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Описание статуса", "Status_Name", new FilterPatternExpressionRule("Status_Name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Дата инвентаризации", "InventoryDate", new FilterDateCompareExpressionRule("InventoryDate"), SummaryCalculationType.Count) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Номер приказа", "Direction_Number", new FilterPatternExpressionRule("Direction_Number"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Дата приказа", "Direction_Date", new FilterDateCompareExpressionRule("Direction_Date"), SummaryCalculationType.Count) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Описание", "Description", new FilterPatternExpressionRule("Description"), SummaryCalculationType.Count) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Тип инвентаризации", "FI_Type_Name", new FilterPatternExpressionRule("FI_Type_Name"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Создатель", "creator", new FilterPatternExpressionRule("creator"), SummaryCalculationType.Count) { Width = 300 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка инвентаризаций
    /// </summary>
    public class InventoryFilialSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
        public string FilialID { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }
        public string InventoryType { get; set; }
    }

    /// <summary>
    /// Представление для грида со счетными листами
    /// </summary>
    public class InventoryFilialCalcListsView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        public bool IsArchiveMode {get; private set;}

        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDataView

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as InventoryFilialCalcListsSearchParameters;

            using (var adapter = new FI_Counting_SheetsTableAdapter())
            {
                if (this.IsArchiveMode)
                    data = adapter.GetDataArchive(sc.SessionID, sc.CalcID);
                else
                    data = adapter.GetData(sc.SessionID, sc.CalcID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public InventoryFilialCalcListsView(bool isArchiveMode)
        {
            this.IsArchiveMode = isArchiveMode;

            dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID")) { Width = 60 });
            dataColumns.Add(new PatternColumn("Статус", "Status_Name", new FilterPatternExpressionRule("Status_Name")) { Width = 280 });
            dataColumns.Add(new PatternColumn("№ сч. листа", "CS_ID", new FilterCompareExpressionRule<Int64>("CS_ID")) { Width = 100 });
            dataColumns.Add(new PatternColumn("№ пересч.", "Recalc_ID", new FilterCompareExpressionRule<Int16>("Recalc_ID")) { Width = 90 });
            dataColumns.Add(new PatternColumn("№ инв.", "Inventory_ID", new FilterCompareExpressionRule<Int32>("Inventory_ID")) { Width = 80 });
            dataColumns.Add(new PatternColumn("Тип", "CS_Type", new FilterPatternExpressionRule("CS_Type")) { Width = 50 });
            dataColumns.Add(new PatternColumn("Штрих-код", "Bar_Code", new FilterPatternExpressionRule("Bar_Code")) { Width = 180 });
            dataColumns.Add(new PatternColumn("Сотрудник", "Employee", new FilterPatternExpressionRule("Employee")) { Width = 280 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка инвентаризаций
    /// </summary>
    public class InventoryFilialCalcListsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }

        /// <summary>
        /// Идентификатор пересчета
        /// </summary>
        public long CalcID { get ; set ; }
    }
}
