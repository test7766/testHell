using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    /// <summary>
    /// Диалог для выбора параметров поиска накладных в архиве
    /// </summary>
    public partial class SearchOptionsForm : Form
    {
        #region Constructor

        /// <summary>
        /// Инициализирует новый экземпляр диалога
        /// </summary>
        public SearchOptionsForm()
        {
            InitializeComponent();

            dtpDateFrom.Value = dtpDateTo.Value = DateTime.Today;
            errorProvider.SetIconPadding(tbOrderType, 3);
            errorProvider.SetIconPadding(tbOrderID, 3);
            errorProvider.SetIconPadding(tbSenderID, 3);
            errorProvider.SetIconPadding(tbShipToID, 3);
            errorProvider.SetIconPadding(dtpDateFrom, 3);
            errorProvider.SetIconPadding(dtpDateTo, 3);
        }

        #endregion


        #region Properties

        /// <summary>
        /// Тип документа
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Номер заказа (накладной)
        /// </summary>
        public double? OrderID { get; set; }

        /// <summary>
        /// Идентификатор отправителя
        /// </summary>
        public int? SenderID { get; set; }

        /// <summary>
        /// Идентификатор получателя
        /// </summary>
        public int? ShipToID { get; set; }

        /// <summary>
        /// Дата заказа (накладной) - с
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Дата заказа (накладной) - по
        /// </summary>
        public DateTime? DateTo { get; set; }

        #endregion


        #region Methods

        /// <summary>
        /// Меняет доступность групп при изменении состояния соответствующих флажков
        /// </summary>
        private void CheckBoxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox s = sender as CheckBox;
            if (s != null)
            {
                if (s == chkbOrderType)
                    tbOrderType.Enabled = s.Checked;
                if (s == chkbOrderID)
                    tbOrderID.Enabled = s.Checked;
                if (s == chkbSenderShipTo)
                    gbSenderShipTo.Enabled = s.Checked;
                if (s == chkbDateFromTo)
                    gbDateFromTo.Enabled = s.Checked;
            }
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК", проверяя введенные данные
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            OrderType = null;
            OrderID = null;
            SenderID = null;
            ShipToID = null;
            DateFrom = null;
            DateTo = null;

            errorProvider.Clear();

            #region Парсинг введенных значений с проверками
            if (chkbOrderType.Checked)
            {
                OrderType = tbOrderType.Text.Trim();
                if (string.IsNullOrEmpty(OrderType))
                {
                    errorProvider.SetError(tbOrderType, "Тип документа задан неверно.\rОбычно он равен значениям \"40\", \"41\".");
                    return;
                }
            }
            if (chkbOrderID.Checked)
            {
                double d;
                bool parsed = double.TryParse(tbOrderID.Text, out d);
                if (parsed)
                {
                    OrderID = d;
                }
                else
                {
                    errorProvider.SetError(tbOrderID, "Номер документа задан неверно.");
                    return;
                }
            }
            if (chkbSenderShipTo.Checked)
            {
                int i;
                bool parsed = int.TryParse(tbSenderID.Text, out i);
                if (parsed)
                {
                    SenderID = i;
                }
                else
                {
                    errorProvider.SetError(tbSenderID, "Код аптечного склада-отправителя (из адресной книги) задан неверно.\rОбычно он равен значениям 17001-17025.");
                    return;
                }

                parsed = int.TryParse(tbShipToID.Text, out i);
                if (parsed)
                {
                    ShipToID = i;
                }
                else
                {
                    errorProvider.SetError(tbShipToID, "Код аптечного склада-получателя (из адресной книги) задан неверно.\rОбычно он равен значениям 17001-17025.");
                    return;
                }
            }
            if (chkbDateFromTo.Checked)
            {
                DateFrom = dtpDateFrom.Value;
                DateTo = dtpDateTo.Value;
            }

            #endregion

            // проверка диапазона дат, если не указан конкретный номер накладной
            if (!chkbOrderID.Checked)
            {
                if (!chkbDateFromTo.Checked)
                {
                    MessageBox.Show("Выбрано слишком мало параметров для поиска данных в архиве." + Environment.NewLine +
                        "Пожалуйста, укажите номер накладной или период дат", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (DateFrom.Value > DateTo.Value || (DateTo.Value - DateFrom.Value).TotalDays > 30)
                {
                    MessageBox.Show("Выбран неверный диапазон дат для поиска данных в архиве." + Environment.NewLine +
                        "Длительность периода не может превышать 30 дней.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        #endregion
    }
}
