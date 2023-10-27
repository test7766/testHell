using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class EmptyShipmentCreateForm : DialogForm
    {
        private static bool IsTestVersion { get { return MainForm.IsTestVersion; } }

        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Код сессии пользователя
        /// </summary>
        public new long UserID { get; set; }

        /// <summary>
        /// Код поставщика
        /// </summary>
        public int VendorID { get { return Convert.ToInt32(this.cmbVendors.SelectedValue); } }

        /// <summary>
        /// Дата поставки
        /// </summary>
        public DateTime ShipmentDate { get; set; }

        /// <summary>
        /// Код филиала, с которого создается поставка
        /// </summary>
        public int OriginatorBranchID { get; set; }

        #endregion


        public EmptyShipmentCreateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Text = "Создать поставку";
            this.btnOK.Width = 110;
            this.btnOK.Location = new Point(290, 8);
            this.btnCancel.Location = new Point(410, 8);

            this.LoadVendors();
        }

        /// <summary>
        /// Загрузка списка поставщиков с признаком возвратности тары
        /// </summary>
        private void LoadVendors()
        {
            try
            {
                this.vendorsForReturnBindingSource.DataSource = this.vendorsForReturnTableAdapter.GetData(this.UserID, this.ShipmentDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EmptyShipmentCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CreateEmptyShipment();
        }

        /// <summary>
        /// Создание пустой поставки
        /// </summary>
        /// <returns></returns>
        private bool CreateEmptyShipment()
        {
            try
            {
                if (cmbVendors.SelectedValue == null)
                    throw new Exception("Поставщик не выбран.");

                if (EmptyShipmentCreateForm.IsTestVersion && this.OriginatorBranchID == this.VendorID)
                    throw new Exception("Один и тот же контрагент не может быть\r\nпоставщиком и получателем.");

                var shipmentID = (int?)null;
                using (var adapter = new Data.ReceiveTableAdapters.FreeShipmentsOnDateTableAdapter())
                    adapter.CreateEmptyShipment(this.UserID, this.VendorID, this.ShipmentDate, ref shipmentID, this.OriginatorBranchID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbVendors.Focus();
                return false;
            }
        }
    }
}
