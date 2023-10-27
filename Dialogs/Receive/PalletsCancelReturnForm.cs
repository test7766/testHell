using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class PalletsCancelReturnForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public new long UserID { get; set; }
        /// <summary>
        /// № поставки
        /// </summary>
        public int ShipmentID { get; set; }

        /// <summary>
        /// Признак возможности редактировать данные
        /// </summary>
        public bool CanModify { get; private set; }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public PalletsCancelReturnForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(205, 8);
            this.btnCancel.Location = new Point(305, 8);
            this.btnOK.Width = 90;
            this.btnOK.Text = "Аннулировать";

            if (this.FindShipment())
                this.LoadData();

            if (!this.CanModify)
            {
                this.dgvData.ReadOnly = true;
                //this.btnOK.Visible = false;
                //this.btnCancel.Text = "Закрыть";
            }
        }

        /// <summary>
        /// Поиск поставки
        /// </summary>
        private bool FindShipment()
        {
            try
            {
                using (var adapter = new Data.ReceiveTableAdapters.ShipmentInfoForCancelReturnTableAdapter())
                {
                    var response = adapter.GetData(this.UserID, this.ShipmentID);
                    if (response.Count == 0)
                        throw new NullReferenceException();
                    else
                    {
                        tbShipmentID.Text = this.ShipmentID.ToString();
                        tbVendorName.Text = response[0].VendorName;
                        tbActNumber.Text = response[0].ActNumber.ToString();

                        //this.CanModify = response[0].CanModify;
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Загрузка данных
        /// </summary>
        private void LoadData()
        {
            try
            {
                this.shipmentInputStructureForCancelReturnTableAdapter.Fill(this.receive.ShipmentInputStructureForCancelReturn, this.UserID, ShipmentID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
            {
                this.dgvData.CurrentCell = this.dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex];
                this.dgvData.BeginEdit(true);
            }
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataRow = (this.dgvData.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.ShipmentInputStructureForCancelReturnRow;

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

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvData.Columns[e.ColumnIndex].DataPropertyName == this.receive.ShipmentInputStructureForCancelReturn.QuantityColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            foreach (Data.Receive.ShipmentInputStructureForCancelReturnRow row in this.receive.ShipmentInputStructureForCancelReturn)
                if (row.Type_ID != -1 && !row.IsQuantityNull())
                    totalQuantity = (totalQuantity ?? 0) + row.Quantity;

            if (totalQuantity.HasValue)
                this.receive.ShipmentInputStructureForCancelReturn[this.receive.ShipmentInputStructureForCancelReturn.Count - 1].Quantity = totalQuantity.Value;
            else
                this.receive.ShipmentInputStructureForCancelReturn[this.receive.ShipmentInputStructureForCancelReturn.Count - 1].SetQuantityNull();
        }

        /// <summary>
        /// Валидация сохранения
        /// </summary>
        private void ValidateDataSaving()
        {
            bool allowSave = true;

            foreach (Data.Receive.ShipmentInputStructureForCancelReturnRow row in this.receive.ShipmentInputStructureForCancelReturn)
                if (row.Type_ID != -1 && row.IsQuantityNull())
                {
                    allowSave = false;
                    break;
                }

            this.btnOK.Enabled = allowSave;
        }

        private void PalletsCancelReturnForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveData();
        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        /// <returns></returns>
        private bool SaveData()
        {
            try
            {
                this.shipmentInputStructureForCancelReturnTableAdapter.UpdateData(
                    this.UserID,
                    this.ShipmentID,
                    this.receive.ShipmentInputStructureForCancelReturn[0].Quantity,
                    this.receive.ShipmentInputStructureForCancelReturn[1].Quantity,
                    this.receive.ShipmentInputStructureForCancelReturn[2].Quantity);
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
