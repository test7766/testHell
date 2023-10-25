using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WO;
using WMSOffice.Data;
using WMSOffice.Reports;
using WMSOffice.Dialogs;
using WMSOffice.Controls;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class WODocsWMoveWindow : GeneralWindow
    {
        /// <summary>
        /// Индикатор выполнения длительной операции
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        public WODocsWMoveWindow()
        {
            InitializeComponent();
        }

        private void WODocsWMoveWindow_Load(object sender, EventArgs e)
        {
            Initialize();
            ClearTerminalLabels();
            RefreshFilters();
        }

        private string Type { get { return (cbDocType.SelectedValue != null) ? (string)cbDocType.SelectedValue : ""; } }
        private string Zone { get { return (cbZones.SelectedValue != null) ? (string)cbZones.SelectedValue : ""; } }
        private string TerminalGroup { get { return (cbTerminalGroups.SelectedValue != null) ? (string)cbTerminalGroups.SelectedValue : ""; } }
        private string Warehouse { get { return string.IsNullOrEmpty(stbWarehouse.Value) ? (string)null : stbWarehouse.Value; } }

        private Data.WMove.DocsRow SelectedDoc { get { return (xdgvDocs.SelectedItems.Count == 1) ? (Data.WMove.DocsRow)(xdgvDocs.SelectedItems[0]) : null; } }
        private long? SelectedDocID { get { return (SelectedDoc != null) ? (long?)SelectedDoc.Doc_ID : null; } }
        private Data.WMove.DocDetailsRow SelectedDocDetail { get { return (gvDetails.SelectedRows.Count == 1) ? (Data.WMove.DocDetailsRow)((DataRowView)gvDetails.SelectedRows[0].DataBoundItem).Row : null; } }

        private bool isClosing = false;

        private void Initialize()
        {
            xdgvDocs.UserID = this.UserID;

            this.xdgvDocs.UseMultiSelectMode = true;

            //this.xdgvDocs.AllowFilter = false;
            this.xdgvDocs.AllowSummary = false;
            this.xdgvDocs.AllowRangeColumns = true;

            this.xdgvDocs.SetSameStyleForAlternativeRows();
            this.xdgvDocs.SetCellStyles(gvDetails.RowTemplate.DefaultCellStyle, gvDetails.ColumnHeadersDefaultCellStyle);
            this.xdgvDocs.FilterGrid.DefaultCellStyle = gvDetails.DefaultCellStyle;
            this.xdgvDocs.SummaryGrid.DefaultCellStyle = gvDetails.DefaultCellStyle;

            this.xdgvDocs.DataGrid.ContextMenuStrip = cmMain;

            this.xdgvDocs.Init(new WODocsWMoveView(), true);

            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_SelectionChanged);
            xdgvDocs.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDocs_CellContentDoubleClick);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_CellFormatting);
            xdgvDocs.OnMouseDown += new MouseEventHandler(xdgvDocs_MouseDown);
            xdgvDocs.OnMouseMove += new MouseEventHandler(xdgvDocs_MouseMove);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();
        }

        private void RefreshFilters()
        {
            this.wMove.TerminalGroups.AddTerminalGroupsRow("", "(все)");
            this.wMove.TerminalGroups.Merge(this.terminalGroupsTableAdapter.GetData());
            this.wMove.Zones.AddZonesRow("", "(все)");
            this.wMove.Zones.Merge(this.zonesTableAdapter.GetData());
            this.wMove.DocTypes.AddDocTypesRow("", "(все)");
            this.wMove.DocTypes.Merge(this.docTypesTableAdapter.GetData());

            this.stbWarehouse.UserID = this.UserID;
            this.stbWarehouse.ValueReferenceQuery = "[dbo].[pr_WM_Get_MCU_List]";
            this.stbWarehouse.OnVerifyValue += stbWarehouses_OnVerifyValue;
        }

        void stbWarehouses_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            Label lblDescription = null;

            if (control == stbWarehouse)
                lblDescription = lblWarehouseName;

            if (lblDescription != null)
            {
                lblDescription.Text = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        private void RefreshAllData()
        {
            if (!isClosing)
            {
                RefreshDocs();
                RefreshTerminals();
            }
        }
        private void RefreshDocs()
        {
            long selectedDocID = 0;
            int scrollingRowIndex = 0;
            if (xdgvDocs.SelectedItems.Count > 0)
            {
                selectedDocID = ((Data.WMove.DocsRow)(xdgvDocs.SelectedItems[0])).Doc_ID;
                scrollingRowIndex = xdgvDocs.FirstDisplayedScrollingRowIndex;
            }

            var searchCriteria = new WODocsWMoveSearchParameters() { SessionID = UserID };
            searchCriteria.DocType = Type;
            searchCriteria.Zone = Zone;
            searchCriteria.TerminalGroup = TerminalGroup;
            searchCriteria.ItemID = (int?)null;
            searchCriteria.Warehouse = Warehouse;

            bool success = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate (object sender, DoWorkEventArgs e)
            {
                try
                {
                    xdgvDocs.DataView.FillData(e.Argument as WODocsWMoveSearchParameters);
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
                    xdgvDocs.BindData(false);
                    xdgvDocs.AllowSummary = true;

                    success = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется загрузка документов..";
            loadWorker.RunWorkerAsync(searchCriteria);
            waitProcessForm.ShowDialog();

            ////DateTime n = DateTime.Now;
            //docsTableAdapter.Fill(wMove.Docs, Type, Zone, TerminalGroup, UserID);
            ////MessageBox.Show((DateTime.Now - n).TotalMilliseconds.ToString());

            if (success)
            {
                if (selectedDocID > 0)
                    foreach (DataGridViewRow row in xdgvDocs.DataGrid.Rows)
                        if (selectedDocID == ((Data.WMove.DocsRow)((DataRowView)row.DataBoundItem).Row).Doc_ID)
                        {
                            xdgvDocs.DataGrid.SelectedRows[0].Selected = false;
                            row.Selected = true;
                            xdgvDocs.DataGrid.FirstDisplayedScrollingRowIndex = scrollingRowIndex;
                            break;
                        }
            }
        }

        private void RefreshDetails()
        {
            long? id = SelectedDocID;
            if (id.HasValue)
                docDetailsTableAdapter.Fill(wMove.DocDetails, id.Value);
            else
                wMove.DocDetails.Clear();
        }

        private void RefreshTerminals()
        {
            string selectedTerminalID = "";
            if (gvTerminals.SelectedRows.Count > 0)
                selectedTerminalID = ((Data.WMove.TerminalsRow)((DataRowView)gvTerminals.SelectedRows[0].DataBoundItem).Row).Terminal_ID;

            var terminalGroup = TerminalGroup;

            bool success = false;
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = terminalsTableAdapter.GetData(terminalGroup, UserID);
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
                    terminalsBindingSource.DataSource = e.Result;
                    //wMove.Terminals.Merge((DataTable)e.Result);
                    success = true;
                }

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется загрузка терминалов..";
            terminalsBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();


            //terminalsTableAdapter.Fill(wMove.Terminals, TerminalGroup, UserID);

            if (success)
            {
                if (!String.IsNullOrEmpty(selectedTerminalID))
                    foreach (DataGridViewRow row in gvTerminals.Rows)
                        if (selectedTerminalID == ((Data.WMove.TerminalsRow)((DataRowView)row.DataBoundItem).Row).Terminal_ID)
                        {
                            gvTerminals.SelectedRows[0].Selected = false;
                            row.Selected = true;
                            break;
                        }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void xdgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            Data.WMove.DocsRow diffRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WMove.DocsRow;

            // простая разрисовка строк
            Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                  ? Color.White
                                  : Color.FromName(diffRow.Color);

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = backColor;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = backColor;
        }

        private void xdgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        private void gvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            Data.WMove.DocDetailsRow diffRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WMove.DocDetailsRow;

            // простая разрисовка строк
            Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                  ? Color.White
                                  : Color.FromName(diffRow.Color);

            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = backColor;
            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = backColor;
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAllData();
        }

        private void gvTerminals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            Data.WMove.TerminalsRow diffRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WMove.TerminalsRow;

            // простая разрисовка строк
            Color backColor = (diffRow.IsColorNull() || diffRow.Color.ToLower() == "white")
                                  ? Color.White
                                  : Color.FromName(diffRow.Color);

            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = backColor;
            grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = backColor;
        }

        private Data.WMove.TerminalsRow SelectedTerminal { get { return (gvTerminals.SelectedRows.Count == 1) ? (Data.WMove.TerminalsRow)((DataRowView)gvTerminals.SelectedRows[0].DataBoundItem).Row : null; } }

        private void gvTerminals_SelectionChanged(object sender, EventArgs e)
        {
            if (SelectedTerminal != null && !SelectedTerminal.IsWO_Doc_IDNull())
            {
                lblWODocType.Text = SelectedTerminal.WO_Doc_Type;
                lblWODocID.Text = SelectedTerminal.WO_Doc_ID.ToString();
                lblWHDocType.Text = SelectedTerminal.Related_WH_Doc_Type;
                lblWHDocID.Text = SelectedTerminal.Related_WH_Doc_ID.ToString();
            } else
            {
                ClearTerminalLabels();
            }
        }

        private void ClearTerminalLabels()
        {
            lblWODocType.Text = lblWODocID.Text = lblWHDocType.Text = lblWHDocID.Text = "";
        }

        private void lblWHDocID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            long docID = 0;
            if (long.TryParse(lblWHDocID.Text, out docID))
                foreach (DataGridViewRow viewRow in xdgvDocs.DataGrid.Rows)
                {
                    var row = (Data.WMove.DocsRow) ((DataRowView) viewRow.DataBoundItem).Row;
                    if (row.Doc_ID == docID && row.Doc_Type == lblWHDocType.Text)
                    {
                        if (xdgvDocs.DataGrid.SelectedRows.Count == 1) xdgvDocs.DataGrid.SelectedRows[0].Selected = false;
                        viewRow.Selected = true;
                        break;
                    }
                }
        }

        #region Drag & Drop - new assign
        private DataGridView.HitTestInfo downHitInfo = null;
        private void xdgvDocs_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            downHitInfo = null;
            DataGridView.HitTestInfo hitInfo = view.HitTest(e.X, e.Y);
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowIndex >= 0)
                downHitInfo = hitInfo;
        }

        private void xdgvDocs_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.ColumnX - dragSize.Width / 2,
                    downHitInfo.RowY - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    Data.WMove.DocsRow row = (Data.WMove.DocsRow)((DataRowView)(view.Rows[downHitInfo.RowIndex]).DataBoundItem).Row;
                    //if (row.)
                    view.DoDragDrop(row, DragDropEffects.Link);
                    downHitInfo = null;
                }
            }
        }

        private void gvTerminals_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Data.WMove.DocsRow)))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void gvTerminals_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            Point clientLocation = grid.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo leaveInfo = grid.HitTest(clientLocation.X, clientLocation.Y);
            if (leaveInfo.RowIndex >= 0)
                try
                {
                    Data.WMove.DocsRow docsRow = (Data.WMove.DocsRow)e.Data.GetData(typeof(Data.WMove.DocsRow));
                    Data.WMove.TerminalsRow terminalsRow = (Data.WMove.TerminalsRow)((DataRowView)grid.Rows[leaveInfo.RowIndex].DataBoundItem).Row;
                    //MessageBox.Show(docsRow.Doc_ID.ToString() + " to " + terminalsRow.Terminal_Name);
                    docsTableAdapter.SetDocToWO(docsRow.Doc_ID, terminalsRow.Terminal_ID);
                    RefreshAllData();
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
        }
        #endregion

        #region show detailes by item
        private void gvDetails_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (xdgvDocs.SelectedItems.Count > 0)
            {
                Data.WMove.DocsRow docsRow = (Data.WMove.DocsRow)(xdgvDocs.SelectedItems[0]);
                if (docsRow.IsWo_Doc_IDNull()) return; // документ без привязки к заданию для ТСД (нет факта выполнения)
                Data.WMove.DocDetailsRow detailsRow = (Data.WMove.DocDetailsRow) ((DataRowView) gvDetails.Rows[e.RowIndex].DataBoundItem).Row;

                Dialogs.WO.WOAssigDetailsForm form = new WOAssigDetailsForm();
                form.Doc_ID = docsRow.Wo_Doc_ID;
                form.Item_ID = detailsRow.Item_ID;
                form.Item_Code_Label = detailsRow.Item_ID.ToString();
                form.Item_Name_Label = detailsRow.Item_Name;
                form.Quantity_Label = detailsRow.Qty.ToString();
                form.Fact_Label = detailsRow.Wo_Qty.ToString();
                form.ShowDialog();
                RefreshDetails();
            }
        }
        #endregion

        private void WODocsWMoveWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            isClosing = true;
        }

        /// <summary>
        /// По двойному щелчку на документе размещения предлагаем напечатать повторно лист размещения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xdgvDocs_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Data.WMove.DocsRow docRow = (Data.WMove.DocsRow)((DataRowView)xdgvDocs.DataGrid.Rows[e.RowIndex].DataBoundItem).Row;
                if (docRow.Doc_Type == "MP" || docRow.Doc_Type == "AP")
                    if (MessageBox.Show("Напечатать упаковочный лист повторно?", "Печать", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        long moveTaskID = docRow.Doc_ID;
                        PrintMoveTaskList(moveTaskID);
                    }
            }
        }

        /// <summary>
        /// Метод печати листа размещения по его идентификатору
        /// </summary>
        /// <param name="moveTaskID"></param>
        private void PrintMoveTaskList(long moveTaskID)
        {
            try
            {
                // создадим таблицу для данных отчета
                WMove.WM_PutListDataTable putList = new WMove.WM_PutListDataTable();

                // получим данные отчета, штрих-код создан
                InterbranchReceiveWindow.MovePutListPrepare(putList, moveTaskID);

                // напечатаем лист размещения
                WMovePutListReport report = new WMovePutListReport();
                report.SetDataSource((DataTable)putList);

                ReportForm form = new ReportForm();
                form.ReportDocument = report;
                form.ShowDialog();

                if (form.IsPrinted)
                {
                    // логирование факта печати
                    PrintDocsThread.AddPrintingDocTelemetryData(this.UserID, "WM", 1, Convert.ToInt64(moveTaskID), (string)null, Convert.ToInt16(putList.Count), form.PrinterName, Convert.ToByte(form.Copies));
                }
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        /// <summary>
        /// Обработчик события "Изменить место назначения" для строки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void miChangeLocnByRow_Click(object sender, EventArgs e)
        {
            if (SelectedDoc != null && SelectedDocDetail != null)
            {
                // создание формы редактирования места назначения
                Dialogs.WMove.ChangeLocnForm form = new WMSOffice.Dialogs.WMove.ChangeLocnForm();
                form.DocID = SelectedDoc.Doc_ID;
                form.ItemID = SelectedDocDetail.Item_ID;
                form.SessionID = UserID;
                form.Qty = (SelectedDocDetail.IsQtyNull()) ? 0 : SelectedDocDetail.Qty;
                form.Locn = (SelectedDocDetail.IsLocationToNull()) ? "" : SelectedDocDetail.LocationTo;

                // вызов формы
                if (form.ShowDialog() == DialogResult.OK)
                {
                    docDetailsTableAdapter.CorrectLocnInDetail(SelectedDoc.Doc_ID, SelectedDocDetail.Line_ID, UserID,
                        form.Locn, (form.QtySplit > 0) ? form.LocnSplit : "", (form.QtySplit > 0) ? (double?)form.QtySplit : null,
                        form.ReasonCodeID, form.ReasonDescription);
                    RefreshDetails();
                }
            }
        }
    }

    /// <summary>
    /// Представление для грида с документами направлений
    /// </summary>
    public class WODocsWMoveView : IDataView
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #endregion

        #region РЕАЛИЗАЦИЯ ИНТЕРФЕЙСА IDataView

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sc = pSearchParameters as WODocsWMoveSearchParameters;

            var docType = sc.DocType;
            var zone = sc.Zone;
            var terminalGroup = sc.TerminalGroup;
            var userID = sc.SessionID;
            var itemID = sc.ItemID;
            var warehouse = sc.Warehouse;

            using (var adapter = new Data.WMoveTableAdapters.DocsTableAdapter())
                data = adapter.GetData(docType, zone, terminalGroup, userID, itemID, warehouse);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public WODocsWMoveView()
        {
            this.dataColumns.Add(new PatternColumn("ID", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID")));
            this.dataColumns.Add(new PatternColumn("Тип", "Doc_Type", new FilterPatternExpressionRule("Doc_Type"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Название", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name")));
            this.dataColumns.Add(new PatternColumn("Склад", "Warehouse_id", new FilterPatternExpressionRule("Warehouse_id"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дата", "Doc_Date", new FilterDateCompareExpressionRule("Doc_Date")));
            this.dataColumns.Add(new PatternColumn("№ заказа", "RelatedPoSoNumber", new FilterCompareExpressionRule<Int64>("RelatedPoSoNumber"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Тип заказа", "RelatedOrderType", new FilterPatternExpressionRule("RelatedOrderType")));
            this.dataColumns.Add(new PatternColumn("Сборочный", "RelatedPickSlipNumber", new FilterCompareExpressionRule<Int64>("RelatedPickSlipNumber"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Сектор", "Sector", new FilterPatternExpressionRule("Sector"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("ID докум.", "Related_WH_Doc_ID", new FilterCompareExpressionRule<Int64>("Related_WH_Doc_ID")));
        }

        #endregion
    }

    /// <summary>
    /// Параметры получения списка накладных
    /// </summary>
    public class WODocsWMoveSearchParameters : SessionIDSearchParameters
    {
        public string DocType { get; set; }
        public string Zone { get; set; }
        public string TerminalGroup { get; set; }
        public int? ItemID { get; set; }
        public string Warehouse { get; set; }

        public WODocsWMoveSearchParameters()
        {

        }
    }
}
