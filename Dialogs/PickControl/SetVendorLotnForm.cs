using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class SetVendorLotnForm : DialogForm
    {
        public enum Scenario
        { 
            InventoryHand,
            Default
        }

        public Scenario CurrentScenario { get; set; }
        public int ItemID { get; set; }

        public SetVendorLotnForm()
        {
            InitializeComponent();
            this.CurrentScenario = Scenario.Default;
        }

        public string Lotn
        {
            get { return tbLotn.Text; }
        }

        private void SetVendorLotnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && !this.VerifyVendorLotn())
            {
                e.Cancel = true;
            }
        }

        private bool VerifyVendorLotn()
        {
            if (String.IsNullOrEmpty(Lotn))
            {
                MessageBox.Show("Необходимо указать серию!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Текущий сценарий - ручной ввод серии - проверка на ее существование
            if (this.CurrentScenario == Scenario.InventoryHand)
            {
                try
                {
                    using (Data.InventoryTableAdapters.IV_Vendor_LotsTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.IV_Vendor_LotsTableAdapter())
                        adapter.CheckVendorLot(this.ItemID, this.Lotn);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }

        private void tbLotn_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
