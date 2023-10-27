using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class SelectReworkReasonsForm : DialogForm
    {
        public long? DocID { get; set; }

        public long? StageID { get; set; }

        public int? ReasonID { get; private set; }
        public string Reason { get; private set; }

        public string Title { get; set; }

        public SelectReworkReasonsForm()
        {
            InitializeComponent();
        }

        private void SelectReworkReasonsForm_Load(object sender, EventArgs e)
        {
            this.LoadReasons();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!string.IsNullOrEmpty(this.Title))
                this.Text = this.Title;
        }

        private void LoadReasons()
        {
            try
            {
                this.reworkReasonsTableAdapter.Fill(this.complaints.ReworkReasons, this.DocID, this.UserID, this.StageID);
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
                var reason = (cmbReasonType.SelectedItem as DataRowView).Row as Data.Complaints.ReworkReasonsRow;

                if (reason.CheckComment == 1)
                {
                    tbReason.ReadOnly = false;
                    tbReason.Clear();
                    tbReason.Focus();
                }
                else
                {
                    tbReason.ReadOnly = true;
                    tbReason.BackColor = SystemColors.Window;
                    tbReason.Text = reason.ReasonDescription;
                    //tbReason.Clear();
                }
            }
        }

        private void SelectReworkReasonsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateReason();
        }

        private bool ValidateReason()
        {
            try
            {
                var reason = (cmbReasonType.SelectedItem as DataRowView).Row as Data.Complaints.ReworkReasonsRow;
                if (reason.CheckComment == 1 && string.IsNullOrEmpty(tbReason.Text))
                    throw new Exception("Необходимо указать описание причины.");

                this.ReasonID = Convert.ToInt32(cmbReasonType.SelectedValue);
                this.Reason = reason.CheckComment == 1 ? tbReason.Text : (string)null;

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
