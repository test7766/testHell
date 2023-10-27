using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.InterBranch
{
    public partial class DeliveryTransportPlanCarForm : DialogForm
    {
        public new long UserID { get; set; }

        public int DeliveryID { get; set; }

        public long? CarID { get; set; }

        public Data.Interbranch.TSP_Shipments_On_DateRow Shipment { get; set; }

        public Data.Interbranch.TSP_FilialsRow CurrentFilial { get; set; }

        public DateTime ShipmentDate { get; set; }
        public DateTime TimeFrom { get; set; }
        public DateTime TimeTo { get; set; }

        public bool AutoRecalcEnabled { get; private set; }

        public double Ratio { get; private set; }
        public double Volume { get; private set; }
        public double MaxVolume { get; private set; }

        public int? VolumeID { get; set; }
        public int? RampID { get; set; }

        public long? RouteNumber { get; set; }
        public string RouteInformation { get; set; }
        public int? FactPallets { get; set; }

        public bool HasPlannedCar { get { return this.CarID.HasValue; } }

        public DeliveryTransportPlanCarForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(207, 8);
            this.btnCancel.Location = new Point(297, 8);

            //this.btnOK.Visible = false;
            //this.btnCancel.Text = "Закрыть";
        }

        private void Initialize()
        {
            if (!this.HasPlannedCar)
                this.Text = string.Format("{0} *", this.Text);
            else
                this.Text = string.Format("{0} [{1}]", this.Text, this.CarID);

            if (this.RouteNumber.HasValue)
                tbRouteNumber.Text = this.RouteNumber.Value.ToString();

            if (!string.IsNullOrEmpty(this.RouteInformation))
                tbRouteInformation.Text = this.RouteInformation.ToString();

            if (this.FactPallets.HasValue)
                tbFactPallets.Text = this.FactPallets.Value.ToString("N0");

            this.LoadRamps(this.HasPlannedCar ? this.RampID : (int?)null);

            if (this.RampID != null)
                cmbRamps.SelectedValue = this.RampID;

            dtpPeriod.Value = this.ShipmentDate.Date;

            dtpTimeFrom.ValueChanged -= dtpTimeFrom_ValueChanged;
            dtpTimeTo.ValueChanged -= dtpTimeTo_ValueChanged;

            dtpTimeFrom.Value = _previousTimeFrom = this.TimeFrom;
            dtpTimeFrom.Enabled = !this.HasPlannedCar;

            dtpTimeTo.Value = _previousTimeTo = this.TimeTo;
            dtpTimeTo.Enabled = !this.HasPlannedCar;

            dtpTimeFrom.ValueChanged += dtpTimeFrom_ValueChanged;
            dtpTimeTo.ValueChanged += dtpTimeTo_ValueChanged;

            this.LoadDeliveries(this.DeliveryID);
            cmbDeliveries.SelectedValue = this.DeliveryID;

            tbShipmentTypeName.Text = this.Shipment.Shipment_Description;

            this.AutoRecalcEnabled = true;

            var shipmentVolume = (double)this.Shipment[string.Format("{0}_OP", this.DeliveryID)];
            var carVolume = (double)this.Shipment[string.Format("{0}_CP", this.DeliveryID)];
            var maxVolume = shipmentVolume - carVolume;

            this.MaxVolume = maxVolume;
            lblMaxVolume.Text = maxVolume.ToString("f4");

            trackVolume.Value = 20; // max volume

            this.LoadCarVolumes(this.VolumeID);
        }

        void cmbCarVolumes_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCarVolumes.SelectedValue != null)
            {
                var carVolume = ((cmbCarVolumes.SelectedItem as DataRowView).Row as Data.Interbranch.TSP_Car_VolumesRow).Volume;
                var maxAccessibleVolume = Math.Min(this.MaxVolume, carVolume);

                this.AutoRecalcEnabled = false;

                this.Volume = maxAccessibleVolume;
                this.Ratio = 1.0 * this.Volume / this.MaxVolume;
                trackVolume.Value = Convert.ToInt32(Math.Truncate(this.Ratio * trackVolume.Maximum));
                lnkVolume.Text = string.Format("{0} ({1:N2}%)", this.Volume.ToString("f4"), this.Ratio * 100);

                this.AutoRecalcEnabled = true;
            }
        }

        private void LoadDeliveries(int? deliveryID)
        {
            try
            {
                tSP_DeliveriesTableAdapter.Fill(interbranch.TSP_Deliveries, deliveryID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCarVolumes(int? volumeID)
        {
            try
            {
                tSP_Car_VolumesTableAdapter.Fill(interbranch.TSP_Car_Volumes, volumeID);
                cmbCarVolumes.SelectedValue = interbranch.TSP_Car_Volumes[interbranch.TSP_Car_Volumes.Count - 1].CV_ID; // max volume
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRamps(int? rampID)
        {
            try
            {
                tSP_RampsTableAdapter.Fill(interbranch.TSP_Ramps, this.CurrentFilial.FilialID, rampID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackVolume_ValueChanged(object sender, EventArgs e)
        {
            if (this.AutoRecalcEnabled)
            {
                this.Ratio = 1.0 * trackVolume.Value / trackVolume.Maximum;
                this.Volume = this.MaxVolume * this.Ratio;
                lnkVolume.Text = string.Format("{0} ({1:N0}%)", this.Volume.ToString("f4"), this.Ratio * 100);
            }
        }
       
        private void lnkVolume_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var dlgDeliveryTransportSetVolume = new DeliveryTransportSetVolumeForm() { UserID = this.UserID, MinVolume = 0.0, MaxVolume = this.MaxVolume, Volume = this.Volume };
            if (dlgDeliveryTransportSetVolume.ShowDialog() == DialogResult.OK)
            {
                this.AutoRecalcEnabled = false;

                this.Volume = dlgDeliveryTransportSetVolume.Volume.Value;
                this.Ratio = 1.0 * this.Volume / this.MaxVolume;
                trackVolume.Value = Convert.ToInt32(Math.Truncate(this.Ratio * trackVolume.Maximum));
                lnkVolume.Text = string.Format("{0} ({1:N2}%)", this.Volume.ToString("f4"), this.Ratio * 100);

                this.AutoRecalcEnabled = true;
            }
        }

        private int? GetShipmentID(DateTime period, int shipmentType, int deliveryID)
        {
            try
            {
                var shipmentID = (int?)null;
                using (var adapter = new Data.InterbranchTableAdapters.TSP_Shipments_On_DateTableAdapter())
                    adapter.GetShipmentID(period, shipmentType, deliveryID, ref shipmentID, this.CurrentFilial.FilialID);

                return shipmentID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (int?)null;
            }
        }

        private long? CreateCar(DateTime period, int rampID, int volumeID, string timeStart, string timeFinish, double volume)
        {
            try
            {
                var carID = (long?)null;

                using (var adapter = new Data.InterbranchTableAdapters.TSP_Cars_On_Ramps_By_DateTableAdapter())
                    carID = Convert.ToInt64(adapter.CreateCar(period, rampID, volumeID, timeStart, timeFinish, this.UserID, volume));

                return carID;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (long?)null;
            }
        }

        private void DeleteCar(long? carID)
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.TSP_Cars_On_Ramps_By_DateTableAdapter())
                    adapter.DeleteCar(carID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool AddShipmentToCar(long? carID, int? shipmentID, double volume, double ratio, int deliveryID)
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.TSP_Cars_On_Ramps_By_DateTableAdapter())
                    adapter.AddShipmentToCar(carID, shipmentID, volume, ratio, this.UserID, deliveryID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void DeleteShipmentFromCar(long? carID, long? shipmentID)
        {
            try
            {
                using (var adapter = new Data.InterbranchTableAdapters.TSP_Cars_On_Ramps_By_DateTableAdapter())
                    adapter.DeleteShipmentFromCar(carID, shipmentID, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeliveryTransportPlanCarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        private bool SaveData()
        {
            try
            {
                var success = this.AddShipmentToCar();
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool AddShipmentToCar()
        {
            var shipmentDate = this.ShipmentDate;
            var shipmentType = this.Shipment.Type_ID;
            var deliveryID = Convert.ToInt32(this.cmbDeliveries.SelectedValue);

            var rampID = Convert.ToInt32(cmbRamps.SelectedValue);
            var volumeID = Convert.ToInt32(cmbCarVolumes.SelectedValue);
            var timeStart = dtpTimeFrom.Value.ToShortTimeString();
            var timeFinish = dtpTimeTo.Value.ToShortTimeString();

            var carID = (long?)(this.CarID ?? -1L);
            var volume = this.Volume;
            var ratio = this.Ratio;

            // Проверка объема
            if (!this.CheckVolume())
                throw new Exception("Превышен допустимый обьем автомобиля!!!");

            // Создание плана перевозки
            if (!this.HasPlannedCar)
            {
                carID = this.CarID = this.CreateCar(shipmentDate, rampID, volumeID, timeStart, timeFinish, volume);
                if (!carID.HasValue)
                    return false;
            }

            // Получение кода поставки
            var shipmentID = this.GetShipmentID(shipmentDate, shipmentType, deliveryID);
            if (!shipmentID.HasValue)
                return false;

            // Добавление поставки в план перевозки
            if (!this.AddShipmentToCar(carID, shipmentID, volume, ratio, deliveryID))
                return false;

            return true;
        }

        private bool CheckVolume()
        {
            return true; // проверяется пороговое значение в процедуре

            //var volume = this.Volume;

            //var volumeID = Convert.ToInt32(cmbCarVolumes.SelectedValue);
            //var maxVolume = interbranch.TSP_Car_Volumes.FindByCV_ID(volumeID).Volume;

            //var success = volume <= maxVolume;

            //return success;
        }

        private DateTime _previousTimeFrom;
        private void dtpTimeFrom_ValueChanged(object sender, EventArgs e)
        {
            _previousTimeFrom = this.EditValue(dtpTimeFrom, _previousTimeFrom);
            dtpTimeTo.Value = dtpTimeFrom.Value.AddMinutes(30);
        }

        private DateTime _previousTimeTo;
        private void dtpTimeTo_ValueChanged(object sender, EventArgs e)
        {
            _previousTimeTo = this.EditValue(dtpTimeTo, _previousTimeTo);
        }

        private DateTime EditValue(DateTimePicker dtpValue, DateTime previousValue)
        {
            var currentValue = dtpValue.Value;
            var diff = currentValue - previousValue;

            if (diff.Ticks < 0)
                dtpValue.Value = previousValue.AddMinutes(-30);
            else
                dtpValue.Value = previousValue.AddMinutes(30);

            return dtpValue.Value;
        }
    }
}
