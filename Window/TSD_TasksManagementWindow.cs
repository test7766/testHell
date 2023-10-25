using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;
using WMSOffice.Dialogs.WH.TSD;

namespace WMSOffice.Window
{
    /// <summary>
    /// Менеджер заданий ТСД
    /// </summary>
    public partial class TSD_TasksManagementWindow : GeneralWindow
    {
        /// <summary>
        /// Индикатор выполнения длительной операции
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public TSD_TasksManagementWindow()
        {
            InitializeComponent();
            this.xdgvTasks.AllowSummary = false;
            this.xdgvTasks.AllowRangeColumns = true;

            this.xdgvTasks.Init(new TSD_TasksView(), true);
            this.xdgvTasks.LoadExtraDataGridViewSettings(this.Name);
        }
        #endregion

        private void TSD_TasksManagementWindow_Load(object sender, EventArgs e)
        {
            this.xdgvTasks.UserID = this.UserID;
            this.xdgvTasks.OnFilterChanged += new EventHandler(xdgvTasks_OnFilterChanged);
            this.xdgvTasks.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvTasks_OnFormattingCell);

            this.CheckPrintersAccess();
            this.CheckAltLiftTasksAccess();

            // активация постраничного просмотра
            this.xdgvTasks.CreatePageNavigator();
        }

        /// <summary>
        /// Настройка доступа к кнопке "Проверка активности принтеров"
        /// </summary>
        private void CheckPrintersAccess()
        {
            try
            {
                var accessflag = (bool?)null;
                using (var adapter = new Data.TSDTableAdapters.CheckedPrintersTableAdapter())
                    adapter.CheckAccess(this.UserID, ref accessflag);

                if (!(accessflag ?? false))
                    sbCheckPrinters.Visible = tssCheckPrinters.Visible = false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        /// <summary>
        /// Настройка доступа к кнопке "Проверка альтернативного лифтового задания"
        /// </summary>
        [Obsolete]
        private void CheckAltLiftTasksAccess()
        {
            return;

            //try
            //{
            //    var accessflag = (bool?)null;
            //    using (var adapter = new Data.TSDTableAdapters.QueriesTableAdapter())
            //        adapter.CheckAltLiftTasksAccess(this.UserID, ref accessflag);

            //    if (!(accessflag ?? false))
            //        sbCheckAltLiftTasks.Visible = tssCheckAltLiftTasks.Visible = false;
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError(ex);
            //}
        }


        void xdgvTasks_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvTasks.RecalculateSummary();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.RefreshData();
        }

        private void sbRefresh_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        #region ФОНОВОЕ ОБНОВЛЕНИЕ СПИСКА ЗАДАНИЙ
        private void RefreshData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Выполняется загрузка заданий..";

            var searchCriteria = new TSD_TasksSearchParameters();
            searchCriteria.UserID = this.UserID;

            loadWorker.RunWorkerAsync(searchCriteria);
            waitProcessForm.ShowDialog();
        }

        void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                this.xdgvTasks.DataView.FillData(e.Argument as TSD_TasksSearchParameters);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);
            else
            {
                this.xdgvTasks.BindData(false);
                this.xdgvTasks.AllowSummary = true;
            }

            waitProcessForm.CloseForce();
        }
        #endregion

        #region ОПЕРАЦИИ НАД ТСД
        /// <summary>
        /// Создание задания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateTask_Click(object sender, EventArgs e)
        {
            var dlgTSD_CreateTask = new TSD_CreateTaskForm() { UserID = this.UserID, UseBoxPickMode = true };
            if (dlgTSD_CreateTask.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    MessageBox.Show("Задание было успешно создано.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RefreshData();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            }
        }

        /// <summary>
        /// Назначение задания
        /// </summary>
        private void sbAssignTask_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = this.xdgvTasks.SelectedItem;
            if (selectedRow == null)
            {
                MessageBox.Show("Для выполнения операции выберите строку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long? doc_id = selectedRow["doc_id"] == DBNull.Value ? (long?)null : Convert.ToInt64(selectedRow["doc_id"]);
            string doc_type_id = selectedRow["doc_type_id"].ToString();
            string warehouse_id = selectedRow["warehouse_id"].ToString();
            string locn_from = selectedRow["locn_from"].ToString();
            string locn_to = selectedRow["locn_to"].ToString();
            bool? can_be_assigned = selectedRow["can_be_assigned"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(selectedRow["can_be_assigned"]);

            if (!can_be_assigned.HasValue || !can_be_assigned.Value)
            {
                MessageBox.Show(string.Format("Задание № {0} не может быть назначено на терминал в связи с тем, что для данного типа задания такая возможность не предусмотрена.", doc_id), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var dlgTSD_Selector = new TSD_Selector() 
            { 
                UserID = this.UserID,
                DocID = doc_id,
                DocTypeID = doc_type_id,
                WarehouseID = warehouse_id,
                LocationFrom = locn_from,
                LocationTo = locn_to
            };

            if (dlgTSD_Selector.ShowDialog() == DialogResult.OK)
            {
                string terminal_id = dlgTSD_Selector.SelectedTerminalID;

                SqlTransaction assignTransaction = null;
                SqlConnection assignConnection = null;
                try
                {
                    using (Data.TSDTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.TSDTableAdapters.QueriesTableAdapter())
                    {
                        (assignConnection = adapter.AssignTaskCommand.Connection).Open();
                        assignTransaction = adapter.AssignTaskCommand.Connection.BeginTransaction();
                        adapter.AssignTaskCommand.Transaction = assignTransaction;

                        adapter.AssignTask(this.UserID, terminal_id, doc_id, doc_type_id, can_be_assigned);
                        assignTransaction.Commit();
                    }

                    MessageBox.Show("Задание было успешно назначено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.RefreshData();
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                    assignTransaction.Rollback();
                }
                finally
                {
                    if (assignConnection != null && assignConnection.State == ConnectionState.Open)
                        assignConnection.Close();
                }
            }
        }

        /// <summary>
        /// Отмена задания
        /// </summary>
        private void sbCancelTask_Click(object sender, EventArgs e)
        {
            DataRow selectedRow = this.xdgvTasks.SelectedItem;
            if (selectedRow == null)
            {
                MessageBox.Show("Для выполнения операции выберите строку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string terminal_id = selectedRow["terminal_id"].ToString();
            long? doc_id = selectedRow["doc_id"] == DBNull.Value ? (long?)null : Convert.ToInt64(selectedRow["doc_id"]);
            string doc_type_id = selectedRow["doc_type_id"].ToString();
            long? so_doc_id = selectedRow["so_doc_id"] == DBNull.Value ? (long?)null : Convert.ToInt64(selectedRow["so_doc_id"]);
            int? execution_status_id = selectedRow["execution_status_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow["execution_status_id"]);
            bool? can_be_canceled = selectedRow["can_be_canceled"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(selectedRow["can_be_canceled"]);

            SqlTransaction cancelTransaction = null;
            SqlConnection cancelConnection = null;
            try
            {
                using (Data.TSDTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.TSDTableAdapters.QueriesTableAdapter())
                {
                    (cancelConnection = adapter.CancelTaskCommand.Connection).Open();
                    cancelTransaction = adapter.CancelTaskCommand.Connection.BeginTransaction();
                    adapter.CancelTaskCommand.Transaction = cancelTransaction;

                    adapter.CancelTask(this.UserID, terminal_id, doc_id, doc_type_id, so_doc_id, execution_status_id, can_be_canceled);
                    cancelTransaction.Commit();
                }

                MessageBox.Show("Задание было успешно отменено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.RefreshData();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                cancelTransaction.Rollback();
            }
            finally
            {
                if (cancelConnection != null && cancelConnection.State == ConnectionState.Open)
                    cancelConnection.Close();
            }
        }

        #region ФОНОВАЯ ОПЕРАЦИЯ УДАЛЕНИЯ ЗАДАНИЯ
        /// <summary>
        /// Удаление задания
        /// </summary>
        private void sbDeleteTask_Click(object sender, EventArgs e)
        {

            DataRow selectedRow = this.xdgvTasks.SelectedItem;
            if (selectedRow == null)
            {
                MessageBox.Show("Для выполнения операции выберите строку.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long? doc_id = selectedRow["doc_id"] == DBNull.Value ? (long?)null : Convert.ToInt64(selectedRow["doc_id"]);
            string doc_type_id = selectedRow["doc_type_id"].ToString();
            string status_id = selectedRow["status_id"].ToString();
            string warehouse_id = selectedRow["warehouse_id"].ToString();
            string locn_from = selectedRow["locn_from"].ToString();
            string locn_to = selectedRow["locn_to"].ToString();
            int? item_id = selectedRow["item_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(selectedRow["item_id"]);
            string batch_number = selectedRow["batch_number"].ToString();
            bool? can_be_deleted = selectedRow["can_be_deleted"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(selectedRow["can_be_deleted"]);

            DeleteWorkerParameters deleteParameters = new DeleteWorkerParameters();
            deleteParameters.DocID = doc_id;
            deleteParameters.DocTypeID = doc_type_id;
            deleteParameters.StatusID = status_id;
            deleteParameters.WarehouseID = warehouse_id;
            deleteParameters.LocnFrom = locn_from;
            deleteParameters.LocnTo = locn_to;
            deleteParameters.ItemID = item_id;
            deleteParameters.BatchNumber = batch_number;
            deleteParameters.CanBeDeleted = can_be_deleted;

            BackgroundWorker deleteWorker = new BackgroundWorker();
            deleteWorker.DoWork += new DoWorkEventHandler(deleteWorker_DoWork);
            deleteWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(deleteWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Выполняется удаление задания..";
            DeleteWorkerParameters.OperationPerformedSuccessfully = false;
            deleteWorker.RunWorkerAsync(deleteParameters);
            waitProcessForm.ShowDialog();

            // При успешном завершении операции обновляем данные
            if (DeleteWorkerParameters.OperationPerformedSuccessfully)
            {
                MessageBox.Show("Задание было успешно удалено.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.RefreshData();
            }
        }

        void deleteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SqlTransaction deleteTransaction = null;
            SqlConnection deleteConnection = null;

            try
            {
                using (Data.TSDTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.TSDTableAdapters.QueriesTableAdapter())
                {
                    (deleteConnection = adapter.DeleteTaskCommand.Connection).Open();
                    deleteTransaction = adapter.DeleteTaskCommand.Connection.BeginTransaction();
                    adapter.DeleteTaskCommand.Transaction = deleteTransaction;

                    DeleteWorkerParameters deleteParameters = e.Argument as DeleteWorkerParameters;
                    adapter.DeleteTask(this.UserID, deleteParameters.DocID, deleteParameters.DocTypeID, deleteParameters.StatusID,
                                       deleteParameters.WarehouseID, deleteParameters.LocnFrom, deleteParameters.LocnTo, deleteParameters.ItemID,
                                       deleteParameters.BatchNumber, deleteParameters.CanBeDeleted);
                    deleteTransaction.Commit();
                }
            }
            catch (Exception ex)
            {
                deleteTransaction.Rollback();
                e.Result = ex;
            }
            finally
            {
                if (deleteConnection != null && deleteConnection.State == ConnectionState.Open)
                    deleteConnection.Close();
            }
        }

        void deleteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                this.ShowError(e.Result as Exception);
            else
                DeleteWorkerParameters.OperationPerformedSuccessfully = true;

            waitProcessForm.CloseForce();
        }
        #endregion
        /// <summary>
        /// Параметры для фонового удаления задания
        /// </summary>
        private class DeleteWorkerParameters
        {
            public long? DocID { get; set; }
            public string DocTypeID { get; set; }
            public string StatusID { get; set; }
            public string WarehouseID { get; set; }
            public string LocnFrom { get; set; }
            public string LocnTo { get; set; }
            public int? ItemID { get; set; }
            public string BatchNumber { get; set; }
            public bool? CanBeDeleted { get; set; }

            /// <summary>
            /// Признак успешного завершения фоновой операции
            /// </summary>
            public static bool OperationPerformedSuccessfully { get; set; }
        }
        #endregion

        void xdgvTasks_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;

            #region ИНДИКАЦИЯ ГРУППЫ "ТОВАР"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "item_name" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "item_qty" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "box_qty" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "item_uom" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "lot_number" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "batch_number" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "bar_code")
            {
                e.CellStyle.BackColor = Color.FromArgb(255, 255, 153);
                //e.CellStyle.SelectionBackColor = Color.FromArgb(255, 255, 153);
                e.CellStyle.SelectionForeColor = Color.FromArgb(255, 255, 153);// Color.Black;
                return;
            }
            #endregion

            #region ИНДИКАЦИЯ ГРУППЫ "ИСПОЛНИТЕЛЬ"
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "terminal_id" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "employee_id" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "employee_name")
            {
                e.CellStyle.BackColor = Color.FromArgb(209, 255, 117);
                //e.CellStyle.SelectionBackColor = Color.FromArgb(209, 255, 117);
                e.CellStyle.SelectionForeColor = Color.FromArgb(209, 255, 117);  //Color.Black;
                return;
            }
            #endregion
        }

        private void TSD_TasksManagementWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvTasks.SaveExtraDataGridViewSettings(this.Name);
        }

        private void sbCheckPrinters_Click(object sender, EventArgs e)
        {
            var dlgTSD_CheckPrinters = new TSD_CheckPrintersForm() { UserID = this.UserID };
            dlgTSD_CheckPrinters.ShowDialog(this);
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            try
            {
                xdgvTasks.ExportToExcel("Экспорт реестра заданий ТСД в Excel", "реестр заданий ТСД", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        [Obsolete]
        private void sbCheckAltLiftTasks_Click(object sender, EventArgs e)
        {
            return;

            //try
            //{
            //    var dlgTSD_AltLiftTasksChange = new TSD_AltLiftTasksChangeForm() { UserID = this.UserID };
            //    dlgTSD_AltLiftTasksChange.ShowDialog();
            //    return;

            //    #region OBSOLETE

            //    //var activateFlag = (int?)null;
            //    //var terminateFlag = false;

            //    //while (true)
            //    //{
            //    //    using (var adapter = new Data.TSDTableAdapters.QueriesTableAdapter())
            //    //        adapter.ActivateAltLiftTasks(activateFlag, this.UserID, ref activateFlag);

            //    //    var activateStatus = string.Empty;
            //    //    switch (activateFlag)
            //    //    {
            //    //        case 1:
            //    //            activateStatus = "АКТИВНО";
            //    //            break;
            //    //        case 0:
            //    //            activateStatus = "ОТКЛЮЧЕНО";
            //    //            break;
            //    //        default:
            //    //            activateStatus = "Н/Д";
            //    //            break;
            //    //    }

            //    //    if (terminateFlag)
            //    //    {
            //    //        MessageBox.Show(string.Format("Статус задания после изменения:\r\n{0}", activateStatus), "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    //        return;
            //    //    }

            //    //    MessageBoxManager.Yes = "&Включить";
            //    //    MessageBoxManager.No = "&Отключить";
            //    //    MessageBoxManager.Cancel = "&Отмена";
            //    //    MessageBoxManager.Register();

            //    //    var msgResult = MessageBox.Show(string.Format("Статус задания:\r\n{0}", activateStatus), "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);
            //    //    switch (msgResult)
            //    //    {
            //    //        case DialogResult.Yes:
            //    //            activateFlag = 1;
            //    //            break;
            //    //        case DialogResult.No:
            //    //            activateFlag = 0;
            //    //            break;
            //    //        case DialogResult.Cancel:
            //    //        default:
            //    //            activateFlag = (int?)null;
            //    //            break;
            //    //    }

            //    //    MessageBoxManager.Unregister();

            //    //    if (activateFlag.HasValue)
            //    //        terminateFlag = true;
            //    //    else
            //    //        return;
            //    //}

            //    #endregion
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError(ex);
            //}
        }
    }

    /// <summary>
    /// Представление для списка заданий ТСД
    /// </summary>
    public class TSD_TasksView : IDataView
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as TSD_TasksSearchParameters;

            string query = string.Format("EXEC [dbo].[pr_so_WM_manage_select_tasks] {0}",
                  searchCriteria.UserID);

            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        public TSD_TasksView()
        {
            this.dataColumns.Add(new PatternColumn("№ документа", "doc_id", new FilterCompareExpressionRule<Int64>("doc_id"), SummaryCalculationType.Count){ Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип документа", "doc_type_id", new FilterPatternExpressionRule("doc_type_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип операции", "doc_type_name", new FilterPatternExpressionRule("doc_type_name")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Дата создания", "date_creation", new FilterDateCompareExpressionRule("date_creation")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Код статуса", "status_id", new FilterPatternExpressionRule("status_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус", "status_name", new FilterPatternExpressionRule("status_name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Внешний документ", "related_doc_id", new FilterCompareExpressionRule<Int64>("related_doc_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Полка \"С\"", "locn_from", new FilterPatternExpressionRule("locn_from")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Полка \"НА\"", "locn_to", new FilterPatternExpressionRule("locn_to")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Код товара", "item_id", new FilterCompareExpressionRule<Int32>("item_id"), SummaryCalculationType.TotalRecords){ Width = 100 });
            this.dataColumns.Add(new PatternColumn("Наименование", "item_name", new FilterPatternExpressionRule("item_name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Количество", "item_qty", new FilterCompareExpressionRule<Int32>("item_qty")) { UseIntegerNumbersAlignment = true, Width = 100 });//, UseIntegerNumbersAlignement = true });
            this.dataColumns.Add(new PatternColumn("Ящиков", "box_qty", new FilterCompareExpressionRule<Int32>("box_qty"), SummaryCalculationType.Sum) { UseIntegerNumbersAlignment = true, Width = 100 });//, UseIntegerNumbersAlignement = true });
            this.dataColumns.Add(new PatternColumn("Ед. изм.", "item_uom", new FilterPatternExpressionRule("item_uom")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Серия", "lot_number", new FilterPatternExpressionRule("lot_number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Партия", "batch_number", new FilterPatternExpressionRule("batch_number")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Штрих-код", "bar_code", new FilterPatternExpressionRule("bar_code")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Дата назначения", "date_assignment", new FilterDateCompareExpressionRule("date_assignment")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата выполнения", "date_execution", new FilterDateCompareExpressionRule("date_execution")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Статус выполнения", "execution_status", new FilterPatternExpressionRule("execution_status")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("ТСД", "terminal_id", new FilterPatternExpressionRule("terminal_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Код сотрудника", "employee_id", new FilterCompareExpressionRule<Int32>("employee_id")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Ф.И.О. сотрудника", "employee_name", new FilterPatternExpressionRule("employee_name")) { Width = 100 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class TSD_TasksSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
    }
}
