using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class PrintingDevicesManagerWindow : GeneralWindow
    {
        private bool lockInitialize = true;

        public Data.WH.DD_LocationsRow SelectedLocation
        {
            get { return dgvLocations.SelectedRows.Count > 0 ? (dgvLocations.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.DD_LocationsRow : null; }
        }

        public Data.WH.DD_DevicesRow SelectedDevice
        {
            get { return dgvDevices.SelectedRows.Count > 0 ? (dgvDevices.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.DD_DevicesRow : null; }
        }

        public Data.WH.DD_DeviceStatisticsRow SelectedDeviceStatisticsDay
        {
            get { return dgvDeviceStatistics.SelectedRows.Count > 0 ? (dgvDeviceStatistics.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.DD_DeviceStatisticsRow : null; }
        }

        public PrintingDevicesManagerWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void Initialize()
        {
            lockInitialize = true;

            var today = DateTime.Today;
            cmbStatisticsMonthes.SelectedIndex = today.Month - 1;
            nudStatisticsYear.Value = Convert.ToDecimal(today.Year);

            this.ReloadLocations();
            this.SetOperationsAccess();

            lockInitialize = false;
        }

        private void SetOperationsAccess()
        {
            var isLocationEnabled = this.SelectedLocation != null;

            
            var isDeviceEnabled = this.SelectedDevice != null;

            miChangeDeviceIP.Enabled = isDeviceEnabled;


            var isDeviceStatisticsDayEnabled = this.SelectedDeviceStatisticsDay != null && this.SelectedDeviceStatisticsDay.PeriodDate.Date == DateTime.Today.Date;

            miDeleteDeviceStatistics.Enabled = isDeviceStatisticsDayEnabled;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadLocations();
        }

        private void ReloadLocations()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var location = this.SelectedLocation;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = dD_LocationsTableAdapter.GetData(this.UserID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError((e.Result as Exception));
                    else
                        dDLocationsBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Виконується завантаження локацій..";
                dDLocationsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                if (location != null)
                    this.NavigateToLocation(location.LocationCode);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void NavigateToLocation(string locationCode)
        {
            foreach (DataGridViewRow dgvrLocation in dgvLocations.Rows)
            {
                var location = (dgvrLocation.DataBoundItem as DataRowView).Row as Data.WH.DD_LocationsRow;
                if (location.LocationCode.Equals(locationCode))
                {
                    dgvrLocation.Selected = true;
                    dgvLocations.FirstDisplayedScrollingRowIndex = dgvrLocation.Index;
                    return;
                }
            }
        }

        private void dgvLocations_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
            this.ReloadLocationDevices();
        }

        private void ReloadLocationDevices()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var locationID = this.SelectedLocation != null ? this.SelectedLocation.LocationCode  : (string)null;
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = dD_DevicesTableAdapter.GetData(this.UserID, locationID);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError((e.Result as Exception));
                    else
                        dDDevicesBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Виконується завантаження пристроїв..";
                dDDevicesBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvDevices_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
            this.ReloadDeviceStatistics();
        }

        private void ReloadDeviceStatistics()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var deviceID = this.SelectedDevice!= null ? this.SelectedDevice.Device_ID : (int?)null;
                var month = cmbStatisticsMonthes.SelectedIndex + 1;
                var year = Convert.ToInt32(nudStatisticsYear.Value);

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = dD_DeviceStatisticsTableAdapter.GetData(deviceID, year, month);
                    }
                    catch (Exception ex)
                    {
                        e.Result = ex;
                    }
                };
                bw.RunWorkerCompleted += (s, e) =>
                {
                    splashForm.CloseForce();

                    if (e.Result is Exception)
                        this.ShowError((e.Result as Exception));
                    else
                        dDDeviceStatisticsBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Виконується завантаження статистики..";
                dDDeviceStatisticsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void cmbStatisticsMonthes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!lockInitialize)
                this.ReloadDeviceStatistics();
        }

        private void nudStatisticsYear_ValueChanged(object sender, EventArgs e)
        {
            if (!lockInitialize)
                this.ReloadDeviceStatistics();
        }

        private void dgvDeviceStatistics_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void miDeleteDeviceStatistics_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Видалити статистику за поточний період?", "Увага", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return;

                var deviceID = this.SelectedDevice != null ? this.SelectedDevice.Device_ID : (int?)null;

                dD_DeviceStatisticsTableAdapter.DeleteStatistics(deviceID);

                this.ReloadDeviceStatistics();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void miChangeDeviceIP_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgPrintingDeviceEditor = new PrintingDeviceEditorForm(this.SelectedDevice) { UserID = this.UserID };
                if (dlgPrintingDeviceEditor.ShowDialog() == DialogResult.OK)
                { 
                
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void dgvLocations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dgvDevices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var device = (dgvDevices.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.DD_DevicesRow;
            var color = device.IsColorNull() ? Color.White : Color.FromName(device.Color);

            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = color;
        }

        private void dgvDeviceStatistics_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var deviceStatisticsDay = (dgvDeviceStatistics.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.DD_DeviceStatisticsRow;
            var color = deviceStatisticsDay.IsErrorMessageNull() ? Color.White : Color.LightPink;

            e.CellStyle.BackColor = e.CellStyle.SelectionForeColor = color;
        }
    }
}
