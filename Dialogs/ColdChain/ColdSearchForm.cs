using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.ColdChain
{
    public partial class ColdSearchForm : DialogForm
    {
        private const int DEFAULT_SELECTOR_MEDICINES_TYPE_INDEX = 0; // тип поиска по товару по умолчанию - код товара
        private const int DEFAULT_SELECTOR_DELIVERY_CODE_TYPE_INDEX = 0; // тип поиска по дебитору по умолчанию - код дебитора
        private const int ORDER_ITEM_NAME_MIN_LENTH = 3; // минимально допустимая длинна для поиска по названию товара

        private const string ERROR_CAPTION = "Ошибка задания элементов фильтра";

        public ColdSearchForm()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.None;
            this.SetInterfaceSettings();
        }

        private void SetInterfaceSettings()
        {
            // настройка размещения элементов управления
            this.btnOK.Location = new Point(475, 8);
            this.btnCancel.Location = new Point(565, 8);
        }

        /// <summary>
        /// Получения списка адаптированных значений параметров для поиска
        /// </summary>
        /// <returns></returns>
        public WMSOffice.Window.ColdChainTemperatureReportWindow.LoadWorkerSearchParameters GetReportParameters()
        {
            WMSOffice.Window.ColdChainTemperatureReportWindow.LoadWorkerSearchParameters parameters = new WMSOffice.Window.ColdChainTemperatureReportWindow.LoadWorkerSearchParameters();

            if (rbDateInterval.Checked)
            {
                parameters.DateFrom = dtDateFrom.Value;
                parameters.DateTo = dtDateTo.Value;

                if (cbAdvancedByDate.Checked)
                {
                    if (rbBranch.Checked)
                        parameters.BranchID = cmbBranch.SelectedValue.ToString();

                    if (rbSaleMedicines.Checked)
                    {
                        if (cmbSelectorMedicinesSearchType.SelectedIndex == 0)
                            parameters.ItemID = Convert.ToInt32(tbSaleMedicines.Text);

                        if (cmbSelectorMedicinesSearchType.SelectedIndex == 1)
                            parameters.ItemName = tbSaleMedicines.Text.Trim();
                    }
                }
            }

            if (rbDelivery.Checked)
            {
                if (cmbSelectorDeliveryCodeSearchType.SelectedIndex == 0)
                    parameters.DebitorID = Convert.ToInt32(tbDelivery.Text);

                if (cmbSelectorDeliveryCodeSearchType.SelectedIndex == 1)
                    parameters.DeliveryID = Convert.ToInt32(tbDelivery.Text);
            }

            if (rbOrder.Checked)
            {
                parameters.OrderID = Convert.ToDouble(tbOrderNumber.Text);
                parameters.OrderType = tbOrderType.Text.Trim();
            }

            if (rbPickSlip.Checked)
                parameters.PickSlipNumber = Convert.ToDouble(tbPickSlipNumber.Text);

            if (rbWhiteStickerBarCode.Checked)
                parameters.WhiteStickerBarCode = Convert.ToDouble(tbWhiteStickerBarCode.Text.Trim());

            return parameters;
        }

        private void ColdSearchForm_Load(object sender, EventArgs e)
        {
            this.branchesTableAdapter.Fill(this.coldChain.Branches);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            cmbSelectorMedicinesSearchType.SelectedIndex = DEFAULT_SELECTOR_MEDICINES_TYPE_INDEX;
            cmbSelectorDeliveryCodeSearchType.SelectedIndex = DEFAULT_SELECTOR_DELIVERY_CODE_TYPE_INDEX;
            cbAdvancedByDate.Checked = false;
            rbBranch.Checked = true;
            rbPickSlip.Checked = true;

            this.tbWhiteStickerBarCode.TextChanged += new EventHandler(tbWhiteStickerBarCode_TextChanged);
        }

        void tbWhiteStickerBarCode_TextChanged(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void tbSaleMedicines_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbSelectorMedicinesSearchType.SelectedIndex == 0)
                AllowOnlyNumber_KeyPress(sender, e);
        }

        private void AllowOnlyNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void ApplyFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyOperation(DialogResult.OK);
        }

        private void tbOrderNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                tbOrderType.Focus();
        }

        private void cmbSelectorDeliveryCodeSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbDelivery.Focus();
        }

        private void cmbSelectorMedicinesSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbSaleMedicines.Clear();
            tbSaleMedicines.Focus();
        }


        private void cbAdvancedByDate_CheckedChanged(object sender, EventArgs e)
        {
            pnlAdvanced.Enabled = cbAdvancedByDate.Checked;

            if (cbAdvancedByDate.Checked && rbSaleMedicines.Checked)
                tbSaleMedicines.Focus();
        }

        private void rbSearchScenario_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchComponent = sender as RadioButton;

            if (rbSearchComponent == null || !rbSearchComponent.Checked)
                return;

            // Деактивируем в начале все компоненты фильтра
            pnlDateInterval.Enabled = pnlDelivery.Enabled =
            pnlOrder.Enabled = pnlPickSlip.Enabled =
            pnlWhiteStickerBarCode.Enabled = false;

            // Сценарий поиска -- по датам
            if (rbSearchComponent == rbDateInterval)
            {
                pnlDateInterval.Enabled = true;
                return;
            }

            // Сценарий поиска -- по дебитору
            if (rbSearchComponent == rbDelivery)
            {
                pnlDelivery.Enabled = true;
                tbDelivery.Focus();
                return;
            }

            // Сценарий поиска -- по заказу
            if (rbSearchComponent == rbOrder)
            {
                pnlOrder.Enabled = true;
                tbOrderNumber.Focus();
                return;
            }

            // Сценарий поиска -- по сборочному
            if (rbSearchComponent == rbPickSlip)
            {
                pnlPickSlip.Enabled = true;
                tbPickSlipNumber.Focus();
                return;
            }

            // Сценарий поиска -- по ш/к белой этикетки
            if (rbSearchComponent == rbWhiteStickerBarCode)
            {
                pnlWhiteStickerBarCode.Enabled = true;
                tbWhiteStickerBarCode.Focus();
                return;
            }
        }

        private void rbAdvancedByDateSearchScenario_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbSearchComponent = sender as RadioButton;

            if (rbSearchComponent == null || !rbSearchComponent.Checked)
                return;

            // Деактивируем в начале все компоненты фильтра
            pnlAdvancedBranch.Enabled = pnlAdvancedMedicines.Enabled = false;

            if (rbSearchComponent == rbBranch)
            {
                pnlAdvancedBranch.Enabled = true;
                cmbBranch.Focus();
                return;
            }

            if (rbSearchComponent == rbSaleMedicines)
            {
                pnlAdvancedMedicines.Enabled = true;
                tbSaleMedicines.Focus();
                return;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
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

        private void ColdSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ValidateFilterSettings();
        }

        /// <summary>
        /// Валидация установленного режима фильтрации
        /// </summary>
        /// <returns></returns>
        private bool ValidateFilterSettings()
        {
            #region Сценарий поиска -- по датам
            if (rbDateInterval.Checked)
            {
                // валидация дат
                if (dtDateFrom.Value.Date > dtDateTo.Value.Date)
                {
                    MessageBox.Show("Начальная дата не должна превышать конечную.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dtDateFrom.Focus();
                    return false;
                }

                if (cbAdvancedByDate.Checked && rbSaleMedicines.Checked)
                {
                    // валидация кода товара
                    if (cmbSelectorMedicinesSearchType.SelectedIndex == 0 && tbSaleMedicines.Text.Trim() == string.Empty)
                    {
                        MessageBox.Show("Код товара не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbSaleMedicines.Focus();
                        return false;
                    }

                    // валидация наименования товара
                    if (cmbSelectorMedicinesSearchType.SelectedIndex == 1 && tbSaleMedicines.Text.Trim().Length < ORDER_ITEM_NAME_MIN_LENTH)
                    {
                        MessageBox.Show(string.Format("Наименование товара должно содержать не менее {0} символов.", ORDER_ITEM_NAME_MIN_LENTH), ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        tbSaleMedicines.Focus();
                        tbSaleMedicines.SelectAll();
                        return false;
                    }
                }
            }
            #endregion

            #region Сценарий поиска -- по дебитору
            if (rbDelivery.Checked)
            {
                // валидация кода дебитора
                if (cmbSelectorDeliveryCodeSearchType.SelectedIndex == 0 && tbDelivery.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Код дебитора не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDelivery.Focus();
                    return false;
                }

                // валидация кода адреса доставки
                if (cmbSelectorDeliveryCodeSearchType.SelectedIndex == 1 && tbDelivery.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Код адреса доставки не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbDelivery.Focus();
                    return false;
                }
            }
            #endregion

            #region Сценарий поиска -- по заказу
            if (rbOrder.Checked)
            {
                // валидация номера заказа
                if (tbOrderNumber.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Номер заказа не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbOrderNumber.Focus();
                    return false;
                }

                // валидация типа заказа
                if (tbOrderType.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Тип заказа не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbOrderType.Focus();
                    return false;
                }
            }
            #endregion

            #region Сценарий поиска -- по сборочному
            if (rbPickSlip.Checked)
            {
                // валидация номера сборочного
                if (tbPickSlipNumber.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Номер сборочного не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbPickSlipNumber.Focus();
                    return false;
                }
            }
            #endregion

            #region Сценарий поиска -- по ш/к белой этикетки
            if (rbWhiteStickerBarCode.Checked)
            {
                // проверка на отсутствие значения
                if (tbWhiteStickerBarCode.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("Ш/К белой этикетки не может быть пустым.", ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbWhiteStickerBarCode.Focus();
                    return false;
                }

                // проверка ш/к на валидность 
                try
                {
                    using (Data.ColdChainTableAdapters.QueriesTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.QueriesTableAdapter())
                        adapter.CheckSticker(tbWhiteStickerBarCode.Text.Trim());
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message, ERROR_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    tbWhiteStickerBarCode.Focus();
                    return false;
                }
            }
            #endregion

            return true;
        }
    }
}
