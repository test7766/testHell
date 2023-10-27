using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    /// <summary>
    /// Форма для задания названия и описания файла
    /// </summary>
    public partial class PostInventoryFilialEnterNameAndDescForm : Form
    {
        /// <summary>
        /// Введенное название файла
        /// </summary>
        public string FileName { get { return tbxName.Text; } }

        /// <summary>
        /// Введенное описание файла
        /// </summary>
        public string Description { get { return tbxDescription.Text; } }

        public PostInventoryFilialEnterNameAndDescForm(string pFileName)
        {
            InitializeComponent();
            tbxName.Text = pFileName;
        }

        /// <summary>
        /// Закрытие окна - все данные введены
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
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
        /// <returns>True, если данные заданы верно, False если есть ошибки</returns>
        private bool ValidateData()
        {
            if (String.IsNullOrEmpty(tbxName.Text))
            {
                MessageBox.Show("Название не может быть пустым!", "Неверные данные", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
    }
}
