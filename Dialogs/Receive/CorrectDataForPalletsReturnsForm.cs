using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class CorrectDataForPalletsReturnsForm : DialogForm
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ
        /// <summary>
        /// Наименование поставщика
        /// </summary>
        public string VendorName { get; private set; }

        /// <summary>
        /// Номер акта
        /// </summary>
        public int ActNumber { get; private set; }

        /// <summary>
        /// Номер поставки
        /// </summary>
        public int ShipmentID { get; private set; }

        /// <summary>
        /// Признак возможности корректировки возврата
        /// </summary>
        public bool AllowCorrectPalletsQuantityForReturn { get; private set; }
        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ
        public CorrectDataForPalletsReturnsForm()
        {
            InitializeComponent();
        }

        public CorrectDataForPalletsReturnsForm(string vendorName, int actNumber, int shipmentID, bool allowCorrectPalletsQuantityForReturn)
            : this()
        {
            this.VendorName = vendorName;
            this.ActNumber = actNumber;
            this.ShipmentID = shipmentID;
            this.AllowCorrectPalletsQuantityForReturn = allowCorrectPalletsQuantityForReturn;
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Text = "Сохранить";
            this.btnOK.Location = new Point(295, 8);
            this.btnCancel.Location = new Point(385, 8);

            this.lblCaption.Text = string.Format("Отказ при возврате паллет поставщику \"{0}\" по акту №{1}:", this.VendorName, this.ActNumber);
            this.btnOK.Visible = this.AllowCorrectPalletsQuantityForReturn;
            this.dgvData.ReadOnly = !this.AllowCorrectPalletsQuantityForReturn;
            if (!this.AllowCorrectPalletsQuantityForReturn)
                this.btnCancel.Text = "Закрыть";

            this.ReloadData(false);
        }

        /// <summary>
        /// Загрузка данных по корректировкам
        /// </summary>
        /// <param name="analizeRefuse">Признак наличия анализа вводимых корректировок отказа по возвратам</param>
        private void ReloadData(bool analizeRefuse)
        {
            try
            {
                int? qSPallet = analizeRefuse && !this.receive.PalletsRefuseData[0].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[0].RefuseQuantity : (int?)null;
                int? qEPallet = analizeRefuse && !this.receive.PalletsRefuseData[1].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[1].RefuseQuantity : (int?)null;
                int? qPPallet = analizeRefuse && !this.receive.PalletsRefuseData[2].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[2].RefuseQuantity : (int?)null;

                string sSDescription = analizeRefuse && !this.receive.PalletsRefuseData[0].IsDescriptionNull() ? this.receive.PalletsRefuseData[0].Description : (string)null;
                string sEDescription = analizeRefuse && !this.receive.PalletsRefuseData[1].IsDescriptionNull() ? this.receive.PalletsRefuseData[1].Description : (string)null;
                string sPDescription = analizeRefuse && !this.receive.PalletsRefuseData[2].IsDescriptionNull() ? this.receive.PalletsRefuseData[2].Description : (string)null;

                this.palletsRefuseDataTableAdapter.Fill(this.receive.PalletsRefuseData, this.UserID, this.ShipmentID, qSPallet, qEPallet, qPPallet, sSDescription, sEDescription, sPDescription);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            int totalRefuseQty = 0;

            // Расчет общего кол-ва паллет в отказе
            foreach (DataGridViewRow row in this.dgvData.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Receive.PalletsRefuseDataRow;
                totalRefuseQty += boundRow.IsRefuseQuantityNull() ? 0 : boundRow.RefuseQuantity;
            }

            this.tbTotalRefuseQty.Text = totalRefuseQty.ToString();
        }

        private void dgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            try
            {
                // Перечитываем данные
                this.ReloadData(true);
                this.ValidateDataSaving();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ValidateDataSaving()
        {
            bool allowSave = true;

            foreach (Data.Receive.PalletsRefuseDataRow row in this.receive.PalletsRefuseData)
                if (row.Type_ID != -1 && !row.IsERROR_IDNull() && row.ERROR_ID)
                {
                    allowSave = false;
                    break;
                }

            this.btnOK.Enabled = allowSave;
        }

        private void dgvData_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var row = (dgvData.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Receive.PalletsRefuseDataRow;
            Color color = row.IsERROR_IDNull() || !row.ERROR_ID ? Color.FromArgb(209, 255, 117) : Color.Salmon;

            if (dgvData.Columns[e.ColumnIndex].DataPropertyName == this.receive.PalletsRefuseData.RefuseQuantityColumn.Caption)
            {
                dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
                dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
            }
        }

        private void dgvData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Context == (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit) && e.Exception != null)
            {
                if (this.dgvData.Columns[e.ColumnIndex].DataPropertyName == this.receive.PalletsRefuseData.RefuseQuantityColumn.Caption)
                {
                    MessageBox.Show("Количество должно быть целым числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CorrectDataForPalletsReturnsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.SaveRefuseData();
        }

        /// <summary>
        /// Сохранение отказа
        /// </summary>
        /// <returns></returns>
        private bool SaveRefuseData()
        {
            try
            {
                int? qSPallet = !this.receive.PalletsRefuseData[0].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[0].RefuseQuantity : (int?)null;
                int? qEPallet = !this.receive.PalletsRefuseData[1].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[1].RefuseQuantity : (int?)null;
                int? qPPallet = !this.receive.PalletsRefuseData[2].IsRefuseQuantityNull() ? this.receive.PalletsRefuseData[2].RefuseQuantity : (int?)null;

                string reasonSPallet = !this.receive.PalletsRefuseData[0].IsDescriptionNull() ? this.receive.PalletsRefuseData[0].Description : (string)null;
                string reasonEPallet = !this.receive.PalletsRefuseData[1].IsDescriptionNull() ? this.receive.PalletsRefuseData[1].Description : (string)null;
                string reasonPPallet = !this.receive.PalletsRefuseData[2].IsDescriptionNull() ? this.receive.PalletsRefuseData[2].Description : (string)null;

                this.palletsRefuseDataTableAdapter.SaveRefuseData(this.UserID, this.ShipmentID, this.ActNumber, 
                    qSPallet, qEPallet, qPPallet, 
                    reasonSPallet, reasonEPallet, reasonPPallet);

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
