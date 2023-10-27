using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Receive
{
    public partial class LimesLoadingWorkModeForm : DialogForm
    {
        /// <summary>
        /// Установленный режим работы
        /// </summary>
        public int SelectedWorkMode { get; private set; }

        public LimesLoadingWorkModeForm()
        {
            InitializeComponent();
        }

        private void LimesLoadingWorkModeForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.limesLoadingModesBindingSource.DataSource = this.limesLoadingModesTableAdapter.GetData(this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimesLoadingWorkModeForm_FormClosing(object sender, FormClosingEventArgs e)
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
            if (this.lbWorkModes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Для продолжения необходимо выбрать режим!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            this.SelectedWorkMode = Convert.ToInt32(this.lbWorkModes.SelectedValue);
            return true;
        }
    }
}
