using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Reports;
using WMSOffice.Classes;

namespace WMSOffice.Dialogs.WH
{
    public partial class PrintWriteOffPackageForm : DialogForm
    {
        public new long UserID { get; set; }

        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        public PrintWriteOffPackageForm()
        {
            InitializeComponent();
        }

        private void PrintWriteOffPackageForm_Load(object sender, EventArgs e)
        {
            PrintDocsThread.FillPrintersComboBox(cmbPrinters);
        }

        private void PrintWriteOffPackageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.PrintActsPackage();
                e.Cancel = true;
            }
        }

        private void PrintActsPackage()
        {
            try
            {
                var sActs = Clipboard.GetText();
                if (string.IsNullOrEmpty(sActs.Trim()))
                    throw new Exception("Нет актов для печати.");

                var printerName = cmbPrinters.Text;
                tbActNumbers.Text = string.Empty;

                var printWorker = new BackgroundWorker();
                printWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
                {
                    try
                    {
                        foreach (var sAct in sActs.Replace("\r\n", ";").Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                        {
                            int actNumber;
                            if (!int.TryParse(sAct, out actNumber))
                                throw new Exception("Номер акта должен быть числом.");

                            var reportDocs = new Data.WH.WF_GetReportsDataTable();
                            using (var adapter = new Data.WHTableAdapters.WF_GetReportsTableAdapter())
                                adapter.FillByAct(reportDocs, this.UserID, actNumber);

                            foreach (Data.WH.WF_GetReportsRow reportDoc in reportDocs)
                            {
                                var wh = GetDataForWriteOffDoc(reportDoc, false);
                                using (var report = new WriteOffActReport())
                                {
                                    report.PrintOptions.PrinterName = printerName;
                                    report.SetDataSource(wh);
                                    report.PrintToPrinter(1, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WF", 8, Convert.ToInt64(reportDoc.Act_Number), reportDoc.JDE_Type_ID, Convert.ToInt16(wh.WF_GetReportDetail.Count), printerName, 1);
                                }

                                using (var report = new WriteOffActAdditionReport())
                                {
                                    report.PrintOptions.PrinterName = printerName;
                                    report.SetDataSource(wh);
                                    report.PrintToPrinter(1, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WF", 8, Convert.ToInt64(reportDoc.Act_Number), reportDoc.JDE_Type_ID, Convert.ToInt16(wh.WF_GetReportDetail.Count), printerName, 1);
                                }

                                // Анализ и печать служебной записки и акта приема-передачи
                                if (!reportDoc.IsShip_to_VendorNull() && reportDoc.Ship_to_Vendor == true)
                                {
                                    wh = GetDataForMemorandumReport(reportDoc);
                                    using (var report = new WFMemorandumReport())
                                    {
                                        report.PrintOptions.PrinterName = printerName;
                                        report.SetDataSource(wh);
                                        report.PrintToPrinter(1, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WF", 20, Convert.ToInt64(reportDoc.Doc_ID), (string)null, Convert.ToInt16(wh.WF_STV_GetMemorandum.Count), printerName, 1);
                                    }

                                    // Печать акта приема-передачи
                                    wh = GetDataByActAccTrans(reportDoc);
                                    using (var report = new WHActAcceptanceTransmission())
                                    {
                                        report.PrintOptions.PrinterName = printerName;
                                        report.SetDataSource(wh);
                                        report.PrintToPrinter(1, true, 1, 0);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WF", 19, Convert.ToInt64(reportDoc.Request_number), (string)null, Convert.ToInt16(wh.WF_GetDestructionInformation.Count), printerName, 1);
                                    }
                                }
                            }

                            PopulatePrintedActsLog(actNumber);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                printWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
                {
                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    waitProgressForm.CloseForce();
                };

                waitProgressForm.ActionText = "Выполняется пакетная печать актов списания..";
                printWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                adapter.Fill(wh.WF_GetReportHeader, this.UserID, pRow.Week, pRow.Doc_ID, pRow.JDE_Type_ID, pRow.Date_ID,
                    pRow.IsAct_NumberNull() ? null : pRow.Act_Number, 1);
            }
            if (wh.WF_GetReportHeader.Count == 0)
                throw new ApplicationException("Не удалось загрузить Header для акта списания!");

            using (var adapter = new WF_GetReportDetailTableAdapter())
            {
                adapter.SetTimeout(600);
                adapter.Fill(wh.WF_GetReportDetail, this.UserID, pRow.Week, pRow.Doc_ID, pRow.JDE_Type_ID, pRow.Date_ID,
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
                adapter.Fill(wh.AAT_GetReportHeader, this.UserID, pRow.Request_number);

            if (wh.AAT_GetReportHeader.Count == 0)
                throw new ApplicationException("Не удалось получить данные для акта приема-передачи!");


            using (var adapter = new WF_GetDestructionInformationTableAdapter())
                adapter.FillByDestRequest(wh.WF_GetDestructionInformation, this.UserID, pRow.Request_number);

            if (wh.WF_GetDestructionInformation.Count == 0)
                throw new ApplicationException("Не удалось получить данные для акта приема-передачи!");

            return wh;
        }

        delegate void PopulatePrintedActsLogHandler(int actNumber);
        private void PopulatePrintedActsLog(int actNumber)
        {
            if (tbActNumbers.InvokeRequired)
            {
                tbActNumbers.Invoke(new PopulatePrintedActsLogHandler(PopulatePrintedActsLog), actNumber);
            }
            else
            {
                if (string.IsNullOrEmpty(tbActNumbers.Text))
                    tbActNumbers.Text = string.Format("Акт {0} напечатан..", actNumber);
                else
                    tbActNumbers.Text = string.Format("{0}\r\nАкт {1} напечатан..", tbActNumbers.Text, actNumber);

            }
        }
    }
}
