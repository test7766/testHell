using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs
{
    /// <summary>
    /// Форма для внесения периода дат
    /// </summary>
    public partial class DatePeriodEnterForm : Form
    {
        /// <summary>
        /// Дата начала периода
        /// </summary>
        public DateTime DateFrom
        {
            get { return dtpDateFrom.Value; }
            set { dtpDateFrom.Value = value; }
        }

        /// <summary>
        /// Дата конца периода
        /// </summary>
        public DateTime DateTo
        {
            get { return dtpDateTo.Value; }
            set { dtpDateTo.Value = value; }
        }

        public DatePeriodEnterForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Закрытие окна с положительным результатом
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
