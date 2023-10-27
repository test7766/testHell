using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class LinkZoneToTeamForm : DialogForm
    {
        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Номер бригады
        /// </summary>
        public long TeamID { get; set; }

        public LinkZoneToTeamForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            this.btnOK.Location = new Point(155, 8);
            this.btnCancel.Location = new Point(245, 8);
            base.OnShown(e);

            this.LoadZones();
        }

        /// <summary>
        /// Получение перечня зон
        /// </summary>
        private void LoadZones()
        {
            this.inventoryTeamZonesBindingSource.DataSource = this.inventoryTeamZonesTableAdapter.GetData(this.UserID, this.InventoryDocID);
        }

        private void LinkZoneToTeamForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.LinkZoneToTeam();
        }

        /// <summary>
        /// Привязка зоны к бригаде
        /// </summary>
        /// <returns></returns>
        private bool LinkZoneToTeam()
        {
            try
            {
                int zoneID = Convert.ToInt32(cmbZones.SelectedValue);
                this.inventoryTeamZonesTableAdapter.LinkZoneToTeam(this.UserID, this.InventoryDocID, this.TeamID, zoneID);
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
