using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class PickReturnCloseDocForm : DialogForm
    {
        public long DocID { get; private set; }

        private readonly Queue<Data.PickControl.DocReturnCloseDocsRow> qDocs = new Queue<Data.PickControl.DocReturnCloseDocsRow>();

        public PickReturnCloseDocForm()
        {
            InitializeComponent();
        }

        public PickReturnCloseDocForm(long docID)
            : this()
        {
            this.DocID = docID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(705, 8);
            this.btnCancel.Location = new Point(795, 8);

            this.DiscardCanceling = true;

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Initialize();
        }

        private void Initialize()
        {
            tbBarCode.TextChanged += new EventHandler(tbBarCode_TextChanged);

            //this.PrepareDocs();

            this.GetNextDoc();
        }

        void tbBarCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbBarCode.Text))
                    return;

                var doc = qDocs.Peek();

                docReturnCloseDocsTableAdapter.SetSSCCForDoc(doc.Doc_ID, doc.Doc_Type_ID, tbBarCode.Text);

                tbBarCode.Text = string.Empty;

                qDocs.Dequeue();

                if (!this.GetNextDoc())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                tbBarCode.Focus();
                tbBarCode.SelectAll();
            }
        }

        public bool PrepareDocs()
        {
            try
            {
                qDocs.Clear();

                docReturnCloseDocsTableAdapter.Fill(pickControl.DocReturnCloseDocs, this.DocID);

                foreach (Data.PickControl.DocReturnCloseDocsRow doc in pickControl.DocReturnCloseDocs)
                    qDocs.Enqueue(doc);

                return qDocs.Count > 0;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return false;

                throw ex;
            }
        }

        private bool GetNextDoc()
        {
            var doc = qDocs.Count > 0 ? qDocs.Peek() : null;

            if (doc != null)
            {
                this.LoadPackItems(doc);

                lblInstruction.Text = doc.User_Instruction;

                var cntDocs = pickControl.DocReturnCloseDocs.Count;
                var cntProcessedDocs = cntDocs - qDocs.Count;
                lblProgress.Text = string.Format("Обработано {0} из {1}", cntProcessedDocs, cntDocs);

                tbBarCode.Focus();

                return true;
            }
            else
                return false;
        }

        private void LoadPackItems(Data.PickControl.DocReturnCloseDocsRow doc)
        {
            try
            {
                docReturnClosePackItemsTableAdapter.Fill(pickControl.DocReturnClosePackItems, doc.Doc_ID, doc.Doc_Type_ID);

                if (dgvDocPackItems.Rows.Count > 0)
                    dgvDocPackItems.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
