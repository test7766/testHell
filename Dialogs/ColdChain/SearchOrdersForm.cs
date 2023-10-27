using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class SearchOrdersForm : DialogForm
    {
        public SearchOrdersForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;  
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            rbDocCode.Checked = true;
        }

        /// <summary>
        /// Получение параметров фильтра
        /// </summary>
        /// <returns></returns>
        public WMSOffice.Window.ColdChainSetUnloadingTimeWindow.LoadWorkerFilterParameters GetFilterParameters()
        {
            WMSOffice.Window.ColdChainSetUnloadingTimeWindow.LoadWorkerFilterParameters p = new WMSOffice.Window.ColdChainSetUnloadingTimeWindow.LoadWorkerFilterParameters();

            if (rbDocCode.Checked)
                p.ActID = Convert.ToInt64(tbDocCode.Text);

            if (rbOrderNumber.Checked)
                p.OrderID = Convert.ToDouble(tbOrderNumber.Text);

            return p;
        }


        private void rbSearchFilterElement_Changed(object sender, EventArgs e)
        {
            RadioButton rbSearchElement = sender as RadioButton;

            if (rbSearchElement != null && rbSearchElement.Checked)
            {
                // Элемент поиска -- код акта
                if (rbSearchElement.Name == rbDocCode.Name)
                {
                    tbDocCode.Enabled = true;
                    tbDocCode.Focus();
                    tbOrderNumber.Enabled = false;
                    return;
                }
                // Элемент поиска -- номер заказа
                if (rbSearchElement.Name == rbOrderNumber.Name)
                {
                    tbOrderNumber.Enabled = true;
                    tbOrderNumber.Focus();
                    tbDocCode.Enabled = false;
                    return;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ApplyOperation(DialogResult.Cancel);
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

        private void tbSearchFilterElement_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }

        private void tbSearchFilterElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void SearchOrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilter();
        }

        private bool ValidateFilter()
        {
            Control filterItem = null;
            try
            {
                if (rbDocCode.Checked && tbDocCode.Text.Trim() == string.Empty)
                {
                    filterItem = tbDocCode;
                    throw new Exception("Код акта не может быть пустым.");
                }

                if (rbOrderNumber.Checked && tbOrderNumber.Text.Trim() == string.Empty)
                {
                    filterItem = tbOrderNumber;
                    throw new Exception("Номер заказа не может быть пустым.");
                }

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                filterItem.Focus();
                return false;
            }
        }
    }
}
