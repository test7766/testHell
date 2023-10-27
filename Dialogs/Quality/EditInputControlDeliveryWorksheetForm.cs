using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using WMSOffice.Data.QualityTableAdapters;
using System.Transactions;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;
using NPOI.XSSF.UserModel;
using System.Drawing;
using System.Text;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно редактирования анкеты входного контроля поставки
    /// </summary>
    public partial class EditInputControlDeliveryWorksheetForm : Form
    {
        private readonly Dictionary<TermoMode, TermoDetailsPackage> dTermoDetailsPackage = null;
        private readonly ShipmentUnloadDatePackage unloadDatePackage = null;
        private readonly ShipmentCarNumberPackage carNumberPackage = null;

        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// True если окно открыто только для просмотра ответов, False если для редактирования
        /// </summary>
        private bool isReadOnlyMode;

        /// <summary>
        /// True если разрешено добавлять вложения, False иначе
        /// </summary>
        private bool canAttachFiles;

        /// <summary>
        /// True если разрешено подтверждать вложения, False иначе
        /// </summary>
        private bool canApproveAttachments;

        /// <summary>
        /// Анкета, которая редактируется
        /// </summary>
        private readonly Data.Quality.AP_DocsRow doc;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public EditInputControlDeliveryWorksheetForm(long pSessionID, Data.Quality.AP_DocsRow pDoc, bool isReadOnly)
        {
            InitializeComponent();
            sessionID = pSessionID;
            doc = pDoc;

            dTermoDetailsPackage = new Dictionary<TermoMode, TermoDetailsPackage>();
            unloadDatePackage = new ShipmentUnloadDatePackage()
            {
                UnloadDate = pDoc.Isunloading_event_dateNull() ? (DateTime?)null : pDoc.unloading_event_date,
                NotYetUnloaded = pDoc.Isnot_yet_unloadedNull() ? false : pDoc.not_yet_unloaded
            };
            carNumberPackage = new ShipmentCarNumberPackage()
            {
                 CarNumber = pDoc.Iscar_numberNull() ? (string)null : pDoc.car_number,
                 TrailerNumber = pDoc.IstrailerNull() ? (string)null : pDoc.trailer
            };

            if (isReadOnly)
                EnanleReadOnlyMode();
        }

        /// <summary>
        /// Переключение окна в режим "Только просмотр"
        /// </summary>
        private void EnanleReadOnlyMode()
        {
            isReadOnlyMode = true;

            btnAddFile.Enabled = btnDeleteFile.Enabled = false;

            btnSave.Visible = false;
            btnCancel.Text = "Закрыть";

            miGenerateRightAnswers.Enabled = false;

            TermoMode.ReadOnly = true;
            TermoMode.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            DirectoryType.ReadOnly = true;
            DirectoryType.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            EquipmentType.ReadOnly = true;
            EquipmentType.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            EquipmentNumber.ReadOnly = true;

            Text += " (режим просмотра)";
        }

        /// <summary>
        /// Загрузка вопросов анкеты при загрузке окна
        /// </summary>
        private void EditInputControlDeliveryWorksheetForm_Load(object sender, EventArgs e)
        {
            FillMainInfo();
            LoadQuestions();
            LoadAdditionalInfo();
            LoadAttachments();
        }

        /// <summary>
        /// Вывод основной информации по анкете в текстовые поля в окне
        /// </summary>
        private void FillMainInfo()
        {
            tbxCarNumber.Text = doc.Iscar_numberNull() ? string.Empty : doc.car_number;
            tbxTrailerNumber.Text = doc.IstrailerNull() ? string.Empty : doc.trailer;
            tbxDocNumber.Text = doc.doc_id.ToString();
            tbxVersionNumber.Text = doc.version_id.ToString();
            tbxDeliveryID.Text = doc.delivery_id.ToString();
            tbxVendor.Text = doc.vendor;
            tbxDocDate.Text = doc.doc_date.ToString();
            tbxVersionDate.Text = doc.version_date.ToString();
            tbxVersionStatus.Text = doc.status;
            tbxVersionUser.Text = doc.Isuser_createdNull() ? "Система" : doc.user_created;
        }

        /// <summary>
        /// Загрузка вопросов по анкете с текущими ответами
        /// </summary>
        private void LoadQuestions()
        {
            try
            {
                taApVersionQuestions.Fill(quality.AP_Version_Questions, sessionID, doc.doc_id, doc.version_id, null);

                if (dgvQuestionGroup1.Rows.Count > 0)
                    dgvQuestionGroup1.Rows[0].Selected = false;

                if (dgvQuestionGroup2.Rows.Count > 0)
                    dgvQuestionGroup2.Rows[0].Selected = false;

                if (dgvQuestionGroup4.Rows.Count > 0)
                    dgvQuestionGroup4.Rows[0].Selected = false;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при загрузке вопросов по анкете: ", exc);
            }
        }

        /// <summary>
        /// Загрузка дополнительной информации по анкете (кто и когда редактировал отдельные части анкеты)
        /// </summary>
        private void LoadAdditionalInfo()
        {
            try
            {
                taApGetWorksheetReportHeader.Fill(quality.AP_Get_Worksheet_Report_Header, sessionID, doc.doc_id, doc.version_id);
                if (quality.AP_Get_Worksheet_Report_Header.Count == 0)
                    Logger.ShowErrorMessageBox("Ошибка: процедура получения дополнительной информации по анкете не вернула данные!");
                else
                {
                    var row = quality.AP_Get_Worksheet_Report_Header[0];

                    if (!row.Isdate_created1Null())
                        tbxEditingDate1.Text = row.date_created1.ToString();

                    if (!row.Isuser1Null())
                        tbxUser1.Text = row.user1;

                    if (!row.Isdate_created2Null())
                        tbxEditingDate2.Text = row.date_created2.ToString();

                    if (!row.Isuser2Null())
                        tbxUser2.Text = row.user2;

                    if (!row.Isdate_created3Null())
                        tbxEditingDate3.Text = row.date_created3.ToString();

                    if (!row.Isuser3Null())
                        tbxUser3.Text = row.user3;

                    if (!row.Isdate_created4Null())
                        tbxEditingDate4.Text = row.date_created4.ToString();

                    if (!row.Isuser4Null())
                        tbxUser4.Text = row.user4;

                    if (!row.IsLicenseNull())
                        tbxLicenseInfo.Text = row.License;

                    if (!row.IsStatusLicenseNull())
                        tbxLicenseStatus.Text = row.StatusLicense;

                    if ((canAttachFiles = (row.IsCanModifyNull() ? false : row.CanModify)))
                    {
                        if (isReadOnlyMode) // вернем доступ для работы с вложениями
                        {
                            TermoMode.ReadOnly = false;
                            TermoMode.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

                            DirectoryType.ReadOnly = false;
                            DirectoryType.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

                            EquipmentType.ReadOnly = false;
                            EquipmentType.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton;

                            EquipmentNumber.ReadOnly = false;

                            btnSave.Visible = true;
                            btnCancel.Text = "Отмена";

                            Text += " - корректировка вложений";
                        }
                    }

                    if (canApproveAttachments = (row.IsCanApproveAttachmentsNull() ? false : row.CanApproveAttachments))
                    {
                        if (isReadOnlyMode) // вернем доступ к сохранению
                        {
                            btnSave.Visible = true;
                            btnCancel.Text = "Отмена";

                            Text += " - подтверждение вложений";
                        }
                    }

                    clYesT.Visible = canApproveAttachments;
                    clNoT.Visible = canApproveAttachments;
                    clNullT.Visible = canApproveAttachments;
                }                
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки дополнительной информации по анкете: ", exc);
            }
        }

        private void LoadAttachments()
        {
            try
            {
                aP_Termo_ModesTableAdapter.Fill(quality.AP_Termo_Modes);

                aP_File_Types_DirectoryTableAdapter.Fill(quality.AP_File_Types_Directory, sessionID, (string)null);

                aP_Equipment_TypesTableAdapter.Fill(quality.AP_Equipment_Types, sessionID, (string)null);

                var blankTermoModesRow = quality.AP_Termo_Modes.NewAP_Termo_ModesRow();
                blankTermoModesRow.Mode_ID = (byte)0;
                blankTermoModesRow.Mode_Name = "(отсутствует)";
                blankTermoModesRow.Min_Temp = 0;
                blankTermoModesRow.Max_Temp = 0;
                blankTermoModesRow.Mode_Key = string.Empty;
                quality.AP_Termo_Modes.Rows.InsertAt(blankTermoModesRow, 0);

                var blankFileTypesRow = quality.AP_File_Types_Directory.NewAP_File_Types_DirectoryRow();
                blankFileTypesRow.ID = 0;
                blankFileTypesRow.TypeDesc = "(отсутствует)";
                quality.AP_File_Types_Directory.Rows.InsertAt(blankFileTypesRow, 0);

                var blankEquipmentTypesRow = quality.AP_Equipment_Types.NewAP_Equipment_TypesRow();
                blankEquipmentTypesRow.ID = 0;
                blankEquipmentTypesRow.TypeDesc = "(отсутствует)";
                quality.AP_Equipment_Types.Rows.InsertAt(blankEquipmentTypesRow, 0);

                aP_Get_AttachmentsTableAdapter.Fill(quality.AP_Get_Attachments, sessionID, doc.doc_id, doc.version_id);

                if (dgvAttachments.Rows.Count > 0)
                    dgvAttachments.Rows[0].Selected = false;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки вложений по анкете: ", exc);
            }
            finally
            {
                this.SetAttachmentsOperationsAccess();
            }
        }

        private void dgvQuestionGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            var dgv = sender as DataGridView;
            foreach (DataGridViewRow dgvr in dgv.Rows)
            {
                var row = (dgvr.DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_QuestionsRow;
                if (!row.Isneed_detailed_answerNull() && row.need_detailed_answer)
                {
                    

                    var cell = dgvr.Cells[0] as DataGridViewButtonCell;
                    cell.Value = "...";
                    cell.ToolTipText = "Просмотр развернутого ответа";
                    dgvr.Tag = "...";
                }
                else
                {
                    dgvr.Cells[0].Style = new DataGridViewCellStyle { Padding = new Padding(dgvr.Cells[0].OwningColumn.Width, 0, 0, 0) };
                }
            }
        }

        private void dgvQuestionGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var dgv = sender as DataGridView;
            var row = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_QuestionsRow;

            e.CellStyle.BackColor = row.question_type_id % 2 == 0 ? ColorTranslator.FromHtml("#ffe6e6e6") : e.CellStyle.BackColor;
        }

        #endregion

        #region РЕДАКТИРОВАНИЕ АНКЕТЫ И СОХРАНЕНИЕ РЕЗУЛЬТАТА

        /// <summary>
        /// В этом методе достигается взаимоисключение ответов
        /// </summary>
        private void dgvQuestionGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var dgv = sender as DataGridView;
            var row = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Version_QuestionsRow;

            if (dgv.Rows[e.RowIndex].Tag != null)
            {
                if (dgv.Columns[e.ColumnIndex] == clShowEditor1 || dgv.Columns[e.ColumnIndex] == clShowEditor2 || dgv.Columns[e.ColumnIndex] == clShowEditor4)
                {
                    foreach (TermoMode tm in Enum.GetValues(typeof(TermoMode)))
                    {
                        #region ИЗМЕНЕНИЕ ДАТЫ РАЗГРУЗКИ
                        if (row.question_id == 25)
                        {
                            var editor = new InputControlDeliveryWorksheetUnloadDateEditForm(unloadDatePackage, isReadOnlyMode);
                            if (editor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                var checkFlag = !unloadDatePackage.NotYetUnloaded;
                                row.yes = checkFlag;
                                row.no = !checkFlag;
                                row._null = false;
                            }

                            return;
                        }
                        #endregion

                        #region ИЗМЕНЕНИЕ НОМЕРА АВТО / ПОЛУПРИЦЕПА
                        if (row.question_id == 26)
                        {
                            var editor = new InputControlDeliveryWorksheetCarNumberEditForm(carNumberPackage, isReadOnlyMode);
                            if (editor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                            {
                                var checkFlag = !string.IsNullOrEmpty(carNumberPackage.CarNumber);
                                row.yes = checkFlag;
                                row.no = !checkFlag;
                                row._null = false;
                            }

                            return;
                        }
                        #endregion

                        #region ИЗМЕНЕНИЯ ТЕМПЕРАТУРЫ С ДАТЧИКОВ
                        if (tm.Equals((TermoMode)row.question_id))
                        {
                            TermoDetailsPackage tmPackage = null;

                            if (!dTermoDetailsPackage.ContainsKey(tm))
                            {
                                dTermoDetailsPackage.Add(tm, TermoDetailsPackage.Create(tm));
                                tmPackage = dTermoDetailsPackage[tm];

                                try
                                {
                                    var sensorsAreAbsent = (bool?)null;
                                    using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                        adapter.Fill(tmPackage.Cache, doc.doc_id, doc.version_id, tmPackage.TermoModeFlag, ref sensorsAreAbsent);

                                    if (sensorsAreAbsent.HasValue)
                                        tmPackage.SensorsAreAbsent = sensorsAreAbsent.Value;
                                }
                                catch (Exception exc)
                                {
                                    Logger.ShowErrorMessageBox("Возникла ошибка при получении температурных показаний: ", exc);
                                }
                            }
                            else
                                tmPackage = dTermoDetailsPackage[tm];


                            var dlgTermoDetailsEditForm = new InputControlDeliveryWorksheetTermoDetailsEditForm(tmPackage, isReadOnlyMode);
                            if (dlgTermoDetailsEditForm.ShowDialog(this) == DialogResult.OK)
                            {
                                var checkFlag = tmPackage.CheckTermoDetails() || tmPackage.Reason.HasReason;
                                row.yes = checkFlag;
                                row.no = !checkFlag;
                                row._null = false;
                            }

                            return;
                        }
                        #endregion
                    }
                }
            }
            else
            {
                if (isReadOnlyMode)
                    return;

                if (dgv.Columns[e.ColumnIndex] == clYes1 || dgv.Columns[e.ColumnIndex] == clYes2 || dgv.Columns[e.ColumnIndex] == clYes4)
                {
                    row.yes = true;
                    row.no = row._null = !row.yes;
                }
                else if (dgv.Columns[e.ColumnIndex] == clNo1 || dgv.Columns[e.ColumnIndex] == clNo2 || dgv.Columns[e.ColumnIndex] == clNo4)
                {
                    row.no = true;
                    row.yes = row._null = !row.no;
                }
                else if (dgv.Columns[e.ColumnIndex] == clNull1 || dgv.Columns[e.ColumnIndex] == clNull2 || dgv.Columns[e.ColumnIndex] == clNull4)
                {
                    row._null = true;
                    row.no = row.yes = !row._null;
                }
            }
        }

        /// <summary>
        /// Сохранение данных и выход из окна
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (SaveData())
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при сохранении вопросов по анкете: ", exc);
            }
        }

        /// <summary>
        /// Сохранение результатов анкетирования
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {
                if (!isReadOnlyMode || canAttachFiles || canApproveAttachments)
                    if (!this.CheckFileAttachments())
                        return false;

                var xmlAnswers = CreateXml();

                using (var ts = new TransactionScope())
                {
                    if (!isReadOnlyMode)
                    {
                        using (var adapter = new AP_DocsTableAdapter())
                        {
                            adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                            adapter.UpdateDoc(sessionID, doc.doc_id, xmlAnswers, doc.version_id);
                        }

                        this.SaveUnloadDate();

                        this.SaveCarNumber();

                        this.SaveTermoDetails();
                    }

                    if (!isReadOnlyMode || canAttachFiles || canApproveAttachments)
                        this.SaveFileAttachments();

                    ts.Complete();
                }

                return true;
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время сохранения результатов редактирования в БД: ", exc);
                return false;
            }
        }


        /// <summary>
        /// Формирование XML-структуры вопрос/ответ для передачи в процедуру
        /// </summary>
        /// <returns>XML-фильтр, который характиризует разворачиваемую строку</returns>
        private string CreateXml()
        {
            var doc = new XmlDocument();
            var root = doc.AppendChild(doc.CreateElement("Root"));
            foreach (Data.Quality.AP_Version_QuestionsRow row in quality.AP_Version_Questions)
            {
                var xmlrow = (XmlElement)root.AppendChild(doc.CreateElement("Question"));
                xmlrow.SetAttribute("question_id", row.question_id.ToString());
                bool? answer = row.yes ? (bool?)true : (row.no ? (bool?)false : null);
                if (answer.HasValue)
                    xmlrow.SetAttribute("new_value", answer.ToString());
            }

            return root.InnerXml;
        }

        /// <summary>
        /// Сохранение даты выгрузки
        /// </summary>
        private void SaveUnloadDate()
        {
            try
            {
                // Если дата была проставлена (есть доступ к внесению даты разгрузки)
                if (unloadDatePackage.UnloadDate.HasValue)
                {
                    var docID = doc.doc_id;
                    var unloadDate = unloadDatePackage.NotYetUnloaded ? (DateTime?)null : unloadDatePackage.UnloadDate;
                    var notYetUnloaded = unloadDatePackage.NotYetUnloaded;

                    using (var adapter = new Data.QualityTableAdapters.AP_DocsTableAdapter())
                        adapter.EditUnloadDate(docID, unloadDate, notYetUnloaded);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Сохранение номера авто / полуприцепа
        /// </summary>
        private void SaveCarNumber()
        {
            try
            {
                var docID = doc.doc_id;
                var carNumber = string.IsNullOrEmpty(carNumberPackage.CarNumber) ? (string)null : carNumberPackage.CarNumber;
                var trailerNumber = string.IsNullOrEmpty(carNumberPackage.TrailerNumber) ? (string)null : carNumberPackage.TrailerNumber;

                using (var adapter = new Data.QualityTableAdapters.AP_DocsTableAdapter())
                    adapter.EditCarNumber(docID, carNumber, trailerNumber);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Сохранение температурных показаний
        /// </summary>
        private void SaveTermoDetails()
        {
            try
            {
                var docID = doc.doc_id;
                var rowID = (long?)null;

                foreach (var kvp in dTermoDetailsPackage)
                {
                    var tmPackage = kvp.Value;
                    var termoMode = tmPackage.TermoModeFlag;

                    foreach (Data.Quality.AP_Version_Termo_DetailRow row in tmPackage.Cache.Rows)
                    {
                        switch (row.RowState)
                        { 
                            case DataRowState.Added:
                            case DataRowState.Modified:
                                rowID = row.IsRow_idNull() ? (long?)null : row.Row_id;
                                var date = row.IsDateNull() ? (DateTime?)null : row.Date;
                                var tfact = row.IsT_FactNull() ? (decimal?)null : row.T_Fact;
                                var tmin = row.IsT_MinNull() ? (decimal?)null : row.T_Min;
                                var tmax = row.IsT_MaxNull() ? (decimal?)null : row.T_Max;
                                var sensorID = row.IsTr_Scaner_IdNull() ? (string)null : row.Tr_Scaner_Id;
                                var equipmentType = row.IsEquipmentTypeNull() ? (int?)null : row.EquipmentType;
                                var equipmentNumber = row.IsEquipmentNumberNull() ? (string)null : row.EquipmentNumber;
                                var comment = row.IsCommentNull() ? (string)null : row.Comment;
                                var reasonID = row.IsReasonIDNull() ? (int?)null : row.ReasonID;
                                var note = row.IsNoteNull() ? (string)null : row.Note;

                                using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                    adapter.Edit(docID, rowID, termoMode, date, tfact, tmin, tmax, sensorID, equipmentType, equipmentNumber, comment, reasonID, note);
                                break;
                            case DataRowState.Deleted:
                                rowID = (long)row[quality.AP_Version_Termo_Detail.Row_idColumn, DataRowVersion.Original];

                                using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                    adapter.Remove(docID, rowID);
                                break;
                            default: 
                                break;
                        }
                    }

                    if (tmPackage.Reason.HasReason)
                    { 
                    
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// Критичный общий размер всех файлов, при котором пользователю будет отображено предупреждение (1 МБ).
        /// </summary>
        private const long ERROR_FILE_SIZE = 1048576;

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            try
            {
                var ofd = new OpenFileDialog();
                ofd.Title = "Показания температуры по поставке";
                ofd.Filter = "Документы(*.docx;*.doc;*.xlsx;*.xls;*.pdf;*.txt)|*.docx;*.doc;*.xlsx;*.xls;*.pdf;*.txt|Изображения(*.png;*.jpeg;*.jpg;*.tiff;*.tif)|*.png;*.jpeg;*.jpg;*.tiff;*.tif|Архивы(*.rar;*.zip;*.7z;*.tar;*.gzip;*.gz;*.jar)|*.rar;*.zip;*.7z;*.tar;*.gzip;*.gz;*.jar|Другое(*.*)|*.*";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = ofd.FileName;
                var fileInfo = new FileInfo(filePath);

                if (fileInfo.Length > ERROR_FILE_SIZE)
                    throw new Exception("Размер файла превышает допустимый (1 мегабайт).");

                var fileName = fileInfo.Name;
                var fileLength = (double)fileInfo.Length / 1024;

                var attachment = quality.AP_Get_Attachments.NewAP_Get_AttachmentsRow();

                attachment.RowNumber = quality.AP_Get_Attachments.Count + 1;
                attachment.AttachmentID = -1L;
                attachment.DocID = doc.doc_id;
                attachment.VersionID = doc.version_id;

                attachment.FileName = fileName;
                attachment.FileData = File.ReadAllBytes(filePath);
                attachment.FileLength = string.Format("{0:f3} КБ", fileLength);

                attachment.UserCreated = "Текущий пользователь";
                attachment.DateCreated = DateTime.Now;

                attachment.TermoMode = string.Empty;
                attachment.DirectoryType = 0;
                attachment.EquipmentType = 0;
                attachment.EquipmentNumber = string.Empty;

                attachment.Yes = false;
                attachment.No = false;
                attachment.Null = true;

                quality.AP_Get_Attachments.AddAP_Get_AttachmentsRow(attachment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckFileAttachments()
        {
            try
            {
                if (quality.AP_Get_Attachments.Select(string.Format("{0} = 0", quality.AP_Get_Attachments.DirectoryTypeColumn.Caption), string.Empty).Length > 0)
                    throw new Exception("Не во всех показаниях температур указан тип файла.");

                if (quality.AP_Get_Attachments.Select(string.Format("{0} = 0", quality.AP_Get_Attachments.EquipmentTypeColumn.Caption), string.Empty).Length > 0)
                    throw new Exception("Не во всех показаниях температур указан вид оборудования.");


                //if (dgvAttachments.Rows.Count == 0)
                //{
                //    MessageBox.Show("Необходимо загрузить показания температуры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    return false;
                //}

                ////if (dgvAttachments.Rows.Count == 0)
                ////    throw new Exception("Не загружены показания температуры транспортировки товара.");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void SaveFileAttachments()
        {
            try
            {
                foreach (Data.Quality.AP_Get_AttachmentsRow attachment in quality.AP_Get_Attachments)
                {
                    switch (attachment.RowState)
                    { 
                        case DataRowState.Added:
                            var answerAdded = attachment.Yes ? (bool?)true : (attachment.No ? (bool?)false : null);
                            aP_Get_AttachmentsTableAdapter.AddDocAttachment(
                                sessionID, 
                                attachment.DocID, 
                                attachment.VersionID, 
                                attachment.FileName, 
                                attachment.FileData,
                                attachment.TermoMode,
                                attachment.DirectoryType,
                                attachment.EquipmentType,
                                attachment.EquipmentNumber,
                                answerAdded);
                            break;
                        case DataRowState.Modified:
                            var answerModified = attachment.Yes ? (bool?)true : (attachment.No ? (bool?)false : null);
                            aP_Get_AttachmentsTableAdapter.UpdateDocAttachment(
                               sessionID,
                               attachment.DocID,
                               attachment.VersionID,
                               attachment.AttachmentID,
                               answerModified);
                            break;
                        case DataRowState.Deleted:
                            aP_Get_AttachmentsTableAdapter.DeleteDocAttachment(
                                (long)attachment[quality.AP_Get_Attachments.AttachmentIDColumn.Caption, DataRowVersion.Original], 
                                sessionID, 
                                (long)attachment[quality.AP_Get_Attachments.DocIDColumn.Caption, DataRowVersion.Original], 
                                (int)attachment[quality.AP_Get_Attachments.VersionIDColumn.Caption, DataRowVersion.Original]);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnDeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                var attachment = (dgvAttachments.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
                attachment.Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviewFile_Click(object sender, EventArgs e)
        {
            PreviewFile();
        }

        private void PreviewFile()
        {
            try
            {
                var attachment = (dgvAttachments.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
                var fileName = attachment.IsFileNameNull() ? "empty.file" : attachment.FileName;
                var fileData = attachment.IsFileDataNull() ? new byte[0] : attachment.FileData;

                var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), fileName);
                File.WriteAllBytes(filePath, fileData);

                Thread.Sleep(100);
                //Process.Start("explorer.exe", string.Format("/select,{0}", filePath));
                Process.Start(filePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvAttachments_SelectionChanged(object sender, EventArgs e)
        {
            this.SetAttachmentsOperationsAccess();
        }

        private void SetAttachmentsOperationsAccess()
        {
            btnAddFile.Enabled = !isReadOnlyMode || canAttachFiles;
            btnDeleteFile.Enabled = dgvAttachments.SelectedRows.Count > 0 && (!isReadOnlyMode || canAttachFiles);
            btnPreviewFile.Enabled = dgvAttachments.SelectedRows.Count > 0;
            btnSaveFileTemplate.Enabled = !isReadOnlyMode || canAttachFiles;
        }

        private void dgvAttachments_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            this.PreviewFile();
        }

        private void dgvAttachments_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!isReadOnlyMode)
            {
                var attachment = (e.Row.DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
                attachment.Delete();
            }
         
            e.Cancel = true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Shift | Keys.S))
            {
                this.SaveFileTemplate();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnSaveFileTemplate_Click(object sender, EventArgs e)
        {
            this.SaveFileTemplate();
        }

        private void SaveFileTemplate()
        {
            try
            {
                if (!btnSaveFileTemplate.Enabled)
                    return;

                var sfd = new SaveFileDialog();
                sfd.FileName = string.Format("Температура транспортировки_{0}_{1}.xlsx", DateTime.Today.ToShortDateString(), doc.delivery_id);
                sfd.Title = "Сохранение бланка температуры транспортиировки";
                sfd.Filter = "Документы(*.xlsx)|*.xlsx";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = sfd.FileName;

                var stream = new MemoryStream(Properties.Resources.QK_TransportationTemperatureTemplate);

                var workBook = new XSSFWorkbook(stream);

                using (var fs = new FileStream(filePath, FileMode.Create))
                {
                    workBook.Write(fs);
                    fs.Close();

                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miGenerateRightAnswers_Click(object sender, EventArgs e)
        {
            try
            {
                var rightAnswers = taApVersionQuestions.GetDataWriteAnswers(sessionID, doc.doc_id, Convert.ToInt32(doc.version_id), null);

                foreach (Data.Quality.AP_Version_QuestionsRow question in quality.AP_Version_Questions.Rows)
                {
                    var rightAnswer = rightAnswers.FindByquestion_idversion_id(question.question_id, question.version_id);
                    if (rightAnswer != null)
                    {
                        question.yes = rightAnswer.yes;
                        question.no = rightAnswer.no;
                        question._null = rightAnswer._null;
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при автозаполнении анкеты: ", exc);
            }
        }

        private void dgvAttachments_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvAttachments.CurrentCell.OwningColumn == TermoMode)
            {
                var attachment = (dgvAttachments.Rows[dgvAttachments.CurrentCell.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
                var termoMode = attachment.TermoMode;

                if (attachment.RowState == DataRowState.Unchanged)
                {
                    dgvAttachments.EndEdit(DataGridViewDataErrorContexts.Commit);
                    return;
                }

                var sbExcept = new StringBuilder();
                foreach (DataGridViewRow row in dgvAttachments.Rows)
                {
                    if (row.Index != dgvAttachments.CurrentCell.RowIndex)
                    {
                        attachment = (row.DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
                        termoMode = attachment.TermoMode;

                        if (termoMode != string.Empty)
                        {
                            if (sbExcept.Length > 0)
                                sbExcept.AppendFormat(", '{0}'", termoMode);
                            else
                                sbExcept.AppendFormat("'{0}'", termoMode);
                        }
                    }
                }

                var bs = new BindingSource();
                bs.DataMember = "AP_Termo_Modes";
                bs.DataSource = this.quality;

                if (sbExcept.Length > 0)
                    bs.Filter = string.Format("{0} NOT IN ({1})", quality.AP_Termo_Modes.Mode_KeyColumn.Caption, sbExcept.ToString());

                var control = e.Control as DataGridViewComboBoxEditingControl;
                control.DataSource = bs;
            }
        }

        private void dgvAttachments_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                dgvAttachments.CurrentCell = dgvAttachments.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvAttachments.BeginEdit(true);
            }
        }

        private void dgvAttachments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Устанавливать флажки на вложения может только начальник отдела
            if (/*isReadOnlyMode && */!canApproveAttachments)
                return;


            var dgv = sender as DataGridView;
            var row = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Quality.AP_Get_AttachmentsRow;
            

            if (dgv.Columns[e.ColumnIndex] == clYesT)
            {
                row.Yes = true;
                row.No = row.Null = !row.Yes;
            }
            else if (dgv.Columns[e.ColumnIndex] == clNoT)
            {
                row.No = true;
                row.Yes = row.Null = !row.No;
            }
            else if (dgv.Columns[e.ColumnIndex] == clNullT)
            {
                row.Null = true;
                row.No = row.Yes = !row.Null;
            }
        }
    }
}
