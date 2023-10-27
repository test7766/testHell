using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Форма для просмотра списка расходных по сводной налоговой накладной
    /// </summary>
    public partial class NaklSummaryDetailsForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Налоговая накладная, по которой печатаются расходные
        /// </summary>
        private WMSOffice.Data.WH.PI_FindNaklSummaryRow naklSummary;

        /// <summary>
        /// Окно ожидания, используемое при длительной обработке данных.
        /// </summary>
        private SplashForm splashForm = new SplashForm();

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ ДАННЫХ

        public NaklSummaryDetailsForm(WMSOffice.Data.WH.PI_FindNaklSummaryRow pNaklSummary)
        {
            InitializeComponent();
            naklSummary = pNaklSummary;
        }

        /// <summary>
        /// Загрузка расходных по налоговой при инициализации формы
        /// </summary>
        private void NaklSummaryDetailsForm_Load(object sender, EventArgs e)
        {
            try
            {
                tApI_GetNaclSummary_Detail.Fill(wH.PI_GetNaclSummary_Detail, naklSummary.Year, naklSummary.Month,
                    Convert.ToInt32(naklSummary.Doc_Number));
                CalculateSummaries();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Не удалось загрузить расходные по сводной налоговой накладной: " + Environment.NewLine + exc.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Пересчет суммарных значений в накладной
        /// </summary>
        private void CalculateSummaries()
        {
            decimal sumWithoutPDV = 0, sumPDV = 0, sumWithPDV = 0;
            foreach (WMSOffice.Data.WH.PI_GetNaclSummary_DetailRow row in wH.PI_GetNaclSummary_Detail)
            {
                if (!row.IsAmountWithoutVATNull())
                    sumWithoutPDV += row.AmountWithoutVAT;
                if (!row.IsAmountVATNull())
                    sumPDV += row.AmountVAT;
                if (!row.IsAmountWithVATNull())
                    sumWithPDV += row.AmountWithVAT;
            }

            tbxSumWithoutPDV.Text = sumWithoutPDV.ToString();
            tbxPdvSum.Text = sumPDV.ToString();
            tbxSumWithPDV.Text = sumWithPDV.ToString();
        }

        #endregion
    }
}
