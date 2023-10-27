using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;
using System.Xml;

namespace WMSOffice.Dialogs.WH
{
    public partial class ReverseOrderForm : DialogForm
    {
        private readonly Data.WH.PurchaseOrdersForDebitRow order = null;

        public ReverseOrderForm()
        {
            InitializeComponent();
        }

        public ReverseOrderForm(Data.WH.PurchaseOrdersForDebitRow pOrder)
            : this()
        {
            order = pOrder;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            btnOK.Location = new Point(1177, 8);
            btnCancel.Location = new Point(1267, 8);

            this.Initialize();   
        }

        private void Initialize()
        {
            this.Text = string.Format("{0} № ({1}){2}", this.Text, order.OrderType, order.OrderNumber);

            dgvItems.Columns[this.isCheckedDataGridViewCheckBoxColumn.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvItems.Columns[this.isCheckedDataGridViewCheckBoxColumn.Index].HeaderCell).CheckBoxClicked += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(ReverseOrderForm_CheckBoxClicked);

            this.LoadOrderItems();

            //(dgvItems.Columns[isCheckedDataGridViewCheckBoxColumn.Index].HeaderCell as DatagridViewCheckBoxHeaderCell).ChangeCheckState(true);

            //foreach (Data.WH.PurchaseOrderDetailsForReverseRow item in wH.PurchaseOrderDetailsForReverse)
            //    item.IsChecked = true;
        }

        void ReverseOrderForm_CheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvItems.Rows)
                    row.Cells[this.isCheckedDataGridViewCheckBoxColumn.Index].Value = e.IsChecked;

                dgvItems.RefreshEdit();
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadOrderItems()
        {
            try
            {
                using (var adapter = new Data.WHTableAdapters.PurchaseOrderDetailsForReverseTableAdapter())
                    adapter.Fill(wH.PurchaseOrderDetailsForReverse, this.UserID, order.OrderNumber, order.OrderType);

                if (dgvItems.Rows.Count > 0)
                    dgvItems.Rows[0].Selected = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReverseOrderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ReverseOrder();
        }

        private bool ReverseOrder()
        {
            try
            {
                var arItems = wH.PurchaseOrderDetailsForReverse.Select(string.Format("{0} = true", wH.PurchaseOrderDetailsForReverse.IsCheckedColumn.Caption));
                if (arItems == null || arItems.Length == 0)
                    throw new Exception("Не выбраны позиции для сторнирования.");

                if (MessageBox.Show("Вы уверены что хотите сторнировать заказ?", "Сторнирование заказа", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
                    return false;

                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml("<Order></Order>");
                XmlElement xRoot = xDoc.DocumentElement;

                XmlAttribute xValue = null;

                #region Lines
                var xLinesElement = xDoc.CreateElement("Lines");
                foreach (Data.WH.PurchaseOrderDetailsForReverseRow item in arItems)
                {
                    var xLineElement = xDoc.CreateElement("Line");

                    xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("line_id"));
                    xValue.Value = item.IsLineIDNull() ? string.Empty : item.LineID.ToString();

                    xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("item_id"));
                    xValue.Value = item.IsItemIDNull() ? string.Empty : item.ItemID.ToString();

                    xValue = xLineElement.Attributes.Append(xDoc.CreateAttribute("batch"));
                    xValue.Value = item.IsBatchNull() ? string.Empty : item.Batch.ToString();

                    xLinesElement.AppendChild(xLineElement);
                }
                xRoot.AppendChild(xLinesElement);
                #endregion

                using (var adapter = new Data.WHTableAdapters.PurchaseOrdersForDebitTableAdapter())
                    adapter.Reverse(this.UserID, order.OrderNumber, order.OrderType, xDoc.InnerXml);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[this.isCheckedDataGridViewCheckBoxColumn.Index].Value);
                foreach (DataGridViewColumn column in this.dgvItems.Columns)
                {
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void dgvItems_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[e.RowIndex].Cells[this.isCheckedDataGridViewCheckBoxColumn.Index].Value);
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }
    }
}
