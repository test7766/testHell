using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно "Замечания от ГЛС"
    /// </summary>
    public partial class GlsRemarksForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор заявки ГЛС, по которой открыто окно замечаний
        /// </summary>
        private readonly long docID;

        /// <summary>
        /// Идентификатор строки заявки ГЛС, по которой открыто окно замечаний,
        /// или null если окно открыто не по строке, а по целой заявке
        /// </summary>
        private readonly int? lineID;

        /// <summary>
        /// True если окно запущено в режиме только просмотра замечаний,
        /// False если окно запущено для редактирования замечаний (это возможно только на статусе заявки 140)
        /// </summary>
        private readonly bool isReadOnly;

        /// <summary>
        /// Выделенные в таблице замечания ГЛС
        /// </summary>
        private Data.Quality.QK_GLS_RemarksRow[] SelectedRemarks
        {
            get
            {
                var list = new List<Data.Quality.QK_GLS_RemarksRow>();
                foreach (DataGridViewRow row in dgvRemarks.SelectedRows)
                    list.Add((row.DataBoundItem as DataRowView).Row as Data.Quality.QK_GLS_RemarksRow);

                return list.ToArray();
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public GlsRemarksForm(long pSessionID, long pDocID, int? pLineID, bool pIsReadOnly)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            lineID = pLineID;
            isReadOnly = pIsReadOnly;
            if (pLineID.HasValue)
                Text += String.Format(" (Заява {0}, рядок {1})", pDocID, pLineID);
            else
                Text += String.Format(" (Заява {0})", pDocID);
        }

        /// <summary>
        /// True если в данный момент времени происходит загрузка замечаний ГЛС,
        /// False в противном случае (по умолчанию False)
        /// </summary>
        private bool isGlsRemarksLoading;

        /// <summary>
        /// Замечания от ГЛС, выделенные в таблице
        /// </summary>
        private readonly List<long> selectedGlsRemarks = new List<long>();

        /// <summary>
        /// Загрузка замечаний ГЛС при загрузке окна
        /// </summary>
        private void GlsRemarksForm_Load(object sender, EventArgs e)
        {
            CustomButtons();
            RefreshGlsRemarks();
        }

        /// <summary>
        /// Обновление замечаний от ГЛС в таблице
        /// </summary>
        private void RefreshGlsRemarks()
        {
            tsButtons.Enabled = dgvRemarks.Enabled = false;
            isGlsRemarksLoading = true;
            SaveSelection();
            bwGlsRemarksLoader.RunWorkerAsync();
            tmrLoadingShower.Start();
        }

        /// <summary>
        /// Сохранение идентификаторов выделенных строк для того, чтобы можно было выделить их после обновления
        /// </summary>
        private void SaveSelection()
        {
            selectedGlsRemarks.Clear();
            if (addedGlsRemarks.Count > 0)
                selectedGlsRemarks.AddRange(addedGlsRemarks);
            else
                foreach (var row in SelectedRemarks)
                    selectedGlsRemarks.Add(row.id);

            addedGlsRemarks.Clear();
        }

        /// <summary>
        /// Обновление замечаний ГЛС по нажатию на кнопку или пункт меню "Обновить"
        /// </summary>
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshGlsRemarks();
        }

        /// <summary>
        /// Асинхронная загрузка замечаний ГЛС
        /// </summary>
        private void bwGlsRemarksLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                taQkGLSRemarks.Fill(quality.QK_GLS_Remarks, sessionID, docID, lineID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание обновления замечаний от ГЛС - перезагрузка данных в таблице
        /// </summary>
        private void bwGlsRemarksLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки замечаний ГЛС: ", e.Result as Exception);
                quality.QK_GLS_Remarks.Clear();
            }
            else
            {
                dgvRemarks.DataSource = null;
                dgvRemarks.DataSource = bsQkGLSRemarks;
                RestoreSelection();
            }

            tmrLoadingShower.Stop();
            pbSplashControl.Visible = isGlsRemarksLoading = false;
            tsButtons.Enabled = dgvRemarks.Enabled = true;
        }

        /// <summary>
        /// Выделение строк, которые были выделены перед обновлением данных в таблице 
        /// (если было действие добавления замечания ГЛС, то выделяем только добавленное замечание)
        /// </summary>
        private void RestoreSelection()
        {
            dgvRemarks.ClearSelection();
            foreach (DataGridViewRow dgvrow in dgvRemarks.Rows)
                if (selectedGlsRemarks.Contains(((dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.QK_GLS_RemarksRow).id))
                    dgvrow.Selected = true;
            if (dgvRemarks.SelectedRows.Count == 0 && dgvRemarks.Rows.Count > 0)
                dgvRemarks.Rows[0].Selected = true;
        }

        /// <summary>
        /// Если загрузка продолжается слишком долго, отображаем индикатор загрузки
        /// </summary>
        private void tmrLoadingShower_Tick(object sender, EventArgs e)
        {
            if (isGlsRemarksLoading)
            {
                pbSplashControl.Visible = true;
                tmrLoadingShower.Stop();
            }
        }

        /// <summary>
        /// Отображение описания для выбранного замечания в большом текстовом поле
        /// </summary>
        private void dgvRemarks_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRemarks.SelectedRows.Count != 1)
                tbxDescription.Text = String.Empty;
            else
                tbxDescription.Text = SelectedRemarks[0].IsdescriptionNull() ? String.Empty : SelectedRemarks[0].description;
            CustomButtons();
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранной причины задержки
        /// </summary>
        private void CustomButtons()
        {
            btnNewRemark.Enabled = miNewRemark.Enabled = !isReadOnly;

            bool canResolve = true, canDocsToGls = true, canInformlist = true, canResume = true;
            foreach (var remark in SelectedRemarks)
            {
                if (!remark.Isdate_resolvedNull())
                    canResolve = false;
                if (remark.Isdate_informlistNull() || !remark.Isdate_docs_to_glsNull())
                    canDocsToGls = false;
                if (!remark.Isdate_informlistNull())
                    canInformlist = false;
                if (remark.Isdate_resolvedNull())
                    canResume = false;
            }

            btnResolveRemark.Enabled = miResolveRemark.Enabled = !isReadOnly && canResolve && dgvRemarks.SelectedRows.Count > 0;
            btnInformlist.Enabled = miInformlist.Enabled = !isReadOnly && canInformlist && dgvRemarks.SelectedRows.Count > 0;
            btnDocsToGls.Enabled = miDocsToGls.Enabled = !isReadOnly && canDocsToGls && dgvRemarks.SelectedRows.Count > 0;
            btnResumeRemark.Enabled = miResumeRemark.Enabled = !isReadOnly && canResume && dgvRemarks.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Раскрашивание строк
        /// </summary>
        private void dgvRemarks_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvRemarks.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Data.Quality.QK_GLS_RemarksRow;
                Color clr;
                if (!diffRow.is_critical && diffRow.Isdate_resolvedNull())
                    clr = Color.FromArgb(255, 153, 153);
                else if (!diffRow.Isdate_resolvedNull())
                    clr = Color.FromArgb(153, 204, 102);
                else
                    clr = Color.FromArgb(204, 204, 204);
                for (int c = 0; c < row.Cells.Count; c++)
                    row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = clr;
            }
        }

        /// <summary>
        /// Глотаем ошибку, просто чтобы не появлялось уведомление по умолчанию
        /// </summary>
        private void dgvRemarks_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        #endregion

        #region ДОБАВЛЕНИЕ И ДРУГИЕ ДЕЙСТВИЯ С ЗАМЕЧАНИЯМИ ГЛС

        /// <summary>
        /// Идентификатор только что добавленного замечания или null, 
        /// если после последнего добавления замечания произошло хотя бы одно обновление таблицы
        /// </summary>
        private readonly List<long> addedGlsRemarks = new List<long>();

        /// <summary>
        /// Добавление нового замечания ГЛС
        /// </summary>
        private void NewGlsRemark_Click(object sender, EventArgs e)
        {
            try
            {
                var newRemarkForm = new NewGlsRemarkForm(sessionID, docID, lineID) { Owner = this };
                if (newRemarkForm.ShowDialog() == DialogResult.OK)
                    if (lineID.HasValue)
                        addedGlsRemarks.Add(Convert.ToInt64(taQkGLSRemarks.InsertGlsRemark(sessionID, docID, lineID,
                            newRemarkForm.RemarkTypeID, newRemarkForm.Description, newRemarkForm.GlsExpert, (bool?)null, (long?)null)));
                    else
                        foreach (var ln in newRemarkForm.CheckedRows)
                            addedGlsRemarks.Add(Convert.ToInt64(taQkGLSRemarks.InsertGlsRemark(sessionID, docID, ln.line_id,
                                newRemarkForm.RemarkTypeID, newRemarkForm.Description, newRemarkForm.GlsExpert, (bool?)null, (long?)null)));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при добавлении замечания от ГЛС: ", exc);
            }
            finally
            {
                RefreshGlsRemarks();
            }
        }

        /// <summary>
        /// Выполнение действия с выделенными замечаниями ГЛС
        /// </summary>
        private void DoActionWithRemark_Click(object sender, EventArgs e)
        {
            try
            {
                string msg;
                GLSRemarksActions action;
                if (sender == btnResolveRemark || sender == miResolveRemark)
                {
                    msg = "Вы точно хотите пометить выделенные в таблице замечания как устраненные?";
                    action = GLSRemarksActions.Resolve;
                }
                else if (sender == btnInformlist || sender == miInformlist)
                {
                    msg = "Вы точно хотите внести факт получения информлиста по выделенным в таблице замечаниям?";
                    action = GLSRemarksActions.Informlist;
                }
                else
                {
                    msg = "Вы точно хотите внести факт передачи документов в ГЛС по выделенным в таблице замечаниям?";
                    action = GLSRemarksActions.DocsToGls;
                }
                if (MessageBox.Show(msg, "Замечания ГЛС", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    foreach (var remark in SelectedRemarks)
                        taQkGLSRemarks.UpdateGlsRemark(sessionID, remark.id, Convert.ToInt32(action));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка:", exc);
            }
            finally
            {
                RefreshGlsRemarks();
            }
        }

        #endregion

        private void ResumeRemark_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы действительно хотите актуализировать замечание?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    var parentRemark = SelectedRemarks[0] as Data.Quality.QK_GLS_RemarksRow;

                    var parentRemarkID = parentRemark.id;
                    var parentRemarkTypeID = parentRemark.remark_type_id;
                    var parentDescription = parentRemark.IsdescriptionNull() ? (string)null : parentRemark.description;
                    var parentGlsExpert = parentRemark.Isgls_expertNull() ? (string)null : parentRemark.gls_expert;

                    var newRemarkForm = new NewGlsRemarkForm(sessionID, docID, (int?)null, parentRemarkTypeID, parentDescription, parentGlsExpert) { Owner = this };
                    if (newRemarkForm.ShowDialog() == DialogResult.OK) 
                    {
                        addedGlsRemarks.Add(Convert.ToInt64(taQkGLSRemarks.InsertGlsRemark(sessionID, docID, (int?)null,
                                newRemarkForm.RemarkTypeID, newRemarkForm.Description, newRemarkForm.GlsExpert, (bool?)null, parentRemarkID)));
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при актуализации замечания от ГЛС: ", exc);
            }
            finally
            {
                RefreshGlsRemarks();
            }
        }
    }

    #region ДЕЙСТВИЯ С ЗАМЕЧАНИЯМИ ГЛС - ПЕРЕЧИСЛЕНИЕ

    /// <summary>
    /// Доступные действия с замечаниями ГЛС
    /// </summary>
    public enum GLSRemarksActions
    {
        /// <summary>
        /// Устранение некритического замечания
        /// </summary>
        Resolve = 1,

        /// <summary>
        /// Внесение даты получения информлиста
        /// </summary>
        Informlist = 2,

        /// <summary>
        /// Внесение даты передачи документов по критическому замечанию в ГЛС
        /// </summary>
        DocsToGls = 3
    }

    #endregion
}
