using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Complaints;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Classes;
using System.Xml;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для печати служебных записок по претензиям.
    /// </summary>
    public partial class ComplaintsCalculationPrintWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
       
        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы со списком расчет-корректировок.
        /// </summary>
        private Data.Complaints.CurrentCalculationsRow SelectedRow
        {
            get
            {
                return this.xdgvCalculations.SelectedItem as Data.Complaints.CurrentCalculationsRow; 
            }
        }

        /// <summary>
        /// Возвращает все выделенные строки из таблицы со списком расчет-корректировок.
        /// </summary>
        private List<Data.Complaints.CurrentCalculationsRow> SelectedRows
        {
            get
            {
                return this.xdgvCalculations.SelectedItems.ConvertAll(new Converter<DataRow, Data.Complaints.CurrentCalculationsRow>(t => t as Data.Complaints.CurrentCalculationsRow));
            }
        }

        /// <summary>
        /// Столбец с информацией об электронных РК
        /// </summary>
        private DataGridViewTextBoxColumn dgvcElectronic = null;

        /// <summary>
        /// Выбранный филиал
        /// </summary>
        public string SelectedWarehouseID { get; private set; }

        /// <summary>
        /// Делегат используемый для формирования РК
        /// </summary>
        private delegate Dictionary<ReportClass, bool> GetCalculationReportsHandler(string kcoo, string dcto, double doco, bool? pDebtorInvoice);

        /// <summary>
        /// Возвращает признак, показывающий, можно ли подтвердить подписание клиентом выбранных расчет-корректировок.
        /// </summary>
        private bool CanApproveSignForSelectedRows
        {
            get
            {
                bool result = false;
                foreach (var row in this.SelectedRows)
                {
                    if (row.CanApproveSign)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Возвращает признак, показывающий, можно ли подтвердить проверку выбранных расчет-корректировок.
        /// </summary>
        private bool CanApproveCheckForSelectedRows
        {
            get
            {
                bool result = false;
                foreach (var row in this.SelectedRows)
                {
                    if (row.CanApproveCheck)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Возвращает признак, показывающий, можно ли выполнить печать выбранных расчет-корректировок.
        /// </summary>
        private bool CanPrintForSelectedRows
        {
            get
            {
                bool result = false;
                foreach (var row in this.SelectedRows)
                {
                    if (row.CanPrint)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Возвращает признак, показывающий, можно ли выполнить изменение даты выбранных расчет-корректировок.
        /// </summary>
        private bool CanChangeDateForSelectedRows
        {
            get
            {
                bool result = false;
                foreach (var row in this.SelectedRows)
                {
                    if (row.CanChangeDate)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                return result;
            }
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public ComplaintsCalculationPrintWindow()
        {
            InitializeComponent();

            // список принтеров, принтер по-умолчанию
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

            btnPrint.Enabled = btnApproveSign.Enabled = btnChangeDate.Enabled = false;
        }

        /// <summary>
        /// Обрабатывает момент первого отображения окна.
        /// </summary>
        private void ComplaintsCalculationPrintWindow_Shown(object sender, EventArgs e)
        {
            if (this.Initialize())
            {
                this.CheckButtonsAccess();
                this.RefreshButtonsState();

                // загрузка списка служебных записок
                btnRefresh_Click(this, EventArgs.Empty);
            }
            else
            {
                this.Close();
            }
        }


        #region ИНИЦИАЛИЗАЦИЯ ОБРАБОТЧИКОВ ФИЛЬТРУЕМОЙ ТАБЛИЦЫ

        public bool Initialize()
        {
            if (!this.PrepareWarehouses())
                return false;

            this.xdgvCalculations.UseMultiSelectMode = true;

            //this.xdgvCalculations.AllowFilter = false;
            this.xdgvCalculations.AllowSummary = false;
            this.xdgvCalculations.AllowRangeColumns = true;

            this.xdgvCalculations.Init(new ComplaintsCalculationsView(), true);

            #region ИНИЦИАЛИЗАЦИЯ "РАБОЧИХ" СТОЛБЦОВ

            foreach (DataGridViewColumn column in xdgvCalculations.DataGrid.Columns)
            {
                if ((column.DataPropertyName ?? string.Empty).Equals("MarkEDI"))
                    dgvcElectronic = column as DataGridViewTextBoxColumn;
            }

            if (dgvcElectronic == null)
            {
                this.ShowError("Отсутствует столбец с информацией об электронных РК.");
                return false;
            }

            #endregion

            this.xdgvCalculations.LoadExtraDataGridViewSettings(this.Name);

            this.xdgvCalculations.UserID = this.UserID;

            this.xdgvCalculations.OnDataError += new DataGridViewDataErrorEventHandler(xdgvCalculations_OnDataError);
            this.xdgvCalculations.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvCalculations_OnRowDoubleClick);
            this.xdgvCalculations.OnRowSelectionChanged += new EventHandler(xdgvCalculations_OnRowSelectionChanged);
            this.xdgvCalculations.OnFilterChanged += new EventHandler(xdgvCalculations_OnFilterChanged);
            this.xdgvCalculations.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvCalculations_OnFormattingCell);
            this.xdgvCalculations.OnDataBindingComplete += new DataGridViewBindingCompleteEventHandler(xdgvCalculations_OnDataBindingComplete);

            this.xdgvCalculations.ContextMenuStrip = cmsCalculationsTable;

            // активация постраничного просмотра
            this.xdgvCalculations.CreatePageNavigator();

            return true;
        }

        private bool PrepareWarehouses()
        {
            try
            {
                var lblWarehouses = new ToolStripLabel("по филиалу");
                toolStripDoc.Items.Insert(1, lblWarehouses);

                var cmbWarehouses = new ToolStripComboBox();

                cmbWarehouses.ComboBox.Width = 200;
                cmbWarehouses.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbWarehouses.ComboBox.DisplayMember = "WarehouseName";
                cmbWarehouses.ComboBox.ValueMember = "WarehouseID";

                cmbWarehouses.ComboBox.SelectedValueChanged += (s, e) =>
                {
                    this.SelectedWarehouseID = cmbWarehouses.ComboBox.SelectedValue != null
                        ? cmbWarehouses.ComboBox.SelectedValue.ToString()
                        : (string)null;
                };

                using (var adapter = new Data.ComplaintsTableAdapters.CalculationsWarehousesTableAdapter())
                    adapter.Fill(complaints.CalculationsWarehouses, this.UserID);

                var bsWarehouses = new BindingSource(complaints, "CalculationsWarehouses");
                cmbWarehouses.ComboBox.DataSource = bsWarehouses;

                toolStripDoc.Items.Insert(2, cmbWarehouses);

                return true;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        void xdgvCalculations_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvCalculations_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        void xdgvCalculations_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.LoadInfoByCalculation();
            this.RefreshButtonsState();
        }

        private void CheckButtonsAccess()
        {
            try
            {
                var access = (bool?)false;
                currentCalculationsTableAdapter.ChangeCalculationDateAccess(this.UserID, ref access);
                
                btnChangeDate.Visible = access ?? false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void RefreshButtonsState()
        {
            btnPrint.Enabled = CanPrintForSelectedRows; //this.SelectedRows.Count > 0;
            miShowClientInvoice.Enabled = miShowOptimaInvoice.Enabled = this.SelectedRows.Count == 1 && !this.SelectedRow.IsDate_CalculationNull();
            btnApproveSign.Enabled = CanApproveSignForSelectedRows;
            btnApproveCheck.Enabled = CanApproveCheckForSelectedRows;
            btnChangeDate.Enabled = CanChangeDateForSelectedRows;

            this.ChangeExportToExcelOptionState();
        }

        private void LoadInfoByCalculation()
        {
            try
            {
                if (this.SelectedRows.Count > 0)
                {
                    var kcoo = this.SelectedRow.KCOO;
                    var dcto = this.SelectedRow.DCTO;
                    var doco = this.SelectedRow.DOCO;

                    // доп. информация по товару
                    infoByCalculationTableAdapter.Fill(complaints.InfoByCalculation, kcoo, dcto, doco);
                    infoByCalculationBindingSource.DataSource = complaints.InfoByCalculation;
                }
                else
                {
                    infoByCalculationBindingSource.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void xdgvCalculations_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvCalculations.RecalculateSummary();
            this.ChangeExportToExcelOptionState();
        }

        void ChangeExportToExcelOptionState()
        {
            btnExportToExcel.Enabled = this.xdgvCalculations.HasRows;
            btnExportItems.Enabled = this.xdgvCalculations.HasRows && this.SelectedRows.Count == 1 && dgvCalculationInfo.Rows.Count > 0;
        }

        void xdgvCalculations_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (xdgvCalculations.DataGrid.Columns[e.ColumnIndex] == dgvcElectronic)
            {
                if (char.IsDigit((e.Value ?? string.Empty).ToString(), 0))
                {
                    var boundRow = (this.xdgvCalculations.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as WMSOffice.Data.Complaints.CurrentCalculationsRow;

                    e.Value = boundRow.IsDate_CalculationNull()
                            ? string.Empty
                            : boundRow.IsPrintClientCopy_FlagNull()
                                ? string.Empty
                                : boundRow.PrintClientCopy_Flag == 0 ? "Да" : "Нет";
                }
            }
        }

        void xdgvCalculations_OnDataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

        #endregion

        /// <summary>
        /// Обрабатывает закрытие окна.
        /// </summary>
        private void ComplaintsCalculationPrintWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvCalculations.SaveExtraDataGridViewSettings(this.Name);
        }

        /// <summary>
        /// Обновляет данные, загружая список не распечатанных расчет корректировок.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BackgroundWorker loadComplaintsWorker = new BackgroundWorker();
            loadComplaintsWorker.DoWork += new DoWorkEventHandler(loadComplaintsWorker_DoWork);
            loadComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadComplaintsWorker_RunWorkerCompleted);

            ComplaintsCalculationsSearchParameters searchCriteria = new ComplaintsCalculationsSearchParameters() { LoadMode = ComplaintsCalculationsLoadMode.Current };
            searchCriteria.SessionID = this.UserID;
            searchCriteria.WarehouseID = this.SelectedWarehouseID;

            splashForm.ActionText = "Загрузка текущих расчет корректировок...";
            loadComplaintsWorker.RunWorkerAsync(searchCriteria);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Загружает в фоне список расчет корректировок, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadComplaintsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var searchCriteria = e.Argument as ComplaintsCalculationsSearchParameters;
                this.xdgvCalculations.DataView.FillData(searchCriteria);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка расчет корректировок.
        /// </summary>
        private void loadComplaintsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
            }
            else
            {
                this.xdgvCalculations.BindData(false);

                //this.xdgvCalculations.AllowFilter = true;
                this.xdgvCalculations.AllowSummary = true;
            }

            splashForm.CloseForce();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск в архиве".
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (Dialogs.Complaints.SearchCalculationOptionsForm form = new Dialogs.Complaints.SearchCalculationOptionsForm(UserID))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BackgroundWorker loadComplaintsWorker = new BackgroundWorker();
                    loadComplaintsWorker.DoWork += new DoWorkEventHandler(loadComplaintsWorker_DoWork);
                    loadComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadComplaintsWorker_RunWorkerCompleted);

                    ComplaintsCalculationsSearchParameters searchCriteria = new ComplaintsCalculationsSearchParameters() { LoadMode = ComplaintsCalculationsLoadMode.Search};
                    searchCriteria.SessionID = this.UserID;
                    searchCriteria.SearchTypeID = (int)form.SearchType;
                    searchCriteria.DocNumber = form.DocNumber;
                    searchCriteria.DocType = form.DocType;
                    searchCriteria.DateFrom = form.DateFrom;
                    searchCriteria.DateTo = form.DateTo;
                    searchCriteria.ItemID = form.ItemID;
                    searchCriteria.ItemName = form.ItemName;

                    splashForm.ActionText = "Поиск расчет-корректировок...";
                    loadComplaintsWorker.RunWorkerAsync(searchCriteria);
                    splashForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Подтвердить подписание клиентом".
        /// </summary>
        private void btnApproveSign_Click(object sender, EventArgs e)
        {
            if (CanApproveSignForSelectedRows)
            {
                try
                {
                    var docPackage = this.GetSelectedDocsXml();

                    var calculationDate = DateTime.MinValue;

                    foreach (var row in this.SelectedRows)
                        calculationDate = calculationDate > row.Date_Calculation ? calculationDate : row.Date_Calculation;

                    using (var dateForm = new Dialogs.Complaints.EnterDateConfirmReturnForm(EnterDateConfirmReturnForm.CalculationDateType.CloseDate, calculationDate))
                    {
                        if (dateForm.ShowDialog() == DialogResult.OK)
                        {
                            currentCalculationsTableAdapter.ChangeCalculationStatusSignApprovedPack(docPackage, UserID, dateForm.Value);
                            //currentCalculationsTableAdapter.ChangeCalculationStatusSignApproved(UserID, row.KCOO, row.DCTO, row.DOCO, dateForm.Value);

                            foreach (var row in this.SelectedRows)
                                row.CanApproveSign = false;
                        }
                    }

                    btnApproveSign.Enabled = false;
                }
                catch (Exception ex)
                {
                    ShowError("Во время смены статуса расчет-корректировок на \"Подписано клиентом\" возникла следующая ошибка:" + Environment.NewLine + ex.Message);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Подтв. проверку корр-ки".
        /// </summary>
        private void btnApproveCheck_Click(object sender, EventArgs e)
        {
            if (CanApproveCheckForSelectedRows)
            {
                try
                {
                    var docPackage = this.GetSelectedDocsXml();

                    currentCalculationsTableAdapter.ChangeCalculationStatusCheckPack(docPackage, UserID);
                    //currentCalculationsTableAdapter.ChangeCalculationStatusCheck(UserID, row.KCOO, row.DCTO, row.DOCO);

                    foreach (var row in this.SelectedRows)
                        row.CanApproveCheck = false;

                    btnApproveCheck.Enabled = false;
                }
                catch (Exception ex)
                {
                    ShowError("Во время подтверждения проверки расчет-корректировки возникла следующая ошибка:" + Environment.NewLine + ex.Message);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Экспорт в Excel".
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvCalculations.ExportToExcel("Сохранение списка расчет-корректировок", "список р-к", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region ПЕЧАТЬ РАСЧЕТ-КОРРЕКТИРОВОК

        private string GetSelectedDocsXml()
        {
            var isDocsSelected = false;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Data></Data>");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (var doc in this.SelectedRows)
            {
                var xElement = xDoc.CreateElement("Line");

                var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("kcoo"));
                xValue.Value = doc.KCOO;

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("doco"));
                xValue.Value = doc.DOCO.ToString();

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("dcto"));
                xValue.Value = doc.DCTO;

                xRoot.AppendChild(xElement);

                isDocsSelected = true;
            }

            if (!isDocsSelected)
                return (string)null;

            return xDoc.InnerXml;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать выбранные расчет корректировки".
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (!CanPrintForSelectedRows)
                return;

            try
            {
                //if (this.SelectedRows.Count == 1 && cbPrinters.SelectedItem != null) // ВНИМАНИЕ! для печати сразу нескольких расчет-корректировок нужно многократно проверять необходимость (возможность) смены даты
                //{

                var docPackage = this.GetSelectedDocsXml();

                PrintWorkerParameters parameters = new PrintWorkerParameters() { PrinterName = (string)cbPrinters.SelectedItem, DocPackage = docPackage };

                object canChangeDate = currentCalculationsTableAdapter.CanChangeCalculationDatePack(docPackage, this.UserID);
                //object canChangeDate = currentCalculationsTableAdapter.CanChangeCalculationDate(SelectedRow.KCOO, SelectedRow.DCTO, SelectedRow.DOCO, this.UserID);

                if (canChangeDate != null && Convert.ToBoolean(canChangeDate))
                {
                    // организация многократного выбора даты РК
                    var changedCalculationDate = DateTime.Today;
                    while (true)
                    {
                        using (var dateForm = new Dialogs.Complaints.EnterDateConfirmReturnForm(Dialogs.Complaints.EnterDateConfirmReturnForm.CalculationDateType.CalculationDate, changedCalculationDate))
                        {
                            if (dateForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    changedCalculationDate = dateForm.Value;
                                    var checkResult = this.CheckCalculationDate(changedCalculationDate);
                                    if (!checkResult)
                                        continue;

                                    currentCalculationsTableAdapter.ChangeCalculationDatePack(docPackage, UserID, changedCalculationDate);
                                    //currentCalculationsTableAdapter.ChangeCalculationDate(UserID, SelectedRow.KCOO, SelectedRow.DCTO, SelectedRow.DOCO, changedCalculationDate);

                                    parameters.CalculationDates.Add(changedCalculationDate);
                                    break;
                                }
                                catch (Exception ex)
                                {
                                    ShowError(ex);
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }
                else
                {
                    if (!SelectedRow.IsDate_CalculationNull())
                        parameters.CalculationDates.Add(SelectedRow.Date_Calculation);
                    else
                        throw new Exception("По данной претензии не найден номер РК.\r\nОбратитесь в ГСПО!");
                }

                parameters.KCOOs.Add(SelectedRow.KCOO);
                parameters.DCTOs.Add(SelectedRow.DCTO);
                parameters.DOCOs.Add(SelectedRow.DOCO);

                /*foreach (DataGridViewRow r in dgvCalculations.Rows)
                {
                    if (r.Selected)
                    {
                        Data.Complaints.CurrentCalculationsRow row = (Data.Complaints.CurrentCalculationsRow)((DataRowView)r.DataBoundItem).Row;
                        parameters.KCOOs.Add(row.KCOO);
                        parameters.DCTOs.Add(row.DCTO);
                        parameters.DOCOs.Add(row.DOCO);
                    }
                }*/

                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                splashForm.ActionText = "Печать выбранных расчет-корректировок...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                // маркируем напечатанные РК
                foreach (DataGridViewRow row in xdgvCalculations.DataGrid.Rows)
                {
                    if (row.Selected)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = Color.LimeGreen;
                            row.Cells[c].Style.SelectionForeColor = Color.LimeGreen;
                        }
                    }
                }
                //}
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private bool CheckCalculationDate(DateTime? calculationDate)
        {
            if (!calculationDate.HasValue)
                return true;

            try
            {
                currentCalculationsTableAdapter.CheckCalculationDate("CC", calculationDate, UserID);
                return true;
            }
            catch (Exception ex)
            {
                var message = ex.Message;

                if (message.Contains("#"))
                {
                    var regex = new System.Text.RegularExpressions.Regex(@"^#(?<Tag>\w+)#(?<Message>.+)#", System.Text.RegularExpressions.RegexOptions.IgnoreCase | System.Text.RegularExpressions.RegexOptions.Singleline);
                    if (regex.IsMatch(ex.Message))
                    {
                        var match = regex.Match(ex.Message);
                        message = match.Groups["Message"].Value;
                        var tag = match.Groups["Tag"].Value.ToUpper();
                        switch (tag)
                        {
                            case "BADDATE":
                                MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return false;
                            default:
                                break;
                        }
                    }
                }

                throw ex;
            }
        }

        /// <summary>
        /// Печатает в фоне выделенные расчет корректировки, используя их идентификаторы, переданные в аргументе.
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var reportPeriodHandlers = new Dictionary<DateTime, GetCalculationReportsHandler>();
                reportPeriodHandlers[new DateTime(2015, 1, 1)] = GetCalculationReports_Since_01_2015;
                reportPeriodHandlers[new DateTime(2014, 12, 1)] = GetCalculationReports_Since_07_2014;
                reportPeriodHandlers[new DateTime(2014, 3, 1)] = GetCalculationReports_Since_01_2014;
                reportPeriodHandlers[new DateTime(2011, 12, 16)] = GetCalculationReports;
                reportPeriodHandlers[new DateTime(2000, 1, 1)] = GetCalculationReportsOld2;

                PrintWorkerParameters p = (PrintWorkerParameters)e.Argument;
                for (int i = 0; i < p.KCOOs.Count; ++i)
                {
                    foreach (var rph in reportPeriodHandlers)
                    {
                        var period = rph.Key;
                        var reportHandler = rph.Value;

                        if (p.CalculationDates[i] >= period)
                        {
                            foreach (var kvp in reportHandler(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i], null))
                            {
                                var report = kvp.Key;

                                try
                                {
                                    if (kvp.Value)
                                        continue;

                                    report.PrintOptions.PrinterName = p.PrinterName;
                                    report.PrintToPrinter(1, false, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "CC", 24, Convert.ToInt64(p.DOCOs[i]), p.DCTOs[i], (short?)null, p.PrinterName, 1);
                                }
                                finally
                                {
                                    report.Dispose();
                                }
                            }

                            break;
                        }
                    }

                    /*foreach (Reports.ComplaintCalculationReport report in GetCalculationReports(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i]))
                    {
                        report.PrintOptions.PrinterName = p.PrinterName;
                        report.PrintToPrinter(1, false, 1, 0);
                        report.Dispose();
                    }*/
                    // подтверждение печати
                    // if (!docsFromArchive) -- Статус обновляется всегда (22.03.2011)
                    {
                        var docPackage = p.DocPackage;
                        currentCalculationsTableAdapter.ChangeCalculationStatusPrintedPack(docPackage, UserID);
                        //currentCalculationsTableAdapter.ChangeCalculationStatusPrinted(UserID, p.KCOOs[i], p.DCTOs[i], p.DOCOs[i]);
                    }

                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание печати расчет корректировок в фоне.
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }

        #endregion

        #region PrintWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для печати расчет корректировок.
        /// </summary>
        private class PrintWorkerParameters
        {
            private List<string> _KCOOs = new List<string>();
            private List<string> _DCTOs = new List<string>();
            private List<double> _DOCOs = new List<double>();
            private List<DateTime> _CalculationDates = new List<DateTime>();

            /// <summary>
            /// Идентификаторы расчет-корректировок (KCOO).
            /// </summary>
            public List<string> KCOOs { get { return _KCOOs; } }
            /// <summary>
            /// Идентификаторы расчет-корректировок (DCTO).
            /// </summary>
            public List<string> DCTOs { get { return _DCTOs; } }
            /// <summary>
            /// Идентификаторы расчет-корректировок (DOCO).
            /// </summary>
            public List<double> DOCOs { get { return _DOCOs; } }
            /// Дата расчет-корректировок (CalculationDate).
            /// </summary>
            public List<DateTime> CalculationDates { get { return _CalculationDates; } }
            /// <summary>
            /// Название принтера.
            /// </summary>
            public string PrinterName { get; set; }
            /// <summary>
            /// XML с параметрами пакета документов для печати
            /// </summary>
            public string DocPackage { get; set; }
        }

        #endregion

        #region ФОРМИРОВАНИЕ ИСТОЧНИКА ДАННЫХ ПЕЧАТНОЙ ФОРМЫ РК

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (с 01.01.2014).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <param name="pDebtorInvoice">True если надо получить только отчет для клиента, 
        /// False если надо получить только отчет для Оптимы, null если оба отчета</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReports_Since_01_2014(string kcoo, string dcto, double doco,
            bool? pDebtorInvoice)
        {
            var result = new Dictionary<ReportClass, bool>();

            // загрузка детальных данных по расчет корректировке
            Data.Complaints.ReportCalculationHeaderDataTable headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
            using (Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
            {
                adapterHeader.SetTimeout(600);
                adapterHeader.Fill(headersTable, kcoo, dcto, doco);
            }
            if (headersTable.Rows.Count > 0 && headersTable[0].CalculationCount > 0)
            {
                Data.Complaints.ReportCalculationDetailDataTable detailsTable = new Data.Complaints.ReportCalculationDetailDataTable();
                using (Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                {
                    adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                    adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headersTable[0].InvoiceNumber);
                }


                bool isElectronicInvoice;

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронный документ
                    isElectronicInvoice = headerRow.MarkEV01 == 0;

                    if (pDebtorInvoice.HasValue && (
                        (pDebtorInvoice == true && (headerRow.IsTaxInvoiceMarkDebtorOriginalNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkDebtorOriginal.Trim()))) ||
                        (pDebtorInvoice == false && (headerRow.IsTaxInvoiceMarkSellerCopyNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkSellerCopy.Trim())))
                        ))
                    {
                        if (!isElectronicInvoice)
                            continue;   // Пропускаем "ненужную" копию
                    }

                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    Data.Complaints tmpCalculationData = new Data.Complaints();
                    tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);

                    Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                    object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                    if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                        Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                    tmpRow.ItemArray = tmpItemArray;
                    tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);

                    Reports.ComplaintCalculationReport_Since_01_2014 report = new Reports.ComplaintCalculationReport_Since_01_2014();
                    report.SetDataSource(tmpCalculationData);
                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (с 01.07.2014).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <param name="pDebtorInvoice">True если надо получить только отчет для клиента, 
        /// False если надо получить только отчет для Оптимы, null если оба отчета</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReports_Since_07_2014(string kcoo, string dcto, double doco,
            bool? pDebtorInvoice)
        {
            var result = new Dictionary<ReportClass, bool>();

            // загрузка детальных данных по расчет корректировке
            var headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
            using (var adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
            {
                adapterHeader.SetTimeout(600);
                adapterHeader.Fill(headersTable, kcoo, dcto, doco);
            }
            if (headersTable.Rows.Count > 0 && headersTable[0].CalculationCount > 0)
            {
                var detailsTable = new Data.Complaints.ReportCalculationDetailDataTable();
                using (var adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                {
                    adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                    adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headersTable[0].InvoiceNumber);
                }


                bool isElectronicInvoice;

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронный документ
                    isElectronicInvoice = headerRow.MarkEV01 == 0;

                    if (pDebtorInvoice.HasValue && (
                        (pDebtorInvoice == true && (headerRow.IsTaxInvoiceMarkDebtorOriginalNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkDebtorOriginal.Trim()))) ||
                        (pDebtorInvoice == false && (headerRow.IsTaxInvoiceMarkSellerCopyNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkSellerCopy.Trim())))
                        ))
                    {
                        if (!isElectronicInvoice)
                            continue;   // Пропускаем "ненужную" копию
                    }

                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    var tmpCalculationData = new Data.Complaints();
                    tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);

                    Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                    object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                    if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                        Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                    tmpRow.ItemArray = tmpItemArray;
                    tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);

                    var report = new Reports.ComplaintCalculationReport_Since_07_2014();
                    report.SetDataSource(tmpCalculationData);
                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (с 01.01.2015).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <param name="pDebtorInvoice">True если надо получить только отчет для клиента, 
        /// False если надо получить только отчет для Оптимы, null если оба отчета</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReports_Since_01_2015(string kcoo, string dcto, double doco,
            bool? pDebtorInvoice)
        {
            var result = new Dictionary<ReportClass, bool>();

            // загрузка детальных данных по расчет корректировке
            var headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
            using (var adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
            {
                adapterHeader.SetTimeout(600);
                adapterHeader.Fill(headersTable, kcoo, dcto, doco);
            }
            if (headersTable.Rows.Count > 0 && headersTable[0].CalculationCount > 0)
            {
                var detailsTable = new Data.Complaints.ReportCalculationDetailDataTable();
                using (var adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                {
                    adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                    adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headersTable[0].InvoiceNumber);
                }


                bool isElectronicInvoice;

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронный документ
                    isElectronicInvoice = headerRow.MarkEV01 == 0;

                    if (pDebtorInvoice.HasValue && (
                        (pDebtorInvoice == true && (headerRow.IsTaxInvoiceMarkDebtorOriginalNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkDebtorOriginal.Trim()))) ||
                        (pDebtorInvoice == false && (headerRow.IsTaxInvoiceMarkSellerCopyNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkSellerCopy.Trim())))
                        ))
                    {
                        if (!isElectronicInvoice)
                            continue;   // Пропускаем "ненужную" копию
                    }

                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    var tmpCalculationData = new Data.Complaints();
                    tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);

                    Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                    object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                    if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                        Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                    tmpRow.ItemArray = tmpItemArray;
                    tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);

                    var report = new Reports.ComplaintCalculationReport_Since_01_2015();
                    report.SetDataSource(tmpCalculationData);
                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (с 16.12.2011).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <param name="pDebtorInvoice">True если надо получить только отчет для клиента, 
        /// False если надо получить только отчет для Оптимы, null если оба отчета</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReports(string kcoo, string dcto, double doco,
            bool? pDebtorInvoice)
        {
            var result = new Dictionary<ReportClass, bool>();

            // загрузка детальных данных по расчет корректировке
            Data.Complaints.ReportCalculationHeaderDataTable headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
            using (Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
            {
                adapterHeader.SetTimeout(600);
                adapterHeader.Fill(headersTable, kcoo, dcto, doco);
            }
            if (headersTable.Rows.Count > 0 && headersTable[0].CalculationCount > 0)
            {
                Data.Complaints.ReportCalculationDetailDataTable detailsTable = new Data.Complaints.ReportCalculationDetailDataTable();
                using (Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                {
                    adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                    adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headersTable[0].InvoiceNumber);
                }

                bool isElectronicInvoice;

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронный документ
                    isElectronicInvoice = headerRow.MarkEV01 == 0;

                    if (pDebtorInvoice.HasValue && (
                        (pDebtorInvoice == true && (headerRow.IsTaxInvoiceMarkDebtorOriginalNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkDebtorOriginal.Trim()))) ||
                        (pDebtorInvoice == false && (headerRow.IsTaxInvoiceMarkSellerCopyNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkSellerCopy.Trim())))
                        ))
                    {
                        if (!isElectronicInvoice)
                            continue;   // Пропускаем "ненужную" копию
                    }

                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    Data.Complaints tmpCalculationData = new Data.Complaints();
                    tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);

                    Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                    object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                    if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                        Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                    tmpRow.ItemArray = tmpItemArray;
                    tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);

                    Reports.ComplaintCalculationReport report = new Reports.ComplaintCalculationReport();
                    report.SetDataSource(tmpCalculationData);
                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (до 15.12.2011).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <param name="pDebtorInvoice">True если надо получить только отчет для клиента, 
        /// False если надо получить только отчет для Оптимы, null если оба отчета</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReportsOld2(string kcoo, string dcto, double doco,
            bool? pDebtorInvoice)
        {
            var result = new Dictionary<ReportClass, bool>();

            // загрузка детальных данных по расчет корректировке
            Data.Complaints.ReportCalculationHeaderDataTable headersTable = new Data.Complaints.ReportCalculationHeaderDataTable();
            using (Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter adapterHeader = new Data.ComplaintsTableAdapters.ReportCalculationHeaderTableAdapter())
            {
                adapterHeader.SetTimeout(600);
                adapterHeader.Fill(headersTable, kcoo, dcto, doco);
            }
            if (headersTable.Rows.Count > 0 && headersTable[0].CalculationCount > 0)
            {
                Data.Complaints.ReportCalculationDetailDataTable detailsTable = new Data.Complaints.ReportCalculationDetailDataTable();
                using (Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                {
                    adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                    adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headersTable[0].InvoiceNumber);
                }

                bool isElectronicInvoice;

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронный документ
                    isElectronicInvoice = headerRow.MarkEV01 == 0;

                    if (pDebtorInvoice.HasValue && (
                        (pDebtorInvoice == true && (headerRow.IsTaxInvoiceMarkDebtorOriginalNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkDebtorOriginal.Trim()))) ||
                        (pDebtorInvoice == false && (headerRow.IsTaxInvoiceMarkSellerCopyNull() || String.IsNullOrEmpty(headerRow.TaxInvoiceMarkSellerCopy.Trim())))
                        ))
                    {
                        if (!isElectronicInvoice)
                            continue;   // Пропускаем "ненужную" копию
                    }

                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    Data.Complaints tmpCalculationData = new Data.Complaints();
                    tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);

                    Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                    object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                    if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                        Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                    tmpRow.ItemArray = tmpItemArray;
                    tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);

                    Reports.ComplaintCalculationReportOld2 report = new Reports.ComplaintCalculationReportOld2();
                    report.SetDataSource(tmpCalculationData);
                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }

        #endregion

        #region ПРОСМОТР РАСЧЕТ-КОРРЕКТИРОВОК

        /// <summary>
        /// Просмотр расчет-корректировки от Оптимы либо клиента
        /// </summary>
        private void miShowInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                bool showForm = false;
                bool allowPrint = true;

                var reportPeriodHandlers = new Dictionary<DateTime, GetCalculationReportsHandler>();
                reportPeriodHandlers[new DateTime(2015, 1, 1)] = GetCalculationReports_Since_01_2015;
                reportPeriodHandlers[new DateTime(2014, 12, 1)] = GetCalculationReports_Since_07_2014;
                reportPeriodHandlers[new DateTime(2014, 3, 1)] = GetCalculationReports_Since_01_2014;
                reportPeriodHandlers[new DateTime(2011, 12, 16)] = GetCalculationReports;
                reportPeriodHandlers[new DateTime(2000, 1, 1)] = GetCalculationReportsOld2;

                using (var reportForm = new ReportForm())
                {
                    foreach (var rph in reportPeriodHandlers)
                    {
                        var period = rph.Key;
                        var reportHandler = rph.Value;

                        if (SelectedRow.Date_Calculation >= period)
                        {
                            foreach (var kvp in reportHandler(SelectedRow.KCOO, SelectedRow.DCTO, SelectedRow.DOCO, sender == miShowClientInvoice))
                            {
                                if (kvp.Value)
                                    allowPrint = false;

                                var report = kvp.Key;

                                showForm = true;
                                reportForm.ReportDocument = report;
                            }

                            break;
                        }
                    }

                    if (showForm)
                    {
                        reportForm.CanPrint = allowPrint;
                        reportForm.CanExport = allowPrint;

                        if (!allowPrint)
                        {
                            reportForm.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", reportForm.Text);
                        }

                        reportForm.ShowDialog();

                        if (reportForm.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "CC", 24, Convert.ToInt64(SelectedRow.DOCO), SelectedRow.DCTO, (short?)null, reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                        }
                    }
                    else
                        Logger.ShowErrorMessageBox("Не удалось получить шаблон для отчета!");
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при отображении расчет-корректировки!", exc);
            }
        }

        #endregion

        #region ЭКСПОРТ ПОЗИЦИЙ В EXCEL

        private void btnExportItems_Click(object sender, EventArgs e)
        {
            var kcoo = this.SelectedRow.KCOO;
            var dcto = this.SelectedRow.DCTO;
            var doco = this.SelectedRow.DOCO;

            var message = ExportHelper.ExportDataTableToExcel(complaints.InfoByCalculation,
               new string[] { "Код", "Наименование товара", "Серия", "Партия", "Цена", "К-во", "Сумма", "Сумма НДС", "Сумма с НДС" },
               new string[] { "Item_ID", "Item", "Vendor_Lot", "LotNumber", "Cost", "Quantity", "Sum", "VAT", "SumVat" },
               "Экспорт перечня товара", String.Format("Перечень товара по заказу ({0}){1}", dcto, doco), true);
            
            if (!String.IsNullOrEmpty(message))
                Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel перечня товара возникла ошибка:\n{0}", message));
        }

        #endregion

        private void btnChangeDate_Click(object sender, EventArgs e)
        {
            if (!CanChangeDateForSelectedRows)
                return;

            try
            {
                var docPackage = this.GetSelectedDocsXml();

                object canChangeDate = currentCalculationsTableAdapter.CanChangeCalculationDatePack(docPackage, this.UserID);
                //object canChangeDate = currentCalculationsTableAdapter.CanChangeCalculationDate(SelectedRow.KCOO, SelectedRow.DCTO, SelectedRow.DOCO, this.UserID);

                if (canChangeDate != null && Convert.ToBoolean(canChangeDate))
                {
                    // организация многократного выбора даты РК
                    var changedCalculationDate = DateTime.Today;
                    while (true)
                    {
                        using (var dateForm = new Dialogs.Complaints.EnterDateConfirmReturnForm(Dialogs.Complaints.EnterDateConfirmReturnForm.CalculationDateType.CalculationDate, changedCalculationDate))
                        {
                            if (dateForm.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    changedCalculationDate = dateForm.Value;
                                    var checkResult = this.CheckCalculationDate(changedCalculationDate);
                                    if (!checkResult)
                                        continue;

                                    currentCalculationsTableAdapter.ChangeCalculationDatePack(docPackage, UserID, changedCalculationDate);
                                    //currentCalculationsTableAdapter.ChangeCalculationDate(UserID, SelectedRow.KCOO, SelectedRow.DCTO, SelectedRow.DOCO, changedCalculationDate);

                                    break;
                                }
                                catch (Exception ex)
                                {
                                    ShowError(ex);
                                    return;
                                }
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                }

                //btnChangeDate.Enabled = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для списка претензий
    /// </summary>
    public class ComplaintsCalculationsView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 600;

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
            var searchCriteria = searchParameters as ComplaintsCalculationsSearchParameters;

            var searchMode = searchCriteria.LoadMode;

            var searchTypeID = searchCriteria.SearchTypeID;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;
            var docNumber = searchCriteria.DocNumber;
            var docType = searchCriteria.DocType;
            var dateFrom = searchCriteria.DateFrom;
            var dateTo = searchCriteria.DateTo;
            var itemID = searchCriteria.ItemID;
            var itemName = searchCriteria.ItemName;

            using (Data.ComplaintsTableAdapters.CurrentCalculationsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentCalculationsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);

                switch (searchMode)
                {
                    case ComplaintsCalculationsLoadMode.Search:
                        data = adapter.GetDataBySearch(sessionID, searchTypeID, docNumber, docType, dateFrom, dateTo, itemID, itemName);
                        break;
                    case ComplaintsCalculationsLoadMode.Current:
                    default:
                        data = adapter.GetCurrent(sessionID, warehouseID);
                        break;
                }
            }
        }

        #endregion

        public ComplaintsCalculationsView()
        {
            this.dataColumns.Add(new PatternColumn("Элект- ронная", "MarkEDI", new FilterPatternExpressionRule("MarkEDI")) { Width = 65 });
            this.dataColumns.Add(new PatternColumn("№ служ. записки", "Memo_Number", new FilterCompareExpressionRule<Int64>("Memo_Number")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("№ расч.- корр.", "Calculation_Number", new FilterCompareExpressionRule<Int64>("Calculation_Number")) { Width = 85 });
            this.dataColumns.Add(new PatternColumn("Статус", "Status_ID", new FilterPatternExpressionRule("Status_ID"), SummaryCalculationType.Count) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("Подтв. проверка корр-ки", "CheckApprove", new FilterPatternExpressionRule("CheckApprove")) { Width = 65 });
            this.dataColumns.Add(new PatternColumn("Подписано", "SignApproved", new FilterPatternExpressionRule("SignApproved")) { Width = 75 });
            this.dataColumns.Add(new PatternColumn("Тип документа", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name"), SummaryCalculationType.Count) { Width = 99 });
            this.dataColumns.Add(new PatternColumn("Код деб.", "Source_Address_Code", new FilterCompareExpressionRule<Int32>("Source_Address_Code"), SummaryCalculationType.Count) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("Дебитор", "Source_Address_Name", new FilterPatternExpressionRule("Source_Address_Name")) { Width = 180 });
            this.dataColumns.Add(new PatternColumn("Адрес дебитора", "Source_Address", new FilterPatternExpressionRule("Source_Address")) { Width = 180 });
            this.dataColumns.Add(new PatternColumn("Тип зак.", "RelatedOrderType", new FilterPatternExpressionRule("RelatedOrderType")) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("№ заказа", "RelatedOrderNumber", new FilterCompareExpressionRule<Int64>("RelatedOrderNumber")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Тип накл.", "RelatedInvoiceType", new FilterPatternExpressionRule("RelatedInvoiceType")) { Width = 55 });
            this.dataColumns.Add(new PatternColumn("№ накладной", "RelatedInvoiceNumber", new FilterCompareExpressionRule<Int64>("RelatedInvoiceNumber")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Сумма", "SumTotal", new FilterCompareExpressionRule<Decimal>("SumTotal"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N2", Width = 90 });
            this.dataColumns.Add(new PatternColumn("Сумма с НДС", "SumTotalWithVAT", new FilterCompareExpressionRule<Decimal>("SumTotalWithVAT"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N4", Width = 90 });
            this.dataColumns.Add(new PatternColumn("НДС", "VatRate", new FilterCompareExpressionRule<Int32>("VatRate")) { UseIntegerNumbersAlignment = true, Width = 56 });
            this.dataColumns.Add(new PatternColumn("Дата р/к", "Date_Calculation", new FilterDateCompareExpressionRule("Date_Calculation")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата закрытия", "Date_Closed", new FilterDateCompareExpressionRule("Date_Closed")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Менеджер", "ManagerName", new FilterPatternExpressionRule("ManagerName")) { Width = 180 });
            this.dataColumns.Add(new PatternColumn("Код фил.", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID"), SummaryCalculationType.Count) { Width = 67 });
            this.dataColumns.Add(new PatternColumn("Филиал", "Warehouse_Name", new FilterPatternExpressionRule("Warehouse_Name")) { Width = 130 });
            this.dataColumns.Add(new PatternColumn("Тип", "DCTO", new FilterPatternExpressionRule("DCTO")) { Width = 37 });
            this.dataColumns.Add(new PatternColumn("Код", "DOCO", new FilterCompareExpressionRule<Int64>("DOCO")) { Width = 65 });
            this.dataColumns.Add(new PatternColumn("№ претензии", "CONumber", new FilterCompareExpressionRule<Int64>("CONumber"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Сумма НДС", "SumVAT", new FilterCompareExpressionRule<Decimal>("SumVAT"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Format = "N4", Width = 90 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class ComplaintsCalculationsSearchParameters : SessionIDSearchParameters
    {
        public ComplaintsCalculationsLoadMode LoadMode { get; set; }

        public int? SearchTypeID { get; set; }

        public string WarehouseID { get; set; }
        public long? DocNumber { get; set; }
        public string DocType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? ItemID { get; set; }
        public string ItemName { get; set; }

        public ComplaintsCalculationsSearchParameters()
        {
            this.WarehouseID = (string)null;
            this.DocType = (string)null;
            this.ItemName = (string)null;
        }
    }

    /// <summary>
    /// Режимы поиска
    /// </summary>
    public enum ComplaintsCalculationsLoadMode
    {
        /// <summary>
        /// Текущий
        /// </summary>
        Current = 1,

        /// <summary>
        /// Поиск
        /// </summary>
        Search = 2
    }
}
