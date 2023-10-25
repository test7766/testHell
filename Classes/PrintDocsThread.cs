using System;
using System.ComponentModel;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace WMSOffice.Classes
{
    /// <summary>
    /// Класс, выполняющий печать документов в фоновом потоке
    /// </summary>
    public class PrintDocsThread
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Класс-поставщик отчетов
        /// </summary>
        public IReportProvider ReportProvider { get; set; }

        #endregion

        #region ПЕЧАТЬ ДОКУМЕНТОВ

        /// <summary>
        /// Запуск печати документов в фоновом потоке
        /// </summary>
        /// <param name="pParams">Структура с параметрами печати (название принтера, печатаемые документы и т.д.)</param>
        public void PrintDocumentsAsynch(PrintDocsParameters pParams)
        {
            if (ReportProvider == null)
                throw new NullReferenceException("Не инициализирован поставщик отчетов!");

            var printWorker = new BackgroundWorker();
            printWorker.DoWork += printWorker_DoWork;
            printWorker.RunWorkerCompleted += printWorker_RunWorkerCompleted;
            printWorker.RunWorkerAsync(pParams);
        }

        /// <summary>
        /// Фоновая печать заданных документов
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintDocs(e.Argument as PrintDocsParameters); 
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Печать документов (по заданным параметрам)
        /// </summary>
        /// <param name="pParams">Параметры печати</param>
        protected virtual void PrintDocs(PrintDocsParameters pParams)
        {
            foreach (var doc in pParams.Docs)
                using (var report = ReportProvider.GetReport(doc))
                {
                    report.PrintOptions.PrinterName = pParams.PrinterName;
                    report.PrintToPrinter(1, true, 1, 0);
                }
        }

        /// <summary>
        /// Вывод сообщения об успешности отправки документов на печать
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка во время печати документов!", e.Result as Exception);
            else
                MessageBox.Show("Документы успешно отправлены на печать!", "Печать документов",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region ДРУГИЕ МЕТОДЫ

        /// <summary>
        /// Заполнение заданного выпадающего списка доступными пользователю принтерами
        /// </summary>
        /// <param name="pCmb">Выпадающий список, который нужно заполнить</param>
        public static void FillPrintersComboBox(ComboBox pCmb)
        {
            try
            {
                pCmb.DataSource = null;
                pCmb.Items.Clear();
                foreach (string printerName in PrinterSettings.InstalledPrinters)
                    pCmb.Items.Add(printerName);

                var tmpSettings = new PrinterSettings();
                if (!String.IsNullOrEmpty(tmpSettings.PrinterName) && pCmb.Items.Contains(tmpSettings.PrinterName))
                    pCmb.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка доступных принтеров: ", exc);
            }
        }

        /// <summary>
        /// Добавление информации о печатаемом документе
        /// </summary>
        /// <param name="userID">Сессия пользователя</param>
        /// <param name="processCode">Код процесса</param>
        /// <param name="docType">Вид документа</param>
        /// <param name="docID">Код документа</param>
        /// <param name="docType">Тип документа</param>
        /// <param name="docLines">Количество позиций документа</param>
        /// <param name="printerName">Наименование принтера</param>
        /// <param name="copies">Количество копий</param>
        public static void AddPrintingDocTelemetryData(long userID, string processCode, short docKind, long docID, string docType, short? docLines, string printerName, byte copies)
        {
            try
            {
                using (var adapter = new Data.AdminTableAdapters.PrintDocTypesTableAdapter())
                    adapter.AddPrintDocTelemetryData(userID, processCode, docKind, docID, docType, docLines, printerName, copies);
            }
            catch (Exception exc)
            {
                //Logger.ShowErrorMessageBox("Возникла ошибка во время добавления информации о печатаемом документе: ", exc);
            }
        }

        //public static bool NeedPrintWatermark { get { return true; } }

        public static bool CheckNeedPrintWatermark(long userID, string processCode, short docKind, long docID, string docType)
        {
            try
            {
                var needPrint = (bool?)null;
                using (var adapter = new Data.AdminTableAdapters.PrintDocTypesTableAdapter())
                    adapter.CheckNeedPrintWatermark(userID, processCode, docKind, docID, docType, ref needPrint);
                
                return needPrint ?? false;
            }
            catch (Exception ex)
            {
                //Logger.ShowErrorMessageBox("Возникла ошибка во время получения сведений о необходимости печати водяных знаков в печатаемом документе: ", exc);
                return false;
            }
        }

        #endregion
    }
}
