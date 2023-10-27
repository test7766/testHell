using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ComplaintsExternalDocsShowForm : DialogForm
    {
        private readonly long _docID;

        public ComplaintsExternalDocsShowForm()
        {
            InitializeComponent();
        }

        public ComplaintsExternalDocsShowForm(long docID)
            : this()
        {
            _docID = docID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} № {1}", this.Text, _docID);

            this.btnOK.Location = new Point(817, 8);
            this.btnCancel.Location = new Point(907, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.LoadExternalDocs();
        }

        private void LoadExternalDocs()
        {
            try
            {
                cO_Get_External_DocsTableAdapter.Fill(complaints.CO_Get_External_Docs, _docID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
