using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Docs
{
    public partial class AttorneyRevertSetDateForm : DialogForm
    {
        public AttorneyProperties AttorneyProperties { get; set; }

        public AttorneyRevertSetDateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(67, 8);
            this.btnCancel.Location = new Point(157, 8);
        }

        private void AttorneyRevertSetDateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var receiverID = this.AttorneyProperties.ReceiverID;
                var attorneyNumber = this.AttorneyProperties.AttorneyNumber;
                
                var periodFrom = this.AttorneyProperties.PeriodFrom.Value;
                var periodTo = dtpRevertDate.Value.Date;

                if (periodFrom > periodTo)
                    throw new Exception(string.Format("Дата отзыва не должна предшествовать\nдате начала действия доверенности {0}.", periodFrom.ToShortDateString()));

                var printOnInvoice = Convert.ToInt32(this.AttorneyProperties.PrintOnInvoice);
                var restrictDaysCount = this.AttorneyProperties.RestrictDaysCount;
                var agreementID = this.AttorneyProperties.AgreementID;

                // Отзыв документа
                using (var adapter = new Data.WHTableAdapters.AC_DocsTableAdapter())
                    adapter.Modify(receiverID, attorneyNumber, periodFrom, periodTo, this.UserID, printOnInvoice, restrictDaysCount, 1, (string)null, agreementID);

                this.AttorneyProperties.PeriodTo = periodTo;

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
