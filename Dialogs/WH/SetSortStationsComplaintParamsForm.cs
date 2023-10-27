using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class SetSortStationsComplaintParamsForm : DialogForm
    {
        public string DocType { get; private set; }
        public string DocSubType { get; private set; }
        public short Quantity { get; private set; }

        public SetSortStationsComplaintParamsForm()
        {
            InitializeComponent();
        }

        public SetSortStationsComplaintParamsForm(Data.WH.PTL_Declare_CO_TypesDataTable complaintTypes)
            : this()
        {
            wH.PTL_Declare_CO_Types.Merge(complaintTypes, true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(217, 8);
            btnCancel.Location = new Point(307, 8);
        }

        private void cmbCompaintDocTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCompaintDocTypes.SelectedValue != null)
            {
                var type = (cmbCompaintDocTypes.SelectedItem as DataRowView).Row as Data.WH.PTL_Declare_CO_TypesRow;

                var maxQty = Convert.ToDecimal(type.Ismax_QTYNull() ? 10000 : type.max_QTY);
                nudQuantity.Maximum = maxQty;
                nudQuantity.Value = 1;
            }
        }

        private void SetSortStationsCompaintParamsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CheckData();
        }

        private bool CheckData()
        {
            try
            {
                var type = (cmbCompaintDocTypes.SelectedItem as DataRowView).Row as Data.WH.PTL_Declare_CO_TypesRow;

                this.DocType = type.Doc_Type;
                this.DocSubType = type.Doc_SubType;
                this.Quantity = Convert.ToInt16(nudQuantity.Value);

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
