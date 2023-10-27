using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

using CrystalDecisions.Shared;

using WMSOffice.Classes;
using WMSOffice.Classes.SearchParameters;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Reports;
using System.ComponentModel;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.Drawing;
using System.Net.Mail;
using System.Drawing.Printing;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Окно для экспорта заявок на уничтожение в Excel
    /// </summary>
    public partial class WhExportDestructionRequestsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Название таблицы с заявками на уничтожение в конфигурационном файле с настройками
        /// </summary>
        private string ConfigDocsTableName { get { return String.Format("{0}_Docs", Name); } }

        /// <summary>
        /// Заявки на уничтожение, выделенные в таблице
        /// </summary>
        private List<Data.WH.WF_Get_Destruction_RequestsRow> SelectedDocs
        {
            get
            {
                var list = new List<Data.WH.WF_Get_Destruction_RequestsRow>();
                foreach (var dgRow in dgvDestructionRequest.SelectedItems)
                    list.Add(dgRow as Data.WH.WF_Get_Destruction_RequestsRow);

                return list;
            }
        }

        public class DocsComparer : IComparer<Data.WH.WF_Get_Destruction_RequestsRow>
        {
            #region IComparer<WF_Get_Destruction_RequestsRow> Members

            public int Compare(WMSOffice.Data.WH.WF_Get_Destruction_RequestsRow x, WMSOffice.Data.WH.WF_Get_Destruction_RequestsRow y)
            {
                return x.request_number.CompareTo(y.request_number);
            }

            #endregion
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public WhExportDestructionRequestsForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            InitializeDestructionRequestsGrid();
        }

        /// <summary>
        /// Начальная инициализация фильтруемого грида с заявками на уничтожение при создании окна
        /// </summary>
        private void InitializeDestructionRequestsGrid()
        {
            dgvDestructionRequest.Init(new DestructionRequestsView(), true);
            dgvDestructionRequest.LoadExtraDataGridViewSettings(ConfigDocsTableName);
            dgvDestructionRequest.UserID = sessionID;
            dgvDestructionRequest.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvDestructionRequest.AllowRangeColumns = true;
            dgvDestructionRequest.UseMultiSelectMode = true;
            dgvDestructionRequest.RowHeadersVisible = false;
            dgvDestructionRequest.AllowSummary = false;

            dgvDestructionRequest.OnRowSelectionChanged += dgvDestructionRequests_OnRowSelectionChanged;
        }

        /// <summary>
        /// Загрузка заявок на списание при загрузке окна
        /// </summary>
        private void WhExportDestructionRequestsForm_Load(object sender, EventArgs e)
        {
            
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            RefreshPrintTypes();
            RefreshRequests();
        }

        /// <summary>
        /// Обновление статусов кнопок при изменении выделенных заявок на уничтожение
        /// </summary>
        private void dgvDestructionRequests_OnRowSelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок на панели управления в зависимости от выделенных заявок на уничтожение
        /// </summary>
        private void CustomButtons()
        {
            var isEnabled = SelectedDocs.Count > 0;

            btnExportToPdf.Enabled = miExportToPdf.Enabled = isEnabled;
            btnConsolidExportToExcel.Enabled = isEnabled;
            btnSendWithRegistry.Enabled = isEnabled;
        }

        /// <summary>
        /// Загрузка типов заявок на уничтожение
        /// </summary>
        private void RefreshPrintTypes()
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.WF_Destruction_Requests_TypesTableAdapter())
                    adapter.Fill(wh.WF_Destruction_Requests_Types);

                var bs = new BindingSource(wh, "WF_Destruction_Requests_Types");
                cmbPrintedFilter.ComboBox.DataSource = bs;
                cmbPrintedFilter.ComboBox.DisplayMember = "TypeName";
                cmbPrintedFilter.ComboBox.ValueMember = "TypeID";

                cmbPrintedFilter.SelectedIndexChanged -= cmbPrintedFilter_SelectedIndexChanged;
                cmbPrintedFilter.SelectedIndexChanged += cmbPrintedFilter_SelectedIndexChanged;     

            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Не удалось загрузить список типов заявок на уничтожение!", ex);
            }
        }

        /// <summary>
        /// Загрузка данных в таблицу с заявками на уничтожение
        /// </summary>
        private void RefreshRequests()
        {
            var typeID = ((cmbPrintedFilter.ComboBox.SelectedItem as DataRowView).Row as Data.WH.WF_Destruction_Requests_TypesRow).TypeID;

            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += (s, e) =>
            {
                try
                {
                    
                    dgvDestructionRequest.DataView.FillData(new WhDirectioRequestsSearchParameters
                    {
                        SessionID = sessionID,
                        FilterTypeID = typeID
                    });
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += (s, e) =>
            {
                waitProgressForm.CloseForce();

                if (e.Result is Exception)
                    Logger.ShowErrorMessageBox("Не удалось загрузить список заявок на уничтожение!", e.Result as Exception);
                else
                {
                    dgvDestructionRequest.BindData(false);
                    CustomButtons();
                }
            };
            
            waitProgressForm.ActionText = "Выполняется получение заявок на уничтожение..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Сохранение настроек грида при закрытии окна
        /// </summary>
        private void hExportDestructionRequestsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dgvDestructionRequest.SaveExtraDataGridViewSettings(ConfigDocsTableName);
        }

        /// <summary>
        /// Изменился фильтр - перезагружаем заявки на уничтожение
        /// </summary>
        private void cmbPrintedFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshRequests();
        }

        #endregion

        #region ЭКСПОРТ ВЫБРАННЫХ ЗАЯВОК НА УНИЧТОЖЕНИЕ
        private SplashForm newWaitProcessForm = new SplashForm();

        /// <summary>
        /// Экспорт выбранных заявок на уничтожение в PDF
        /// </summary>
        private void btnExportToPdf_Click(object sender, EventArgs e)
        {
            BackgroundWorker pastePartlyWorker = new BackgroundWorker();
            pastePartlyWorker.DoWork += new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
            pastePartlyWorker.WorkerReportsProgress = true;
            newWaitProcessForm.ActionText = "Подготовка данных...";
            pastePartlyWorker.RunWorkerAsync("PDF");
            newWaitProcessForm.ShowDialog();

            pastePartlyWorker.DoWork -= new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);

            //try
            //{
            //    string dir = GetDirectory();

            //    using (var adapter = new WF_GetDestructionInformationTableAdapter())
            //        foreach (var req in SelectedDocs)
            //        {
            //            adapter.SetTimeout(600);
            //            adapter.FillByDestRequest(wh.WF_GetDestructionInformation, sessionID, req.request_number);
            //            string[] headers = new string[] { "Код товара", "Наименование товара", "Основное вещество", "номер гос. рег.",
            //                "ед.\nизм.", "кол-во на\nскладе", "Серия", "Срок\nгодности", "Причина уничтожения", "Производитель", 
            //                "Страна\nпроисхождения", "Вес на\nскладе, кг", "Фармгруппа", "Название фармгруппы", "кол-во в\nящике",
            //                "Дата последнего\nпоступления", "№ макета\nсписания", "№ акта ОМУ" };
            //            string[] columnNames = new string[] { "Item_ID", "Item_Name", "Basic_Substance", "Registration_Number",
            //                "UOM", "Quantity", "Vendor_Lot", "Expiration_Date", "Cause_Destruction", "Manufacturer", 
            //                "Origin_Country", "Weight", "Farm_Group", "Farm_Group_Name", "Qty_In_Box",
            //                "Last_Receipt_Date", "Act_ID", "OMU_Act_ID" };
            //            AddTotalWeightValue(wh.WF_GetDestructionInformation);
            //            string message = ExportHelper.ExportDataTableToExcelFile(dir + "\\" + req.description + ".csv",
            //                wh.WF_GetDestructionInformation, headers, columnNames);
            //            if (!String.IsNullOrEmpty(message))
            //                throw new ApplicationException(message);
            //            adapter.SetPrinted(sessionID, req.request_number);
            //        }
            //    MessageBox.Show("Заявки на уничтожение были экспортированы в папку " + dir, "Экспорт заявок",
            //        MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception exc)
            //{
            //    Logger.ShowErrorMessageBox("Произошла ошибка во время экспорта в PDF заявок на уничтожение: ", exc);
            //}

        }

        /// <summary>
        /// Экспорт выбранных заявок на уничтожение в Excel
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            BackgroundWorker pastePartlyWorker = new BackgroundWorker();
            pastePartlyWorker.DoWork += new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
            pastePartlyWorker.WorkerReportsProgress = true;
            newWaitProcessForm.ActionText = "Подготовка данных...";
            pastePartlyWorker.RunWorkerAsync("XLS");
            newWaitProcessForm.ShowDialog();

            pastePartlyWorker.DoWork -= new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);

        }


        private delegate void GetdataForExport(ReportClass pReport, string description, ExportFormatType format);
        private GetdataForExport exportMethod;

        private void InitDataForExport(ReportClass pReport, string description, ExportFormatType format)
        {
            try
            {

                string message = ExportHelper.ExportCrystalReport(pReport, format,
                            "Заявка на уничтожение", description, true);
                if (!String.IsNullOrEmpty(message))
                    throw new ApplicationException(message);

            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Произошла ошибка во время экспорта в PDF заявок на уничтожение: ", exc);
            }
            finally
            {
                RefreshRequests();
            }
        }

        private class ExportToExcelResult { public string FilePath { get; set; } public string RootDir { get; set; } }
        private delegate ExportToExcelResult ExportDestructionToExcelDelegate(string description, string rootDir);
        private delegate ExportToExcelResult ExportDestructionRegistryToExcelDelegate(string description, string rootDir, IEnumerable<DestructionRegistryItem> items);
        private delegate void CreateDestructionOutlookDocumentDelegate(DestructionRegistryItem registryDoc, List<DestructionRegistryItem> completedDocs);
        private ExportDestructionToExcelDelegate exExcelDestruction;
        private ExportDestructionRegistryToExcelDelegate exExcelDestructionRegistry;
        private CreateDestructionOutlookDocumentDelegate createDestructionOutlookDocument;
        
        private ExportToExcelResult ExportDestructionReportToExcel(string description, string rootDir)
        {
            try
            {
                rootDir = !string.IsNullOrEmpty(rootDir) ? rootDir : GetDirectory();
                if (rootDir == string.Empty)
                {
                    MessageBox.Show("Вы отменили последнее действие.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return null;
                }

                MemoryStream stream = new MemoryStream(Properties.Resources.WF_DestructionTemp);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                var sheet = templateWorkbook.GetSheet("Лист1");

                var fontBold = templateWorkbook.CreateFont();
                fontBold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                var format = templateWorkbook.CreateDataFormat();

                var numericFormat = format.GetFormat("#,##0.00");
                var numericStyle = templateWorkbook.CreateCellStyle();
                numericStyle.DataFormat = numericFormat;

                var numericStyleBold = templateWorkbook.CreateCellStyle();
                numericStyleBold.DataFormat = numericFormat;
                numericStyleBold.SetFont(fontBold);

                ICell cell = null;

                var total = 0.0f;
                int rowNum = 1;

                foreach (Data.WH.WF_GetDestructionInformationRow item in wh.WF_GetDestructionInformation)
                {
                    try
                    {
                        IRow row = sheet.CreateRow(rowNum);

                        row.CreateCell(0).SetCellValue(item.IsItem_IDNull() ? string.Empty : item.Item_ID.ToString());
                        row.CreateCell(1).SetCellValue(item.IsItem_NameNull() ? string.Empty : item.Item_Name);

                        cell = row.CreateCell(2);
                        if (!item.IsQuantityNull())
                            cell.SetCellValue(item.Quantity);

                        row.CreateCell(3).SetCellValue(item.IsVendor_LotNull() ? string.Empty : item.Vendor_Lot);
                        row.CreateCell(4).SetCellValue(item.IsExpiration_DateNull() ? string.Empty : item.Expiration_Date);
                        row.CreateCell(5).SetCellValue(item.IsManufacturerNull() ? string.Empty : item.Manufacturer);

                        cell = row.CreateCell(6);
                        if (!item.IsAct_IDNull())
                            cell.SetCellValue(item.Act_ID);

                        cell = row.CreateCell(7);
                        cell.CellStyle = numericStyle;
                        if (!item.IsWeightNull())
                            cell.SetCellValue(item.Weight);

                        row.CreateCell(8).SetCellValue(item.IsUOMNull() ? string.Empty : item.UOM);

                        row.CreateCell(9).SetCellValue(item.IsRegistration_NumberNull() ? string.Empty : item.Registration_Number);
                        row.CreateCell(10).SetCellValue(item.IsCause_DestructionNull() ? string.Empty : item.Cause_Destruction);
                        row.CreateCell(11).SetCellValue(item.IsOrigin_CountryNull() ? string.Empty : item.Origin_Country);
                        row.CreateCell(12).SetCellValue(item.IsBasic_SubstanceNull() ? string.Empty : item.Basic_Substance);
                        row.CreateCell(13).SetCellValue(item.IsFarm_GroupNull() ? string.Empty : item.Farm_Group);
                        row.CreateCell(14).SetCellValue(item.IsFarm_Group_NameNull() ? string.Empty : item.Farm_Group_Name);

                        cell = row.CreateCell(15);
                        if (!item.IsQty_In_BoxNull())
                            cell.SetCellValue(item.Qty_In_Box);

                        row.CreateCell(16).SetCellValue(item.IsLast_Receipt_DateNull() ? string.Empty : item.Last_Receipt_Date);
                        row.CreateCell(17).SetCellValue(item.IsOMU_Act_IDNull() ? string.Empty : item.OMU_Act_ID);
                        row.CreateCell(18).SetCellValue(item.IsPrescriptionNull() ? string.Empty : item.Prescription);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                IRow rowSum = sheet.CreateRow(rowNum);

                cell = rowSum.CreateCell(6);
                cell.SetCellValue("Общий вес, кг:");
                //cell.CellStyle.SetFont(fontBold);

                cell = rowSum.CreateCell(7);
                cell.SetCellFormula(String.Format("SUM(H2:H{0})", rowNum));
                //cell.SetCellValue(total);
                cell.CellStyle = numericStyleBold;

                for (int i = 0; i <= 18; i++)
                    sheet.AutoSizeColumn(i);

                description = description.Replace(@"\", "_").Replace(@"/", "_").Replace(@":", "_");

                var filePath = Path.Combine(rootDir, string.Format("{0}.xlsx", description));

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                return new ExportToExcelResult { FilePath = filePath, RootDir = rootDir };
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Произошла ошибка во время экспорта в Excel заявки на уничтожение: {0}", exc.Message));
            }
        }
        private ExportToExcelResult ExportDestructionRegistryReportToExcel(string description, string rootDir, IEnumerable<DestructionRegistryItem> items)
        {
            try
            {
                MemoryStream stream = new MemoryStream(Properties.Resources.WF_DestructionRegistryTemp);

                XSSFWorkbook templateWorkbook = new XSSFWorkbook(stream);
                var sheet = templateWorkbook.GetSheet("Лист1");

                var fontBold = templateWorkbook.CreateFont();
                fontBold.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.Bold;

                var format = templateWorkbook.CreateDataFormat();

                var numericFormat = format.GetFormat("#,##0.00");
                var numericStyle = templateWorkbook.CreateCellStyle();
                numericStyle.DataFormat = numericFormat;

                var numericStyleBold = templateWorkbook.CreateCellStyle();
                numericStyleBold.DataFormat = numericFormat;
                numericStyleBold.SetFont(fontBold);

                ICell cell = null;

                int rowNum = 1;

                foreach (var item in items)
                {
                    try
                    {
                        IRow row = sheet.CreateRow(rowNum);

                        row.CreateCell(0).SetCellValue(rowNum);
                        row.CreateCell(1).SetCellValue(item.Item.request_number);

                        cell = row.CreateCell(2);
                        cell.CellStyle = numericStyle;
                        cell.SetCellValue((double)item.Item.weight);

                        rowNum++;
                    }
                    catch (Exception ex)
                    {

                    }
                }

                IRow rowSum = sheet.CreateRow(rowNum);

                cell = rowSum.CreateCell(1);
                cell.SetCellValue("Итого:");
                //cell.CellStyle.SetFont(fontBold);

                cell = rowSum.CreateCell(2);
                cell.SetCellFormula(String.Format("SUM(C2:C{0})", rowNum));
                cell.CellStyle = numericStyleBold;

                for (int i = 0; i <= 6; i++)
                    sheet.AutoSizeColumn(i);

                description = description.Replace(@"\", "_").Replace(@"/", "_").Replace(@":", "_");

                var filePath = Path.Combine(rootDir, string.Format("{0}.xlsx", description));

                FileStream file = new FileStream(filePath, FileMode.Create);
                templateWorkbook.Write(file);

                file.Close();
                file.Dispose();

                stream.Close();
                stream.Dispose();

                return new ExportToExcelResult { FilePath = filePath, RootDir = rootDir };
            }
            catch (Exception exc)
            {
                throw new Exception(string.Format("Произошла ошибка во время экспорта в Excel реестра заявок на уничтожение: {0}", exc.Message));
            }
        }

        private Microsoft.Office.Interop.Outlook.MailItem oMsg = null;

        /// <summary>
        /// Автоматическое создание документа в Outlook
        /// </summary>
        /// <param name="registryPath"></param>
        /// <param name="completedDocs"></param>
        private void CreateDestructionOutlookDocument(DestructionRegistryItem registryDoc, List<DestructionRegistryItem> completedDocs)
        {
            try
            {
                oMsg = null;

                Microsoft.Office.Interop.Outlook.Application oApp = new Microsoft.Office.Interop.Outlook.Application();
                oMsg = (Microsoft.Office.Interop.Outlook.MailItem)oApp.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

                oMsg.Attachments.Add(registryDoc.FilePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, new FileInfo(registryDoc.FilePath).Name);

                var itemsSequence = DestructionRegistryItem.GetItemsIntervals(completedDocs);
                var subject = string.Format("Заявки к счёту № ... ({0})", itemsSequence);
                oMsg.Subject = subject.Substring(0, Math.Min(subject.Length, 255));

                foreach (var item in completedDocs)
                {
                    oMsg.Attachments.Add(item.FilePath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olByValue, 1, new FileInfo(item.FilePath).Name);
                }
               
                var tmpPath = Path.GetTempFileName();
                var logoPath = string.Format("{0}.png", tmpPath);
                File.Move(tmpPath, logoPath);
                File.WriteAllBytes(logoPath, (byte[])new ImageConverter().ConvertTo(Properties.Resources.logo, typeof(byte[])));
                var logo = oMsg.Attachments.Add(logoPath, Microsoft.Office.Interop.Outlook.OlAttachmentType.olEmbeddeditem, null, "");
                logo.PropertyAccessor.SetProperty("http://schemas.microsoft.com/mapi/proptag/0x3712001E", logoPath);

                oMsg.HTMLBody = string.Format(Properties.Resources.WF_EmailMessageDestruct, logoPath);
                oMsg.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;

                oMsg.To = "ruslantarkom@gmail.com;";
                oMsg.CC = "SRadkevich@optimapharm.ua;VKorsun@optimapharm.ua;";

                oMsg.Recipients.ResolveAll();

                oMsg.Display(false);

                _isSend = false;
                _csvCompletedDocs = DestructionRegistryItem.GetItemsSequence(completedDocs);

                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Send += new Microsoft.Office.Interop.Outlook.ItemEvents_10_SendEventHandler(ThisAddIn_Send);
                ((Microsoft.Office.Interop.Outlook.ItemEvents_10_Event)oMsg).Close += new Microsoft.Office.Interop.Outlook.ItemEvents_10_CloseEventHandler(ThisAddIn_Close);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Произошла ошибка во время формирования документа outlook заявок на уничтожение: {0}", ex.Message));
            }
        }

        bool _isSend = false;
        void ThisAddIn_Send(ref bool Cancel)
        {
            try
            {
                using (var adapter = new WF_Get_Destruction_RequestsTableAdapter())
                    adapter.PrintRequests(_csvCompletedDocs, sessionID);

                _isSend = true;               
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки заявок на уничтожение произошла ошибка: ", ex);
            }
        }

        void ThisAddIn_Close(ref bool Cancel)
        {
            try
            {
                if (_isSend)
                {
                    if (MessageBox.Show("Распечатать акты приема-передачи\r\nпо выбранным заявкам?", "Печать актов ПП", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        var printerName = new PrinterSettings().PrinterName;
                        this.PrintAcceptanceTransmissionReports(printerName);
                    }

                    MessageBox.Show("Обработка заявок завершена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ThreadSafeDelegate(() => { RefreshRequests(); });
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время отправки заявок на уничтожение произошла ошибка: ", ex);
            }
        }

        private void PrintAcceptanceTransmissionReports(string printerName)
        {
            var copies = 2;
            var docNumbers = _csvCompletedDocs.Split(new char[] { ',' },  StringSplitOptions.RemoveEmptyEntries);
            foreach (var docNumber in docNumbers)
            {
                using (var report = this.CreateAcceptanceTransmissionReport(Convert.ToInt32(docNumber)))
                {
                    report.PrintOptions.PrinterName = printerName;
                    report.PrintToPrinter(copies, true, 1, 0);
                }
            }
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private string _csvCompletedDocs = string.Empty; 

        #region ФОНОВАЯ ОПЕРАЦИЯ ЭКСПОРТА АКТОВ УТИЛИЗАЦИИ

        void pastePartlyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var actionText = newWaitProcessForm.ActionText;

                var selectedDocs = this.SelectedDocs;
                selectedDocs.Sort(new DocsComparer());

                var completedDocs = new List<DestructionRegistryItem>();

                var rootDir = e.Argument.Equals("MSG") ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) : string.Empty;

                var cntDocs = selectedDocs.Count;
                var cntCompletedDocs = 0;

                foreach (var req in selectedDocs)
                {
                    this.ThreadSafeDelegate(() =>
                    {
                        newWaitProcessForm.ActionText = string.Format("{0}\r\nОбработано документов: {1} из {2}.", actionText, cntCompletedDocs, cntDocs);
                    });

                    using (var adapter = new WF_GetDestructionInformationTableAdapter())
                    {
                        adapter.SetTimeout(600);
                        adapter.FillByDestRequest(wh.WF_GetDestructionInformation, sessionID, req.request_number);

                        if (e.Argument != null && (e.Argument.Equals("XLS") || e.Argument.Equals("MSG")))
                        {
                            var description = string.Format("Заявка № {0}, общий вес {1} кг {2}", req.request_number, Math.Round(req.weight, 2).ToString().Replace(",", "."), req.IsVendorNull() ? "" : string.Format("({0})", req.Vendor)).TrimEnd();

                            exExcelDestruction = new ExportDestructionToExcelDelegate(ExportDestructionReportToExcel);
                            var retExport = (ExportToExcelResult)Invoke(exExcelDestruction, description, rootDir);
                            if (retExport == null)
                                return;

                            rootDir = retExport.RootDir;

                            completedDocs.Add(new DestructionRegistryItem { Item = req, FilePath = retExport.FilePath });
                        }
                        else
                        {
                            var report = new WhDestructionRequestReport();
                            report.SetDataSource(wh);

                            ExportFormatType format = ExportFormatType.PortableDocFormat;

                            exportMethod = new GetdataForExport(InitDataForExport);
                            Invoke(exportMethod, report, req.description, format);
                        }
                    }

                    cntCompletedDocs++;
                }

                this.ThreadSafeDelegate(() =>
                {
                    newWaitProcessForm.ActionText = string.Format("{0}\r\nОбработано документов: {1} из {2}.", actionText, cntCompletedDocs, cntDocs);
                });
                System.Threading.Thread.Sleep(500);

                if (e.Argument != null && e.Argument.Equals("XLS"))
                {
                    MessageBox.Show("Заявки на уничтожение были экспортированы в папку " + rootDir, "Экспорт заявок", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (e.Argument != null && e.Argument.Equals("MSG"))
                {
                    this.ThreadSafeDelegate(() =>
                    {
                        newWaitProcessForm.ActionText = string.Format("{0}\r\nФормируется реестр.", actionText);
                    });

                    exExcelDestructionRegistry = new ExportDestructionRegistryToExcelDelegate(ExportDestructionRegistryReportToExcel);
                    var retExport = (ExportToExcelResult)Invoke(exExcelDestructionRegistry, "Реестр заявок", rootDir, completedDocs);
                    if (retExport == null)
                        throw new Exception("Реестр не был получен.");

                    var registryDoc = new DestructionRegistryItem { FilePath = retExport.FilePath };

                    createDestructionOutlookDocument = new CreateDestructionOutlookDocumentDelegate(CreateDestructionOutlookDocument);
                    Invoke(createDestructionOutlookDocument, registryDoc, completedDocs);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Произошла ошибка во время экспорта заявок на уничтожение: ", exc);
            }
        }

        void pastePartlyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            newWaitProcessForm.CloseForce();
        }

        public class DestructionRegistryItem
        {
            public Data.WH.WF_Get_Destruction_RequestsRow Item { get; set; }
            public string FilePath { get; set; }

            public static string GetItemsIntervals(List<DestructionRegistryItem> items)
            {
                var start = 0;
                var end = 0;
                var sbIntervals = new StringBuilder((start = end = items[0].Item.request_number).ToString());

                for (var i = 1; i < items.Count; i++)
                {
                    if (items[i].Item.request_number == end + 1)
                    {
                        end++;
                    }
                    else
                    {
                        if (start != end)
                            sbIntervals.AppendFormat("{0}{1}", end - start > 1 ? "-" : ", ", items[i - 1].Item.request_number);

                        sbIntervals.AppendFormat(", {0}", start = end = items[i].Item.request_number);
                    }
                }

                if (start != end)
                    sbIntervals.AppendFormat("{0}{1}", end - start > 1 ? "-" : ", ", items[items.Count - 1].Item.request_number);

                return sbIntervals.ToString();
            }

            public static string GetItemsSequence(List<DestructionRegistryItem> items)
            {
                var sbSequence = new StringBuilder();

                foreach (var item in items)
                    if (sbSequence.Length > 0)
                        sbSequence.AppendFormat(",{0}", item.Item.request_number);
                    else
                        sbSequence.AppendFormat("{0}", item.Item.request_number);

                return sbSequence.ToString();
            }
        }

        #endregion

        /// <summary>
        /// Отображение пользователю окна "Сохранение файла" для выбора места, куда экспортировать заявки на уничтожение
        /// </summary>
        /// <returns>Папка, в которую нужно экспортировать заявки на уничтожение</returns>
        private static string GetDirectory()
        {
            var dlg = new FolderBrowserDialog()
            {
                Description = "Выберите каталог для сохранения Excel-заявок",
                //AddExtension = true,
                //DefaultExt = "csv",
                RootFolder = Environment.SpecialFolder.MyDocuments
                //Filter = "Текстовый файл с разделителями (*.csv)|*.csv",
                //FilterIndex = 0
            };
            if (dlg.ShowDialog() == DialogResult.OK)
                return dlg.SelectedPath;
            else
                return String.Empty;
        }

        /// <summary>
        /// Добавляет строку с общим весом к данным по заявке на уничтожение
        /// </summary>
        /// <param name="pTable">Таблица с данными по заявке на уничтожение, куда нужно добавить строку с общим весом</param>
        [Obsolete]
        private static void AddTotalWeightValue(Data.WH.WF_GetDestructionInformationDataTable pTable)
        {
            double totalWeight = 0;
            foreach (Data.WH.WF_GetDestructionInformationRow row in pTable)
                totalWeight += row.Weight;
            var newRow = pTable.NewWF_GetDestructionInformationRow();
            newRow.Origin_Country = "Общий вес, кг:";
            newRow.Weight = totalWeight;
            //newRow.SetAct_IDNull();
            pTable.AddWF_GetDestructionInformationRow(newRow);
        }

        #endregion

        #region Метод печати акта према-передачи
        private void btnAcceptanceTransmission_Click(object sender, EventArgs e)
        {
            if (SelectedDocs.Count == 0)
                return;
            try
            {
                using (var report = this.CreateAcceptanceTransmissionReport(SelectedDocs[0].request_number))
                using (var reportForm = new ReportForm() { ShowInTaskbar = false })
                {
                    reportForm.ReportDocument = report;
                    reportForm.ShowDialog(this);

                    if (reportForm.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(sessionID, "WF", 19, Convert.ToInt64(SelectedDocs[0].request_number), (string)null, Convert.ToInt16(wh.WF_GetDestructionInformation.Count), reportForm.PrinterName, Convert.ToByte(reportForm.Copies));
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время просмотра акта приема-передачи: ", ex);
            }
        }

        private WHActAcceptanceTransmission CreateAcceptanceTransmissionReport(int requestNumber)
        {
            var report = new WHActAcceptanceTransmission();
            var ds = GetDataByActAccTrans(requestNumber);
            report.SetDataSource(ds);
            
            return report;    
        }

        private Data.WH GetDataByActAccTrans(int requestNumber)
        {
            var wh = new Data.WH();

            using (var adapter = new AAT_GetReportHeaderTableAdapter())
                adapter.Fill(wh.AAT_GetReportHeader, sessionID, requestNumber);

            using (var adapter = new WF_GetDestructionInformationTableAdapter())
                adapter.FillByDestRequest(wh.WF_GetDestructionInformation, sessionID, requestNumber);

            return wh;
        }
        #endregion

        private void btnConsolidExportExcel_Click(object sender, EventArgs e)
        {
            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += (s, ea) => 
            {
                try
                {
                    var requests = ea.Argument as List<Data.WH.WF_Get_Destruction_RequestsRow>;
                    var sbRequsts = new StringBuilder();
                    foreach (var req in requests)
                        sbRequsts.AppendFormat("{0},", req.request_number);

                    var sRequests = sbRequsts.ToString().TrimEnd(',');

                    using (var adapter = new WF_GetDestructionConsolidInformationTableAdapter())
                    {
                        adapter.SetTimeout(600);
                        adapter.Fill(wh.WF_GetDestructionConsolidInformation, sRequests);
                    }

                    if (wh.WF_GetDestructionConsolidInformation.Count == 0)
                        throw new Exception("По Вашему запросу не вернулись данные.");
                    
                    ea.Result = wh.WF_GetDestructionConsolidInformation;
                }
                catch (Exception ex)
                {
                    ea.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += (s, ea) => 
            {
                newWaitProcessForm.CloseForce();

                if (ea.Result is Exception)
                    MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.ExportConsolidReportToExcel(ea.Result as Data.WH.WF_GetDestructionConsolidInformationDataTable);
                }
            };

            newWaitProcessForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(this.SelectedDocs);
            newWaitProcessForm.ShowDialog();
        }

        private void ExportConsolidReportToExcel(Data.WH.WF_GetDestructionConsolidInformationDataTable report)
        {
            var message = ExportHelper.ExportDataTableToExcel(
                report,
                new string[] { "№ заявки", "Дата заявки", "Код товара", "Название товара", "Количество товара", "Вес", "№ макета списания" },
                new string[] { "Doc_ID", "Doc_Date", "Item_ID", "Item_Name", "Qty", "Weight", "Act_ID" },             
               "Экспорт заявок на утилизацию", "заявки на утилизацию", true);

            if (!String.IsNullOrEmpty(message))
                Logger.ShowErrorMessageBox(String.Format("Во время экспорта в Excel возникла ошибка:\n{0}", message));
        }

        private void btnSendWithRegistry_Click(object sender, EventArgs e)
        {
            BackgroundWorker pastePartlyWorker = new BackgroundWorker();
            pastePartlyWorker.DoWork += new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
            pastePartlyWorker.WorkerReportsProgress = true;
            newWaitProcessForm.ActionText = "Подготовка данных...";
            pastePartlyWorker.RunWorkerAsync("MSG");
            newWaitProcessForm.ShowDialog();

            pastePartlyWorker.DoWork -= new DoWorkEventHandler(pastePartlyWorker_DoWork);
            pastePartlyWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(pastePartlyWorker_RunWorkerCompleted);
        }

    }

    #region ПРЕДСТАВЛЕНИЕ ДЛЯ ГРИДА С ЗАЯВКАМИ НА УНИЧТОЖЕНИЕ

    /// <summary>
    /// Представление для грида с заявками на уничтожение
    /// </summary>
    public class DestructionRequestsView : IDataView
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
            var sc = pSearchParameters as WhDirectioRequestsSearchParameters;
            using (var adapter = new WF_Get_Destruction_RequestsTableAdapter())
                data = adapter.GetData(sc.SessionID, sc.All, sc.FilterTypeID);
        }

        public DestructionRequestsView()
        {
            this.dataColumns.Add(new PatternColumn("Номер", "request_number", new FilterCompareExpressionRule<Int32>("request_number"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Описание заявки", "description", new FilterPatternExpressionRule("description")) { Width = 600 });
            this.dataColumns.Add(new PatternColumn("Экспортирована", "is_printed_str", new FilterPatternExpressionRule("is_printed_str")) { Width = 100 });
        }
    }

    #endregion
}
