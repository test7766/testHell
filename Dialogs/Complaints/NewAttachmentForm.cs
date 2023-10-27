using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для добавления прикрепляемых к претензии файлов
    /// </summary>
    public partial class NewAttachmentForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Пользовательский тип документа вложения
        /// </summary>
        private const string CUSTOM_ATTACHMENT_TYPE = "CT";

        /// <summary>
        /// Критичный общий размер всех файлов, при котором пользователю будет отображено предупреждение (1 МБ).
        /// </summary>
        private const long WARNING_FILE_SIZE = 1048576;

        /// <summary>
        /// Критичный общий размер всех файлов, при котором пользователю будет отображена ошибка (3 МБ).
        /// </summary>
        private const long ERROR_FILE_SIZE = 3128576;

        /// <summary>
        /// Название настройки с последней открытой папкой
        /// </summary>
        private const string CUR_DIR_SETTING = "CurDir";

        /// <summary>
        /// Возвращает тип вложения (из справочника)
        /// </summary>
        public string AttachmentDocTypeCode 
        {   
            get { return cmbDescription.SelectedValue.Equals(CUSTOM_ATTACHMENT_TYPE) ? (string)null : cmbDescription.SelectedValue.ToString(); }
            set { cmbDescription.Tag = value; }
        }

        /// <summary>
        /// Возвращает описание типа вложения (для пользовательского типа)
        /// </summary>
        public string AttachmentDocTypeDescription { get { return cmbDescription.SelectedValue.Equals(CUSTOM_ATTACHMENT_TYPE) ? tbDescription.Text : complaints.DocAttachmentTypes.FindByAttachment_Type_Code(cmbDescription.SelectedValue.ToString()).Attachment_Type_Name; } }

        /// <summary>
        /// Выбранные файлы
        /// </summary>
        private readonly List<string> filePaths = new List<string>();

        /// <summary>
        /// Выбранные файлы
        /// </summary>
        public string[] FilePaths { get { return filePaths.ToArray(); } }

        /// <summary>
        /// № документа вложения 
        /// </summary>
        public string AttachDocNumber { get { return tbAttachDocNumber.Text; } }

        /// <summary>
        /// Дата документа вложения
        /// </summary>
        public DateTime AttachDocDate { get { return dtpAttachDocDate.Value.Date; } }

        /// <summary>
        /// Сумма с НДС документа вложения
        /// </summary>
        public double? AttachDocAmount { get { return nudAttachDocAmount.Visible ? Convert.ToDouble(nudAttachDocAmount.Value) : (double?)null; } }

        /// <summary>
        /// Признак оплаты документа вложения Поставщиком
        /// </summary>
        public bool? AttachDocIsVendorPayer { get { return cbAttachDocIsVendorPayer.Visible ? cbAttachDocIsVendorPayer.Checked : (bool?)null; } }

        /// <summary>
        /// Режим редактирования реквизитов вложения
        /// </summary>
        public bool EditRequisitesMode { get; private set; }

        /// <summary>
        /// Признак возможности видеть/редактировать расширенные реквизиты вложения
        /// </summary>
        public bool ExtendedPropertiesCanAccess { get; set; }

        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Фильтр вложения при добавлении
        /// </summary>
        public string AttachmentFilter { get; set; }

        /// <summary>
        /// Возвращает/ устанавливает признак вложений для возвратов поставщику
        /// </summary>
        public bool UseAttachVR { get; set; }

        /// <summary>
        /// Возвращает/ устанавливает признак вложений для распоряжений ГЛС
        /// </summary>
        public bool UseAttachGA { get; set; }

        /// <summary>
        /// Возвращает/ устанавливает признак вложений для макета списаний
        /// </summary>
        public bool UseAttachWF { get; set; }

        /// <summary>
        /// Возвращает/ устанавливает признак вложений для документов качества
        /// </summary>
        public bool UseAttachQK { get; set; }

        #endregion

        #region ИНИЦИАЛИЗАЦИЯ

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public NewAttachmentForm()
        {
            InitializeComponent();
            
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dtpAttachDocDate.Value = DateTime.Today;
            btnOpenFile.Focus();
        }

        public NewAttachmentForm(bool useAttachVR, bool useAttachGA, bool useAttachWF, bool useAttachQK)
            : this()
        {
            this.UseAttachVR = useAttachVR;
            this.UseAttachGA = useAttachGA;
            this.UseAttachWF = useAttachWF;
            this.UseAttachQK = useAttachQK;
        }

        public NewAttachmentForm(string attachDocNumber, DateTime attachDocDate, double? attachDocAmount, bool? attachDocIsVendorPayer)
            : this(attachDocNumber, attachDocDate, attachDocAmount, attachDocIsVendorPayer, false, false, false, false)
        { 
        
        }

        public NewAttachmentForm(string attachDocNumber, DateTime attachDocDate, double? attachDocAmount, bool? attachDocIsVendorPayer, bool useAttachVR, bool useAttachGA, bool useAttachWF, bool useAttachQK)
            : this(useAttachVR, useAttachGA, useAttachWF, useAttachQK)
        {
            EditRequisitesMode = true;

            tbAttachDocNumber.Text = attachDocNumber;
            dtpAttachDocDate.Value = attachDocDate;

            if (attachDocAmount.HasValue)
                nudAttachDocAmount.Value = Convert.ToDecimal(attachDocAmount.Value);
            if (attachDocIsVendorPayer.HasValue)
                cbAttachDocIsVendorPayer.Checked = attachDocIsVendorPayer.Value;
        }

        private void NewAttachmentForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.UseAttachVR)
                    this.docAttachmentTypesTableAdapter.FillVR(complaints.DocAttachmentTypes, this.UserID);
                else if (this.UseAttachGA)
                    this.docAttachmentTypesTableAdapter.FillGA(complaints.DocAttachmentTypes, this.UserID);
                else if (this.UseAttachWF)
                    this.docAttachmentTypesTableAdapter.FillWF(complaints.DocAttachmentTypes, this.UserID);
                else if (this.UseAttachQK)
                    this.docAttachmentTypesTableAdapter.FillWF(complaints.DocAttachmentTypes, this.UserID);
                else
                {
                    this.docAttachmentTypesTableAdapter.Fill(complaints.DocAttachmentTypes, this.UserID, ExtendedPropertiesCanAccess);

                    if (cmbDescription.Tag != null)
                        cmbDescription.SelectedValue = cmbDescription.Tag;
                }

                complaints.DocAttachmentTypes.AddDocAttachmentTypesRow(CUSTOM_ATTACHMENT_TYPE, "Інший...");

                cmbDescription_SelectedIndexChanged(cmbDescription, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox(string.Format("Во время загрузки справочника типов файлов возникла ошибка:\r\n{0}", ex));
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format(this.Text, this.UseAttachVR ? "повернення" : this.UseAttachGA ? "розпорядження" : this.UseAttachWF ? "макета списання" : this.UseAttachQK ? "заяви" : "претензії");

            if (EditRequisitesMode)
            {
                this.Text = string.Format("Зміна реквізитів файла {0}", this.UseAttachVR ? "повернення" : this.UseAttachGA ? "розпорядження" : this.UseAttachWF ? "макета списання" : this.UseAttachQK ? "заяви" : "претензії");

                this.Height -= pnlAttachment.Height;
                pnlAttachment.Visible = false;

                tbAttachDocNumber.Focus();
            }

            if (!ExtendedPropertiesCanAccess)
            {
                nudAttachDocAmount.Visible = lblAttachDocAmount.Visible = false;
                cbAttachDocIsVendorPayer.Visible = false;
            }
        }

        private void cmbDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDescription.Visible = cmbDescription.SelectedValue.Equals(CUSTOM_ATTACHMENT_TYPE);
            tbDescription.Focus();
        }

        /// <summary>
        /// Загрузка текущей папки из конфиг-файла
        /// </summary>
        private void SetCurrentDirectory()
        {
            var myDocsDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            try
            {
                string curDir = Config.LoadSetting(Name, CUR_DIR_SETTING);
                openFileDialog.InitialDirectory = String.IsNullOrEmpty(curDir) ? myDocsDir : curDir;

            }
            catch
            {
                openFileDialog.InitialDirectory = myDocsDir;
            }
        }

        #endregion

        #region ПРИКРЕПЛЕНИЕ ФАЙЛОВ

        /// <summary>
        /// Общий размер всех выбранных файлов
        /// </summary>
        private long totalFileSize = 0;

        /// <summary>
        /// Добавление одного либо нескольких файлов
        /// </summary>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (filePaths.Count > 0)
                    openFileDialog.InitialDirectory = Path.GetDirectoryName(filePaths[0]);

                openFileDialog.Filter = this.AttachmentFilter;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePaths.Clear();
                    foreach (string path in openFileDialog.FileNames)
                        filePaths.Add(path);
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(String.Format("Во время открытия файла {0} произошла ошибка: ",
                    filePaths.Count > 0 ? filePaths[filePaths.Count - 1] : String.Empty), exc);
            }
            finally
            {
                RefreshControls();
            }
        }

        /// <summary>
        /// Обновление формы после выбора файлов
        /// </summary>
        private void RefreshControls()
        {
            totalFileSize = 0;
            var sb = new StringBuilder();
            foreach (string fileName in filePaths)
            {
                var fileInfo = new FileInfo(fileName);
                totalFileSize += fileInfo.Length / 1024;
                sb.AppendLine(fileName);
            }

            lblFileSize.Text = String.Format("{0} КБ", totalFileSize.ToString());
            switch (filePaths.Count)
            {
                case 0:
                    tbxFilePath.Text = String.Empty;
                    tltFilePaths.SetToolTip(tbxFilePath, String.Empty);
                    break;
                case 1:
                    tbxFilePath.Text = filePaths[0];
                    tltFilePaths.SetToolTip(tbxFilePath, String.Empty);
                    break;
                default:
                    tbxFilePath.Text = "Декілька файлів";
                    tltFilePaths.SetToolTip(tbxFilePath, sb.ToString());
                    break;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (EditRequisitesMode)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else if (ValidateData())
            {
                string msg = totalFileSize > WARNING_FILE_SIZE ? 
                    "Внимание! Общий размер файлов очень велик (более 1 мегабайта). " : String.Empty;
                msg += string.Format("Вы действительно хотите добавить к {0} выбранные файлы?", this.UseAttachVR ? "возврату" : this.UseAttachGA ? "распоряжению" : this.UseAttachQK ? "заявке" : "претензии");
                if (MessageBox.Show(msg, "Добавление файлов", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
                    == DialogResult.Yes)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        /// <summary>
        /// Проверка введенных данных
        /// </summary>
        /// <returns>True если все файлы заданы корректно, False если хотя бы с одним файлом есть проблемы</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            if (filePaths.Count == 0)
                msg = "Нужно выбрать хотя бы один файл!";
            else
                foreach (string fileName in filePaths)
                    if (String.IsNullOrEmpty(fileName) || !File.Exists(fileName))
                    {
                        msg = String.Format("Файл {0} не найден!", fileName);
                        break;
                    }

            if (String.IsNullOrEmpty(msg))  // Продолжаем проверку
            {
                if (totalFileSize > ERROR_FILE_SIZE)
                    msg = "Размер файлов превышает максимально допустимый (3 мегабайта)!";
            }

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка файлов", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (cmbDescription.SelectedValue.Equals(CUSTOM_ATTACHMENT_TYPE))
            {
                if (string.IsNullOrEmpty(tbDescription.Text))
                {
                    MessageBox.Show("Описание (тип) файла должно быть указано!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDescription.Focus();
                    return false;
                }
                else
                    return true;
            }
            else 
                return true;
        }

        #endregion
    }
}
