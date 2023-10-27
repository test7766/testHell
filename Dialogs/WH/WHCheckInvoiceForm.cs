using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.WH
{
    public partial class WHCheckInvoiceForm : Form
    {
        public bool IsWaybillModeEnabled { get; set; }

        public long UserID { get; set; }

        public string RouteBarCode { get; private set; }

        public long? CheckDocID { get; private set; }

        public int DocsCount { get; private set; }

        public int ProcessedDocsCount { get; private set; }

        public List<Data.WH.CheckInvoiceDocsRow> DocsToPrint { get; private set; }

        public WHCheckInvoiceForm()
        {
            InitializeComponent();
            this.DocsToPrint = new List<WMSOffice.Data.WH.CheckInvoiceDocsRow>();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            lblStatistics.Visible = false;

            dgvcIsChecked.Visible = false;
            btnPrint.Visible = false;

             dgvItems.Columns[dgvcIsChecked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvItems.Columns[dgvcIsChecked.Index].HeaderCell).CheckBoxClicked += CheckBoxHeaderCell_OnCheckBoxClicked;

            tbScaner.TextChanged += new EventHandler(tbScaner_TextChanged);
        }

        private void CheckBoxHeaderCell_OnCheckBoxClicked(object sender, WMSOffice.Dialogs.Complaints.DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvItems.Rows)
                row.Cells[dgvcIsChecked.Index].Value = e.IsChecked;

            dgvItems.RefreshEdit();
        }

        void tbScaner_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(RouteBarCode))
                {
                    RouteBarCode = tbScaner.Text;

                    long? checkDocID = null;
                    string driverName = null;

                    #region СОЗДАНИЕ ЗАДАНИЯ НА ПРОВЕРКУ

                    using (var adapter = new Data.WHTableAdapters.CheckInvoiceDocsTableAdapter())
                        adapter.CreateTask(this.UserID, this.RouteBarCode, ref checkDocID, ref driverName, this.IsWaybillModeEnabled);

                    #endregion

                    if ((this.CheckDocID = checkDocID).HasValue)
                    {
                        lblAction.Text = string.Format("Отсканируйте документ из текущего маршрутного листа (Водитель: {0}):", driverName);
                        Text = string.Format("{0} [МЛ № {1}]", Text, RouteBarCode);
                        lblStatistics.Visible = true;
                    }
                    else
                    {
                        RouteBarCode = (string)null;
                        throw new Exception("Неверный номер маршрутного листа.");
                    }
                }
                else
                {
                    #region ПРОВЕРКА СКАНИРУЕМОГО ДОКУМЕНТА

                    int? errorCode = null;
                    string errorMessage = null;

                    using (var adapter = new Data.WHTableAdapters.CheckInvoiceDocsTableAdapter())
                        adapter.CheckDoc(this.UserID, this.CheckDocID, tbScaner.Text, ref errorCode, ref errorMessage, this.IsWaybillModeEnabled);

                    if ((errorCode.HasValue && errorCode.Value != 0) || !string.IsNullOrEmpty(errorMessage))
                        throw new Exception(errorMessage);

                    // документ проверен
                    ProcessedDocsCount++;

                    #endregion
                }

                #region ПОЛУЧЕНИЕ СПИСКА ДОКУМЕНТОВ

                using (var adapter = new Data.WHTableAdapters.CheckInvoiceDocsTableAdapter())
                    adapter.Fill(wH.CheckInvoiceDocs, this.UserID, this.CheckDocID, this.IsWaybillModeEnabled);

                // общее кол-во документов получено при первом обращении
                if (this.DocsCount == 0)
                    this.DocsCount = wH.CheckInvoiceDocs.Rows.Count;

                if (wH.CheckInvoiceDocs.Rows.Count == 0)
                {
                    this.Close();
                    return;
                }
                else
                {
                    dgvItems.Rows[0].Selected = false;
                }

                lblStatistics.Text = string.Format("Документов обработано: {0} из {1}", this.ProcessedDocsCount, this.DocsCount);

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tbScaner.Text = string.Empty;
            tbScaner.Focus();
        }

        /// <summary>
        /// Печать пакета документов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                this.DocsToPrint.Clear();

                foreach (Data.WH.CheckInvoiceDocsRow row in wH.CheckInvoiceDocs.Rows)
                    if (row.isChecked)
                        this.DocsToPrint.Add(row);

                if (DocsToPrint.Count == 0)
                    throw new Exception("Не выбраны документы для печати.");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbScaner.Focus();
            }
        }

        private void dgvItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvItems.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvItems.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[this.dgvItems.CurrentRow.Index].Cells[this.dgvcIsChecked.Index].Value);
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
            bool isChecked = Convert.ToBoolean(this.dgvItems.Rows[e.RowIndex].Cells[this.dgvcIsChecked.Index].Value);
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvItems.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        }
    }
}
