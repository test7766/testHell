using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryControlResourcePlanningForm : DialogForm
    {
        /// <summary>
        /// Время ожидания выполнения запроса
        /// </summary>
        private const int DEFAULT_RESPONSE_TIMEOUT = 300;

        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        public InventoryControlResourcePlanningForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(650, 8);
            this.btnCancel.Location = new Point(740, 8);
            this.btnCancel.Text = "Закрыть";

            this.LoadData();
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            string query = string.Format("EXEC [dbo].[pr_IV_CountEmptyTeam] {0}, {1}", this.UserID, this.InventoryDocID);
            SqlDataAdapter adapter = new SqlDataAdapter(query, new SqlConnection(Properties.Settings.Default.JDE_PROCConnectionString));
            adapter.SelectCommand.CommandTimeout = DEFAULT_RESPONSE_TIMEOUT;
            //adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            bool loadSucceeded = false;
            var dataSet = new DataSet();
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    adapter.Fill(dataSet);
                }
                catch (Exception ex)
                {
                    e.Result = ex;
                }
            };
            loadWorker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e)
            {
                if (e.Result is Exception)
                    MessageBox.Show((e.Result as Exception).Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    loadSucceeded = true;

                waitProcessForm.CloseForce();
            };

            waitProcessForm.ActionText = "Выполняется загрузка статистики..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();

            if (!loadSucceeded)
                return;

            if (dataSet.Tables.Count == 2)
            {
                // Обработка статистики
                DataTable dtStatistics = dataSet.Tables[0];
                this.dgvStatistics.DataSource = dtStatistics;
                CustomizeGrid();

                // Обработка итогов
                DataTable dtTotal = dataSet.Tables[1];
                if (dtTotal.Rows.Count == 0)
                    return;

                if (dtTotal.Rows[0]["Total_hh"] != DBNull.Value)
                    lblTotalHours.Text = Convert.ToDecimal(dtTotal.Rows[0]["Total_hh"]).ToString("N1");

                if (dtTotal.Rows[0]["CountEmptyTeam"] != DBNull.Value)
                    lblCheckEmptyTeams.Text = Convert.ToInt32(dtTotal.Rows[0]["CountEmptyTeam"]).ToString("N0");
            }
        }

        /// <summary>
        /// Оформление таблицы отображения
        /// </summary>
        private void CustomizeGrid()
        {
            if (this.dgvStatistics.Columns.Count == 8)
            {
                this.dgvStatistics.Columns[0].HeaderText = "Тип места";

                this.dgvStatistics.Columns[1].HeaderText = "Мест";
                this.dgvStatistics.Columns[1].DefaultCellStyle.Format = "N0";
                this.dgvStatistics.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[2].HeaderText = "Укомпл. бригад";
                this.dgvStatistics.Columns[2].DefaultCellStyle.Format = "N0";
                this.dgvStatistics.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[3].HeaderText = "Сотрудников";
                this.dgvStatistics.Columns[3].DefaultCellStyle.Format = "N0";
                this.dgvStatistics.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[4].HeaderText = "1-й пересчет, часов";
                this.dgvStatistics.Columns[4].DefaultCellStyle.Format = "N1";
                this.dgvStatistics.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[5].HeaderText = "2-й пересчет, часов";
                this.dgvStatistics.Columns[5].DefaultCellStyle.Format = "N1";
                this.dgvStatistics.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[6].HeaderText = "3-й пересчет, часов";
                this.dgvStatistics.Columns[6].DefaultCellStyle.Format = "N1";
                this.dgvStatistics.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                this.dgvStatistics.Columns[7].HeaderText = "Итого, часов";
                this.dgvStatistics.Columns[7].DefaultCellStyle.Format = "N1";
                this.dgvStatistics.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
    }
}
