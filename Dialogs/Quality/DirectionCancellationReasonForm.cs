using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class DirectionCancellationReasonForm : DialogForm
    {
        public int CancelReasonID { get; private set; }

        public string CancelDescription { get; private set; }


        public DirectionCancellationReasonForm()
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
            this.LoadReasons();
        }

        private void LoadReasons()
        {
            try
            {
                this.dRCancelReasonsTableAdapter.Fill(this.quality.DRCancelReasons);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DirectionCancellationReasonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveReason();
        }

        private bool SaveReason()
        {
            try
            {
                if (cmbReasons == null)
                    throw new Exception("Не обрана причина.");

                if (cmbReasons.SelectedValue.Equals(4) && string.IsNullOrEmpty(tbDescription.Text))
                    throw new Exception("Необхідно внести опис.");

                this.CancelReasonID = (int)cmbReasons.SelectedValue;
                this.CancelDescription = tbDescription.Text;

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
