using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WH;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class EmployeeMotivationReportWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        private static readonly string QTY_MARKER = "@";
        private static readonly string SUM_MARKER = "∑";

        private readonly List<string> lstMarkers = null;

        private readonly Dictionary<string, string> dicViewModes = null;

        private readonly ReportHeaderGroupsWrapper _groupsWrapper = new ReportHeaderGroupsWrapper();

        private string currentViewModeMarker = QTY_MARKER;

        public int? SelectedEmployeeID { get; private set; }

        public Data.WH.EmployeeMotivationReportRow SelectedReportRow { get { return dgvReport.SelectedRows.Count == 0 ? null : ((dgvReport.SelectedRows[0].DataBoundItem) as DataRowView).Row as Data.WH.EmployeeMotivationReportRow; } }

        public EmployeeMotivationReportWindow()
        {
            InitializeComponent();

            dicViewModes = new Dictionary<string, string>();
            dicViewModes[QTY_MARKER] = "по количествам (ЕИ)";
            dicViewModes[SUM_MARKER] = "по баллам";

            lstMarkers = new List<string>();
            foreach (var kvp in dicViewModes)
                lstMarkers.Add(kvp.Key);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            if (!this.SelectEmployee())
            {
                this.Close();
                return;
            }
        }

        private void Initialize()
        {
            this.InitializeToolbar();
            this.InitializeGrid();
            this.RecreateGrid();
        }

        private void InitializeToolbar()
        {
            var lblViewModes = new ToolStripLabel();
            lblViewModes.Text = "для режима просмотра";
            tsMain.Items.Add(lblViewModes);

            var cmbViewModes = new ToolStripComboBox();
            cmbViewModes.ComboBox.Width = 150;
            cmbViewModes.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbViewModes.ComboBox.DisplayMember = "Value";
            cmbViewModes.ComboBox.ValueMember = "Key";

            foreach (var kvp in dicViewModes)
                cmbViewModes.ComboBox.Items.Add(kvp);

            cmbViewModes.ComboBox.SelectedIndex = 0;

            cmbViewModes.ComboBox.SelectedIndexChanged += (s, e) =>
            {
                var kvp = (KeyValuePair<string, string>)cmbViewModes.ComboBox.SelectedItem;
                currentViewModeMarker = kvp.Key;

                this.RecreateGrid();
            };

            tsMain.Items.Add(cmbViewModes);

            tsMain.Items.Add(new ToolStripSeparator());

            var btnSelectEmployee = new ToolStripButton("Выбрать\r\nсотрудника", Properties.Resources.user, (s, e) => { this.SelectEmployee(); });
            tsMain.Items.Add(btnSelectEmployee);


            cmbPeriod.ComboBox.SelectedIndexChanged += (s, e) =>
            {
                this.ReloadDetails();
            };
            cmbPeriod.ComboBox.SelectedIndex = 0; // детализация за сегодня выбрана по умолчанию
        }

        private void InitializeGrid()
        {
            #region РЕДИЗАЙН ОПИСАТЕЛЬНЫХ КОЛОНОК

            процессDataGridViewTextBoxColumn1.Width = 220; // 120

            типОперацииDataGridViewTextBoxColumn1.Width = 250;

            едИзмDataGridViewTextBoxColumn1.DataPropertyName = "UOM";
            едИзмDataGridViewTextBoxColumn1.HeaderText = "Ед. изм.";
            едИзмDataGridViewTextBoxColumn1.Width = 100; // 120;

            #endregion

            foreach (DataGridViewColumn dgvc in dgvReport.Columns)
                if (dgvc.HeaderText.Contains(QTY_MARKER) || dgvc.HeaderText.Contains(SUM_MARKER))
                    dgvc.Tag = dgvc.HeaderText;
           
        }

        private void RecreateGrid()
        {
            #region ПОВТОРНОЕ СОЗДАНИЕ КОЛОНОК

            var widthGroupHeadersIndent = 0;

            _groupsWrapper.ClearGroups();

            foreach (DataGridViewColumn dgvc in dgvReport.Columns)
            {
                dgvc.Visible = true;
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;

                var dgvcTagHeader = (dgvc.Tag ?? string.Empty).ToString(); 
                if (dgvcTagHeader.Contains(currentViewModeMarker))
                {
                    var sHeaderParts = dgvcTagHeader.Split(new char[] { currentViewModeMarker[0] }, StringSplitOptions.RemoveEmptyEntries);

                    if (sHeaderParts.Length == 2)
                    {
                        var sHeaderGroup = sHeaderParts[0];
                        var sHeaderUpd = sHeaderParts[1];

                        dgvc.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvc.HeaderText = sHeaderUpd;
                        dgvc.DefaultCellStyle.Format = "N2";
                        dgvc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                        // Формирование параметров групп заголовка
                        var foundGroup = _groupsWrapper.FindGroup(sHeaderGroup);

                        if (foundGroup != null)
                            foundGroup.Width += dgvc.Width;
                        else
                            _groupsWrapper.AddGroup(new ReportHeaderGroup() { Header = sHeaderGroup, Width = dgvc.Width });
                    }
                }
                else if (this.ContainsMarker(dgvcTagHeader))
                {
                    dgvc.Visible = false;
                }
                else
                {
                    widthGroupHeadersIndent += dgvc.Width;
                }
            }


            // Фомирование групп заголовка
            dgvReportGroups.Columns.Clear();

            dgvReportGroups.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvReportGroups.Columns.Add(new DataGridViewTextBoxColumn() { Width = widthGroupHeadersIndent, SortMode = DataGridViewColumnSortMode.NotSortable });

            foreach (var group in _groupsWrapper.Items)
                dgvReportGroups.Columns.Add(new DataGridViewTextBoxColumn() { HeaderText = group.Header, Width = group.Width, SortMode = DataGridViewColumnSortMode.NotSortable });

            #endregion
        }

        private bool ContainsMarker(string sPattern)
        {
            foreach (var marker in lstMarkers)
                if (sPattern.Contains(marker))
                    return true;

            return false;
        }

        private void btnRefreshReport_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        private void ReloadData()
        {
            var bw = new BackgroundWorker();
            bw.DoWork += (s, e) =>
            {
                try
                {
                    var userID = this.UserID;
                    var employeeID = this.SelectedEmployeeID;

                    e.Result = employeeMotivationReportTableAdapter.GetData(userID, employeeID);
                }
                catch (Exception ex)
                {
                    this.ShowError(ex);
                }
            };
            bw.RunWorkerCompleted += (s, e) =>
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    employeeMotivationReportBindingSource.DataSource = e.Result;

                splashForm.CloseForce();
            };

            employeeMotivationReportBindingSource.DataSource = null;
            splashForm.ActionText = "Выполняется получение отчета..";

            bw.RunWorkerAsync();

            splashForm.ShowDialog();
        }

        private bool SelectEmployee()
        {
            var dlgSelectEmployee = new EmloyeesForMotivationForm(SelectedEmployeeID) { UserID = this.UserID };
            if (dlgSelectEmployee.ShowDialog(this) == DialogResult.OK)
            {
                var employeeID = dlgSelectEmployee.SelectedEmployeeID;
                var employeeName = dlgSelectEmployee.SelectedEmployeeName;
                this.PrepareDocTitle(employeeID, employeeName);

                SelectedEmployeeID = employeeID;
                
                this.ReloadData();
                
                return true;
            }

            return false;
        }

        private void PrepareDocTitle(int? employeeID, string employeeName)
        {
            this.DocTitle.Text = string.Format("{0} ({1}) [{2}({3})]", this.DocName, this.DocType, employeeName, employeeID);
        }

        private void dgvReport_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (e.Value.Equals(0.00) && this.ContainsMarker((dgvReport.Columns[e.ColumnIndex].Tag ?? string.Empty).ToString()))
            {
                e.Value = "-";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            var boundRow = (dgvReport.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.EmployeeMotivationReportRow;
            if (string.IsNullOrEmpty(boundRow.UOM))
            {
                var color = Color.Khaki;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }

        private void dgvReport_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadDetails();
        }

        private void ReloadDetails()
        {
            try
            {
                employeeMotivationReportDetailsBindingSource.DataSource = null;

                if (!SelectedEmployeeID.HasValue)
                    return;

                if (SelectedReportRow == null)
                    return;

                var userID = this.UserID;
                var employeeID = SelectedEmployeeID.Value;
                var uom = SelectedReportRow.ЕИ;
                var operationID = SelectedReportRow.IsOper_TPNull() ? (short?)null : SelectedReportRow.Oper_TP;
                var periodID = cmbPeriod.ComboBox.SelectedIndex + 1;

                var _splashForm = new WMSOffice.Dialogs.SplashForm();

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) => 
                {
                    try
                    {
                        e.Result = employeeMotivationReportDetailsTableAdapter.GetData(userID, employeeID, uom, operationID, (byte)periodID);
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
                        employeeMotivationReportDetailsBindingSource.DataSource = e.Result;

                    _splashForm.CloseForce();
                };

                _splashForm.ActionText = "Выполняется получение деталей отчета..";

                bw.RunWorkerAsync();

                _splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReportDetails.Rows.Count == 0)
                {
                    MessageBox.Show("Отсутствуют данные для экспорта.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                var employeeID = SelectedEmployeeID.Value;
                var operationName = SelectedReportRow.Тип_операции;
                var period = cmbPeriod.Text;
                var fileName = string.Format("{0}_{1}_{2}", employeeID, operationName, period);
                ExportHelper.ExportDataGridViewToExcel(dgvReportDetails, "Экспорт деталей отчета мотивации", fileName, true);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
        
        private void dgvReportDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == -1)
                return;

            if (dgvReportDetails.Columns[e.ColumnIndex].DataPropertyName == wH.EmployeeMotivationReportDetails.БалловColumn.Caption
                && e.Value.Equals(0.00f))
            {
                e.Value = "-";
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
    }

    public class ReportHeaderGroupsWrapper
    {
        private readonly List<ReportHeaderGroup> _groups = new List<ReportHeaderGroup>();

        public IEnumerable<ReportHeaderGroup> Items { get { return _groups; } }

        public ReportHeaderGroup FindGroup(string header)
        {
            foreach (var group in _groups)
                if (group.Header.Equals(header, StringComparison.OrdinalIgnoreCase))
                    return group;

            return null;
        }

        public void AddGroup(ReportHeaderGroup group)
        {
            _groups.Add(group);
        }

        public void ClearGroups()
        {
            _groups.Clear();
        }
    }
            
    public class ReportHeaderGroup
    {
        public string Header { get; set; }
        public int Width { get; set; }
    }
}
