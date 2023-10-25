using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Classes;

namespace WMSOffice.Window
{
    public partial class ContainersBalanceReportWindow : GeneralWindow
    {
        public string WarehouseID { get; set; }

        public string WarehouseName { get; set; }

        public ContainersBalanceReportWindow()
        {
            InitializeComponent();
        }

        private void ContainersBalanceReportWindow_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.DocTitle.Text = string.Format("{0} [{1}]", this.DocTitle.Text, this.WarehouseName);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                tareBalanceReportTableAdapter.Fill(containers.TareBalanceReport, this.WarehouseID);
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvBalanceReport.Rows.Count == 0)
                    MessageBox.Show("Отсутствуют данные для экспорта", "Экспорт в Excel", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    ExportHelper.ExportDataGridViewToExcel(dgvBalanceReport, "Экспорт остатков оборотной тары в Excel", String.Format("остатки оборотной тары по складу {0}", this.WarehouseName), true);
            }
            catch (Exception ex)
            {
                Logger.ShowErrorMessageBox("Во время экспорта остатков оборотной тары в Excel возникла ошибка!", ex);
            }
        }
    }
}
