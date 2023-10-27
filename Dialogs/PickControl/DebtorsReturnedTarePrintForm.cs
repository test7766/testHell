using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTarePrintForm : DialogForm
    {
        public string DefaultPrinterID { get; set; }

        public DebtorsReturnedTarePrintForm()
        {
            InitializeComponent();
        }

        private void DebtorsReturnedTarePrintForm_Load(object sender, EventArgs e)
        {
            LoadPrinters();
            LoadTareTypes();
        }

        private void LoadPrinters()
        {
            try
            {
                this.cT_PrintersTableAdapter.Fill(this.pickControl.CT_Printers);
                cmbPrinters.SelectedValue = this.DefaultPrinterID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTareTypes()
        {
            try
            {
                this.cT_TareTypesTableAdapter.Fill(this.pickControl.CT_TareTypes, (string)null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);
        }

        private void cmbTareType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbTareType.SelectedValue == null)
                return;

            try
            {
                var tareName = cmbTareType.SelectedValue.ToString();

                var qty = (int?)null;
                using (var adapter = new Data.PickControlTableAdapters.CT_TareTypesTableAdapter())
                    adapter.GetAvailableTareQuantity(tareName, ref qty);

                if (qty.HasValue)
                    tbAvailableQuantity.Text = qty.Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DebtorsReturnedTarePrintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == System.Windows.Forms.DialogResult.OK)
                e.Cancel = !PrintEtics();
        }

        private bool PrintEtics()
        {
            try
            {
                var printerID = (string)null;
                var tareType = (string)null;
                var eticsQuantity = (int?)null; 
                var itemID = (int?)null;
                var barCode = (string)null;
                var repeatMode = (int?)null;

                if (cmbPrinters.SelectedValue == null)
                    throw new Exception("Не выбран принтер.");
                printerID = cmbPrinters.SelectedValue.ToString();

                if (cmbTareType.SelectedValue == null)
                    throw new Exception("Не определен тип тары.");
                tareType = cmbTareType.SelectedValue.ToString();

                if (nudQuantity.Value > Convert.ToDecimal(tbAvailableQuantity.Text))
                    throw new Exception("Количество этикеток превышает допустимое.");
                eticsQuantity = Convert.ToInt32(nudQuantity.Value);

                using (var adapter = new Data.PickControlTableAdapters.CT_TareEticsTableAdapter())
                    adapter.PrintEtic(printerID, tareType, eticsQuantity, itemID, barCode, repeatMode);

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
