using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data;
using WMSOffice.Data.QualityTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Quality;
using System.Transactions;
using System.IO;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Diagnostics;
using System.Collections.Generic;
using System.Drawing;

namespace WMSOffice.Window
{
    /// <summary>
    /// Окно входного контроля поставки
    /// </summary>
    public partial class QualityInputControlDeliveryWindow : GeneralWindow
    {
        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public QualityInputControlDeliveryWindow()
        {
            InitializeComponent();
            InitializeInputControlDeliveryGrid();
            spReportProvider = new QualityInputControlReportProvider(UserID);
            searchParams = new InputControlDeliverySheetsSearchParameters { SessionID = UserID };
        }

        /// <summary>
        /// Загрузка анкет при загрузке окна
        /// </summary>
        private void QualityInputControlDeliveryWindow_Load(object sender, EventArgs e)
        {
            CustomCheckBoxesPanel();
            PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            this.CheckDocApproveAccess();

            edgWorksheets.UseMultiSelectMode = canDocApprove;
            btnApproveWorksheet.Visible = canDocApprove;

            RefreshDocs();
        }

        #endregion

        #region ТАБЛИЦА АНКЕТ

        /// <summary>
        /// True если в данный момент загружаются анкеты, False в противном случае
        /// </summary>
        private bool isDocLoading;

        /// <summary>
        /// Идентификатор текущей выбранной анкеты в списке анкет. 
        /// Если в таблице анкет не выбрана ни одна анкета, будет выдано исключение
        /// </summary>
        private int CurrentDocId 
        { 
            get { return Convert.ToInt32(edgWorksheets.SelectedItem[InputControlDeliveryView.DOC_ID_PROPERTY_NAME]); } 
        }

        /// <summary>
        /// True если в таблице анкет выделена одна строка, False в противном случае
        /// </summary>
        private bool IsDocSelected { get { return edgWorksheets.SelectedItem != null; } }

        /// <summary>
        /// Анкета, выделенная в таблице либо null, если не выделена ни одна анкета
        /// </summary>
        public Quality.AP_DocsRow SelectedDoc { get { return edgWorksheets.SelectedItem as Quality.AP_DocsRow; } }

        /// <summary>
        /// Признак возможности подтверждения
        /// </summary>
        private bool canDocApprove;

        /// <summary>
        /// Признак возможности отмены
        /// </summary>
        private bool canDocUndo;

        /// <summary>
        /// Инициализация фильтруемого грида с анкетами
        /// </summary>
        private void InitializeInputControlDeliveryGrid()
        {
            edgWorksheets.Init(new InputControlDeliveryView(), true);
            edgWorksheets.LoadExtraDataGridViewSettings(Name);
            
            edgWorksheets.UserID = UserID;

            edgWorksheets.OnDataError += new DataGridViewDataErrorEventHandler(edgWorksheets_OnDataError);
            edgWorksheets.OnFilterChanged += new EventHandler(edgWorksheets_OnFilterChanged);
            edgWorksheets.OnFormattingCell += new DataGridViewCellFormattingEventHandler(edgWorksheets_OnFormattingCell);

            edgWorksheets.AllowRangeColumns = true;

            // активация постраничного просмотра
            edgWorksheets.CreatePageNavigator();
        }

        void edgWorksheets_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        //void edgWorksheets_OnFilterChanged(object sender, EventArgs e)
        //{
        //    edgWorksheets.RecalculateSummary();
        //}

        void edgWorksheets_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            var docsRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_DocsRow;

            #region ИНДИКАЦИЯ АНКЕТ

            var color = docsRow.IsindicatorNull() 
                ? Color.White 
                : docsRow.indicator == 0 
                    ? Color.White 
                    : docsRow.indicator == 1 
                        ? Color.LightPink 
                        : docsRow.indicator == 2 
                            ? Color.LightGreen 
                            : Color.White;

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;

            #endregion
        }

        /// <summary>
        /// Проверка доступа к действию "Подтвердить" и "Вернуть"
        /// </summary>
        private void CheckDocApproveAccess()
        {
            try
            {
                var accessFlag = (bool?)null;
                var accessUndoFlag = (bool?)null;
                using (var adapter = new Data.QualityTableAdapters.AP_DocsTableAdapter())
                    adapter.CheckDocApproveAccess(this.UserID, ref accessFlag, ref accessUndoFlag);

                canDocApprove = accessFlag ?? false;
                canDocUndo = accessUndoFlag ?? false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Обновление записей в таблице анкет по нажатию на кнопку "Обновить"
        /// </summary>
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Изменение выделенной в таблице анкеты - обновление доступности кнопок
        /// </summary>
        private void edgWorksheets_SelectionChanged(object sender, EventArgs e)
        {
            CustomDocsControls();
        }

        /// <summary>
        /// Настройка доступности котролов, относящихся к таблице анкет
        /// </summary>
        private void CustomDocsControls()
        {
            edgWorksheets.Enabled = !isDocLoading;
            pbSplashControl.Visible = isDocLoading;

            btnRefresh.Visible = miRefresh.Enabled = btnSearch.Visible = miSearch.Enabled = !isDocLoading;
            btnRefresh.Enabled = btnSearch.Enabled = btnRefresh.Visible;

            btnCancelLoading.Visible = miCancelLoading.Enabled = isDocLoading;
            btnCancelLoading.Enabled = btnCancelLoading.Visible;

            btnPreviewWorksheet.Visible = miPreviewWorksheet.Enabled = !isDocLoading && IsDocSelected;
            btnPreviewWorksheet.Enabled = btnPreviewWorksheet.Visible;

            btnPrintWorksheet.Visible = miPrintWorksheet.Enabled = !isDocLoading && IsDocSelected;
            btnPrintWorksheet.Enabled = btnPrintWorksheet.Visible;

            btnEditWorksheet.Visible = miEditWorksheet.Enabled = !isDocLoading && IsDocSelected;
            btnEditWorksheet.Enabled = btnEditWorksheet.Visible;

            tssAfterEdit.Visible = btnApproveWorksheet.Visible;
            
            btnApproveWorksheet.Visible = !isDocLoading && IsDocSelected && canDocApprove;
            btnApproveWorksheet.Enabled = btnApproveWorksheet.Visible;

            tssAfterApprove.Visible = btnEditWorksheet.Visible;

            btnUndoWorksheet.Visible = !isDocLoading && IsDocSelected && canDocUndo;
            btnUndoWorksheet.Enabled = btnUndoWorksheet.Visible;

            tssAfterUndo.Visible = btnUndoWorksheet.Visible;

            ssbExportToExcel.Visible = miExportToExcel.Enabled = !isDocLoading;
            ssbExportToExcel.Enabled = ssbExportToExcel.Visible;

            tssAfterPrint.Visible = ssbExportToExcel.Visible;

            btnPrintViolationAct.Visible = !isDocLoading && IsDocSelected;

            btnEditWorksheet.Text = (SelectedDoc != null && SelectedDoc.is_last_version &&
                (SelectedDoc.status_id == Constants.QK_IC_STATUS_NEW || SelectedDoc.status_id == Constants.QK_IC_STATUS_IN_WORK)) ?
                "Редактировать\nанкету (F2)" : "Просмотр\nанкеты (F2)";
        }

        /// <summary>
        /// Пересчет аггрегирующих значений, если изменилось значение фильтра
        /// </summary>
        private void edgWorksheets_OnFilterChanged(object pSender, EventArgs pE)
        {
            edgWorksheets.RecalculateSummary();
        }

        /// <summary>
        /// Запуск асинхронной загрузки анкет
        /// </summary>
        private void RefreshDocs()
        {
            var param = new SessionIDSearchParameters { SessionID = UserID };
            isDocLoading = true;
            CustomDocsControls();
            bgwLoader = new BackgroundWorker();
            bgwLoader.DoWork += bgwLoader_DoWork;
            bgwLoader.RunWorkerCompleted += bgwLoader_RunWorkerCompleted;
            bgwLoader.RunWorkerAsync(param);
        }

        /// <summary>
        /// Асинхронная загрузка анкет
        /// </summary>
        private void bgwLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using (var adapter = new AP_DocsTableAdapter())
                    e.Result = adapter.GetData(searchParams.SessionID, searchParams.OnlyActual, 
                        searchParams.DeliveryNumber, searchParams.OrderNumber, searchParams.VendorID,
                        searchParams.DateFrom.HasValue ? (DateTime?)searchParams.DateFrom.Value.Date : null,
                        searchParams.DateTo.HasValue ? (DateTime?)(searchParams.DateTo.Value.Date + TimeSpan.FromDays(1)) : null, 
                        searchParams.ProvisorID, searchParams.FilterByStatus, searchParams.IncludeOnlyApproved);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание загрузки анкет и их отображение в таблице
        /// </summary>
        private void bgwLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке анкет:", e.Result as Exception);
            else
                RefreshDataViewBinding(e.Result as Quality.AP_DocsDataTable);

            isDocLoading = false;
            CustomDocsControls();
        }

        /// <summary>
        /// Отображение загруженных анкет в фильтруемом гриде
        /// </summary>
        /// <param name="pData">Таблица с анкетами, которые нужно отобразить в гриде</param>
        private void RefreshDataViewBinding(Quality.AP_DocsDataTable pData)
        {
            try
            {
                long selDocID = -1, selVersionID = -1;
                int rowIndex = edgWorksheets.FirstDisplayedScrollingRowIndex;
                if (IsDocSelected)
                {
                    selDocID = CurrentDocId;
                    selVersionID = SelectedDoc.version_id;
                }

                (edgWorksheets.DataView as InputControlDeliveryView).FillData(pData);
                edgWorksheets.BindData(false);

                edgWorksheets.SelectRow(InputControlDeliveryView.DOC_ID_PROPERTY_NAME, selDocID.ToString(),
                    InputControlDeliveryView.VERSION_ID_PROPERTY_NAME, selVersionID.ToString());
                edgWorksheets.ScrollToRow(rowIndex);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка во время отображения анкет: ", exc);
            }
        }

        /// <summary>
        /// Отмена текущей асинхронной загрузки анкет
        /// </summary>
        private void CancelLoading_Click(object sender, EventArgs e)
        {
            isDocLoading = false;
            bgwLoader.RunWorkerCompleted -= bgwLoader_RunWorkerCompleted;
            bgwLoader = null;
            CustomDocsControls();
        }

        /// <summary>
        /// Сохранение настроек таблицы анкет при закрытии окна
        /// </summary>
        private void QualityInputControlDeliveryWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            edgWorksheets.SaveExtraDataGridViewSettings(Name);
        }

        /// <summary>
        /// Обновление таблицы анкет входного контроля поставки по нажатию на кнопку F5
        /// </summary>
        private void QualityInputControlDeliveryWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (isDocLoading)
                return;

            if (e.KeyCode == Keys.F5)
                RefreshDocs();
            else if (e.KeyCode == Keys.F && e.Control)
                SearchWorksheets();
            else if (e.KeyCode == Keys.F2 && edgWorksheets.SelectedItems.Count == 1)
                EditSelectedWorksheet();
        }

        #endregion

        #region ПОИСК АНКЕТ

        /// <summary>
        /// Параметры загрузки списка анкет
        /// </summary>
        private InputControlDeliverySheetsSearchParameters searchParams;

        /// <summary>
        /// Заполнение значений в чекбоксах под панелью инструментов текущими значениями фильтров
        /// </summary>
        private void CustomCheckBoxesPanel()
        {
            chbStatusNew.Checked = searchParams.IncludeNew;
            chbStatusInWork.Checked = searchParams.IncludeInWork;
            chbStatusAccepted.Checked = searchParams.IncludeAccepted;
            chbWithSuspectedQuality.Checked = searchParams.IncludeWithSuspectedQuality;
            chbStatusNotAccepted.Checked = searchParams.IncludeNotAccepted;
            chbOnlyApproved.Checked = searchParams.IncludeOnlyApproved;
        }

        /// <summary>
        /// Изменение фильтров по статусах анкет при переключении соответствующих флажков
        /// </summary>
        private void chbStatus_CheckedChanged(object sender, EventArgs e)
        {
            searchParams.IncludeNew = chbStatusNew.Checked;
            searchParams.IncludeInWork = chbStatusInWork.Checked;
            searchParams.IncludeAccepted = chbStatusAccepted.Checked;
            searchParams.IncludeWithSuspectedQuality = chbWithSuspectedQuality.Checked;
            searchParams.IncludeNotAccepted = chbStatusNotAccepted.Checked;
            searchParams.IncludeOnlyApproved = chbOnlyApproved.Checked;
        }

        /// <summary>
        /// Запуск поиска анкет
        /// </summary>
        private void Search_Click(object sender, EventArgs e)
        {
            SearchWorksheets();
        }

        /// <summary>
        /// Запуск окна поиска анкет входного контроля поставки
        /// </summary>
        private void SearchWorksheets()
        {
            var searchForm = new InputControlDeliveryWorksheetSearchForm(searchParams);
            if (searchForm.ShowDialog(this) == DialogResult.OK)
            {
                searchParams.OnlyActual = searchForm.FilterOnlyActive;
                searchParams.DeliveryNumber = searchForm.FilterDeliveryNumber;
                searchParams.OrderNumber = searchForm.FilterOrderNumber;
                searchParams.VendorID = searchForm.FilterVendorID;
                searchParams.VendorName = searchForm.VendorName;
                searchParams.DateFrom = searchForm.FilterDateFrom;
                searchParams.DateTo = searchForm.FilterDateTo;
                searchParams.ProvisorID = searchForm.FilterProvisorID;
                searchParams.IncludeNew = searchForm.FilterIncludeNew;
                searchParams.IncludeInWork = searchForm.FilterIncludeInWork;
                searchParams.IncludeAccepted = searchForm.FilterIncludeAccepted;
                searchParams.IncludeWithSuspectedQuality = searchForm.FilterIncludeWithSuspectedQuality;
                searchParams.IncludeNotAccepted = searchForm.FilterIncludeNotAccepted;
                searchParams.IncludeOnlyApproved = searchForm.FilterIncludeOnlyApproved;
                CustomCheckBoxesPanel();
                RefreshDocs();
            }
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ АНКЕТЫ

        /// <summary>
        /// Редактирование анкеты, выбранной в таблице
        /// </summary>
        private void EditWorksheet_Click(object sender, EventArgs e)
        {
            EditSelectedWorksheet();
        }

        /// <summary>
        /// Запуск окна редактирования по двойному клику на анкету
        /// </summary>
        private void edgWorksheets_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (btnEditWorksheet.Visible)
                EditSelectedWorksheet();
        }

        /// <summary>
        /// Редактирование анкеты, выбранной в таблице анкет
        /// </summary>
        private void EditSelectedWorksheet()
        {
            var isEditable = SelectedDoc.is_last_version && (SelectedDoc.status_id == Constants.QK_IC_STATUS_NEW || SelectedDoc.status_id == Constants.QK_IC_STATUS_IN_WORK);
            var isReadOnly = !isEditable;
            var editForm = new EditInputControlDeliveryWorksheetForm(UserID, SelectedDoc, isReadOnly);

            if (editForm.ShowDialog(this) == DialogResult.OK)
            {
                this.PrintViolationAct(false);
                RefreshDocs();
            }
        }

        #endregion

        #region ПРОСМОТР И ПЕЧАТЬ АНКЕТЫ ВХОДНОГО КОНТРОЛЯ

        /// <summary>
        /// Класс-поставщик отчетов-анкет входного контроля поставки
        /// </summary>
        private QualityInputControlReportProvider spReportProvider;

        /// <summary>
        /// Просмотр анкеты входного контроля поставки
        /// </summary>
        private void PreviewWorksheet_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new ReportForm();
                form.ReportDocument = spReportProvider.GetReport(SelectedDoc);
                form.ShowDialog(this);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время просмотра анкеты входного контроля поставки: ", exc);
            }
        }

        /// <summary>
        /// Печать выбранной анкеты входного контроля поставки
        /// </summary>
        private void PrintWorksheet_Click(object sender, EventArgs e)
        {
            var printThread = new PrintDocsThread();
            printThread.ReportProvider = spReportProvider;
            var printParams = new PrintDocsParameters
            {
                PrinterName = cmbPrinters.SelectedItem.ToString(),
                Docs = new DataRow[] { SelectedDoc }
            };

            printThread.PrintDocumentsAsynch(printParams);
        }

        #endregion

        #region ПЕЧАТЬ АКТА НЕСООТВЕТСТВИЯ

        private void btnPrintViolationAct_Click(object sender, EventArgs e)
        {
            this.PrintViolationAct(true);
        }

        private void PrintViolationAct(bool reprintMode)
        {
            var fullContent = new Data.Quality.AP_ViolationTermoActsContentDataTable();

            try
            {
                var docID = SelectedDoc.doc_id;
                var versionID = SelectedDoc.version_id;

                using (var adapter = new Data.QualityTableAdapters.AP_ViolationTermoActsContentTableAdapter())
                    adapter.Fill(fullContent, docID, versionID, (string)null);

                if (fullContent.Rows.Count == 0)
                {
                    if (reprintMode)
                        throw new Exception("По данной анкете отсутствуют акты несоответствия.");
                    else
                        return;
                }

                var dTermoModeReports = new Dictionary<string, Data.Quality.AP_ViolationTermoActsContentDataTable>();

                // Группировка актов по терморежиму
                foreach (Data.Quality.AP_ViolationTermoActsContentRow row in fullContent.Rows)
                {
                    var key = row.IsTermo_modeNull() ? string.Empty : row.Termo_mode;
                    if (!dTermoModeReports.ContainsKey(key))
                        dTermoModeReports[key] = new Quality.AP_ViolationTermoActsContentDataTable();

                    dTermoModeReports[key].LoadDataRow(row.ItemArray, true);
                }

                var dtTermoModes = fullContent.DefaultView.ToTable("dtKeys", true, "termo_mode");

                if (reprintMode)
                {
                    if (dtTermoModes.Rows.Count != 1)
                    {
                        var dlgSelectTermoMode = new WMSOffice.Dialogs.RichListForm();
                        dlgSelectTermoMode.Text = "Выберите температурный режим для печати акта";
                        dlgSelectTermoMode.AddColumn("termo_mode", "termo_mode", "температурный режим, °C");
                        dlgSelectTermoMode.FilterVisible = false;
                        dlgSelectTermoMode.DataSource = dtTermoModes;

                        if (dlgSelectTermoMode.ShowDialog() == DialogResult.OK)
                        {
                            var tm = (dlgSelectTermoMode.SelectedRow as DataRow)["termo_mode"].ToString();

                            dtTermoModes.Rows.Clear();
                            dtTermoModes.LoadDataRow(new object[] { tm }, true);
                        }
                        else
                            return;
                    }
                }

                // Печать актов
                foreach (DataRow dr in dtTermoModes.Rows)
                {
                    var tm = dr["termo_mode"].ToString();
                    var dt = dTermoModeReports[tm];

                    var report = new Reports.AP_ViolationTermoActReport();
                    report.SetDataSource(dt as DataTable);

                    report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
                    report.PrintToPrinter(1, false, 1, 0);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        #region ЭКСПОРТ В EXCEL

        /// <summary>
        /// Экспорт в Excel строк в таблице анкет
        /// </summary>
        private void ssbiExportDocs_Click(object sender, EventArgs e)
        {
            try
            {
                if (edgWorksheets.DataGrid.RowCount == 0)
                    throw new Exception("Отсутствуют данные в справочнике анкет.");

                edgWorksheets.ExportToExcel("Экспорт анкет", "Анкеты входного контроля поставки", true);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время экспорта таблицы анкет в Excel:", exc);
            }
        }


        /// <summary>
        /// Экспорт в Excel реестра поставок
        /// </summary>
        private void ssbiExportShipments_Click(object sender, EventArgs e)
        {
            var findShipmentsForm = new QualityInputControlsFindShipmentsForm() { UserID = this.UserID };
            if (findShipmentsForm.ShowDialog(this) == DialogResult.OK)
            {
                isDocLoading = true;
                CustomDocsControls();

                var periodFrom = findShipmentsForm.PeriodFrom;
                var periodTo = findShipmentsForm.PeriodTo;
                var vendorID = findShipmentsForm.VendorID;
                var shipmentID = findShipmentsForm.ShipmentID;
                var statusFrom = findShipmentsForm.StatusFrom;
                var statusTo = findShipmentsForm.StatusTo;

                var vendorName = findShipmentsForm.VendorName;
                var statusFromName = findShipmentsForm.StatusFromName;
                var statusToName = findShipmentsForm.StatusToName;

                bgwLoader = new BackgroundWorker();
                bgwLoader.DoWork += (s, ea) =>
                {
                    try
                    {
                        var registryData = new Data.Quality.AP_ShipmentsRegistryDataTable();

                        using (var adapter = new Data.QualityTableAdapters.AP_ShipmentsRegistryTableAdapter())
                            adapter.Fill(registryData, periodFrom, periodTo, vendorID, shipmentID, statusFrom, statusTo, this.UserID);

                        var stream = new MemoryStream(Properties.Resources.AP_Shipments);

                        var workBook = new XSSFWorkbook(stream);

                        ISheet workSheet = null;
                        int rowIndex;

                        #region ЭКСПОРТ ПОСТАВОК
                        workSheet = workBook.GetSheet("Реестр поставок");

                        var periodFromString = periodFrom.HasValue ? string.Format("с {0}", periodFrom.Value.ToShortDateString()) : (string)null;
                        var periodToString = periodTo.HasValue ? string.Format("по {0}", periodTo.Value.ToShortDateString()) : (string)null;
                        var periodString = string.Format("{0} {1}", periodFromString, periodToString).Trim();
                        workSheet.GetRow(0).Cells[2].SetCellValue(periodString);

                        // Настроен форматированный вывод периода (выше)
                        //
                        //if (periodFrom.HasValue)
                        //    workSheet.GetRow(0).Cells[2].SetCellValue(periodFrom.Value.ToShortDateString());

                        //if (periodTo.HasValue)
                        //    workSheet.GetRow(0).Cells[4].SetCellValue(periodTo.Value.ToShortDateString());

                        if (vendorID.HasValue)
                            workSheet.GetRow(2).Cells[1].SetCellValue(vendorID.Value);

                        if (vendorID.HasValue)
                            workSheet.GetRow(2).Cells[1].SetCellValue(vendorID.Value);

                        workSheet.GetRow(2).Cells[2].SetCellValue(vendorName);

                        if (shipmentID.HasValue)
                            workSheet.GetRow(3).Cells[1].SetCellValue(shipmentID.Value);

                        if (statusFrom.HasValue)
                            workSheet.GetRow(4).Cells[1].SetCellValue(statusFrom.Value);

                        workSheet.GetRow(4).Cells[2].SetCellValue(statusFromName);

                        if (statusTo.HasValue)
                            workSheet.GetRow(5).Cells[1].SetCellValue(statusTo.Value);

                        workSheet.GetRow(5).Cells[2].SetCellValue(statusToName);

                        rowIndex = 8;
                        foreach (Data.Quality.AP_ShipmentsRegistryRow shipment in registryData.Rows)
                        {
                            IRow row = workSheet.CreateRow(rowIndex);

                            if (!shipment.IsDate_planNull())
                                row.CreateCell(0).SetCellValue(shipment.Date_plan.ToString());

                            if (!shipment.IsDate_factNull())
                                row.CreateCell(1).SetCellValue(shipment.Date_fact.ToString());

                            if (!shipment.IsDelivery_numberNull())
                                row.CreateCell(2).SetCellValue(shipment.Delivery_number.ToString());

                            if (!shipment.Isdelivery_statusNull())
                                row.CreateCell(3).SetCellValue(shipment.delivery_status);

                            if (!shipment.IsVendorNull())
                                row.CreateCell(4).SetCellValue(shipment.Vendor);

                            if (!shipment.IsWarehouse_nameNull())
                                row.CreateCell(5).SetCellValue(shipment.Warehouse_name);

                            if (!shipment.IsTermo_mode_15_25Null())
                                row.CreateCell(6).SetCellValue(shipment.Termo_mode_15_25);

                            if (!shipment.IsTermo_mode_2_8Null())
                                row.CreateCell(7).SetCellValue(shipment.Termo_mode_2_8);

                            if (!shipment.IsTermo_mode_8_15Null())
                                row.CreateCell(8).SetCellValue(shipment.Termo_mode_8_15);

                            if (!shipment.IsStatus_controlNull())
                                row.CreateCell(9).SetCellValue(shipment.Status_control);

                            if (!shipment.IsUser_controlNull())
                                row.CreateCell(10).SetCellValue(shipment.User_control);

                            if (!shipment.IsApprove_controlNull())
                                row.CreateCell(11).SetCellValue(shipment.Approve_control);

                            if (!shipment.IsApprove_userNull())
                                row.CreateCell(12).SetCellValue(shipment.Approve_user);

                            rowIndex++;
                        }

                        // Автоподбор ширины колонок
                        for (int i = 0; i <= 12; i++)
                            workSheet.AutoSizeColumn(i);

                        #endregion

                        ea.Result = workBook;
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                bgwLoader.RunWorkerCompleted += (s, ea) =>
                {
                    isDocLoading = false;
                    CustomDocsControls();

                    if (ea.Result is Exception)
                        MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        try
                        {
                            var workBook = ea.Result as XSSFWorkbook;

                            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), string.Format("Реестр поставок.xlsx"));
                            using (var fs = new FileStream(filePath, FileMode.Create))
                            {
                                workBook.Write(fs);
                                fs.Close();

                                Process.Start(filePath);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                };
                bgwLoader.RunWorkerAsync();
            }
        }


        /// <summary>
        /// Экспорт в Excel журнала поставок
        /// </summary>
        private void ssbiExportApprovedShipments_Click(object sender, EventArgs e)
        {
             var findShipmentsForm = new QualityInputControlsFindApprovedShipmentsForm() { UserID = this.UserID };
             if (findShipmentsForm.ShowDialog(this) == DialogResult.OK)
             {
                 isDocLoading = true;
                 CustomDocsControls();

                 var periodFrom = findShipmentsForm.PeriodFrom;
                 var periodTo = findShipmentsForm.PeriodTo;
                 var warehouseID = findShipmentsForm.WarehouseID;

                  bgwLoader = new BackgroundWorker();
                  bgwLoader.DoWork += (s, ea) =>
                  {
                      try
                      {
                          #region obsolete
                          //var journalData = new Data.Quality.AP_ShipmentsJournalDataTable();
                          //using (var adapter = new Data.QualityTableAdapters.AP_ShipmentsJournalTableAdapter())
                          //    adapter.Fill(journalData, periodFrom, periodTo, warehouseID, this.UserID);
                          #endregion

                          var journalData = new Data.Quality.QK_CB_Control_Registry_ReportDataTable();
                          using (var adapter = new Data.QualityTableAdapters.QK_CB_Control_Registry_ReportTableAdapter())
                              adapter.FillAP(journalData, this.UserID, (long?)null, periodFrom, periodTo, (long?)null, warehouseID);

                          ea.Result = journalData;
                      }
                      catch (Exception ex)
                      {
                          ea.Result = ex;
                      }
                  };
                  bgwLoader.RunWorkerCompleted += (s, ea) =>
                  {
                      isDocLoading = false;
                      CustomDocsControls();

                      if (ea.Result is Exception)
                          MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                      else
                      {
                          var ds = new Data.Quality();

                          #region obsolete
                          //ds.AP_ShipmentsJournal.Merge(ea.Result as Data.Quality.AP_ShipmentsJournalDataTable);
                          //var report = new Reports.QualityShipmentsJournalReport();
                          #endregion

                          ds.QK_CB_Control_Registry_Report.Merge(ea.Result as Data.Quality.QK_CB_Control_Registry_ReportDataTable);
                          var report = new Reports.QualityInputControlBranchControlRegistryReport();

                          report.SetDataSource(ds);

                          var reportForm = new ReportForm() { Text = "Журнал поставок" };
                          reportForm.ReportDocument = report;
                          reportForm.ShowDialog();
                      }
                  };
                  bgwLoader.RunWorkerAsync();
             }
        }

        #endregion

        private void btnApproveWorksheet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите подтвердить выбранные анкеты?", "Внимание",  MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            var itemsToApprove = edgWorksheets.SelectedItems;

            try
            {
                foreach (var item in itemsToApprove)
                {
                    var docID = (long)item[InputControlDeliveryView.DOC_ID_PROPERTY_NAME];
                    var versionID = (int)item[InputControlDeliveryView.VERSION_ID_PROPERTY_NAME];

                    using (var adapter = new Data.QualityTableAdapters.AP_DocsTableAdapter())
                        adapter.DocApprove(docID, versionID, this.UserID);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.RefreshDocs();
            }
        }

        private void btnUndoWorksheet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите вернуть выбранные анкеты?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            var itemsToUndo = edgWorksheets.SelectedItems;

            try
            {
                foreach (var item in itemsToUndo)
                {
                    var docID = (long)item[InputControlDeliveryView.DOC_ID_PROPERTY_NAME];
                    var versionID = (int)item[InputControlDeliveryView.VERSION_ID_PROPERTY_NAME];

                    using (var adapter = new Data.QualityTableAdapters.AP_DocsTableAdapter())
                        adapter.DocUndo(docID, versionID, this.UserID);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.RefreshDocs();
            }
        }

        private void ssbExportToExcel_ButtonClick(object sender, EventArgs e)
        {
            ssbExportToExcel.ShowDropDown();
        }
    }

    #region КЛАСС ДЛЯ ОТОБРАЖЕНИЯ ФИЛЬТРУЕМОГО ГРИДА АНКЕТ ВХОДНОГО КОНТРОЛЯ ПОСТАВКИ

    /// <summary>
    /// Представление для грида с анкетами входного контроля партии
    /// </summary>
    public class InputControlDeliveryView : IDataView
    {
        /// <summary>
        /// Название свойства, которое должно выступать как идентификатор анкеты в таблице анкет
        /// </summary>
        public const string DOC_ID_PROPERTY_NAME = "doc_id";

        /// <summary>
        /// Название свойства, которое должно выступать как код версии анкеты в таблице анкет
        /// </summary>
        public const string VERSION_ID_PROPERTY_NAME = "version_id";

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
            var sc = pSearchParameters as InputControlDeliverySheetsSearchParameters;
        using (var adapter = new AP_DocsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.OnlyActual, sc.DeliveryNumber, sc.OrderNumber, sc.VendorID,
                    sc.DateFrom.HasValue ? (DateTime?)sc.DateFrom.Value.Date : null, 
                    sc.DateTo.HasValue ? (DateTime?)(sc.DateTo.Value.Date + TimeSpan.FromDays(1)) : null,
                    sc.ProvisorID, sc.FilterByStatus, sc.IncludeOnlyApproved);
        }

        /// <summary>
        /// Установка источника для грида с анкетами
        /// </summary>
        /// <param name="pDataTable">Таблица с анкетами</param>
        public void FillData(Data.Quality.AP_DocsDataTable pDataTable)
        {
            data = pDataTable;
        }

        public InputControlDeliveryView()
        {
            this.dataColumns.Add(new PatternColumn("Код поставки", "delivery_id", new FilterCompareExpressionRule<Int64>("delivery_id"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Номер авто", "car_number", new FilterPatternExpressionRule("car_number")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Номер полуприцепа", "trailer", new FilterPatternExpressionRule("trailer")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Код поставщика", "vendor_id", new FilterCompareExpressionRule<Int64>("vendor_id")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "vendor", new FilterPatternExpressionRule("vendor")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("Статус версии", "status", new FilterPatternExpressionRule("status")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ анкеты", DOC_ID_PROPERTY_NAME, new FilterCompareExpressionRule<Int64>(DOC_ID_PROPERTY_NAME)) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Версия анкеты", VERSION_ID_PROPERTY_NAME, new FilterCompareExpressionRule<Int64>(VERSION_ID_PROPERTY_NAME)) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата анкеты", "doc_date", new FilterDateCompareExpressionRule("doc_date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Дата версии", "version_date", new FilterDateCompareExpressionRule("version_date")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("Автор версии", "user_created", new FilterPatternExpressionRule("user_created")) { Width = 200 });

            // [WMS-4777]
            this.dataColumns.Add(new PatternColumn("Филиал", "FilialName", new FilterPatternExpressionRule("FilialName")) { Width = 250 });

            // [WMS-10009]
            this.dataColumns.Add(new PatternColumn("Подтверждена", "doc_accepted_tag", new FilterPatternExpressionRule("doc_accepted_tag")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Дата разгрузки", "unloading_event_date", new FilterDateCompareExpressionRule("unloading_event_date")) { Width = 110 });
        }
    }

    #endregion
}
