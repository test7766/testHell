using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class RemainsOfReturns : DialogForm
    {
        /// <summary>
        /// Сплеш-окно, используемое при длительной обработке данных.
        /// </summary>
        private Dialogs.SplashForm waitProcessForm = new WMSOffice.Dialogs.SplashForm();

        /// <summary>
        /// Ид-р полки
        /// </summary>
        private string _locationID = string.Empty;

        /// <summary>
        /// Описание полки
        /// </summary>
        private string _locationDesc = string.Empty;

        /// <summary>
        /// Пустое изображение
        /// </summary>
        private static Bitmap emptyIcon = new Bitmap(16, 16);

        public RemainsOfReturns(string locationID, string locationDesc)
        {
            InitializeComponent();
            dgvcTemperature.DefaultCellStyle.NullValue = null;

            _locationID = locationID;
            _locationDesc = locationDesc;
        }

        private void LoadData()
        {
            BackgroundWorker loadWorker = new BackgroundWorker();
            loadWorker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.returnsRemainsTableAdapter.GetData(this.UserID, _locationID);
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
                    this.returnsRemainsBindingSource.DataSource = e.Result;

                waitProcessForm.CloseForce();
            };

            this.returnsRemainsBindingSource.DataSource = null;
            waitProcessForm.ActionText = "Выполняется загрузка остатков..";
            loadWorker.RunWorkerAsync();
            waitProcessForm.ShowDialog();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(808, 8);
            this.btnCancel.Location = new Point(898, 8);

            this.Text = string.Format("{0} \"{1}\"", this.Text, _locationDesc);

            this.LoadData();
        }

        private void dgvRemains_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in this.dgvRemains.Rows)
            {
                var bindRow = (row.DataBoundItem as DataRowView).Row as Data.Complaints.ReturnsRemainsRow;
                foreach (DataGridViewColumn column in this.dgvRemains.Columns)
                {
                    #region ПОДСТАНОВКА ИКОНОК ПО ХОЛОДОВОМУ ТОВАРУ
                    if (column == dgvcTemperature)
                    {
                        string temperatureSign = bindRow.Temperature;
                        if (temperatureSign == "B")
                            this.dgvRemains.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.snowflakeB;
                        else if (temperatureSign == "R")
                            this.dgvRemains.Rows[row.Index].Cells[column.Index].Value = Properties.Resources.snowflakeR;
                        else
                            this.dgvRemains.Rows[row.Index].Cells[column.Index].Value = emptyIcon;
                    }
                }
                    #endregion
            }
        }
    }
}
