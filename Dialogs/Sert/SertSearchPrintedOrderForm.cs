using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Sert
{
    /// <summary>
    /// Диалог для ввода параметров поиска заказа (задания для печати сертификатов).
    /// </summary>
    public partial class SertSearchPrintedOrderForm : Form
    {
        /// <summary>
        /// Признак, печатать только НДС-заказы либо все заказы
        /// </summary>
        public bool OnlyNds { get { return chbNdsOnly.Checked; } }

        /// <summary>
        /// Тип заказа
        /// </summary>
        public string DCTO { get; private set; }

        /// <summary>
        /// Номер заказа
        /// </summary>
        public double? DOCO { get; private set; }

        /// <summary>
        /// Тип накладной
        /// </summary>
        public string DCT { get; private set; }

        /// <summary>
        /// Номер накладаной
        /// </summary>
        public double? DOC { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public SertSearchPrintedOrderForm()
        {
            InitializeComponent();
        }

        private void SertSearchPrintedOrderForm_Load(object sender, EventArgs e)
        {
            // 0 - поиск по заказу
            // 1 - поиск по накладной

            cmbCriterion.SelectedIndex = 1;
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            DCTO = null;
            DOCO = (double?)null;
            DCT = null;
            DOC = (double?)null;

            double number = 0;

            try
            {
                // поиск по заказу
                //
                if (cmbCriterion.SelectedIndex == 0)
                {
                    DCTO = string.IsNullOrEmpty(tbType.Text) ? null : tbType.Text;

                    if (!double.TryParse(tbNumber.Text, out number))
                        throw new Exception("Номер заказа не введен или введен некорректно.");

                    DOCO = number;
                }

                // поиск по накладной
                //
                if (cmbCriterion.SelectedIndex == 1)
                {
                    DCT = string.IsNullOrEmpty(tbType.Text) ? null : tbType.Text;

                    if (!double.TryParse(tbNumber.Text, out number))
                        throw new Exception("Номер накладной не введен или введен некорректно.");

                    DOC = number;
                }

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbNumber.Focus();
            }
        }
    }
}
