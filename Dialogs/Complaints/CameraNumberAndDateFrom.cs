using System;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для ввода номера камеры, под которой проводился поштучный контроль товара
    /// и даты/времени обнаружения проблемы
    /// </summary>
    public partial class CameraNumberAndDateFrom : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор претензии
        /// </summary>
        private readonly long docID;

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public CameraNumberAndDateFrom(long pSessionID, long pDocID)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            LoadExistedInfo();
        }

        /// <summary>
        /// Загрузка номера камеры и даты проблемы, если они редактировались ранее
        /// </summary>
        private void LoadExistedInfo()
        {
            try
            {
                using (var adapter = new CO_Add_Doc_CommentTableAdapter())
                {
                    var table = adapter.GetData(docID, sessionID, null, null, true);
                    if (table != null && table.Count > 0)
                    {
                        var row = table[0];

                        // Устанавливаем номер камеры
                        if (!row.IsCamera_NumberNull())
                            tbxCameraNumber.Text = row.Camera_Number;

                        // Устанавливаем дату обнаружения проблемы
                        if (!row.IsProblem_DateNull())
                            dtpProblemAndDateTime.Value = row.Problem_Date;
                        else
                            chbNoDate.Checked = true;
                    }
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("При проверке ранее введенных данных о камере и времени произошла ошибка: ", exc);
            }
        }

        #endregion

        #region СОХРАНЕНИЕ РЕЗУЛЬТАТОВ РЕДАКТИРОВАНИЯ

        /// <summary>
        /// Настройка доступности выбора даты обнаружения проблемы 
        /// (если задана опция "дата не определена", то выбор даты не доступен)
        /// </summary>
        private void chbNoDate_CheckedChanged(object sender, EventArgs e)
        {
            dtpProblemAndDateTime.Enabled = !(sender as CheckBox).Checked;
        }

        /// <summary>
        /// Сохранение результатов редактирования и закрытие окна
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                using (var adapter = new CO_Add_Doc_CommentTableAdapter())
                    adapter.AddDocComment(docID, sessionID, tbxCameraNumber.Text,
                        chbNoDate.Checked ? null : (DateTime?)dtpProblemAndDateTime.Value, false);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при сохранении введенных данных:", exc);
            }
        }

        #endregion
    }
}
