using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintActCloseForm : DialogForm
    {
        public int ActID { get; private set; }
        public string ActNumber { get; private set; }

        public ComplaintActCloseForm()
        {
            InitializeComponent();
        }

        public ComplaintActCloseForm(int actID, string actNumber)
            : this()
        {
            this.ActID = actID;
            this.ActNumber = actNumber;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.LoadAgreementsResult();

            this.Text = string.Format("{0} № {1}", this.Text, this.ActNumber);

            this.btnOK.Location = new Point(167, 8);
            this.btnCancel.Location = new Point(257, 8);
        }

        private void LoadAgreementsResult()
        {
            try
            {
                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Agreement_ResultsTableAdapter())
                    adapter.Fill(complaints.CO_Vendor_Agreement_Results, this.ActID, this.UserID);

                cmbResult.SelectedItem = null;
            }
            catch (Exception ex)
            {
                
                throw;
            }
        }

        private void ComplaintActCloseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbResult.SelectedValue == null)
                    throw new Exception("Не выбран результат закрытия акта.");

                var agreementID = Convert.ToInt32(cmbResult.SelectedValue);
                var note = tbNote.Text;

                using (var adapter = new Data.ComplaintsTableAdapters.CO_Vendor_Act_HeaderTableAdapter())
                    adapter.CloseAct(this.ActID, agreementID, note, this.UserID);

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
