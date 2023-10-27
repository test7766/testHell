using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReturnsDeliverySetMemoResultForm : DialogForm
    {
        public string MemoBarcode { get; set; }

        public int? ReasonID { get; private set; }
        public string ReasonDesc { get; private set; }

        public ReturnsDeliverySetMemoResultForm()
        {
            InitializeComponent();
            tbReasonDesc.ReadOnly = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(172, 8);
            this.btnCancel.Location = new Point(262, 8);
        }

        private void ReturnsDeliverySetMemoRejectReasonForm_Load(object sender, EventArgs e)
        {
            this.LoadReasons();
        }

        private void LoadReasons()
        {
            try
            {
                this.cO_Memo_FailedReasonsTableAdapter.Fill(this.complaints.CO_Memo_FailedReasons, this.MemoBarcode);

                var blankRow = this.complaints.CO_Memo_FailedReasons.NewCO_Memo_FailedReasonsRow();
                blankRow.ReasonID = -1;
                blankRow.Reason = "(отсутствует)";
                blankRow.CheckDesc = false;

                this.complaints.CO_Memo_FailedReasons.Rows.InsertAt(blankRow, 0);
                cmbReasons.SelectedValue = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReasons_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReasons.SelectedItem == null)
                return;

            var reasonRow = (cmbReasons.SelectedItem as DataRowView).Row as Data.Complaints.CO_Memo_FailedReasonsRow;
            var checkDesc = reasonRow.IsCheckDescNull() ? false : reasonRow.CheckDesc;
            
            tbReasonDesc.ReadOnly = !checkDesc;
            tbReasonDesc.Clear();

            if (checkDesc)
                tbReasonDesc.Focus();
        }

        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter & e.Modifiers == Keys.Control)
                this.DialogResult = DialogResult.OK;
        }

        private void ReturnsDeliverySetMemoRejectReasonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var reasonRow = (cmbReasons.SelectedItem as DataRowView).Row as Data.Complaints.CO_Memo_FailedReasonsRow;
                var checkDesc = reasonRow.IsCheckDescNull() ? false : reasonRow.CheckDesc;

                if (checkDesc && string.IsNullOrEmpty(tbReasonDesc.Text.Trim()))
                    throw new Exception("Необходимо указать описание причины.");

                this.ReasonID = reasonRow.ReasonID == -1 ? (int?)null : reasonRow.ReasonID;
                this.ReasonDesc = checkDesc ? tbReasonDesc.Text.Substring(0, Math.Min(300, tbReasonDesc.Text.Length)) : (string)null;

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
