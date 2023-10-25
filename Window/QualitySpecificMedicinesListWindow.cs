using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Quality;

namespace WMSOffice.Window
{
    public partial class QualitySpecificMedicinesListWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public Data.Quality.NL_ListRow SelectedDocGroup { get { return xdgvDocGroups.SelectedItem != null ? xdgvDocGroups.SelectedItem as Data.Quality.NL_ListRow : null; } }

        public Data.Quality.NL_ListDetailsRow SelectedDoc { get { return dgvDocs.SelectedRows.Count > 0 ? (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow : null; } }

        public bool FullAccess { get; private set; }

        public QualitySpecificMedicinesListWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
            this.ReloadDocGroups();
        }

        private void Initialize()
        {
            xdgvDocGroups.AllowSummary = false;

            xdgvDocGroups.Init(new SpecificMedicinesListView(), true);
            xdgvDocGroups.UserID = this.UserID;

            xdgvDocGroups.SetSameStyleForAlternativeRows();

            xdgvDocGroups.OnDataError += new DataGridViewDataErrorEventHandler(xdgvDocs_OnDataError);
            xdgvDocGroups.OnRowSelectionChanged += new EventHandler(xdgvDocs_OnRowSelectionChanged);
            xdgvDocGroups.OnFilterChanged += new EventHandler(xdgvDocs_OnFilterChanged);
            xdgvDocGroups.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDocs_OnFormattingCell);

            this.CheckDocAccess();

            if (!this.FullAccess)
                btnEditDoc.Text = "Открыть";

            this.SetDocOperationAccess();
        }

        private void CheckDocAccess()
        {
            try
            {
                var fullAccess = (bool?)null;
                using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                    adapter.CheckAccess(this.UserID, ref fullAccess);

                this.FullAccess = fullAccess ?? false;
            }
            catch (Exception)
            {

            }
        }

        void xdgvDocs_OnDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        void xdgvDocs_OnRowSelectionChanged(object sender, EventArgs e)
        {
            this.ReloadDocs();
        }

        void xdgvDocs_OnFilterChanged(object sender, EventArgs e)
        {
            xdgvDocGroups.RecalculateSummary();
        }

        void xdgvDocs_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (xdgvDocGroups.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            #region СТИЛЬ ДЛЯ ИНДИКАЦИИ АРХИВНЫХ ПЕРЕЧНЕЙ

            var isEnable = Convert.ToBoolean(boundRow["IsEnable"]);
            if (!isEnable)
            {
                var color = Color.LightGray;
                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
                //e.CellStyle.SelectionBackColor = color;
            }

            #endregion
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadDocGroups();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadDocGroups();
        }


        private void ReloadDocGroups()
        {
            try
            {
                var docID = this.SelectedDocGroup == null ? (string)null : this.SelectedDocGroup.PerelikID;

                var searchParams = new SpecificMedicinesListSearchParameters() { SessionID = this.UserID };

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    this.xdgvDocGroups.DataView.FillData(e.Argument as SpecificMedicinesListSearchParameters);
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    if (e.Result is Exception)
                        this.ShowError(e.Result as Exception);
                    else
                    {
                        this.xdgvDocGroups.BindData(false);

                        //this.xdgvDocs.AllowFilter = true;
                        this.xdgvDocGroups.AllowSummary = true;
                    }

                    splashForm.CloseForce();
                };

                splashForm.ActionText = "Выполняется получение данных..";
                bw.RunWorkerAsync(searchParams);
                splashForm.ShowDialog();

                if (!string.IsNullOrEmpty(docID))
                    this.NavigateToDocGroup(docID);

                xdgvDocGroups.DataGrid.Select();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void NavigateToDocGroup(string perelikID)
        {
            xdgvDocGroups.SelectRow("PerelikID", perelikID);
            xdgvDocGroups.ScrollToSelectedRow();
        }


        private void ReloadDocs()
        {
            var detailID = this.SelectedDoc == null ? (int?)null : this.SelectedDoc.DetailID;

            try
            {
                var perelikID = xdgvDocGroups.SelectedItem == null ? (string)null : xdgvDocGroups.SelectedItem["PerelikID"].ToString();

                nL_ListDetailsTableAdapter.Fill(quality.NL_ListDetails, perelikID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (detailID != null)
                    this.NavigateToDoc(detailID.Value);
            }
        }

        private void NavigateToDoc(int detailID)
        {
            foreach (DataGridViewRow boundRow in dgvDocs.Rows)
            {
                var detail = (boundRow.DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow;
                if (detail.DetailID.Equals(detailID))
                {
                    boundRow.Selected = true;
                    dgvDocs.FirstDisplayedScrollingRowIndex = boundRow.Index;
                    return;
                }
            }
        }


        private void btnCreateDoc_Click(object sender, EventArgs e)
        {
            this.AddDoc();
        }

        private void AddDoc()
        {
            if (!btnCreateDoc.Enabled)
                return;

            var detail = (Data.Quality.NL_ListDetailsRow)null;
            this.EditOrCreateDoc(detail, false);
        }

        private void btnEditDoc_Click(object sender, EventArgs e)
        {
            this.EditDoc();
        }

        private void EditDoc()
        {
            this.EditDoc(true);
        }
        private void EditDoc(bool isReadOnly)
        {
            if (!btnEditDoc.Enabled)
                return;

            var detail = (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow;
            this.EditOrCreateDoc(detail, isReadOnly);
        }

        private void EditOrCreateDoc(Data.Quality.NL_ListDetailsRow detail, bool isReadOnly)
        {
            try
            {
                var perelikID = xdgvDocGroups.SelectedItem["PerelikID"].ToString();

                var dlgQualitySpecificMedicinesListItemsEditor = new QualitySpecificMedicinesListItemsEditorForm(perelikID, detail) { UserID = this.UserID, FullAccess = isReadOnly ? this.FullAccess : true };
                if (dlgQualitySpecificMedicinesListItemsEditor.ShowDialog(this) == DialogResult.OK)
                    this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnDeleteDoc_Click(object sender, EventArgs e)
        {
            this.DeleteDoc();
        }

        private void DeleteDoc()
        {
            if (!btnDeleteDoc.Enabled)
                return;

            if (MessageBox.Show("Вы уверены что хотите удалить приказ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                var perelikID = xdgvDocGroups.SelectedItem == null ? (string)null : xdgvDocGroups.SelectedItem["PerelikID"].ToString();
                var detailID = ((dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow).DetailID;

                nL_ListDetailsTableAdapter.Remove(perelikID, detailID);

                this.ReloadDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetDocOperationAccess();
        }

        private void SetDocOperationAccess()
        {
            var isDocGroupEnabled = xdgvDocGroups.SelectedItem != null; 
            var isDocEnabled = isDocGroupEnabled && dgvDocs.SelectedRows.Count == 1;

            var isCreateEnabled = isDocGroupEnabled && this.FullAccess;
            btnCreateDoc.Enabled = isCreateEnabled;

            bool isEditEnabled = isDocEnabled;
            btnEditDoc.Enabled = isEditEnabled;

            bool isCopyEnebled = isDocEnabled;
            btnCopyDoc.Enabled = isCopyEnebled;

            bool isDeleteEnabled = isDocEnabled && this.FullAccess;
            btnDeleteDoc.Enabled = isDeleteEnabled;
        }

        private void dgvDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.EditDoc();
        }

        private void btnCopyDoc_Click(object sender, EventArgs e)
        {
            this.CopyDoc();
        }

        private void CopyDoc()
        {
            if (!btnCopyDoc.Enabled)
                return;

            if (MessageBox.Show("Вы уверены что хотите создать копию приказа?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                var perelikID = xdgvDocGroups.SelectedItem == null ? (string)null : xdgvDocGroups.SelectedItem["PerelikID"].ToString();
                var srcDetailID = ((dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow).DetailID;

                var trgDetailID = (int?)null;
                using (var adapter = new Data.QualityTableAdapters.NL_ListDetailsTableAdapter())
                    adapter.Copy(perelikID, srcDetailID, this.UserID, ref trgDetailID);

                if (trgDetailID.HasValue)
                {
                    this.ReloadDocs();

                    this.NavigateToDoc(trgDetailID.Value);

                    this.EditDoc(false);
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var detail = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.NL_ListDetailsRow;
            if (detail.IsOrderNumberNull() || detail.IsDateFromNull() || detail.IsDescriptionNull())
                e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = Color.LightPink;
        }
    }

    /// <summary>
    /// Представление для нац. перечней
    /// </summary>
    public class SpecificMedicinesListView : IDataView
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
            var searchCriteria = searchParameters as SpecificMedicinesListSearchParameters;

            using (var adapter = new Data.QualityTableAdapters.NL_ListTableAdapter())
                this.data = adapter.GetData(Convert.ToInt32(searchCriteria.OnlyEnable ?? false));
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public SpecificMedicinesListView()
        {
            this.dataColumns.Add(new PatternColumn("Код перечня", "PerelikID", new FilterPatternExpressionRule("PerelikID")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Государственное ограничение наценки", "PerelikName", new FilterPatternExpressionRule("PerelikName")) { Width = 500 });

            //this.dataColumns.Add(new PatternColumn("Дата с", "DateFrom", new FilterDateCompareExpressionRule("DateFrom")) { Width = 100 });
            //this.dataColumns.Add(new PatternColumn("Дата по", "DateTo", new FilterDateCompareExpressionRule("DateTo")) { Width = 100 });

            //this.dataColumns.Add(new PatternColumn("Гос. рег.", "GosReg", new FilterPatternExpressionRule("GosReg")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Изменен кем", "UserName", new FilterPatternExpressionRule("UserName")) { Width = 250 });
            this.dataColumns.Add(new PatternColumn("Изменен когда", "DateUpdated", new FilterDateCompareExpressionRule("DateUpdated")) { Width = 150 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска
    /// </summary>
    public class SpecificMedicinesListSearchParameters : SessionIDSearchParameters
    {
        public bool? OnlyEnable { get; set; }
    }
}
