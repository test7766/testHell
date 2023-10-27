using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveReturnedTareInvoiceDelayReasonsSetForm : DialogForm
    {
        public int? DelayReasonsFlag { get; private set; }

        public ArchiveReturnedTareInvoiceDelayReasonsSetForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(142, 8);
            this.btnCancel.Location = new Point(232, 8);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            { 
                case Keys.Control | Keys.D0:
                case Keys.Control | Keys.D1:
                case Keys.Control | Keys.D2:
                case Keys.Control | Keys.D3:
                case Keys.Control | Keys.D4:
                case Keys.Control | Keys.D5:
                case Keys.Control | Keys.D6:
                case Keys.Control | Keys.D7:
                case Keys.Control | Keys.D8:
                case Keys.Control | Keys.D9:
                    // Извлекаем код 0-9 из искомой комбинации
                    var reasonCode = 9 - (Convert.ToInt32(Keys.D9) - (Convert.ToInt32(keyData) - Convert.ToInt32(Keys.Control)));
                    this.SelectReason(reasonCode);
                    return true;
                default:
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void SelectReason(object reasonCode)
        {
            foreach (CheckBox cbReason in gbReasons.Controls)
                if ((cbReason.Tag ?? (object)string.Empty).Equals(reasonCode.ToString()))
                    cbReason.Checked = !cbReason.Checked;
        }

        private void ArchiveReturnedTareInvoiceDelayReasonsSetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                foreach (CheckBox cbReason in gbReasons.Controls)
                    if (cbReason.Checked)
                        this.DelayReasonsFlag = (this.DelayReasonsFlag ?? 0) + Convert.ToInt32(Math.Pow(2, Convert.ToInt32(cbReason.Tag ?? (object)0)));

                if ((this.DelayReasonsFlag ?? 0) == 0)
                    throw new Exception("Необходимо выбрать одну или несколько причин.");

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
