using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.WHTableAdapters;
using WMSOffice.Dialogs.WH;
using CrystalDecisions.CrystalReports.Engine;
using WMSOffice.Reports;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Window
{
    public partial class WHOperationsWindow : GeneralWindow
    {
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();
        private Data.WH.OperationActionsDataTable actions = new WMSOffice.Data.WH.OperationActionsDataTable();

        //private Data.WH.OperationsDocsRow SelectedDoc
        //{
        //    get
        //    {
        //        if (dgvMainDocGrid.SelectedRows.Count == 0)
        //            return null;
        //        else
        //            return (Data.WH.OperationsDocsRow)((DataRowView)dgvMainDocGrid.SelectedRows[0].DataBoundItem).Row;
        //    }
        //}

        public WHOperationsWindow()
        {
            InitializeComponent();
            InitializePrinters();

            this.xdgvMainDocGrid.AllowSummary = false;
            this.xdgvMainDocGrid.Init(new OperationsView(), true);
        }

        private void InitializePrinters()
        {
            foreach (string printerName in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                cmbPrinters.Items.Add(printerName);

            System.Drawing.Printing.PrinterSettings tmpSettings = new System.Drawing.Printing.PrinterSettings();
            cmbPrinters.SelectedItem = tmpSettings.PrinterName;
        }

        private void WHOperationsWindow_Load(object sender, EventArgs e)
        {
            WHCache.UserID = this.UserID;

            this.LoadActions();
            this.LoadWarehouses();
            //this.operationsDocsBindingSource.CurrentItemChanged += new EventHandler(operationsDocsBindingSource_CurrentItemChanged); 
        }


        /// <summary>
        /// Загрузка справочника действий
        /// </summary>
        private void LoadActions()
        {
            try
            {
                using (Data.WHTableAdapters.OperationActionsTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.OperationActionsTableAdapter())
                    adapter.Fill(this.actions);

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника действий", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Заполнение справочника складов
        /// </summary>
        private void LoadWarehouses()
        {
            try
            {
                this.wH.OperationWarehouses.Clear();
                this.wH.OperationWarehouses.Merge(WHCache.Warehouses);
                //this.operationWarehousesTableAdapter.Fill(this.wH.OperationWarehouses, this.UserID);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Ошибка загрузки справочника складов", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void operationsDocsBindingSource_CurrentItemChanged(object sender, EventArgs e)
        //{
        //    //if (this.IsDocumentsExists() && this.SelectedDoc != null)
        //    //{
        //    //    this.SetDocActions();
        //    //    this.SetPrintDocAccessebilityOptions();
        //    //}
        //    //else
        //    //    sbDocActions.Enabled = false;
        //}

        //private bool IsDocumentsExists()
        //{
        //    return this.operationsDocsBindingSource.CurrencyManager.Count > 0;
        //}

        /// <summary>
        /// Установка доступности действий для текущей операции
        /// </summary>
        private void SetDocActions()
        {
            sbDocActions.Enabled = true;
            foreach (ToolStripItem item in sbDocActions.DropDownItems)
                if (item.Tag != null)
                {
                    item.Enabled = false;
                    foreach (Data.WH.OperationActionsRow action in this.GetActionProperties(item.Tag))
                        item.Enabled = true;
                }
        }

        private Data.WH.OperationActionsRow[] GetActionProperties(object actionID)
        {
            string subDocType = this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString();
            string status_id = this.xdgvMainDocGrid.SelectedItem["Status_ID"].ToString();

            return this.actions.Select(string.Format("{0} = {1} AND {2} = '{3}' AND {4} = {5}",
                            this.actions.ButtonIDColumn.Caption, actionID,
                            this.actions.SubType_IDColumn, /*this.SelectedDoc.SubDocType*/ subDocType,
                            this.actions.Status_ID_FromColumn.Caption, /*this.SelectedDoc.Status_ID*/ status_id)) as Data.WH.OperationActionsRow[];
        }

        /// <summary>
        /// Обработчик события выбора действия для текущей операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sbExecuteAction_Click(object sender, EventArgs e)
        {
            long doc_id = Convert.ToInt64(this.xdgvMainDocGrid.SelectedItem["Doc_ID"]);

            foreach (Data.WH.OperationActionsRow action in this.GetActionProperties((sender as ToolStripDropDownItem).Tag))
                using (ExecuteActionForm updateStatusForm = new ExecuteActionForm() { UserID = this.UserID, DocID = /*this.SelectedDoc.Doc_ID*/doc_id, NewStatusID = action.Status_ID_To })
                    if ((!action.UseBarCode && updateStatusForm.ExecuteOperation()) ||
                        (action.UseBarCode && updateStatusForm.ShowDialog() == DialogResult.OK))
                        this.RefreshDocs();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            sbDocActions.Enabled = false;
            sbPrintDoc.Enabled = false;

            this.xdgvMainDocGrid.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvMainDocGrid_OnRowDoubleClick);
            this.xdgvMainDocGrid.OnRowSelectionChanged += new EventHandler(xdgvMainDocGrid_OnRowSelectionChanged);

            // активация постраничного просмотра
            this.xdgvMainDocGrid.CreatePageNavigator();

            //this.RefreshDocs(); // При запуске формы получение документов изначально не вызывается, а появляется окно поиска
            CheckUserLimitations();
            this.LoadDocumentsViaFilter();
        }

        #region Проверка ограничений пользователя

        private void CheckUserLimitations()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorkerCheck_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            waitProcessForm.ActionText = "Проверяются ваши ограничения по полкам склада...";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

        }

        void loadWorkerCheck_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                waitProcessForm.CloseForce();
            }
            catch (Exception)
            {

            }
        }

        void loadWorkerCheck_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                GetLocationAccessTableAdapter adapter = new GetLocationAccessTableAdapter();
                adapter.GetData(UserID);
            }
            catch (Exception)
            {

            }
        }

        #endregion

        void xdgvMainDocGrid_OnRowSelectionChanged(object sender, EventArgs e)
        {
            if (this.xdgvMainDocGrid.SelectedItem != null)
            {
                this.SetDocActions();
                this.SetPrintDocAccessebilityOptions();
            }
            else
                sbDocActions.Enabled = false;
        }

        void xdgvMainDocGrid_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvMainDocGrid.SelectedItem != null)
            {
                string subDocType = xdgvMainDocGrid.SelectedItem["SubDocType"].ToString();
                string subDocTypeName = xdgvMainDocGrid.SelectedItem["SubDocTypeName"].ToString();
                long doc_id = Convert.ToInt64(xdgvMainDocGrid.SelectedItem["Doc_ID"]);
                bool can_modified = Convert.ToBoolean(xdgvMainDocGrid.SelectedItem["CanModified"]);

                this.OpenOperationDetails(OperationBuildState.Modify, subDocType, subDocTypeName, doc_id, can_modified);
            }
        }

        private void sbRefreshDocs_Click(object sender, EventArgs e)
        {
            this.RefreshDocs();
        }

        #region ФОНОВОЕ ОБНОВЛЕНИЕ СПИСКА ДОКУМЕНТОВ
        /// <summary>
        /// Обновление списка документов
        /// </summary>
        private void RefreshDocs()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += new DoWorkEventHandler(loadWorker_DoWork);
            loadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(loadWorker_RunWorkerCompleted);
            //this.operationsDocsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Загрузка списка документов...";

            OperationsSearchParameters searchCriteria = new OperationsSearchParameters()
            {
                UserID = this.UserID,
                SubDocType = OperationFindForm.SubDocType,
                DateFrom = OperationFindForm.DateFrom,
                DateTo = OperationFindForm.DateTo,
                StatusID = OperationFindForm.StatusID,
                WarehouseID = OperationFindForm.WarehouseID,
                JDDocID = OperationFindForm.JDDocID,
                JDDocType = OperationFindForm.JDDocType,
                BatchNumber = OperationFindForm.BatchNumber,
                TSDDocID = OperationFindForm.TSDDocID,
                TSDDocType = OperationFindForm.TSDDocType,
                IsVirtual = OperationFindForm.IsVirtual,
                EmployeeID = OperationFindForm.EmployeeID,
                Description = OperationFindForm.Description,
                CloseOperations = OperationFindForm.CloseOperations
            };

            loadWorker.RunWorkerAsync(searchCriteria);
            waitProcessForm.ShowDialog();
        }

        private void loadWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                //e.Result = this.operationsDocsTableAdapter.GetData(this.UserID, OperationFindForm.SubDocType, OperationFindForm.DateFrom, OperationFindForm.DateTo,
                //    OperationFindForm.StatusID, OperationFindForm.WarehouseID, OperationFindForm.JDDocID, OperationFindForm.JDDocType,
                //    OperationFindForm.BatchNumber, OperationFindForm.TSDDocID, OperationFindForm.TSDDocType, OperationFindForm.IsVirtual,
                //    OperationFindForm.EmployeeID, OperationFindForm.Description, OperationFindForm.CloseOperations);

                this.xdgvMainDocGrid.DataView.FillData(e.Argument as OperationsSearchParameters);
            }
            catch (Exception error)
            {
                e.Result = error;
            }
        }

        private void loadWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                this.ShowError(e.Result as Exception);
                //this.wH.OperationsDocs.Clear();
            }
            else
            {
                //this.operationsDocsBindingSource.DataSource = e.Result;

                this.xdgvMainDocGrid.BindData(false);
                this.xdgvMainDocGrid.AllowSummary = false;
            }

            waitProcessForm.CloseForce();
        }
        #endregion

        private void sbCreateOperation_Click(object sender, EventArgs e)
        {
            using (var newOperation = new ChoiseOperationForm() { UserID = this.UserID })
                if (newOperation.ShowDialog() == DialogResult.OK)
                    this.OpenOperationDetails(OperationBuildState.New, newOperation.OperationTypeCode, newOperation.OperationTypeName, null, true);
        }

        /// <summary>
        /// Открытие существующей операции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvMainDocGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //    this.OpenOperationDetails(OperationBuildState.Modify, this.SelectedDoc.SubDocType, this.SelectedDoc.SubDocTypeName, this.SelectedDoc.Doc_ID, this.SelectedDoc.CanModified);
        }

        /// <summary>
        /// Открыть детали операции
        /// </summary>
        private void OpenOperationDetails(OperationBuildState operationBuildState, string operationTypeCode, string operationTypeName, long? docID, bool canModify)
        {
            using (var operationEditor = new OperationEditorForm(operationBuildState) 
            {
                UserID = this.UserID,
                OperationTypeID = operationTypeCode,
                OperationTypeName = operationTypeName,
                DocID = docID,
                CanModify = canModify
            })
                if (operationEditor.ShowDialog() == DialogResult.OK)
                    this.RefreshDocs();
        }

        #region ПЕЧАТЬ ДОКУМЕНТОВ
        private void sbMovementOrderReport_Click(object sender, EventArgs e)
        {
            try
            {
                long doc_id = Convert.ToInt64(this.xdgvMainDocGrid.SelectedItem["Doc_ID"]);
                using (Data.WHTableAdapters.MovementReportTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.MovementReportTableAdapter())
                    adapter.Fill(this.wH.MovementReport, this.UserID, /*this.SelectedDoc.Doc_ID*/doc_id);

                if (this.wH.MovementReport.Rows.Count > 0)
                {
                    var reportRow = this.wH.MovementReport[0];
                    reportRow.BarCodeImage = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(reportRow.BarCode.Trim());

                    using (WHMovementReport report = new WHMovementReport())
                        this.PrintDocument(report, null);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка печати документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbRegradingGoodsNoteReport_Click(object sender, EventArgs e)
        {
            try
            {
                long doc_id = Convert.ToInt64(this.xdgvMainDocGrid.SelectedItem["Doc_ID"]);
                using (Data.WHTableAdapters.RegradingGoodsNoteReportTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.RegradingGoodsNoteReportTableAdapter())
                    adapter.Fill(this.wH.RegradingGoodsNoteReport, this.UserID, /*this.SelectedDoc.Doc_ID*/ doc_id);

                if (this.wH.RegradingGoodsNoteReport.Rows.Count > 0)
                {
                    var reportRow = this.wH.RegradingGoodsNoteReport[0];
                    reportRow.BarCodeImage = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(reportRow.BarCode.Trim());

                    using (WHRegradingGoodsNoteReport report = new WHRegradingGoodsNoteReport())
                        this.PrintDocument(report, null);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка печати документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbRegradingGoodsReceiptActReport_Click(object sender, EventArgs e)
        {
            try
            {
                long doc_id = Convert.ToInt64(this.xdgvMainDocGrid.SelectedItem["Doc_ID"]);
                using (Data.WHTableAdapters.RegradingGoodsReceiptReportTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.RegradingGoodsReceiptReportTableAdapter())
                    adapter.Fill(this.wH.RegradingGoodsReceiptReport, this.UserID, /*this.SelectedDoc.Doc_ID*/doc_id);

                if (this.wH.RegradingGoodsReceiptReport.Rows.Count > 0)
                {
                    var reportRow = this.wH.RegradingGoodsReceiptReport[0];
                    reportRow.BarCodeImage = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(reportRow.BarCode.Trim());

                    using (Data.WHTableAdapters.RegradingGoodsReceiptReportRowsTableAdapter adapterRows = new WMSOffice.Data.WHTableAdapters.RegradingGoodsReceiptReportRowsTableAdapter())
                        adapterRows.Fill(this.wH.RegradingGoodsReceiptReportRows, this.UserID, /*this.SelectedDoc.Doc_ID*/doc_id);

                    using (RegradingGoodsReceiptReport report = new RegradingGoodsReceiptReport())
                        this.PrintDocument(report, null);
                }
            }
            catch
            {
                MessageBox.Show("Произошла ошибка печати документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sbWriteOffReport_Click(object sender, EventArgs e)
        {
            try
            {
                long doc_id = Convert.ToInt64(this.xdgvMainDocGrid.SelectedItem["Doc_ID"]);
                using (SubscribersForm sf = new SubscribersForm() { UserID = this.UserID })
                    if (sf.ShowDialog() == DialogResult.OK)
                    {

                        using (Data.WHTableAdapters.WriteOffActReportTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.WriteOffActReportTableAdapter())
                            adapter.Fill(this.wH.WriteOffActReport, this.UserID, /*this.SelectedDoc.Doc_ID*/doc_id);

                        if (this.wH.WriteOffActReport.Rows.Count > 0)
                        {
                            var reportRow = this.wH.WriteOffActReport[0];
                            reportRow.BarCodeImage = Dialogs.Complaints.BarCodeGenerator.GetBarcodeCODE39(reportRow.BarCode.Trim());


                            var lastReportRow = this.wH.WriteOffActReport[this.wH.WriteOffActReport.Count - 1];
                            lastReportRow.Sign1 = sf.Sign1;
                            lastReportRow.Sign2 = sf.Sign2;
                            lastReportRow.Sign3 = sf.Sign3;
                            lastReportRow.Sign4 = sf.Sign4;
                            lastReportRow.Sign5 = sf.Sign5;
                            lastReportRow.Sign6 = sf.Sign6;
                            lastReportRow.Sign7 = sf.Sign7;

                            using (WHWriteOffActReport report = new WHWriteOffActReport())
                                this.PrintDocument(report, sf.GetSubscribersCaption());
                        }
                    }
                    else
                        MessageBox.Show("Печать была Вами отменена.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка печати документа", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Печать документа на выбранный принтер
        /// </summary>
        /// <param name="report"></param>
        private void PrintDocument(ReportDocument report, string reportParameter)
        {
            report.SetDataSource(this.wH);

            if (reportParameter != null)
                report.SetParameterValue("ComissionCaption", reportParameter);

            report.PrintOptions.PrinterName = cmbPrinters.SelectedItem.ToString();
            report.PrintToPrinter(1, true, 1, 0);
        }
        #endregion

        #region Логическое определение типа текущей операции
        /// <summary>
        /// Определения того, является ли текущая операция пересортом серии?
        /// </summary>
        /// <returns></returns>
        private bool IsRegradingOfLotsOperation()
        {
            //return (this.SelectedDoc.SubDocType == "I");
            return (this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString() == "I");
        }

        /// <summary>
        /// Определения того, является ли текущая операция пересортом товаров?
        /// </summary>
        /// <returns></returns>
        private bool IsRegradingOfGoodsOperation()
        {
            //return (this.SelectedDoc.SubDocType == "P");
            return (this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString() == "P");
        }

        /// <summary>
        /// Определения того, является ли текущая операция перемещением?
        /// </summary>
        /// <returns></returns>
        private bool IsMovementOperation()
        {
            //return (this.SelectedDoc.SubDocType == "M");
            return (this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString() == "M");
        }

        /// <summary>
        /// Определения того, является ли текущая операция виртуальным перемещением?
        /// </summary>
        /// <returns></returns>
        private bool IsVirtualMovementOperation()
        {
            //return (this.SelectedDoc.SubDocType == "M");
            return (this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString() == "V");
        }

        /// <summary>
        /// Определения того, является ли текущая операция списанием?
        /// </summary>
        /// <returns></returns>
        private bool IsWriteOffOperation()
        {
            //return (this.SelectedDoc.SubDocType == "S");
            return (this.xdgvMainDocGrid.SelectedItem["SubDocType"].ToString() == "S");
        }
        #endregion

        /// <summary>
        /// Установка доступности документов для печати
        /// </summary>
        private void SetPrintDocAccessebilityOptions()
        {
            string status_id = this.xdgvMainDocGrid.SelectedItem["Status_ID"].ToString();

            sbPrintDoc.Enabled = true;

            sbMovementOrderReport.Enabled = false;
            sbRegradingGoodsNoteReport.Enabled = false;
            sbWriteOffReport.Enabled = false;
            sbRegradingGoodsReceiptActReport.Enabled = false;

            if (this.IsMovementOperation() || this.IsVirtualMovementOperation())
                sbMovementOrderReport.Enabled = true;

            if (this.IsRegradingOfGoodsOperation())
                sbRegradingGoodsReceiptActReport.Enabled =
                    sbRegradingGoodsNoteReport.Enabled = 
                    (/*this.SelectedDoc.Status_ID*/status_id == "130");

            if (this.IsWriteOffOperation())
                sbWriteOffReport.Enabled = (/*this.SelectedDoc.Status_ID*/status_id == "100");
        }

        private void sbFindDocuments_Click(object sender, EventArgs e)
        {
            this.LoadDocumentsViaFilter();
        }

        /// <summary>
        /// Поиск документов через фильтрацию по критериям
        /// </summary>
        private void LoadDocumentsViaFilter()
        {
            using (OperationFindForm frmFindDoc = new OperationFindForm() { UserID = this.UserID })
                if (frmFindDoc.ShowDialog() == DialogResult.OK)
                    this.RefreshDocs();
        }
    }

    public class OperationsView : IDataView
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
            var searchCriteria = searchParameters as OperationsSearchParameters;

            SqlDataAdapter adapter = new SqlDataAdapter("[dbo].[pr_WW_GetDocs]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Session_ID", SqlDbType.BigInt) { Value = searchCriteria.UserID });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@SubDocType", SqlDbType.NChar) { Value = searchCriteria.SubDocType, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@DateFrom", SqlDbType.DateTime) { Value = searchCriteria.DateFrom, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@DateTo", SqlDbType.DateTime) { Value = searchCriteria.DateTo, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Status_ID", SqlDbType.NChar) { Value = searchCriteria.StatusID, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Warehouse_ID", SqlDbType.NChar) { Value = searchCriteria.WarehouseID, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@JD_DocID", SqlDbType.Float) { Value = searchCriteria.JDDocID, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@JD_DocType", SqlDbType.Char) { Value = searchCriteria.JDDocType, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@BatchNumber", SqlDbType.Float) { Value = searchCriteria.BatchNumber, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WO_Doc_ID", SqlDbType.BigInt) { Value = searchCriteria.TSDDocID, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@WO_Doc_Type", SqlDbType.NChar) { Value = searchCriteria.TSDDocType });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@IsVirtual", SqlDbType.Bit) { Value = searchCriteria.IsVirtual, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@Employee_ID", SqlDbType.Int) { Value = searchCriteria.EmployeeID, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@dsc", SqlDbType.NVarChar) { Value = searchCriteria.Description, IsNullable = true });
            adapter.SelectCommand.Parameters.Add(new SqlParameter("@close", SqlDbType.Bit) { Value = searchCriteria.CloseOperations });

            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            var dataSet = new DataSet();
            adapter.Fill(dataSet);
            this.data = dataSet.Tables[0];
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public OperationsView()
        {
            this.dataColumns.Add(new PatternColumn("№ док-та", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID")));
            this.dataColumns.Add(new PatternColumn("Тип док-та", "SubDocTypeName", new FilterPatternExpressionRule("SubDocTypeName")));
            this.dataColumns.Add(new PatternColumn("Дата док-та", "DocDate", new FilterCompareExpressionRule<DateTime>("DocDate")));
            this.dataColumns.Add(new PatternColumn("Статус", "StatusName", new FilterPatternExpressionRule("StatusName")));
            this.dataColumns.Add(new PatternColumn("Описание операции", "Description", new FilterPatternExpressionRule("Description")));
            this.dataColumns.Add(new PatternColumn("Склад \"откуда\"", "WarehouseID_From", new FilterPatternExpressionRule("WarehouseID_From")));
            this.dataColumns.Add(new PatternColumn("Склад \"куда\"", "WarehouseID_To", new FilterPatternExpressionRule("WarehouseID_To")));
            this.dataColumns.Add(new PatternColumn("№ док-та JD", "JD_DocID"));
            this.dataColumns.Add(new PatternColumn("Тип док-та JD", "JD_DocType"));
            this.dataColumns.Add(new PatternColumn("Номер пакета", "BatchNumber"));
            this.dataColumns.Add(new PatternColumn("№ задания ТСД", "WO_Doc_ID"));
            this.dataColumns.Add(new PatternColumn("Тип задания ТСД", "WO_Doc_Type"));
            this.dataColumns.Add(new PatternColumn("Виртуальная операция", "IsVirtual", ColumnType.Logical, new FilterEmptyExpressionRule(), SummaryCalculationType.None));
            this.dataColumns.Add(new PatternColumn("Автор операции", "Employers", new FilterPatternExpressionRule("Employers")));
            this.dataColumns.Add(new PatternColumn("Сумма док-та, грн.", "Amount_UAH"));
        }
        #endregion
    }

    public class OperationsSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public string SubDocType { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string StatusID { get; set; }
        public string WarehouseID { get; set; }
        public double? JDDocID { get; set; }
        public string JDDocType { get; set; }
        public double? BatchNumber { get; set; }
        public long? TSDDocID { get; set; }
        public string TSDDocType { get; set; }
        public bool? IsVirtual { get; set; }
        public int? EmployeeID { get; set; }
        public string Description { get; set; }
        public bool? CloseOperations { get; set; }
    }
}
