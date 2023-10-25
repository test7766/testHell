using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Classes.ReportProviders;
using WMSOffice.Data;
using WMSOffice.Data.InterbranchTableAdapters;
using WMSOffice.Reports;
using WMSOffice.Dialogs;
using WMSOffice.Controls;
using WMSOffice.Controls.EBW;
using System.ComponentModel;
using WMSOffice.Classes.ReportProviders.DebtorsReturnedTareInvoice;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class WHDocsControlWindow : GeneralWindow
    {
        private readonly ResourceContext resourceContext = new ResourceContext();

        public WHDocsControlWindow()
        {
            InitializeComponent();
        }

        private void WHDocsControlWindow_Load(object sender, EventArgs e)
        {
            this.wH.Statuses.Clear();
            this.wH.Statuses.AddStatusesRow("-", "(все)");
            this.wH.Statuses.Merge(this.statusesTableAdapter.GetData());
            dateFrom.Value = dateTo.Value = DateTime.Today;

            this.CanCancelDoc();

            // TODO: Позже можно удалить
            InitPrintControls();

            scDocDetails.Panel2Collapsed = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            stbSupplierCode.ValueReferenceQuery = "[dbo].[pr_WHAdmin_Get_Supplier_List]";
            stbSupplierCode.UserID = this.UserID;
            stbSupplierCode.OnVerifyValue += delegate(object snd, WMSOffice.Controls.VerifyValueArgs ea)
            {
                var control = snd as SearchTextBox;
                Label lblDescription = null;

                if (control == stbSupplierCode)
                    lblDescription = lblSupplierName;

                if (lblDescription != null)
                {
                    lblDescription.Text = ea.Success ? ea.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                    lblDescription.ForeColor = ea.Success ? SystemColors.ControlText : Color.Red;

                    if (ea.Success)
                        control.Value = ea.Value;
                    //else
                    //    control.Value = string.Empty;
                }
            };
        }

        /// <summary>
        /// Проверка доступности опции аннулирования документа
        /// </summary>
        private void CanCancelDoc()
        {
            try
            {
                var result = (long?)null;
                docsControlTableAdapter.CanCancelDoc(this.UserID, ref result);

                btnDelete.Visible = btnDelete.Enabled = result.HasValue && result.Value == 1;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        private void RefreshDocs()
        {
            // сохранение текущей позиции
            Data.WH.DocsControlRow curDoc = CurrentDoc;
            long selDocID = 0;
            int rowIndex = 0;
            if (curDoc != null) {
                selDocID = curDoc.Doc_ID;
                rowIndex = gvDocs.FirstDisplayedScrollingRowIndex;
            }

            #region обновление данных

            int doc = 0;
            if (!String.IsNullOrEmpty(tbDoc.Text)) int.TryParse(tbDoc.Text, out doc);

            var docID = (doc == 0) ? null : (int?)doc;
            var docType = String.IsNullOrEmpty(tbDocType.Text) ? null : tbDocType.Text;
            var statusID = (cbStatus.SelectedValue == null || (string)cbStatus.SelectedValue == "-") ? null : (string)cbStatus.SelectedValue;
            var dateFromV = dateFrom.Value;
            var dateToV = dateTo.Value;
            var employee = String.IsNullOrEmpty(tbEmployee.Text) ? null : tbEmployee.Text;
            var itemCode = String.IsNullOrEmpty(tbItemCode.Text) ? (int?)null : Convert.ToInt32(tbItemCode.Text);
            var boxCode = String.IsNullOrEmpty(tbBoxCode.Text) ? null : tbBoxCode.Text;
            var supplierCode = String.IsNullOrEmpty(stbSupplierCode.Value) ? (int?)null : Convert.ToInt32(stbSupplierCode.Value);
            var deliveryID = String.IsNullOrEmpty(tbDeliveryID.Text) ? (int?)null : Convert.ToInt32(tbDeliveryID.Text);

            var ebw = new EmbeddedBackgroundWorker(gvDocs, "Выполняется загрузка документов..", new object[] { btnRefresh,  }, resourceContext);
            ebw.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    // обновление данных
                    e.Result = this.docsControlTableAdapter.GetData(UserID,
                        docID,
                        docType,
                        statusID,
                        dateFromV,
                        dateToV,
                        employee,
                        itemCode,
                        boxCode,
                        supplierCode,
                        deliveryID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            ebw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                {
                    wH.DocsControl.Merge(e.Result as DataTable);
                    docsControlBindingSource.DataSource = e.Result;
                }

                // выделение строки после обновления
                if (selDocID > 0)
                    foreach (DataGridViewRow row in gvDocs.Rows)
                        if (selDocID == ((Data.WH.DocsControlRow)((DataRowView)row.DataBoundItem).Row).Doc_ID)
                        {
                            row.Selected = true;
                            if (gvDocs.RowCount > rowIndex)
                                gvDocs.FirstDisplayedScrollingRowIndex = rowIndex;
                            break;
                        }
            };

            wH.DocsControl.Clear();
            docsControlBindingSource.DataSource = null;

            ebw.RunWorkerAsync();

            #endregion
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private bool loadingDocLinesInProgress = false;
        private bool waitForLoadingDocLines = false;
        /// <summary>
        /// Обновить информацию о документе
        /// </summary>
        private void RefreshDocLines(long docID, string docType, int? itemCode)
        {
            loadingDocLinesInProgress = true;

            var ebw = new EmbeddedBackgroundWorker(gvDocLines, string.Format("Выполняется загрузка строк документа {0}-{1}..", docType, docID), new object[] { btnRefresh }, resourceContext);
            ebw.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    // обновить информацию о строках документа
                    e.Result = docDetailsTableAdapter.GetData(docID, docType, itemCode);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            ebw.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                loadingDocLinesInProgress = false;

                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                {
                    wH.DocDetails.Merge(e.Result as DataTable);
                    docDetailsBindingSource.DataSource = e.Result;
                }

                if (docType == "PR" || docType == "PS")
                    scDocDetails.Panel2Collapsed = false;

                if (waitForLoadingDocLines)
                {
                    gvDocs_SelectionChanged(gvDocs, EventArgs.Empty);
                    waitForLoadingDocLines = false;
                }
            };

            ebw.RunWorkerAsync();
        }

        private void RefreshDocLineItems(long docID, string docType, int itemID, string lotNumber)
        {
            try
            {
                // обновить информацию о местах строки документа
                docDetailItemsTableAdapter.Fill(wH.DocDetailItems, docID, itemID, lotNumber, docType, UserID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void gvDocs_SelectionChanged(object sender, EventArgs e)
        {
            scDocDetails.Panel2Collapsed = true;

            wH.DocDetails.Clear();
            docDetailsBindingSource.DataSource = null;

            if (!loadingDocLinesInProgress)
            {               
                if (gvDocs.SelectedRows.Count == 1)
                {
                    var itemCode = String.IsNullOrEmpty(tbItemCode.Text) ? (int?)null : Convert.ToInt32(tbItemCode.Text);

                    Data.WH.DocsControlRow doc = (Data.WH.DocsControlRow)((DataRowView)gvDocs.SelectedRows[0].DataBoundItem).Row;
                    RefreshDocLines(doc.Doc_ID, doc.Doc_Type, itemCode);
                }
            }
            else
            {
                waitForLoadingDocLines = true;
            }
        }

        private void gvDocLines_SelectionChanged(object sender, EventArgs e)
        {
            wH.DocDetailItems.Clear();
            if (gvDocLines.SelectedRows.Count == 1)
            {
                Data.WH.DocsControlRow doc = (Data.WH.DocsControlRow)((DataRowView)gvDocs.SelectedRows[0].DataBoundItem).Row;

                if (doc.Doc_Type == "PR" || doc.Doc_Type == "PS")
                {
                    Data.WH.DocDetailsRow docLine = (Data.WH.DocDetailsRow)((DataRowView)gvDocLines.SelectedRows[0].DataBoundItem).Row;
                    RefreshDocLineItems(doc.Doc_ID, doc.Doc_Type, docLine.Item_ID, docLine.Lot_Code);
                }
            }
        }

        private Data.WH.DocsControlRow CurrentDoc
        {
            get
            {
                if (gvDocs.SelectedRows.Count == 1)
                    return (Data.WH.DocsControlRow)((DataRowView)gvDocs.SelectedRows[0].DataBoundItem).Row;
                else 
                    return null;
            }
        }

        #region print
        private void btnPrint_Click(object sender, EventArgs e)
        {
            Data.WH.DocsControlRow doc = CurrentDoc;
            if (doc != null)
            {
                var docType = doc.Doc_Type.Trim();

                if (docType == "OK" || docType == "PR" || docType == "AR" || docType == "BR" || docType == "WR" || docType == "TC")
                    PrintPackingList(doc.Doc_ID, docType);
                else if (docType == "TR" || docType == "RO")
                    PrintMoveToSale(doc.Doc_ID, docType);
                else if (docType == "IP" || docType == "CD")
                    PrintInterbranchPackingList(doc.Doc_ID, docType);
                else if (docType == "AD" || docType == "AS" || docType == "AX")
                    PrintInterbranchAct(doc.Doc_ID, docType);
                else if (docType == "ID" || docType == "IS" || docType == "IZ")
                    PrintInterbranchBoxAct(doc.Doc_ID, docType);
                else if (docType == "AM")
                    PrintImmunobiologyAct(doc.Doc_ID, docType);
                else if (docType == "AN")
                    PrintNovoNordiskAct(doc.Doc_ID, docType);
                else if (docType == "BL" || docType == "BO" || docType == "NV")
                    PrintSubstandartAct(doc.Doc_ID, docType);
                else if (docType == "PCMP")
                    PrintMultiPickSlipReport(doc.Doc_ID, docType);
                else if (docType == "CT")
                    PrintTareInvoiceReport(doc.Doc_ID, docType);
                else if (docType == "OTCD")
                    PrintTareMoveCrossDockReport(doc.Doc_ID, docType);
            }
        }

        private void PrintPackingList(long docID, string docType)
        {
            try
            {
                // обновить информацию о строках документа (для печатного отчета)
                receive.DocLines.Clear();

                if (docType.ToUpper() == "WR")
                    docLinesTableAdapter.FillFR(receive.DocLines, docID);  
                else
                    docLinesTableAdapter.Fill(receive.DocLines, docID, docType);

                // напечатать упаковочный лист

                PackingListReport report = new PackingListReport();
                ReceiveWindow.BarcodePrepare(receive, docID, docType);
                if (docType.ToUpper() == "PR")
                    ReceiveWindow.SetUserFIO(receive, UserID);
                report.SetDataSource(receive);
                report.SetParameterValue("DocID", docID);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 2, Convert.ToInt64(docID), docType, Convert.ToInt16(receive.DocLines.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }

        }

        private void PrintMoveToSale(long docID, string docType)
        {
            try
            {
                Data.MoveToSale moveToSale = new Data.MoveToSale();

                // напечатаем сборочный лист
                MoveToSaleReport report = new MoveToSaleReport();
                MoveToSaleWindow.DocsPrepare(moveToSale, docID, docType);
                MoveToSaleWindow.BarcodePrepare(moveToSale, docID);

                report.SetDataSource(moveToSale);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 3, Convert.ToInt64(docID), docType, Convert.ToInt16(moveToSale.MoveReport.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PrintInterbranchPackingList(long docID, string docType)
        {
            try
            {
                Data.Interbranch.PackingDataTable dataTable = new WMSOffice.Data.Interbranch.PackingDataTable();

                InterbranchPackReport report = new InterbranchPackReport();
                InterbranchPickWindow.DocsPrepare(dataTable, docID);
                InterbranchPickWindow.BarcodePrepare(dataTable);

                report.SetDataSource((DataTable)dataTable);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 2, Convert.ToInt64(docID), docType, Convert.ToInt16(dataTable.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PrintInterbranchAct(long docID, string docType)
        {
            try
            {
                // информация о текущем Акте, который необходимо перепечатать
                Data.Interbranch interbranchActs = new Data.Interbranch();
                using (Data.InterbranchTableAdapters.ActsTableAdapter actsTableAdapter = new Data.InterbranchTableAdapters.ActsTableAdapter())
                    interbranchActs.Acts.Merge(actsTableAdapter.GetAct(docID));

                InterbranchActByPackingReport report = new InterbranchActByPackingReport();
                InterbranchReceiveWindow.ActPrepare(interbranchActs.ActDetails, docID);
                InterbranchReceiveWindow.BarcodePrepare(interbranchActs.Acts);

                report.SetDataSource((DataSet)interbranchActs);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 4, Convert.ToInt64(docID), docType, Convert.ToInt16(interbranchActs.ActDetails.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Печать межскладского акта
        /// </summary>
        /// <param name="pDocID">Идентификатор межскладского акта</param>
        private void PrintInterbranchBoxAct(long pDocID, string docType)
        {
            try
            {
                using (var adapter = new IB_IB_ActsTableAdapter())
                {
                    var tbl = adapter.GetData(pDocID);
                    if (tbl == null || tbl.Count == 0)
                        throw new ApplicationException("Процедура получения данных по акту не вернула данные!");

                    var provider = new ComplaintsActReportProvider(UserID, ComplaintActsReportProviderMode.ByAct);
                    var form = new ReportForm();
                    form.ReportDocument = provider.GetReport(tbl[0]);
                    form.ShowDialog();

                    if (form.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 4, Convert.ToInt64(pDocID), docType, (short?)null, form.PrinterName, Convert.ToByte(form.Copies));
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время печати межскладского акта возникла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Для строк акта приема-передачи иммунобиологических препаратов (а именно для первой строки)
        /// выполняем создание изображения штрих-кода
        /// </summary>
        /// <param name="mibpAct">Таблица со строками Акта</param>
        private static void ImmunobiologyActBarcodePrepare(Data.Frost.ImmunobiologyActDetailsDataTable mibpAct)
        {
            if (mibpAct.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(160 * 5, 60 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = false;
                barCodeCtrl.TopMargin = 2 * 5;
                barCodeCtrl.BarCode = mibpAct[0].Bar_Code;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                mibpAct[0].Bar_Code_IMG = barCode;
            }
        }

        /// <summary>
        /// Для строк акта приема-передачи Novo Nordisk (а именно для первой строки)
        /// выполняем создание изображения штрих-кода
        /// </summary>
        /// <param name="mibpAct">Таблица со строками Акта</param>
        private static void NovoNordiskActBarcodePrepare(Data.Frost.NovoNordiskActDetailsDataTable nnAct)
        {
            if (nnAct.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(160 * 5, 60 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = false;
                barCodeCtrl.TopMargin = 2 * 5;
                barCodeCtrl.BarCode = nnAct[0].AppendixAct_Bar;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                nnAct[0].Bar_Code_IMG = barCode;
            }
        }

        private void PrintImmunobiologyAct(long docID, string docType)
        {
            try
            {
                var psnID = (long?)null;
                var doco = (int?)null;
                var dcto = (string)null;

                // собственно формирование акта приема-передачи иммунобиологических препаратов
                Data.Frost.ImmunobiologyActDetailsDataTable mibpAct = new Frost.ImmunobiologyActDetailsDataTable();
                using (Data.FrostTableAdapters.ImmunobiologyActDetailsTableAdapter actsTableAdapter = new WMSOffice.Data.FrostTableAdapters.ImmunobiologyActDetailsTableAdapter())
                    mibpAct.Merge(actsTableAdapter.GetData(psnID, doco, dcto, docID));

                FrostImmunobiologyActReport report = new FrostImmunobiologyActReport();
                //InterbranchReceiveBoxWindow.ActPrepare(interbranchActs.BoxActDetails, docID);
                //InterbranchReceiveBoxWindow.BarcodePrepare(null);//(interbranchActs.BoxActs);
                ImmunobiologyActBarcodePrepare(mibpAct);

                report.SetDataSource((DataTable)mibpAct);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 4, Convert.ToInt64(docID), docType, Convert.ToInt16(mibpAct.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PrintNovoNordiskAct(long docID, string docType)
        {
            try
            {
                // собственно формирование акта Novo Nordisk
                Data.Frost.NovoNordiskActDetailsDataTable nnAct = new Frost.NovoNordiskActDetailsDataTable();
                using (Data.FrostTableAdapters.NovoNordiskActDetailsTableAdapter actsTableAdapter = new WMSOffice.Data.FrostTableAdapters.NovoNordiskActDetailsTableAdapter())
                    nnAct.Merge(actsTableAdapter.GetData(docID));

                NovoNordiskActReport report = new NovoNordiskActReport();
                NovoNordiskActBarcodePrepare(nnAct);

                report.SetDataSource((DataTable)nnAct);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 4, Convert.ToInt64(docID), docType, Convert.ToInt16(nnAct.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Для акта обнаружения некондиционного товара
        /// выполняем создание изображения штрих-кода
        /// </summary>
        /// <param name="mibpAct">Таблица со строкой Акта</param>
        public static void SubstandartActBarcodePrepare(Data.PickControl.SubstandartActsDataTable substandartAct)
        {
            if (substandartAct.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new Size(160 * 5, 80 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 2 * 5;
                barCodeCtrl.BarCode = substandartAct[0].bar_code;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                substandartAct[0].bar_code_img = barCode;
            }
        }

        /// <summary>
        /// Повторная печать Акта некондиционного товара
        /// </summary>
        /// <param name="docID">Номер акта</param>
        private void PrintSubstandartAct(long docID, string docType)
        {
            try
            {
                // формирование акта приема-передачи иммунобиологических препаратов
                Data.PickControl.SubstandartActsDataTable substandartAct = new PickControl.SubstandartActsDataTable();
                using (Data.PickControlTableAdapters.SubstandartActsTableAdapter actsTableAdapter = new WMSOffice.Data.PickControlTableAdapters.SubstandartActsTableAdapter())
                    substandartAct.Merge(actsTableAdapter.GetData(docID));

                SubstandartActReport report = new SubstandartActReport();
                SubstandartActBarcodePrepare(substandartAct);

                report.SetDataSource((DataTable)substandartAct);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 4, Convert.ToInt64(docID), docType, Convert.ToInt16(substandartAct.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void PrintMultiPickSlipReport(long docID, string docType)
        {
            try
            {
                var report = Dialogs.PickControl.MultiPickRegistrationForm.PrepareMultiPickDocument(this.UserID, docID);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 3, Convert.ToInt64(docID), docType, (short?)null, form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrintTareInvoiceReport(long docID, string docType)
        {
            try
            {
                var isDraft = true;
                var pickControlData = DebtorsReturnedTareInvoiceHelper.GetTareInvoiceReportData(docID, docType, "00001", (long?)null, (int?)null, this.UserID, false, out isDraft);
                if (pickControlData != null)
                {
                    using (var rdp = new PrintReportDocumentProvider())
                    {
                        // подставляем признак черновика
                        rdp.Init(isDraft, pickControlData);
                        rdp.Preview();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void PrintTareMoveCrossDockReport(long docID, string docType)
        {
            try
            {
                var report = TareMoveCrossDockWindow.CreateReport((int)docID);
                if (report != null)
                {
                    ReportForm form = new ReportForm();
                    form.ReportDocument = report;
                    form.ShowDialog();

                    if (form.IsPrinted)
                    {
                        // логирование факта печати
                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WH", 1, Convert.ToInt64(docID), docType, (short?)null, form.PrinterName, Convert.ToByte(form.Copies));
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #endregion

        private void btnOpenDoc_Click(object sender, EventArgs e)
        {
            try
            {
                Data.WH.DocsControlRow doc = CurrentDoc;
                if (doc != null)
                    // ручное закрытие документа WMS (для администратора)
                    if ((Control.ModifierKeys == Keys.Control) && (doc.Doc_Type == "TR" || doc.Doc_Type == "RO"))
                    {
                        if (MessageBox.Show("Вы действительно желаете закрыть документ в ручном режиме?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                        {
                            docsControlTableAdapter.CloseManual(doc.Doc_ID, doc.Doc_Type, UserID);
                            RefreshDocs();
                        }
                    }
                    // открытие документа WMS, возвращается в работу
                    else if (doc.Doc_Type == "OK" || doc.Doc_Type == "PR" || doc.Doc_Type == "TR" || doc.Doc_Type == "RO")
                    {
                        if (MessageBox.Show("Вы действительно желаете вернуть закрытый документ в работу?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            docsControlTableAdapter.OpenDoc(doc.Doc_ID, UserID);
                            RefreshDocs();
                        }
                    }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Data.WH.DocsControlRow doc = CurrentDoc;
                if (doc != null)
                {
                    if (doc.Doc_Type == "PR" && MessageBox.Show(string.Format("Вы действительно желаете аннулировать документ {0}-{1}?", doc.Doc_Type, doc.Doc_ID), "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        docsControlTableAdapter.CancelDoc(doc.Doc_ID, UserID);
                        RefreshDocs();
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void gvDocLines_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                Data.WH.DocsControlRow doc = CurrentDoc;
                if ((doc != null && doc.Status_ID == "100") &&
                    (doc.Doc_Type == "OK" || doc.Doc_Type == "PR" || doc.Doc_Type == "TR" || doc.Doc_Type == "RO")
                    )
                {
                    Data.WH.DocDetailsRow line = (Data.WH.DocDetailsRow)((DataRowView)((DataGridViewRow)e.Row).DataBoundItem).Row;
                    if (line != null)
                    {
                        if (MessageBox.Show("Вы действительно желаете удалить строку документа?", "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            docDetailsTableAdapter.DeleteDocsDetail(doc.Doc_ID, line.Item_ID, line.Lot_Code, line.LocationFrom, UserID);
                            RefreshDocs();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
            e.Cancel = true;
        }

        #region ВРЕМЕННАЯ ПЕЧАТЬ ДОКУМЕНТОВ МАЙДАНИКА

        private void InitPrintControls()
        {
            try
            {
                var adapter = new Data.WHTableAdapters.WH_TEMP_Get_Locations_Rang_And_SectionTableAdapter();
                btnPrintRangSection.Visible = btnPrintZoneRank.Visible = cmbPrinters.Visible =
                    Convert.ToBoolean(adapter.CanPrintEtics(UserID));
                WMSOffice.Classes.PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);
            }
            catch
            {
                btnPrintRangSection.Visible = btnPrintZoneRank.Visible = cmbPrinters.Visible = false;
            }
        }

        private void btnPrintRangSection_Click(object sender, EventArgs e)
        {
            try
            {
                var adapter = new Data.WHTableAdapters.WH_TEMP_Get_Locations_Rang_And_SectionTableAdapter();
                var tbl = adapter.GetData();
                var ds = new WH();
                foreach (Data.WH.WH_TEMP_Get_Locations_Rang_And_SectionRow row in tbl)
                {
                    row.Bar_Code_IMG = WMSOffice.Classes.BarcodeGenerator.GetBarcodeCODE39(row.BarCode);
                    var report = new MaydanikEticLetter();
                    report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
                    ds.WH_TEMP_Get_Locations_Rang_And_Section.Clear();
                    ds.WH_TEMP_Get_Locations_Rang_And_Section.ImportRow(row);
                    report.SetDataSource(ds);
                    report.PrintToPrinter(1, true, 1, 0);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(exc.Message);
            }
        }

        private void btnPrintZoneRank_Click(object sender, EventArgs e)
        {
            try
            {
                var adapter = new Data.WHTableAdapters.WH_TEMP_Get_Locations_Zone_And_RangTableAdapter();
                var tbl = adapter.GetData();
                var ds = new WH();
                foreach (Data.WH.WH_TEMP_Get_Locations_Zone_And_RangRow row in tbl)
                {
                    row.Bar_Code_IMG = WMSOffice.Classes.BarcodeGenerator.GetBarcodeCODE39(row.BarCode);
                    var report = new MaydanikA4Letter();
                    report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
                    ds.WH_TEMP_Get_Locations_Zone_And_Rang.Clear();
                    ds.WH_TEMP_Get_Locations_Zone_And_Rang.ImportRow(row);
                    report.SetDataSource(ds);
                    report.PrintToPrinter(1, true, 1, 0);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(exc.Message);
            }
        }

        #endregion

        private void gvDocLineItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (gvDocLineItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.DocDetailItemsRow;
            var colorFlag = boundRow.IsColor_flagNull() ? 0 : boundRow.Color_flag;
            var color = Color.Empty;
            switch (colorFlag)
            {
                case 2: // ЖЭ проконтролирована 
                    color = Color.LightSkyBlue;
                    break;
                case 1: // ЖЭ принята
                    color = Color.LightGreen;
                    break;
                case 0:
                default:
                    color = Color.White;
                    break;
            }

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        private void gvDocLineItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (gvDocLineItems.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.DocDetailItemsRow;
            var canChange = boundRow.IsCan_Change_FlagNull() ? false : boundRow.Can_Change_Flag;
            if (canChange)
            {
                try
                {
                    var dlgScanYL = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                    {
                        Label = "Отсканируйте ЖЭ, которой необходимо\r\nзаменить текущую ЖЭ",
                        Text = "Замена ЖЭ",
                        Image = Properties.Resources.barcode,
                        //OnlyNumbersInBarcode = true
                        UseScanModeOnly = true
                    };

                    if (dlgScanYL.ShowDialog() == DialogResult.OK)
                    {
                        var oldBarcodeYL = boundRow.IsBar_CodeNull() ? (string)null : boundRow.Bar_Code;
                        var newBarcodeYL = dlgScanYL.Barcode;

                        // Выполним замену ЖЭ
                        docDetailItemsTableAdapter.ChangeBarcodeYL(this.UserID, oldBarcodeYL, newBarcodeYL);

                        // Обновим список ЖЭ
                        gvDocLines_SelectionChanged(gvDocLines, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }
    }
}
