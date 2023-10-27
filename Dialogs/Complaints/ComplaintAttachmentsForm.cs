using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.ComplaintsTableAdapters;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для просмотра прикрепленных к претензии файлов.
    /// </summary>
    public partial class ComplaintAttachmentsForm : DialogForm
    {
        private const string DEFAULT_EXPORT_INIT_FOLDER = @"\\vidfs\Video\Запрос_оф_рекл";

        private const string EXPORT_INIT_FOLDER_SETTING_NAME = "ExportInitFolder";

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();


        /// <summary>
        /// Возвращает / устанавливает идентификатор пользовательской сессии.
        /// </summary>
        private long SessionID { get; set; }
        /// <summary>
        /// Возвращает / устанавливает идентификатор документа претензии.
        /// </summary>
        private long DocID { get; set; }
        /// <summary>
        /// Возвращает/ устанавливает признак вложений для возвратов поставщику
        /// </summary>
        private bool UseAttachVR { get; set; }
        /// <summary>
        /// Возвращает/ устанавливает признак вложений для распоряжений ГЛС
        /// </summary>
        private bool UseAttachGA { get; set; }
        /// <summary>
        /// Возвращает/ устанавливает признак вложений для макетов списаний
        /// </summary>
        private bool UseAttachWF { get; set; }
        /// <summary>
        /// Возвращает/ устанавливает признак вложений для документов качества
        /// </summary>
        private bool UseAttachQK { get; set; }

        //private bool? deleteCanAccess = null;
        /// <summary>
        /// Признак возможности удаления вложения
        /// </summary>
        public bool DeleteCanAccess {get; set;}
        //{
        //    get
        //    {
        //        if (!deleteCanAccess.HasValue || this.UserID.Equals(0))
        //        {
        //            try
        //            {
        //                var hasAccess = (int?)null;
        //                using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
        //                    adapter.AttachmentDeleteCheckAccess(this.UserID, ref hasAccess);

        //                deleteCanAccess = hasAccess.HasValue && Convert.ToBoolean(hasAccess.Value) == true;
        //            }
        //            catch (Exception ex)
        //            {
        //                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            }
        //        }

        //        return deleteCanAccess;
        //    }
        //}

        /// <summary>
        /// Признак возможности добавлять вложения
        /// </summary>
        public bool AddCanAccess { get; set; }

        /// <summary>
        /// Признак возможности редактировать реквизиты вложения
        /// </summary>
        public bool EditCanAccess { get; set; }

        /// <summary>
        /// Признак возможности видеть/редактировать расширенные реквизиты вложения
        /// </summary>
        public bool ExtendedPropertiesCanAccess { get; set; }

        /// <summary>
        /// Признак использования режима выбора документов-вложений
        /// </summary>
        public bool UseSelectionMode { get; set; }

        /// <summary>
        /// Возвращает все отмеченные документы-вложения
        /// </summary>
        public List<Data.Complaints.DocAttachmentsRow> SelectedAttachments { get; private set; }

        /// <summary>
        /// Возвращает текущую выделенную строку из таблицы со списком файлов.
        /// </summary>
        private Data.Complaints.DocAttachmentsRow SelectedRow
        {
            get
            {
                if (dgvFiles.SelectedRows.Count > 0)
                    return (Data.Complaints.DocAttachmentsRow)((DataRowView)dgvFiles.SelectedRows[0].DataBoundItem).Row;
                else
                    return null;
            }
        }

        /// <summary>
        /// Каталог для экспорта по умолчанию
        /// </summary>
        public string ExportInitFolder { get; private set; }

        public ComplaintAttachmentsForm(long sessionID, long docID)
            : this(sessionID, docID, false, false, false, false)
        { 
        
        }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        /// <param name="docID">Идентификатор документа претензии.</param>
        /// <param name="useAttachVR">Признак вложений для возвратов поставщику</param>
        /// <param name="useAttachGA">Признак вложений для распоряжений ГЛС</param>
        /// <param name="useAttachWF">Признак вложений для макетов списаний</param>
        /// <param name="useAttachWF">Признак вложений для документов качества</param>
        public ComplaintAttachmentsForm(long sessionID, long docID, bool useAttachVR, bool useAttachGA, bool useAttachWF, bool useAttachQK)
        {
            InitializeComponent();

            this.SessionID = sessionID;
            this.DocID = docID;
            this.UseAttachVR = useAttachVR;
            this.UseAttachGA = useAttachGA;
            this.UseAttachWF = useAttachWF;
            this.UseAttachQK = useAttachQK;

            this.DeleteCanAccess = true;
            this.AddCanAccess = true;
            this.EditCanAccess = true;
            this.ExtendedPropertiesCanAccess = true;

            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        private void ComplaintAttachmentsForm_Load(object sender, EventArgs e)
        {
            if (this.UseSelectionMode)
            {
                dgvFiles.Columns[dgvcIsChecked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
                ((DatagridViewCheckBoxHeaderCell)dgvFiles.Columns[dgvcIsChecked.Index].HeaderCell).CheckBoxClicked += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(ComplaintAttachmentsForm_CheckBoxClicked);
            }
            else
            {
                dgvcIsChecked.Visible = false;
            }
        }

        void ComplaintAttachmentsForm_CheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {

                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    var file = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocAttachmentsRow;

                    // Пропускаем сброс обязательных вложений
                    if (file.IsObligatory && file[complaints.DocAttachments.IsCheckedColumn.Caption, DataRowVersion.Original].Equals(true))
                        continue;

                    row.Cells[dgvcIsChecked.Index].Value = e.IsChecked;
                }

                dgvFiles.RefreshEdit();
            }
            catch (Exception ex)
            {
                
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.RefreshAttachments(true);

            this.CheckAccessToExtendedProperties();
        }

        private void Initialize()
        {
            try
            {
                this.btnOK.Location = new Point(956, 8); // 1319
                this.btnCancel.Location = new Point(1046, 8); // 1409 

                if (!this.UseSelectionMode)
                {
                    btnOK.Visible = false;
                    btnCancel.Text = "Закрити";
                }

                this.Text = string.Format(this.Text, this.UseAttachVR ? "повернення" : this.UseAttachGA ? "розпорядження" : this.UseAttachWF ? "макета списання" : this.UseAttachQK ? "заяви" : "претензії");
                if (this.UseSelectionMode)
                    this.Text += " [РЕЖИМ ВИБОРУ]";


                var sExportInitFolder = Config.LoadSetting(this.Name, EXPORT_INIT_FOLDER_SETTING_NAME);
                this.ExportInitFolder = Directory.Exists(sExportInitFolder) ? sExportInitFolder : DEFAULT_EXPORT_INIT_FOLDER;

                this.SetAccessToExtendedProperties(false);
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void CheckAccessToExtendedProperties()
        {
            var hasAccess = (bool?)null;
            using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
            {
                if (this.UseAttachVR)
                    adapter.AttachmentsCheckAccessToExtendedPropertiesVR(SessionID, DocID, ref hasAccess);
                else if (this.UseAttachGA)
                    adapter.AttachmentsCheckAccessToExtendedPropertiesGA(SessionID, DocID, ref hasAccess);
                else if (this.UseAttachWF)
                    adapter.AttachmentsCheckAccessToExtendedPropertiesWF(SessionID, DocID, ref hasAccess);
                else if (this.UseAttachQK)
                    adapter.AttachmentsCheckAccessToExtendedPropertiesWF(SessionID, DocID, ref hasAccess);
                else
                    adapter.AttachmentsCheckAccessToExtendedProperties(SessionID, DocID, ref hasAccess);
            }

            //this.ExtendedPropertiesCanAccess = hasAccess ?? false;

            this.SetAccessToExtendedProperties(/*this.ExtendedPropertiesCanAccess*/hasAccess ?? false);
        }

        private void CheckAccess()
        {
            // Получение доступа к удалению вложений 
            var hasAccess = (int?)null;
            using (var adapter = new Data.ComplaintsTableAdapters.DocAttachmentsTableAdapter())
            {
                if (this.UseAttachVR)
                    adapter.AttachmentDeleteCheckAccessVR(SessionID, ref hasAccess);
                else if (this.UseAttachGA)
                    adapter.AttachmentDeleteCheckAccessGA(SessionID, ref hasAccess);
                else if (this.UseAttachWF)
                    adapter.AttachmentDeleteCheckAccessWF(SessionID, ref hasAccess);
                else if (this.UseAttachQK)
                    adapter.AttachmentDeleteCheckAccessWF(SessionID, ref hasAccess);
                else
                    adapter.AttachmentDeleteCheckAccess(SessionID, ref hasAccess);
            }

            DeleteCanAccess = DeleteCanAccess && !UseSelectionMode && hasAccess.HasValue && Convert.ToBoolean(hasAccess.Value) == true && !this.UseAttachWF;
            AddCanAccess = AddCanAccess && !UseSelectionMode && !this.UseAttachWF;
            EditCanAccess = EditCanAccess && !UseSelectionMode && !this.UseAttachWF;

            this.SetAccess();
        }

        /// <summary>
        /// Обрабатывает изменение выбранной строки в списке файлов, прикрепленных к претензии.
        /// </summary>
        private void dgvFiles_SelectionChanged(object sender, EventArgs e)
        {
            this.SetAccess();
        }

        private void SetAccess()
        {
            btnView.Enabled = btnSaveAs.Enabled = (SelectedRow != null);
            sbSaveAll.Enabled = dgvFiles.Rows.Count > 0;
            btnEditAttachmentRequisites.Enabled = EditCanAccess && (SelectedRow != null); 
            btnDelete.Enabled = DeleteCanAccess && (SelectedRow != null);
            btnAdd.Enabled = AddCanAccess;
        }

        private void SetAccessToExtendedProperties(bool canAccess)
        {
            if (this.ExtendedPropertiesCanAccess == canAccess)
                return;

            if (canAccess)
            {
                Document_Amount.Visible = true;
                //this.Width += Document_Amount.Width;

                IS_Vendor_Payer.Visible = true;
                //this.Width += IS_Vendor_Payer.Width;
            }
            else
            {
                Document_Amount.Visible = false;
                //this.Width -= Document_Amount.Width;

                IS_Vendor_Payer.Visible = false;
                //this.Width -= IS_Vendor_Payer.Width;
            }

            this.ExtendedPropertiesCanAccess = canAccess;
        }

        /// <summary>
        /// Обрабатывает двойной клик по строке в списке файлов, вызывая просмотр выбранного файла.
        /// </summary>
        private void dgvFiles_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex.Equals(dgvcIsChecked.Index))
                return;

            if (SelectedRow != null)
                btnView_Click(sender, EventArgs.Empty);
        }

        /// <summary>
        /// Добавление к претензии одного или нескольких файлов
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new NewAttachmentForm(this.UseAttachVR, this.UseAttachGA, this.UseAttachWF, this.UseAttachQK) { ExtendedPropertiesCanAccess = ExtendedPropertiesCanAccess };
                if (form.ShowDialog(this) == DialogResult.OK)
                    using (var adapter = new DocAttachmentsTableAdapter())
                        foreach (string fileName in form.FilePaths)
                        {
                            if (this.UseAttachVR)
                                adapter.AddDocAttachmentVR(DocID, Path.GetFileName(fileName), form.AttachmentDocTypeDescription, File.ReadAllBytes(fileName), SessionID, form.AttachDocNumber, form.AttachDocDate, form.AttachmentDocTypeCode);
                            else if (this.UseAttachGA)
                                adapter.AddDocAttachmentGA(Convert.ToInt32(DocID), Path.GetFileName(fileName), form.AttachmentDocTypeDescription, File.ReadAllBytes(fileName), SessionID, form.AttachDocNumber, form.AttachDocDate, form.AttachmentDocTypeCode);
                            else if (this.UseAttachWF)
                                adapter.AddDocAttachmentWF(Convert.ToInt32(DocID), Path.GetFileName(fileName), form.AttachmentDocTypeDescription, File.ReadAllBytes(fileName), SessionID, form.AttachDocNumber, form.AttachDocDate, form.AttachmentDocTypeCode);
                            else if (this.UseAttachQK)
                                adapter.AddDocAttachmentWF(Convert.ToInt32(DocID), Path.GetFileName(fileName), form.AttachmentDocTypeDescription, File.ReadAllBytes(fileName), SessionID, form.AttachDocNumber, form.AttachDocDate, form.AttachmentDocTypeCode);
                            else
                                adapter.AddDocAttachment(DocID, Path.GetFileName(fileName), form.AttachmentDocTypeDescription, File.ReadAllBytes(fileName), SessionID, form.AttachDocNumber, form.AttachDocDate, form.AttachmentDocTypeCode, form.AttachDocAmount, form.AttachDocIsVendorPayer);
                        }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(string.Format("Во время добавления файлов к {0} возникла ошибка: ", this.UseAttachVR ? "возврату" : this.UseAttachGA ? "распоряжению" : this.UseAttachQK ? "заявке" : "претензии"), exc);
            }
            finally
            {
                RefreshAttachments();
            }
        }

        private void RefreshAttachments()
        {
            RefreshAttachments(false);
        }

        /// <summary>
        /// Обновление таблицы с прикрепленными файлами
        /// </summary>
        private void RefreshAttachments(bool checkAccess)
        {
            try
            {
                var mode = this.UseSelectionMode ? 1 : 0;

                var loadWorker = new BackgroundWorker();
                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        // Загрузка вложений
                        if (this.UseAttachVR)
                            e.Result = docAttachmentsTableAdapter.GetDataVR(SessionID, DocID, mode);
                        else if (this.UseAttachGA)
                            e.Result = docAttachmentsTableAdapter.GetDataGA(SessionID, DocID, mode);
                        else if (this.UseAttachWF)
                            e.Result = docAttachmentsTableAdapter.GetDataWF(SessionID, DocID, mode);
                        else if (this.UseAttachQK)
                            e.Result = docAttachmentsTableAdapter.GetDataWF(SessionID, DocID, mode);
                        else
                            e.Result = docAttachmentsTableAdapter.GetData(SessionID, DocID, mode);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        complaints.DocAttachments.Merge(e.Result as Data.Complaints.DocAttachmentsDataTable);

                        if (checkAccess)
                            this.CheckAccess();

                        if (dgvFiles.Rows.Count > 0)
                            dgvFiles.Rows[0].Selected = false;
                    }
                };
                complaints.DocAttachments.Clear();
                splashForm.ActionText = "Выполняется загрузка документов-вложений..";
                loadWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время загрузки прикрепленных файлов произошла ошибка: ", exc);
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Просмотреть".
        /// </summary>
        private void btnView_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                try
                {
                    string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), SelectedRow.File_Name);
                    System.IO.File.WriteAllBytes(tempFilePath, SelectedRow.File_Data);
                    System.Diagnostics.Process.Start(tempFilePath);
                    MessageBox.Show("Нажмите \"ОК\" после закрытия программы просмотра для удаления временного файла.");

                    bool fileDeleted = false;
                    while (!fileDeleted)
                    {
                        try
                        {
                            System.IO.File.Delete(tempFilePath);
                            fileDeleted = true;
                        }
                        catch (Exception ex)
                        {
                            if (MessageBox.Show("Во время удаления временного файла возникла следующая ошибка:" +
                                    Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine +
                                    "Нажмите \"Повтор\" (\"Retry\") для повторной попытки удаления или \"Отмена\" (\"Cancel\") для отмены.",
                                    "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                            {
                                fileDeleted = true;
                            }
                        }
                    }
                }
                catch (System.IO.IOException ex1)
                {
                    MessageBox.Show(string.Format("Во время просмотра прикрепленного к {0} файла возникла следующая ошибка:", this.UseAttachVR ? "возврату" : this.UseAttachGA ? "распоряжению" : this.UseAttachQK ? "заявке" : "претензии") +
                       Environment.NewLine + ex1.Message + Environment.NewLine + Environment.NewLine + "Возможно, файл уже открыт для просмотра.",
                       "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(string.Format("Во время просмотра прикрепленного к {0} файла возникла следующая ошибка:", this.UseAttachVR ? "возврату" : this.UseAttachGA ? "распоряжению" : this.UseAttachQK ? "заявке" : "претензии") +
                        Environment.NewLine + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Сохранить в файл".
        /// </summary>
        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            if (SelectedRow != null)
            {
                saveFileDialog.FileName = SelectedRow.File_Name;
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        System.IO.File.WriteAllBytes(saveFileDialog.FileName, SelectedRow.File_Data);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Во время сохранения файла \"" + saveFileDialog.FileName + "\" возникла следующая ошибка:" +
                            Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(string.Format("Вы действительно хотите удалить\r\nприкрепленный к {0} файл?", this.UseAttachVR ? "возврату" : this.UseAttachGA ? "распоряжению" : "претензии"), "Удаление файла", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (this.UseAttachVR)
                        docAttachmentsTableAdapter.DeleteDocAttachmentVR(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID);
                    else if (this.UseAttachGA)
                        docAttachmentsTableAdapter.DeleteDocAttachmentGA(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID);
                    else if (this.UseAttachWF)
                        docAttachmentsTableAdapter.DeleteDocAttachmentWF(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID);
                    else if (this.UseAttachQK)
                        docAttachmentsTableAdapter.DeleteDocAttachmentWF(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID);
                    else
                        docAttachmentsTableAdapter.DeleteDocAttachment(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshAttachments();
            }
        }

        private void btnEditAttachmentRequisites_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new NewAttachmentForm(SelectedRow.IsDocument_NumberNull() ? string.Empty : SelectedRow.Document_Number, SelectedRow.IsDocument_DateNull() ? DateTime.Today : SelectedRow.Document_Date, SelectedRow.IsDocument_AmountNull() ? (double?)null : SelectedRow.Document_Amount, SelectedRow.IsIS_Vendor_PayerNull() ? (bool?)null : SelectedRow.IS_Vendor_Payer, this.UseAttachVR, this.UseAttachGA, this.UseAttachWF, this.UseAttachQK) { ExtendedPropertiesCanAccess = ExtendedPropertiesCanAccess };
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    if (this.UseAttachVR)
                        docAttachmentsTableAdapter.UpdateDocAttachmentVR(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID, form.AttachDocNumber, form.AttachDocDate);
                    else if (this.UseAttachGA)
                        docAttachmentsTableAdapter.UpdateDocAttachmentGA(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID, form.AttachDocNumber, form.AttachDocDate);
                    else if (this.UseAttachWF)
                        docAttachmentsTableAdapter.UpdateDocAttachmentWF(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID, form.AttachDocNumber, form.AttachDocDate);
                    else if (this.UseAttachQK)
                        docAttachmentsTableAdapter.UpdateDocAttachmentWF(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID, form.AttachDocNumber, form.AttachDocDate);
                    else
                        docAttachmentsTableAdapter.UpdateDocAttachment(SelectedRow.Attachment_ID, this.UserID, SelectedRow.First_Doc_ID, form.AttachDocNumber, form.AttachDocDate, form.AttachDocAmount, form.AttachDocIsVendorPayer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                RefreshAttachments();
            }
        }

        private void dgvFiles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvFiles.Rows[e.RowIndex].Cells[this.dgvcIsChecked.Index].Value);
            this.dgvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvFiles.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }

        private void dgvFiles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvFiles.CurrentCell is DataGridViewCheckBoxCell)
            {
                var file = (dgvFiles.CurrentCell.OwningRow.DataBoundItem as DataRowView).Row as Data.Complaints.DocAttachmentsRow;

                // Пропускаем сброс обязательных вложений
                if (file.IsObligatory && dgvFiles.CurrentCell.Value.Equals(true))
                {
                    dgvFiles.CancelEdit();
                    return;
                }

                dgvFiles.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvFiles.Rows[this.dgvFiles.CurrentRow.Index].Cells[this.dgvcIsChecked.Index].Value);
                foreach (DataGridViewColumn column in this.dgvFiles.Columns)
                {
                    this.dgvFiles.Rows[this.dgvFiles.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvFiles.Rows[this.dgvFiles.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void ComplaintAttachmentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                if (this.UseSelectionMode)
                    e.Cancel = !this.ApplySelection();
            }
        }

        private bool ApplySelection()
        {
            try
            {
                var arFiles = complaints.DocAttachments.Select(string.Format("{0} = true", complaints.DocAttachments.IsCheckedColumn.Caption));
                if (arFiles == null || arFiles.Length == 0)
                    throw new Exception("Не выбраны файлы.");

                this.SelectedAttachments = new List<WMSOffice.Data.Complaints.DocAttachmentsRow>();
                foreach (Data.Complaints.DocAttachmentsRow file in arFiles)
                    this.SelectedAttachments.Add(file);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void sbSaveAll_ButtonClick(object sender, EventArgs e)
        {
            sbSaveAll.ShowDropDown();
        }

        private void miSaveAll_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvFiles.Rows.Count == 0)
                    return;

                var docName = string.Format("{0}_№_{1}", this.UseAttachVR ? "Повернення" : this.UseAttachGA ? "Розпорядження" : this.UseAttachWF ? "Макет списання" : this.UseAttachQK ? "Заява" : "Претензія", this.DocID);
                var folderName = System.Environment.SpecialFolder.MyDocuments.ToString();

                using (var dlgSelectFolder = new FolderBrowserDialog())
                {
                    //dlgSelectFolder.RootFolder = System.Environment.SpecialFolder.MyDocuments;
                    dlgSelectFolder.SelectedPath = this.ExportInitFolder;
                    dlgSelectFolder.Description = string.Format("Експорт вкладень - {0}", this.ExportInitFolder);
                    dlgSelectFolder.ShowNewFolderButton = false;

                    if (dlgSelectFolder.ShowDialog() != DialogResult.OK)
                        return;

                    var rootFolder = this.ExportInitFolder = dlgSelectFolder.SelectedPath;
                    folderName = Path.Combine(rootFolder, docName);

                    if (!Directory.Exists(folderName))
                        Directory.CreateDirectory(folderName);
                }

                var files = new List<Data.Complaints.DocAttachmentsRow>();

                foreach (DataGridViewRow row in dgvFiles.Rows)
                {
                    var file = (row.DataBoundItem as DataRowView).Row as Data.Complaints.DocAttachmentsRow;
                    files.Add(file);
                }

                var splashForm = new SplashForm();

                var exportWorker = new BackgroundWorker();
                exportWorker.DoWork += (s, ea) =>
                {
                    try
                    {
                        var cntFiles = files.Count;
                        var cntProcessedFiles = 0;
                        for (int idxFile = 0; idxFile < cntFiles; idxFile++)
                        {
                            try
                            {
                                var file = files[idxFile];

                                var fileName = file.File_Name;
                                var fileBin = file.File_Data;

                                var filePath = Path.Combine(folderName, fileName);
                                File.WriteAllBytes(filePath, fileBin);

                                cntProcessedFiles++;

                                ThreadSafeDelegate(() =>
                                {
                                    splashForm.ActionText = string.Format("Выполняется экспорт вложений..\r\nОбработано файлов: {0} из {1}.", cntProcessedFiles, cntFiles);
                                });
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ea.Result = ex;
                    }
                };
                exportWorker.RunWorkerCompleted += (s, ea) =>
                {
                    splashForm.CloseForce();

                    if (ea.Result is Exception)
                        MessageBox.Show((ea.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                    {
                        Thread.Sleep(500);
                        Process.Start(folderName);
                    }
                };

                splashForm.ActionText = "Выполняется экспорт вложений..";
                exportWorker.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void miClearSettings_Click(object sender, EventArgs e)
        {
            this.ExportInitFolder = DEFAULT_EXPORT_INIT_FOLDER;
        }

        private void ThreadSafeDelegate(MethodInvoker method)
        {
            if (this.InvokeRequired)
                this.BeginInvoke((Delegate)method);
            else
                method();
        }

        private void ComplaintAttachmentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                var sExportInitFolder = this.ExportInitFolder;
                Config.SaveSetting(this.Name, EXPORT_INIT_FOLDER_SETTING_NAME, sExportInitFolder);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
