using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Reports;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно для печати документов списания
    /// </summary>
    public partial class PrintWriteOffActsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Название таблицы с документами списания в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Docs", Name); } }

        /// <summary>
        /// Документы, выделенные в таблице
        /// </summary>
        private List<Data.WH.WF_GetReportsRow> SelectedDocs
        {
            get
            {
                var list = new List<Data.WH.WF_GetReportsRow>();
                foreach (var dgRow in dgvPrintDocs.SelectedItems)
                    list.Add(dgRow as Data.WH.WF_GetReportsRow);
                return list;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public PrintWriteOffActsForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            InitializeWriteOffDocsGrid();
        }

        /// <summary>
        /// Загрузка документов при загрузке окна
        /// </summary>
        private void PrintWriteOffActsForm_Load(object sender, EventArgs e)
        {
            InitPrinters();
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
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке принтеров: ", exc);
            }
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с документами списания при создании окна
        /// </summary>
        private void InitializeWriteOffDocsGrid()
        {
            dgvPrintDocs.Init(new PrintWriteOffActsView(), true);
            dgvPrintDocs.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvPrintDocs.UserID = sessionID;
            dgvPrintDocs.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvPrintDocs.AllowRangeColumns = true;
            dgvPrintDocs.UseMultiSelectMode = true;
            dgvPrintDocs.RowHeadersVisible = false;

            dgvPrintDocs.OnFilterChanged += dgvPrintDocs_OnFilterChanged;
            dgvPrintDocs.OnRowSelectionChanged += dgvPrintDocs_OnRowSelectionChanged;
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void dgvPrintDocs_OnFilterChanged(object pSender, EventArgs pE)
        {
            dgvPrintDocs.RecalculateSummary();
        }

        /// <summary>
        /// Обновление статусов кнопок при изменении выделенного документа списания
        /// </summary>
        private void dgvPrintDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выбранного документа списания
        /// </summary>
        private void CustomButtons()
        {
        }

        /// <summary>
        /// Загрузка данных в таблицу документов списания
        /// </summary>
        private void RefreshDocs()
        {
            try
            {
                dgvPrintDocs.DataView.FillData(new PrintWriteOffActsSearchParameters() { SessionID = sessionID });
                dgvPrintDocs.BindData(false);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список документов списания!", exc);
            }
            finally
            {
                CustomButtons();
            }
        }

        /// <summary>
        /// Сохранение настроек грида при закрытии окна
        /// </summary>
        private void PrintWriteOffActsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvPrintDocs.SaveExtraDataGridViewSettings(ConfigDocsTableName);
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ ДОКУМЕНТОВ СПИСАНИЯ

        /// <summary>
        /// Предварительный просмотр документов списания
        /// </summary>
        private void btnPreview_Click(object sender, EventArgs e)
        {
            try
            {
                using (var report = sender == btnExtendedReport ? 
                    (ReportClass)(new WriteOffActExtendedReport()) : (ReportClass)(new WriteOffActReport()))
                using (var reportForm = new ReportForm() { ShowInTaskbar = false })
                {
                    var wh = GetDataForWriteOffDoc(SelectedDocs[0], sender == btnExtendedReport);
                    if (wh != null)
                    {
                        report.SetDataSource(wh);
                        reportForm.ReportDocument = report;
                        reportForm.ShowDialog(this);

                        if (reportForm.IsPrinted) 
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 8, Convert.ToInt64(SelectedDocs[0].Act_Number), SelectedDocs[0].JDE_Type_ID, Convert.ToInt16(wh.WF_GetReportDetail.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время просмотра документа списания возникла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Получение данных для заданного отчета
        /// </summary>
        /// <param name="pRow">Отчет, для которого нужно получить данные</param>
        /// <param name="pExtended">True если получение расширенного отчета, False если обычного</param>
        /// <returns>DataSet с данными для заданного отчета</returns>
        private Data.WH GetDataForWriteOffDoc(Data.WH.WF_GetReportsRow pRow, bool pExtended)
        {
            var wh = new Data.WH();
            using (var adapter = new WF_GetReportHeaderTableAdapter())
            {
                adapter.SetTimeout(600);
                adapter.Fill(wh.WF_GetReportHeader, sessionID, pRow.Week, pRow.Doc_ID, pRow.JDE_Type_ID, pRow.Date_ID,
                    pRow.IsAct_NumberNull() ? null : pRow.Act_Number, (int?)null);
            }
            if (wh.WF_GetReportHeader.Count == 0)
                throw new ApplicationException("Не удалось загрузить Header для акта списания!");
            using (var adapter = new WF_GetReportDetailTableAdapter())
            {
                adapter.SetTimeout(600);
                adapter.Fill(wh.WF_GetReportDetail, sessionID, pRow.Week, pRow.Doc_ID, pRow.JDE_Type_ID, pRow.Date_ID, 
                    pRow.IsAct_NumberNull() ? null : pRow.Act_Number, pExtended);
            }
            return wh;
        }

        /// <summary>
        /// Получение данных для служебной записки
        /// </summary>
        /// <param name="pRow">Макет, для которого нужно сформировать служебную записку</param>
        /// <returns>DataSet с данными</returns>
        private Data.WH GetDataForMemorandumReport(Data.WH.WF_GetReportsRow pRow)
        {
            var wh = new Data.WH();

            using (var adapter = new WF_STV_GetMemorandumTableAdapter())
            {
                adapter.SetTimeout(600);
                adapter.Fill(wh.WF_STV_GetMemorandum, pRow.Doc_ID);
            }

            if (wh.WF_STV_GetMemorandum.Count == 0)
                throw new ApplicationException("Не удалось получить данные для служебной записки!");

            return wh;
        }

        private Data.WH GetDataByActAccTrans(Data.WH.WF_GetReportsRow pRow)
        {
            var wh = new Data.WH();

            using (var adapter = new AAT_GetReportHeaderTableAdapter())
                adapter.Fill(wh.AAT_GetReportHeader, sessionID, pRow.Request_number);

            if (wh.AAT_GetReportHeader.Count == 0)
                throw new ApplicationException("Не удалось получить данные для акта приема-передачи!");


            using (var adapter = new WF_GetDestructionInformationTableAdapter())
                adapter.FillByDestRequest(wh.WF_GetDestructionInformation, sessionID, pRow.Request_number);

            if (wh.WF_GetDestructionInformation.Count == 0)
                throw new ApplicationException("Не удалось получить данные для акта приема-передачи!");

            return wh;
        }

        /// <summary>
        /// Печать выделенных в таблице документов списания
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;

            var parameters = new PrinterWorkerParameters() { PrinterName = (string)cmbPrinters.SelectedItem };
            parameters.DocsToPrint.AddRange(SelectedDocs);
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
                    var wh = GetDataForWriteOffDoc(doc, false);
                    using (var report = new WriteOffActReport())
                    {
                        report.PrintOptions.PrinterName = param.PrinterName;
                        report.SetDataSource(wh);
                        report.PrintToPrinter(1, true, 1, 0);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 8, Convert.ToInt64(doc.Act_Number), doc.JDE_Type_ID, Convert.ToInt16(wh.WF_GetReportDetail.Count), param.PrinterName, 1);
                    }

                    using (var report = new WriteOffActAdditionReport())
                    {
                        report.PrintOptions.PrinterName = param.PrinterName;
                        report.SetDataSource(wh);
                        report.PrintToPrinter(1, true, 1, 0);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 8, Convert.ToInt64(doc.Act_Number), doc.JDE_Type_ID, Convert.ToInt16(wh.WF_GetReportDetail.Count), param.PrinterName, 1);
                    }

                    // Анализ и печать служебной записки и акта приема-передачи
                    if (!doc.IsShip_to_VendorNull() && doc.Ship_to_Vendor == true)
                    {
                        wh = GetDataForMemorandumReport(doc);
                        using (var report = new WFMemorandumReport())
                        {
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.SetDataSource(wh);
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 20, Convert.ToInt64(doc.Doc_ID), (string)null, Convert.ToInt16(wh.WF_STV_GetMemorandum.Count), param.PrinterName, 1);
                        }

                        // Печать акта приема-передачи
                        wh = GetDataByActAccTrans(doc);
                        using (var report = new WHActAcceptanceTransmission())
                        {
                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.SetDataSource(wh);
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 19, Convert.ToInt64(doc.Request_number), (string)null, Convert.ToInt16(wh.WF_GetDestructionInformation.Count), param.PrinterName, 1);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Обработка окончания печати документов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при печати документов!", e.Result as Exception);
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати документов списания
        /// </summary>
        private class PrinterWorkerParameters
        {
            /// <summary>
            /// Документы, которые нужно распечатать
            /// </summary>
            public List<Data.WH.WF_GetReportsRow> DocsToPrint = new List<Data.WH.WF_GetReportsRow>();

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion

        private void btnPrintPackage_Click(object sender, EventArgs e)
        {
            new PrintWriteOffPackageForm() { UserID = sessionID }.ShowDialog();
        }
    }

    /// <summary>
    /// Представление для грида с документами списания
    /// </summary>
    public class PrintWriteOffActsView : IDataView
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
            var sc = pSearchParameters as PrintWriteOffActsSearchParameters;
            using (var adapter = new WF_GetReportsTableAdapter())
                data = adapter.GetData(sc.SessionID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public PrintWriteOffActsView()
        {
            this.dataColumns.Add(new PatternColumn("Отчет", "Doc_name", new FilterPatternExpressionRule("Doc_name"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Сумма, грн", "Sm", new FilterCompareExpressionRule<Double>("Sm")));
            this.dataColumns.Add(new PatternColumn("Дата отчета", "Date_ID", new FilterDateCompareExpressionRule("Date_ID")));
            this.dataColumns.Add(new PatternColumn("Тип документа", "JDE_Type", new FilterPatternExpressionRule("JDE_Type")));
            this.dataColumns.Add(new PatternColumn("Номер отчета", "Act_Number", new FilterPatternExpressionRule("Act_Number")));
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения документов списания
    /// </summary>
    public class PrintWriteOffActsSearchParameters : SearchParametersBase
    {
        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public long SessionID { get; set; }
    }
}
