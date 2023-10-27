#define UPGRADE

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareForm : DialogForm
    {
        public string RouteListBarcode { get; set; }

        public bool UseCorrectMode { get; set; }

        public int ReceiptDocID { get; private set; }

        public int? TareDocID { get; set; }

        public ReceiptDebtorsReturnedTareForm()
        {
            InitializeComponent();
        }

        public ReceiptDebtorsReturnedTareForm(int receiptDocID)
            : this()
        {
            ReceiptDocID = receiptDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.ChangeClientRemainsVisibility(false);

#if UPGRADE

            btnOK.Location = new Point(1142, 8); // 1307
            btnCancel.Location = new Point(1232, 8); // 1397
#else
            scWorkSpace.Panel2Collapsed = true;
            this.Width = 800;
            this.Height = 500;

            btnOK.Location = new Point(620, 8); 
            btnCancel.Location = new Point(710, 8);
#endif

            if (this.UseCorrectMode)
                this.Text = string.Format("{0} (доработка)", this.Text);
            else
                this.Text = string.Format("{0} (Ш/К МЛ: {1})", this.Text, this.RouteListBarcode);

            tbsTare.TextChanged += new EventHandler(tbsTare_TextChanged);
            tbsTare.UseScanModeOnly = true;
            ReloadTare();
            RefreshDetails();
        }

        void tbsTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsTare.Text))
                    return;

                var tareBarCode = tbsTare.Text;

                if (this.UseCorrectMode)
                {
                    tareReturnByRouteListTableAdapter.CheckTareRevision(this.ReceiptDocID, this.TareDocID, tareBarCode, this.UserID);
                }
                else
                {
                    tareReturnByRouteListTableAdapter.CheckTare(this.ReceiptDocID, tareBarCode);
                    // CheckInputTareBarCode
                    // ScanRZon
                    // ClientTareTypes
                }

                ReloadTare();

                tbsTare.Text = string.Empty;
                tbsTare.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTare.Focus();
                tbsTare.SelectAll();
            }
        }

        private void btnManualTareInput_Click(object sender, EventArgs e)
        {
           var frmReceiptDebtorsReturnedTareSetManual = new ReceiptDebtorsReturnedTareSetManualForm { UserID = this.UserID, ReceiptDocID = this.ReceiptDocID };
           if (frmReceiptDebtorsReturnedTareSetManual.ShowDialog() == DialogResult.OK)
           {
               if (!string.IsNullOrEmpty(frmReceiptDebtorsReturnedTareSetManual.TareBarCode))
               {
                   tbsTare.Text = frmReceiptDebtorsReturnedTareSetManual.TareBarCode;
                   tbsTare.OnTextChanged();
               }
           }
        }

        private void ReloadTare()
        {
            try
            {
                tareReturnByRouteListBindingSource.DataSource = null;
                delivery.TareReturnByRouteList.Clear();

                var selectedTare = dgvTareDetails.SelectedRows.Count > 0 ? (dgvTareDetails.Rows[dgvTareDetails.SelectedRows[0].Index].DataBoundItem as DataRowView).Row as Data.Delivery.FullTareByRouteListRow : null;
                var tareType = selectedTare != null ? selectedTare.Tare_Type : (string)null;
                var clientID = selectedTare != null ? selectedTare.Client_id : (int?)null;
                var tare = tareReturnByRouteListTableAdapter.GetData(this.ReceiptDocID, tareType, clientID);

                if (tare != null) // && tare.Rows.Count > 0)
                    lblScannedReturnedTareQtty.Text = tare.Rows.Count.ToString();

                delivery.TareReturnByRouteList.Merge(tare);
                tareReturnByRouteListBindingSource.DataSource = tare;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReceiptDebtorsReturnedTareForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                var tareReceiptCommit = false;
                var tareReceiptCancel = false;

                if (DialogResult == DialogResult.OK)
                    tareReceiptCommit = true;
                else
                    tareReceiptCancel = true;

                if (tareReceiptCommit)
                {
                    var returnType = (int?)null;
                    //returnType = SelectReturnType();
                    ConfirmTareReceipt(returnType);
                    return;
                }

                if (tareReceiptCancel)
                {
                    CancelTareReceipt();
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsTare.Text = string.Empty;
                tbsTare.Focus();

                e.Cancel = true;
            }
        }

        [Obsolete("Не используется")]
        private int SelectReturnType()
        { 
            Data.Delivery.TareReturnTypesDataTable returnTypes = null;
            using (var adapter = new Data.DeliveryTableAdapters.TareReturnTypesTableAdapter())
                returnTypes = adapter.GetData();

            if (returnTypes != null && returnTypes.Rows.Count > 0)
            {
                var dlgSelectReturnTypes = new WMSOffice.Dialogs.RichListForm();
                dlgSelectReturnTypes.Text = "Выберите режим сдачи ОТ";
                dlgSelectReturnTypes.AddColumn("ID_Description", "ID_Description", "Режим сдачи ОТ");
                //dlgSelectReturnTypes.ColumnForFilters = new List<string>(new string[] { "ID_Description" });
                dlgSelectReturnTypes.DisableFilter = true;
                dlgSelectReturnTypes.FilterChangeLevel = 0;
                dlgSelectReturnTypes.ShowGridViewItemsWithoutSelection = true;
                dlgSelectReturnTypes.DataSource = returnTypes;
                dlgSelectReturnTypes.DiscardCanceling = true;

                if (dlgSelectReturnTypes.ShowDialog(this) == DialogResult.OK)
                {
                    var selectedItem = dlgSelectReturnTypes.SelectedRow as Data.Delivery.TareReturnTypesRow;
                    var returnType = selectedItem.ID;
                    return returnType;
                }
                else
                    throw new Exception("Не выбран режим сдачи ОТ.");
            }
            else
                throw new Exception("Не определен режим сдачи ОТ.");
        }

        private void ConfirmTareReceipt(int? returnType)
        {
            if (this.UseCorrectMode)
            {

            }
            else
            {
                RefreshDetails();
                var allowConfirm = this.CheckDetails();

                if (allowConfirm || (!allowConfirm && MessageBox.Show("Обнаружены расхождения!\r\nВы уверены что хотите закрыть документ?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes))
                    tareReturnByRouteListTableAdapter.ConfirmReceipt(this.ReceiptDocID, this.UserID, returnType);
                else
                    throw new Exception("Исправьте расхождения\r\nи повторите попытку закрытия документа.");
            }
        }

        private void CancelTareReceipt()
        {
            if (this.UseCorrectMode)
            {

            }
            else
            {
                ReceiptDebtorsReturnedTareForm.CancelTareReceipt(this.ReceiptDocID);
            }
        }

        public static void CancelTareReceipt(int? receiptDocID)
        {
            using (var adapter = new Data.DeliveryTableAdapters.TareReturnByRouteListTableAdapter())
                adapter.CancelReceipt(receiptDocID);
        }

        private void btnRefreshDetails_Click(object sender, EventArgs e)
        {
            this.RefreshDetails();
        }

        private void RefreshDetails()
        {
            if (scWorkSpace.Panel2Collapsed)
                return;

            try
            {
                lockWhileReloadData = true;

                fullTareByRouteListBindingSource.DataSource = null;
                delivery.FullTareByRouteList.Clear();

                var tare = fullTareByRouteListTableAdapter.GetData(this.ReceiptDocID);

                delivery.FullTareByRouteList.Merge(tare);
                fullTareByRouteListBindingSource.DataSource = tare;

                if (dgvTareDetails.Rows.Count > 0)
                    dgvTareDetails.Rows[0].Selected = false;

                lockWhileReloadData = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowClientRemains_Click(object sender, EventArgs e)
        {
            this.ChangeClientRemainsVisibility(!btnShowClientRemains.Checked);
            this.RefreshClientRemains();
        }

        private void RefreshClientRemains()
        {
            try
            {
                clientTareRemainsBindingSource.DataSource = null;
                delivery.ClientTareRemains.Clear();

                if (btnShowClientRemains.Checked && dgvTareDetails.SelectedRows.Count > 0)
                {
                    var selectedTare = dgvTareDetails.SelectedRows.Count > 0 ? (dgvTareDetails.Rows[dgvTareDetails.SelectedRows[0].Index].DataBoundItem as DataRowView).Row as Data.Delivery.FullTareByRouteListRow : null;
                    var tareType = selectedTare != null ? selectedTare.Tare_Type : (string)null;
                    var clientID = selectedTare != null ? selectedTare.Client_id : (int?)null;
                    var tare = clientTareRemainsTableAdapter.GetData(this.ReceiptDocID, tareType, clientID);

                    delivery.ClientTareRemains.Merge(tare);
                    clientTareRemainsBindingSource.DataSource = tare;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeClientRemainsVisibility(bool showRemains)
        { 
            scFoolTareByRouteListDetails.Panel2Collapsed = !showRemains; 
            btnShowClientRemains.Checked = showRemains;

            if (dgvTareDetails.SelectedRows.Count > 0)
                dgvTareDetails.FirstDisplayedScrollingRowIndex = dgvTareDetails.SelectedRows[0].Index;
        }

        private void dgvTareDetails_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvTareDetails.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvTareDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                var boundRow = (dgvTareDetails.Rows[dgvTareDetails.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.Delivery.FullTareByRouteListRow;
                var color = Color.FromName(boundRow.Color);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvTareDetails.Rows[this.dgvTareDetails.CurrentRow.Index].Cells[this.isSelectedDataGridViewCheckBoxColumn.Index].Value);
                
                foreach (DataGridViewColumn column in this.dgvTareDetails.Columns)
                {
                    this.dgvTareDetails.Rows[this.dgvTareDetails.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : color;
                    this.dgvTareDetails.Rows[this.dgvTareDetails.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : color;
                }

                if (!isChecked && dgvTareDetails.Rows.Count > 0)
                    dgvTareDetails.Rows[0].Selected = false;
            }
        }

        private void dgvTareDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var boundRow = (dgvTareDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Delivery.FullTareByRouteListRow;
            var color = Color.FromName(boundRow.Color);

            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvTareDetails.Rows[e.RowIndex].Cells[this.isSelectedDataGridViewCheckBoxColumn.Index].Value);

            this.dgvTareDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : color;
            this.dgvTareDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : color;

            // Информация об адресе доставки
            if (e.ColumnIndex == this.dgvTareDetails.Columns[clientNameDataGridViewTextBoxColumn.Name].Index)
            {
                var currentCell = this.dgvTareDetails.Rows[e.RowIndex].Cells[e.ColumnIndex];
                currentCell.ToolTipText = boundRow.Address;
            }
        }

        private bool lockWhileReloadData = false;
        private void dgvTareDetails_SelectionChanged(object sender, EventArgs e)
        {
            if (!lockWhileReloadData)
                this.SelectSingleTareRow();
        }

        private void SelectSingleTareRow()
        {
            foreach (DataGridViewRow gridRow in dgvTareDetails.Rows)
                gridRow.Cells[this.isSelectedDataGridViewCheckBoxColumn.Index].Value = gridRow.Selected;

            ReloadTare();
            RefreshClientRemains();
        }

        private bool CheckDetails()
        {
            foreach (DataGridViewRow gridRow in dgvTareDetails.Rows)
            {
                var boundRow = (gridRow.DataBoundItem as DataRowView).Row as Data.Delivery.FullTareByRouteListRow;
                var color = Color.FromName(boundRow.Color);

                if (!color.Equals(Color.White))
                    return false;
            }

            return true;
        }
    }
}
