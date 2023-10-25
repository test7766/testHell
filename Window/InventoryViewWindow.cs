using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Inventory;
using WMSOffice.Dialogs;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Threading;
using System.Diagnostics;
using WMSOffice.Reports;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Window
{
    public partial class InventoryViewWindow : GeneralWindow
    {
        /// <summary>
        /// Таймаут для получения отклика от выполнения запроса
        /// </summary>
        private const Int32 RESPONSE_WAIT_TIMEOUT = 300; // 5 минут

        /// <summary>
        /// Тип инвентаризации - "Полная"
        /// </summary>
        private const string FULL_INVENTORY_TYPE = "01";

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; private set; }
        #endregion

        /// <summary>
        /// Конструктор класса
        /// </summary>
        public InventoryViewWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие загрузки формы, обновляем данные
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InventoryViewWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
            this.PreparePrintersList();
            RefreshDocs();
        }

        private void Initialize()
        {
            this.xdgvCountSheets.AllowSummary = false;
            this.xdgvCountSheets.AllowRangeColumns = true;
            this.xdgvCountSheets.UseMultiSelectMode = true;
            this.xdgvCountSheets.UserID = this.UserID;
            this.xdgvCountSheets.SetSameStyleForAlternativeRows();
            this.xdgvCountSheets.Init(new CountSheetsView(), true);
            xdgvCountSheets.OnFilterChanged += new EventHandler(xdgvCountSheets_OnFilterChanged);
            xdgvCountSheets.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvCountSheets_OnFormattingCell);
            xdgvCountSheets.OnRowSelectionChanged += new EventHandler(xdgvCountSheets_OnRowSelectionChanged);
        }

        void xdgvCountSheets_OnRowSelectionChanged(object sender, EventArgs e)
        {
            bool allowOperation = this.xdgvCountSheets.SelectedItem != null;
            sbPreviewCountSheetHeader.Enabled = allowOperation;
            sbPrintCountSheetHeader.Enabled = allowOperation;
            sbPreviewCountSheet.Enabled = allowOperation;
            sbPrintCountSheet.Enabled = allowOperation;
        }

        void xdgvCountSheets_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var gridView = sender as DataGridView;
            gridView.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 16);

            var bindRow = (gridView.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;        

            int r = Convert.ToInt32(bindRow["R"]);
            int g = Convert.ToInt32(bindRow["G"]);
            int b = Convert.ToInt32(bindRow["B"]);
            Color color = Color.FromArgb(r, g, b);

            gridView.Rows[e.RowIndex].DefaultCellStyle.BackColor = color;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.Black;
            gridView.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Black;
            gridView.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = color;
        }

        void xdgvCountSheets_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvCountSheets.RecalculateSummary();
        }

        /// <summary>
        /// Сформировать список принтеров, выбрать принтер по умолчанию
        /// </summary>
        private void PreparePrintersList()
        {
            try
            {
                foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                    cmbPrinters.Items.Add(printerName);

                System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
                cmbPrinters.SelectedItem = tmpSettings.PrinterName;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        // ------------------------------------ Обновление данных -----------------------------------------

        /// <summary>
        /// Метод обновления списка инвентаризаций
        /// </summary>
        private void RefreshDocs()
        {
            try
            {
                iM_DocsTableAdapter.Fill(inventory.IM_Docs, UserID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Получить выбранную инвентаризацию
        /// </summary>
        private Data.Inventory.IM_DocsRow SelectedDoc
        {
            get
            {
                if (gvDocs.SelectedRows.Count > 0)
                    return (Data.Inventory.IM_DocsRow)(((DataRowView)gvDocs.SelectedRows[0].DataBoundItem).Row);
                else
                    return null;
            }
        }

        /// <summary>
        /// Метод обновления списка пересчетов по выбранной инвентаризации
        /// </summary>
        private void RefreshCalcs()
        {
            try
            {
                var doc = SelectedDoc;
                if (doc == null || doc.IsDoc_IDNull())
                    inventory.IM_Calcs.Clear();
                else
                    iM_CalcsTableAdapter.Fill(inventory.IM_Calcs, UserID, (int)doc.Doc_ID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Получить выбранный расчет
        /// </summary>
        private Data.Inventory.IM_CalcsRow SelectedCalc
        {
            get
            {
                if (gvCalcs.SelectedRows.Count > 0)
                    return (Data.Inventory.IM_CalcsRow)(((DataRowView)gvCalcs.SelectedRows[0].DataBoundItem).Row);
                else
                    return null;
            }
        }

        /// <summary>
        /// Метод обновления списка счетных листов
        /// </summary>
        private void RefreshCountSheets(bool clearFiler)
        {
            //this.xdgvCountSheets.Focus();

            if (clearFiler)
                this.xdgvCountSheets.ClearFilter();

            if (this.SelectedCalc == null)
            {
                xdgvCountSheets.ClearItems();
                return;
            }


            BackgroundWorker loadWorker = new BackgroundWorker();

            var searchCriteria = new CountSheetsParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.InventoryDocID = this.SelectedCalc.Doc_ID;
            searchCriteria.CalcID = (short)this.SelectedCalc.Calc_ID;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvCountSheets.DataView.FillData(searchCriteria);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.xdgvCountSheets.BindData(false);

                    //this.xdgvResult.AllowFilter = true;
                    //this.xdgvCountSheets.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование счетных листов..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        // ------------------------------------ Работа с данными на форме -----------------------------------------

        // === Инвентаризация ===

        #region Context menu Docs

        /// <summary>
        /// Настройка контекстного меню при открытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmDoc_Opening(object sender, CancelEventArgs e)
        {
            var doc = SelectedDoc;
            miCreateDoc.Enabled = (doc != null && doc.IsDoc_IDNull()); // возможность создания инвентаризации
            
            bool canCreateCalc = (!doc.IsStatus_IDNull() && doc.Status_ID == "100");
            foreach (Data.Inventory.IM_CalcsRow calc in inventory.IM_Calcs)
                canCreateCalc = canCreateCalc && calc.Status_ID == "199";

            miCloseDoc.Enabled = (!doc.IsDoc_IDNull() && !doc.IsStatus_IDNull() && doc.Status_ID == "100"
                && inventory.IM_Calcs.Count > 0 && canCreateCalc); // возможность закрытия инвентаризации
            
            canCreateCalc = canCreateCalc && (inventory.IM_Calcs.Count < 3);
            miCreateCalc.Enabled = !miCreateDoc.Enabled && canCreateCalc; // возможность создания пересчета
        }

        /// <summary>
        /// Обновление списка документов инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miRefreshDocs_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        /// <summary>
        /// Создание инвентаризации WMS по выбранной строке JDE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateDoc_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = SelectedDoc;
                if (doc == null || doc.IsJde_Doc_IDNull())
                    ShowError("Нельзя создать инвентаризацию WMS, так как не выбрана инвентаризация JDE.");
                else
                    if (MessageBox.Show("Создать инвентаризацию WMS для выбранной инвентаризации JDE?", "Создание инвентаризации", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        // создание инвентаризации в системе WMS
                        iM_DocsTableAdapter.CreateDocByJDE(UserID, (int)doc.Jde_Doc_ID);
                        // обновить список инвентаризаций
                        RefreshDocs();
                    }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Создание пересчета (1 - 3)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateCalc_Click(object sender, EventArgs e)
        {
            try
            {
                var doc = SelectedDoc;
                var calc = SelectedCalc;
                if (doc != null && calc == null && !doc.IsDoc_IDNull())
                {
                    // только для первого пересчета
                    switch (MessageBox.Show("Вы создаете первый пересчет.\nМожно создать первый пересчет двух типов:\n\n1. СТАНДАРТНЫЙ - ручной пересчет, \n(счетные ведомости создаются автоматически)\n2. ПОЛНЫЙ - пересчет на столах контроля,\n(счетные ведомости создаются на столах контроля\nи наполняются по мере сканирования)\n\nСоздать пересчет первого типа (Yes), второго (No)\nили не создавать первый пересчет (Cancel)?",
                        "Выбор типа пересчета", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            CreateCalc(true);
                            break;
                        case DialogResult.No:
                            CreateCalc(false);
                            break;
                        case DialogResult.Cancel:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Создание "ручного" пересчета, счетные листы будут сгенерированы автоматически
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateHandCalc_Click(object sender, EventArgs e)
        {
            CreateCalc(true);
        }

        /// <summary>
        /// Создание пересчета "методом котроля" на столах контроля (счетные листы создаются на местах)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateControlCalc_Click(object sender, EventArgs e)
        {
            CreateCalc(false);
        }

        /// <summary>
        /// Метод создания пересчета
        /// (открывается форма с выбором товара для пересчета)
        /// </summary>
        /// <param name="csAutoCreateFlag">Флаг "создавать счетные листы автоматически"</param>
        private void CreateCalc(bool csAutoCreateFlag)
        {
            try
            {
                int nextCalcID = inventory.IM_Calcs.Count + 1;
                var doc = SelectedDoc;
                if (doc != null && !doc.IsDoc_IDNull())
                {
                    CalcItemsForm form = new CalcItemsForm(UserID, (int)doc.Doc_ID, (int)doc.Jde_Doc_ID, nextCalcID, csAutoCreateFlag);
                    if (form.ShowDialog() == DialogResult.OK)
                        RefreshCalcs();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Закрываем инвентаризацию
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCloseDoc_Click(object sender, EventArgs e)
        {
            try
            {
                int nextCalcID = 4; // код закрытия инвентаризации
                var doc = SelectedDoc;
                if (doc != null && !doc.IsDoc_IDNull())
                {
                    CalcItemsForm form = new CalcItemsForm(UserID, (int)doc.Doc_ID, (int)doc.Jde_Doc_ID, nextCalcID, false);
                    if (form.ShowDialog() == DialogResult.OK)
                        RefreshDocs();
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        /// <summary>
        /// Разрисовка строк в таблице с документами инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvDocs.Rows)
            {
                Data.Inventory.IM_DocsRow diffRow = (Data.Inventory.IM_DocsRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        /// <summary>
        /// Реагируем на выбор инвентаризации - обновляем список пересчетов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvDocs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshCalcs();
        }

        // === Пересчеты ===

        #region Context menu Calcs

        /// <summary>
        /// Настройка контекстного меню при открытии
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmCalcs_Opening(object sender, CancelEventArgs e)
        {
            var calc = SelectedCalc;
            if (calc != null)
            {
                int statusID = 0;
                int.TryParse(calc.Status_ID, out statusID);
                miCloseCalc.Enabled = (calc != null && statusID < 190);
                miCreateEmptyCountSheet.Enabled = (calc != null && statusID < 190);
                miReportCalcDiff.Enabled = (calc != null && statusID > 190);
            }
            else miCloseCalc.Enabled = miCreateEmptyCountSheet.Enabled = miReportCalcDiff.Enabled = false;
        }

        /// <summary>
        /// Обновление списка пересчетов по выбранной инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miRefreshCalcs_Click(object sender, EventArgs e)
        {
            RefreshCalcs();
        }

        /// <summary>
        /// Создание "пустографки" - счетной ведомости с незаполненными графами
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCreateEmptyCountSheet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите создать новую\nпустую счетную ведомость для текущего пересчета?", "Создание счетной ведомости", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    var calc = SelectedCalc;
                    if (calc != null)
                    {
                        iM_CalcsTableAdapter.CreateCS(calc.Doc_ID, calc.Calc_ID, "IJ", UserID);
                        RefreshCalcs();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
        }

        /// <summary>
        /// Закрываем пересчет
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miCloseCalc_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите закрыть текущий пересчет?", "Закрытые пересчета", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    var calc = SelectedCalc;
                    if (calc != null)
                    {
                        BackgroundWorker worker = new BackgroundWorker();
                        worker.DoWork += new DoWorkEventHandler(CloseCalcWorker_DoWork);
                        worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(CloseCalcWorker_RunWorkerCompleted);

                        splashForm.ActionText = "Выполняется закрытие пересчета...";
                        worker.RunWorkerAsync(calc);
                        splashForm.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
        }

        #region close calc in background
        /// <summary>
        /// Фоновая печать счетных листов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CloseCalcWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Data.Inventory.IM_CalcsRow calc = (Data.Inventory.IM_CalcsRow)e.Argument;
                iM_CalcsTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                iM_CalcsTableAdapter.CloseCalc(calc.Doc_ID, calc.Calc_ID);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        /// <summary>
        /// Обработка окончания закрытия пересчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CloseCalcWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                MessageBox.Show((e.Result as Exception).Message, "Ошибка выполнения действия", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // закрываем окно прогреса обновлений
            splashForm.CloseForce();

            // обновляем список пересчетов
            RefreshCalcs();
        }
        #endregion

        #endregion

        /// <summary>
        /// Разрисовка строк в таблице со списком пересчетов инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvCalcs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in gvCalcs.Rows)
            {
                Data.Inventory.IM_CalcsRow diffRow = (Data.Inventory.IM_CalcsRow)((DataRowView)row.DataBoundItem).Row;

                // простая разрисовка строк
                Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                      ? Color.White
                                      : Color.FromName(diffRow.Color);
                for (int c = 0; c < row.Cells.Count; c++)
                {
                    row.Cells[c].Style.BackColor = backColor;
                    row.Cells[c].Style.SelectionForeColor = backColor;
                }
            }
        }

        /// <summary>
        /// Реагируем на выбор пересчета - обновляем список счетных листов по пересчету
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gvCalcs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshCountSheets(true);
        }
        
        // === Счетные листы ===

        #region Context menu CountSheets

        /// <summary>
        /// Просмотр корешка счетного листа
        /// </summary>
        private void miPreviewCountSheetHeader_Click(object sender, EventArgs e)
        {
            long id = 0;          
            if (xdgvCountSheets.SelectedItem != null)
            {
                if (xdgvCountSheets.SelectedItem["CS_Type"].ToString() == "IY")
                {
                    id = Convert.ToInt64(xdgvCountSheets.SelectedItem["ID"]);
                    this.PrepareCountSheetHeaderDoc(true, id);
                }
                else if (xdgvCountSheets.SelectedItem["CS_Type"].ToString() == "IK")
                {
                    id = Convert.ToInt64(xdgvCountSheets.SelectedItem["ID"]);
                    this.PrepareIKCountSheetHeaderDoc(true, new List<long>(new long[] { id }));
                }
                else
                    MessageBox.Show("Невозможно сформировать корешок для данного типа документа счетного листа.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Печать корешка счетного листа
        /// </summary>
        private void miPrintCountSheetHeader_Click(object sender, EventArgs e)
        {
            long id = 0;
            List<long> calcSheetIDs = new List<long>();

            foreach (DataRow row in xdgvCountSheets.SelectedItems)
            {
                if (row["CS_Type"].ToString() == "IY")
                {
                    id = Convert.ToInt64(row["ID"]);
                    this.PrepareCountSheetHeaderDoc(false, id);
                }
                else if (row["CS_Type"].ToString() == "IK")
                {
                    id = Convert.ToInt64(row["ID"]);
                    calcSheetIDs.Add(id);
                }
            }

            // Выполняем формирование списка счетных листов типа IK
            if (calcSheetIDs.Count > 0)
                this.PrepareIKCountSheetHeaderDoc(false, calcSheetIDs);


            // обновляем список счетных листов
            RefreshCountSheets(false);
        }

        /// <summary>
        /// Подготовка корешка счетного листа
        /// </summary>
        private void PrepareCountSheetHeaderDoc(bool previewMode, long calcSheetID)
        {
            bool canContinue = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (var adapter = new Data.InventoryTableAdapters.InventoryCalculationSheetReportHeaderTableAdapter())
                        adapter.Fill(this.inventory.InventoryCalculationSheetReportHeader, this.UserID, calcSheetID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    canContinue = true;

                waitProgressForm.CloseForce();
            };
            waitProgressForm.ActionText = "Формирование корешка счетного листа..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (canContinue)
            {
                using (var report = new InventoryCalculationSheetHeaderReport())
                {
                    BarcodePrepare(this.inventory.InventoryCalculationSheetReportHeader);
                    report.SetDataSource(this.inventory);
                    if (previewMode)
                    {
                        using (var reportViewer = new ReportForm())
                        {
                            reportViewer.ReportDocument = report;
                            reportViewer.ShowDialog();
                        }
                    }
                    else
                    {
                        report.PrintOptions.PrinterName = this.cmbPrinters.SelectedItem.ToString();
                        report.PrintToPrinter(1, true, 1, 0);

                        // изменение статуса документа на "110 - напечатан"
                        iM_CountSheetsTableAdapter.UpdateStatus(calcSheetID, UserID, "110");

                    }
                }
            }
        }

        /// <summary>
        /// Подготовка корешка счетного листа для типа IK
        /// </summary>
        /// <param name="previewMode"></param>
        /// <param name="calcSheetIDs"></param>
        private void PrepareIKCountSheetHeaderDoc(bool previewMode, List<long> calcSheetIDs)
        {
            bool canContinue = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.inventory.InventoryCalculationSheetReportHeader.Clear();

                    foreach (var calcSheetID in calcSheetIDs)
                    {
                        var header = new WMSOffice.Data.Inventory.InventoryCalculationSheetReportHeaderDataTable();

                        using (var adapter = new Data.InventoryTableAdapters.InventoryCalculationSheetReportHeaderTableAdapter())
                            adapter.Fill(header, this.UserID, calcSheetID);

                        this.inventory.InventoryCalculationSheetReportHeader.Merge(header);
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    canContinue = true;

                waitProgressForm.CloseForce();
            };
            waitProgressForm.ActionText = "Формирование корешка счетного листа..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (canContinue)
            {
                using (var report = new InventoryIKCalculationSheetHeaderReport())
                {
                    BarcodePrepare(this.inventory.InventoryCalculationSheetReportHeader);
                    report.SetDataSource(this.inventory);
                    if (previewMode)
                    {
                        using (var reportViewer = new ReportForm())
                        {
                            reportViewer.ReportDocument = report;
                            reportViewer.ShowDialog();
                        }
                    }
                    else
                    {
                        report.PrintOptions.PrinterName = this.cmbPrinters.SelectedItem.ToString();
                        report.PrintToPrinter(1, true, 1, 0);

                        foreach (var calcSheetID in calcSheetIDs)
                        {
                            // изменение статуса документа на "110 - напечатан"
                            iM_CountSheetsTableAdapter.UpdateStatus(calcSheetID, UserID, "110");
                        }

                    }
                }
            }
        }

        /// <summary>
        /// Подготовка штрих/кода к печати
        /// </summary>
        /// <param name="header"></param>
        public static void BarcodePrepare(WMSOffice.Data.Inventory.InventoryCalculationSheetReportHeaderDataTable header)
        {
            foreach (Data.Inventory.InventoryCalculationSheetReportHeaderRow headerRow in header.Rows)
                headerRow.BarCodeImage = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(headerRow.Bar_Code.Trim());
        }

        /// <summary>
        /// Просмотр печатной версии счетного листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miPreviewCountSheet_Click(object sender, EventArgs e)
        {
            long id = 0;
            if (xdgvCountSheets.SelectedItem != null)
            {
                id = Convert.ToInt64(xdgvCountSheets.SelectedItem["ID"]);
                this.PrepareCountSheetDoc(true, id);
            }
        }

        /// <summary>
        /// Печать счетных листов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miPrintCountSheet_Click(object sender, EventArgs e)
        {
            long id = 0;
            foreach (DataRow row in xdgvCountSheets.SelectedItems)
            {
                id = Convert.ToInt64(row["ID"]);
                this.PrepareCountSheetDoc(false, id);
            }

            // обновляем список счетных листов
            RefreshCountSheets(false);
        }

        /// <summary>
        /// Подготовка документа счетного листа
        /// </summary>
        /// <param name="previewMode"></param>
        /// <param name="calcSheetID"></param>
        private void PrepareCountSheetDoc(bool previewMode, long calcSheetID)
        {
            bool canContinue = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    // получение заголовка счетного листа
                    using (var adapter = new Data.InventoryTableAdapters.InventoryCalculationSheetReportHeaderTableAdapter())
                        adapter.Fill(this.inventory.InventoryCalculationSheetReportHeader, this.UserID, calcSheetID);

                    // получение деталей счетного листа
                    using (var adapter = new Data.InventoryTableAdapters.InventoryCalculationSheetReportDetailsTableAdapter())
                        adapter.Fill(this.inventory.InventoryCalculationSheetReportDetails, calcSheetID);

                    // TODO дубликат - для тестирования
                    //int cnt = this.inventory.InventoryCalculationSheetReportDetails.Count;
                    //for (int i = 0; i < cnt; i++)
                    //    this.inventory.InventoryCalculationSheetReportDetails.LoadDataRow(this.inventory.InventoryCalculationSheetReportDetails[i].ItemArray, true);

                    // получение подписчиков счетного листа
                    using (var adapter = new Data.InventoryTableAdapters.InventoryCalculationSheetReportSignersTableAdapter())
                        adapter.Fill(this.inventory.InventoryCalculationSheetReportSigners, calcSheetID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    canContinue = true;

                waitProgressForm.CloseForce();
            };
            waitProgressForm.ActionText = "Формирование документа счетного листа..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (canContinue)
            {
                using (var report = new InventoryCalculationSheetReport())
                {
                    BarcodePrepare(this.inventory.InventoryCalculationSheetReportHeader);
                    report.SetDataSource(this.inventory);
                    if (previewMode)
                    {
                        using (var reportViewer = new ReportForm())
                        {
                            reportViewer.ReportDocument = report;
                            reportViewer.ShowDialog();
                        }
                    }
                    else
                    {
                        report.PrintOptions.PrinterName = this.cmbPrinters.SelectedItem.ToString();
                        report.PrintToPrinter(1, true, 1, 0);

                        // изменение статуса документа на "110 - напечатан"
                        iM_CountSheetsTableAdapter.UpdateStatus(calcSheetID, UserID, "110");
                    }
                }
            }
        }

        #endregion

        /// <summary>
        /// Отчет "Ведомость расхождений" создается для каждого закрытого пересчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miReportCalcDiff_Click(object sender, EventArgs e)
        {
            try
            {
                var docRow = SelectedDoc;
                var calcRow = SelectedCalc;
                if (calcRow != null)
                {
                    #region // печать ведомости расхождений
                    // получение данных ведомости расхождений
                    using (Data.InventoryTableAdapters.CalcDiffReportTableAdapter diffAdapter = new WMSOffice.Data.InventoryTableAdapters.CalcDiffReportTableAdapter())
                    {
                        diffAdapter.Fill(inventory.CalcDiffReport, calcRow.Doc_ID, calcRow.Calc_ID, UserID);
                    }

                    if (inventory.CalcDiffReport.Count < 1)
                        throw new Exception("Не удалось получить данные Ведомости расхождений.");

                    // напечатаем заполненный Счетный лист
                    Reports.InventoryCalcDiffReportReport report = new Reports.InventoryCalcDiffReportReport();

                    report.SetDataSource((DataTable)inventory.CalcDiffReport);

                    #region // другие параметры отчета

                    // описание параметров отчета
                    ParameterFieldDefinitions crParameterFieldDefinitions = report.DataDefinition.ParameterFields;

                    // параметр CalcID
                    ParameterFieldDefinition crParameterFieldLocation = crParameterFieldDefinitions["CalcID"];
                    ParameterValues crParameterValues = crParameterFieldLocation.CurrentValues;
                    ParameterDiscreteValue crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    crParameterDiscreteValue.Value = calcRow.Calc_ID.ToString();
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldLocation.ApplyCurrentValues(crParameterValues);

                    // параметр InventoryJDE
                    crParameterFieldLocation = crParameterFieldDefinitions["InventoryJDE"];
                    crParameterValues = crParameterFieldLocation.CurrentValues;
                    crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    crParameterDiscreteValue.Value = docRow.Jde_Doc_ID.ToString();
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldLocation.ApplyCurrentValues(crParameterValues);

                    // параметр Warehouse
                    crParameterFieldLocation = crParameterFieldDefinitions["Warehouse"];
                    crParameterValues = crParameterFieldLocation.CurrentValues;
                    crParameterDiscreteValue = new CrystalDecisions.Shared.ParameterDiscreteValue();
                    crParameterDiscreteValue.Value = docRow.Filial.ToString();
                    crParameterValues.Add(crParameterDiscreteValue);
                    crParameterFieldLocation.ApplyCurrentValues(crParameterValues);

                    #endregion

                    ReportForm form = new ReportForm();
                    form.ReportDocument = report;
                    form.ShowDialog();
                    #endregion
                }
                else MessageBox.Show("Вы не выбрали пересчет!", "Просмотр ведомости расхождений", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void sbPlanIventory_Click(object sender, EventArgs e)
        {
            // шаг 1
            InventoryHeaderForm dlgInventoryHeader = new InventoryHeaderForm() { UserID = this.UserID };
            if (dlgInventoryHeader.ShowDialog() == DialogResult.OK)
            {
                DateTime inventoryDate = dlgInventoryHeader.InventoryDate;
                string inventoryType = dlgInventoryHeader.InventoryType;
                string inventoryPlanDuration = dlgInventoryHeader.InventoryPlanDuration;

                if (this.CreateInventory(inventoryDate, inventoryType, inventoryPlanDuration))
                {
                    // шаг 2
                    InventoryTargetPlacementForm dlgInventoryTargetPlacement = new InventoryTargetPlacementForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID };
                    if (dlgInventoryTargetPlacement.ShowDialog() == DialogResult.OK)
                    {
                        // Для неполной инвентаризации предоставим выбор товара
                        if (inventoryType != FULL_INVENTORY_TYPE)
                        {
                            MessageBox.Show("Завершение создания неполной инвентаризации будет доступно в следущих версиях!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            //// шаг 3
                            //InventoryTargetItemsForm dlgInventoryTargetItems = new InventoryTargetItemsForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID };
                            //if (dlgInventoryTargetItems.ShowDialog() == DialogResult.OK)
                            //{
                            //    // инвентаризация создана
                            //}
                        }
                    }
                }
            }
        }   

        /// <summary>
        /// Создание инвентаризации
        /// </summary>
        /// <param name="inventoryDate"></param>
        /// <param name="inventoryType"></param>
        /// <returns></returns>
        private bool CreateInventory(DateTime inventoryDate, string inventoryType, string inventoryPlanDuration)
        {
            try
            {
                using (Data.InventoryTableAdapters.CreateInventoryDocTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.CreateInventoryDocTableAdapter())
                    this.InventoryDocID = adapter.GetData(this.UserID, null, null, inventoryDate, inventoryType, inventoryPlanDuration)[0].Doc_ID;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось создать документ инвентаризации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Вызов метода выполнения проверок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbCheckIventory_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;

            using (InventoryCheckDialog wnd = new InventoryCheckDialog() { DocID = (int)SelectedDoc.Doc_ID })
            {
                if (wnd.ShowDialog(this) == DialogResult.Cancel)
                    return;
            }
        }

        private void sbPlanResources_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;

            using (InventoryResourcePlanningForm dlgPlanResources = new InventoryResourcePlanningForm() { UserID = this.UserID, InventoryDocID = SelectedDoc.Doc_ID })
            {
                dlgPlanResources.ShowDialog(this);
            }
        }

        private void sbRegisterMembers_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;

            using (InventoryMembersRegistrationForm dlgRegisterMembers = new InventoryMembersRegistrationForm() { UserID = this.UserID, InventoryDocID = SelectedDoc.Doc_ID })
            {
                dlgRegisterMembers.ShowDialog(this);
            }
        }

        private void sbPrintMakeInventoryOrder_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;

            this.PrintInventoryOrder(SelectedDoc.Doc_ID);
        }

        /// <summary>
        /// Печать приказа о проведении инвентаризации
        /// </summary>
        /// <param name="inventoryID"></param>
        private void PrintInventoryOrder(long inventoryID)
        {
            bool canContinue = false;
            BackgroundWorker printWorker = new BackgroundWorker();
            printWorker.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                try
                {
                    // Загрузка заголовка приказа
                    using (Data.InventoryTableAdapters.InventoryOrderReportHeaderTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryOrderReportHeaderTableAdapter())
                        adapter.Fill(this.inventory.InventoryOrderReportHeader, this.UserID, inventoryID);

                    // Загрузка членов комиссии заголовка приказа
                    using (Data.InventoryTableAdapters.InventoryOrderReportHeaderEmployeeTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryOrderReportHeaderEmployeeTableAdapter())
                        adapter.Fill(this.inventory.InventoryOrderReportHeaderEmployee, this.UserID, inventoryID);

                    // Загрузка перечня ресурсов
                    using (Data.InventoryTableAdapters.InventoryOrderReportResourcesDetailsTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryOrderReportResourcesDetailsTableAdapter())
                        adapter.Fill(this.inventory.InventoryOrderReportResourcesDetails, this.UserID, inventoryID);

                    // Загрузка сгрупированного по специальности перечня ресурсов
                    using (Data.InventoryTableAdapters.InventoryOrderReportResourcesGroupTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryOrderReportResourcesGroupTableAdapter())
                        adapter.Fill(this.inventory.InventoryOrderReportResourcesGroup, this.UserID, inventoryID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            printWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    ShowError(e.Result as Exception);
                else
                {
                    canContinue = true;
                }
                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется формирование приказа о проведении инвентаризации..";
            printWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            // Источник для отчета сформирован - можно печатать
            if (canContinue)
            {
                using (WMSOffice.Reports.MakeInventoryOrderReport report = new WMSOffice.Reports.MakeInventoryOrderReport())
                {
                    report.SetDataSource(this.inventory);
                    //report.PrintOptions.PrinterName = cmbPrinters.SelectedText;

                    using (SaveFileDialog dlgSaveToPDF = new SaveFileDialog()
                    {
                        Title = "Укажите файл для сохранения приказа",
                        Filter = "PDF файлы (*.pdf)|*.pdf",
                        FileName = string.Format("Инвентаризация № {0}", inventoryID)
                    })
                        if (dlgSaveToPDF.ShowDialog() == DialogResult.OK)
                        {
                            report.ExportToDisk(ExportFormatType.PortableDocFormat, dlgSaveToPDF.FileName);
                            Thread.Sleep(500);
                            Process.Start(dlgSaveToPDF.FileName);
                        }
                }
            }
        }

        private void sbStartInventory_Click(object sender, EventArgs e)
        {
            if (SelectedDoc == null)
                return;

            this.StartInventory(SelectedDoc.Doc_ID);
        }

        /// <summary>
        /// Запустить инвентаризацию
        /// </summary>
        private void StartInventory(long inventoryID)
        {
            BackgroundWorker startWorker = new BackgroundWorker();
            startWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.iM_DocsTableAdapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                    this.iM_DocsTableAdapter.StartInventory(this.UserID, inventoryID);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            startWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    MessageBox.Show("Счетные листы 1-го пересчета созданы.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.ShowInventoryRegistrationInfo(inventoryID);
                }

                waitProgressForm.CloseForce();
            };
            waitProgressForm.ActionText = "Выполняется попытка запуска инвентаризации..";
            startWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Отобразить информацию о регистрации участников
        /// </summary>
        private void ShowInventoryRegistrationInfo(long inventoryID)
        {
            try
            {
                using (var adapter = new Data.InventoryTableAdapters.CheckEmployeeResponseTableAdapter())
                {
                   adapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                   var response = adapter.GetData(this.UserID, inventoryID);
                   if (response.Count > 0)
                   {
                       var registrationInfo = response[0];
                       MessageBox.Show(string.Format("Зарегистрировано {0}% ({1} из {2}) счетных бригад.", registrationInfo.Prc, registrationInfo.emIn, registrationInfo.emTotal), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                       MessageBox.Show("Инвентаризация запущена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                   }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Мониторинг инвентаризации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbInventoryMonitoring_Click(object sender, EventArgs e)
        {
            if (this.SelectedDoc == null)
                return;

            using (var dlgMonitor = new WMSOffice.Dialogs.Inventory.InventoryMonitoringForm() { UserID = this.UserID, InventoryDocID = this.SelectedDoc.Doc_ID })
                dlgMonitor.ShowDialog();
        }

        /// <summary>
        /// Закрыть инвентаризацию
        /// </summary>
        private void sbCloseInventory_Click(object sender, EventArgs e)
        {
            this.CloseInventory();
        }

        /// <summary>
        /// Закрытие инвентаризации
        /// </summary>
        private void CloseInventory()
        {
            if (this.SelectedDoc == null)
                return;

            // Выбор режима работы
            var dlgClosureActions = new InventoryClosureActionsForm() { UserID = this.UserID, InventoryDocID = SelectedDoc.Doc_ID };
            if (dlgClosureActions.ShowDialog() == DialogResult.OK)
            {
                switch (dlgClosureActions.SelectedAction.ID)
                { 
                    case 1: // Корректировка остатков
                        if (this.RunCorrectRemains(this.SelectedDoc.Doc_ID))
                            if (this.CreateSheetOfDiscrepancies(this.SelectedDoc.Doc_ID))
                                this.InvokeTotalDiscrepanciesOffer(this.SelectedDoc.Doc_ID);
                                //if (this.InvokeTotalDiscrepanciesOffer(this.SelectedDoc.Doc_ID))
                                //    this.InvokeMovementShortage(this.SelectedDoc.Doc_ID);
                        break;
                    case 2: // Ведомость расхождений
                        this.CreateSheetOfDiscrepancies(this.SelectedDoc.Doc_ID);
                        break;
                    case 3: // Балансировка расхождений
                        this.InvokeTotalDiscrepanciesOffer(this.SelectedDoc.Doc_ID);
                        //if (this.InvokeTotalDiscrepanciesOffer(this.SelectedDoc.Doc_ID))
                        //    this.InvokeMovementShortage(this.SelectedDoc.Doc_ID);
                        break;
                    //case 4: // Перемещение итоговых недостач
                    //    this.InvokeMovementShortage(this.SelectedDoc.Doc_ID);
                    //    break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Запуск корректировки остатков
        /// </summary>
        private bool RunCorrectRemains(long inventoryID)
        {
            Data.Inventory.InventoryCorrectRemainsResponseDataTable dtResponse = null;
            bool loadSucceded = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    using (Data.InventoryTableAdapters.InventoryCorrectRemainsResponseTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryCorrectRemainsResponseTableAdapter())
                    {
                        int RESPONSE_WAIT_TIMEOUT = 1800; // 30 минут
                        adapter.SetTimeout(RESPONSE_WAIT_TIMEOUT);
                        e.Result = adapter.GetData(inventoryID);
                    }
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    dtResponse = e.Result as Data.Inventory.InventoryCorrectRemainsResponseDataTable;
                    loadSucceded = true;
                }

                waitProgressForm.CloseForce();
            };
            waitProgressForm.ActionText = "Выполняется корректировка остатка..";
            loadWorker.RunWorkerAsync();
            waitProgressForm.ShowDialog();

            if (loadSucceded)
            {
                if (dtResponse.Count > 0)
                {
                    if (!dtResponse[0].IsAmountUAHNull())
                    {
                        MessageBox.Show(string.Format("Остаток откорректирован.\n\nВыполнена проводка на сумму {0} грн.", dtResponse[0].AmountUAH.ToString("f2")), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }

            return loadSucceded;
        }

        /// <summary>
        /// Сформировать ведомость расхождений
        /// </summary>
        /// <param name="inventoryID"></param>
        private bool CreateSheetOfDiscrepancies(long inventoryID)
        {
            var dlgDifferenceDoc = new InventoryDifferenceDocForm() { UserID = this.UserID, InventoryDocID = inventoryID };
            return dlgDifferenceDoc.ShowDialog() == DialogResult.OK;
            
            #region Not used
            //bool canContinue = false;
            //BackgroundWorker loadWorker = new BackgroundWorker();
            //loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            //{
            //    try
            //    {
            //        using (Data.InventoryTableAdapters.SheetOfDiscrepanciesReportTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.SheetOfDiscrepanciesReportTableAdapter())
            //            adapter.Fill(this.inventory.SheetOfDiscrepanciesReport, this.UserID, inventoryID);
            //    }
            //    catch (Exception ex)
            //    {
            //        e.Result = ex;
            //    }
            //};
            //loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            //{
            //    if (e.Result is Exception)
            //        this.ShowError(e.Result as Exception);
            //    else
            //        canContinue = true;

            //    waitProgressForm.CloseForce();
            //};
            //waitProgressForm.ActionText = "Выполняется формирование ведомости расхождений..";
            //loadWorker.RunWorkerAsync();
            //waitProgressForm.ShowDialog();


            //// Источник для отчета сформирован - можно печатать
            //if (canContinue)
            //{
            //    using (WMSOffice.Reports.InventorySheetOfDiscrepanciesReport report = new WMSOffice.Reports.InventorySheetOfDiscrepanciesReport())
            //    {
            //        report.SetDataSource(this.inventory);
            //        report.SetParameterValue("InventoryDocID", inventoryID);
            //        //report.PrintOptions.PrinterName = cmbPrinters.SelectedText;

            //        using (SaveFileDialog dlgSaveToPDF = new SaveFileDialog()
            //        {
            //            Title = "Укажите файл для сохранения ведомости расхождений",
            //            Filter = "PDF файлы (*.pdf)|*.pdf",
            //            FileName = string.Format("Ведомость расхождений по инвентаризации № {0}", inventoryID)
            //        })
            //            if (dlgSaveToPDF.ShowDialog() == DialogResult.OK)
            //            {
            //                report.ExportToDisk(ExportFormatType.PortableDocFormat, dlgSaveToPDF.FileName);
            //                Thread.Sleep(500);
            //                Process.Start(dlgSaveToPDF.FileName);
            //            }
            //    }
            //}
            #endregion
        }

        /// <summary>
        /// Балансировка расхождений
        /// </summary>
        /// <param name="inventoryID"></param>
        private bool InvokeTotalDiscrepanciesOffer(long inventoryID)
        {
            var dlgManageDiscrepancies = new InventoryManageDiscrepanciesForm() { UserID = this.UserID, InventoryDocID = this.InventoryDocID };
            return dlgManageDiscrepancies.ShowDialog() == DialogResult.OK;
        }

        /// <summary>
        /// Перемещение итоговых недостач
        /// </summary>
        [Obsolete]
        private bool InvokeMovementShortage(long inventoryID)
        {
            var dlgMovementShortage = new InventoryShortageMovementForm() { UserID = this.UserID, InventoryDocID = inventoryID };
            return dlgMovementShortage.ShowDialog() == DialogResult.OK;
        }
    }

    /// <summary>
    /// Представление счетных листов
    /// </summary>
    public class CountSheetsView : IDataView
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

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as CountSheetsParameters;

            string query = string.Format("EXEC [dbo].[pr_IV_IM_GetCalcSheets] {0}, {1}, {2}",
                searchCriteria.UserID,
                searchCriteria.InventoryDocID,
                searchCriteria.CalcID);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        public CountSheetsView()
        {
            this.dataColumns.Add(new PatternColumn("№ бригады", "Team_ID", new FilterCompareExpressionRule<Int64>("Team_ID")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Статус", "Status", new FilterPatternExpressionRule("Status")) { Width = 280 });
            this.dataColumns.Add(new PatternColumn("№ сч. листа", "ID", new FilterCompareExpressionRule<Int64>("ID")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Порядк. ном.", "CS_ID", new FilterCompareExpressionRule<Int32>("CS_ID")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ пересч.", "Calc_ID", new FilterCompareExpressionRule<Int16>("Calc_ID")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("№ инв.", "Doc_ID", new FilterCompareExpressionRule<Int32>("Doc_ID")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Тип", "CS_Type", new FilterPatternExpressionRule("CS_Type")) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Штрих-код", "Bar_Code", new FilterPatternExpressionRule("Bar_Code")) { Width = 180 });
        }
    }

    /// <summary>
    /// Критерий поиска счетных листов
    /// </summary>
    public class CountSheetsParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public long InventoryDocID { get; set; }
        public short CalcID { get; set; }
    }
}
