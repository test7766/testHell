using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Отображает информацию о этапах обработки претензии (визах, ...) и предоставляет признаки доступности действий с выбранной претензией.
    /// </summary>
    public partial class DocStagesInfo : UserControl
    {
        /// <summary>
        /// Инициализирует новый экземпляр элемента управления.
        /// </summary>
        public DocStagesInfo()
        {
            InitializeComponent();

            new ToolTip().SetToolTip(btnMoveToPreviousLevelStages, "На уровень выше");
            RefreshInfo(0, (long?)null);
        }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии просматривать список файлов, прикрепленных к выбранной претензии.
        /// </summary>
        public bool CanSeeAttachments { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии анализировать состав выбранной претензии.
        /// </summary>
        public bool CanAnalyze { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии делать запросы на снятие остатков для выбранной претензии.
        /// </summary>
        public bool CanAddTakingRemainsRequest { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии вводить результаты снятия остатков по выбранной претензии.
        /// </summary>
        public bool CanEnterTakingRemainsResults { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии корректировать выбранную претензию.
        /// </summary>
        public bool CanEdit { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сесии менять код виновного сотрудника по выбранной претензии.
        /// </summary>
        public bool CanChangeCommonFaultEmployee { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии поставить положительную визу по выбранной претензию.
        /// </summary>
        public bool CanAccept { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии поставить отрицательную визу по выбранной претензии.
        /// </summary>
        public bool CanDecline { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии сохранить только комментарий
        /// (без конкретного результата визирования, т.е. "отложенная виза") по выбранной претензии.
        /// </summary>
        public bool CanComment { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии запрашивать опытные образцы по выбранной претензии.
        /// </summary>
        public bool CanRequestSample { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии ставить визу "Отклонено заводом" по выбранной претензии.
        /// </summary>
        public bool CanDeclineByFactory { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии ставить признак "Письмо клиенту отправлено" по выбранной претензии.
        /// </summary>
        public bool CanSetClientLetterSent { get; private set; }

        /// <summary>
        /// Возвращает признак, показывающий, может ли пользователь текущей сессии восстановить выбранную отклоненную претензию.
        /// </summary>
        public bool CanRestoreDeclined { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии построчно визировать выбранную претензию
        /// </summary>
        public bool CanLineSight { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии редактировать номер камеры и дату обнаружения проблемы
        /// </summary>
        public bool CanEnterCameraInfo { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии запрашивать повторный фотоотчет
        /// </summary>
        public bool CanRequestAttachment { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии изменять полку, на которую нужно положить товар
        /// </summary>
        public bool CanChangeLocation { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии списывать недостачу на водителя
        /// </summary>
        public bool CanSetShortageOnDriver { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии отклонять предыдущую визу
        /// </summary>
        public bool CanClearPreviousVisa { get; private set; }


        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии обрабатывать журнал исключений созданных претензий
        /// </summary>
        public bool CanAccessCheckExceptionsLog { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии формировать протокол расследований
        /// </summary>
        public bool CanPrintInvestigationReport { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии просматривать документы выбранной претензии
        /// </summary>
        public bool CanCheckExternalDocs { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь текущей сессии исправлять документ
        /// </summary>
        public bool CanSetRevision { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь выбирать из списка причину утверждения документа
        /// </summary>
        public bool CanAcceptRework { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь выбирать из списка причину отклонения документа
        /// </summary>
        public bool CanDeclineRework { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь назначать задание
        /// </summary>
        public bool CanAssignTask { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь взять задание
        /// </summary>
        public bool CanStartTask { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь отложить задание
        /// </summary>
        public bool CanDelayTask { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь закрыть задание
        /// </summary>
        public bool CanCloseTask { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь создать акт поставщику
        /// </summary>
        public bool CanCreateVendorAct { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь отправить акт поставщику
        /// </summary>
        public bool CanSendVendorAct { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь формировать служебную записку
        /// </summary>
        public bool CanPrintLogisticsComplaintsReport { get; private set; }

        /// <summary>
        /// Номер служебной записки
        /// </summary>
        public string MemoNumber { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь просматривать параметры уведомления по отзыву
        /// </summary>
        public bool CanShowRecallNotification { get; private set; }

        /// <summary>
        /// Идентификатор документа распоряжения ГЛС
        /// </summary>
        public int? RecallNotificationDocID { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать реестр лек. средств
        /// </summary>
        public bool CanPrintMedicalRegister { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь менять фактическую серию
        /// </summary>
        public bool CanChangeFactLotn { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь печатать акт приема-передачи
        /// </summary>
        public bool CanPrintAcceptanceCert { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь подтверждать брак
        /// </summary>
        public bool CanConfirmDefects { get; private set; }

        /// <summary>
        /// Признак, показывающий, нужно ли добавлять вложения
        /// </summary>
        public bool NeedAttachments { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять пролонгацию визы
        /// </summary>
        public bool CanChangeExpirationDate { get; private set; }

        /// <summary>
        /// Признак, показывающий, может ли пользователь отправлять на доработку клиенту
        /// </summary>
        /// <returns></returns>
        public bool CheckCanClientRework()
        {
            return complaints.DocStages.Count > 0 ? complaints.DocStages[complaints.DocStages.Count - 1].Group_ID.Equals(11) : false; // 11 - ОМУ
        }

        /// <summary>
        /// Признак, показывающий, может ли пользователь выполнять отгрузку без Промо
        /// </summary>
        /// <returns></returns>
        public bool CheckCanShipmentWithoutPromo()
        {
            return complaints.DocStages.Count > 0 ? complaints.DocStages[complaints.DocStages.Count - 1].Group_ID.Equals(999) : false; // 999 - Система
        }

        /// <summary>
        /// Обновляет информацию о этапах обработки и доступности действий по выбранной претензии.
        /// </summary>
        /// <param name="sessionID">Идентификатор текущей пользовательской сессии.</param>
        /// <param name="docID">Идентификатор документа претензии.</param>
        public void RefreshInfo(long sessionID, long? docID)
        {
            btnMoveToPreviousLevelStages.Enabled = false;

            complaints.DocStages.Clear();

            this.CanSeeAttachments =
                this.CanAnalyze =
                this.CanAddTakingRemainsRequest =
                this.CanEnterTakingRemainsResults =
                this.CanEdit =
                this.CanChangeCommonFaultEmployee =
                this.CanAccept =
                this.CanDecline =
                this.CanComment =
                this.CanRequestSample =
                this.CanDeclineByFactory =
                this.CanSetClientLetterSent = 
                this.CanRestoreDeclined = 
                this.CanLineSight = 
                this.CanEnterCameraInfo =
                this.CanRequestAttachment = 
                this.CanChangeLocation = 
                this.CanSetShortageOnDriver = 
                this.CanClearPreviousVisa = 
                this.CanAccessCheckExceptionsLog =
                this.CanPrintInvestigationReport =
                this.CanCheckExternalDocs =
                this.CanSetRevision =
                this.CanAcceptRework =
                this.CanDeclineRework = 
                this.CanAssignTask = 
                this.CanStartTask = 
                this.CanDelayTask = 
                this.CanCloseTask =
                this.CanCreateVendorAct =
                this.CanSendVendorAct =
                this.CanPrintLogisticsComplaintsReport =
                this.CanShowRecallNotification =
                this.CanPrintMedicalRegister = 
                this.CanChangeFactLotn = 
                this.CanPrintAcceptanceCert = 
                this.CanConfirmDefects =
                this.NeedAttachments =
                this.CanChangeExpirationDate = false;

                this.MemoNumber = null;

            if (sessionID > 0 && docID.HasValue)
            {
                using (Data.ComplaintsTableAdapters.DocStagesTableAdapter adapter = new Data.ComplaintsTableAdapters.DocStagesTableAdapter())
                {
                    var table = complaints.DocStages;
                    adapter.Fill(table, sessionID, docID);

                    if (table != null && table.Count > 0)
                    {
                        SetFlags(table[0]);

                        dgvStages.Rows[0].Selected = false;
                    }
                }
            }
        }

        /// <summary>
        ///  Обновляет информацию по позициям этапа визирования выбранной претензии
        /// </summary>
        /// <param name="sessionID">Идентификатор текущей пользовательской сессии.</param>
        /// <param name="stageID">Идентификатор документа этапа визирования претензии</param>
        public void RefreshInfoDetails(long sessionID, long? stageID)
        {
            btnMoveToPreviousLevelStages.Enabled = true;

            complaints.DocStages.Clear();

            if (sessionID > 0 && stageID.HasValue)
            {
                using (Data.ComplaintsTableAdapters.DocStagesTableAdapter adapter = new Data.ComplaintsTableAdapters.DocStagesTableAdapter())
                {
                    var table = complaints.DocStages;
                    adapter.FillDetailsData(table, sessionID, stageID);

                    if (table != null && table.Count > 0)
                        dgvStages.Rows[0].Selected = false;
                }
            }
        }

        /// <summary>
        /// Устанавливает признаки доступности действий с выбранной претензией по данным из первой строки таблицы.
        /// </summary>
        /// <param name="firstRow">Ссылка на первую строку таблицы.</param>
        private void SetFlags(Data.Complaints.DocStagesRow firstRow)
        {
            this.CanSeeAttachments = firstRow.IsCanSeeAttachmentsNull() ? false : firstRow.CanSeeAttachments;
            this.CanAnalyze = firstRow.IsCanAnalyzeNull() ? false : firstRow.CanAnalyze;
            this.CanAddTakingRemainsRequest = firstRow.IsCanAddTakingRemainsRequestNull() ? false : firstRow.CanAddTakingRemainsRequest;
            this.CanEnterTakingRemainsResults = firstRow.IsCanEnterTakingRemainsResultsNull() ? false : firstRow.CanEnterTakingRemainsResults;
            this.CanEdit = firstRow.IsCanEditNull() ? false : firstRow.CanEdit;
            this.CanChangeCommonFaultEmployee = firstRow.IsCanChangeCommonFaultEmployeeNull() ? false : firstRow.CanChangeCommonFaultEmployee;
            this.CanAccept = firstRow.IsCanAcceptNull() ? false : firstRow.CanAccept;
            this.CanDecline = firstRow.IsCanDeclineNull() ? false : firstRow.CanDecline;
            this.CanComment = firstRow.IsCanCommentNull() ? false : firstRow.CanComment;
            this.CanRequestSample = firstRow.IsCanRequestSampleNull() ? false : firstRow.CanRequestSample;
            this.CanDeclineByFactory = firstRow.IsCanDeclineByFactoryNull() ? false : firstRow.CanDeclineByFactory;
            this.CanSetClientLetterSent = firstRow.IsCanSetClientLetterSentNull() ? false : firstRow.CanSetClientLetterSent;
            this.CanRestoreDeclined = firstRow.IsCanRestoreDeclinedNull() ? false : firstRow.CanRestoreDeclined;
            this.CanLineSight = firstRow.IsCanLineSightComplaintNull() ? false : firstRow.CanLineSightComplaint;
            this.CanEnterCameraInfo = firstRow.IsCanEnterCameraInfoNull() ? false : firstRow.CanEnterCameraInfo;
            this.CanRequestAttachment = firstRow.IsCanRequestAttachmentNull() ? false : firstRow.CanRequestAttachment;
            this.CanChangeLocation = firstRow.IsCanChangeLocationNull() ? false : firstRow.CanChangeLocation;
            this.CanSetShortageOnDriver = firstRow.IsCanSetShortageToDriverNull() ? false : firstRow.CanSetShortageToDriver;
            this.CanClearPreviousVisa = firstRow.IsCanClearPreviousVisaNull() ? false : firstRow.CanClearPreviousVisa;
            this.CanAccessCheckExceptionsLog = firstRow.IsCanAccessCheckExceptionsLogNull() ? false : firstRow.CanAccessCheckExceptionsLog;
            this.CanPrintInvestigationReport = firstRow.IsCanPrintInvestigationReportNull() ? false : firstRow.CanPrintInvestigationReport;
            this.CanCheckExternalDocs = firstRow.IsCanCheckExternalDocsNull() ? false : firstRow.CanCheckExternalDocs;
            this.CanSetRevision = firstRow.IsCanSetRevisionNull() ? false : firstRow.CanSetRevision;
            this.CanAcceptRework = firstRow.IsCanAcceptReworkNull() ? false : firstRow.CanAcceptRework;
            this.CanDeclineRework = firstRow.IsCanDeclineReworkNull() ? false : firstRow.CanDeclineRework;
            this.CanAssignTask = firstRow.IsCanAssignTaskNull() ? false : firstRow.CanAssignTask;
            this.CanStartTask = firstRow.IsCanStartTaskNull() ? false : firstRow.CanStartTask;
            this.CanDelayTask = firstRow.IsCanDelayTaskNull() ? false : firstRow.CanDelayTask;
            this.CanCloseTask = firstRow.IsCanCloseTaskNull() ? false : firstRow.CanCloseTask;
            this.CanCreateVendorAct = firstRow.IsCanCreateVendorActNull() ? false : firstRow.CanCreateVendorAct;
            this.CanSendVendorAct = firstRow.IsCanSendVendorActNull() ? false : firstRow.CanSendVendorAct;

            this.CanPrintLogisticsComplaintsReport = firstRow.IsMemo_NumberNull() || string.IsNullOrEmpty(firstRow.Memo_Number) ? false : true;
            this.MemoNumber = this.CanPrintLogisticsComplaintsReport ? firstRow.Memo_Number : (string)null;

            this.CanShowRecallNotification = firstRow.IsMoz_Doc_IDNull() ? false : true;
            this.RecallNotificationDocID = this.CanShowRecallNotification ? firstRow.Moz_Doc_ID : (int?)null;

            this.CanPrintMedicalRegister = firstRow.IsCanPrintLSReestrNull() ? false : firstRow.CanPrintLSReestr;
            this.CanChangeFactLotn = firstRow.IsCanChangeFactLotnNull() ? false : firstRow.CanChangeFactLotn;

            this.CanPrintAcceptanceCert = firstRow.IsCanPrintAcceptanceCertNull() ? false : firstRow.CanPrintAcceptanceCert;
            this.CanConfirmDefects = firstRow.IsCanConfirmDefectsNull() ? false : firstRow.CanConfirmDefects;

            this.NeedAttachments = firstRow.IsNeedAttachmentsNull() ? false : firstRow.NeedAttachments;
            this.CanChangeExpirationDate = firstRow.IsCanChangeExpirationDateNull() ? false : firstRow.CanChangeExpirationDate;
        }

        private void dgvStages_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dgvStages.SelectedRows.Count > 0)
            {
                var docStageInfo = (dgvStages.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.DocStagesRow;
                if (docStageInfo != null)
                {
                    var canCheckVisaDetails = docStageInfo.IsCanCheckVisaDetailsNull() ? false : docStageInfo.CanCheckVisaDetails;
                    if (canCheckVisaDetails)
                    {
                        var stageID = docStageInfo.Stage_ID;
                        this.RaiseNeedDocStageDetails(stageID);
                    }
                }
            }
        }

        private void btnMoveToPreviousLevelStages_Click(object sender, EventArgs e)
        {
            this.RaiseNeedPreviousLevelStages();
        }

        private void cmsStages_Opening(object sender, CancelEventArgs e)
        {
            var docStageInfo = dgvStages.SelectedRows.Count > 0 ? (dgvStages.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.DocStagesRow : null;
            cmsiAcceptComplaintFromStage.Enabled = docStageInfo != null && !docStageInfo.IsCanAcceptFromStageNull() && docStageInfo.CanAcceptFromStage;
        }

        private void cmsiAcceptComplaintFromStage_Click(object sender, EventArgs e)
        {
            var docStageInfo = (dgvStages.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.DocStagesRow;
            
            var stageID = docStageInfo.Stage_ID;
            this.RaiseAcceptComplaintFromStage(stageID);
        }

        public event EventHandler<NeedDocStageDetailsEventArgs> OnNeedDocStageDetails;
        public class NeedDocStageDetailsEventArgs : EventArgs
        {
            public long StageID { get; private set; }
            public NeedDocStageDetailsEventArgs(long stageID)
            {
                this.StageID = stageID;
            }
        }

        public void RaiseNeedDocStageDetails(long stageID)
        {
            var handler = OnNeedDocStageDetails;
            if (handler != null)
                handler(this, new NeedDocStageDetailsEventArgs(stageID));
        }

        public event EventHandler OnNeedPreviousLevelStages;
        public void RaiseNeedPreviousLevelStages()
        {
            var handler = OnNeedPreviousLevelStages;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }


        public event EventHandler<AcceptComplaintFromStageEventArgs> OnAcceptComplaintFromStage;
        public class AcceptComplaintFromStageEventArgs : EventArgs
        {
            public long StageID { get; private set; }
            public AcceptComplaintFromStageEventArgs(long stageID)
            {
                this.StageID = stageID;
            }
        }

        public void RaiseAcceptComplaintFromStage(long stageID)
        {
            var handler = OnAcceptComplaintFromStage;
            if (handler != null)
                handler(this, new AcceptComplaintFromStageEventArgs(stageID));
        }

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        private void dgvStages_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in dgvStages.Rows)
            {
                try
                {
                    var row = (dgvRow.DataBoundItem as DataRowView).Row as Data.Complaints.DocStagesRow;

                    int imageIndex = 4; // результат этапа не определен
                    if (!row.IsStage_Result_IDNull() && (row.Stage_Result_ID == 2 || row.Stage_Result_ID == 4)) // отрицательный
                        imageIndex = 0;
                    if (!row.IsStage_Result_IDNull() && (row.Stage_Result_ID == 1 || row.Stage_Result_ID == 5)) // положительный
                        imageIndex = 1;
                    if (!row.IsStage_Result_IDNull() && row.Stage_Result_ID == 8) // частичное визирование
                        imageIndex = 3;

                    var image = imageIndex < imageList.Images.Count ? imageList.Images[imageIndex] : emptyIcon;

                    dgvRow.Cells[dgvcStageResultID.Index].Value = image;
                }
                catch (Exception ex)
                { 
                
                }
            }
        }

        private void dgvStages_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                var row = (dgvStages.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.DocStagesRow;

                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.Group_NameColumn.Caption)
                    e.Value = row.IsGroup_NameNull() ? "-" : row.Group_Name;
                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.Stage_Result_NameColumn.Caption)
                    e.Value = row.IsStage_Result_NameNull() ? "-" : row.Stage_Result_Name;
                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.CommentColumn.Caption)
                    e.Value = row.IsCommentNull() ? "-" : row.Comment;
                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.Expiration_DateColumn.Caption)
                    e.Value = row.IsExpiration_DateNull() ? "-" : row.Expiration_Date.ToString("dd.MM.yyy HH:mm:ss");
                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.Users_UpdatedColumn.Caption)
                    e.Value = row.IsUsers_UpdatedNull() ? "-" : row.Users_Updated;
                if (dgvStages.Columns[e.ColumnIndex].DataPropertyName == complaints.DocStages.Date_UpdatedColumn.Caption)
                    e.Value = row.IsDate_UpdatedNull() ? "-" : row.Date_Updated.ToString("dd.MM.yyy HH:mm:ss");
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
