using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryResourcePlanningAddTeamForm : DialogForm
    {
        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Тип бригады
        /// </summary>
        public int TeamTypeID { get { return Convert.ToInt32(cmbTeamType.SelectedValue); } }

        /// <summary>
        /// Кол-во бригад
        /// </summary>
        public int TeamsQuantity { get { return (int)nudTeamsQuantity.Value; } }

        /// <summary>
        /// Режим процесса из обновленной модели
        /// </summary>
        public bool UpgradeMode { get; set; }

        public InventoryResourcePlanningAddTeamForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(235, 8);
            this.btnCancel.Location = new Point(325, 8);

            this.LoadTeamTypes();
        }

        /// <summary>
        /// Загрузка списка типов бригад
        /// </summary>
        private void LoadTeamTypes()
        {
            try
            {
                Data.Inventory.InventoryTeamTypesDataTable teamTypes = null;

                if (this.UpgradeMode)
                    teamTypes = this.inventoryTeamTypesTableAdapter.GetDataUpg(this.UserID, this.InventoryDocID);
                else
                    teamTypes = this.inventoryTeamTypesTableAdapter.GetData(this.UserID, this.InventoryDocID);

                this.inventoryTeamTypesBindingSource.DataSource = teamTypes;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InventoryResourcePlanningAddTeam_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.CreateTeams();
        }

        /// <summary>
        /// Создание бригад
        /// </summary>
        /// <returns></returns>
        private bool CreateTeams()
        {
            try
            {
                if (this.UpgradeMode)
                    this.inventoryTeamTypesTableAdapter.CreateTeamsUpg(this.UserID, this.InventoryDocID, this.TeamTypeID, this.TeamsQuantity);
                else
                    this.inventoryTeamTypesTableAdapter.CreateTeams(this.UserID, this.InventoryDocID, this.TeamTypeID, this.TeamsQuantity);

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
