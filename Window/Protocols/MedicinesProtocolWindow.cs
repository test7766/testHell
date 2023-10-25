using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Quality;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using WMSOffice.Data.PrintNaklTableAdapters;
using WMSOffice.Classes;

namespace WMSOffice.Window.Protocols
{
    public partial class MedicinesProtocolWindow : GeneralWindow
    {
        #region ПОЛЯ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        /// <summary>
        /// Реквизит компании - название "Оптима фарм"
        /// </summary>
        private string optimaRequisiteName;

        /// <summary>
        /// Параметры фильтра для поиска
        /// </summary>
        private MedicinesRegistryFilterParameters filterParameters;

        /// <summary>
        /// Источник данных для реестра
        /// </summary>
        private Quality.MedicinesRegistryDataTable medicinesRegistry = new Quality.MedicinesRegistryDataTable();

        /// <summary>
        /// Режим работы окна печати реестров (может от поставщика, а может реестры реализации по накладным)
        /// </summary>
        public MedicinesReestrWindowMode Mode { get; private set; }

        #endregion

        /// <summary>
        /// Возвращает одну выделенную строку из реестра.
        /// </summary>
        private Data.Quality.MedicinesRegistryRow SelectedRow
        {
            get
            {
                if (dgvRegistry.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.Quality.MedicinesRegistryRow)((DataRowView)dgvRegistry.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Возвращает выделенные строки в списке накладных 
        /// </summary>
        private List<Data.Quality.MedicinesRegistryRow> SelectedRows
        {
            get
            {
                List<Data.Quality.MedicinesRegistryRow> result = new List<Data.Quality.MedicinesRegistryRow>();
                foreach (DataGridViewRow r in dgvRegistry.Rows)
                    if (r.Selected)
                        result.Add((Data.Quality.MedicinesRegistryRow)((DataRowView)r.DataBoundItem).Row);

                return result;
            }
        }

        public MedicinesProtocolWindow()
        {
            InitializeComponent();
            CustomMode(MedicinesReestrWindowMode.FromVendor);
            this.PreparePrintersList();
            this.SetOptimaRequisites();
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Установка реквизитов компании
        /// </summary>
        private void SetOptimaRequisites()
        {
            try
            {
                var optima = new PrintNakl.CompanyConstantsDataTable();
                using (var adapter = new CompanyConstantsTableAdapter())
                    adapter.Fill(optima, "UA", null, null);

                optimaRequisiteName = optima[0].Name;
            }
            catch { }
        }

        /// <summary>
        /// Настройка контролов в зависимости от режима запуска окна
        /// </summary>
        /// <param name="pMode">Режим запуска окна</param>
        private void CustomMode(MedicinesReestrWindowMode pMode)
        {
            Mode = pMode;
            
            if (Mode == MedicinesReestrWindowMode.ForSale)
                dgvRegistry.CellFormatting += dgvRegistry_CellFormatting;

            //sbProvisors.Visible = false;
        }

        /// <summary>
        /// Раскрашивание строк таблицы зеленым цветом, если разрешен отпуск товара
        /// (используется только в режиме реестров реализованных ЛС)
        /// </summary>
        private void dgvRegistry_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dbRow = (dgvRegistry.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Quality.MedicinesRegistryRow;
            if (!dbRow.IsApprovedNull() && dbRow.Approved == 1)
                dgvRegistry.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
        }


        /// <summary>
        /// Класс преобразует и хранит пользовательские параметры поиска реестра ЛС
        /// </summary>
        private class MedicinesRegistryFilterParameters
        {
            public int UserID { get; set; }
            public int SearchType { get; private set; }

            public int? OrderNumber { get; private set; }
            public int? SupplierCode { get; private set; }
            public DateTime? DateFrom { get; private set; }
            public DateTime? DateTo { get; private set; }
            public DateTime? InternalDateFrom { get; private set; }
            public DateTime? InternalDateTo { get; private set; }
            public int? DrugsCode { get; private set; }
            public string VendorLot { get; private set; }

            public int? QualityItemID { get; private set; }
            public string QualityVendorLot { get; private set; }
            public int? QualityVendorID { get; private set; }
            public DateTime? QualityDateFrom { get; private set; }
            public DateTime? QualityDateTo { get; private set; }
            public int QualityPermissionFilter { get; private set; }

            public string QualityLotNumber { get; set; }
            public string QualityVendorInvoiceId { get; set; }

           
            // Параметры, которые используются только в режиме "Реестр реализованных ЛС"

            /// <summary>
            /// Номер накладной или null, если номер накладной не задан
            /// </summary>
            public int? InvoiceNumber { get; private set; }

            /// <summary>
            /// Номер сборочного, или null если номер сборочного не задан
            /// </summary>
            public int? PickListNumber { get; private set; }

            /// <summary>
            /// Код дебитора
            /// </summary>
            public int? DebitorID { get; private set; }

            public MedicinesRegistryFilterParameters(int searchType, List<object> parametersCollection)
            {
                this.SearchType = searchType;

                InitializeParameters();

                if (parametersCollection[0] != null)
                    OrderNumber = Convert.ToInt32(parametersCollection[0]);
                if (parametersCollection[1] != null)
                    SupplierCode = Convert.ToInt32(parametersCollection[1]);
                if (parametersCollection[2] != null)
                    DateFrom = Convert.ToDateTime(parametersCollection[2]);
                if (parametersCollection[3] != null)
                    DateTo = Convert.ToDateTime(parametersCollection[3]);
                if (parametersCollection[4] != null)
                    InternalDateFrom = Convert.ToDateTime(parametersCollection[4]);
                if (parametersCollection[5] != null)
                    InternalDateTo = Convert.ToDateTime(parametersCollection[5]);
                if (parametersCollection[6] != null)
                    DrugsCode = Convert.ToInt32(parametersCollection[6]);
                if (parametersCollection[7] != null)
                    VendorLot = parametersCollection[7].ToString();
                if (parametersCollection[8] != null && !String.IsNullOrEmpty(parametersCollection[8].ToString()))
                    QualityItemID = Convert.ToInt32(parametersCollection[8]);
                if (parametersCollection[9] != null && !String.IsNullOrEmpty(parametersCollection[9].ToString()))
                    QualityVendorLot = parametersCollection[9].ToString();
                if (parametersCollection[10] != null && !String.IsNullOrEmpty(parametersCollection[10].ToString()))
                    QualityVendorID = Convert.ToInt32(parametersCollection[10]);
                if (parametersCollection[11] != null)
                    QualityDateFrom = Convert.ToDateTime(parametersCollection[11]);
                if (parametersCollection[12] != null)
                    QualityDateTo = Convert.ToDateTime(parametersCollection[12]);
                if (parametersCollection[13] != null)
                    QualityPermissionFilter = Convert.ToInt32(parametersCollection[13]);
                if (parametersCollection[14] != null)
                    QualityLotNumber = parametersCollection[14].ToString();
                if (parametersCollection[15] != null)
                    QualityVendorInvoiceId = parametersCollection[15].ToString();
            }

            /// <summary>
            /// Конструктор, используемый в режиме "Реестр реализованных ЛС"
            /// </summary>
            public MedicinesRegistryFilterParameters(int? pInvoiceNumber, int? pPickListNumber, int? pDebitorID,
                DateTime pDateFrom, DateTime pDateTo)
            {
                InvoiceNumber = pInvoiceNumber;
                PickListNumber = pPickListNumber;
                DebitorID = pDebitorID;
                DateFrom = pDateFrom;
                DateTo = pDateTo;
            }

            private void InitializeParameters()
            {
                OrderNumber = null;
                SupplierCode = null;
                DateFrom = null;
                DateTo = null;
                InternalDateFrom = null;
                InternalDateTo = null;
                DrugsCode = null;
                VendorLot = null;
                QualityItemID = null;
                QualityVendorLot = null;
                QualityVendorID = null;
                QualityDateFrom = null;
                QualityDateTo = null;
                QualityPermissionFilter = 0;
            }
        }

        /// <summary>
        /// Параметры для фоновой печати реестра
        /// </summary>
        private class PrintWorkerParameters
        {
            public string PrinterName { get; set; }
            public int NumberCopies { get; set; }
            public List<Data.Quality.MedicinesRegistryRow> PrintedDocuments { get; private set; }

            public DocType DocType { get; set; }

            public PrintWorkerParameters()
            {
                this.PrintedDocuments = new List<WMSOffice.Data.Quality.MedicinesRegistryRow>();
            }
        }

        /// <summary>
        /// Тип документа
        /// </summary>
        private enum DocType
        {
            /// <summary>
            /// Реестр
            /// </summary>
            Registry,

            /// <summary>
            /// Журнал учета температуры
            /// </summary>
            TemperatureJournal
        }


        private void sbFindRegistry_Click(object sender, EventArgs e)
        {
            this.FindRegistry();
        }

        /// <summary>
        /// Поиск реестра по параметрам фильтра
        /// </summary>
        private void FindRegistry()
        {
            Form findRegistryForm = (Mode == MedicinesReestrWindowMode.FromVendor) ?
                (Form)new MedicinesRegistrySearchForm() : (Form)new ReestrRealizationSearchForm(
                    filterParameters == null ? null : filterParameters.InvoiceNumber,
                    filterParameters == null ? null : filterParameters.PickListNumber,
                    filterParameters == null ? null : filterParameters.DebitorID,
                    filterParameters == null ? null : filterParameters.DateFrom,
                    filterParameters == null ? null : filterParameters.DateTo);
            if (findRegistryForm.ShowDialog(this) == DialogResult.OK)
            {
                filterParameters = (Mode == MedicinesReestrWindowMode.FromVendor) ? (new MedicinesRegistryFilterParameters((findRegistryForm as MedicinesRegistrySearchForm).SearchTypeCode,
                    (findRegistryForm as MedicinesRegistrySearchForm).GetParametersFromFilter()) { UserID = this.UserID }) :
                    (new MedicinesRegistryFilterParameters((findRegistryForm as ReestrRealizationSearchForm).InvoiceNumber,
                        (findRegistryForm as ReestrRealizationSearchForm).PickListNumber,
                        (findRegistryForm as ReestrRealizationSearchForm).DebitorID,
                        (findRegistryForm as ReestrRealizationSearchForm).DateFrom,
                        (findRegistryForm as ReestrRealizationSearchForm).DateTo));
                RefreshRegistry();
            }
        }

        #region Запуск фонового обновления реестра
        /// <summary>
        /// Обновить реестр
        /// </summary>
        private void RefreshRegistry()
        {
            BackgroundWorker loadDocsWorker = new BackgroundWorker();
            loadDocsWorker.DoWork += new DoWorkEventHandler(loadDocsWorker_DoWork);
            loadDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadDocsWorker_RunWorkerCompleted);

            this.medicinesRegistryBindingSource.DataSource = null;
            splashForm.ActionText = "Загрузка протокола лекарственных средств...";
            loadDocsWorker.RunWorkerAsync(null);
            splashForm.ShowDialog();

        }

        private void loadDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool isQP = filterParameters.SearchType == 5;  // является ли поиск по разрешениям на реализацию
                using (var adapter = new WMSOffice.Data.QualityTableAdapters.MedicinesRegistryTableAdapter())
                    if (Mode == MedicinesReestrWindowMode.FromVendor)
                    {
                        adapter.SetTimeout(600);
                        adapter.Fill(this.medicinesRegistry,
                            this.filterParameters.SearchType,
                            this.filterParameters.OrderNumber,
                            isQP ? this.filterParameters.QualityVendorID : this.filterParameters.SupplierCode,
                            isQP ? this.filterParameters.QualityDateFrom : this.filterParameters.DateFrom,
                            isQP ? this.filterParameters.QualityDateTo : this.filterParameters.DateTo,
                            this.filterParameters.InternalDateFrom,
                            this.filterParameters.InternalDateTo,
                            isQP ? this.filterParameters.QualityItemID : this.filterParameters.DrugsCode,
                            isQP ? this.filterParameters.QualityVendorLot : this.filterParameters.VendorLot,
                            this.UserID,
                            this.filterParameters.QualityPermissionFilter,
                            isQP ? filterParameters.QualityLotNumber: null,
                            isQP ? filterParameters.QualityVendorInvoiceId: null);
                    }
                    else
                    {
                        adapter.SetTimeout(600);
                        adapter.FillBy(medicinesRegistry, UserID, filterParameters.DateFrom, filterParameters.DateTo,
                            filterParameters.PickListNumber, filterParameters.InvoiceNumber, filterParameters.DebitorID);
                    }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void loadDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                this.medicinesRegistry.Clear();
            }
            else
                this.medicinesRegistryBindingSource.DataSource = this.medicinesRegistry;
            splashForm.CloseForce();
        }
        #endregion


        #region Запуск фоновой печати реестра

        /// <summary>
        /// Просмотр реестра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miPreviewRegistry_Click(object sender, EventArgs e)
        {
            this.PreviewDoc(DocType.Registry);
        }

        /// <summary>
        /// просмотр реестра
        /// </summary>
        /// <param name="docType"></param>
        private void PreviewDoc(DocType docType)
        {
            try
            {
                if (dgvRegistry.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.Quality registryData = PrepareDataSetForSelectedRegistry(SelectedRow, docType);
                using (var report = this.CreateReport(registryData, docType))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            if (docType == DocType.Registry)
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PS", 28, Convert.ToInt64(SelectedRow.optima_order_id), SelectedRow.optima_order_type, (short?)null, form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbPrintTemperatureJournal_Click(object sender, EventArgs e)
        {
            this.PrintDocuments(DocType.TemperatureJournal);
        }

        private void sbPrintRegistry_Click(object sender, EventArgs e)
        {
            this.PrintDocuments(DocType.Registry);
        }

        /// <summary>
        /// Печать документов по типу
        /// </summary>
        /// <param name="docType"></param>
        private void PrintDocuments(DocType docType)
        {
            if (dgvRegistry.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    PrinterName = (string)cbPrinters.SelectedItem,
                    DocType = docType,
                    NumberCopies = 1 // кол-во экземпляров реестра равно 1
                };
                foreach (Data.Quality.MedicinesRegistryRow printedRegistry in this.SelectedRows)
                    parameters.PrintedDocuments.Add(printedRegistry);

                BackgroundWorker printDocsWorker = new BackgroundWorker();
                printDocsWorker.DoWork += new DoWorkEventHandler(printDocsWorker_DoWork);
                printDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printDocsWorker_RunWorkerCompleted);

                splashForm.ActionText = "Печать документов...";
                printDocsWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        private void printDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters parameters = e.Argument as PrintWorkerParameters;
                foreach (Data.Quality.MedicinesRegistryRow printedRegistry in parameters.PrintedDocuments)
                {
                    Data.Quality registryData = PrepareDataSetForSelectedRegistry(printedRegistry, parameters.DocType);

                    using (var report = this.CreateReport(registryData, parameters.DocType))
                    {
                        report.PrintOptions.PrinterName = parameters.PrinterName;

                        if (parameters.DocType == DocType.Registry)
                            report.PrintOptions.PrinterDuplex = this.GetPrinterDuplexRegime(registryData);

                        report.PrintToPrinter(parameters.NumberCopies, true, 1, 0);
                    }

                    // логирование факта печати
                    if (parameters.DocType == DocType.Registry)
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PS", 28, Convert.ToInt64(printedRegistry.optima_order_id), printedRegistry.optima_order_type, (short?)null, parameters.PrinterName, Convert.ToByte(parameters.NumberCopies));

                    //using (var report = this.GetRegistryReport(registryData))
                    //{
                    //    report.PrintOptions.PrinterName = parameters.PrinterName;
                    //    report.PrintOptions.PrinterDuplex = this.GetPrinterDuplexRegime(registryData);
                    //    report.PrintToPrinter(parameters.NumberCopies, true, 1, 0);
                    //}

                    //// Если есть термопродукция, тогда печатаем отчет "журнал контроля температур"
                    //if (registryData.TermoReportJournal.Rows.Count > 0)
                    //{
                    //    using (var report = GetTemperatureJournalReport(registryData))
                    //    {
                    //        report.PrintOptions.PrinterName = parameters.PrinterName;
                    //        report.PrintToPrinter(parameters.NumberCopies, true, 1, 0);
                    //    }
                    //}
                }
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void printDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
            dgvRegistry.ClearSelection(); // После печати очистим выделение
        }

        /// <summary>
        /// Формирование реестра для выбранной записи
        /// </summary>
        /// <param name="selectedRow"></param>
        /// <returns></returns>
        private Data.Quality PrepareDataSetForSelectedRegistry(Data.Quality.MedicinesRegistryRow selectedRow, DocType docType)
        {
            Data.Quality registryData = new WMSOffice.Data.Quality();

            switch (docType)
            {
                case DocType.Registry:

                    // Выбираем ответственного сотрудника
                    var responsiblePerson = (string)null;
                    this.PrepareResponsiblePerson(selectedRow.optima_order_id, selectedRow.optima_order_type, out responsiblePerson);
                    if (!string.IsNullOrEmpty(responsiblePerson))
                        selectedRow.responsible_person = responsiblePerson;

                    // Выбираем дату приходования в шапке
                    var responsiblePersonDate = (DateTime?)null;
                    this.PrepareResponsiblePersonDate(selectedRow.optima_order_id, selectedRow.optima_order_type, out responsiblePersonDate);
                    if (responsiblePersonDate.HasValue)
                        selectedRow.delivery_date = responsiblePersonDate.Value.ToShortDateString();

                    using (Data.QualityTableAdapters.MedicinesRegistryDetailsTableAdapter adapter = new WMSOffice.Data.QualityTableAdapters.MedicinesRegistryDetailsTableAdapter())
                        if (Mode == MedicinesReestrWindowMode.FromVendor)
                        {
                            adapter.Fill(registryData.MedicinesRegistryDetails, selectedRow.company_id, selectedRow.optima_order_id,
                                selectedRow.optima_order_type, selectedRow.optima_invoice_id, this.filterParameters.DrugsCode, this.filterParameters.VendorLot, false, filterParameters.QualityLotNumber);

                            // Выбираем дату приходования в подписи
                            if (registryData.MedicinesRegistryDetails.Rows.Count > 0 && responsiblePersonDate.HasValue)
                                foreach (Data.Quality.MedicinesRegistryDetailsRow registryDetail in registryData.MedicinesRegistryDetails.Rows)
                                    registryDetail.date_print_reestr = responsiblePersonDate.Value;
                        }
                        else
                            adapter.FillBy(registryData.MedicinesRegistryDetails, UserID, Convert.ToInt32(selectedRow.optima_order_id),
                                selectedRow.optima_order_type, Convert.ToInt32(selectedRow.optima_invoice_id));
                    selectedRow.HeaderPart = Mode == MedicinesReestrWindowMode.ForSale ? "які реалізуються суб'єктом" : "які надійшли до суб'єкта";
                    selectedRow.Column2Header = Mode == MedicinesReestrWindowMode.ForSale ? "покупця" : "постачальника";
                    registryData.MedicinesRegistry.LoadDataRow(selectedRow.ItemArray, true);
                    break;

                case DocType.TemperatureJournal:

                    // Добавлено формирование источника данных для "журнала учета температуры"
                    using (Data.QualityTableAdapters.TermoReportJournalTableAdapter qualityAdapter = new Data.QualityTableAdapters.TermoReportJournalTableAdapter())
                        qualityAdapter.Fill(registryData.TermoReportJournal, this.UserID, selectedRow.company_id, selectedRow.optima_order_id,
                            selectedRow.optima_order_type, selectedRow.optima_invoice_id, this.filterParameters.DrugsCode, this.filterParameters.VendorLot);
                    break;

                default:
                    break;
            }

            return registryData;
        }

        /// <summary>
        /// Подготовка ответственного сотрудника за проведение входного контроля
        /// </summary>
        /// <param name="doco"></param>
        /// <param name="orderType"></param>
        /// <param name="responsiblePerson"></param>
        private void PrepareResponsiblePerson(double doco, string orderType, out string responsiblePerson)
        {
            responsiblePerson = (string)null;

            try
            {
                var orderID = Convert.ToInt32(doco);

                using (var adapter = new Data.QualityTableAdapters.AT_DocsTableAdapter())
                    adapter.GetResponsiblePerson(this.UserID, orderID, orderType, ref responsiblePerson);
            }
            catch (Exception ex)
            {
               
            }
        }

        /// <summary>
        /// Подготовка даты проведения входного контроля ответственным сотрудником
        /// </summary>
        /// <param name="doco"></param>
        /// <param name="orderType"></param>
        /// <param name="responsiblePersonDate"></param>
        private void PrepareResponsiblePersonDate(double doco, string orderType, out DateTime? responsiblePersonDate)
        {
            responsiblePersonDate = (DateTime?)null;

            try
            {
                var orderID = Convert.ToInt32(doco);

                using (var adapter = new Data.QualityTableAdapters.AT_DocsTableAdapter())
                    adapter.GetResponsibleUserDate(this.UserID, orderID, orderType, ref responsiblePersonDate);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// Cоздание отчета
        /// </summary>
        /// <param name="reportData"></param>
        /// <param name="docType"></param>
        /// <returns></returns>
        private ReportClass CreateReport(Data.Quality reportData, DocType docType)
        {
            switch (docType)
            {
                case DocType.Registry:
                    return this.GetRegistryReport(reportData);
                case DocType.TemperatureJournal:
                    return this.GetTemperatureJournalReport(reportData);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Создает отчет - реестр лекарственных средств.
        /// </summary>
        /// <returns>Отчет в виде реестра лекарственных средств.</returns>
        private ReportClass GetRegistryReport(Data.Quality registryData)
        {
            if (registryData.MedicinesRegistryDetails.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в источнике данных для формирования содержимого реестра.");

            // создание и возврат отчета
            ReportClass report;
            if (Mode == MedicinesReestrWindowMode.FromVendor)
                report = new Reports.QKVendorProtocol();
            else
                report = new Reports.QKClientRegister();
            report.SetDataSource(registryData);
            report.SetParameterValue("optima_company", this.optimaRequisiteName); // установим параметр "реквизит - название компании" - в шапку документа

            return report;
        }

        /// <summary>
        /// Создает отчет - журнал учета температуры.
        /// </summary>
        /// <returns>Отчет в виде журнала учета температуры.</returns>
        private Reports.TemperatureObservationsJournalReport GetTemperatureJournalReport(Data.Quality registryData)
        {
            if (registryData.TermoReportJournal.Rows.Count < 1)
                throw new ArgumentException("В данном реестре отсутсвует термолабильная продукция.");

            // создание и возврат отчета
            Reports.TemperatureObservationsJournalReport report = new Reports.TemperatureObservationsJournalReport();
            report.SetDataSource(registryData);
            report.SetParameterValue("PrintYear", DateTime.Today.Year);
            return report;
        }

        /// <summary>
        /// Анализ печати в дуплексном режиме
        /// </summary>
        /// <param name="naklData"></param>
        /// <returns></returns>
        private PrinterDuplex GetPrinterDuplexRegime(WMSOffice.Data.Quality registryData)
        {
            if (registryData.MedicinesRegistryDetails.Rows.Count > 10)
                return PrinterDuplex.Horizontal;
            else
                return PrinterDuplex.Simplex;
        }

        #endregion


    }
}
