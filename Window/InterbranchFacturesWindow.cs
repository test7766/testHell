using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для поиска и печати межскладских накладных
    /// </summary>
    public partial class InterbranchFacturesWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Признак, показывающий, были ли накладные загружены из архива (т.е. их не нужно переводить по статусам после печати)
        /// </summary>
        private bool facturesFromArchive = false;

        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public InterbranchFacturesWindow()
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
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // загрузка списка накладных
            btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обновляет данные, загружая текущий список накладных (не распечатанных)
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BackgroundWorker loadFacturesWorker = new BackgroundWorker();
            loadFacturesWorker.DoWork += new DoWorkEventHandler(loadFacturesWorker_DoWork);
            loadFacturesWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadFacturesWorker_RunWorkerCompleted);
            LoadWorkerParameters parameters = new LoadWorkerParameters()
            {
                OrderType = null,
                OrderID = null,
                SenderID = null,
                ShipToID = null,
                DateFrom = null,
                DateTo = null,
                ArchiveFlag = false,
                Timeout = 60
            };

            facturesFromArchive = false;
            splashForm.ActionText = "Загрузка списка накладных...";
            loadFacturesWorker.RunWorkerAsync(parameters);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск в архиве"
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (Dialogs.InterBranch.SearchOptionsForm form = new Dialogs.InterBranch.SearchOptionsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    BackgroundWorker loadFacturesWorker = new BackgroundWorker();
                    loadFacturesWorker.DoWork += new DoWorkEventHandler(loadFacturesWorker_DoWork);
                    loadFacturesWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadFacturesWorker_RunWorkerCompleted);
                    LoadWorkerParameters parameters = new LoadWorkerParameters()
                    {
                        OrderType = form.OrderType,
                        OrderID = form.OrderID,
                        SenderID = form.SenderID,
                        ShipToID = form.ShipToID,
                        DateFrom = form.DateFrom,
                        DateTo = form.DateTo,
                        ArchiveFlag = true,
                        Timeout = 180
                    };

                    facturesFromArchive = true;
                    splashForm.ActionText = "Загрузка архивных накладных...";
                    loadFacturesWorker.RunWorkerAsync(parameters);
                    splashForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Загружает в фоне список накладных, используя параметры, переданные в аргументе
        /// </summary>
        private void loadFacturesWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadWorkerParameters parameters = (LoadWorkerParameters)e.Argument;
            try
            {
                Data.IBFactures currFactures = Data.IBFacturesTableAdapters.FacturesListTableAdapter.GetData(
                    parameters.OrderType,
                    parameters.OrderID,
                    parameters.SenderID,
                    parameters.ShipToID,
                    parameters.DateFrom,
                    parameters.DateTo,
                    parameters.ArchiveFlag,
                    UserID,
                    parameters.Timeout);
                iBFactures = currFactures;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка накладных
        /// </summary>
        private void loadFacturesWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                dgvFactures.DataSource = null;
            }
            else
            {
                dgvFactures.DataSource = iBFactures.FacturesList;
            }

            if (!facturesFromArchive)
            {
                lblDocsCount.Text = iBFactures.FacturesList.Rows.Count.ToString();
            }

            splashForm.CloseForce();
        } 

        /// <summary>
        /// Меняет доступность кнопок при смене выделения строк в таблице
        /// </summary>
        private void dgvFactures_SelectionChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = btnPrintPreview.Enabled = dgvFactures.SelectedRows.Count > 0;
        }

        private void cbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFactures.Focus();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать выбранные накладные"
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvFactures.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters() { PrinterName = (string)cbPrinters.SelectedItem };
                foreach (DataGridViewRow r in dgvFactures.Rows)
                {
                    if (r.Selected)
                    {
                        var br = (r.DataBoundItem as DataRowView).Row as Data.IBFactures.FacturesListRow;
                        
                        parameters.KCOOs.Add(br.IskcooNull() ? string.Empty : br.kcoo);
                        parameters.DCTOs.Add(br.IsdctoNull() ? string.Empty : br.dcto);
                        parameters.DOCOs.Add(br.IsdocoNull() ? 0 : br.doco);
                        parameters.ACTIDs.Add(br.Isneed_to_print_actNull() || br.need_to_print_act == long.MinValue ? (long?)null : br.need_to_print_act);
                        parameters.ACTTYPEs.Add(br.Isco_doc_typeNull() ? string.Empty : br.co_doc_type);
                        parameters.ActDocuments.Add(br.Isneed_to_print_act_NTV_placementNull() || br.need_to_print_act_NTV_placement == int.MinValue ? (int?)null : br.need_to_print_act_NTV_placement);

                        //parameters.KCOOs.Add((string)r.Cells[kcooDataGridViewTextBoxColumn.Name].Value);
                        //parameters.DCTOs.Add((string)r.Cells[dctoDataGridViewTextBoxColumn.Name].Value);
                        //parameters.DOCOs.Add((double)r.Cells[docoDataGridViewTextBoxColumn.Name].Value);
                    }
                }

                splashForm.ActionText = "Печать выбранных накладных...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                // Автообновление отключено по заявке [148423]
                //
                //// обновление списка накладных
                //btnRefresh_Click(this, EventArgs.Empty);

                // пометка напечатанных строк
                foreach (DataGridViewRow row in dgvFactures.Rows)
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
                foreach (DataGridViewRow row in dgvFactures.Rows)
                {
                    row.Selected = false;
                }
            }
        }

        /// <summary>
        /// Печатает в фоне выделенные накладные, используя их идентификаторы, переданные в аргументе
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters p = (PrintWorkerParameters)e.Argument;
                for (int i = 0; i < p.DOCOs.Count; ++i)
                {
                    // -> [GSPO-3826]
                    int cntMainReport = p.DCTOs[i] == "48" ? 3 : 2;
                    using (var report = GetIBFactureReport(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i], this.UserID))
                    {
                        report.PrintOptions.PrinterName = p.PrinterName;
                        report.PrintToPrinter(cntMainReport, true, 1, 0);

                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IF", 18, Convert.ToInt64(p.DOCOs[i]), p.DCTOs[i], Convert.ToInt16(0), p.PrinterName, Convert.ToByte(cntMainReport));
                    }

                    // Печать отключена по заявке [147375]
                    //
                    //// печать реестра приемки ЛС на межсклад
                    //using (Reports.InterbranchRegisterReport report = GetIBRegisterReport(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i]))
                    //{
                    //    report.PrintOptions.PrinterName = p.PrinterName;
                    //    //report.PrintOptions.PrinterDuplex = PrinterDuplex.Horizontal;
                    //    report.PrintOptions.PrinterDuplex = this.PrinterDuplexRegime;
                    //    report.PrintToPrinter(1, true, 1, 0);
                    //}

                    // Есть акт приема-передачи
                    if (p.ACTIDs[i].HasValue)
                    {
                        // печать акта приема-передачи
                        using (var report = GetComplaintActReport(p.KCOOs[i], p.ACTTYPEs[i], p.ACTIDs[i].Value))
                        {
                            report.PrintOptions.PrinterName = p.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IF", 19, Convert.ToInt64(p.ACTIDs[i]), p.ACTTYPEs[i], Convert.ToInt16(0), p.PrinterName, Convert.ToByte(1));
                        }
                    }

                    // Есть акт приема-передачи по документу
                    if (p.ActDocuments[i].HasValue)
                    {
                        // печать акта по документу
                        using (var report = GetDocumentActReport(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i]))
                        {
                            report.PrintOptions.PrinterName = p.PrinterName;
                            report.PrintToPrinter(1, true, 1, 0);

                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IF", 4, Convert.ToInt64(p.DOCOs[i]), p.DCTOs[i], Convert.ToInt16(0), p.PrinterName, Convert.ToByte(1));
                        }
                    }

                    // подтверждение печати
                    if (!facturesFromArchive)
                    {
                        Data.IBFacturesTableAdapters.FacturesListTableAdapter.UpdateFactureStatus(p.KCOOs[i], p.DCTOs[i], p.DOCOs[i], this.UserID);
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание печати накладных в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Предварительный просмотр"
        /// </summary>
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgvFactures.SelectedRows.Count > 0)
            {
                using (var report = GetIBFactureReport(
                    (string)dgvFactures.SelectedRows[0].Cells[kcooDataGridViewTextBoxColumn.Name].Value,
                    (string)dgvFactures.SelectedRows[0].Cells[dctoDataGridViewTextBoxColumn.Name].Value,
                    (double)dgvFactures.SelectedRows[0].Cells[docoDataGridViewTextBoxColumn.Name].Value,
                    this.UserID))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IF", 18, Convert.ToInt64((double)dgvFactures.SelectedRows[0].Cells[docoDataGridViewTextBoxColumn.Name].Value), (string)dgvFactures.SelectedRows[0].Cells[dctoDataGridViewTextBoxColumn.Name].Value, Convert.ToInt16(0), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотр реестра".
        /// </summary>
        private void btnRegisterPreview_Click(object sender, EventArgs e)
        {
            if (dgvFactures.SelectedRows.Count > 0)
            {
                using (Reports.InterbranchRegisterReport report = GetIBRegisterReport(
                    (string)dgvFactures.SelectedRows[0].Cells[kcooDataGridViewTextBoxColumn.Name].Value,
                    (string)dgvFactures.SelectedRows[0].Cells[dctoDataGridViewTextBoxColumn.Name].Value,
                    (double)dgvFactures.SelectedRows[0].Cells[docoDataGridViewTextBoxColumn.Name].Value))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "IF", 13, Convert.ToInt64((double)dgvFactures.SelectedRows[0].Cells[docoDataGridViewTextBoxColumn.Name].Value), (string)dgvFactures.SelectedRows[0].Cells[dctoDataGridViewTextBoxColumn.Name].Value, Convert.ToInt16(0), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Создает отчет-накладную по ключевым данным
        /// </summary>
        /// <param name="kcoo">Код компании</param>
        /// <param name="dcto">Тип документа</param>
        /// <param name="doco">Номер документа</param>
        /// <returns>Отчет в виде накладной с загруженными из базы данными</returns>
        public static CrystalDecisions.CrystalReports.Engine.ReportClass GetIBFactureReport(string kcoo, string dcto, double doco, long userID)
        {
            // загрузка детальных данных по накладной
            Data.IBFactures facture = Data.IBFacturesTableAdapters.FacturesDetailsTableAdapter.GetData(kcoo, dcto, doco);

            // подготовка штрих-кода
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (BarcodeLib.Barcode b = new BarcodeLib.Barcode())
                {
                    b.Encode(
                        BarcodeLib.TYPE.CODE128B, facture.FactureHeader[0].BarCode,
                        1400,
                        100).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }
                facture.FactureHeader[0].BarCodeImage = ms.ToArray();
            }

            var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(userID, "IF", 18, Convert.ToInt64(doco), dcto);

            var report = InterbranchFacturesWindow.GetIBFactureReport(facture, needPrintWatermark);
            return report;
        }

        private static CrystalDecisions.CrystalReports.Engine.ReportClass GetIBFactureReport(Data.IBFactures facture, bool needPrintWatermark)
        {
            CrystalDecisions.CrystalReports.Engine.ReportClass report = facture.FactureHeader[0].InvoiceFormType == 1 ? (CrystalDecisions.CrystalReports.Engine.ReportClass)new WMSOffice.Reports.InterbranchFactureReportEx() : (CrystalDecisions.CrystalReports.Engine.ReportClass)new WMSOffice.Reports.InterbranchFactureReport();
            report.SetDataSource(facture);
            report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);
            return report;
        }

        /// <summary>
        /// Создает отчет - реестр лек. средств ключевым данным.
        /// </summary>
        /// <param name="kcoo">Код компании.</param>
        /// <param name="dcto">Тип документа.</param>
        /// <param name="doco">Номер документа.</param>
        /// <returns>Отчет в виде реестра лекарственных средств с загруженными из базы данными.</returns>
        private Reports.InterbranchRegisterReport GetIBRegisterReport(string kcoo, string dcto, double doco)
        {
            // загрузка детальных данных
            Data.IBFactures registerDetails = Data.IBFacturesTableAdapters.RegisterDetailsTableAdapter.GetData(kcoo, dcto, doco);

            this.PrinterDuplexRegime = this.GetPrinterDuplexRegime(registerDetails);

            // создание и возврат отчета
            Reports.InterbranchRegisterReport report = new WMSOffice.Reports.InterbranchRegisterReport();
            report.SetDataSource(registerDetails);
            return report;
        }

        /// <summary>
        /// Создает отчет - акт приема-передачи.
        /// </summary>
        /// <param name="kcoo">Код компании.</param>
        /// <param name="dcto">Тип документа.</param>
        /// <param name="doco">Номер документа.</param>
        /// <returns>Отчет в виде акта приема-передачи с загруженными из базы данными.</returns>
        private CrystalDecisions.CrystalReports.Engine.ReportClass GetComplaintActReport(string kcoo, string dcto, double doco)
        {
            var reportProvider = new WMSOffice.Classes.ReportProviders.ComplaintsActReportProvider(UserID, WMSOffice.Classes.ReportProviders.ComplaintActsReportProviderMode.ByComplaint);

            var docs = new Data.Complaints.CurrentDocsDataTable();
            var row = docs.NewCurrentDocsRow();
            row.Doc_ID = (long)doco;
            row.Doc_Type = dcto;
            row.Status_ID = string.Empty;
            row.Warehouse_ID = string.Empty;
            row.Source_Address_Code = 0;
            row.Session_ID_Created = 0;
            row.Date_Created = DateTime.Today;

            docs.AddCurrentDocsRow(row);

            return reportProvider.GetReport(docs[0]);
        }

        /// <summary>
        /// Создает отчет - акт приема-передачи по документу.
        /// </summary>
        /// <param name="kcoo">Код компании.</param>
        /// <param name="dcto">Тип документа.</param>
        /// <param name="doco">Номер документа.</param>
        /// <returns>Отчет в виде акта приема-передачи с загруженными из базы данными.</returns>
        private CrystalDecisions.CrystalReports.Engine.ReportClass GetDocumentActReport(string kcoo, string dcto, double doco)
        {
            var reportProvider = new WMSOffice.Classes.ReportProviders.ComplaintsActReportProvider(UserID, WMSOffice.Classes.ReportProviders.ComplaintActsReportProviderMode.ByDocument);

            var docRequisites = new WMSOffice.Classes.ReportProviders.DocRequisites
            {
                KCOO = kcoo,
                DCTO = dcto,
                DOCO = (long)doco
            };

            return reportProvider.GetReport(docRequisites);
        }

        /// <summary>
        /// Режим печати
        /// </summary>
        private PrinterDuplex PrinterDuplexRegime { get; set; }

        /// <summary>
        /// Анализ печати в дуплексном режиме
        /// </summary>
        /// <param name="registerDetails"></param>
        /// <returns></returns>
        private PrinterDuplex GetPrinterDuplexRegime(Data.IBFactures registerDetails)
        {
            if (registerDetails.Register.Rows.Count > 10)
                return PrinterDuplex.Horizontal;
            else
                return PrinterDuplex.Simplex;
        }


        #region LoadWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для загрузки накладных
        /// </summary>
        private class LoadWorkerParameters
        {
            /// <summary>
            /// Тип заказа
            /// </summary>
            public string OrderType { get; set; }
            /// <summary>
            /// Идентификатор заказа
            /// </summary>
            public double? OrderID { get; set; }
            /// <summary>
            /// Код отправителя
            /// </summary>
            public int? SenderID { get; set; }
            /// <summary>
            /// Код получателя
            /// </summary>
            public int? ShipToID { get; set; }
            /// <summary>
            /// Дата (с)
            /// </summary>
            public DateTime? DateFrom { get; set; }
            /// <summary>
            /// Дата (по)
            /// </summary>
            public DateTime? DateTo { get; set; }
            /// <summary>
            /// Признак, показывающий, нужно ли загружать данные из архива
            /// </summary>
            public bool ArchiveFlag { get; set; }
            /// <summary>
            /// Тайм-аут для выполнения запроса
            /// </summary>
            public int Timeout { get; set; }
        }

        #endregion


        #region PrintWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для загрузки накладных
        /// </summary>
        private class PrintWorkerParameters
        {
            private List<string> kcoos = new List<string>();
            private List<string> dctos = new List<string>();
            private List<double> docos = new List<double>();
            private List<long?> actids = new List<long?>();
            private List<string> acttypes = new List<string>();
            private List<int?> actdocuments = new List<int?>();

            /// <summary>
            /// Коды компаний
            /// </summary>
            public List<string> KCOOs { get { return kcoos; } }
            /// <summary>
            /// Типы документов
            /// </summary>
            public List<string> DCTOs { get { return dctos; } }
            /// <summary>
            /// Номера документов
            /// </summary>
            public List<double> DOCOs { get { return docos; } }
            /// <summary>
            /// Признаки печати актов приема-передачи
            /// </summary>
            public List<long?> ACTIDs { get { return actids; } }
            /// <summary>
            /// Тип претензии для печати актов приема-передачи
            /// </summary>
            public List<string> ACTTYPEs { get { return acttypes; } }
            /// <summary>
            /// Признаки печати актов по документам
            /// </summary>
            public List<int?> ActDocuments { get { return actdocuments; } }
            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion
    }
}
