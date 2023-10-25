using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Inventory;

namespace WMSOffice.Window
{
    public partial class InventoryScheduleWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public Data.Inventory.InventoriesScheduleRow SelectedInventorySchedule { get { return xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow; } }

        public InventoryScheduleWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void Initialize()
        {
            xdgvInventories.AllowSummary = false;

            xdgvInventories.Init(new InventoryScheduleView(), true);
            xdgvInventories.UserID = this.UserID;

            xdgvInventories.OnDataError += new DataGridViewDataErrorEventHandler(xdgvInventories_OnDataError);
            xdgvInventories.OnRowSelectionChanged += new EventHandler(xdgvInventories_OnRowSelectionChanged);
            xdgvInventories.OnFilterChanged += new EventHandler(xdgvInventories_OnFilterChanged);

            this.SetOperationAccess(true);

            this.ReloadData();
        }


        void xdgvInventories_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvInventories_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess(false);
        }

        private void SetOperationAccess(bool wholeViewAccess)
        {
            if (wholeViewAccess)
            {
                bool hasRows = xdgvInventories.HasRows;
                bool isEnabled = hasRows && xdgvInventories.SelectedItem != null;
                bool canModify = isEnabled && this.SelectedInventorySchedule.can_modif == 1;

                btnModify.Enabled = canModify;
                btnRemove.Enabled = isEnabled;
                btnPlanStations.Enabled = isEnabled;
                btnPlanResources.Enabled = isEnabled;
            }
            else
            {
                bool isEnabled = xdgvInventories.SelectedItem != null;
                bool canModify = isEnabled && this.SelectedInventorySchedule.can_modif == 1;

                btnModify.Enabled = canModify;
                btnRemove.Enabled = isEnabled;
                btnPlanStations.Enabled = isEnabled;
                btnPlanResources.Enabled = isEnabled;
            }
        }

        void xdgvInventories_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvInventories.RecalculateSummary();
            this.SetOperationAccess(true);
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
                var searchParams = new InventoryScheduleSearchParameters() { SessionID = this.UserID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvInventories.DataView.FillData(e.Argument as InventoryScheduleSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvInventories.BindData(false);

                        //this.xdgvInventories.AllowFilter = true;
                        this.xdgvInventories.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение планов инвентаризаций..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.Create))
                return;

            using (var dlgInventoryScheduleEdit = new InventoryScheduleEditForm() { UserID = this.UserID })
            {
                if (dlgInventoryScheduleEdit.ShowDialog() == DialogResult.OK)
                    this.ReloadData();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.Modify))
                return;

            var inventorySchedule = xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow;
            using (var dlgInventoryScheduleEdit = new InventoryScheduleEditForm(inventorySchedule) { UserID = this.UserID })
            {
                if (dlgInventoryScheduleEdit.ShowDialog() == DialogResult.OK)
                    this.ReloadData();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.Remove))
                return;

            if (MessageBox.Show("Вы уверены что хотите удалить план инвентаризации?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                var inventorySchedule = xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow;
                var planID = Convert.ToInt64(inventorySchedule.pln_id);

                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    adapter.Remove(this.UserID, planID);

                this.ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckActionMode(PlanScheduleActionType actionType)
        {
            try
            {
                var inventorySchedule = xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow;
                var planID = Convert.ToInt64(inventorySchedule.pln_id);

                var actionID = (int)actionType;

                var canExecuteFlag = (int?)null;

                using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                    adapter.CheckActionMode(this.UserID, planID, actionID, ref canExecuteFlag);

                var canExecute = Convert.ToBoolean(canExecuteFlag ?? 0);
                if (!canExecute)
                    throw new ActionAccessDeniedException("У Вас недостаточно прав для выполнения указанного действия.");

                return true;
            }
            catch (ActionAccessDeniedException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnPlanStations_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.PlanStations))
                return;

            var inventorySchedule = xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow;
            using (var dlgInventoryScheduleStationsEdit = new InventoryScheduleStationsEditForm(inventorySchedule) { UserID = this.UserID })
            {
                if (dlgInventoryScheduleStationsEdit.ShowDialog() == DialogResult.OK)
                    this.ReloadData();
            }
        }

        private void btnPlanResources_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.PlanResources))
                return;

            var inventorySchedule = xdgvInventories.SelectedItem as Data.Inventory.InventoriesScheduleRow;
            using (var dlgInventoryScheduleResourcesEdit = new InventoryScheduleResourcesEditForm(inventorySchedule) { UserID = this.UserID })
            {
                if (dlgInventoryScheduleResourcesEdit.ShowDialog() == DialogResult.OK)
                    this.ReloadData();
            }
        }

        private void btnCreateVirtual_Click(object sender, EventArgs e)
        {
            if (!this.CheckActionMode(PlanScheduleActionType.CreateVirtual))
                return;

            using (var dlgInventoryVirtualScheduleEdit = new InventoryVirtualScheduleEditForm() { UserID = this.UserID })
            {
                if (dlgInventoryVirtualScheduleEdit.ShowDialog() == DialogResult.OK)
                    this.ReloadData();
            }
        }
    }

    /// <summary>
    /// Представление для плана инвентаризаций
    /// </summary>
    public class InventoryScheduleView : IDataView
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
            var searchCriteria = searchParameters as InventoryScheduleSearchParameters;

            using (var adapter = new Data.InventoryTableAdapters.InventoriesScheduleTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public InventoryScheduleView()
        {
            this.dataColumns.Add(new PatternColumn("ID плана", "pln_id", new FilterCompareExpressionRule<Int32>("pln_id"), SummaryCalculationType.Count) { Width = 80 });
           
            this.dataColumns.Add(new PatternColumn("Код филиала", "filial_code", new FilterPatternExpressionRule("filial_code"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Наименование филиала", "filial_name", new FilterPatternExpressionRule("filial_name")) { Width = 160 });

            this.dataColumns.Add(new PatternColumn("Код статуса", "status_id", new FilterCompareExpressionRule<Int32>("status_id"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Наименование статуса", "status_name", new FilterPatternExpressionRule("status_name")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("Запланированная дата", "plan_date_d", new FilterDateCompareExpressionRule("plan_date_d")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Тип инвентаризации", "fi_type_name", new FilterPatternExpressionRule("fi_type_name")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("План подготовлен", "user_created", new FilterPatternExpressionRule("user_created")) { Width = 200 });

            this.dataColumns.Add(new PatternColumn("№ инвентаризации", "inventory_number", new FilterCompareExpressionRule<Int32>("inventory_number")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("Описание", "pln_dsc", new FilterPatternExpressionRule("pln_dsc")) { Width = 200 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class InventoryScheduleSearchParameters : SessionIDSearchParameters
    {
        
    }

    /// <summary>
    /// Отсутствие доступа к выполнению действия
    /// </summary>
    public class ActionAccessDeniedException : Exception
    {
        public ActionAccessDeniedException(string message)
            : base(message)
        {

        }
    }

    public enum PlanScheduleActionType
    { 
        /// <summary>
        /// Создание
        /// </summary>
        Create = 0,
        /// <summary>
        /// Редактирование
        /// </summary>
        Modify = 1,
        /// <summary>
        /// Удаление
        /// </summary>
        Remove = 2,
        /// <summary>
        /// Планирование станций
        /// </summary>
        PlanStations = 3,
        /// <summary>
        /// Планирование ресурсов
        /// </summary>
        PlanResources = 4,
        /// <summary>
        /// Создание виртуальной
        /// </summary>
        CreateVirtual = 5
    }
}
