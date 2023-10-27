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
using System.Drawing;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно редактирования анкеты входного контроля поставки
    /// </summary>
    public partial class EditShippingAuthorizationWorksheetForm : Form
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
        private readonly Data.Quality.QK_SA_WorksheetsRow doc;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public EditShippingAuthorizationWorksheetForm(long pSessionID, Data.Quality.QK_SA_WorksheetsRow pDoc, bool isReadOnly)
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
                SelectedWorksheet = doc,
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

            btnSave.Enabled = false;
            miGenerateRightAnswers.Enabled = false;
            
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
        }

        /// <summary>
        /// Вывод основной информации по анкете в текстовые поля в окне
        /// </summary>
        private void FillMainInfo()
        {
            tbxRouteListNumber.Text = doc.route_list_number.ToString();
            tbxCarNumber.Text = doc.car_number;
            tbxTrailerNumber.Text = doc.IstrailerNull() ? string.Empty : doc.trailer;
            tbxDocNumber.Text = doc.worksheet_number.ToString();
            tbxDocStatus.Text = doc.worksheet_status;
            tbxDriver.Text = doc.Isdriver_nameNull() ? (string)null : doc.driver_name;
            tbxDocDate.Text = doc.worksheet_date.ToShortDateString();
            
            tbxVersionDate.Text = doc.version_date.ToShortDateString();
            //tbxVersionUser.Text = doc.Isuser_createdNull() ? "Система" : doc.user_created;
        }

        /// <summary>
        /// Загрузка вопросов по анкете с текущими ответами
        /// </summary>
        private void LoadQuestions()
        {
            try
            {
                taApVersionQuestions.FillSA(quality.AP_Version_Questions, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number), null);

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
                taApGetWorksheetReportHeader.FillSA(quality.AP_Get_Worksheet_Report_Header, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number));
                if (quality.AP_Get_Worksheet_Report_Header.Count == 0)
                    Logger.ShowErrorMessageBox("Ошибка: процедура получения дополнительной информации по анкете не вернула данные!");
                else
                {
                    var row = quality.AP_Get_Worksheet_Report_Header[0];

                    if (!row.Isdate_created1Null())
                        tbxEditingDate1.Text = row.date_created1.ToShortDateString();

                    if (!row.Isuser1Null())
                        tbxUser1.Text = row.user1;

                    if (!row.Isdate_created2Null())
                        tbxEditingDate2.Text = row.date_created2.ToShortDateString();

                    if (!row.Isuser2Null())
                        tbxUser2.Text = row.user2;
                }                
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки дополнительной информации по анкете: ", exc);
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
                                        adapter.FillSA(tmPackage.Cache, doc.worksheet_number, Convert.ToInt32(doc.version_number), tmPackage.TermoModeFlag, ref sensorsAreAbsent);

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


                            var dlgTermoDetailsEditForm = new InputControlDeliveryWorksheetTermoDetailsEditForm(tmPackage, isReadOnlyMode, true);
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
                var xmlAnswers = CreateXml();

                using (var ts = new TransactionScope())
                {
                    using (var adapter = new QK_SA_WorksheetsTableAdapter())
                    {
                        adapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                        adapter.UpdateWorksheet(sessionID, doc.worksheet_number, xmlAnswers, Convert.ToInt32(doc.version_number));
                    }

                    this.SaveUnloadDate();

                    this.SaveTermoDetails();

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

                    using (var adapter = new Data.QualityTableAdapters.QK_SA_WorksheetsTableAdapter())
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
                                    adapter.EditSA(docID, rowID, termoMode, date, tfact, tmin, tmax, sensorID, equipmentType, equipmentNumber, comment);
                                break;
                            case DataRowState.Deleted:
                                rowID = (long)row[quality.AP_Version_Termo_Detail.Row_idColumn, DataRowVersion.Original];

                                using (var adapter = new Data.QualityTableAdapters.AP_Version_Termo_DetailTableAdapter())
                                    adapter.RemoveSA(docID, rowID);
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

        private void miGenerateRightAnswers_Click(object sender, EventArgs e)
        {
            this.GenerateRightAnswers();
        }

        private void GenerateRightAnswers()
        {
            try
            {
                var rightAnswers = taApVersionQuestions.GetDataSAWriteAnswers(sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number), null);

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

        private void DeleteDesinfectionCert()
        {
            try
            {
                using (var adapter = new Data.QualityTableAdapters.AP_Get_AttachmentsTableAdapter())
                    adapter.DeleteDocAttachmentSA((long?)null, sessionID, doc.worksheet_number, Convert.ToInt32(doc.version_number));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditShippingAuthorizationWorksheetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isReadOnlyMode && desinficationCertPackage.HasAttachment && this.DialogResult == DialogResult.Cancel)
                this.DeleteDesinfectionCert();
        }
    }
}
