using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data.ComplaintsTableAdapters;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class VendorReturnsInvoiceEditForm : DialogForm
    {
        public int DocID { get; private set; }
        public string SupplierName { get; private set; }

        public VendorReturnsInvoiceEditForm()
        {
            InitializeComponent();
        }

        public VendorReturnsInvoiceEditForm(int docID, string supplierName)
            : this()
        {
            this.DocID = docID;
            this.SupplierName = supplierName;
        }

        private void VendorReturnsInvoiceEditForm_Load(object sender, EventArgs e)
        {
            Config.LoadDataGridViewSettings(this.Name, dgvDetails);

            if (!LoadDocLines())
                this.Close();
        }

        private bool LoadDocLines()
        {
            try
            {
                vR_DocDetailsTableAdapter.Fill(complaints.VR_DocDetails, this.UserID, this.DocID);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось загрузить строки документа возврата.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.btnOK.Location = new Point(1165, 8);
            this.btnCancel.Location = new Point(1255, 8);

            tbDocID.Text = this.DocID.ToString();
            tbSupplierName.Text = this.SupplierName;

            tbVendorInvoiceNumber.Focus();

            this.WindowState = FormWindowState.Maximized;
        }

        private void dgvDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var boundRow = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.VR_DocDetailsRow;

            var receiptPriceExists = !boundRow.IsReceiptPriceNull();
            var optPriceExists = !boundRow.IsOptPriceNull();
            var hasStateReg = !boundRow.IsIS_State_Reg_ItemNull() && boundRow.IS_State_Reg_Item;

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.ReceiptPriceColumn.Caption)
            {
                e.CellStyle.BackColor = receiptPriceExists ? Color.LightGreen : Color.LightPink;
                e.CellStyle.SelectionForeColor = receiptPriceExists ? Color.LightGreen : Color.LightPink;
            }

            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.OptPriceColumn.Caption)
            {
                e.CellStyle.BackColor = optPriceExists ? Color.LightGreen : Color.LightPink;
                e.CellStyle.SelectionForeColor = optPriceExists ? Color.LightGreen : Color.LightPink;
            }

            if (hasStateReg)
            {
                e.CellStyle.ForeColor = e.CellStyle.SelectionForeColor = Color.Brown;
            }
        }

        private void dgvDetails_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1)
                    return;

                var value = dgvDetails.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                var docRow = (dgvDetails.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.Complaints.VR_DocDetailsRow;
                var lineID = docRow.Line_ID;
                var itemID = docRow.Item_ID;
                var lotNumber = docRow.Lot_Number;

                foreach (Data.Complaints.VR_DocDetailsRow dr in complaints.VR_DocDetails.Select(string.Format("{0} = {1} AND {2} = '{3}' AND {4} <> {5}", complaints.VR_DocDetails.Item_IDColumn.Caption, itemID, complaints.VR_DocDetails.Lot_NumberColumn.Caption, lotNumber, complaints.VR_DocDetails.Line_IDColumn.Caption, lineID)))
                {
                    if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.ReceiptPriceColumn.Caption)
                    {
                        if (dr.IsReceiptPriceNull())
                        {
                            if (value.Equals(DBNull.Value))
                                dr.SetReceiptPriceNull();
                            else
                                dr.ReceiptPrice = (decimal)value;
                        }
                    }

                    else if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.OptPriceColumn.Caption)
                    {
                        if (dr.IsOptPriceNull())
                        {
                            if (value.Equals(DBNull.Value))
                                dr.SetOptPriceNull();
                            else
                                dr.OptPrice = (decimal)value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void dgvDetails_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.ReceiptPriceColumn.Caption ||
                dgvDetails.Columns[e.ColumnIndex].DataPropertyName == complaints.VR_DocDetails.OptPriceColumn.Caption)
            {
                if (e.Exception != null)
                {
                    var context = (DataGridViewDataErrorContexts.Parsing | DataGridViewDataErrorContexts.Commit);
                    if ((e.Context | context) == context)
                    {
                        MessageBox.Show(string.Format("Поле \"{0}\" должно содержать числовое значение.", dgvDetails.Columns[e.ColumnIndex].HeaderText), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void VendorReturnsInvoiceEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !ApplyChanges();
        }

        private bool ApplyChanges()
        {
            try
            {
                if (string.IsNullOrEmpty(tbVendorInvoiceNumber.Text))
                    throw new Exception("Номер инвойса поставщика должен быть указан.");

                foreach (Data.Complaints.VR_DocDetailsRow row in complaints.VR_DocDetails.Rows)
                {
                    if (row.IsReceiptPriceNull())
                        throw new Exception("Все цены поставки должны быть указаны.");

                    if (row.IsOptPriceNull())
                        throw new Exception("Все ООЦ должны быть указаны.");
                }

                // Установка номера/даты инвойса поставщика
                var invoiceNumber = tbVendorInvoiceNumber.Text.Trim();
                var invoiceDate = dtpVendorInvoiceDate.Value;
                vR_DocDetailsTableAdapter.SetInvoiceDateNumber(this.UserID, this.DocID, invoiceNumber, invoiceDate);

                // Установка цен поставки
                foreach (Data.Complaints.VR_DocDetailsRow row in complaints.VR_DocDetails.Rows)
                    vR_DocDetailsTableAdapter.SetReceiptPrice(this.UserID, this.DocID, row.Line_ID, row.ReceiptPrice, row.OptPrice);

                // Перевод статуса
                using (var adapter = new VR_DocsTableAdapter())
                    adapter.ChangeStatus(this.UserID, this.DocID, "217", null, null, null, null);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void VendorReturnsInvoiceEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Config.SaveDataGridViewSettings(this.Name, dgvDetails);
        }
    }
}
