using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryHeaderForm : DialogForm
    {
        /// <summary>
        /// Дата инвентаризации
        /// </summary>
        public DateTime InventoryDate { get { return dtpInventoryDate.Value.Date; } }

        /// <summary>
        /// Тип инвентаризации
        /// </summary>
        public string InventoryType { get { return cmbInventoryType.SelectedValue.ToString(); } }

        /// <summary>
        /// Планируемая длительность инвентаризации (ччч:мм)
        /// </summary>
        public string InventoryPlanDuration { get { return string.Format("{0}:{1}", 
            nudInventoryPlanDurationHours.Value.ToString().PadLeft(3, '0'), 
            dtpInventoryPlanDurationMinutes.Value.Minute.ToString().PadLeft(2, '0')); } }
      

        public InventoryHeaderForm()
        {
            InitializeComponent();
        }

        private void InventoryHeaderForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.dtpInventoryPlanDurationMinutes.Value = DateTime.Today;
                this.inventoryTypesBindingSource.DataSource = this.inventoryTypesTableAdapter.GetData(this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(252, 8);
            this.btnCancel.Location = new Point(342, 8);
        }   
    }
}
