using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Docs;

namespace WMSOffice.Window
{
    public partial class FixedLocationsWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public FixedLocationsWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            Initialize();
        }

        private void Initialize()
        {
            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_FL_Get_MCU_List]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            stbWarehouseID.SetFirstValueByDefault();

            stbItemID.ValueReferenceQuery = "[dbo].[pr_FL_Get_Item_List]";
            stbItemID.UserID = this.UserID;
            stbItemID.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);

            stbUnitOfMeasure.ValueReferenceQuery = "[dbo].[pr_FL_Get_UOM_List]";
            stbUnitOfMeasure.UserID = this.UserID;
            stbUnitOfMeasure.OnVerifyValue += new VerifyValueHandler(stb_OnVerifyValue);
            stbUnitOfMeasure.SetFirstValueByDefault();

            xdgvItems.AllowSummary = false;

            xdgvItems.Init(new FixedLocationsView(), true);
            xdgvItems.UserID = this.UserID;

            xdgvItems.UseMultiSelectMode = true;

            xdgvItems.OnDataError += new DataGridViewDataErrorEventHandler(xdgvItems_OnDataError);
            xdgvItems.OnRowSelectionChanged += new EventHandler(xdgvItems_OnRowSelectionChanged);
            xdgvItems.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvItems_OnRowDoubleClick);
            xdgvItems.OnFilterChanged += new EventHandler(xdgvItems_OnFilterChanged);
            xdgvItems.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvItems_OnFormattingCell);

            // активация постраничного просмотра
            xdgvItems.CreatePageNavigator();

            this.SetOperationAccess(true);
        }

        void stb_OnVerifyValue(object sender, VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbWarehouseID)
                lblDescription = tbWarehouseName;
            else if (control == stbItemID)
                lblDescription = tbItemName;
            else if (control == stbUnitOfMeasure)
                lblDescription = tbUnitOfMeasure;

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

        void xdgvItems_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvItems_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        void xdgvItems_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvItems.SelectedItem != null)
                this.Edit();
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = hasRows && xdgvItems.SelectedItems.Count > 0;

                bool isEditEnabled = isEnabled;
                btnEdit.Enabled = isEditEnabled;

                bool isDeleteEnabled = isEnabled;
                btnDelete.Enabled = isDeleteEnabled;
            }
            else
            {
                bool hasRows = xdgvItems.HasRows;
                bool isEnabled = hasRows && xdgvItems.SelectedItems.Count > 0;

                bool isEditEnabled = isEnabled;
                btnEdit.Enabled = isEditEnabled;

                bool isDeleteEnabled = isEnabled;
                btnDelete.Enabled = isDeleteEnabled;
            }
        }

        void xdgvItems_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvItems.RecalculateSummary();
            this.SetOperationAccess(true);
        }

        void xdgvItems_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            try
            {
                var searchParams = new FixedLocationsViewSearchParameters() { SessionID = this.UserID };

                if (string.IsNullOrEmpty(stbWarehouseID.Value))
                    throw new Exception("Код склада должен быть указан.");
                else
                    searchParams.WarehouseID = stbWarehouseID.Value;

                if (!string.IsNullOrEmpty(stbItemID.Value))
                {
                    int itemID;
                    if (!int.TryParse(stbItemID.Value, out itemID))
                        throw new Exception("Код товара должен быть числом.");
                    else
                        searchParams.ItemID = itemID;
                }

                if (!string.IsNullOrEmpty(stbUnitOfMeasure.Value))
                {
                    searchParams.UnitOfMeasure = stbUnitOfMeasure.Value;
                }

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvItems.DataView.FillData(e.Argument as FixedLocationsViewSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvItems.BindData(false);

                        //this.xdgvItems.AllowFilter = true;
                        this.xdgvItems.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение данных..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();

                if (xdgvItems.DataGrid.Rows.Count > 0)
                    xdgvItems.DataGrid.Rows[0].Selected = false;

                xdgvItems.DataGrid.Select();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.Add();
        }

        private void Add()
        {
            var dlgFixedLocationsEdit = new FixedLocationsEditForm() { UserID = this.UserID };
            if (dlgFixedLocationsEdit.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Edit();
        } 
        
        private void Edit()
        {
            var item = (xdgvItems.SelectedItems[0] as Data.WH.FL_RowsRow);
            var clonedItem = new Data.WH.FL_RowsDataTable().NewFL_RowsRow();
            clonedItem.ItemArray = item.ItemArray;

            var dlgFixedLocationsEdit = new FixedLocationsEditForm(clonedItem) { UserID = this.UserID };
            if (dlgFixedLocationsEdit.ShowDialog() == DialogResult.OK)
                this.ReloadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены что хотите удалить выбранные фиксированные места?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                foreach (var _item in xdgvItems.SelectedItems)
                {
                    var item = _item as Data.WH.FL_RowsRow;
                    var warehouseID = item.Warehouse_ID;
                    var itemID = Convert.ToInt32(item.Item_ID);
                    var uom = item.UOM;
                    var location = item.Location;

                    using (var adapter = new Data.WHTableAdapters.FL_RowsTableAdapter())
                        adapter.Remove(this.UserID, warehouseID, itemID, uom, location);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.ReloadData();
            }
        }
    }

    /// <summary>
    /// Представление для фиксированных мест
    /// </summary>
    public class FixedLocationsView : IDataView
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
            var searchCriteria = searchParameters as FixedLocationsViewSearchParameters;

            var sessionID = searchCriteria.SessionID;
            var warehouseID = searchCriteria.WarehouseID;
            var itemID = searchCriteria.ItemID;
            var uom = searchCriteria.UnitOfMeasure;

            using (var adapter = new Data.WHTableAdapters.FL_RowsTableAdapter())
                this.data = adapter.GetData(sessionID, warehouseID, itemID, uom);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public FixedLocationsView()
        {
            this.dataColumns.Add(new PatternColumn("Филиал", "Warehouse_ID", new FilterPatternExpressionRule("Warehouse_ID"), SummaryCalculationType.Count) { Width = 120 });

            this.dataColumns.Add(new PatternColumn("Код товара", "Item_ID", new FilterCompareExpressionRule<Int32>("Item_ID"), SummaryCalculationType.Count) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Наименование товара", "ItemName", new FilterPatternExpressionRule("ItemName")) { Width = 420 });

            this.dataColumns.Add(new PatternColumn("ЕИ", "UOM", new FilterPatternExpressionRule("UOM")) { Width = 80 });

            this.dataColumns.Add(new PatternColumn("Местонахождение", "Location", new FilterPatternExpressionRule("Location"), SummaryCalculationType.Count) { Width = 160 });

            this.dataColumns.Add(new PatternColumn("Кол-во в ЗУ", "QtyInZU", new FilterCompareExpressionRule<Int32>("QtyInZU")) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во в ТЕ", "QtyInTE", new FilterCompareExpressionRule<Int32>("QtyInTE")) { Width = 130, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Кол-во ТЕ в месте", "CountTE", new FilterCompareExpressionRule<Int32>("CountTE")) { Width = 130, UseIntegerNumbersAlignment = true });

            this.dataColumns.Add(new PatternColumn("Макс. кол-во пополнения", "ReplMaxQty", new FilterCompareExpressionRule<Int32>("ReplMaxQty")) { Width = 170, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Точка норм. пополнения", "PointNorm", new FilterCompareExpressionRule<Int32>("PointNorm")) { Width = 170, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Точка мин. пополнения", "PointMin", new FilterCompareExpressionRule<Int32>("PointMin")) { Width = 170, UseIntegerNumbersAlignment = true });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class FixedLocationsViewSearchParameters : SessionIDSearchParameters
    {
        public string WarehouseID { get; set; }
        public int? ItemID { get; set; }
        public string UnitOfMeasure { get; set; }
    }
}
