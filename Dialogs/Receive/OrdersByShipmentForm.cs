using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Window;

namespace WMSOffice.Dialogs.Receive
{
    public partial class OrdersByShipmentForm : DialogForm
    {
        /// <summary>
        /// Хост
        /// </summary>
        public IHost Host { get; private set; }

        /// <summary>
        /// Поставка
        /// </summary>
        public int ShipmentID { get; private set; }

        /// <summary>
        /// Ошибка
        /// </summary>
        public string ErrorMessage { get; private set; }

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public OrdersByShipmentForm()
        {
            InitializeComponent();
        }

        public OrdersByShipmentForm(IHost host, int shipmentID)
            : this()
        {
            this.Host = host;
            this.ShipmentID = shipmentID;
        }

        public OrdersByShipmentForm(IHost host, int shipmentID, string errorMessage)
            : this(host, shipmentID)
        {
            this.ErrorMessage = errorMessage;
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(517, 8);
            this.btnCancel.Location = new Point(607, 8);

            if (string.IsNullOrEmpty(this.ErrorMessage))
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
            }
            else
            {
                this.btnOK.Text = "Принять";
                this.btnCancel.Text = "Отмена";
            }

            this.Text = string.Format("{0} № {1} {2}", this.Text, this.ShipmentID, this.ErrorMessage);
            this.LoadData();
        }

        private void LoadData()
        {
            BackgroundWorker loadworker = new BackgroundWorker();
            loadworker.DoWork += delegate(object sender, DoWorkEventArgs e)
            {
                try
                {
                    e.Result = this.ordersByShipmentTableAdapter.GetData(this.Host.SessionID, this.ShipmentID);
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
                    this.ordersByShipmentBindingSource.DataSource = e.Result;

                this.Host.WaitProgressForm.CloseForce();
            };

            this.ordersByShipmentBindingSource.DataSource = null;
            this.Host.WaitProgressForm.ActionText = "Выполняется загрузка заказов по поставке..";
            loadworker.RunWorkerAsync();
            this.Host.WaitProgressForm.ShowDialog();
        }

        private void dgvShipmentOrders_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvShipmentOrders.Rows)
                {
                    var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Receive.OrdersByShipmentRow;
                    var color = boundRow.IsColorLnNull() ? Color.White : Color.FromName(boundRow.ColorLn);

                    for (int c = 0; c < row.Cells.Count; c++)
                    {
                        row.Cells[c].Style.BackColor = color;
                        row.Cells[c].Style.SelectionForeColor = color;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
