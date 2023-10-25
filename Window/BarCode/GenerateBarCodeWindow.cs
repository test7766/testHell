using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.BarCode;
using WMSOffice.Data.BCTableAdapters;
using WMSOffice.Controls;

namespace WMSOffice.Window.BarCode
{
    public partial class GenerateBarCodeWindow : GeneralWindow
    {        
        public GenerateBarCodeWindow()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Initialize();
            PrepareData();
        }

        private void Initialize()
        {
            stbWarehouseID.ValueReferenceQuery = "[dbo].[pr_BC_Get_Available_Warehouses]";
            stbWarehouseID.UserID = this.UserID;
            stbWarehouseID.OnVerifyValue += (s, e) => 
            {
                lblWarehouseDesc.Text = e.Success ? e.Description : "СКЛАД НЕ НАЙДЕН";
                lblWarehouseDesc.ForeColor = e.Success ? SystemColors.ControlText : Color.Red;

                if (e.Success)
                    stbWarehouseID.Value = e.Value;
            };
            stbWarehouseID.SetFirstValueByDefault();

            tsMain.Items.Insert(0, new ToolStripControlHost(pnlWarehouseFilter));
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.F5))
            {
                PrepareData();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void GenerateClick(object sender, EventArgs e)
        {
            try
            {
                var dlg = new BarCodeGenDialog { Owner = this, SessionID = this.UserID };
                if (dlg.ShowDialog() == DialogResult.Cancel)
                    return;

                portionTableAdapter.SetTimeout(300);
                portionTableAdapter.GenerateBarcode(dlg.PortionCnt, BarCodeGenDialog.PrintEmpty == dlg.PrinterName ? null : dlg.PrinterName, dlg.PortionType);
                PrepareData();
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException ?? ex;
                MessageBox.Show(msg.Message, "Ошибка генерации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GivenClick(object sender, EventArgs e)
        {
            var row = (gridViewPortion.CurrentRow.DataBoundItem as DataRowView).Row as Data.BC.PortionRow;
            if (row == null || !(row.IsIsPrintedNull() ? false : row.IsPrinted))
                return;

            var dlg = new PortionGivenDialog { Owner = this };
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;

            int code = -1;
            string name = String.Empty;

            if (!int.TryParse(dlg.textBoxScaner.Text, out code))
            {
                MessageBox.Show("Не верно указан код сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var ta = new F0101TableAdapter())
            {
                var emp = ta.GetData(code);
                if (emp.Rows.Count > 0)
                    name = emp.Rows[0]["Name"].ToString();
            }

            portionTableAdapter.SetEmployee(code, name, DateTime.Now, row.PortionID);
            PrepareData();
        }

        private void RefreshClick(object sender, EventArgs e)
        {
            PrepareData();
        }

        private void PrepareData()
        {
            try
            {
                var warehouseID = stbWarehouseID.Value;

                gridViewPortion.SelectionChanged -= gridViewPortion_SelectionChanged;

                portionTableAdapter.Fill(bC.Portion, warehouseID);

                gridViewPortion.SelectionChanged += gridViewPortion_SelectionChanged;

                SetEnabled();
            }
            catch (Exception ex)
            {
                this.ShowError(ex);
            }
        }

        private void SetEnabled()
        {
            btnApply.Enabled = toolStripButton2.Enabled = false;
            var row = gridViewPortion.CurrentRow != null ? (gridViewPortion.CurrentRow.DataBoundItem as DataRowView).Row as Data.BC.PortionRow : null;

            btnApply.Enabled = row == null || row.IsRecipientCodeNull() ? false : true;

            btnCheck.Enabled = row != null;

            if (row == null || !row.IsRecipientCodeNull())
                return;

            toolStripButton2.Enabled = row.IsIsPrintedNull() ? false : row.IsPrinted;
        }

        private void gridViewPortion_SelectionChanged(object sender, EventArgs e)
        {
            SetEnabled();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            var row = (gridViewPortion.CurrentRow.DataBoundItem as DataRowView).Row as Data.BC.PortionRow;
            if (row == null || row.IsRecipientCodeNull())
                return;

            portionTableAdapter.ClosePortion(false, row.PortionID);
            PrepareData();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            var row = (gridViewPortion.CurrentRow.DataBoundItem as DataRowView).Row as Data.BC.PortionRow;
            if (row == null)
                return;

            var portionID = row.PortionID;
            var dlg = new CheckPortionBarcodesDialog(portionID) { Owner = this };
            dlg.ShowDialog();
        }
    }
}
