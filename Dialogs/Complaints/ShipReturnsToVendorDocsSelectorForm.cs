using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WMSOffice.Dialogs.Complaints
{
    public partial class ShipReturnsToVendorDocsSelectorForm : DialogForm
    {
        public Data.Complaints.SV_VR_Docs_By_VendorDataTable Docs { get; private set; }

        public string VendorName { get; private set; }

        public bool NeedPrintTTN { get; private set; }

        /// <summary>
        /// Возвращает все отмеченные документы
        /// </summary>
        public List<Data.Complaints.SV_VR_Docs_By_VendorRow> SelectedDocs { get; private set; }

        public ShipReturnsToVendorDocsSelectorForm()
        {
            InitializeComponent();
        }

        public ShipReturnsToVendorDocsSelectorForm(Data.Complaints.SV_VR_Docs_By_VendorDataTable docs, string vendorName, bool needPrintTTN)
            : this()
        {
            this.Docs = docs;
            this.VendorName = vendorName;
            this.NeedPrintTTN = needPrintTTN;
        }

        private void ShipReturnsToVendorPrintForm_Load(object sender, EventArgs e)
        {
            dgvVendorReturns.Columns[this.IsChecked.Index].HeaderCell = new DatagridViewCheckBoxHeaderCell(true);
            ((DatagridViewCheckBoxHeaderCell)dgvVendorReturns.Columns[this.IsChecked.Index].HeaderCell).CheckBoxClicked += new EventHandler<DataGridViewCheckBoxHeaderCellEventArgs>(ComplaintAttachmentsForm_CheckBoxClicked);
        }

        void ComplaintAttachmentsForm_CheckBoxClicked(object sender, DataGridViewCheckBoxHeaderCellEventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvVendorReturns.Rows)
                    row.Cells[this.IsChecked.Index].Value = e.IsChecked;

                dgvVendorReturns.RefreshEdit();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.Initialize();

            this.Text = string.Format("{0} [{1}]", this.Text, this.VendorName);

            this.btnOK.Location = new Point(807, 8);
            this.btnCancel.Location = new Point(897, 8);

            if (this.NeedPrintTTN)
                MessageBox.Show("Не забудьте внести параметры отгрузки\nи распечатать ТТН!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void Initialize()
        {
            try
            {
                complaints.SV_VR_Docs_By_Vendor.Clear();
                complaints.SV_VR_Docs_By_Vendor.Merge(Docs, true);

                foreach (Data.Complaints.SV_VR_Docs_By_VendorRow doc in complaints.SV_VR_Docs_By_Vendor)
                    doc.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvVendorReturns_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvVendorReturns.CurrentCell is DataGridViewCheckBoxCell)
            {
                dgvVendorReturns.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Раскраска
                bool isChecked = Convert.ToBoolean(this.dgvVendorReturns.Rows[this.dgvVendorReturns.CurrentRow.Index].Cells[this.IsChecked.Index].Value);
                foreach (DataGridViewColumn column in this.dgvVendorReturns.Columns)
                {
                    this.dgvVendorReturns.Rows[this.dgvVendorReturns.CurrentRow.Index].Cells[column.Index].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
                    this.dgvVendorReturns.Rows[this.dgvVendorReturns.CurrentRow.Index].Cells[column.Index].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
                }
            }
        }

        private void dgvVendorReturns_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Раскраска
            bool isChecked = Convert.ToBoolean(this.dgvVendorReturns.Rows[e.RowIndex].Cells[this.IsChecked.Index].Value);
            this.dgvVendorReturns.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = isChecked ? Color.FromArgb(209, 255, 117) : SystemColors.Window;
            this.dgvVendorReturns.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.SelectionForeColor = isChecked ? Color.FromArgb(209, 255, 117) : Color.Black;
        
        }

        private void ShipReturnsToVendorPrintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
                e.Cancel = !this.ApplySelection();
        }

        private bool ApplySelection()
        {
            try
            {
                var arDocs = complaints.SV_VR_Docs_By_Vendor.Select(string.Format("{0} = true", complaints.SV_VR_Docs_By_Vendor.IsCheckedColumn.Caption));
                if (arDocs == null || arDocs.Length == 0)
                    throw new Exception("Не выбраны документы.");

                this.SelectedDocs = new List<WMSOffice.Data.Complaints.SV_VR_Docs_By_VendorRow>();
                foreach (Data.Complaints.SV_VR_Docs_By_VendorRow doc in arDocs)
                    this.SelectedDocs.Add(doc);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
