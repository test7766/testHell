using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH
{
    public partial class RepackItemSetFactUnits : Form
    {
        #region ПОЛЯ И СВОЙСТВА ДАННЫХ

        /// <summary>
        /// Код сессии
        /// </summary>
        public long UserID { get; set; }

        public int ItemID_Fact { get; private set; }

        #endregion

        #region КОНСТРУКЦИЯ И ИНИЦИАЛИЗАЦИЯ

        public RepackItemSetFactUnits()
        {
            InitializeComponent();
        }

        private void RepackItemSetFactUnits_Load(object sender, EventArgs e)
        {
            this.LoadItems();
        }

        /// <summary>
        /// Загрузка товаров
        /// </summary>
        private void LoadItems()
        {
            try
            {
                this.repackItemItemsFactTableAdapter.Fill(this.wH.RepackItemItemsFact, this.UserID);
                this.SetFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        private void tbFilter_TextChanged(object sender, EventArgs e)
        {
            this.SetFilter();
        }

        private void SetFilter()
        {
            string filter = null;

            try
            {
                var pattern = tbFilter.Text;

                if (tbFilter.Text.Length > 0)
                {
                    int itemID;
                    if (int.TryParse(pattern, out itemID))
                        filter = string.Format("{0} = {1}", this.wH.RepackItemItemsFact.Item_IDColumn.Caption, itemID);
                    else
                        filter = string.Format("{0} LIKE '%{2}%' OR {1} LIKE '%{2}%'", this.wH.RepackItemItemsFact.Item_DescColumn.Caption, this.wH.RepackItemItemsFact.ManufacturerColumn.Caption, pattern);
                }
            }
            catch (Exception ex)
            {

            }

            this.repackItemItemsFactBindingSource.Filter = filter;
        }

        private void dgvData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                this.SelectNextControl(sender as Control, true, true, true, true);
                e.Handled = true;
            }

            if (e.KeyCode == Keys.Enter && dgvData.SelectedRows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                e.Handled = true;
            }
        }

        private void RepackItemSetFactUnits_FormClosing(object sender, FormClosingEventArgs e)
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
                if (dgvData.SelectedRows.Count == 0 && !chbUnknownItemID.Checked)
                    throw new Exception("Товар не выбран.");

                if (chbUnknownItemID.Checked)
                {
                    this.ItemID_Fact = 0;
                }
                else
                {
                    var row = (dgvData.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.RepackItemItemsFactRow;
                    this.ItemID_Fact = Convert.ToInt32(row.Item_ID);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbFilter.Focus();
                return false;
            }
        }
    }
}
