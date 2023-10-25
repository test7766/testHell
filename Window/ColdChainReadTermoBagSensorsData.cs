using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.ColdChain;
using WMSOffice.Controls.ExtraDataGridViewComponents;

namespace WMSOffice.Window
{
    public partial class ColdChainReadTermoBagSensorsData : GeneralWindow
    {
        /// <summary>
        /// Менеджер формы
        /// </summary>
        private ColdChainReadTermoBagSensorsDataManager manager = null;

        public ColdChainReadTermoBagSensorsData(ColdChainReadTermoBagSensorsDataManager manager)
        {
            InitializeComponent();
            this.manager = manager;
        }

        private void SetInterfaceSettings()
        {
            sbReadSensorData.Enabled = IsDataExists();
        }

        /// <summary>
        /// Определение существования набора данных
        /// </summary>
        /// <returns></returns>
        private bool IsDataExists()
        {
            return xdgvMainGrid.SelectedItem != null;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.xdgvMainGrid.DataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
            this.xdgvMainGrid.DataGrid.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
            this.xdgvMainGrid.SetSameStyleForAlternativeRows();

            this.xdgvMainGrid.AllowSummary = false;
            this.xdgvMainGrid.AllowRangeColumns = false;
            this.xdgvMainGrid.UseMultiSelectMode = false;

            this.xdgvMainGrid.Init(new SensorsView(), true);
            this.xdgvMainGrid.UserID = this.UserID;

            this.xdgvMainGrid.OnFilterChanged += new EventHandler(xdgvMainGrid_OnFilterChanged);
            this.xdgvMainGrid.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvMainGrid_OnRowDoubleClick);
            this.xdgvMainGrid.OnRowSelectionChanged += new EventHandler(xdgvMainGrid_OnRowSelectionChanged);

            this.RefreshData();
        }

        void xdgvMainGrid_OnRowSelectionChanged(object sender, EventArgs e)
        {
            if (xdgvMainGrid.SelectedItem != null)
            {
                var row = xdgvMainGrid.SelectedItem as Data.ColdChain.ReadingEquipmentsRow;
                manager.CurrentEquipmentID = row.Equipment_ID;
                manager.CurrentSensorSerialNumber = row.Serial_Number;
                manager.CurrentSensorModeName = row.IsSensor_Mode_NameNull() ? (string)null : row.Sensor_Mode_Name;
            }

            this.SetInterfaceSettings();
        }

        void xdgvMainGrid_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.xdgvMainGrid.SelectedItem != null)
                this.ReadSensorData();
        }

        void xdgvMainGrid_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvMainGrid.RecalculateSummary();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                this.RefreshData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        #region ФОНОВАЯ ЗАГРУЗКА ДАННЫХ

        /// <summary>
        /// Обновление данных
        /// </summary>
        private void RefreshData()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvMainGrid.DataView.FillData(e.Argument as SensorsSearchParameters);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    this.xdgvMainGrid.BindData(false);
                    this.xdgvMainGrid.AllowSummary = true;
                }

                manager.WaitProcessForm.CloseForce();
            };

            manager.WaitProcessForm.ActionText = "Загрузка списка закрепленного оборудования..";

            var searchParameters = new SensorsSearchParameters();
            searchParameters.SessionID = this.UserID;

            loadworker.RunWorkerAsync(searchParameters);
            manager.WaitProcessForm.ShowDialog();
        }

        #endregion

        private void sbReadSensorData_Click(object sender, EventArgs e)
        {
            this.ReadSensorData();  
        }

        /// <summary>
        /// Снять показания с датчика
        /// </summary>
        private void ReadSensorData()
        {
            try
            {
                Data.ColdChain.EquipmentSensorPeriodRow equipmentSensorPeriod = GetEquipmentSensorPeriod();
                using (WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm dataLoggerSaveForm = new WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm()
                {
                    UserID = this.UserID, 
                    EquipmentID = manager.CurrentEquipmentID,
                    StartTimeStamp = equipmentSensorPeriod.Date_From,
                    EndTimeStamp = equipmentSensorPeriod.Date_To,
                    SensorSerialNumber = manager.CurrentSensorSerialNumber,
                    SensorModeName = manager.CurrentSensorModeName
                })
                    if (dataLoggerSaveForm.ShowDialog() == DialogResult.OK)
                        this.RefreshData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка момента снятия показаний с датчика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Получения диапазона дат для датчика оборудования
        /// </summary>
        /// <returns></returns>
        private Data.ColdChain.EquipmentSensorPeriodRow GetEquipmentSensorPeriod()
        {
            try
            {
                using (Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter())
                    adapter.Fill(this.coldChain.EquipmentSensorPeriod, manager.CurrentEquipmentID, (long?)null);

                return this.coldChain.EquipmentSensorPeriod[0];
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        private void dgvMainGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.ReadSensorData();
        }
    }

    /// <summary>
    /// Отображение датчиков
    /// </summary>
    public class SensorsView : IDataView
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        #region IDataView Members

        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();
        public PatternColumnsCollection Columns
        {
            get { return this.dataColumns; }
        }

        private DataTable data;
        public DataTable Data
        {
            get { return this.data; }
        }

        /// <summary>
        /// Поиск конечной выборки согласно критериям
        /// </summary>
        /// <param name="searchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as SensorsSearchParameters;

            using (var adapter = new Data.ColdChainTableAdapters.ReadingEquipmentsTableAdapter())
                this.data = adapter.GetData(searchCriteria.SessionID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public SensorsView()
        {
            this.dataColumns.Add(new PatternColumn("№", "Equipment_ID", new FilterCompareExpressionRule<Int32>("Equipment_ID"), SummaryCalculationType.Count) { Width = 50 });
            this.dataColumns.Add(new PatternColumn("Название", "Equipment_Name", new FilterPatternExpressionRule("Equipment_Name")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Тип", "Equipment_Type_Name", new FilterPatternExpressionRule("Equipment_Type_Name")) { Width = 180 });
            //this.dataColumns.Add(new PatternColumn("Филиал", "Branch", new FilterPatternExpressionRule("Branch")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Филиал", "Filial_Name", new FilterPatternExpressionRule("Filial_Name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Отдел", "Department", new FilterPatternExpressionRule("Department")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Тип транспортировки", "Transportation_Type_Name", new FilterPatternExpressionRule("Transportation_Type_Name")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("S/N датчика", "Serial_Number", new FilterPatternExpressionRule("Serial_Number")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Тип датчика", "Sensor_Type_Name", new FilterPatternExpressionRule("Sensor_Type_Name")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Режим t° датчика", "Sensor_Mode_Name", new FilterPatternExpressionRule("Sensor_Mode_Name")) { Width = 150 });
            //this.dataColumns.Add(new PatternColumn("Водитель-экспедитор", "Forwarder", new FilterPatternExpressionRule("Forwarder")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("Водитель-экспедитор", "Forwarder_Name", new FilterPatternExpressionRule("Forwarder_Name")) { Width = 400 });
        }
        #endregion
    }

    public class SensorsSearchParameters : SessionIDSearchParameters
    { 
    
    }
}
