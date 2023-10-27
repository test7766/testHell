using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Delivery
{
    public partial class ReceiptDebtorsReturnedTareTransitForm : DialogForm
    {
        public string RouteListBarcode { get; set; }
        
        public int ReceiptDocID { get; private set; }

        public Guid? GroupID { get; private set; }

        public ReceiptDebtorsReturnedTareTransitForm()
        {
            InitializeComponent();
        }

        public ReceiptDebtorsReturnedTareTransitForm(int receiptDocID)
            : this()
        {
            ReceiptDocID = receiptDocID;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(620, 8);
            btnCancel.Location = new Point(710, 8);

            btnOK.Enabled = false;

            this.Text = string.Format("{0} (Ш/К МЛ: {1})", this.Text, this.RouteListBarcode);

            tbsTare.TextChanged += new EventHandler(tbsTare_TextChanged);
            tbsTare.UseScanModeOnly = true;

            ReloadTare();

            //Init();
        }

        [Obsolete("test")]
        private void Init()
        {
            try
            {
                var now = DateTime.Now;

                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "BOX0001", "Ящик", 1, 1, now.AddSeconds(1) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "CAP0001", "Крышка", 1, 1, now.AddSeconds(2) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK1001", "Пломба 1", 1, 1, now.AddSeconds(4) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK2001", "Пломба 2", 1, 1, now.AddSeconds(3) }, true);

                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "BOX0002", "Ящик", 1, 2, now.AddSeconds(7) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "CAP0002", "Крышка", 1, 2, now.AddSeconds(5) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK1002", "Пломба 1", 1, 2, now.AddSeconds(6) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK2002", "Пломба 2", 1, 2, now.AddSeconds(8) }, true);

                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK1003", "Пломба 1", 0, 3, now.AddSeconds(10) }, true);
                delivery.TareTransitReturnByRouteList.LoadDataRow(new object[] { new Guid(), "LOCK2003", "Пломба 2", 0, 3, now.AddSeconds(9) }, true);

                tareTransitReturnByRouteListBindingSource.DataSource = delivery.TareTransitReturnByRouteList;

                lblScannedInvoicesQtty.Text = delivery.TareTransitReturnByRouteList.Rows.Count.ToString();

                CreateTareGroups();

                NavigateToTare("LOCK1003");
            }
            catch (Exception ex)
            {
               
            }
        }

        void tbsTare_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbsTare.Text))
                    return;

                var tareBarCode = tbsTare.Text;

                var groupID = (Guid?)null;
                var finishFlag = (bool?)null;

                using (var adapter = new Data.DeliveryTableAdapters.TareTransitReturnByRouteListTableAdapter())
                    adapter.ScanTare(this.ReceiptDocID, tareBarCode, this.GroupID, ref groupID, ref finishFlag);

                // Получаем код группы
                this.GroupID = groupID;

                // Признак сканирования последней тары
                if (Convert.ToBoolean(finishFlag ?? false) == true)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                ReloadTare();
                NavigateToTare(tareBarCode);

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

        private void ReloadTare()
        {
            try
            {
                tareTransitReturnByRouteListBindingSource.Sort = (string)null;
                tareTransitReturnByRouteListBindingSource.DataSource = null;
                delivery.TareTransitReturnByRouteList.Clear();

                var qttyScannedInvoices = (int?)null;
                var tare = tareTransitReturnByRouteListTableAdapter.GetData(this.ReceiptDocID);

                if (tare != null) // && tare.Rows.Count > 0)
                    lblScannedInvoicesQtty.Text = tare.Rows.Count.ToString();

                delivery.TareTransitReturnByRouteList.Merge(tare);
                tareTransitReturnByRouteListBindingSource.DataSource = tare;

                tareTransitReturnByRouteListBindingSource.Sort = string.Format("{0} ASC, {1} ASC", delivery.TareTransitReturnByRouteList.RNKColumn.Caption, delivery.TareTransitReturnByRouteList.Type_DescriptionColumn.Caption);

                CreateTareGroups();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void NavigateToTare(string tareBarCode)
        {
            foreach (DataGridViewRow row in dgvTareInvoice.Rows)
            {
                var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Delivery.TareTransitReturnByRouteListRow;
                var barCode = boundRow.IsBar_codeNull() ? (string)null : boundRow.Bar_code;

                if (tareBarCode == barCode)
                {
                    row.Selected = true;
                    dgvTareInvoice.FirstDisplayedScrollingRowIndex = row.Index;
                }
            }
        }

        private void dgvTareInvoice_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
           
        }

        private void CreateTareGroups()
        {
            try
            {
                var rankID = 1M;

                var rows = delivery.TareTransitReturnByRouteList.Select(string.Empty, tareTransitReturnByRouteListBindingSource.Sort);
                foreach (Data.Delivery.TareTransitReturnByRouteListRow row in rows)
                {
                    if (row.RNK > rankID)
                    {
                        var groupRow = delivery.TareTransitReturnByRouteList.NewTareTransitReturnByRouteListRow();
                        groupRow.RNK = rankID + 0.5M;
                        delivery.TareTransitReturnByRouteList.AddTareTransitReturnByRouteListRow(groupRow);

                        rankID++;
                    }
                }

                tareTransitReturnByRouteListBindingSource.DataSource = delivery.TareTransitReturnByRouteList;
                tareTransitReturnByRouteListBindingSource.ResetBindings(false);

                foreach (DataGridViewRow row in dgvTareInvoice.Rows)
                {
                    var boundRow = (row.DataBoundItem as DataRowView).Row as Data.Delivery.TareTransitReturnByRouteListRow;
                    var isGroupRow = Math.Truncate(boundRow.RNK) != boundRow.RNK;

                    if (isGroupRow)
                        row.Height = 5;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvTareInvoice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                var boundRow = (dgvTareInvoice.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Delivery.TareTransitReturnByRouteListRow;
                var isGroupCompleted = boundRow.IsCompl_FlagNull() ? false : Convert.ToBoolean(boundRow.Compl_Flag);
                var isGroupRow = Math.Truncate(boundRow.RNK) != boundRow.RNK;

                e.CellStyle.BackColor = isGroupCompleted ? Color.LightGreen : isGroupRow ? SystemColors.AppWorkspace : SystemColors.Window;
                e.CellStyle.SelectionForeColor = isGroupCompleted ? Color.LightGreen : isGroupRow ? SystemColors.AppWorkspace : SystemColors.Window;
                e.CellStyle.SelectionBackColor = isGroupRow ? SystemColors.AppWorkspace : e.CellStyle.SelectionBackColor;
            }
            catch (Exception ex)
            {

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
                    ConfirmTareReceipt();
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

        private void ConfirmTareReceipt()
        {
            ReceiptDebtorsReturnedTareTransitForm.ConfirmTareReceipt(this.UserID, this.ReceiptDocID);
        }

        public static void ConfirmTareReceipt(long userID, int? receiptDocID)
        {
            using (var adapter = new Data.DeliveryTableAdapters.TareTransitReturnByRouteListTableAdapter())
                adapter.ConfirmReceipt(receiptDocID, userID);
        }

        private void CancelTareReceipt()
        {
            ReceiptDebtorsReturnedTareTransitForm.CancelTareReceipt(this.ReceiptDocID);
        }

        public static void CancelTareReceipt(int? receiptDocID)
        {
            using (var adapter = new Data.DeliveryTableAdapters.CheckTareInvoiceTransitReturnByRouteListTableAdapter())
                adapter.CancelDoc(receiptDocID);
        }
    }
}
