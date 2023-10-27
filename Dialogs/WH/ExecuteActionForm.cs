using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class ExecuteActionForm : DialogForm
    {
        public long DocID { get; set; }
        public string NewStatusID { get; set; }

        public ExecuteActionForm()
        {
            InitializeComponent();
            this.ApplyOperation(DialogResult.None);
        }

        private void ExecuteActionForm_Load(object sender, EventArgs e)
        {
            this.tbBarCodeScaner.TextChanged += new EventHandler(tbBarCodeScaner_TextChanged);
        }

        private void tbBarCodeScaner_TextChanged(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(158, 8);
            this.btnCancel.Location = new Point(248, 8);

            tbBarCodeScaner.Focus();
        }

        private void ApplyOperation(DialogResult agreedResult)
        {
            this.DialogResult = agreedResult;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.OK);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ApplyOperation(DialogResult.Cancel);
        }

        private void ExecuteActionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ExecuteOperation();
        }

        /// <summary>
        /// Обновления статуса документа
        /// </summary>
        /// <returns></returns>
        public bool ExecuteOperation()
        {
            try
            {
                using (Data.WHTableAdapters.OperationsDocsTableAdapter adapter = new WMSOffice.Data.WHTableAdapters.OperationsDocsTableAdapter())
                    adapter.UpdateDocStatus(this.UserID, this.DocID, tbBarCodeScaner.Text, this.NewStatusID);

                return true;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка обновления статуса документа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
