using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using WMSOffice.Classes;
using WMSOffice.Data.AdminTableAdapters;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для ввода параметров по анализу серии
    /// </summary>
    public partial class SetAnalizForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Режим запуска окна редактирования данных об анализе
        /// </summary>
        private readonly SetAnalizFormMode mode;

        /// <summary>
        /// Строка заявки, для которой редактируются данные анализа
        /// </summary>
        private readonly Data.Quality.DocDetailsRow currentLine;

        /// <summary>
        /// Номер анализа
        /// </summary>
        public string Number { get { return tbxNumber.Text; } }

        /// <summary>
        /// Дата анализа
        /// </summary>
        public DateTime SelectedDate { get { return dtpDateFrom.Value; } }

        /// <summary>
        /// Код компании, которая провела анализ
        /// </summary>
        public int CompanyID { get { return (int)cmbCompany.SelectedValue; } }

        /// <summary>
        /// Дата получения образцов из лаборатории
        /// </summary>
        public DateTime? ReceiptDate { get { return chbReceipt.Checked ? (DateTime?)dtpDateReceipt.Value : null; } }

        /// <summary>
        /// Дата передачи образцов в инспекцию
        /// </summary>
        public DateTime? DeliveryDate { get { return chbDelivery.Checked ? (DateTime?)dtpDateDelivery.Value : null; } }

        /// <summary>
        /// Режим запуска окна редактирования данных об анализе
        /// </summary>
        public SetAnalizFormMode Mode { get { return mode; } }

        /// <summary>
        /// True если результат анализа отрицательный, False если результат анализа положительный
        /// </summary>
        public bool IsNegativeAnaliz { get { return chbNegativeAnaliz.Checked; } }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SetAnalizForm(long pSessionID, Data.Quality.DocDetailsRow pLine, SetAnalizFormMode pMode)
        {
            InitializeComponent();
            sessionID = pSessionID;
            currentLine = pLine;
            mode = pMode;

            FillCompanies();
            CustomControls();
        }

        private void FillCompanies()
        {
            try
            {
                analizCompanyTableAdapter.Fill(quality.AnalizCompany, sessionID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Настройка контролов в зависимости от режима запуска окна
        /// </summary>
        private void CustomControls()
        {
            tbxNumber.Text = currentLine.IsAnalizNumNull() ? String.Empty : currentLine.AnalizNum;
            dtpDateFrom.Value = currentLine.IsAnalizDateNull() ? DateTime.Now : currentLine.AnalizDate;
            
            cmbCompany.SelectedValue = currentLine.IsAnalizCompanyIDNull() ? quality.AnalizCompany[0].id : currentLine.AnalizCompanyID;
            cmbCompany.Enabled = mode == SetAnalizFormMode.Receipt;

            dtpDateReceipt.Value = (mode == SetAnalizFormMode.Receipt || currentLine.IsAnalizReceiptDateNull()) ?
                DateTime.Now : currentLine.AnalizReceiptDate;
            dtpDateDelivery.Value = currentLine.IsAnalizDeliveryDateNull() ? DateTime.Now : currentLine.AnalizDeliveryDate;

            chbReceipt.Enabled = chbReceipt.Checked = dtpDateReceipt.Enabled = 
                dtpDateFrom.Enabled = tbxNumber.Enabled = lblDateFrom.Enabled = lblNumber.Enabled = mode == SetAnalizFormMode.Receipt;
            chbDelivery.Checked = dtpDateDelivery.Enabled = mode == SetAnalizFormMode.Delivery;
            chbDelivery.Enabled = mode != SetAnalizFormMode.EditData;
            grbResult.Enabled = chbDelivery.Enabled || chbReceipt.Enabled;
        }

        /// <summary>
        /// Загрузка признаков анализа для строки заявки
        /// </summary>
        private void SetAnalizForm_Load(object sender, EventArgs e)
        {
            CustomTwoListControl();
            SetFocus();
        }

        /// <summary>
        /// Настройка двосвязного списка для редактирования признаков анализа
        /// </summary>
        private void CustomTwoListControl()
        {
            tlcFeatures.Parameters.Add(new KeyValuePair<string, object>("session_id", sessionID));
            tlcFeatures.Parameters.Add(new KeyValuePair<string, object>("doc_id", currentLine.Doc_ID));
            tlcFeatures.CanBind = true;
            tlcFeatures.SelectedListParamValue = currentLine.Line_ID;
        }

        /// <summary>
        /// Установка фокуса на первый доступный контрол
        /// </summary>
        private void SetFocus()
        {
            if (tbxNumber.Enabled)
                tbxNumber.Focus();
            else if (dtpDateDelivery.Enabled)
                dtpDateDelivery.Select();
            else
                tlcFeatures.Select();
        }

        #endregion

        #region ВВЕДЕНИЕ ИНФОРМАЦИИ ПО АНАЛИЗУ

        /// <summary>
        /// Настройка доступности редакторов дат в зависимости от соответствующих флажков
        /// </summary>
        private void chb_CheckedChanged(object sender, EventArgs e)
        {
            dtpDateReceipt.Enabled = (chbReceipt.Enabled && chbReceipt.Checked);
            dtpDateDelivery.Enabled = (chbDelivery.Enabled && chbDelivery.Checked);  
        }

        /// <summary>
        /// Меняем дату отправки в Инспекцию при получении образца из лаборатории
        /// </summary>
        private void dtpReceiptDate_ValueChanged(object sender, EventArgs e)
        {
            if (chbDelivery.Enabled && !chbDelivery.Checked)
                dtpDateDelivery.Value = dtpDateReceipt.Value;
        }

        /// <summary>
        /// Данные введены - сохраняем данные
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если все данные введены правильно, False если есть некорректные либо отсутствующие данные</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;

            if (String.IsNullOrEmpty(tbxNumber.Text) && !chbNegativeAnaliz.Checked)
                msg = "Номер анализа должен быть обязательно задан!";

            if (!String.IsNullOrEmpty(msg))
            {
                MessageBox.Show(msg, "Проверка данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
                return true;
        }

        /// <summary>
        /// Добавление нескольких признаков анализа для строки заявки
        /// </summary>
        private bool tlcFeatures_OnAddItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                taQkGetAnalysisFeatures.AddAnalysisFeaturesForDocDetail(sessionID, currentLine.Doc_ID,
                    currentLine.Line_ID, CreateAnalysisFeatureIdsString(e));
                return true;
            }
            catch { return false; }
        }

        /// <summary>
        /// Создание строки с идентификаторами признаков анализа для передачи в процедуру
        /// </summary>
        /// <param name="pCol">Коллекция ListViewItem-ов - признаков анализа, из которых нужно составить строку</param>
        /// <returns>Строка с идентификаторами признаков анализа для передачи в процедуру</returns>
        private string CreateAnalysisFeatureIdsString(ListView.SelectedListViewItemCollection pCol)
        {
            var str = new StringBuilder();
            foreach (ListViewItem item in pCol)
            {
                if (str.Length > 0)
                    str.Append(",");
                str.Append(item.Name);
            }

            return str.ToString();
        }

        /// <summary>
        /// Удаление нескольких признаков анализа для строки заявки
        /// </summary>
        private bool tlcFeatures_OnDeleteItem(object sender, ListView.SelectedListViewItemCollection e)
        {
            try
            {
                taQkGetAnalysisFeatures.DeleteAnalysisFeaturesForDocDetail(sessionID, currentLine.Doc_ID,
                    currentLine.Line_ID, CreateAnalysisFeatureIdsString(e));
                return true;
            }
            catch { return false; }
        }

        #endregion
    }

    /// <summary>
    /// Режимы, в которых может запускаться окно редактирования данных об анализе
    /// </summary>
    public enum SetAnalizFormMode
    {
        /// <summary>
        /// Режим обозначения факта получения анализа
        /// </summary>
        Receipt = 1, 

        /// <summary>
        /// Режим обозначения факта отправки результатов анализа в Инспекцию
        /// </summary>
        Delivery = 2,

        /// <summary>
        /// Редактирование данных об анализе
        /// </summary>
        EditData = 3
    }
}
