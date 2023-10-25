using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WH;
using WMSOffice.Dialogs;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Reports;
using System.Threading;
using System.Diagnostics;

namespace WMSOffice.Window
{
    public partial class PrePaymentDocsWindow : GeneralWindow
    {
        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        /// <summary>
        /// Последний установленный режим поиска
        /// </summary>
        private SearchMode lastSearchMode;

        public PrePaymentDocsWindow()
        {
            InitializeComponent();
        }

        private void PrePaymentDocsWindow_Load(object sender, EventArgs e)
        {
            this.xdgvDocs.AllowSummary = false;
            this.xdgvDocs.UseMultiSelectMode = true;
            this.xdgvDocs.AllowRangeColumns = true;

            this.xdgvDocs.Init(new PrePaymentDocsView(), true);
            this.xdgvDocs.LoadExtraDataGridViewSettings(this.Name);

            this.xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvDocs.RecalculateSummary();
            ChangeButtonsState();
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            ChangeButtonsState();
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var dataPropertyName = this.xdgvDocs.DataGrid.Columns[e.ColumnIndex].DataPropertyName.ToUpper();
            if (dataPropertyName.Contains("INVOICE"))
            {
                e.CellStyle.BackColor = Color.LightGreen;
                e.CellStyle.SelectionForeColor = Color.LightGreen;
            }

            if (dataPropertyName.Contains("RETURN"))
            {
                e.CellStyle.BackColor = Color.LightPink;
                e.CellStyle.SelectionForeColor = Color.LightPink;
            }

            foreach (var property in new string[] {"PRINTED", "APPROVED"})
                if (dataPropertyName.Contains(property))
                {
                    var value = (xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row[dataPropertyName].ToString().ToUpper();
                    switch (value)
                    { 
                        case "ДА":
                            e.CellStyle.BackColor = Color.LightGreen;
                            e.CellStyle.SelectionForeColor = Color.LightGreen;
                            break;
                        case "НЕТ":
                            e.CellStyle.BackColor = Color.LightPink;
                            e.CellStyle.SelectionForeColor = Color.LightPink;
                            break;
                        default:
                            break;

                    }
                }
        }

        private void ChangeButtonsState()
        {
            bool isEnabled = xdgvDocs.HasRows && xdgvDocs.SelectedItems.Count > 0;

            sbPrintDocs.Enabled = isEnabled;
            sbConfirmDebtorSign.Enabled = isEnabled;
            sbExportToExcel.Enabled = isEnabled;

            miPreviewInvoiceReport.Enabled = isEnabled;
            miPreviewComplaintsCalculationsReport.Enabled = isEnabled;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            WMSOffice.Classes.PrintDocsThread.FillPrintersComboBox(cmbPrinters.ComboBox);

            ChangeButtonsState();
            RefreshData(SearchMode.ActualDocs);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData(SearchMode.ActualDocs);
                return true;
            }

            if (keyData == (Keys.F4))
            {
                this.ApplyFilter();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            RefreshData(SearchMode.ActualDocs);
        }

        private void sbFilter_Click(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            var dlgFilter = new PrePaymentDocsFilterForm();
            if (dlgFilter.ShowDialog() == DialogResult.OK)
                RefreshData(SearchMode.SearchedDocs);
        }

        private void RefreshData(SearchMode searchMode)
        {
            this.xdgvDocs.Focus();

            var loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvDocs.DataView.FillData(e.Argument as PrePaymentDocsSearchParameters);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                {
                    this.xdgvDocs.BindData(false);

                    //this.xdgvDocs.AllowFilter = true;
                    this.xdgvDocs.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            var searchCriteria = new PrePaymentDocsSearchParameters();

            searchCriteria.UserID = this.UserID;
            searchCriteria.SearchMode = (lastSearchMode = searchMode);

            if (PrePaymentDocsFilterForm.PrePaymentDocsFilter != null)
            {
                searchCriteria.SearchType = PrePaymentDocsFilterForm.PrePaymentDocsFilter.SearchType;
                searchCriteria.DebtorCode = PrePaymentDocsFilterForm.PrePaymentDocsFilter.DebtorCode;
                searchCriteria.DocNumber = PrePaymentDocsFilterForm.PrePaymentDocsFilter.DocNumber;
                searchCriteria.DateFrom = PrePaymentDocsFilterForm.PrePaymentDocsFilter.DateFrom;
                searchCriteria.DateTo = PrePaymentDocsFilterForm.PrePaymentDocsFilter.DateTo;
            }

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(searchCriteria);
            waitProgressForm.ShowDialog();

            ChangeButtonsState();
        }


        private void sbPrintDocs_Click(object sender, EventArgs e)
        {
            try
            {
                if (xdgvDocs.SelectedItems.Count == 0)
                    throw new Exception("Выберите документы для печати.");

                var printerName = cmbPrinters.SelectedItem.ToString();

                var printWorker = new BackgroundWorker();
                printWorker.DoWork += delegate(object s, DoWorkEventArgs ea)
                {
                    try
                    {
                        var tasks = ea.Argument as Queue<DataRow>;
                        ReportClass report = null;
                        bool allowPrint;

                        while (tasks.Count > 0)
                        {
                            var task = tasks.Dequeue();

                            report = GetInvoiceReport(task, out allowPrint);
                            if (allowPrint)
                            {
                                report.PrintOptions.PrinterName = printerName;
                                report.PrintToPrinter(1, true, 1, 0);
                            }

                            report = GetComplaintsCalculationsReport(task, true, out allowPrint);
                            if (allowPrint)
                            {
                                report.PrintOptions.PrinterName = printerName;
                                report.PrintToPrinter(1, true, 1, 0);
                            }

                            report = GetComplaintsCalculationsReport(task, false, out allowPrint);
                            if (allowPrint)
                            {
                                report.PrintOptions.PrinterName = printerName;
                                report.PrintToPrinter(1, true, 1, 0);
                            }

                            var kco = task["return_KCO"].ToString();
                            var dct = task["return_DCT"].ToString();
                            var doc = Convert.ToInt64(task["return_DOC"]);

                            using (var adapter = new Data.WHTableAdapters.PrePaymentDocsTableAdapter())
                                adapter.ChangeStatusPrinted(this.UserID, kco, dct, doc);
                        }
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };

                printWorker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs ea)
                {
                    if (ea.Result is Exception)
                        ShowError(ea.Result as Exception);
                    else
                    {
                    }

                    waitProgressForm.CloseForce();
                };

                var qTasks = new Queue<DataRow>();
                foreach (var item in xdgvDocs.SelectedItems)
                    qTasks.Enqueue(item);

                waitProgressForm.ActionText = "Выполняется печать пакета документов..";
                printWorker.RunWorkerAsync(qTasks);
                waitProgressForm.ShowDialog();

                RefreshData(lastSearchMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbConfirmDebtorSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (xdgvDocs.SelectedItems.Count == 0)
                    throw new Exception("Выберите документы для подтверждения подписания клиентом.");

                var worker = new BackgroundWorker();
                worker.DoWork += delegate(object s, DoWorkEventArgs ea)
                {
                    try
                    {
                        var tasks = ea.Argument as Queue<DataRow>;

                        while (tasks.Count > 0)
                        {
                            var task = tasks.Dequeue();

                            var kco = task["return_KCO"].ToString();
                            var dct = task["return_DCT"].ToString();
                            var doc = Convert.ToInt64(task["return_DOC"]);

                            using (var adapter = new Data.WHTableAdapters.PrePaymentDocsTableAdapter())
                                adapter.ChangeStatusSignApproved(this.UserID, kco, dct, doc);
                        }
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };

                worker.RunWorkerCompleted += delegate(object s, RunWorkerCompletedEventArgs ea)
                {
                    if (ea.Result is Exception)
                        ShowError(ea.Result as Exception);
                    else
                    {
                    }

                    waitProgressForm.CloseForce();
                };

                var qTasks = new Queue<DataRow>();
                foreach (var item in xdgvDocs.SelectedItems)
                    qTasks.Enqueue(item);

                waitProgressForm.ActionText = "Выполняется подтверждение подписания клиентами документов..";
                worker.RunWorkerAsync(qTasks);
                waitProgressForm.ShowDialog();

                RefreshData(lastSearchMode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbExportToExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Сохранение списка РК";
                dlg.FileName = string.Format("Cписок РК за {0}.csv", DateTime.Now.ToShortDateString());
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlg.Filter = "Текстовый файл с разделителями (*.csv)|*.csv;*.csv|Все файлы (*.*)|*.*";
                dlg.FilterIndex = 0;
                dlg.AddExtension = true;
                dlg.DefaultExt = "csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExportGridToCSV(xdgvDocs.DataGrid, dlg.FileName);
                        Thread.Sleep(500);
                        Process.Start(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Во время экспорта списка расчет-корректировок возникла следующая ошибка:" +
                            Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Экспортирует данные из объекта класса DataGridView в файл типа CSV
        /// </summary>
        /// <param name="dgv">Ссылка на экземпляр класса DataGridView</param>
        /// <param name="strFilePath">Путь к итоговому файлу</param>
        public static void ExportGridToCSV(DataGridView dgv, string strFilePath)
        {
            var sw = new System.IO.StreamWriter(strFilePath, false, Encoding.Default);

            // создание отсортированного по DisplayIndex списка столбцов
            List<DataGridViewColumn> columns = new List<DataGridViewColumn>();
            foreach (DataGridViewColumn col in dgv.Columns)
                if (col.Visible)
                    columns.Add(col);
            for (int i = 0; i < columns.Count; ++i)
                for (int j = i + 1; j < columns.Count; ++j)
                    if (columns[i].DisplayIndex > columns[j].DisplayIndex)
                    {
                        DataGridViewColumn tmp = columns[i];
                        columns[i] = columns[j];
                        columns[j] = tmp;
                    }

            // заголовки
            for (int i = 0; i < columns.Count; i++)
            {
                sw.Write("\"" + columns[i].HeaderText.Replace("Σ", "Сумма") + "\"");
                if (i < columns.Count - 1)
                    sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
            }

            sw.Write(sw.NewLine);

            // строки с данными
            foreach (DataGridViewRow dr in dgv.Rows)
            {
                foreach (DataGridViewColumn c in columns)
                {
                    if (!Convert.IsDBNull(dr.Cells[c.Index].Value) && dr.Cells[c.Index].Value != null && dr.Cells[c.Index].Value != string.Empty)
                    {
                        sw.Write("\"" + dr.Cells[c.Index].Value.ToString() + "\"");
                    }
                    else
                    {
                        sw.Write("\" \"");
                    }
                    if (c != columns[columns.Count - 1])
                        sw.Write(System.Globalization.CultureInfo.CurrentCulture.TextInfo.ListSeparator);
                }
                sw.Write(sw.NewLine);
            }

            sw.Close();
        }


        private void PrePaymentDocsWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.xdgvDocs.SaveExtraDataGridViewSettings(this.Name);
            PrePaymentDocsFilterForm.PrePaymentDocsFilter = null;
        }


        private void miPreviewInvoiceReport_Click(object sender, EventArgs e)
        {           
            try
            {
                if (xdgvDocs.SelectedItems.Count == 0)
                    throw new Exception("Выберите документ для просмотра.");

                using (var reportForm = new ReportForm() { Text = "Налоговая накладная" })
                {
                    bool allowPrint;
                    reportForm.ReportDocument = GetInvoiceReport(xdgvDocs.SelectedItems[0], out allowPrint);

                    if (!allowPrint)
                    {
                        reportForm.CanPrint = false;
                        reportForm.CanExport = false;
                        reportForm.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", reportForm.Text);
                    }

                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ReportClass GetInvoiceReport(DataRow row, out bool allowPrint)
        {
            var printDate = Convert.ToDateTime(xdgvDocs.SelectedItems[0]["invoice_date"]);
            ReportClass report = null;

            if (printDate >= new DateTime(2015, 1, 1))
                report = new PNTaxInvoiceReport_Since_01_2015();
            else if (printDate >= new DateTime(2014, 12, 1))
                report = new PNTaxInvoiceReport_Since_07_2014();
            else if (printDate >= new DateTime(2014, 3, 1))
                report = new PNTaxInvoiceReport_Since_01_2014();
            else if (printDate >= new DateTime(2011, 12, 16))
                report = new PNTaxInvoiceReport();
            else if (printDate >= new DateTime(2011, 1, 10) && printDate <= new DateTime(2011, 12, 15))
                report = new PNTaxInvoiceOld3Report();
            else if (printDate >= new DateTime(2011, 1, 1) && printDate <= new DateTime(2011, 1, 9))
                report = new PNTaxInvoiceOld2Report();
            else if (printDate < new DateTime(2011, 1, 1))
                report = new PNTaxInvoiceOldReport();

            var docSource = PrepareInvoiceData(row, true, true, out allowPrint);
            report.SetDataSource(docSource);
            return report;
        }

        private Data.PrintNakl PrepareInvoiceData(DataRow row, bool preview, bool debtorCopy, out bool allowPrint)
        {
            var kco = row["invoice_KCO"].ToString();
            var dct = row["invoice_DCT"].ToString();
            var doc = Convert.ToInt64(row["invoice_DOC"]);

            Data.WH dsSource = new WMSOffice.Data.WH();

            using (var adapter = new Data.WHTableAdapters.InvoiceHeaderTableAdapter())
                adapter.Fill(dsSource.InvoiceHeader, kco, dct, doc, this.UserID, preview, debtorCopy);

        using (var adapter = new Data.WHTableAdapters.InvoiceDetailsTableAdapter())
                adapter.Fill(dsSource.InvoiceDetails, kco, dct, doc);

            Data.PrintNakl dsTarget = new WMSOffice.Data.PrintNakl();

            foreach (Data.WH.InvoiceHeaderRow dsSorceRow in dsSource.InvoiceHeader.Rows)
            {
                var dsTargetRow = dsTarget.DocHeaders.NewDocHeadersRow();

                #region АДАПТАЦИЯ ЗАГОЛОВКА

                dsTargetRow.TaxInvoiceReportID = dsSorceRow.TaxInvoiceReportID;

                if (dsSorceRow.IsTaxInvoiceMarkDebtorOriginalNull())
                    dsTargetRow.SetTaxInvoiceMarkDebtorOriginalNull();
                else
                    dsTargetRow.TaxInvoiceMarkDebtorOriginal = dsSorceRow.TaxInvoiceMarkDebtorOriginal;

                if (dsSorceRow.IsTaxInvoiceMarkERPNNull())
                    dsTargetRow.SetTaxInvoiceMarkERPNNull();
                else
                    dsTargetRow.TaxInvoiceMarkERPN = dsSorceRow.TaxInvoiceMarkERPN;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalNull())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalNull();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginal = dsSorceRow.TaxInvoiceMarkSellerOriginal;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalReason1Null())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalReason1Null();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginalReason1 = dsSorceRow.TaxInvoiceMarkSellerOriginalReason1;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalReason2Null())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalReason2Null();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginalReason2 = dsSorceRow.TaxInvoiceMarkSellerOriginalReason2;

                if (dsSorceRow.IsTaxInvoiceMarkSellerCopyNull())
                    dsTargetRow.SetTaxInvoiceMarkSellerCopyNull();
                else
                    dsTargetRow.TaxInvoiceMarkSellerCopy = dsSorceRow.TaxInvoiceMarkSellerCopy;

                if (dsSorceRow.IsInvoicePrintDateNull())
                    dsTargetRow.SetInvoicePrintDateNull();
                else
                    dsTargetRow.InvoicePrintDate = dsSorceRow.InvoicePrintDate;

                if (dsSorceRow.IsInvoiceIDNull())
                    dsTargetRow.SetInvoiceIDNull();
                else
                    dsTargetRow.InvoiceID = dsSorceRow.InvoiceID;

                if (dsSorceRow.IsInvoiceTypeNull())
                    dsTargetRow.SetInvoiceTypeNull();
                else
                    dsTargetRow.InvoiceType = dsSorceRow.InvoiceType;

                if (dsSorceRow.IsSellerNameNull())
                    dsTargetRow.SetSellerNameNull();
                else
                    dsTargetRow.SellerName = dsSorceRow.SellerName;

                if (dsSorceRow.IsSellerINNNull())
                    dsTargetRow.SetSellerINNNull();
                else
                    dsTargetRow.SellerINN = dsSorceRow.SellerINN;

                if (dsSorceRow.IsSellerPostCodeNull())
                    dsTargetRow.SetSellerPostCodeNull();
                else
                    dsTargetRow.SellerPostCode = dsSorceRow.SellerPostCode;

                if (dsSorceRow.IsSellerAddressNull())
                    dsTargetRow.SetSellerAddressNull();
                else
                    dsTargetRow.SellerAddress = dsSorceRow.SellerAddress;

                if (dsSorceRow.IsSellerPhoneNull())
                    dsTargetRow.SetSellerPhoneNull();
                else
                    dsTargetRow.SellerPhone = dsSorceRow.SellerPhone;

                if (dsSorceRow.IsSellerTaxNull())
                    dsTargetRow.SetSellerTaxNull();
                else
                    dsTargetRow.SellerTax = dsSorceRow.SellerTax;

                if (dsSorceRow.IsDebtorNameNull())
                    dsTargetRow.SetDebtorNameNull();
                else
                    dsTargetRow.DebtorName = dsSorceRow.DebtorName;

                if (dsSorceRow.IsDebtorCodeNull())
                    dsTargetRow.SetDebtorCodeNull();
                else
                    dsTargetRow.DebtorCode = dsSorceRow.DebtorCode;

                if (dsSorceRow.IsDebtorTaxNumberNull())
                    dsTargetRow.SetDebtorTaxNumberNull();
                else
                    dsTargetRow.DebtorTaxNumber = dsSorceRow.DebtorTaxNumber;

                if (dsSorceRow.IsDebtorAddressNull())
                    dsTargetRow.SetDebtorAddressNull();
                else
                    dsTargetRow.DebtorAddress = dsSorceRow.DebtorAddress;

                if (dsSorceRow.IsDebtorPhoneNull())
                    dsTargetRow.SetDebtorPhoneNull();
                else
                    dsTargetRow.DebtorPhone = dsSorceRow.DebtorPhone;

                if (dsSorceRow.IsDebtorCertNumberNull())
                    dsTargetRow.SetDebtorCertNumberNull();
                else
                    dsTargetRow.DebtorCertNumber = dsSorceRow.DebtorCertNumber;

                if (dsSorceRow.IsDebtorContractTypeNull())
                    dsTargetRow.SetDebtorContractTypeNull();
                else
                    dsTargetRow.DebtorContractType = dsSorceRow.DebtorContractType;

                if (dsSorceRow.IsDebtorContractNumNull())
                    dsTargetRow.SetDebtorContractNumNull();
                else
                    dsTargetRow.DebtorContractNum = dsSorceRow.DebtorContractNum;

                if (dsSorceRow.IsDebtorContractDateNull())
                    dsTargetRow.SetDebtorContractDateNull();
                else
                    dsTargetRow.DebtorContractDate = dsSorceRow.DebtorContractDate;

                if (dsSorceRow.IsPayTypeNull())
                    dsTargetRow.SetPayTypeNull();
                else
                    dsTargetRow.PayType = dsSorceRow.PayType;

                if (dsSorceRow.IsInvoiceSumNalNull())
                    dsTargetRow.SetInvoiceSumNalNull();
                else
                    dsTargetRow.InvoiceSumNal = dsSorceRow.InvoiceSumNal;

                if (dsSorceRow.IsInvoiceSumWithVATNalNull())
                    dsTargetRow.SetInvoiceSumWithVATNalNull();
                else
                    dsTargetRow.InvoiceSumWithVATNal = dsSorceRow.InvoiceSumWithVATNal;

                if (dsSorceRow.IsInvoiceSumVATNalNull())
                    dsTargetRow.SetInvoiceSumVATNalNull();
                else
                    dsTargetRow.InvoiceSumVATNal = dsSorceRow.InvoiceSumVATNal;

                if (dsSorceRow.IsNalogDeliveryResponsePersonNull())
                    dsTargetRow.SetNalogDeliveryResponsePersonNull();
                else
                    dsTargetRow.NalogDeliveryResponsePerson = dsSorceRow.NalogDeliveryResponsePerson;

                if (dsSorceRow.IsTaxInvoiceNull())
                    dsTargetRow.SetTaxInvoiceNull();
                else
                    dsTargetRow.TaxInvoice = dsSorceRow.TaxInvoice;

                if (dsSorceRow.Isdelivery_termsNull())
                    dsTargetRow.Setdelivery_termsNull();
                else
                    dsTargetRow.delivery_terms = dsSorceRow.delivery_terms;

                dsTargetRow.is_print = dsSorceRow.is_print;

                if (dsSorceRow.IsTaxInvoiceMarkEDINull())
                    dsTargetRow.SetTaxInvoiceMarkEDINull();
                else
                    dsTargetRow.TaxInvoiceMarkEDI = dsSorceRow.TaxInvoiceMarkEDI;

                if (dsSorceRow.IsTaxInvoiceMarkEDINull())
                    dsTargetRow.SetTaxInvoiceMarkEDINull();
                else
                    dsTargetRow.TaxInvoiceMarkEDI = dsSorceRow.TaxInvoiceMarkEDI;

                dsTargetRow.InvoiceType2 = dsSorceRow.InvoiceType2;

                dsTargetRow.MarkEV01 = dsSorceRow.MarkEV01;

                dsTargetRow.InvoiceType3 = dsSorceRow.InvoiceType3;

                #endregion

                dsTarget.DocHeaders.AddDocHeadersRow(dsTargetRow);
            }

            foreach (Data.WH.InvoiceDetailsRow dsSorceRow in dsSource.InvoiceDetails.Rows)
            {
                var dsTargetRow = dsTarget.DocDetail.NewDocDetailRow();

                #region АДАПТАЦИЯ СТРОК

                if (dsSorceRow.IsCompanyIDNull())
                    dsTargetRow.CompanyID = string.Empty;
                else
                    dsTargetRow.CompanyID = dsSorceRow.CompanyID;

                dsTargetRow.OrderID = dsSorceRow.OrderID;
                dsTargetRow.OrderType = dsSorceRow.OrderType;

                if (dsSorceRow.IsWarehouseIDNull())
                    dsTargetRow.SetWarehouseIDNull();
                else
                    dsTargetRow.WarehouseID = dsSorceRow.WarehouseID;

                dsTargetRow.InvoiceID = dsSorceRow.InvoiceID;

                if (dsSorceRow.IsInvoiceDateNull())
                    dsTargetRow.SetInvoiceDateNull();
                else
                    dsTargetRow.InvoiceDate = dsSorceRow.InvoiceDate;

                if (dsSorceRow.IsDeliveryDateNull())
                    dsTargetRow.SetDeliveryDateNull();
                else
                    dsTargetRow.DeliveryDate = dsSorceRow.DeliveryDate;

                if (dsSorceRow.IsRowNumNull())
                    dsTargetRow.SetRowNumNull();
                else
                    dsTargetRow.RowNum = dsSorceRow.RowNum;

                if (dsSorceRow.IsLocationNameNull())
                    dsTargetRow.SetLocationNameNull();
                else
                    dsTargetRow.LocationName = dsSorceRow.LocationName;

                if (dsSorceRow.IsSectionNameNull())
                    dsTargetRow.SetSectionNameNull();
                else
                    dsTargetRow.SectionName = dsSorceRow.SectionName;

                if (dsSorceRow.IsItemIDNull())
                    dsTargetRow.SetItemIDNull();
                else
                    dsTargetRow.ItemID = dsSorceRow.ItemID;

                if (dsSorceRow.IsItemNameNull())
                    dsTargetRow.SetItemNameNull();
                else
                    dsTargetRow.ItemName = dsSorceRow.ItemName;

                if (dsSorceRow.IsItemGroupNull())
                    dsTargetRow.SetItemGroupNull();
                else
                    dsTargetRow.ItemGroup = dsSorceRow.ItemGroup;

                if (dsSorceRow.IsItemRegDateNull())
                    dsTargetRow.SetItemRegDateNull();
                else
                    dsTargetRow.ItemRegDate = dsSorceRow.ItemRegDate;

                if (dsSorceRow.IsItemRegEndDateNull())
                    dsTargetRow.SetItemRegEndDateNull();
                else
                    dsTargetRow.ItemRegEndDate = dsSorceRow.ItemRegEndDate;

                if (dsSorceRow.IsItemRegNumNull())
                    dsTargetRow.SetItemRegNumNull();
                else
                    dsTargetRow.ItemRegNum = dsSorceRow.ItemRegNum;

                if (dsSorceRow.IsUnitOfMeasureNameNull())
                    dsTargetRow.SetUnitOfMeasureNameNull();
                else
                    dsTargetRow.UnitOfMeasureName = dsSorceRow.UnitOfMeasureName;

                if (dsSorceRow.IsVendorLotNull())
                    dsTargetRow.SetVendorLotNull();
                else
                    dsTargetRow.VendorLot = dsSorceRow.VendorLot;

                if (dsSorceRow.IsExpiryDateNull())
                    dsTargetRow.SetExpiryDateNull();
                else
                    dsTargetRow.ExpiryDate = dsSorceRow.ExpiryDate;

                if (dsSorceRow.IsLifeTimeInMonthsNull())
                    dsTargetRow.SetLifeTimeInMonthsNull();
                else
                    dsTargetRow.LifeTimeInMonths = dsSorceRow.LifeTimeInMonths;

                if (dsSorceRow.IsManufacturerNameNull())
                    dsTargetRow.SetManufacturerNameNull();
                else
                    dsTargetRow.ManufacturerName = dsSorceRow.ManufacturerName;

                if (dsSorceRow.IsSertNumberNull())
                    dsTargetRow.SetSertNumberNull();
                else
                    dsTargetRow.SertNumber = dsSorceRow.SertNumber;

                if (dsSorceRow.IsSertDateNull())
                    dsTargetRow.SetSertDateNull();
                else
                    dsTargetRow.SertDate = dsSorceRow.SertDate;

                if (dsSorceRow.IsShelfNull())
                    dsTargetRow.SetShelfNull();
                else
                    dsTargetRow.Shelf = dsSorceRow.Shelf;

                if (dsSorceRow.IsQuantityNull())
                    dsTargetRow.SetQuantityNull();
                else
                    dsTargetRow.Quantity = dsSorceRow.Quantity;

                if (dsSorceRow.IsIsVATNull())
                    dsTargetRow.SetIsVATNull();
                else
                    dsTargetRow.IsVAT = dsSorceRow.IsVAT;

                if (dsSorceRow.IsSellPriceNull())
                    dsTargetRow.SetSellPriceNull();
                else
                    dsTargetRow.SellPrice = dsSorceRow.SellPrice;

                if (dsSorceRow.IsRowSumNull())
                    dsTargetRow.SetRowSumNull();
                else
                    dsTargetRow.RowSum = Convert.ToDecimal(dsSorceRow.RowSum);

                if (dsSorceRow.IsRowSumVATNull())
                    dsTargetRow.SetRowSumVATNull();
                else
                    dsTargetRow.RowSumVAT = dsSorceRow.RowSumVAT;

                if (dsSorceRow.IsCustUSDNull())
                    dsTargetRow.SetCustUSDNull();
                else
                    dsTargetRow.CustUSD = dsSorceRow.CustUSD;

                if (dsSorceRow.IsCustUAHNull())
                    dsTargetRow.SetCustUAHNull();
                else
                    dsTargetRow.CustUAH = dsSorceRow.CustUAH;

                if (dsSorceRow.IsCustPriceNull())
                    dsTargetRow.SetCustPriceNull();
                else
                    dsTargetRow.CustPrice = dsSorceRow.CustPrice;

                if (dsSorceRow.IsCustPriceCoefNull())
                    dsTargetRow.SetCustPriceCoefNull();
                else
                    dsTargetRow.CustPriceCoef = dsSorceRow.CustPriceCoef;

                if (dsSorceRow.IsIsImportNull())
                    dsTargetRow.SetIsImportNull();
                else
                    dsTargetRow.IsImport = dsSorceRow.IsImport;

                if (dsSorceRow.IsUSDCourseNull())
                    dsTargetRow.SetUSDCourseNull();
                else
                    dsTargetRow.USDCourse = dsSorceRow.USDCourse;

                if (dsSorceRow.IsIsPriceControlNull())
                    dsTargetRow.SetIsPriceControlNull();
                else
                    dsTargetRow.IsPriceControl = dsSorceRow.IsPriceControl;

                if (dsSorceRow.IsPharmGroupNull())
                    dsTargetRow.SetPharmGroupNull();
                else
                    dsTargetRow.PharmGroup = dsSorceRow.PharmGroup;

                if (dsSorceRow.IsColNumNull())
                    dsTargetRow.SetColNumNull();
                else
                    dsTargetRow.ColNum = dsSorceRow.ColNum;

                if (dsSorceRow.IsSellPriceNalNull())
                    dsTargetRow.SetSellPriceNalNull();
                else
                    dsTargetRow.SellPriceNal = dsSorceRow.SellPriceNal;

                if (dsSorceRow.IsRowSumNalNull())
                    dsTargetRow.SetRowSumNalNull();
                else
                    dsTargetRow.RowSumNal = dsSorceRow.RowSumNal;

                if (dsSorceRow.IsRowSumVATNalNull())
                    dsTargetRow.SetRowSumVATNalNull();
                else
                    dsTargetRow.RowSumVATNal = dsSorceRow.RowSumVATNal;

                if (dsSorceRow.IsTotalSumNull())
                    dsTargetRow.SetTotalSumNull();
                else
                    dsTargetRow.TotalSum = dsSorceRow.TotalSum;

                if (dsSorceRow.IsTotalSumTextNull())
                    dsTargetRow.SetTotalSumTextNull();
                else
                    dsTargetRow.TotalSumText = dsSorceRow.TotalSumText;

                if (dsSorceRow.IsIsUniPriceNull())
                    dsTargetRow.SetIsUniPriceNull();
                else
                    dsTargetRow.IsUniPrice = dsSorceRow.IsUniPrice;

                if (dsSorceRow.IsIsRequiredNull())
                    dsTargetRow.SetIsRequiredNull();
                else
                    dsTargetRow.IsRequired = dsSorceRow.IsRequired;

                if (dsSorceRow.IsPrintInRegisterNull())
                    dsTargetRow.SetPrintInRegisterNull();
                else
                    dsTargetRow.PrintInRegister = dsSorceRow.PrintInRegister;

                if (dsSorceRow.IsTPP_CODNull())
                    dsTargetRow.SetTPP_CODNull();
                else
                    dsTargetRow.TPP_COD = dsSorceRow.TPP_COD;

                if (dsSorceRow.Isresponsible_personNull())
                    dsTargetRow.Setresponsible_personNull();
                else
                    dsTargetRow.responsible_person = dsSorceRow.responsible_person;

                if (dsSorceRow.Isvendor_control_rezultNull())
                    dsTargetRow.Setvendor_control_rezultNull();
                else
                    dsTargetRow.vendor_control_rezult = dsSorceRow.vendor_control_rezult;

                if (dsSorceRow.IsCostPriceNull())
                    dsTargetRow.SetCostPriceNull();
                else
                    dsTargetRow.CostPrice = dsSorceRow.CostPrice;

                if (dsSorceRow.IsGTD_NumNull())
                    dsTargetRow.SetGTD_NumNull();
                else
                    dsTargetRow.GTD_Num = dsSorceRow.GTD_Num;

                if (dsSorceRow.IsGTD_DateNull())
                    dsTargetRow.SetGTD_DateNull();
                else
                    dsTargetRow.GTD_Date = dsSorceRow.GTD_Date;

                if (dsSorceRow.IsUOMNull())
                    dsTargetRow.SetUOMNull();
                else
                    dsTargetRow.UOM = dsSorceRow.UOM;

                if (dsSorceRow.IsuktzNull())
                    dsTargetRow.SetuktzNull();
                else
                    dsTargetRow.uktz = dsSorceRow.uktz;

                if (dsSorceRow.IsTotalSumVATNull())
                    dsTargetRow.SetTotalSumVATNull();
                else
                    dsTargetRow.TotalSumVAT = dsSorceRow.TotalSumVAT;

                if (dsSorceRow.IsTotal_sum_FNull())
                    dsTargetRow.SetTotal_sum_FNull();
                else
                    dsTargetRow.Total_sum_F = dsSorceRow.Total_sum_F;

                if (dsSorceRow.IsTotal_sum_VAT_FNull())
                    dsTargetRow.SetTotal_sum_VAT_FNull();
                else
                    dsTargetRow.Total_sum_VAT_F = dsSorceRow.Total_sum_VAT_F;

                if (dsSorceRow.IsCurr_RateNull())
                    dsTargetRow.SetCurr_RateNull();
                else
                    dsTargetRow.Curr_Rate = dsSorceRow.Curr_Rate;

                if (dsSorceRow.IsF_SumTxtNull())
                    dsTargetRow.SetF_SumTxtNull();
                else
                    dsTargetRow.F_SumTxt = dsSorceRow.F_SumTxt;

                #endregion

                dsTarget.DocDetail.AddDocDetailRow(dsTargetRow);
            }

            allowPrint = true;
            if (dsTarget.DocHeaders.Rows.Count > 0)
            {
                if (dsTarget.DocHeaders[0].MarkEV01.Equals(0))
                    allowPrint = false;
            }
            else
            {
                allowPrint = false;
            }

            return dsTarget;
        }

       
        private void miPreviewComplaintsCalculationsReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (xdgvDocs.SelectedItems.Count == 0)
                    throw new Exception("Выберите документ для просмотра.");

                using (var reportForm = new ReportForm() { Text = "Расчет-корректировка" })
                {
                    bool allowPrint;
                    reportForm.ReportDocument = GetComplaintsCalculationsReport(xdgvDocs.SelectedItems[0], true, out allowPrint);

                    if (!allowPrint)
                    {
                        reportForm.CanPrint = false;
                        reportForm.CanExport = false;
                        reportForm.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", reportForm.Text);
                    }

                    reportForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ReportClass GetComplaintsCalculationsReport(DataRow row, bool debtorCopy, out bool allowPrint)
        {
            var printDate = Convert.ToDateTime(xdgvDocs.SelectedItems[0]["return_date"]);
            ReportClass report = null;

            if (printDate >= new DateTime(2015, 1, 1))
                report = new ComplaintCalculationReport_Since_01_2015();
            else if (printDate >= new DateTime(2014, 12, 1))
                report = new ComplaintCalculationReport_Since_07_2014();
            else if (printDate >= new DateTime(2014, 3, 1))
                report = new ComplaintCalculationReport_Since_01_2014();
            else if (printDate >= new DateTime(2011, 12, 16))
                report = new ComplaintCalculationReport();
            else if (printDate <= new DateTime(2011, 12, 15))
                report = new ComplaintCalculationReportOld2();

            var docSource = PrepareComplaintsCalculationsData(row, debtorCopy, out allowPrint);
            report.SetDataSource(docSource);

            return report;
        }

        private Data.Complaints PrepareComplaintsCalculationsData(DataRow row, bool debtorCopy, out bool allowPrint)
        {
            var kco = row["return_KCO"].ToString();
            var dct = row["return_DCT"].ToString();
            var doc = Convert.ToInt64(row["return_DOC"]);         

            Data.WH dsSource = new WMSOffice.Data.WH();

            using (var adapter = new Data.WHTableAdapters.ComplaintsCalculationsHeaderTableAdapter())
                adapter.Fill(dsSource.ComplaintsCalculationsHeader, kco, dct, doc, debtorCopy);

            using (var adapter = new Data.WHTableAdapters.ComplaintsCalculationsDetailsTableAdapter())
                adapter.Fill(dsSource.ComplaintsCalculationsDetails, kco, dct, doc);

            Data.Complaints dsTarget = new WMSOffice.Data.Complaints();

            foreach (Data.WH.ComplaintsCalculationsHeaderRow dsSorceRow in dsSource.ComplaintsCalculationsHeader.Rows)
            {
                var dsTargetRow = dsTarget.ReportCalculationHeader.NewReportCalculationHeaderRow();

                #region АДАПТАЦИЯ ЗАГОЛОВКА

                dsTargetRow.TaxInvoiceReportID = dsSorceRow.TaxInvoiceReportID;

                if (dsSorceRow.IsTaxInvoiceMarkDebtorOriginalNull())
                    dsTargetRow.SetTaxInvoiceMarkDebtorOriginalNull();
                else
                    dsTargetRow.TaxInvoiceMarkDebtorOriginal = dsSorceRow.TaxInvoiceMarkDebtorOriginal;

                if (dsSorceRow.IsTaxInvoiceMarkERPNNull())
                    dsTargetRow.SetTaxInvoiceMarkERPNNull();
                else
                    dsTargetRow.TaxInvoiceMarkERPN = dsSorceRow.TaxInvoiceMarkERPN;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalNull())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalNull();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginal = dsSorceRow.TaxInvoiceMarkSellerOriginal;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalReason1Null())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalReason1Null();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginalReason1 = dsSorceRow.TaxInvoiceMarkSellerOriginalReason1;

                if (dsSorceRow.IsTaxInvoiceMarkSellerOriginalReason2Null())
                    dsTargetRow.SetTaxInvoiceMarkSellerOriginalReason2Null();
                else
                    dsTargetRow.TaxInvoiceMarkSellerOriginalReason2 = dsSorceRow.TaxInvoiceMarkSellerOriginalReason2;

                if (dsSorceRow.IsTaxInvoiceMarkSellerCopyNull())
                    dsTargetRow.SetTaxInvoiceMarkSellerCopyNull();
                else
                    dsTargetRow.TaxInvoiceMarkSellerCopy = dsSorceRow.TaxInvoiceMarkSellerCopy;

                dsTargetRow.CalculationCount = dsSorceRow.CalculationCount;

                if (dsSorceRow.IsCalculationNumberNull())
                    dsTargetRow.SetCalculationNumberNull();
                else
                    dsTargetRow.CalculationNumber = dsSorceRow.CalculationNumber;

                if (dsSorceRow.IsInvoiceDateNull())
                    dsTargetRow.SetInvoiceDateNull();
                else
                    dsTargetRow.InvoiceDate = dsSorceRow.InvoiceDate;

                if (dsSorceRow.IsInvoiceDateGermanNull())
                    dsTargetRow.SetInvoiceDateGermanNull();
                else
                    dsTargetRow.InvoiceDateGerman = dsSorceRow.InvoiceDateGerman;

                if (dsSorceRow.IsInvoiceNumberNull())
                    dsTargetRow.SetInvoiceNumberNull();
                else
                    dsTargetRow.InvoiceNumber = dsSorceRow.InvoiceNumber;

                if (dsSorceRow.IsAgreementDateNull())
                    dsTargetRow.SetAgreementDateNull();
                else
                    dsTargetRow.AgreementDate = dsSorceRow.AgreementDate;

                if (dsSorceRow.IsAgreementNull())
                    dsTargetRow.SetAgreementNull();
                else
                    dsTargetRow.Agreement = dsSorceRow.Agreement;

                dsTargetRow.CreditorName = dsSorceRow.CreditorName;
                dsTargetRow.CreditorINN = dsSorceRow.CreditorINN;
                dsTargetRow.CreditorAddress = dsSorceRow.CreditorAddress;
                dsTargetRow.CreditorTelephone = dsSorceRow.CreditorTelephone;
                dsTargetRow.CreditorCertificate = dsSorceRow.CreditorCertificate;

                if (dsSorceRow.IsDebitorNameNull())
                    dsTargetRow.SetDebitorNameNull();
                else
                    dsTargetRow.DebitorName = dsSorceRow.DebitorName;

                if (dsSorceRow.IsDebitorINNNull())
                    dsTargetRow.SetDebitorINNNull();
                else
                    dsTargetRow.DebitorINN = dsSorceRow.DebitorINN;

                if (dsSorceRow.IsDebitorAddressNull())
                    dsTargetRow.SetDebitorAddressNull();
                else
                    dsTargetRow.DebitorAddress = dsSorceRow.DebitorAddress;

                if (dsSorceRow.IsDebitorTelephoneNull())
                    dsTargetRow.SetDebitorTelephoneNull();
                else
                    dsTargetRow.DebitorTelephone = dsSorceRow.DebitorTelephone;

                if (dsSorceRow.IsDebitorCertificateNull())
                    dsTargetRow.SetDebitorCertificateNull();
                else
                    dsTargetRow.DebitorCertificate = dsSorceRow.DebitorCertificate;

                if (dsSorceRow.IsCalculationDateGermanNull())
                    dsTargetRow.SetCalculationDateGermanNull();
                else
                    dsTargetRow.CalculationDateGerman = dsSorceRow.CalculationDateGerman;

                if (dsSorceRow.IsCalculationDateNull())
                    dsTargetRow.SetCalculationDateNull();
                else
                    dsTargetRow.CalculationDate = dsSorceRow.CalculationDate;

                if (dsSorceRow.IsCalculationBritannicNull())
                    dsTargetRow.SetCalculationBritannicNull();
                else
                    dsTargetRow.CalculationBritannic = dsSorceRow.CalculationBritannic;

                if (dsSorceRow.IsCreatedEmployeeNameNull())
                    dsTargetRow.SetCreatedEmployeeNameNull();
                else
                    dsTargetRow.CreatedEmployeeName = dsSorceRow.CreatedEmployeeName;

                dsTargetRow.TermsOfDelivery = dsSorceRow.TermsOfDelivery;

                if (dsSorceRow.IsTaxCalculationNumberNull())
                    dsTargetRow.SetTaxCalculationNumberNull();
                else
                    dsTargetRow.TaxCalculationNumber = dsSorceRow.TaxCalculationNumber;

                if (dsSorceRow.IsTaxCalculationNumber2Null())
                    dsTargetRow.SetTaxCalculationNumber2Null();
                else
                    dsTargetRow.TaxCalculationNumber2 = dsSorceRow.TaxCalculationNumber2;

                if (dsSorceRow.IsTaxInvoiceNumberNull())
                    dsTargetRow.SetTaxInvoiceNumberNull();
                else
                    dsTargetRow.TaxInvoiceNumber = dsSorceRow.TaxInvoiceNumber;

                if (dsSorceRow.IsTaxInvoiceNumber2Null())
                    dsTargetRow.SetTaxInvoiceNumber2Null();
                else
                    dsTargetRow.TaxInvoiceNumber2 = dsSorceRow.TaxInvoiceNumber2;

                if (dsSorceRow.IsTaxInvoiceMarkEDINull())
                    dsTargetRow.SetTaxInvoiceMarkEDINull();
                else
                    dsTargetRow.TaxInvoiceMarkEDI = dsSorceRow.TaxInvoiceMarkEDI;

                dsTargetRow.InvoiceType2 = dsSorceRow.InvoiceType2;

                if (dsSorceRow.IsCalcDateNull())
                    dsTargetRow.SetCalcDateNull();
                else
                    dsTargetRow.CalcDate = dsSorceRow.CalcDate;

                dsTargetRow.MarkEV01 = dsSorceRow.MarkEV01;

                dsTargetRow.InvoiceType3 = dsSorceRow.InvoiceType3;

                #endregion

                dsTarget.ReportCalculationHeader.AddReportCalculationHeaderRow(dsTargetRow);
            }

            foreach (Data.WH.ComplaintsCalculationsDetailsRow dsSorceRow in dsSource.ComplaintsCalculationsDetails.Rows)
            {
                    var dsTargetRow = dsTarget.ReportCalculationDetail.NewReportCalculationDetailRow();

                #region АДАПТАЦИЯ СТРОК

                if (dsSorceRow.IsCalculationNumberNull())
                    dsTargetRow.SetCalculationNumberNull();
                else
                    dsTargetRow.CalculationNumber = dsSorceRow.CalculationNumber;

                if (dsSorceRow.IsReasonNull())
                    dsTargetRow.SetReasonNull();
                else
                    dsTargetRow.Reason = dsSorceRow.Reason;

                if (dsSorceRow.IsItemNameNull())
                    dsTargetRow.SetItemNameNull();
                else
                    dsTargetRow.ItemName = dsSorceRow.ItemName;

                if (dsSorceRow.IsVendorLotNull())
                    dsTargetRow.SetVendorLotNull();
                else
                    dsTargetRow.VendorLot = dsSorceRow.VendorLot;

                if (dsSorceRow.IsUnitOfMeasureNull())
                    dsTargetRow.SetUnitOfMeasureNull();
                else
                    dsTargetRow.UnitOfMeasure = dsSorceRow.UnitOfMeasure;

                if (dsSorceRow.IsQuantityNull())
                    dsTargetRow.SetQuantityNull();
                else
                    dsTargetRow.Quantity = dsSorceRow.Quantity;

                if (dsSorceRow.IsCostNull())
                    dsTargetRow.SetCostNull();
                else
                    dsTargetRow.Cost = dsSorceRow.Cost;

                if (dsSorceRow.IsChangeCostNull())
                    dsTargetRow.SetChangeCostNull();
                else
                    dsTargetRow.ChangeCost = dsSorceRow.ChangeCost;

                if (dsSorceRow.IsQuantityDeliveryNull())
                    dsTargetRow.SetQuantityDeliveryNull();
                else
                    dsTargetRow.QuantityDelivery = dsSorceRow.QuantityDelivery;

                if (dsSorceRow.IsWithoutTAXNull())
                    dsTargetRow.SetWithoutTAXNull();
                else
                    dsTargetRow.WithoutTAX = dsSorceRow.WithoutTAX;

                if (dsSorceRow.IsSumVat0Null())
                    dsTargetRow.SetSumVat0Null();
                else
                    dsTargetRow.SumVat0 = dsSorceRow.SumVat0;

                if (dsSorceRow.IsSumVat20Null())
                    dsTargetRow.SetSumVat20Null();
                else
                    dsTargetRow.SumVat20 = dsSorceRow.SumVat20;

                if (dsSorceRow.IsVATNull())
                    dsTargetRow.SetVATNull();
                else
                    dsTargetRow.VAT = dsSorceRow.VAT;

                if (dsSorceRow.IsTPP_CODNull())
                    dsTargetRow.SetTPP_CODNull();
                else
                    dsTargetRow.TPP_COD = dsSorceRow.TPP_COD;

                if (dsSorceRow.IsSumVat7Null())
                    dsTargetRow.SetSumVat7Null();
                else
                    dsTargetRow.SumVat7 = dsSorceRow.SumVat7;

                #endregion

                dsTarget.ReportCalculationDetail.AddReportCalculationDetailRow(dsTargetRow);
            }

            allowPrint = true;
            if (dsTarget.ReportCalculationHeader.Rows.Count > 0)
            {
                if (dsTarget.ReportCalculationHeader[0].MarkEV01.Equals(0))
                    allowPrint = false;
            }
            else
            {
                allowPrint = false;
            }

            return dsTarget;
        }       
    }

     /// <summary>
    /// Представление для предоплатных НН и РК
    /// </summary>
    public class PrePaymentDocsView : IDataView
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
            var searchCriteria = searchParameters as PrePaymentDocsSearchParameters;

            var docs = new Data.WH.PrePaymentDocsDataTable();
            using (var adapter = new Data.WHTableAdapters.PrePaymentDocsTableAdapter())
            {
                switch (searchCriteria.SearchMode)
                {
                    case SearchMode.ActualDocs:
                        adapter.Fill(docs,
                            searchCriteria.UserID);
                        break;
                    case SearchMode.SearchedDocs:
                        adapter.SearchBy(docs,
                            searchCriteria.UserID,
                            searchCriteria.SearchType,
                            searchCriteria.DocNumber,
                            searchCriteria.DebtorCode,
                            searchCriteria.DateFrom,
                            searchCriteria.DateTo);
                        break;
                    default:
                        break;

                }
            }

            this.data = null;

            if (docs != null)
            {
                this.data = docs;
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public PrePaymentDocsView()
        {
            this.dataColumns.Add(new PatternColumn("Электронная", "is_el", new FilterPatternExpressionRule("is_el")));
            this.dataColumns.Add(new PatternColumn("Тип инвойса", "invoice_DCT", new FilterPatternExpressionRule("invoice_DCT")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("№ инвойса", "invoice_DOC", new FilterCompareExpressionRule<Int64>("invoice_DOC"), SummaryCalculationType.Count) { Width = 100 });
            //this.dataColumns.Add(new PatternColumn("Σ инвойса", "invoice_SumTotal", new FilterCompareExpressionRule<Decimal>("invoice_SumTotal"), SummaryCalculationType.Sum){ UseDecimalNumbersAlignement = true, Width = 120 });
            this.dataColumns.Add(new PatternColumn("Σ с НДС инвойса", "invoice_SumTotalWithVAT", new FilterCompareExpressionRule<Decimal>("invoice_SumTotalWithVAT"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Width = 125 });
            this.dataColumns.Add(new PatternColumn("Σ НДС инвойса", "invoice_SumVAT", new FilterCompareExpressionRule<Decimal>("invoice_SumVAT"), SummaryCalculationType.None) { UseDecimalNumbersAlignment = true, Width = 125 });
            this.dataColumns.Add(new PatternColumn("Дата инвойса", "invoice_date", new FilterDateCompareExpressionRule("invoice_date")) { Width = 110 });

            //this.dataColumns.Add(new PatternColumn("Комп. возврата", "return_KCO", new FilterPatternExpressionRule("return_KCO")){ Width = 120 });
            this.dataColumns.Add(new PatternColumn("Тип возврата", "return_DCT", new FilterPatternExpressionRule("return_DCT")) { Width = 110 });
            this.dataColumns.Add(new PatternColumn("№ возврата", "return_DOC", new FilterCompareExpressionRule<Int64>("return_DOC"), SummaryCalculationType.Count) { Width = 100 });
            //this.dataColumns.Add(new PatternColumn("Σ возврата", "return_SumTotal", new FilterCompareExpressionRule<Decimal>("return_SumTotal"), SummaryCalculationType.Sum){ UseDecimalNumbersAlignement = true, Width = 120 });
            this.dataColumns.Add(new PatternColumn("Σ с НДС возврата", "return_SumTotalWithVAT", new FilterCompareExpressionRule<Decimal>("return_SumTotalWithVAT"), SummaryCalculationType.Sum) { UseDecimalNumbersAlignment = true, Width = 125 });
            this.dataColumns.Add(new PatternColumn("Дата возврата", "return_date", new FilterDateCompareExpressionRule("return_date")) { Width = 110 });

            this.dataColumns.Add(new PatternColumn("Код склада", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Наименование склада", "Warehouse_Name", new FilterPatternExpressionRule("Warehouse_Name")) { Width = 170 });

            this.dataColumns.Add(new PatternColumn("Код дебитора", "Debtor_Code", new FilterCompareExpressionRule<Int32>("Debtor_Code"), SummaryCalculationType.Count) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Наименование дебитора", "Debtor_Name", new FilterPatternExpressionRule("Debtor_Name")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Адрес доставки", "DebtorAddress", new FilterPatternExpressionRule("DebtorAddress")) { Width = 350 });
            this.dataColumns.Add(new PatternColumn("Торговый представитель", "TP_Name", new FilterPatternExpressionRule("TP_Name")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("Подписано", "SignApproved", new FilterPatternExpressionRule("SignApproved")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Напечатано", "IsPrinted", new FilterPatternExpressionRule("IsPrinted")) { Width = 100 });
        }

        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class PrePaymentDocsSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public SearchMode SearchMode { get; set; }
        public int SearchType { get; set; }
        public int? DebtorCode { get; set; }
        public long? DocNumber { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
    }

    /// <summary>
    /// Режим поиска
    /// </summary>
    public enum SearchMode
    {
        /// <summary>
        /// Актуальные документы
        /// </summary>
        ActualDocs,

        /// <summary>
        /// Документы найденные через опцию поиска
        /// </summary>
        SearchedDocs
    }
}
