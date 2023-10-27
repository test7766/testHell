using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class DeliveryTermoboxMoovingHistory : DialogForm
    {
        public DeliveryTermoboxMoovingHistory()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(817, 8);
            this.btnOK.Visible = false;

            this.btnCancel.Location = new Point(907, 8);
            this.btnCancel.Text = "Закрыть";
        }

        public void SetDataSource(Data.Delivery.TermoboxMoovingHistoryDataTable termoboxMoovingHistory)
        {
            delivery.TermoboxMoovingHistory.Merge(termoboxMoovingHistory);
        }
    }
}
