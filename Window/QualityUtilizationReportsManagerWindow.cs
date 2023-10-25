using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using WMSOffice.Dialogs.Quality;
using WMSOffice.Reports;
using WMSOffice.Dialogs;
using System.Xml;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

namespace WMSOffice.Window
{
    public partial class QualityUtilizationReportsManagerWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public QualityUtilizationReportsManagerWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            Initialize();
        }

        private void Initialize()
        {
            sbConsExportActs.Click += (s, e) => { sbConsExportActs.ShowDropDown(); };

            xdgvActs.UserID = this.UserID;

            //this.xdgvActs.AllowFilter = false;
            this.xdgvActs.AllowSummary = false;
            this.xdgvActs.AllowRangeColumns = true;

            this.xdgvActs.Init(new QualityUtilizationReportsView(), true);
            this.xdgvActs.LoadExtraDataGridViewSettings(this.Name);

            xdgvActs.OnRowSelectionChanged += new EventHandler(xdgvActs_OnRowSelectionChanged);
            xdgvActs.OnFilterChanged += new EventHandler(xdgvActs_OnFilterChanged);
            xdgvActs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvActs_OnFormattingCell);

            // активация постраничного просмотра
            xdgvActs.CreatePageNavigator();

            this.ChangeOperationsState();
        }

        void xdgvActs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            ChangeOperationsState();
        }

        private void ChangeOperationsState()
        {
            bool isEnabled = xdgvActs.SelectedItem != null;

            sbPrintUsageProhibitionReport.Enabled = isEnabled;
            sbPrintTransferToUtilizationReport.Enabled = isEnabled;
            sbPrintUtilizationVolumeMethodsReport.Enabled = isEnabled;

            var hasRows = xdgvActs.HasRows;
            sbConsExportUsageProhibitionActs.Enabled = hasRows;
            sbConsExportTransferToUtilizationActs.Enabled = hasRows;
        }

        void xdgvActs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvActs.RecalculateSummary();
        }

        void xdgvActs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
                this.FindData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void sbFind_Click(object sender, EventArgs e)
        {
            FindData();
        }

        private void FindData()
        {
            var dlgQualityUtilizationReportsSearchForm = new QualityUtilizationReportsSearchForm() { UserID = this.UserID };
            if (dlgQualityUtilizationReportsSearchForm.ShowDialog() == DialogResult.OK)
                RefreshData();
        }

        private void RefreshData()
        {
            QualityUtilizationReportsSearchForm.SearchParameters.UserID = this.UserID;

            var loadworker = new BackgroundWorker();

            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    System.Threading.Thread.Sleep(1000);
                    this.xdgvActs.DataView.FillData(e.Argument as QualityUtilizationReportsSearchParameters);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    this.xdgvActs.BindData(false);

                    //this.xdgvActs.AllowFilter = true;
                    this.xdgvActs.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadworker.RunWorkerAsync(QualityUtilizationReportsSearchForm.SearchParameters);
            waitProgressForm.ShowDialog();
        }

        #region ПЕЧАТЬ АКТОВ

        private void sbPrintUsageProhibitionReport_Click(object sender, EventArgs e)
        {
            try
            {
                var docNumber = Convert.ToInt32(xdgvActs.SelectedItem["DocNumber"]);
                var docType = xdgvActs.SelectedItem["DocTypeCode"].ToString();

                var quality = new Data.Quality();

                using (var adapter = new Data.QualityTableAdapters.UsageProhibitionReportTableAdapter())
                    adapter.Fill(quality.UsageProhibitionReport, docNumber, docType);

                using (var report = new QualityItemsAvailabilityProhibitionActReport())
                {
                    report.SetDataSource(quality);

                    //report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
                    //report.PrintToPrinter(1, false, 1, 0);

                    var reportForm = new ReportForm();
                    reportForm.ReportDocument = report;
                    reportForm.Text = "Акт \"ЛС не подлежащие использованию\"";
                    reportForm.ShowDialog();

                    if (reportForm.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "UR", 28, Convert.ToInt64(docNumber), docType, (short?)null, reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                    }
                }
            }
            catch
            {

            }
        }

        private void sbPrintTransferToUtilizationReport_Click(object sender, EventArgs e)
        {
            try
            {
                var docNumber = Convert.ToInt32(xdgvActs.SelectedItem["DocNumber"]);
                var docType = xdgvActs.SelectedItem["DocTypeCode"].ToString();

                var quality = new Data.Quality();

                using (var adapter = new Data.QualityTableAdapters.TransferToUtilizationReportTableAdapter())
                    adapter.Fill(quality.TransferToUtilizationReport, docNumber, docType);

                using (var report = new QualityItemsAvailabilityProhibitionFormReport())
                {
                    report.SetDataSource(quality);
                    //report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
                    //report.PrintToPrinter(1, false, 1, 0);

                    var reportForm = new ReportForm();
                    reportForm.ReportDocument = report;
                    reportForm.Text = "Акт \"ЛС переданные на утилизацию\"";
                    reportForm.ShowDialog();

                    if (reportForm.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "UR", 28, Convert.ToInt64(docNumber), docType, (short?)null, reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                    }
                }
            }
            catch
            {

            }
        }

        private void sbPrintUtilizationVolumeMethodsReport_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void QualityUtilizationReportsManagerWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.xdgvActs.SaveExtraDataGridViewSettings(this.Name);
        }

        private void sbConsExportUsageProhibitionActs_Click(object sender, EventArgs e)
        {
            try
            {
                var pFileNamePart = "Акт(и) про наявність лікарських засобів, що не підлягають подальшому використанню.XLSX";
                var now = DateTime.Now;

                var sfg = new SaveFileDialog()
                {
                    FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                       now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                       now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), pFileNamePart),
                    Title = "Акт(и) про наявність лікарських засобів, що не підлягають подальшому використанню",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Excel-файл (*.xlsx)|*.xlsx",
                    FilterIndex = 0,
                    AddExtension = true,
                    DefaultExt = "xlsx"
                };

                if (sfg.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = sfg.FileName;


                var xActs = this.CreateActsXML();

                var quality = new Data.Quality();

                using (var adapter = new Data.QualityTableAdapters.UsageProhibitionReportTableAdapter())
                    adapter.FillCons(quality.UsageProhibitionReport, xActs.InnerXml);


                MemoryStream stream = new MemoryStream(Properties.Resources.UsageProhibitionReportTemp);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                var sheet = templateWorkbook.GetSheet("Лист1");

                ICell cell = null;

                int rowNum = 3; // первая строка данных реестра

                foreach (Data.Quality.UsageProhibitionReportRow item in quality.UsageProhibitionReport)
                {
                    try
                    {
                        IRow row = sheet.CreateRow(rowNum);

                        row.CreateCell(0).SetCellValue(item.ТДС);
                        row.CreateCell(1).SetCellValue(item.Код_ЄДРПОУ);
                        row.CreateCell(2).SetCellValue(item._Найменування_суб_єкта);
                        row.CreateCell(3).SetCellValue(item.Номер_реєстраційного_посвідчення_лікарського_засобу);
                        row.CreateCell(4).SetCellValue(item.Назва_лікарського_засобу);
                        row.CreateCell(5).SetCellValue(item.Форма_випуску);
                        row.CreateCell(6).SetCellValue(item.Дозування);
                        row.CreateCell(7).SetCellValue(item.Найменування_виробника);
                        row.CreateCell(8).SetCellValue(item.Країна_виробника);
                        row.CreateCell(9).SetCellValue(item.Номер_серії_лікарського_засобу);
                        row.CreateCell(10).SetCellValue(item.Наявна_кількість);
                        row.CreateCell(11).SetCellValue(item.Причина);
                        row.CreateCell(12).SetCellValue(item.Номер_акту);
                        row.CreateCell(13).SetCellValue(item.Дата_акту.ToShortDateString());

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                //for (int i = 0; i <= 13; i++)
                //    sheet.AutoSizeColumn(i);

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                System.Diagnostics.Process.Start(filePath);
            }
            catch
            {
                
            }
        }

        private void sbConsExportTransferToUtilizationActs_Click(object sender, EventArgs e)
        {
            try
            {
                var pFileNamePart = "Форма надання інформації про лікарські засоби, що не підлягають подальшому використанню, передані для знешкодження.XLSX";
                var now = DateTime.Now;

                var sfg = new SaveFileDialog()
                {
                    FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                       now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                       now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), pFileNamePart),
                    Title = "Форма надання інформації про лікарські засоби, що не підлягають подальшому використанню, передані для знешкодження",
                    InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    Filter = "Excel-файл (*.xlsx)|*.xlsx",
                    FilterIndex = 0,
                    AddExtension = true,
                    DefaultExt = "xlsx"
                };

                if (sfg.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = sfg.FileName;


                var xActs = this.CreateActsXML();

                var quality = new Data.Quality();

                using (var adapter = new Data.QualityTableAdapters.TransferToUtilizationReportTableAdapter())
                    adapter.FillCons(quality.TransferToUtilizationReport, xActs.InnerXml);


                MemoryStream stream = new MemoryStream(Properties.Resources.TransferToUtilizationReportTemp);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                var sheet = templateWorkbook.GetSheet("Лист1");

                ICell cell = null;

                int rowNum = 3; // первая строка данных реестра

                foreach (Data.Quality.TransferToUtilizationReportRow item in quality.TransferToUtilizationReport)
                {
                    try
                    {
                        IRow row = sheet.CreateRow(rowNum);

                        row.CreateCell(0).SetCellValue(item.ТДС);
                        row.CreateCell(1).SetCellValue(item._ЄДРПОУ_суб_єкта);
                        row.CreateCell(2).SetCellValue(item._Найменування_суб_єкта);
                        row.CreateCell(3).SetCellValue(item.Номер_реєстраційного_посвідчення_лікарського_засобу);
                        row.CreateCell(4).SetCellValue(item.Назва_лікарського_засобу);
                        row.CreateCell(5).SetCellValue(item.Форма_випуску);
                        row.CreateCell(6).SetCellValue(item.Дозування);
                        row.CreateCell(7).SetCellValue(item.Найменування_виробника);
                        row.CreateCell(8).SetCellValue(item.Країна_виробника);
                        row.CreateCell(9).SetCellValue(item.Номер_серії_лікарського_засобу);
                        row.CreateCell(10).SetCellValue(item._Передана_кількість__уп__);
                        row.CreateCell(11).SetCellValue(item._Загальний_обсяг__кг_);
                        row.CreateCell(12).SetCellValue(item.Код_за_ЄДРПОУ);
                        row.CreateCell(13).SetCellValue(item._Найменування_суб_єкта_господарювання);
                        row.CreateCell(14).SetCellValue(item.___ліцензії);
                        row.CreateCell(15).SetCellValue(item.___акта);
                        row.CreateCell(16).SetCellValue(item.Дата_акта.ToShortDateString());

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                //for (int i = 0; i <= 16; i++)
                //    sheet.AutoSizeColumn(i);

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                System.Diagnostics.Process.Start(filePath);
            }
            catch
            {

            }
        }

        private XmlDocument CreateActsXML()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Acts></Acts>");
            XmlElement xRoot = xDoc.DocumentElement;

            XmlAttribute xValue = null;

            foreach (DataGridViewRow row in xdgvActs.DataGrid.Rows)
            {
                var act = (row.DataBoundItem as DataRowView).Row as Data.Quality.UtilizationReportsRow;
                var xHeaderElement = xDoc.CreateElement("Act");

                xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("ACT_ID"));
                xValue.Value = act.DocNumber.ToString();

                xValue = xHeaderElement.Attributes.Append(xDoc.CreateAttribute("Doc_Type_Code"));
                xValue.Value = act.DocTypeCode.ToString();

                xRoot.AppendChild(xHeaderElement);
            }

            return xDoc;
        }
    }

    public class QualityUtilizationReportsView : IDataView
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as QualityUtilizationReportsSearchParameters;

            using (var adapter = new Data.QualityTableAdapters.UtilizationReportsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                this.data = adapter.GetData(
                    searchCriteria.UserID,
                    string.IsNullOrEmpty(searchCriteria.DocNumber) ? (int?)null : Convert.ToInt32(searchCriteria.DocNumber),
                    searchCriteria.PeriodFrom,
                    searchCriteria.PeriodTo,
                    string.IsNullOrEmpty(searchCriteria.ItemID) ? (int?)null : Convert.ToInt32(searchCriteria.ItemID),
                    searchCriteria.VendorLot,
                    searchCriteria.BatchNumber,
                    string.IsNullOrEmpty(searchCriteria.Supplier) ? (int?)null : Convert.ToInt32(searchCriteria.Supplier));
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public QualityUtilizationReportsView()
        {
            this.dataColumns.Add(new PatternColumn("№ заявки", "DocNumber", new FilterCompareExpressionRule<int>("DocNumber" ), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата заявки", "DocDate", new FilterDateCompareExpressionRule("DocDate"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип заявки", "DocTypeName", new FilterPatternExpressionRule("DocTypeName")) { Width = 100 });
        }

        #endregion
    }

    public class QualityUtilizationReportsSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }

        public string DocNumber { get; set; }
        public DateTime? PeriodFrom { get; set; }
        public DateTime? PeriodTo { get; set; }

        public string ItemID { get; set; }
        public string VendorLot { get; set; }
        public string BatchNumber { get; set; }
        public string Supplier { get; set; }

        public bool? AllowUsageProhibitionReports { get; set; }
        public bool? AllowTransferToUtilizationReports { get; set; }
        public bool? AllowUtilizationVolumeMethodsReports { get; set; }

        public bool? SearchLastActiveReports { get; set; }
    }
}
