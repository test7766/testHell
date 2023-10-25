using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs;
using WMSOffice.Dialogs.Receive;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Window
{
    public partial class PalletsAccountingControlWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        /// <summary>
        /// Период "с"
        /// </summary>
        public DateTime PeriodFrom { get; private set; }

        /// <summary>
        /// Период "по"
        /// </summary>
        public DateTime PeriodTo { get; private set; }

        /// <summary>
        ///  Опция корректировки возврата
        /// </summary>
        private ToolStripButton btnCorrectPalletsReturns = null;
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsAccountingControlWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        public void Initialize()
        {
            this.PeriodFrom = this.PeriodTo = DateTime.Today.Date;

            // Фильтры для диапазона дат
            var dtPeriodFromFilter = new DateTimePicker();
            var dtPeriodToFilter = new DateTimePicker();

            #region Добавление компонента фильтра по началу отрезка дат
            tsMainMenu.Items.Add(new ToolStripLabel("  с "));

            dtPeriodFromFilter.Width = 120;
            dtPeriodFromFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodFromFilter.CustomFormat = "dd / MM / yyyy";
            dtPeriodFromFilter.ValueChanged += delegate(object sender, EventArgs e)
            {
                this.PeriodFrom = dtPeriodFromFilter.Value.Date;
                //dtPeriodToFilter.Value = this.PeriodFrom;
            };

            tsMainMenu.Items.Add(new ToolStripControlHost(dtPeriodFromFilter));
            #endregion

            #region Добавление компонента фильтра по концу отрезка дат
            tsMainMenu.Items.Add(new ToolStripLabel("  по "));

            dtPeriodToFilter.Width = 120;
            dtPeriodToFilter.Format = DateTimePickerFormat.Custom;
            dtPeriodToFilter.CustomFormat = "dd / MM / yyyy";
            dtPeriodToFilter.ValueChanged += delegate(object sender, EventArgs e)
            {
                this.PeriodTo = dtPeriodToFilter.Value.Date;
            };

            tsMainMenu.Items.Add(new ToolStripControlHost(dtPeriodToFilter));
            #endregion

            #region Добавление опций для роли "Начальник приемного отдела"
            // анализ роли
            if (this.AllowCloseActs())
            {
                #region Добавление опции закрытия актов
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
                tsMainMenu.Items.Add(new ToolStripSeparator());
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

                tsMainMenu.Items.Add(new ToolStripButton("Прием актов", Properties.Resources.assign,
                    delegate(object sender, EventArgs e)
                    {
                        this.CloseActs();
                    }));
                #endregion

                #region Добавление опции корректировки возврата
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));
                tsMainMenu.Items.Add(new ToolStripSeparator());
                tsMainMenu.Items.Add(new ToolStripLabel(string.Empty.PadLeft(1, ' ')));

                tsMainMenu.Items.Add(this.btnCorrectPalletsReturns = new ToolStripButton("Корректировка\nвозврата", Properties.Resources.edit_document,
                    delegate(object sender, EventArgs e)
                    {
                        this.CorrectPalletsReturns();
                    }));
                #endregion
            }
            #endregion
        }

        /// <summary>
        /// Анализ возможности закрывать акты
        /// </summary>
        /// <returns></returns>
        private bool AllowCloseActs()
        {
            try
            {
                bool canChangeFlag = false;
                using (var adapter = new Data.ReceiveTableAdapters.ChangeStatusSignResponseForPalletsActTableAdapter())
                    canChangeFlag = adapter.GetData(this.UserID)[0].CanChangeFlag;

                this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, canChangeFlag ? "Начальник приемного отдела" : "Диспетчер оперативного планирования");
                return canChangeFlag;
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
                return false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
            this.PrepareGrid();
            this.RefreshData();
        }
        #endregion

        /// <summary>
        /// Подготовка грида к использованию, привязка отображения
        /// </summary>
        private void PrepareGrid()
        {
            this.xdgvData.SetSameStyleForAlternativeRows();
            this.xdgvData.AllowSummary = false;
            this.xdgvData.AllowRangeColumns = false;
            this.xdgvData.UserID = this.UserID;
            this.xdgvData.Init(new PalletsActsView(), true);
            xdgvData.OnFilterChanged += new EventHandler(xdgvData_OnFilterChanged);
            xdgvData.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvData_OnFormattingCell);
            xdgvData.OnRowSelectionChanged += new EventHandler(xdgvData_OnRowSelectionChanged);
        }

        void xdgvData_OnRowSelectionChanged(object sender, EventArgs e)
        {
            bool isEnabled = xdgvData.SelectedItem != null;

            if (this.btnCorrectPalletsReturns != null)
                this.btnCorrectPalletsReturns.Enabled = isEnabled && Convert.ToBoolean(this.xdgvData.SelectedItem["NeedCorrections"]);
        }

        void xdgvData_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvData.RecalculateSummary();
        } 
        
        void xdgvData_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            DataRow row = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            Color markColor = row["ActStatusID"] != DBNull.Value && Convert.ToInt16(row["ActStatusID"]) == 90 // '90' - акт принят
                ? Color.FromArgb(209, 255, 117)
                : Convert.ToDateTime(row["Period"]).Date == DateTime.Today.Date
                    ? Color.FromArgb(255, 255, 153)
                    : Color.FromArgb(255, 225, 225);

            if (grid.Columns[e.ColumnIndex].DataPropertyName == "ActStatus")
            {
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = markColor;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = SystemColors.ControlText;
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionBackColor = markColor;
            }

            //if (grid.Columns[e.ColumnIndex].DataPropertyName == "ActNumber")
            //{
            //    grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        /// <summary>
        /// Фоновое обновление данных
        /// </summary>
        private void RefreshData()
        {
            // Валидация диапазона дат в фильтре
            if (this.PeriodFrom > this.PeriodTo)
            {
                MessageBox.Show("Начальный период не должен превышать конечный!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формирование критерия поиска
            var searchCriteria = new PalletsActsSearchParameters();
            searchCriteria.UserID = this.UserID;
            searchCriteria.PeriodFrom = this.PeriodFrom;
            searchCriteria.PeriodTo = this.PeriodTo;

            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    this.xdgvData.DataView.FillData(searchCriteria);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadworker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    this.ShowError(e.Result as Exception);
                else
                {
                    this.xdgvData.BindData(false);
                    this.xdgvData.AllowSummary = true;
                }

                waitProgressForm.CloseForce();
            };

            waitProgressForm.ActionText = "Выполняется загрузка данных..";
            loadworker.RunWorkerAsync();
            waitProgressForm.ShowDialog();
        }

        /// <summary>
        /// Прием актов
        /// </summary>
        private void CloseActs()
        {
            using (var dlgCloseActs = new PalletsAccountingControlCloseActsForm() { Owner = this, UserID = this.UserID })
                dlgCloseActs.ShowDialog();

            this.RefreshData();
        }

        /// <summary>
        /// Корректировка возврата
        /// </summary>
        private void CorrectPalletsReturns()
        {
            string vendorName = this.xdgvData.SelectedItem["VendorName"].ToString().Trim();
            int actNumber = Convert.ToInt32(this.xdgvData.SelectedItem["ActNumber"]);
            int shipmentID = Convert.ToInt32(this.xdgvData.SelectedItem["ShipmentID"]);
            bool allowCorrectPalletsQuantityForReturn = Convert.ToInt16(this.xdgvData.SelectedItem["ActStatusID"]) == 10; // Вносить коррективы можно только на статусе "Не сдан"

            using (var dlgCorrectPalletsReturns = new CorrectDataForPalletsReturnsForm(vendorName, actNumber, shipmentID, allowCorrectPalletsQuantityForReturn) { UserID = this.UserID })
                if (dlgCorrectPalletsReturns.ShowDialog() == DialogResult.OK)
                    this.RefreshData();
        }
    }

    /// <summary>
    /// Отображение для актов
    /// </summary>
    public class PalletsActsView : IDataView
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

        public void FillData(SearchParametersBase searchParameters)
        {
            var searchCriteria = searchParameters as PalletsActsSearchParameters;
            using (SqlDataAdapter adapter = new SqlDataAdapter("[dbo].[pr_PL_GetPalletsAccountingActs]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString)))
            {
                var command = adapter.SelectCommand;
                command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.BigInt) { Value = searchCriteria.UserID });
                command.Parameters.Add(new SqlParameter("@PeriodFrom", SqlDbType.DateTime) { Value = searchCriteria.PeriodFrom });
                command.Parameters.Add(new SqlParameter("@PeriodTo", SqlDbType.DateTime) { Value = searchCriteria.PeriodTo });

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                this.data = dataSet.Tables[0];
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsActsView()
        {
            this.dataColumns.Add(new PatternColumn("Дата", "Period", new FilterDateCompareExpressionRule("Period")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("№ поставки", "ShipmentID", new FilterCompareExpressionRule<Int32>("ShipmentID")) { Width = 70 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "VendorName", new FilterPatternExpressionRule("VendorName")) { Width = 300 });
            this.dataColumns.Add(new PatternColumn("Тип акта приема-передачи тары", "ActTypeName", new FilterPatternExpressionRule("ActTypeName")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("№ служебной записки", "DeliveryNote", new FilterPatternExpressionRule("DeliveryNote")) { Width = 100 });
            this.dataColumns.Add(new PatternColumn("№ акта", "ActNumber", new FilterCompareExpressionRule<Int32>("ActNumber"), SummaryCalculationType.Count) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Статус", "ActStatus", new FilterPatternExpressionRule("ActStatus")) { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Паллет в акте", "PalletsQty", SummaryCalculationType.Sum) { Width = 70, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Корректировка", "CorrectQty", new FilterCompareExpressionRule<Int32>("CorrectQty")) { Width = 90, UseIntegerNumbersAlignment = true });
            this.dataColumns.Add(new PatternColumn("Для корректировки", "NeedCorrectionsText", new FilterPatternExpressionRule("NeedCorrectionsText")) { Width = 100 });

            this.dataColumns.Add(new PatternColumn("Код отправителя/получателя", "ShipToCode", new FilterCompareExpressionRule<Int32>("ShipToCode")) { Width = 150 });
            this.dataColumns.Add(new PatternColumn("Отправитель/Получатель", "ShipToName", new FilterPatternExpressionRule("ShipToName")) { Width = 250 });

            this.dataColumns.Add(new PatternColumn("Автор операции", "ResponsiblePerson", new FilterPatternExpressionRule("ResponsiblePerson")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Время операции", "OperationEventDate", new FilterPatternExpressionRule("OperationEventDate")) { Width = 100 });
        }
        #endregion
    }

    /// <summary>
    /// Критерий поиска актов
    /// </summary>
    public class PalletsActsSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
    }
}
