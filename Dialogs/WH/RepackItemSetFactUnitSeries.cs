using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemSetFactUnitSeries : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Код сессии
        /// </summary>
        public long UserID { get; set; }

        /// <summary>
        /// Код товара
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Склад
        /// </summary>
        public string WarehouseID { get; set; }

        /// <summary>
        /// Фактическая серия
        /// </summary>
        public string VendorLot_Fact { get; private set; }

        #endregion

        #region КОНСТРУКТОРЫ И ИНИЦИАЛИЗАЦИЯ

        public RepackItemSetFactUnitSeries()
        {
            InitializeComponent();
        }

        private void SetFactUnitSeries_Load(object sender, EventArgs e)
        {
            this.LoadVendorLots();
        }

        /// <summary>
        /// Загрузка серий по товару
        /// </summary>
        private void LoadVendorLots()
        {
            try
            {
                this.repackItemVendorLotFactTableAdapter.Fill(this.wH.RepackItemVendorLotFact, this.UserID, this.ItemID, this.WarehouseID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            if (dgvData.Rows.Count > 0)
                dgvData.Rows[0].Selected = false;
        }

        #endregion

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(sender as Control, true, true, true, true);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Right && dgvData.SelectedRows.Count == 0)
            {
                dgvData.Rows[0].Selected = true;
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter && dgvData.SelectedRows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
            }
        }

        private void dgvData_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count == 0)
            {
                tbVendorLotFact.Text = string.Empty;
            }
            else
            {
                var row = (dgvData.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.RepackItemVendorLotFactRow;
                tbVendorLotFact.Text = row.IsVendorLotFactNull() ? string.Empty : row.VendorLotFact;
            }
        }

        private void SetFactUnitSeries_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ValidateChanges();
        }

        /// <summary>
        /// Валидация изменений
        /// </summary>
        /// <returns></returns>
        private bool ValidateChanges()
        {
            try
            {
                if (tbVendorLotFact.Text.Trim() == string.Empty)
                    throw new Exception("Фактическая серия не выбрана.");

                this.VendorLot_Fact = tbVendorLotFact.Text.Trim();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbVendorLotFact.Focus();
                return false;
            }
        }
    }
}
