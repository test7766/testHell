using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    /// <summary>
    /// Форма для редактирования количества
    /// </summary>
    public partial class SetQuantityForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА

        /// <summary>
        /// Минимально возможное значение для ввода
        /// </summary>
        private int minValue;

        /// <summary>
        /// Максимально возможное значение для ввода
        /// </summary>
        private int maxValue;

        /// <summary>
        /// Количество, введенное в окне
        /// </summary>
        public int Quantity
        {
            get { return Convert.ToInt32(tbxQuantity.Text); }
            set { tbxQuantity.Text = value.ToString(); }
        }

        #endregion

        #region КОНСТРУКТОР И ИНИЦИАЛИЗАЦИЯ

        public SetQuantityForm(int pMinValue, int pMaxValue) 
        {
            InitializeComponent();
            minValue = pMinValue;
            maxValue = pMaxValue;
        }

        /// <summary>
        /// После загрузки окна сразу устанавливаем фокус на текстовое поле Количество
        /// </summary>
        private void SetQuantityForm_Load(object sender, EventArgs e)
        {
            tbxQuantity.Focus();
            tbxQuantity.SelectAll();
        }

        #endregion

        #region ПРОВЕРКА ДАННЫХ И ЗАКРЫТИЕ ОКНА

        /// <summary>
        /// По нажатию на кнопку ОК проверяем данные и закрываем окно
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        /// <summary>
        /// Проверка данных и закрытие окна
        /// </summary>
        private void CloseWindow()
        {
            if (ValidateData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        /// <summary>
        /// По нажатию на кнопку Enter в текстовом поле "Количество" закрываем окно
        /// </summary>
        private void tbxQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                CloseWindow();
        }

        /// <summary>
        /// Проверка введенных данных на корректность
        /// </summary>
        /// <returns>True если количество введено правильно, False если количество введено некорректно</returns>
        private bool ValidateData()
        {
            string msg = String.Empty;
            int quantity;
            if (String.IsNullOrEmpty(tbxQuantity.Text))
                msg = "Нужно ввести количество!";
            else if (!Int32.TryParse(tbxQuantity.Text, out quantity) || quantity > maxValue || quantity < minValue)
                msg = String.Format("Количество должно быть целым числом между {0} и {1}!", minValue, maxValue);

            if (String.IsNullOrEmpty(msg))
                return true;
            else
            {
                Logger.ShowErrorMessageBox(msg);
                tbxQuantity.Focus();
                tbxQuantity.SelectAll();
                return false;
            }
        }

        #endregion
    }
}
