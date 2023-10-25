#define waybill

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Shared;
using WMSOffice.Data;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Dialogs.WH;
using WMSOffice.Classes;
using WMSOffice.Classes.ReportProviders.DebtorsReturnedTareInvoice;
using WMSOffice.Controls;
using System.Xml;
using OpenCvSharp;
using System.IO;

namespace WMSOffice.Window
{
    /// <summary>
    /// Диалог для печати пакетов документов (накладных, расходных, реестров) по заказам.
    /// </summary>
    public partial class WHDocsPrintNaklWindow : GeneralWindow
    {
        #region Fields

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Признак, показывающий, были ли документы загружены из архива (т.е. их не нужно переводить по статусам после печати).
        /// </summary>
        private bool docsFromArchive = false;

        /// <summary>
        /// Результаты поиска в архиве.
        /// </summary>
        private Data.PrintNakl archiveData = new Data.PrintNakl();

        /// <summary>
        /// Задание сортировки при печати документа
        /// </summary>
        private PrintDocumentComparer printDocComparer = new PrintDocumentComparer();

        /// <summary>
        /// Строка хранящая пользовательскую сортировку
        /// </summary>
        private string sCustomSortString = string.Empty;

        /// <summary>
        /// Объект-маркер строки, по которой был распечатан пакет налоговых документов.
        /// </summary>
        private object PrintedRowTag = new object();

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        #endregion


        #region Constructor & first show & close

        /// <summary>
        /// Инициализирует новый экземпляр документа.
        /// </summary>
        public WHDocsPrintNaklWindow()
        {
            InitializeComponent();

#if !waybill
            btnEnableWaybillMode.Enabled = false;
#else
            btnShowHideRouteLists_Click(this, EventArgs.Empty);
#endif

            WMSOffice.Dialogs.SearchDocOptionsForm.Initialize(isWaybillModeEnabled);

            btnPrintPackage.Enabled =

                miPrintPackage.Enabled = miPrintInvoice.Enabled = miPrintTaxInvoice.Enabled =
                miPrintControlSheet.Enabled = miPrintRegister.Enabled = miPrintSaleRegister.Enabled =
                miPrintRequirementOrder.Enabled = miPrintBillInvoice.Enabled = miPrintTareInvoice.Enabled =

                miPreviewInvoiceBase.Enabled = miPreviewInvoice.Enabled = miPreviewTaxInvoiceForOptima.Enabled =
                miPreviewControlSheet.Enabled = miPreviewRegister.Enabled = miPreviewSaleRegister.Enabled =
                miPreviewRequirementOrder.Enabled = miPreviewBillInvoice.Enabled = miPreviewTareInvoice.Enabled = false;

            Config.LoadDataGridViewSettings(this.Name, dgvRouteListDocs);
            Config.LoadDataGridViewSettings(this.Name, dgvWaybillDocs);
            Config.LoadDataGridViewSettings(this.Name, dgvDocs);

            dgvcIsAlreadyPrinted.DefaultCellStyle.NullValue = null;
            dgvcIsAlreadyPrinted.DisplayIndex = 0;

            dgvcIsReadyToPrint.DefaultCellStyle.NullValue = null;
            dgvcIsReadyToPrint.DisplayIndex = 0;

            dgvcNeedPrint.DefaultCellStyle.NullValue = null;
            dgvcNeedPrint.DisplayIndex = 0;
        }

        private void InitializePrinters()
        {
            chbIsRemotePrint.Visible = false;

            // список принтеров, принтер по-умолчанию
            try
            {
                try
                {
                    PNPrintersRepositoryCache.Instance.Initialize(this.UserID);
                    chbIsRemotePrint.Visible = true;
                }
                catch (Exception ex)
                {
                    //ShowError(ex);

                    lblPrinter.ToolTipText = ex.Message;
                    lblPrinter.Image = Properties.Resources.exclamation_blink;
                }

                var bs = new BindingSource();
                bs.DataSource = PNPrintersRepositoryCache.Instance.GetPrinters(chbIsRemotePrint.Checked);

                cbPrinters.ComboBox.Tag = bs;

                cbPrinters.ComboBox.ValueMember = "PrinterID";
                cbPrinters.ComboBox.DisplayMember = "PrinterName";
                cbPrinters.ComboBox.DataSource = bs;

                cbPrinters.SelectedItem = PNPrintersRepositoryCache.Instance.GetSelectedPrinter(chbIsRemotePrint.Checked);

                //foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                //    cbPrinters.Items.Add(printerName);

                //System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                //cbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void cbPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PNPrintersRepositoryCache.Instance.SelectPrinter(chbIsRemotePrint.Checked, (IPNPrinter)cbPrinters.SelectedItem);

            this.SetWaybillOperationAccess();
            this.ChangeAccessToPrintOptions();
        }

        private void chbIsRemotePrint_CheckedChanged(object sender, EventArgs e)
        {
            InitializePrintersBySelectedMode();
            this.ChangeAccessToPrintOptions();
        }

        private void InitializePrintersBySelectedMode()
        {
            //PNPrintersRepositoryCache.Instance.SelectPrinter(!chbIsRemotePrint.Checked, (IPNPrinter)cbPrinters.SelectedItem);

            var bs = cbPrinters.ComboBox.Tag as BindingSource;
            bs.DataSource = PNPrintersRepositoryCache.Instance.GetPrinters(chbIsRemotePrint.Checked);
            cbPrinters.SelectedItem = PNPrintersRepositoryCache.Instance.GetSelectedPrinter(chbIsRemotePrint.Checked);
        }

        #region РЕПОЗИТОРИЙ ПРИНТЕРОВ

        public interface IPNPrinter
        {
            int PrinterID { get; }
            string PrinterAlias { get; }
            string PrinterName { get; }
            string PrinterPath { get; }
        }

        public abstract class PNPrinter : IPNPrinter
        {
            public int PrinterID { get; set; }
            public string PrinterAlias { get; set; }
            public string PrinterName { get; set; }
            public string PrinterPath { get; set; }

            public override string ToString()
            {
                return string.Format("{0}", this.PrinterPath);
            }
        }

        public class PNLocalPrinter : PNPrinter
        {
           
        }

        public class PNRemotePrinter : PNPrinter
        {
           
        }

        public interface IPNPrintersRepository<T> where T : IPNPrinter
        {
            void ClearPrinters();
            void FillPrinters(long sessionID);
            IEnumerable<T> Printers { get; }
            T SelectedPrinter { get; }
        }

        public abstract class PNPrintersRepository<T> : IPNPrintersRepository<T> where T : IPNPrinter
        {
            protected readonly List<T> _printers = new List<T>();

            public abstract T SelectedPrinter { get; protected set; }

            #region IPNPrintersRepository<T> Members

            public IEnumerable<T> Printers { get { return _printers; } }

            public abstract void FillPrinters(long sessionID);

            public void ClearPrinters()
            {
                _printers.Clear();
            }

            [Obsolete]
            public void SelectPrinter(T printer)
            {
                foreach (var _printer in _printers)
                    if (_printer.Equals(printer))
                        this.SelectedPrinter = printer;
            }

            #endregion
        }

        public class PNLocalPrintersRepository : PNPrintersRepository<PNLocalPrinter>
        {
            public override PNLocalPrinter SelectedPrinter { get; protected set; }

            public override void FillPrinters(long sessionID)
            {
                var printerID = 0;

                foreach (var printer in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    _printers.Add(new PNLocalPrinter
                    {
                        PrinterID = ++printerID,
                        PrinterAlias = string.Format("PN0{0}", printerID.ToString().PadLeft(2, '0')),
                        PrinterName = printer.ToString(),
                        PrinterPath = printer.ToString()
                    });

                var selectedPrinter = new System.Drawing.Printing.PrinterSettings().PrinterName;
                foreach (var printer in _printers)
                {
                    if (printer.PrinterName.Equals(selectedPrinter, StringComparison.OrdinalIgnoreCase))
                    {
                        this.SelectedPrinter = printer;
                        break;
                    }
                }
            }
        }

        public class PNRemotePrintersRepository : PNPrintersRepository<PNRemotePrinter>
        {
            public override PNRemotePrinter SelectedPrinter { get; protected set; }

            public override void FillPrinters(long sessionID)
            {
                using (var adapter = new Data.PrintNaklTableAdapters.PN_PrintersTableAdapter())
                    foreach (Data.PrintNakl.PN_PrintersRow printer in adapter.GetData(sessionID))
                        _printers.Add(new PNRemotePrinter
                        {
                            PrinterID = printer.Printer_ID,
                            PrinterAlias = printer.Printer_Alias,
                            PrinterName = printer.Printer_Name,
                            PrinterPath = printer.Printer_SharePath
                        });

                foreach (var printer in _printers)
                {
                    this.SelectedPrinter = printer;
                    break;
                }

                if (_printers.Count == 0)
                    throw new Exception("Режим отложенной печати не настроен для Вашего пользователя, обратитесь в ГСПО");
            }
        }

        public class PNPrintersRepositoryCache
        {
            private readonly PNLocalPrintersRepository repLocalPrinters = new PNLocalPrintersRepository();
            private readonly PNRemotePrintersRepository repRemotePrinters = new PNRemotePrintersRepository();

            #region SINGLETON

            private static object syncRoot = new object();

            private static PNPrintersRepositoryCache _instance = null;
            public static PNPrintersRepositoryCache Instance
            {
                get
                {
                    lock (syncRoot)
                    {
                        if (_instance == null)
                            _instance = new PNPrintersRepositoryCache();

                        return _instance;
                    }
                }
            }

            protected PNPrintersRepositoryCache()
            {
                
            }

            #endregion

            public void Initialize(long sessionID)
            {
                this.ClearPrinters();

                repLocalPrinters.FillPrinters(sessionID);
                repRemotePrinters.FillPrinters(sessionID);
            }

            private void ClearPrinters()
            {
                repLocalPrinters.ClearPrinters();
                repRemotePrinters.ClearPrinters();
            }

            public IEnumerable<IPNPrinter> GetPrinters(bool isRemotePrint)
            {
                var printers = new List<IPNPrinter>();

                if (isRemotePrint)
                    foreach(var printer in repRemotePrinters.Printers)
                        printers.Add(printer);
                else
                    foreach (var printer in repLocalPrinters.Printers)
                        printers.Add(printer);

                return printers;
            }

            public IPNPrinter GetSelectedPrinter(bool isRemotePrint)
            {
                if (isRemotePrint)
                    return repRemotePrinters.SelectedPrinter;
                else
                    return repLocalPrinters.SelectedPrinter;
            }

            [Obsolete]
            public void SelectPrinter(bool isRemotePrint, IPNPrinter printer)
            {
                if (isRemotePrint)
                    repRemotePrinters.SelectPrinter((PNRemotePrinter)printer);
                else
                    repLocalPrinters.SelectPrinter((PNLocalPrinter)printer);
            }
        }

        #endregion

        ///// <summary>
        ///// Получение имени альтернативного принтера, сохраненного на предыдущем сеансе
        ///// </summary>
        ///// <param name="defaultPrinterName"></param>
        ///// <returns></returns>
        //private string GetDefaultAlternativePrinterName(string defaultPrinterName)
        //{
        //    object alternativePrinterName = RegistryHelper.GetAlternativePrinterName();

        //    if (alternativePrinterName == null)
        //        return defaultPrinterName;
        //    else
        //        return alternativePrinterName.ToString();
        //}

        private DataGridViewColumn SortedColumn = null;
        private SortOrder SortOrder = SortOrder.Ascending;

        private void dgvDocs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(dgvDocs.SortedColumn.DataPropertyName) && dgvDocs.SortedColumn.SortMode != DataGridViewColumnSortMode.NotSortable)
                {
                    this.SortedColumn = dgvDocs.SortedColumn; // dgvDocs.Columns[e.ColumnIndex];
                    //this.SortOrder = dgvDocs.SortOrder;
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private void dgvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var sortString = this.sCustomSortString;

            //var sortedColumn = dgvDocs.SortedColumn != this.SortedColumn ? (this.SortedColumn ?? dgvDocs.SortedColumn) : dgvDocs.SortedColumn;
            //var sortOrder = dgvDocs.SortOrder == SortOrder.Descending ? SortOrder.Descending : SortOrder.Ascending; // this.SortOrder;

            var sortedColumn = dgvDocs.SortedColumn;
            var sortOrder = dgvDocs.SortOrder;

            if (sortedColumn != null)
            {
                if (sortedColumn.DataPropertyName == "OrderID")
                    sortString = string.Format("{0} {1}, InvoiceID ASC", sortedColumn.DataPropertyName, sortOrder == SortOrder.Ascending ? "ASC" : "DESC");
                else
                    if (sortedColumn.DataPropertyName == "InvoiceID")
                        sortString = string.Format("{0} {1}", sortedColumn.DataPropertyName, sortOrder == SortOrder.Ascending ? "ASC" : "DESC");
                    else
                        sortString = string.Format("{0} {1}, OrderID ASC, InvoiceID ASC", sortedColumn.DataPropertyName, sortOrder == SortOrder.Ascending ? "ASC" : "DESC");

                //sortString = string.IsNullOrEmpty(sortString) ? "PrintWatermark ASC, Orders_Seuqence ASC" : string.Format("PrintWatermark ASC, Orders_Seuqence ASC, {0}", sortString.Replace("PrintWatermark ASC, ", string.Empty).Replace("Orders_Seuqence ASC, ", string.Empty));
                docsBindingSource.Sort = sortString;
                //System.Diagnostics.Debug.WriteLine("dgvDocs_DataBindingComplete: " + docsBindingSource.Sort);
            }

            #region БЛОК РАСКРАСКИ ЭЛЕКТРОННЫХ РН
            try
            {
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    var doc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
                    var hasEDoc = doc.IsEDFlagNull() ? false : Convert.ToBoolean(doc.EDFlag);
                    var needPrint = doc.IsPrintModeNull() ? false : Convert.ToBoolean(doc.PrintMode);

                    row.Cells[dgvcIsAlreadyPrinted.Index].Value = needPrint ? emptyIcon : Properties.Resources.cancel;

                    if (!needPrint)
                    {
                        row.Cells[dgvcIsAlreadyPrinted.Index].ToolTipText = "Печать документа не требуется\nДокумент уже печатался ранее";

                        //for (int c = 0; c < row.Cells.Count; c++)
                        //{
                        //    row.Cells[c].Style.BackColor = Color.LightGray;
                        //    row.Cells[c].Style.SelectionForeColor = Color.LightGray;
                        //}
                    }
                    
                    if (hasEDoc)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = Color.Khaki;
                            row.Cells[c].Style.SelectionForeColor = Color.Khaki;

                            if (doc.EDFlag == 2)
                                row.Cells[c].Style.ForeColor = Color.Blue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            #endregion
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ ДОП. СОГЛАШЕНИЯ ПО ТЕНДЕРУ
            if (dgvDocs.Columns[e.ColumnIndex].DataPropertyName == "SCGP_Flag")
            {
                var value = dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (value == null || Convert.ToDecimal(value) == 0)
                    e.Value = "Нет";
                else
                    e.Value = "Да";
            }
            #endregion
        }

        /// <summary>
        /// Обрабатывает момент первого отображения окна.
        /// </summary>
        private void WHDocsPrintNaklWindow_Shown(object sender, EventArgs e)
        {
            this.InitializePrinters();

            this.SetActiveGrid();

            tbScaner.TextChanged += new EventHandler(tbScaner_TextChanged);
            //tbScaner.Leave += new EventHandler(tbScaner_TextChanged);

            // загрузка списка документов
            this.LoadDocsByMode();
        }

        void tbScaner_TextChanged(object sender, EventArgs e)
        {
            // загрузка списка документов
            this.LoadDocsByMode(tbScaner.Text);
        }

        /// <summary>
        /// Обрабатывает закрытия окна.
        /// </summary>
        private void WHDocsPrintNaklWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvRouteListDocs);
            Config.SaveDataGridViewSettings(this.Name, dgvWaybillDocs);
            Config.SaveDataGridViewSettings(this.Name, dgvDocs);
        }

        #endregion


        #region Properties

        /// <summary>
        /// Возвращает одну (последнюю) выделенную строку из списка накладных.
        /// </summary>
        private Data.PrintNakl.DocsRow SelectedRow
        {
            get
            {
                if (dgvDocs.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.PrintNakl.DocsRow)((DataRowView)dgvDocs.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Возвращает выделенные строки в списке накладных в том порядке, в котором они были загружены из БД
        /// (по умолчанию свойство DataGridView.SelectedRows возвращает набор строк "как попало").
        /// </summary>
        private IList<Data.PrintNakl.DocsRow> SelectedRowsOrdered
        {
            get
            {
                List<Data.PrintNakl.DocsRow> result = new List<WMSOffice.Data.PrintNakl.DocsRow>();
                foreach (DataGridViewRow r in dgvDocs.Rows)
                {
                    if (r.Selected)
                    {
                        result.Add((Data.PrintNakl.DocsRow)((DataRowView)r.DataBoundItem).Row);
                    }
                }
                printDocComparer.AdaptSortSequence(docsBindingSource.Sort);
                result.Sort(printDocComparer);

                return result;
            }
        }

        private IList<Data.PrintNakl.Waybill_DocsRow> SelectedWaybillDocs
        {
            get
            {
                var result = new List<Data.PrintNakl.Waybill_DocsRow>();
                foreach (DataGridViewRow r in dgvWaybillDocs.Rows)
                {
                    if (r.Selected)
                    {
                        result.Add((Data.PrintNakl.Waybill_DocsRow)((DataRowView)r.DataBoundItem).Row);
                    }
                }

                return result;
            }
        }

        /// <summary>
        /// Возвращает одну (последнюю) выделенную строку из списка маршрутных.
        /// </summary>
        private Data.PrintNakl.Route_List_DocsRow SelectedRouteListDocRow
        {
            get
            {
                if (dgvRouteListDocs.SelectedRows.Count == 0)
                    return null;
                else
                    return (Data.PrintNakl.Route_List_DocsRow)((DataRowView)dgvRouteListDocs.SelectedRows[0].DataBoundItem).Row;
            }
        }

        /// <summary>
        /// Возвращает признак, показывающий, был ли напечатан пакет документов по выделенной строке.
        /// </summary>
        private bool IsSelectedRowPrinted
        {
            get
            {
                if (dgvDocs.SelectedRows.Count != 0 && dgvDocs.SelectedRows[0].Tag == PrintedRowTag)
                    return true;
                else
                    return false;
            }
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Меняет доступность кнопок при смене выделения строк в таблице.
        /// </summary>
        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.ChangeAccessToPrintOptions();
        }

        private void ChangeAccessToPrintOptions()
        {
            miPrintTareInvoice.Visible = miPreviewTareInvoice.Visible = false;

            btnPrintPackage.Enabled = miPrintPackage.Enabled =
                    SelectedRow != null && cbPrinters.SelectedItem != null;

            miPreviewTaxInvoiceForOptima.Enabled = miPreviewTaxInvoiceForClient.Enabled = miPrintTaxInvoice.Enabled =
                SelectedRow != null && cbPrinters.SelectedItem != null && (docsFromArchive || IsSelectedRowPrinted)
                && SelectedRow.is_print == 1 && !chbIsRemotePrint.Checked;

            miPreviewInvoice.Enabled = 
                SelectedRow != null && cbPrinters.SelectedItem != null && (docsFromArchive || IsSelectedRowPrinted);

            miPrintInvoice.Enabled = miPreviewInvoiceBase.Enabled = 
                miPrintControlSheet.Enabled = miPreviewControlSheet.Enabled =
                miPreviewRegister.Enabled =
                miPrintSaleRegister.Enabled = miPreviewSaleRegister.Enabled =
                miPrintRequirementOrder.Enabled = miPreviewRequirementOrder.Enabled =
                miPrintBillInvoice.Enabled = miPreviewBillInvoice.Enabled =
                miPrintTareInvoice.Enabled = miPreviewTareInvoice.Enabled =
                miPrintDocAgreement.Enabled = miPreviewDocAgreement.Enabled =
                SelectedRow != null && cbPrinters.SelectedItem != null && (docsFromArchive || IsSelectedRowPrinted) && !chbIsRemotePrint.Checked;

            miPrintRegister.Enabled = false;
        }

        /// <summary>
        /// Обновляет данные, загружая список не распечатанных документов.
        /// </summary>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // загрузка списка документов
            this.LoadDocsByMode();
        }

        private void LoadDocs()
        {
            this.LoadDocs((string)null);
        }

        private void LoadDocs(string routeListBarCode)
        {
            this.LoadDocs(routeListBarCode, (int?)null);
        }

        private void LoadDocs(string routeListBarCode, int? routeListNumber)
        {
            BackgroundWorker loadDocsWorker = new BackgroundWorker();
            loadDocsWorker.DoWork += new DoWorkEventHandler(loadDocsWorker_DoWork);
            loadDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadDocsWorker_RunWorkerCompleted);
            LoadWorkerParameters parameters = new LoadWorkerParameters()
            {
                CurrentDocuments = !docsFromArchive,
                SearchType = WMSOffice.Dialogs.SearchDocOptionsForm.SearchType.ByRoute,
                RouteListBarCode = routeListBarCode,
                RouteListNumber = routeListNumber
            };

            if (isWaybillModeEnabled && string.IsNullOrEmpty(routeListBarCode))
            {
                parameters.Waybills = new WaybillParameters();
                foreach (var waybill in this.SelectedWaybillDocs)
                    parameters.Waybills.Add(new WaybillParameter { RouteListNumber = waybill.Route_List_Number, AddressID = waybill.Delivery_Code });
            }

            this.sCustomSortString = docsBindingSource.Sort == null ? "OrderID ASC, InvoiceID ASC" : docsBindingSource.Sort; // запоминаем пользовательскую сортировку
            docsBindingSource.Sort = string.Empty; // очищаем сортировку после ее запоминания и перед обновлением источника данных
            docsBindingSource.DataSource = null;
            splashForm.ActionText = !docsFromArchive ? "Загрузка текущих документов..." : "Загрузка текущих документов из архива...";
            loadDocsWorker.RunWorkerAsync(parameters);
            splashForm.ShowDialog();
        }

        /// <summary>
        /// Загружает в фоне список документов, используя параметры, переданные в аргументе.
        /// </summary>
        private void loadDocsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            LoadWorkerParameters parameters = (LoadWorkerParameters)e.Argument;
            try
            {
                using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                {
                    docsAdapter.SetTimeout(300);

                    // загрузка документов в зависимости от типа поиска
                    if (parameters.CurrentDocuments)
                    {
                        var oWaybills = parameters.Waybills == null ? (XmlDocument)null : parameters.Waybills.CreateXml();
                        var sWaybills = oWaybills == null ? (string)null : oWaybills.InnerXml;

                        //docsAdapter.Fill(printNakl.Docs, UserID, tbScaner.Text);
                        object oFictive = null;
                        docsAdapter.FillCons(printNakl.Docs, UserID, parameters.RouteListBarCode, (string)null, (double?)null, (bool?)null, ref oFictive, (byte?)null, (int?)null, (int?)null, sWaybills);
                    }
                    else if (parameters.SearchType == Dialogs.SearchDocOptionsForm.SearchType.ByOrderNumber)
                    {
                        //docsAdapter.FillFromArchive(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByOrderNumber, parameters.OrderID, null, null, null, null, null);
                        object oFictive = null;
                        docsAdapter.FillFromArchiveCons(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByOrderNumber, parameters.OrderID, null, null, null, null, null, ref oFictive, (int?)null, (object)null);
                    }
                    else if (parameters.SearchType == Dialogs.SearchDocOptionsForm.SearchType.ByInvoiceNumber)
                    {
                        //docsAdapter.FillFromArchive(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByInvoiceNumber, parameters.InvoiceID, null, null, null, null, null);
                        object oFictive = null;
                        docsAdapter.FillFromArchiveCons(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByInvoiceNumber, parameters.InvoiceID, null, null, null, null, null, ref oFictive, (int?)null, (object)null);
                    }
                    else if (parameters.SearchType == Dialogs.SearchDocOptionsForm.SearchType.ByDebtor)
                    {
                        //docsAdapter.FillFromArchive(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByDebtor, null, parameters.DebtorID, parameters.DateFrom, parameters.DateTo, parameters.AddressID, null);
                        object oFictive = null;
                        docsAdapter.FillFromArchiveCons(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByDebtor, null, parameters.DebtorID, parameters.DateFrom, parameters.DateTo, parameters.AddressID, null, ref oFictive, (int?)null, (object)null);
                    }
                    else if (parameters.SearchType == Dialogs.SearchDocOptionsForm.SearchType.ByRoute)
                    {
                        var oWaybills = parameters.Waybills == null ? (XmlDocument)null : parameters.Waybills.CreateXml();
                        var sWaybills = oWaybills == null ? (string)null : oWaybills.InnerXml;

                        //docsAdapter.FillFromArchive(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByRoute, null, null, null, null, parameters.RouteListNumber, null);
                        object oFictive = null;
                        docsAdapter.FillFromArchiveCons(archiveData.Docs, UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByRoute, null, null, null, null, null, null, ref oFictive, parameters.RouteListNumber, sWaybills);
                    }
                }
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обрабатывает окончание загрузки в фоне списка документов.
        /// </summary>
        private void loadDocsWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError(e.Result as Exception);
                printNakl.Docs.Clear();
                archiveData.Docs.Clear();
            }

            if (docsFromArchive)
                docsBindingSource.DataSource = archiveData.Docs;
            else
                docsBindingSource.DataSource = printNakl.Docs;

            var sortString = this.sCustomSortString;

            if (this.isWaybillModeEnabled)
                sortString = string.IsNullOrEmpty(sortString) ? "PrintWatermark ASC, Orders_Seuqence ASC" : string.Format("PrintWatermark ASC, Orders_Seuqence ASC, {0}", sortString.Replace("PrintWatermark ASC, ", string.Empty).Replace("Orders_Seuqence ASC, ", string.Empty));
            else
                sortString = (sortString ?? string.Empty).Replace("PrintWatermark ASC, ", string.Empty).Replace("Orders_Seuqence ASC, ", string.Empty);

            //if (this.isWaybillModeEnabled)
            //    sortString = string.IsNullOrEmpty(sortString) ? "PrintWatermark ASC, Orders_Seuqence ASC" : string.Format("PrintWatermark ASC, Orders_Seuqence ASC, {0}", sortString.Replace("PrintWatermark ASC, Orders_Seuqence ASC, ", string.Empty));
            //else
            //    sortString = (sortString ?? string.Empty).Replace("PrintWatermark ASC, Orders_Seuqence ASC, ", string.Empty);
            
            docsBindingSource.Sort = sortString;
            //System.Diagnostics.Debug.WriteLine("loadDocsWorker_RunWorkerCompleted: " + docsBindingSource.Sort);

            if (!docsFromArchive)
            {
                lblDocsCount.Text = printNakl.Docs.Rows.Count.ToString();

                #region РАСЧЕТ ЧИСЛА ПЕЧАТАЕМЫХ ДОКУМЕНТОВ
                var cntDocsToPrint = 0;
                foreach (PrintNakl.DocsRow doc in printNakl.Docs)
                {
                    var needPrint = doc.IsPrintModeNull() ? false : Convert.ToBoolean(doc.PrintMode);
                    if (needPrint)
                        cntDocsToPrint++;
                }
                lblDocsCount.Text = cntDocsToPrint.ToString();
                #endregion

                if (printNakl.Docs.Rows.Count > 0)
                {
                    var doc = (PrintNakl.DocsRow)printNakl.Docs.Rows[0];
                    lblDocsCountNT.Text = (doc.IsOrders_OutNull() ? 0 : doc.Orders_Out).ToString();
                }
            }

            splashForm.CloseForce();
        }

        private void ClearDocs()
        {
            try
            {
                printNakl.Docs.Clear();
                archiveData.Docs.Clear();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск в архиве".
        /// </summary>
        private void btnFind_Click(object sender, EventArgs e)
        {
            using (Dialogs.SearchDocOptionsForm form = new Dialogs.SearchDocOptionsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (this.isWaybillModeEnabled)
                    {
                        var routeListNumber = form.RouteListNumber;
                        var deliveryCode = form.DeliveryCode;
                        var waybillDateFrom = routeListNumber.HasValue ? (DateTime?)null : form.WaybillDateFrom;
                        var waybillDateTo = routeListNumber.HasValue ? (DateTime?)null : form.WaybillDateTo;
                        var invoiceNumber = form.InvoiceNumber;
                        this.LoadDocsByMode(true, (string)null, routeListNumber, deliveryCode, waybillDateFrom, waybillDateTo, invoiceNumber);
                    }
                    else
                    {
                        BackgroundWorker loadDocsWorker = new BackgroundWorker();
                        loadDocsWorker.DoWork += new DoWorkEventHandler(loadDocsWorker_DoWork);
                        loadDocsWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadDocsWorker_RunWorkerCompleted);
                        LoadWorkerParameters parameters = new LoadWorkerParameters()
                        {
                            CurrentDocuments = false,
                            SearchType = form.SelectedSearchType,
                            OrderID = form.OrderNumber,
                            InvoiceID = form.InvoiceNumber,
                            DebtorID = form.DebtorID,
                            DateFrom = form.DateFrom,
                            DateTo = form.DateTo,
                            AddressID = form.AddressID,
                            RouteListNumber = form.RouteListNumber
                        };

                        this.sCustomSortString = docsBindingSource.Sort == null ? "OrderID ASC, InvoiceID ASC" : docsBindingSource.Sort; // запоминаем пользовательскую сортировку
                        docsBindingSource.Sort = string.Empty; // очищаем сортировку после ее запоминания и перед обновлением источника данных
                        docsBindingSource.DataSource = null;
                        splashForm.ActionText = "Загрузка документов из архива...";
                        
                        docsFromArchive = true;
                        
                        loadDocsWorker.RunWorkerAsync(parameters);
                        splashForm.ShowDialog();
                    }
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать пакет документов".
        /// </summary>
        private void btnPrintPackage_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvDocs.SelectedRows)
            //{
            //    var doc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
            //    var needPrint = doc.IsPrintModeNull() ? false : Convert.ToBoolean(doc.PrintMode);

            //    if (!needPrint)
            //        row.Selected = false;
            //}

            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null /*&& this.ContinuePrinting()*/)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.Package,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };

                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать пакетов выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                // пометка напечатанных строк
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    if (row.Selected)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = Color.LightGreen;
                            row.Cells[c].Style.SelectionForeColor = Color.LightGreen;
                        }
                        row.Tag = PrintedRowTag;

                        if (chbIsRemotePrint.Checked)
                        {
                            var doc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
                            doc.PrintMode = (byte)0;

                            row.Cells[dgvcIsAlreadyPrinted.Index].ToolTipText = "Печать документа не требуется\nДокумент был отправлен на печать";
                        }
                    }
                }
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    row.Selected = false;
                }
            }
        }

        ///// <summary>
        ///// Проверка выбора отдельного принтера для печати реестров реализации перед запуском процесса печати пакета документов
        ///// </summary>
        ///// <returns></returns>
        //private bool ContinuePrinting()
        //{
        //    if (string.Compare(cbPrinters.SelectedItem.ToString(), cbAlternativePrinters.SelectedItem.ToString()) == 0 &&
        //        MessageBox.Show("Рекомендуется выбрать отдельный принтер для печати реестров реализации. Все равно продолжить печать?",
        //                        "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
        //        return false;

        //    return true;
        //}

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать расходную".
        /// </summary>
        private void miPrintInvoice_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.Invoice,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать расходных накладных для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать налоговую".
        /// </summary>
        private void miPrintTaxInvoice_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.TaxInvoice,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать налоговых накладных для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать контрольный лист".
        /// </summary>
        private void miPrintControlSheet_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.ControlSheet,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать контрольных листов для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать реестр лек. средств".
        /// </summary>
        private void miPrintRegister_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.Register,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать реестров лек. средств для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать реестр реализации лек. средств".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miPrintSaleRegister_Click(object sender, EventArgs e)
        {
            // TODO - реализовать печать 

            //if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            //{
            //    BackgroundWorker printWorker = new BackgroundWorker();
            //    printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
            //    printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
            //    PrintWorkerParameters parameters = new PrintWorkerParameters()
            //    {
            //        PrinterName = cbPrinters.SelectedItem.ToString(),
            //        ReportTypes = ReportTypes.SaleRegister
            //    };
            //    foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
            //    {
            //        parameters.DocsToPrint.Add(r);
            //    }

            //    splashForm.ActionText = "Печать реестров лек. средств для выбранных документов...";
            //    printWorker.RunWorkerAsync(parameters);
            //    splashForm.ShowDialog();
            //}
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать заказ-требование".
        /// </summary>
        private void miPrintRequirementOrder_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.OrderRequirement,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                if (parameters.DocsToPrint.Count > 0)
                {
                    splashForm.ActionText = "Печать заказов-требований для выбранных документов...";
                    printWorker.RunWorkerAsync(parameters);
                    splashForm.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать счет-фактуру".
        /// </summary>
        private void miPrintBillInvoice_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.BillInvoice,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать счет-фактур для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }


        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать накладную на оборотную тару".
        /// </summary>
        private void miPrintTareInvoice_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.TareInvoice,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать накладных на оборотную тару для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Напечатать доп. соглашение к тендеру".
        /// </summary>
        private void miPrintDocAgreement_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.TenderAgreement,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                splashForm.ActionText = "Печать доп. соглашения к тендеру для выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }


        string responsiblePerson = string.Empty; // ответственное лицо за первичную печать документов

        /// <summary>
        /// Печатает в фоне отчеты по выбранным документам, используя параметры, переданные в аргументе.
        /// </summary>
        private void printWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                PrintWorkerParameters p = (PrintWorkerParameters)e.Argument;

                var waybillDocs = new List<Data.PrintNakl.Waybill_DocsRow>();

                if (p.WaybillDocs == null)
                    waybillDocs.Add(null);
                else
                    waybillDocs.AddRange(p.WaybillDocs);

                foreach (var waybillDoc in waybillDocs)
                {
                    var docsToPrint = new List<Data.PrintNakl.DocsRow>(p.DocsToPrint);

                    //foreach (Data.PrintNakl.DocsRow docsRow in p.DocsToPrint)
                    for (int iDocsCounter = 0; iDocsCounter < docsToPrint.Count; iDocsCounter++)
                    {
                        var docsRow = docsToPrint[iDocsCounter];

                        if (waybillDoc != null)
                        {
                            // Фильтрация РН при мульти печати
                            if (!(waybillDoc.Route_List_Number.Equals(docsRow.Rout_Number.ToString(), StringComparison.OrdinalIgnoreCase) && waybillDoc.Delivery_Code.Equals(docsRow.DeliveryAddressID)))
                                continue;
                        }
#if TEST
                        docsToPrint.Remove(docsRow);
                        continue;
#endif
                        // запросим проверку на разрешение печати (первичной)
                        // --- если она неуспешна, то получаем исключение и печать останавливаем
                        // --- если она успешна, то получаем ответственное лицо для подписи
                        if (!p.IsRemotePrint && !docsFromArchive)
                            using (Data.PrintNaklTableAdapters.DocDetailTableAdapter adapter = new WMSOffice.Data.PrintNaklTableAdapters.DocDetailTableAdapter())
                            {
                                object respPersonObj = adapter.CheckAllowDocumentPackageFirstPrint(this.UserID, docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID);
                                responsiblePerson = respPersonObj != null ? respPersonObj.ToString() : string.Empty;
                            }

                        Data.PrintNakl naklData = PrepareDataSetForDoc(docsRow, !p.IsRemotePrint);

                        #region Расходная накладная
                        if ((p.ReportTypes & ReportTypes.Invoice) > 0 || p.ReportTypes == ReportTypes.Package)
                        {
                            int copies = 1;
                            if (p.ReportTypes == ReportTypes.Package || p.CheckInvoiceMode)
                                copies = docsRow.InvoiceCount;
                            if (copies > 0)
                            {
                                var needRemotePrint = false;

                                var edFlag = docsRow.IsEDFlagNull() ? false : docsRow.EDFlag == 2 ? false : Convert.ToBoolean(docsRow.EDFlag); // признак электронной РН

                                // Электронные РН не печатаем (!!!)
                                var allowPrintDoc = !edFlag;
                                if (allowPrintDoc)
                                {
                                    if (!p.IsRemotePrint)
                                    {
                                        var tenderInvoice = docsRow.Isflag_TenderInvoiceNull() ? (int?)null : docsRow.flag_TenderInvoice;

                                        if (!p.IsRemotePrint)
                                            this.PrepareAdditionalRequisites(docsRow, tenderInvoice, ref naklData);

                                        var needPrintWatermark = docsRow.IsPrintWatermarkNull() ? false : docsRow.PrintWatermark == 2 ? false : Convert.ToBoolean(docsRow.PrintWatermark);
                                        var watermarkType = docsRow.IsPrintWatermarkNull() ? 0 : docsRow.PrintWatermark;
                                        //var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "PN", 5, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT);

                                        using (var report = GetInvoiceReport(docsRow.InvoicePrintDate, docsRow.flag_Invoice, tenderInvoice, docsRow.DebtorID, Convert.ToInt32(docsRow.IsEDFlagNull() ? (byte)0 : docsRow.EDFlag), docsRow.IsDocumentCategoryNull() ? string.Empty : docsRow.DocumentCategory))
                                        {
                                            report.SetDataSource(!p.IsRemotePrint ? GetInvoiceReportData(naklData) : naklData);
                                            report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

                                            if (report.ParameterFields["WatermarkType"] != null)
                                                report.SetParameterValue("WatermarkType", watermarkType);

                                            var signElectronicDoc = !docsRow.PrintClientCopy_Flag;
                                            string apendix = signElectronicDoc ? "(електронний документ)" : string.Empty;
                                            report.SetParameterValue("@TaxApendix", apendix);

                                            report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                            report.PrintToPrinter(copies, true, 1, 0);

                                            // сохранение PDF-варианта РН
                                            this.SaveDocAttributes(docsRow, report);

                                            // логирование факта печати
                                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 5, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                        }
                                    }
                                    else
                                    {
                                        needRemotePrint = true;
                                    }
                                }
                                else
                                {
                                    if (p.IsRemotePrint)
                                        needRemotePrint = true;
                                }

                                if (needRemotePrint)
                                {
                                    // Создаем задание отложенной печати

                                    var edFlagByte = Convert.ToByte(docsRow.IsEDFlagNull() ? (byte)0 : docsRow.EDFlag); // признак электронной РН

                                    using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                                    {
                                        docsAdapter.SetTimeout(300);
                                        docsAdapter.CreatePrintTask(UserID, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, docsRow.IsRout_NumberNull() ? (int?)null : Convert.ToInt32(docsRow.Rout_Number), docsRow.DeliveryAddressID, docsFromArchive, "PN", p.SelectedPrinter.PrinterAlias, edFlagByte, p.ReprintMode, copies);
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Доп. соглашение для тендера
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.TenderAgreement) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            var copyAgreements = docsRow.SCGP_Flag;
                            if (copyAgreements > 0)
                            {
                                var agreementsData = GetDocAgreementReportData(docsRow.CompanyID, docsRow.InvoiceID, docsRow.SDDCT);
                                using (var report = new WMSOffice.Reports.PNInvoiceAgreementReport())
                                {
                                    report.SetDataSource(agreementsData);

                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintToPrinter(copyAgreements, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 15, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(agreementsData.DocTenderAgreements.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copyAgreements));
                                }
                            }
                        }
                        #endregion

                        #region Промо флаер

                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.PromoFlyer) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            var promoID = docsRow.IsPromo_IDNull() ? (int?)null : docsRow.Promo_ID;
                            if (promoID.HasValue)
                            {
                                var promoFlyersData = GetPromoFlyersReportData(promoID.Value);

                                using (var report = new WMSOffice.Reports.PromoFlyerReport())
                                {
                                    report.SetDataSource(promoFlyersData);

                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintToPrinter(1, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 16, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, null, p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                }

                                var doco = docsRow.InvoiceID;
                                var dcto = docsRow.SDDCT;

                                using (var adapter = new Data.PrintNaklTableAdapters.PromoFlyersTableAdapter())
                                    adapter.UpdateStatus(promoID.Value, doco, dcto);
                            }
                        }
                        #endregion

                        #region Налоговая накладная
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.TaxInvoice) > 0 || p.ReportTypes == ReportTypes.Package) &&
                            docsRow.is_print == 1) // Проверка, разрешено ли для этого дебитора печать налоговых (возможно, для него нужно печатать только сводные)
                        {
                            if (p.ReportTypes != ReportTypes.Package || p.ReportTypes == ReportTypes.Package && docsRow.TaxInvoiceCount > 0)
                            {
                                bool debtorCopy = true;
                                bool allowPrint = docsRow.PrintClientCopy_Flag;

                                if (allowPrint)
                                {
                                    Data.PrintNakl.DocHeadersDataTable docHeaders = new Data.PrintNakl.DocHeadersDataTable();
                                    using (Data.PrintNaklTableAdapters.DocHeadersTableAdapter docHeadersAdapter = new Data.PrintNaklTableAdapters.DocHeadersTableAdapter())
                                    {
                                        docHeadersAdapter.SetTimeout(300);

                                        if (docsFromArchive)
                                            docHeadersAdapter.FillFromArchive(docHeaders, docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID, UserID, false, debtorCopy);
                                        else
                                            docHeadersAdapter.Fill(docHeaders, docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID, UserID, false, debtorCopy);
                                    }

                                    foreach (Data.PrintNakl.DocHeadersRow docHeadersRow in docHeaders.Rows)
                                    {
                                        // Электронная
                                        if (docHeadersRow.MarkEV01 == 0)
                                            continue;

                                        naklData.DocHeaders.Clear();
                                        Data.PrintNakl.DocHeadersRow tmpRow = naklData.DocHeaders.NewDocHeadersRow();
                                        object[] tmpItemArray = (object[])docHeadersRow.ItemArray.Clone();
                                        if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                                            Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
                                        tmpRow.ItemArray = tmpItemArray;
                                        naklData.DocHeaders.AddDocHeadersRow(tmpRow);

                                        if (docsRow.InvoicePrintDate >= (new DateTime(2015, 1, 1)))
                                        {
                                            using (Reports.PNTaxInvoiceReport_Since_01_2015 report = GetTaxInvoiceReport_Since_01_2015(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate >= (new DateTime(2014, 12, 1)))
                                        {
                                            using (Reports.PNTaxInvoiceReport_Since_07_2014 report = GetTaxInvoiceReport_Since_07_2014(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate >= (new DateTime(2014, 3, 1)))
                                        {
                                            using (Reports.PNTaxInvoiceReport_Since_01_2014 report = GetTaxInvoiceReport_Since_01_2014(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate >= (new DateTime(2011, 12, 16)))
                                        {
                                            using (Reports.PNTaxInvoiceReport report = GetTaxInvoiceReport(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate >= (new DateTime(2011, 1, 10)) && docsRow.InvoicePrintDate <= (new DateTime(2011, 12, 15)))
                                        {
                                            using (Reports.PNTaxInvoiceOld3Report report = GetTaxInvoiceOld3Report(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate >= (new DateTime(2011, 1, 1)) && docsRow.InvoicePrintDate <= (new DateTime(2011, 1, 9)))
                                        {
                                            using (Reports.PNTaxInvoiceOld2Report report = GetTaxInvoiceOld2Report(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                        else if (docsRow.InvoicePrintDate < (new DateTime(2011, 1, 1)))
                                        {
                                            using (Reports.PNTaxInvoiceOldReport report = GetTaxInvoiceOldReport(naklData))
                                            {
                                                report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                                report.PrintToPrinter(1, true, 1, 0);

                                                // логирование факта печати
                                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(1));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion

                        #region OBSOLETE Реестр лек. средств. (приемки - для клиента)
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.Register) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            int copies = 1;
                            if (p.ReportTypes == ReportTypes.Package)
                                copies = docsRow.RegisterCount;

                            //  copies = (copies == 1 ? 2 : copies); // TODO выставить только одну копию - принудительная печать реестра в кол-ве 2-х экземпляров, если кол-во копий равно 1

                            if (copies > 0)
                            {
                                using (Reports.PNRegister report = GetRegisterReport(naklData))
                                {
                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    //report.PrintOptions.PrinterDuplex = PrinterDuplex.Horizontal;
                                    report.PrintOptions.PrinterDuplex = this.GetPrinterDuplexRegime(naklData);
                                    report.PrintToPrinter(copies, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 13, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                }
                            }
                        }
                        #endregion

                        #region OBSOLETE Реестр реализации лек. средств. (для Оптимы) в случае выбора альтернативного принтера
                        //if (!p.IsRemotePrint && (((p.ReportTypes & ReportTypes.SaleRegister) > 0 || p.ReportTypes == ReportTypes.Package) && p.UseAlternativePrinter()))
                        //{
                        //    int copies = 1;
                        //    if (p.ReportTypes == ReportTypes.Package)
                        //        copies = docsRow.RegisterCount;

                        //    copies = (copies == 1 ? 2 : copies); // TODO выставить только одну копию - принудительная печать реестра в кол-ве 2-х экземпляров, если кол-во копий равно 1

                        //    if (copies > 0)
                        //    {
                        //        using (Reports.PNSaleRegister report = GetSaleRegisterReport(naklData))
                        //        {
                        //            report.PrintOptions.PrinterName = p.AlternativePrinterName;
                        //            report.PrintToPrinter(copies, true, 1, 0);
                        //        }
                        //    }
                        //}
                        #endregion

                        #region Контрольный лист
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.ControlSheet) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            int copies = 1;
                            if (p.ReportTypes == ReportTypes.Package)
                                copies = docsRow.InvoiceDebtorCount;
                            if (copies > 0)
                            {
                                using (Reports.PNControlSheetReport report = GetControlSheetReport(naklData))
                                {
                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintToPrinter(copies, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 12, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                }
                            }
                        }
                        #endregion

                        #region Заказ-требование
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.OrderRequirement) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            int copies = 1;
                            if (p.ReportTypes == ReportTypes.Package)
                                copies = docsRow.OrderRequirementCount;
                            if (copies > 0)
                            {
                                using (Reports.PNOrderRequirementReport report = GetOrderRequirementReport(naklData))
                                {
                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintToPrinter(copies, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 11, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                }
                            }
                        }
                        #endregion

                        #region Счет-фактура
                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.BillInvoice) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            int copies = 1;
                            if (p.ReportTypes == ReportTypes.Package)
                                copies = docsRow.BillInvoiceCount;
                            if (copies > 0)
                            {
                                using (Reports.PNBillInvoiceReport report = GetBillInvoiceReport(naklData))
                                {
                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintToPrinter(copies, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 10, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                }
                            }
                        }
                        #endregion

                        #region Накладная на оборотную тару
                        var tareInvoicePrintFlag = false;

                        if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.TareInvoice) > 0 || p.ReportTypes == ReportTypes.Package))
                        {
                            int copies = docsRow.TareInvoiceCount;
                            if (copies > 0)
                            {
                                tareInvoicePrintFlag = true;

                                var isDraft = false;
                                var pickControlData = DebtorsReturnedTareInvoiceHelper.GetTareInvoiceReportData(docsRow, this.UserID, out isDraft);
                                if (pickControlData != null)
                                {
                                    using (var rdp = new PrintReportDocumentProvider())
                                    {
                                        isDraft = false; // всегда в режиме печати формируем рабочий вариант
                                        rdp.Init(isDraft, pickControlData);
                                        rdp.Print(p.SelectedPrinter.PrinterName, copies);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 14, Convert.ToInt64(docsRow.InvoiceID), docsRow.SDDCT, Convert.ToInt16(pickControlData.CT_Tare_Invoice_Details.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                    }
                                }
                            }
                        }
                        #endregion

                        #region OBSOLETE(GSPO-3216) Спецификация (для клиента 10624)

                        //if (docsRow.DebtorID == 10624)
                        //    if (!p.IsRemotePrint && ((p.ReportTypes & ReportTypes.Invoice) > 0 || p.ReportTypes == ReportTypes.Package))
                        //    {
                        //        int copies = 3;
                        //        if (copies > 0)
                        //        {
                        //            using (Reports.PNSpecificationReport report = GetSpecificationReport(naklData))
                        //            {
                        //                report.PrintOptions.PrinterName = p.PrinterName;
                        //                report.PrintToPrinter(copies, true, 1, 0);
                        //            }
                        //        }
                        //    }

                        #endregion

                        #region Смена статуса для документа НЕ ИЗ АРХИВА
                        if (!p.IsRemotePrint && !docsFromArchive)
                        {
                            var routNumber = tareInvoicePrintFlag ? docsRow.Rout_Number : (long?)null;
                            var deliveryAddressID = tareInvoicePrintFlag ? docsRow.DeliveryAddressID : (int?)null;

                            var edFlag = Convert.ToByte(docsRow.IsEDFlagNull() ? (byte)0 : docsRow.EDFlag); // признак электронной РН

                            using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                            {
                                docsAdapter.SetTimeout(300);
                                docsAdapter.UpdateDocStatus(docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID, UserID, routNumber, deliveryAddressID, edFlag, p.ReprintMode);
                            }
                        }
                        #endregion

                        docsToPrint.Remove(docsRow);
                        iDocsCounter--;
                    }

                    if (waybillDoc != null)
                    {
                        #region ТТН

                        //int copies = p.DocsToPrint.Count > 0 ? (waybillDoc.IsCopiesNumberNull() ? 0 : waybillDoc.CopiesNumber) : 1; // p.DocsToPrint.Count > 0 ? 2 : 1;
                        int copies = waybillDoc.IsCopiesNumberNull() ? 0 : waybillDoc.CopiesNumber;

                        if (copies > 0)
                        {
                            if (!p.IsRemotePrint)
                            {
                                Data.PrintNakl naklData = GetWaybillReportData(waybillDoc);
                                var waybillID = this.GetWaybillID(waybillDoc);
                                var needPrintWatermark = waybillDoc.IsPrintWatermarkNull() ? false : Convert.ToBoolean(waybillDoc.PrintWatermark);

                                using (var report = GetWaybillReport(naklData, waybillID, needPrintWatermark))
                                {
                                    report.PrintOptions.PrinterName = p.SelectedPrinter.PrinterName;
                                    report.PrintOptions.PrinterDuplex = PrinterDuplex.Horizontal;
                                    report.PrintToPrinter(copies, true, 1, 0);

                                    // логирование факта печати
                                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 7, waybillID, "TN", Convert.ToInt16(naklData.PN_WaybillReport_Details.Count), p.SelectedPrinter.PrinterName, Convert.ToByte(copies));
                                }
                            }
                            else
                            {
                                // Создаем задание отложенной печати

                                var waybillID = this.GetWaybillID(waybillDoc);
                                using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                                {
                                    docsAdapter.SetTimeout(300);
                                    docsAdapter.CreatePrintTask(UserID, Convert.ToInt64(waybillID), "TN", Convert.ToInt32(waybillDoc.Route_List_Number), waybillDoc.Delivery_Code, docsFromArchive, "TTN", p.SelectedPrinter.PrinterAlias, (byte)0, p.ReprintMode, copies);
                                }
                            }
                        }

                        #endregion
                    }
                }

                // Если для печати реестра реализации не выбран альтернативный принтер, тогда печать реестра выполнить после печати всех пакетов документов
                #region OBSOLETE Процесс печати реестров реализации в цикле
                //if (((p.ReportTypes & ReportTypes.SaleRegister) > 0 || p.ReportTypes == ReportTypes.Package) && !p.UseAlternativePrinter())
                //    foreach (Data.PrintNakl.DocsRow docsRow in p.DocsToPrint)
                //    {
                //        Data.PrintNakl naklData = PrepareDataSetForDoc(docsRow);

                //        int copies = 1;
                //        if (p.ReportTypes == ReportTypes.Package)
                //            copies = docsRow.RegisterCount;

                //        copies = (copies == 1 ? 2 : copies); // TODO выставить только одну копию - принудительная печать реестра в кол-ве 2-х экземпляров, если кол-во копий равно 1

                //        if (copies > 0)
                //        {
                //            using (Reports.PNSaleRegister report = GetSaleRegisterReport(naklData))
                //            {
                //                report.PrintOptions.PrinterName = p.AlternativePrinterName;
                //                report.PrintToPrinter(copies, true, 1, 0);
                //            }
                //        }
                //    }
                #endregion
            }
            catch (Exception ex)
            {
                Logger.WriteLogError(this.UserID, this.DocType, ex);
                e.Result = ex;
            }
        }

        /// <summary>
        /// Сохранение PDF-варианта РН
        /// </summary>
        /// <param name="docsRow"></param>
        /// <param name="report"></param>
        private void SaveDocAttributes(PrintNakl.DocsRow docsRow, ReportClass report)
        {
            try
            {
                var ms = (MemoryStream)report.ExportToStream(ExportFormatType.PortableDocFormat);

                var binPDF = ms.ToArray();

                using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                {
                    docsAdapter.SetTimeout(300);
                    docsAdapter.SaveDocAttributes(this.UserID, docsRow.SDDCT, docsRow.InvoiceID, binPDF, docsFromArchive);
                }

                ms.Close();
            }
            catch (Exception ex)
            { 
            
            }
        }

        private long GetWaybillID(Data.PrintNakl.Waybill_DocsRow waybillDoc)
        {
            return Convert.ToInt64(string.Format("{0}{1}", waybillDoc.Route_List_Number, waybillDoc.Delivery_Code.ToString().PadLeft(6, '0')));
        }

        /// <summary>
        /// Анализ печати в дуплексном режиме
        /// </summary>
        /// <param name="naklData"></param>
        /// <returns></returns>
        private PrinterDuplex GetPrinterDuplexRegime(WMSOffice.Data.PrintNakl naklData)
        {
            if (naklData.DocDetail.Rows.Count > 10)
                return PrinterDuplex.Horizontal;
            else
                return PrinterDuplex.Simplex;
        }

        /// <summary>
        /// Обрабатывает окончание печати отчетов в фоне.
        /// </summary>
        private void printWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                ShowError((e.Result as Exception).Message);
            }

            splashForm.CloseForce();
        }

        /// <summary>
        /// Возвращает шаблон расходной накладной
        /// </summary>
        /// <param name="invoicePrintDate"></param>
        /// <returns></returns>
        private ReportClass GetInvoiceReport(DateTime invoicePrintDate, int invoiceFlag, int? tenderInvoice, int debtorID, int edFlag, string category)
        {
            ReportClass report = null;
            //report = new Reports.PNInvoiceReportEx();
            //return report;

            // Актуальные тендерные РН
            if (tenderInvoice.HasValue && tenderInvoice.Value > 0) // тендерная накладная
            {
                if (tenderInvoice.Value == 1)
                {
                    report = new Reports.PNInvoiceReport_UA_Since_03_2015Tender();
                }
                else if (tenderInvoice.Value == 2)
                {
                    report = new Reports.PNTenderInvoiceReport(); // тендерная нового образца
                }
                else if (tenderInvoice.Value == 3)
                {
                    report = new Reports.PNTenderForCurrencyInvoiceReport(); // тендерная за валюту
                }
            }
            // Актуальные РН
            else if (invoicePrintDate >= new DateTime(2015, 3, 18))
            {
                if (invoiceFlag == 0) // полный вариант расходной
                {
                    report = debtorID == 75923 ? (ReportClass)new Reports.PNInvoiceReport_UA_Since_WithRegNum() : (ReportClass)new Reports.PNInvoiceReport_UA_Since_03_2015();
                }
                else if (invoiceFlag == 1) // укороченный вариант расходной
                {
                    report = debtorID == 75923 
                        ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_WithRegNum() 
                        : debtorID == 8979
                            ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_ForDebtor_8979()
                            : debtorID == 128590
                                ?  (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_ForDebtor_128590()
                                     : debtorID == 76211
                                     ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_ForDebtor_76211()
                                        : category.Equals("GUM")
                                        ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_ForCategory_GUM()
                                            : category.Equals("GFT")
                                            ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_ForCategory_GFT()
                                            //: edFlag == 2 
                                            //    ? (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015_Watermark()
                                                : (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015();
                                                //: (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015___Courier();
                }
                else if (invoiceFlag == 2) // формируем ш/к для номера накладной
                {
                    report = (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015();
                }
                //else if (invoiceFlag == 2) //3) // формируем qr для номера накладной
                //{
                //    report = (ReportClass)new Reports.PNInvoiceReport_UA_Short_Since_03_2015();
                //}
            }
            // Устаревшие РН
            #region obsolete
            else if (invoicePrintDate >= new DateTime(2015, 1, 26))
            {
                if (invoiceFlag == 0) // полный вариант расходной
                {
                    report = new Reports.PNInvoiceReport_UA_Since_01_2015();
                }
                else if (invoiceFlag == 1) // укороченный вариант расходной
                {
                    report = new Reports.PNInvoiceReport_UA_Short_Since_01_2015();
                }
            }
            else if (invoicePrintDate >= new DateTime(2014, 4, 1))
            {
                report = new Reports.PNInvoiceReport_UA_Since_04_2014();
            }
            else
            {
                report = new Reports.PNInvoiceReport_UA();
            }
            #endregion

            return report;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть расходную".
        /// </summary>
        private void miPreviewInvoice_Click(object sender, EventArgs e)
        {

            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);

                var needPrintWatermark = SelectedRow.IsPrintWatermarkNull() ? false : SelectedRow.PrintWatermark == 2 ? false : Convert.ToBoolean(SelectedRow.PrintWatermark);
                var watermarkType = SelectedRow.IsPrintWatermarkNull() ? 0 : SelectedRow.PrintWatermark;
                //var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "PN", 5, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT);

                var tenderInvoice = SelectedRow.Isflag_TenderInvoiceNull() ? (int?)null : SelectedRow.flag_TenderInvoice;
                this.PrepareAdditionalRequisites(SelectedRow, tenderInvoice, ref naklData);

                bool printTagML = false;
                using (var report = sender.Equals(miPreviewInvoiceBase) ? this.GetTenderInvoiceReport(SelectedRow.DebtorID, ref printTagML) : GetInvoiceReport(SelectedRow.InvoicePrintDate, SelectedRow.flag_Invoice, tenderInvoice, SelectedRow.DebtorID, Convert.ToInt32(SelectedRow.IsEDFlagNull() ? (byte)0 : SelectedRow.EDFlag), SelectedRow.IsDocumentCategoryNull() ? string.Empty : SelectedRow.DocumentCategory))
                {
                    report.SetDataSource(GetInvoiceReportData(naklData));

                    if (!sender.Equals(miPreviewInvoiceBase))
                    {
                        report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

                        if (report.ParameterFields["WatermarkType"] != null)
                            report.SetParameterValue("WatermarkType", watermarkType);
                    }

                    var signElectronicDoc = !SelectedRow.PrintClientCopy_Flag;
                    string apendix = signElectronicDoc ? "(електронний документ)" : string.Empty;

                    report.SetParameterValue("@TaxApendix", apendix);

                    // Заполнение поля пробелами для возможности вставки в него значений при экспорте
                    if (printTagML)
                        report.SetParameterValue("@TagML", string.Empty.PadLeft(2, ' '));

                    var allowPrintDoc = true; // !(SelectedRow.IsEDFlagNull() ? false : SelectedRow.EDFlag);
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        if (!allowPrintDoc)
                        {
                            form.CanPrint = false;
                            form.CanExport = false;
                            form.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", form.Text);
                        }

                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 5, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Выбор шаблона тендерной накладной
        /// </summary>
        /// <returns></returns>
        private ReportClass GetTenderInvoiceReport(int debtorID, ref bool printTagML)
        {
            ReportClass report = null;

            if (debtorID == 78084)
            {
                report = new Reports.PNInvoiceReportExModified();
                printTagML = true;
            }
            else
            {
                report = new Reports.PNInvoiceReportEx();
            }

            return report;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть налоговую".
        /// </summary>
        private void miPreviewTaxInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                bool debtorCopy = sender == miPreviewTaxInvoiceForClient;
                bool allowPrint = SelectedRow.PrintClientCopy_Flag;

                if (!debtorCopy)
                    allowPrint = false;

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
                using (Data.PrintNaklTableAdapters.DocHeadersTableAdapter docHeadersAdapter = new Data.PrintNaklTableAdapters.DocHeadersTableAdapter())
                {
                    if (docsFromArchive)
                        docHeadersAdapter.FillFromArchive(naklData.DocHeaders, SelectedRow.CompanyID, SelectedRow.OrderType, SelectedRow.OrderID, SelectedRow.InvoiceID, UserID, true, debtorCopy);
                    else
                        docHeadersAdapter.Fill(naklData.DocHeaders, SelectedRow.CompanyID, SelectedRow.OrderType, SelectedRow.OrderID, SelectedRow.InvoiceID, UserID, true, debtorCopy);

                    //SetDebtorOrSellerMark(sender == miPreviewTaxInvoiceForClient, naklData.DocHeaders);
                }
                while (naklData.DocHeaders.Rows.Count > 1)
                {
                    naklData.DocHeaders.Rows.RemoveAt(1);
                }

                if (naklData.DocHeaders.Rows.Count > 0)
                {
                    // Электронная
                    if (naklData.DocHeaders[0].MarkEV01 == 0)
                        allowPrint = false;
                }

                using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                {
                    if (!allowPrint)
                    {
                        form.CanPrint = false;
                        form.CanExport = false;
                        form.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", form.Text);
                    }

                    if (SelectedRow.InvoicePrintDate >= (new DateTime(2015, 1, 1)))
                    {
                        using (Reports.PNTaxInvoiceReport_Since_01_2015 report = GetTaxInvoiceReport_Since_01_2015(naklData))
                        {
                            form.ReportDocument = report;
                            form.CanExport = form.CanPrint = Environment.UserName.Equals("maydanik", StringComparison.CurrentCultureIgnoreCase);
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate >= (new DateTime(2014, 12, 1)))
                    {
                        using (Reports.PNTaxInvoiceReport_Since_07_2014 report = GetTaxInvoiceReport_Since_07_2014(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate >= (new DateTime(2014, 3, 1)))
                    {
                        using (Reports.PNTaxInvoiceReport_Since_01_2014 report = GetTaxInvoiceReport_Since_01_2014(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate >= (new DateTime(2011, 12, 16)))
                    {
                        using (Reports.PNTaxInvoiceReport report = GetTaxInvoiceReport(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate >= (new DateTime(2011, 1, 10)) && SelectedRow.InvoicePrintDate <= (new DateTime(2011, 12, 15)))
                    {
                        using (Reports.PNTaxInvoiceOld3Report report = GetTaxInvoiceOld3Report(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate >= (new DateTime(2011, 1, 1)) && SelectedRow.InvoicePrintDate <= (new DateTime(2011, 1, 9)))
                    {
                        using (Reports.PNTaxInvoiceOld2Report report = GetTaxInvoiceOld2Report(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                    else if (SelectedRow.InvoicePrintDate < (new DateTime(2011, 1, 1)))
                    {
                        using (Reports.PNTaxInvoiceOldReport report = GetTaxInvoiceOldReport(naklData))
                        {
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 17, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Установка "Х" напротив продавца или покупца (в зависимости от параметра)
        /// </summary>
        /// <param name="pForDebtor">True, если налоговая печатается для покупца, False если для продавца</param>
        /// <param name="pHeaderTable">Таблица с заголовком отчета (изменения по отображению "Х" в нужно месте вносятся сюда)</param>
        private void SetDebtorOrSellerMark(bool pForDebtor, PrintNakl.DocHeadersDataTable pHeaderTable)
        {
            if (pHeaderTable == null || pHeaderTable.Count == 0)
                return;
            var row = pHeaderTable[0];
            row.TaxInvoiceMarkDebtorOriginal = pForDebtor ? "X" : " ";
            row.TaxInvoiceMarkSellerCopy = pForDebtor ? " " : "X";
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть контрольный лист".
        /// </summary>
        private void miPreviewControlSheet_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
                using (Reports.PNControlSheetReport report = GetControlSheetReport(naklData))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 12, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть реестр лек. средств".
        /// </summary>
        private void miPreviewRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
                using (Reports.PNRegister report = GetRegisterReport(naklData))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.CanPrint = false;
                        form.CanExport = false;
                        form.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", form.Text);

                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 13, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть реестр реализации лек. средств".
        /// </summary>
        private void miPreviewSaleRegister_Click(object sender, EventArgs e)
        {
            //// TODO просмотр реестра реализации - реализовать

            //try
            //{
            //    if (dgvDocs.SelectedRows.Count < 1)
            //        throw new Exception("Не выбран ни один документ.");

            //    Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
            //    using (Reports.PNSaleRegister report = GetSaleRegisterReport(naklData))
            //    {
            //        using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
            //        {
            //            form.ReportDocument = report;
            //            form.ShowDialog();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
            //        ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть заказ-требование".
        /// </summary>
        private void miPreviewRequirementOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                if (SelectedRow.OrderRequirementCount < 1)
                    throw new Exception("Выбранная накладная не содержит товаров предметно-количественного учета (ПКУ).");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
                using (Reports.PNOrderRequirementReport report = GetOrderRequirementReport(naklData))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 11, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть счет-фактуру".
        /// </summary>
        private void miPreviewBillInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);
                using (Reports.PNBillInvoiceReport report = GetBillInvoiceReport(naklData))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 10, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(naklData.DocDetail.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть накладную на оборотную тару".
        /// </summary>
        private void miPreviewTareInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                if (SelectedRow.TareInvoiceCount < 1)
                    throw new Exception("Выбранный документ не содержит накладную на оборотную тару.");

                var isDraft = true;
                var pickControlData = DebtorsReturnedTareInvoiceHelper.GetTareInvoiceReportData(SelectedRow, this.UserID, out isDraft);
                if (pickControlData != null)
                {
                    using (var rdp = new PrintReportDocumentProvider())
                    {
                        isDraft = true; // всегда в режиме просмотра формируем черновой вариант
                        rdp.Init(isDraft, pickControlData);
                        rdp.Preview();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miPreviewDocAgreement_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                if (SelectedRow.SCGP_Flag < 1)
                    throw new Exception("Выбранный документ не содержит доп. соглашение к тендеру.");

                var agreementsData = GetDocAgreementReportData(SelectedRow.CompanyID, SelectedRow.InvoiceID, SelectedRow.SDDCT);
                if (agreementsData != null)
                {
                    using (var report = new WMSOffice.Reports.PNInvoiceAgreementReport())
                    {
                        report.SetDataSource(agreementsData);
                        using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                        {
                            
                            form.ReportDocument = report;
                            form.ShowDialog();

                            if (form.IsPrinted)
                            {
                                // логирование факта печати
                                PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 15, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT, Convert.ToInt16(agreementsData.DocTenderAgreements.Count), form.PrinterName, Convert.ToByte(form.Copies));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        #region Methods for report creation

        private Data.PrintNakl PrepareDataSetForDoc(Data.PrintNakl.DocsRow docsRow)
        {
            return this.PrepareDataSetForDoc(docsRow, true);
        }

        /// <summary>
        /// Создает и заполняет DataSet, на основании которого будут генерироваться отчеты для документа.
        /// </summary>
        /// <param name="docsRow">Ссылка на строку, содержащую данные документа.</param>
        /// <returns>DataSet, на основании которого будут генерироваться отчеты для документа.</returns>
        private Data.PrintNakl PrepareDataSetForDoc(Data.PrintNakl.DocsRow docsRow, bool loadFullData)
        {
            Data.PrintNakl result = new Data.PrintNakl();

            if (!loadFullData)
                return result;

            Data.PrintNakl.DocsRow tmpRow = result.Docs.NewDocsRow();
            object[] tmpItemArray = (object[])docsRow.ItemArray.Clone();
            if (tmpItemArray.Length > tmpRow.Table.Columns.Count)
                Array.Resize<object>(ref tmpItemArray, tmpRow.Table.Columns.Count);
            tmpRow.ItemArray = tmpItemArray;
            result.Docs.AddDocsRow(tmpRow);

            using (Data.PrintNaklTableAdapters.CompanyConstantsTableAdapter companyConstantsAdapter = new Data.PrintNaklTableAdapters.CompanyConstantsTableAdapter())
            {
                companyConstantsAdapter.SetTimeout(300);
                companyConstantsAdapter.Fill(result.CompanyConstants, "UA", docsRow.InvoicePrintDate, docsRow.SelectionFlag);
            }

            var tenderInvoiceForCurrency = docsRow.Isflag_TenderInvoiceNull() ? false : docsRow.flag_TenderInvoice == 3;

            // реквизиты Оптимы для тендерной за валюту
            if (tenderInvoiceForCurrency)
            {
                using (Data.PrintNaklTableAdapters.CompanyConstantsENTableAdapter companyConstantsAdapter = new Data.PrintNaklTableAdapters.CompanyConstantsENTableAdapter())
                {
                    companyConstantsAdapter.SetTimeout(300);
                    companyConstantsAdapter.Fill(result.CompanyConstantsEN, "EN", docsRow.InvoicePrintDate);
                }
            }

            using (Data.PrintNaklTableAdapters.DocDetailTableAdapter docDetailAdapter = new Data.PrintNaklTableAdapters.DocDetailTableAdapter())
            {
                // спецификация тендерной за валюту
                if (tenderInvoiceForCurrency)
                {
                    docDetailAdapter.SetTimeout(300);
                    docDetailAdapter.FillConsCurrency(result.DocDetail, docsRow.CompanyID, docsRow.SDDCT, docsRow.InvoiceID);
                }
                else
                {
                    if (docsFromArchive)
                    {
                        //docDetailAdapter.FillFromArchive(result.DocDetail, docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID);
                        docDetailAdapter.SetTimeout(300);
                        object oFictive = null;
                        docDetailAdapter.FillFromArchiveCons(result.DocDetail, docsRow.CompanyID, docsRow.SDDCT, docsRow.InvoiceID, docsRow.DebtorID, ref oFictive);
                    }
                    else
                    {
                        //docDetailAdapter.Fill(result.DocDetail, docsRow.CompanyID, docsRow.OrderType, docsRow.OrderID, docsRow.InvoiceID);
                        docDetailAdapter.SetTimeout(300);
                        object oFictive = null;
                        var edFlag = Convert.ToByte(docsRow.IsEDFlagNull() ? (byte)0 : docsRow.EDFlag); // признак электронной РН
                        docDetailAdapter.FillCons(result.DocDetail, docsRow.CompanyID, docsRow.SDDCT, docsRow.InvoiceID, docsRow.DebtorID, (bool?)null, ref oFictive, edFlag);
                    }
                }
            }

            // итоговые суммы по тендерной за валюту
            if (tenderInvoiceForCurrency)
            {
                using (Data.PrintNaklTableAdapters.DocSumCurrencyTableAdapter docSumCurrencyAdapter = new Data.PrintNaklTableAdapters.DocSumCurrencyTableAdapter())
                {
                    docSumCurrencyAdapter.SetTimeout(300);
                    docSumCurrencyAdapter.Fill(result.DocSumCurrency, docsRow.CompanyID, docsRow.SDDCT, docsRow.InvoiceID);
                }
            }

            return result;
        }

        private void PrepareAdditionalRequisites(Data.PrintNakl.DocsRow docsRow, int? tenderInvoice, ref Data.PrintNakl result)
        {
            if (tenderInvoice.HasValue && (tenderInvoice.Value == 2 || tenderInvoice.Value == 3))
            {
                // Получение доп. реквизитов
                using (var adapter = new Data.PrintNaklTableAdapters.AdditionalTenderRequisitesTableAdapter())
                    adapter.Fill(result.AdditionalTenderRequisites, docsRow.CompanyID, docsRow.SDDCT, docsRow.InvoiceID, docsRow.DebtorID, docsRow.IsDebtorContractNumNull() ? (string)null : docsRow.DebtorContractNum);
            }
        }

        /// <summary>
        /// Создает отчет - расходную накладную.
        /// </summary>
        /// <returns>Отчет в виде расходной накладной.</returns>
        private Data.PrintNakl /*Reports.PNInvoiceReport*/ GetInvoiceReportData(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание изображения штрих-кода
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                using (BarcodeLib.Barcode b = new BarcodeLib.Barcode())
                {
                    b.Encode(
                        BarcodeLib.TYPE.CODE128B, printNaklData.Docs[0].InvoiceBarCodeString,
                        1600,
                        200).Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                }

                printNaklData.Docs[0].InvoiceBarCodeImage = ms.ToArray();
            }

            // создание изображения QR-кода
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                Zen.Barcode.CodeQrBarcodeDraw qrDrawTool = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                var qrImage = qrDrawTool.Draw(printNaklData.Docs[0].InvoiceBarCodeString, 100, 2);
                qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                printNaklData.Docs[0].InvoiceQRCodeImage = ms.ToArray();
            }

            // создание изображения штрих-кода по номеру накладной в формате EAN-13
            if (printNaklData.Docs[0].flag_Invoice == 2)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new System.Drawing.Size(160 * 5, 60 * 5);
                barCodeCtrl.BarCodeHeight = 50 * 5;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 12 * 5, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10 * 5;
                barCodeCtrl.ShowFooter = false;
                barCodeCtrl.TopMargin = 2 * 5;
                barCodeCtrl.BarCode = printNaklData.Docs[0].InvoiceID.ToString();

                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }

                printNaklData.Docs[0].InvoiceEAN13BarCodeImage = barCode;
            }

            // создание изображения штрих-кода по номеру накладной в формате QR
            if (printNaklData.Docs[0].flag_Invoice == 2) // 3
            {
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Zen.Barcode.CodeQrBarcodeDraw qrDrawTool = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    var qrImage = qrDrawTool.Draw(printNaklData.Docs[0].QrCode, 100, 2);
                    qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    printNaklData.Docs[0].QrCodeImage = ms.ToArray();
                }
            }

            // Если выполняется первичная печать документа, то устанавливаем ответственное лицо за подпись (!!! и только в этом случае) 
            // Сценарий просмотра и повторной печати уже содержит ответственное лицо в источнике данных
            if (!docsFromArchive)
            {
                foreach (Data.PrintNakl.DocDetailRow row in printNaklData.DocDetail.Rows)
                    row.responsible_person = this.responsiblePerson;
                //printNaklData.DocDetail[0].responsible_person = this.responsiblePerson;
            }

            /*// создание и возврат отчета
            Reports.PNInvoiceReport report = new Reports.PNInvoiceReport();
            report.SetDataSource(printNaklData);*/
            return printNaklData/*report*/;
        }

        /// <summary>
        /// Создает отчет - промо флаер 
        /// </summary>
        /// <param name="promoID"></param>
        /// <returns></returns>
        public static Data.PrintNakl GetPromoFlyersReportData(int promoID)
        {
            var promoFlyersData = new Data.PrintNakl();

            using (var adapter = new Data.PrintNaklTableAdapters.PromoFlyersTableAdapter())
                adapter.Fill(promoFlyersData.PromoFlyers, promoID);

            return promoFlyersData;
        }

        /// <summary>
        /// Создает отчет - доп. соглашение для тендера
        /// </summary>
        /// <param name="promoID"></param>
        /// <returns></returns>
        public static Data.PrintNakl GetDocAgreementReportData(string company, double invoiceNumber, string invoiceType)
        {
            var agreementData = new Data.PrintNakl();

            using (var adapter = new Data.PrintNaklTableAdapters.DocTenderAgreementsTableAdapter())
                adapter.Fill(agreementData.DocTenderAgreements, company, invoiceNumber, invoiceType);

            return agreementData;
        }

        /// <summary>
        /// Создает отчет - спецификацию.
        /// </summary>
        /// <returns>Отчет в виде расходной накладной.</returns>
        private Reports.PNSpecificationReport GetSpecificationReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание и возврат отчета
            Reports.PNSpecificationReport report = new Reports.PNSpecificationReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в новом формате (с 16.12.2011).
        /// </summary>
        /// <returns>Отчет в виде налоговой накладной в новом формате (с 16.12.2011).</returns>
        private Reports.PNTaxInvoiceReport GetTaxInvoiceReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceReport report = new Reports.PNTaxInvoiceReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в новом формате (с 01.07.2014).
        /// </summary>
        /// <returns>Отчет в виде налоговой накладной в новом формате (с 01.07.2014).</returns>
        private Reports.PNTaxInvoiceReport_Since_07_2014 GetTaxInvoiceReport_Since_07_2014(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceReport_Since_07_2014 report = new Reports.PNTaxInvoiceReport_Since_07_2014();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в новом формате (с 01.01.2015).
        /// </summary>
        /// <returns>Отчет в виде налоговой накладной в новом формате (с 01.01.2015).</returns>
        private Reports.PNTaxInvoiceReport_Since_01_2015 GetTaxInvoiceReport_Since_01_2015(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceReport_Since_01_2015 report = new Reports.PNTaxInvoiceReport_Since_01_2015();
            report.SetDataSource(printNaklData);
            return report;
        }


        /// <summary>
        /// Создает отчет - налоговую накладную в новом формате (с 01.01.2014).
        /// </summary>
        /// <returns>Отчет в виде налоговой накладной в новом формате (с 01.01.2014).</returns>
        private Reports.PNTaxInvoiceReport_Since_01_2014 GetTaxInvoiceReport_Since_01_2014(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceReport_Since_01_2014 report = new Reports.PNTaxInvoiceReport_Since_01_2014();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в старом формате (до 01.01.2011).
        /// </summary>
        /// <returns>Отчет в виде старой налоговой накладной (до 01.01.2011).</returns>
        private Reports.PNTaxInvoiceOldReport GetTaxInvoiceOldReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceOldReport report = new Reports.PNTaxInvoiceOldReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в старом/новом формате (c 10.01.2011 по 15.12.2011).
        /// </summary>
        /// <returns>Отчет в виде старой/новой налоговой накладной (c 10.01.2011 по 15.12.2011).</returns>
        private Reports.PNTaxInvoiceOld2Report GetTaxInvoiceOld2Report(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceOld2Report report = new Reports.PNTaxInvoiceOld2Report();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - налоговую накладную в старом/новом формате (c 01.01.2011 по 09.01.2011).
        /// </summary>
        /// <returns>Отчет в виде старой/новой налоговой накладной (c 01.01.2011 по 09.01.2011).</returns>
        private Reports.PNTaxInvoiceOld3Report GetTaxInvoiceOld3Report(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");
            if (printNaklData.DocHeaders.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocHeaders.");

            // создание и возврат отчета
            Reports.PNTaxInvoiceOld3Report report = new Reports.PNTaxInvoiceOld3Report();
            report.SetDataSource(printNaklData);
            return report;
        }
        /// <summary>
        /// Создает отчет - контрольный лист.
        /// </summary>
        /// <returns>Отчет в виде контрольного листа.</returns>
        private Reports.PNControlSheetReport GetControlSheetReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание и возврат отчета
            Reports.PNControlSheetReport report = new Reports.PNControlSheetReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - реестр лекарственных средств.
        /// </summary>
        /// <returns>Отчет в виде реестра лекарственных средств.</returns>
        private Reports.PNRegister GetRegisterReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание и возврат отчета
            Reports.PNRegister report = new Reports.PNRegister();
            report.SetDataSource(printNaklData);
            return report;
        }

        ///// <summary>
        ///// Создает отчет - реестр реализации лекарственных средств.
        ///// </summary>
        ///// <returns>Отчет в виде реестра реализации лекарственных средств.</returns>
        //private Reports.PNSaleRegister GetSaleRegisterReport(Data.PrintNakl printNaklData)
        //{
        //    if (printNaklData.Docs.Rows.Count < 1)
        //        throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
        //    if (printNaklData.DocDetail.Rows.Count < 1)
        //        throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
        //    if (printNaklData.CompanyConstants.Rows.Count < 1)
        //        throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

        //    // создание и возврат отчета
        //    Reports.PNSaleRegister report = new Reports.PNSaleRegister();
        //    report.SetDataSource(printNaklData);
        //    return report;
        //}

        /// <summary>
        /// Создает отчет - заказ-требование для препаратов предметно-количественного учета (ПКУ).
        /// </summary>
        /// <returns>Отчет в виде заказа-требования для препаратов предметно-количественного учета (ПКУ).</returns>
        private Reports.PNOrderRequirementReport GetOrderRequirementReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание и возврат отчета
            Reports.PNOrderRequirementReport report = new Reports.PNOrderRequirementReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - счет-фактуру.
        /// </summary>
        /// <returns>Отчет в виде счета-фактуры.</returns>
        private Reports.PNBillInvoiceReport GetBillInvoiceReport(Data.PrintNakl printNaklData)
        {
            if (printNaklData.Docs.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.Docs.");
            if (printNaklData.DocDetail.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.DocDetail.");
            if (printNaklData.CompanyConstants.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.CompanyConstants.");

            // создание и возврат отчета
            Reports.PNBillInvoiceReport report = new Reports.PNBillInvoiceReport();
            report.SetDataSource(printNaklData);
            return report;
        }

        /// <summary>
        /// Создает отчет - накладная на оборотную тару.
        /// </summary>
        /// <returns>Отчет в виде накладной на оборотную тару.</returns>
        private Reports.DebtorsReturnedTareInvoiceReport GetTareInvoiceReport(Data.PickControl pickControlData)
        {
            if (pickControlData.CT_Tare_Invoice_Copies.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице pickControlData.CT_Tare_Invoice_Copies.");
            if (pickControlData.CT_Tare_Invoice_Header.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице pickControlData.CT_Tare_Invoice_Header.");
            if (pickControlData.CT_Tare_Invoice_Details.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице pickControlData.CT_Tare_Invoice_Details.");

            // создание и возврат отчета
            Reports.DebtorsReturnedTareInvoiceReport report = new Reports.DebtorsReturnedTareInvoiceReport();
            report.SetDataSource(pickControlData);
            return report;
        }

        #endregion

        /// <summary>
        /// Проверка накладных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckInvoice_Click(object sender, EventArgs e)
        {
            var dlgCheckInvoice = new WHCheckInvoiceForm() { UserID = this.UserID, IsWaybillModeEnabled = isWaybillModeEnabled };
            dlgCheckInvoice.ShowDialog();
            return;

#if print_mode        
            if (dlgCheckInvoice.DocsToPrint.Count > 0 && cbPrinters.SelectedItem != null)
            {
                #region ПЕЧАТЬ РН
                // запомним предыдущий режим и изменим текущий режим на работу с архивом
                var oldDocsFromArchive = docsFromArchive;
                docsFromArchive = true;

                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);

                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    PrinterName = cbPrinters.SelectedItem.ToString(),
                    ReportTypes = ReportTypes.Invoice,
                    CheckInvoiceMode = true
                };

                var ctParams = new List<PrintParameterCT>();

                // Цикл по всем накладным
                foreach (var row in dlgCheckInvoice.DocsToPrint)
                {
                    try
                    {
                        // Выявлена накладная на ОТ
                        if (!row.Isis_retNull() && row.is_ret == 1)
                        {
                            ctParams.Add(new PrintParameterCT { dcto = row.document_type, doco = row.document_id, kcoo = "00001" });
                        }
                        else // РН
                        {
                            Data.PrintNakl.DocsDataTable docs = null;
                            using (Data.PrintNaklTableAdapters.DocsTableAdapter docsAdapter = new Data.PrintNaklTableAdapters.DocsTableAdapter())
                            {
                                docsAdapter.SetTimeout(300);
                                docs = docsAdapter.GetDataFromArchive(UserID, (int)Dialogs.SearchDocOptionsForm.SearchType.ByInvoiceNumber, row.document_id, null, null, null, null, row.document_type);
                            }

                            if (docs != null && docs.Count > 0)
                                foreach (Data.PrintNakl.DocsRow doc in docs.Rows)
                                    parameters.DocsToPrint.Add(doc);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                }

                splashForm.ActionText = "Выполняется печать накладных..";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                // вернем режим на предыдущий
                docsFromArchive = oldDocsFromArchive;
                #endregion

                #region ПЕЧАТЬ ОТ
                if (ctParams.Count > 0)
                {
                    var printerName = cbPrinters.SelectedItem.ToString();

                    printWorker = new BackgroundWorker();
                    printWorker.DoWork += (s, ea) =>
                    {
                        try
                        {
                            var docs = ea.Argument as List<PrintParameterCT>;
                            foreach (var doc in docs)
                            {
                                var isDraft = false;
                                var pickControlData = DebtorsReturnedTareInvoiceHelper.GetTareInvoiceReportData(doc.doco, doc.dcto, doc.kcoo, (long?)null, (int?)null, this.UserID, true, out isDraft);
                                if (pickControlData != null)
                                {
                                    using (var rdp = new PrintReportDocumentProvider())
                                    {
                                        isDraft = false; // всегда в режиме печати формируем рабочий вариант
                                        rdp.Init(isDraft, pickControlData);
                                        rdp.Print(printerName, 1);

                                        // логирование факта печати
                                        PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 14, Convert.ToInt64(doc.doco), doc.dcto, Convert.ToInt16(pickControlData.CT_Tare_Invoice_Details.Count), printerName, Convert.ToByte(1));
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ea.Result = ex;
                        }
                    };
                    printWorker.RunWorkerCompleted += (s, ea) =>
                    {
                        if (ea.Result is Exception)
                            ShowError((ea.Result as Exception).Message);

                        splashForm.CloseForce();
                    };
                    splashForm.ActionText = "Выполняется печать накладных ОТ..";
                    printWorker.RunWorkerAsync(ctParams);
                    splashForm.ShowDialog();
                }
                #endregion
            }
#endif
        }

        class PrintParameterCT
        {
            public string dcto { get; set; }
            public int doco { get; set; }
            public string kcoo { get; set; }
        }

        /// <summary>
        /// Экспорт выбранных документов в Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportDocs_Click(object sender, EventArgs e)
        {
            try
            {
                var docs = new Data.PrintNakl.DocsDataTable();
                foreach (DataGridViewRow dr in dgvDocs.SelectedRows)
                {
                    var doc = (dr.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
                    var docClone = docs.NewDocsRow();

                    object[] docCloneArray = (object[])doc.ItemArray.Clone();
                    if (docCloneArray.Length > docClone.Table.Columns.Count)
                        Array.Resize<object>(ref docCloneArray, docClone.Table.Columns.Count);

                    docClone.ItemArray = docCloneArray;
                    docs.AddDocsRow(docClone);
                }

                var lstTitles = new List<string>();
                var lstDataFields = new List<string>();

                foreach (DataGridViewColumn dc in dgvDocs.Columns)
                    if (dc.Visible && !string.IsNullOrEmpty(dc.DataPropertyName))
                    {
                        lstTitles.Add(dc.HeaderText);
                        lstDataFields.Add(dc.DataPropertyName);
                    }

                ExportHelper.ExportDataTableToExcel(docs, lstTitles.ToArray(), lstDataFields.ToArray(), "Экспорт документов", "PNDocs", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        [Obsolete("При просмотре формируется либо расходная либо тендерная, поэтому данный пункт меню избыточен")]
        private void miPreviewTenderInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDocs.SelectedRows.Count != 1)
                    throw new Exception("Не выбран ни один документ.");

                Data.PrintNakl naklData = PrepareDataSetForDoc(SelectedRow);

                var needPrintWatermark = SelectedRow.IsPrintWatermarkNull() ? false : SelectedRow.PrintWatermark == 2 ? false : Convert.ToBoolean(SelectedRow.PrintWatermark);
                var watermarkType = SelectedRow.IsPrintWatermarkNull() ? 0 : SelectedRow.PrintWatermark;
                //var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "PN", 5, Convert.ToInt64(SelectedRow.InvoiceID), SelectedRow.SDDCT);

                var tenderInvoice = SelectedRow.Isflag_TenderInvoiceNull() ? (int?)null : SelectedRow.flag_TenderInvoice;
                this.PrepareAdditionalRequisites(SelectedRow, tenderInvoice, ref naklData);

                using (var report = GetInvoiceReport(SelectedRow.InvoicePrintDate, SelectedRow.flag_Invoice, tenderInvoice, SelectedRow.DebtorID, Convert.ToInt32(SelectedRow.IsEDFlagNull() ? (byte)0 : SelectedRow.EDFlag), SelectedRow.IsDocumentCategoryNull() ? string.Empty : SelectedRow.DocumentCategory))
                {
                    report.SetDataSource(GetInvoiceReportData(naklData));
                    report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

                    if (report.ParameterFields["WatermarkType"] != null)
                        report.SetParameterValue("WatermarkType", watermarkType);

                    var signElectronicDoc = !SelectedRow.PrintClientCopy_Flag;
                    string apendix = signElectronicDoc ? "(електронний документ)" : string.Empty;
                    report.SetParameterValue("@TaxApendix", apendix);

                    using (var form = new WMSOffice.Dialogs.ReportForm())
                    {
                        form.ReportDocument = report;
                        form.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region LoadWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для загрузки данных.
        /// </summary>
        private class LoadWorkerParameters
        {
            /// <summary>
            /// Признак, показывающий, что нужно загрузить текущий список документов (еще не напечатанных).
            /// </summary>
            public bool CurrentDocuments { get; set; }

            /// <summary>
            /// Тип поиска в архиве.
            /// </summary>
            public Dialogs.SearchDocOptionsForm.SearchType SearchType { get; set; }

            /// <summary>
            /// Номер заказа для поиска в архиве.
            /// </summary>
            public long? OrderID { get; set; }

            /// <summary>
            /// Номер заказа для поиска в архиве.
            /// </summary>
            public long? InvoiceID { get; set; }

            /// <summary>
            /// Код дебитора для поиска в архиве.
            /// </summary>
            public int? DebtorID { get; set; }

            /// <summary>
            /// Код доставки для поиска в архиве
            /// </summary>
            public int? AddressID { get; set; }

            /// <summary>
            /// Дата "с" для поиска в архиве.
            /// </summary>
            public DateTime? DateFrom { get; set; }

            /// <summary>
            /// Дата "по" для поиска в архиве.
            /// </summary>
            public DateTime? DateTo { get; set; }

            /// <summary>
            /// № МЛ
            /// </summary>
            public int? RouteListNumber { get; set; }

            /// <summary>
            /// Ш/К МЛ
            /// </summary>
            public string RouteListBarCode { get; set; }

            /// <summary>
            /// Список параметров для поиска нескольких ТТН
            /// </summary>
            public WaybillParameters Waybills { get; set; }
        }

        public class WaybillParameters : List<WaybillParameter>
        {
            public WaybillParameters()
            {

            }

            public WaybillParameters(IEnumerable<WaybillParameter> collection)
                : base(collection)
            {

            }

            public XmlDocument CreateXml()
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml("<Waybills></Waybills>");
                XmlElement xRoot = xDoc.DocumentElement;

                XmlAttribute xValue = null;
                foreach (var waybill in this)
                {
                    var xWaybillElement = xDoc.CreateElement("Waybill");

                    xValue = xWaybillElement.Attributes.Append(xDoc.CreateAttribute("route_number"));
                    xValue.Value = string.IsNullOrEmpty(waybill.RouteListNumber) ? string.Empty : waybill.RouteListNumber.ToString();

                    xValue = xWaybillElement.Attributes.Append(xDoc.CreateAttribute("delivery_id"));
                    xValue.Value = !waybill.AddressID.HasValue ? string.Empty : waybill.AddressID.Value.ToString();

                    xRoot.AppendChild(xWaybillElement);
                }

                return xDoc;
            }
        }

        public class WaybillParameter
        {
            /// <summary>
            ///  № МЛ
            /// </summary>
            public string RouteListNumber { get; set; }
            
            /// <summary>
            /// Код доставки
            /// </summary>
            public int? AddressID { get; set; }
        }

        #endregion

        #region PrintWorkerParameters class

        /// <summary>
        /// Класс, содержащий параметры для печати отчетов по документу.
        /// </summary>
        private class PrintWorkerParameters
        {
            /// <summary>
            /// Список строк документов, для которых печатаются отчеты.
            /// </summary>
            private List<Data.PrintNakl.DocsRow> docsToPrint = new List<WMSOffice.Data.PrintNakl.DocsRow>();

            /// <summary>
            /// Список строк документов, для которых печатаются отчеты.
            /// </summary>
            public List<Data.PrintNakl.DocsRow> DocsToPrint { get { return docsToPrint; } }

            /// <summary>
            /// ТТН
            /// </summary>
            public Data.PrintNakl.Waybill_DocsRow WaybillDoc { get; set; }

            /// <summary>
            /// ТТН
            /// </summary>
            public List<Data.PrintNakl.Waybill_DocsRow> WaybillDocs { get; set; }

            /// <summary>
            /// Выбранный принтер
            /// </summary>
            public IPNPrinter SelectedPrinter { get; set; }

            /// <summary>
            /// Типы отчетов, которые нужно распечатать.
            /// </summary>
            public ReportTypes ReportTypes { get; set; }

            /// <summary>
            /// Режим печати расходных накладных после проверки
            /// </summary>
            public bool CheckInvoiceMode { get; set; }

            /// <summary>
            /// Режим повтрной печати
            /// </summary>
            public bool ReprintMode { get; set; }

            /// <summary>
            /// Признак удаленной печати
            /// </summary>
            public bool IsRemotePrint { get; set; }

            ///// <summary>
            ///// Название альтернативного принтера.
            ///// </summary>
            //public string AlternativePrinterName { get; set; }

            ///// <summary>
            ///// Проверка использования альтернативного принтера
            ///// </summary>
            ///// <returns></returns>
            //public bool UseAlternativePrinter()
            //{
            //    return (string.Compare(this.PrinterName, this.AlternativePrinterName) != 0);
            //}
        }

        /// <summary>
        /// Содержит перечисление возможных типов печатаемых отчетов по документу; позволяет указывать сразу несколько типов отчетов.
        /// </summary>
        private enum ReportTypes
        {
            /// <summary>
            /// Весь пакет документов (расходная, налоговая, контрольный лист, реестр, заказ-требование, счет-фактура - по признакам необходимости).
            /// </summary>
            Package = 0,
            /// <summary>
            /// Расходная накладная.
            /// </summary>
            Invoice = 2,
            /// <summary>
            /// Налоговая накладная.
            /// </summary>
            TaxInvoice = 8,
            /// <summary>
            /// Контрольный лист.
            /// </summary>
            ControlSheet = 32,
            /// <summary>
            /// Реестр лек. средств.
            /// </summary>
            Register = 128,
            /// <summary>
            /// Заказ-требование.
            /// </summary>
            OrderRequirement = 512,
            /// <summary>
            /// Счет-фактура.
            /// </summary>
            BillInvoice = 2048,
            /// <summary>
            /// Накладная на оборотную тару.
            /// </summary>
            TareInvoice = 4096,
            /// <summary>
            /// Промо флаер.
            /// </summary>
            PromoFlyer = 8192,

            ///// <summary>
            ///// Реестр реализации лек. средств.
            ///// </summary>
            //SaleRegister = 16384
            
            /// <summary>
            /// Доп. соглашение для тендера
            /// </summary>
            TenderAgreement = 32768,

            /// <summary>
            /// ТТН
            /// </summary>
            Waybill = 65536
        }
        #endregion

        /// <summary>
        /// Класс, задающий сортировку при печати документа
        /// </summary>       
        public class PrintDocumentComparer : IComparer<Data.PrintNakl.DocsRow>
        {
            /// <summary>
            /// Коллекция содержащая поэлементно компоненты сортировки
            /// </summary>
            private Dictionary<string, string> CompareCollection = null;

            /// <summary>
            /// Адаптация строки сортировки к структуре "обьекта-сравнивателя"
            /// </summary>
            /// <param name="sortSequence"></param>
            public void AdaptSortSequence(string sortSequence)
            {
                this.CompareCollection = new Dictionary<string, string>();
                foreach (string sortItem in sortSequence.Split(','))
                {
                    string[] sortItemProperties = sortItem.Trim().Split(' ');
                    this.CompareCollection[sortItemProperties[0]] = sortItemProperties[1];
                }
            }

            // Внутрення сортировка по пользовательскому выбору
            public int Compare(Data.PrintNakl.DocsRow x, Data.PrintNakl.DocsRow y)
            {
                int compareResult = 0;

                foreach (KeyValuePair<string, string> kvp in this.CompareCollection)
                    if ((compareResult = CompareItem(x[kvp.Key], y[kvp.Key]) * (kvp.Value == "ASC" ? 1 : -1)) != 0)
                        return compareResult;

                return compareResult;
            }

            // Метод сравнения в зависимости от типа данных
            public int CompareItem(object x, object y)
            {
                if (x is int)
                    return ((int)x).CompareTo((int)y);

                if (x is long)
                    return ((long)x).CompareTo((long)y);

                if (x is float)
                    return ((float)x).CompareTo((float)y);

                if (x is double)
                    return ((double)x).CompareTo((double)y);

                if (x is decimal)
                    return ((decimal)x).CompareTo((decimal)y);

                if (x is bool)
                    return ((bool)x).CompareTo((bool)y);

                if (x is string)
                    return ((string)x).CompareTo((string)y);

                if (x is DateTime)
                    return ((DateTime)x).CompareTo((DateTime)y);

                return 0;
            }
        }

        bool isWaybillModeEnabled = false;
        private void btnEnableWaybillMode_Click(object sender, EventArgs e)
        {
            isWaybillModeEnabled = !isWaybillModeEnabled;
            btnEnableWaybillMode.BackColor = isWaybillModeEnabled ? Color.LightSkyBlue : SystemColors.Control;

            this.ChangeDocsViewMode();

            this.LoadDocsByMode();
        }

        private void LoadDocsByMode()
        {
            this.LoadDocsByMode((string)null);
        }

        private void LoadDocsByMode(string routeListBarcode)
        {
            this.LoadDocsByMode(false, routeListBarcode, (int?)null, (int?)null, (DateTime?)null, (DateTime?)null, (long?)null);
        }

        private void LoadDocsByMode(bool enableArchiveMode, string routeListBarcode, int? routeNumber, int? deliveryCode, DateTime? dateFrom, DateTime? dateTo, long? invoiceNumber)
        {
            docsFromArchive = enableArchiveMode;

            if (isWaybillModeEnabled)
            {
                this.ClearRouteListDocs();
                this.ClearWaybillDocs();
                this.ClearDocs();

                if (isRouteListsShown)
                {
                    if (docsFromArchive)
                        this.LoadWaybillDocs(routeListBarcode, routeNumber, deliveryCode, dateFrom, dateTo, invoiceNumber);
                    else
                        this.LoadRouteLists(routeListBarcode, routeNumber, deliveryCode, dateFrom, dateTo, invoiceNumber);
                }
                else
                {
                    this.LoadWaybillDocs(routeListBarcode, routeNumber, deliveryCode, dateFrom, dateTo, invoiceNumber);
                }
            }
            else
            {
                this.ClearRouteListDocs();
                this.ClearWaybillDocs();
                this.LoadDocs(routeListBarcode, routeNumber);
            }

            //this.SetActiveGrid();
        }

        private void LoadWaybillDocs(string routeListBarcode)
        {
            this.LoadWaybillDocs(routeListBarcode, (int?)null, (int?)null, (DateTime?)null, (DateTime?)null, (long?)null);
        }

        private bool lockWaybillDocSelection = false;
        private void LoadWaybillDocs(string routeListBarcode, int? routeListNumber, int? deliveryCode, DateTime? dateFrom, DateTime? dateTo, long? invoiceNumber)
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                printNakl.Waybill_Docs.Clear();

                lockWaybillDocSelection = true;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        if (docsFromArchive)
                        {
                            e.Result = waybill_DocsTableAdapter.GetDataArchive(this.UserID, routeListNumber, deliveryCode, dateFrom, dateTo, invoiceNumber);
                        }
                        else
                        {
                            e.Result = waybill_DocsTableAdapter.GetData(this.UserID, routeListBarcode);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        printNakl.Waybill_Docs.Merge(e.Result as PrintNakl.Waybill_DocsDataTable, true);


                    lockWaybillDocSelection = false;

                    if (dgvWaybillDocs.Rows.Count > 0)
                        this.LoadDocsByWaybillDocs(routeListNumber);
                };
                splashForm.ActionText = docsFromArchive ? "Загрузка ТТН из архива..." : "Загрузка ТТН...";
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ClearWaybillDocs()
        {
            try
            {
                printNakl.Waybill_Docs.Clear();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ChangeDocsViewMode()
        {
            scWaybillDocsContent.Panel1Collapsed = !isWaybillModeEnabled;
            scWaybillDocsContent.IsSplitterFixed = !isWaybillModeEnabled;

            btnShowHideRouteLists.Enabled = isWaybillModeEnabled;

            btnFind.Enabled = true;
            WMSOffice.Dialogs.SearchDocOptionsForm.Initialize(isWaybillModeEnabled);

            btnCheckInvoice.Enabled = true;
            
            btnPrintFullPackageByWaybill.Visible = tssPrintFullPackageByWaybill.Visible = isWaybillModeEnabled;

            lblDocsCount.Text = "0";
            lblDocsCountNT.Text = "0";

            this.SetActiveGrid();
        }

        private void SetActiveGrid()
        {
            if (isWaybillModeEnabled)
            {
                if (isRouteListsShown)
                    dgvRouteListDocs.Focus();
                else
                    dgvWaybillDocs.Focus();
            }
            else
                dgvDocs.Focus();
        }

        private void dgvWaybillDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetWaybillOperationAccess();

            if (!isWaybillModeEnabled)
                return;

            this.ClearDocs();

            if (dgvWaybillDocs.SelectedRows.Count == 0)
                return;

            if (lockWaybillDocSelection)
                return;

            this.LoadDocsByWaybillDocs(docsFromArchive ? Dialogs.SearchDocOptionsForm.CurrentRouteListNumber : (int?)null);
        }

        private void SetWaybillOperationAccess()
        {
            miRefreshWaybillDocs.Enabled = isWaybillModeEnabled;

            var isReadyToPrint = false;
            var isAlreadyPrinted = false;

            foreach (var waybillDoc in this.SelectedWaybillDocs)
            {
                if (!isReadyToPrint)
                    isReadyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);

                if (!isAlreadyPrinted)
                    isAlreadyPrinted = this.CheckWaybillDocAlreadyPrinted(waybillDoc);
            }

            miPrintWaybillDoc.Enabled = isWaybillModeEnabled && (isReadyToPrint || isAlreadyPrinted);
            miPrintPackageByWaybill.Enabled = isWaybillModeEnabled && isReadyToPrint && !docsFromArchive;
            miPrintFullPackageByWaybill.Enabled = btnPrintFullPackageByWaybill.Enabled = isWaybillModeEnabled && isReadyToPrint && !docsFromArchive;

            miRePrintFullPackageByWaybill.Enabled = dgvWaybillDocs.SelectedRows.Count > 0 && isWaybillModeEnabled && isAlreadyPrinted && !docsFromArchive;

            miPreviewWaybillDoc.Enabled = dgvWaybillDocs.SelectedRows.Count > 0 && isWaybillModeEnabled;
        }

        private void LoadDocsByWaybillDocs()
        {
            this.LoadDocsByWaybillDocs((int?)null);
        }

        private void LoadDocsByWaybillDocs(int? routeListNumber)
        {
            if (lockWaybillDocSelection)
                return;

            var routeListBarcode = (string)null;
            this.LoadDocs(routeListBarcode, routeListNumber);
        }

        private void miPrintWaybillDoc_Click(object sender, EventArgs e)
        {
            if (dgvWaybillDocs.SelectedRows.Count > 0 && cbPrinters.SelectedItem != null)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.Waybill,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };

                parameters.WaybillDocs = new List<PrintNakl.Waybill_DocsRow>();
                foreach (var waybillDoc in this.SelectedWaybillDocs)
                {
                    var isReadyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);
                    var isAlreadyPrinted = this.CheckWaybillDocAlreadyPrinted(waybillDoc);

                    if (isReadyToPrint || isAlreadyPrinted)
                        parameters.WaybillDocs.Add(waybillDoc);
                }

                splashForm.ActionText = "Печать ТТН...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();
            }
        }

        private void miPrintPackageByWaybill_Click(object sender, EventArgs e)
        {
            this.PrintDocsByWaybill(false);
        }

        private void btnPrintFullPackageByWaybill_Click(object sender, EventArgs e)
        {
            this.PrintDocsByWaybill(true);
        }

        private void miPrintFullPackageByWaybill_Click(object sender, EventArgs e)
        {
            this.PrintDocsByWaybill(true);
        }

        private void miRePrintFullPackageByWaybill_Click(object sender, EventArgs e)
        {
            this.PrintDocsByWaybill(true, true);
        }

        private void miPreviewWaybillDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvWaybillDocs.SelectedRows.Count < 1)
                    throw new Exception("Не выбран ни один документ.");

                var waybillDoc = (dgvWaybillDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PrintNakl.Waybill_DocsRow;
                Data.PrintNakl naklData = GetWaybillReportData(waybillDoc);

                var waybillID = this.GetWaybillID(waybillDoc);
                var needPrintWatermark = waybillDoc.IsPrintWatermarkNull() ? false : Convert.ToBoolean(waybillDoc.PrintWatermark);

                var isReadyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);
                var isAlreadyPrinted = this.CheckWaybillDocAlreadyPrinted(waybillDoc);
                var allowPrintDoc = isReadyToPrint || isAlreadyPrinted;

                using (var report = GetWaybillReport(naklData, waybillID, needPrintWatermark))
                {
                    using (Dialogs.ReportForm form = new WMSOffice.Dialogs.ReportForm())
                    {
                        if (!allowPrintDoc)
                        {
                            form.CanPrint = false;
                            form.CanExport = false;
                            form.Text = string.Format("{0} [ТОЛЬКО ЧТЕНИЕ]", form.Text);
                        }

                        form.ReportDocument = report;
                        form.ShowDialog();

                        if (form.IsPrinted)
                        {
                            // логирование факта печати
                            PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "PN", 7, waybillID, "TN", Convert.ToInt16(naklData.PN_WaybillReport_Details.Count), form.PrinterName, Convert.ToByte(form.Copies));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Во время подготовки отчета к просмотру возникла следующая ошибка:" + Environment.NewLine +
                    ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrintDocsByWaybill(bool printWaybill)
        {
            this.PrintDocsByWaybill(printWaybill, false);
        }

        private void PrintDocsByWaybill(bool printWaybill, bool reprintMode)
        {
            if (dgvWaybillDocs.SelectedRows.Count > 0)
            {
                //if (dgvDocs.Rows.Count > 0)
                //    dgvDocs.Rows[0].Selected = false;

                dgvDocs.ClearSelection();

                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    var doc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
                    var needPrint = doc.IsPrintModeNull() ? false : Convert.ToBoolean(doc.PrintMode);

                    if (reprintMode && !needPrint)
                        needPrint = true;

                    if (needPrint)
                        row.Selected = true;
                }
            }

            if ((dgvDocs.SelectedRows.Count > 0) && cbPrinters.SelectedItem != null /*&& this.ContinuePrinting()*/)
            {
                BackgroundWorker printWorker = new BackgroundWorker();
                printWorker.DoWork += new DoWorkEventHandler(printWorker_DoWork);
                printWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(printWorker_RunWorkerCompleted);
                PrintWorkerParameters parameters = new PrintWorkerParameters()
                {
                    SelectedPrinter = (IPNPrinter)cbPrinters.SelectedItem,
                    ReportTypes = ReportTypes.Package,
                    ReprintMode = reprintMode,
                    IsRemotePrint = chbIsRemotePrint.Checked
                };
                foreach (Data.PrintNakl.DocsRow r in SelectedRowsOrdered)
                {
                    parameters.DocsToPrint.Add(r);
                }

                if (printWaybill)
                {
                    // Подготовка отсортированных ТТН
                    var dtWaybillDocs = new Data.PrintNakl.Waybill_DocsDataTable();
                    foreach (var waybillDoc in this.SelectedWaybillDocs)
                        dtWaybillDocs.LoadDataRow(waybillDoc.ItemArray, true);

                    var arSortedWaybillDocs = dtWaybillDocs.Select(string.Empty, string.Format("{0} ASC, {1} ASC, {2} ASC", dtWaybillDocs.PrintWatermarkColumn.Caption, dtWaybillDocs.Route_List_NumberColumn.Caption, dtWaybillDocs.OrdersSequenceColumn.Caption));

                    // Отбор разрешенных к печати ТТН
                    parameters.WaybillDocs = new List<PrintNakl.Waybill_DocsRow>();
                    foreach (Data.PrintNakl.Waybill_DocsRow waybillDoc in arSortedWaybillDocs)
                    {
                        var isReadyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);

                        if (reprintMode)
                            isReadyToPrint = this.CheckWaybillDocAlreadyPrinted(waybillDoc);

                        if (isReadyToPrint)
                            parameters.WaybillDocs.Add(waybillDoc);
                    }
                }

                splashForm.ActionText = printWaybill ? (reprintMode ? "Повторная печать пакетов выбранных документов с ТТН..." : "Печать пакетов выбранных документов с ТТН...") : "Печать пакетов выбранных документов...";
                printWorker.RunWorkerAsync(parameters);
                splashForm.ShowDialog();

                // пометка напечатанных строк
                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    if (row.Selected)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = Color.LightGreen;
                            row.Cells[c].Style.SelectionForeColor = Color.LightGreen;
                        }
                        row.Tag = PrintedRowTag;

                        if (chbIsRemotePrint.Checked)
                        {
                            var doc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.DocsRow;
                            doc.PrintMode = (byte)0;

                            row.Cells[dgvcIsAlreadyPrinted.Index].ToolTipText = "Печать документа не требуется\nДокумент был отправлен на печать";
                        }
                    }
                }

                foreach (DataGridViewRow row in dgvDocs.Rows)
                {
                    row.Selected = false;
                }

                // пометка напечатанных строк ТТН
                foreach (DataGridViewRow row in dgvWaybillDocs.Rows)
                {
                    if (row.Selected)
                    {
                        var waybillDoc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.Waybill_DocsRow;
                        var isReadyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);
                        if (isReadyToPrint)
                        {
                            waybillDoc.ReadyToPrintFlag = 0;

                            if (chbIsRemotePrint.Checked)
                                row.Cells[dgvcIsReadyToPrint.Index].ToolTipText = "Документы были отправлены на печать";

                            //for (int c = 0; c < row.Cells.Count; c++)
                            //{
                            //    row.Cells[c].Style.BackColor = Color.LightGreen;
                            //    row.Cells[c].Style.SelectionForeColor = Color.LightGreen;
                            //}

                            //row.Tag = PrintedRowTag;
                        }
                    }
                }

                this.SetWaybillOperationAccess();
            }
        }

        private Data.PrintNakl GetWaybillReportData(Data.PrintNakl.Waybill_DocsRow waybillDoc)
        {
            var data = new Data.PrintNakl();

            var routeListNumber = waybillDoc.Route_List_Number.ToString();
            var deliveryID = waybillDoc.Delivery_Code;

            data.Waybill_Docs.LoadDataRow(waybillDoc.ItemArray, true);

            //using (var adapter = new Data.PrintNaklTableAdapters.PN_WaybillReport_HeaderTableAdapter())
            //    adapter.Fill(data.PN_WaybillReport_Header, routeListNumber, deliveryID);

            using (var adapter = new Data.PrintNaklTableAdapters.PN_WaybillReport_HeaderTableAdapter())
                adapter.FillExt(data.PN_WaybillReport_Header, routeListNumber, deliveryID);

            using (var adapter = new Data.PrintNaklTableAdapters.PN_WaybillReport_DetailsTableAdapter())
                adapter.Fill(data.PN_WaybillReport_Details, routeListNumber, deliveryID);

            WaybillReportBarcodePrepare(data.PN_WaybillReport_Header);

            WaybillReportQrCodePrepare(data.PN_WaybillReport_Header);

            return data;
        }

        private void WaybillReportBarcodePrepare(Data.PrintNakl.PN_WaybillReport_HeaderDataTable header)
        {
            if (header.Count > 0)
            {
                // создание штрих-кода
                BarCodeCtrl barCodeCtrl = new BarCodeCtrl();
                barCodeCtrl.Weight = BarCodeCtrl.BarCodeWeight.Large;
                barCodeCtrl.Size = new System.Drawing.Size(1000, 200); // 720
                barCodeCtrl.BarCodeHeight = 140;
                barCodeCtrl.FooterFont = new Font(barCodeCtrl.FooterFont.FontFamily, 24, FontStyle.Bold);
                barCodeCtrl.HeaderText = "";
                barCodeCtrl.LeftMargin = 10;
                //barCodeCtrl.ShowFooter = true;
                barCodeCtrl.TopMargin = 20;
                barCodeCtrl.BarCode = header[0].barcode;
                byte[] barCode = null;
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    barCodeCtrl.GetImage().Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
                    barCode = ms.ToArray();
                }
                header[0].barcode_binary = barCode;
            }
        }

        private void WaybillReportQrCodePrepare(Data.PrintNakl.PN_WaybillReport_HeaderDataTable header)
        {
            if (header.Count > 0)
            {
                // создание изображения QR-кода
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    Zen.Barcode.CodeQrBarcodeDraw qrDrawTool = Zen.Barcode.BarcodeDrawFactory.CodeQr;
                    var qrImage = qrDrawTool.Draw(header[0].barcode, 100, 2);
                    qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

                    header[0].qrcode_binary = ms.ToArray();
                }
            }
        }

        /// <summary>
        /// Создает отчет - ТТН.
        /// </summary>
        /// <returns>Отчет в виде счета-фактуры.</returns>
        private Reports.PNWaybillReportExt GetWaybillReport(Data.PrintNakl printNaklData, long waybillID, bool needPrintWatermark)
        {
            if (printNaklData.PN_WaybillReport_Header.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.PN_WaybillReport_Header.");
            if (printNaklData.PN_WaybillReport_Details.Rows.Count < 1)
                throw new ArgumentException("Нет ни одной строки в таблице printNaklData.PN_WaybillReport_Details.");

            #region ОПРЕДЕЛЕНИЕ ТОВАРА ИЗ КАТЕГОРИИ ПКУ, НАРКОЗ
            List<string> lstItemCategoryAll = new List<string>();
            foreach (Data.PrintNakl.PN_WaybillReport_DetailsRow detail in printNaklData.PN_WaybillReport_Details.Rows)
            {
                if (!detail.IsItm_categoryNull() && !detail.IsItm_nameNull())
                {
                    if (detail.Itm_name.ToUpper().Contains("ПКУ") && !lstItemCategoryAll.Contains("ПКУ"))
                        lstItemCategoryAll.Add("ПКУ");
                    else if (detail.Itm_name.ToUpper().Contains("НАРКОЗ")&& !lstItemCategoryAll.Contains("НАРКОЗ"))
                        lstItemCategoryAll.Add("НАРКОЗ");
                }
            }

            lstItemCategoryAll.Sort();
            lstItemCategoryAll.Reverse();

            var sbItemCategoryAll = new StringBuilder();
            foreach (var itemCategory in lstItemCategoryAll)
            {
                if (sbItemCategoryAll.Length > 0)
                    sbItemCategoryAll.AppendFormat(", {0}", itemCategory);
                else
                    sbItemCategoryAll.AppendFormat("{0}", itemCategory);
            }
            #endregion

            //var needPrintWatermark = PrintDocsThread.CheckNeedPrintWatermark(this.UserID, "PN", 7, waybillID, "TN");

            // создание и возврат отчета
            //Reports.PNWaybillReport report = new Reports.PNWaybillReport();
            Reports.PNWaybillReportExt report = new Reports.PNWaybillReportExt();
            report.SetDataSource(printNaklData);
            report.SetParameterValue("NeedPrintWatermark", needPrintWatermark);

            var waybillDoc = printNaklData.Waybill_Docs[0];
            var docType = waybillDoc.IsDocTypeNull() ? string.Empty : waybillDoc.DocType;
            report.SetParameterValue("DocType", docType);
            report.SetParameterValue("ItemCategoryAll", sbItemCategoryAll.ToString());

            #region ОТОБРАЖЕНИЕ ПОДПИСИ ПОВЕРХ ПЕЧАТИ
            var waybillReportHeader = printNaklData.PN_WaybillReport_Header[0];
            var filial = waybillReportHeader.IsSignatureFilialNull() ? string.Empty : waybillReportHeader.SignatureFilial;
            var userCode = waybillReportHeader.IsSignatureUserCodeNull() ? string.Empty : waybillReportHeader.SignatureUserCode;

            var stamp = report.ReportDefinition.ReportObjects["WATERMARK_STAMP"];
            var targetSignatureName = string.Format("WATERMARK_SIGNATURE_{0}_{1}", filial.Trim(), userCode);
            var indent = 120 * 3; // отступ - 3 деления в сетке

            try
            {
                var targetSignature = report.ReportDefinition.ReportObjects[targetSignatureName];
                targetSignature.Left = stamp.Left + indent;
                targetSignature.Top = stamp.Top + indent;
                targetSignature.Width = stamp.Width - 2 * indent;
                targetSignature.Height = stamp.Height - 2 * indent;

                //targetSignature.Border.TopLineStyle = LineStyle.SingleLine;
                //targetSignature.Border.BottomLineStyle = LineStyle.SingleLine;
                //targetSignature.Border.LeftLineStyle = LineStyle.SingleLine;
                //targetSignature.Border.RightLineStyle = LineStyle.SingleLine;
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("Факсимиле \"{0}\" не зарегистрировано в системе.\n\nТТН будет сформирована без него.", targetSignatureName), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            #endregion

            return report;
        }

        private void dgvWaybillDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            #region БЛОК РАСКРАСКИ ЭЛЕКТРОННЫХ РН
            try
            {
                foreach (DataGridViewRow row in dgvWaybillDocs.Rows)
                {
                    var waybillDoc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.Waybill_DocsRow;
                    var hasEDoc = waybillDoc.IsEDFlagNull() ? false : Convert.ToBoolean(waybillDoc.EDFlag);

                    var readyToPrint = this.CheckWaybillDocReadyToPrint(waybillDoc);
                    var alreadyPrinted = this.CheckWaybillDocAlreadyPrinted(waybillDoc);
                    var readyToPrintFlag = waybillDoc.IsReadyToPrintFlagNull() ? (int?)null : waybillDoc.ReadyToPrintFlag;

                    row.Cells[dgvcIsReadyToPrint.Index].Value = readyToPrint ? emptyIcon : alreadyPrinted ? Properties.Resources.cancel : Properties.Resources.cancel_red;

                    if (!readyToPrint)
                    {
                        var sbToolTip = new StringBuilder(); // Пакет документов не подготовлен к печати\n

                        switch (readyToPrintFlag)
                        { 
                            case 0:
                                sbToolTip.Append("Документы уже напечатаны");
                                break;
                            case 1:
                                sbToolTip.Append("Ожидает синхронизации с Логистикой");
                                break;
                            case 2:
                                sbToolTip.Append("Часть документов еще не подготовлена");
                                break;
                            case 3:
                                sbToolTip.Append("Маршрутный лист еще не укомплектован");
                                break;
                            default:
                                break;
                        }

                        row.Cells[dgvcIsReadyToPrint.Index].ToolTipText = sbToolTip.ToString();

                        //for (int c = 0; c < row.Cells.Count; c++)
                        //{
                        //    row.Cells[c].Style.BackColor = Color.LightGray;
                        //    row.Cells[c].Style.SelectionForeColor = Color.LightGray;
                        //}
                    }

                    if (hasEDoc)
                    {
                        for (int c = 0; c < row.Cells.Count; c++)
                        {
                            row.Cells[c].Style.BackColor = Color.Khaki;
                            row.Cells[c].Style.SelectionForeColor = Color.Khaki;

                            if (waybillDoc.EDFlag == 2)
                                row.Cells[c].Style.ForeColor = Color.Blue;
                        }
                    }

                    var copiesNumber = waybillDoc.IsCopiesNumberNull() ? 0 : waybillDoc.CopiesNumber;
                    row.Cells[NeedPrint.Index].ToolTipText = string.Format("Число копий: {0}", copiesNumber);
                }
            }
            catch (Exception ex)
            {

            }
            #endregion
        }

        private bool CheckWaybillDocReadyToPrint(Data.PrintNakl.Waybill_DocsRow waybillDoc)
        {
            var readyToPrint = waybillDoc.IsReadyToPrintFlagNull() ? false : waybillDoc.ReadyToPrintFlag == 4;
            return readyToPrint;
        }

        private bool CheckWaybillDocAlreadyPrinted(Data.PrintNakl.Waybill_DocsRow waybillDoc)
        {
            var alreadyPrinted = waybillDoc.IsReadyToPrintFlagNull() ? false : waybillDoc.ReadyToPrintFlag == 0;
            return alreadyPrinted;
        }


        private void dgvRouteListDocs_SelectionChanged(object sender, EventArgs e)
        {
            if (!isWaybillModeEnabled)
                return;

            if (!isRouteListsShown)
                return;

            this.ClearWaybillDocs();
            this.ClearDocs();

            if (dgvRouteListDocs.SelectedRows.Count == 0)
                return;

            if (lockRouteListWaybillDocsSelection)
                return;

            if (lockWaybillDocSelection)
                return;

            this.LoadWaybillDocsByRouteList(docsFromArchive ? Dialogs.SearchDocOptionsForm.CurrentRouteListNumber : (int?)null);
        }

        private bool isRouteListsShown = false;
        private void btnShowHideRouteLists_Click(object sender, EventArgs e)
        {
           btnShowHideRouteLists.Image = (isRouteListsShown = !isRouteListsShown) ? Properties.Resources.chevron_left : Properties.Resources.chevron_right;
           
           scRouteListWaybillsContent.Panel1Collapsed = !isRouteListsShown;
           scRouteListWaybillsContent.IsSplitterFixed = !isRouteListsShown;

           btnShowHideRouteLists.ToolTipText = string.Format("{0} уровень МЛ", isRouteListsShown ? "Скрыть" : "Отобразить");

           if (isWaybillModeEnabled)
               this.LoadDocsByMode();
        }

        private bool lockRouteListWaybillDocsSelection = false;
        private void LoadRouteLists(string routeListBarcode, int? routeListNumber, int? deliveryCode, DateTime? dateFrom, DateTime? dateTo, long? invoiceNumber)
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                printNakl.Route_List_Docs.Clear();

                lockRouteListWaybillDocsSelection = true;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        if (docsFromArchive)
                        {
                            
                        }
                        else
                        {
                            e.Result = route_List_DocsTableAdapter.GetData(this.UserID, routeListBarcode);
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        printNakl.Route_List_Docs.Merge(e.Result as PrintNakl.Route_List_DocsDataTable, true);


                    lockRouteListWaybillDocsSelection = false;

                    if (dgvRouteListDocs.Rows.Count > 0)
                    {
                        routeListBarcode = this.SelectedRouteListDocRow.Route_List_Number;
                        this.LoadWaybillDocs(routeListBarcode);
                    }
                };
                splashForm.ActionText = docsFromArchive ? "Загрузка МЛ из архива..." : "Загрузка МЛ...";
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void LoadWaybillDocsByRouteList(int? routeListNumber)
        {
            if (lockRouteListWaybillDocsSelection)
                return;

            var routeListBarcode = this.SelectedRouteListDocRow.Route_List_Number;
            this.LoadWaybillDocs(routeListBarcode);
        }

        private void ClearRouteListDocs()
        {
            try
            {
                printNakl.Route_List_Docs.Clear();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvRouteListDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvRouteListDocs.Rows)
                {
                    var routeListDoc = (row.DataBoundItem as DataRowView).Row as Data.PrintNakl.Route_List_DocsRow;
                    var needPrintFlag = routeListDoc.IsNeedPrintFlagNull() ? (int?)null : routeListDoc.NeedPrintFlag;

                    var sbToolTip = new StringBuilder(); // Степень готовности к печати - 

                    switch (needPrintFlag)
                    { 
                        case 1:
                            sbToolTip.Append("Документы не готовы к печати");
                            row.Cells[dgvcNeedPrint.Index].Value = imageList.Images["status-error.png"];
                            break;
                        case 2:
                            sbToolTip.Append("Часть документов готова к печати");
                            row.Cells[dgvcNeedPrint.Index].Value = imageList.Images["status-warn.png"];
                            break;
                        case 3:
                            sbToolTip.Append("Все документы готовы к печати");
                            row.Cells[dgvcNeedPrint.Index].Value = imageList.Images["status-ok.png"];
                            break;
                        case 0:
                            sbToolTip.Append("Все документы напечатаны");
                            row.Cells[dgvcNeedPrint.Index].Value = imageList.Images["status-offline.png"];
                            break;
                        default:
                            sbToolTip.Append("Отсутствует");
                            row.Cells[dgvcNeedPrint.Index].Value = emptyIcon;
                            break;
                    }

                    row.Cells[dgvcNeedPrint.Index].ToolTipText = sbToolTip.ToString();
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
