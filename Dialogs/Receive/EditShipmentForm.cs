using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class EditShipmentForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public new long UserID { get; set; }
        /// <summary>
        /// Номер поставки
        /// </summary>
        public int ShipmentID { get; set; }

        /// <summary>
        /// Номер рампы по умолчанию
        /// </summary>
        public int DefaultRampID { get; set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public EditShipmentForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(200, 8);
            this.btnCancel.Location = new Point(290, 8);
            this.btnOK.Text = "Сохранить";

            if (!this.LoadData())
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }
        }

        /// <summary>
        /// Получение данных по поставке
        /// </summary>
        private bool LoadData()
        {
            try
            {
                this.shipmentDetailTableAdapter.Fill(this.receive.ShipmentDetail, this.UserID, this.ShipmentID);
                if (this.receive.ShipmentDetail.Count == 0)
                    throw new Exception("Указанной поставки не существует!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void EditShipmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        /// <summary>
        /// Сохранение данных о поставке
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {
                var shipmentInfo = this.receive.ShipmentDetail[0];

                string[] dateParts = null;

                dateParts = shipmentInfo.TimeFrom.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                shipmentInfo.TimeFrom = dateParts.Length == 1 ? dateParts[0] : dateParts[1];

                dateParts = shipmentInfo.TimeTo.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                shipmentInfo.TimeTo = dateParts.Length == 1 ? dateParts[0] : dateParts[1];             
                
                using (var adapter = new Data.ReceiveTableAdapters.FreeShipmentsOnDateTableAdapter())
                    adapter.UpdateShipmentInfo(this.UserID, (int)shipmentInfo.Shipment_ID,
                        shipmentInfo.IsShipmentDescriptionNull() ? string.Empty : shipmentInfo.ShipmentDescription, 
                        shipmentInfo.IsCarNumberNull() ? string.Empty : shipmentInfo.CarNumber, 
                        shipmentInfo.IsCountPLNull() ? (int?)null : (int)shipmentInfo.CountPL, 
                        shipmentInfo.ShipDate, 
                        shipmentInfo.TimeFrom, 
                        shipmentInfo.TimeTo, 
                        shipmentInfo.F, 
                        shipmentInfo.P, 
                        shipmentInfo.IsReturnQuantityNull() ? (double?)null : shipmentInfo.ReturnQuantity,
                        shipmentInfo.Ramp_ID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void EditShipmentForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'receive.Ramps' table. You can move, or remove it, as needed.
            this.rampsTableAdapter.Fill(this.receive.Ramps, this.UserID, (int?)null);

            var defaultRamp = this.receive.Ramps.FindByRamp_ID(this.DefaultRampID);
            if (defaultRamp != null && defaultRamp.Type_Ramp == 2)
                rampsBindingSource.Filter = string.Format("{0} = {1}", this.receive.Ramps.Ramp_IDColumn.Caption, defaultRamp.Ramp_ID);
            else
                rampsBindingSource.Filter = string.Format("{0} <> 2", this.receive.Ramps.Type_RampColumn.Caption);
        }
    }
}
