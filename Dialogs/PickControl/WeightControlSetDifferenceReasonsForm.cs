using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class WeightControlSetDifferenceReasonsForm : DialogForm
    {
        private const int DEFAULT_REASON_ID = -1;

        public new long UserID { get; set; }
        public long DocID { get; set; }
        public Data.PickControl.PC_WeightControl_False_ReasonsDataTable Reasons { get; set; }

        public int? ReasonID { get; private set; }
        public string ReasonNote { get; private set; }

        public WeightControlSetDifferenceReasonsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(173, 8);
            this.btnCancel.Location = new Point(263, 8);
        }

        private void Initialize()
        {
            try
            {
                if (this.Reasons != null)
                    pickControl.PC_WeightControl_False_Reasons.Merge(this.Reasons, true);
                else
                    pC_WeightControl_False_ReasonsTableAdapter.Fill(pickControl.PC_WeightControl_False_Reasons, this.DocID, this.UserID);

                if (pickControl.PC_WeightControl_False_Reasons.Count > 0)
                    cmbReasons.SelectedValue = DEFAULT_REASON_ID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Enter))
                this.DialogResult = DialogResult.OK;

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void WeightControlSetDifferenceReasonsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                if (cmbReasons.SelectedValue.Equals(DEFAULT_REASON_ID) && string.IsNullOrEmpty(tbNote.Text.TrimEnd('\r', '\n')))
                    throw new Exception("Необходимо указать примечание.");

                this.ReasonID = Convert.ToInt32(cmbReasons.SelectedValue);
                this.ReasonNote = tbNote.Text.Trim();

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
