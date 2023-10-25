using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Threading;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

using WMSOffice.Data;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.WH;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно в модуле документов для работы со сводными налоговыми накладными
    /// </summary>
    public partial class WHDocsPrintSummaryInvoicesWindow : GeneralWindow
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Окно ожидания, используемое при длительной обработке данных.
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        /// <summary>
        /// Выделенная строка в таблице сводных накладных
        /// </summary>
        private WH.PI_FindNaklSummaryRow SelectedRow
        {
            get
            {
                if (dgvDocs.SelectedRows.Count == 0)
                    return null;
                else
                    return (WH.PI_FindNaklSummaryRow)((DataRowView)dgvDocs.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Код дебитора для поиска в архиве
        /// </summary>
        private int? debtorID;

        /// <summary>
        /// Дата "с" для поиска в архиве
        /// </summary>
        private DateTime? dateFrom;

        /// <summary>
        /// Дата "по" для поиска в архиве
        /// </summary>
        private DateTime? dateTo;

        /// <summary>
        /// Номер сводной налоговой для поиска в архиве
        /// </summary>
        private long? sNukl;

        /// <summary>
        /// Признак "распечатан" для поиска в архиве
        /// </summary>
        private int? printed = 0;

        /// <summary>
        /// Номер накладной для поиска в архиве
        /// </summary>
        private int? nuklNumber;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public WHDocsPrintSummaryInvoicesWindow()
        {
            InitializeComponent();
            InitPrinters();
            Config.LoadDataGridViewSettings(Name, dgvDocs);
            cbPrintedFilter.SelectedIndex = 0;
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
        /// Загрузка данных при отображении окна
        /// </summary>
        private void WHDocsPrintSummaryInvoicesWindow_Shown(object sender, EventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Загрузка данных в таблицу сводных НН
        /// </summary>
        private void RefreshData()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += loadDocsWorker_DoWork;
            worker.RunWorkerCompleted += loadDocsWorker_RunWorkerCompleted;
            bsPIFindNaklSummary.DataSource = null;
            splashForm.ActionText = "Загрузка текущих сводных НН...";
            dgvDocs.Enabled = false;
            worker.RunWorkerAsync();
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Загружает в фоне список налоговых накладных
        /// </summary>
        private void loadDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var adapter = new PI_FindNaklSummaryTableAdapter())
                {
                    adapter.SetTimeout(600);
                    adapter.Fill(wH.PI_FindNaklSummary, UserID, debtorID, dateFrom, dateTo, sNukl, printed, nuklNumber, null);
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Загрузка данных завершена - обновляем таблицу на интерфейсе
        /// </summary>
        private void loadDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                wH.PI_FindNaklSummary.Clear();
            }

            bsPIFindNaklSummary.DataSource = wH.PI_FindNaklSummary;
            RefreshInvoicesToPrintLabel();
            splashForm.CloseForce();
            dgvDocs.Enabled = true;
            MakeButtonsDisabled();
        }

        /// <summary>
        /// Обновление надписи с количеством накладных для печати
        /// </summary>
        private void RefreshInvoicesToPrintLabel()
        {
            int count = 0;

            foreach (DataRowView row in bsPIFindNaklSummary)
            {
                var invoice = row.Row as WH.PI_FindNaklSummaryRow;
                if (invoice.IS_Printed1 == 0)
                    count++;
            }

            lblCount.Text = "Кол-во накладных для печати:" + Environment.NewLine + count;
        }

        /// <summary>
        /// Метод, который делает недоступными некоторые кнопки и пункты меню в зависимости от условий
        /// </summary>
        private void MakeButtonsDisabled()
        {
            if (dgvDocs.SelectedRows.Count == 0)
            {
                tsmiViewOptimaInvoice.Enabled = false;
                tsmiPrintPaketDocs.Enabled = false;
                tsmiExportRegister.Enabled = false;
                tsmiExportGroupedRegister.Enabled = false;
                tsmiPrintInvoiceForClient.Enabled = false;
                tsmiPrintInvoiceForOptima.Enabled = false;
                btnExportRegisterToExcel.Enabled = false;
                btnPrintPaketDocs.Enabled = false;
                tsmiViewClientInvoice.Enabled = false;
                tsmiViewOptimaInvoice.Enabled = false;
            }
            else
            {
                tsmiViewOptimaInvoice.Enabled = true;
                tsmiPrintPaketDocs.Enabled = false; // cbPrinters.SelectedItem != null;
                tsmiPrintInvoiceForClient.Enabled = false; // cbPrinters.SelectedItem != null && SelectedRow.IS_Printed1 > 0;

                tsmiPrintInvoiceForOptima.Enabled = false;
                //tsmiPrintInvoiceForOptima.Enabled = cbPrinters.SelectedItem != null && SelectedRow.IS_Printed1 > 0;

                tsmiViewClientInvoice.Enabled = SelectedRow.IS_Printed1 > 0;
                tsmiViewOptimaInvoice.Enabled = SelectedRow.IS_Printed1 > 0;
                tsmiExportRegister.Enabled = true;
                tsmiExportGroupedRegister.Enabled = true;
                btnExportRegisterToExcel.Enabled = true;
                btnPrintPaketDocs.Enabled = false; // cbPrinters.SelectedItem != null;
            }
        }

        /// <summary>
        /// Закрашивание распечатанных строк в зеленый цвет
        /// </summary>
        private void dgvDocs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var printed = dgvDocs.Rows[e.RowIndex].Cells[iSPrintedDataGridViewCheckBoxColumn.Index].Value;

            if (printed != null && printed != DBNull.Value && Convert.ToBoolean(printed))
                dgvDocs.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Green;
        }

        /// <summary>
        /// Определение доступности кнопок при изменении выделенной накладной
        /// </summary>
        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            MakeButtonsDisabled();
        }

        #endregion

        #region ФИЛЬТРАЦИЯ ПО ПРИЗНАКУ "НАПЕЧАТАН"

        /// <summary>
        /// Фильтрация по признаку "напечатан" при изменении фильтра по уже загруженным данным
        /// </summary>
        private void cbPrintedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var cmb = sender as ToolStripComboBox;
            if (cmb.SelectedIndex == 0)
                bsPIFindNaklSummary.Filter = "Is_Printed1 = 0";
            else if (cmb.SelectedIndex == 1)
                bsPIFindNaklSummary.Filter = "Is_Printed1 = 1";
            else
                bsPIFindNaklSummary.Filter = "";

            RefreshInvoicesToPrintLabel();
        }

        #endregion

        #region ОТОБРАЖЕНИЕ СВОДНЫХ НАЛОГОВЫХ НАКЛАДНЫХ

        /// <summary>
        /// Обновление данных в таблице сводных налоговых накладных
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        #endregion

        #region ПОИСК В АРХИВЕ

        /// <summary>
        /// Поиск в архиве по параметрам
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchNaklSummaryForm
            {
                DebtorID = debtorID,
                SNukl = sNukl,
                NuklNumber = nuklNumber,
                Printed = printed,
                DateFrom = dateFrom,
                DateTo = dateTo
            };

            searchForm.Owner = this;
            searchForm.ShowDialog();
            if (searchForm.DialogResult == DialogResult.OK)
            {
                debtorID = searchForm.DebtorID;
                sNukl = searchForm.SNukl;
                nuklNumber = searchForm.NuklNumber;
                printed = searchForm.Printed;
                dateFrom = searchForm.DateFrom;
                dateTo = searchForm.DateTo;
                RefreshData();
                SynchronizePrintedFilters(printed);
            }
        }

        /// <summary>
        /// Синхронизация фильтра по признаку "распечатан" в выпадающем списке и фильтра по признаку "распечатан" на форме поиска
        /// </summary>
        /// <param name="pPrinted">Значение фильтра по признаку "распечатан" на форме поиска</param>
        private void SynchronizePrintedFilters(int? pPrinted)
        {
            if (pPrinted == 0)
                cbPrintedFilter.SelectedIndex = 0;
            else if (pPrinted == 1)
                cbPrintedFilter.SelectedIndex = 1;
            else
                cbPrintedFilter.SelectedIndex = 2;
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ ДОКУМЕНТОВ

        /// <summary>
        /// Просмотр выбранной накладной
        /// </summary>
        private void tsmiViewInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                bool canPrintSign;
                bool canPrint = true;

                var ds = PrepareDataSetForNaklSummary(SelectedRow, sender == tsmiViewClientInvoice, out canPrintSign);

                canPrintSign &= !(SelectedRow.MarkEV01 == 0);

                if (sender == tsmiViewOptimaInvoice)
                {
                    if (ds.PrintNaklSummaryHeader[0].InvoiceNNDate < new DateTime(2014, 3, 1))
                        AdaptPNSummaryForSeller(ds);

                    canPrint = false;
                }
                else if (sender == tsmiViewClientInvoice)
                {
                    if (ds.PrintNaklSummaryHeader[0].InvoiceNNDate < new DateTime(2014, 3, 1))
                        AdaptPNSummaryForDebtor(ds);

                    canPrint = true; // ?
                }

                if (!canPrintSign)
                    canPrint = false;

                using (var reportForm = new ReportForm())
                using (var report = GetSumTaxInvoiceReport(ds))
                {
                    reportForm.ReportDocument = report;

                    if (ds.PrintNaklSummaryHeader[0].InvoiceNNDate >= new DateTime(2014, 3, 1) && !canPrint)
                    {
                        reportForm.CanPrint = false;
                        reportForm.CanExport = false;
                        reportForm.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", reportForm.Text);
                    }

                    reportForm.ShowDialog();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка: " + Environment.NewLine +
                    exc.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид сводных налоговых накладных
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные документа</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид сводных налоговых накладных</returns>
        private PrintNaklSummary PrepareDataSetForNaklSummary(WH.PI_FindNaklSummaryRow pRow, bool debtorCopy, out bool allowPrint)
        {
            allowPrint = true;

            var dataSet = new PrintNaklSummary();

            var conn = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);
            var command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "pr_PI_GetNaklSummary_forPrint";
            command.Parameters.AddWithValue("@Year", pRow["Year"]);
            command.Parameters.AddWithValue("@Month", pRow["Month"]);
            command.Parameters.AddWithValue("@Doc", pRow["Doc_Number"]);
            command.Parameters.AddWithValue("@DebtorCopy", debtorCopy);
            command.CommandTimeout = 600;
            conn.Open();
            var reader = command.ExecuteReader();

            AddHeaderForNaklSummary(dataSet, reader);

            if (reader["MarkEV01"].Equals(0))
                allowPrint = false;

            reader.NextResult();
            AddDetailsForNaklSummary(dataSet, reader);
            conn.Close();

            return dataSet;
        }

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

        /// <summary>
        /// Создание отчета сводной налоговой накладной в новом формате (с 16.12.2011) по выбранной сводной НН
        /// </summary>
        /// <param name="pDs">Источник данных для отчета</param>
        /// <returns>Отчет в виде сводной налоговой накладной в новом формате (с 16.12.2011) по выбранной сводной НН</returns>
        private ReportClass GetSumTaxInvoiceReport(PrintNaklSummary pDs)
        {
            if (pDs.PrintNaklSummaryHeader.Rows.Count < 1)
                throw new ArgumentException("Не удалось загрузить заголовок отчета!");
            else if (pDs.PrintNaklSummaryDetails.Rows.Count < 1)
                throw new ArgumentException("Отчет не содержит ни одной строки!");

            ReportClass report = null;

            if (pDs.PrintNaklSummaryHeader[0].InvoiceNNDate >= new DateTime(2015, 1, 1))
            {
                report = new PNSumTaxInvoiceReport_Since_01_2015();
            }
            else if (pDs.PrintNaklSummaryHeader[0].InvoiceNNDate >= new DateTime(2014, 12, 1))
            {
                report = new PNSumTaxInvoiceReport_Since_07_2014();
            }
            else if (pDs.PrintNaklSummaryHeader[0].InvoiceNNDate >= new DateTime(2014, 3, 1))
            {
                report = new PNSumTaxInvoiceReport_Since_01_2014();
            }
            else if (pDs.PrintNaklSummaryHeader[0].InvoiceNNDate < new DateTime(2014, 3, 1))
            {
                report = new PNSumTaxInvoiceReport();
            }

            report.SetDataSource(pDs);
            return report;
        }

        /// <summary>
        /// Печать документа (какого именно - зависит от нажатого пункта меню
        /// </summary>
        private void tsmiPrintDocument_Click(object sender, EventArgs e)
        {
            if (sender == tsmiPrintInvoiceForClient)
                PrintDocument(PrintDocsType.TaxInvoiceForClient);
            else if (sender == tsmiPrintInvoiceForOptima)
                PrintDocument(PrintDocsType.TaxInvoiceForOptima);
            else if (sender == btnPrintPaketDocs || sender == tsmiPrintPaketDocs)
                PrintDocument(PrintDocsType.TaxInvoiceAndRegister);
        }

        /// <summary>
        /// Запуск печати заданного документа по выбранной накладной в фоновом потоке
        /// </summary>
        /// <param name="pDocType">Тип документа, который нужно распечатать</param>
        private void PrintDocument(PrintDocsType pDocType)
        {
            //MessageBox.Show("Печать", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            string title = String.Empty;
            if (pDocType == PrintDocsType.TaxInvoice)
                title = "Печать налоговых накладных для выбранных документов...";
            else if (pDocType == PrintDocsType.TaxInvoiceForClient)
                title = "Печать налоговой накладной для клиента для выбранных документов...";
            else if (pDocType == PrintDocsType.TaxInvoiceForOptima)
                title = "Печать налоговой накладной для Оптимы для выбранных документов...";
            else if (pDocType == PrintDocsType.TaxInvoiceAndRegister)
                title = "Печать пакета документов...";

            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            var parameters = new PrinterWorkerParameters() { PrinterName = (string)cbPrinters.SelectedItem, DocsType = pDocType };
            foreach (DataGridViewRow row in dgvDocs.SelectedRows)
                parameters.DocsToPrint.Add((row.DataBoundItem as DataRowView).Row as WH.PI_FindNaklSummaryRow);
            parameters.DocsToPrint.Reverse();
            //parameters.DocsToPrint.Sort(CompareInvoicesByNumber);
            splashForm.ActionText = title;
            printWorker.RunWorkerAsync(parameters);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Печатает в фоне сводную налоговую накладную по выбранному в таблице документу
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                bool canPrintSign;

                var param = (PrinterWorkerParameters)e.Argument;

                // Сначала печатаем копии для клиентов
                foreach (var doc in param.DocsToPrint)
                {
                    var ds = PrepareDataSetForNaklSummary(doc, param.DocsType == PrintDocsType.TaxInvoiceForClient || param.DocsType == PrintDocsType.TaxInvoiceAndRegister, out canPrintSign);

                    using (var report = GetSumTaxInvoiceReport(ds))
                    {
                        // Если нужно - печать реестра
                        if ((param.DocsType == PrintDocsType.TaxInvoiceAndRegister || param.DocsType == PrintDocsType.TaxInvoiceForClient) &&
                            (ds.PrintNaklSummaryHeader.Rows[0] as PrintNaklSummary.PrintNaklSummaryHeaderRow).isClienPrint)
                            PrintRegister(doc, param.PrinterName);

                        canPrintSign &= !(doc.MarkEV01 == 0);
                        if (!canPrintSign)
                            continue;

                        // Если нужно - печать копии для покупателя
                        if ((param.DocsType == PrintDocsType.TaxInvoice || param.DocsType == PrintDocsType.TaxInvoiceAndRegister ||
                            param.DocsType == PrintDocsType.TaxInvoiceForClient) &&
                            (ds.PrintNaklSummaryHeader.Rows[0] as PrintNaklSummary.PrintNaklSummaryHeaderRow).isClienPrint)
                        {
                            if (ds.PrintNaklSummaryHeader[0].InvoiceNNDate < new DateTime(2014, 3, 1))
                                AdaptPNSummaryForDebtor(ds);

                            report.SetDataSource(ds);
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);
                        }
                    }
                }


                // Затем все копии для продавца
                foreach (var doc in param.DocsToPrint)
                {
                    var ds = PrepareDataSetForNaklSummary(doc, param.DocsType == PrintDocsType.TaxInvoiceForClient || param.DocsType == PrintDocsType.TaxInvoiceAndRegister, out canPrintSign);

                    // если до 1-го марта 2014, то без изменений
                    if (ds.PrintNaklSummaryHeader[0].InvoiceNNDate < new DateTime(2014, 3, 1))
                    {
                        using (var report = GetSumTaxInvoiceReport(ds))
                        {
                            report.PrintOptions.PrinterName = param.PrinterName;

                            // Если нужно - печать реестра
                            if (param.DocsType == PrintDocsType.TaxInvoiceAndRegister || param.DocsType == PrintDocsType.TaxInvoiceForOptima)
                                PrintRegister(doc, param.PrinterName);

                            canPrintSign &= !(doc.MarkEV01 == 0);
                            if (!canPrintSign)
                                continue;

                            // Если нужно - печать копии для продавца
                            if (param.DocsType == PrintDocsType.TaxInvoice || param.DocsType == PrintDocsType.TaxInvoiceAndRegister ||
                                param.DocsType == PrintDocsType.TaxInvoiceForOptima)
                            {
                                AdaptPNSummaryForSeller(ds);
                                report.SetDataSource(ds);
                                report.PrintToPrinter(1, true, 1, 0);
                            }
                        }
                    }

                    if (param.DocsType != PrintDocsType.TaxInvoiceForClient && param.DocsType != PrintDocsType.TaxInvoiceForOptima)
                        SetNaklAsPrinted(doc.Year, doc.Month, Convert.ToInt32(doc.Doc_Number));

                    doc.IS_Printed1 = 1;
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Адаптация источника данных для печати сводной накладной продавцу
        /// (примечание: печать для покупателя происходит после печати для продавца, чтобы не потерять причины)
        /// </summary>
        /// <param name="pDs">Источник данный, который нужно адаптировать</param>
        private void AdaptPNSummaryForSeller(PrintNaklSummary pDs)
        {
            var row = pDs.PrintNaklSummaryHeader.Rows[0] as PrintNaklSummary.PrintNaklSummaryHeaderRow;
            row.TaxInvoiceMarkDebtorOriginal = String.Empty;
            row.TaxInvoiceMarkSellerCopy = "X";
        }

        /// <summary>
        /// Адаптация источника данных для печати сводной накладной покупателю
        /// (примечание: печать для покупателя происходит после печати для продавца, чтобы не потерять причины)
        /// </summary>
        /// <param name="pDs">Источник данный, который нужно адаптировать</param>
        private void AdaptPNSummaryForDebtor(PrintNaklSummary pDs)
        {
            var row = pDs.PrintNaklSummaryHeader.Rows[0] as PrintNaklSummary.PrintNaklSummaryHeaderRow;
            row.TaxInvoiceMarkDebtorOriginal = "X";
            row.TaxInvoiceMarkSellerCopy = String.Empty;
            row.TaxInvoiceMarkSellerOriginal = String.Empty;
            row.TaxInvoiceMarkSellerOriginalReason1 = String.Empty;
            row.TaxInvoiceMarkSellerOriginalReason2 = String.Empty;
        }

        /// <summary>
        /// Печать реестра на принтере для заданной сводной НН
        /// </summary>
        /// <param name="pDoc">Сводная НН, которую нужно распечатать на принтере</param>
        private void PrintRegister(WH.PI_FindNaklSummaryRow pDoc, string pPrinterName)
        {
            using (var report = new PNSummaryRegisterReport())
            {
                report.SetDataSource(PrepareDataSetForNaklSummaryRegister(pDoc, null));
                report.PrintOptions.PrinterName = pPrinterName;
                report.PrintToPrinter(1, true, 1, 0);
            }
        }

        /// <summary>
        /// Отмечаем накладную в БД как такую, которая печаталась
        /// </summary>
        /// <param name="pYear">Год накладной</param>
        /// <param name="pMonth">Месяц накладной</param>
        /// <param name="pDocId">Номер накладной</param>
        private void SetNaklAsPrinted(double pYear, double pMonth, int pDocId)
        {
            try
            {
                taPI_FindNaklSummary.SetNaklPrinted(pYear, pMonth, pDocId);
            }
            catch (Exception exc) { }
        }

        /// <summary>
        /// Обработка окончания печати отчетов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError((e.Result as Exception).Message);

            splashForm.CloseForce();
        }

        /// <summary>
        /// Метод для сравнивания накладных по номерам
        /// </summary>
        /// <param name="pX">Первая накладная</param>
        /// <param name="pY">Вторая накладная</param>
        /// <returns>1, если первая накладная "больше" за вторую, 0 если они равны, -1, если "больше" вторая накладная</returns>
        private static int CompareInvoicesByNumber(WH.PI_FindNaklSummaryRow pX, WH.PI_FindNaklSummaryRow pY)
        {
            if (Math.Abs(pX.Doc_Number - pY.Doc_Number) < Double.Epsilon)
                return 0;
            else if (pX.Doc_Number > pY.Doc_Number)
                return 1;
            else
                return -1;
        }

        #endregion

        #region ЭКСПОРТ РЕЕСТРА В Excel

        /// <summary>
        /// Экспорт реестра в Excel
        /// </summary>
        private void ExportToExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                bool shortReestr = sender == tsmiExportGroupedRegister;
                var window = new PrintNaklSummaryReestrForm((int)SelectedRow.Doc_Number, SelectedRow.Debtor_ID, UserID, shortReestr);
                window.ShowDialog(this);
                if (window.DialogResult != DialogResult.OK)
                    return;

                using (var dialog = new SaveFileDialog()
                {
                    Title = "Укажите файл для выгрузки реестра",
                    Filter = "Excel-файлы (*.xls)|*.xls"
                })
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var param = window.ForNakl ? null :
                            new ReestrParameters
                            {
                                DateFrom = window.DateFrom,
                                DateTo = window.DateTo,
                                DebtorID = window.DebtorId,
                                ShortReestr = shortReestr,
                                OnlySummary = window.OnlyNaklsSummary,
                                RegistryType = window.RegistryType
                            };

                        // TODO (!) провести анализ
                        using (var report = window.ForNakl 
                            ? (ReportClass)new PNSummaryRegisterReport()
                            : (shortReestr ? (window.RegistryType == RegistryType.InvoiceExtended ? (ReportClass)new PNSummaryRegisterExtendedGroupedReport() : (ReportClass)new PNSummaryRegisterGroupedReport()) : (ReportClass)new PNSummaryRegisterPeriodReport()))
                        {
                            report.SetDataSource(PrepareDataSetForNaklSummaryRegister(SelectedRow, param));
                            report.ExportToDisk(ExportFormatType.Excel, dialog.FileName);
                            Thread.Sleep(500);
                            OpenFile(dialog.FileName);
                        }
                    }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время экспорта реестра: ", exc);
            }
        }

        /// <summary>
        /// Заполняет DataSet, на основании которого будут генерироваться печатный вид реестра сводной налоговой накладной
        /// </summary>
        /// <param name="pRow">Ссылка на строку, содержащую данные документа</param>
        /// <returns>Возвращает DataSet, на основании которого будут генерироваться печатный вид реестра сводной налоговой накладной</returns>
        private PrintNaklSummary PrepareDataSetForNaklSummaryRegister(WH.PI_FindNaklSummaryRow pRow, ReestrParameters pParams)
        {
            var dataSet = new PrintNaklSummary();

            var conn = new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString);
            var command = conn.CreateCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = (pParams != null && pParams.ShortReestr) ?
                (pParams.RegistryType == RegistryType.SummaryInvoice 
                    ? "pr_PI_GetReestrSummaryShort_forPrint" 
                    : pParams.RegistryType == RegistryType.Invoice 
                        ? "pr_PI_GetReestrSummaryShortFull_forPrint" 
                        : pParams.RegistryType == RegistryType.InvoiceExtended
                            ? "pr_PI_GetReestrSummaryShortFullAdvanced_forPrint" 
                            : null) :
                //(pParams.OnlySummary ? "pr_PI_GetReestrSummaryShort_forPrint" : "pr_PI_GetReestrSummaryShortFull_forPrint") :
                "pr_PI_GetReestrSummary_forPrint";
            command.Parameters.AddWithValue("@Year", pParams == null ? pRow["Year"] : String.Empty);
            command.Parameters.AddWithValue("@Month", pParams == null ? pRow["Month"] : String.Empty);
            command.Parameters.AddWithValue("@Doc", pParams == null ? pRow["Doc_Number"] : String.Empty);
            command.Parameters.AddWithValue("@debtorId", pParams == null ? null : (int?)pParams.DebtorID);
            command.Parameters.AddWithValue("@dateFrom", pParams == null ? null : (DateTime?)pParams.DateFrom);
            command.Parameters.AddWithValue("@dateTo", pParams == null ? null : (DateTime?)pParams.DateTo);
            command.CommandTimeout = 600;
            conn.Open();
            var reader = command.ExecuteReader();
            AddHeaderForNaklSummaryRegister(dataSet, reader, pParams);
            reader.NextResult();
            AddDetailsForNaklSummaryRegister(dataSet, reader, (pParams != null && pParams.ShortReestr), (pParams != null && pParams.RegistryType == RegistryType.InvoiceExtended));
            conn.Close();

            return dataSet;
        }

        /// <summary>
        /// Создание таблицы с заголовком печатной формы сводной накладной
        /// </summary>
        /// <param name="pDs">DataSet, в котором находится таблица с заголовком сводной накладной</param>
        /// <param name="pReader">Объект для чтения данных заголовка из БД</param>
        /// <param name="pForNakl">Параметры, по которым загружался список расходных накладных для реестра</param>
        private void AddHeaderForNaklSummaryRegister(PrintNaklSummary pDs, SqlDataReader pReader, ReestrParameters pParam)
        {
            if (!pReader.HasRows)
                throw new ApplicationException("Нет данных по этому дебитору за заданный период!");
            pReader.Read();  // Считываем заголовок
            var table = (pParam != null && pParam.ShortReestr) ?
                (DataTable)pDs.PrintNaklSummaryGroupedRegisterHeader : (DataTable)pDs.PrintNaklSummaryRegisterHeader;
            table.Rows.Add(
                pReader["NaklNumber"],
                pReader["NaklDate"],
                pReader["SellerName"],
                pReader["SellerAddress"],
                pReader["SellerEDRPOY"],
                pReader["SellerINN"],
                pReader["SellerCertificate"],
                pReader["SellerLicens"],
                pReader["SellerType"],
                pReader["InvoiceSum"],
                pReader["InvoiceSumWithVAT"],
                pReader["InvoiceSumVAT"],
                pReader["CorrectSum"],
                pReader["CorrectSumWithVAT"],
                pReader["CorrectSumVAT"],
                pReader["SummarySum"],
                pReader["SummarySumWithVAT"],
                pReader["SummarySumVAT"],
                pReader["DebtorName"],
                pReader["DebtorAddress"],
                pReader["DebtorEDRPOY"],
                pReader["DebtorPhone"],
                pReader["DeliveryTerms"],
                pReader["TextSum"],
                pReader["Perron_ID"],
                pReader["PrintingPerson"],
                pParam == null ? String.Format("РЕЕСТР ВИДАТКОВИХ НАКЛАДНИХ ДО ЗВЕДЕНОЇ ПОДАТКОВОЇ НАКЛАДНОЇ (ЗПН) №{0} ВІД {1}",
                    pReader["NaklNumber"].ToString(), Convert.ToDateTime(pReader["NaklDate"]).ToShortDateString()) :
                String.Format("{0} З {1} ПО {2}",
                pParam.ShortReestr ? (pParam.OnlySummary ? "РЕЕСТР ЗВЕДЕНИХ ПОДАТКОВИХ НАКЛАДНИХ" : "РЕЕСТР ПОДАТКОВИХ НАКЛАДНИХ") : "РЕЕСТР ВИДАТКОВИХ НАКЛАДНИХ ДО ЗВЕДЕНИХ ПОДАТКОВИХ НАКЛАДНИХ",
                    pParam.DateFrom.ToShortDateString(), pParam.DateTo.ToShortDateString()));
        }

        /// <summary>
        /// Создание таблицы со строками печатной формы сводной накладной
        /// </summary>
        /// <param name="pDs">DataSet, в котором находится таблица со строками сводной накладной</param>
        /// <param name="pReader">Объект для чтения данных сводной накладной из БД</param>
        /// <param name="pShortReestr">True если в реестре должны быть только суммы по сводным, False если и расходные накладные тоже</param>
        private void AddDetailsForNaklSummaryRegister(PrintNaklSummary pDs, SqlDataReader pReader, bool pShortReestr, bool extended)
        {
            while (pReader.Read())
            {
                if (pShortReestr)
                {
                    if (!extended)
                    {
                        pDs.PrintNaklSummaryGroupedRegisterDetails.Rows.Add(
                                pReader["Row"],
                                pReader["Date"],
                                pReader["AmountWithoutVAT"],
                                pReader["AmountVAT"],
                                pReader["AmountWithVAT"],
                                pReader["SNN"]);
                    }
                    else
                    {
                        pDs.PrintNaklSummaryGroupedRegisterDetails.Rows.Add(
                            pReader["Row"],
                            pReader["Date"],
                            pReader["AmountWithoutVAT"],
                            pReader["AmountVAT"],
                            pReader["AmountWithVAT"],
                            pReader["SNN"],
                            pReader["DocNumber"],
                            pReader["DeliveryAddress"]);
                    }
                }
                else
                    pDs.PrintNaklSummaryRegisterDetails.Rows.Add(
                        pReader["Row"],
                        pReader["DeliveryPoint"],
                        pReader["DocumentType"],
                        pReader["Date"],
                        pReader["DocNumber"],
                        pReader["AmountWithoutVAT"],
                        pReader["AmountVAT"],
                        pReader["AmountWithVAT"],
                        pReader["SNN"]);
            }
        }

        /// <summary>
        /// Открытие файла в программе, которая соответствует типу файла
        /// </summary>
        /// <param name="pFileName">Название файла</param>
        private void OpenFile(string pFileName)
        {
            try
            {
                Process.Start(pFileName);
            }
            catch (Exception exc)
            {
                ShowError(exc);
            }
        }

        /// <summary>
        /// Параметры для получения данных для реестра
        /// </summary>
        private class ReestrParameters
        {
            /// <summary>
            /// Идентификатор дебитора
            /// </summary>
            public int DebtorID { get; set; }

            /// <summary>
            /// Дата с
            /// </summary>
            public DateTime DateFrom { get; set; }

            /// <summary>
            /// Дата по
            /// </summary>
            public DateTime DateTo { get; set; }

            /// <summary>
            /// Идентификатор накладной
            /// </summary>
            public int NaklId { get; set; }

            /// <summary>
            /// True если в реестре нужно указывать только суммы по сводным, False если вместе с расходными
            /// </summary>
            public bool ShortReestr { get; set; }

            /// <summary>
            /// True если реестр формируется только по сводным накладныма, False - если по всем накладным
            /// </summary>
            public bool OnlySummary { get; set; }

            /// <summary>
            /// Тип реестра
            /// </summary>
            public RegistryType RegistryType { get; set; } 
        }

        #endregion

        #region ОТОБРАЖЕНИЕ ОКНА С РАСХОДНЫМИ СВОДНОЙ НАКЛАДНОЙ

        /// <summary>
        /// Отображение окна с расходными в сводной налоговой накладной
        /// </summary>
        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var window = new NaklSummaryDetailsForm(SelectedRow);
            window.Owner = this;
            window.ShowDialog();
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати отчетов по документу.
        /// </summary>
        private class PrinterWorkerParameters
        {

            /// <summary>
            /// Список строк документов, для которых печатаются отчеты
            /// </summary>
            public List<WH.PI_FindNaklSummaryRow> DocsToPrint = new List<WH.PI_FindNaklSummaryRow>();

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }

            /// <summary>
            /// Тип печати (печать только одной накладной либо пакета документов)
            /// </summary>
            public PrintDocsType DocsType { get; set; }
        }

        /// <summary>
        /// Тип печати (печать только одной накладной либо пакета документов
        /// </summary>
        private enum PrintDocsType
        {
            /// <summary>
            /// Печать только накладной (двух экземпляров, для продавца и покупателя)
            /// </summary>
            TaxInvoice,

            /// <summary>
            /// Печать накладной только для клиента
            /// </summary>
            TaxInvoiceForClient,

            /// <summary>
            /// Печать накладной только для Оптимы
            /// </summary>
            TaxInvoiceForOptima,

            /// <summary>
            /// Печать пакета документов (накладная для продавца, нужное количество накладных для покупателя и реестр)
            /// </summary>
            TaxInvoiceAndRegister
        }

        #endregion

        #region ЗАКРЫТИЕ ФОРМЫ И СОХРАНЕНИЕ НАСТРОЕК

        /// <summary>
        /// Сохранение настроек при закрытии формы
        /// </summary>
        private void WHDocsPrintSummaryInvoicesWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(Name, dgvDocs);
        }

        #endregion
    }
}
