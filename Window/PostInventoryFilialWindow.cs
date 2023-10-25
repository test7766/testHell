using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.IBFacturesTableAdapters;
using WMSOffice.Data.InventoryTableAdapters;

using WMSOffice.Dialogs.Inventory;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно модуля постинвентаризации
    /// </summary>
    public partial class PostInventoryFilialWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Идентификатор выбранной инвентаризации (в случае, если выбрано несколько строк, возвращается идентификатор первой из них).
        /// Если таблица пустая либо в ней не выбрана ни одна инвентаризация, будет сгенерировано исключение
        /// </summary>
        private long SelectedInvId { get { return Convert.ToInt32(dgvInventories.SelectedItem["Inventory_number"]); } }

        /// <summary>
        /// True, если в таблице инвентаризаций выделена хотя бы одна строка а если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одной строки, либо выделено несколько
        /// инвентаризаций на разных статусах
        /// </summary>
        private bool IsInvSelected
        {
            get
            {
                if (dgvInventories.SelectedItem == null)
                    return false;
                int status = SelectedInv.Status_ID;
                foreach (var doc in SelectedInvs)
                    if (doc.Status_ID != status)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Выбранная инвентаризация в таблице либо null, если таблица пустая или в ней не выбрано ни одной инвентаризации.
        /// Если в таблице выделено несколько инвентаризаций, то возвращается первая из них
        /// </summary>
        private Inventory.FP_Get_InventoriesRow SelectedInv
        {
            get { return dgvInventories.SelectedItem as Inventory.FP_Get_InventoriesRow; }
        }

        /// <summary>
        /// Коллекция номеров инвентаризаций, выделенных в таблице. Если не выделена ни одна инвентаризация, то коллекция пуста
        /// </summary>
        private List<long> SelectedInvIds
        {
            get
            {
                var ids = new List<long>();
                foreach (var doc in SelectedInvs)
                    ids.Add(doc.Inventory_number);
                return ids;
            }
        }

        /// <summary>
        /// Коллекция инвентаризаций, выделенных в таблице. Если не выделена ни одна инвентаризация, то коллекция пуста
        /// </summary>
        private IEnumerable<Inventory.FP_Get_InventoriesRow> SelectedInvs
        {
            get
            {
                return
                    dgvInventories.SelectedItems.ConvertAll(
                    new Converter<DataRow, Inventory.FP_Get_InventoriesRow>(x => x as Inventory.FP_Get_InventoriesRow));
            }
        }

        /// <summary>
        /// Название таблицы с инвентаризациями в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Header", Name); } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public PostInventoryFilialWindow()
        {
            InitializeComponent();
            InitializeInventoryGrid();
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с инвентаризации при создании окна
        /// </summary>
        private void InitializeInventoryGrid()
        {
            dgvInventories.Init(new PostInventoryFilialView(), true);
            dgvInventories.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvInventories.UserID = UserID;
            dgvInventories.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvInventories.AllowRangeColumns = true;
            dgvInventories.UseMultiSelectMode = true;

            dgvInventories.OnFilterChanged += dgvInventories_OnFilterChanged;
            dgvInventories.OnRowSelectionChanged += dgvInventories_OnRowSelectionChanged;

            // активация постраничного просмотра
            dgvInventories.CreatePageNavigator();

            this.CustomButtons();
            this.CustomCorrectionDocsButtons();
        }

        /// <summary>
        /// Обновление данных в таблице инвентаризаций с сохранением выделения и прокрутки
        /// </summary>
        private void RefreshDocs()
        {
            dgvInventories.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            var selectedDocIds = SelectedInvIds;

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
                var loadworker = new BackgroundWorker();
                loadworker.DoWork += (s, e) =>
                {
                    try
                    {
                        dgvInventories.DataView.FillData(new PostInventoryFilialSearchParameters() { SessionID = UserID });
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

                    waitProgressForm.CloseForce();

                };

                waitProgressForm.ActionText = "Выполняется загрузка данных..";
                loadworker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
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
            RefreshCorrectionsDocs();
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранной инвентаризации
        /// </summary>
        private void CustomButtons()
        {
            btnCreatePeresort.Visible = miCreatePeresort.Enabled = !IsCpDoc;
            btnOverages.Visible = miOverage.Enabled = !IsCoDoc;
        }

        /// <summary>
        /// True если уже был создан документ потоварной пересортицы, False если нет
        /// </summary>
        private bool IsCpDoc
        {
            get
            {
                foreach (DataGridViewRow row in dgvCorrectionDocs.Rows)
                    if (((row.DataBoundItem as DataRowView).Row as Inventory.FP_Get_Correction_DocumentsRow).CorrectionType == "CP")
                        return true;
                return false;
            }
        }

        /// <summary>
        /// True если уже был создан документ приходования излишков, False если нет
        /// </summary>
        private bool IsCoDoc
        {
            get
            {
                foreach (DataGridViewRow row in dgvCorrectionDocs.Rows)
                    if (((row.DataBoundItem as DataRowView).Row as Inventory.FP_Get_Correction_DocumentsRow).CorrectionType == "CO")
                        return true;
                return false;
            }
        }

        /// <summary>
        /// Загрузка инвентаризаций при загрузке окна
        /// </summary>
        private void PostInventoryFilialWindow_Load(object sender, EventArgs e)
        {
            InitPrinters();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            RefreshDocs();
        }

        /// <summary>
        /// Обновление инвентаризаций при нажатии на кнопку "Обновить"
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
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
                    cmbPrinters.Items.Add(printerName);

                var tmpSettings = new PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        #endregion

        #region ТАБЛИЦА ДОКУМЕНТОВ ИНВЕНТАРИЗАЦИИ

        /// <summary>
        /// Идентификатор выбранного документа инвентаризации (в случае, если выбрано несколько строк, возвращается идентификатор первой из них).
        /// Если таблица пустая либо в ней не выбран ни один документ, будет сгенерировано исключение
        /// </summary>
        private long SelectedInvDocId { get { return SelectedInvDoc.___документа; } }

        /// <summary>
        /// True, если в таблице документов инвентаризации выделена хотя бы одна строка а если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одной строки, либо выделено несколько
        /// документов на разных статусах
        /// </summary>
        private bool IsInvDocSelected
        {
            get
            {
                if (SelectedInvDoc == null)
                    return false;
                int status = SelectedInvDoc.Ст_;
                foreach (var doc in SelectedInvDocs)
                    if (doc.Ст_ != status)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Выбранный документ инвентаризации в таблице либо null, если таблица пустая или в ней не выбрано ни одного документа
        /// Если в таблице выделено несколько документов, то возвращается первый из них
        /// </summary>
        private Inventory.FP_Get_Correction_DocumentsRow SelectedInvDoc
        {
            get
            {
                return dgvCorrectionDocs.SelectedRows.Count == 0 ? null :
                    ((dgvCorrectionDocs.SelectedRows[0] as DataGridViewRow).DataBoundItem as DataRowView).Row as
                    Inventory.FP_Get_Correction_DocumentsRow;
            }
        }

        /// <summary>
        /// Коллекция номеров документов инвентаризаций, выделенных в таблице
        /// </summary>
        private List<long> SelectedInvDocIds
        {
            get
            {
                var ids = new List<long>();
                foreach (var doc in SelectedInvDocs)
                    ids.Add(doc.___документа);
                return ids;
            }
        }

        /// <summary>
        /// Коллекция документов инвентаризации, выделенных в таблице
        /// </summary>
        private List<Inventory.FP_Get_Correction_DocumentsRow> SelectedInvDocs
        {
            get
            {
                var list = new List<Inventory.FP_Get_Correction_DocumentsRow>();
                foreach (DataGridViewRow row in dgvCorrectionDocs.SelectedRows)
                    list.Add((row.DataBoundItem as DataRowView).Row as Inventory.FP_Get_Correction_DocumentsRow);
                return list;
            }
        }

        /// <summary>
        /// Обновление документов по заданной инвентаризации
        /// </summary>
        private void RefreshCorrectionsDocs()
        {
            try
            {
                if (SelectedInv == null)
                    inventory.FP_Get_Correction_Documents.Clear();
                else
                    taFpGetCorrection_Documents.Fill(inventory.FP_Get_Correction_Documents, UserID, SelectedInvId);
                CustomCorrectionDocsButtons();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке документов по инвентаризации!", exc);
                inventory.FP_Get_Correction_Documents.Clear();
            }
        }

        /// <summary>
        /// Обновление доступности кнопок в зависимости от выбранного документа по постинвентаризации
        /// </summary>
        private void dgvCorrectionDocs_SelectionChanged(object sender, EventArgs e)
        {
            CustomCorrectionDocsButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок для действий с документами постинвентаризации
        /// </summary>
        private void CustomCorrectionDocsButtons()
        {
            btnEditInvDoc.Visible = SelectedInvDocIds.Count == 1 &&
                (SelectedInvDoc.CorrectionType == "CO" || (SelectedInvDoc.CorrectionType == "CP" || SelectedInvDoc.CorrectionType == "CN")) && SelectedInvDoc.Ст_ == 100;
            btnShowInfo.Visible = SelectedInvDocIds.Count == 1 &&
                (SelectedInvDoc.CorrectionType == "CO" || (SelectedInvDoc.CorrectionType == "CP" || SelectedInvDoc.CorrectionType == "CN")) &&
                (SelectedInvDoc.Ст_ > 100);
            btnPrintInvoice.Visible = SelectedInvDocIds.Count == 1 && cmbPrinters.SelectedItem != null &&
                SelectedInvDoc.CorrectionType == "CO" && SelectedInvDoc.Ст_ == 199;
            btnFiles.Visible = SelectedInvDocIds.Count == 1;
            btnRunDoc.Visible = SelectedInvDocIds.Count == 1 && SelectedInvDoc.Can_Start_Correction_Document &&
               ((SelectedInvDoc.CorrectionType == "CO" && SelectedInvDoc.Ст_ == 100) ||
               ((SelectedInvDoc.CorrectionType == "CP" || SelectedInvDoc.CorrectionType == "CN") && SelectedInvDoc.Ст_ == 120));
            btnCommitDoc.Visible = SelectedInvDocIds.Count == 1 && (SelectedInvDoc.CorrectionType == "CP" || SelectedInvDoc.CorrectionType == "CN") && SelectedInvDoc.Ст_ == 100 &&
                SelectedInvDoc.Can_Update_Correction_Status;
            tssAfterFiles.Visible = btnShowInfo.Visible || btnFiles.Visible || btnEditInvDoc.Visible;
            tssAfterRunDoc.Visible = btnRunDoc.Visible || btnCommitDoc.Visible;
        }

        /// <summary>
        /// Обновление документов по инвентаризации при нажатии на кнопку "Обновить"
        /// </summary>
        private void btnRefreshCorrectionDocs_Click(object sender, EventArgs e)
        {
            RefreshCorrectionsDocs();
        }

        #endregion

        #region ПОТОВАРНЫЙ ПЕРЕСОРТ

        /// <summary>
        /// Создание документа потоварного пересорта
        /// </summary>
        private void CreatePeresort_Click(object sender, EventArgs e)
        {
            Form window;
            if (SelectedInv.AutoOperation)
                window = new PostInventoryFilialOverageForm(UserID, SelectedInv)
                {
                    Text = "Пересорт",
                    CorrectionType = "CN"
                };
            else
                window = new PostInventoryFilialItemPeresortForm(UserID, SelectedInv);

            window.ShowDialog(this);
            RefreshCorrectionsDocs();
        }

        /// <summary>
        /// Редактирование документа инвентаризации
        /// </summary>
        private void btnEditInvDoc_Click(object sender, EventArgs e)
        {
            EditInventoryDoc();
        }

        /// <summary>
        /// Редактирование документа постинвентаризации
        /// </summary>
        private void EditInventoryDoc()
        {
            Form window = null;
            if ((SelectedInvDoc.CorrectionType == "CN" || SelectedInvDoc.CorrectionType == "CP")
                && SelectedInvDoc.CorrectionType_ID == 2)
                window = new PostInventoryFilialItemPeresortForm(UserID, SelectedInv, SelectedInvDocId);
            else if (SelectedInvDoc.CorrectionType == "CO"
                || (SelectedInvDoc.CorrectionType == "CN" && SelectedInvDoc.CorrectionType_ID != 2))
                window = new PostInventoryFilialOverageForm(UserID, SelectedInv, SelectedInvDocId) { Text = SelectedInvDoc.CorrectionType == "CN" ? "Пересорт" : Text };
            window.ShowDialog(this);
        }

        /// <summary>
        /// Запуск редактирования по двойному щелчку
        /// </summary>
        private void dgvCorrectionDocs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (btnEditInvDoc.Visible)
                EditInventoryDoc();
            else if (btnShowInfo.Visible)
                ShowInfoForDoc();
        }

        /// <summary>
        /// Отображение деталей по документу
        /// </summary>
        private void ShowInfoForDoc()
        {
            var window = new PostInventoryFilialShowInfoForm(UserID, SelectedInvDoc);
            window.ShowDialog(this);
        }

        /// <summary>
        /// Отображение сделанных взаимозачетов
        /// </summary>
        private void btnShowInfo_Click(object sender, EventArgs e)
        {
            ShowInfoForDoc();
        }

        #endregion

        #region ПРИХОДОВАНИЕ ИЗЛИШКОВ

        /// <summary>
        /// Создание документа приходования излишков
        /// </summary>
        private void btnOverages_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите создать документ перемещения?", "Внимание",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            var window = new PostInventoryFilialOverageForm(UserID, SelectedInv);
            window.ShowDialog(this);
            RefreshCorrectionsDocs();
        }

        /// <summary>
        /// Печать межскладской накладной по выбранному документу приходования излишков
        /// </summary>
        private void btnPrintInvoices_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters
            {
                PrinterName = cmbPrinters.SelectedItem.ToString(),
                DocToPrint = SelectedInvDoc
            };
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Печать в фоне выделенной накладной
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = e.Argument as PrinterWorkerParameters;
                using (var report = InterbranchFacturesWindow.GetIBFactureReport(
                    "00001", param.DocToPrint.JD_DocType, param.DocToPrint.___документа_в_JDE, this.UserID))
                {
                    report.PrintOptions.PrinterName = param.PrinterName;
                    report.PrintToPrinter(1, true, 1, 0);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание фоновой печати накладной (если надо - отображение ошибки)
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Во время печати накладных произошла ошибка!", e.Result as Exception);
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати межскладской накладной
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Документ приходования излишков, для которого нужно напечатать межскладскую накладную
            /// </summary>
            public Inventory.FP_Get_Correction_DocumentsRow DocToPrint { get; set; }

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion

        #region ПРИКРЕПЛЕНИЕ ФАЙЛОВ К ДОКУМЕНТАМ

        /// <summary>
        /// Открытие окна добавления/просмотра файлов, прикрепленных к документам
        /// </summary>
        private void btnFiles_Click(object sender, EventArgs e)
        {
            var window = new PostInventoryFilialAddDocScansForm(UserID, SelectedInvDoc);
            window.ShowDialog(this);
        }

        #endregion

        #region ЗАПУСК ДОКУМЕНА В РАБОТУ

        /// <summary>
        /// Запуск документа в работу
        /// </summary>
        private void btnRunDoc_Click(object sender, EventArgs e)
        {
            try
            {
                string message;
                if ((SelectedInvDoc.CorrectionType == "CP" || SelectedInvDoc.CorrectionType == "CN"))
                    message = "Выполнить указанные взаимозачеты?";
                else
                    message = "Выполнить приходование излишков?";

                if (MessageBox.Show(message, "Выполнение документа",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    taFpGetCorrection_Documents.StartCorrectionDocument(UserID, SelectedInvDocId);
                    RefreshCorrectionsDocs();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при запуске документа в работу!", exc);
            }
        }

        /// <summary>
        /// Утверждение документа (перевод на 120й статус)
        /// </summary>
        private void btnCommitDoc_Click(object sender, EventArgs e)
        {
            try
            {
                taFpGetCorrection_Documents.UpdateCorrectionStatus(UserID, SelectedInvDocId);
                RefreshCorrectionsDocs();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время утверждения документа возникла ошибка!", exc);
            }
        }

        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                var reportData = new FP_Report_CorrectionTableAdapter().GetData(SelectedInvId);

                if (reportData.Rows.Count == 0)
                {
                    Logger.ShowErrorMessageBox("Нет данных для экспорта!");
                    return;
                }

                List<string> columns = new List<string>();
                foreach (DataColumn item in reportData.Columns)
                    columns.Add(item.ColumnName);

                var errorMsg = ExportHelper.ExportDataTableToExcel(reportData, columns.ToArray(), columns.ToArray(), "Экспорт в Excel", "Пересорт", true);
                if (String.IsNullOrEmpty(errorMsg))
                    return;

                Logger.ShowErrorMessageBox(errorMsg);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время экспорта возникла ошибка!", ex);
            }
        }
    }

    /// <summary>
    /// Представление для грида с инвентаризациями
    /// </summary>
    public class PostInventoryFilialView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

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
            var sc = pSearchParameters as PostInventoryFilialSearchParameters;
            using (var adapter = new FP_Get_InventoriesTableAdapter())
                data = adapter.GetData((int)sc.SessionID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public PostInventoryFilialView()
        {
            this.dataColumns.Add(new PatternColumn("ID филиала", "Filial_ID", new FilterPatternExpressionRule("Filial_ID"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Филиал", "Filial_Name", new FilterPatternExpressionRule("Filial_Name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ инв.", "Inventory_number", new FilterCompareExpressionRule<Int64>("Inventory_number"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Описание статуса", "Status_Name", new FilterPatternExpressionRule("Status_Name"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Дата инвентаризации", "InventoryDate", new FilterDateCompareExpressionRule("InventoryDate"), SummaryCalculationType.Count) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Описание", "Description", new FilterPatternExpressionRule("Description"), SummaryCalculationType.Count) { Width = 300 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка инвентаризаций
    /// </summary>
    public class PostInventoryFilialSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
    }
}
