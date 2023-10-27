using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Форма для задания параметров печати реестра
    /// </summary>
    public partial class PrintNaklSummaryReestrForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        private readonly long sessionID;

        /// <summary>
        /// Идентификатор дебитора для накладной, по которой загрузили форму
        /// </summary>
        private readonly int debtorId;

        /// <summary>
        /// Номер накладной
        /// </summary>
        public int NaklNumber
        {
            get { return String.IsNullOrEmpty(tbxNaklNumber.Text) ? -1 : Convert.ToInt32(tbxNaklNumber.Text); }
            private set { tbxNaklNumber.Text = value.ToString(); }
        }

        /// <summary>
        /// Дата с
        /// </summary>
        public DateTime DateFrom 
        { 
            get { return dtpDateFrom.Value; }
            private set { dtpDateFrom.Value = value; }
        }

        /// <summary>
        /// Дата по
        /// </summary>
        public DateTime DateTo
        {
            get { return dtpDateTo.Value; }
            set { dtpDateTo.Value = value; }
        }

        /// <summary>
        /// True, если включен режим печати реестра по одной накладной, 
        /// False если включен режим печати реестра сразу по нескольким накладным
        /// </summary>
        public bool ForNakl { get { return rbtNaklNumber.Checked; } }

        /// <summary>
        /// Идентификатор выбранного дебитора
        /// </summary>
        public int DebtorId { get { return Convert.ToInt32(cmbDebtorId.SelectedValue); } }

        /// <summary>
        /// True, если реестр формируется только по сводным накладным, 
        /// False если реестр формируется по всем накладным
        /// </summary>
        public bool OnlyNaklsSummary { get { return rbtOnlySummary.Checked; } }

        public RegistryType RegistryType
        {
            get 
            {
                if (rbtOnlySummary.Checked)
                    return RegistryType.SummaryInvoice;
                if (rbtAll.Checked)
                    return RegistryType.Invoice;
                if (rbtAllExtended.Checked)
                    return RegistryType.InvoiceExtended;

                throw new NotSupportedException("Не известный тип реестра");
            }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ КЛАССА

        public PrintNaklSummaryReestrForm(int pNaklNumber, int pDebtorId, long pSessionID, bool pShortRegister)
        {
            InitializeComponent();
            sessionID = pSessionID;
            debtorId = pDebtorId;
            NaklNumber = pNaklNumber;
            var month = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateFrom = month.AddMonths(-1);
            DateTo = month.AddDays(-1);
            CustomControlsByMode(pShortRegister);
        }

        /// <summary>
        /// Настройка контрола в зависимости от режима (реестры по всем накладным или только по суммам)
        /// </summary>
        /// <param name="pShortRegister">True если нужно загрузить реестр только по суммам, False если по всем накладным</param>
        private void CustomControlsByMode(bool pShortRegister)
        {
            if (pShortRegister)
            {
                grbNaklNumber.Visible = rbtNaklNumber.Visible = false;
                grbFewNakl.Location = new Point(12, 12);
                rbtFewNakls.Checked = true;
                pnlLoadType.Visible = true;
                rbtFewNakls.Visible = false;
            }
            else
                pnlSettings.Location = pnlLoadType.Location;

            int btnLocationY = grbFewNakl.Size.Height + grbFewNakl.Location.Y + 8;
            btnOk.Location = new Point(btnOk.Location.X, btnLocationY);
            btnCancel.Location = new Point(btnCancel.Location.X, btnLocationY);
        }

        /// <summary>
        /// Загрузка списка дебиторов
        /// </summary>
        private void PrintNaklSummaryReestrForm_Load(object sender, EventArgs e)
        {
            try
            {
                taDebitors.Fill(printNaklSummary.Debitors, sessionID);
                if (cmbDebtorId.Items.Count == 0)
                    throw new ApplicationException("Процедура [dbo].[pr_PI_Get_debitors] не возвратила ни одного дебитора!");
                cmbDebtorId.SelectedValue = debtorId;
                rbt_CheckedChanged(this, EventArgs.Empty);
            }
            catch (Exception exc)
            {
                Logger.ShowErrorMessageBox("Возникла ошибка во время загрузки списка дебиторов: ", exc);
                Close();
            }
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Переключение между режимами загрузки реестра
        /// </summary>
        private void rbt_CheckedChanged(object sender, EventArgs e)
        {
            grbNaklNumber.Enabled = rbtNaklNumber.Checked;
            grbFewNakl.Enabled = rbtFewNakls.Checked;
        }

        #endregion
    }

    /// <summary>
    /// Тип реестра
    /// </summary>
    public enum RegistryType
    {
        /// <summary>
        /// Сводные накладные
        /// </summary>
        SummaryInvoice,
        /// <summary>
        /// Все накладаные
        /// </summary>
        Invoice,
        /// <summary>
        /// Все накладные (расширенный)
        /// </summary>
        InvoiceExtended
    }
}
