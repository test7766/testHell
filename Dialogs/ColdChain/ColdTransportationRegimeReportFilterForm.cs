using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class ColdTransportationRegimeReportFilterForm : DialogForm
    {
        private const int FILTER_PARAMETERS_COUNT = 6; // кол-во параметров настраиваемых при помощи этой формы
        private const int DEFAULT_DOCUMENT_INDEX = 1; // тип документа по умолчанию - накладная
        private const int INVOICE_ITEM_NAME_MIN_LENTH = 3; // минимально допустимая длинна для поиска по названию товара

        private const string ERROR_CAPTION = "Ошибка задания элементов фильтра";

        public List<object> GetParametersFromFilter()// TODO нужно ли?
        {
            List<object> parameters = new List<object>(FILTER_PARAMETERS_COUNT);

            // проинилициализируем параметрами null-значениями
            for (int i = 0; i < parameters.Capacity; i++)
                parameters.Add(null);

            // если выбран фильтр по номеру документа
            if (rbDocumentNumber.Checked)
            {
                // cbDocumentType построен таким образом, что номер индекса его элемента совпадает с номером параметра
                parameters[cbDocumentType.SelectedIndex] = tbDocumentNumber.Text.Trim(); // номер документа выбранного типа
            }
            // если выбран фильтр по дате и товару накладной 
            else if (rbDateInvoiceItems.Checked)
            {
                parameters[2] = dtStartDate.Value; // начальная дата накладной
                parameters[3] = dtEndDate.Value; // конечная дата накладной

                // если выбран фильтр по коду товара
                if (rbInvoiceItemID.Checked)
                {
                    parameters[4] = tbInvoiceItemID.Text.Trim(); // код товара
                }
                // если выбран фильтр по названию товара
                else if (rbInvoiceItemName.Checked)
                {
                    parameters[5] = tbInvoiceItemName.Text.Trim(); // название товара
                }
            }

            return parameters;
        }

        public ColdTransportationRegimeReportFilterForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rbDocumentNumber.Checked = true;
        }

        private void cbDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDocumentNumber.Focus();
        }

        /// <summary>
        /// Выполнить запрашиваемую операцию согласно ожидаемого результата - статуса диалогового окна
        /// </summary>
        /// <param name="agreedResult"></param>
        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void FilterTextItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }

        private void rbSearchMainFilter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchElement = sender as RadioButton;

            if (rbSearchElement != null && rbSearchElement.Checked)
            {
                // Элемент фильтра -- номер документ
                if (rbSearchElement.Name == rbDocumentNumber.Name)
                {
                    pnlDocumentNumber.Enabled = true;
                    cbDocumentType.SelectedIndex = DEFAULT_DOCUMENT_INDEX;
                    tbDocumentNumber.Focus();

                    pnlDateInvoiceItems.Enabled = false;
                    return;
                }
                // Элемент фильтра -- дата и товар 
                if (rbSearchElement.Name == rbDateInvoiceItems.Name)
                {
                    pnlDateInvoiceItems.Enabled = true;
                    rbInvoiceItemID.Checked = true;
                    tbInvoiceItemID.Focus();

                    pnlDocumentNumber.Enabled = false;
                    return;
                }
            }
        }

        private void rbSearchDataInvoiceItemsFilter_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchElement = sender as RadioButton;

            if (rbSearchElement != null && rbSearchElement.Checked)
            {
                // Элемент фильтра -- код товара
                if (rbSearchElement.Name == rbInvoiceItemID.Name)
                {
                    tbInvoiceItemID.Enabled = true;
                    tbInvoiceItemID.Focus();

                    tbInvoiceItemName.Enabled = false;
                    return;
                }
                // Элемент фильтра -- название товара 
                if (rbSearchElement.Name == rbInvoiceItemName.Name)
                {
                    tbInvoiceItemName.Enabled = true;
                    tbInvoiceItemName.Focus();

                    tbInvoiceItemID.Enabled = false;
                    return;
                }
            }
        }

        private void ColdTransportationRegimeReportFilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilterSettings();
        }

        /// <summary>
        /// Валидация ввода допустимых значений для выбранных настроек фильтра
        /// </summary>
        /// <returns></returns>
        private bool ValidateFilterSettings()
        {
            // Выбран фильтр по номеру документа
            if (rbDocumentNumber.Checked && tbDocumentNumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Номер документа не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbDocumentNumber.Focus();
                tbDocumentNumber.SelectAll();
                return false;
            }

            // Выбран фильтр по дате и товару
            if (rbDateInvoiceItems.Checked)
            {
                if (dtStartDate.Value > dtEndDate.Value)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtStartDate.Focus();
                    return false;
                }

                // Выбран фильтр по коду товара в накладной
                if (rbInvoiceItemID.Checked && tbInvoiceItemID.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Код товара не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbInvoiceItemID.Focus();
                    tbInvoiceItemID.SelectAll();
                    return false;
                }

                // Выбран фильтр по названию товара в накладной
                if (rbInvoiceItemName.Checked && tbInvoiceItemName.Text.Trim().Length < INVOICE_ITEM_NAME_MIN_LENTH)
                {
                    MessageBox.Show(string.Format("Название товара должно содержать не менее {0} букв.", INVOICE_ITEM_NAME_MIN_LENTH), ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbInvoiceItemName.Focus();
                    tbInvoiceItemName.SelectAll();
                    return false;
                }

                return true;
            }

            return true;
        }
    }
}
