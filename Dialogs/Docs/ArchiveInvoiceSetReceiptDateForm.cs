using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WMSOffice.Dialogs.Complaints;

namespace WMSOffice.Dialogs.Docs
{
    public partial class ArchiveInvoiceSetReceiptDateForm : DialogForm
    {
        /// <summary>
        /// Признак сохранения данных
        /// </summary>
        public bool DataSaved { get; private set; } 

        public ArchiveInvoiceSetReceiptDateForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.btnOK.Location = new Point(1217, 8);
            this.btnCancel.Location = new Point(1307, 8);

            this.btnOK.Text = "Применить";
            this.btnCancel.Text = "Закрыть";
        }

        private void Initialize()
        {
            var headerCell = new DatagridViewCheckBoxHeaderCell(true);
            headerCell.CheckBoxClicked += (s, e) => 
            {
                this.CheckRows(e.IsChecked);
            };
            
            dgvDocs.Columns[dgvcbcSelectDoc.Index].HeaderCell = headerCell;
        }

        private void CheckRows(bool isChecked)
        {
            foreach (DataGridViewRow row in dgvDocs.Rows)
                row.Cells[dgvcbcSelectDoc.Index].Value = isChecked;

            dgvDocs.RefreshEdit();
        }

        public void PrepareDataSource(Data.WH.AI_DocsDataTable dataSource)
        {
            wH.AI_Docs.Merge(dataSource);
            wH.AI_Docs.AcceptChanges();
            //aIDocsBindingSource.DataSource = dataSource;
        }

        private void ArchiveInvoiceSetReceiptDateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                this.ApplyReceiptDate();
                this.SaveChanges();
                e.Cancel = true;
            }
        }

        private void ApplyReceiptDate()
        {
            foreach (DataGridViewRow dgvRow in dgvDocs.Rows)
            {
                var checkedObject = dgvRow.Cells[dgvcbcSelectDoc.Index].Value;
                if (checkedObject != null && checkedObject.Equals(true))
                {
                    var doc = (dgvRow.DataBoundItem as DataRowView).Row as Data.WH.AI_DocsRow;
                    doc.date_from_filial = dtpReceiptDate.Value.Date;
                }
            }
        }

        private void SaveChanges()
        {
            try
            {
                foreach (Data.WH.AI_DocsRow row in wH.AI_Docs.Rows)
                {
                    if (row.RowState == DataRowState.Modified)
                    {
                        try
                        {
                            double docNumber = row.doc;
                            string docType = row.doc_type;
                            DateTime? receiptDate = row.Isdate_from_filialNull() ? (DateTime?)null : row.date_from_filial;

                            if (receiptDate.HasValue)
                            {
                                row.SetnoteNull();

                                aI_DocsTableAdapter.Close(docNumber, docType, receiptDate.Value, 1, this.UserID, null);
                                //row.note = string.Format("Дата поступления из филиала: {0}", receiptDate.Value.ToShortDateString());

                                this.DataSaved = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            //row.Setdate_from_filialNull();
                            row.note = ex.Message;
                        }
                    }
                }
                
                wH.AI_Docs.AcceptChanges();
                this.CheckRows(false);
                (dgvDocs.Columns[dgvcbcSelectDoc.Index].HeaderCell as DatagridViewCheckBoxHeaderCell).ChangeCheckState(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDocs_SelectionChanged(object sender, EventArgs e)
        {
            tbNote.Clear();

            if (dgvDocs.SelectedRows.Count == 0)
                return;

            var doc = (dgvDocs.SelectedRows[0].DataBoundItem as DataRowView).Row as Data.WH.AI_DocsRow;
            tbNote.Text = doc.IsnoteNull() ? string.Empty : doc.note;
        }

        private void dgvDocs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == -1)
                return;

            var checkedObject = dgvDocs.Rows[e.RowIndex].Cells[dgvcbcSelectDoc.Index].Value;
            var isChecked = checkedObject != null && checkedObject.Equals(true);

            var doc = (dgvDocs.Rows[e.RowIndex].DataBoundItem as DataRowView).Row as Data.WH.AI_DocsRow;
            var hasDate = doc.Isdate_from_filialNull() ? false : true;
            var hasNote = doc.IsnoteNull() ? false : !string.IsNullOrEmpty(doc.note);

            Color color = Color.Empty;

            if (isChecked)
            {
                //if (doc.RowState == DataRowState.Unchanged)
                color = Color.FromArgb(209, 255, 117); // строка выбрана
            }
            else
            {
                if (doc.RowState == DataRowState.Modified)
                {
                    color = Color.FromArgb(255, 255, 153); // строка не выбрана, но изменена
                }
                else if (doc.RowState == DataRowState.Unchanged)
                {
                    if (hasDate && hasNote)
                    {
                        color = Color.FromArgb(255, 225, 225); // строка с ошибкой после сохранения
                    }
                    else if (hasDate)
                    {
                        color = Color.LightGray; // строка с датой после сохранения либо изначально
                    }
                    else
                    {
                        color = SystemColors.Window; // строка без даты и не изменена
                    }
                }
            }

            this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = color;
            this.dgvDocs.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = color;
        }

        private void dgvDocs_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDocs.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvDocs.CommitEdit(DataGridViewDataErrorContexts.Commit);


                var checkedObject = dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[dgvcbcSelectDoc.Index].Value;
                var isChecked = checkedObject != null && checkedObject.Equals(true);

                var doc = (dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].DataBoundItem as DataRowView).Row as Data.WH.AI_DocsRow;
                var hasDate = doc.Isdate_from_filialNull() ? false : true;
                var hasNote = doc.IsnoteNull() ? false : !string.IsNullOrEmpty(doc.note);

                Color color = Color.Empty;

                if (isChecked)
                {
                    //if (doc.RowState == DataRowState.Unchanged)
                    color = Color.FromArgb(209, 255, 117); // строка выбрана
                }
                else
                {
                    if (doc.RowState == DataRowState.Modified)
                    {
                        color = Color.FromArgb(255, 255, 153); // строка не выбрана, но изменена
                    }
                    else if (doc.RowState == DataRowState.Unchanged)
                    {
                        if (hasDate && hasNote)
                        {
                            color = Color.FromArgb(255, 225, 225); // строка с ошибкой после сохранения
                        }
                        else if (hasDate)
                        {
                            color = Color.LightGray; // строка с датой после сохранения либо изначально
                        }
                        else
                        {
                            color = SystemColors.Window; // строка без даты и не изменена
                        }
                    }
                }

                // Раскраска
                foreach (DataGridViewColumn column in this.dgvDocs.Columns)
                {
                    this.dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[column.Index].Style.BackColor = color;
                    this.dgvDocs.Rows[this.dgvDocs.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = color;
                }
            }
        }
    }
}
