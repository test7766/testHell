using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareInventoryCheckDetailsForm : DialogForm
    {
        public long DocID { get; set; }

        public DebtorsReturnedTareInventoryCheckDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(817, 8);
            this.btnCancel.Location = new Point(907, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.Text = string.Format("{0} № {1}", this.Text, this.DocID);

            this.RefreshData();

        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                rET_Tare_Inventory_Inv_Check_DetailsTableAdapter.Fill(pickControl.RET_Tare_Inventory_Inv_Check_Details, this.DocID, this.UserID);

                // Снимаем выделение с первой строки
                if (dgvCheckDetails.Rows.Count > 0)
                    dgvCheckDetails.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
