using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainTemperatureReportWindow : GeneralWindow
    {
        private ColdChainTransportationRegimeReportManager manager = null;

        /// <summary>
        /// Текущяя этикетка
        /// </summary>
        private Data.ColdChain.TemperatureRegimeReportDataRow CurrentStickerRow { get { return (this.temperatureRegimeReportDataBindingSource.CurrencyManager.Current as DataRowView).Row as Data.ColdChain.TemperatureRegimeReportDataRow; } }

        /// <summary>
        /// Список выбранных этикеток
        /// </summary>
        private List<Data.ColdChain.TemperatureRegimeReportDataRow> SelectedStickerRows
        {
            get
            {
                List<Data.ColdChain.TemperatureRegimeReportDataRow> selectedRows = new List<WMSOffice.Data.ColdChain.TemperatureRegimeReportDataRow>();

                foreach (DataGridViewRow stickerRow in dgvMain.Rows)
                    if (stickerRow.Selected)
                        selectedRows.Add((stickerRow.DataBoundItem as DataRowView).Row as Data.ColdChain.TemperatureRegimeReportDataRow);

                return selectedRows;
            }
        }

        public ColdChainTemperatureReportWindow(ColdChainTransportationRegimeReportManager manager)
        {
            InitializeComponent();
            this.manager = manager;
            this.PreparePrintersList();
        }

        /// <summary>
        /// Обновление состояния интерфейса
        /// </summary>
        private void SetInterfaceSettings()
        {
            bool enableOperation = this.IsReportDataExists();
            sbPreview.Enabled = enableOperation;
            sbPrint.Enabled = enableOperation;
            sbExportToPDF.Enabled = enableOperation;
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.SetInterfaceSettings();
            this.SearchData();
        }

        private void ColdChainTemperatureReportWindow_Load(object sender, EventArgs e)
        {
            this.temperatureRegimeReportDataBindingSource.CurrentItemChanged += new EventHandler(temperatureRegimeReportDataBindingSource_CurrentItemChanged);
        }

        private void temperatureRegimeReportDataBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            this.temperatureRegimeReportDataDetailBindingSource.DataSource = null;

            if (this.IsReportDataExists())
            {
                manager.StickerCode = Convert.ToDouble(this.CurrentStickerRow.Etic);
                this.RefreshEticDetails();
            }

            this.SetInterfaceSettings();
        }

        /// <summary>
        /// Признак существования данных по пользовательскому запросу 
        /// </summary>
        /// <returns></returns>
        private bool IsReportDataExists()
        {
            return this.temperatureRegimeReportDataBindingSource.CurrencyManager.Count > 0;
        }

        /// <summary>
        /// Загрузка списка товаров по белой этикетке
        /// </summary>
        private void RefreshEticDetails()
        {
            try
            {
                this.temperatureRegimeReportDataDetailBindingSource.DataSource = this.temperatureRegimeReportDataDetailTableAdapter.GetData(manager.StickerCode.ToString());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка момента загрузки состава этикетки", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbSearch_Click(object sender, EventArgs e)
        {
            this.SearchData();
        }

        /// <summary>
        /// Поиск данных отчетов
        /// </summary>
        private void SearchData()
        {
            using (ColdSearchForm searchForm = new ColdSearchForm())
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                    this.RefreshData(searchForm.GetReportParameters());
            }
        }

        #region Фоновая загрузка данных
        /// <summary>
        /// Загрузка данных по параметрам поиска
        /// </summary>
        private void RefreshData(LoadWorkerSearchParameters parameters)
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            this.temperatureRegimeReportDataBindingSource.DataSource = null;
            manager.WaitProcessForm.ActionText = "Идет обработка запроса...";
            loadWorker.RunWorkerAsync(parameters);
            manager.WaitProcessForm.ShowDialog();
        }
     
        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                LoadWorkerSearchParameters p = e.Argument as LoadWorkerSearchParameters;
                e.Result = this.temperatureRegimeReportDataTableAdapter.
                    GetData(manager.UserID, p.DateFrom, p.DateTo, p.BranchID, p.ItemID, p.ItemName, 
                    p.DebitorID, p.DeliveryID, p.OrderID, p.OrderType, p.PickSlipNumber, p.WhiteStickerBarCode);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                this.coldChain.TemperatureRegimeReportData.Clear();
            }
            else
                this.temperatureRegimeReportDataBindingSource.DataSource = e.Result;

            manager.WaitProcessForm.CloseForce();
        }
        #endregion

        #region Методы связанные с построением отчета
        private void sbPreview_Click(object sender, EventArgs e)
        {
            this.PrepareReportThread(new PreviewReportWorkerParameters(), "Подготовка просмотра температурного отчета...");          
        }

        private void sbPrint_Click(object sender, EventArgs e)
        {
            this.PrepareReportThread(new PrintReportWorkerParameters() { PrinterName = this.cmbPrinters.SelectedItem.ToString() }, "Печать температурного отчета...");
        }

        private void sbExportToPDF_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSaveToPDF = new SaveFileDialog() { Title = "Укажите файл для сохранения отчета", Filter = "PDF файлы (*.pdf)|*.pdf" })
            {
                if (dlgSaveToPDF.ShowDialog() == DialogResult.OK)
                    this.PrepareReportThread(new PDFExportReportWorkerParameters() { FilePath = dlgSaveToPDF.FileName }, "Экспорт в PDF файл температурного отчета...");
            }
        }

        /// <summary>
        /// Фоновая подготовка данных для построения отчета и само построение
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="threadProcessActionText"></param>
        private void PrepareReportThread(ReportWorkerParameters parameters, string threadProcessActionText)
        {
            BackgroundWorker reportWorker = new BackgroundWorker();
            reportWorker.DoWork += new DoWorkEventHandler(reportWorker_DoWork);
            reportWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(reportWorker_RunWorkerCompleted);
            manager.WaitProcessForm.ActionText = threadProcessActionText;

            foreach (Data.ColdChain.TemperatureRegimeReportDataRow processingStickerRow in this.SelectedStickerRows)
                parameters.ProcessingStickerRows.Add(processingStickerRow);

            reportWorker.RunWorkerAsync(parameters);
            manager.WaitProcessForm.ShowDialog();
        }

        private void reportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                ReportWorkerParameters parameters = e.Argument as ReportWorkerParameters;
                parameters.ExportReport(this.PrepareReport(ref parameters));
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void reportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            manager.WaitProcessForm.CloseForce();
        }

        /// <summary>
        /// Подготовка температурного отчета
        /// </summary>
        private Reports.TemperatureRegimeReport PrepareReport(ref ReportWorkerParameters parameters)
        {
            this.coldChain.Clear(); // В начале процесса очистим источник данных

            foreach (Data.ColdChain.TemperatureRegimeReportDataRow reportRow in parameters.ProcessingStickerRows)
            { 
               this.coldChain.TemperatureRegimeReportData.LoadDataRow(reportRow.ItemArray, true);

                // Загрузка препаратов
               using (Data.ColdChainTableAdapters.TemperatureReportItemsTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.TemperatureReportItemsTableAdapter())
               {
                   adapter.ClearBeforeFill = false;
                   adapter.Fill(this.coldChain.TemperatureReportItems, manager.StickerCode);
               }

                // Загрузка стадий транспортировки 
               using (Data.ColdChainTableAdapters.TemperatureReportStagesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.TemperatureReportStagesTableAdapter())
               {
                   adapter.ClearBeforeFill = false;
                   adapter.Fill(this.coldChain.TemperatureReportStages, manager.StickerCode);
               }

                // Загрузка данных для построения графика
               using (Data.ColdChainTableAdapters.TemperatureReportGraphDataTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.TemperatureReportGraphDataTableAdapter())
               {
                   adapter.ClearBeforeFill = false;
                   adapter.Fill(this.coldChain.TemperatureReportGraphData, manager.StickerCode);
               }
            }

            // Формируем отчет
            Reports.TemperatureRegimeReport report = new WMSOffice.Reports.TemperatureRegimeReport();
            report.SetDataSource(this.coldChain);
            return report;
        }
        #endregion

        private void dgvMain_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.ColorActs();
        }

        /// <summary>
        /// Раскраска строк согласно признаку "вакцина", "не вакцина"
        /// </summary>
        private void ColorActs()
        {
            // Разрисовка строк в таблице
            foreach (DataGridViewRow row in dgvMain.Rows)
            {
                Data.ColdChain.TemperatureRegimeReportDataRow itemRow = (Data.ColdChain.TemperatureRegimeReportDataRow)((DataRowView)row.DataBoundItem).Row;

                // Простая разрисовка строки
                string colorName = itemRow.IsColorNull() ? "white" : itemRow.Color.ToLower();
                Color backColor = Color.FromName(colorName);

                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        /// <summary>
        /// Класс параметеров для поиска отчетов
        /// </summary>
        public class LoadWorkerSearchParameters
        {
            public DateTime? DateFrom { get; set; }
            public DateTime? DateTo { get; set; }
            public string BranchID { get; set; }
            public int? ItemID { get; set; }
            public string ItemName { get; set; }
            public int? DebitorID { get; set; }
            public int? DeliveryID { get; set; }
            public double? OrderID { get; set; }
            public string OrderType { get; set; }
            public double? PickSlipNumber { get; set; }
            public double? WhiteStickerBarCode { get; set; }

            public LoadWorkerSearchParameters()
            {
                this.DateFrom = null;
                this.DateTo = null;
                this.BranchID = null;
                this.ItemID = null;
                this.ItemName = null;
                this.DebitorID = null;
                this.DeliveryID = null;
                this.OrderID = null;
                this.OrderType = null;
                this.PickSlipNumber = null;
                this.WhiteStickerBarCode = null;
            }
        }

        #region Служебные классы для формирования отчета
        public abstract class ReportWorkerParameters
        {
            public List<Data.ColdChain.TemperatureRegimeReportDataRow> ProcessingStickerRows { get; private set; }
            public abstract void ExportReport(Reports.TemperatureRegimeReport report);

            public ReportWorkerParameters()
            {
              this.ProcessingStickerRows = new List<WMSOffice.Data.ColdChain.TemperatureRegimeReportDataRow>();
            }
        }

        /// <summary>
        /// Предварительный просмотр отчета
        /// </summary>
        public class PreviewReportWorkerParameters : ReportWorkerParameters
        {
            public override void ExportReport(Reports.TemperatureRegimeReport report)
            {
                using (WMSOffice.Dialogs.ReportForm reportForm = new WMSOffice.Dialogs.ReportForm())
                {
                    reportForm.ReportDocument = report;
                    reportForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Печать отчета
        /// </summary>
        public class PrintReportWorkerParameters : ReportWorkerParameters
        {
            public string PrinterName { get; set; }

            public override void ExportReport(Reports.TemperatureRegimeReport report)
            {
                report.PrintOptions.PrinterName = this.PrinterName;
                report.PrintToPrinter(1, true, 1, 0);
            }
        }

        /// <summary>
        /// Экспорт в PDF отчета
        /// </summary>
        public class PDFExportReportWorkerParameters : ReportWorkerParameters
        {
            public string FilePath { get; set; }

            public override void ExportReport(Reports.TemperatureRegimeReport report)
            {
                report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, this.FilePath);
            }
        }
        #endregion
    }
}
