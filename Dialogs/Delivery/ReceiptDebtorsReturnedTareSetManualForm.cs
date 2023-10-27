using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareSetManualForm : DialogForm
    {
        private readonly Data.Delivery.ClientTareTypesDataTable clientTateTypesCache = new WMSOffice.Data.Delivery.ClientTareTypesDataTable();

        public int ReceiptDocID { get; set; }

        public string TareBarCode { get; private set; }

        public ReceiptDebtorsReturnedTareSetManualForm()
        {
            InitializeComponent();
        }

        private void ReceiptDebtorsReturnedTareSetManualForm_Load(object sender, EventArgs e)
        {
            LoadTareTypes();
            ChangeBarCodeFlag(false);
        }

        private void LoadTareTypes()
        {
            try
            {
                this.clientTareTypesTableAdapter.Fill(clientTateTypesCache);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AttachClientTareTypes()
        {
            this.delivery.ClientTareTypes.Clear();
         
            if (cbWithoutBarCode.Checked)
                this.delivery.ClientTareTypes.Merge(clientTateTypesCache, true);

            cmbTareType.SelectedValue = "N/A";
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(107, 8);
            this.btnCancel.Location = new Point(197, 8);
        }

        private void cbWithoutBarCode_CheckedChanged(object sender, EventArgs e)
        {
            ChangeBarCodeFlag(cbWithoutBarCode.Checked);
        }

        private void ChangeBarCodeFlag(bool isChecked)
        {
            gbWithoutBarCode.Enabled = isChecked;
            tbTareBarCode.Enabled = !isChecked;

            tbTareBarCode.Clear();
            AttachClientTareTypes();

            this.SelectNextControl(cbWithoutBarCode, isChecked, true, true, false);
        }

        private void tbTareBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.DialogResult = DialogResult.OK;
        }

        private void ReceiptDebtorsReturnedTareSetManualForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !CheckResult();
        }

        private bool CheckResult()
        {
            try
            {
                this.TareBarCode = (string)null;

                var flagWithoutBarCode = cbWithoutBarCode.Checked ? 1 : 0;
                var tareBarcode = (string)null;
                var tareType = (string)null;

                // 0. Валидация
                if (cbWithoutBarCode.Checked)
                {
                    if (cmbTareType.SelectedValue == null)
                        throw new Exception("Выберите тип тары.");

                    tareType = cmbTareType.SelectedValue.ToString();
                }
                else
                {
                    if (string.IsNullOrEmpty(tbTareBarCode.Text))
                        throw new Exception("Введите ш/к тары.");

                    tareBarcode = tbTareBarCode.Text;
                }

                // 1. Создание записи в журнале ручного сканирования
                var logID = (long?)null;
                using (var adapter = new Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter())
                    adapter.CheckInputTareBarCode(this.ReceiptDocID, tareBarcode, this.UserID, flagWithoutBarCode, tareType, ref logID);

                if (!logID.HasValue)
                    throw new Exception("Возникла ошибка при создании записи в журнале ручного ввода тары.");

                // 2. Сканирование RZon
                var rzon = (string)null;
                while (true)
                {
                    try
                    {
                        var dlgScanRZon = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                        {
                            Label = "Отсканируйте место RZon\r\nдля размещения тары",
                            Text = "Сдача клиентской оборотной тары",
                            Image = Properties.Resources.barcode,
                            DiscardCanceling = true
                        };

                        if (dlgScanRZon.ShowDialog() == DialogResult.OK)
                            rzon = dlgScanRZon.Barcode;
                        else
                            continue;
                       
                        using (var adapter = new Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter())
                            adapter.ScanRZon(this.ReceiptDocID, logID, rzon);

                        break;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rzon = (string)null;
                        continue;
                    }
                }

                if (!cbWithoutBarCode.Checked)
                    this.TareBarCode = tareBarcode;

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
