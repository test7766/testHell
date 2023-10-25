using System;
using System.Collections.Generic;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using System.Drawing.Printing;
using WMSOffice.Dialogs;
using System.Windows.Forms;

namespace WMSOffice.Classes.ReportProviders.DebtorsReturnedTareInvoice
{
    public abstract class ReportDocumentProvider : IDisposable
    {
        protected Data.PickControl data = null;

        public abstract void Init(bool pIsDraft, Data.PickControl pData);
        public abstract void Print();
        public abstract void Print(string printerName, int copies);
        public abstract void Preview();

        public event EventHandler<ReportDocumentProviderEventArgs> OnPrintCompleted;
        protected void RaisePrintCompleted(string printerName, int copies, int docLines)
        {
            if (OnPrintCompleted != null)
                OnPrintCompleted(this, new ReportDocumentProviderEventArgs(printerName, copies, docLines));
        }

        public virtual void Dispose() { }
    }

    public class ReportDocumentProviderEventArgs : EventArgs
    {
        public string PrinterName { get; private set; }
        public int Copies { get; private set; }
        public int DocLines { get; private set; }

        public ReportDocumentProviderEventArgs(string printerName, int copies, int docLines)
        {
            this.PrinterName = printerName;
            this.Copies = copies;
            this.DocLines = docLines;
        }
    }

    public class PrintReportDocumentProvider : ReportDocumentProvider
    {
        private PrintDocument pd = null;
        private PrintPreviewDialog ppd = null;
        private DebtorsReturnedTareInvoiceHelper.DebtorsReturnedTareInvoiceReportPrintController pc = null;

        public override void Init(bool pIsDraft, Data.PickControl pData)
        {
            data = pData;
            pc = new DebtorsReturnedTareInvoiceHelper.DebtorsReturnedTareInvoiceReportPrintController(pIsDraft, data);

            pd = new PrintDocument();
            pd.DocumentName = "ОТ";
            pd.PrinterSettings.PrinterName = new PrinterSettings().PrinterName;
            pd.DefaultPageSettings.Landscape = true;
            //pd.OriginAtMargins = true;
            pd.DefaultPageSettings.Margins = new Margins(10, 10, 10, 10);
            pd.PrintController = new StandardPrintController();
            pd.BeginPrint += (s, e) =>
            {

            };
            pd.PrintPage += (s, e) =>
            {
                //e.Graphics.TranslateTransform(-e.PageSettings.HardMarginX, -e.PageSettings.HardMarginY);
                e.HasMorePages = pc.PrintPage(e);
            };
            pd.EndPrint += (s, e) =>
            {
                if (e.PrintAction == PrintAction.PrintToPrinter)
                {
                    if (ppd != null)
                    {
                        ppd.Close();
                        ppd = null;
                    }

                    this.RaisePrintCompleted(pd.PrinterSettings.PrinterName, Convert.ToInt32(pd.PrinterSettings.Copies), data.CT_Tare_Invoice_Details.Count + data.CT_Tare_Invoice_Details.Count);
                }
            };
        }

        public override void Print()
        {
            this.Print(pd.PrinterSettings.PrinterName, 1);
        }

        public override void Print(string printerName, int copies)
        {
            pd.PrinterSettings.PrinterName = printerName;
            pd.PrinterSettings.Copies = Convert.ToInt16(copies);
            pd.Print();
        }

        public override void Preview()
        {
            if (data != null)
            {
                var dlgPrintPreviewDialog = ppd = new PrintPreviewDialog();
                dlgPrintPreviewDialog.GetType().GetProperty("WindowState").SetValue(dlgPrintPreviewDialog, FormWindowState.Maximized, null);
                dlgPrintPreviewDialog.GetType().GetProperty("Text").SetValue(dlgPrintPreviewDialog, "Предварительный просмотр ОТ", null);

                #region ИСПРАВЛЕНИЕ БАГА ПРИ ОТПРАВКЕ НА ПЕЧАТЬ (ОЧЕРЕДЬ ПЕЧАТИ БЫЛА ПУСТА - ОЧИСТКА ПРОИСХОДИТ ПРИ РЕНДЕРИНГЕ ДОКУМЕНТА ДЛЯ ПРЕДВАРИТЕЛЬНОГО ПРОСМОТРА)

                var fiOldPrint = dlgPrintPreviewDialog.GetType().GetField("printToolStripButton", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                var btnOldPrint = (ToolStripButton)fiOldPrint.GetValue(dlgPrintPreviewDialog);
                btnOldPrint.Visible = false;

                var btnNewPrint = new ToolStripButton(btnOldPrint.Text, btnOldPrint.Image, (s, e) => { pc.Restore(); pd.Print(); });
                btnOldPrint.Owner.Items.Insert(btnOldPrint.Owner.Items.IndexOf(btnOldPrint), btnNewPrint);

                #endregion

                dlgPrintPreviewDialog.FormClosed += (s, e) =>
                {
                    ppd = null;
                };

                dlgPrintPreviewDialog.PrintPreviewControl.Zoom = 1.5f;
                dlgPrintPreviewDialog.Document = pd;
                dlgPrintPreviewDialog.ShowDialog();
            }
        }

        public override void Dispose()
        {
            if (pd != null)
                pd.Dispose();
        }
    }

    public class CrystalReportDocumentProvider : ReportDocumentProvider
    {
        private ReportClass cr = null;

        public override void Init(bool pIsDraft, Data.PickControl pData)
        {
            data = pData;

            cr = new Reports.DebtorsReturnedTareInvoiceReport();
            cr.SetDataSource(data);
        }

        public override void Print()
        {
            this.Print(cr.PrintOptions.PrinterName, 1);
        }

        public override void Print(string printerName, int copies)
        {
            cr.PrintOptions.PrinterName = printerName;
            cr.PrintToPrinter(copies, true, 1, 0);
        }

        public override void Preview()
        {
            if (data != null)
            {
                ReportForm form = new ReportForm();
                form.ReportDocument = cr;
                form.ShowDialog();
            }
        }

        public override void Dispose()
        {
            if (cr != null)
                cr.Dispose();
        }
    }
}
