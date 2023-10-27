using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareSetDublicateForm : DialogForm
    {
        public Data.PickControl.DBL_RET_DocsRow SelectedDoc { get { return dgvDocs.SelectedRows.Count > 0 ? (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.DBL_RET_DocsRow : null; } }

        private bool hasChanges = false;

        public DebtorsReturnedTareSetDublicateForm()
        {
            InitializeComponent();
        }

        private void DebtorsReturnedTareSetDublicateForm_Load(object sender, EventArgs e)
        {
            this.ReloadDocs(false);
            this.PrepareOperations();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(817, 8);
            this.btnCancel.Location = new Point(907, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void ReloadDocs(bool withLockDocDetails)
        {
            try
            {
                if (withLockDocDetails)
                    lockDocDetails = true;

                var defaultWarehouseID = (string)null;
                using (var adapter = new Data.PickControlTableAdapters.DBL_RET_DocsTableAdapter())
                    adapter.Fill(pickControl.DBL_RET_Docs, this.UserID, defaultWarehouseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (withLockDocDetails)
                    lockDocDetails = false;
            }
        }

        private bool lockDocDetails = false;
        private void ReloadDocDetails()
        {
            if (lockDocDetails)
                return;

            try
            {
                var docID = this.SelectedDoc != null ? this.SelectedDoc.Log_Id : (long?)null;
                using (var adapter = new Data.PickControlTableAdapters.DBL_RET_DocDetailsTableAdapter())
                    adapter.Fill(pickControl.DBL_RET_DocDetails, this.UserID, docID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadDocDetails();
            this.PrepareOperations();
        }

        private void PrepareOperations()
        {
            sbAddTare.Enabled = true;
            sbAddDublicate.Enabled = this.SelectedDoc != null;
        }

        private void sbAddTare_Click(object sender, EventArgs e)
        {
            this.AddTare();
        }

        private void AddTare()
        {
            var frmDebtorsReturnedTareAddDublicateDoc = new DebtorsReturnedTareAddDublicateDocForm { UserID = this.UserID };
            if (frmDebtorsReturnedTareAddDublicateDoc.ShowDialog() == DialogResult.OK)
            {
                hasChanges = true;

                this.ReloadDocs(true);

                var docID = frmDebtorsReturnedTareAddDublicateDoc.DocID;
                if (this.FindDoc(docID.Value))
                    this.AddDublicate();
            }
        }

        private bool FindDoc(long? docID)
        {
            foreach (DataGridViewRow gridRow in dgvDocs.Rows)
            {
                var boundRow = (gridRow.DataBoundItem as DataRowView).Row as Data.PickControl.DBL_RET_DocsRow;
                if (boundRow.Log_Id.Equals(docID))
                {
                    gridRow.Selected = true;
                    dgvDocs.FirstDisplayedScrollingRowIndex = gridRow.Index;

                    return true;
                }
            }

            return false;
        }

        private void sbAddDublicate_Click(object sender, EventArgs e)
        {
            this.AddDublicate();   
        }

        public void AddDublicate()
        {
            var docID = this.SelectedDoc.Log_Id;
            var frmDebtorsReturnedTareAddDublicateDocDetail = new DebtorsReturnedTareAddDublicateDocDetailForm { UserID = this.UserID, DocID = SelectedDoc.Log_Id };
            if (frmDebtorsReturnedTareAddDublicateDocDetail.ShowDialog() == DialogResult.OK)
            {
                hasChanges = true;

                this.ReloadDocs(true);
                this.FindDoc(docID);

                this.ReloadDocDetails();
            }
        }

        private void DebtorsReturnedTareSetDublicateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                if (hasChanges)
                    this.DialogResult = DialogResult.OK;
            }
        }
    }
}
