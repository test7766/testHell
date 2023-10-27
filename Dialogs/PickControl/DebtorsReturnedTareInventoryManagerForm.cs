using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.PickControl
{
    public partial class DebtorsReturnedTareInventoryManagerForm : DialogForm
    {
        public Data.PickControl.RET_Tare_Inventory_Inv_DocsRow SelectedDoc { get { return dgvInventoryDocs.SelectedRows.Count == 0 ? null : (dgvInventoryDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.PickControl.RET_Tare_Inventory_Inv_DocsRow; } }

        public DebtorsReturnedTareInventoryManagerForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(917, 8);
            this.btnCancel.Location = new Point(1007, 8);

            this.btnOK.Visible = false;
            this.btnCancel.Text = "Закрыть";

            this.SetOperationAccess();
            this.RefreshData();
        }

        private void dgvInventoryDocs_SelectionChanged(object sender, EventArgs e)
        {
            this.SetOperationAccess();
        }

        private void SetOperationAccess()
        {
            var isEnabled = this.SelectedDoc != null;

            sbRunChecks.Enabled = isEnabled && this.SelectedDoc.can_run_checks;
            sbOpenCheckDetails.Enabled = isEnabled && this.SelectedDoc.can_open_check_details;
            sbStartInventory.Enabled = isEnabled && this.SelectedDoc.can_start_inventory;
            sbSetTareShortageOnInitRecounts.Enabled = isEnabled && this.SelectedDoc.can_set_tare_shortage_on_init_recounts;
            sbMoveDublicateTare.Enabled = isEnabled && this.SelectedDoc.can_move_dublicate_tare;
            sbRunFourthRecalculation.Enabled = isEnabled && this.SelectedDoc.can_run_4th_recalculation;
            sbCloseInventory.Enabled = isEnabled && this.SelectedDoc.can_close_inventory;
            sbOpenDetails.Enabled = isEnabled && this.SelectedDoc.can_get_inv_info;
        }

        #region RefreshData

        private void sbRefreshData_Click(object sender, EventArgs e)
        {
            this.RefreshData();
        }

        private void RefreshData()
        {
            try
            {
                rET_Tare_Inventory_Inv_DocsTableAdapter.Fill(pickControl.RET_Tare_Inventory_Inv_Docs, this.UserID);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region RunChecks

        private void sbRunChecks_Click(object sender, EventArgs e)
        {
            this.RunChecks();
        }

        private void RunChecks()
        {
            try
            {
                Data.PickControl.RET_Inventory_ModesDataTable modes = null;
                using (var adapter = new Data.PickControlTableAdapters.RET_Inventory_ModesTableAdapter())
                    modes = adapter.GetData(this.UserID);

                if (modes != null && modes.Rows.Count > 0)
                {
                    var dlgSelectMode = new WMSOffice.Dialogs.RichListForm();
                    dlgSelectMode.Text = "Выберите режим работы с инвентаризацией ОТ";
                    dlgSelectMode.AddColumn("Mode_ID", "Mode_ID", "Код");
                    dlgSelectMode.AddColumn("DSCR", "DSCR", "Наименование");
                    dlgSelectMode.FilterVisible = false;
                    dlgSelectMode.DataSource = modes;

                    if (dlgSelectMode.ShowDialog() == DialogResult.OK)
                    {
                        var mode = dlgSelectMode.SelectedRow as Data.PickControl.RET_Inventory_ModesRow;
                        var modeID = mode.Mode_ID;

                        var docID = this.SelectedDoc.Inventory_number;
                        rET_Tare_Inventory_Inv_DocsTableAdapter.RunInventoryChecks(docID, this.UserID, modeID);

                        this.RefreshData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region OpenCheckDetails

        private void sbOpenCheckDetails_Click(object sender, EventArgs e)
        {
            this.OpenCheckDetails();
        }

        private void OpenCheckDetails()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;

                using (var dlgDebtorsReturnedTareInventoryCheckDetails = new DebtorsReturnedTareInventoryCheckDetailsForm() { UserID = this.UserID, DocID = docID })
                    dlgDebtorsReturnedTareInventoryCheckDetails.ShowDialog();

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region StartInventory

        private void sbStartInventory_Click(object sender, EventArgs e)
        {
            this.StartInventory();
        }

        private void StartInventory()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;
                rET_Tare_Inventory_Inv_DocsTableAdapter.StartInventory(docID, this.UserID);

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region MoveDublicateTare

        private void sbMoveDublicateTare_Click(object sender, EventArgs e)
        {
            this.MoveDublicateTare();
        }

        private void MoveDublicateTare()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;

                using (var dlgDebtorsReturnedTareInventoryMoveDublicateTare = new DebtorsReturnedTareInventoryMoveDublicateTareForm() { UserID = this.UserID, DocID = docID })
                    if (dlgDebtorsReturnedTareInventoryMoveDublicateTare.ShowDialog() == DialogResult.OK)
                        this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region RunFourthRecalculation

        private void sbRunFourthRecalculation_Click(object sender, EventArgs e)
        {
            this.RunFourthRecalculation();
        }

        private void RunFourthRecalculation()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;
                rET_Tare_Inventory_Inv_DocsTableAdapter.RunInventoryFourthRecalculation(docID, this.UserID);

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region CloseInventory

        private void sbCloseInventory_Click(object sender, EventArgs e)
        {
            this.CloseInventory();
        }

        private void CloseInventory()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;
                rET_Tare_Inventory_Inv_DocsTableAdapter.CloseInventory(docID, this.UserID);

                this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region SetTareShortageOnInitRecounts

        private void sbSetTareShortageOnInitRecounts_Click(object sender, EventArgs e)
        {
            this.SetTareShortageOnInitRecounts();
        }

        private void SetTareShortageOnInitRecounts()
        {
            try
            {
                var needConfirm = true;
                var confirm = false;

                var docID = this.SelectedDoc.Inventory_number;

                while (needConfirm)
                {
                    var message = (string)null;
                    rET_Tare_Inventory_Inv_DocsTableAdapter.CloseInventoryInitRecounts(docID, this.UserID, confirm, ref message);

                    if (!string.IsNullOrEmpty(message))
                    {
                        MessageBoxManager.Yes = "&Да";
                        MessageBoxManager.No = "&Нет";
                        MessageBoxManager.Cancel = "&Повтор";

                        MessageBoxManager.Register();

                        var dlgResult = MessageBox.Show(message, "Внимание", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button3);

                        MessageBoxManager.Unregister();

                        if (dlgResult == DialogResult.Yes)
                        {
                            confirm = true;
                            continue;
                        }
                        else if (dlgResult == DialogResult.Cancel)
                            continue;
                    }

                    needConfirm = false;
                }

                if (confirm)
                    this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region OpenDetails

        private void sbOpenDetails_Click(object sender, EventArgs e)
        {
            this.OpenDetails();
        }

        private void OpenDetails()
        {
            try
            {
                var docID = this.SelectedDoc.Inventory_number;

                using (var dlgDebtorsReturnedTareInventoryInfo = new DebtorsReturnedTareInventoryInfoForm() { UserID = this.UserID, DocID = docID })
                    if (dlgDebtorsReturnedTareInventoryInfo.ShowDialog() == DialogResult.OK)
                        this.RefreshData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
