using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class QuantityChangeControl : BaseControl
    {
        public QuantityChangeControl()
        {
            InitializeComponent();
        }

        #region свойства

        /// <summary>
        /// Изначальное количество
        /// </summary>
        public int OriginalQuantity { get; set; }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Отмененное количество
        /// </summary>
        public int CanceledQuantity
        {
            get { return OriginalQuantity - Quantity; }
        }

        /// <summary>
        /// Опция "переместить на полку недостач весь доступный остаток"
        /// </summary>
        public bool MoveAllRemains
        {
            get { return chbMoveAllRemains.Checked; }
            set { chbMoveAllRemains.Checked = value; }
        }

        #endregion

        #region обработчики событий элемента управления

        /// <summary>
        /// Обработчик события загрузки элемента управления
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuantityChangeControl_Load(object sender, EventArgs e)
        {
            tbQuantity.Text = Quantity.ToString();
        }

        /// <summary>
        /// Обработка изменения значения поля Количество
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (int.TryParse(tbQuantity.Text, out quantity))
            {
                // правильное значение
                if (quantity >= 0 && quantity < OriginalQuantity)
                {
                    SetQuantityStyle(false, "");
                    Quantity = quantity;
                } 
                else
                    SetQuantityStyle(true, "Конечное количество должно быть больше или равно 0 и меньше Исходного количества.");
            } 
            else
                SetQuantityStyle(true, "Неправильный формат числа. Количество установлено в 0.");

            DoValueChanged();
        }

        /// <summary>
        /// Обработка изменения флага "переместить на полку недостач весь доступный остаток"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbMoveAllRemains_CheckedChanged(object sender, EventArgs e)
        {
            OnValueChanged("MoveAllRemains", chbMoveAllRemains.Checked);
        }

        #endregion

        /// <summary>
        /// Метод обновления значений при изменении количества
        /// </summary>
        private void DoValueChanged()
        {
            tbCanceledQuantity.Text = CanceledQuantity.ToString();
            OnValueChanged("Quantity", Quantity);
        }

        /// <summary>
        /// Метод установки стиля поля ввода количества при возникновении ошибок
        /// </summary>
        /// <param name="error"></param>
        /// <param name="text"></param>
        private void SetQuantityStyle(bool error, string text)
        {
            if (error)
            {
                // ошибка ввода
                tbQuantity.BackColor = Color.Tomato;
                Quantity = 0;
            }
            else
            {
                tbQuantity.BackColor = SystemColors.Window;
            }
            lblError.Text = text;
        }

    }
}
