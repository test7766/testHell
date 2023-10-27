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
    /// Диалог для ввода результатов снятия остатков по претензии.
    /// </summary>
    public partial class EnterTakingRemainsResultsForm : DialogForm
    {
        /// <summary>
        /// Строка с общими данными претензии.
        /// </summary>
        private Data.Complaints.CurrentDocsRow DocRow { get; set; }

        /// <summary>
        /// Возвращает / устанавливает идентификатор пользовательской сессии.
        /// </summary>
        private long SessionID { get; set; } 
        
        /// <summary>
        /// Инициализирует новый экземпляр диалога.
        /// </summary>
        /// <param name="docRow">Строка с общими данными претензии.</param>
        /// <param name="sessionID">Идентификатор пользовательской сессии.</param>
        public EnterTakingRemainsResultsForm(Data.Complaints.CurrentDocsRow docRow, long sessionID)
        {
            if (docRow == null)
                throw new ArgumentNullException("docRow");

            InitializeComponent();

            this.DocRow = docRow;
            this.SessionID = sessionID;
            this.btnOK.DialogResult = DialogResult.None;
            this.Text += " по претензии №" + docRow.First_Doc_ID.ToString();
            this.btnCancel.Text = "Закрыть";

            takingRemainsTableAdapter.FillRequests(complaints.TakingRemains, docRow.First_Doc_ID);

            if (complaints.TakingRemains.Rows.Count == 0)
            {
                throw new InvalidOperationException("По данной претензии (" + docRow.First_Doc_ID.ToString() + ") нет активных запросов на снятие остатков.");
            }

            dgvTakingRemainsRequests.Columns[colCheckBox.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell();
            ((DatagridViewCheckBoxHeaderCell)dgvTakingRemainsRequests.Columns[colCheckBox.Index].HeaderCell).CheckBoxClicked += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(CheckBoxHeaderCell_OnCheckBoxClicked);
        }

        /// <summary>
        /// Обрабатывает клик по флажку в заголовке столбца "Отм.".
        /// </summary>
        private void CheckBoxHeaderCell_OnCheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTakingRemainsRequests.Rows)
            {
                row.Cells[colCheckBox.Index].Value = e.IsChecked;
            }
            dgvTakingRemainsRequests.RefreshEdit();
        }

        /// <summary>
        /// Обрабатывает нажатие на кнопку "ОК".
        /// </summary>
        private void btnOK_Click(object sender, EventArgs e)
        {
            List<Data.Complaints.TakingRemainsRow> selectedRows = new List<Data.Complaints.TakingRemainsRow>();
            StringBuilder itemsList = new StringBuilder();
            bool foundWrongQuantity = false;
            foreach (DataGridViewRow r in dgvTakingRemainsRequests.Rows)
            {
                if (r.Cells[colCheckBox.Name].Value != DBNull.Value && r.Cells[colCheckBox.Name].Value != null && (bool)r.Cells[colCheckBox.Name].Value)
                {
                    Data.Complaints.TakingRemainsRow row = (Data.Complaints.TakingRemainsRow)((DataRowView)r.DataBoundItem).Row;
                    if (row.IsQuantity_By_TakingNull() || row.Quantity_By_Taking < 0)
                    {
                        foundWrongQuantity = true;
                        break;
                    }
                    else
                    {
                        selectedRows.Add(row);
                        if (selectedRows.Count <= 20) // чтобы не было очень большого текстового сообщения
                        {
                            itemsList.AppendLine("(" + row.Item_ID.ToString() + ") " + row.Item_Name + ", серия " + row.Vendor_Lot);
                        }
                    }
                }
            }

            if (selectedRows.Count >= 20)
                itemsList.AppendLine("...");

            if (foundWrongQuantity)
            {
                MessageBox.Show("По одной из отмеченных товарных позиций введено некорректное количество!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (selectedRows.Count == 0)
            {
                MessageBox.Show("Для ввода результатов снятия остатков необходимо выбрать (в столбце \"Отм.\") как минимум одну товарную позицию!",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Вы действительно хотите сохранить результаты снятия остатков по выбранным позициям?" + Environment.NewLine +
                Environment.NewLine + itemsList.ToString(), "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    foreach (Data.Complaints.TakingRemainsRow row in selectedRows)
                    {
                        takingRemainsTableAdapter.AddResult(SessionID, DocRow.First_Doc_ID, Convert.ToInt32(row.Item_ID), row.Vendor_Lot, row.Quantity_By_Taking);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Во время добавления запроса на снятие остатков возникла следующая ошибка:" + Environment.NewLine +
                        Environment.NewLine + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                takingRemainsTableAdapter.FillRequests(complaints.TakingRemains, DocRow.First_Doc_ID);
            }
        }
    }
}
