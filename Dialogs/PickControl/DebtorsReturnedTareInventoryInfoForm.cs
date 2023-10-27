using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareInventoryInfoForm : DialogForm
    {
        public long DocID { get; set; }

        public DebtorsReturnedTareInventoryInfoForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Text = string.Format("{0} № {1}", this.Text, this.DocID);

            this.btnOK.Location = new Point(617, 8);
            this.btnCancel.Location = new Point(707, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.ReloadInfo();
        }

        private void ReloadInfo()
        {
            try
            {
                rET_Tare_Inventory_InfoTableAdapter.Fill(pickControl.RET_Tare_Inventory_Info, this.DocID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadInfoDetails()
        {
            try
            {
                var info = dgvInfo.SelectedRows.Count == 0 ? null : (dgvInfo.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.RET_Tare_Inventory_InfoRow;

                var typeID = info == null ? (int?)null : info.IsOpen_DetNull() ? (int?)null : info.Open_Det != 1 ? (int?)null : info.IsType_IdNull() ? (int?)null : info.Type_Id;

                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var loadWorker = new BackgroundWorker();

                loadWorker.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = rET_Tare_Inventory_Info_DetailsTableAdapter.GetData(this.DocID, typeID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                loadWorker.RunWorkerCompleted += (s, e) => 
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    pickControl.RET_Tare_Inventory_Info_Details.Merge(e.Result as Data.PickControl.RET_Tare_Inventory_Info_DetailsDataTable, true);
                    rETTareInventoryInfoDetailsBindingSource.DataSource = e.Result;
                };

                splashForm.ActionText = "Выполняется загрузки деталей счета..";

                pickControl.RET_Tare_Inventory_Info_Details.Clear();
                rETTareInventoryInfoDetailsBindingSource.DataSource = null;

                loadWorker.RunWorkerAsync();

                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvInfo_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadInfoDetails();
        }
    }
}
