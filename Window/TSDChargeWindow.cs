using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Classes;
using WMSOffice.Dialogs.WH.TSD;

namespace WMSOffice.Window
{
    public partial class TSDChargeWindow : GeneralWindow
    {
        public Data.TSD.TSDAccountingDepotsRow SelectedDepot { get { return dgvDepots.SelectedRows.Count > 0 ? (dgvDepots.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.TSD.TSDAccountingDepotsRow : null; } }

        public TSDChargeWindow()
        {
            InitializeComponent();
        }

        private void TSDChargeWindow_Load(object sender, EventArgs e)
        {
            this.Initialize();
        }

        private void Initialize()
        {
            xdgvUsageItems.AllowSummary = false;
            xdgvChargeItems.AllowSummary = false;
            xdgvCheckItems.AllowSummary = false;

            xdgvUsageItems.Init(new TSDAccauntingView(TSDAccountingMode.Usage), true);
            xdgvChargeItems.Init(new TSDAccauntingView(TSDAccountingMode.Charge), true);
            xdgvCheckItems.Init(new TSDAccauntingView(TSDAccountingMode.Check), true);

            xdgvUsageItems.UserID = this.UserID;
            xdgvChargeItems.UserID = this.UserID;
            xdgvCheckItems.UserID = this.UserID;

            xdgvUsageItems.UseMultiSelectMode = false;
            xdgvChargeItems.UseMultiSelectMode = false;
            xdgvCheckItems.UseMultiSelectMode = false;

            xdgvUsageItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvChargeItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvCheckItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);

            xdgvUsageItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvChargeItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvCheckItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);

            xdgvUsageItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);
            xdgvChargeItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);
            xdgvCheckItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);

            xdgvUsageItems.OnMouseDown += new MouseEventHandler(xdgvItems_MouseDown);
            xdgvChargeItems.OnMouseDown += new MouseEventHandler(xdgvItems_MouseDown);
            xdgvCheckItems.OnMouseDown += new MouseEventHandler(xdgvItems_MouseDown);

            xdgvUsageItems.OnMouseMove += new MouseEventHandler(xdgvItems_MouseMove);
            xdgvChargeItems.OnMouseMove += new MouseEventHandler(xdgvItems_MouseMove);
            xdgvCheckItems.OnMouseMove += new MouseEventHandler(xdgvItems_MouseMove);

            this.SetOperationsAccess();
        }

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
            (sender as ExtraDataGridView).RecalculateSummary();
        }

        void xdgvItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.RefreshData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            this.RefreshDepots();
        }

        private void RefreshDepots()
        {
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            try
            {
                var depot = this.SelectedDepot;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = tSDAccountingDepotsTableAdapter.GetData(this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                        tSDAccountingDepotsBindingSource.DataSource = e.Result;
                };
                tSDAccountingDepotsBindingSource.DataSource = null;
                waitProgressForm.ActionText = "Выполняется загрузка шкафов..";
                bw.RunWorkerAsync();
                waitProgressForm.ShowDialog();

                if (depot != null)
                    this.NavigateToDepot(depot.Depot_ID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void NavigateToDepot(short depotID)
        {
            foreach (DataGridViewRow dgvDepot in dgvDepots.Rows)
            {
                var depot = (dgvDepot.DataBoundItem as DataRowView).Row as Data.TSD.TSDAccountingDepotsRow;
                if (depot.Depot_ID.Equals(depotID))
                {
                    dgvDepot.Selected = true;
                    dgvDepots.FirstDisplayedScrollingRowIndex = dgvDepot.Index;
                    return;
                }
            }
        }

        private void dgvDepots_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
            this.RefreshItems();
        }

        private void SetOperationsAccess()
        {
            btnOpenDepot.Visible = this.SelectedDepot == null || this.SelectedDepot.IsOpenedNull() ? false : !this.SelectedDepot.Opened;
            btnCloseDepot.Visible = this.SelectedDepot == null || this.SelectedDepot.IsOpenedNull() ? false : this.SelectedDepot.Opened;
            tssOpenCloseDepot.Visible = btnOpenDepot.Visible || btnCloseDepot.Visible;

            btnEditTSDSettings.Enabled = true;

            btnExportToExcel.Enabled = this.SelectedDepot != null;
        }

        private void RefreshItems()
        {
            var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

            try
            {
                var searchParameters = new TSDAccauntingSearchParameters();
                searchParameters.SessionID = this.UserID;
                searchParameters.DepotID = this.SelectedDepot == null ? (short?)null : this.SelectedDepot.Depot_ID;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) => 
                {
                    try
                    {
                        this.xdgvUsageItems.DataView.FillData(e.Argument as TSDAccauntingSearchParameters);
                        this.xdgvChargeItems.DataView.FillData(e.Argument as TSDAccauntingSearchParameters);
                        this.xdgvCheckItems.DataView.FillData(e.Argument as TSDAccauntingSearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    waitProgressForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvUsageItems.BindData(false);
                        this.xdgvChargeItems.BindData(false);
                        this.xdgvCheckItems.BindData(false);

                        //this.xdgvChargeItems.AllowFilter = true;
                        //this.xdgvUsageItems.AllowFilter = true;
                        this.xdgvUsageItems.AllowSummary = true;
                        this.xdgvChargeItems.AllowSummary = true;
                        this.xdgvCheckItems.AllowSummary = true;
                    }
                };
                waitProgressForm.ActionText = "Выполняется загрузка закрепленных ТСД..";
                bw.RunWorkerAsync(searchParameters);
                waitProgressForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnOpenDepot_Click(object sender, EventArgs e)
        {
            try
            {
                var depotID = this.SelectedDepot.Depot_ID;
                tSDAccountingDepotsTableAdapter.OpenDepot(this.UserID, depotID);

                this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCloseDepot_Click(object sender, EventArgs e)
        {
            try
            {
                var depotID = this.SelectedDepot.Depot_ID;
                tSDAccountingDepotsTableAdapter.CloseDepot(this.UserID, depotID);

                this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        #region Drag & Drop

        private DataGridView.HitTestInfo downHitInfo = null;
        private void xdgvItems_MouseDown(object sender, MouseEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            downHitInfo = null;
            DataGridView.HitTestInfo hitInfo = view.HitTest(e.X, e.Y);
            if (Control.ModifierKeys != Keys.None) return;
            if (e.Button == MouseButtons.Left && hitInfo.RowIndex >= 0)
                downHitInfo = hitInfo;
        }

        private void xdgvItems_MouseMove(object sender, MouseEventArgs e)
        {
            DataGridView view = (DataGridView)sender;
            if (e.Button == MouseButtons.Left && downHitInfo != null)
            {
                Size dragSize = SystemInformation.DragSize;
                Rectangle dragRect = new Rectangle(new Point(downHitInfo.ColumnX - dragSize.Width / 2,
                    downHitInfo.RowY - dragSize.Height / 2), dragSize);

                if (!dragRect.Contains(new Point(e.X, e.Y)))
                {
                    Data.TSD.TSDAccountingItemsRow row = (Data.TSD.TSDAccountingItemsRow)((DataRowView)(view.Rows[downHitInfo.RowIndex]).DataBoundItem).Row;
                    //if (row.)
                    view.DoDragDrop(row, DragDropEffects.Link);
                    downHitInfo = null;
                }
            }
        }

        private void dgvDepots_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Data.TSD.TSDAccountingItemsRow)))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;

            DataGridView grid = (DataGridView)sender;
            Point clientLocation = grid.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo leaveInfo = grid.HitTest(clientLocation.X, clientLocation.Y);

            var rowIndex = leaveInfo.RowIndex;

            if (rowIndex == highlightedRowIndex)
                return;

            // Unhighlight the previously highlighted row.
            if (highlightedRowIndex >= 0)
                SetRowStyle(dgvDepots.Rows[highlightedRowIndex], null);

            // Highlight the row holding the mouse.
            highlightedRowIndex = rowIndex;
            if (highlightedRowIndex >= 0)
                SetRowStyle(dgvDepots.Rows[highlightedRowIndex], highlightStyle);
        }

        private void dgvDepots_DragDrop(object sender, DragEventArgs e)
        {
            DataGridView grid = (DataGridView)sender;
            Point clientLocation = grid.PointToClient(new Point(e.X, e.Y));
            DataGridView.HitTestInfo leaveInfo = grid.HitTest(clientLocation.X, clientLocation.Y);
            if (leaveInfo.RowIndex >= 0)
            {
                try
                {
                    Data.TSD.TSDAccountingItemsRow item = (Data.TSD.TSDAccountingItemsRow)e.Data.GetData(typeof(Data.TSD.TSDAccountingItemsRow));
                    Data.TSD.TSDAccountingDepotsRow depotTarget = (Data.TSD.TSDAccountingDepotsRow)((DataRowView)grid.Rows[leaveInfo.RowIndex].DataBoundItem).Row;

                    if (depotTarget.Depot_ID == this.SelectedDepot.Depot_ID)
                        throw new Exception("Невозможно переместить ТСД в тот же шкаф.");

                   var terminalID = item.terminal_id.Trim();
                    var depotName = depotTarget.Depot_Name.Trim();
                    if (MessageBox.Show(string.Format("Вы подтверждаете перемещение ТСД \"{0}\"\r\nв шкаф \"{1}\"?", terminalID, depotName), "Перемещение ТСД", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        var depotID = depotTarget.Depot_ID;
                        tSDAccountingDepotsTableAdapter.ChangeDepot(this.UserID, terminalID, depotID);

                        this.RefreshData();
                    }
                    else
                    {
                        // Unhighlight the previously highlighted row.
                        if (highlightedRowIndex >= 0)
                            SetRowStyle(dgvDepots.Rows[highlightedRowIndex], null);
                    }
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                }
            }
        }

        private int highlightedRowIndex = -1;
        private readonly DataGridViewCellStyle highlightStyle = new DataGridViewCellStyle { BackColor = Color.Khaki };

        private void dgvDepots_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (highlightedRowIndex >= 0)
            {
                SetRowStyle(dgvDepots.Rows[highlightedRowIndex], null);
                highlightedRowIndex = -1;
            }
        }

        private void SetRowStyle(DataGridViewRow row, DataGridViewCellStyle style)
        {
            foreach (DataGridViewCell cell in row.Cells)
                cell.Style = style;
        }

        #endregion

        private void btnEditTSDSettings_Click(object sender, EventArgs e)
        {
            try
            {
                var frmTSD_Settings = new TSD_SettingsForm { UserID = this.UserID };
                if (frmTSD_Settings.ShowDialog() == DialogResult.OK)
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                var depotID = this.SelectedDepot.Depot_ID;
                var depotName = this.SelectedDepot.Depot_Name.Trim();

                var view = new TSDAccauntingView(TSDAccountingMode.All);

                var table = view.Data;
                var titles = new List<string>();
                var columnNames = new List<string>();

                var success = false;


                var waitProgressForm = new WMSOffice.Dialogs.SplashForm();

                var exportWorker = new BackgroundWorker();
                exportWorker.DoWork += (s, ea) =>
                {
                    try
                    {
                        var searchParameters = new TSDAccauntingSearchParameters() { DepotID = depotID };
                        view.FillData(searchParameters);
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                exportWorker.RunWorkerCompleted += (s, ea) =>
                {
                    waitProgressForm.CloseForce();

                    if (ea.Result is Exception)
                        this.ShowError(ea.Result as Exception);
                    else
                    {
                        foreach (PatternColumn column in view.Columns)
                        {
                            titles.Add(column.Caption);
                            columnNames.Add(column.DataFieldName);
                        }

                        success = true;
                    }
                };

                waitProgressForm.ActionText = "Выполняется экспорт закрепленных ТСД..";
                exportWorker.RunWorkerAsync();
                waitProgressForm.ShowDialog();

                if (success)
                    ExportHelper.ExportDataTableToExcel(view.Data, titles.ToArray(), columnNames.ToArray(), string.Format("Экспорт списка закрепленных ТСД за шкафом [{0}]", depotName), string.Format("Список закрепленных ТСД за шкафом [{0}]", depotName), true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void xdgvChargeItems_Load(object sender, EventArgs e)
        {

        }

        private void extraDataGridView1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDepots_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    /// <summary>
    /// Представление для грида учтенных ТСД
    /// </summary>
    public class TSDAccauntingView : IDataView
    {
        public TSDAccountingMode AccountingMode { get; private set; }

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
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var searchParameters = pSearchParameters as TSDAccauntingSearchParameters;
            var sessionID = Convert.ToInt32(searchParameters.SessionID);
            var depotID = searchParameters.DepotID;
            var isChargeAccauntingModeApplied = 
                this.AccountingMode == TSDAccountingMode.Charge 
                    ? 1 
                    : this.AccountingMode == TSDAccountingMode.Usage
                    ? 0
                    : this.AccountingMode == TSDAccountingMode.Check 
                        ? 2 
                        : (int?)null; 

            using (var adapter = new Data.TSDTableAdapters.TSDAccountingItemsTableAdapter())
                data = adapter.GetData(sessionID, depotID, isChargeAccauntingModeApplied);
        }

        #endregion

        public TSDAccauntingView(TSDAccountingMode accountingMode)
        {
            switch ((this.AccountingMode = accountingMode))
            {
                case TSDAccountingMode.Charge:
                    this.dataColumns.Add(new PatternColumn("Название", "terminal_id", new FilterPatternExpressionRule("terminal_id"), SummaryCalculationType.Count) { Width = 110 });
                    this.dataColumns.Add(new PatternColumn("Инв. №", "Inventory_No", new FilterPatternExpressionRule("Inventory_No")) { Width = 110 });
                    this.dataColumns.Add(new PatternColumn("Кто вернул", "FN_USER", new FilterPatternExpressionRule("FN_USER")) { Width = 280 });
                    this.dataColumns.Add(new PatternColumn("Когда вернул", "FN_DTTM", new FilterDateCompareExpressionRule("FN_DTTM")) { Width = 150 });
                    break;
                case TSDAccountingMode.Usage:
                    this.dataColumns.Add(new PatternColumn("Название", "terminal_id", new FilterPatternExpressionRule("terminal_id"), SummaryCalculationType.Count) { Width = 75 });
                    this.dataColumns.Add(new PatternColumn("Инв. №", "Inventory_No", new FilterPatternExpressionRule("Inventory_No")) { Width = 75 });
                    this.dataColumns.Add(new PatternColumn("Кто взял", "ST_USER", new FilterPatternExpressionRule("ST_USER")) { Width = 260 });
                    this.dataColumns.Add(new PatternColumn("Когда взял", "ST_DTTM", new FilterDateCompareExpressionRule("ST_DTTM")) { Width = 140 });
                    this.dataColumns.Add(new PatternColumn("Кто пользовался", "Last_USER", new FilterPatternExpressionRule("Last_USER")) { Width = 260 });
                    this.dataColumns.Add(new PatternColumn("Когда пользовался", "Last_Action_DTTM", new FilterDateCompareExpressionRule("Last_Action_DTTM")) { Width = 140 });
                    break;
                case TSDAccountingMode.Check:
                    this.dataColumns.Add(new PatternColumn("Название", "terminal_id", new FilterPatternExpressionRule("terminal_id"), SummaryCalculationType.Count) { Width = 70 });
                    this.dataColumns.Add(new PatternColumn("Инв. №", "Inventory_No", new FilterPatternExpressionRule("Inventory_No")) { Width = 70 });
                    this.dataColumns.Add(new PatternColumn("Дата проверки", "ST_DTTM", new FilterDateCompareExpressionRule("ST_DTTM")) { Width = 130 });
                    break;
                case TSDAccountingMode.All:
                    this.dataColumns.Add(new PatternColumn("Название ТСД", "terminal_id", new FilterPatternExpressionRule("terminal_id")));
                    this.dataColumns.Add(new PatternColumn("Место хранения", "Depot_Name", new FilterPatternExpressionRule("Depot_Name")));
                    this.dataColumns.Add(new PatternColumn("Кто взял", "ST_USER", new FilterPatternExpressionRule("ST_USER")));
                    this.dataColumns.Add(new PatternColumn("Когда взял", "ST_DTTM", new FilterDateCompareExpressionRule("ST_DTTM")));
                    this.dataColumns.Add(new PatternColumn("Кто вернул", "FN_USER", new FilterPatternExpressionRule("FN_USER")));
                    this.dataColumns.Add(new PatternColumn("Когда вернул", "FN_DTTM", new FilterDateCompareExpressionRule("FN_DTTM")));
                    this.dataColumns.Add(new PatternColumn("Кто пользовался", "Last_USER", new FilterPatternExpressionRule("Last_USER")));
                    this.dataColumns.Add(new PatternColumn("Когда пользовался", "Last_Action_DTTM", new FilterDateCompareExpressionRule("Last_Action_DTTM")));
                    this.dataColumns.Add(new PatternColumn("Инвентарный номер", "Inventory_No", new FilterPatternExpressionRule("Inventory_No")));
                    break;
                default:
                    break;
            }
        }
    }

    public class TSDAccauntingSearchParameters : SessionIDSearchParameters
    {
        public short? DepotID { get; set; }
    }

    public enum TSDAccountingMode
    { 
        /// <summary>
        /// Все
        /// </summary>
        All = -1,

        /// <summary>
        /// Хранение
        /// </summary>
        Charge = 1,

        /// <summary>
        /// Использование
        /// </summary>
        Usage = 2 ,

        /// <summary>
        /// На проверке
        /// </summary>
        Check = 3
    }

    /// <summary>
    /// Тип шкафа (МХ)
    /// </summary>
    public enum DepotType
    {
        /// <summary>
        /// Основное МХ
        /// </summary>
        Common = 0,

        /// <summary>
        /// Ремонтное МХ
        /// </summary>
        Repair = 1,

        /// <summary>
        /// МХ доступных ТСД
        /// </summary>
        Accessible = 2
    }
}
