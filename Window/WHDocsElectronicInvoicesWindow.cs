using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.WH;
using System.Data.SqlClient;
using WMSOffice.Dialogs;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Reports;
using WMSOffice.Data;

namespace WMSOffice.Window
{
    public partial class WHDocsElectronicInvoicesWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        private ElectronicInvoiceSearchDialog setSearchCriteriaForm = new ElectronicInvoiceSearchDialog();

        public WHDocsElectronicInvoicesWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            WMSOffice.Classes.PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            this.xdgvResult.AllowSummary = false;
            this.xdgvResult.AllowRangeColumns = true;
            this.xdgvResult.UseMultiSelectMode = true;

            this.xdgvResult.Init(new ElectronicInvoicesView(), true);
            this.xdgvResult.LoadExtraDataGridViewSettings(this.Name);

            this.xdgvResult.UserID = this.UserID;
            setSearchCriteriaForm.UserID = this.UserID;

            this.xdgvResult.OnFilterChanged += new EventHandler(xdgvResult_OnFilterChanged);
            this.xdgvResult.OnRowSelectionChanged += new EventHandler(xdgvResult_OnRowSelectionChanged);
            this.xdgvResult.DataGrid.MouseDown += new MouseEventHandler(DataGrid_MouseDown);
            this.xdgvResult.DataGrid.CellClick += new DataGridViewCellEventHandler(DataGrid_CellClick);
            this.xdgvResult.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvResult_OnFormattingCell);

            miPrintPreviewTaxInvoice.Enabled = false;
            miPreviewSellerTaxInvoice.Enabled = false;

            this.SetSearchCriteria();
        }

        void xdgvResult_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            var row = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;

            #region ИНДИКАЦИЯ НАКЛАДНЫХ С ДОСТУПНЫМИ ДЛЯ ПЕЧАТИ КОПИЯМИ КЛИЕНТА
            bool clientCopy = Convert.ToBoolean(row["PrintClientCopy_Flag"]);
            if (clientCopy)
            {
                if (grid.Columns[e.ColumnIndex].DataPropertyName == "PrintClientCopy")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                    return;
                }
            }
            #endregion

            #region ИНДИКАЦИЯ НАКЛАДНЫХ С ДОСТУПНЫМИ ДЛЯ ПЕЧАТИ КОПИЯМИ КЛИЕНТА
            bool isSumInvoice = Convert.ToBoolean(row["svod_flag"]);
            if (isSumInvoice)
            {
                if (grid.Columns[e.ColumnIndex].DataPropertyName == "svod")
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.SelectionForeColor = Color.LightGreen;
                    return;
                }
            }
            #endregion
        }

        void DataGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.ChangeOperationsAccess();
        }

        void DataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var point = new Point(e.X, e.Y);
                var hitTestInfo = this.xdgvResult.DataGrid.HitTest(point.X, point.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    this.xdgvResult.DataGrid.CurrentCell = this.xdgvResult.DataGrid.Rows[hitTestInfo.RowIndex].Cells[hitTestInfo.ColumnIndex];
                    this.ChangeOperationsAccess();
                }
            }
        }

        void xdgvResult_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.ChangeOperationsAccess();
        }

        private void ChangeOperationsAccess()
        {
            bool isEnabled = xdgvResult.SelectedItem != null;
            miPrintPreviewTaxInvoice.Enabled = isEnabled;
            miPreviewSellerTaxInvoice.Enabled = isEnabled;
        }

        void xdgvResult_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvResult.RecalculateSummary();
        }

        #region ОБНОВЛЕНИЕ ДАННЫХ

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData();
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                this.SetSearchCriteria();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void RefreshData()
        {
            this.xdgvResult.Focus();

            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

            this.waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(setSearchCriteriaForm.SearchCriteria);
            this.waitProgressForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.xdgvResult.DataView.FillData(e.Argument as ElectronicInvoicesSearchParameters);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);
            else
            {
                this.xdgvResult.BindData(false);
                this.xdgvResult.AllowSummary = true;
            }

            this.waitProgressForm.CloseForce();
        }

        #endregion

        private void sbSetSearchCriteria_Click(object sender, EventArgs e)
        {
            this.SetSearchCriteria();
        }

        /// <summary>
        /// Открытие редактора критериев поиска
        /// </summary>
        private void SetSearchCriteria()
        {
            if (setSearchCriteriaForm.ShowDialog() == DialogResult.OK)
                this.RefreshData();
        }

        private void miPrintPreviewTaxInvoice_Click(object sender, EventArgs e)
        {
            var isSummaryInvoice = Convert.ToBoolean(this.xdgvResult.SelectedItem["svod_flag"]);
            var canPrint = isSummaryInvoice
                ? Convert.ToBoolean(this.xdgvResult.SelectedItem["svod_print"])
                : Convert.ToBoolean(this.xdgvResult.SelectedItem["PrintClientCopy_Flag"]);

            var printParameters = new DocPrintParameters();
            printParameters.PreviewOnly = !canPrint;
            printParameters.ImmediatelyPrint = false;
            printParameters.PrintContext = TaxInvoicePrintContext.Client;
            printParameters.Documents.Add(this.xdgvResult.SelectedItem);

            this.PrintDocument(printParameters);
        }

        private void miPreviewSellerTaxInvoice_Click(object sender, EventArgs e)
        {
            var printParameters = new DocPrintParameters();
            printParameters.PreviewOnly = true;
            printParameters.ImmediatelyPrint = false;
            printParameters.PrintContext = TaxInvoicePrintContext.Seller;
            printParameters.Documents.Add(this.xdgvResult.SelectedItem);

            this.PrintDocument(printParameters);
        }

        private void miPrintClientTaxInvoices_Click(object sender, EventArgs e)
        {
            var printParameters = new DocPrintParameters();
            printParameters.PreviewOnly = false;
            printParameters.ImmediatelyPrint = true;
            printParameters.PrintContext = TaxInvoicePrintContext.Client;
            printParameters.PrinterName = cmbPrinters.SelectedItem.ToString();

            foreach (var document in this.xdgvResult.SelectedItems)
            {
                var isSummaryInvoice = Convert.ToBoolean(document["svod_flag"]);
                var canPrint = isSummaryInvoice
                    ? Convert.ToBoolean(document["svod_print"])
                    : Convert.ToBoolean(document["PrintClientCopy_Flag"]);

                if (canPrint)
                    printParameters.Documents.Add(document);
            }

            this.PrintDocument(printParameters);
        }

        #region ОРГАНИЗАЦИЯ ПЕЧАТИ ДОКУМЕНТОВ

        /// <summary>
        /// Фоновая обработка пакета документов
        /// </summary>
        /// <param name="parameters"></param>
        private void PrintDocument(DocPrintParameters parameters)
        {
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.WorkerReportsProgress = true;
            printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            printWorker.ProgressChanged += new ProgressChangedEventHandler(printWorker_ProgressChanged);
            printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);

            waitProgressForm.ActionText = "Выполняется обработка документов..";
            printWorker.RunWorkerAsync(parameters);
            waitProgressForm.ShowDialog();

        }

        void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var printParameters = e.Argument as DocPrintParameters;
            try
            {
                for (int i = 0; i < printParameters.Documents.Count; i++)
                {
                    (sender as BackgroundWorker).ReportProgress(i, new ProgressState() { ProcessedItems = i, TotalItems = printParameters.Documents.Count });

                    var document = printParameters.Documents[i];

                    var docType = document["InvoiceType"].ToString().ToUpper(); // тип накладной
                    var isSummaryInvoice = Convert.ToBoolean(document["svod_flag"]); // признак сводной налоговой

                    IReportManager reportManager = isSummaryInvoice
                        ? (IReportManager)(new ElSumTaxInvoiceReportManager() { UserID = this.UserID })
                        : (docType.StartsWith("3") || docType.StartsWith("X"))
                            ? (IReportManager)(new ElComplaintCalculationsReportManager() { UserID = this.UserID })
                            : (IReportManager)(new ElTaxInvoiceReportManager() { UserID = this.UserID });

                    this.PrintDocument(document, printParameters, reportManager);

                    (sender as BackgroundWorker).ReportProgress(i + 1, new ProgressState() { ProcessedItems = i + 1, TotalItems = printParameters.Documents.Count });
                }

                System.Threading.Thread.Sleep(500);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Формирование документа
        /// </summary>
        private void PrintDocument(DataRow document, DocPrintParameters parameters, IReportManager reportManager)
        {
            try
            {
                var printContext = parameters.PrintContext;
                var previewOnly = parameters.PreviewOnly;
                var immediatelyPrint = parameters.ImmediatelyPrint;
                var printerName = parameters.PrinterName;

                bool allowPrint;
                var docSource = reportManager.PrepareDocumentSource(document, printContext == TaxInvoicePrintContext.Client, out allowPrint);

                if (!allowPrint)
                {
                    previewOnly = true;

                    if (immediatelyPrint)
                    {
                        MessageBox.Show("Запрещено печатать этот документ!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (docSource != null)
                {
                    var docPrintDate = Convert.ToDateTime(this.xdgvResult.SelectedItem["TaxInvoiceDate"]);

                    using (var report = reportManager.GetReport(docSource, docPrintDate))
                    {
                        #region МГНОВЕННАЯ ПЕЧАТЬ

                        if (immediatelyPrint)
                        {
                            report.PrintOptions.PrinterName = printerName;
                            report.PrintToPrinter(1, true, 1, 0);
                        }

                        #endregion

                        #region ФОРМИРОВАНИЕ ПЕЧАТНОГО ДОКУМЕНТА

                        else
                        {
                            using (var reportForm = new ReportForm() { Text = "Налоговая накладная" })
                            {
                                reportForm.ReportDocument = report;

                                if (previewOnly)
                                {
                                    reportForm.CanPrint = false;
                                    reportForm.CanExport = false;
                                    reportForm.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", reportForm.Text);
                                }

                                reportForm.ShowDialog();
                            }
                        }

                        #endregion
                    }
                }
                else
                {
                    throw new Exception("Возникла ошибка при формировании источника данных отчета.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void printWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var progressState = e.UserState as ProgressState;
            waitProgressForm.ActionText = string.Format("Выполняется обработка документов..\nОбработано {0} из {1}.", progressState.ProcessedItems, progressState.TotalItems);
        }

        void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);

            waitProgressForm.CloseForce();
        }

        #endregion

        private void WHDocsElectronicInvoicesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvResult.SaveExtraDataGridViewSettings(this.Name);
        }
    }

    /// <summary>
    /// Представление для электронных накладных
    /// </summary>
    public class ElectronicInvoicesView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as ElectronicInvoicesSearchParameters;

            using (SqlCommand command = new SqlCommand("[dbo].[pr_EI_Get_Documents]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString)))
            {
                command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.BigInt) { Value = searchCriteria.UserID });
                command.Parameters.Add(new SqlParameter("@DebtorID", SqlDbType.Int) { Value = searchCriteria.DebtorID });
                command.Parameters.Add(new SqlParameter("@DeliveryID", SqlDbType.Int) { Value = searchCriteria.DeliveryID });
                command.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.Float) { Value = searchCriteria.OrderID });
                command.Parameters.Add(new SqlParameter("@InvoiceNumber", SqlDbType.Float) { Value = searchCriteria.InvoiceID });
                command.Parameters.Add(new SqlParameter("@TaxInvoiceNumber", SqlDbType.Float) { Value = searchCriteria.TaxInvoiceID });
                command.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime) { Value = searchCriteria.DateFrom });
                command.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime) { Value = searchCriteria.DateTo });

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    this.data = dataSet.Tables[0];
                }
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ElectronicInvoicesView()
        {
            this.dataColumns.Add(new PatternColumn("Компания", "CompanyID", new FilterPatternExpressionRule("CompanyID")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ заказа", "OrderID", new FilterCompareExpressionRule<Int64>("OrderID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип заказа", "OrderType", new FilterPatternExpressionRule("OrderType")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ расходной", "InvoiceNumber", new FilterCompareExpressionRule<Int64>("InvoiceNumber"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип расходной", "InvoiceType", new FilterPatternExpressionRule("InvoiceType")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("№ налоговой", "TaxInvoiceNumber", new FilterCompareExpressionRule<Int64>("TaxInvoiceNumber"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата расходной", "TaxInvoiceDate", new FilterDateCompareExpressionRule("TaxInvoiceDate")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Код дебитора", "DebtorID", new FilterCompareExpressionRule<Int32>("DebtorID"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Наименование дебитора", "DebtorName", new FilterPatternExpressionRule("DebtorName")) { Width = 350 });
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse", new FilterPatternExpressionRule("Warehouse")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Сводная", "svod", new FilterPatternExpressionRule("svod")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Копия клиента", "PrintClientCopy", new FilterPatternExpressionRule("PrintClientCopy")) { Width = 100 });
        }

        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ElectronicInvoicesSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код дебитора
        /// </summary>
        public int? DebtorID { get; set; }

        /// <summary>
        /// Признак валидности кода дебитора
        /// </summary>
        public bool IsDebtorIDValid { get; set; }

        /// <summary>
        /// Наименование дебитора
        /// </summary>
        public string DebtorName { get; set; }

        /// <summary>
        /// Код доставки
        /// </summary>
        public int? DeliveryID { get; set; }

        /// <summary>
        /// Номер налоговой
        /// </summary>
        public long? TaxInvoiceID { get; set; }

        /// <summary>
        /// Номер расходной
        /// </summary>
        public long? InvoiceID { get; set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public long? OrderID { get; set; }

        /// <summary>
        /// Дата "с"
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата "по"
        /// </summary>
        public DateTime? DateTo { get; set; }
    }

    /// <summary>
    /// Параметры печати документов
    /// </summary>
    public class DocPrintParameters
    {
        /// <summary>
        /// Только режим просмотра
        /// </summary>
        public bool PreviewOnly { get; set; }

        /// <summary>
        /// Признак немедленной печати
        /// </summary>
        public bool ImmediatelyPrint { get; set; }

        /// <summary>
        /// Контекст печати документа
        /// </summary>
        public TaxInvoicePrintContext PrintContext { get; set; }

        /// <summary>
        /// Список документов
        /// </summary>
        public List<DataRow> Documents { get; set; }

        /// <summary>
        /// Имя принтера
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// Менеджер отчетов
        /// </summary>
        public IReportManager ReportManager { get; set; }


        public DocPrintParameters()
        {
            this.Documents = new List<DataRow>();
        }
    }

    /// <summary>
    /// Контекст печати документа 
    /// </summary>
    public enum TaxInvoicePrintContext
    {
        /// <summary>
        /// Для продавца (Оптима-фарм)
        /// </summary>
        Seller,

        /// <summary>
        /// Для клиента
        /// </summary>
        Client
    }

    /// <summary>
    /// Статус обработки
    /// </summary>
    public class ProgressState
    {
        public int TotalItems { get; set; }

        public int ProcessedItems { get; set; }
    }

    /// <summary>
    /// Интерфейс менеджера отчетов 
    /// </summary>
    public interface IReportManager
    {
        int UserID { get; set; }
        DataSet PrepareDocumentSource(DataRow document, bool debtorCopy, out bool allowPrint);
        ReportClass GetReport(DataSet docSource, DateTime printDate);
    }

    /// <summary>
    /// Менеджер отчетов для налоговых накладных
    /// </summary>
    public class ElTaxInvoiceReportManager : IReportManager
    {
        #region IReportManager Members

        public int UserID { get; set; }

        public DataSet PrepareDocumentSource(DataRow document, bool debtorCopy, out bool allowPrint)
        {
            allowPrint = true;

            try
            {
                var invoice = new Data.PrintNakl();

                var companyID = document["CompanyID"].ToString();
                var orderID = Convert.ToInt64(document["OrderID"]);
                var orderType = document["OrderType"].ToString();
                var invoiceNumber = Convert.ToInt64(document["InvoiceNumber"]);

                #region ФОРМИРОВАНИЕ ЗАГОЛОВКА

                using (var headerAdapter = new Data.PrintNaklTableAdapters.DocHeadersTableAdapter())
                    headerAdapter.FillFromArchive(invoice.DocHeaders, companyID, orderType, orderID, invoiceNumber, this.UserID, true, debtorCopy);

                while (invoice.DocHeaders.Rows.Count > 1)
                    invoice.DocHeaders.Rows.RemoveAt(1);

                if (invoice.DocHeaders.Rows.Count > 1)
                {
                    // Электронная
                    if (invoice.DocHeaders[0].MarkEV01 == 0)
                        allowPrint = false;
                }

                //if (debtorCopy)
                //{
                //    invoice.DocHeaders[0].TaxInvoiceMarkDebtorOriginal = "X";
                //    invoice.DocHeaders[0].TaxInvoiceMarkSellerCopy = " ";
                //}
                //else
                //{
                //    invoice.DocHeaders[0].TaxInvoiceMarkDebtorOriginal = " ";
                //    invoice.DocHeaders[0].TaxInvoiceMarkSellerCopy = " ";
                //    invoice.DocHeaders[0].TaxInvoiceMarkEDI = "X";
                //}

                #endregion

                #region ФОРМИРОВАНИЕ ПОЗИЦИЙ

                using (var detailsAdapter = new Data.PrintNaklTableAdapters.DocDetailTableAdapter())
                    detailsAdapter.FillFromArchive(invoice.DocDetail, companyID, orderType, orderID, invoiceNumber);

                #endregion

                return invoice;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReportClass GetReport(DataSet docSource, DateTime printDate)
        {
            ReportClass report = null;

            if (printDate >= new DateTime(2015, 1, 1))
                report = new PNTaxInvoiceReport_Since_01_2015();
            else if (printDate >= new DateTime(2014, 12, 1))
                report = new PNTaxInvoiceReport_Since_07_2014();
            else if (printDate >= new DateTime(2014, 3, 1))
                report = new PNTaxInvoiceReport_Since_01_2014();
            else if (printDate >= new DateTime(2011, 12, 16))
                report = new PNTaxInvoiceReport();
            else if (printDate >= new DateTime(2011, 1, 10) && printDate <= new DateTime(2011, 12, 15))
                report = new PNTaxInvoiceOld3Report();
            else if (printDate >= new DateTime(2011, 1, 1) && printDate <= new DateTime(2011, 1, 9))
                report = new PNTaxInvoiceOld2Report();
            else if (printDate < new DateTime(2011, 1, 1))
                report = new PNTaxInvoiceOldReport();

            report.SetDataSource(docSource);
            return report;
        }

        #endregion
    }

    /// <summary>
    /// Менеджер отчетов для расчет-корректировок
    /// </summary>
    public class ElComplaintCalculationsReportManager : IReportManager
    {
        #region IReportManager Members

        public int UserID { get; set; }

        public DataSet PrepareDocumentSource(DataRow document, bool debtorCopy, out bool allowPrint)
        {
            allowPrint = true;

            try
            {
                var complaint = new Data.Complaints();

                var companyID = document["CompanyID"].ToString();
                var orderID = Convert.ToInt64(document["OrderID"]);
                var orderType = document["OrderType"].ToString();

                #region ФОРМИРОВАНИЕ ЗАГОЛОВКА

                Data.Complaints.ReportCalculationHeaderDataTable headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
                using (Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
                {
                    adapterHeader.SetTimeout(600);
                    adapterHeader.Fill(headersTable, companyID, orderType, orderID);
                }

                foreach (Data.Complaints.ReportCalculationHeaderRow header in headersTable)
                {
                    if (debtorCopy && !header.IsTaxInvoiceMarkDebtorOriginalNull() && !string.IsNullOrEmpty(header.TaxInvoiceMarkDebtorOriginal))
                    {
                        header.TaxInvoiceMarkDebtorOriginal = "X";
                        header.TaxInvoiceMarkSellerCopy = " ";
                        complaint.ReportCalculationHeader.LoadDataRow(header.ItemArray, true);
                        //break;
                    }
                    else if (!debtorCopy && !header.IsTaxInvoiceMarkSellerCopyNull() && !string.IsNullOrEmpty(header.TaxInvoiceMarkSellerCopy))
                    {
                        header.TaxInvoiceMarkDebtorOriginal = " ";
                        header.TaxInvoiceMarkSellerCopy = " ";
                        //header.TaxInvoiceMarkEDI = "X";
                        complaint.ReportCalculationHeader.LoadDataRow(header.ItemArray, true);
                        //break;
                    }

                    // Электронная
                    var flagElectroInvoice = (header.MarkEV01 == 0);
                    if (flagElectroInvoice)
                        header.TaxInvoiceMarkEDI = "X";

                    break;
                }


                #endregion

                #region ФОРМИРОВАНИЕ ПОЗИЦИЙ

                var taxInvoiceNumber = complaint.ReportCalculationHeader[0].InvoiceNumber;

                using (Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                    adapterDetail.Fill(complaint.ReportCalculationDetail, companyID, orderType, orderID, taxInvoiceNumber.ToString());

                #endregion

                return complaint;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReportClass GetReport(DataSet docSource, DateTime printDate)
        {
            ReportClass report = null;

            if (printDate >= new DateTime(2015, 1, 1))
                report = new ComplaintCalculationReport_Since_01_2015();
            else if (printDate >= new DateTime(2014, 12, 1))
                report = new ComplaintCalculationReport_Since_07_2014();
            else if (printDate >= new DateTime(2014, 3, 1))
                report = new ComplaintCalculationReport_Since_01_2014();
            else if (printDate >= new DateTime(2011, 12, 16))
                report = new ComplaintCalculationReport();
            else if (printDate <= new DateTime(2011, 12, 15))
                report = new ComplaintCalculationReportOld2();

            report.SetDataSource(docSource);
            return report;
        }

        #endregion
    }

    /// <summary>
    /// Менеджер отчетов для сводных налоговых накладных
    /// </summary>
    public class ElSumTaxInvoiceReportManager : IReportManager
    {
        #region IReportManager Members

        public int UserID { get; set; }

        public DataSet PrepareDocumentSource(DataRow document, bool debtorCopy, out bool allowPrint)
        {
            allowPrint = true;

            try
            {
                var sumInvoice = new Data.PrintNaklSummary();

                var conn = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);
                var command = conn.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "pr_PI_GetNaklSummary_forPrint";
                command.Parameters.AddWithValue("@Year", document["svod_year"]);
                command.Parameters.AddWithValue("@Month", document["svod_month"]);
                command.Parameters.AddWithValue("@Doc", document["svod_number"]);
                command.Parameters.AddWithValue("@DebtorCopy", debtorCopy);

                command.CommandTimeout = 600;
                conn.Open();
                var reader = command.ExecuteReader();

                #region ФОРМИРОВАНИЕ ЗАГОЛОВКА

                AddHeaderForNaklSummary(sumInvoice, reader);

                if (reader["MarkEV01"].Equals(0))
                    allowPrint = false;

                #endregion

                reader.NextResult();

                #region ФОРМИРОВАНИЕ ПОЗИЦИЙ

                AddDetailsForNaklSummary(sumInvoice, reader);

                #endregion

                conn.Close();

                return sumInvoice;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public ReportClass GetReport(DataSet docSource, DateTime printDate)
        {
            ReportClass report = null;

            if (printDate >= new DateTime(2015, 1, 1))
                report = new PNSumTaxInvoiceReport_Since_01_2015();
            else if (printDate >= new DateTime(2014, 12, 1))
                report = new PNSumTaxInvoiceReport_Since_07_2014();
            else if (printDate >= new DateTime(2014, 3, 1))
                report = new PNSumTaxInvoiceReport_Since_01_2014();
            else if (printDate < new DateTime(2014, 3, 1))
                report = new PNSumTaxInvoiceReport();

            report.SetDataSource(docSource);
            return report;
        }

        #endregion

        /// <summary>
        /// Создание таблицы с заголовком печатной формы сводной накладной
        /// </summary>
        /// <param name="pDs">DataSet, в котором находится таблица с заголовком сводной накладной</param>
        /// <param name="pReader">Объект для чтения данных заголовка из БД</param>
        private void AddHeaderForNaklSummary(PrintNaklSummary pDs, SqlDataReader pReader)
        {
            pReader.Read();  // Считываем заголовок
            pDs.PrintNaklSummaryHeader.Rows.Add(
                pReader["IsVAT"],
                pReader["SummarySum"],
                pReader["DebtorCode"],
                pReader["DebtorName"],
                pReader["SellerName"],
                pReader["SellerINN"],
                pReader["SellerPostCode"],
                pReader["SellerAddress"],
                pReader["SellerPhone"],
                pReader["SellerTax"],
                pReader["DebtorTaxNumber"],
                pReader["DebtorAddress"],
                pReader["DebtorPhone"],
                pReader["DebtorContractType"],
                pReader["PayType"],
                pReader["DebtorCertNumber"],
                pReader["DebtorContractNum"],
                pReader["DebtorContractDate"],
                pReader["TaxInvoice"],
                pReader["NalogDeliveryResponsePerson"],
                pReader["InvoiceSumNal"],
                pReader["InvoiceSumWithVATNal"],
                pReader["InvoiceSumVATNal"],
                pReader["TaxInvoiceMarkDebtorOriginal"],
                pReader["TaxInvoiceMarkDebtorERPN"],
                pReader["TaxInvoiceMarkSellerOriginal"],
                pReader["TaxInvoiceMarkSellerOriginalReason1"],
                pReader["TaxInvoiceMarkSellerOriginalReason2"],
                pReader["TaxInvoiceMarkSellerCopy"],
                pReader["InvoicePrintDate"],
                pReader["InvoiceType"],
                pReader["TaxInvoiceCount"],
                pReader["isClienPrint"],
                pReader["TaxInvoiceMarkEDI"],
                pReader["InvoiceType2"],
                pReader["InvoiceNNDate"]);
        }

        /// <summary>
        /// Создание таблицы со строками печатной формы сводной накладной
        /// </summary>
        /// <param name="pDs">DataSet, в котором находится таблица со строками сводной накладной</param>
        /// <param name="pReader">Объект для чтения данных сводной накладной из БД</param>
        private void AddDetailsForNaklSummary(PrintNaklSummary pDs, SqlDataReader pReader)
        {
            while (pReader.Read())
                pDs.PrintNaklSummaryDetails.Rows.Add(
                    pReader["InvoiceDate"],
                    pReader["ItemName"],
                    pReader["UnitOfMeasureName"],
                    pReader["Quantity"],
                    pReader["SellPriceNal"],
                    pReader["RowSumNal"],
                    pDs.PrintNaklSummaryHeader.Rows[0]["IsVAT"],
                    pReader["TPP_COD"],
                    pReader["UomCode"]);
        }
    }
}
