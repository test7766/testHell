using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Data;
using WMSOffice.Classes;
using WMSOffice.Dialogs;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Data.PrintNaklTableAdapters;
using CrystalDecisions.Shared;
using WMSOffice.Reports;

namespace WMSOffice.Window.QualityWnd
{
    public partial class QualityRegistryGLSWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        /// <summary>
        /// Реквизит компании - название "Оптима фарм"
        /// </summary>
        private string optimaRequisiteName;


        public QualityRegistryGLSWindow()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PrintDocsThread.FillPrintersComboBox(cbPrinter.ComboBox);
            PrepareGridViews();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            SearchData();
        }

        private void PrepareGridViews()
        {
            xdgvDocs.Init(new RegistryNewGLSView(), true); // RegistryGLSView
            //dgvDocs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            xdgvDocs.UserID = UserID;
            xdgvDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            xdgvDocs.AllowRangeColumns = true;
            xdgvDocs.UseMultiSelectMode = false;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);

#if old_version
            dgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);

            dgvDetails.Init(new RegistryGLSDetailsView(), true);
            //dgvDetails.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvDetails.UserID = UserID;
            dgvDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDetails.AllowRangeColumns = true;
            dgvDetails.UseMultiSelectMode = true;
#endif

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            SetOperationAccess();
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            var row = xdgvDocs.SelectedItem as Quality.BL_Registry_DocsRow;
            if (row == null)
                return;

            var par = new DocDetailSearchParam { DocId = row.Registry_Id };

            BackgroundWorker detailWorker = new BackgroundWorker();
            detailWorker.DoWork += new DoWorkEventHandler(detailWorker_DoWork);
            detailWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printDocsWorker_RunWorkerCompleted);

            splashForm.ActionText = "Подготовка данных...";
            detailWorker.RunWorkerAsync(par);
            splashForm.ShowDialog();
        }

        void detailWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var par = e.Argument as DocDetailSearchParam;
            if (par == null)
                return;

            dgvDetails.DataView.FillData(par);
            Action<DocDetailSearchParam> action = PrepareDetail;

            BeginInvoke(action, par);
        }

        private void PrepareDetail(DocDetailSearchParam par)
        {
            dgvDetails.BindData(false);
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocs.RecalculateSummary();
            SetOperationAccess();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SetOperationAccess()
        {
            btnExportToExcel.Enabled = xdgvDocs.HasRows;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                var searchParams = new RegistryNewGLSSearchParameters
                {
                    SessionID = this.UserID,

                    PeriodFrom = QualityRegistrySearchPrintDocForm.SearchParameter.PeriodFrom,
                    PeriodTo = QualityRegistrySearchPrintDocForm.SearchParameter.PeriodTo,
                    WarehouseCode = QualityRegistrySearchPrintDocForm.SearchParameter.WarehouseCode
                };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as RegistryNewGLSSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение реестра ГЛС..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintWorkerParameters parameters = new PrintWorkerParameters()
            {
                PrinterName = (string)cbPrinter.SelectedItem
            };

            BackgroundWorker printDocsWorker = new BackgroundWorker();
            printDocsWorker.DoWork += new DoWorkEventHandler(printDocsWorker_DoWork);
            printDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printDocsWorker_RunWorkerCompleted);

            splashForm.ActionText = "Печать документов...";
            printDocsWorker.RunWorkerAsync(parameters);
            splashForm.ShowDialog();

        }

        private void printDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters parameters = e.Argument as PrintWorkerParameters;

                using (var report = GetRegistryReport())
                {
                    report.PrintOptions.PrinterName = parameters.PrinterName;

                    report.PrintOptions.PrinterDuplex = this.GetPrinterDuplexRegime();

                    //report.PrintToPrinter(1, true, 1, 0);

                    using (var reportForm = new ReportForm() { ShowInTaskbar = false })
                    {
                        reportForm.ReportDocument = report;
                        Invoke((MethodInvoker)delegate
                        {
                            reportForm.ShowDialog(this);
                        });
                    }
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
        }


        private void SearchData()
        {

#if old_version
            var frm = new QualityRegistrySearchForm() { ShowInTaskbar = false, StartPosition = FormStartPosition.CenterParent, Owner = this };
            if (frm.ShowDialog() != DialogResult.OK)
                return;

            var par = new DocSearchParam
            {
                BlockID = frm.BlockType,
                End = frm.DateEnd,
                ItemID = frm.ItemID,
                LotID = frm.VendorLot,
                Manufacturer = frm.Manufacturer,
                Start = frm.DateStart,
                Vendor = frm.Vendor,
                SearchType = frm.SearchType,
                SessionID = UserID
            };
#endif

            var dlgQualityRegistrySearchPrintDoc = new QualityRegistrySearchPrintDocForm { UserID = this.UserID };
            if (dlgQualityRegistrySearchPrintDoc.ShowDialog() != DialogResult.OK)
                return;

            LoadDocs();

        }

        /// <summary>
        /// Анализ печати в дуплексном режиме
        /// </summary>
        /// <param name="naklData"></param>
        /// <returns></returns>
        private PrinterDuplex GetPrinterDuplexRegime()
        {
            if (dgvDetails.DataView.Data.Rows.Count > 10)
                return PrinterDuplex.Horizontal;
            else
                return PrinterDuplex.Simplex;
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
        /// Создает отчет - реестр лекарственных средств.
        /// </summary>
        /// <returns>Отчет в виде реестра лекарственных средств.</returns>
        private ReportClass GetRegistryReport()
        {
            if (dgvDetails.DataView.Data.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в источнике данных для формирования содержимого реестра.");

            // создание и возврат отчета
            ReportClass report;
            report = new Reports.QBVendorRegister();

            report.SetDataSource(dgvDetails.DataView.Data);

            return report;
        }

        private void ssbPrintRegistry_ButtonClick(object sender, EventArgs e)
        {
            ssbPrintRegistry.ShowDropDown();
        }

        private void ssbiPrintGlsRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgQualityRegistrySearchPrintDoc = new QualityRegistrySearchPrintDocForm { UserID = this.UserID };
                if (dlgQualityRegistrySearchPrintDoc.ShowDialog() != DialogResult.OK)
                    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.pr_QB_Get_Registry_ActsTableAdapter())
                    adapter.Fill(reportSource.pr_QB_Get_Registry_Acts, QualityRegistrySearchPrintDocForm.SearchParameter.WarehouseCode, this.UserID, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodFrom, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodTo);

                using (var report = new QualityGlsRegistryReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ssbiRecalledProductsRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgQualityRegistrySearchPrintDoc = new QualityRegistrySearchPrintDocForm { UserID = this.UserID };
                if (dlgQualityRegistrySearchPrintDoc.ShowDialog() != DialogResult.OK)
                    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.pr_QB_Get_Registry_Recalled_ProductsTableAdapter())
                    adapter.Fill(reportSource.pr_QB_Get_Registry_Recalled_Products, QualityRegistrySearchPrintDocForm.SearchParameter.WarehouseCode, this.UserID, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodFrom, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodTo);

                using (var report = new QualityRecalledProductsRegistryReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ssbiGlsProhibitionsNotificationsRegistry_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgQualityRegistrySearchPrintDoc = new QualityRegistrySearchPrintDocForm { UserID = this.UserID };
                if (dlgQualityRegistrySearchPrintDoc.ShowDialog() != DialogResult.OK)
                    return;

                var reportSource = new Quality();
                using (var adapter = new Data.QualityTableAdapters.pr_QB_Get_Registry_ReportsTableAdapter())
                    adapter.Fill(reportSource.pr_QB_Get_Registry_Reports, QualityRegistrySearchPrintDocForm.SearchParameter.WarehouseCode, this.UserID, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodFrom, QualityRegistrySearchPrintDocForm.SearchParameter.PeriodTo);

                using (var report = new QualityGlsProhibitionsNotificationsRegistryReport())
                {
                    report.SetDataSource(reportSource);

                    using (var reportForm = new ReportForm())
                    {
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvDocs.ExportToExcel("Экспорт реестра о запрете и приостановлении реализации товара в Excel", "реестр о запрете и приостановлении реализации товара", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        public class RegistryNewGLSView : IDataView
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
                try
                {
                    var par = pSearchParameters as RegistryNewGLSSearchParameters;
                    using (var adapter = new pr_QB_Get_Main_RegistryTableAdapter())
                        data = adapter.GetData(par.WarehouseCode, par.SessionID, par.PeriodFrom, par.PeriodTo);
                }
                catch
                {
                    data = new Quality.BL_Registry_DocsDataTable();
                }
            }

            public RegistryNewGLSView()
            {
                this.dataColumns.Add(new PatternColumn("№ п/п", "RowNum", new FilterCompareExpressionRule<Int32>("RowNum"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("№ розпорядження", "DocNumber", new FilterPatternExpressionRule("DocNumber"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата розпорядження", "DocDate", new FilterDateCompareExpressionRule("DocDate"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Код товару", "ItemID", new FilterCompareExpressionRule<Int32>("ItemID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Найменування товару", "ItemName", new FilterPatternExpressionRule("ItemName"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Виробник", "Manufacturer", new FilterPatternExpressionRule("Manufacturer"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Код постачальника", "VendorID", new FilterCompareExpressionRule<Int32>("VendorID"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Постачальник", "VendorName", new FilterPatternExpressionRule("VendorName"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Серія", "LotNumber", new FilterPatternExpressionRule("LotNumber"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Наявність товару на складі", "Remain", new FilterPatternExpressionRule("Remain"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Опис", "DocType", new FilterPatternExpressionRule("DocType"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Підстава для відкликання", "RecallBasis", new FilterPatternExpressionRule("RecallBasis"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Ініціатор відкликання", "Originator", new FilterPatternExpressionRule("Originator"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата початку відкликання", "CoDateFrom", new FilterDateCompareExpressionRule("CoDateFrom"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата закінчення відкликання", "CoDateTo", new FilterDateCompareExpressionRule("CoDateTo"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Причина відкликання", "RecallReason", new FilterPatternExpressionRule("RecallReason"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("№ повідомлення в ДЛС", "ReportNumber", new FilterCompareExpressionRule<Int32>("ReportNumber"), SummaryCalculationType.Count));
                this.dataColumns.Add(new PatternColumn("Дата повідомлення в ДЛС", "ReportDate", new FilterDateCompareExpressionRule("ReportDate"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата внесення в систему", "DateCreated", new FilterDateCompareExpressionRule("DateCreated"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("П.І.Б. особи, що внесла дані", "UserCreated", new FilterPatternExpressionRule("UserCreated"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Назва складу", "McuName", new FilterPatternExpressionRule("McuName"), SummaryCalculationType.None));
            }
        }

        public class RegistryNewGLSSearchParameters : SessionIDSearchParameters
        {
            public DateTime? PeriodFrom { get; set; }
            public DateTime? PeriodTo { get; set; }
            public string WarehouseCode { get; set; }
        }

        #region КЛАССЫ ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА С РЕЕСТРАМИ

        /// <summary>
        /// Представление для грида с макетами списания
        /// </summary>
        private class RegistryGLSView : IDataView
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
                try
                {
                    var par = pSearchParameters as DocSearchParam;
                    using (var adapter = new BL_Registry_DocsTableAdapter())
                        data = adapter.GetData(par.SearchType, par.Manufacturer, par.Vendor, par.Start, par.End, par.ItemID, par.LotID, par.SessionID, par.BlockID);
                }
                catch
                {
                    data = new Quality.BL_Registry_DocsDataTable();
                }
            }

            public RegistryGLSView()
            {
                this.dataColumns.Add(new PatternColumn("№ реестра", "Registry_Id", new FilterCompareExpressionRule<Int64>("Registry_Id"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Период реестра", "Period_Name", new FilterPatternExpressionRule("Period_Name"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Тип реестра", "Registry_Type", new FilterPatternExpressionRule("Registry_Type"), SummaryCalculationType.None));
            }
        }

        private class DocDetailSearchParam : SearchParametersBase
        {
            public int DocId { get; set; }
        }

        private class DocSearchParam : SearchParametersBase
        {
            public DateTime Start { get; set; }
            public DateTime End { get; set; }
            public int? ItemID { get; set; }
            public string LotID { get; set; }
            public int? Manufacturer { get; set; }
            public int? Vendor { get; set; }
            public string BlockID { get; set; }
            public int SearchType { get; set; }
            public long SessionID { get; set; }
        }

        #endregion

        #region КЛАССЫ ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА С СТРОКАМИ РЕЕСТРА

        /// <summary>
        /// Представление для грида с макетами списания
        /// </summary>
        private class RegistryGLSDetailsView : IDataView
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
                try
                {
                    var par = pSearchParameters as DocDetailSearchParam;
                    using (var adapter = new BL_Registry_DetailTableAdapter())
                        data = adapter.GetData(par.DocId);
                }
                catch
                {
                    data = new Quality.BL_Registry_DetailDataTable();
                }
            }

            public RegistryGLSDetailsView()
            {
                this.dataColumns.Add(new PatternColumn("Номер распоряжения", "doc_number", new FilterCompareExpressionRule<Int64>("doc_number"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата распоряжения", "doc_date", new FilterDateCompareExpressionRule("doc_date"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Код товара", "item_id", new FilterCompareExpressionRule<Int64>("item_id"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Наименование", "item", new FilterPatternExpressionRule("item"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Производитель", "manufacturer", new FilterPatternExpressionRule("manufacturer"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Серия", "lot_number", new FilterPatternExpressionRule("lot_number"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Срок годности", "expiration_date", new FilterDateCompareExpressionRule("expiration_date"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Тип блокировки", "hold_type", new FilterPatternExpressionRule("hold_type"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Поставщик", "vender", new FilterPatternExpressionRule("vender"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Номер накладной поставщика", "invoice", new FilterCompareExpressionRule<Int64>("invoice"), SummaryCalculationType.None));
                this.dataColumns.Add(new PatternColumn("Дата накладной поставщика", "invoice_date", new FilterDateCompareExpressionRule("invoice_date"), SummaryCalculationType.None));

            }
        }

        #endregion
    }
}
