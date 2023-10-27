using System;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Форма для внесения данных по отгрузке товара
    /// </summary>
    public partial class ShippingReturnToCarForm : Form
    {
        #region ПЕРЕМЕННЫЕ И СВОЙСТВА КЛАССА

        /// <summary>
        /// Дата отгрузки
        /// </summary>
        public DateTime ShippingDate { get { return dtpShipDate.Value; } }

        /// <summary>
        /// Номер автомобиля, который забрал возврат
        /// </summary>
        public string CarNumber { get { return tbxCarNumber.Text; } }

        /// <summary>
        /// ФИО водителя, который забрал накладную
        /// </summary>
        public string DriverName { get { return tbxDriver.Text; } }

        /// <summary>
        /// Признак необходимости проверки введеных данных
        /// </summary>
        public bool CheckDataBeforeSave { get; set; }

        #endregion

        #region КОНСТРУКТОР

        public ShippingReturnToCarForm()
        {
            InitializeComponent();
        }

        #endregion

        #region СОХРАНЕНИЕ ДАННЫХ

        /// <summary>
        /// Проверка входных данных на корректность
        /// </summary>
        /// <returns>True, если данные внесены верно, False если данных не хватает</returns>
        private bool CheckData()
        {
            if (this.CheckDataBeforeSave)
            {
                if (String.IsNullOrEmpty(CarNumber))
                {
                    MessageBox.Show("Должен быть указан номер автомобиля, который забрал возврат!", "Неверные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else if (String.IsNullOrEmpty(DriverName))
                {
                    MessageBox.Show("Должен быть указаны ФИО водителя, который забрал накладную!", "Неверные данные",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Сохранение данных по отгрузке возврата в БД
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        #endregion
    }
}
