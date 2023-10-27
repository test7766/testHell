using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Receive.Pallets;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsDenyDepartureNotifyForm : Form
    {
        /// <summary>
        /// Направление выезда
        /// </summary>
        public ViewSearchDirectionType DepartureDirection { get; set; }

        /// <summary>
        /// Признак блокировки выезда
        /// </summary>
        public bool LockDeparture { get; set; }

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsDenyDepartureNotifyForm()
        {
            InitializeComponent();
        }

        public PalletsDenyDepartureNotifyForm(int shipmentID, string carNumber, string vendorName, bool canModifyShipmentDeparture)
            : this()
        {
            this.shipmentDeliveryInfoControl.InitializeShipmentDeliveryInfo(shipmentID, carNumber, vendorName, canModifyShipmentDeparture);
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.lblMessage.Text = this.lblMessage.Text = string.Format("{0} ЗАПРЕЩЕН!", this.DepartureDirection == ViewSearchDirectionType.Entry ? "ВЪЕЗД" : this.DepartureDirection == ViewSearchDirectionType.Outgoing ? "ВЫЕЗД" : string.Empty);
            this.lblAction.Text = string.Format("{0}", this.LockDeparture ? "ДОЖДИТЕСЬ НАЧАЛЬНИКА СЛУЖБЫ БЕЗОПАСНОСТИ" : "ПРОВЕДИТЕ ПОВТОРНЫЙ ПЕРЕСЧЕТ\nПУСТЫХ ПАЛЛЕТ");
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter || keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
