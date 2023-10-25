using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using WMSOffice.Dialogs.Delivery;
using WMSOffice.Dialogs.Inventory;

namespace WMSOffice.Window
{
    public partial class DeliveryCloseActsWindow : GeneralWindow
    {
        /// <summary>
        /// Режим основной
        /// </summary>
        public static readonly int GENERAL_MODE = 1;

        /// <summary>
        /// Режим филиальный
        /// </summary>
        public static readonly int BRANCH_MODE = 2;

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных
        /// </summary>
        private Dialogs.SplashForm waitProgressForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Режим работы 
        /// </summary>
        public int WorkMode { get; private set; }

        /// <summary>
        /// Описание режима работы
        /// </summary>
        public string WorkModeDescription { get; private set; }

        #endregion

        public DeliveryCloseActsWindow()
        {
            InitializeComponent();

            splitContainer2.Visible = false;
            splitContainer1.Visible = false;
        }

        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrEmpty(tbBarcode.Text))
                    try
                    {
                        var typeID = this.WorkMode == BRANCH_MODE ? 1 : this.WorkMode == GENERAL_MODE ? 0 : (int?)null;
                        using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
                            adapter.ArchiveAct(UserID, tbBarcode.Text, typeID);
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                tbBarcode.Text = "";
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Title = "Сохранение списка не вернувшихся Актов МИБП";
                dlg.FileName = "Cписок не вернувшихся Актов МИБП, " + DateTime.Now.ToShortDateString() + ".csv";
                dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                dlg.Filter = "Текстовый файл с разделителями (*.csv)|*.csv;*.csv|Все файлы (*.*)|*.*";
                dlg.FilterIndex = 0;
                dlg.AddExtension = true;
                dlg.DefaultExt = "csv";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        this.xdgvLines.ExportToExcel(dlg.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Во время экспорта списка не вернувшихся Актов МИБП возникла следующая ошибка:" +
                            Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDocs();
        }

        void xdgvLines_OnRowSelectionChanged(object sender, EventArgs e)
        {
            ChangeOperationsAccess();
            RefreshLines();
        }

        private void ChangeOperationsAccess()
        {
            bool isEnabled = xdgvLines.SelectedItem != null;

            btnAssignTermoBox.Text = !isEnabled ? "Закрепить/вернуть\nтермобокс" : this.xdgvLines.SelectedItem["Equipment_ID"].Equals(DBNull.Value) ? "Закрепить\nтермобокс" : "Вернуть\nтермобокс";

            btnAssignDataLogger.Enabled = isEnabled;
            btnAssignTermoBox.Enabled = isEnabled && !this.xdgvLines.SelectedItem["Sensor_ID"].Equals(DBNull.Value);

            //btnCloseAct.Enabled = isEnabled && !this.xdgvLines.SelectedItem["Equipment_ID"].Equals(DBNull.Value);
        }

        private void RefreshLines()
        {
            try
            {
                var pickSlipNumber = xdgvLines.SelectedItem == null ? (long?)null : Convert.ToInt64(xdgvLines.SelectedItem["RelatedPickSlipNumber"]);
                var doco = xdgvLines.SelectedItem == null ? (int?)null : Convert.ToInt32(xdgvLines.SelectedItem["RelatedPoSoNumber"]);
                var dcto = xdgvLines.SelectedItem == null ? (string)null : xdgvLines.SelectedItem["RelatedOrderType"].ToString();
                var docID = xdgvLines.SelectedItem == null ? (long?)null : Convert.ToInt64(xdgvLines.SelectedItem["Doc_ID"]);
                
                notClosedActsDetailsTableAdapter.SetTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);
                notClosedActsDetailsTableAdapter.Fill(delivery.NotClosedActsDetails, pickSlipNumber, doco, dcto, docID);
            }
            catch (Exception ex)
            {
                ShowError(ex);
            }
        }

        void xdgvLines_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvLines.RecalculateSummary();
        }

        void xdgvLines_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var grid = sender as DataGridView;

                var boundRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as DataRow;
                var color = Color.FromName(boundRow["Color"].ToString());

                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
            catch
            { 
            
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (!this.ContinueWorkInSelectedMode())
            {
                this.Close();
                return;
            }

            splitContainer2.Visible = true;
            splitContainer1.Visible = true;

            this.InitializeWorkArea();
        }

        /// <summary>
        /// Возвращает признак продолжения работать с интерфейсом в установленном режиме
        /// </summary>
        /// <returns></returns>
        private bool ContinueWorkInSelectedMode()
        {
            try
            {
                Data.Delivery.DeliveryTermoActsWorkModesRow selectedMode = null;

                using (var adapter = new Data.DeliveryTableAdapters.DeliveryTermoActsWorkModesTableAdapter())
                    adapter.Fill(delivery.DeliveryTermoActsWorkModes, this.UserID);

                if (delivery.DeliveryTermoActsWorkModes.Rows.Count == 1)
                {
                    selectedMode = delivery.DeliveryTermoActsWorkModes[0];
                }
                else
                {
                    var dlgSelectWorkMode = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectWorkMode.Text = "Выберите режим работы";
                    dlgSelectWorkMode.AddColumn("ModeName", "ModeName", "Режим работы");
                    dlgSelectWorkMode.FilterVisible = false;
                    dlgSelectWorkMode.DataSource = delivery.DeliveryTermoActsWorkModes;

                    if (dlgSelectWorkMode.ShowDialog() == DialogResult.OK)
                        selectedMode = dlgSelectWorkMode.SelectedRow as Data.Delivery.DeliveryTermoActsWorkModesRow;
                }

                if (selectedMode != null)
                {
                    this.WorkMode = selectedMode.ModeID;
                    this.WorkModeDescription = selectedMode.ModeName;
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        /// <summary>
        /// Инициализация рабочей области
        /// </summary>
        private void InitializeWorkArea()
        {
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WorkModeDescription.Trim());

            if (this.WorkMode == BRANCH_MODE)
            {
                btnAssignDataLogger.Visible = false;
                btnAssignTermoBox.Visible = false;
                btnRegistrationOnRoute.Visible = false;
                btnShowRouteDataLoggers.Visible = false;
                sbTermoboxMoveHistory.Visible = false;

                //splitContainer1.Panel2Collapsed = true;
            }

            this.xdgvLines.AllowSummary = false;
            this.xdgvLines.AllowRangeColumns = true;
            this.xdgvLines.SetSameStyleForAlternativeRows();
            this.xdgvLines.SetCellStyles(dgvDetails.RowTemplate.DefaultCellStyle, dgvDetails.ColumnHeadersDefaultCellStyle);
            this.xdgvLines.FilterGrid.DefaultCellStyle = this.xdgvLines.DataGrid.DefaultCellStyle;
            this.xdgvLines.SummaryGrid.DefaultCellStyle = this.xdgvLines.DataGrid.DefaultCellStyle;

            this.xdgvLines.Init(new CloseActsView(), true);
            this.xdgvLines.LoadExtraDataGridViewSettings(this.Name);
            this.xdgvLines.UserID = this.UserID;

            xdgvLines.OnRowSelectionChanged += new EventHandler(xdgvLines_OnRowSelectionChanged);
            xdgvLines.OnFilterChanged += new EventHandler(xdgvLines_OnFilterChanged);
            xdgvLines.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvLines_OnFormattingCell);

            // активация постраничного просмотра
            xdgvLines.CreatePageNavigator();

            RefreshDocs();
            tbBarcode.Focus();
        }

        private void RefreshDocs()
        {
            var loadWorker = new BackgroundWorker();

            var sp = new CloseActsViewSearcParameters();
            sp.SessionID = this.UserID;
            sp.WorkMode = this.WorkMode;

            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvLines.DataView.FillData(e.Argument as CloseActsViewSearcParameters);
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
                {
                    this.xdgvLines.BindData(false);
                    this.xdgvLines.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadWorker.RunWorkerAsync(sp);
            waitProgressForm.ShowDialog();
        }

        #region ОБРАБОТКА АКТОВ

        private void btnAssignDataLogger_Click(object sender, EventArgs e)
        {
            try
            {
                // Получение списка логгеров
                using (var adapter = new Data.DeliveryTableAdapters.SensorsTableAdapter())
                    adapter.Fill(delivery.Sensors, this.UserID);

                var dlgSelectDataLogger = new WMSOffice.Dialogs.RichListForm();
                dlgSelectDataLogger.Text = "Выберите логгер";
                dlgSelectDataLogger.AddColumn("Sensor_Name", "Sensor_Name", "S/N");
                dlgSelectDataLogger.AddColumn("Sensor_BarCode", "Sensor_BarCode", "Ш/К");
                dlgSelectDataLogger.ColumnForFilters = new List<string>(new string[] { "Sensor_Name", "Sensor_BarCode" });
                dlgSelectDataLogger.FilterChangeLevel = 0;

                delivery.Sensors.DefaultView.RowFilter = string.Empty;
                dlgSelectDataLogger.DataSource = delivery.Sensors;

                if (dlgSelectDataLogger.ShowDialog() != DialogResult.OK)
                    return;

                long docID = Convert.ToInt64(this.xdgvLines.SelectedItem["Doc_ID"]);

                var dataLogger = dlgSelectDataLogger.SelectedRow as Data.Delivery.SensorsRow;
                var sensorBarCode = dataLogger.IsSensor_BarcodeNull() ? (string)null : dataLogger.Sensor_Barcode;

                // Закрепление логгера
                using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
                    adapter.AddDataLogger(this.UserID, docID, sensorBarCode);

                // Перечитка актов
                this.RefreshDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnAssignTermoBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Выбор действия: закрепление/возврат термобокса
                var assignTermoboxMode = this.xdgvLines.SelectedItem["Equipment_ID"].Equals(DBNull.Value);

                var equipmentBarCode = string.Empty;
                int driverID = 0;

                #region СКАНИРОВАНИЕ ТЕРМОБОКСА

                var dlgTermoboxScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = string.Format("Отсканируйте термобокс,\r\nкоторый необходимо {0}", assignTermoboxMode ? "закрепить" : "вернуть"),
                    Text = string.Format("{0} термобокса", assignTermoboxMode ? "Закрепление" : "Возврат"),
                    Image = Properties.Resources.cold_chain_icon_75
                };

                if (dlgTermoboxScanner.ShowDialog() == DialogResult.OK)
                    equipmentBarCode = dlgTermoboxScanner.Barcode;
                else
                    return;

                #endregion

                #region СКАНИРОВАНИЕ ВОДИТЕЛЯ

                var dlgDriverScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    OnlyNumbersInBarcode = true,
                    Label = "Отсканируйте бэйдж водителя,\r\nкоторый транспортирует термобокс",
                    Text = "Подтверждение водителя",
                    Image = Properties.Resources.metacontact_unknown
                };

                if (dlgDriverScanner.ShowDialog() == DialogResult.OK)
                    driverID = Convert.ToInt32(dlgDriverScanner.Barcode);
                else
                    return;

                #endregion

                long docID = Convert.ToInt64(this.xdgvLines.SelectedItem["Doc_ID"]);

                using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
                {
                    if (assignTermoboxMode)
                        adapter.AddTermoBox(this.UserID, docID, equipmentBarCode, driverID); // закрепление термобокса
                    else
                        adapter.ReturnTermoBox(this.UserID, docID, equipmentBarCode, driverID); // возврат термобокса
                }

                // Перечитка актов
                this.RefreshDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnRegistrationOnRoute_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgScanEmployee = new ScanEmployeeForm() 
                { 
                    Text = "Выбор водителя", 
                    Description  = "Отсканируйте штрих-код водителя:", 
                    //UseScanModeOnly = true 
                };

                if (dlgScanEmployee.ShowDialog() != DialogResult.OK)
                    return;

                var employeeID = dlgScanEmployee.EmployeeID;
                var employeeName = dlgScanEmployee.EmployeeName;

                var dlgRegistrationOnRoute = new DeliveryRegistrationOnRouteForm()
                {
                    UserID = this.UserID,
                    ForwarderID = employeeID,
                    ForwarderName = employeeName
                };

                if (dlgRegistrationOnRoute.ShowDialog() == DialogResult.OK)
                {
                    // Перечитка актов
                    this.RefreshDocs();
                }
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnShowRouteDataLoggers_Click(object sender, EventArgs e)
        {
            try
            {
                var dlgDeliverySensorsOnRoute = new DeliverySensorsOnRoute() { UserID = this.UserID };
                dlgDeliverySensorsOnRoute.ShowDialog();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void sbTermoboxMoveHistory_Click(object sender, EventArgs e)
        {
            try
            {
                var equipmentBarCode = string.Empty;

                #region СКАНИРОВАНИЕ ТЕРМОБОКСА

                var dlgTermoboxScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте термобокс,\r\nпо которому необходимо посмотреть историю движения",
                    Text = "История движения термобокса",
                    Image = Properties.Resources.cold_chain_icon_75
                };

                if (dlgTermoboxScanner.ShowDialog() == DialogResult.OK)
                    equipmentBarCode = dlgTermoboxScanner.Barcode;
                else
                    return;

                #endregion

                #region ПОЛУЧЕНИЕ ИСТОРИИ ЗАКРЕПЛЕНИЯ

                using (var adapter = new Data.DeliveryTableAdapters.TermoboxMoovingHistoryTableAdapter())
                    adapter.Fill(delivery.TermoboxMoovingHistory, this.UserID, equipmentBarCode);

                var dlgDeliveryTermoboxMoovingHistory = new DeliveryTermoboxMoovingHistory();
                dlgDeliveryTermoboxMoovingHistory.SetDataSource(delivery.TermoboxMoovingHistory);
                dlgDeliveryTermoboxMoovingHistory.ShowDialog();
                
                #endregion
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnCloseAct_Click(object sender, EventArgs e)
        {
            try
            {
                var actBarCode = string.Empty;
                var equipmentID = (int?)null;

                #region СКАНИРОВАНИЕ АКТА

                var dlgActScanner = new WMSOffice.Dialogs.Containers.ScanContainerForm()
                {
                    Label = "Отсканируйте акт,\r\nкоторый необходимо закрыть",
                    Text = "Закрытие акта",
                    Image = Properties.Resources.document_ok
                };

                if (dlgActScanner.ShowDialog() == DialogResult.OK)
                    actBarCode = dlgActScanner.Barcode;
                else
                    return;

                #endregion

                // только для основного режима
                if (this.WorkMode == GENERAL_MODE)
                {
                    #region ПОЛУЧЕНИЕ ТЕРМОБОКСА

                    using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
                        adapter.SearchActEquipmentID(this.UserID, actBarCode, ref equipmentID);

                    if (!equipmentID.HasValue)
                        return;

                    #endregion

                    #region СНЯТИЕ ПОКАЗАНИЙ С ЛОГГЕРА

                    var equipmentSensorPeriod = new Data.ColdChain.EquipmentSensorPeriodDataTable();

                    using (var adapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter())
                        adapter.Fill(equipmentSensorPeriod, equipmentID, (long?)null);

                    if (equipmentSensorPeriod.Rows.Count == 0)
                        throw new Exception("Невозможно получить период, за который необходимо снять показания логгера.");

                    var dataLoggerSaveForm = new WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm()
                    {
                        UserID = this.UserID,
                        EquipmentID = equipmentID,
                        StartTimeStamp = equipmentSensorPeriod[0].Date_From,
                        EndTimeStamp = equipmentSensorPeriod[0].Date_To
                    };

                    if (dataLoggerSaveForm.ShowDialog() != DialogResult.OK)
                        return;

                    #endregion
                }

                #region ЗАКРЫТИЕ АКТА

                var typeID = this.WorkMode == BRANCH_MODE ? 1 : this.WorkMode == GENERAL_MODE ? 0 : (int?)null;
                using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
                    adapter.ArchiveAct(this.UserID, actBarCode, typeID);

                #endregion

                this.RefreshDocs();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }

            #region OBSOLETE

            //try
            //{
            //    var equipmentID = Convert.ToInt32(this.xdgvLines.SelectedItem["Equipment_ID"]);
            //    var equipmentSensorPeriod = new Data.ColdChain.EquipmentSensorPeriodDataTable();

            //    using (Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter adapter = new WMSOffice.Data.ColdChainTableAdapters.EquipmentSensorPeriodTableAdapter())
            //        adapter.Fill(equipmentSensorPeriod, equipmentID);

            //    if (equipmentSensorPeriod.Rows.Count == 0)
            //        throw new Exception("Невозможно получить период, за который необходимо снять показания логгера.");

            //    using (WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm dataLoggerSaveForm = new WMSOffice.Dialogs.ColdChain.DataLoggerSaveForm()
            //    {
            //        UserID = this.UserID,
            //        EquipmentID = equipmentID,
            //        StartTimeStamp = equipmentSensorPeriod[0].Date_From,
            //        EndTimeStamp = equipmentSensorPeriod[0].Date_To
            //    })

            //    if (dataLoggerSaveForm.ShowDialog() == DialogResult.OK)
            //        this.RefreshDocs();
            //}
            //catch (Exception ex)
            //{
            //    this.ShowError(ex);
            //}

            #endregion
        }

        #endregion

        private void DeliveryCloseActsWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.xdgvLines.SaveExtraDataGridViewSettings(this.Name);
        }
    }

    /// <summary>
    /// Представление для грида с актами
    /// </summary>
    public class CloseActsView : IDataView
    {
        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        private PatternColumnsCollection dataColumns = new PatternColumnsCollection();

        /// <summary>
        /// Коллекция отображаемых колонок
        /// </summary>
        public PatternColumnsCollection Columns { get { return dataColumns; } }

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        private DataTable data;

        /// <summary>
        /// Источник данных для представления
        /// </summary>
        public DataTable Data { get { return data; } }

        /// <summary>
        /// Получение источника данных согласно критериям поиска
        /// </summary>
        /// <param name="pSearchParameters">Критерии поиска</param>
        public void FillData(SearchParametersBase pSearchParameters)
        {
            var sp = pSearchParameters as CloseActsViewSearcParameters;
            using (var adapter = new Data.DeliveryTableAdapters.NotClosedActsTableAdapter())
            {
                adapter.SetTimeout((int)TimeSpan.FromMinutes(10).TotalSeconds);

                // основной режим
                if (sp.WorkMode == DeliveryCloseActsWindow.GENERAL_MODE)
                    data = adapter.GetData(sp.SessionID);
                // режим м/с актов
                else if (sp.WorkMode == DeliveryCloseActsWindow.BRANCH_MODE)
                    data = adapter.GetDataByBranch(sp.SessionID, sp.IsArchived);

                else
                    data = null;
            }
        }

        public CloseActsView()
        {
            this.dataColumns.Add(new PatternColumn("Филиал", "Warehouse_name", new FilterPatternExpressionRule("Warehouse_name")) { Width = 350 });
            this.dataColumns.Add(new PatternColumn("Тип документа", "doc_type_name", new FilterPatternExpressionRule("doc_type_name")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ акта", "Doc_ID", new FilterCompareExpressionRule<Int64>("Doc_ID"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("Дата", "Doc_Date", new FilterPatternExpressionRule("Doc_Date")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Ст.", "Status_ID", new FilterCompareExpressionRule<Int32>("Status_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Статус", "Status_Name", new FilterPatternExpressionRule("Status_Name")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("№ заказа", "RelatedPoSoNumber", new FilterCompareExpressionRule<Int64>("RelatedPoSoNumber"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Тип", "RelatedOrderType", new FilterPatternExpressionRule("RelatedOrderType")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Сборочный", "RelatedPickSlipNumber", new FilterCompareExpressionRule<Int64>("RelatedPickSlipNumber"), SummaryCalculationType.Count) { Width = 150 });
                this.dataColumns.Add(new PatternColumn("МЛ", "Route_List_Number", new FilterCompareExpressionRule<Int64>("Route_List_Number"), SummaryCalculationType.Count) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ авто", "Car_Number", new FilterPatternExpressionRule("Car_Number")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Водитель", "DriverName", new FilterPatternExpressionRule("DriverName")) { Width = 350 });
            this.dataColumns.Add(new PatternColumn("Клиент", "ClientName", new FilterPatternExpressionRule("ClientName")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("Адрес", "ClientAddress", new FilterPatternExpressionRule("ClientAddress")) { Width = 400 });
            this.dataColumns.Add(new PatternColumn("№ термобокса", "Equipment_ID", new FilterCompareExpressionRule<Int64>("Equipment_ID"), SummaryCalculationType.Count) { Width = 150 });
            //this.dataColumns.Add(new PatternColumn("ID логгера", "Sensor_ID", new FilterCompareExpressionRule<Int64>("Sensor_ID"), SummaryCalculationType.Count) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("S/N логгера", "Sensor_Serial_Number", new FilterPatternExpressionRule("Sensor_Serial_Number"), SummaryCalculationType.Count) { Width = 150 });
        }
    }

    /// <summary>
    /// Параметры поиска
    /// </summary>
    public class CloseActsViewSearcParameters : SessionIDSearchParameters
    {
        public int WorkMode { get; set; }
        public bool IsArchived { get; set; }
    }
}
