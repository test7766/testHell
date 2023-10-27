using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.WH.SD
{
    public partial class SelectSalesDispatcherWorkModeForm : DialogForm
    {
        /// <summary>
        /// Установленный режим работы с диспетчером продаж
        /// </summary>
        public int SelectedWorkMode { get; private set; }

        /// <summary>
        /// Описание установленного режима работы
        /// </summary>
        public string SelectedWorkModeDescription { get; private set; }

        public SelectSalesDispatcherWorkModeForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(147, 8);
            this.btnCancel.Location = new Point(237, 8);
        }

        private void SelectSalesDispatcherWorkModeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.salesDispatcherModesBindingSource.DataSource = this.salesDispatcherModesTableAdapter.GetData(this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SelectSalesDispatcherWorkModeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplySelectedWorkMode();
        }

        /// <summary>
        /// Установка выбранного режима с проверкой на возможность
        /// </summary>
        /// <returns></returns>
        private bool ApplySelectedWorkMode()
        {
            if (this.lblWorkModes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Для продолжения необходимо выбрать режим!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            this.SelectedWorkMode = Convert.ToInt32(this.lblWorkModes.SelectedValue);
            this.SelectedWorkModeDescription = ((this.lblWorkModes.SelectedItem as DataRowView).Row as Data.WH.SalesDispatcherModesRow).Mode;
            return true;
        }
    }
}
