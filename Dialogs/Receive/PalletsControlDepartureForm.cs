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
    public partial class PalletsControlDepartureForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Идентификатор сессии пользователя
        /// </summary>
        public new long UserID { get; set; }
        /// <summary>
        /// Направление выезда
        /// </summary>
        public ViewSearchDirectionType DepartureDirection { get; set; }

        /// <summary>
        /// Признак режима "Начальник охраны"
        /// </summary>
        public bool IsChiefSecurityMode { get; set; }

        /// <summary>
        /// Необходимость повторного пересчета
        /// </summary>
        private bool _NeedRecalculation;
        public bool NeedRecalculation
        {
            get { return _NeedRecalculation; }
            private set
            {
                _NeedRecalculation = value;
                this.pnlWarning.Visible = _NeedRecalculation;
            }
        }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsControlDepartureForm()
        {
            InitializeComponent();
        }

        public PalletsControlDepartureForm(int shipmentID, string carNumber, string vendorName, bool canModifyShipmentDeparture)
            : this()
        {
            this.shipmentDeliveryInfoControl.InitializeShipmentDeliveryInfo(shipmentID, carNumber, vendorName, canModifyShipmentDeparture);
        }

        /// <summary>
        /// Инициализация
        /// </summary>
        private void Initialize()
        {
            this.shipmentDeliveryInfoControl.UserID = this.UserID;
            this.shipmentDeliveryInfoControl.DepartureDirection = this.DepartureDirection;

            // Если данные по поставке нельзя редактировать - запретим возможное сохранение
            if (!this.shipmentDeliveryInfoControl.CanModifyShipmentDeparture)
            {
                this.btnOK.Visible = false;
                this.btnCancel.Text = "Закрыть";
                this.dgvData.ReadOnly = true;
            }

            this.Text = string.Format("Контроль на {0}", this.DepartureDirection == ViewSearchDirectionType.Entry ? "въезде" : this.DepartureDirection == ViewSearchDirectionType.Outgoing ? "выезде" : string.Empty);
            this.lblAction.Text = string.Format("Введите кол-во пустых паллет на {0}:", this.DepartureDirection == ViewSearchDirectionType.Entry ? "въезде" : this.DepartureDirection == ViewSearchDirectionType.Outgoing ? "выезде" : string.Empty);

            this.btnOK.Text = "Сохранить";
            this.btnOK.Location = new Point(215, 8);
            this.btnCancel.Location = new Point(305, 8);

            //this.btnOK.Enabled = false;
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Initialize();
            this.ReloadData(false);
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void ReloadData(bool clearQuantity)
        {
            try
            {
                var direction = ParameterMarkAttribute.GetConvertedMark(this.shipmentDeliveryInfoControl.DepartureDirection);
                this.palletsQuantityByTypeTableAdapter.Fill(this.receive.PalletsQuantityByType, this.UserID, this.shipmentDeliveryInfoControl.ShipmentID, direction.ToString(), clearQuantity);
                this.btnOK.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvData.Columns[e.ColumnIndex].DataPropertyName == this.receive.PalletsQuantityByType.QuantityColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataRow = (this.dgvData.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.PalletsQuantityByTypeRow;

            #region СТИЛЬ ДЛЯ ИТОГОВОЙ СТРОКИ
            if (dataRow.Type_ID == -1)
            {
                e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                this.dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = true;

                if (e.RowIndex > 0)
                    this.dgvData.Rows[e.RowIndex - 1].DividerHeight = 1;
            }
            #endregion
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvData.CurrentCell = this.dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvData.BeginEdit(true);
            }
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            this.RecalculateTotal();
            this.ValidateDataSaving();
        }

        /// <summary>
        /// Пересчет итогового значения
        /// </summary>
        private void RecalculateTotal()
        {
            int? totalQuantity = null;
            foreach (Data.Receive.PalletsQuantityByTypeRow row in this.receive.PalletsQuantityByType)
                if (row.Type_ID != -1 && !row.IsQuantityNull())
                    totalQuantity = (totalQuantity ?? 0) + row.Quantity;

            if (totalQuantity.HasValue)
                this.receive.PalletsQuantityByType[this.receive.PalletsQuantityByType.Count - 1].Quantity = totalQuantity.Value;
            else
                this.receive.PalletsQuantityByType[this.receive.PalletsQuantityByType.Count - 1].SetQuantityNull();
        }

        /// <summary>
        /// Валидация сохранения
        /// </summary>
        private void ValidateDataSaving()
        {
            bool allowSave = true;

            foreach (Data.Receive.PalletsQuantityByTypeRow row in this.receive.PalletsQuantityByType)
                if (row.Type_ID != -1 && row.IsQuantityNull())
                {
                    allowSave = false;
                    break;
                }

            this.btnOK.Enabled = allowSave;
        }

        private void PalletsControlDepartureForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                if (!this.SaveData())
                {
                    e.Cancel = true;
                    this.ReloadData(true);
                }
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {               
                var direction = ParameterMarkAttribute.GetConvertedMark(this.shipmentDeliveryInfoControl.DepartureDirection);
                this.palletsQuantityByTypeTableAdapter.UpdateShipmentDepartureData(
                    this.UserID, 
                    this.shipmentDeliveryInfoControl.ShipmentID, 
                    direction.ToString(), 
                    this.receive.PalletsQuantityByType[0].Quantity, 
                    this.receive.PalletsQuantityByType[1].Quantity, 
                    this.receive.PalletsQuantityByType[2].Quantity, 
                    this.shipmentDeliveryInfoControl.CarNumber, 
                    this.NeedRecalculation);

                new PalletsAllowDepartureNotifyForm(
                       this.shipmentDeliveryInfoControl.ShipmentID,
                       this.shipmentDeliveryInfoControl.CarNumber,
                       this.shipmentDeliveryInfoControl.VendorName,
                       this.shipmentDeliveryInfoControl.CanModifyShipmentDeparture) { Owner = this, DepartureDirection = this.DepartureDirection }.ShowDialog();
                return true;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToUpper().Contains("NEED_RECALC"))
                {
                    new PalletsDenyDepartureNotifyForm(
                        this.shipmentDeliveryInfoControl.ShipmentID,
                        this.shipmentDeliveryInfoControl.CarNumber,
                        this.shipmentDeliveryInfoControl.VendorName,
                       this.shipmentDeliveryInfoControl.CanModifyShipmentDeparture) { Owner = this, DepartureDirection = this.DepartureDirection }.ShowDialog();

                    this.NeedRecalculation = true;
                    this.DiscardCanceling = true; // Для повторного пересчета блокируем отмену операции

                    return false;
                }

                if (ex.Message.ToUpper().Contains("NEED_CEO"))
                {
                    new PalletsDenyDepartureNotifyForm(
                        this.shipmentDeliveryInfoControl.ShipmentID,
                        this.shipmentDeliveryInfoControl.CarNumber,
                        this.shipmentDeliveryInfoControl.VendorName,
                       this.shipmentDeliveryInfoControl.CanModifyShipmentDeparture) { Owner = this, DepartureDirection = this.DepartureDirection, LockDeparture = true }.ShowDialog();
                    return true;
                }

                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
