using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoicesRegisterBoxEticsShowStatisticsForm : DialogForm
    {
        public ArchiveInvoicesRegisterBoxEticsShowStatisticsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(217, 8);
            this.btnCancel.Location = new Point(307, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Initialize();
        }

        private void Initialize()
        {
            tbAcceptBox.TextChanged += new EventHandler(tbAcceptBox_TextChanged);

            this.LoadBoxEticsStatistics();

            tbAcceptBox.Focus();
        }

        void tbAcceptBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbAcceptBox.Text))
                return;

            this.AcceptBox(tbAcceptBox.Text);
        }

        private void AcceptBox(string barCode)
        {
            try
            {
                rG_BoxEticsTableAdapter.Accept(this.UserID, barCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.LoadBoxEticsStatistics();

                tbAcceptBox.Text = string.Empty;
                tbAcceptBox.Focus();
            }
        }

        private void LoadBoxEticsStatistics()
        {
            try
            {
                rG_BoxEticsTableAdapter.Fill(wH.RG_BoxEtics, this.UserID);

                if (dgvBoxEticsStatistics.Rows.Count > 0)
                    dgvBoxEticsStatistics.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
