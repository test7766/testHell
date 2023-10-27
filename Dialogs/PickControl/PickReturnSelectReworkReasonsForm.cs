using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class PickReturnSelectReworkReasonsForm : DialogForm
    {
        public int? ReasonID { get; private set; }
        public string Reason { get; private set; }

        public PickReturnSelectReworkReasonsForm()
        {
            InitializeComponent();
        }

        private void PickReturnSelectReworkReasonsForm_Load(object sender, EventArgs e)
        {
            this.LoadReasons();
        }

        private void LoadReasons()
        {
            try
            {
                this.docReturnReworkReasonsTableAdapter.Fill(this.pickControl.DocReturnReworkReasons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbReasonType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbReasonType.SelectedValue != null)
            {
                var reason = (cmbReasonType.SelectedItem as DataRowView).Row as Data.PickControl.DocReturnReworkReasonsRow;

                if (reason.NeedType)
                {
                    tbReason.ReadOnly = false;
                    tbReason.Clear();
                    tbReason.Focus();
                }
                else
                {
                    tbReason.ReadOnly = true;
                    tbReason.BackColor = SystemColors.Window;
                    tbReason.Text = reason.ReworkReason;
                }
            }
        }

        private void PickReturnSelectReworkReasonsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateReason();
        }

        private bool ValidateReason()
        {
            try
            {
                var reason = (cmbReasonType.SelectedItem as DataRowView).Row as Data.PickControl.DocReturnReworkReasonsRow;
                if (reason.NeedType && string.IsNullOrEmpty(tbReason.Text))
                    throw new Exception("Необходимо указать описание причины.");

                this.ReasonID = Convert.ToInt32(cmbReasonType.SelectedValue);
                this.Reason = reason.NeedType ? tbReason.Text : (string)null;

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
