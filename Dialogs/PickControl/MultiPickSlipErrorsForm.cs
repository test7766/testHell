using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class MultiPickSlipErrorsForm : DialogForm
    {
        public MultiPickSlipErrorsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(517, 8);
            this.btnCancel.Location = new Point(607, 8);
            this.btnCancel.Text = "Закрыть";
        }

        public void PopulateErrors(Data.PickControl.MultiPickSlipErrorsDataTable errors, int statusID)
        {
            pickControl.MultiPickSlipErrors.Merge(errors);
            lblErrorMessage.Text = string.Format("Возникли ошибки при переводе документа мультисборки на статус {0}", statusID);
        }
    }
}
