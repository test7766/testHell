using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class QualityLotsEditorForm : DialogForm
    {
        public DateTime? ExpDate { get; private set; }
        public string LotNumber { get; private set; }

        public QualityLotsEditorForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(158, 8);
            this.btnCancel.Location = new Point(248, 8);
        }

        private void QualityLotsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.UpdateData();
        }
        
        private bool UpdateData()
        {

            var expDate = dtpExpDate.Checked ? (DateTime?)dtpExpDate.Value : null;
            var lotNumber = tbVendor_Lot.Text.ToString().Trim();

            try
            {
                if (expDate == null && string.IsNullOrEmpty(lotNumber))
                    throw new Exception("Повинно бути заповнено одне з полів:\nТермін придатності або Серія постачальника.");

                this.ExpDate = expDate;
                this.LotNumber = lotNumber;

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

     
    }
}
