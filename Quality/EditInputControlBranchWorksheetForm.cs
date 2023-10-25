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
    public partial class EditInputControlBranchWorksheetForm : Form
    {
        private readonly Dictionary<TermoMode, TermoDetailsPackage> dTermoDetailsPackage = null;
        private readonly ShipmentUnloadDatePackage unloadDatePackage = null;
        private readonly ShipmentDesinficationCertPackage desinficationCertPackage = null;

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
        /// Анкета, которая редактируется
        /// </summary>
        private readonly Data.Quality.QK_CB_WorksheetsRow doc;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public EditInputControlBranchWorksheetForm(long pSessionID, Data.Quality.QK_CB_WorksheetsRow pDoc, bool isReadOnly)
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
            desinficationCertPackage = new ShipmentDesinficationCertPackage()
            {
                SelectedWorksheet = null,
                RouteListNumber = doc.route_list_number
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
            btnSave.Enabled = false;
            miGenerateRightAnswers.Enabled = false;

            TermoMode.ReadOnly = true;
            TermoMode.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;
            
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
            tbxRouteListNumber.Text = doc.route_list_number.ToString();
            tbxCarNumber.Text = doc.Iscar_numberNull() ? string.Empty : doc.car_number;
            tbxTrailerNumber.Text = doc.IstrailerNull() ? string.Empty : doc.trailer;
            tbxDocNumber.Text = doc.worksheet_number.ToString();
            tbxVersionNumber.Text = doc.version_number.ToString();
            tbxFilialFrom.Text = doc.filial_from_name.ToString();
            tbxFilialTo.Text = doc.filial_to_name.ToString();
            tbxVersionDate.Text = doc.version_date.ToString();
            tbxVersionStatus.Text = doc.worksheet_status;
            tbxVersionUser.Text = doc.Isuser_createdNull() ? "Система" : doc.user_created;
        }

        /// <summary>
        /// Загрузка вопросов по анкете с текущими ответами
        /// </summary>
        private void LoadQuestions()
        {
            try
            {
                taApVersionQuestions.FillCB(quality.AP_Version_Questions, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number), null);

                if (dgvQuestionGroup1.Rows.Count > 0)
                    dgvQuestionGroup1.Rows[0].Selected = false;

                if (dgvQuestionGroup2.Rows.Count > 0)
                    dgvQuestionGroup2.Rows[0].Selected = false;
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
                taApGetWorksheetReportHeader.FillCB(quality.AP_Get_Worksheet_Report_Header, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number));
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

                var blankRow = quality.AP_Termo_Modes.NewAP_Termo_ModesRow();
                blankRow.Mode_ID = (byte)0;
                blankRow.Mode_Name = "(отсутствует)";
                blankRow.Min_Temp = 0;
                blankRow.Max_Temp = 0;
                blankRow.Mode_Key = string.Empty;
                quality.AP_Termo_Modes.Rows.InsertAt(blankRow, 0);

                aP_Get_AttachmentsTableAdapter.FillCB(quality.AP_Get_Attachments, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number));

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

            e.CellStyle.BackColor = row.question_type_id % 3 == 0 || row.question_type_id % 4 == 0 ? ColorTranslator.FromHtml("#ffe6e6e6") : e.CellStyle.BackColor;
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
                if (dgv.Columns[e.ColumnIndex] == clShowEditor1 || dgv.Columns[e.ColumnIndex] == clShowEditor2)
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

                        #region ИЗМЕНЕНИЕ ПАСПОРТА ДЕЗИНФЕКЦИИ
                        if (row.question_id == 30)
                        {
                            var editor = new InputControlDeliveryWorksheetDesinfectionCertEditForm(desinficationCertPackage, isReadOnlyMode) { UserID = Convert.ToInt32(sessionID) };
                            editor.ShowDialog(this); 

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
                                        adapter.FillCB(tmPackage.Cache, doc.worksheet_number, Convert.ToInt32(doc.version_number), tmPackage.TermoModeFlag, ref sensorsAreAbsent);

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
                                var checkFlag = tmPackage.CheckTermoDetails();
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

                if (dgv.Columns[e.ColumnIndex] == clYes1 || dgv.Columns[e.ColumnIndex] == clYes2)
                {
                    row.yes = true;
                    row.no = row._null = !row.yes;
                }
                else if (dgv.Columns[e.ColumnIndex] == clNo1 || dgv.Columns[e.ColumnIndex] == clNo2)
                {
                    row.no = true;
                    row.yes = row._null = !row.no;
                }
                else if (dgv.Columns[e.ColumnIndex] == clNull1 || dgv.Columns[e.ColumnIndex] == clNull2)
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
                //if (!this.CheckFileAttachments())
                //    return false;

                var xmlAnswers = CreateXml();

                using (var ts = new TransactionScope())
                {
                    using (var adapter = new QK_CB_WorksheetsTableAdapter())
                    {
                        adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        adapter.UpdateWorksheet(sessionID, doc.worksheet_number, xmlAnswers, Convert.ToInt32(doc.version_number));
                    }

                    this.SaveUnloadDate();

                    this.SaveTermoDetails();

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
                    var docID = doc.worksheet_number;
                    var unloadDate = unloadDatePackage.NotYetUnloaded ? (DateTime?)null : unloadDatePackage.UnloadDate;
                    var notYetUnloaded = unloadDatePackage.NotYetUnloaded;

                    using (var adapter = new Data.QualityTableAdapters.QK_CB_WorksheetsTableAdapter())
                        adapter.EditUnloadDate(docID, unloadDate, notYetUnloaded);
                }
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
                var docID = doc.worksheet_number;
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

                                using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                    adapter.EditCB(docID, rowID, termoMode, date, tfact, tmin, tmax, sensorID, equipmentType, equipmentNumber, comment);
                                break;
                            case DataRowState.Deleted:
                                rowID = (long)row[quality.AP_Version_Termo_Detail.Row_idColumn, DataRowVersion.Original];

                                using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                    adapter.RemoveCB(docID, rowID);
                                break;
                            default: 
                                break;
                        }
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
                attachment.DocID = doc.worksheet_number;
                attachment.VersionID = Convert.ToInt32(doc.version_number);

                attachment.FileName = fileName;
                attachment.FileData = File.ReadAllBytes(filePath);
                attachment.FileLength = string.Format("{0:f3} КБ", fileLength);

                attachment.UserCreated = "Текущий пользователь";
                attachment.DateCreated = DateTime.Now;

                attachment.TermoMode = string.Empty;

                quality.AP_Get_Attachments.AddAP_Get_AttachmentsRow(attachment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [Obsolete]
        private bool CheckFileAttachments()
        {
            try
            {
                if (dgvAttachments.Rows.Count == 0)
                {
                    MessageBox.Show("Необходимо загрузить показания температуры.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                //if (dgvAttachments.Rows.Count == 0)
                //    throw new Exception("Не загружены показания температуры транспортировки товара.");

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
                            aP_Get_AttachmentsTableAdapter.AddDocAttachmentCB(
                                sessionID, 
                                attachment.DocID, 
                                attachment.VersionID, 
                                attachment.FileName, 
                                attachment.FileData,
                                attachment.TermoMode,
                                null,
                                null,
                                null
                                );
                            break;
                        case DataRowState.Deleted:
                            aP_Get_AttachmentsTableAdapter.DeleteDocAttachmentCB(
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
            btnAddFile.Enabled = !isReadOnlyMode;
            btnDeleteFile.Enabled = dgvAttachments.SelectedRows.Count > 0 && !isReadOnlyMode;
            btnPreviewFile.Enabled = dgvAttachments.SelectedRows.Count > 0;
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
                sfd.FileName = string.Format("Температура транспортировки_{0}_{1}.xlsx", DateTime.Today.ToShortDateString(), doc.route_list_number);
                sfd.Title = "Сохранение бланка температуры транспортиировки";
                sfd.Filter = "Документы(*.xlsx)|*.xlsx";
                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                var filePath = sfd.FileName;

                var stream = new MemoryStream(Properties.Resources.QK_TransportationTemperatureTemplate);

                var workBook = new XSSFWorkbook(stream);

                //var sheet = workBook.GetSheetAt(0);
                //var row = sheet.GetRow(0);
                //var cell = row.CreateCell(1);
                //cell.SetCellValue(doc.route_list_number);

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
                var rightAnswers = taApVersionQuestions.GetDataCBWriteAnswers(sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number), null);

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
    }
}
