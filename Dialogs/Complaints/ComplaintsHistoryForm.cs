using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    /// <summary>
    /// Диалог для отображения истории претензий по адресу доставки или номеру накладной.
    /// </summary>
    public partial class ComplaintsHistoryForm : DialogForm
    {
        /// <summary>
        /// Возвращает / устанавливает идентификатор пользовательской сессии.
        /// </summary>
        private long SessionID { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="addressCode">Код адреса доставки (из "шапки" претензии).</param>
        /// <param name="relatedInvoiceType">Тип накладной.</param>
        /// <param name="relatedInvoiceNumber">Номер накладной.</param>
        /// <param name="canChooseForLink">Признак, показывающий, можно ли выбирать претензию для связи с создаваемой.</param>
        public ComplaintsHistoryForm(long sessionID, int? addressCode, string relatedInvoiceType, double? relatedInvoiceNumber, bool canChooseForLink)
        {
            InitializeComponent();

            this.SessionID = sessionID;
            this.WasLinked = false;

            if (addressCode.HasValue)
                tbAddressCode.Text = addressCode.Value.ToString();
            if (!string.IsNullOrEmpty(relatedInvoiceType))
                tbInvoiceType.Text = relatedInvoiceType;
            if (relatedInvoiceNumber.HasValue)
                tbInvoiceNumber.Text = relatedInvoiceNumber.Value.ToString();

            chkbAddressCode.Checked = addressCode.HasValue;
            chkbInvoice.Checked = !string.IsNullOrEmpty(relatedInvoiceType) && relatedInvoiceNumber.HasValue;
            btnChooseForLink.Enabled = canChooseForLink;

            btnSearch_Click(this, EventArgs.Empty);
        }

        /// <summary>
        /// Возвращает признак, показывающий, была ли выбрана претензия для связи.
        /// </summary>
        public bool WasLinked { get; private set; }
        /// <summary>
        /// Возвращает идентификатор претензии, выбранной для связи.
        /// </summary>
        public long LinkedDocID { get; private set; }
        /// <summary>
        /// Возвращает краткую информацию о претензии, выбранной для связи (№, дата обращения клиента, тип претензии).
        /// </summary>
        public string LinkedDocCaption { get; private set; }

        /// <summary>
        /// Меняет состояние текстовых полей условий поиска в зависимости от состояния флажков.
        /// </summary>
        private void chkbAddressCode_CheckedChanged(object sender, EventArgs e)
        {
            tbAddressCode.Enabled = chkbAddressCode.Checked;
            tbInvoiceNumber.Enabled = tbInvoiceType.Enabled = chkbInvoice.Checked;
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Поиск по претензиям".
        /// </summary>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            int? addressCode = null;
            if (chkbAddressCode.Checked)
            {
                int tmp = 0;
                if (!int.TryParse(tbAddressCode.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Код адреса доставки не задан или задан некорректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    addressCode = tmp;
                }
            }

            string invoiceType = null;
            double? invoiceNumber = null;
            if (chkbInvoice.Checked)
            {
                if (string.IsNullOrEmpty(tbInvoiceType.Text))
                {
                    MessageBox.Show("Тип накладной не задан или задан некорректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    invoiceType = tbInvoiceType.Text;
                }

                int tmp = 0;
                if (!int.TryParse(tbInvoiceNumber.Text, out tmp) || tmp <= 0)
                {
                    MessageBox.Show("Номер накладной не задан или задан некорректно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    invoiceNumber = tmp;
                }
            }

            currentDocsTableAdapter.FillDocsHistory(complaints.CurrentDocs, SessionID, addressCode, invoiceType, invoiceNumber);
            dgvDocs_SelectionChanged(this, EventArgs.Empty);
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "Выбрать для связи" (сохраняет данные о выбранной претензии и закрашивает строку зеленым цветом).
        /// </summary>
        private void btnChooseForLink_Click(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count == 1)
            {
                Data.Complaints.CurrentDocsRow selectedRow = (Data.Complaints.CurrentDocsRow)((DataRowView)dgvDocs.SelectedRows[0].DataBoundItem).Row;

                if (selectedRow.Doc_Type.Equals(ComplaintsConstants.ComplaintDocTypeBreak, StringComparison.InvariantCultureIgnoreCase))
                {
                    WasLinked = true;
                    LinkedDocID = selectedRow.First_Doc_ID;
                    LinkedDocCaption = string.Format("№ {0} от {1:dd.MM.yyy} (тип претензии - ({2}) {3})",
                        selectedRow.First_Doc_ID,
                        selectedRow.Date_ReceivedFromClient,
                        selectedRow.Doc_Type,
                        selectedRow.Doc_Type_Name);

                    int selectedIndex = dgvDocs.SelectedRows[0].Index;
                    foreach (DataGridViewRow row in dgvDocs.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (row.Index == selectedIndex)
                                cell.Style.BackColor = Color.LawnGreen;
                            else
                                cell.Style.BackColor = dgvDocs.DefaultCellStyle.BackColor;
                        }
                        row.Selected = false;
                    }
                }
                else
                {
                    MessageBox.Show("Для связи можно выбирать только претензии с типом \"(BR) Бой\"", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Обрабатывает изменение выбора претензии в списке.
        /// </summary>
        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDocs.SelectedRows.Count > 0)
            {
                Data.Complaints.CurrentDocsRow selectedRow = (Data.Complaints.CurrentDocsRow)((DataRowView)dgvDocs.SelectedRows[0].DataBoundItem).Row;
                docRequestDetailsTableAdapter.Fill(complaints.DocRequestDetails, SessionID, selectedRow.Doc_ID);
                docRequestDetailsBindingSource.DataSource = complaints.DocRequestDetails;
            }
            else
            {
                docRequestDetailsBindingSource.DataSource = null;
            }
        }
    }
}
