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




        private bool UpdateData()
        {

            ExpDate = dtpExpDate.Checked == false ? null : (DateTime?)dtpExpDate.Value;
            LotNumber = tbVendor_Lot.Text.ToString() == "" ? "" : tbVendor_Lot.Text.ToString();
            try
            {
                if (ExpDate == null && string.IsNullOrEmpty(LotNumber))
                    throw new Exception("Повинно бути заповнено поле: Термін придатності або Серія постачальника");

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void QualityLotsEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.UpdateData();
        }
    }
}
