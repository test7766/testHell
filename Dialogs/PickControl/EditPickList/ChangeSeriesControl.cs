using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl.EditPickList
{
    public partial class ChangeSeriesControl : BaseControl
    {
        #region конструктор

        public ChangeSeriesControl()
        {
            InitializeComponent();
        }

        #endregion

        #region свойства

        // надписи формы
        public string SplitLabel
        {
            get { return chbSplit.Text; }
            set { chbSplit.Text = value; }
        }

        public string QuantityLabel
        {
            get { return lblQuantity.Text; }
            set { lblQuantity.Text = value; }
        }

        public string SeriesLabel
        {
            get { return lblSeries.Text; }
            set { lblSeries.Text = value; }
        }

        public PickListRow PickList { get; set; }
        public int SessionID { get; set; }

        /// <summary>
        /// Изначальное количество
        /// </summary>
        public int OriginalQuantity { get; set; }

        /// <summary>
        /// Количество
        /// </summary> 
        public int Quantity { get; set; }
        //{
        //    get { return _quantity; }
        //    set
        //    {
        //        _quantity = value;
        //        tbQuantity.Text = _quantity.ToString();
        //    }
        //}
        //private int _quantity;

        /// <summary>
        /// Серия
        /// </summary>
        public string Series { get; set; }

        /// <summary>
        /// Включена ли опция сплитовки (разделения) строки
        /// </summary>
        public bool SplitChecked { get { return chbSplit.Checked; } set { chbSplit.Checked = value; } }

        // доступность редактирования с помощью элементов управления
        public bool SplitEnabled { get { return chbSplit.Visible; } set { chbSplit.Visible = value; } }
        public bool EditQuantityEnabled { get { return !tbQuantity.ReadOnly; } set { tbQuantity.ReadOnly = !value; } }
        public bool EditSeriesEnabled { get { return !tbSeries.ReadOnly; } set { tbQuantity.ReadOnly = !value; btnSeries.Enabled = value; } }

        #endregion

        /// <summary>
        /// Метод обновления значений при изменении количества
        /// </summary>
        private void DoValueChanged()
        {
            // tbCanceledQuantity.Text = CanceledQuantity.ToString();
            OnValueChanged("Quantity", Quantity);
        }

        private void DoSeriesChanged()
        {
            OnValueChanged("Series", Series);
        }

        public override void RefreshForm()
        {
            tbQuantity.Text = Quantity.ToString();
            tbSeries.Text = Series;
        }

        private void chbSplit_CheckedChanged(object sender, EventArgs e)
        {
            lblQuantity.Enabled = tbQuantity.Enabled = lblSeries.Enabled = tbSeries.Enabled = btnSeries.Visible = lblError.Visible = chbSplit.Checked;
            if (!chbSplit.Checked)
            {
                Quantity = 0;
            } else
            {
                int qty;
                if (int.TryParse(tbQuantity.Text, out qty))
                    Quantity = qty;
                tbQuantity_TextChanged(this, null);
            }
            OnValueChanged("Split", chbSplit.Checked);
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
                    if (tbSeries.Enabled && String.IsNullOrEmpty(tbSeries.Text)) SetQuantityStyle(2, "Необходимо выбрать серию."); else SetQuantityStyle(0, "");
                    Quantity = quantity;
                }
                else
                    SetQuantityStyle(1, "Конечное количество должно быть больше или равно 0 и меньше или равно Исходного количества.");
            }
            else
                SetQuantityStyle(1, "Неправильный формат числа. Количество установлено в 0.");

            DoValueChanged();
        }

        /// <summary>
        /// Обработка нажатия кнопки выбора серий из списка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSeries_Click(object sender, EventArgs e)
        {
            ChooseSeriesForm form = new ChooseSeriesForm(PickList, SessionID)
                                        {
                                            ItemName = PickList.Item
                                        };
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (!String.IsNullOrEmpty(form.BlockReason))
                    MessageBox.Show(
                        String.Format(
                            "Внимание!\nВы выбрали серию с блокировкой \"{0}\". При выполнении корректировки будет напечатан Акт обнаружения некондиционного товара.",
                            form.BlockReason), "Выбор заблокированной серии", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                Series = tbSeries.Text = form.Series;
                DoSeriesChanged();
            }

            if (tbSeries.Enabled && String.IsNullOrEmpty(tbSeries.Text)) SetQuantityStyle(2, "Необходимо выбрать серию."); else SetQuantityStyle(0, "");
        }

        private void ChangeSeriesControl_Load(object sender, EventArgs e)
        {
            if (SplitEnabled)
                lblQuantity.Enabled = tbQuantity.Enabled = lblSeries.Enabled = tbSeries.Enabled = btnSeries.Visible = lblError.Visible = chbSplit.Checked;
            RefreshForm();
        }

        /// <summary>
        /// Метод установки стиля поля ввода количества при возникновении ошибок
        /// </summary>
        /// <param name="error"></param>
        /// <param name="text"></param>
        private void SetQuantityStyle(byte error, string text)
        {
            if (error == 1)
            {
                // ошибка ввода количества
                tbQuantity.BackColor = Color.Tomato;
                tbSeries.BackColor = SystemColors.Control;
                Quantity = 0;
            }
            else if (error == 2)
            {
                // ошибка ввода серии
                tbQuantity.BackColor = (tbQuantity.ReadOnly) ? SystemColors.Control : SystemColors.Window;
                tbSeries.BackColor = Color.Tomato;
            }
            
            if (error == 0 || !tbQuantity.Enabled)
            {
                // нет ошибки, либо не активный элемент управления
                tbQuantity.BackColor = (tbQuantity.ReadOnly) ? SystemColors.Control : SystemColors.Window;
                tbSeries.BackColor = SystemColors.Control;
            }

            lblError.Text = text;
        }

    }
}
