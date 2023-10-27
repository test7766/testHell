using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class DeliverySensorsOnRoute : DialogForm
    {
        public DeliverySensorsOnRoute()
        {
            InitializeComponent();
        }

        private void DeliverySensorsOnRoute_Load(object sender, EventArgs e)
        {
            Config.LoadDataGridViewSettings(this.Name, this.dgvSensorsOnRoute);
            this.LoadData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(817, 8);
            this.btnOK.Visible = false;

            this.btnCancel.Location = new Point(907, 8);
            this.btnCancel.Text = "Закрыть";
        }

        private void LoadData()
        {
            try
            {
                using (var adapter = new Data.DeliveryTableAdapters.SensorsOnRouteTableAdapter())
                    adapter.Fill(delivery.SensorsOnRoute, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeliverySensorsOnRoute_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, this.dgvSensorsOnRoute);
        }
    }
}
