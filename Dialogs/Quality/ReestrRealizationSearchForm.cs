using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для задания параметров загрузки накладных для печати реестров ЛС, которые реализовуются
    /// </summary>
    public partial class ReestrRealizationSearchForm : Form
    {
        #region СВОЙСТВА

        /// <summary>
        /// Номер накладной, заданный на форме
        /// </summary>
        public int? InvoiceNumber
        {
            get
            {
                return String.IsNullOrEmpty(tbxInvoiceNumber.Text) ? null : (int?)Convert.ToInt32(tbxInvoiceNumber.Text);
            }
        }

        /// <summary>
        /// Номер сборочного листа, заданный на форме
        /// </summary>
        public int? PickListNumber
        {
            get
            {
                return String.IsNullOrEmpty(tbxPickListNumber.Text) ? null : (int?)Convert.ToInt32(tbxPickListNumber.Text);
            }
        }

        /// <summary>
        /// Код дебитора, заданный на форме
        /// </summary>
        public int? DebitorID
        {
            get
            {
                return String.IsNullOrEmpty(tbxDebitorID.Text) ? null : (int?)Convert.ToInt32(tbxDebitorID.Text);
            }
        }

        /// <summary>
        /// Дата с, заданная на форме
        /// </summary>
        public DateTime DateFrom { get { return dtpDateFrom.Value; } }

        /// <summary>
        /// Дата по, заданная на форме
        /// </summary>
        public DateTime DateTo { get { return dtpDateTo.Value; } }

        #endregion

        #region КОНСТРУКТОР

        public ReestrRealizationSearchForm(int? pInvoiceNumber, int? pPiclListNumber, int? pDebitorID,
            DateTime? pDateFrom, DateTime? pDateTo)
        {
            InitializeComponent();
            if (pInvoiceNumber.HasValue)
                tbxInvoiceNumber.Text = pInvoiceNumber.Value.ToString();
            if (pPiclListNumber.HasValue)
                tbxPickListNumber.Text = pPiclListNumber.Value.ToString();
            if (pDebitorID.HasValue)
                tbxDebitorID.Text = pDebitorID.Value.ToString();
            if (pDateFrom.HasValue)
                dtpDateFrom.Value = pDateFrom.Value;
            if (pDateTo.HasValue)
                dtpDateTo.Value = pDateTo.Value;
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Закрытие окна - настройки заданы
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
        /// Проверка введенных данных на правильность
        /// </summary>
        /// <returns>True если данные введены правильно, False в противном случае</returns>
        private bool ValidateData()
        {
            int number;
            string msg = String.Empty;
            if (!String.IsNullOrEmpty(tbxInvoiceNumber.Text) && !Int32.TryParse(tbxInvoiceNumber.Text, out number))
                msg = "Номер накладной должен быть целым числом!";
            else if (!String.IsNullOrEmpty(tbxPickListNumber.Text) && !Int32.TryParse(tbxPickListNumber.Text, out number))
                msg = "Номер сборочного должен быть целым числом!";
            else if (!String.IsNullOrEmpty(tbxDebitorID.Text) && !Int32.TryParse(tbxDebitorID.Text, out number))
                msg = "Код дебитора должен быть целым числом!";

            if (!String.IsNullOrEmpty(msg))
            {
                Logger.ShowErrorMessageBox(msg);
                return false;
            }

            return true;
        }

        #endregion
    }
}
