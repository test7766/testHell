using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;
using CrystalDecisions.CrystalReports.Engine;
using System.Xml;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно для просмотра расчет-корректировок по акту скидки
    /// </summary>
    public partial class ActDiscountRKsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// Акт скидки, для которого загружаются расчет-корректировки
        /// </summary>
        private WMSOffice.Data.WH.AS_Get_DocsRow act;

        /// <summary>
        /// Коллекция актов скидок, выделенных в таблице. Если не выделена ни один акт скидки, то коллекция пуста
        /// </summary>
        private List<WMSOffice.Data.WH.AS_Get_CalculationsRow> SelectedDocs
        {
            get
            {
                var docs = new List<WMSOffice.Data.WH.AS_Get_CalculationsRow>();
                foreach (DataGridViewRow row in dgvActDetails.SelectedRows)
                    docs.Add((row.DataBoundItem as DataRowView).Row as WMSOffice.Data.WH.AS_Get_CalculationsRow);
                return docs;                
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public ActDiscountRKsForm(WMSOffice.Data.WH.AS_Get_DocsRow pDoc, long pSessionID)
        {
            InitializeComponent();
            act = pDoc;
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка расчет-корректировок для акта скидки
        /// </summary>
        private void ActDiscountRKsForm_Load(object sender, EventArgs e)
        {
            RefreshRKs();
        }

        /// <summary>
        /// Перезагрузка списка расчет-корректировок
        /// </summary>
        private void RefreshRKs()
        {
            try
            {
                taAsGetCalculations.Fill(wH.AS_Get_Calculations, act.Doc_ID);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить расчет-корректировки для акта скидки: " + Environment.NewLine, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        #endregion

        #region ПЕЧАТЬ РАСЧЕТ-КОРРЕКТИРОВОК

        private string GetSelectedDocsXml()
        {
            var isDocsSelected = false;

            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml("<Data></Data>");

            XmlElement xRoot = xDoc.DocumentElement;
            foreach (var doc in this.SelectedDocs)
            {
                var xElement = xDoc.CreateElement("Line");

                var xValue = xElement.Attributes.Append(xDoc.CreateAttribute("kcoo"));
                xValue.Value = "00001";

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("doco"));
                xValue.Value = doc.Calculation_Number.ToString();

                xValue = xElement.Attributes.Append(xDoc.CreateAttribute("dcto"));
                xValue.Value = doc.Calculation_Type;

                xRoot.AppendChild(xElement);

                isDocsSelected = true;
            }

            if (!isDocsSelected)
                return (string)null;

            return xDoc.InnerXml;
        }

        /// <summary>
        /// Запуск печать расчет-корректировок
        /// </summary>
        private void miPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectedDocs.Count == 0)
                {
                    MessageBox.Show("Не выбрано ни одной расчет-корректировки!", "Печать расчет-корректировок", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                // организация многократного выбора даты РК
                var changedCalculationDate = (DateTime?)null;
                while (true)
                {
                    try
                    {
                        var defineDateResult = this.DefineChangedCalculationDate(ref changedCalculationDate);
                        if (defineDateResult)
                        {
                            var checkResult = this.CheckCalculationDate(changedCalculationDate);
                            if (!checkResult)
                                continue;

                            break;
                        }
                        else
                        {
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                var docPackage = this.GetSelectedDocsXml();

                var printWorker = new BackgroundWorker();
                printWorker.DoWork += printWorker_DoWork;
                printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
                var parameters = new PrinterWorkerParameters() { PrinterName = (new PrinterSettings()).PrinterName, ChangedCalculationDate = changedCalculationDate, DocPackage = docPackage };

                // [GSPO-4256]
                //parameters.DocsToPrint.AddRange(SelectedDocs);

                #region ДОБАВЛЕНИЕ УНИКАЛЬНЫХ ДОКУМЕНТОВ ДЛЯ ПЕЧАТИ

                foreach (var selectedDoc in SelectedDocs)
                {
                    bool docFound = false;
                    foreach (var docToPrint in parameters.DocsToPrint)
                        if (docToPrint.Calculation_Type == selectedDoc.Calculation_Type && docToPrint.Calculation_Number == selectedDoc.Calculation_Number)
                        {
                            docFound = true;
                            break;
                        }

                    if (!docFound)
                        parameters.DocsToPrint.Add(selectedDoc);
                }

                #endregion

                printWorker.RunWorkerAsync(parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckCalculationDate(DateTime? calculationDate)
        {
            if (!calculationDate.HasValue)
                return true;

            try
            {
                taAsGetCalculations.CheckCalculationDate("AS", calculationDate, sessionID);
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
        /// Определение изменений в дате расчет-корректировки во время печати
        /// </summary>
        private bool DefineChangedCalculationDate(ref DateTime? changedCalculationDate)
        {
            try
            {
                bool needDefineCalculationDate = false; // признак необходимости установки даты РК
                var canCheckNeedDefineCalculationDate = !changedCalculationDate.HasValue; // признак необходимости искать флаг установки даты РК
                if (canCheckNeedDefineCalculationDate)
                {
                    foreach (WMSOffice.Data.WH.AS_Get_CalculationsRow doc in SelectedDocs)
                    {
                        if (doc.IsCalculation_DateNull())
                        {
                            needDefineCalculationDate = true;
                            break;
                        }
                    }
                }
                else
                {
                    needDefineCalculationDate = true;
                }


                //if (Convert.ToBoolean(taAsGetCalculations.CanChangeCalculationDate("00001", SelectedDocs[0].Calculation_Type, SelectedDocs[0].Calculation_Number)))
                //if (Convert.ToBoolean(taAsGetCalculations.CanChangeCalculationDatePack(null, sessionID)))
                if (needDefineCalculationDate)
                {
                    if (!changedCalculationDate.HasValue)
                        changedCalculationDate = DateTime.Today;

                    using (var window = new EnterDateConfirmReturnForm(EnterDateConfirmReturnForm.CalculationDateType.CalculationDate, changedCalculationDate.Value))
                    {
                        window.ShowDialog(this);
                        if (window.DialogResult == DialogResult.OK)
                        {
                            changedCalculationDate = window.Value;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время редактирования даты расчет-корректировки: ", exc);
                return false;
            }
        }

        /// <summary>
        /// Печатает в фоне документы
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var param = (PrinterWorkerParameters)e.Argument;
                //WMSOffice.Data.Complaints ds = null;

                var docPackage = param.DocPackage;

                // Смена даты РК (если необходимо)
                var needChangeCalculationDate = param.ChangedCalculationDate.HasValue; // && doc.IsCalculation_DateNull();
                if (needChangeCalculationDate)
                {
                    taAsGetCalculations.ChangeCalculationDatePack(docPackage, sessionID, param.ChangedCalculationDate.Value);
                    //taAsGetCalculations.ChangeCalculationDate(sessionID, "00001", doc.Calculation_Type, doc.Calculation_Number, param.ChangedCalculationDate.Value);

                    needChangeCalculationDate = false;
                }

                foreach (var doc in param.DocsToPrint)
                {
                    //ds = PrepareDataForRKPrint(doc);
                    foreach (var kvp in GetCalculationReports("00001", doc.Calculation_Type, doc.Calculation_Number))
                    {
                        var report = kvp.Key;

                        try
                        {
                            // Пропускаем печать электронных док-тов
                            if (kvp.Value)
                                continue;

                            report.PrintOptions.PrinterName = param.PrinterName;
                            report.PrintToPrinter(1, false, 1, 0);
                        }
                        finally
                        {
                            report.Dispose();
                        }
                    }
                }

                e.Result = param;
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Создает отчет - расчет корректировку по ключевым данным (с 16.12.2011).
        /// </summary>
        /// <param name="kcoo">Идентификатор расчет-корректировки (KCOO).</param>
        /// <param name="dcto">Идентификатор расчет-корректировки (DCTO).</param>
        /// <param name="doco">Идентификатор расчет-корректировки (DOCO).</param>
        /// <returns>Отчет в виде расчет корректировки с загруженными из базы данными.</returns>
        private Dictionary<ReportClass, bool> GetCalculationReports(string kcoo, string dcto, double doco)
        {
            Dictionary<ReportClass, bool> result = new Dictionary<ReportClass, bool>();

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

                // создание и возврат отчетов
                foreach (Data.Complaints.ReportCalculationHeaderRow headerRow in headersTable.Rows)
                {
                    // Электронная
                    var isElectronicInvoice = (headerRow.MarkEV01 == 0);
                    if (isElectronicInvoice)
                        headerRow.TaxInvoiceMarkEDI = "X";

                    Data.Complaints tmpCalculationData = new Data.Complaints();

                    if (!isElectronicInvoice)
                    {
                        if (detailsTable.Rows.Count == 0)
                        {
                            using (Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter adapterDetail = new Data.ComplaintsTableAdapters.ReportCalculationDetailTableAdapter())
                            {
                                adapterDetail.SetTimeout((int)TimeSpan.FromMinutes(15).TotalSeconds);
                                adapterDetail.Fill(detailsTable, kcoo, dcto, doco, headerRow.InvoiceNumber);
                            }
                            tmpCalculationData.ReportCalculationDetail.Merge(detailsTable);
                        }

                        Data.Complaints.ReportCalculationHeaderRow tmpRow = tmpCalculationData.ReportCalculationHeader.NewReportCalculationHeaderRow();
                        object[] tmpItemArray = (object[])headerRow.ItemArray.Clone();
                        if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                            Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                        tmpRow.ItemArray = tmpItemArray;
                        tmpCalculationData.ReportCalculationHeader.AddReportCalculationHeaderRow(tmpRow);
                    }

                    ReportClass report = null;

                    if (headerRow.CalcDate >= new DateTime(2015, 1, 1))
                        report = new Reports.ComplaintCalculationReport_Since_01_2015();
                    else if (headerRow.CalcDate >= new DateTime(2014, 12, 1))
                        report = new Reports.ComplaintCalculationReport_Since_07_2014();
                    else if (headerRow.CalcDate >= new DateTime(2014, 3, 1))
                        report = new Reports.ComplaintCalculationReport_Since_01_2014();
                    else if (headerRow.CalcDate < new DateTime(2014, 3, 1))
                        report = new Reports.ComplaintCalculationReport();

                    if (!isElectronicInvoice)
                        report.SetDataSource(tmpCalculationData);

                    result.Add(report, isElectronicInvoice);
                }
            }

            return result;
        }
        /*
        /// <summary>
        /// Подготовка данных для печати расчет-корректировки
        /// </summary>
        /// <param name="pDoc">Документ, по которому получаем данные</param>
        /// <returns>DataSet з заполненными таблицами для печати расчет-корректировки</returns>
        private WMSOffice.Data.Complaints PrepareDataForRKPrint(WMSOffice.Data.WH.AS_Get_CalculationsRow pDoc)
        {
            try
            {
                var ds = new WMSOffice.Data.Complaints();
                using (var adapter = new ReportCalculationHeaderTableAdapter())
                    adapter.Fill(ds.ReportCalculationHeader, "00001", pDoc.Calculation_Type, pDoc.Calculation_Number);

                using (var adapter = new ReportCalculationDetailTableAdapter())
                    adapter.Fill(ds.ReportCalculationDetail, "00001", pDoc.Calculation_Type,
                        pDoc.Calculation_Number, pDoc.Doc_Number.ToString());

                return ds;
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось получить данные для электронной возвратной накладной: " + Environment.NewLine + exc.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }*/

        /// <summary>
        /// Обработка окончания печати документов
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show("Возникла ошибка во время печати расчет-корректировок: " + 
                    Environment.NewLine + (e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            RefreshRKs();
        }

        #endregion

        #region КЛАСС ПАРАМЕТРОВ ПЕЧАТИ

        /// <summary>
        /// Класс, содержащий параметры для печати расчет-корректировок
        /// </summary>
        private class PrinterWorkerParameters
        {
            /// <summary>
            /// Список расчет-корректировок, которые нужно распечатать
            /// </summary>
            public List<WMSOffice.Data.WH.AS_Get_CalculationsRow> DocsToPrint { get { return docsToPrint; } }

            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }

            /// <summary>
            /// Измененная дата РК
            /// </summary>
            public DateTime? ChangedCalculationDate { get; set; }

            /// <summary>
            /// Список расчет-корректировок, которые нужно распечатать
            /// </summary>
            private List<WMSOffice.Data.WH.AS_Get_CalculationsRow> docsToPrint = new List<WMSOffice.Data.WH.AS_Get_CalculationsRow>();

            /// <summary>
            /// XML с параметрами пакета документов для печати
            /// </summary>
            public string DocPackage { get; set; }
        }

        #endregion
    }
}
