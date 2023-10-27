using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class ScanUsedTareForm : DialogForm
    {
        public int AccessibleItemsQtty { get; private set; }

        public string TareCombinedBarCode { get; private set; }

        public ScanUsedTareForm()
        {
            InitializeComponent();
        }

        public ScanUsedTareForm(int accessibleItemsQtty)
            : this()
        {
            this.AccessibleItemsQtty = accessibleItemsQtty;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(620, 8);
            btnCancel.Location = new Point(710, 8);

            tbAccessibleItemsQtty.Text = this.AccessibleItemsQtty.ToString();

            tbsTare.UseScanModeOnly = true;
            tbsTare.TextChanged += new EventHandler(tbsTare_TextChanged);
        }

        void tbsTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsTare.Text))
                    return;

                var tareBarCode = tbsTare.Text;

                if (pickControl.UsedTare.FindByTareBarCode(tareBarCode) != null)
                    throw new Exception("Тара уже выбрана.");

                using (var adapter = new Data.PickControlTableAdapters.QueriesTableAdapter())
                    adapter.CheckUsedTare(tareBarCode);

                this.AddTare(tareBarCode);

                tbsTare.Text = string.Empty;
                tbsTare.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTare.Focus();
                tbsTare.SelectAll();
            }
        }

        private void AddTare(string tareBarCode)
        {
            try
            {
                pickControl.UsedTare.LoadDataRow(new object[] { tareBarCode }, true);

                var tareCount = pickControl.UsedTare.Rows.Count;
                lblScannedReturnedTareQtty.Text = tareCount.ToString();

                if (tareCount == this.AccessibleItemsQtty)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReceiptDebtorsReturnedTareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.DialogResult == DialogResult.OK)
                    e.Cancel = !this.SaveData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTare.Text = string.Empty;
                tbsTare.Focus();

                e.Cancel = true;
            }
        }

        private bool SaveData()
        {
            try
            {
                if (pickControl.UsedTare.Rows.Count == 0)
                    throw new Exception("Тара не выбрана.");

                var sbTarecombinedBarCode = new StringBuilder();
                foreach (Data.PickControl.UsedTareRow tareRow in pickControl.UsedTare.Rows)
                {
                    if (sbTarecombinedBarCode.Length > 0)
                        sbTarecombinedBarCode.AppendFormat(";{0}", tareRow.TareBarCode);
                    else
                        sbTarecombinedBarCode.AppendFormat("{0}", tareRow.TareBarCode);
                }

                this.TareCombinedBarCode = sbTarecombinedBarCode.ToString();
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
