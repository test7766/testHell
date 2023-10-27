using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class BoxMeasurementControl : BaseControl
    {
        public BoxMeasurementControl()
        {
            InitializeComponent();
        }

        public string QuantityLabel
        {
            get { return lblQuantity.Text; }
            set { lblQuantity.Text = value; }
        }

        public string BoxLabel
        {
            get { return lblBox.Text; }
            set { lblBox.Text = value; }
        }

        public int Quantity { get; set; }
        public int BoxCount { get; set; }

        public bool QuantityEnabled
        {
            get { return !tbQuantity.ReadOnly; }
            set { tbQuantity.ReadOnly = !value; }
        }

        /// <summary>
        /// Изначальное количество
        /// </summary>
        public int OriginalQuantity { get; set; }

        public override void RefreshForm()
        {
            tbBox.Text = BoxCount.ToString();
            tbQuantity.Text = Quantity.ToString();
        }

        private void BoxMeasurementControl_Load(object sender, EventArgs e)
        {
            RefreshForm();
        }

        private void tbQuantity_TextChanged(object sender, EventArgs e)
        {
            int quantity = 0;
            if (int.TryParse(tbQuantity.Text, out quantity))
            {
                // правильное значение
                if (quantity > 0)// && quantity <= OriginalQuantity)
                {
                    SetQuantityStyle(false, "");
                    Quantity = quantity;
                }
                else
                    // SetQuantityStyle(true, "Значение от 0 до Исходного количества.");
                    SetQuantityStyle(true, "Значение должно быть больше 0.");
            }
            else
                SetQuantityStyle(true, "Неправильный формат числа. Значение 0.");

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
                // ошибка ввода количества
                tbQuantity.BackColor = Color.Tomato;
                Quantity = 1;
            }

            if (!error || !tbQuantity.Enabled)
            {
                // нет ошибки, либо не активный элемент управления
                tbQuantity.BackColor = (tbQuantity.ReadOnly) ? SystemColors.Control : SystemColors.Window;
            }

            // lblError.Text = text;
        }
    }
}
