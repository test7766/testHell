using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class ItemMeasurementBarCodes : DialogForm
    {
        /// <summary>
        /// Код товара
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        /// Перечень удаленных ш/к
        /// </summary>
        private List<string> DeletedBarCodes = new List<string>();

        /// <summary>
        /// Выбранный ш/к
        /// </summary>
        public String SelectedBarCode { get; private set; }

        public ItemMeasurementBarCodes()
        {
            InitializeComponent();
        }

        private void ItemMeasurementBarCodes_Load(object sender, EventArgs e)
        {
            this.LoadBarCodes();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(78, 8);
            this.btnCancel.Location = new Point(168, 8);

            dgvBarCodes.Focus();
        }

        /// <summary>
        /// Загрузка перечня штрих-кодов
        /// </summary>
        private void LoadBarCodes()
        {
            try
            {
                using (Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter adapter =
                    new WMSOffice.Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter())
                    adapter.Fill(this.itemsMeasurement.ItemMeasurementBarCodes, this.ItemID);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить список штрих-кодов", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Опеределение того, что ш/к товара был удален
        /// </summary>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public bool CheckForDeletedBarCode(String barCode)
        {
            foreach (var bkDeleted in this.DeletedBarCodes)
                if (String.Equals(bkDeleted, barCode))
                    return true;

            return false;
        }

        private void dgvBarCodes_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить данный штрих-код товара?", "Внимание",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var barCodeEntity = (e.Row.DataBoundItem as DataRowView).Row as Data.ItemsMeasurement.ItemMeasurementBarCodesRow;
                int barCodeID = (int)barCodeEntity.ID;
                if (!this.DeleteBarCode(barCodeID))
                    e.Cancel = true;

                this.DeletedBarCodes.Add(barCodeEntity.BarCodes);
                return;
            }
         
            e.Cancel = true;
        }

        /// <summary>
        /// Удаление штрих-кода товара по ид-ру
        /// </summary>
        /// <param name="barCodeID"></param>
        /// <returns></returns>
        private bool DeleteBarCode(int barCodeID)
        {
            try
            {
                using (Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter adapter =
                    new WMSOffice.Data.ItemsMeasurementTableAdapters.ItemMeasurementBarCodesTableAdapter())
                    adapter.DeleteBarCode(this.UserID, barCodeID);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка во время удаления штрих-кода", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void dgvBarCodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
                this.DialogResult = DialogResult.OK;
        }

        private void ItemMeasurementBarCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK && dgvBarCodes.SelectedRows.Count == 1)
                this.SelectedBarCode = ((dgvBarCodes.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.ItemsMeasurement.ItemMeasurementBarCodesRow).BarCodes;
        }
    }
}
