using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Controls;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Window
{
    public partial class DocsForBranchesOfPersonalResponsibilityWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private Data.PickControl.MB_DocsRow SelectedDoc { get { return xdgvDocs.SelectedItem as Data.PickControl.MB_DocsRow; } }

        public DocsForBranchesOfPersonalResponsibilityWindow()
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
            stbEmployee.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Employees_List]";
            stbEmployee.UserID = this.UserID;
            stbEmployee.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);

            stbStatusFrom.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Statuses_List]";
            stbStatusFrom.UserID = this.UserID;
            stbStatusFrom.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);
            stbStatusFrom.SetValueByDefault("100");

            stbStatusTo.ValueReferenceQuery = "[dbo].[pr_MB_Get_Doc_Statuses_List]";
            stbStatusTo.UserID = this.UserID;
            stbStatusTo.OnVerifyValue += new WMSOffice.Controls.VerifyValueHandler(stbFilterItem_OnVerifyValue);
            stbStatusTo.SetValueByDefault("110");

            xdgvDocs.AllowSummary = false;
            xdgvDocs.AllowRangeColumns = true;

            xdgvDocs.UseMultiSelectMode = false;

            xdgvDocs.Init(new DocsForBranchesOfPersonalResponsibilityView(), true);
            xdgvDocs.LoadExtraDataGridViewSettings(this.Name);

            xdgvDocs.UserID = this.UserID;

            xdgvDocs.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocs.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocs.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);
            xdgvDocs.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);

            // активация постраничного просмотра
            xdgvDocs.CreatePageNavigator();

            SetOperationAccess();

            LoadDocs();
        }

        void stbFilterItem_OnVerifyValue(object sender, WMSOffice.Controls.VerifyValueArgs e)
        {
            var control = sender as SearchTextBox;
            TextBox lblDescription = null;

            if (control == stbEmployee)
                lblDescription = tbEmployee;
            else if (control == stbStatusFrom)
                lblDescription = tbStatusFrom;
            else if (control == stbStatusTo)
                lblDescription = tbStatusTo;

            if (lblDescription != null)
            {
                var description = e.Success ? e.Description : "ЗНАЧЕНИЕ НЕ НАЙДЕНО!";

                if (e.Success && !string.IsNullOrEmpty(e.Value) && control == stbEmployee)
                    description = string.Format("{0} [{1}]", description, e.OwnedRow["Department"].ToString());

                lblDescription.Text = description;
                lblDescription.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    control.Value = e.Value;
                //else
                //    control.Value = string.Empty;
            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
            xdgvDocs.RecalculateSummary();
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            try
            {
                var docID = this.SelectedDoc != null ? this.SelectedDoc.DocID : (int?)null;

                var isEnabled = this.SelectedDoc != null;

                btnCreateDoc.Enabled = 
                btnAssignDoc.Enabled =
                btnAcceptDoc.Enabled =
                btnDeclineDoc.Enabled = isEnabled;

                btnExportDoc.Enabled = xdgvDocs.HasRows;

                var actions = new Data.PickControl.MB_Doc_Avaliable_ActionsDataTable();
                using (var adapter = new Data.PickControlTableAdapters.MB_Doc_Avaliable_ActionsTableAdapter())
                    adapter.Fill(actions, this.UserID, docID);

                if (actions.Count > 0)
                {
                    var hasDocsToCreate = true;
                    var hasDocsToAssign = isEnabled && this.CheckDocs(100);

                    var hasDocsToAcceptOrDecline = isEnabled && this.CheckDocs(110);
                    var hasDocsToAccept = hasDocsToAcceptOrDecline;
                    var hasDocsToDecline = hasDocsToAcceptOrDecline;

                    var action = actions[0];

                    btnCreateDoc.Enabled = action.CanCreateDoc && hasDocsToCreate;
                    btnAssignDoc.Enabled = action.CanAssignDoc && hasDocsToAssign;
                    btnAcceptDoc.Enabled = action.CanAcceptDoc && hasDocsToAccept;
                    btnDeclineDoc.Enabled = action.CanDeclineDoc && hasDocsToDecline;
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var grid = sender as DataGridView;

                var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
                var color = Color.FromName(boundRow["Color"].ToString());

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch
            {

            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                LoadDocs();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefreshDocs_Click(object sender, EventArgs e)
        {
            LoadDocs();
        }

        private void LoadDocs()
        {
            try
            {
                var searchParams = new DocsForBranchesOfPersonalResponsibilitySearchParameters() { SessionID = this.UserID };

                if (!string.IsNullOrEmpty(stbEmployee.Value))
                {
                    int employeeID;
                    if (!int.TryParse(stbEmployee.Value, out employeeID))
                        throw new Exception("Код сотрудника должен быть числом.");
                    else
                        searchParams.EmployeeID = employeeID;
                }

                if (!string.IsNullOrEmpty(stbStatusFrom.Value))
                {
                    int statusFrom;
                    if (!int.TryParse(stbStatusFrom.Value, out statusFrom))
                        throw new Exception("Код статуса с должен быть числом.");
                    else
                        searchParams.StatusFrom = statusFrom;
                }

                if (!string.IsNullOrEmpty(stbStatusTo.Value))
                {
                    int statusTo;
                    if (!int.TryParse(stbStatusTo.Value, out statusTo))
                        throw new Exception("Код статуса по должен быть числом.");
                    else
                        searchParams.StatusTo = statusTo;
                }

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        this.xdgvDocs.DataView.FillData(e.Argument as DocsForBranchesOfPersonalResponsibilitySearchParameters);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvDocs.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocs.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение списка макетов полок..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        private void btnCreateDoc_Click(object sender, EventArgs e)
        {
            CreateDoc();
        }

        private void CreateDoc()
        {
            try
            {
                if (!btnCreateDoc.Enabled)
                    return;

                var dlgDocsForBranchesOfPersonalResponsibilityCreate = new DocsForBranchesOfPersonalResponsibilityCreateForm { UserID = this.UserID };
                if (dlgDocsForBranchesOfPersonalResponsibilityCreate.ShowDialog() == DialogResult.OK)
                    this.LoadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAssignDoc_Click(object sender, EventArgs e)
        {
            AssignDoc();
        }

        private void AssignDoc()
        {
            try
            {
                if (!btnAssignDoc.Enabled)
                    return;

                var sDocs = this.GetDocsSequence(100);

                var message = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.MB_DocsTableAdapter())
                    adapter.AssignDoc(this.UserID, sDocs, ref message);

                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDocs();
            }
        }

        private void btnAcceptDoc_Click(object sender, EventArgs e)
        {
            this.AcceptDoc();
        }

        private void AcceptDoc()
        {
            try
            {
                if (!btnAcceptDoc.Enabled)
                    return;

                var sDocs = this.GetDocsSequence(110);

                var message = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.MB_DocsTableAdapter())
                    adapter.AcceptDoc(this.UserID, sDocs, ref message);

                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDocs();
            }
        }

        private void btnDeclineDoc_Click(object sender, EventArgs e)
        {
            DeclineDoc();
        }

        private void DeclineDoc()
        {
            try
            {
                if (!btnDeclineDoc.Enabled)
                    return;

                var sDocs = this.GetDocsSequence(110);

                var message = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.MB_DocsTableAdapter())
                    adapter.DeclineDoc(this.UserID, sDocs, ref message);

                if (!string.IsNullOrEmpty(message))
                    MessageBox.Show(message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
            finally
            {
                this.LoadDocs();
            }
        }

        private bool CheckDocs(int targetStatus)
        {
            foreach (Data.PickControl.MB_DocsRow doc in xdgvDocs.SelectedItems)
                if (doc.StatusID == targetStatus)
                    return true;

            return false;
        }

        private string GetDocsSequence(int targetStatus)
        {
            var sbDocs = new StringBuilder();
            foreach (Data.PickControl.MB_DocsRow doc in xdgvDocs.SelectedItems)
                if (doc.StatusID == targetStatus)
                {
                    if (sbDocs.Length > 0)
                        sbDocs.AppendFormat(",{0}", doc.DocID);
                    else
                        sbDocs.AppendFormat("{0}", doc.DocID);
                }

            return sbDocs.ToString();
        }

        private void DocsForBranchesOfPersonalResponsibilityWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            xdgvDocs.SaveExtraDataGridViewSettings(this.Name);
        }

        private void btnExportDoc_Click(object sender, EventArgs e)
        {
            ExportDoc();
        }

        private void ExportDoc()
        {
            try
            {
                if (!btnExportDoc.Enabled)
                    return;

                xdgvDocs.ExportToExcel("Экспорт макетов полок в Excel", "макеты полок", true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }

    /// <summary>
    /// Представление для макетов создания полок персональной ответственности
    /// </summary>
    public class DocsForBranchesOfPersonalResponsibilityView : IDataView
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
            var searchCriteria = searchParameters as DocsForBranchesOfPersonalResponsibilitySearchParameters;

            var sessionID = searchCriteria.SessionID;
            var employeeID = searchCriteria.EmployeeID;
            var statusFrom = searchCriteria.StatusFrom;
            var statusTo = searchCriteria.StatusTo;
          

            using (var adapter = new Data.PickControlTableAdapters.MB_DocsTableAdapter())
            {
                adapter.SetTimeout(DEFAULT_RESPONSE_TIMEOUT);
                data = adapter.GetData(sessionID, employeeID, statusFrom, statusTo);
            }
        }

        #endregion

        public DocsForBranchesOfPersonalResponsibilityView()
        {
            this.dataColumns.Add(new PatternColumn("№ макета", "DocID", new FilterCompareExpressionRule<Int32>("DocID"), SummaryCalculationType.Count) { Width = 90 });

            this.dataColumns.Add(new PatternColumn("Склад", "WarehouseID", new FilterPatternExpressionRule("WarehouseID")) { Width = 85 });
            this.dataColumns.Add(new PatternColumn("Адрес полки", "LocationName", new FilterPatternExpressionRule("LocationName")) { Width = 95 });

            this.dataColumns.Add(new PatternColumn("Код сотрудника", "EmployeeID", new FilterCompareExpressionRule<Int32>("EmployeeID"), SummaryCalculationType.Count) { Width = 115 });
            this.dataColumns.Add(new PatternColumn("ФИО Сотрудника", "EmployeeName", new FilterPatternExpressionRule("EmployeeName")) { Width = 190 });
            this.dataColumns.Add(new PatternColumn("Отдел", "Department", new FilterPatternExpressionRule("Department")) { Width = 140 });
            this.dataColumns.Add(new PatternColumn("Должность", "EmployeePost", new FilterPatternExpressionRule("EmployeePost")) { Width = 150 });

            this.dataColumns.Add(new PatternColumn("ФИО Инициатора", "AuthorName", new FilterPatternExpressionRule("AuthorName")) { Width = 190 });
            this.dataColumns.Add(new PatternColumn("Причина создания полки", "DocReason", new FilterPatternExpressionRule("DocReason")) { Width = 160 });

            this.dataColumns.Add(new PatternColumn("Дата создания макета", "DocDate", new FilterDateCompareExpressionRule("DocDate")) { Width = 155 });

            this.dataColumns.Add(new PatternColumn("Статус", "StatusID", new FilterCompareExpressionRule<Int32>("StatusID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Название статуса", "StatusName", new FilterPatternExpressionRule("StatusName")) { Width = 130 });

            this.dataColumns.Add(new PatternColumn("ФИО Византа", "ApproverName", new FilterPatternExpressionRule("ApproverName")) { Width = 190 });

            this.dataColumns.Add(new PatternColumn("Дата текущего статуса", "StatusDate", new FilterDateCompareExpressionRule("StatusDate")) { Width = 155 });
        }
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class DocsForBranchesOfPersonalResponsibilitySearchParameters : SessionIDSearchParameters
    {
        public int? EmployeeID { get; set; }
        public int? StatusFrom { get; set; }
        public int? StatusTo { get; set; }
    }
}
