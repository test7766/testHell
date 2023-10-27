using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    /// <summary>
    /// Элемент управления для выбора подпричины корректировки
    /// </summary>
    public partial class SelectSubreasonControl : BaseControl
    {
        #region конструктор

        public SelectSubreasonControl()
        {
            InitializeComponent();
        }

        #endregion

        #region свойства

        /// <summary>
        /// Название под-причины
        /// </summary>
        public string SubreasonLabel
        {
            get { return chbSelect.Text; }
            set { chbSelect.Text = value; }
        }

        /// <summary>
        /// Название количества
        /// </summary>
        public string QuantityLabel
        {
            get { return lblQuantity.Text; }
            set { lblQuantity.Text = value; }
        }

        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Выбор подпричины
        /// </summary>
        public bool Selected
        {
            get { return chbSelect.Checked; }
            set { chbSelect.Checked = value; }
        }
        
        /// <summary>
        /// Изначальное количество
        /// </summary>
        public int OriginalQuantity { get; set; }

        #endregion

        /// <summary>
        /// Метод обновления значений при изменении количества
        /// </summary>
        private void DoValueChanged()
        {
            OnValueChanged("Quantity", Quantity);
        }

        /// <summary>
        /// Метод обновления значений формы
        /// </summary>
        public override void RefreshForm()
        {
            tbQuantity.Text = Quantity.ToString();
        }

        private void chbSelect_CheckedChanged(object sender, EventArgs e)
        {
            lblQuantity.Enabled = tbQuantity.Enabled = lblError.Visible = chbSelect.Checked;
            if (!chbSelect.Checked)
            {
                Quantity = 0;
            }
            else
            {
                int qty;
                if (int.TryParse(tbQuantity.Text, out qty))
                    Quantity = qty;
                tbQuantity_TextChanged(this, null);
            }
            OnValueChanged("Select", chbSelect.Checked);
            DoValueChanged();
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (int.TryParse(tbQuantity.Text, out quantity))
            {
                // правильное значение
                if (quantity >= 0 && quantity <= OriginalQuantity)
                {
                    SetQuantityStyle(false, "");
                    Quantity = quantity;
                }
                else
                    SetQuantityStyle(true, "Значение от 0 до Исходного количества.");
            }
            else
                SetQuantityStyle(true, "Неправильный формат числа. Значение 0.");

            DoValueChanged();
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
                // ошибка ввода количества
                tbQuantity.BackColor = Color.Tomato;
                Quantity = 0;
            }

            if (!error || !tbQuantity.Enabled)
            {
                // нет ошибки, либо не активный элемент управления
                tbQuantity.BackColor = (tbQuantity.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            }

            lblError.Text = text;
        }
    }
}
