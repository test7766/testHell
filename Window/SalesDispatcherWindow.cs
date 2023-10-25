using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using WMSOffice.Dialogs.WH.SD;
using WMSOffice.Controls;
using WMSOffice.Reports;
using WMSOffice.Dialogs;
using System.Diagnostics;
using System.Threading;
using WMSOffice.Data;
using WMSOffice.Data.WHTableAdapters;

using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Text.RegularExpressions;
using System.Xml;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class SalesDispatcherWindow : GeneralWindow
    {
        #region КОНСТАНТЫ
        /// <summary>
        /// Признак для возможности печати контрольного листа
        /// </summary>
        const short CONTROL_LIST_FLAG = 1;

        /// <summary>
        /// Признак для возможности печати контрольного листа ВР
        /// </summary>
        const short CONTROL_LIST_BP_FLAG = 3;

        /// <summary>
        /// Режим основной
        /// </summary>
        const int GENERAL_MODE = 1;

        /// <summary>
        /// Режим приходования межскладов
        /// </summary>
        const int BRING_ON_CHARGE_MODE = 2;

        /// <summary>
        /// Режим журнализации
        /// </summary>
        const int CREATE_SALES_LOGGING_MODE = 3;

        /// <summary>
        /// Регулярное выражение для расчета итогового значения в поле "Кросс-Док"
        /// </summary>
        private readonly Regex rgxCalcCrossDocSummary = new Regex(@"^Фил\.\((\d+)\)\|ПАК\.\:(?<values>.*)\|МЛ\:(.*)$", RegexOptions.IgnoreCase);

        #endregion

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Источник данных для создания отчета перед экспортом его в PDF-формат
        /// </summary>
        List<WMSOffice.Data.ProxyBusinessObjects> reportSource = null;

        /// <summary>
        /// Режим работы 
        /// </summary>
        public int WorkMode { get; private set; }

        /// <summary>
        /// Описание режима работы
        /// </summary>
        public string WorkModeDescription { get; private set; }

        /// <summary>
        /// Режим выгрузки данных
        /// </summary>
        public int LoadDataMode { get; private set; }

        /// <summary>
        /// Количество потоков выгрузки данных
        /// </summary>
        public int WorkersCount { get; private set; }


        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public SalesDispatcherWindow()
        {
            InitializeComponent();
            this.pnlWorkArea.Visible = false;
            LoadDpDocTypes();
        }

        /// <summary>
        /// Инициализация выпадающего списка с категориями документов
        /// </summary>
        private void LoadDpDocTypes()
        {
            try
            {
                using (var adapter = new DpDocTypesTableAdapter())
                {
                    var table = adapter.GetData();
                    foreach (WH.DpDocTypesRow row in table)
                        chbCategories.Items.Add(new CCBoxItem(row.Decs, row.ID));

                    for (int i = 0; i < chbCategories.Items.Count; i++)
                        chbCategories.SetItemChecked(i, true);
                }

            }
            catch (Exception exc)
            {
                ShowError(exc);
                chbCategories.Items.Clear();
            }
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
                this.ShowError(ex);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!this.ContinueWorkInSelectedMode())
            {
                this.Close();
                return;
            }

            if (!this.GetLoadDataMode())
            {
                this.Close();
                return;
            }

            this.pnlWorkArea.Visible = true;
            this.InitializeWorkArea();
        }

        /// <summary>
        /// Возвращает признак продолжения работать с интерфейсом в установленном режиме
        /// </summary>
        /// <returns></returns>
        private bool ContinueWorkInSelectedMode()
        {
            var workModeSelector = new SelectSalesDispatcherWorkModeForm() { UserID = this.UserID };
            if (workModeSelector.ShowDialog() == DialogResult.OK)
            {
                this.WorkMode = workModeSelector.SelectedWorkMode;
                this.WorkModeDescription = workModeSelector.SelectedWorkModeDescription;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Получение режима выгрузки данных
        /// </summary>
        /// <returns></returns>
        private bool GetLoadDataMode()
        {
            try
            {
                var loadDataMode = (int?)null;
                var workersCount = (int?)null;

                using (var adapter = new Data.WHTableAdapters.QueriesTableAdapter())
                    adapter.SalesDispatcherGetLoadDataMode(this.UserID, ref loadDataMode, ref workersCount);

                this.LoadDataMode = loadDataMode ?? 1;
                this.WorkersCount = workersCount ?? 1;

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        /// <summary>
        /// Инициализация рабочей области
        /// </summary>
        private void InitializeWorkArea()
        {
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WorkModeDescription.Trim());

            // ------------------------------------------------------------------------------------------------------------
            // Инициализация фильтруемого грида и установка процедур для вызова справочников из компонент критериев поиска
            // ------------------------------------------------------------------------------------------------------------
            this.xdgvResult.UseMultiSelectMode = true;

            //this.xdgvResult.AllowFilter = false;
            this.xdgvResult.AllowSummary = false;
            this.xdgvResult.AllowRangeColumns = true;

            this.xdgvResult.Init(new SalesDispatcherView(), true);
            this.xdgvResult.LoadExtraDataGridViewSettings(this.Name);

            stbStateFrom.ValueReferenceQuery = "[dbo].[pr_DP_Get_Status_List]";
            stbStateTo.ValueReferenceQuery = "[dbo].[pr_DP_Get_Status_List]";
            stbWarehouseFrom.ValueReferenceQuery = "[dbo].[pr_DP_Get_MCU_List]";
            stbWarehouseTo.ValueReferenceQuery = "[dbo].[pr_DP_Get_MCU_List]";
            stbItem.ValueReferenceQuery = "[dbo].[pr_DP_Get_Item_List]";
            stbSalesMan.ValueReferenceQuery = "[dbo].[pr_DP_Get_TP_List]";
            stbDocType.ValueReferenceQuery = "[dbo].[pr_DP_Get_DocTypes_List]";

            // -------------------------------------------------------------------------------------------------------
            // Передача компонентам критериев поиска кода сессии и подписка на события
            // -------------------------------------------------------------------------------------------------------

            this.xdgvResult.UserID = this.UserID;

            stbStateFrom.UserID = this.UserID;
            stbStateTo.UserID = this.UserID;
            stbWarehouseFrom.UserID = this.UserID;
            stbWarehouseTo.UserID = this.UserID;
            stbItem.UserID = this.UserID;
            stbSalesMan.UserID = this.UserID;
            stbDocType.UserID = this.UserID;

            // Установка дополнительного параметра - режим работы
            stbStateFrom.ApplyAdditionalParameter(this.WorkMode);
            stbStateTo.ApplyAdditionalParameter(this.WorkMode);
            stbWarehouseFrom.ApplyAdditionalParameter(this.WorkMode);
            stbWarehouseTo.ApplyAdditionalParameter(this.WorkMode);
            stbItem.ApplyAdditionalParameter(this.WorkMode);
            stbSalesMan.ApplyAdditionalParameter(this.WorkMode);
            stbDocType.ApplyAdditionalParameter(this.WorkMode);
            //

            // Установка доступности опциональных кнопок согласно режиму работы
            sbBringOnCharge.Visible = false;
            sbCreateSalesLogging.Visible = false;
            sbApprove.Visible = false;

            switch (this.WorkMode)
            {
                case GENERAL_MODE:
                    sbApprove.Visible = true;
                    break;
                case BRING_ON_CHARGE_MODE:
                    sbBringOnCharge.Visible = true;
                    break;
                case CREATE_SALES_LOGGING_MODE:
                    sbCreateSalesLogging.Visible = true;
                    break;
                default:
                    break;
            }
            //

            stbStateFrom.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbStateTo.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbWarehouseFrom.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbWarehouseTo.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbItem.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbSalesMan.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);
            stbDocType.OnVerifyValue += new VerifyValueHandler(searchCriteria_OnVerifyValue);

            // TODO Раскомментировать если появится необходимость печати на выбранный принтер
            //this.PreparePrintersList();

            // -------------------------------------------------------------------------------------------------------
            // Подписка фильтруемого грида на события, инициализация значениями компонент критериев поиска
            // -------------------------------------------------------------------------------------------------------

            stbStateFrom.Focus();
            xdgvResult.OnDataError += new DataGridViewDataErrorEventHandler(xdgvResult_OnDataError);
            xdgvResult.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvResult_OnRowDoubleClick);
            xdgvResult.OnRowSelectionChanged += new EventHandler(xdgvResult_OnRowSelectionChanged);
            xdgvResult.OnFilterChanged += new EventHandler(xdgvResult_OnFilterChanged);
            xdgvResult.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvResult_OnFormattingCell);
            xdgvResult.OnCustomSummaryCalculation += new EventHandler<СustomSummaryCalculationEventArgs>(xdgvResult_OnСustomSummaryCalculation);

            sbPrintInvoice.Enabled = false;
            sbPreviewInvoice.Enabled = false;
            sbExportInvoiceToPDF.Enabled = false;
            sbExportInvoiceToExcel.Enabled = false;
            sbExportCheckListToPDF.Enabled = false;
            sbExportCheckListBPToPDF.Enabled = false;
            sbReprintPSN.Enabled = false;
            sbExportOrdersToExcel.Enabled = false;
            sbBringOnCharge.Enabled = false;
            sbCreateSalesLogging.Enabled = false;
            sbApprove.Enabled = false;
            sbSetDeliveryInfo.Enabled = false;

            // Установка значений по умолчанию

            //stbStateFrom.SetValueByDefault("530");
            //stbStateTo.SetValueByDefault("590");

            // WMS-1686
            stbStateFrom.SetFirstValueByDefault();
            stbStateTo.SetLastValueByDefault();

            stbWarehouseFrom.SetFirstValueByDefault();
            stbWarehouseTo.SetLastValueByDefault();

            // активация постраничного просмотра
            xdgvResult.CreatePageNavigator();
        }

        void searchCriteria_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbStateFrom)
                lblDescription = lblStateFrom;
            else if (control == stbStateTo)
                lblDescription = lblStateTo;
            else if (control == stbWarehouseFrom)
                lblDescription = lblWarehouseFrom;
            else if (control == stbWarehouseTo)
                lblDescription = lblWarehouseTo;
            else if (control == stbItem)
                lblDescription = lblItem;
            else if (control == stbSalesMan)
                lblDescription = lblSalesMan;
            else if (control == stbDocType)
                lblDescription = lblDocType;

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


        void xdgvResult_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvResult.RecalculateSummary();
            this.ChangeExportToExcelOptionState();
        }

        /// <summary>
        /// Изменение статуса активность опции экспорта в Excel
        /// </summary>
        private void ChangeExportToExcelOptionState()
        {
            sbExportOrdersToExcel.Enabled = this.xdgvResult.HasRows;
        }

        void xdgvResult_OnRowSelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = xdgvResult.SelectedItem != null;

            bool canCreateInvoice = isEnabled && this.CanCreateInvoice();
            sbPrintInvoice.Enabled = canCreateInvoice;
            sbPreviewInvoice.Enabled = canCreateInvoice;
            sbExportInvoiceToPDF.Enabled = canCreateInvoice;
            sbExportInvoiceToExcel.Enabled = canCreateInvoice;

            sbExportCheckListToPDF.Enabled = isEnabled && Convert.ToInt16(xdgvResult.SelectedItem["CN"]) == CONTROL_LIST_FLAG;
            sbExportCheckListBPToPDF.Enabled = isEnabled && Convert.ToInt16(xdgvResult.SelectedItem["CN"]) == CONTROL_LIST_BP_FLAG;
            sbReprintPSN.Enabled = isEnabled && xdgvResult.SelectedItem["SDPSN"] != DBNull.Value;
            sbBringOnCharge.Enabled = isEnabled && Convert.ToBoolean(xdgvResult.SelectedItem["CanReceipt"]);
            sbCreateSalesLogging.Enabled = isEnabled && Convert.ToBoolean(xdgvResult.SelectedItem["CanSalesUpdate"]);
            sbApprove.Enabled = isEnabled && Convert.ToBoolean(xdgvResult.SelectedItem["CanApproveMC"]);

            sbSetDeliveryInfo.Enabled = isEnabled && Convert.ToBoolean(xdgvResult.SelectedItem["CanSetDeliverySettings"]);
        }

        void xdgvResult_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvResult.SelectedItem != null)
            {
                string docType = xdgvResult.SelectedItem["SDDCTO"].ToString();
                long docNumber = Convert.ToInt64(xdgvResult.SelectedItem["SDDOCO"]);
                long? pickSlip = xdgvResult.SelectedItem["SDPSN"] == DBNull.Value ? (long?)null : Convert.ToInt64(xdgvResult.SelectedItem["SDPSN"]);
                SalesDispatcherLinesForm form = new SalesDispatcherLinesForm(this.UserID, docType, docNumber, pickSlip);
                form.ShowDialog();
            }
        }

        void xdgvResult_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        /// <summary>
        /// Проверяет заказ по статусу на возможность формирования счета-фактуры
        /// </summary>
        /// <returns></returns>
        private bool CanCreateInvoice()
        {
            string paymentTerm = xdgvResult.SelectedItem["PaymentTerm"].ToString().Trim();

            // Устанавливаем минимальный порог по статусам: для предоплатных заказов ("*00") или по факту ("*01") - 530, иначе - 543 
            int minAllowedStatus = paymentTerm.EndsWith("00") || paymentTerm.EndsWith("01") ? 530 : 543;

            foreach (DataColumn column in xdgvResult.SelectedItem.Table.Columns)
            {
                int status;
                if (Int32.TryParse(column.Caption, out status)
                    && status >= minAllowedStatus
                    && this.xdgvResult.SelectedItem[column.Caption] != DBNull.Value)
                    return true;
            }

            return false;
        }
        #endregion

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

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #region ФОНОВОЕ ОБНОВЛЕНИЕ ДАННЫХ
        private void RefreshData()
        {
            try
            {
                this.xdgvResult.Focus();

                BackgroundWorker loadWorker = new BackgroundWorker();
                loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
                loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);

                var searchCriteria = new SalesDispatherSearchParameters();
                searchCriteria.UserID = this.UserID;

                searchCriteria.LoadDataMode = this.LoadDataMode;
                searchCriteria.WorkersCount = this.WorkersCount;

                searchCriteria.StateFrom = this.stbStateFrom.Value; // "530";
                searchCriteria.StateTo = this.stbStateTo.Value; //"531";
                searchCriteria.WarehouseFrom = this.stbWarehouseFrom.Value; // "       00LA1";
                searchCriteria.WarehouseTo = this.stbWarehouseTo.Value; // "       01LA1";

                if (this.stbItem.Value == null)
                    searchCriteria.ItemID = null;
                else
                {
                    int parsedResult;
                    if (Int32.TryParse(this.stbItem.Value, out parsedResult))
                        searchCriteria.ItemID = parsedResult;
                    else
                        searchCriteria.ItemID = -1;
                }

                if (this.stbSalesMan.Value == null)
                    searchCriteria.SalesMan = null;
                else
                {
                    int parsedResult;
                    if (Int32.TryParse(this.stbSalesMan.Value, out parsedResult))
                        searchCriteria.SalesMan = parsedResult;
                    else
                        searchCriteria.SalesMan = -1;
                }

                searchCriteria.DocType = this.stbDocType.Value;
                searchCriteria.DocCategories = CheckedCategories;

                searchCriteria.OrderID = string.IsNullOrEmpty(tbOrderID.Text) ? (long?)null : Convert.ToInt64(tbOrderID.Text);
                searchCriteria.InvoiceID = string.IsNullOrEmpty(tbInvoiceID.Text) ? (long?)null : Convert.ToInt64(tbInvoiceID.Text);

                this.waitProgressForm.ActionText = "Выполняется загрузка данных..";
                loadWorker.RunWorkerAsync(searchCriteria);
                this.waitProgressForm.ShowDialog();

                // После выполнения поиска определим активность опции экспорта реестра в Excel
                this.ChangeExportToExcelOptionState();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Список через запятую идентификаторов отмеченных категорий документов
        /// </summary>
        private string CheckedCategories
        {
            get
            {
                string s = String.Empty;
                foreach (var item in chbCategories.CheckedItems)
                {
                    if (s.Length > 0)
                        s += ",";
                    s += (item as CCBoxItem).Value.ToString();
                }

                return String.IsNullOrEmpty(s) ? null : s;
            }
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.xdgvResult.DataView.FillData(e.Argument as SalesDispatherSearchParameters);
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

                //this.xdgvResult.AllowFilter = true;
                this.xdgvResult.AllowSummary = true;
            }

            this.waitProgressForm.CloseForce();
        }
        #endregion

        private void sbPrintInvoice_Click(object sender, EventArgs e)
        {
            this.PrintInvoice(false);
        }

        private void sbPreviewInvoice_Click(object sender, EventArgs e)
        {
            this.PrintInvoice(true);
        }

        private void sbExportInvoiceToPDF_Click(object sender, EventArgs e)
        {
            this.ExportInvoice(ExportFormatType.PortableDocFormat);
        }

        #region ФОНОВЫЙ ЭКСПОРТ СЧЕТА-ФАКТУРЫ
        private void ExportInvoice(ExportFormatType pExportType)
        {
            BackgroundWorker exportWorker = new BackgroundWorker();
            exportWorker.DoWork += new DoWorkEventHandler(exportWorker_DoWork);
            exportWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(exportWorker_RunWorkerCompleted);

            SalesDispatherLinesSearchParameters searchCriteria = new SalesDispatherLinesSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.DocType = xdgvResult.SelectedItem["SDDCTO"].ToString();
            searchCriteria.DocNumber = Convert.ToInt32(xdgvResult.SelectedItem["SDDOCO"]);

            waitProgressForm.ActionText = "Выполняется подготовка к экспорту в PDF счет-фактуры";
            reportSource = null;
            exportWorker.RunWorkerAsync(searchCriteria);
            waitProgressForm.ShowDialog();

            if (reportSource != null)
                foreach (var sourceItem in this.reportSource)
                {
                    ReportClass report = null;
                    if (pExportType == ExportFormatType.Excel)
                        report = new SalesDispatcherInvoiceReportExcel();
                    else
                        report = new SalesDispatcherInvoiceReport();

                    report.SetDataSource(sourceItem);

                    var header = sourceItem.SalesDispatcherInvoiceReportHeader.Rows[0] as Data.ProxyBusinessObjects.SalesDispatcherInvoiceReportHeaderRow;
                    //string signVAT = header.HasVAT ? "з ПДВ" : "без ПДВ";
                    string signVAT = header.VatRate == 0.0M ? "без ПДВ" : string.Format("з ПДВ ({0}%)", header.VatRate);
                    report.SetParameterValue("@SignVAT", signVAT);

                    //string valueVAT = header.HasVAT ? header.OrderSumVAT.ToString("f2").Replace(',', '.') : "без ПДВ";
                    string valueVAT = header.VatRate == 0.0M ? "без ПДВ" : header.OrderSumVAT.ToString("f2").Replace(',', '.');
                    report.SetParameterValue("@ValueVAT", valueVAT);

                    string valueVAT_F = header.VatRate == 0.0M ? "без ПДВ" : header.OrderSumVAT_F.ToString("f2").Replace(',', '.');
                    report.SetParameterValue("@ValueVAT_F", valueVAT_F);

                    using (SaveFileDialog dlgSaveToPDF = new SaveFileDialog()
                    {
                        Title = "Укажите файл для сохранения отчета",
                        Filter = pExportType == ExportFormatType.Excel ? "Excel-файлы (*.xls)|*.xls" : "PDF файлы (*.pdf)|*.pdf",
                        FileName = string.Format("IV-{0}-{1} ({2})", searchCriteria.DocType, searchCriteria.DocNumber, signVAT)
                    })
                        if (dlgSaveToPDF.ShowDialog() == DialogResult.OK)
                        {
                            report.ExportToDisk(pExportType, dlgSaveToPDF.FileName);
                            Thread.Sleep(500);
                            Process.Start(dlgSaveToPDF.FileName);
                        }
                }
        }

        void exportWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = e.Argument as SalesDispatherLinesSearchParameters;
                this.reportSource = this.PrepareInvoicePrintSource(parameters);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void exportWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);

            waitProgressForm.CloseForce();
        }

        /// <summary>
        /// Экспорт счета-фактуры в Excel
        /// </summary>
        private void sbExportInvoiceToExcel_Click(object sender, EventArgs e)
        {
            ExportInvoice(ExportFormatType.Excel);
        }

        #endregion

        private void sbExportCheckListToPDF_Click(object sender, EventArgs e)
        {
            this.ExportCheckList(false);
        }

        private void sbExportCheckListBPToPDF_Click(object sender, EventArgs e)
        {
            this.ExportCheckList(true);
        }

        private void ExportCheckList(bool useControlListBP)
        {
            SalesDispatherLinesSearchParameters searchCriteria = new SalesDispatherLinesSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.DocType = xdgvResult.SelectedItem["SDDCTO"].ToString();
            searchCriteria.DocNumber = Convert.ToInt32(xdgvResult.SelectedItem["SDDOCO"]);
            searchCriteria.UseControlListBP = useControlListBP;

            BackgroundWorker printCheckListWorker = new BackgroundWorker();
            printCheckListWorker.DoWork += new DoWorkEventHandler(printCheckListWorker_DoWork);
            printCheckListWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printCheckListWorker_RunWorkerCompleted);
            waitProgressForm.ActionText = "Выполняется подготовка к экспорту в PDF контрольного листа";
            reportSource = null;
            printCheckListWorker.RunWorkerAsync(searchCriteria);
            waitProgressForm.ShowDialog();

            if (reportSource != null)
                foreach (var sourceItem in this.reportSource)
                {
                    SalesDispatcherCheckListReport report = new SalesDispatcherCheckListReport();
                    report.SetDataSource(sourceItem); // TODO заменить

                    var header = sourceItem.SalesDispatcherCheckListReportHeader.Rows[0] as Data.ProxyBusinessObjects.SalesDispatcherCheckListReportHeaderRow;
                    //string signVAT = header.HasVAT ? "с НДС" : "без НДС";
                    string signVAT = header.VATRate == 0.0M ? "без НДС" : string.Format("с НДС ({0}%)", header.VATRate);
                    report.SetParameterValue("@SignVAT", signVAT);

                    //string valueVAT = header.HasVAT ? header.OrderSumVAT.ToString("f2").Replace(',', '.') : "без НДС";
                    string valueVAT = header.VATRate == 0.0M ? "без НДС" : header.OrderSumVAT.ToString("f2").Replace(',', '.');
                    report.SetParameterValue("@ValueVAT", valueVAT);

                    using (SaveFileDialog dlgSaveToPDF = new SaveFileDialog()
                    {
                        Title = "Укажите файл для сохранения отчета",
                        Filter = "PDF файлы (*.pdf)|*.pdf",
                        FileName = string.Format("{0}-{1}-{2} ({3})", useControlListBP ? "CLBP" : "CL", searchCriteria.DocType, searchCriteria.DocNumber, signVAT)
                    })
                        if (dlgSaveToPDF.ShowDialog() == DialogResult.OK)
                        {
                            report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, dlgSaveToPDF.FileName);
                            Thread.Sleep(500);
                            Process.Start(dlgSaveToPDF.FileName);
                        }
                }
        }

        void printCheckListWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = e.Argument as SalesDispatherLinesSearchParameters;
                this.reportSource = this.PrepareCheckListPrintSource(parameters);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void printCheckListWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);
            else
            { }

            this.waitProgressForm.CloseForce();
        }

        #region ФОНОВАЯ ПЕЧАТЬ СЧЕТА-ФАКТУРЫ
        /// <summary>
        /// Печать счета-фактуры
        /// </summary>
        /// <param name="preview">Признак только просмотра счет-фактуры</param>
        private void PrintInvoice(bool preview)
        {
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);

            SalesDispatherLinesSearchParameters searchCriteria = new SalesDispatherLinesSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.DocType = xdgvResult.SelectedItem["SDDCTO"].ToString();
            searchCriteria.DocNumber = Convert.ToInt32(xdgvResult.SelectedItem["SDDOCO"]);

            PrintWorkerParameters parameters = new PrintWorkerParameters();
            parameters.SearchCriteria = searchCriteria;
            parameters.PrinterName = cmbPrinters.SelectedItem.ToString();
            parameters.PreviewInvoice = preview;

            waitProgressForm.ActionText = preview ? "Выполняется подготовка к просмотру счет-фактуры" : "Выполняется печать счет-фактуры";
            printWorker.RunWorkerAsync(parameters);
            waitProgressForm.ShowDialog();
        }

        void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var parameters = e.Argument as PrintWorkerParameters;
                foreach (var sourceItem in this.PrepareInvoicePrintSource(parameters.SearchCriteria))
                {
                    SalesDispatcherInvoiceReport report = new SalesDispatcherInvoiceReport();
                    report.SetDataSource(sourceItem);

                    var header = sourceItem.SalesDispatcherInvoiceReportHeader.Rows[0] as Data.ProxyBusinessObjects.SalesDispatcherInvoiceReportHeaderRow;
                    //string signVAT = header.HasVAT ?  "з ПДВ" :  "без ПДВ";
                    string signVAT = header.VatRate == 0.0M ? "без ПДВ" : string.Format("з ПДВ ({0}%)", header.VatRate);
                    report.SetParameterValue("@SignVAT", signVAT);

                    //string valueVAT = header.HasVAT ? header.OrderSumVAT.ToString("f2").Replace(',', '.') : "без ПДВ";
                    string valueVAT = header.VatRate == 0.0M ? "без ПДВ" : header.OrderSumVAT.ToString("f2").Replace(',', '.');
                    report.SetParameterValue("@ValueVAT", valueVAT);

                    string valueVAT_F = header.VatRate == 0.0M ? "без ПДВ" : header.OrderSumVAT_F.ToString("f2").Replace(',', '.');
                    report.SetParameterValue("@ValueVAT_F", valueVAT_F);

                    // Печать счет-фактуры
                    if (!parameters.PreviewInvoice)
                    {
                        report.PrintOptions.PrinterName = parameters.PrinterName;
                        report.PrintToPrinter(1, false, 1, 0);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "DP", 23, parameters.SearchCriteria.DocNumber, parameters.SearchCriteria.DocType, Convert.ToInt16(sourceItem.SalesDispatcherInvoiceReportDetails.Count), report.PrintOptions.PrinterName, 1);
                    }
                    // Просмотр счет-фактуры 
                    else
                    {
                        using (ReportForm form = new ReportForm() { Text = "Счет-фактура" })
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "DP", 23, parameters.SearchCriteria.DocNumber, parameters.SearchCriteria.DocType, Convert.ToInt16(sourceItem.SalesDispatcherInvoiceReportDetails.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Подготовка источника данных для печатной формы счет-фактуры
        /// </summary>
        /// <param name="parameters"></param>
        private List<Data.ProxyBusinessObjects> PrepareInvoicePrintSource(SalesDispatherLinesSearchParameters searchCriteria)
        {
            int DEFAULT_RESPONSE_TIMEOUT = 300;
            string query = string.Format("EXEC [dbo].[pr_DP_GetOrderFactura] {0}, '{1}', '{2}'",
                searchCriteria.UserID,
                searchCriteria.DocType,
                searchCriteria.DocNumber);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            List<Data.ProxyBusinessObjects> resultSource = new List<WMSOffice.Data.ProxyBusinessObjects>();
            Data.ProxyBusinessObjects source = null;

            foreach (DataRow header in dataSet.Tables[0].Rows)
            {
                source = new WMSOffice.Data.ProxyBusinessObjects();

                #region АДАПТАЦИЯ ЗАГОЛОВКА СЧЕТА-ФАКТУРЫ
                var headerRow = source.SalesDispatcherInvoiceReportHeader.NewSalesDispatcherInvoiceReportHeaderRow();
                headerRow.OrderID = Convert.ToInt64(header["OrderID"]);
                headerRow.OrderDate = Convert.ToDateTime(header["OrderDate"]);
                headerRow.OrderType = header["OrderType"].ToString();
                headerRow.HasVAT = Convert.ToBoolean(header["HasVAT"]);
                headerRow.OptimaReq1 = header["OptimaRec1"].ToString();
                headerRow.OptimaReq2 = header["OptimaRec2"].ToString();
                headerRow.OptimaReq3 = header["OptimaRec3"].ToString();
                headerRow.PayerAddressID = Convert.ToInt32(header["PayerAddressID"]);
                headerRow.PayerName = header["PayerName"].ToString();
                headerRow.DebtorID = Convert.ToInt32(header["DebtorID"]);
                headerRow.DebtorName = header["DebtorName"].ToString();
                headerRow.DebtorDeliveryAddress = header["DebtorDeliveryAddress"].ToString();
                headerRow.ManagerName = header["ManagerName"].ToString();
                headerRow.OrderSum = Convert.ToDecimal(header["OrderSum"]);
                headerRow.OrderSumWithVAT = Convert.ToDecimal(header["OrderSumWithVAT"]);
                headerRow.OrderSumVAT = Convert.ToDecimal(header["OrderSumVAT"]);
                headerRow.TextSum = header["TextSum"].ToString();
                headerRow.VatRate = Convert.ToDecimal(header["VatRate"]);

                if (header["foreign_currency_code"] == DBNull.Value)
                    headerRow.Setforeign_currency_codeNull();
                else
                    headerRow.foreign_currency_code = header["foreign_currency_code"].ToString();

                if (header["OrderSumVAT_F"] == DBNull.Value)
                    headerRow.SetOrderSumVAT_FNull();
                else
                    headerRow.OrderSumVAT_F = Convert.ToDecimal(header["OrderSumVAT_F"]);


                #region ПОЛУЧЕНИЕ ИЗОБРАЖЕНИЯ Ш/К
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = false;
                barCodeCtrl.TopMargin = 20 * 5;
                barCodeCtrl.BarCode = header["OrderBarCodeString"].ToString();
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                headerRow.OrderBarCode = barCode;
                #endregion

                source.SalesDispatcherInvoiceReportHeader.AddSalesDispatcherInvoiceReportHeaderRow(headerRow);
                #endregion

                #region АДАПТАЦИЯ СТРОК СЧЕТА-ФАКТУРЫ
                //foreach (DataRow detail in dataSet.Tables[1].Select(String.Format("HasVAT = {0}", headerRow.HasVAT), "ItemName"))
                foreach (DataRow detail in dataSet.Tables[1].Select(String.Format("VatRate = {0}", headerRow.VatRate), "ItemName"))
                {
                    var detailRow = source.SalesDispatcherInvoiceReportDetails.NewSalesDispatcherInvoiceReportDetailsRow();
                    detailRow.ItemID = Convert.ToInt32(detail["ItemID"]);
                    detailRow.ItemName = detail["ItemName"].ToString();
                    detailRow.ManufacturerName = detail["ManufacturerName"].ToString();
                    detailRow.VendorLot = detail["VendorLot"].ToString();
                    detailRow.Quantity = Convert.ToDecimal(detail["Quantity"]);
                    detailRow.SellPrice = Convert.ToDecimal(detail["SellPrice"]);
                    detailRow.RowSum = Convert.ToDecimal(detail["RowSum"]);

                    if (detail["OrderSum_F"] == DBNull.Value)
                        detailRow.SetTotal_sum_FNull();
                    else
                        detailRow.Total_sum_F = Convert.ToDecimal(detail["OrderSum_F"]);

                    if (detail["OrderSumWithVAT_F"] == DBNull.Value)
                        detailRow.SetTotal_sum_With_VAT_FNull();
                    else
                        detailRow.Total_sum_With_VAT_F = Convert.ToDecimal(detail["OrderSumWithVAT_F"]);

                    if (detail["CurrRate"] == DBNull.Value)
                        detailRow.SetCurr_RateNull();
                    else
                        detailRow.Curr_Rate = Convert.ToDecimal(detail["CurrRate"]);

                    if (detail["SumTxt_F"] == DBNull.Value)
                        detailRow.SetF_SumTxtNull();
                    else
                        detailRow.F_SumTxt = detail["SumTxt_F"].ToString();

                    source.SalesDispatcherInvoiceReportDetails.AddSalesDispatcherInvoiceReportDetailsRow(detailRow);
                }
                #endregion

                resultSource.Add(source);
            }

            return resultSource;
        }

        /// <summary>
        /// Подготовка источника данных для печатной формы "Контрольный лист"
        /// </summary>
        /// <param name="searchCriteria"></param>
        private List<Data.ProxyBusinessObjects> PrepareCheckListPrintSource(SalesDispatherLinesSearchParameters searchCriteria)
        {
            int DEFAULT_RESPONSE_TIMEOUT = 300;
            string storedProcedure = searchCriteria.UseControlListBP ? "[dbo].[pr_DP_GetOrderControlList_VR]" : "[dbo].[pr_DP_GetOrderControlList]";
            string query = string.Format("EXEC {0} {1}, '{2}', '{3}'",
                storedProcedure,
                searchCriteria.UserID,
                searchCriteria.DocType,
                searchCriteria.DocNumber);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);

            List<Data.ProxyBusinessObjects> resultSource = new List<WMSOffice.Data.ProxyBusinessObjects>();
            Data.ProxyBusinessObjects source = null;

            foreach (DataRow header in dataSet.Tables[0].Rows)
            {
                source = new WMSOffice.Data.ProxyBusinessObjects();

                #region АДАПТАЦИЯ ЗАГОЛОВКА КОНТРОЛЬНОГО ЛИСТА
                var headerRow = source.SalesDispatcherCheckListReportHeader.NewSalesDispatcherCheckListReportHeaderRow();
                headerRow.OrderID = Convert.ToInt64(header["OrderID"]);
                headerRow.OrderDate = Convert.ToDateTime(header["OrderDate"]);
                headerRow.OrderType = header["OrderType"].ToString();
                headerRow.DeliveryDate = Convert.ToDateTime(header["DeliveryDate"]);
                headerRow.HasVAT = Convert.ToBoolean(header["HasVAT"]);
                headerRow.DeliveryNote = header["DeliveryNote"].ToString();
                headerRow.DeliveryAddress = header["DeliveryAddress"].ToString();
                headerRow.OrderSum = Convert.ToDecimal(header["OrderSum"]);
                headerRow.OrderSumWithVAT = Convert.ToDecimal(header["OrderSumWithVAT"]);
                headerRow.OrderSumVAT = Convert.ToDecimal(header["OrderSumVAT"]);
                headerRow.VATRate = Convert.ToDecimal(header["VATRate"]);

                source.SalesDispatcherCheckListReportHeader.AddSalesDispatcherCheckListReportHeaderRow(headerRow);
                #endregion

                #region АДАПТАЦИЯ СТРОК СЧЕТА-ФАКТУРЫ
                //foreach (DataRow detail in dataSet.Tables[1].Select(String.Format("HasVAT = {0}", headerRow.HasVAT), "RowNum"))
                foreach (DataRow detail in dataSet.Tables[1].Select(String.Format("VATRate = {0}", headerRow.VATRate), "RowNum"))
                {
                    var detailRow = source.SalesDispatcherCheckListReportDetails.NewSalesDispatcherCheckListReportDetailsRow();
                    detailRow.ItemID = Convert.ToInt32(detail["ItemID"]);
                    detailRow.ItemName = detail["ItemName"].ToString();
                    detailRow.VendorLot = detail["VendorLot"].ToString();
                    detailRow.Quantity = Convert.ToDecimal(detail["Quantity"]);
                    detailRow.SellPrice = Convert.ToDecimal(detail["SellPrice"]);
                    detailRow.RowSum = Convert.ToDecimal(detail["RowSum"]);
                    source.SalesDispatcherCheckListReportDetails.AddSalesDispatcherCheckListReportDetailsRow(detailRow);
                }
                #endregion
                resultSource.Add(source);
            }

            return resultSource;
        }

        void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);

            waitProgressForm.CloseForce();
        }
        #endregion

        /// <summary>
        /// Повторная печать сборочного
        /// </summary>
        private void sbReprintPSN_Click(object sender, EventArgs e)
        {
            long psn = Convert.ToInt64(xdgvResult.SelectedItem["SDPSN"]);
            string docType = xdgvResult.SelectedItem["SDDCTO"].ToString();
            long docNumber = Convert.ToInt64(xdgvResult.SelectedItem["SDDOCO"]);

            string query = string.Format("EXEC [dbo].[pr_DP_ReprintPSN] {0}, '{1}', {2}, {3}", this.UserID, docType, docNumber, psn);
            SqlCommand cmdUpdatePSN = new SqlCommand(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));

            try
            {
                cmdUpdatePSN.Connection.Open();
                cmdUpdatePSN.ExecuteNonQuery();
                MessageBox.Show("Сборочный был успешно добавлен в очередь печати.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmdUpdatePSN.Connection.Close();
            }
        }

        private void SalesDispatcherWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvResult.SaveExtraDataGridViewSettings(this.Name);
        }

        /// <summary>
        /// Экспорт реестра заказов в Excel по фильтру
        /// </summary>
        private void sbExportOrdersToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlgSelectFile = new SaveFileDialog())
            {
                dlgSelectFile.Title = "Экспорт реестра заказов";

                DateTime now = DateTime.Now;
                dlgSelectFile.FileName = string.Format("{0}{1}{2}{3}{4}{5}-реестр заказов",
                    now.Year.ToString(),
                    now.Month.ToString().PadLeft(2, '0'),
                    now.Day.ToString().PadLeft(2, '0'),
                    now.Hour.ToString().PadLeft(2, '0'),
                    now.Minute.ToString().PadLeft(2, '0'),
                    now.Second.ToString().PadLeft(2, '0')
                    );

                dlgSelectFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlgSelectFile.Filter = "Текстовый файл с разделителями (*.csv)|*.csv";//;*.csv|Все файлы (*.*)|*.*";
                dlgSelectFile.FilterIndex = 0;
                dlgSelectFile.AddExtension = true;
                dlgSelectFile.DefaultExt = "csv";
                if (dlgSelectFile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvResult.ExportToExcel(dlgSelectFile.FileName);
                        Process.Start(dlgSelectFile.FileName);
                    }
                    catch (Exception ex)
                    {
                        this.ShowError(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Приходовать межсклад
        /// </summary>
        private void sbBringOnCharge_Click(object sender, EventArgs e)
        {
            try
            {
                string company = xdgvResult.SelectedItem["SDKCOO"].ToString();
                string docType = xdgvResult.SelectedItem["SDDCTO"].ToString();
                long docNumber = Convert.ToInt64(xdgvResult.SelectedItem["SDDOCO"]);
                string deliveryPerson = xdgvResult.SelectedItem["DeliveryName"].ToString();

                var dialogBringOnCharge = new SalesDispatcherBringOnChargeForm(this.WorkMode, this.UserID, company, docType, docNumber, deliveryPerson);
                if (dialogBringOnCharge.ShowDialog() == DialogResult.OK)
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Выполнить журнализацию
        /// </summary>
        private void sbCreateSalesLogging_Click(object sender, EventArgs e)
        {
            string company = xdgvResult.SelectedItem["SDKCOO"].ToString();
            string docType = xdgvResult.SelectedItem["SDDCTO"].ToString();
            long docNumber = Convert.ToInt64(xdgvResult.SelectedItem["SDDOCO"]);

            string query = string.Format("EXEC dbo.pr_DP_SalesUpdateButton {0}, '{1}', '{2}', {3}", this.UserID, company, docType, docNumber);
            SqlCommand cmdCreateSalesLogging = new SqlCommand(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            bool success = false; // признак успешного выполнения операции

            try
            {
                cmdCreateSalesLogging.Connection.Open();
                cmdCreateSalesLogging.ExecuteNonQuery();

                // TODO При необходимости раскомментировать
                //MessageBox.Show("Журнализация документа была успешно создана.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmdCreateSalesLogging.Connection.Close();
            }

            if (success)
                this.RefreshData();
        }

        void xdgvResult_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            #region ИНДИКАЦИЯ ГРУППЫ "ПРИХОДОВАНИЕ"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "ReceipDoc" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "ReceipDocType" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "RecepButchNum")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                //e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 153); //Color.Black;
                return;
            }
            #endregion
        }

        void xdgvResult_OnСustomSummaryCalculation(object sender, СustomSummaryCalculationEventArgs e)
        {
            try
            {
                #region РАСЧЕТ ИТОГОВОГО ЗНАЧЕНИЯ ДЛЯ КРОСС-ДОКОВ
                if (e.PatternСolumn.DataFieldName == "CrossDoc")
                {
                    var dtValues = new DataTable();
                    dtValues.Columns.Add("value");

                    foreach (DataRow dataRow in e.FilteredTruncatedDataRows)
                    {
                        var fieldValue = dataRow[e.PatternСolumn.DataFieldName];
                        if (fieldValue != DBNull.Value)
                        {
                            var sValue = fieldValue.ToString();
                            if (rgxCalcCrossDocSummary.IsMatch(sValue))
                            {
                                var match = rgxCalcCrossDocSummary.Match(sValue);
                                var values = match.Groups["values"].Value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                                foreach (var value in values)
                                    dtValues.LoadDataRow(new object[] { value }, true);
                            }
                        }
                    }

                    e.TargetCell.Value = dtValues.DefaultView.ToTable(true).Rows.Count;
                }
                #endregion
            }
            catch (Exception ex)
            {

            }
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        /// <summary>
        /// Утвердить м/с
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbApprove_Click(object sender, EventArgs e)
        {
            bool success = false; // признак успешного выполнения операции

            try
            {
                // пакетная операция
                foreach (var item in xdgvResult.SelectedItems)
                {
                    SqlCommand cmdApprove = null;

                    try
                    {
                        string docType = item["SDDCTO"].ToString();
                        long docNumber = Convert.ToInt64(item["SDDOCO"]);

                        string query = string.Format("EXEC dbo.pr_DP_ApproveFilialMC '{0}', {1}, {2}", docType, docNumber, this.UserID);
                        cmdApprove = new SqlCommand(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));

                        cmdApprove.Connection.Open();
                        cmdApprove.ExecuteNonQuery();
                    }
                    finally
                    {
                        cmdApprove.Connection.Close();
                    }
                }

                success = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (success)
                this.RefreshData();
        }

        /// <summary>
        /// Детали доставки
        /// </summary>
        private void sbSetDeliveryInfo_Click(object sender, EventArgs e)
        {
            try
            {
                string company = xdgvResult.SelectedItem["SDKCOO"].ToString();
                string docType = xdgvResult.SelectedItem["SDDCTO"].ToString();
                long docNumber = Convert.ToInt64(xdgvResult.SelectedItem["SDDOCO"]);
                long psn = Convert.ToInt64(xdgvResult.SelectedItem["SDPSN"]);
                var routePointID = xdgvResult.SelectedItem["VR_RoutePointID"].Equals(DBNull.Value) ? (int?)null : Convert.ToInt32(xdgvResult.SelectedItem["VR_RoutePointID"]);

                var dialogSalesDispatcherSetDeliverySettings = new SalesDispatcherSetDeliveryInfoForm(this.UserID, company, docType, docNumber, psn, routePointID);
                if (dialogSalesDispatcherSetDeliverySettings.ShowDialog() == DialogResult.OK)
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    public class PrintWorkerParameters
    {
        /// <summary>
        /// Признак просмотра/печати счета-фактуры
        /// </summary>
        public Boolean PreviewInvoice { get; set; }

        /// <summary>
        /// Имя принтера
        /// </summary>
        public String PrinterName { get; set; }

        /// <summary>
        /// Критерий поиска
        /// </summary>
        public SalesDispatherLinesSearchParameters SearchCriteria { get; set; }
    }

    /// <summary>
    /// Представление для диспетчера продаж
    /// </summary>
    public class SalesDispatcherView : IDataView
    {
        private const int SEQUENTIAL_LOAD_DATA_MODE = 1;
        private const int PARALLEL_LOAD_DATA_MODE = 2;

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
            var searchCriteria = searchParameters as SalesDispatherSearchParameters;

            switch (searchCriteria.LoadDataMode)
            { 
                case SEQUENTIAL_LOAD_DATA_MODE:

                    bool dataFromArchive = searchCriteria.OrderID.HasValue || searchCriteria.InvoiceID.HasValue;
                    string query = string.Format("{0} {1}, '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11}",
                        dataFromArchive ? "EXEC [dbo].[pr_DP_GetOrderList_Archive]" : "EXEC [dbo].[pr_DP_GetOrderList]",
                        searchCriteria.UserID,
                        searchCriteria.StateFrom,
                        searchCriteria.StateTo,
                        searchCriteria.WarehouseFrom,
                        searchCriteria.WarehouseTo,
                        searchCriteria.ItemID.HasValue ? searchCriteria.ItemID.Value.ToString() : "NULL",
                        searchCriteria.SalesMan.HasValue ? searchCriteria.SalesMan.Value.ToString() : "NULL",
                        searchCriteria.DocType == null ? "NULL" : "'" + searchCriteria.DocType + "'",
                        searchCriteria.DocCategories == null ? "NULL" : "'" + searchCriteria.DocCategories + "'",
                        searchCriteria.OrderID.HasValue ? searchCriteria.OrderID.Value.ToString() : "NULL",
                        searchCriteria.InvoiceID.HasValue ? searchCriteria.InvoiceID.Value.ToString() : "NULL");

                    SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
                    adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                    //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    this.data = dataSet.Tables[0];
                    break;
                case PARALLEL_LOAD_DATA_MODE:

                    var dataKeys = new Data.WH.SalesDispatcherDataKeysDataTable();
                    using (var dataKeysAdapter = new Data.WHTableAdapters.SalesDispatcherDataKeysTableAdapter())
                    {
                        dataKeysAdapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                        dataKeys = dataKeysAdapter.GetData(
                            searchCriteria.UserID,
                            searchCriteria.StateFrom,
                            searchCriteria.StateTo,
                            searchCriteria.WarehouseFrom,
                            searchCriteria.WarehouseTo,
                            searchCriteria.ItemID,
                            searchCriteria.SalesMan,
                            searchCriteria.DocType,
                            searchCriteria.DocCategories,
                            searchCriteria.OrderID,
                            searchCriteria.InvoiceID);
                    }

                    var loadDataManager = new SalesDispatcherLoadDataManager(searchCriteria.WorkersCount, dataKeys, searchCriteria.UserID);
                    loadDataManager.Run();
                    loadDataManager.Wait();
                    this.data = loadDataManager.GetResult();
                    break;
                default:
                    throw new Exception("Неизвестный режим получения данных.");
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public SalesDispatcherView()
        {
            this.dataColumns.Add(new PatternColumn("Комп.", "SDKCOO", new FilterPatternExpressionRule("SDKCOO")) { Width = 45 });
            this.dataColumns.Add(new PatternColumn("Тип зак.", "SDDCTO", new FilterPatternExpressionRule("SDDCTO")) { Width = 40 });
            this.dataColumns.Add(new PatternColumn("Номер накладной", "Invoice", new FilterCompareExpressionRule<Int64>("Invoice"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Номер заказа", "SDDOCO", new FilterCompareExpressionRule<Int64>("SDDOCO"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Сборочный", "SDPSN", new FilterCompareExpressionRule<Int64>("SDPSN"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Зона сборки", "PickZone", new FilterPatternExpressionRule("PickZone")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Код деб-ра", "Debitor", new FilterCompareExpressionRule<Int32>("Debitor"), SummaryCalculationType.Count) { Width = 45 });
            this.dataColumns.Add(new PatternColumn("Дебитор", "DebitorName", new FilterPatternExpressionRule("DebitorName")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Код доставки", "Delivery", new FilterCompareExpressionRule<Int32>("Delivery"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Дебитор доставки", "DeliveryName", new FilterPatternExpressionRule("DeliveryName")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Город", "City", new FilterPatternExpressionRule("City")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Адрес доставки", "Address", new FilterPatternExpressionRule("Address")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Кросс-Док", "CrossDoc", new FilterPatternExpressionRule("CrossDoc"), SummaryCalculationType.Custom) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Опт. доставка", "IS_Opt", new FilterCompareExpressionRule<Int32>("IS_Opt"), SummaryCalculationType.Count) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Инструкция по доставке 1", "Instruction 1", new FilterPatternExpressionRule("Instruction 1")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Инструкция по доставке 2", "Instruction 2", new FilterPatternExpressionRule("Instruction 2")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Дата заказа", "Order Date", new FilterDateCompareExpressionRule("Order Date")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Дата доставки", "Delivery Date", new FilterDateCompareExpressionRule("Delivery Date")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Сумма заказа (без НДС)", "Amount", SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("НДС", "AmountVAT", SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Номер зоны", "Zone", new FilterPatternExpressionRule("Zone")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Код маршр.", "Route", new FilterPatternExpressionRule("Route"), SummaryCalculationType.Count) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("Услов. оплаты", "PaymentTerm", new FilterValueReferenceExpressionRule("PaymentTerm", "[dbo].[pr_DP_Get_Condition_List]")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("530", "530", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("531", "531", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("535", "535", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("536", "536", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("537", "537", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("540", "540", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("541", "541", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("542", "542", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("543", "543", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("548", "548", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("550", "550", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("551", "551", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("555", "555", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("558", "558", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("559", "559", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("560", "560", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("561", "561", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("562", "562", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("563", "563", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("565", "565", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("570", "570", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("571", "571", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("572", "572", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("575", "575", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("579", "579", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("580", "580", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("586", "586", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("590", "590", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("600", "600", SummaryCalculationType.Sum));
            this.dataColumns.Add(new PatternColumn("Код ТП", "SalesMan", new FilterCompareExpressionRule<Int32>("SalesMan")) { Width = 45 });
            this.dataColumns.Add(new PatternColumn("Код врача", "Doctor", new FilterCompareExpressionRule<Int32>("Doctor")) { Width = 45 }); 
            this.dataColumns.Add(new PatternColumn("Автор", "Author", new FilterPatternExpressionRule("Author")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("№ приход. док-та", "ReceipDoc", new FilterCompareExpressionRule<Int64>("ReceipDoc")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Тип приход. док-та", "ReceipDocType", new FilterPatternExpressionRule("ReceipDocType")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("№ пакета", "RecepButchNum", new FilterCompareExpressionRule<Int64>("RecepButchNum")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Сумма с НДС", "AmountWithVAT", SummaryCalculationType.Sum) { Width = 100, UseDecimalNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Дата перевода на 550", "ChangeDate", new FilterDateCompareExpressionRule("ChangeDate")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Кто перевел на 550", "ChangeUser", new FilterPatternExpressionRule("ChangeUser")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Время начала сборки", "SborkaStart", new FilterPatternExpressionRule("SborkaStart")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Время окончания сборки", "SborkaFinish", new FilterPatternExpressionRule("SborkaFinish")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Номер РК", "Calculation_Number", new FilterPatternExpressionRule("Calculation_Number")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Дата РК", "Calculation_Date", new FilterDateCompareExpressionRule("Calculation_Date")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse", new FilterPatternExpressionRule("Warehouse")) { Width = 95 });
            this.dataColumns.Add(new PatternColumn("Код контейнера", "Container_Code", new FilterPatternExpressionRule("Container_Code")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Тип контейнера", "Container_Type", new FilterPatternExpressionRule("Container_Type")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Тип сборочного", "PSNTP", new FilterPatternExpressionRule("PSNTP")) { Width = 130 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class SalesDispatherSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public string StateFrom { get; set; }
        public string StateTo { get; set; }
        public string WarehouseFrom { get; set; }
        public string WarehouseTo { get; set; }
        public int? ItemID { get; set; }
        public int? SalesMan { get; set; }
        public string DocType { get; set; }
        public string DocCategories { get; set; }
        public long? OrderID { get; set; }
        public long? InvoiceID { get; set; }

        public int LoadDataMode { get; set; }
        public int WorkersCount { get; set; }
    }

    /// <summary>
    /// Менеджер асинхронной загрузки данных
    /// </summary>
    public class SalesDispatcherLoadDataManager
    {
        private readonly Data.WH.SalesDispatcherDataKeysDataTable _dataKeys = null;

        private readonly List<SalesDispatherLoadDataWorker> _workers = new List<SalesDispatherLoadDataWorker>();

        public SalesDispatcherLoadDataManager(int workersCount, Data.WH.SalesDispatcherDataKeysDataTable dataKeys, long userID)
        {
            for (int i = 0; i < workersCount; i++)
                _workers.Add(new SalesDispatherLoadDataWorker(userID));

            _dataKeys = dataKeys;

            this.Initialize();
        }

        private void Initialize()
        {
            try
            {
                var dataKeyGroups = _dataKeys.DefaultView.ToTable(true, _dataKeys.StreamColumn.Caption);

                foreach (DataRow dataKeyGroup in dataKeyGroups.Rows)
                {
                    var streamID = Convert.ToInt32(dataKeyGroup[_dataKeys.StreamColumn.Caption]);
                    var workerID = streamID % _workers.Count;

                    _workers[workerID].DataKeys[streamID] = new List<WH.SalesDispatcherDataKeysRow>();
                    foreach (Data.WH.SalesDispatcherDataKeysRow dataKey in _dataKeys.Select(string.Format("{0} = {1}", _dataKeys.StreamColumn.Caption, streamID)))
                        _workers[workerID].DataKeys[streamID].Add(dataKey);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void Run()
        {
            try
            {
                var qWorkers = new Queue<SalesDispatherLoadDataWorker>(_workers);
                while (qWorkers.Count > 0)
                    qWorkers.Dequeue().Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Wait()
        {
            try
            {
                var qWorkers = new Queue<SalesDispatherLoadDataWorker>(_workers);
                while (qWorkers.Count > 0)
                    qWorkers.Dequeue().Wait();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Data.WH.SalesDispatcherDataByKeyDataTable GetResult()
        {
            try
            {
                var result = new Data.WH.SalesDispatcherDataByKeyDataTable();
                foreach (var worker in _workers)
                    result.Merge(worker.GetResult());

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    /// <summary>
    /// Асинхронный загрузчик данных
    /// </summary>
    public class SalesDispatherLoadDataWorker
    {
        private Thread thWorker = null;

        public long UserID { get; private set; }

        public Dictionary<int, List<Data.WH.SalesDispatcherDataKeysRow>> DataKeys { get; private set; }

        private readonly Dictionary<int, Data.WH.SalesDispatcherDataByKeyDataTable> _dataValues = null;

        public SalesDispatherLoadDataWorker(long userID)
        {
            this.UserID = userID;

            this.DataKeys = new Dictionary<int, List<WH.SalesDispatcherDataKeysRow>>();
            _dataValues = new Dictionary<int, WH.SalesDispatcherDataByKeyDataTable>();

            thWorker = new Thread(t => { this.Execute(); });
        }

        public void Start()
        {
            thWorker.Start();
        }

        public void Wait()
        {
            if (thWorker.ThreadState != System.Threading.ThreadState.Unstarted)
                thWorker.Join();
        }

        public Data.WH.SalesDispatcherDataByKeyDataTable GetResult()
        {
            try
            {
                var result = new Data.WH.SalesDispatcherDataByKeyDataTable();
                foreach (var kvp in _dataValues)
                {
                    var streamID = kvp.Key;
                    var dataValue = kvp.Value;

                    result.Merge(dataValue);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Execute()
        {
            try
            {
                foreach (var kvp in this.DataKeys)
                {
                    var streamID = kvp.Key;
                    var dataKeys = kvp.Value;

                    var parameterKey = this.CreateParameterKey(dataKeys);

                    using (var adapter = new Data.WHTableAdapters.SalesDispatcherDataByKeyTableAdapter())
                        _dataValues[streamID] = adapter.GetData(this.UserID, parameterKey.InnerXml);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private XmlDocument CreateParameterKey(List<Data.WH.SalesDispatcherDataKeysRow> keys)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<O></O>");
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (Data.WH.SalesDispatcherDataKeysRow key in keys)
            {
                var xElement = xDoc.CreateElement("K");

                var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("t"));
                xValue.Value = key.SDDCTO.ToString();

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("n"));
                xValue.Value = key.SDDOCO.ToString();

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("p"));
                xValue.Value = key.SDPSN.ToString();

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("d"));
                xValue.Value = key.SDSHAN.ToString();

                xRoot.AppendChild(xElement);
            }

            return xDoc;
        }
    }
}
