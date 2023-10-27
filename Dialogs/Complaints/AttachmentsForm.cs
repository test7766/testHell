using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для добавления файлов при создании клиентской претензии
    /// </summary>
    public partial class AttachmentsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Выделенные в таблице строки
        /// </summary>
        private List<Data.Complaints.AttachmentsRow> SelectedRows
        {
            get
            {
                var result = new List<Data.Complaints.AttachmentsRow>();
                foreach (DataGridViewRow row in dgvFiles.SelectedRows)
                    result.Add((row.DataBoundItem as DataRowView).Row as Data.Complaints.AttachmentsRow);
                return result;
            }
        }

        private Data.Complaints.AttachmentsRow SelectedRow
        {
            get { return (dgvFiles.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.Complaints.AttachmentsRow; }
        }

        /// <summary>
        /// Файлы в таблице
        /// </summary>
        public List<Data.Complaints.AttachmentsRow> Files
        {
            get
            {
                var result = new List<Data.Complaints.AttachmentsRow>();
                foreach (DataGridViewRow row in dgvFiles.Rows)
                    result.Add((row.DataBoundItem as DataRowView).Row as Data.Complaints.AttachmentsRow);
                return result;
            }
        }

        /// <summary>
        /// Фильтр вложений при добавлении
        /// </summary>
        public string AttachmentsFilter { get; set; }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public AttachmentsForm(IEnumerable<Data.Complaints.AttachmentsRow> pFiles)
        {
            InitializeComponent();
            dlgSaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            foreach (var existedRow in pFiles)
            {
                var row = complaints.Attachments.NewAttachmentsRow();
                row.ItemArray = existedRow.ItemArray;
                complaints.Attachments.AddAttachmentsRow(row);
            }
        }

        /// <summary>
        /// Настройка доступности просмотра файла в зависимости от того, выбран ли файл
        /// </summary>
        private void dgvFiles_SelectionChanged(object sender, EventArgs e)
        {
            btnView.Enabled = miView.Enabled = dgvFiles.SelectedRows.Count == 1;
            btnRemove.Enabled = miRemove.Enabled = btnEditAttachmentRequisites.Enabled = miEditAttachmentRequisites.Enabled = dgvFiles.SelectedRows.Count > 0;
        }

        #endregion

        #region ДОБАВЛЕНИЕ НОВОГО ФАЙЛА В ТАБЛИЦУ

        /// <summary>
        /// Добавление к претензии одного или нескольких файлов
        /// </summary>
        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new NewAttachmentForm() { AttachmentFilter = this.AttachmentsFilter };
                if (form.ShowDialog(this) == DialogResult.OK)
                    using (var adapter = new DocAttachmentsTableAdapter())
                        foreach (string fileName in form.FilePaths)
                        {
                            var row = complaints.Attachments.NewAttachmentsRow();
                            var info = new FileInfo(fileName);
                            row.File_Name = Path.GetFileName(fileName);
                            row.File_Data = File.ReadAllBytes(fileName);
                            row.DescriptionType = form.AttachmentDocTypeCode;
                            row.Description = form.AttachmentDocTypeDescription;
                            row.File_Length = Math.Round((double)info.Length / 1024, 1).ToString();
                            row.Document_Number = form.AttachDocNumber;
                            row.Document_Date = form.AttachDocDate;

                            if (form.AttachDocAmount.HasValue)
                                row.Document_Amount = form.AttachDocAmount.Value;
                            if (form.AttachDocIsVendorPayer.HasValue)
                                row.IS_Vendor_Payer = form.AttachDocIsVendorPayer.Value;

                            complaints.Attachments.AddAttachmentsRow(row);
                        }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Во время добавления файлов к претензии возникла ошибка: ", exc);
            }
        }

        #endregion

        #region ПРОСМОТР ВЫДЕЛЕННОГО ФАЙЛА

        /// <summary>
        /// Запуск просмотра выбранного файла по двойному клику
        /// </summary>
        private void dgvFiles_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFiles.SelectedRows.Count == 1)
                View_Click(sender, e);
        }

        /// <summary>
        /// Просмотр выбранного файла
        /// </summary>
        private void View_Click(object sender, EventArgs e)
        {
            try
            {
                string tempFilePath = Path.Combine(Path.GetTempPath(), SelectedRows[0].File_Name);
                File.WriteAllBytes(tempFilePath, SelectedRows[0].File_Data);
                Process.Start(tempFilePath);
                MessageBox.Show("Нажмите \"ОК\" после закрытия программы просмотра для удаления временного файла.");
                DeleteFile(tempFilePath);
            }
            catch (IOException ex1)
            {
                MessageBox.Show("Во время просмотра прикрепленного к претензии файла возникла следующая ошибка:" +
                   Environment.NewLine + ex1.Message + Environment.NewLine + Environment.NewLine + 
                   "Возможно, файл уже открыт для просмотра", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex2)
            {
                MessageBox.Show("Во время просмотра прикрепленного к претензии файла возникла следующая ошибка:" +
                    Environment.NewLine + ex2.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление временного файла, созданного при просмотре
        /// </summary>
        /// <param name="pFileName">Полное название файла, который нужно удалить</param>
        private static void DeleteFile(string pFileName)
        {
            while (true)
            {
                try
                {
                    File.Delete(pFileName);
                    return;
                }
                catch (Exception exc)
                {
                    if (MessageBox.Show("Во время удаления временного файла возникла следующая ошибка:" +
                            Environment.NewLine + exc.Message + Environment.NewLine + Environment.NewLine +
                            "Нажмите \"Повтор\" (\"Retry\") для повторной попытки удаления или \"Отмена\" (\"Cancel\") для отмены",
                            "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Cancel)
                        return;
                }
            }
        }

        #endregion

        #region УДАЛЕНИЕ ВЫБРАННЫХ ФАЙЛОВ

        /// <summary>
        /// Удаление выбранных файлов в таблице
        /// </summary>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            foreach (var row in SelectedRows)
                for (int i = 0; i < complaints.Attachments.Count; i++)
                    if (row == complaints.Attachments[i])
                    {
                        row.Delete();
                        break;
                    }
        }

        #endregion

        private void btnEditAttachmentRequisites_Click(object sender, EventArgs e)
        {
            var form = new NewAttachmentForm(SelectedRow.IsDocument_NumberNull() ? string.Empty : SelectedRow.Document_Number, SelectedRow.IsDocument_DateNull() ? DateTime.Today : SelectedRow.Document_Date, SelectedRow.IsDocument_AmountNull() ? (double?)null : SelectedRow.Document_Amount, SelectedRow.IsIS_Vendor_PayerNull() ? (bool?)null: SelectedRow.IS_Vendor_Payer);
            form.AttachmentFilter = this.AttachmentsFilter;
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                SelectedRow.Document_Number = form.AttachDocNumber;
                SelectedRow.Document_Date = form.AttachDocDate;

                if (form.AttachDocAmount.HasValue)
                    SelectedRow.Document_Amount = form.AttachDocAmount.Value;
                if (form.AttachDocIsVendorPayer.HasValue)
                    SelectedRow.IS_Vendor_Payer = form.AttachDocIsVendorPayer.Value;
            }
        }
    }
}
