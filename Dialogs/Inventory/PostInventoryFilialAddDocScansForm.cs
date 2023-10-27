using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Окно для добавления/просмотра добавленных к документу инвентаризации файлов
    /// </summary>
    public partial class PostInventoryFilialAddDocScansForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Документ инвентаризации, для которого добавляются файлы
        /// </summary>
        private readonly Data.Inventory.FP_Get_Correction_DocumentsRow invDoc;

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Критичный размер файла, при котором пользователю будет отображена ошибка (3 МБ)
        /// </summary>
        private const long MAX_FILE_SIZE = 3128576;

        /// <summary>
        /// Файл, выбранный в таблице
        /// </summary>
        private Data.Inventory.FP_Get_Correction_AttachmentsRow SelectedFile
        {
            get
            {
                var dgvRow = dgvFiles.SelectedRows[0];
                return (dgvRow.DataBoundItem as DataRowView).Row as Data.Inventory.FP_Get_Correction_AttachmentsRow;
            }
        }

        #endregion

        #region КОНСТРУКТОР

        public PostInventoryFilialAddDocScansForm(int pSessionID, Data.Inventory.FP_Get_Correction_DocumentsRow pInvDoc)
        {
            InitializeComponent();
            sessionID = pSessionID;
            invDoc = pInvDoc;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        /// <summary>
        /// Загрузка файлов при загрузке окна
        /// </summary>
        private void PostInventoryFilialAddDocScansForm_Load(object sender, EventArgs e)
        {
            LoadFiles();
        }

        /// <summary>
        /// Загрузка файлов в таблицу
        /// </summary>
        private void LoadFiles()
        {
            try
            {
                taFpGetCorrectionAttachments.Fill(inventory.FP_Get_Correction_Attachments,
                    sessionID, invDoc.___документа);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при загрузке прикрепленных файлов: ", exc);
                inventory.FP_Get_Correction_Attachments.Clear();
            }
        }

        #endregion

        #region ДОБАВЛЕНИЕ/УДАЛЕНИЕ ФАЙЛОВ

        /// <summary>
        /// True, если последней нажатой кнопкой был Escape (это нужно, чтобы отменять в таком случае редактирование названия)
        /// </summary>
        private bool wasEscapePressed;

        /// <summary>
        /// Добавление файла к документу по нажатию на кнопку "Добавить"
        /// </summary>
        private void btnAddDoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                {
                    var fileInfo = new FileInfo(openFileDialog.FileName);
                    if (fileInfo.Length > MAX_FILE_SIZE * 5)
                    {
                        MessageBox.Show("Размер файла превышает допустимый (3Мб)!", "Выбор файла", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    else
                    {
                        var nameDesc = TypeNameAndDescription(fileInfo.Name);
                        if (nameDesc == null)
                            return;
                        else
                            AddAttachment(nameDesc[0], nameDesc[1], File.ReadAllBytes(openFileDialog.FileName));
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при добавлении файла:", exc);
            }
        }

        /// <summary>
        /// Ввод названия и описания файла. Возвращается null, если при вводе была нажата кнопка "Отмена"
        /// </summary>
        /// <param name="pFileName">Название файла на компьютере пользователя</param>
        /// <returns>Список, где первый элемент - название, второй - описание</returns>
        private List<string> TypeNameAndDescription(string pFileName)
        {
            var window = new PostInventoryFilialEnterNameAndDescForm(pFileName);
            if (window.ShowDialog(this) == DialogResult.OK)
            {
                var result = new List<string>();
                result.Add(window.FileName);
                result.Add(window.Description);
                return result;
            }
            else
                return null;
        }

        /// <summary>
        /// Добавление файла в БД
        /// </summary>
        /// <param name="pFileName">Название добавляемого файла</param>
        /// <param name="pFileDescription">Описание добавляемого файла</param>
        /// <param name="pFileData">Содержимое файла</param>
        private void AddAttachment(string pFileName, string pFileDescription, byte[] pFileData)
        {
            long id = Convert.ToInt64(taFpGetCorrectionAttachments.AddCorrectionAttachment(invDoc.___документа, pFileName,
                pFileDescription, pFileData, sessionID, null));
            LoadFiles();
        }

        /// <summary>
        /// Удаление выделенного файла из БД
        /// </summary>
        private void btnRemoveDoc_Click(object sender, EventArgs e)
        {
            try
            {
                taFpGetCorrectionAttachments.AddCorrectionAttachment(invDoc.___документа, SelectedFile.File_Name, SelectedFile.Description,
                    null, sessionID, SelectedFile.Attachment_ID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Ошибка при удалении файла из БД:", exc);
            }
        }

        /// <summary>
        /// Проверка, был ли нажат Escape (используется для отмены редактирования)
        /// </summary>
        protected override bool ProcessDialogKey(Keys pKeyData)
        {
            wasEscapePressed = pKeyData == Keys.Escape;
            return base.ProcessDialogKey(pKeyData);
        }

        /// <summary>
        /// Редактирование названия файла и описания прямо в таблице
        /// </summary>
        private void dgvFiles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var dgv = sender as DataGridView;
                var row = ((dgv.Rows[e.RowIndex]).DataBoundItem as DataRowView).Row as Data.Inventory.FP_Get_Correction_AttachmentsRow;
                taFpGetCorrectionAttachments.AddCorrectionAttachment(invDoc.___документа, row.File_Name, row.Description,
                    row.File_Data, sessionID, row.Attachment_ID);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Не удалось отредактировать название/описание файла: ", exc);
                LoadFiles();
            }
        }

        /// <summary>
        /// Проверка, задано ли имя файла
        /// </summary>
        private void dgvFiles_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            var dgv = sender as DataGridView;

            if (dgv.Columns[e.ColumnIndex] != clFileName)
                return;

            if ((String.IsNullOrEmpty(e.FormattedValue.ToString()) && !wasEscapePressed))
            {
                MessageBox.Show("Название должно быть обязательно задано!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
                return;
            }
        }

        /// <summary>
        /// Закрытие окна
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region ПРОСМОТР ФАЙЛОВ

        /// <summary>
        /// Отображение выбранного в таблице файла (на панели справа)
        /// </summary>
        private void dgvFiles_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count > 0)
            {
                var dbRow = (dgvFiles.SelectedRows[0].DataBoundItem as DataRowView).Row as 
                    Data.Inventory.FP_Get_Correction_AttachmentsRow;
                var img = ByteToImage(dbRow.File_Data);
                pbImageDisplaying.Visible = !(img == null);
                lblNotPicture.Visible = img == null;
                pbImageDisplaying.Image = ByteToImage(dbRow.File_Data);
            }

            btnRemoveDoc.Enabled = dgvFiles.SelectedRows.Count > 0;
        }

        /// <summary>
        /// Конвертация массива байтов в рисунок
        /// </summary>
        /// <param name="pByteArray">Массив байтов</param>
        /// <returns>Рисунок</returns>
        public static Bitmap ByteToImage(byte[] pByteArray)
        {
            try
            {
                var mStream = new MemoryStream();
                mStream.Write(pByteArray, 0, Convert.ToInt32(pByteArray.Length));
                var bm = new Bitmap(mStream, false);
                mStream.Dispose();
                return bm;
            }
            catch { return null; }
        }

        #endregion
    }
}
