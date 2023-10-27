using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class DeliveryRegistrationOnRouteForm : DialogForm
    {
        /// <summary>
        /// Код водителя
        /// </summary>
        public int? ForwarderID { get; set; }

        /// <summary>
        /// Имя водителя
        /// </summary>
        public string ForwarderName { get; set; }

        private Data.Delivery.DriverRouteNumbersRow selectedRoute
        {
            get
            {
                if (cmbActiveRoutes.SelectedItem == null)
                    return null;
                else
                    return (cmbActiveRoutes.SelectedItem as DataRowView).Row as Data.Delivery.DriverRouteNumbersRow;
            }
        }

        public DeliveryRegistrationOnRouteForm()
        {
            InitializeComponent();
        }

        private void DeliveryRegistrationOnRouteForm_Load(object sender, EventArgs e)
        {
            LoadActiveRoutes();
        }

        private void LoadActiveRoutes()
        {
            try
            {
                driverRouteNumbersTableAdapter.Fill(delivery.DriverRouteNumbers, this.ForwarderID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(455, 8);
            this.btnCancel.Location = new Point(545, 8);

            this.Text = string.Format("{0} [Водитель: {1}]", this.Text, this.ForwarderName);

            stbLogger28.UseScanModeOnly = true;
            stbTermoBox28.UseScanModeOnly = true;
            stbLogger815.UseScanModeOnly = true;
            stbTermoBox815.UseScanModeOnly = true;

            stbLogger28.Enter += new EventHandler(stbControl_Enter);
            stbTermoBox28.Enter += new EventHandler(stbControl_Enter);
            stbLogger815.Enter += new EventHandler(stbControl_Enter);
            stbTermoBox815.Enter += new EventHandler(stbControl_Enter);

            stbLogger28.TextChanged += new EventHandler(stbLogger_TextChanged);
            stbTermoBox28.TextChanged += new EventHandler(stbTermoBox_TextChanged);
            stbLogger815.TextChanged += new EventHandler(stbLogger_TextChanged);
            stbTermoBox815.TextChanged += new EventHandler(stbTermoBox_TextChanged);

            if (selectedRoute != null)
                ShowNotification();

            cmbActiveRoutes.SelectedIndexChanged += new EventHandler(cmbActiveRoutes_SelectedIndexChanged);
        }

        private void ShowNotification()
        {
            if (cmbActiveRoutes.SelectedValue.Equals(cmbActiveRoutes.Tag))
                return;

            cmbActiveRoutes.Tag = cmbActiveRoutes.SelectedValue;

            stbLogger28.Text = string.Empty;
            stbTermoBox28.Text = string.Empty;
            stbLogger815.Text = string.Empty;
            stbTermoBox815.Text = string.Empty;

            var docCount28 = selectedRoute.Isr2_doc_countNull() ? (int?)null : selectedRoute.r2_doc_count;
            var docCount815 = selectedRoute.Isr8_doc_countNull() ? (int?)null : selectedRoute.r8_doc_count;

            var docCountExists28 = docCount28.HasValue && docCount28.Value > 0;
            var docCountExists815 = docCount815.HasValue && docCount815.Value > 0;

            if (docCountExists28 || docCountExists815)
            {
                var sbMessage = new StringBuilder();

                if (docCountExists28)
                    sbMessage.AppendFormat("Количество документов типа 2-8: {0}\r\n", docCount28.Value);

                if (docCountExists815)
                    sbMessage.AppendFormat("Количество документов типа 8-15: {0}\r\n", docCount815.Value);

                MessageBox.Show(sbMessage.ToString(), "Внимание: заберите коробки", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.SelectNextControl(cmbActiveRoutes, true, true, true, false);
        }

        void cmbActiveRoutes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowNotification();
        }

        void stbControl_Enter(object sender, EventArgs e)
        {
            (sender as TextBoxScaner).SelectAll();
        }

        void stbLogger_TextChanged(object sender, EventArgs e)
        {
            var logger = sender as TextBoxScaner;
            if (string.IsNullOrEmpty(logger.Text))
                return;

            try
            {
                var barCode = logger.Text;
                var docType = logger.Tag.ToString();
                driverRouteNumbersTableAdapter.CheckLogger(barCode, this.ForwarderID, docType); 

                this.SelectNextControl(sender as Control, true, true, true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logger.Text = string.Empty;
                logger.Focus();
            }
        }

        void stbTermoBox_TextChanged(object sender, EventArgs e)
        {
            var termoBox = sender as TextBoxScaner;
            if (string.IsNullOrEmpty(termoBox.Text))
                return;

            try
            {
                var barCode = termoBox.Text;
                var docType = termoBox.Tag.ToString();

                if (selectedRoute == null)
                    throw new Exception("Не выбран активный маршрут.");

                var routeNumber = selectedRoute.route_number;

                driverRouteNumbersTableAdapter.CheckEquipment(barCode, this.ForwarderID, docType, routeNumber);

                this.SelectNextControl(sender as Control, true, true, true, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                termoBox.Text = string.Empty;
                termoBox.Focus();
            }
        }

        private void DeliveryRegistrationOnRouteForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveChanges();
        }

        private bool SaveChanges()
        {
            try
            {
                if (selectedRoute == null)
                    throw new Exception("Не выбран активный маршрут.");

                var routeNumber = selectedRoute.route_number;

                var sensor28bc = string.IsNullOrEmpty(stbLogger28.Text) ? (string)null : stbLogger28.Text;
                var equipment28bc = string.IsNullOrEmpty(stbTermoBox28.Text) ? (string)null : stbTermoBox28.Text;
                var sensor815bc = string.IsNullOrEmpty(stbLogger815.Text) ? (string)null : stbLogger815.Text;
                var equipment815bc = string.IsNullOrEmpty(stbTermoBox815.Text) ? (string)null : stbTermoBox815.Text;

                driverRouteNumbersTableAdapter.RegisterDriverOnRoute(this.UserID, this.ForwarderID, routeNumber, sensor28bc, sensor815bc, equipment28bc, equipment815bc);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
