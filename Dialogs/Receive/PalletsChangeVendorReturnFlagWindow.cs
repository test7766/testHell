using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;
using WMSOffice.Controls.ExtraDataGridViewComponents;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsChangeVendorReturnFlagWindow : GeneralWindow
    {
        #region ПОЛЯ И СВОЙСТВА КЛАССА
        /// <summary>
        /// Окно ожидания, которое отображается при длительных операциях
        /// </summary>
        private SplashForm waitProgressForm = new SplashForm();

        /// <summary>
        /// Операция архивации
        /// </summary>
        private ToolStripButton sbDelete = null;

        /// <summary>
        /// Заголовок контекстного меню
        /// </summary>
        private ToolStripLabel lblOPerationsCaption = null;
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsChangeVendorReturnFlagWindow()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, "Изменение признака возвратности");

            this.PrepareGrid();
            this.ReloadData();
        }

        /// <summary>
        /// Подготовка отображения
        /// </summary>
        private void PrepareGrid()
        {
            this.xdgvData.SetSameStyleForAlternativeRows();
            this.xdgvData.AllowSummary = false;
            this.xdgvData.AllowRangeColumns = false;
            this.xdgvData.UserID = this.UserID;
            this.xdgvData.Init(new PalletsChangeVendorReturnFlagView(), true);
            xdgvData.OnFilterChanged += new EventHandler(xdgvData_OnFilterChanged);
            xdgvData.OnFormattingCell += new DataGridViewCellFormattingEventHandler(xdgvData_OnFormattingCell);
            xdgvData.OnRowDoubleClick += new DataGridViewCellEventHandler(xdgvData_OnRowDoubleClick);
            xdgvData.OnRowSelectionChanged += new EventHandler(xdgvData_OnRowSelectionChanged);
        }

        void xdgvData_OnRowSelectionChanged(object sender, EventArgs e)
        {
            bool isAccessible = this.xdgvData.SelectedItem != null;
            isAccessible = isAccessible && Convert.ToBoolean(this.xdgvData.SelectedItem["Active"]);

            sbAddToArchive.Enabled = isAccessible;
        }

        void xdgvData_OnFilterChanged(object sender, EventArgs e)
        {
            this.xdgvData.RecalculateSummary();
        }

        void xdgvData_OnFormattingCell(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var grid = sender as DataGridView;

            #region СТИЛЬ ДЛЯ ПОКРАСКИ ЗАПИСЕЙ В ЗАВИСИМОСТИ ОТ СТАТУСА
            var dataRow = (grid.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;

            bool isActive = Convert.ToBoolean(dataRow["Active"]);
            int r = Convert.ToInt16(dataRow["R"]);
            int g = Convert.ToInt16(dataRow["G"]);
            int b = Convert.ToInt16(dataRow["B"]);
            Color rowColor = Color.FromArgb(r, g, b);

            e.CellStyle.BackColor = rowColor;
            e.CellStyle.SelectionForeColor = rowColor;

            if (!isActive)
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Strikeout);

            #endregion

            #region ВЫРАВНИВАНИЕ ПО ЦЕНТРУ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "Vendor_ID" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "StartDate" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "EndDate" ||
                grid.Columns[e.ColumnIndex].DataPropertyName == "WriteOffMode")
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            #endregion

            #region ФОРМАТИРОВАНЫЙ ВЫВОД ПРИЗНАКА СПИСАНИЯ
            if (grid.Columns[e.ColumnIndex].DataPropertyName == "WriteOffMode")
            {
                var value = grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                var formattedValue = value.Equals(DBNull.Value) || value.Equals(false) ? string.Empty : "Да";
                e.Value = formattedValue;
            }
            #endregion
        }

        void xdgvData_OnRowDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            if (xdgvData.SelectedItem != null)
                this.ShowVendorReturnFlagEditor(false);
        }

        /// <summary>
        /// Добавить признак возвратности
        /// </summary>
        private void sbAdd_Click(object sender, EventArgs e)
        {
            this.ShowVendorReturnFlagEditor(true);
        }

        private void sbAddToArchive_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.ShowVendorReturnFlagEditor(null);
        }

        /// <summary>
        /// Отображение редактора признака возвратности
        /// </summary>
        /// <param name="createData">true - создание, false - модификация, null - архивация</param>
        private void ShowVendorReturnFlagEditor(bool? createData)
        {
            var dlgEditor = new PalletsChangeVendorReturnFlagForm() { UserID = this.UserID, DeleteData = !createData.HasValue, Owner = this };
            if (!(dlgEditor.CreateData = createData.HasValue ? createData.Value : false))
            {
                int vendorID = Convert.ToInt32(this.xdgvData.SelectedItem["Vendor_ID"]);
                DateTime dateFrom = Convert.ToDateTime(this.xdgvData.SelectedItem["StartDate"]);
                DateTime dateTo = Convert.ToDateTime(this.xdgvData.SelectedItem["EndDate"]);
                string agreeNum = this.xdgvData.SelectedItem["AgreeNum"].ToString();
                string agreeSubNum = this.xdgvData.SelectedItem["AgreeSubNum"].ToString();
                bool writeOffMode = createData.HasValue ? Convert.ToBoolean(this.xdgvData.SelectedItem["WriteOffMode"]) : false;
                bool isActive = createData.HasValue ? Convert.ToBoolean(this.xdgvData.SelectedItem["Active"]) : false;

                dlgEditor.Initialize(vendorID, dateFrom, dateTo, agreeNum, agreeSubNum, writeOffMode, isActive);
            }

            bool success = false; // признак успешного завершения операции
            if (createData.HasValue)
            { // модификация либо создание
                if (dlgEditor.ShowDialog() == DialogResult.OK)
                    success = true;
            }
            else
            { // архивация
                if (dlgEditor.SaveData())
                    success = true;
            }

            // Если операция завершена успешно, то обновим данные
            if (success)
                this.ReloadData();
        }

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.ReloadData();
        }

        /// <summary>
        /// Фоновое обновление данных
        /// </summary>
        private void ReloadData()
        {
            // Формирование критерия поиска
            var searchCriteria = new PalletsChangeVendorReturnFlagSearchParameters();
            searchCriteria.UserID = this.UserID;

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
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }

    /// <summary>
    /// Представление
    /// </summary>
    public class PalletsChangeVendorReturnFlagView : IDataView
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
            var searchCriteria = searchParameters as PalletsChangeVendorReturnFlagSearchParameters;
            using (SqlDataAdapter adapter = new SqlDataAdapter("[dbo].[pr_UP_GetVendorsAccounts]", new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString)))
            {
                var command = adapter.SelectCommand;
                command.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Session_ID", SqlDbType.BigInt) { Value = searchCriteria.UserID });

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
                this.data = dataSet.Tables[0];
            }
        }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsChangeVendorReturnFlagView()
        {
            this.dataColumns.Add(new PatternColumn("Код пост.", "Vendor_ID", new FilterCompareExpressionRule<Int32>("Vendor_ID")) { Width = 60 });
            this.dataColumns.Add(new PatternColumn("Поставщик", "VendorName", new FilterPatternExpressionRule("VendorName")) { Width = 270 });
            this.dataColumns.Add(new PatternColumn("Дата \"с\"", "StartDate", new FilterDateCompareExpressionRule("StartDate")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("Дата \"по\"", "EndDate", new FilterDateCompareExpressionRule("EndDate")) { Width = 90 });
            this.dataColumns.Add(new PatternColumn("№ Договора/ допсоглашения", "AgreeNum", new FilterPatternExpressionRule("AgreeNum")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Пункт договора/ допсоглашения", "AgreeSubNum", new FilterPatternExpressionRule("AgreeSubNum")) { Width = 120 });
            this.dataColumns.Add(new PatternColumn("Списание", "WriteOffMode") { Width = 80 });
            this.dataColumns.Add(new PatternColumn("Автор операции", "UserName", new FilterPatternExpressionRule("UserName")) { Width = 200 });
            this.dataColumns.Add(new PatternColumn("Время операции", "DateUpdated") { Width = 120 });
        }
        #endregion
    }

     /// <summary>
    /// Критерий поиска
    /// </summary>
    public class PalletsChangeVendorReturnFlagSearchParameters : SearchParametersBase
    {
        public long UserID { get; set; }
    }
}
