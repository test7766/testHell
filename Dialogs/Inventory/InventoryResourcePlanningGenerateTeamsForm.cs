using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Inventory
{
    public partial class InventoryResourcePlanningGenerateTeamsForm : DialogForm
    {
        /// <summary>
        /// Ид-р документа инвентаризации
        /// </summary>
        public long InventoryDocID { get; set; }

        /// <summary>
        /// Плановая длительность инвентаризации
        /// </summary>
        public int PlanInventoryDuration { get { return (int)nudInventoryPlanDurationHours.Value; } }

        /// <summary>
        /// Вероятный процент 2-го пересчета
        /// </summary>
        public int ProbablePercentOfSecondRecount { get { return (int)nudProbablePercentOfSecondRecount.Value; } }

        /// <summary>
        /// Вероятный процент 3-го пересчета:
        /// </summary>
        public int ProbablePercentOfThirdRecount { get { return (int)nudProbablePercentOfThirdRecount.Value; } }


        public InventoryResourcePlanningGenerateTeamsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.btnOK.Location = new Point(156, 8);
            this.btnCancel.Location = new Point(246, 8);
        }

        private void InventoryResourcePlanningGenerateTeams_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.GenerateTeams();
        }

        /// <summary>
        /// Формирование бригад
        /// </summary>
        /// <returns></returns>
        private bool GenerateTeams()
        {
            try
            {
                using (Data.InventoryTableAdapters.InventoryTeamTypesTableAdapter adapter = new WMSOffice.Data.InventoryTableAdapters.InventoryTeamTypesTableAdapter())
                    adapter.GenerateTeams(this.UserID, this.InventoryDocID, this.PlanInventoryDuration, this.ProbablePercentOfSecondRecount, this.ProbablePercentOfThirdRecount);
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
