using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Quality
{
    public partial class ImportLicenseSetConclusionForm : DialogForm
    {
        private readonly Data.Quality.QK_LI_LicRequestsRow _request = null;

        public ImportLicenseSetConclusionForm()
        {
            InitializeComponent();
        }

        public ImportLicenseSetConclusionForm(Data.Quality.QK_LI_LicRequestsRow request)
            : this()
        {
            _request = request;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            //cmbConclusion.SelectedIndex = 0;

            this.btnOK.Location = new Point(267, 8);
            this.btnCancel.Location = new Point(357, 8);
        }

        private void ImportLicenseSetConclusionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveConclusion();
        }

        private bool SaveConclusion()
        {
            try
            {
                if (cmbConclusion.SelectedIndex == -1)
                    throw new Exception("Необходимо выбрать решение.");

                var isApproved = Convert.ToBoolean(cmbConclusion.SelectedIndex == 0);
                if (!isApproved && string.IsNullOrEmpty(tbDescription.Text))
                    throw new Exception("Необходимо указать примечание.");

                var conclusionDate = dtpConclusionDate.Value.Date;

                var note = tbDescription.Text.Trim();

                using (var adapter = new Data.QualityTableAdapters.QK_LI_LicRequestsTableAdapter())
                    adapter.SetConclusion(this.UserID, _request.RequestID, isApproved, note, conclusionDate);

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
