using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;
using WMSOffice.Data.InventoryTableAdapters;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Диалог для управления списком счетных листов инвентаризации
    /// </summary>
    public partial class CountSheetsByInventoryForm : DialogForm
    {
        /// <summary>
        /// Возвращает / устанавливает идентификатор документа (инвентаризации)
        /// </summary>
        private long DocID { get; set; }

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        /// <param name="userID">Идентификато текущей сессии пользователя</param>
        /// <param name="docID">Идентификатор документа (инвентаризации), по которому будут загружены счетные листы</param>
        public CountSheetsByInventoryForm(int userID, long docID)
        {
            InitializeComponent();

            UserID = userID;
            DocID = docID;
            btnRefresh_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обновляет список счетных листов
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                iN_CountSheetsTableAdapter.Fill(inventory.IN_CountSheets, DocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "При загрузке списка счетных листов возникла следующая ошибка:" + Environment.NewLine + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
            }
        }

        /// <summary>
        /// Создает новые счетные листы
        /// </summary>
        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (CreateCountSheetsForm form = new CreateCountSheetsForm())
                if (form.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (IN_CountSheetsTableAdapter adapter = new IN_CountSheetsTableAdapter())
                            adapter.CreateCountSheets(
                                DocID,
                                UserID,
                                (form.CreateUsual ? true : false),
                                (form.CreateEmpty ? form.CountEmpty : 0),
                                (form.CreateWO ? form.CountWO : 0));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            "При создании счетных листов возникла следующая ошибка:" + Environment.NewLine + ex.Message,
                            "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    btnRefresh_Click(this, EventArgs.Empty);
                }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать выделенные листы"
        /// </summary>
        private void btnPrintSelected_Click(object sender, EventArgs e)
        {
            if (dgvCountSheets.SelectedRows.Count > 0)
            {
                PrintDialog printDialog = new PrintDialog() { AllowCurrentPage = false, AllowPrintToFile = false, AllowSelection = false, AllowSomePages = false };
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    PrintWorkerParameters parameters = new PrintWorkerParameters() { PrinterName = printDialog.PrinterSettings.PrinterName };
                    BackgroundWorker printWorker = new BackgroundWorker();
                    printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                    printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                    foreach (DataGridViewRow row in dgvCountSheets.SelectedRows)
                    {
                        long docID = (long)row.Cells[colDocID.Name].Value;
                        string docType = (string)row.Cells[colDocType.Name].Value;
                        parameters.DocIDs.Add(docID);
                        parameters.DocTypes.Add(docType);
                    }
                    splashForm.ActionText = "Печать выбранных счетных листов...";
                    printWorker.RunWorkerAsync(parameters);
                    splashForm.ShowDialog();
                    // обновление списка накладных
                    btnRefresh_Click(this, EventArgs.Empty);
                }
            }
            else
            {
                MessageBox.Show("Для печати нужно выбрать один или несколько счетных листов.",
                                "Счетный лист не выбран", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Печатает в фоне выделенные листы, используя их идентификаторы, переданные в аргументе
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters p = (PrintWorkerParameters)e.Argument;
                for (int i = 0; i < p.DocIDs.Count; ++i)
                {
                    using (Data.Inventory.IN_CSForPrintDataTable table = new Data.Inventory.IN_CSForPrintDataTable())
                    {
                        using (IN_CSForPrintTableAdapter adapter = new IN_CSForPrintTableAdapter())
                        {
                            adapter.Fill(table, p.DocIDs[i], p.DocTypes[i]);
                            using (Reports.InventoryCountSheetReport report = new InventoryCountSheetReport())
                            {
                                #region создание штрих-кода
                                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                                barCodeCtrl.Size = new Size(600, 200);
                                barCodeCtrl.BarCodeHeight = 140;
                                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                                barCodeCtrl.HeaderText = "";
                                barCodeCtrl.LeftMargin = 10;
                                barCodeCtrl.ShowFooter = true;
                                barCodeCtrl.TopMargin = 20;
                                barCodeCtrl.BarCode = (string)table.Rows[0][table.Bar_CodeColumn];
                                byte[] barCode = null;
                                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                                {
                                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                                    barCode = ms.ToArray();
                                }
                                table.Rows[0][table.Bar_Code_ImgColumn] = barCode;
                                #endregion
                                
                                report.SetDataSource((System.Data.DataTable)table);
                                report.PrintOptions.PrinterName = p.PrinterName;
                                report.PrintToPrinter(1, false, 1, 0);
                                // подтверждение печати
                                adapter.UpdateCSStatusAfterPrint(p.DocIDs[i], p.DocTypes[i]);
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
        /// Обрабатывает окончание печати листов в фоне
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                MessageBox.Show("Во время печати листов возникла следующая ошибка: " + Environment.NewLine + Environment.NewLine +
                    e.Result.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

            splashForm.CloseForce();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Предварительный просмотр"
        /// </summary>
        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            if (dgvCountSheets.SelectedRows.Count == 1)
            {
                long docID = (long) dgvCountSheets.SelectedRows[0].Cells[colDocID.Name].Value;
                string docType = (string) dgvCountSheets.SelectedRows[0].Cells[colDocType.Name].Value;
                using (Data.Inventory.IN_CSForPrintDataTable table = new Data.Inventory.IN_CSForPrintDataTable())
                {
                    using (IN_CSForPrintTableAdapter adapter = new IN_CSForPrintTableAdapter())
                    {
                        adapter.Fill(table, docID, docType);
                    }
                    using (Reports.InventoryCountSheetReport report = new InventoryCountSheetReport())
                    {
                        #region создание штрих-кода
                        BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                        barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                        barCodeCtrl.Size = new Size(600, 200);
                        barCodeCtrl.BarCodeHeight = 140;
                        barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                        barCodeCtrl.HeaderText = "";
                        barCodeCtrl.LeftMargin = 10;
                        barCodeCtrl.ShowFooter = true;
                        barCodeCtrl.TopMargin = 20;
                        barCodeCtrl.BarCode = (string)table.Rows[0][table.Bar_CodeColumn];
                        byte[] barCode = null;
                        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                        {
                            barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                            barCode = ms.ToArray();
                        }
                        table.Rows[0][table.Bar_Code_ImgColumn] = barCode;
                        #endregion
                        report.SetDataSource((System.Data.DataTable)table);
                        using (Dialogs.ReportForm reportForm = new ReportForm())
                        {
                            reportForm.ReportDocument = report;
                            reportForm.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Для предварительного просмотра нужно выбрать один счетный лист.",
                                "Счетный лист не выбран или выбрано несколько", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        #region PrintWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для печати счетных листов
        /// </summary>
        private class PrintWorkerParameters
        {
            private List<long> docIDs = new List<long>();
            private List<string> docTypes = new List<string>();

            /// <summary>
            /// Идентификаторы счетных листов
            /// </summary>
            public List<long> DocIDs { get { return docIDs; } }
            /// <summary>
            /// Типы счетных листов
            /// </summary>
            public List<string> DocTypes { get { return docTypes; } }
            /// <summary>
            /// Название принтера
            /// </summary>
            public string PrinterName { get; set; }
        }

        #endregion
    }
}
