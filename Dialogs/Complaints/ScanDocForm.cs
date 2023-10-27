using System;
using System.Windows.Forms;

using WMSOffice.Data.ComplaintsTableAdapters;
using System.Drawing;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для определения документа и получения его идентификатора путем сканирования штрих-кода документа
    /// </summary>
    public partial class ScanDocForm : DialogForm
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private long sessionID;

        /// <summary>
        /// Режим, в котором запускается окно (поштучный контроль претензии, закрытие претензии и т.д.)
        /// </summary>
        private ComplaintsConstants.BarCodeRecognizeMode mode { get; set; }

        /// <summary>
        /// Набор возможных действий с документом, полученный путем запроса к базе по штрих-коду
        /// </summary>
        public Data.Complaints.CustomActionsDataTable CustomActions { get; private set; }

        /// <summary>
        /// Код компании
        /// </summary>
        public string CompanyCode { get; private set; }

        /// <summary>
        /// Тип документа заказа
        /// </summary>
        public string OrderDocType { get; private set; }

        /// <summary>
        /// № документа заказа
        /// </summary>
        public int? OrderDocNumber { get; private set; }

        /// <summary>
        /// Отсканированный штрих-код
        /// </summary>
        public string LastBarcode { get; private set; }

        /// <summary>
        /// True если нужно реализовать автоматическое нажатие Enter после ввода текста, False в противном случае
        /// </summary>
        public bool RaiseTextChangedWithoutEnter
        {
            get { return tbScanner.RaiseTextChangeWithoutEnter; }
            set { tbScanner.RaiseTextChangeWithoutEnter = value; }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public ScanDocForm(long pSessionID, string pCaption, string pDescription, ComplaintsConstants.BarCodeRecognizeMode pMode)
        {
            InitializeComponent();
            sessionID = pSessionID;
            Text = pCaption;
            if (!String.IsNullOrEmpty(pDescription))
                lblDescription.Text = pDescription;
            mode = pMode;
            ButtonOKEnabled = false;
            CustomActions = new Data.Complaints.CustomActionsDataTable();

            btnOK.Location = new Point(200, 8);
            btnCancel.Location = new Point(280, 8);
        }

        #endregion

        #region СКАНИРОВАНИЕ ШТРИХ-КОДА ДОКУМЕНТА

        /// <summary>
        /// Обрабатывает ввод штрих-кода служебной записки / акта аннулирования, выполняя запрос к базе для получения идентификатора документа претензии.
        /// </summary>
        private void tbScanner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LastBarcode = tbScanner.Text;
                using (var adapter = new CustomActionsTableAdapter())
                {
                    switch (mode)
                    {
                        case ComplaintsConstants.BarCodeRecognizeMode.ItemsControl:
                            CustomActions = adapter.ItemsControl_TryStart(sessionID, tbScanner.Text);
                            if (CustomActions == null || CustomActions.Rows.Count == 0)
                                throw new InvalidOperationException("Отсутствуют возможные действия, возвращенные хранимой процедурой начала поштучного контроля.");
                            break;
                        case ComplaintsConstants.BarCodeRecognizeMode.FinishProcessing:
                            var docType = (string)null;
                            var docNumber = (double?)null;
                            CustomActions = adapter.Processing_TryClose(sessionID, tbScanner.Text, ref docNumber, ref docType);
                            this.CompanyCode = "00001";
                            this.OrderDocType = docType;
                            this.OrderDocNumber = docNumber.HasValue ? Convert.ToInt32(docNumber.Value) : (int?)null;
                            if (CustomActions == null || CustomActions.Rows.Count == 0)
                                throw new InvalidOperationException("Отсутствуют возможные действия, возвращенные хранимой процедурой попытки закрытия претензии.");
                            break;
                        default:
                            throw new InvalidOperationException("Неизвестный режим BarCodeRecognizeMode.");
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox(exc.Message);
                tbScanner.Text = String.Empty;
                tbScanner.Focus();
                tbScanner.SelectAll();
            }
        }

        #endregion
    }
}
