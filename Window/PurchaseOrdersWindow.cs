using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Dialogs;

namespace WMSOffice.Window
{
    public partial class PurchaseOrdersWindow : GeneralWindow
    {
        public PurchaseOrdersWindow()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        SplashForm splashForm = new SplashForm();
        double selDocID = 0;
        int rowIndex = 0;

        private void RefreshDocs()
        {
            try
            {
                // сохраняем текущее выделение документа
                if (gvDocuments.SelectedRows.Count == 1)
                {
                    selDocID = ((PurchaseOrders.NotClosedReceiptsRow)((DataRowView)gvDocuments.SelectedRows[0].DataBoundItem).Row).Doc_ID;
                    rowIndex = gvDocuments.FirstDisplayedScrollingRowIndex;
                }

                // выполнение основной операции в фоновом режиме
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
                worker.RunWorkerAsync(); // без параметров в этот раз

                splashForm.ActionText = "Подготовка действия...";
                splashForm.ShowDialog(this);
            }
            catch (Exception ex) { ShowError(ex); }
        }

        #region worker
        Data.PurchaseOrders.NotClosedReceiptsDataTable tempTable = null;
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            ((BackgroundWorker)sender).ReportProgress(0, "Идет получение данных...");

            tempTable = this.notClosedReceiptsTableAdapter.GetData();
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            splashForm.ActionText = (string)e.UserState;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            splashForm.ActionText = "Идет обновление информации...";
            // обновление информации
            this.purchaseOrders.NotClosedReceipts.Clear();
            if (tempTable != null) this.purchaseOrders.NotClosedReceipts.Merge(tempTable);
            // восстанавливаем выделение
            if (selDocID != 0)
                foreach (DataGridViewRow row in gvDocuments.Rows)
                    if (selDocID == ((PurchaseOrders.NotClosedReceiptsRow)((DataRowView)row.DataBoundItem).Row).Doc_ID)
                    {
                        row.Selected = true;
                        if (gvDocuments.RowCount > rowIndex)
                            gvDocuments.FirstDisplayedScrollingRowIndex = rowIndex;
                        break;
                    }
            // закрываем окно
            splashForm.CloseForce();
        }
        #endregion

        private void PurchaseOrdersWindow_Load(object sender, EventArgs e)
        {
            // RefreshDocs();
        }

        private void gvDocuments_SelectionChanged(object sender, EventArgs e)
        {
            purchaseOrders.NotClosedReceipts_Detail.Clear();

            if (gvDocuments.SelectedRows.Count == 1)
            {
                try
                {
                    PurchaseOrders.NotClosedReceiptsRow doc = (PurchaseOrders.NotClosedReceiptsRow) ((DataRowView) gvDocuments.SelectedRows[0].DataBoundItem).Row;
                    this.notClosedReceipts_DetailTableAdapter.Fill(
                        this.purchaseOrders.NotClosedReceipts_Detail,
                        doc.Doc_ID, doc.Doc_Type);
                } catch (Exception ex) { ShowError(ex); }
            }


        }
    }
}
