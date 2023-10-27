using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Controls.Receive.Pallets;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsFindShipmentForm : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Навправление выезда
        /// </summary>
        public ViewSearchDirectionType DepartureDirection { get; set; }

        /// <summary>
        /// Номер поставки
        /// </summary>
        public int ShipmentID { get { return this.shipmentDeliveryInfoControl.ShipmentID; } }

        /// <summary>
        /// Номер авто
        /// </summary>
        public string CarNumber { get { return this.shipmentDeliveryInfoControl.CarNumber; } }

        /// <summary>
        /// Наименование поставщика
        /// </summary>
        public string VendorName { get { return this.shipmentDeliveryInfoControl.VendorName; } }

        /// <summary>
        /// Признак возможности редактировать данные по въезду/выезду поставки
        /// </summary>
        public bool CanModifyShipmentDeparture { get { return this.shipmentDeliveryInfoControl.CanModifyShipmentDeparture; } }

        /// <summary>
        /// Признак модификации данных поставки
        /// </summary>
        public bool IsShipmentDataChanged { get; private set; }

        /// <summary>
        /// Идентификатор поставки для поиска
        /// </summary>
        private int? searchShipmentID;
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsFindShipmentForm()
        {
            InitializeComponent();
        }

        public PalletsFindShipmentForm(int? searchShipmentID)
            : this()
        {
            this.searchShipmentID = searchShipmentID;
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        public void Initialize()
        {
            this.shipmentDeliveryInfoControl.UserID = this.UserID;
            this.shipmentDeliveryInfoControl.DepartureDirection = this.DepartureDirection;
            this.Text = string.Format("Контроль на {0}", this.DepartureDirection == ViewSearchDirectionType.Entry ? "въезде" : this.DepartureDirection == ViewSearchDirectionType.Outgoing ? "выезде" : string.Empty);
            this.shipmentDeliveryInfoControl.OnShipmentChanged += delegate(object sender, EventArgs e) 
            { 
                this.btnOK.Enabled = this.shipmentDeliveryInfoControl.ShipmentApplied; 
            };

            // Инициализация для поиска
            if (this.searchShipmentID.HasValue)
            {
                this.shipmentDeliveryInfoControl.InitializeShipment(this.searchShipmentID.Value);
                this.SearchShipment();
            }
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchShipment();
        }

        /// <summary>
        /// Поиск информации о поставке
        /// </summary>
        private void SearchShipment()
        {
            this.shipmentDeliveryInfoControl.SearchShipment();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.ApplyShipment())
                this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Фиксация выбранной поставки
        /// </summary>
        /// <returns></returns>
        private bool ApplyShipment()
        {
            try
            {
                // Если номер авто был изменен - сохраним изменения
                if (this.shipmentDeliveryInfoControl.IsCarNumberChanged)
                {
                    using (var adapter = new Data.ReceiveTableAdapters.FindShipmentInfoResponseTableAdapter())
                        adapter.UpdateCarNumber(this.UserID, this.shipmentDeliveryInfoControl.ShipmentID, this.shipmentDeliveryInfoControl.CarNumber);

                    this.IsShipmentDataChanged = true;
                }

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
