using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

using WMSOffice.Classes;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для работы с причинами задержки
    /// </summary>
    public partial class DelayReasonsForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;
        
        /// <summary>
        /// Заявка, для которой открыто окно (соответственно, рассматриваются причины задержки)
        /// </summary>
        private readonly Data.Quality.DocsRow doc;

        /// <summary>
        /// True если окно запущено в режиме только просмотра причин задержки,
        /// False если окно запущено для редактирования причин задержки (это возможно только на статусе заявки 100)
        /// </summary>
        private readonly bool isReadOnly;

        /// <summary>
        /// Выделенные в таблице причины
        /// </summary>
        private Data.Quality.QK_Delay_ReasonsRow[] SelectedReasons
        {
            get
            {
                var list = new List<Data.Quality.QK_Delay_ReasonsRow>();
                foreach (DataGridViewRow row in dgvReasons.SelectedRows)
                    list.Add((row.DataBoundItem as DataRowView).Row as Data.Quality.QK_Delay_ReasonsRow);

                return list.ToArray();
            }
        }

        /// <summary>
        /// True если есть неаннулированные причины, False в противном случае
        /// </summary>
        public bool HasReasons
        {
            get
            {
                foreach (DataGridViewRow row in dgvReasons.Rows)
                    if (((row.DataBoundItem as DataRowView).Row as Data.Quality.QK_Delay_ReasonsRow).status_id.ToString() !=
                        Constants.QK_STATUS_DLRN_IS_CANCELED)
                        return true;
                return false;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ЗАГРУЗКА ПРИЧИН

        public DelayReasonsForm(long pSessionID, Data.Quality.DocsRow pDoc, bool pIsReadOnly)
        {
            InitializeComponent();
            sessionID = pSessionID;
            doc = pDoc;
            isReadOnly = pIsReadOnly;
        }

        /// <summary>
        /// True если в данный момент времени происходит загрузка причин задержки,
        /// False в противном случае (по умолчанию False)
        /// </summary>
        private bool isReasonsLoading;

        /// <summary>
        /// Причины задержки, выделенные в таблице
        /// </summary>
        private readonly List<long> selectedReasons = new List<long>();

        /// <summary>
        /// Загрузка причин задержки при запуске окна
        /// </summary>
        private void DelayReasonsForm_Load(object sender, EventArgs e)
        {
            CustomButtons();
            RefreshReasons();
        }

        /// <summary>
        /// Обновление причин задержки в таблице
        /// </summary>
        private void RefreshReasons()
        {
            tsButtons.Enabled = dgvReasons.Enabled = false;
            isReasonsLoading = true;
            SaveSelection();
            bwReasonsLoader.RunWorkerAsync();
            tmrLoadingShower.Start();
        }

        /// <summary>
        /// Сохранение идентификаторов выделенных строк для того, чтобы можно было выделить их после обновления
        /// </summary>
        private void SaveSelection()
        {
            selectedReasons.Clear();
            if (addedReason.HasValue)
                selectedReasons.Add(addedReason.Value);
            else
                foreach (var row in SelectedReasons)
                    selectedReasons.Add(row.id);

            addedReason = null;
        }

        /// <summary>
        /// Обновление причин задержки по нажатию на кнопку или пункт меню "Обновить"
        /// </summary>
        private void Refresh_Click(object sender, EventArgs e)
        {
            RefreshReasons();
        }

        /// <summary>
        /// Асинхронная загрузка причин задержки для таблицы
        /// </summary>
        private void bwReasonsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                taQkDelayReasons.Fill(quality.QK_Delay_Reasons, sessionID, doc.Doc_ID, false);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Завершение загрузки причин задержки в таблице
        /// </summary>
        private void bwReasonsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки причин задержки: ", e.Result as Exception);
                quality.QK_Delay_Reasons.Clear();
            }
            else
            {
                bsQkDelayReasons.ResetBindings(false);
                RestoreSelection();
            }

            tmrLoadingShower.Stop();
            pbSplashControl.Visible = isReasonsLoading = false;
            tsButtons.Enabled = dgvReasons.Enabled = true;
        }

        /// <summary>
        /// Выделение строк, которые были выделены перед обновлением данных в таблице 
        /// (если было действие добавления причины задержки, то выделяем только добавленную причину)
        /// </summary>
        private void RestoreSelection()
        {
            dgvReasons.ClearSelection();
            foreach (DataGridViewRow dgvrow in dgvReasons.Rows)
                if (selectedReasons.Contains(((dgvrow.DataBoundItem as DataRowView).Row as Data.Quality.QK_Delay_ReasonsRow).id))
                    dgvrow.Selected = true;
            if (dgvReasons.SelectedRows.Count == 0 && dgvReasons.Rows.Count > 0)
                dgvReasons.Rows[0].Selected = true;
        }

        /// <summary>
        /// Если загрузка продолжается слишком долго, отображаем индикатор загрузки
        /// </summary>
        private void tmrLoadingShower_Tick(object sender, EventArgs e)
        {
            if (isReasonsLoading)
            {
                pbSplashControl.Visible = true;
                tmrLoadingShower.Stop();
            }
        }

        /// <summary>
        /// Обновление доступности кнопок при изменении выделенных записей в таблице
        /// </summary>
        private void dgvReasons_SelectionChanged(object sender, EventArgs e)
        {
            CustomButtons();
            tbxDescription.Text = (dgvReasons.SelectedRows.Count != 1 || SelectedReasons[0].IsdescriptionNull()) ? String.Empty :
                SelectedReasons[0].description;
        }

        /// <summary>
        /// Настройка доступности кнопок в зависимости от выбранной причины задержки
        /// </summary>
        private void CustomButtons()
        {
            btnNewReason.Enabled = miNewReason.Enabled = !isReadOnly;
            btnEditDescription.Enabled = miEditDescription.Enabled = !isReadOnly && dgvReasons.SelectedRows.Count == 1;

            bool canClose = true;
            foreach (var reason in SelectedReasons)
                if (reason.status_id.ToString() != Constants.QK_STATUS_DLRN_IS_CREATED)
                {
                    canClose = false;
                    break;
                }

            btnResolveReason.Enabled = miResolveReason.Enabled = btnCancelReason.Enabled = miCancelReason.Enabled =
                !isReadOnly && canClose && dgvReasons.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Пустой метод - только для того, чтобы не показывать странное сообщение об ошибке
        /// </summary>
        private void dgvReasons_DataError(object sender, DataGridViewDataErrorEventArgs e) { }

        /// <summary>
        /// Раскрашивание причин в таблице в зависимости от статуса
        /// </summary>
        private void dgvReasons_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvReasons.Rows)
            {
                var diffRow = (row.DataBoundItem as DataRowView).Row as Data.Quality.QK_Delay_ReasonsRow;
                Color clr;
                if (diffRow.status_id.ToString() == Constants.QK_STATUS_DLRN_IS_CREATED)
                    clr = Color.FromArgb(255, 153, 153);
                else if (diffRow.status_id.ToString() == Constants.QK_STATUS_DLRN_IS_RESOLVED)
                    clr = Color.FromArgb(153, 204, 102);
                else
                    clr = Color.FromArgb(204, 204, 204);
                for (int c = 0; c < row.Cells.Count; c++)
                    row.Cells[c].Style.BackColor = row.Cells[c].Style.SelectionForeColor = clr;
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ И ЗАКРЫТИЕ ПРИЧИН

        /// <summary>
        /// Идентификатор только что добавленной причины задержки или null, 
        /// если после последнего добавления причины задержки произошло хотя бы одно обновление таблицы
        /// </summary>
        private long? addedReason = null;

        /// <summary>
        /// Добавление новой причины задержки
        /// </summary>
        private void NewReason_Click(object sender, EventArgs e)
        {
            try
            {
                var newReasonForm = new NewDelayReasonForm(sessionID, doc.Doc_ID, doc.Vendor_Name) { Owner = this };
                if (newReasonForm.ShowDialog() == DialogResult.OK)
                    addedReason = Convert.ToInt64(taQkDelayReasons.InsertDelayReason(sessionID, doc.Doc_ID,
                        newReasonForm.ReasonTypeID, newReasonForm.Description, newReasonForm.GspoTask));
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при добавлении причины задержки: ", exc);
            }
            finally
            {
                RefreshReasons();
            }
        }

        /// <summary>
        /// Закрытие (решение или аннулирование причины задержки)
        /// </summary>
        private void CloseReason_Click(object sender, EventArgs e)
        {
            bool resolve = sender == btnResolveReason || sender == miResolveReason;
            string question = resolve ? "Вы точно хотите отметить причину как решенную?" : "Вы точно хотите аннулировать причину задержки?";
            if (MessageBox.Show(question, "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    string statusID = resolve ? Constants.QK_STATUS_DLRN_IS_RESOLVED : Constants.QK_STATUS_DLRN_IS_CANCELED;
                    foreach (var reason in SelectedReasons)
                        taQkDelayReasons.ChangeDelayReasonStatus(sessionID, reason.id, Convert.ToInt32(statusID), null);
                }
                catch (Exception exc)
                {
                    string s = resolve ? "закрытия" : "аннулирования";
                    Logger.ShowErrorMessageBox(String.Format("Возникла ошибка во время {0} причины задержки:", s), exc);
                }
                finally
                {
                    RefreshReasons();
                }
        }

        #endregion

        #region ИЗМЕНЕНИЕ ОПИСАНИЯ ПРИЧИНЫ ЗАДЕРЖКИ

        /// <summary>
        /// Редактирование описания причины задержки по нажатию на кнопку или пункт контекстного меню
        /// </summary>
        private void EditDescription_Click(object sender, EventArgs e)
        {
            EditDescription();
        }

        /// <summary>
        /// Редактирование описания для причины задержки, выделенной в таблице
        /// </summary>
        private void EditDescription()
        {
            var commentWindow = new CommentForm(false)
            {
                CommentLabel = "Описание:",
                Comment = SelectedReasons[0].IsdescriptionNull() ? String.Empty : SelectedReasons[0].description,
                Text = "Изменение описания"
            };
            if (commentWindow.ShowDialog(this) == DialogResult.OK)
                try
                {
                    taQkDelayReasons.ChangeDelayReasonStatus(sessionID, SelectedReasons[0].id, null, commentWindow.Comment);
                }
                catch (Exception exc)
                {
                    Logger.ShowErrorMessageBox("Во время сохранения описания в БД произошла ошибка: ", exc);
                }
                finally
                {
                    RefreshReasons();
                }
        }

        /// <summary>
        /// Редактирование описания выбранной причины задержки по двойному щелчку мышкой
        /// </summary>
        private void dgvReasons_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (SelectedReasons.Length == 1 && !isReadOnly)
                EditDescription();
        }

        #endregion
    }
}
