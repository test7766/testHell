using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Data;
using WMSOffice.Data.MoveToSaleTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Reports;

namespace WMSOffice.Window
{
    public partial class MoveToSaleWindow : GeneralWindow
    {
        /// <summary>
        /// Признак вызова джоба (только в рамках контекста претензионного модуля!!!)
        /// </summary>
        bool InvokeMoveDocsJob = false;

        public MoveToSaleWindow()
        {
            InitializeComponent();
        }

        private void MoveToSaleWindow_Load(object sender, EventArgs e)
        {
            this.InvokeMoveDocsJob = this.DocType == "RO";
            RefreshDocs();
        }

        SplashForm splashForm = new SplashForm();
        private void btnNewDocument_Click(object sender, EventArgs e)
        {
            try
            {
                // выполнение основной операции в фоновом режиме
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync(); // без параметров в этот раз

                splashForm.ActionText = "Идет генерирование Сборочных на перемещение из ПО в отделы ЦС...";
                splashForm.ShowDialog(this);

            } catch (Exception ex)
            {
                ShowError(ex);
            }
        }


        #region worker
        Data.PurchaseOrders.NotClosedReceiptsDataTable tempTable = null;
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            using (QueriesTableAdapter adapter = new QueriesTableAdapter())
            {
                if (this.InvokeMoveDocsJob)
                    adapter.InvokeMoveDocs();
                else
                    adapter.GenerateMoveDocs(UserID);
            }
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            splashForm.ActionText = (string)e.UserState;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // обновление информации
            RefreshDocs();
            // закрываем окно
            splashForm.CloseForce();
        }
        #endregion


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        private void RefreshDocs()
        {
            long selDocID = 0;
            int rowIndex = 0;
            if (gvDocuments.SelectedRows.Count == 1) {
                selDocID = ((WH.DocsRow) ((DataRowView) gvDocuments.SelectedRows[0].DataBoundItem).Row).Doc_ID;
                rowIndex = gvDocuments.FirstDisplayedScrollingRowIndex;
            }

            wH.Docs.Clear();
            wH.Docs.Merge(docsTableAdapter.GetDataByDocType(DocType, UserID));

            if (selDocID != 0)
                foreach (DataGridViewRow row in gvDocuments.Rows)
                    if (selDocID == ((WH.DocsRow)((DataRowView)row.DataBoundItem).Row).Doc_ID)
                    {
                        row.Selected = true;
                        if (gvDocuments.RowCount > rowIndex)
                            gvDocuments.FirstDisplayedScrollingRowIndex = rowIndex;
                        break;
                    }
        }

        public static void DocsPrepare(MoveToSale moveToSale, long docID, string docType)
        {
            moveToSale.Docs.Clear();
            moveToSale.MoveReport.Clear();

            using (Data.MoveToSaleTableAdapters.DocsTableAdapter adapter = new DocsTableAdapter())
            {
                using (Data.MoveToSaleTableAdapters.MoveReportTableAdapter moveReportTableAdapter = new MoveReportTableAdapter())
                {
                    adapter.Fill(moveToSale.Docs, docID, docType);
                    moveReportTableAdapter.Fill(moveToSale.MoveReport, docID);
                }
            }
        }

        public static void BarcodePrepare(MoveToSale moveToSale, long docID)
        {
            using (MoveReportTableAdapter adapter = new MoveReportTableAdapter())
            {
                adapter.Fill(moveToSale.MoveReport, docID);
                if (moveToSale.Docs.Count > 0)
                {
                    // создание штрих-кода
                    BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                    barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                    barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                    barCodeCtrl.BarCodeHeight = 50 * 5;
                    barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                    barCodeCtrl.HeaderText = "";
                    barCodeCtrl.LeftMargin = 10 * 5;
                    barCodeCtrl.ShowFooter = true;
                    barCodeCtrl.TopMargin = 20 * 5;
                    barCodeCtrl.BarCode = moveToSale.Docs[0].Bar_Code; //"12345678PRWMS";
                    byte[] barCode = null;
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                    {
                        barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                        barCode = ms.ToArray();
                    }
                    moveToSale.Docs[0].Bar_Code_IMG = barCode;
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (gvDocuments.SelectedRows.Count == 1)
            {
                // напечатаем сборочный лист
                MoveToSaleReport report = new MoveToSaleReport();
                //BarcodePrepare(moveToSale, DocID);
                
                #region barcode

                    if (moveToSale.Docs.Count > 0)
                    {
                        // создание штрих-кода
                        BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                        barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                        barCodeCtrl.Size = new Size(274 * 5, 108 * 5);
                        barCodeCtrl.BarCodeHeight = 50 * 5;
                        barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                        barCodeCtrl.HeaderText = "";
                        barCodeCtrl.LeftMargin = 10 * 5;
                        barCodeCtrl.ShowFooter = true;
                        barCodeCtrl.TopMargin = 20 * 5;
                        barCodeCtrl.BarCode = moveToSale.Docs[0].Bar_Code; //"12345678PRWMS";
                        byte[] barCode = null;
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            barCode = ms.ToArray();
                        }
                        moveToSale.Docs[0].Bar_Code_IMG = barCode;
                    }

                #endregion
                
                report.SetDataSource(moveToSale);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.Print();
                //form.ShowDialog();

                if (form.IsPrinted)
                {
                    try
                    {
                        // переводим статус
                        docsTableAdapter.UpdateStatus(moveToSale.Docs[0].Doc_ID, "110", UserID);

                        // закрываем окно
                        RefreshDocs();
                    } catch (Exception ex) { ShowError(ex); }
                }
            }
        }

        private void gvDocuments_SelectionChanged(object sender, EventArgs e)
        {
            // очистка результата
            moveToSale.Docs.Clear();
            moveToSale.MoveReport.Clear();
            
            if (gvDocuments.SelectedRows.Count == 1)
            {
                try
                {
                    WH.DocsRow doc = (WH.DocsRow) ((DataRowView) gvDocuments.SelectedRows[0].DataBoundItem).Row;
                    using (Data.MoveToSaleTableAdapters.DocsTableAdapter adapter = new DocsTableAdapter())
                    {
                        adapter.Fill(moveToSale.Docs, doc.Doc_ID, doc.Doc_Type);
                        moveReportTableAdapter.Fill(moveToSale.MoveReport, doc.Doc_ID);
                    }
                } catch (Exception ex) { ShowError(ex); }
            }
        }
    }
}
