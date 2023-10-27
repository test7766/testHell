using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// 
    /// </summary>
    public partial class BlockDocsApproveForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Признак, показывающий, был ли подтвержден/отклонен хотя бы один документ
        /// </summary>
        public bool WasChanges { get; private set; }

        /// <summary>
        /// Выделенный в таблице документ блокировок либо null, если в таблице не выбран никакой документ
        /// </summary>
        private Data.Quality.BL_Get_Docs_ApprovedRow SelectedRow
        {
            get
            {
                if (dgvDocs.SelectedRows.Count == 0)
                    return null;
                else
                    return (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as
                        Data.Quality.BL_Get_Docs_ApprovedRow;
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public BlockDocsApproveForm(long pSessionID)
        {
            InitializeComponent();
            sessionID = pSessionID;
        }

        /// <summary>
        /// Загрузка неподтвержденных документов при загрузке окна
        /// </summary>
        private void BlockDocsApproveForm_Load(object sender, EventArgs e)
        {
            StartDocsLoading();
        }

        /// <summary>
        /// Начало асинхронной загрузки документов для подтверждения
        /// </summary>
        private void StartDocsLoading()
        {
            if (!bgwDocsLoader.IsBusy)
            {
                pbLoading.Visible = true;
                spcTwoGrids.Enabled = false;
                bgwDocsLoader.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Асинхронная загрузка данных в таблицу неподтвержденных документов
        /// </summary>
        private void bgwDocsLoader_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                taBlGetDocsApproved.Fill(quality.BL_Get_Docs_Approved, sessionID);
            }
            catch (Exception exc)
            {
                e.Result = exc;
            }
        }

        /// <summary>
        /// Окончание асинхронной загрузки неподтвержденных документов - и отображение ошибки, если она есть
        /// </summary>
        private void bgwDocsLoader_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is Exception)
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки неподтвержденных документов: ", e.Result as Exception);

            pbLoading.Visible = false;
            spcTwoGrids.Enabled = true;
            bsBlGetDocsApproved.ResetBindings(false);
        }

        /// <summary>
        /// Обновление документов для подтверждения при выборе соответствующего пункта меню
        /// </summary>
        private void miRefreshDocs_Click(object sender, EventArgs e)
        {
            StartDocsLoading();
        }

        /// <summary>
        /// Загрузка деталей при изменении выделенного документа
        /// </summary>
        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (SelectedRow == null)
                    quality.BL_Get_Docs_Approved_Detail.Clear();
                else
                    taBlGetDocsApprovedDetail.Fill(quality.BL_Get_Docs_Approved_Detail, sessionID, SelectedRow.Doc_ID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки неподтвержденных блокировок в документе: ", exc);
            }
        }

        /// <summary>
        /// Инициализация надписей на кнопках
        /// </summary>
        private void dgvDocs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvDocs.Rows)
            {
                dgvRow.Cells[clApprove.Index].Value = "Подтвердить";
                dgvRow.Cells[clReject.Index].Value = "Отклонить!";
            }
        }

        #endregion

        #region УТВЕРЖДЕНИЕ ДОКУМЕНТОВ

        /// <summary>
        /// Щелчок по кнопке - утверждение/отклонение документов
        /// </summary>
        private void dgvDocs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == clApprove.Index || e.ColumnIndex == clReject.Index)
                try
                {
                    var dgvRow = dgvDocs.Rows[e.RowIndex];
                    var dbRow = (dgvRow.DataBoundItem as DataRowView).Row as Data.Quality.BL_Get_Docs_ApprovedRow;
                    taBlGetDocsApproved.ApproveDoc(sessionID, dbRow.Doc_ID, e.ColumnIndex == clApprove.Index ? 1 : 0,
                        (dgvRow.Cells[clComment.Index].Value == null || dgvRow.Cells[clComment.Index].Value == DBNull.Value) ?
                        null : dgvRow.Cells[clComment.Index].Value.ToString(), DateTime.Now);
                    dbRow.Delete();
                    quality.BL_Get_Docs_Approved.AcceptChanges();
                    WasChanges = true;
                }
                catch (Exception exc)
                {

                    Logger.ShowErrorMessageBox(String.Format("Возникла ошибка во время {0} документа блокировки: ",
                        e.ColumnIndex == clApprove.Index ? "подтверждения" : "отклонения"), exc);
                }
        }

        #endregion
    }
}
