using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ApplyingOfWLReturnsShowErrorForm : DialogForm
    {
        public long DocID { get; private set; }

        public ApplyingOfWLReturnsShowErrorForm()
        {
            InitializeComponent();
        }

        public ApplyingOfWLReturnsShowErrorForm(long docID)
            : this()
        {
            this.DocID = docID;
        }

        private void ApplyingOfWLReturnsShowErrorForm_Load(object sender, EventArgs e)
        {
            this.LoadData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(817, 8);
            this.btnCancel.Location = new Point(907, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";
        }

        private void LoadData()
        {
            try
            {
                cO_DocError_ItemsTableAdapter.Fill(complaints.CO_DocError_Items, this.DocID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
