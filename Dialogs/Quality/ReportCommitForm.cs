using System;
using System.Windows.Forms;

using CrystalDecisions.CrystalReports.Engine;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Окно для просмотра и подтверждения отчета 
    /// </summary>
    public partial class ReportCommitForm : Form
    {
        /// <summary>
        /// True, если нужно подтвердить и распечатать отчет, False если только подтвердить 
        /// </summary>
        public bool NeedToPrint { get; private set; }

        public ReportCommitForm(ReportClass pReportToView, bool pCanPrint)
        {
            InitializeComponent();
            btnPrint.Enabled = pCanPrint;
            if (pReportToView == null)
                throw new ArgumentNullException("Отображаемый отчет равен NULL!");

            crvViewer.ReportSource = pReportToView;
        }

        /// <summary>
        /// Подтверждение отчета
        /// </summary>
        private void btnCommit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            NeedToPrint = sender == btnPrint;
            Close();
        }
    }
}
