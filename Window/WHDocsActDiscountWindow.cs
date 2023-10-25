using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.WH;
using WMSOffice.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно для работы с актами скидок
    /// </summary>
    public partial class WHDocsActDiscountWindow : GeneralWindow
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Идентификатор выбранного акта скидки (в случае, если выбрано несколько строк, возвращается идентификатор первого из них).
        /// Если таблица пустая либо в ней не выбрана ни один акт скидки, будет сгенерировано исключение
        /// </summary>
        private int SelectedDocId { get { return Convert.ToInt32(dgvActs.SelectedItem["Doc_ID"]); } }

        /// <summary>
        /// True, если в таблице актов выделен хотя бы один акт и если несколько, то все они имеют одинаковый статус
        /// False, если таблица пуста либо в таблице не выделено ни одного акта, либо выделено несколько актов с разными статусами
        /// </summary>
        private bool IsDocSelected
        {
            get
            {
                if (dgvActs.SelectedItem == null)
                    return false;
                int status = SelectedDoc.Status_ID;
                foreach (var doc in SelectedDocs)
                    if (doc.Status_ID != status)
                        return false;
                return true;
            }
        }

        /// <summary>
        /// Выбранный акт в таблице либо null, если таблица пустая или в ней не выбрано ни одного акта скидки.
        /// Если в таблице выделено несколько актов, то возвращается первый из них
        /// </summary>
        private WH.AS_Get_DocsRow SelectedDoc { get { return dgvActs.SelectedItem as WH.AS_Get_DocsRow; } }

        /// <summary>
        /// Коллекция идентификаторов актов, выделенных в таблице. Если не выделен ни один акт, то коллекция пуста
        /// </summary>
        private List<long> SelectedDocIds
        {
            get
            {
                var ids = new List<long>();
                foreach (var doc in SelectedDocs)
                    ids.Add(doc.Doc_ID);
                return ids;
            }
        }

        /// <summary>
        /// Коллекция актов скидок, выделенных в таблице. Если не выделен ни один акт, то коллекция пуста
        /// </summary>
        private IEnumerable<WH.AS_Get_DocsRow> SelectedDocs
        {
            get
            {
                return
                    dgvActs.SelectedItems.ConvertAll(new Converter<DataRow, WH.AS_Get_DocsRow>(x => x as WH.AS_Get_DocsRow));
            }
        }

        /// <summary>
        /// Название таблицы с актами скидок в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Header", Name); } }

        /// <summary>
        /// БД адаптер для работы с актами скидок
        /// </summary>
        private AS_Get_DocsTableAdapter docsAdapter = new AS_Get_DocsTableAdapter();

        /// <summary>
        /// Признак группировки данных АС по РН
        /// </summary>
        private readonly bool _groupByInvoice = true;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public WHDocsActDiscountWindow()
        {
            InitializeComponent();
            InitPrinters();
            InitializeActDiscountGrid();
        }

        /// <summary>
        /// Загрузка данных при открытии окна
        /// </summary>
        private void WHDocsActDiscountWindow_Load(object sender, EventArgs e)
        {
            LoadUserAccesses();
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

        /// <summary>
        /// Начальная инициализация фильтруемого грида с накладными при создании окна
        /// </summary>
        private void InitializeActDiscountGrid()
        {
            dgvActs.Init(new ActDiscountView(), true);
            dgvActs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvActs.UserID = UserID;
            dgvActs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvActs.AllowRangeColumns = true;
            dgvActs.UseMultiSelectMode = true;
            dgvActs.AllowSummary = false;

            dgvActs.OnFilterChanged += dgvActs_OnFilterChanged;
            dgvActs.OnRowSelectionChanged += dgvActs_OnRowSelectionChanged;
            dgvActs.OnRowDoubleClick += dgvActs_OnRowDoubleClick;
            dgvActs.OnCellContentClick += new DataGridViewCellEventHandler(dgvActs_OnCellContentClick);
            dgvActs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(dgvActs_OnFormattingCell);
            dgvActs.OnDataError += new DataGridViewDataErrorEventHandler(dgvActs_OnDataError);

            // активация постраничного просмотра
            dgvActs.CreatePageNavigator();
        }

        void dgvActs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void dgvActs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var actRow = (dgvActs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.AS_Get_DocsRow;
                var edFlag = actRow.IsEDFlagNull() ? false : actRow.EDFlag;

                if (edFlag)
                {
                    var color = Color.Khaki;
                    e.CellStyle.BackColor = color;
                    e.CellStyle.SelectionForeColor = color;
                }
            }
            catch (Exception ex)
            { 
            
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            CustomButtons();
            RefreshDocs();
        }

        /// <summary>
        /// Обновление данных в таблице актов скидок с сохранением выделения и прокрутки
        /// </summary>
        private void RefreshDocs()
        {
            dgvActs.SaveExtraDataGridViewSettings(ConfigDocsTableName);
            var selectedDocIds = SelectedDocIds;

            RefreshDataViewBinding();

            dgvActs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvActs.UnselectAllRows();

            bool isSelected = false;
            foreach (var id in selectedDocIds)
            {
                dgvActs.SelectRow("Doc_ID", id.ToString());
                isSelected = true;
            }

            if (!isSelected)
                dgvActs.SelectRow(0);

            dgvActs.ScrollToSelectedRow();
            CustomButtons();
        }

        /// <summary>
        /// Загрузка актов скидок в фильтруемый грид из БД
        /// </summary>
        private void RefreshDataViewBinding()
        {
            try
            {
                var searchParams = new ActDiscountSearchParameters() { SessionID = this.UserID };
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.dgvActs.DataView.FillData(e.Argument as ActDiscountSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        this.dgvActs.BindData(false);

                        //this.dgvActs.AllowFilter = true;
                        this.dgvActs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка актов скидок..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //try
            //{
            //    dgvActs.DataView.FillData(new ActDiscountSearchParameters() { SessionID = UserID });
            //    dgvActs.BindData(false);
                
            //    dgvActs.AllowSummary = true;
            //}
            //catch (Exception exc)
            //{
            //    ShowError("Не удалось загрузить список актов скидок: " + Environment.NewLine + exc.Message);
            //}
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvActs_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvActs.RecalculateSummary();
            CustomButtons();
        }

        /// <summary>
        /// Обновление списка актов скидок при нажатии на кнопку "Обновить"
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Обновление статусов кнопок при изменении выделенного акта
        /// </summary>
        private void dgvActs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранного акта скидки
        /// </summary>
        private void CustomButtons()
        {
            var fullAccess = SelectedDoc != null && !SelectedDoc.Read_only;

            btnAddAct.Visible = miAddNewAct.Enabled = fullAccess && canCreateAct;
            btnAddActPrc.Visible = miAddNewActPrc.Enabled = fullAccess && canCreateActPrc;

            btnAddActSelector.Visible = fullAccess && (canCreateAct || canCreateActPrc);

            btnAddManyActs.Visible = fullAccess && canBulkInsertAct;
            btnEditAct.Visible = miEdit.Enabled = fullAccess && IsDocSelected && SelectedDocIds.Count == 1 && SelectedDoc.Status_ID == 100 && canEditAct;

            var edFlag = IsDocSelected ? (SelectedDoc.IsEDFlagNull() ? false : SelectedDoc.EDFlag) : false;
            btnPreviewActDiscount.Visible = miPreviewActDiscount.Enabled = IsDocSelected && SelectedDocIds.Count == 1 && canPrintAct && !edFlag;
            btnPrintActsDiscount.Visible = miPrintActsDiscount.Enabled = fullAccess && IsDocSelected && canPrintAct && !edFlag;
            btnSendEDoc.Visible = miSendEDoc.Enabled = fullAccess && IsDocSelected && canPrintAct && edFlag && SelectedDoc.Status_ID == 100;

            btnCloseActDiscount.Visible = miCloseActDiscount.Enabled = fullAccess && IsDocSelected && (SelectedDoc.Status_ID == 130 || SelectedDoc.Status_ID == 135) && SelectedDoc.RkStatus != 590 && canCloseAct;
            btnDeleteActDiscount.Visible = miDeleteActDiscount.Enabled = fullAccess && IsDocSelected && SelectedDoc.Status_ID == 100 && canDeleteAct;

            tssAfterActEdit.Visible = btnAddActSelector.Visible || btnAddManyActs.Visible || btnDeleteActDiscount.Visible;

            tssAfterPrint.Visible = btnPrintActsDiscount.Visible || btnPreviewActDiscount.Visible;

            miOriginalReceived.Enabled = fullAccess && this.SelectedDoc != null && !edFlag;

            btnChangeActDate.Visible = miChangeActDate.Enabled = fullAccess && IsDocSelected && SelectedDocIds.Count == 1 && (SelectedDoc.IsCan_Change_Doc_DateNull() ? false : SelectedDoc.Can_Change_Doc_Date);
        }

        /// <summary>
        /// Сохранение состояния колонок таблицы актов скидок при закрытии окна
        /// </summary>
        private void WHDocsActDiscountWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvActs.SaveExtraDataGridViewSettings(ConfigDocsTableName);
        }

        #endregion

        #region ПРАВА ДОСТУПА НА КНОПКИ

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать акт скидки
        /// </summary>
        private bool canCreateAct;

        /// <summary>
        /// Признак, показывающий, может ли пользователь создавать акт скидки PRC
        /// </summary>
        private bool canCreateActPrc;

        /// <summary>
        /// Признак, показывающий, может ли пользователь осуществлять массовую вставку актов скидки
        /// </summary>
        private bool canBulkInsertAct;

        /// <summary>
        /// Признак, показывающий, может ли пользователь редактировать акт скидки
        /// </summary>
        private bool canEditAct;

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать и просматривать акт скидки
        /// </summary>
        private bool canPrintAct;

        /// <summary>
        /// Признак, показывающий, может ли пользователь журнализировать акт скидки
        /// </summary>
        private bool canCloseAct;

        /// <summary>
        /// Признак, показывающий, может ли пользователь удалять акт скидки
        /// </summary>
        private bool canDeleteAct;

        /// <summary>
        /// Признак, показывающий, имеет ли пользователь доступ к расчет-корректировкам
        /// </summary>
        private bool canCalculation;

        /// <summary>
        /// Загрузка прав пользователей
        /// </summary>
        private void LoadUserAccesses()
        {
            try
            {
                using (var adapter = new AS_AccessTableAdapter())
                {
                    var table = adapter.GetData(UserID);
                    canCreateAct = GetAccess(table, "canInsert");
                    canCreateActPrc = GetAccess(table, "canCreate");
                    canBulkInsertAct = GetAccess(table, "canBulkInsert");
                    canEditAct = GetAccess(table, "canEdit");
                    canPrintAct = GetAccess(table, "canPrint");
                    canCloseAct = GetAccess(table, "canClose");
                    canDeleteAct = GetAccess(table, "canDelete");
                    canCalculation = GetAccess(table, "canСalculation");
                }
            }
            catch (Exception exc)
            {
                ShowError("Не удалось загрузить роли пользователя для актов скидок: " + Environment.NewLine + exc.Message);
            }
        }

        /// <summary>
        /// Получение значение права доступа по его ключу
        /// </summary>
        /// <param name="pAccesses">Таблица с правами доступа</param>
        /// <param name="pKey">Ключ, которых характеризирует получаемое право доступа</param>
        /// <returns>True, если пользователь имеет право доступа, False если не имеет</returns>
        private static bool GetAccess(WH.AS_AccessDataTable pAccesses, string pKey)
        {
            foreach (WH.AS_AccessRow row in pAccesses)
                if (row.Entity_Key == pKey)
                    return row.Entity_Value;

            return false;
        }

        #endregion

        #region ОТОБРАЖЕНИЕ РАСЧЕТ-КОРРЕКТИРОВОК АКТА СКИДКИ

        /// <summary>
        /// Отображение окна с расчет-корректировками акта скидки
        /// </summary>
        private void dgvActs_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!IsDocSelected || !canCalculation)
                return;

            var window = new ActDiscountRKsForm(SelectedDoc, UserID) { Owner = this };
            window.ShowDialog();
        }

        #endregion

        #region УСТАНОВКА ПРИЗНАКА "ПОЛУЧЕН ОРИГИНАЛ"

        void dgvActs_OnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvActs.DataGrid.Columns[e.ColumnIndex].DataPropertyName == "HaveOriginal")
                this.ChangeOriginalReceived();
        }

        private void miOriginalReceived_Click(object sender, EventArgs e)
        {
            this.ChangeOriginalReceived();
        }

        private void ChangeOriginalReceived()
        {
            try
            {
                if (!IsDocSelected)
                    return;

                var edFlag = SelectedDoc.IsEDFlagNull() ? false : SelectedDoc.EDFlag;
                if (edFlag)
                    return;

                var isChecked = SelectedDoc.IsHaveOriginalNull() ? false : SelectedDoc.HaveOriginal;
                var targetFlag = !isChecked;

                foreach (var doc in SelectedDocs)
                {
                    var actID = doc.Doc_ID;

                    using (var adapter = new Data.WHTableAdapters.AS_Get_DocsTableAdapter())
                        adapter.ChangeOriginalReceivedFlag(actID, targetFlag, UserID);

                    doc.HaveOriginal = targetFlag;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время изменения признака \"Оригинал получен\" возникла ошибка:", exc);
            }
        }

        #endregion

        #region СОЗДАНИЕ И РЕДАКТИРОВАНИЕ АКТА СКИДКИ

        private void btnAddActSelector_ButtonClick(object sender, EventArgs e)
        {
            btnAddActSelector.ShowDropDown();
        }

        /// <summary>
        /// Создание нового акта скидки
        /// </summary>
        private void btnAddAct_Click(object sender, EventArgs e)
        {
            var window = new ActDiscountEditForm(UserID) { Owner = this, Text = "Создание акта скидки" };
            if (window.ShowDialog() == DialogResult.OK)
                RefreshDocs();
        }

        /// <summary>
        /// Создание нового акта скидки PRC
        /// </summary>
        private void btnAddActPrc_Click(object sender, EventArgs e)
        {
            var window = new ActDiscountPrcEditForm(UserID) { Owner = this, Text = "Создание акта скидки по товару" };
            if (window.ShowDialog() == DialogResult.OK)
                RefreshDocs();
        }

        /// <summary>
        /// Редактирование акта скидки
        /// </summary>
        private void btnEditAct_Click(object sender, EventArgs e)
        {
            var window = SelectedDoc.Short_Doc_Type.Equals("PRC") 
                ? (Form)new ActDiscountPrcEditForm(UserID, SelectedDoc) { Owner = this, Text = "Редактирование акта скидки по товару" }
                : (Form)new ActDiscountEditForm(UserID, SelectedDoc) { Owner = this, Text = "Редактирование акта скидки" };
            if (window.ShowDialog() == DialogResult.OK)
                RefreshDocs();
        }

        /// <summary>
        /// Массовая вставка актов скидки
        /// </summary>
        private void btnAddManyActs_Click(object sender, EventArgs e)
        {
            var window = new ActDiscountManyActsInsertForm(UserID) { Owner = this };
            window.ShowDialog();
        }

        /// <summary>
        /// Удаление акта скидки
        /// </summary>
        private void btnDeleteActDiscount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите удалить выбранные акты скидки?", "Удаление актов скидок",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            foreach (var doc in SelectedDocs)
                try
                {
                    docsAdapter.DeleteAct(doc.Doc_ID, UserID);
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Не удалось удалить акт скидки № {0}:", doc.Doc_ID) +
                        Environment.NewLine + exc.Message);
                }

            RefreshDocs();
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ АКТОВ СКИДКИ

        /// <summary>
        /// Печать выбранных актов скидки
        /// </summary>
        private void btnPrintActsDiscount_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;

            var window = new EnterSignaturerForDiscountAct() { Owner = this };
            window.ShowDialog();

            // Формируем АС консолидированно в разрезе РН (исключение лишь составляют дебиторы 60582, 243 - с расшифровкой товара)
            var groupByInvoice = (SelectedDoc.Debtor_ID == 60582 || SelectedDoc.Debtor_ID == 243) ? false : _groupByInvoice;

            var parameters = new PrinterWorkerParameters()
            {
                PrinterName = (string)cbPrinters.SelectedItem,
                Signaturer = window.Signaturer,
                GroupByInvoice = groupByInvoice
            };
            parameters.DocsToPrint.AddRange(SelectedDocs);
            printWorker.RunWorkerAsync(parameters);
        }

        /// <summary>
        /// Печатает в фоне акты скидок, выбранные в таблице
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (PrinterWorkerParameters)e.Argument;
                var groupByInvoice = param.GroupByInvoice;

                foreach (var doc in param.DocsToPrint)
                {
                    var edFlag = doc.IsEDFlagNull() ? false : doc.EDFlag; // признак электронного АС

                    #region ФОРМИРОВАНИЕ ПЕЧАТНЫХ ДОКУМЕНТОВ С ПОСЛЕДУЮЩЕЙ ПЕЧАТЬЮ

                    if (doc != null && !String.IsNullOrEmpty(doc.Doc_Type_ID))
                    {
                        if (!doc.IsShort_Doc_TypeNull() && doc.Short_Doc_Type == "COR")
                        {
                            var ds = PrepareDataSetForActDiscountExtModifiedPrinting(doc, String.Empty, groupByInvoice);
                            using (var report = groupByInvoice ? (ReportClass)new WhActDiscountExtModified_ByInvoice_Report() : (ReportClass)new WhActDiscountExtModifiedReport())
                            {
                                report.PrintOptions.PrinterName = param.PrinterName;
                                report.SetDataSource(ds);
                                report.PrintToPrinter(2, true, 1, 0);

                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                            }
                        }
                        else
                        {
                            if (doc.Doc_Type_ID == "ACT")
                            {
                                if (doc.Short_Doc_Type == "CND")
                                {
                                    var ds = PrepareDataSetForActDiscountCNDPrinting(doc);
                                    using (var report = (ReportClass)new WhActDiscountCNDReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                                else if (doc.Short_Doc_Type == "CNR")
                                {
                                    var ds = PrepareDataSetForActDiscountCNRPrinting(doc);
                                    using (var report = (ReportClass)new WhActDiscountCNRReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                                else if (doc.Short_Doc_Type == "FPP")
                                {
                                    var ds = PrepareDataSetForActDiscountFPPPrinting(doc, String.Empty, true);
                                    using (var report = (ReportClass)new WhActDiscountFPPReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                                else if (doc.Short_Doc_Type == "FPM")
                                {
                                    var ds = PrepareDataSetForActDiscountFPMPrinting(doc, String.Empty, true);
                                    using (var report = (ReportClass)new WhActDiscountFPMReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                                else if (SelectedDoc.Short_Doc_Type == "OOC")
                                {
                                    var ds = PrepareDataSetForActDiscountExtPrinting(SelectedDoc, String.Empty, false);
                                    using (var report = (ReportClass)new WhActDiscountOOCReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                                else
                                {
                                    var ds = PrepareDataSetForActDiscountExtPrinting(doc, String.Empty, groupByInvoice);
                                    using (var report = groupByInvoice ? (ReportClass)new WhActDiscountExt_ByInvoice_Report() : (ReportClass)new WhActDiscountExtReport())
                                    {
                                        report.PrintOptions.PrinterName = param.PrinterName;
                                        report.SetDataSource(ds);
                                        report.PrintToPrinter(2, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                    }
                                }
                            }
                            else
                            {
                                var ds = PrepareDataSetForActTransitDiscountPrinting(doc, String.Empty);
                                using (var report = new WhActDiscountTransitReport())
                                {
                                    report.PrintOptions.PrinterName = param.PrinterName;
                                    report.SetDataSource(ds);
                                    report.PrintToPrinter(2, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                                }
                            }
                        }
                    }
                    else
                    {
                        var ds = PrepareDataSetForActDiscountPrinting(doc, param.Signaturer);
                        using (var report = new WhActDiscountReport())
                        {
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.SetDataSource(ds);
                            PrepareReportParameters(report, doc);
                            report.PrintToPrinter(2, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), param.PrinterName, 2);
                        }
                    }

                    #endregion

                    // Перевод статуса документа после печати
                    using (var adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                        adapter.UpdateActStatus(doc.Doc_ID, edFlag);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountCNDPrinting(WH.AS_Get_DocsRow pRow)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            using (var adapter = new AS_CND_Act_DetailsTableAdapter())
                adapter.Fill(dataSet.AS_CND_Act_Details, pRow.Doc_ID);

            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountCNRPrinting(WH.AS_Get_DocsRow pRow)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            using (var adapter = new AS_CND_Act_DetailsTableAdapter())
                adapter.Fill(dataSet.AS_CND_Act_Details, pRow.Doc_ID);

            //using (var adapter = new AS_CNR_Act_DetailsTableAdapter())
            //    adapter.Fill(dataSet.AS_CNR_Act_Details, pRow.Doc_ID);

            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <param name="pGroupByInvoice">Признак группировки данных по РН</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountFPPPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer, bool pGroupByInvoice)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            var edFlag = pRow.IsEDFlagNull() ? false : pRow.EDFlag; // признак электронного АС

            using (var adapter = new NomenclatureAct_DetailsTableAdapter())
            {
                adapter.SetTimeout(180);

                if (pGroupByInvoice)
                    adapter.FillByInvoice(dataSet.NomenclatureAct_Details, pRow.Doc_ID, edFlag);
                else
                    adapter.Fill(dataSet.NomenclatureAct_Details, pRow.Doc_ID);
            }

            using (var adapter = new NomenclatureAct_HeaderTableAdapter())
            {
                adapter.SetTimeout(180);
                adapter.Fill(dataSet.NomenclatureAct_Header, pRow.Doc_ID, pSignaturer, edFlag);
            }
            //CreateBarCode(dataSet.Get_TransitDiscountAct_Details.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <param name="pGroupByInvoice">Признак группировки данных по РН</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountFPMPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer, bool pGroupByInvoice)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            var edFlag = pRow.IsEDFlagNull() ? false : pRow.EDFlag; // признак электронного АС

            using (var adapter = new NomenclatureAct_DetailsTableAdapter())
            {
                adapter.SetTimeout(180);

                if (pGroupByInvoice)
                    adapter.FillByInvoice(dataSet.NomenclatureAct_Details, pRow.Doc_ID, edFlag);
                else
                    adapter.Fill(dataSet.NomenclatureAct_Details, pRow.Doc_ID);
            }

            using (var adapter = new NomenclatureAct_HeaderTableAdapter())
            {
                adapter.SetTimeout(180);
                adapter.Fill(dataSet.NomenclatureAct_Header, pRow.Doc_ID, pSignaturer, edFlag);
            }
            //CreateBarCode(dataSet.Get_TransitDiscountAct_Details.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActTransitDiscountPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            using (var adapter = new Get_TransitDiscountAct_DetailsTableAdapter())
                adapter.Fill(dataSet.Get_TransitDiscountAct_Details, pRow.Doc_ID);

            using (var adapter = new Get_TransitDiscountAct_HeaderTableAdapter())
                adapter.Fill(dataSet.Get_TransitDiscountAct_Header, pRow.Doc_ID, pSignaturer);
            //CreateBarCode(dataSet.Get_TransitDiscountAct_Details.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <param name="pGroupByInvoice">Признак группировки данных по РН</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountExtPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer, bool pGroupByInvoice)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            var edFlag = pRow.IsEDFlagNull() ? false : pRow.EDFlag; // признак электронного АС

            using (var adapter = new NomenclatureAct_DetailsTableAdapter())
            {
                adapter.SetTimeout(180);

                if (pGroupByInvoice)
                    adapter.FillByInvoice(dataSet.NomenclatureAct_Details, pRow.Doc_ID, edFlag);
                else
                    adapter.Fill(dataSet.NomenclatureAct_Details, pRow.Doc_ID);
            }

            using (var adapter = new NomenclatureAct_HeaderTableAdapter())
            {
                adapter.SetTimeout(180);
                adapter.Fill(dataSet.NomenclatureAct_Header, pRow.Doc_ID, pSignaturer, edFlag);
            }
            //CreateBarCode(dataSet.Get_TransitDiscountAct_Details.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <param name="pGroupByInvoice">Признак группировки данных по РН</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountExtModifiedPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer, bool pGroupByInvoice)
        {
            var dataSet = new WH();

            dataSet.AS_Get_Docs.LoadDataRow(pRow.ItemArray, true);

            var edFlag = pRow.IsEDFlagNull() ? false : pRow.EDFlag; // признак электронного АС

            using (var adapter = new NomenclatureActDiscount_DetailsTableAdapter())
            {
                adapter.SetTimeout(180);

                if (pGroupByInvoice)
                    adapter.FillByInvoice(dataSet.NomenclatureActDiscount_Details, pRow.Doc_ID);
                else
                    adapter.Fill(dataSet.NomenclatureActDiscount_Details, pRow.Doc_ID);
            }

            using (var adapter = new NomenclatureAct_HeaderTableAdapter())
            {
                adapter.SetTimeout(180);
                adapter.Fill(dataSet.NomenclatureAct_Header, pRow.Doc_ID, pSignaturer, edFlag);
            }
            //CreateBarCode(dataSet.Get_TransitDiscountAct_Details.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид актов скидок
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные акта скидки</param>
        /// <param name="pSignaturer">Подписант со стороны дебитора</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид акта скидки</returns>
        private WH PrepareDataSetForActDiscountPrinting(WH.AS_Get_DocsRow pRow, string pSignaturer)
        {
            var dataSet = new WH();
            using (var adapter = new AS_Get_Discounts_ActTableAdapter())
                adapter.Fill(dataSet.AS_Get_Discounts_Act, pRow.Doc_ID, pSignaturer);
            CreateBarCode(dataSet.AS_Get_Discounts_Act.Rows[0] as WH.AS_Get_Discounts_ActRow);
            return dataSet;
        }

        /// <summary>
        /// Создание штрих-кода в виде байтового массива по текстовому представлению штрих кода
        /// </summary>
        /// <param name="pHeaderRow">Строка в БД, содержащая данные об акте скидок</param>
        private static void CreateBarCode(WH.AS_Get_Discounts_ActRow pHeaderRow)
        {
            var barCodeCtrl = new BarCodeCtrl();
            barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
            barCodeCtrl.Size = new Size(720, 200);
            barCodeCtrl.BarCodeHeight = 140;
            barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
            barCodeCtrl.HeaderText = String.Empty;
            barCodeCtrl.LeftMargin = 10;
            barCodeCtrl.ShowFooter = true;
            barCodeCtrl.TopMargin = 20;
            barCodeCtrl.BarCode = pHeaderRow.Barcode;
            byte[] barCode = null;
            using (var ms = new MemoryStream())
            {
                barCodeCtrl.GetImage().Save(ms, ImageFormat.Bmp);
                barCode = ms.ToArray();
            }
            pHeaderRow.Bar_Code_IMG = barCode;
        }

        /// <summary>
        /// Обработка окончания печати отчетов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError((e.Result as Exception).Message);
        }

        /// <summary>
        /// Просмотр акта скидки
        /// </summary>
        private void btnPreviewActDiscount_Click(object sender, EventArgs e)
        {
            try
            {
                // Формируем АС консолидированно в разрезе РН (исключение лишь составляют дебиторы 60582, 243 - с расшифровкой товара)
                var groupByInvoice = (SelectedDoc.Debtor_ID == 60582 || SelectedDoc.Debtor_ID == 243) ? false : _groupByInvoice;

                var edFlag = SelectedDoc.IsEDFlagNull() ? false : SelectedDoc.EDFlag;

                using (var reportForm = new ReportForm())
                {
                    if (SelectedDoc != null && !String.IsNullOrEmpty(SelectedDoc.Doc_Type_ID))
                    {
                        if (!SelectedDoc.IsShort_Doc_TypeNull() && SelectedDoc.Short_Doc_Type == "COR")
                        {
                            var ds = PrepareDataSetForActDiscountExtModifiedPrinting(SelectedDoc, String.Empty, groupByInvoice);
                            using (var report = groupByInvoice ? (ReportClass)new WhActDiscountExtModified_ByInvoice_Report() : (ReportClass)new WhActDiscountExtModifiedReport())
                            {
                                report.SetDataSource(ds);
                                reportForm.ReportDocument = report;
                                reportForm.ShowDialog();

                                if (reportForm.IsPrinted)
                                {
                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                }
                            }
                        }
                        else
                        {
                            if (SelectedDoc.Doc_Type_ID == "ACT")
                            {
                                if (SelectedDoc.Short_Doc_Type == "CND")
                                {
                                    var ds = PrepareDataSetForActDiscountCNDPrinting(SelectedDoc);
                                    using (var report = (ReportClass)new WhActDiscountCNDReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                                else if (SelectedDoc.Short_Doc_Type == "CNR")
                                {
                                    var ds = PrepareDataSetForActDiscountCNRPrinting(SelectedDoc);
                                    using (var report = (ReportClass)new WhActDiscountCNRReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                                else if (SelectedDoc.Short_Doc_Type == "FPP")
                                {
                                    var ds = PrepareDataSetForActDiscountFPPPrinting(SelectedDoc, String.Empty, true);
                                    using (var report = (ReportClass)new WhActDiscountFPPReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                                else if (SelectedDoc.Short_Doc_Type == "FPM")
                                {
                                    var ds = PrepareDataSetForActDiscountFPMPrinting(SelectedDoc, String.Empty, true);
                                    using (var report = (ReportClass)new WhActDiscountFPMReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                                else if (SelectedDoc.Short_Doc_Type == "OOC")
                                {
                                    var ds = PrepareDataSetForActDiscountExtPrinting(SelectedDoc, String.Empty, false);
                                    using (var report = (ReportClass)new WhActDiscountOOCReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                                else
                                {
                                    var ds = PrepareDataSetForActDiscountExtPrinting(SelectedDoc, String.Empty, groupByInvoice);
                                    using (var report = groupByInvoice ? (ReportClass)new WhActDiscountExt_ByInvoice_Report() : (ReportClass)new WhActDiscountExtReport())
                                    {
                                        report.SetDataSource(ds);
                                        reportForm.ReportDocument = report;
                                        reportForm.ShowDialog();

                                        if (reportForm.IsPrinted)
                                        {
                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                        }
                                    }
                                }
                            }
                            else
                            {
                                var ds = PrepareDataSetForActTransitDiscountPrinting(SelectedDoc, String.Empty);
                                using (var report = new WhActDiscountTransitReport())
                                {
                                    report.SetDataSource(ds);
                                    reportForm.ReportDocument = report;
                                    reportForm.ShowDialog();

                                    if (reportForm.IsPrinted)
                                    {
                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        var ds = PrepareDataSetForActDiscountPrinting(SelectedDoc, String.Empty);
                        //using (var reportForm = new ReportForm())
                        using (var report = new WhActDiscountReport())
                        {
                            report.SetDataSource(ds);
                            PrepareReportParameters(report, SelectedDoc);
                            reportForm.ReportDocument = report;
                            reportForm.ShowDialog();

                            if (reportForm.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "AS", 21, Convert.ToInt64(SelectedDoc.Doc_ID), (string)null, Convert.ToInt16(ds.NomenclatureActDiscount_Details.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка: " + Environment.NewLine +
                    exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareReportParameters(WhActDiscountReport report, Data.WH.AS_Get_DocsRow doc)
        {
            bool isDefaultDiscountAct = doc.IsDebtor_IDNull() || doc.Debtor_ID != 12225;
            report.SetParameterValue("Title", isDefaultDiscountAct ? "НАДАННЯ ЗНИЖКИ" : "ЗМЕНШЕННЯ ЦІНИ");
            report.SetParameterValue("ActionText", isDefaultDiscountAct ? "Постачальник надає Покупцю знижку" : "Сторони домовились на зменшення ціни");
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати актов скидок
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Список актов скидок, которые нужно напечатать
            /// </summary>
            public List<WH.AS_Get_DocsRow> DocsToPrint = new List<WH.AS_Get_DocsRow>();

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }

            /// <summary>
            /// Подписант акта скидки со стороны дебитора
            /// </summary>
            public string Signaturer { get; set; }

            /// <summary>
            /// Признак формирования АС нового образца
            /// </summary>
            public bool GroupByInvoice { get; set; }
        }

        #endregion

        #region ЖУРНАЛИЗАЦИЯ АКТА СКИДКИ

        /// <summary>
        /// Журнализация акта скидки
        /// </summary>
        private void btnCloseActDiscount_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы точно хотите журнализовать выбранные акты скидок?", "Журнализация",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (var doc in SelectedDocs)
                try
                {
                    using (var adapter = new AS_Get_CalculationsTableAdapter())
                    {
                        adapter.SetTimeout(180);
                        foreach (WH.AS_Get_CalculationsRow row in adapter.GetData(doc.Doc_ID))
                            adapter.Logging_Calculation(UserID, row.Calculation_Number, row.Calculation_Type);
                    }
                }
                catch (Exception exc)
                {
                    ShowError(String.Format("Ошибка во время журнализации расчет-корректировок в акте скидки № {0}:", doc.Doc_ID) +
                        Environment.NewLine + exc.Message);
                }

            RefreshDocs();
        }

        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                dgvActs.ExportToExcel("Экспорт актов скидок в Excel", "акты скидок", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время экспорта актов скидок в Excel возникла ошибка:", exc);
            }
        }

        private void btnChangeActDate_Click(object sender, EventArgs e)
        {
            var actID = this.SelectedDoc.Doc_ID;
            var actDate = this.SelectedDoc.IsDoc_DateNull() ? DateTime.Today : this.SelectedDoc.Doc_Date;

            var form = new DiscountActDateEditorForm() { ActDate = actDate };
            if (form.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var adapter = new AS_Get_DocsTableAdapter())
                        adapter.EditActDate(this.UserID, actID, form.ActDate.Date); 

                    this.RefreshDocs();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        #region ОБРАБОТКА ЭЛЕКТРОННЫХ ДОКУМЕНТОВ

        private void btnSendEDoc_Click(object sender, EventArgs e)
        {
            //this.SendEDoc();
            this.SendEDocPackage();
        }

        private void SendEDocPackage()
        {
            try
            {
                var sendSplashForm = new WMSOffice.Dialogs.SplashForm();
                var success = false;

                var sendWorker = new BackgroundWorker();
                sendWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        var sbErrors = new StringBuilder();

                        var docs = e.Argument as IEnumerable<WH.AS_Get_DocsRow>;
                        foreach (var doc in docs)
                        {
                            try
                            {
                                var edFlag = doc.IsEDFlagNull() ? false : doc.EDFlag;
                                var statusID = doc.Status_ID;

                                // Отправка для типа ЭД для 100-го статуса
                                if (edFlag && statusID == 100)
                                    this.SendEDoc(doc);
                            }
                            catch (Exception ex)
                            {
                                if (sbErrors.Length > 0)
                                    sbErrors.AppendFormat("\r\n-\tАкт № {0} : {1}", doc.Doc_ID, ex.Message);
                                else
                                    sbErrors.AppendFormat("-\tАкт № {0} : {1}", doc.Doc_ID, ex.Message);
                            }
                        }

                        if (sbErrors.Length > 0)
                            throw new Exception(string.Format("Отправка ЭД АС завершена с ошибками:\r\n\r\n{0}", sbErrors.ToString()));
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                sendWorker.RunWorkerCompleted += (s, e) => 
                {
                    sendSplashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        success = true;
                };
                sendSplashForm.ActionText = "Выполняется отправка ЭД АС..";
                sendWorker.RunWorkerAsync(this.SelectedDocs);
                sendSplashForm.ShowDialog();

                if (success)
                    MessageBox.Show("Отправка ЭД АС завершена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void SendEDoc()
        {
            this.SendEDoc(this.SelectedDoc);
        }

        private void SendEDoc(WH.AS_Get_DocsRow doc)
        {
            try
            {
                var edFlag = doc.IsEDFlagNull() ? false : doc.EDFlag;

                // Перевод статуса документа после печати
                using (var adapter = new Data.ComplaintsTableAdapters.QueriesTableAdapter())
                {
                    adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                    adapter.UpdateActStatus(doc.Doc_ID, edFlag);
                }
            }
            catch (Exception ex)
            {
                //this.ShowError(ex);
                throw ex;
            }
        }

        #endregion
    }

    /// <summary>
    /// Представление для грида с актами скидок
    /// </summary>
    public class ActDiscountView : IDataView
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
            var sc = pSearchParameters as ActDiscountSearchParameters;
            using (var adapter = new AS_Get_DocsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sc.SessionID);
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ActDiscountView()
        {
            this.dataColumns.Add(new PatternColumn("№ акта скидки", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Дата документа", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Период", "Period", new FilterPatternExpressionRule("Period")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Статус", "Status", new FilterPatternExpressionRule("Status")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Код дебитора", "Debtor_ID", new FilterCompareExpressionRule<Int64>("Debtor_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Дебитор", "Debtor_Name", new FilterPatternExpressionRule("Debtor_Name")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Описание", "Description", new FilterPatternExpressionRule("Description")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Общая сумма, грн", "Amount_Gross", SummaryCalculationType.Sum) { Width = 50, UseDecimalNumbersAlignment = true, Format = "N4" });
            this.dataColumns.Add(new PatternColumn("Исп. сумма, грн", "Used_Amount", SummaryCalculationType.Sum) { Width = 50, UseDecimalNumbersAlignment = true, Format = "N4" });
            this.dataColumns.Add(new PatternColumn("Ост. сумма, грн", "Remaining_Sum", SummaryCalculationType.Sum) { Width = 50, UseDecimalNumbersAlignment = true, Format = "N4" });

            this.dataColumns.Add(new PatternColumn("Сумма с НДС", "Used_Amount_WNDS", SummaryCalculationType.Sum) { Width = 50, UseDecimalNumbersAlignment = true, Format = "N4" });
            this.dataColumns.Add(new PatternColumn("Сумма НДС", "Used_Amount_NDS", SummaryCalculationType.Sum) { Width = 50, UseDecimalNumbersAlignment = true, Format = "N4" });

            this.dataColumns.Add(new PatternColumn("Код БЕ", "Business_Unit_ID", new FilterPatternExpressionRule("Business_Unit_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Бизнес-единица", "Business_Unit", new FilterPatternExpressionRule("Business_Unit")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Тип акта скидки", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Ориг. тип акта скидки", "Doc_Type_DR", new FilterPatternExpressionRule("Doc_Type_DR"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Менеджер", "Manager", new FilterPatternExpressionRule("Manager")) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Ориг. получ.", "HaveOriginal", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("E-док.", "EDFLagFormat", new FilterPatternExpressionRule("EDFLagFormat"), SummaryCalculationType.None) { Width = 40 });
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка актов скидок
    /// </summary>
    public class ActDiscountSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
    }
}
