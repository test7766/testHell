using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    /// <summary>
    /// Форма для ввода подписанта со стороны дебитора
    /// </summary>
    public partial class EnterSignaturerForDiscountAct : Form
    {
        /// <summary>
        /// Подписант со стороны дебитора
        /// </summary>
        public string Signaturer { get { return tbxSignaturer.Text; } }

        public EnterSignaturerForDiscountAct()
        {
            InitializeComponent();
        }
    }
}
