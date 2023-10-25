using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

using WMSOffice.Data;
using WMSOffice.Data.ComplaintsTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Complaints;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для печати актов аннулирования по претензиям.
    /// </summary>
    public partial class ComplaintCancActPrintWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы со списком претензий.
        /// </summary>
        private Data.Complaints.CurrentDocsRow SelectedRow
        {
            get
            {
                if (dgvComplaints.SelectedRows.Count > 0)
                    return (Data.Complaints.CurrentDocsRow)((DataRowView)dgvComplaints.SelectedRows[0].DataBoundItem).Row;
                else
                    return null;
            }
        }
        /// <summary>
        /// Признак, показывающий, были ли акты аннулирования загружены из архива (т.е. их не нужно переводить по статусам после печати).
        /// </summary>
        private bool docsFromArchive = false;

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public ComplaintCancActPrintWindow()
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

            btnPrint.Enabled = btnPrintPreview.Enabled = false;

            Config.LoadDataGridViewSettings(this.Name, dgvComplaints);
        }

        /// <summary>
        /// Обновляет содержимое при первом показе окна.
        /// </summary>
        private void ComplaintCancActPrintWindow_Shown(object sender, EventArgs e)
        {
            // загрузка списка актов аннулирования
            btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обрабатывает закрытие окна.
        /// </summary>
        private void ComplaintCancActPrintWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvComplaints);
        }

        /// <summary>
        /// Меняет доступность кнопок при смене выделения строк в таблице.
        /// </summary>
        private void dgvComplaints_SelectionChanged(object sender, EventArgs e)
        {
            btnPrint.Enabled = btnPrintPreview.Enabled = dgvComplaints.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Обновляет данные, загружая список не распечатанных актов аннулирования.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            currentDocsTableAdapter.FillDocsToPrintCancAct(complaints.CurrentDocs, UserID, null, null, null);
            currentDocsBindingSource.DataSource = complaints.CurrentDocs;
            docsFromArchive = false;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать выбранные акты".
        /// </summary>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvComplaints.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters() { PrinterName = (string)cbPrinters.SelectedItem };
                foreach (DataGridViewRow r in dgvComplaints.Rows)
                {
                    if (r.Selected)
                    {
                        parameters.DocIDs.Add((long)r.Cells[docIDDataGridViewTextBoxColumn.Index].Value);
                        parameters.OldStatus = (string)r.Cells[statusIDDataGridViewTextBoxColumn.Index].Value;
                    }
                }

                splashForm.ActionText = "Печать выбранных актов аннулирования...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Печатает в фоне выделенные акты аннулирования, используя их идентификаторы, переданные в аргументе.
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters p = (PrintWorkerParameters)e.Argument;
                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter changeStatusAdapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                {
                    for (int i = 0; i < p.DocIDs.Count; ++i)
                    {
                        using (Reports.ComplaintCancellationActReport report = GetCancellationActReport(p.DocIDs[i]))
                        {
                            report.PrintOptions.PrinterName = p.PrinterName;
                            report.PrintToPrinter(1, false, 1, 0);

                            // подтверждение печати
#if old_version
                            if (!docsFromArchive)
#endif
                            {
                                changeStatusAdapter.ChangeDocStatus(UserID, p.DocIDs[i], Dialogs.Complaints.ComplaintsConstants.ComplaintStatusItemsControl1, p.OldStatus);
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
        /// Обрабатывает окончание печати служебных записок в фоне.
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                ShowError(e.Result as Exception);

            splashForm.CloseForce();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Предварительный просмотр".
        /// </summary>
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
                try
                {
                    using (var report = GetCancellationActReport(SelectedRow.Doc_ID))
                    using (var form = new ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();
                    }
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Ошибка во время получения данных для отчета:", exc);
                }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск в архиве".
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (Dialogs.Complaints.SearchComplaintOptionsForm searchForm = new Dialogs.Complaints.SearchComplaintOptionsForm(UserID, new string[] {Dialogs.Complaints.ComplaintsConstants.ComplaintDocTypeCancellation}))
            {
                if (searchForm.ShowDialog() == DialogResult.OK)
                {
                    BackgroundWorker loadComplaintsWorker = new BackgroundWorker();
                    loadComplaintsWorker.DoWork += new DoWorkEventHandler(loadComplaintsWorker_DoWork);
                    loadComplaintsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadComplaintsWorker_RunWorkerCompleted);

                    docsFromArchive = true;
                    currentDocsBindingSource.DataSource = null;
                    splashForm.ActionText = "Загрузка архивных актов...";
                    loadComplaintsWorker.RunWorkerAsync(searchForm);
                    splashForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Загружает в фоне список актов аннулирования, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadComplaintsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Dialogs.Complaints.SearchComplaintOptionsForm searchForm = (Dialogs.Complaints.SearchComplaintOptionsForm)e.Argument;
            Data.Complaints.CurrentDocsDataTable resultTable = new Data.Complaints.CurrentDocsDataTable();
            try
            {
                using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                    adapter.FillBySearchDocs(resultTable, UserID, searchForm.DocID, searchForm.DocType, searchForm.ManagerID, searchForm.DebtorID,
                        searchForm.CreatorID, searchForm.DateFrom, searchForm.DateTo, searchForm.ItemName, searchForm.LinkedOrderID, null, searchForm.FaultEmployeeID, searchForm.LinkedInvoiceID);
                e.Result = resultTable;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка актов аннулирования.
        /// </summary>
        private void loadComplaintsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Data.Complaints.CurrentDocsDataTable resultTable = null;
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
            }
            else if (e.Result is Data.Complaints.CurrentDocsDataTable)
            {
                resultTable = (Data.Complaints.CurrentDocsDataTable)e.Result;
            }
            currentDocsBindingSource.DataSource = resultTable;

            splashForm.CloseForce();
        }

        /// <summary>
        /// Создает отчет-акт аннулирования по ключевым данным.
        /// </summary>
        /// <param name="docID">Номер документа (претензии).</param>
        /// <returns>Отчет в виде акта аннулирования с загруженными из базы данными.</returns>
        private ComplaintCancellationActReport GetCancellationActReport(long docID)
        {
            // загрузка детальных данных по акту аннулирования
            var actData = new Complaints();
            using (var adapter = new Data.ComplaintsTableAdapters.ReportCancellationActTableAdapter())
                adapter.Fill(actData.ReportCancellationAct, docID);

            // создание изображения штрих-кода
            if (actData.ReportCancellationAct.Rows.Count > 0)
            {
                var reportFirstRow = actData.ReportCancellationAct[0];
                reportFirstRow.ActBarCode = BarCodeGenerator.GetBarcodeCODE39("CN" + reportFirstRow.Number.ToString());
            }

            // создание и возврат отчета
            var report = new ComplaintCancellationActReport();
            report.SetDataSource(actData);
            return report;
        }

        #region PrintWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для печати актов аннулирования.
        /// </summary>
        private class PrintWorkerParameters
        {
            private List<long> docIDs = new List<long>();

            /// <summary>
            /// Идентификаторы документов (претензий).
            /// </summary>
            public List<long> DocIDs { get { return docIDs; } }
            /// <summary>
            /// Название принтера.
            /// </summary>
            public string PrinterName { get; set; }
            /// <summary>
            /// Статус документов до печати.
            /// </summary>
            public string OldStatus { get; set; }
        }

        #endregion
    }
}
