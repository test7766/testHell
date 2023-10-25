using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.ColdChain;

namespace WMSOffice.Window
{
    public partial class ColdChainProcessSensorsDataWindow : GeneralWindow
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm splashForm = new WMSOffice.Dialogs.SplashForm();

        public ColdChainProcessSensorsDataWindow()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.xdgvDetails.DataGrid.ColumnHeadersDefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
            this.xdgvDetails.DataGrid.DefaultCellStyle.Font = new Font(new FontFamily("Microsoft Sans Serif"), 10);
            this.xdgvDetails.SetSameStyleForAlternativeRows();

            this.xdgvDetails.FilterGrid.DefaultCellStyle = this.xdgvDetails.DataGrid.DefaultCellStyle;
            this.xdgvDetails.SummaryGrid.DefaultCellStyle = this.xdgvDetails.DataGrid.DefaultCellStyle;

            this.xdgvDetails.AllowSummary = false;
            this.xdgvDetails.AllowRangeColumns = false;
            this.xdgvDetails.UseMultiSelectMode = false;

            this.xdgvDetails.Init(new ReadSensorsView(), true);
            this.xdgvDetails.UserID = this.UserID;

            this.xdgvDetails.OnFilterChanged += new EventHandler(xdgvDetails_OnFilterChanged);
            this.xdgvDetails.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvDetails_OnRowDoubleClick);
            this.xdgvDetails.OnRowSelectionChanged += new EventHandler(xdgvDetails_OnRowSelectionChanged);
            this.xdgvDetails.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvDetails_OnFormattingCell);

            SetInterfaceSettings();
            this.RefreshDocs(false);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F5)
            {
                this.RefreshDocs(false);
                return true;
            }

            if (keyData == (Keys.Control | Keys.F))
            {
                this.FindSensor();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        void xdgvDetails_OnRowSelectionChanged(object sender, EventArgs e)
        {
            SetInterfaceSettings();
        }

        private void SetInterfaceSettings()
        {
            var isSelected = xdgvDetails.SelectedItem != null;
            var needReadSensor = isSelected && !Convert.ToBoolean(xdgvDetails.SelectedItem["IsReadOut"] == DBNull.Value ? false : xdgvDetails.SelectedItem["IsReadOut"]);
            sbReadSensorData.Enabled = needReadSensor;
        }

        void xdgvDetails_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (sbReadSensorData.Enabled)
                this.ReadSensorData();
        }

        void xdgvDetails_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvDetails.RecalculateSummary();
        }

        void xdgvDetails_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var drDetail = (this.xdgvDetails.DataGrid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
            var isArchived = Convert.ToBoolean(drDetail["IsReadOut"] == DBNull.Value ? false : drDetail["IsReadOut"]);

            if (isArchived)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.SelectionForeColor = Color.LightGray;
            }
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var drDoc = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.ColdChain.ReadOutDocsRow;
            var isArchived = Convert.ToBoolean(drDoc.IsArchivedNull() ? false : (object)drDoc.Archived);

            if (isArchived)
            {
                e.CellStyle.BackColor = Color.LightGray;
                e.CellStyle.SelectionForeColor = Color.LightGray;
            }
        }

        #region ОБНОВЛЕНИЕ ЗАКРЕПЛЕНИЙ

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            RefreshDocs(false);
        }

        private void RefreshDocs(bool useFilter)
        {
            var loadWorker = new BackgroundWorker();

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    var sp = e.Argument as SearchWorkedEquipmentParameters;
                    e.Result = readOutDocsTableAdapter.GetData(
                        sp.SessionID,
                        sp.DocID,
                        sp.EquipmentBarCode,
                        sp.SensorBarCode,
                        sp.RouteListNumber,
                        sp.RouteListDate,
                        sp.DriverCode,
                        sp.PickSlipNumber,
                        sp.DebtorCode,
                        sp.SearchInArchive);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };

            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                    readOutDocsBindingSource.DataSource = e.Result;

                splashForm.CloseForce();
            };

            var searchParameters = useFilter ? SearchWorkedEquipment.SearchParameters : new SearchWorkedEquipmentParameters() { SessionID = UserID };

            splashForm.ActionText = "Выполняется поиск документов по закрепленному оборудованию..";
            readOutDocsBindingSource.DataSource = null;
            loadWorker.RunWorkerAsync(searchParameters);
            splashForm.ShowDialog();
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            RefreshDetails();
        }

        private void RefreshDetails()
        {
            try
            {
                var searchParameters = new ReadSensorsSearchParameters();
                searchParameters.SessionID = this.UserID;
                searchParameters.DocID = dgvDocs.SelectedRows.Count == 0 ? (long?)null : ((dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.ColdChain.ReadOutDocsRow).doc_id;

                this.xdgvDetails.DataView.FillData(searchParameters);
                this.xdgvDetails.BindData(false);
                this.xdgvDetails.AllowSummary = true;
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        #endregion

        #region ПОИСК ЗАКРЕПЛЕНИЙ

        private void sbFindSensor_Click(object sender, EventArgs e)
        {
            FindSensor();
        }

        private void FindSensor()
        {
            using (var frmSearch = new SearchWorkedEquipment() { UserID = this.UserID })
            {
                if (frmSearch.ShowDialog() == DialogResult.OK)
                    this.RefreshDocs(true);
            }
        }

        #endregion

        #region СНЯТИЕ ПОКАЗАНИЙ С ДАТЧИКА

        private void sbReadSensorData_Click(object sender, EventArgs e)
        {
            ReadSensorData();
        }

        /// <summary>
        /// Снять показания с датчика
        /// </summary>
        private void ReadSensorData()
        {
            try
            {
                var equipmentID = Convert.ToInt32(xdgvDetails.SelectedItem["Equipment_ID"]);
                var sensorModeName = xdgvDetails.SelectedItem["Sensor_Mode_Name"].ToString();
                var docID = Convert.ToInt64(xdgvDetails.SelectedItem["doc_id"]);
                var sensorSerialNumber = xdgvDetails.SelectedItem["Serial_Number"].ToString();

                Data.ColdChain.EquipmentSensorPeriodRow equipmentSensorPeriod = GetEquipmentSensorPeriod(equipmentID, docID);
                using (WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm dataLoggerSaveForm = new WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm()
                {
                    UserID = this.UserID,
                    EquipmentID = equipmentID,
                    StartTimeStamp = equipmentSensorPeriod.Date_From,
                    EndTimeStamp = equipmentSensorPeriod.Date_To,
                    SensorSerialNumber = sensorSerialNumber,
                    SensorModeName = sensorModeName,
                    ValidateSensorMode = true,
                    DocID = docID
                })
                {
                    if (dataLoggerSaveForm.ShowDialog() == DialogResult.OK)
                    {
                        if (this.ArchiveSensorData())
                            this.RefreshDetails();
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Ошибка момента снятия показаний с датчика", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Архивация снятых показаний
        /// </summary>
        private bool ArchiveSensorData()
        {
            // Архивация снятых показний выполнена на этапе сохранения
            return true;
        }

        /// <summary>
        /// Получения диапазона дат для датчика оборудования
        /// </summary>
        /// <returns></returns>
        private Data.ColdChain.EquipmentSensorPeriodRow GetEquipmentSensorPeriod(int equipmentID, long? docID)
        {
            try
            {
                using (Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter())
                    adapter.Fill(this.coldChain.EquipmentSensorPeriod, equipmentID, docID);

                return this.coldChain.EquipmentSensorPeriod[0];
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        #endregion

        #region ЖУРНАЛ УЧЕТА ТЕМПЕРАТУРНОГО РЕЖИМА

        private void sbOpenTemperatureAccountingReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Журнал учета темпаратур находится в процессе разработки!");
        }

        #endregion
    }

    /// <summary>
    /// Отображение датчиков
    /// </summary>
    public class ReadSensorsView : IDataView
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
            var searchCriteria = searchParameters as ReadSensorsSearchParameters;

            using (var adapter = new Data.ColdChainTableAdapters.ReadOutDetailsTableAdapter())
                this.data = adapter.GetData(searchCriteria.DocID);
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public ReadSensorsView()
        {
            this.dataColumns.Add(new PatternColumn("№ п/п", "line_id", new FilterCompareExpressionRule<Int32>("line_id")));
            this.dataColumns.Add(new PatternColumn("№ сборочного", "RelatedPickSlipNumber", new FilterCompareExpressionRule<Int32>("RelatedPickSlipNumber"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Дебитор доставки", "FormattedDebtorPointName", new FilterPatternExpressionRule("FormattedDebtorPointName"), SummaryCalculationType.Count) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("№ оборудования", "Equipment_ID", new FilterCompareExpressionRule<Int32>("Equipment_ID"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Название оборудования", "Equipment_Name", new FilterPatternExpressionRule("Equipment_Name")));
            this.dataColumns.Add(new PatternColumn("Тип оборудования", "Equipment_Type_Name", new FilterPatternExpressionRule("Equipment_Type_Name")));
            this.dataColumns.Add(new PatternColumn("Отдел", "Department", new FilterPatternExpressionRule("Department")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Тип транспортировки", "Transportation_Type_Name", new FilterPatternExpressionRule("Transportation_Type_Name")) { Width = 170 });
            this.dataColumns.Add(new PatternColumn("S/N датчика", "Serial_Number", new FilterPatternExpressionRule("Serial_Number"), SummaryCalculationType.Count));
            this.dataColumns.Add(new PatternColumn("Тип датчика", "Sensor_Type_Name", new FilterPatternExpressionRule("Sensor_Type_Name")));
            this.dataColumns.Add(new PatternColumn("Режим t° датчика", "Sensor_Mode_Name", new FilterPatternExpressionRule("Sensor_Mode_Name")));
            this.dataColumns.Add(new PatternColumn("Дата поверки", "Verification_Date", new FilterDateCompareExpressionRule("Verification_Date")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Тип документа", "Doc_Type_Name", new FilterPatternExpressionRule("Doc_Type_Name")));
        }
        #endregion
    }

    /// <summary>
    /// Параметры поиска датчиков
    /// </summary>
    public class ReadSensorsSearchParameters : SessionIDSearchParameters
    {
        public long? DocID { get; set; }
    }
}
