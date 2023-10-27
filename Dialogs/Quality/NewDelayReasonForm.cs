using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class NewDelayReasonForm : Form
    {
        #region ОСНОВНЫЕ ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Название поставщика заявки ОК, для которой открыто окно причин задержки
        /// </summary>
        private readonly string vendorName;

        /// <summary>
        /// Идентификатор заявки ОК, для которой открыто окно причин задержки
        /// </summary>
        private readonly long docID;

        /// <summary>
        /// Идентификатор типа причины
        /// </summary>
        public int ReasonTypeID { get { return Convert.ToInt32(cmbReasonTypes.SelectedValue); } }

        /// <summary>
        /// Номер заявки ГСПО либо null если ответственный не сотрудник ГСПО
        /// </summary>
        public int? GspoTask { get { return tbxGspoRequest.Enabled ? (int?)Convert.ToInt32(tbxGspoRequest.Text) : null; } }

        /// <summary>
        /// Описание проблемы
        /// </summary>
        public string Description { get { return tbxDescription.Text; } }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public NewDelayReasonForm(long pSessionID, long pDocID, string pVendorName)
        {
            InitializeComponent();
            sessionID = pSessionID;
            docID = pDocID;
            vendorName = pVendorName;
        }

        /// <summary>
        /// Загрузка доступных причин задержки при загрузке окна
        /// </summary>
        private void NewDelayReasonForm_Load(object sender, EventArgs e)
        {
            if (!LoadReasonTypes())
                Close();
        }

        /// <summary>
        /// Загрузка доступных причин задержки заявки ОК
        /// </summary>
        /// <returns>True если загрузка прошла успешно, False если с ошибкой</returns>
        private bool LoadReasonTypes()
        {
            try
            {
                taQkDelayReasonTypes.Fill(quality.QK_Delay_Reason_Types, sessionID);
                if (quality.QK_Delay_Reason_Types.Count > 0)
                {
                    RefreshResponsiblePerson();
                    return true;
                }
                else
                {
                    Logger.ShowErrorMessageBox("Нет ни одной доступной причины задержки. Дальнейшая работа с окном невозможна!");
                    return false;
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки доступных причин задержки. Дальнейшая работа с окном невозможна!", exc);
                return false;
            }
        }

        #endregion

        #region ОПРЕДЕЛЕНИЕ ОТВЕТСТВЕННОГО

        /// <summary>
        /// Сообщение об ошибке в заполнении данных или пустая строка (либо null), если данные заполнены правильно
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Изменение ответственного при изменении типа причины задержки
        /// </summary>
        private void cmbReasonTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbReasonTypes.SelectedItem == null)    // В этом случае окно закроется само
                return;
            RefreshResponsiblePerson();
        }

        /// <summary>
        /// Обновление ответственного по заявке
        /// </summary>
        private void RefreshResponsiblePerson()
        {
            try
            {
                var reasonTypeID = Convert.ToInt32(cmbReasonTypes.SelectedValue);
                var resp = taQkDelayReasonsRespEmployee.GetData(sessionID, docID, reasonTypeID, vendorName, tbxGspoRequest.Text.Trim());
                var row = resp[0];

                tbxResponsible.Text = row.responsible;
                errorMessage = row.Iserror_msgNull() ? String.Empty : row.error_msg;
                lblGspoRequest.Enabled = tbxGspoRequest.Enabled = row.need_GSPO_number;

                //if (reasonTypeID == 15)
                //{
                //    tbxResponsible.Text = "";
                //    tbxResponsible.ReadOnly = false;
                //}
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка при определении ответственного по заявке:", exc);
                lblGspoRequest.Enabled = tbxGspoRequest.Enabled = false;
                errorMessage = "При загрузке ответственного возникла ошибка! Поробуйте закрыть окно и попробовать еще раз";
            }
        }

        /// <summary>
        /// Определение нового ответственного при изменении номера заявки ГСПО
        /// </summary>
        private void tbxGspoRequest_TextChanged(object sender, EventArgs e)
        {
            RefreshResponsiblePerson();
        }

        /// <summary>
        /// При выходе из окна проверяем, есть ли ответственный
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(errorMessage))
                Logger.ShowErrorMessageBox(errorMessage);
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }
}
