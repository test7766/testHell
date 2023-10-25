using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ServiceProcess;
using WMSOffice.Dialogs.WH;

namespace WMSOffice.Window
{
    public partial class SortStationsDispatcherWindow : GeneralWindow
    {
        public Data.WH.PTL_StationsRow SelectedStation
        {
            get { return dgvStations.SelectedRows.Count > 0 ? (dgvStations.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.PTL_StationsRow : null; }
        }

        public Data.WH.PTL_Station_DetailsRow SelectedStationDetail
        {
            get { return dgvStationDetails.SelectedRows.Count > 0 ? (dgvStationDetails.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.PTL_Station_DetailsRow : null; }
        }

        public Data.WH.PTL_Station_ContainersRow SelectedContainer
        {
            get { return dgvStationContainers.SelectedRows.Count > 0 ? (dgvStationContainers.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.PTL_Station_ContainersRow : null; }
        }

        public SortStationsDispatcherWindow()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.ReloadStations();
                return true;
            }

            if (keyData == (Keys.F6))
            {
                this.Restart();
                return true;
            }

            if (keyData == (Keys.F7))
            {
                this.CreateComplaint();
                return true;
            }

            if (keyData == (Keys.F8))
            {
                this.CancelBox();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void Initialize()
        {
            this.ReloadStations();
            this.SetOperationsAccess();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.ReloadStations();
        }

        private void ReloadStations()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var station = this.SelectedStation;

                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) => 
                {
                    try
                    {
                        e.Result = pTL_StationsTableAdapter.GetData(this.UserID);
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
                         pTLStationsBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Выполняется загрузка станций..";
                pTLStationsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();

                if (station != null)
                    this.NavigateToStation(station.Station_ID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void NavigateToStation(short stationID)
        {
            foreach (DataGridViewRow dgvStation in dgvStations.Rows)
            {
                var station = (dgvStation.DataBoundItem as DataRowView).Row as Data.WH.PTL_StationsRow;
                if (station.Station_ID.Equals(stationID))
                {
                    dgvStation.Selected = true;
                    dgvStations.FirstDisplayedScrollingRowIndex = dgvStation.Index;
                    return;
                }
            }
        }

        private void dgvStations_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
            this.ReloadStationDetails();
            this.ReloadStationContainers();
        }

        private void dgvStationDetails_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationsAccess();
        }

        private void SetOperationsAccess()
        {
            var isEnabled = this.SelectedStation != null;
            btnRestart.Enabled = isEnabled;
            btnCreateComplaint.Enabled = isEnabled;

            var isDetailEnabled = this.SelectedStationDetail != null;
            btnCancelBox.Enabled = isDetailEnabled;
        }

        private void ReloadStationDetails()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var stationID = this.SelectedStation != null ? this.SelectedStation.Station_ID : (short?)null;
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = pTL_Station_DetailsTableAdapter.GetData(stationID);
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
                        pTLStationDetailsBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Выполняется загрузка товара..";
                pTLStationDetailsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void ReloadStationContainers()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var stationID = this.SelectedStation != null ? this.SelectedStation.Station_ID : (short?)null;
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = pTL_Station_ContainersTableAdapter.GetData(stationID);
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
                        pTLStationContainersBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Выполняется загрузка контейнеров..";
                pTLStationContainersBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void dgvStationContainers_SelectionChanged(object sender, EventArgs e)
        {
            this.ReloadStationContainerDetails();
        }

        private void ReloadStationContainerDetails()
        {
            try
            {
                var splashForm = new WMSOffice.Dialogs.SplashForm();

                var containerID = this.SelectedContainer != null ? this.SelectedContainer.Port_Container_ID : (long?)null;
                var bw = new BackgroundWorker();
                bw.DoWork += (s, e) =>
                {
                    try
                    {
                        e.Result = pTL_Station_Container_DetailsTableAdapter.GetData(containerID);
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
                        pTLStationContainerDetailsBindingSource.DataSource = e.Result;
                };
                splashForm.ActionText = "Выполняется загрузка товаров в контейнере..";
                pTLStationContainerDetailsBindingSource.DataSource = null;
                bw.RunWorkerAsync();
                splashForm.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void dgvStations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;
           
            if (dgvStations.Columns[e.ColumnIndex].DataPropertyName == wH.PTL_Stations.Last_Error_DescrColumn.Caption)
            {
                var boundRow = (dgvStations.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PTL_StationsRow;
                Color color = Color.Empty;
                switch (boundRow.IsError_FlagNull() ? 0 : boundRow.Error_Flag)
                {
                    case 2: // сканирование успешно
                        color = Color.LightGreen;
                        break;
                    case 1: // сканирование неуспешно
                        color = Color.Salmon;
                        break;
                    case 0: // остальное
                    default:
                        color = Color.White;
                        break;
                }

                e.CellStyle.BackColor = color;
                e.CellStyle.SelectionForeColor = color;
            }
        }

        private void dgvStationDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            var boundRow = (dgvStationDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PTL_Station_DetailsRow;
            Color color = Color.Empty;
            switch (boundRow.IsState_flagNull() ? 0 : boundRow.State_flag)
            {
                case 100: // ожидается со вчерашнего дня
                    color = Color.Salmon;
                    break;
                case 30: // обработан
                    color = Color.LightGreen;
                    break;
                case 20: // в работе
                    color = Color.Khaki;
                    break;
                case 10: // на станции
                    color = Color.White;
                    break;
                case 0 : // ожидается
                default:
                    color = Color.LightGray;
                    break;
            }

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }

        private void dgvStationContainers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0)
                return;

            var boundRow = (dgvStationContainers.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.PTL_Station_ContainersRow;
            Color color = Color.Empty;
            if (!boundRow.IsFN_DTTMNull())
            {
                if (!boundRow.IsSent_To_ControlNull() && boundRow.Sent_To_Control)
                {
                    color = Color.LightGreen; // контейнер отправлен на контроль
                }
                else
                {
                    color = Color.Khaki; // контейнер закрыт
                }
            }
            else
            {
                color = Color.White; // контейнер открыт 
            }

            e.CellStyle.BackColor = color;
            e.CellStyle.SelectionForeColor = color;
        }
        

        private void btnRestart_Click(object sender, EventArgs e)
        {
            this.Restart();
        }

        private void Restart()
        {
            if (!btnRestart.Enabled)
                return;

            try
            {
                var clusterID = this.SelectedStation.Cluster_ID;
                pTL_StationsTableAdapter.Restart(clusterID, true);

                MessageBox.Show("Перезапуск службы произойдет в течении минуты.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCreateComplaint_Click(object sender, EventArgs e)
        {
            this.CreateComplaint();
        }

        private void CreateComplaint()
        {
            if (!btnCreateComplaint.Enabled)
                return;

            try
            {
                var stationID = this.SelectedStation.Station_ID;

                var complaintTypes = new Data.WH.PTL_Declare_CO_TypesDataTable();
                using (var adapter = new Data.WHTableAdapters.PTL_Declare_CO_TypesTableAdapter())
                    adapter.Fill(complaintTypes, this.UserID, stationID);

                var frmSetSortStationsCompaintParams = new SetSortStationsComplaintParamsForm(complaintTypes);
                if (frmSetSortStationsCompaintParams.ShowDialog() == DialogResult.OK)
                {
                    var docType = frmSetSortStationsCompaintParams.DocType;
                    var docSubType = frmSetSortStationsCompaintParams.DocSubType;
                    var quantity = frmSetSortStationsCompaintParams.Quantity;

                    var requestID = (long?)null;
                    using (var adapter = new Data.WHTableAdapters.PTL_Declare_CO_TypesTableAdapter())
                        adapter.CreateComplaintRequest(this.UserID, stationID, docType, docSubType, quantity, ref requestID);

                    if (requestID.HasValue)
                    {
                        MessageBox.Show(string.Format("Создана заявка на создание претензии № {0}.", requestID.Value), "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        
                        this.Restart();
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }


        private void btnCancelBox_Click(object sender, EventArgs e)
        {
            this.CancelBox();
        }

        private void CancelBox()
        {
            if (!btnCancelBox.Enabled)
                return;

            if (MessageBox.Show("Отклонить выбранный ящик?", "Отмена ящика", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                return;

            try
            {
                var stationBoxID = this.SelectedStationDetail.Station_Box_ID;

                using (var adapter = new Data.WHTableAdapters.PTL_Station_DetailsTableAdapter())
                    adapter.CancelBox(stationBoxID);

                this.ReloadStations();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }
    }
}
