using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Data;
using WMSOffice.Data.ContainersTableAdapters;
using WMSOffice.Dialogs;
using WMSOffice.Reports;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Окно для сканирования штрих-кодов расходных накладных для закрытия претензии "Аннулирование заказа".
    /// </summary>
    public partial class CheckInvoicesForCancelWindow : WMSOffice.Window.GeneralWindow
    {
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        public CheckInvoicesForCancelWindow(long docID, string lastBarCode)
        {
            if (docID <= 0)
                throw new ArgumentException("Не задан код документа претензии (он должен быть больше 0).", "docID");
            
            InitializeComponent();

            this.DocID = docID;
            tbBarcode.Text = lastBarCode;
            tbBarcode_TextChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обрабатывает ввод нового штрих-кода.
        /// </summary>
        private void tbBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbBarcode.Text))
            {
                string previousBarcodes = string.Empty;
                if (complaints.CheckInvoicesForCancel.Count > 0)
                    previousBarcodes = complaints.CheckInvoicesForCancel[0].IsBarCodesNull() ? null : complaints.CheckInvoicesForCancel[0].BarCodes;
                try
                {
                    checkInvoicesForCancelTableAdapter.Fill(complaints.CheckInvoicesForCancel, UserID, DocID, previousBarcodes, tbBarcode.Text);
                }
                catch (Exception ex)
                {
                    ShowError(ex);
                    try
                    {
                        checkInvoicesForCancelTableAdapter.Fill(complaints.CheckInvoicesForCancel, UserID, DocID, previousBarcodes, string.Empty);
                    }
                    catch { }
                }
            }
            tbBarcode.Text = "";
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Завершить аннулирование заказа".
        /// </summary>
        private void btnCloseDoc_Click(object sender, EventArgs e)
        {
            bool allInvoicesScanned = false;
            foreach (Data.Complaints.CheckInvoicesForCancelRow row in complaints.CheckInvoicesForCancel.Rows)
            {
                if (row.IsScanned)
                {
                    allInvoicesScanned = true;
                }
                else
                {
                    allInvoicesScanned = false;
                    break;
                }
            }

            if (!allInvoicesScanned)
            {
                ShowError("Отсканированы не все расходные накладные!");
            }
            else
            {
                if (MessageBox.Show("Завершить аннулирование заказа?" + Environment.NewLine +
                    "Нажмите \"Да\" (\"Yes\") только в том случае, если вы уничтожили весь комплект документов!",
                    "Подтверждение действия", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (Data.ComplaintsTableAdapters.CurrentDocsTableAdapter adapter = new Data.ComplaintsTableAdapters.CurrentDocsTableAdapter())
                        {
                            adapter.ChangeDocStatus(UserID, DocID, ComplaintsConstants.ComplaintStatusAutoClosingAccepted, ComplaintsConstants.ComplaintStatusClosingAccepted);
                        }
                        Close();
                    }
                    catch (Exception ex)
                    {
                        ShowError(ex);
                    }
                }
            }
        }

        /// <summary>
        /// Меняет расцветку строк после обновления данных в таблице.
        /// </summary>
        private void gvLines_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow dgvRow in gvLines.Rows)
            {
                if (((Data.Complaints.CheckInvoicesForCancelRow)((DataRowView)dgvRow.DataBoundItem).Row).IsScanned)
                {
                    for (int c = 0; c < dgvRow.Cells.Count; c++)
                    {
                        dgvRow.Cells[c].Style.BackColor = Color.LimeGreen;
                        dgvRow.Cells[c].Style.SelectionForeColor = Color.LimeGreen;
                    }
                }
                dgvRow.Selected = false;
            }
        }
    }
}
